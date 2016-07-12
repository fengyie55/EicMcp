using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ZhuifengLib
{
    public static class NpoiHelper
    {

        /// <summary>
        /// 将实体类列表导入到Excel中
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t"></param>
        /// <param name="_Patch"></param>
        public static void ExportToExcel<T>(List<T> modelList,string patch)
        {
           
            var wk = new XSSFWorkbook();  //创建工作薄
            var tb = wk.CreateSheet("Data");  //创建一个名称为mySheet的表

            //创建标题
            var row = tb.CreateRow(0); var temCell = 0;
            var properties = modelList[0].GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var item in properties)  //为新行 myRow 赋值
            {
                row.CreateCell(temCell).SetCellValue(item.Name);
                temCell++;
            }


            var rowD = 1;
            //创建数据填充
            foreach (var t in modelList)
            {
                var datarow = tb.CreateRow(rowD);

                var myproperties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var cellD = 0;
                foreach (var item2 in myproperties)
                {
                    var value = item2.GetValue(t, null);
                    datarow.CreateCell(cellD).SetCellValue(string.Format("{0}", value));
                    cellD++;
                }
                rowD++;
            }

            var fs2 = File.Create(patch);
            wk.Write(fs2);   //向打开的这个xls文件中写入mySheet表并保存。

            MessageBox.Show("提示：创建成功！");


        }


      



        /// <summary>
        /// 从Excel表中获取数据
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public static DataTable GenerateTableData(string patch)
        {
            var stream = new FileStream(patch, FileMode.Open, FileAccess.Read);
       
            var workbook = WorkbookFactory.Create(stream);  //使用接口，自动识别excel2003/2007格式
              
           
            var sheet = workbook.GetSheetAt(0);                //得到里面第一个sheet

            var table = new DataTable(sheet.SheetName);
            for (var rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);

                if (row == null)
                    break;

                if (rowIndex == 0)
                {
                    for (var cellIndex = 0; cellIndex < row.LastCellNum; cellIndex++)
                    {
                        var value = row.GetCell(cellIndex).ToString();

                        if (string.IsNullOrEmpty(value)) break;
                        table.Columns.Add(new DataColumn(value));
                    }
                }
                else
                {
                    var datarow = table.NewRow();
                    var objectArray = new object[table.Columns.Count];
                    for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
                    {
                        try
                        {
                            var cell = row.GetCell(columnIndex);

                            if (cell != null)
                                objectArray[columnIndex] = cell.ToString();
                            else
                                objectArray[columnIndex] = string.Empty;
                        }
                        catch (Exception error)
                        {
                            Debug.WriteLine(error.Message);
                            Debug.WriteLine("Column Index" + columnIndex);
                            Debug.WriteLine("Row Index" + row.RowNum);
                        }
                    }
                    datarow.ItemArray = objectArray;
                    table.Rows.Add(datarow);
                }
            }
            return table;
        }


        /// <summary>
        /// DataSet转换为实体列表
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类列表</returns>
        private static IList<T> DataSetToEntityList<T>(DataTable pData)
        {
            // 返回值初始化
            IList<T> result = new List<T>();
            for (var j = 0; j < pData.Rows.Count; j++)
            {
                var t = (T)Activator.CreateInstance(typeof(T));
                var propertys = t.GetType().GetProperties();
                foreach (var pi in propertys)
                {
                    if (pData.Columns.IndexOf(pi.Name.ToUpper()) != -1 && pData.Rows[j][pi.Name.ToUpper()] != DBNull.Value)
                    {
                        var temValue = pData.Rows[j][pi.Name.ToUpper()];
                        if (temValue.ToString().IsInt()) { temValue = temValue.ToString().ToInt(); }
                        pi.SetValue(t,temValue, null);
                    }
                    else
                    {
                        pi.SetValue(t, null, null);
                    }
                }
                result.Add(t);
            }
            return result;
        }

    }

}
