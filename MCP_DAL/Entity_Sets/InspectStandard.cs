using MCP_DBUitility;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System;
using System.Data.SqlClient;


namespace Maticsoft.DAL
{

    /// <summary>
    /// 数据访问类
    /// </summary>
    public partial class InspectStandard
    {
        DbHelperSQL dbs = new DbHelperSQL();
        public InspectStandard() { }
        #region BaseMethod


        //3D测试标准
        ObservableCollection<Maticsoft.Model.TestStandard_3D> _Tem3d
            = new ObservableCollection<Maticsoft.Model.TestStandard_3D>();
        //Exfo测试标准
        ObservableCollection<Maticsoft.Model.TestStandard_Exfo> _TemExfo
            = new ObservableCollection<Model.TestStandard_Exfo>();
     

       TestStandard_3D _tem3d = new DAL.TestStandard_3D();
       TestStandard_Exfo _temExfo = new DAL.TestStandard_Exfo();

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_isd"></param>
        /// <returns></returns>
        public bool Add(Maticsoft.Model.InspectStandard _isd)
        {
            //3D赋值
            _Tem3d.Add(new Model.TestStandard_3D()
            {
                RCO_Max = _isd.RCO_Max,
                RCO_Min = _isd.RCO_Min,
                AE_Max = _isd.AE_Max,
                AE_Min = _isd.AE_Min,
                AO_Max = _isd.AO_Max,
                AO_Min = _isd.AO_Min,
                FH_Max = _isd.FH_Max,
                FH_Min = _isd.FH_Min,
                OrderID = _isd.OrderID,
                Type = _isd.Type
            });
            //Exfo赋值
            _TemExfo.Add(new Model.TestStandard_Exfo()
            {
                IL_Max = _isd.IL_Max,
                IL_Min = _isd.IL_Min,
                RL_Max = _isd.RL_Max,
                RL_Min = _isd.RL_Min,
                OrderID = _isd.OrderID,
                Type = _isd.Type,
                Wave = _isd.Wave
            });
            bool TemExfoAddResult = false;
            Delete(_isd.OrderID, _isd.Type);
            if (_temExfo.Add(_TemExfo[0]) != 0) { TemExfoAddResult = true; }
            if (_tem3d.Add(_Tem3d[0]) && TemExfoAddResult)
            {
                _Tem3d.Clear();
                _TemExfo.Clear();

                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// 确定数据库中是否存在该记录
        /// </summary>
        /// <param name="_orderID">工单单号</param>
        /// <param name="_type">接头类型</param>
        /// <returns></returns>
        public bool Exists(string _orderID, string _type)
        {
            if ( _tem3d.Exists(_orderID, _type) || _temExfo.Exists(_orderID, _type) )
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// 删除数据库中的记录
        /// </summary>
        /// <param name="orderID">工单单号</param>
        /// <param name="_type">接头类型</param>
        /// <returns></returns>
        public bool Delete(string _orderID, string _type)
        {
            if (_tem3d.Delete(_orderID, _type) && _temExfo.Delete(_orderID, _type))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// 删除数据库中的记录
        /// </summary>
        /// <param name="orderID">工单单号</param>
        /// <returns></returns>
        public bool Delete(string _orderID)
        {
            if (_tem3d.Delete(_orderID) && _temExfo.Delete(_orderID))
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string _orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT tb_TestStandard_Exfo.OrderID, tb_TestStandard_Exfo.Type, ");
            strSql.Append(" tb_TestStandard_Exfo.Wave, tb_TestStandard_Exfo.IL_Min,  ");
            strSql.Append(" tb_TestStandard_Exfo.IL_Max, tb_TestStandard_Exfo.RL_Min, ");
            strSql.Append(" tb_TestStandard_Exfo.RL_Max, tb_TestStandard_3D.RCO_Min,  ");
            strSql.Append(" tb_TestStandard_3D.RCO_Max, tb_TestStandard_3D.AO_Min,  ");
            strSql.Append(" tb_TestStandard_3D.AO_Max, tb_TestStandard_3D.FH_Min,  ");
            strSql.Append(" tb_TestStandard_3D.FH_Max, tb_TestStandard_3D.AE_Min,  ");
            strSql.Append(" tb_TestStandard_3D.AE_Max " );
            strSql.Append(" FROM tb_TestStandard_Exfo LEFT OUTER JOIN ");
            strSql.Append(" tb_TestStandard_3D ON tb_TestStandard_Exfo.Type = tb_TestStandard_3D.Type AND  ");
            strSql.Append(" tb_TestStandard_Exfo.OrderID = tb_TestStandard_3D.OrderID ");
            strSql.Append(" WHERE (tb_TestStandard_Exfo.OrderID = '"+_orderID+"') ");
            /*
            SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,20)};
            parameters[0].Value = _orderID;
             */
            return dbs.Query(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.InspectStandard DataRowToModel(DataRow row)
        {
            Maticsoft.Model.InspectStandard model = new Maticsoft.Model.InspectStandard();
            if (row != null)
            {
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["RCO_Min"] != null)
                {
                    model.RCO_Min = row["RCO_Min"].ToString();
                }
                if (row["RCO_Max"] != null)
                {
                    model.RCO_Max = row["RCO_Max"].ToString();
                }
                if (row["AO_Min"] != null)
                {
                    model.AO_Min = row["AO_Min"].ToString();
                }
                if (row["AO_Max"] != null)
                {
                    model.AO_Max = row["AO_Max"].ToString();
                }
                if (row["FH_Min"] != null)
                {
                    model.FH_Min = row["FH_Min"].ToString();
                }
                if (row["FH_Max"] != null)
                {
                    model.FH_Max = row["FH_Max"].ToString();
                }
                if (row["AE_Min"] != null)
                {
                    model.AE_Min = row["AE_Min"].ToString();
                }
                if (row["AE_Max"] != null)
                {
                    model.AE_Max = row["AE_Max"].ToString();
                }
                if (row["OrderID"] != null)
                {
                    model.OrderID = row["OrderID"].ToString();
                }
                
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["Wave"] != null)
                {
                    model.Wave = row["Wave"].ToString();
                }
                if (row["IL_Min"] != null)
                {
                    model.IL_Min = row["IL_Min"].ToString();
                }
                if (row["IL_Max"] != null)
                {
                    model.IL_Max = row["IL_Max"].ToString();
                }
                if (row["RL_Min"] != null)
                {
                    model.RL_Min = row["RL_Min"].ToString();
                }
                if (row["RL_Max"] != null)
                {
                    model.RL_Max = row["RL_Max"].ToString();
                }             
               
            }
            return model;
        }

        #endregion
    }
}
