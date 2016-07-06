using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace DAL
{
  public  class Cls_Find
    {
      /*
        #region Exfo查询
        string _SN;
        Cls_ISP_Exfo_Standard _ISP;
        /// <summary>
        /// 查询Exfo数据
        /// </summary>
        /// <param name="_SN">条码</param>
        /// <param name="_ISP">检测标准</param>
        /// <param name="Isp_Method">检测方法</param>
        /// <param name="Connector">接头数量</param>
        /// <returns>string类型的 sql查询语句</returns>
        public string Exfo(string _SN, Cls_ISP_Exfo_Standard _ISP, E_InspectMethod Isp_Method, int Connector)
        {
            this._SN = _SN;      //SN编码赋值
            this._ISP = _ISP;    //检测标准
            if (E_InspectMethod.双并线材 == Isp_Method)  //检测类型为双并
            {
                return Paralleling();
            }
            else
            {
                if (E_InspectMethod.一码一头 == Isp_Method) //检测类型为单芯
                {
                    return One_Connector();
                }
                else //检测类型为多芯
                {
                    return More_Connector(Connector);
                }
            }
        }

        #region 方法
        /// <summary>
        /// 单芯
        /// </summary>
        /// <returns></returns>
        private string One_Connector()
        {
            string sql = " SELECT SUBSTRING(SN, 1, 10) AS SN, SUBSTRING(SN, 12, 2) AS Name, Result,";
            sql += " Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate FROM User_JDS_Test_Good";
            sql += " WHERE (SN LIKE '" + _SN + "%') AND (Result = 'Passed')";
            sql += " AND (IL_A > '" + _ISP.IL_Min + "')";
            sql += " AND (IL_A < '" + _ISP.IL_Max + "')";
            sql += " AND (Refl_A > '" + _ISP.RL_Min + "')";
            sql += " AND (Refl_A < '" + _ISP.RL_Max + "')  ";
            return sql;
        }


        //双并
        private string Paralleling()
        {
            string sql = " SELECT * FROM (SELECT SUBSTRING(SN, 1, 10) AS SN, SUBSTRING(SN, 12, 2) AS Name, Result,";
            sql += " Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate FROM User_JDS_Test_Good";
            sql += " WHERE (SN LIKE '" + _SN + "%') AND (Result = 'Passed')";
            sql += " AND (IL_A > '" + _ISP.IL_Min + "')";
            sql += " AND (IL_A < '" + _ISP.IL_Max + "')";
            sql += " AND (Refl_A > '" + _ISP.RL_Min + "')";
            sql += " AND (Refl_A < '" + _ISP.RL_Max + "') ) AS TemTab ";
            sql += " WHERE (Name IN ('A1', 'A2', 'B1', 'B2')) ";
            sql += " ORDER BY Name";
            return sql;
        }



        /// <summary>
        /// 多芯
        /// </summary>
        /// <returns></returns>
        private string More_Connector(int _Connector)
        {
            string sql = " SELECT * FROM (SELECT SUBSTRING(SN, 1, 10) AS SN, SUBSTRING(SN, 12, 2) AS Name, Result,";
            sql += " Wave, IL_A, Refl_A, IL_B, Refl_B, TestDate FROM User_JDS_Test_Good";
            sql += " WHERE (SN LIKE '" + _SN + "%') AND (Result = 'Passed')";
            sql += " AND (IL_A > '" + _ISP.IL_Min + "')";
            sql += " AND (IL_A < '" + _ISP.IL_Max + "')";
            sql += " AND (Refl_A > '" + _ISP.RL_Min + "')";
            sql += " AND (Refl_A < '" + _ISP.RL_Max + "') ) AS TemTab ";
            sql += " WHERE (Name IN (" + Find_IN_Name(_Connector) + ")) ";
            sql += " ORDER BY Name";
            return sql;
        }

        /// <summary>
        /// 生成Name列的查询字符
        /// </summary>
        /// <param name="Connector">连接头数量</param>
        /// <returns></returns>
        private string Find_IN_Name(int Connector) //动态生成 3D数据查询字符
        {
            string Tem = "'1'";
            for (int t = 2; t < Connector + 1; t++)
            {
                Tem = Tem + " ,'" + t + "'";
            }
            return Tem;  // ('1', '2', '3', '4')
        }

        #endregion
        #endregion
       */
    }

}
