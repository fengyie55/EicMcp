using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using MessageBox = System.Windows.MessageBox;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

/********************************************
 * 名称：clsExtension
 * 功能:  扩展方法： 对现有无法修改的类进行方法的添加，如 string int bool 等
 * 版本: V 1.0.0
 * 日期: 2015-02-12 16:12
 * 作者: 张文明  修改:
 ********************************************/

namespace ZhuifengLib
{
    public static class ExtensionMethod
    {

        #region string

        /// <summary>
        /// 字符串是否为Null
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// 是否为Int类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(this string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        /// <summary>
        /// 转换为Int类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        /// <summary>
        ///  是否为double类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Isdouble(this string s)
        {
            double i;
            return double.TryParse(s, out i);
        }
        
        /// <summary>
        /// 转换为doublel类型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double Todouble(this string s)
        {
            return double.Parse(s);
        }


        #endregion

        #region int



        #endregion

        #region DataTable
        /// <summary>
        /// DataTable转换为List
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> List<T>(this DataTable dt)
        {
            var list = new List<T>();
            var t = typeof(T);
            var plist = new List<PropertyInfo>(typeof(T).GetProperties());

            foreach (DataRow item in dt.Rows)
            {
                var s = Activator.CreateInstance<T>();
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    var info = plist.Find(p => p.Name == dt.Columns[i].ColumnName);
                    if (info != null)
                    {
                        if (!Convert.IsDBNull(item[i]))
                        {
                            info.SetValue(s, item[i], null);
                        }
                    }
                }
                list.Add(s);
            }
            return list;
        }

        /// <summary>
        /// DataSet转换为实体列表
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类列表</returns>
        public static List<T> ToList<T>(this DataTable pData)
        {
            // 返回值初始化
            var result = new List<T>();
            for (var j = 0; j < pData.Rows.Count; j++)
            {
                var t = (T)Activator.CreateInstance(typeof(T));
                var propertys = t.GetType().GetProperties();
                foreach (var pi in propertys)
                {
                    if (pData.Columns.IndexOf(pi.Name.ToUpper()) != -1 && pData.Rows[j][pi.Name.ToUpper()] != DBNull.Value)
                    {
                        var temValue = pData.Rows[j][pi.Name.ToUpper()];
                        if(!temValue.ToString().IsNullOrEmpty())
                        {
                            if (temValue.ToString().IsInt()) { temValue = temValue.ToString().ToInt(); } //是否Int
                            else if (temValue.ToString().Isdouble()) { temValue = temValue.ToString().Todouble(); }

                            pi.SetValue(t, temValue, null);
                        }
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

        #endregion

        #region List<T>
        //http://blog.csdn.net/flyingdream123/article/details/9294973
        //要复制的实例必须可序列化，包括实例引用的其它实例都必须在类定义时加[Serializable]特性。  
        public static T Copy<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制     
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }
        /// <summary>
        ///  将实体类列表到处到Excel中 支持Excel2007
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dt"></param>
        /// <param name="patch">绝对路径</param>
        /// <param name="isCreateTitle">是否生成标题</param>
        public static void ExportToExcel<T>(this List<T> dt, string patch,bool isCreateTitle, int inputStartRow)
        {
            m_ExportToExcel(dt, patch,isCreateTitle, inputStartRow);
        }

        /// <summary>
        ///  将实体类列表到处到Excel中 支持Excel2007
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="ls"></param>
        /// <param name="isCreateTitle">是否生成标题</param>
        public static void ExportToExcel<T>(this List<T> ls,bool isCreateTitle,int inputStartRow)
        { 
            //string localFilePath, fileNameExt, newFileName, FilePath; 
            var sfd = new SaveFileDialog();
            //设置文件类型 
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var localFilePath = sfd.FileName; //获得文件路径 
                var fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                m_ExportToExcel(ls, localFilePath,isCreateTitle, inputStartRow);
            }
           
        }


        /// <summary>
        /// 将实体类列表到处到根据模板创建的Excel中 支持Excel2007
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ls"></param>
        /// <param name="modulePatch"></param>
        /// <param name="inputStartRow"></param>
        public static void ExportToExcel_forModule<T>(this List<T> ls, string modulePatch,int inputStartRow)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel 2007 (*.xlsx)|*.xlsx";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string localFilePath = sfd.FileName.ToString(); //获得文件路径 
                File.Copy(modulePatch, localFilePath, true);
                m_ExportToExcel(ls, localFilePath, false, inputStartRow);
            }
        }
       
        /// <summary>
        /// 判断此集合是否为空 集合是否大于1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this List<T> dt)
        {
            if (dt == null || dt.Count < 1)
                return false;
            return true;
        }



        /// <summary>
        /// 导出数据到Excel
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dt"></param>
        /// <param name="patch">导出的绝对路径</param>
        /// <param name="isCreateTitle">是否创建标题</param>
        /// <param name="inputStartRow">数据从第几行开始插入 请默认设置为 1 </param>
        private static void m_ExportToExcel<T>(List<T> dt, string patch, bool isCreateTitle, int inputStartRow)
        {
            if (dt.Count > 0)
            {
                ISheet tb = null;
                IWorkbook wk = null;
                if (File.Exists(patch))               //如果文件存在 说明是从模板创建的
                {
                    wk = WorkbookFactory.Create(patch);
                    tb = wk.GetSheet(wk.GetSheetName(0));
                }
                else                                  //如果文件不存在，说明需要新建一个Excel
                {
                    wk = new XSSFWorkbook();
                    tb = wk.CreateSheet("mySheet");
                }

                if (isCreateTitle)                    //创建标题
                {
                    var row = tb.CreateRow(0); var temCell = 0;
                    var properties = dt[0].GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    foreach (var item in properties)  //为新行 myRow 赋值
                    {
                        row.CreateCell(temCell).SetCellValue(item.Name);
                        temCell++;
                    }
                }

                foreach (var t in dt)                 //创建数据填充
                {

                    var datarow = tb.CreateRow(inputStartRow);

                    var myproperties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    var cellD = 0;
                    foreach (var item2 in myproperties)
                    {

                        var value = item2.GetValue(t, null);
                        if (value != null)
                        {
                            switch (value.GetType().ToString())
                            {
                                case "System.String"://字符串类型   
                                    datarow.CreateCell(cellD).SetCellValue(string.Format("{0}", value));
                                    break;
                                //case "System.DateTime"://日期类型   
                                //    DateTime dateV;
                                //    DateTime.TryParse(value.ToString(), out dateV);
                                //    datarow.CreateCell(cellD).SetCellValue(dateV);

                                // datarow.CreateCell(cellD).CellStyle = 
                                //break;
                                case "System.Boolean"://布尔型   
                                    bool boolV = false;
                                    bool.TryParse(value.ToString(), out boolV);
                                    datarow.CreateCell(cellD).SetCellValue(boolV);
                                    break;
                                case "System.Int16"://整型   
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Byte":
                                    int intV = 0;
                                    int.TryParse(value.ToString(), out intV);
                                    datarow.CreateCell(cellD).SetCellValue(intV);
                                    break;
                                case "System.Decimal"://浮点型   
                                case "System.Double":
                                    double doubV = 0;
                                    double.TryParse(value.ToString(), out doubV);
                                    datarow.CreateCell(cellD).SetCellValue(doubV);
                                    break;
                                case "System.DBNull"://空值处理   
                                    datarow.CreateCell(cellD).SetCellValue("");
                                    break;
                                default:
                                    datarow.CreateCell(cellD).SetCellValue(string.Format("{0}", value));
                                    break;
                            }
                        }
                        cellD++;
                    }
                    inputStartRow++;
                }

                var fs2 = File.Create(patch);
                wk.Write(fs2);                         //向打开的这个xls文件中写入mySheet表并保存。

                MessageBox.Show("提示：导出完成！");
            }
            else
            {
                MessageBox.Show("无任何需要导出的项目！");
            }
        }
        

        #endregion

    }



}
