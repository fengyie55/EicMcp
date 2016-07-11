using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using ZhuifengLib.MessageShow;

namespace ZhuifengLib.EXCEL
{
    public class ExcelControl
    {

        private Application _excel = new Application();//引用Excel对象
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="excelPatch"></param>
        /// <param name="errInfo"></param>
        public void OpenExcel(string excelPatch, out string errInfo)
        {
            _excel.Workbooks._Open(excelPatch);
            _excel.Visible = true;//使Excel可视
            errInfo = "";
        }

        /// <summary>
        /// 读取Excel数据到DS
        /// </summary>
        /// <param name="excelName">xls文件路径(服务器物理路径)string RootDir =Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录</param>
        /// <returns></returns>
        public DataSet ExcelReader(string excelName)
        {
            try
            {
                return ExcelToDataSet_OleDb(excelName);
            }
            catch 
            {
                var ds = new DataSet();
              return  ExecleToDataSet(excelName, 1, "");
                
            }
         
        }

        private static DataSet ExcelToDataSet_OleDb(string excelName)
        {

            // 拼写连接字符串，打开连接
            var strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "data source=" + excelName + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";
            var objConn = new OleDbConnection(strConn);
            objConn.Open();
            // 取得Excel工作簿中所有工作表
            var schemaTable = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            var sqlada = new OleDbDataAdapter();
            var ds = new DataSet();
            // 遍历工作表取得数据并存入Dataset
            foreach (DataRow dr in schemaTable.Rows)
            {
                var strSql = "Select * From [" + dr[2].ToString().Trim() + "]";
                var objCmd = new OleDbCommand(strSql, objConn);
                sqlada.SelectCommand = objCmd;
                sqlada.Fill(ds, dr[2].ToString().Trim());
            }
            objConn.Close();
            return ds;
        }

        /// <summary>
        /// 清除Excel中的内容
        /// </summary>
        /// <param name="excelPatch"></param>
        /// <param name="rows"></param>
        public bool ClearDate(string excelPatch, int rows)
        {
            try
            {
                // kill_Process("excel");
                //将数据填充到模板
                var xlApp = new Application();
                if (xlApp == null) { return false; }
                xlApp.Workbooks._Open(excelPatch);
                var oSheet = (_Worksheet)xlApp.Sheets.get_Item(1);
                //删除指定区域
                for (var t = 0; t <= rows; t++)
                {
                    var mObjRange = (Range)oSheet.Rows[2, Missing.Value];
                    mObjRange.EntireRow.Delete(XlDeleteShiftDirection.xlShiftUp);
                }

                //填充完成后的操作          
                xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
                xlApp.AlertBeforeOverwriting = false;
                xlApp.SaveWorkspace(); //保存工作簿  
                xlApp.Quit();          //确保Excel进程关闭  
                xlApp = null;
                GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出 
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// 实体类导入到 Excel模板
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化的实体类</param>
        /// <param name="_Patch">要保存到Excel模板的完整文件名</param>
        public void ModelToExcel<T>(T t, string patch) 
        {
            var tLineName = string.Empty;   //标题
            var tLineValue = string.Empty;  //值

            if (t == null) { }
            var properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (properties.Length <= 0) { }
            foreach (var item in properties)
            {
                var name = item.Name;
                var value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    tLineName += string.Format("{0},", name);
                    tLineValue += string.Format("'{0}',", value);
                }
                else
                {
                    ModelToExcel(value, patch);
                }
            }
            tLineName = tLineName.Substring(0, tLineName.Length - 1);
            tLineValue = tLineValue.Substring(0, tLineValue.Length - 1);
            SaveFp2ToExcel(patch, tLineName, tLineValue);
        }

        /// <summary>
        /// 实体类导入Excel模板
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化的实体类</param>
        /// <param name="_Patch">要保存到Excel模板的完整文件名</param>
        public void ModelToExcel<T>(List<T> t,string patch)
        {
            foreach(var tem in t)
            {
                if(tem != null)
                {
                    ModelToExcel(tem, patch);
                }
               
            }
        }

       /// <summary>
       /// 写入Excel
       /// </summary>
       /// <param name="_Path">保存文件的路径</param>
       /// <param name="_lineName">列名称</param>
       /// <param name="_lineValue">列值</param>
       /// <returns></returns>
 
        public bool SaveFp2ToExcel(string path, string lineName, string lineValue)
        {
            try
            {
                var strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";" + "Extended Properties=Excel 8.0;";
                var conn = new OleDbConnection(strConn);
                conn.Open();
                var cmd = new OleDbCommand();
                cmd.Connection = conn;
                //插入数据的命令
                cmd.CommandText = "INSERT INTO [sheet1$] (" + lineName + ") VALUES (" + lineValue + ")";
                cmd.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch(SystemException ex) { Message.MessageInfo(ex.Message); return false; }

        }


        /// <summary> 
        /// 把Excel里的数据转换为DataTable,应用引用的com组件：Microsoft.Office.Interop.Excel.dll 读取EXCEL文件
        /// </summary> 
        /// <param name="filenameurl">物理路径</param> 
        /// <param name="sheetIndex">sheet名称的索引</param> 
        /// <param name="splitstr">如果是已存在列，则自定义添加的字符串</param> 
        /// <returns></returns> 
        public DataSet ExecleToDataSet(string filenameurl, int sheetIndex, string splitstr)
        {
            // 
            Workbook wb = null;
            Worksheet ws = null;
            var isEqual = false;//不相等 
            var columnArr = new ArrayList();//列字段表 
            var myDs = new DataSet();
            var xlsTable = myDs.Tables.Add("show");
            object missing = Missing.Value;
            var excel = new Application();//lauch excel application
            if (excel != null)
            {
                excel.Visible = false;
                excel.UserControl = true;
                // 以只读的形式打开EXCEL文件 
                wb = excel.Workbooks.Open(filenameurl, missing, true, missing, missing, missing,
                 missing, missing, missing, true, missing, missing, missing, missing, missing);
                //取得第一个工作薄 
                ws = (Worksheet)wb.Worksheets.get_Item(sheetIndex);
                //取得总记录行数(包括标题列) 
                var rowsint = ws.UsedRange.Cells.Rows.Count; //得到行数 
                var columnsint = ws.UsedRange.Cells.Columns.Count;//得到列数 
                DataRow dr;
                for (var i = 1; i <= columnsint; i++)
                {
                    //判断是否有列相同 
                    if (i >= 2)
                    {
                        var r = 0;
                        for (var k = 1; k <= i - 1; k++)//列从第一列到第i-1列遍历进行比较 
                        {
                            if (((Range)ws.Cells[1, i]).Text.ToString() == ((Range)ws.Cells[1, k]).Text.ToString())
                            {
                                //如果该列的值等于前面列中某一列的值 
                                xlsTable.Columns.Add(((Range)ws.Cells[1, i]).Text.ToString() + splitstr + (r + 1).ToString(), typeof(string));
                                columnArr.Add(((Range)ws.Cells[1, i]).Text.ToString() + splitstr + (r + 1).ToString());
                                isEqual = true;
                                r++;
                                break;
                            }
                            isEqual = false;
                        }
                        if (!isEqual)
                        {
                            xlsTable.Columns.Add(((Range)ws.Cells[1, i]).Text.ToString(), typeof(string));
                            columnArr.Add(((Range)ws.Cells[1, i]).Text.ToString());
                        }
                    }
                    else
                    {
                        xlsTable.Columns.Add(((Range)ws.Cells[1, i]).Text.ToString(), typeof(string));
                        columnArr.Add(((Range)ws.Cells[1, i]).Text.ToString());
                    }
                }
                for (var i = 2; i <= rowsint; i++)
                {
                    dr = xlsTable.NewRow();
                    for (var j = 1; j <= columnsint; j++)
                    {
                        dr[columnArr[j - 1].ToString()] = ((Range)ws.Cells[i, j]).Text.ToString();
                    }
                    xlsTable.Rows.Add(dr);
                }
            }
            excel.Quit();
            excel = null;
            // Dispose(ws, wb);
            return myDs;
        }



       
    }

    
}
