using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
using System.Collections;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:TestStandard_Exfo
	/// </summary>
	public partial class TestStandard_Exfo
	{

		public TestStandard_Exfo()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string _orderID, string _type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestStandard_Exfo");
            strSql.Append(" where OrderID=@OrderID AND Type=@Type ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,15),
					new SqlParameter("@Type", SqlDbType.VarChar,15)
			};
            parameters[0].Value = _orderID;
            parameters[1].Value = _type;

            return dbs.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 生成Sql查询语句-Exfo
        /// </summary>
        /// <param name="SN">Pigtail编码</param>
        /// <returns></returns>                                                                                                                                                                                                                                                     
        public string Get_StrWhere(string _sn, Maticsoft.Model.TestStandard_Exfo _tsetStandard)
        {
            string _Tem = "";
            
            if (_tsetStandard != null)
            {
                _Tem += "   (SN IN " + _sn + ") ";
                _Tem += " AND (CONVERT(float,IL_A) >= " + _tsetStandard.IL_Min + ") AND (CONVERT(float,Refl_A) >= " + _tsetStandard.RL_Min + ")  ";
                _Tem += " AND (CONVERT(float,IL_A) <= " + _tsetStandard.IL_Max + ") AND (CONVERT(float,Refl_A) <= " + _tsetStandard.RL_Max + ") AND (Wave = '1550nm') ";
            }
            else
            {
                _Tem += "   (SN IN " + _sn + ") AND (Wave = '1550nm') ";
            }
             
           //  _Tem += "   (SN IN " + _sn + ") AND (Wave = '1550nm') ";
           return _Tem;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.TestStandard_Exfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_TestStandard_Exfo(");
			strSql.Append("Type,Wave,IL_Min,IL_Max,RL_Min,RL_Max,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Wave,@IL_Min,@IL_Max,@RL_Min,@RL_Max,@OrderID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,15),
					new SqlParameter("@Wave", SqlDbType.VarChar,15),
					new SqlParameter("@IL_Min", SqlDbType.VarChar,15),
					new SqlParameter("@IL_Max", SqlDbType.VarChar,15),
					new SqlParameter("@RL_Min", SqlDbType.VarChar,15),
					new SqlParameter("@RL_Max", SqlDbType.VarChar,15),
					new SqlParameter("@OrderID", SqlDbType.VarChar,15)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Wave;
			parameters[2].Value = model.IL_Min;
			parameters[3].Value = model.IL_Max;
			parameters[4].Value = model.RL_Min;
			parameters[5].Value = model.RL_Max;
			parameters[6].Value = model.OrderID;

			object obj = dbs.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.TestStandard_Exfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_TestStandard_Exfo set ");
			strSql.Append("Type=@Type,");
			strSql.Append("Wave=@Wave,");
			strSql.Append("IL_Min=@IL_Min,");
			strSql.Append("IL_Max=@IL_Max,");
			strSql.Append("RL_Min=@RL_Min,");
			strSql.Append("RL_Max=@RL_Max,");
			strSql.Append("OrderID=@OrderID");
			
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,15),
					new SqlParameter("@Wave", SqlDbType.VarChar,15),
					new SqlParameter("@IL_Min", SqlDbType.VarChar,15),
					new SqlParameter("@IL_Max", SqlDbType.VarChar,15),
					new SqlParameter("@RL_Min", SqlDbType.VarChar,15),
					new SqlParameter("@RL_Max", SqlDbType.VarChar,15),
					new SqlParameter("@OrderID", SqlDbType.VarChar,15)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Wave;
			parameters[2].Value = model.IL_Min;
			parameters[3].Value = model.IL_Max;
			parameters[4].Value = model.RL_Min;
			parameters[5].Value = model.RL_Max;
			parameters[6].Value = model.OrderID;

			int rows=dbs.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string _orderID ,string _type)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_TestStandard_Exfo ");
			strSql.Append(" where OrderID=@OrderID AND Type=@Type ");
			SqlParameter[] parameters = {
                    new SqlParameter("@OrderID", SqlDbType.VarChar,15),
					new SqlParameter("@Type", SqlDbType.VarChar,15)
			};
			parameters[0].Value = _orderID;
            parameters[1].Value = _type;

			int rows=dbs.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string _orderID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestStandard_Exfo ");
            strSql.Append(" where OrderID= '"+_orderID+"' ");          
            int rows = dbs.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string ID_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_TestStandard_Exfo ");
			strSql.Append(" where ID_Key in ("+ID_Keylist + ")  ");
			int rows=dbs.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.TestStandard_Exfo GetModel(string Where)
		{			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Type,Wave,IL_Min,IL_Max,RL_Min,RL_Max,OrderID,ID_Key from tb_TestStandard_Exfo ");
			strSql.Append(" where "+Where+"");
		
			Maticsoft.Model.TestStandard_Exfo model=new Maticsoft.Model.TestStandard_Exfo();
			DataSet ds=dbs.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.TestStandard_Exfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.TestStandard_Exfo model=new Maticsoft.Model.TestStandard_Exfo();
			if (row != null)
			{
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Wave"]!=null)
				{
					model.Wave=row["Wave"].ToString();
				}
				if(row["IL_Min"]!=null)
				{
					model.IL_Min=row["IL_Min"].ToString();
				}
				if(row["IL_Max"]!=null)
				{
					model.IL_Max=row["IL_Max"].ToString();
				}
				if(row["RL_Min"]!=null)
				{
					model.RL_Min=row["RL_Min"].ToString();
				}
				if(row["RL_Max"]!=null)
				{
					model.RL_Max=row["RL_Max"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Type,Wave,IL_Min,IL_Max,RL_Min,RL_Max,OrderID,ID_Key ");
			strSql.Append(" FROM tb_TestStandard_Exfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbs.Query(strSql.ToString());
		}
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        public ArrayList GetArrayList(string _strWhere)
        {
            ArrayList tem = new ArrayList();
            DataSet temds = GetList(_strWhere);
            foreach (DataRow dr in temds.Tables[0].Rows)
            {
                tem.Add(DataRowToModel(dr));
            }
            return tem;
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Type,Wave,IL_Min,IL_Max,RL_Min,RL_Max,OrderID,ID_Key ");
			strSql.Append(" FROM tb_TestStandard_Exfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return dbs.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_TestStandard_Exfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = dbs.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID_Key desc");
			}
			strSql.Append(")AS Row, T.*  from tb_TestStandard_Exfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return dbs.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_TestStandard_Exfo";
			parameters[1].Value = "ID_Key";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

