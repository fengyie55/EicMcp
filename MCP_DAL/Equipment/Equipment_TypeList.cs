using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Equipment_TypeList
	/// </summary>
	public partial class Equipment_TypeList
	{
		public Equipment_TypeList()
		{}

        MCP_DBUitility.DbHelperSQL dbs = new MCP_DBUitility.DbHelperSQL(Model.E_ConnectionList.EquipmentMS);

		#region  Method

      


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Equipment_TypeList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Equipment_TypeList(");
			strSql.Append("ID,Type,Value,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Type,@Value,@Remarks)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal,9),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@Value", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,255)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Value;
			parameters[3].Value = model.Remarks;

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
		public bool Update(Maticsoft.Model.Equipment_TypeList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Equipment_TypeList set ");
			strSql.Append("ID=@ID,");
			strSql.Append("Type=@Type,");
			strSql.Append("Value=@Value,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal,9),
					new SqlParameter("@Type", SqlDbType.VarChar,50),
					new SqlParameter("@Value", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,255)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.Value;
			parameters[3].Value = model.Remarks;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Equipment_TypeList ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.Equipment_TypeList GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Type,Value,Remarks from tb_Equipment_TypeList ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.Equipment_TypeList model=new Maticsoft.Model.Equipment_TypeList();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Type"]!=null && ds.Tables[0].Rows[0]["Type"].ToString()!="")
				{
					model.Type=ds.Tables[0].Rows[0]["Type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Value"]!=null && ds.Tables[0].Rows[0]["Value"].ToString()!="")
				{
					model.Value=ds.Tables[0].Rows[0]["Value"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remarks"]!=null && ds.Tables[0].Rows[0]["Remarks"].ToString()!="")
				{
					model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Type,Value,Remarks ");
			strSql.Append(" FROM tb_Equipment_TypeList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbs.Query(strSql.ToString());
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
			strSql.Append(" ID,Type,Value,Remarks ");
			strSql.Append(" FROM tb_Equipment_TypeList ");
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
			strSql.Append("select count(1) FROM tb_Equipment_TypeList ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Equipment_TypeList T ");
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
			parameters[0].Value = "tb_Equipment_TypeList";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

