using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MCP_DBUitility
{
    /// <summary>
    /// 数据库连接字符类
    /// </summary>
 public   class Cls_DBConnection
    {
        /// <summary>
        /// 连接到—db_MCP数据库
        /// </summary>
        /// <returns></returns>
        public static SqlConnection MyConnection_MCP()
        {
            return new SqlConnection("Data Source=QQQQ-MS2;Initial Catalog=db_MCP;User ID=sa;Password=1234567890");
        }

        /// <summary>
        /// 连接到—TwoLine数据库
        /// </summary>
        /// <returns></returns>
        public static SqlConnection MyConnection_ds_TwoLine()
        {
            return new SqlConnection("Data Source=QQQQ-MS2;Initial Catalog=TwoLine;User ID=sa;Password=1234567890");
        }


    }
}
