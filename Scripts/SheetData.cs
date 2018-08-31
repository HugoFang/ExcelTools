//**************************************************
// Copyright©2018 何冠峰
// Licensed under the MIT license
//**************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

using MotionEngine.IO;
using MotionEngine.Res;

public class SheetData
{
	private class HeadWrapper
	{
		public int CellNum { get; }
		public string Name { get; }
		public string Type { get; }
		public string TypeEx { get; }
		public string Logo { get; }
		public bool IsEmpty { get; }

		public HeadWrapper(int cellNum, string name, string type, string typeEx, string logo)
		{
			CellNum = cellNum;
			Name = name;
			Type = type;
			TypeEx = typeEx;
			Logo = logo;

			//名字为空代表为策划备注列
			IsEmpty = string.IsNullOrEmpty(name);
		}
	}
	private class TableWrapper
	{
		public int RowNum { get; }
		public IRow Row { get; }

		public TableWrapper(int rowNum, IRow row)
		{
			RowNum = rowNum;
			Row = row;
		}
	}

	/// <summary>
	/// 文件标记
	/// </summary>
	private const short HEAD_MARK = 0x2B2B;

	/// <summary>
	/// ID列名称
	/// </summary>
	private const string StrHeadId = "id";

	/// <summary>
	/// 结束符号
	/// </summary>
	private const string StrTableEnd = "//end";


	/// <summary>
	/// 工作页完整名称
	/// </summary>
	public string SheetName { get; }

	/// <summary>
	/// 表格的类型名称
	/// </summary>
	public string TypeName { get; }

	/// <summary>
	/// 生成标识符号
	/// </summary>
	public string CreateLogo { get; set; }

	private readonly List<HeadWrapper> _heads = new List<HeadWrapper>();
	private readonly List<TableWrapper> _tables = new List<TableWrapper>();


	public SheetData(string sheetName)
	{
		SheetName = sheetName;
		TypeName = ToUpperFirstChar(SheetName.Replace("t_", ""));
	}

	/// <summary>
	/// 解析
	/// </summary>
	/// <param name="sheet"></param>
	public void Parase(ISheet sheet)
	{
		int firstRowNum = sheet.FirstRowNum;

		//数据头一共6行
		IRow row1 = sheet.GetRow(firstRowNum);
		IRow row2 = sheet.GetRow(++firstRowNum);
		IRow row3 = sheet.GetRow(++firstRowNum);
		IRow row4 = sheet.GetRow(++firstRowNum);
		++firstRowNum; //无用行
		++firstRowNum; //无用行

		for (int cellNum = row1.FirstCellNum; cellNum < row1.LastCellNum; cellNum++)
		{
			ICell row1cell = row1.GetCell(cellNum);
			ICell row2cell = row2.GetCell(cellNum);
			ICell row3cell = row3.GetCell(cellNum);
			ICell row4cell = row4.GetCell(cellNum);

			//检测重复的列
			string headName = row1cell.StringCellValue;
			if (string.IsNullOrEmpty(headName) == false)
			{
				if (IsContainsHead(headName))
				{
					throw new Exception($"Have same head name : {headName}");
				}
			}

			//创建Wrapper
			string name = row1cell.StringCellValue;
			string type = row2cell.StringCellValue;
			string typeEx = row3cell.StringCellValue;
			string logo = row4cell.StringCellValue;
			HeadWrapper wrapper = new HeadWrapper(cellNum, name, type, typeEx, logo);
			_heads.Add(wrapper);
		}

		//如果没有ID列
		if (IsContainsHead(StrHeadId) == false)
		{
			throw new Exception("Not found 'id' cell.");
		}

		int tableBeginRowNum = ++firstRowNum; //Table初始行
		for (int rowNum = tableBeginRowNum; rowNum <= sheet.LastRowNum; rowNum++)
		{
			IRow row = sheet.GetRow(rowNum);

			//检测结尾行
			if (IsEndRow(row))
				break;

			//创建Wrapper
			TableWrapper wrapper = new TableWrapper(rowNum, row);
			_tables.Add(wrapper);
		}
	}

	/// <summary>
	/// 是否是结束行
	/// </summary>
	private bool IsEndRow(IRow row)
	{
		ICell firstCell = row.GetCell(row.FirstCellNum);
		string value = GetTableCellValue(firstCell);
		return value.ToLower().Contains(StrTableEnd);
	}

	/// <summary>
	/// 是否包含该头
	/// </summary>
	private bool IsContainsHead(string headName)
	{
		for (int i = 0; i < _heads.Count; i++)
		{
			if (_heads[i].Name == headName)
				return true;
		}
		return false;
	}

	/// <summary>
	/// 获取头封装
	/// </summary>
	private HeadWrapper GetHead(int cellNum)
	{
		for (int i = 0; i < _heads.Count; i++)
		{
			if (_heads[i].CellNum == cellNum)
				return _heads[i];
		}
		return null;
	}

	#region 生成字节文件
	public void CreateCfgBytesFile(string path)
	{
		MoByteBuffer byteBuffer = new MoByteBuffer(ResDefine.CfgStreamMaxLen);
		MoByteBuffer tableBuffer = new MoByteBuffer(ResDefine.TabStreamMaxLen);

		for (int i = 0; i < _tables.Count; i++)
		{
			//写入行标记
			byteBuffer.WriteShort(ResDefine.TabStreamHead);
			//清空缓存
			tableBuffer.Clear();

			//写入数据
			IRow row = _tables[i].Row;
			for (int cellNum = row.FirstCellNum; cellNum < row.LastCellNum; cellNum++)
			{
				ICell cell = row.GetCell(cellNum);
				string value = GetTableCellValue(cell);
				HeadWrapper head = GetHead(cellNum);
				WriteCell(tableBuffer, head, value);
			}

			//检测数据大小有效性
			int tabSize = tableBuffer.ReadableBytes();
			if (tabSize == 0)
			{
				throw new Exception("Table size is zero.");
			}

			//写入到总缓存
			byteBuffer.WriteInt(tabSize);
			byteBuffer.WriteBytes(tableBuffer.ReadBytes(tabSize));
		}

		//创建文件
		string filePath = GetSaveFileFullPath(path, ".bytes");
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
		{
			byte[] data = byteBuffer.Buf;
			int length = byteBuffer.ReadableBytes();
			fs.Write(data, 0, length);
		}
	}
	private void WriteCell(MoByteBuffer buffer, HeadWrapper head, string value)
	{
		if (head.IsEmpty || head.Logo.Contains(CreateLogo) == false)
			return;

		//int
		if (head.Type == "int")
		{
			buffer.WriteInt(MoStringConvert.StringToValue<int>(value));
		}
		else if (head.Type == "List<int>")
		{
			buffer.WriteListInt(MoStringConvert.StringToValueList<int>(value, '_'));
		}

		//long
		else if (head.Type == "long")
		{
			buffer.WriteLong(MoStringConvert.StringToValue<long>(value));
		}
		else if (head.Type == "List<long>")
		{
			buffer.WriteListLong(MoStringConvert.StringToValueList<long>(value, '_'));
		}

		//float
		else if (head.Type == "float")
		{
			buffer.WriteFloat(MoStringConvert.StringToValue<float>(value));
		}
		else if (head.Type == "List<float>")
		{
			buffer.WriteListFloat(MoStringConvert.StringToValueList<float>(value, '_'));
		}

		//double
		else if (head.Type == "double")
		{
			buffer.WriteDouble(MoStringConvert.StringToValue<double>(value));
		}
		else if (head.Type == "List<double>")
		{
			buffer.WriteListDouble(MoStringConvert.StringToValueList<double>(value, '_'));
		}

		//bool
		else if (head.Type == "bool")
		{
			buffer.WriteBool(MoStringConvert.StringToBool(value));
		}

		//string
		else if (head.Type == "string")
		{
			buffer.WriteUTF(value);
		}

		//enum
		else if (head.Type == "enumIndex")
		{
			buffer.WriteInt(MoStringConvert.StringToValue<int>(value));
		}
		else if (head.Type == "enumName")
		{
			buffer.WriteUTF(value);
		}

		//wrapper
		else if (head.Type == "wrapper")
		{
			buffer.WriteUTF(value);
		}
		else if (head.Type == "List<wrapper>")
		{
			buffer.WriteUTF(value);
		}

		else
		{
			throw new Exception($"Not support head type {head.Type}");
		}
	}
	#endregion

	#region 生成文本文件
	public void CreateCfgTextFile(string path)
	{
		string[] lines = GetTextLines();
		if (lines.Length == 0)
		{
			throw new Exception("Write text file lines is empty.");
		}

		//创建文件
		string filePath = GetSaveFileFullPath(path, ".txt");
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
		using (StreamWriter sw = new StreamWriter(fs))
		{
			for (int i = 0; i < lines.Length; i++)
			{
				sw.WriteLine(lines[i]);
			}
		}
	}
	private string[] GetTextLines()
	{
		List<string> allLines = new List<string>();

		StringBuilder sb = new StringBuilder();

		//写入表头
		sb.Clear();
		for (int i = 0; i < _heads.Count; i++)
		{
			HeadWrapper head = _heads[i];
			if (head.IsEmpty) continue;
			if (head.Logo.Contains(CreateLogo))
			{
				sb.Append(head.Name);
				sb.Append("\t");
			}
		}
		allLines.Add(sb.ToString());

		//写入表头
		sb.Clear();
		for (int i = 0; i < _heads.Count; i++)
		{
			HeadWrapper head = _heads[i];
			if (head.IsEmpty) continue;
			if (head.Logo.Contains(CreateLogo))
			{
				sb.Append(head.Type);
				sb.Append("\t");
			}
		}
		allLines.Add(sb.ToString());

		//写入数据
		for (int i = 0; i < _tables.Count; i++)
		{
			sb.Clear();
			TableWrapper table = _tables[i];
			for (int j = 0; j < _heads.Count; j++)
			{
				HeadWrapper head = _heads[j];
				if (head.IsEmpty) continue;
				if (head.Logo.Contains(CreateLogo))
				{
					ICell cell = table.Row.GetCell(head.CellNum);
					sb.Append(GetTableCellValue(cell));
					sb.Append("\t");
				}
			}
			allLines.Add(sb.ToString());
		}

		return allLines.ToArray();
	}
	#endregion

	#region 生成脚本文件
	public void CreateCfgCSFile(string path)
	{
		string filePath = GetSaveFileFullPath(path, ".cs");
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
		using (StreamWriter sw = new StreamWriter(fs))
		{
			WriteUsing(sw);

			//Tab类
			WriteTabCalss(sw);
			sw.WriteLine("{");
			WriteTabClassMember(sw);
			sw.WriteLine();
			WriteTabClassFunction(sw);
			sw.WriteLine("}");
			sw.WriteLine();

			//Cfg类
			WriteCfgPortal(sw);
			WriteCfgClass(sw);
			sw.WriteLine("{");
			WriteCfgClassFunction(sw);
			sw.WriteLine("}");
		}
	}
	private void WriteUsing(StreamWriter sw)
	{
		sw.WriteLine("using MotionEngine;");
		sw.WriteLine("using System.Collections.Generic;");
		sw.WriteLine();
	}
	private void WriteTabCalss(StreamWriter sw)
	{
		sw.WriteLine($"public class Cfg{TypeName}Tab : MoCfgTab");
	}
	private void WriteTabClassMember(StreamWriter sw)
	{
		string tChar = "\t";
		string protectedChar = " { protected set; get; }";

		for (int i = 0; i < _heads.Count; i++)
		{
			HeadWrapper head = _heads[i];

			if (head.IsEmpty || head.Logo.Contains(CreateLogo) == false)
				continue;

			//跳过ID
			if (head.Name == StrHeadId)
				continue;

			//变量名称首字母大写
			string headName = ToUpperFirstChar(head.Name);

			if (head.Type == "int" || head.Type == "long" || head.Type == "float" || head.Type == "double" ||
				head.Type == "List<int>" || head.Type == "List<long>" || head.Type == "List<float>" || head.Type == "List<double>" ||
				head.Type == "bool" || head.Type == "string")
			{
				sw.WriteLine(tChar + $"public {head.Type} " + headName + protectedChar);
			}
			else if (head.Type == "enumIndex" || head.Type == "enumName" || head.Type == "wrapper")
			{
				sw.WriteLine(tChar + $"public {head.TypeEx} " + headName + protectedChar);
			}
			else if (head.Type == "List<wrapper>")
			{
				sw.WriteLine(tChar + $"public List<{head.TypeEx}> " + headName + protectedChar);
			}
			else
			{
				throw new Exception($"Not support head type {head.Type}");
			}
		}
	}
	private void WriteTabClassFunction(StreamWriter sw)
	{
		string tChar = "\t";
		string tTwoChar = "\t\t";

		sw.WriteLine(tChar + "public override void ReadByte(MoByteBuffer byteBuf)");
		sw.WriteLine(tChar + "{");

		for (int i = 0; i < _heads.Count; i++)
		{
			HeadWrapper head = _heads[i];

			if (head.IsEmpty || head.Logo.Contains(CreateLogo) == false)
				continue;

			//HashCode
			if (head.Name == StrHeadId && head.Type == "string")
			{
				sw.WriteLine(tTwoChar + $"{ToUpperFirstChar(head.Name)} = byteBuf.ReadUTF().GetHashCode();");
				continue;
			}

			//变量名称首字母大写
			string headName = ToUpperFirstChar(head.Name);

			if (head.Type == "int")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadInt();");
			}
			else if (head.Type == "long")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadLong();");
			}
			else if (head.Type == "float")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadFloat();");
			}
			else if (head.Type == "double")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadDouble();");
			}
			else if (head.Type == "List<int>")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadListInt();");
			}
			else if (head.Type == "List<long>")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadListLong();");
			}
			else if (head.Type == "List<float>")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadListFloat();");
			}
			else if (head.Type == "List<double>")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadListDouble();");
			}
			else if (head.Type == "bool")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadBool();");
			}
			else if (head.Type == "string")
			{
				sw.WriteLine(tTwoChar + $"{headName} = byteBuf.ReadUTF();");
			}
			else if (head.Type == "enumIndex")
			{
				sw.WriteLine(tTwoChar + $"{headName} = MoStringConvert.IndexToEnum<{head.TypeEx}>(byteBuf.ReadInt());");
			}
			else if (head.Type == "enumName")
			{
				sw.WriteLine(tTwoChar + $"{headName} = MoStringConvert.NameToEnum<{head.TypeEx}>(byteBuf.ReadUTF());");
			}
			else if (head.Type == "wrapper")
			{
				sw.WriteLine(tTwoChar + $"{headName} = {head.TypeEx}.Parse(byteBuf);");
			}
			else if (head.Type == "List<wrapper>")
			{
				sw.WriteLine(tTwoChar + $"{headName} = {head.TypeEx}.ParseList(byteBuf);");
			}
			else
			{
				throw new Exception($"Not support head type {head.Type}");
			}
		}

		sw.WriteLine(tChar + "}");
	}
	private void WriteCfgPortal(StreamWriter sw)
	{
		sw.WriteLine($"[ConfigPortal((int)EConfigType.{TypeName})]");
	}
	private void WriteCfgClass(StreamWriter sw)
	{
		sw.WriteLine($"public partial class Cfg{TypeName} : MoAssetConfig");
	}
	private void WriteCfgClassFunction(StreamWriter sw)
	{
		string tChar = "\t";
		string tTwoChar = "\t\t";

		sw.WriteLine(tChar + "protected override MoCfgTab ReadTab(MoByteBuffer byteBuffer)");
		sw.WriteLine(tChar + "{");
		sw.WriteLine(tTwoChar + $"Cfg{TypeName}Tab tab = new Cfg{TypeName}Tab" + "{};");
		sw.WriteLine(tTwoChar + "tab.ReadByte(byteBuffer);");
		sw.WriteLine(tTwoChar + "return tab;");
		sw.WriteLine(tChar + "}");
	}
	#endregion

	/// <summary>
	/// 获取格子值
	/// </summary>
	private string GetTableCellValue(ICell cell)
	{
		if (cell.CellType == CellType.Numeric)
		{
			return cell.NumericCellValue.ToString();
		}
		else if (cell.CellType == CellType.String)
		{
			return cell.StringCellValue;
		}
		else
		{
			throw new Exception($"Not support table cell type {cell.CellType}");
		}
	}

	/// <summary>
	/// 首字母大写
	/// </summary>
	private string ToUpperFirstChar(string str)
	{
		return char.ToUpper(str[0]) + str.Substring(1);
	}

	/// <summary>
	/// 获取存储文件完整的路径
	/// </summary>
	/// <param name="path">路径</param>
	/// <param name="fileExtension">文件格式</param>
	private string GetSaveFileFullPath(string path, string fileExtension)
	{
		return path + Path.DirectorySeparatorChar + TypeName + fileExtension;
	}
}