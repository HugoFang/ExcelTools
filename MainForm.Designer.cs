
partial class MainForm
{
	/// <summary>
	/// 必需的设计器变量。
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// 清理所有正在使用的资源。
	/// </summary>
	/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows 窗体设计器生成的代码

	/// <summary>
	/// 设计器支持所需的方法 - 不要修改
	/// 使用代码编辑器修改此方法的内容。
	/// </summary>
	private void InitializeComponent()
	{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.selectFileButton = new System.Windows.Forms.Button();
			this.selectFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.selectDirDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.fileListBox = new System.Windows.Forms.ListBox();
			this.createButton = new System.Windows.Forms.Button();
			this.clientGroupBox = new System.Windows.Forms.GroupBox();
			this.clientFindButton2 = new System.Windows.Forms.Button();
			this.clientFindButton1 = new System.Windows.Forms.Button();
			this.clientLabelCSDir = new System.Windows.Forms.Label();
			this.clientLabelCfgDir = new System.Windows.Forms.Label();
			this.serverGroupBox = new System.Windows.Forms.GroupBox();
			this.serverFindButton2 = new System.Windows.Forms.Button();
			this.serverFindButton1 = new System.Windows.Forms.Button();
			this.serverLabelCSDir = new System.Windows.Forms.Label();
			this.serverLabelCfgDir = new System.Windows.Forms.Label();
			this.battleGroupBox = new System.Windows.Forms.GroupBox();
			this.battleFindButton2 = new System.Windows.Forms.Button();
			this.battleFindButton1 = new System.Windows.Forms.Button();
			this.battleLabelCSDir = new System.Windows.Forms.Label();
			this.battleLabelCfgDir = new System.Windows.Forms.Label();
			this.createTextCheckBox = new System.Windows.Forms.CheckBox();
			this.createCSCheckBox = new System.Windows.Forms.CheckBox();
			this.clientGroupBox.SuspendLayout();
			this.serverGroupBox.SuspendLayout();
			this.battleGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// selectFileButton
			// 
			this.selectFileButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.selectFileButton.Location = new System.Drawing.Point(26, 15);
			this.selectFileButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.selectFileButton.Name = "selectFileButton";
			this.selectFileButton.Size = new System.Drawing.Size(166, 51);
			this.selectFileButton.TabIndex = 0;
			this.selectFileButton.Text = "选择文件";
			this.selectFileButton.UseVisualStyleBackColor = true;
			this.selectFileButton.Click += new System.EventHandler(this.SelectButton_Click);
			// 
			// selectFileDialog
			// 
			this.selectFileDialog.FileName = "excel file";
			this.selectFileDialog.Multiselect = true;
			// 
			// fileListBox
			// 
			this.fileListBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.fileListBox.FormattingEnabled = true;
			this.fileListBox.ItemHeight = 23;
			this.fileListBox.Location = new System.Drawing.Point(218, 15);
			this.fileListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.fileListBox.Name = "fileListBox";
			this.fileListBox.Size = new System.Drawing.Size(746, 326);
			this.fileListBox.TabIndex = 4;
			// 
			// createButton
			// 
			this.createButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.createButton.Location = new System.Drawing.Point(26, 85);
			this.createButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.createButton.Name = "createButton";
			this.createButton.Size = new System.Drawing.Size(166, 54);
			this.createButton.TabIndex = 1;
			this.createButton.Text = "生成";
			this.createButton.UseVisualStyleBackColor = true;
			this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
			// 
			// clientGroupBox
			// 
			this.clientGroupBox.Controls.Add(this.clientFindButton2);
			this.clientGroupBox.Controls.Add(this.clientFindButton1);
			this.clientGroupBox.Controls.Add(this.clientLabelCSDir);
			this.clientGroupBox.Controls.Add(this.clientLabelCfgDir);
			this.clientGroupBox.Location = new System.Drawing.Point(26, 364);
			this.clientGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.clientGroupBox.Name = "clientGroupBox";
			this.clientGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.clientGroupBox.Size = new System.Drawing.Size(939, 128);
			this.clientGroupBox.TabIndex = 6;
			this.clientGroupBox.TabStop = false;
			this.clientGroupBox.Text = "客户端";
			// 
			// clientFindButton2
			// 
			this.clientFindButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.clientFindButton2.Location = new System.Drawing.Point(8, 81);
			this.clientFindButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.clientFindButton2.Name = "clientFindButton2";
			this.clientFindButton2.Size = new System.Drawing.Size(51, 29);
			this.clientFindButton2.TabIndex = 3;
			this.clientFindButton2.Text = "Find";
			this.clientFindButton2.UseVisualStyleBackColor = true;
			this.clientFindButton2.Click += new System.EventHandler(this.ClientFindButton2_Click);
			// 
			// clientFindButton1
			// 
			this.clientFindButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.clientFindButton1.Location = new System.Drawing.Point(8, 42);
			this.clientFindButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.clientFindButton1.Name = "clientFindButton1";
			this.clientFindButton1.Size = new System.Drawing.Size(51, 29);
			this.clientFindButton1.TabIndex = 2;
			this.clientFindButton1.Text = "Find";
			this.clientFindButton1.UseVisualStyleBackColor = true;
			this.clientFindButton1.Click += new System.EventHandler(this.ClientFindButton1_Click);
			// 
			// clientLabelCSDir
			// 
			this.clientLabelCSDir.AutoSize = true;
			this.clientLabelCSDir.Location = new System.Drawing.Point(66, 81);
			this.clientLabelCSDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.clientLabelCSDir.Name = "clientLabelCSDir";
			this.clientLabelCSDir.Size = new System.Drawing.Size(82, 24);
			this.clientLabelCSDir.TabIndex = 1;
			this.clientLabelCSDir.Text = "脚本路径";
			// 
			// clientLabelCfgDir
			// 
			this.clientLabelCfgDir.AutoSize = true;
			this.clientLabelCfgDir.Location = new System.Drawing.Point(66, 42);
			this.clientLabelCfgDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.clientLabelCfgDir.Name = "clientLabelCfgDir";
			this.clientLabelCfgDir.Size = new System.Drawing.Size(82, 24);
			this.clientLabelCfgDir.TabIndex = 0;
			this.clientLabelCfgDir.Text = "配置路径";
			// 
			// serverGroupBox
			// 
			this.serverGroupBox.Controls.Add(this.serverFindButton2);
			this.serverGroupBox.Controls.Add(this.serverFindButton1);
			this.serverGroupBox.Controls.Add(this.serverLabelCSDir);
			this.serverGroupBox.Controls.Add(this.serverLabelCfgDir);
			this.serverGroupBox.Location = new System.Drawing.Point(26, 511);
			this.serverGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.serverGroupBox.Name = "serverGroupBox";
			this.serverGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.serverGroupBox.Size = new System.Drawing.Size(939, 128);
			this.serverGroupBox.TabIndex = 7;
			this.serverGroupBox.TabStop = false;
			this.serverGroupBox.Text = "服务器";
			// 
			// serverFindButton2
			// 
			this.serverFindButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.serverFindButton2.Location = new System.Drawing.Point(8, 81);
			this.serverFindButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.serverFindButton2.Name = "serverFindButton2";
			this.serverFindButton2.Size = new System.Drawing.Size(51, 29);
			this.serverFindButton2.TabIndex = 5;
			this.serverFindButton2.Text = "Find";
			this.serverFindButton2.UseVisualStyleBackColor = true;
			this.serverFindButton2.Click += new System.EventHandler(this.ServerFindButton2_Click);
			// 
			// serverFindButton1
			// 
			this.serverFindButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.serverFindButton1.Location = new System.Drawing.Point(8, 42);
			this.serverFindButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.serverFindButton1.Name = "serverFindButton1";
			this.serverFindButton1.Size = new System.Drawing.Size(51, 29);
			this.serverFindButton1.TabIndex = 4;
			this.serverFindButton1.Text = "Find";
			this.serverFindButton1.UseVisualStyleBackColor = true;
			this.serverFindButton1.Click += new System.EventHandler(this.ServerFindButton1_Click);
			// 
			// serverLabelCSDir
			// 
			this.serverLabelCSDir.AutoSize = true;
			this.serverLabelCSDir.Location = new System.Drawing.Point(66, 81);
			this.serverLabelCSDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.serverLabelCSDir.Name = "serverLabelCSDir";
			this.serverLabelCSDir.Size = new System.Drawing.Size(82, 24);
			this.serverLabelCSDir.TabIndex = 1;
			this.serverLabelCSDir.Text = "脚本路径";
			// 
			// serverLabelCfgDir
			// 
			this.serverLabelCfgDir.AutoSize = true;
			this.serverLabelCfgDir.Location = new System.Drawing.Point(66, 42);
			this.serverLabelCfgDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.serverLabelCfgDir.Name = "serverLabelCfgDir";
			this.serverLabelCfgDir.Size = new System.Drawing.Size(82, 24);
			this.serverLabelCfgDir.TabIndex = 0;
			this.serverLabelCfgDir.Text = "配置路径";
			// 
			// battleGroupBox
			// 
			this.battleGroupBox.Controls.Add(this.battleFindButton2);
			this.battleGroupBox.Controls.Add(this.battleFindButton1);
			this.battleGroupBox.Controls.Add(this.battleLabelCSDir);
			this.battleGroupBox.Controls.Add(this.battleLabelCfgDir);
			this.battleGroupBox.Location = new System.Drawing.Point(26, 660);
			this.battleGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.battleGroupBox.Name = "battleGroupBox";
			this.battleGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.battleGroupBox.Size = new System.Drawing.Size(939, 128);
			this.battleGroupBox.TabIndex = 8;
			this.battleGroupBox.TabStop = false;
			this.battleGroupBox.Text = "战服";
			// 
			// battleFindButton2
			// 
			this.battleFindButton2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.battleFindButton2.Location = new System.Drawing.Point(8, 78);
			this.battleFindButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.battleFindButton2.Name = "battleFindButton2";
			this.battleFindButton2.Size = new System.Drawing.Size(51, 29);
			this.battleFindButton2.TabIndex = 6;
			this.battleFindButton2.Text = "Find";
			this.battleFindButton2.UseVisualStyleBackColor = true;
			this.battleFindButton2.Click += new System.EventHandler(this.BattleFindButton2_Click);
			// 
			// battleFindButton1
			// 
			this.battleFindButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.battleFindButton1.Location = new System.Drawing.Point(8, 40);
			this.battleFindButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.battleFindButton1.Name = "battleFindButton1";
			this.battleFindButton1.Size = new System.Drawing.Size(51, 29);
			this.battleFindButton1.TabIndex = 5;
			this.battleFindButton1.Text = "Find";
			this.battleFindButton1.UseVisualStyleBackColor = true;
			this.battleFindButton1.Click += new System.EventHandler(this.BattleFindButton1_Click);
			// 
			// battleLabelCSDir
			// 
			this.battleLabelCSDir.AutoSize = true;
			this.battleLabelCSDir.Location = new System.Drawing.Point(66, 78);
			this.battleLabelCSDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.battleLabelCSDir.Name = "battleLabelCSDir";
			this.battleLabelCSDir.Size = new System.Drawing.Size(82, 24);
			this.battleLabelCSDir.TabIndex = 1;
			this.battleLabelCSDir.Text = "脚本路径";
			// 
			// battleLabelCfgDir
			// 
			this.battleLabelCfgDir.AutoSize = true;
			this.battleLabelCfgDir.Location = new System.Drawing.Point(66, 40);
			this.battleLabelCfgDir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.battleLabelCfgDir.Name = "battleLabelCfgDir";
			this.battleLabelCfgDir.Size = new System.Drawing.Size(82, 24);
			this.battleLabelCfgDir.TabIndex = 0;
			this.battleLabelCfgDir.Text = "配置路径";
			// 
			// createTextCheckBox
			// 
			this.createTextCheckBox.AutoSize = true;
			this.createTextCheckBox.Location = new System.Drawing.Point(49, 170);
			this.createTextCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.createTextCheckBox.Name = "createTextCheckBox";
			this.createTextCheckBox.Size = new System.Drawing.Size(140, 28);
			this.createTextCheckBox.TabIndex = 2;
			this.createTextCheckBox.Text = "生成比对文本";
			this.createTextCheckBox.UseVisualStyleBackColor = true;
			this.createTextCheckBox.CheckedChanged += new System.EventHandler(this.CreateTextCheckBox_CheckedChanged);
			// 
			// createCSCheckBox
			// 
			this.createCSCheckBox.AutoSize = true;
			this.createCSCheckBox.Location = new System.Drawing.Point(49, 208);
			this.createCSCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.createCSCheckBox.Name = "createCSCheckBox";
			this.createCSCheckBox.Size = new System.Drawing.Size(104, 28);
			this.createCSCheckBox.TabIndex = 3;
			this.createCSCheckBox.Text = "生成脚本";
			this.createCSCheckBox.UseVisualStyleBackColor = true;
			this.createCSCheckBox.CheckedChanged += new System.EventHandler(this.CreateCSCheckBox_CheckedChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(980, 828);
			this.Controls.Add(this.createCSCheckBox);
			this.Controls.Add(this.createTextCheckBox);
			this.Controls.Add(this.battleGroupBox);
			this.Controls.Add(this.serverGroupBox);
			this.Controls.Add(this.clientGroupBox);
			this.Controls.Add(this.createButton);
			this.Controls.Add(this.fileListBox);
			this.Controls.Add(this.selectFileButton);
			this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "MainForm";
			this.Text = "ExcelTools";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.clientGroupBox.ResumeLayout(false);
			this.clientGroupBox.PerformLayout();
			this.serverGroupBox.ResumeLayout(false);
			this.serverGroupBox.PerformLayout();
			this.battleGroupBox.ResumeLayout(false);
			this.battleGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

	}

	#endregion
	
	private System.Windows.Forms.Button selectFileButton;
	private System.Windows.Forms.OpenFileDialog selectFileDialog;
	private System.Windows.Forms.FolderBrowserDialog selectDirDialog;
	private System.Windows.Forms.ListBox fileListBox;
	private System.Windows.Forms.Button createButton;
	private System.Windows.Forms.GroupBox clientGroupBox;
	private System.Windows.Forms.Label clientLabelCSDir;
	private System.Windows.Forms.Label clientLabelCfgDir;
	private System.Windows.Forms.GroupBox serverGroupBox;
	private System.Windows.Forms.Label serverLabelCSDir;
	private System.Windows.Forms.Label serverLabelCfgDir;
	private System.Windows.Forms.GroupBox battleGroupBox;
	private System.Windows.Forms.Label battleLabelCSDir;
	private System.Windows.Forms.Label battleLabelCfgDir;
	private System.Windows.Forms.Button clientFindButton2;
	private System.Windows.Forms.Button clientFindButton1;
	private System.Windows.Forms.Button serverFindButton2;
	private System.Windows.Forms.Button serverFindButton1;
	private System.Windows.Forms.Button battleFindButton2;
	private System.Windows.Forms.Button battleFindButton1;
	private System.Windows.Forms.CheckBox createTextCheckBox;
	private System.Windows.Forms.CheckBox createCSCheckBox;
}