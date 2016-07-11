using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ZhuifengLib.EXCEL
{
    public class ModelToExcel:ExcelControlModel
    {
        /// <summary>
        /// Model导入到Excel
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="t"></param>
        /// <param name="_Patch"></param>
        public void ModelExportExcel<T>(List<T> modelList)  
        {
            /* 1.获取Excel保存路径
             * 2.根据实体类生成模板
             * 3.开始保存*/
            var patch = string.Empty;
            if(modelList.Count <1)return;
            CreateExclTemplater(modelList[0], out patch); 

            if(patch != string.Empty)
            {
                foreach (var tem in modelList)
                {
                    if (tem != null)
                    {
                        ModelToExcel(tem, patch);
                    }

                }
            }

        }

        /// <summary>
        /// Excel导入到Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public List<T> ExcelToModel<T>(string fileName)
        {
             /* 1.获取Excel的路径
              * 2.开始导入
              */
            /*
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = " Excel Files(*.xlsx)|*.xlsx";
            openfiledialog.FilterIndex = 1;

            openfiledialog.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openfiledialog.ShowDialog() == DialogResult.OK;
            string _fileName = openfiledialog.FileName;
            
           
            if (userClickedOK == true)
            {
               

              
            }
             */
           
            var mExcel = new ExcelControl();
            var ds = mExcel.ExcelReader(fileName);
            return DataSetToEntityList<T>(ds, 0).ToList();
        }

        private void CreateExclTemplater<T>(T t,out string _patch)
        {
            //获取文件名
            var patch = string.Empty;
            var saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = " Excel Files(*.xlsx)|*.xlsx";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                patch = saveFileDialog1.FileName;
            }
             _patch = patch;
            
            //生成模板表头
            if(t != null)
            {
                var excel = new ExcelEdit(patch);
                excel.Create();
                var properties = t.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var cell = 1;
                foreach (var item in properties)  //为新行 myRow 赋值
                {
                    var name = item.Name;
                    excel.SetCellValue("Sheet1", 1, cell, name);
                    cell++;
                }
              //  excel.SetCellProperty("Sheet1", 1, 1, 1, Cell, 14, "宋体", Microsoft.Office.Interop.Excel.Constants.xlAutomatic, Microsoft.Office.Interop.Excel.Constants.xlRight);
                excel.SaveAs(patch);
                excel.Close();
            }
           

        }


        /// <summary>
        /// DataSet转换为实体类
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类</returns>
        private T DataSetToEntity<T>(DataSet pDataSet, int pTableIndex)
        {
            if (pDataSet == null || pDataSet.Tables.Count < 0)
                return default(T);
            if (pTableIndex > pDataSet.Tables.Count - 1)
                return default(T);
            if (pTableIndex < 0)
                pTableIndex = 0;
            if (pDataSet.Tables[pTableIndex].Rows.Count <= 0)
                return default(T);

            var pData = pDataSet.Tables[pTableIndex].Rows[0];
            // 返回值初始化
            var t = (T)Activator.CreateInstance(typeof(T));
            var propertys = t.GetType().GetProperties();
            foreach (var pi in propertys)
            {
                if (pDataSet.Tables[pTableIndex].Columns.IndexOf(pi.Name.ToUpper()) != -1 && pData[pi.Name.ToUpper()] != DBNull.Value)
                {
                    pi.SetValue(t, pData[pi.Name.ToUpper()], null);
                }
                else
                {
                    pi.SetValue(t, null, null);
                }
            }
            return t;
        }

        /// <summary>
        /// DataSet转换为实体列表
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类列表</returns>
        private IList<T> DataSetToEntityList<T>(DataSet pDataSet, int pTableIndex)
        {
            if (pDataSet == null || pDataSet.Tables.Count < 0)
                return default(IList<T>);
            if (pTableIndex > pDataSet.Tables.Count - 1)
                return default(IList<T>);
            if (pTableIndex < 0)
                pTableIndex = 0;
            if (pDataSet.Tables[pTableIndex].Rows.Count <= 0)
                return default(IList<T>);

            var pData = pDataSet.Tables[pTableIndex];
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
                            pi.SetValue(t, pData.Rows[j][pi.Name.ToUpper()], null);
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
