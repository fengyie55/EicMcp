using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:User_WK
	/// </summary>
	public partial class User_WK
	{
		public User_WK()
		{}
		#region  Method
        DbHelperSQL dbs = new DbHelperSQL();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal WU_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_User_WK");
			strSql.Append(" where WU_ID=@WU_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@WU_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = WU_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.User_WK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_User_WK(");
			strSql.Append("WK,ClassType,JobNum,Name,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@WK,@ClassType,@JobNum,@Name,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WK", SqlDbType.VarChar,50),
					new SqlParameter("@ClassType", SqlDbType.VarChar,50),
					new SqlParameter("@JobNum", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,50)};
			parameters[0].Value = model.WK;
			parameters[1].Value = model.ClassType;
			parameters[2].Value = model.JobNum;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Remarks;

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
		public bool Update(Maticsoft.Model.User_WK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_User_WK set ");
			strSql.Append("WK=@WK,");
			strSql.Append("ClassType=@ClassType,");
			strSql.Append("JobNum=@JobNum,");
			strSql.Append("Name=@Name,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where WU_ID=@WU_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@WK", SqlDbType.VarChar,50),
					new SqlParameter("@ClassType", SqlDbType.VarChar,50),
					new SqlParameter("@JobNum", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.VarChar,50),
					new SqlParameter("@WU_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.WK;
			parameters[1].Value = model.ClassType;
			parameters[2].Value = model.JobNum;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.Remarks;
			parameters[5].Value = model.WU_ID;

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
		public bool Delete(decimal WU_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_User_WK ");
			strSql.Append(" where WU_ID=@WU_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@WU_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = WU_ID;

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
		public bool DeleteList(string WU_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_User_WK ");
			strSql.Append(" where WU_ID in ("+WU_IDlist + ")  ");
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
		public Maticsoft.Model.User_WK GetModel(decimal WU_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 WU_ID,WK,ClassType,JobNum,Name,Remarks from tb_User_WK ");
			strSql.Append(" where WU_ID=@WU_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@WU_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = WU_ID;

			Maticsoft.Model.User_WK model=new Maticsoft.Model.User_WK();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["WU_ID"]!=null && ds.Tables[0].Rows[0]["WU_ID"].ToString()!="")
				{
					model.WU_ID=decimal.Parse(ds.Tables[0].Rows[0]["WU_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WK"]!=null && ds.Tables[0].Rows[0]["WK"].ToString()!="")
				{
					model.WK=ds.Tables[0].Rows[0]["WK"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ClassType"]!=null && ds.Tables[0].Rows[0]["ClassType"].ToString()!="")
				{
					model.ClassType=ds.Tables[0].Rows[0]["ClassType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["JobNum"]!=null && ds.Tables[0].Rows[0]["JobNum"].ToString()!="")
				{
					model.JobNum=ds.Tables[0].Rows[0]["JobNum"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
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
			strSql.Append("select WU_ID,WK,ClassType,JobNum,Name,Remarks ");
			strSql.Append(" FROM tb_User_WK ");
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
			strSql.Append(" WU_ID,WK,ClassType,JobNum,Name,Remarks ");
			strSql.Append(" FROM tb_User_WK ");
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
			strSql.Append("select count(1) FROM tb_User_WK ");
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
				strSql.Append("order by T.WU_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_User_WK T ");
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
			parameters[0].Value = "tb_User_WK";
			parameters[1].Value = "WU_ID";
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

