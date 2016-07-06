using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
using System.Collections;

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:TestStandard_3D
	/// </summary>
	public partial class TestStandard_3D
	{
		public TestStandard_3D()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();
       
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string _orderID,string _type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_TestStandard_3D");
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
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.TestStandard_3D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_TestStandard_3D(");
			strSql.Append("Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@Type,@RCO_Min,@RCO_Max,@AO_Min,@AO_Max,@FH_Min,@FH_Max,@AE_Min,@AE_Max,@OrderID)");
			SqlParameter[] parameters = {
					new SqlParameter("@Type",    SqlDbType.VarChar,15),
					new SqlParameter("@RCO_Min", SqlDbType.VarChar,15),
					new SqlParameter("@RCO_Max", SqlDbType.VarChar,15),
					new SqlParameter("@AO_Min",  SqlDbType.VarChar,15),
					new SqlParameter("@AO_Max",  SqlDbType.VarChar,15),
					new SqlParameter("@FH_Min",  SqlDbType.VarChar,15),
					new SqlParameter("@FH_Max",  SqlDbType.VarChar,15),
					new SqlParameter("@AE_Min",  SqlDbType.VarChar,15),
					new SqlParameter("@AE_Max",  SqlDbType.VarChar,15),
					new SqlParameter("@OrderID", SqlDbType.VarChar,15)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.RCO_Min;
			parameters[2].Value = model.RCO_Max;
			parameters[3].Value = model.AO_Min;
			parameters[4].Value = model.AO_Max;
			parameters[5].Value = model.FH_Min;
			parameters[6].Value = model.FH_Max;
			parameters[7].Value = model.AE_Min;
			parameters[8].Value = model.AE_Max;
			parameters[9].Value = model.OrderID;			
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.TestStandard_3D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_TestStandard_3D set ");
			strSql.Append("Type=@Type,");
			strSql.Append("RCO_Min=@RCO_Min,");
			strSql.Append("RCO_Max=@RCO_Max,");
			strSql.Append("AO_Min=@AO_Min,");
			strSql.Append("AO_Max=@AO_Max,");
			strSql.Append("FH_Min=@FH_Min,");
			strSql.Append("FH_Max=@FH_Max,");
			strSql.Append("AE_Min=@AE_Min,");
			strSql.Append("AE_Max=@AE_Max,");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("ID_Key=@ID_Key");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,15),
					new SqlParameter("@RCO_Min", SqlDbType.VarChar,15),
					new SqlParameter("@RCO_Max", SqlDbType.VarChar,15),
					new SqlParameter("@AO_Min", SqlDbType.VarChar,15),
					new SqlParameter("@AO_Max", SqlDbType.VarChar,15),
					new SqlParameter("@FH_Min", SqlDbType.VarChar,15),
					new SqlParameter("@FH_Max", SqlDbType.VarChar,15),
					new SqlParameter("@AE_Min", SqlDbType.VarChar,15),
					new SqlParameter("@AE_Max", SqlDbType.VarChar,15),
					new SqlParameter("@OrderID", SqlDbType.VarChar,15),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.RCO_Min;
			parameters[2].Value = model.RCO_Max;
			parameters[3].Value = model.AO_Min;
			parameters[4].Value = model.AO_Max;
			parameters[5].Value = model.FH_Min;
			parameters[6].Value = model.FH_Max;
			parameters[7].Value = model.AE_Min;
			parameters[8].Value = model.AE_Max;
			parameters[9].Value = model.OrderID;
			parameters[10].Value = model.ID_Key;

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
		/// <param name="_orderID">工单单号</param>
		/// <param name="_type">接头类型</param>
		/// <returns></returns>
		public bool Delete(string _orderID ,string _type)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_TestStandard_3D ");
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
        /// <param name="_orderID">工单单号</param>
        /// <returns></returns>
        public bool Delete(string _orderID)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_TestStandard_3D ");
            strSql.Append(" where OrderID= '"+_orderID+"'");                    
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.TestStandard_3D GetModel(string _strSql)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max,OrderID,ID_Key from tb_TestStandard_3D ");
			strSql.Append(" where "+_strSql+"");
                          
			Maticsoft.Model.TestStandard_3D model=new Maticsoft.Model.TestStandard_3D();
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
		public Maticsoft.Model.TestStandard_3D DataRowToModel(DataRow row)
		{
			Maticsoft.Model.TestStandard_3D model=new Maticsoft.Model.TestStandard_3D();
			if (row != null)
			{
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["RCO_Min"]!=null)
				{
					model.RCO_Min=row["RCO_Min"].ToString();
				}
				if(row["RCO_Max"]!=null)
				{
					model.RCO_Max=row["RCO_Max"].ToString();
				}
				if(row["AO_Min"]!=null)
				{
					model.AO_Min=row["AO_Min"].ToString();
				}
				if(row["AO_Max"]!=null)
				{
					model.AO_Max=row["AO_Max"].ToString();
				}
				if(row["FH_Min"]!=null)
				{
					model.FH_Min=row["FH_Min"].ToString();
				}
				if(row["FH_Max"]!=null)
				{
					model.FH_Max=row["FH_Max"].ToString();
				}
				if(row["AE_Min"]!=null)
				{
					model.AE_Min=row["AE_Min"].ToString();
				}
				if(row["AE_Max"]!=null)
				{
					model.AE_Max=row["AE_Max"].ToString();
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
			strSql.Append("select Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max,OrderID,ID_Key ");
			strSql.Append(" FROM tb_TestStandard_3D ");
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
			strSql.Append(" Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max,OrderID,ID_Key ");
			strSql.Append(" FROM tb_TestStandard_3D ");
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
			strSql.Append("select count(1) FROM tb_TestStandard_3D ");
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
				strSql.Append("order by T.SN desc");
			}
			strSql.Append(")AS Row, T.*  from tb_TestStandard_3D T ");
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
			parameters[0].Value = "tb_TestStandard_3D";
			parameters[1].Value = "SN";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod



	}
}

