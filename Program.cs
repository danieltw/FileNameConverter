using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FileNameConverter
{
    static class Program
    {
        /// <summary>
        /// 定義使用者自定的副檔名
        /// </summary>
        private static string _CustomLegalExtName = Properties.Settings.Default.LegalExtName.ToLower();

        /// <summary>
        /// 設定/讀取 使用者自定的副檔名
        /// </summary>
        internal static string CustomLegalExt
        {
            get { return _CustomLegalExtName; }
            set
            {
                if ((value.Trim() == "") || (value.Trim() == ";"))
                {
                    Properties.Settings.Default.LegalExtName = "";
                }
                else
                {
                    if (value.EndsWith(";")) value = value.Substring(0, value.Length - 1);
                    Properties.Settings.Default.LegalExtName = value.Trim().ToLower();
                }
                _CustomLegalExtName = Properties.Settings.Default.LegalExtName;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 定義使用者自定的副檔名資料集
        /// </summary>
        internal static List<vFileExtList> lstLegalExt = new List<vFileExtList>();

        private const int LocaleSystemDefault = 0x0800;
        private const int LcmapSimplifiedChinese = 0x02000000;
        private const int LcmapTraditionalChinese = 0x04000000;

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int LCMapString(int locale, int dwMapFlags, string lpSrcStr, int cchSrc,
                                              [Out] string lpDestStr, int cchDest);

        /// <summary>
        /// 轉換為簡體中文
        /// </summary>
        /// <param name="SourceText">來源文字</param>
        public static string ToSimplified(string SourceText)
        {
            var t = new String(' ', SourceText.Length);
            LCMapString(LocaleSystemDefault, LcmapSimplifiedChinese, SourceText, SourceText.Length, t, SourceText.Length);
            return t;
        }

        /// <summary>
        /// 轉換為繁體中文
        /// </summary>
        /// <param name="SourceText">來源文字</param>
        public static string ToTraditional(string SourceText)
        {
            var t = new String(' ', SourceText.Length);
            LCMapString(LocaleSystemDefault, LcmapTraditionalChinese, SourceText, SourceText.Length, t, SourceText.Length);
            return t;
        }

        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// 更新自定的副檔名設定值
        /// </summary>
        internal static void UpdateCustomLegalExt()
        {
            string NewLegalExtConfig = string.Join(";", lstLegalExt.Select(x => x.ExtName).ToArray());
            CustomLegalExt = NewLegalExtConfig;
        }


        /// <summary>
        /// 調整 DataGridView 來源資料集的欄位對應與欄位順序
        /// </summary>
        /// <param name="dgvTargetView">目地的 DataGridView 控制項</param>
        /// <param name="dtSourceTable">來源資料集</param>
        internal static void DataTableReMapDataGridView(DataGridView dgvTargetView, DataTable dtSourceTable)
        {
            try
            {
                List<string> KeepColumn = dgvTargetView.Columns.Cast<DataGridViewColumn>().ToList().Where(x => x.DataPropertyName != "").Select(x => x.DataPropertyName).ToList();
                List<string> SourceColumnName = dtSourceTable.Columns.Cast<DataColumn>().ToList().Select(x => x.ColumnName).ToList();

                foreach (string tColumnName in SourceColumnName)
                {
                    if (KeepColumn.Contains(tColumnName)) continue;
                    dtSourceTable.Columns.Remove(tColumnName);
                }

                int SN = 0;
                for (int i = 0; i < dgvTargetView.Columns.Count; i++)
                {
                    if ((!dgvTargetView.Columns[i].Visible) ||
                       ((dgvTargetView.Columns[i].DataPropertyName == null) || (dgvTargetView.Columns[i].DataPropertyName == "")) ||
                       (!dtSourceTable.Columns.Contains(dgvTargetView.Columns[i].DataPropertyName))) continue;

                    dtSourceTable.Columns[dgvTargetView.Columns[i].DataPropertyName].SetOrdinal(SN);
                    SN++;
                }
                dtSourceTable.AcceptChanges();
            }
            catch { }
        }
        
        /// <summary>
        /// List 轉為 DataTable
        /// </summary>
        /// <typeparam name="TResult">來源型別</typeparam>
        /// <param name="ListValue">來源資料集</param>
        /// <returns>轉換成功的 DataTable</returns>
        internal static DataTable ListToDataTable<TResult>(IEnumerable<TResult> ListValue) where TResult : class, new()
        {
            return ListToDataTable<TResult>(ListValue, null);
        }

        /// <summary>
        /// List 轉為 DataTable
        /// </summary>
        /// <typeparam name="TResult">來源型別</typeparam>
        /// <param name="ListValue">來源資料集</param>
        /// <param name="ExcludeName">排除的欄位名稱</param>
        /// <returns>轉換成功的 DataTable</returns>
        internal static DataTable ListToDataTable<TResult>(IEnumerable<TResult> ListValue, List<string> ExcludeName) where TResult : class, new()
        {
            DataTable dtReturn = new DataTable();
            try
            {
                Type tmpType = typeof(TResult);
                PropertyInfo[] piList = null;

                foreach (var sItem in ListValue)
                {
                    if (dtReturn.Columns.Count == 0)
                    {
                        piList = sItem.GetType().GetProperties();
                        foreach (var tmpItem in piList)
                        {
                            if ((ExcludeName != null) && (ExcludeName.Count() > 0))
                            {
                                if (ExcludeName.Contains(tmpItem.Name)) continue;
                            }

                            Type colType = tmpItem.PropertyType;
                            bool allowNull = false;
                            if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                            {
                                colType = colType.GetGenericArguments()[0];
                                allowNull = true;
                            }

                            dtReturn.Columns.Add(tmpItem.Name, colType);
                            if (allowNull)
                            {
                                dtReturn.Columns[tmpItem.Name].AllowDBNull = true;
                            }
                        }
                    }

                    DataRow tRow = dtReturn.NewRow();
                    foreach (var tmpItem in piList)
                    {
                        if ((ExcludeName != null) && (ExcludeName.Count() > 0))
                        {
                            if (ExcludeName.Contains(tmpItem.Name)) continue;
                        }

                        try
                        {
                            if (dtReturn.Columns[tmpItem.Name].AllowDBNull)
                                tRow[tmpItem.Name] = tmpItem.GetValue(sItem, null) ?? DBNull.Value;
                            else
                                tRow[tmpItem.Name] = tmpItem.GetValue(sItem, null) ?? "";
                        }
                        catch { }
                    }
                    dtReturn.Rows.Add(tRow);
                }
            }
            catch
            {
                dtReturn = new DataTable();
            }
            return dtReturn;
        }

        /// <summary>
        /// DataTable 轉為 List
        /// </summary>
        /// <typeparam name="TResult">來源型別</typeparam>
        /// <param name="DataTableValue">來源資料集</param>
        /// <returns>轉換成功的 List 資料</returns>
        internal static List<TResult> DataTableToList<TResult>(DataTable DataTableValue) where TResult : class, new()
        {
            return DataTableToList<TResult>(DataTableValue, null);
        }

        /// <summary>
        /// DataTable 轉為 List
        /// </summary>
        /// <typeparam name="TResult">來源型別</typeparam>
        /// <param name="DataTableValue">來源資料集</param>
        /// <param name="ExcludeName">排除的欄位名稱</param>
        /// <returns>轉換成功的 List 資料</returns>
        internal static List<TResult> DataTableToList<TResult>(DataTable DataTableValue, List<string> ExcludeName) where TResult : class, new()
        {
            List<TResult> lstReturnValue = new List<TResult>();
            if ((DataTableValue == null) || (DataTableValue.Rows.Count <= 0)) return lstReturnValue;

            try
            {
                Type tmpType = typeof(TResult);

                List<PropertyInfo> piList = new List<PropertyInfo>();

                foreach (PropertyInfo sItem in tmpType.GetProperties())
                {
                    if (DataTableValue.Columns.IndexOf(sItem.Name) != -1)
                    {
                        if ((ExcludeName != null) && (ExcludeName.Count() > 0))
                        {
                            if (ExcludeName.Contains(sItem.Name)) continue;
                        }
                        piList.Add(sItem);
                    }
                }

                foreach (DataRow tItem in DataTableValue.Rows)
                {
                    TResult tmpResult = new TResult();
                    foreach (PropertyInfo tmpItem in piList)
                    {
                        if ((ExcludeName != null) && (ExcludeName.Count() > 0))
                        {
                            if (ExcludeName.Contains(tmpItem.Name)) continue;
                        }

                        if (tItem[tmpItem.Name] != DBNull.Value)
                        {
                            if (tmpItem.PropertyType.IsGenericType && tmpItem.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                                tmpItem.SetValue(tmpResult, Convert.ChangeType(tItem[tmpItem.Name], Nullable.GetUnderlyingType(tmpItem.PropertyType)), null);
                            else if (tmpItem.PropertyType.IsEnum)
                                tmpItem.SetValue(tmpResult, Convert.ToInt32(tItem[tmpItem.Name]), null);
                            else
                                tmpItem.SetValue(tmpResult, Convert.ChangeType(tItem[tmpItem.Name], tmpItem.PropertyType), null);
                        }
                    }

                    lstReturnValue.Add(tmpResult);
                }
            }
            catch
            {
                return new List<TResult>();
            }
            return lstReturnValue;
        }
    }

    /// <summary>
    /// 自定檔案清單顯示類別
    /// </summary>
    internal class vFileList
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public vFileList() { }

        /// <summary>
        /// 設定/取得 檔案名稱
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 設定/取得 檔案大小
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// 設定/取得 檔案最後修改日期
        /// </summary>
        public DateTime LastModifyDate { get; set; }
        /// <summary>
        /// 設定/取得 完整檔案名稱
        /// </summary>
        public string FullFileName { get; set; }
        /// <summary>
        /// 設定/取得 完整路徑名稱
        /// </summary>
        public string DirectoryName { get; set; }
    }

    /// <summary>
    /// 自定副檔名清單顯示類別
    /// </summary>
    internal class vFileExtList
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public vFileExtList() { }

        /// <summary>
        /// 設定/取得 副檔名稱
        /// </summary>
        public string ExtName { get; set; }
    }

}
