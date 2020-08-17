using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FileNameConverter
{
    public partial class MainForm : Form
    {
        private DataTable dtFileList = new DataTable();
        private List<vFileList> lstFileList = new List<vFileList>();
        private DataTable dtFileExt = new DataTable();

        private List<DirectoryInfo> lstAllDirectory = new List<DirectoryInfo>();
        private List<FileInfo> lstAllFile = new List<FileInfo>();

        private Thread procConvert = null;

        /// <summary>
        /// 初始化
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 程式載入
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Program.lstLegalExt.Clear();

            foreach (string tmpExtName in Program.CustomLegalExt.Split(';'))
            {
                Program.lstLegalExt.Add(new vFileExtList() { ExtName = tmpExtName.ToUpper() });
            }

            BindFileExt();
            BindFileList();

            UpdateSelectFileDialog();
        }

        /// <summary>
        /// 檢測是否已在轉換中
        /// </summary>
        private bool IsThreadRunning()
        {
            if ((procConvert != null) && (procConvert.IsAlive))
            {
                MessageBox.Show("轉換中，請稍後再執行!");
                return true;
            }
            return false;
        }

        #region 資料繫結
        /// <summary>
        /// 選取檔案資料繫結
        /// </summary>
        private void BindFileList()
        {

            dgvFileList.ClearSelection();
            dtFileList = Program.ListToDataTable<vFileList>(lstFileList);
            if (dtFileList.Columns.Count == 0)
            {
                List<vFileList> tmpList = new List<vFileList>();
                tmpList.Add(new vFileList());
                dtFileList = Program.ListToDataTable<vFileList>(tmpList);
                dtFileList.Rows.Clear();
            }
            Program.DataTableReMapDataGridView(dgvFileList, dtFileList);
            dtFileList.PrimaryKey = new DataColumn[] { dtFileList.Columns[colFileName.DataPropertyName], dtFileList.Columns[colDirectoryName.DataPropertyName] };

            dtFileList.AcceptChanges();
            dgvFileList.DataSource = dtFileList;

            UpdateTotalFileCount();
        }

        /// <summary>
        /// 副檔名資料繫結
        /// </summary>
        private void BindFileExt()
        {
            dgvFileExt.ClearSelection();
            dtFileExt = Program.ListToDataTable<vFileExtList>(Program.lstLegalExt);
            if (dtFileExt.Columns.Count == 0)
            {
                List<vFileExtList> tmpList = new List<vFileExtList>();
                tmpList.Add(new vFileExtList());
                dtFileExt = Program.ListToDataTable<vFileExtList>(tmpList);
                dtFileExt.Rows.Clear();
            }
            Program.DataTableReMapDataGridView(dgvFileExt, dtFileExt);
            dtFileExt.AcceptChanges();
            dgvFileExt.DataSource = dtFileExt;
        }
        #endregion

        #region 副檔名處理
        /// <summary>
        /// 新增副檔名
        /// </summary>
        private void btnAddFileExt_Click(object sender, EventArgs e)
        {
            if (IsThreadRunning()) return;

            string tmpExtName = txtAddFileExt.Text.Trim().ToUpper();
            if (tmpExtName.StartsWith(".")) tmpExtName = tmpExtName.Length == 1 ? "" : tmpExtName.Substring(1);
            if (tmpExtName.EndsWith(".")) tmpExtName = tmpExtName.Length == 1 ? "" : tmpExtName.Substring(0, tmpExtName.Length - 1);
            if (tmpExtName == "") return;
            if (Program.lstLegalExt.Where(x => x.ExtName == tmpExtName).Count() > 0) return;
            Program.lstLegalExt.Add(new vFileExtList() { ExtName = tmpExtName });
            BindFileExt();
            Program.UpdateCustomLegalExt();
            txtAddFileExt.Text = "";
            UpdateSelectFileDialog();
        }

        /// <summary>
        /// 刪除副檔名
        /// </summary>
        private void dgvFileExt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex < 0) || (e.ColumnIndex < 0)) return;
            if (dgvFileExt.Columns[e.ColumnIndex].Name != colDelete.Name) return;
            string tmpExtName = dgvFileExt.CurrentRow.Cells[colFileExtensionName.Name].Value.ToString();
            Program.lstLegalExt.RemoveAll(x => x.ExtName == tmpExtName);
            BindFileExt();
            Program.UpdateCustomLegalExt();
            UpdateSelectFileDialog();
        }

        /// <summary>
        /// 更新選取檔案視窗的過濾條件
        /// </summary>
        private void UpdateSelectFileDialog()
        {
            dlgSelectFile.Filter = "";
            if (Program.lstLegalExt.Count == 0)
            {
                dlgSelectFile.Filter = "所有檔案|*.*";
                return;
            }
            string tmpFilter = "允許的檔案類型|";
            foreach (vFileExtList tmpS in Program.lstLegalExt)
            {
                tmpFilter += string.Format("*.{0};", tmpS.ExtName.ToLower());
            }
            tmpFilter = tmpFilter.Substring(0, tmpFilter.Length - 1);

            if (Program.lstLegalExt.Count > 1)
            {
                tmpFilter += "|所有檔案|*.*";
                foreach (vFileExtList tmpS in Program.lstLegalExt)
                {
                    tmpFilter += string.Format("|{0} 檔案|*.{1}", tmpS.ExtName.ToUpper(), tmpS.ExtName.ToLower());
                }
            }
            dlgSelectFile.Filter = tmpFilter;
        }
        #endregion

        #region 檔案清單設定
        #region 拖曳處理
        /// <summary>
        /// 加入拖曳過來的項目
        /// </summary>
        private void dgvFileList_DragDrop(object sender, DragEventArgs e)
        {
            if (IsThreadRunning()) return;
            if (!((DataObject)e.Data).ContainsFileDropList()) return;
            List<string> lstDropItem = ((DataObject)e.Data).GetFileDropList().Cast<string>().ToList();

            lstAllDirectory.Clear();
            lstAllFile.Clear();

            foreach (string tmpS in lstDropItem)
            {
                if (System.IO.Directory.Exists(tmpS))
                    lstAllDirectory.Add(new DirectoryInfo(tmpS));
                else if (System.IO.File.Exists(tmpS))
                    lstAllFile.Add(new FileInfo(tmpS));
            }
            AddMatchFiles();
        }

        /// <summary>
        /// 滑鼠拖曳進入
        /// </summary>
        private void dgvFileList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        #endregion

        #region 按鍵處理
        /// <summary>
        /// 新增資料夾
        /// </summary>
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (IsThreadRunning()) return;

            if (dlgSelectFolder.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            lstAllDirectory.Clear();
            lstAllFile.Clear();
            lstAllDirectory.Add(new DirectoryInfo(dlgSelectFolder.SelectedPath));
            AddMatchFiles();
        }

        /// <summary>
        /// 新增檔案
        /// </summary>
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (IsThreadRunning()) return;

            if (dlgSelectFile.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            lstAllDirectory.Clear();
            lstAllFile.Clear();
            foreach (string tmpFileName in dlgSelectFile.FileNames)
            {
                if (System.IO.File.Exists(tmpFileName)) lstAllFile.Add(new FileInfo(tmpFileName));
            }
            AddMatchFiles();
        }

        /// <summary>
        /// 清除清單資料
        /// </summary>
        private void btnClearList_Click(object sender, EventArgs e)
        {
            if (IsThreadRunning()) return;

            dgvFileList.ClearSelection();
            lstFileList.Clear();
            dtFileList.Rows.Clear();
            BindFileList();

            txtStatus.Text = "";
        }
        #endregion

        /// <summary>
        /// 搜尋符合條件的檔案並加入到清單中
        /// </summary>
        private void AddMatchFiles()
        {
            foreach (DirectoryInfo tmpDirectoryInfo in lstAllDirectory)
            {
                foreach (string tmpExtName in Program.lstLegalExt.Select(x => x.ExtName).ToArray())
                {
                    lstAllFile.AddRange(tmpDirectoryInfo.EnumerateFiles(string.Format("*.{0}", tmpExtName), ckbIncludeSubFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).ToList());
                }
            }
            AddToFileList(lstAllFile);
        }

        /// <summary>
        /// 加入檔案清單
        /// </summary>
        /// <param name="FileNames">完整檔案名稱</param>
        private void AddToFileList(List<FileInfo> FileNames)
        {
            foreach (FileInfo tmpFileInfo in FileNames)
            {
                if (!tmpFileInfo.Exists) continue;
                if (lstFileList.Where(x => x.FullFileName.ToLower() == tmpFileInfo.FullName.ToLower()).Count() > 0) continue;
                if (Program.lstLegalExt.Where(x => x.ExtName == tmpFileInfo.Extension.ToUpper().Substring(1)).Count() == 0) continue;
                lstFileList.Add(new vFileList()
                {
                    DirectoryName = tmpFileInfo.DirectoryName,
                    FullFileName = tmpFileInfo.FullName,
                    FileName = tmpFileInfo.Name,
                    FileSize = tmpFileInfo.Length,
                    LastModifyDate = tmpFileInfo.LastWriteTime
                });
            }
            dgvFileList.ClearSelection();
            BindFileList();
        }
        #endregion

        /// <summary>
        /// 更新總檔案數
        /// </summary>
        private void UpdateTotalFileCount()
        {
            if (this.InvokeRequired)
            {
                Action action = () =>
                {
                    labExecuteStatus.Text = "0 %";
                    pgbExecuteStatus.Value = 0;
                    labExecuteFiles.Text = "0";
                    labTotalFiles.Text = lstFileList.Count.ToString("#,###,##0");
                    btnExecute.Enabled = dgvFileList.Rows.Count > 0 ? true : false;
                };
                this.Invoke(action);
            }
            else
            {
                labExecuteStatus.Text = "0 %";
                pgbExecuteStatus.Value = 0;
                labExecuteFiles.Text = "0";
                labTotalFiles.Text = lstFileList.Count.ToString("#,###,##0");
                btnExecute.Enabled = dgvFileList.Rows.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// 執行轉換
        /// </summary>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (IsThreadRunning()) return;

            if (txtStatus.Text != "") txtStatus.Text = Environment.NewLine + Environment.NewLine + txtStatus.Text;
            pgbExecuteStatus.Maximum = lstFileList.Count;
            pgbExecuteStatus.Value = 0;
            pgbExecuteStatus.Step = 1;

            procConvert = new Thread(() => ExecuteConvert());
            procConvert.Start();
        }

        private void ExecuteConvert()
        {
            List<string> lstRemove = new List<string>();

            UpdateControlText(labExecuteStatus, "0 %");
            UpdateControlText(labExecuteFiles, "0");

            int _CT = 0;
            int _FileCount = 0;
            try
            {
                foreach (vFileList tmpFile in lstFileList)
                {
                    string oldFileName = tmpFile.FileName;
                    string oldFullFileName = tmpFile.FullFileName;
                    string oldDirectoryName = tmpFile.DirectoryName;
                    tmpFile.FileName = Program.ToTraditional(tmpFile.FileName);
                    tmpFile.FullFileName = string.Format("{0}\\{1}", tmpFile.DirectoryName.EndsWith("\\") ? tmpFile.DirectoryName.Substring(0, tmpFile.DirectoryName.Length - 1) : tmpFile.DirectoryName, tmpFile.FileName);
                    if (oldFileName != tmpFile.FileName)
                    {
                        System.IO.File.Move(oldFullFileName, tmpFile.FullFileName);
                        UpdateLogText(string.Format("檔案：[{0}] → [{1}]", oldFullFileName, tmpFile.FileName));
                        _FileCount++;
                    }
                    lstRemove.Add(tmpFile.FullFileName);
                    _CT++;
                    if (this.InvokeRequired)
                    {
                        Action action = () =>
                        {
                            pgbExecuteStatus.PerformStep();
                            dtFileList.Rows.Remove(dtFileList.Rows.Find(new object[] { oldFileName, oldDirectoryName }));
                            dtFileList.AcceptChanges();
                            dgvFileList.DataSource = dtFileList;
                        };
                        this.Invoke(action);
                    }
                    else
                    {
                        pgbExecuteStatus.PerformStep();
                        dtFileList.Rows.Remove(dtFileList.Rows.Find(new object[] { oldFileName, oldDirectoryName }));
                        dtFileList.AcceptChanges();
                        dgvFileList.DataSource = dtFileList;
                    }
                    UpdateControlText(labExecuteStatus, string.Format("{0} %", (Convert.ToDouble(pgbExecuteStatus.Value) / Convert.ToDouble(pgbExecuteStatus.Maximum) * 100.0).ToString("##0.##")));
                    UpdateControlText(labExecuteFiles, _CT.ToString("#,###,##0"));
                }
                UpdateLogText(Environment.NewLine + string.Format("總共轉換 {0} 個檔案。", _FileCount));

                if (ckbConvertFolder.Checked) ProcessDirectoryName();
                UpdateControlText(labExecuteStatus, "100 %");
                dgvFileList.ClearSelection();
                if (this.InvokeRequired)
                    this.Invoke(new Action(() => { dtFileList.Rows.Clear(); }));
                else
                    dtFileList.Rows.Clear();
                lstFileList.Clear();

                UpdateTotalFileCount();
            }
            catch (Exception ex)
            {
                lstFileList.RemoveAll(x => lstRemove.Contains(x.FullFileName));
                BindFileList();
                UpdateTotalFileCount();
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 處理資料夾名稱
        /// </summary>
        private void ProcessDirectoryName()
        {
            try
            {
                int FolderCount = 0;
                foreach (DirectoryInfo tmpDirectoryInfo in lstAllDirectory)
                {
                    if (ckbIncludeSubFolder.Checked)
                        ProcessDirectoryName(tmpDirectoryInfo, ref FolderCount);
                    else
                        ConvertFolderName(tmpDirectoryInfo, ref FolderCount);
                }
                UpdateLogText(string.Format("總共轉換 {0} 個資料夾。", FolderCount));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 處理資料夾名稱
        /// </summary>
        /// <param name="SourceDirectory">來源資料夾</param>
        private void ProcessDirectoryName(DirectoryInfo SourceDirectory, ref int FolderCount)
        {
            if (SourceDirectory.EnumerateDirectories().Count() > 0)
            {
                foreach (DirectoryInfo tmpDirectoryInfo in SourceDirectory.EnumerateDirectories())
                {
                    ProcessDirectoryName(tmpDirectoryInfo, ref FolderCount);
                }
            }
            ConvertFolderName(SourceDirectory, ref FolderCount);
        }

        /// <summary>
        /// 轉換資料夾名稱
        /// </summary>
        /// <param name="SourceDirectory">來源資料夾</param>
        private void ConvertFolderName(DirectoryInfo SourceDirectory, ref int FolderCount)
        {
            string _oldName = SourceDirectory.Name;
            string _oldPath = SourceDirectory.FullName.Substring(0, SourceDirectory.FullName.Length - _oldName.Length);
            string _newName = Program.ToTraditional(_oldName);

            if (_oldName != _newName)
            {
                System.IO.Directory.Move(SourceDirectory.FullName, _oldPath + _newName);
                UpdateLogText(string.Format("資料夾：[{0}] → [{1}]", SourceDirectory.FullName, _newName));
                FolderCount++;
            }
        }

        /// <summary>
        /// 點選LOG鍵
        /// </summary>
        private void btnLog_Click(object sender, EventArgs e)
        {
            spcMain.Panel2Collapsed = !spcMain.Panel2Collapsed;

            if (spcMain.Panel2Collapsed)
                btnLog.BackColor = Color.FromArgb(192, 255, 255);
            else
                btnLog.BackColor = Color.FromArgb(255, 224, 192);
        }

        /// <summary>
        /// 更新 Log 顯示文字
        /// </summary>
        /// <param name="sMessage">要顯示的文字</param>
        private void UpdateLogText(string sMessage)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => { txtStatus.Text = sMessage + Environment.NewLine + txtStatus.Text; }));
            else
                txtStatus.Text = sMessage + Environment.NewLine + txtStatus.Text;
        }

        /// <summary>
        /// 更新Label控制項上顯示的文字
        /// </summary>
        /// <param name="TargetControl">Label控制項</param>
        /// <param name="sMessage">要顯示的文字</param>
        private void UpdateControlText(Label TargetControl, string sMessage)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => { TargetControl.Text = sMessage; }));
            else
                TargetControl.Text = sMessage;
        }

        /// <summary>
        /// 點選 CheckBox
        /// </summary>
        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (IsThreadRunning())
            {
                ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
                return;
            }
        }
    }
}
