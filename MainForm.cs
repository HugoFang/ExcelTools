using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


public partial class MainForm : Form
{
	/// <summary>
	/// 存储在本地的配置文件
	/// </summary>
	private const string StrConfigFileName = "ExcelToolsConfig.data";
	
	private string _folderPath = "";

	public bool IsCreateTextFile = false;
	public bool IsCreateCSFile = false;
	public string ClientCfgPath;
	public string ClientCSPath;
	public string ServerCfgPath;
	public string ServerCSPath;
	public string BattleCfgPath;
	public string BattleCSPath;


	public MainForm()
	{
		InitializeComponent();
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		_folderPath = Application.StartupPath;

		//读取本地配置
		ReadConfig();

		//刷新控件
		RefreshForm();
	}
	private void SelectButton_Click(object sender, EventArgs e)
	{
		selectFileDialog.InitialDirectory = _folderPath;

		DialogResult result = this.selectFileDialog.ShowDialog();
		if (result == DialogResult.OK)
		{
			fileListBox.Items.Clear();
			int lastIndex = selectFileDialog.FileName.LastIndexOf("\\");
			string folderName = selectFileDialog.FileName.Substring(0, lastIndex);

			for (int i = 0; i < selectFileDialog.SafeFileNames.Length; i++)
			{
				string fileName = selectFileDialog.SafeFileNames[i];
				fileListBox.Items.Add(fileName);
			}

			_folderPath = folderName;
		}
	}
	private void CreateButton_Click(object sender, EventArgs e)
	{
		ExcelData.CreateParams param = new ExcelData.CreateParams();
		param.IsCreateTextFile = IsCreateTextFile;
		param.IsCreateCSFile = IsCreateCSFile;
		param.ClientCfgDir = ClientCfgPath;
		param.ClientCSDir = ClientCSPath;
		param.ServerCfgDir = ServerCfgPath;
		param.ServerCSDir = ServerCSPath;
		param.BattleCfgDir = BattleCfgPath;
		param.BattleCSDir = BattleCSPath;

		string[] filePaths = selectFileDialog.FileNames;
		for (int i = 0; i < filePaths.Length; i++)
		{
			string filePath = filePaths[i];
			ExcelData data = new ExcelData(filePath);
			if(data.Load())
				data.Create(param);

			//Dispose
			data.Dispose();
		}

		//保存本地配置
		SaveConfig();
	}

	private void CreateTextCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		IsCreateTextFile = createTextCheckBox.Checked;
	}
	private void CreateCSCheckBox_CheckedChanged(object sender, EventArgs e)
	{
		IsCreateCSFile = createCSCheckBox.Checked;

		clientFindButton2.Enabled = IsCreateCSFile;
		clientLabelCSDir.Enabled = IsCreateCSFile;

		serverFindButton2.Enabled = IsCreateCSFile;
		serverLabelCSDir.Enabled = IsCreateCSFile;

		battleFindButton2.Enabled = IsCreateCSFile;
		battleLabelCSDir.Enabled = IsCreateCSFile;
	}

	private void ClientFindButton1_Click(object sender, EventArgs e)
	{
		ClientCfgPath = SelectSavePath(ClientCfgPath);
		clientLabelCfgDir.Text = ClientCfgPath;
	}
	private void ClientFindButton2_Click(object sender, EventArgs e)
	{
		ClientCSPath = SelectSavePath(ClientCSPath);
		clientLabelCSDir.Text = ClientCSPath;
	}

	private void ServerFindButton1_Click(object sender, EventArgs e)
	{
		ServerCfgPath = SelectSavePath(ServerCfgPath);
		serverLabelCfgDir.Text = ServerCfgPath;
	}
	private void ServerFindButton2_Click(object sender, EventArgs e)
	{
		ServerCSPath = SelectSavePath(ServerCSPath);
		serverLabelCSDir.Text = ServerCSPath;
	}

	private void BattleFindButton1_Click(object sender, EventArgs e)
	{
		BattleCfgPath = SelectSavePath(BattleCfgPath);
		battleLabelCfgDir.Text = BattleCfgPath;
	}
	private void BattleFindButton2_Click(object sender, EventArgs e)
	{
		BattleCSPath = SelectSavePath(BattleCSPath);
		battleLabelCSDir.Text = BattleCSPath;
	}

	private string SelectSavePath(string defaultPath)
	{
		selectDirDialog.SelectedPath = defaultPath;

		DialogResult result = selectDirDialog.ShowDialog();
		if (result == DialogResult.OK)
		{
			return selectDirDialog.SelectedPath;
		}

		return defaultPath;
	}
	private void ReadConfig()
	{
		string appPath = Application.StartupPath;
		string configPath = Path.Combine(appPath, StrConfigFileName);

		//如果配置文件不存在
		if (!File.Exists(configPath))
		{
			ClientCfgPath = appPath;
			ClientCSPath = appPath;
			ServerCfgPath = appPath;
			ServerCSPath = appPath;
			BattleCfgPath = appPath;
			BattleCSPath = appPath;
			return;
		}

		FileStream fs = new FileStream(configPath, FileMode.Open, FileAccess.Read);
		try
		{
			StreamReader sr = new StreamReader(fs);
			IsCreateTextFile = sr.ReadLine().Contains("true");
			IsCreateCSFile = sr.ReadLine().Contains("true");
			ClientCfgPath = sr.ReadLine();
			ClientCSPath = sr.ReadLine();
			ServerCfgPath = sr.ReadLine();
			ServerCSPath = sr.ReadLine();
			BattleCfgPath = sr.ReadLine();
			BattleCSPath = sr.ReadLine();

			sr.Dispose();
			sr.Close();
		}
		catch (Exception e)
		{
			throw e;
		}
		finally
		{
			fs.Dispose();
			fs.Close();
		}
	}
	private void SaveConfig()
	{
		string appPath = Application.StartupPath;
		string configPath = Path.Combine(appPath, StrConfigFileName);
		FileStream fs = new FileStream(configPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

		try
		{
			StreamWriter sw = new StreamWriter(fs);
			sw.Flush();
			sw.WriteLine(createTextCheckBox.Checked ? "true" : "false");
			sw.WriteLine(createCSCheckBox.Checked ? "true" : "flase");
			sw.WriteLine(ClientCfgPath);
			sw.WriteLine(ClientCSPath);
			sw.WriteLine(ServerCfgPath);
			sw.WriteLine(ServerCSPath);
			sw.WriteLine(BattleCfgPath);
			sw.WriteLine(BattleCSPath);

			sw.Flush();
			sw.Dispose();
			sw.Close();
		}
		catch (Exception e)
		{
			throw e;
		}
		finally
		{
			fs.Dispose();
			fs.Close();
		}
	}
	private void RefreshForm()
	{
		createTextCheckBox.Checked = IsCreateTextFile;
		createCSCheckBox.Checked = IsCreateCSFile;

		clientLabelCfgDir.Text = ClientCfgPath;
		clientLabelCSDir.Text = ClientCSPath;

		serverLabelCfgDir.Text = ServerCfgPath;
		serverLabelCSDir.Text = ServerCSPath;

		battleLabelCfgDir.Text = BattleCfgPath;
		battleLabelCSDir.Text = BattleCSPath;

		CreateCSCheckBox_CheckedChanged(null, null);
	}
}