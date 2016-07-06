/* StateList.cs
*
* 功 能： N/A
* 类 名： StateList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-5-27 10:24:37   N/A    初版  
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:StateList
	/// </summary>
	public partial class StateList
	{
		public StateList()
		{}
		#region  BasicMethod


        DbHelperSQL dbs = new DbHelperSQL();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Ste_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_StateList");
			strSql.Append(" where Ste_ID=@Ste_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Ste_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Ste_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.StateList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_StateList(");
			strSql.Append("Type,Wk_ID,State)");
			strSql.Append(" values (");
			strSql.Append("@Type,@Wk_ID,@State)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,20),
					new SqlParameter("@Wk_ID", SqlDbType.VarChar,20),
					new SqlParameter("@State", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Wk_ID;
			parameters[2].Value = model.State;

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
		public bool Update(Maticsoft.Model.StateList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_StateList set ");
			strSql.Append("Type=@Type,");
			strSql.Append("Wk_ID=@Wk_ID,");
			strSql.Append("State=@State");
			strSql.Append(" where Ste_ID=@Ste_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,20),
					new SqlParameter("@Wk_ID", SqlDbType.VarChar,20),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@Ste_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.Wk_ID;
			parameters[2].Value = model.State;
			parameters[3].Value = model.Ste_ID;

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
		public bool Delete(decimal Ste_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_StateList ");
			strSql.Append(" where Ste_ID=@Ste_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Ste_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Ste_ID;

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
		public bool DeleteList(string Ste_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_StateList ");
			strSql.Append(" where Ste_ID in ("+Ste_IDlist + ")  ");
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
		public Maticsoft.Model.StateList GetModel(decimal Ste_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Ste_ID,Type,Wk_ID,State from tb_StateList ");
			strSql.Append(" where Ste_ID=@Ste_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Ste_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Ste_ID;

			Maticsoft.Model.StateList model=new Maticsoft.Model.StateList();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.StateList DataRowToModel(DataRow row)
		{
			Maticsoft.Model.StateList model=new Maticsoft.Model.StateList();
			if (row != null)
			{
				if(row["Ste_ID"]!=null && row["Ste_ID"].ToString()!="")
				{
					model.Ste_ID=decimal.Parse(row["Ste_ID"].ToString());
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["Wk_ID"]!=null)
				{
					model.Wk_ID=row["Wk_ID"].ToString();
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
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
			strSql.Append("select Ste_ID,Type,Wk_ID,State ");
			strSql.Append(" FROM tb_StateList ");
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
			strSql.Append(" Ste_ID,Type,Wk_ID,State ");
			strSql.Append(" FROM tb_StateList ");
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
			strSql.Append("select count(1) FROM tb_StateList ");
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
				strSql.Append("order by T.Ste_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_StateList T ");
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
			parameters[0].Value = "tb_StateList";
			parameters[1].Value = "Ste_ID";
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

