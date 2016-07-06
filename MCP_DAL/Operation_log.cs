using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Operation_log
	/// </summary>
	public partial class Operation_log
	{
		public Operation_log()
		{}
		#region  Method

        MCP_DBUitility.DbHelperSQL dbs = new MCP_DBUitility.DbHelperSQL();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal R_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Operation_log");
			strSql.Append(" where R_ID=@R_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@R_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = R_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Operation_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Operation_log(");
			strSql.Append("UserName,Operation,Remarks,DateTime)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Operation,@Remarks,@DateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Operation", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Operation;
			parameters[2].Value = model.Remarks;
			parameters[3].Value = model.DateTime;

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
		public bool Update(Maticsoft.Model.Operation_log model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Operation_log set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Operation=@Operation,");
			strSql.Append("Remarks=@Remarks,");
			strSql.Append("DateTime=@DateTime");
			strSql.Append(" where R_ID=@R_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Operation", SqlDbType.NVarChar,50),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@R_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Operation;
			parameters[2].Value = model.Remarks;
			parameters[3].Value = model.DateTime;
			parameters[4].Value = model.R_ID;

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
		public bool Delete(decimal R_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Operation_log ");
			strSql.Append(" where R_ID=@R_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@R_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = R_ID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string R_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Operation_log ");
			strSql.Append(" where R_ID in ("+R_IDlist + ")  ");
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
		public Maticsoft.Model.Operation_log GetModel(decimal R_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 R_ID,UserName,Operation,Remarks,DateTime from tb_Operation_log ");
			strSql.Append(" where R_ID=@R_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@R_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = R_ID;

			Maticsoft.Model.Operation_log model=new Maticsoft.Model.Operation_log();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["R_ID"]!=null && ds.Tables[0].Rows[0]["R_ID"].ToString()!="")
				{
					model.R_ID=decimal.Parse(ds.Tables[0].Rows[0]["R_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserName"]!=null && ds.Tables[0].Rows[0]["UserName"].ToString()!="")
				{
					model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Operation"]!=null && ds.Tables[0].Rows[0]["Operation"].ToString()!="")
				{
					model.Operation=ds.Tables[0].Rows[0]["Operation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remarks"]!=null && ds.Tables[0].Rows[0]["Remarks"].ToString()!="")
				{
					model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DateTime"]!=null && ds.Tables[0].Rows[0]["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(ds.Tables[0].Rows[0]["DateTime"].ToString());
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
			strSql.Append("select R_ID,UserName,Operation,Remarks,DateTime ");
			strSql.Append(" FROM tb_Operation_log ");
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
			strSql.Append(" R_ID,UserName,Operation,Remarks,DateTime ");
			strSql.Append(" FROM tb_Operation_log ");
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
			strSql.Append("select count(1) FROM tb_Operation_log ");
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
				strSql.Append("order by T.R_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Operation_log T ");
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
			parameters[0].Value = "tb_Operation_log";
			parameters[1].Value = "R_ID";
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

