using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 返回Sql语句
    /// </summary>
 public  class Cls_SQL_str
    {
     Cls_Find FE = new Cls_Find();
        /// <summary>
        /// 查询语句
        /// </summary>
     public Cls_Find Find
        {
            get { return FE ; }
        }
    }

  

}
