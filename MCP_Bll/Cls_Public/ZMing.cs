using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace Maticsoft.BLL
{
    public class ZMing
    {
        #region DataGrid设置数据源
        /// <summary>
        /// 控件设置数据源
        /// </summary>
        /// <param name="_DataGrid"></param>
        /// <param name="_Source"></param>
        public void SetDataGriveSource(DataGrid _DataGrid, DataSet _Source)
        {
            _DataGrid.DataSource = _Source.Tables[0];
        }
        #endregion
      
        #region DateGridView导出到csv格式的Excel
        /// <summary>  
        /// 常用方法，列之间加\t，一行一行输出，此文件其实是csv文件，不过默认可以当成Excel打开。  
        /// </summary>  
        /// <remarks>  
        /// using System.IO;  
        /// </remarks>  
        /// <param name="dgv"></param>  
        public void DataGridViewToExcel(System.Data.DataTable dgv)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = true;
            dlg.Title = "保存为Excel文件";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                Stream myStream;
                myStream = dlg.OpenFile();
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题  
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            columnTitle += "\t";
                        }
                        columnTitle += dgv.Columns[i];
                    }
                    sw.WriteLine(columnTitle);

                    //写入列内容  
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (k > 0)
                            {
                                columnValue += "\t";
                            }
                            if (dgv.Rows[j][k] == null)
                                columnValue += "";
                            else
                                columnValue += dgv.Rows[j][k].ToString().Trim();
                        }
                        sw.WriteLine(columnValue);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
        }
        #endregion



        #region 关闭Excel进程
        
        /// <summary>
        /// 关闭Excel进程
        /// </summary>
        private void KillExcelProcess()                                          //结束EXCEL进程
        {
            System.Diagnostics.Process[] myProcesses;
            DateTime startTime;
            myProcesses = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            //得不到Excel进程ID，暂时只能判断进程启动时间
            foreach (System.Diagnostics.Process myProcess in myProcesses)
            {
                startTime = myProcess.StartTime;
                myProcess.Kill();
            }
        }
        #endregion
    }
}


