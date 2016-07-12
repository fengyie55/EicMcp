using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.Data;
using System.IO;
using msg = ZhuifengLib.MessageShow.Message;
using Excel = Microsoft.Office.Interop.Excel;

namespace ZhuifengLib
{
    public class ExcelHelper
    {
        public ExcelHelper(string patch)
        {
            this.Patch = patch;
            wk = WorkbookFactory.Create(patch);
            dt = NpoiHelper.GenerateTableData(patch);
            startRow = dt.Rows.Count + 1;
        }

        private string Patch;

        private IWorkbook wk;

        private DataTable dt;

        private int startRow;

        /// <summary>
        /// 插入一行数据到Excel
        /// </summary>
        /// <param name="parameterList"></param>
        public void InsertRow(List<InsertExcelParameter> parameterList)
        {
            ISheet tb = wk.GetSheet(wk.GetSheetName(0));
            IRow row = tb.CreateRow(startRow);
            foreach (var par in parameterList)
            {
                row.CreateCell(GetCollectionIndex(par.Type)).SetCellValue(string.Format("{0}", par.Paramenter));
            }
            FileStream fs2 = File.Create(Patch);
            wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
        }

        /// <summary>
        /// 插入多行数据到模板
        /// </summary>
        /// <param name="parameterList"></param>
        public void InsertRows(List<List<InsertExcelParameter>> parameterList)
        {
            ISheet tb = wk.GetSheet(wk.GetSheetName(0));
            IRow row = tb.CreateRow(startRow);
            foreach (var parList in parameterList)
            {
                foreach (var par in parList)
                {
                    row.CreateCell(GetCollectionIndex(par.Type)).SetCellValue(string.Format("{0}", par.Paramenter));
                }
            }
            FileStream fs2 = File.Create(Patch);
            wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
        }

        /// <summary>
        /// 清空Excel中的数据
        /// </summary>
        /// <summary>
        /// 清除Excel中的内容
        /// </summary>
        /// <param name="excelPatch"></param>
        /// <param name="rows"></param>
        public bool ClearDateForNPOI()
        {
            try
            {
                ISheet tb = wk.GetSheet(wk.GetSheetName(0));
                IRow row = tb.CreateRow(startRow);
                int ttt = tb.LastRowNum;

                for (int i = 1; i >= ttt; i++)
                {
                    tb.GetRow(i).Cells.Clear();
                }
                FileStream fs2 = File.Create(Patch);
                wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。
                return true;
            }
            catch (SyntaxErrorException ex)
            {
                msg.MessageErr(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 清除指定Excel中的数据
        /// </summary>
        /// <param name="_Patch"></param>
        /// <returns></returns>
        public bool ClearDate()
        {
            try
            {
                // kill_Process("excel");
                //将数据填充到模板
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null) { return false; }
                xlApp.Workbooks._Open(Patch);
                Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
                //删除指定区域
                for (int t = 0; t < 24; t++)
                {
                    Excel.Range m_objRange = (Excel.Range)oSheet.Rows[2, System.Reflection.Missing.Value];
                    m_objRange.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }

                //填充完成后的操作
                xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框
                xlApp.AlertBeforeOverwriting = false;
                xlApp.SaveWorkspace(); //保存工作簿
                xlApp.Quit();          //确保Excel进程关闭
                xlApp = null;
                System.GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出
                return true;
            }
            catch (SyntaxErrorException ex)
            {
                msg.MessageInfo(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 清除指定Excel中的数据
        /// </summary>
        /// <param name="_Patch"></param>
        /// <returns></returns>
        public bool ClearDate(int startRow, int ClearCount)
        {
            try
            {
                // kill_Process("excel");
                //将数据填充到模板
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null) { return false; }
                xlApp.Workbooks._Open(Patch);
                Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
                //删除指定区域
                for (int t = startRow; t < ClearCount; t++)
                {
                    Excel.Range m_objRange = (Excel.Range)oSheet.Rows[2, System.Reflection.Missing.Value];
                    m_objRange.EntireRow.Delete(Excel.XlDeleteShiftDirection.xlShiftUp);
                }

                //填充完成后的操作
                xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框
                xlApp.AlertBeforeOverwriting = false;
                xlApp.SaveWorkspace(); //保存工作簿
                xlApp.Quit();          //确保Excel进程关闭
                xlApp = null;
                System.GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出
                return true;
            }
            catch (SyntaxErrorException ex)
            {
                msg.MessageInfo(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获取指定列的索引
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public int GetCollectionIndex(string columnName) => dt.Columns.IndexOf(columnName);
    }

    public class InsertExcelParameter
    {
        public string Type { get; set; }
        public string Paramenter { get; set; }
    }

}
