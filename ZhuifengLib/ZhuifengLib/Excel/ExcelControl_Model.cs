using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

namespace ZhuifengLib.EXCEL
{
    /**************************************
     * 类名:ExelcControl_Model 
     * 功能：实体类导入到Excel
     * 说明: 提供实体类导入Excel中的方法
     * 作者: 张明
     * 版本：V1.0.0
     * 创建日期:2015-4-6 12:29
     *************************************/
    public  class ExcelControlModel
    {

        /// <summary>
        /// 实体类导入到 Excel模板
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化的实体类</param>
        /// <param name="_Patch">要保存到Excel模板的完整文件名</param>
        public void ModelToExcel<T>(T t, string patch)
        {
            if (t != null)
            {
                var properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                if (properties.Length > 0)
                {
                    var strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + patch + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
                    
                    var myConn = new OleDbConnection(strCon);

                    var strCom = "SELECT * FROM [Sheet1$]";
                    myConn.Open();

                    var myDataAdapter = new OleDbDataAdapter(strCom, myConn);

                    var myDataSet = new DataSet();

                    myDataAdapter.Fill(myDataSet, "[Sheet1$]");

                    myConn.Close();

                    var dt = myDataSet.Tables[0]; //初始化DataTable实例
                    var myRow = dt.NewRow();       //新行

                    foreach (var item in properties)  //为新行 myRow 赋值
                    {
                        var name = item.Name;
                        var value = item.GetValue(t, null);
                        if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                        {
                            myRow[string.Format("{0}", name)] = string.Format("{0}", value);
                        }
                        else
                        {
                            ModelToExcel(value, patch);
                        }
                    }
                    dt.Rows.Add(myRow);  //添加新行到表 [Sheet1$]
                    var odcb = new OleDbCommandBuilder(myDataAdapter);

                    odcb.QuotePrefix = "[";   //用于搞定INSERT INTO 语句的语法错误

                    odcb.QuoteSuffix = "]";

                    myDataAdapter.Update(myDataSet, "[Sheet1$]"); //更新数据集对应的表

                }
            }
        }


        /// <summary>
        /// 实体类导入Excel模板
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="t">实例化的实体类</param>
        /// <param name="_Patch">要保存到Excel模板的完整文件名</param>
        public void ModelToExcel<T>(List<T> t, string patch)
        {
            foreach (var tem in t)
            {
                if (tem != null)
                {
                    ModelToExcel(tem, patch);
                }

            }
        }

        /// <summary>
        /// 将指定的Excel转换为DataSet
        /// </summary>
        /// <param name="_Patch"></param>
        public DataTable ExcelToDataSet(string patch)
        {
            var strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + patch + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
            var myConn = new OleDbConnection(strCon);
            var strCom = "SELECT * FROM [Sheet1$]";
            myConn.Open();
            var myDataAdapter = new OleDbDataAdapter(strCom, myConn);
            var myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "[Sheet1$]");
            myConn.Close();
            var dt = myDataSet.Tables[0]; //初始化DataTable实例
            return dt;
        }

        public void DataTabToExcel<T>(List<T> t, string patch)
        {
            var strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + patch + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";
            var myConn = new OleDbConnection(strCon);
            var strCom = "SELECT * FROM [Sheet1$]";
            myConn.Open();
            var myDataAdapter = new OleDbDataAdapter(strCom, myConn);
            var myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet, "[Sheet1$]");
            myConn.Close();
            var dt = myDataSet.Tables[0]; //初始化DataTable实例
            foreach (var tem in t)
            {
                var myRow = dt.NewRow();       //新行
                if (tem != null)
                {
                    var properties = tem.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    if (properties.Length > 0)
                    {
                        foreach (var item in properties)  //为新行 myRow 赋值
                        {
                            var name = item.Name;
                            var value = item.GetValue(tem, null);
                            myRow[string.Format("{0}", name)] = string.Format("{0}", value);
                        }
                    }
                }
                dt.Rows.Add(myRow);  //添加新行到表 [Sheet1$]
            }
            var odcb = new OleDbCommandBuilder(myDataAdapter);
            odcb.QuotePrefix = "[";   //用于搞定INSERT INTO 语句的语法错误
            odcb.QuoteSuffix = "]";
            myDataAdapter.Update(myDataSet, "[Sheet1$]"); //更新数据集对应的表
        }
        private void Test()
        {
            //IMEX：只有是0才能成功更新，1或2都有错误提示，操作必须使用一个可更新的查询，2也有奇怪？

            var path = "D:\\模板\\ProcessFlow.xlsx";
            var strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";

            var myConn = new OleDbConnection(strCon);

            var strCom = "SELECT * FROM [Sheet1$]";

            myConn.Open();

            var myDataAdapter = new OleDbDataAdapter(strCom, myConn);

            var myDataSet = new DataSet();

            myDataAdapter.Fill(myDataSet, "[Sheet1$]");

            myConn.Close();

            var dt = myDataSet.Tables[0]; //初始化DataTable实例

            //  dt.PrimaryKey = new DataColumn[] { dt.Columns["ID_Key"] };//创建索引列

            var myRow = dt.NewRow();

            myRow["Value"] = "2015-3-31 10:27:54";

          

            dt.Rows.Add(myRow);

            var odcb = new OleDbCommandBuilder(myDataAdapter);

            odcb.QuotePrefix = "[";   //用于搞定INSERT INTO 语句的语法错误

            odcb.QuoteSuffix = "]";

            myDataAdapter.Update(myDataSet, "[Sheet1$]"); //更新数据集对应的表


        }

    }
}
