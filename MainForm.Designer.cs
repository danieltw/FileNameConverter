namespace FileNameConverter
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.ckbIncludeSubFolder = new System.Windows.Forms.CheckBox();
            this.tlpExecuteStatus = new System.Windows.Forms.TableLayoutPanel();
            this.labExecuteStatus = new System.Windows.Forms.Label();
            this.pgbExecuteStatus = new System.Windows.Forms.ProgressBar();
            this.labExecuteFiles = new System.Windows.Forms.Label();
            this.labFileSP = new System.Windows.Forms.Label();
            this.labTotalFiles = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.tlpFileExtension = new System.Windows.Forms.TableLayoutPanel();
            this.txtAddFileExt = new System.Windows.Forms.TextBox();
            this.btnAddFileExt = new System.Windows.Forms.Button();
            this.labAddFileExt = new System.Windows.Forms.Label();
            this.dgvFileExt = new System.Windows.Forms.DataGridView();
            this.colFileExtensionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ckbConvertFolder = new System.Windows.Forms.CheckBox();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.dgvFileList = new System.Windows.Forms.DataGridView();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModifyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirectoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.dlgSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgSelectFile = new System.Windows.Forms.OpenFileDialog();
            this.tlpMain.SuspendLayout();
            this.tlpExecuteStatus.SuspendLayout();
            this.tlpFileExtension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileExt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMain.Controls.Add(this.btnAddFolder, 1, 0);
            this.tlpMain.Controls.Add(this.btnAddFile, 1, 1);
            this.tlpMain.Controls.Add(this.btnClearList, 1, 2);
            this.tlpMain.Controls.Add(this.btnExecute, 1, 4);
            this.tlpMain.Controls.Add(this.ckbIncludeSubFolder, 1, 6);
            this.tlpMain.Controls.Add(this.tlpExecuteStatus, 0, 6);
            this.tlpMain.Controls.Add(this.tlpFileExtension, 1, 5);
            this.tlpMain.Controls.Add(this.ckbConvertFolder, 1, 3);
            this.tlpMain.Controls.Add(this.spcMain, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 7;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(924, 511);
            this.tlpMain.TabIndex = 0;
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFolder.Font = new System.Drawing.Font("新細明體", 10F);
            this.btnAddFolder.Location = new System.Drawing.Point(776, 2);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(146, 31);
            this.btnAddFolder.TabIndex = 0;
            this.btnAddFolder.Text = "新增資料夾";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFile.Font = new System.Drawing.Font("新細明體", 10F);
            this.btnAddFile.Location = new System.Drawing.Point(776, 37);
            this.btnAddFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(146, 31);
            this.btnAddFile.TabIndex = 1;
            this.btnAddFile.Text = "新增檔案";
            this.btnAddFile.UseVisualStyleBackColor = true;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Font = new System.Drawing.Font("新細明體", 10F);
            this.btnClearList.Location = new System.Drawing.Point(776, 72);
            this.btnClearList.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(146, 31);
            this.btnClearList.TabIndex = 2;
            this.btnClearList.Text = "全部清除";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Font = new System.Drawing.Font("新細明體", 10F, System.Drawing.FontStyle.Bold);
            this.btnExecute.ForeColor = System.Drawing.Color.Blue;
            this.btnExecute.Location = new System.Drawing.Point(776, 148);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(2);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(146, 45);
            this.btnExecute.TabIndex = 3;
            this.btnExecute.Text = "執行轉換";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // ckbIncludeSubFolder
            // 
            this.ckbIncludeSubFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbIncludeSubFolder.AutoSize = true;
            this.ckbIncludeSubFolder.Location = new System.Drawing.Point(777, 490);
            this.ckbIncludeSubFolder.Name = "ckbIncludeSubFolder";
            this.ckbIncludeSubFolder.Size = new System.Drawing.Size(144, 16);
            this.ckbIncludeSubFolder.TabIndex = 4;
            this.ckbIncludeSubFolder.Text = "搜尋時包含子資料夾";
            this.ckbIncludeSubFolder.UseVisualStyleBackColor = true;
            this.ckbIncludeSubFolder.Click += new System.EventHandler(this.CheckBox_Click);
            // 
            // tlpExecuteStatus
            // 
            this.tlpExecuteStatus.ColumnCount = 6;
            this.tlpExecuteStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpExecuteStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpExecuteStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpExecuteStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpExecuteStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpExecuteStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpExecuteStatus.Controls.Add(this.labExecuteStatus, 1, 0);
            this.tlpExecuteStatus.Controls.Add(this.pgbExecuteStatus, 2, 0);
            this.tlpExecuteStatus.Controls.Add(this.labExecuteFiles, 3, 0);
            this.tlpExecuteStatus.Controls.Add(this.labFileSP, 4, 0);
            this.tlpExecuteStatus.Controls.Add(this.labTotalFiles, 5, 0);
            this.tlpExecuteStatus.Controls.Add(this.btnLog, 0, 0);
            this.tlpExecuteStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpExecuteStatus.Location = new System.Drawing.Point(0, 486);
            this.tlpExecuteStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlpExecuteStatus.Name = "tlpExecuteStatus";
            this.tlpExecuteStatus.RowCount = 1;
            this.tlpExecuteStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpExecuteStatus.Size = new System.Drawing.Size(774, 25);
            this.tlpExecuteStatus.TabIndex = 6;
            // 
            // labExecuteStatus
            // 
            this.labExecuteStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labExecuteStatus.AutoSize = true;
            this.labExecuteStatus.Location = new System.Drawing.Point(48, 6);
            this.labExecuteStatus.Name = "labExecuteStatus";
            this.labExecuteStatus.Size = new System.Drawing.Size(44, 12);
            this.labExecuteStatus.TabIndex = 0;
            this.labExecuteStatus.Text = "0 %";
            this.labExecuteStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pgbExecuteStatus
            // 
            this.pgbExecuteStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbExecuteStatus.Location = new System.Drawing.Point(98, 3);
            this.pgbExecuteStatus.Name = "pgbExecuteStatus";
            this.pgbExecuteStatus.Size = new System.Drawing.Size(543, 19);
            this.pgbExecuteStatus.Step = 1;
            this.pgbExecuteStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbExecuteStatus.TabIndex = 1;
            // 
            // labExecuteFiles
            // 
            this.labExecuteFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labExecuteFiles.AutoSize = true;
            this.labExecuteFiles.Location = new System.Drawing.Point(647, 6);
            this.labExecuteFiles.Name = "labExecuteFiles";
            this.labExecuteFiles.Size = new System.Drawing.Size(54, 12);
            this.labExecuteFiles.TabIndex = 2;
            this.labExecuteFiles.Text = "0";
            this.labExecuteFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labFileSP
            // 
            this.labFileSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labFileSP.AutoSize = true;
            this.labFileSP.Font = new System.Drawing.Font("新細明體", 10F);
            this.labFileSP.Location = new System.Drawing.Point(705, 5);
            this.labFileSP.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.labFileSP.Name = "labFileSP";
            this.labFileSP.Size = new System.Drawing.Size(9, 14);
            this.labFileSP.TabIndex = 3;
            this.labFileSP.Text = "/";
            this.labFileSP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTotalFiles
            // 
            this.labTotalFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labTotalFiles.AutoSize = true;
            this.labTotalFiles.Location = new System.Drawing.Point(717, 6);
            this.labTotalFiles.Name = "labTotalFiles";
            this.labTotalFiles.Size = new System.Drawing.Size(54, 12);
            this.labTotalFiles.TabIndex = 4;
            this.labTotalFiles.Text = "0";
            this.labTotalFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLog
            // 
            this.btnLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLog.Location = new System.Drawing.Point(2, 2);
            this.btnLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(41, 21);
            this.btnLog.TabIndex = 5;
            this.btnLog.Text = "LOG";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // tlpFileExtension
            // 
            this.tlpFileExtension.ColumnCount = 2;
            this.tlpFileExtension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tlpFileExtension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tlpFileExtension.Controls.Add(this.txtAddFileExt, 0, 1);
            this.tlpFileExtension.Controls.Add(this.btnAddFileExt, 1, 1);
            this.tlpFileExtension.Controls.Add(this.labAddFileExt, 0, 0);
            this.tlpFileExtension.Controls.Add(this.dgvFileExt, 0, 2);
            this.tlpFileExtension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFileExtension.Location = new System.Drawing.Point(774, 205);
            this.tlpFileExtension.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tlpFileExtension.Name = "tlpFileExtension";
            this.tlpFileExtension.RowCount = 3;
            this.tlpFileExtension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFileExtension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpFileExtension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFileExtension.Size = new System.Drawing.Size(150, 281);
            this.tlpFileExtension.TabIndex = 7;
            // 
            // txtAddFileExt
            // 
            this.txtAddFileExt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddFileExt.Location = new System.Drawing.Point(3, 34);
            this.txtAddFileExt.Name = "txtAddFileExt";
            this.txtAddFileExt.Size = new System.Drawing.Size(73, 22);
            this.txtAddFileExt.TabIndex = 0;
            // 
            // btnAddFileExt
            // 
            this.btnAddFileExt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFileExt.Location = new System.Drawing.Point(82, 33);
            this.btnAddFileExt.Name = "btnAddFileExt";
            this.btnAddFileExt.Size = new System.Drawing.Size(65, 23);
            this.btnAddFileExt.TabIndex = 1;
            this.btnAddFileExt.Text = "新增";
            this.btnAddFileExt.UseVisualStyleBackColor = true;
            this.btnAddFileExt.Click += new System.EventHandler(this.btnAddFileExt_Click);
            // 
            // labAddFileExt
            // 
            this.labAddFileExt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labAddFileExt.AutoSize = true;
            this.tlpFileExtension.SetColumnSpan(this.labAddFileExt, 2);
            this.labAddFileExt.Font = new System.Drawing.Font("新細明體", 10F);
            this.labAddFileExt.Location = new System.Drawing.Point(3, 8);
            this.labAddFileExt.Name = "labAddFileExt";
            this.labAddFileExt.Size = new System.Drawing.Size(144, 14);
            this.labAddFileExt.TabIndex = 2;
            this.labAddFileExt.Text = "搜尋的檔案類型";
            this.labAddFileExt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvFileExt
            // 
            this.dgvFileExt.AllowUserToAddRows = false;
            this.dgvFileExt.AllowUserToDeleteRows = false;
            this.dgvFileExt.AllowUserToResizeColumns = false;
            this.dgvFileExt.AllowUserToResizeRows = false;
            this.dgvFileExt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFileExt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileExtensionName,
            this.colDelete});
            this.tlpFileExtension.SetColumnSpan(this.dgvFileExt, 2);
            this.dgvFileExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFileExt.Location = new System.Drawing.Point(3, 63);
            this.dgvFileExt.MultiSelect = false;
            this.dgvFileExt.Name = "dgvFileExt";
            this.dgvFileExt.ReadOnly = true;
            this.dgvFileExt.RowHeadersVisible = false;
            this.dgvFileExt.RowTemplate.Height = 24;
            this.dgvFileExt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileExt.ShowCellErrors = false;
            this.dgvFileExt.ShowEditingIcon = false;
            this.dgvFileExt.ShowRowErrors = false;
            this.dgvFileExt.Size = new System.Drawing.Size(144, 215);
            this.dgvFileExt.TabIndex = 3;
            this.dgvFileExt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFileExt_CellClick);
            // 
            // colFileExtensionName
            // 
            this.colFileExtensionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFileExtensionName.DataPropertyName = "ExtName";
            this.colFileExtensionName.HeaderText = "副檔名";
            this.colFileExtensionName.Name = "colFileExtensionName";
            this.colFileExtensionName.ReadOnly = true;
            // 
            // colDelete
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "刪除";
            this.colDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDelete.HeaderText = "";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Width = 50;
            // 
            // ckbConvertFolder
            // 
            this.ckbConvertFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbConvertFolder.AutoSize = true;
            this.ckbConvertFolder.Location = new System.Drawing.Point(777, 108);
            this.ckbConvertFolder.Name = "ckbConvertFolder";
            this.ckbConvertFolder.Size = new System.Drawing.Size(144, 16);
            this.ckbConvertFolder.TabIndex = 8;
            this.ckbConvertFolder.Text = "轉換資料夾名稱";
            this.ckbConvertFolder.UseVisualStyleBackColor = true;
            this.ckbConvertFolder.Click += new System.EventHandler(this.CheckBox_Click);
            // 
            // spcMain
            // 
            this.spcMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Margin = new System.Windows.Forms.Padding(0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.dgvFileList);
            this.spcMain.Panel1MinSize = 200;
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.txtStatus);
            this.spcMain.Panel2MinSize = 80;
            this.tlpMain.SetRowSpan(this.spcMain, 6);
            this.spcMain.Size = new System.Drawing.Size(774, 486);
            this.spcMain.SplitterDistance = 385;
            this.spcMain.SplitterWidth = 3;
            this.spcMain.TabIndex = 10;
            // 
            // dgvFileList
            // 
            this.dgvFileList.AllowDrop = true;
            this.dgvFileList.AllowUserToAddRows = false;
            this.dgvFileList.AllowUserToDeleteRows = false;
            this.dgvFileList.AllowUserToResizeRows = false;
            this.dgvFileList.ColumnHeadersHeight = 25;
            this.dgvFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileName,
            this.colModifyDate,
            this.colFileSize,
            this.colDirectoryName,
            this.colSP});
            this.dgvFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFileList.Location = new System.Drawing.Point(0, 0);
            this.dgvFileList.MultiSelect = false;
            this.dgvFileList.Name = "dgvFileList";
            this.dgvFileList.ReadOnly = true;
            this.dgvFileList.RowHeadersVisible = false;
            this.dgvFileList.RowTemplate.Height = 24;
            this.dgvFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileList.ShowCellErrors = false;
            this.dgvFileList.ShowEditingIcon = false;
            this.dgvFileList.Size = new System.Drawing.Size(770, 381);
            this.dgvFileList.TabIndex = 5;
            this.dgvFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvFileList_DragDrop);
            this.dgvFileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvFileList_DragEnter);
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "FileName";
            this.colFileName.HeaderText = "檔案名稱";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            this.colFileName.Width = 200;
            // 
            // colModifyDate
            // 
            this.colModifyDate.DataPropertyName = "LastModifyDate";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "f";
            dataGridViewCellStyle2.NullValue = null;
            this.colModifyDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colModifyDate.HeaderText = "修改日期";
            this.colModifyDate.Name = "colModifyDate";
            this.colModifyDate.ReadOnly = true;
            // 
            // colFileSize
            // 
            this.colFileSize.DataPropertyName = "FileSize";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,###,##0 KB";
            dataGridViewCellStyle3.NullValue = "0 KB";
            this.colFileSize.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFileSize.HeaderText = "大小";
            this.colFileSize.Name = "colFileSize";
            this.colFileSize.ReadOnly = true;
            this.colFileSize.Width = 80;
            // 
            // colDirectoryName
            // 
            this.colDirectoryName.DataPropertyName = "DirectoryName";
            this.colDirectoryName.HeaderText = "路徑";
            this.colDirectoryName.Name = "colDirectoryName";
            this.colDirectoryName.ReadOnly = true;
            this.colDirectoryName.Width = 350;
            // 
            // colSP
            // 
            this.colSP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSP.HeaderText = "";
            this.colSP.Name = "colSP";
            this.colSP.ReadOnly = true;
            // 
            // txtStatus
            // 
            this.txtStatus.BackColor = System.Drawing.SystemColors.Window;
            this.txtStatus.DetectUrls = false;
            this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatus.HideSelection = false;
            this.txtStatus.Location = new System.Drawing.Point(0, 0);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.ShortcutsEnabled = false;
            this.txtStatus.Size = new System.Drawing.Size(770, 94);
            this.txtStatus.TabIndex = 9;
            this.txtStatus.Text = "";
            // 
            // dlgSelectFolder
            // 
            this.dlgSelectFolder.Description = "請選擇要處理的資料夾";
            // 
            // dlgSelectFile
            // 
            this.dlgSelectFile.Filter = "所有檔案|*.*|MP3|*.mp3";
            this.dlgSelectFile.Multiselect = true;
            this.dlgSelectFile.RestoreDirectory = true;
            this.dlgSelectFile.SupportMultiDottedExtensions = true;
            this.dlgSelectFile.Title = "請選取要處理的檔案";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 511);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(940, 550);
            this.Name = "MainForm";
            this.Text = "檔案名稱簡轉繁";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpExecuteStatus.ResumeLayout(false);
            this.tlpExecuteStatus.PerformLayout();
            this.tlpFileExtension.ResumeLayout(false);
            this.tlpFileExtension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileExt)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.CheckBox ckbIncludeSubFolder;
        private System.Windows.Forms.DataGridView dgvFileList;
        private System.Windows.Forms.TableLayoutPanel tlpExecuteStatus;
        private System.Windows.Forms.Label labExecuteStatus;
        private System.Windows.Forms.ProgressBar pgbExecuteStatus;
        private System.Windows.Forms.Label labExecuteFiles;
        private System.Windows.Forms.Label labFileSP;
        private System.Windows.Forms.Label labTotalFiles;
        private System.Windows.Forms.FolderBrowserDialog dlgSelectFolder;
        private System.Windows.Forms.OpenFileDialog dlgSelectFile;
        private System.Windows.Forms.TableLayoutPanel tlpFileExtension;
        private System.Windows.Forms.TextBox txtAddFileExt;
        private System.Windows.Forms.Button btnAddFileExt;
        private System.Windows.Forms.Label labAddFileExt;
        private System.Windows.Forms.DataGridView dgvFileExt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileExtensionName;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModifyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSP;
        private System.Windows.Forms.CheckBox ckbConvertFolder;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Button btnLog;
    }
}

