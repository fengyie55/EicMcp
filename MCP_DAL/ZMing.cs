using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;


namespace Maticsoft.DAL
{
    class ZMing
    {
        /// <summary>
        /// 控件设置数据源
        /// </summary>
        /// <param name="_DataGrid"></param>
        /// <param name="_Source"></param>
        public void SetDataGriveSource( DataGrid _DataGrid, DataSet _Source)
        {
            _DataGrid.DataSource = _Source.Tables[0].DefaultView;
        }

        /// <summary>
        /// 读取Excel文档
        /// </summary>
        /// <param name="Path">文件名称</param>
        /// <returns>返回一个数据集</returns>
        public DataSet ExcelToDS(string Path)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string strExcel = "";
            OleDbDataAdapter myCommand = null;
            DataSet ds = null;
            strExcel = "select * from [sheet1$]";
            myCommand = new OleDbDataAdapter(strExcel, strConn);
            ds = new DataSet();
            myCommand.Fill(ds, "table1");
            return ds;
        }

    }
}
