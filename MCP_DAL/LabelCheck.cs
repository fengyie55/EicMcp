/* LabelCheck.cs
*
* 功 能： N/A
* 类 名： LabelCheck
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/24 14:17:46   张文明    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
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
	/// 数据访问类:LabelCheck
	/// </summary>
	public partial class LabelCheck
	{

        DbHelperSQL dbs = new DbHelperSQL();
		public LabelCheck()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LabelCheck");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)			};
			parameters[0].Value = SN;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.LabelCheck model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LabelCheck(");
			strSql.Append("SN,Lab)");
			strSql.Append(" values (");
			strSql.Append("@SN,@Lab)");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@Lab", SqlDbType.VarChar,200)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Lab;

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
		public bool Update(Maticsoft.Model.LabelCheck model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LabelCheck set ");
			strSql.Append("Lab=@Lab");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@Lab", SqlDbType.VarChar,200),
					new SqlParameter("@SN", SqlDbType.VarChar,50)};
			parameters[0].Value = model.Lab;
			parameters[1].Value = model.SN;

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
		public bool Delete(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LabelCheck ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)			};
			parameters[0].Value = SN;

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
		public bool DeleteList(string SNlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LabelCheck ");
			strSql.Append(" where SN in ("+SNlist + ")  ");
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
		public Maticsoft.Model.LabelCheck GetModel(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,Lab from LabelCheck ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50)			};
			parameters[0].Value = SN;

			Maticsoft.Model.LabelCheck model=new Maticsoft.Model.LabelCheck();
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
		public Maticsoft.Model.LabelCheck DataRowToModel(DataRow row)
		{
			Maticsoft.Model.LabelCheck model=new Maticsoft.Model.LabelCheck();
			if (row != null)
			{
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["Lab"]!=null)
				{
					model.Lab=row["Lab"].ToString();
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
			strSql.Append("select SN,Lab ");
			strSql.Append(" FROM LabelCheck ");
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
			strSql.Append(" SN,Lab ");
			strSql.Append(" FROM LabelCheck ");
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
			strSql.Append("select count(1) FROM LabelCheck ");
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
			strSql.Append(")AS Row, T.*  from LabelCheck T ");
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
			parameters[0].Value = "LabelCheck";
			parameters[1].Value = "SN";
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

