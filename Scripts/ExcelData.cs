//**************************************************
// Copyright©2018 何冠峰
// Licensed under the MIT license
//**************************************************
using System;
using System.Collections.Generic;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

using System.IO;
using System.Windows.Forms;


public class ExcelData : IDisposable
{
	public class CreateParams
	{
		public bool IsCreateTextFile = false;
		public bool IsCreateCSFile = false;

		public string ClientCfgDir;
		public string ClientCSDir;

		public string ServerCfgDir;
		public string ServerCSDir;

		public string BattleCfgDir;
		public string BattleCSDir;
	}

	/// <summary>
	/// 工作页标记符号
	/// </summary>
	public const string StrSheetLabel = "t_";

	/// <summary>
	/// Excel文件名称
	/// </summary>
	public string ExcelName { get; }

	/// <summary>
	/// Excel文件路径
	/// </summary>
	public string ExcelPath { get; }

	/// <summary>
	/// 工作表列表
	/// </summary>
	private readonly List<SheetData> _sheetDataList = new List<SheetData>();

	private IWorkbook _workbook = null;
	private FileStream _stream = null;


	public ExcelData(string excelPath)
	{
		ExcelPath = excelPath;
		ExcelName = Path.GetFileNameWithoutExtension(ExcelPath);
	}

	/// <summary>
	/// Dispose
	/// </summary>
	public void Dispose()
	{
		if (_stream != null)
		{
			_stream.Close();
			_stream = null;
		}

		if (_workbook != null)
		{
			_workbook.Close();
			_workbook = null;
		}

		_sheetDataList.Clear();
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// 加载
	/// </summary>
	public bool Load()
	{
		try
		{
			_stream = new FileStream(ExcelPath, FileMode.Open, FileAccess.Read);

			if (ExcelPath.IndexOf(".xlsx") > 0)
				_workbook = new XSSFWorkbook(_stream);
			else if (ExcelPath.IndexOf(".xls") > 0)
				_workbook = new HSSFWorkbook(_stream);

			for (int i = 0; i < _workbook.NumberOfSheets; i++)
			{
				ISheet sheet = _workbook.GetSheetAt(i);
				if (sheet.SheetName.StartsWith(StrSheetLabel))
				{
					SheetData sheetData = new SheetData(sheet.SheetName);
					sheetData.Parase(sheet);
					_sheetDataList.Add(sheetData);
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Load Error：{ex}");
			return false;
		}

		//如果没有找到有效的工作页
		if (_sheetDataList.Count == 0)
		{
			MessageBox.Show(string.Format("Not found include 't_' sheet in the excel file : {0}", ExcelName));
			return false;
		}

		return true; //加载成功
	}

	/// <summary>
	/// 生成
	/// </summary>
	/// <param name="createParams">参数</param>
	public bool Create(CreateParams createParams)
	{
		try
		{
			for (int i = 0; i < _sheetDataList.Count; i++)
			{
				CreateInternal(_sheetDataList[i], createParams);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Create Error：{ex}");
			return false;
		}

		MessageBox.Show($" {ExcelName} files successfully created.");
		return true; //生成成功
	}

	/// <summary>
	/// 内部生成方法
	/// </summary>
	private void CreateInternal(SheetData sheet, CreateParams createParams)
	{
		//生成客户端文件
		sheet.CreateLogo = "C";
		if (!string.IsNullOrEmpty(createParams.ClientCfgDir))
			sheet.CreateCfgBytesFile(createParams.ClientCfgDir);
		if (createParams.IsCreateTextFile)
			sheet.CreateCfgTextFile(createParams.ClientCfgDir);
		if (createParams.IsCreateCSFile)
			sheet.CreateCfgCSFile(createParams.ClientCSDir);

		//生成服务器文件
		sheet.CreateLogo = "S";
		if (!string.IsNullOrEmpty(createParams.ServerCfgDir))
			sheet.CreateCfgBytesFile(createParams.ServerCfgDir);
		if (createParams.IsCreateTextFile)
			sheet.CreateCfgTextFile(createParams.ServerCfgDir);
		if (createParams.IsCreateCSFile)
			sheet.CreateCfgCSFile(createParams.ServerCSDir);

		//生成战服文件
		sheet.CreateLogo = "B";
		if (!string.IsNullOrEmpty(createParams.BattleCfgDir))
			sheet.CreateCfgBytesFile(createParams.BattleCfgDir);
		if (createParams.IsCreateTextFile)
			sheet.CreateCfgTextFile(createParams.BattleCfgDir);
		if (createParams.IsCreateCSFile)
			sheet.CreateCfgCSFile(createParams.BattleCSDir);
	}
}