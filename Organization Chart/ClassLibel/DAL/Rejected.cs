* Rejected.cs
*
* 功 能： N/A
* 类 名： Rejected
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-12 15:19:29   N/A    初版  
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
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Rejected
	/// </summary>
	public partial class Rejected
	{
		public Rejected()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Rejected model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Rejected(");
			strSql.Append("tb_RejectCode,Reject,Descriptions,Picture,Notes)");
			strSql.Append(" values (");
			strSql.Append("@tb_RejectCode,@Reject,@Descriptions,@Picture,@Notes)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@tb_RejectCode", SqlDbType.VarChar,20),
					new SqlParameter("@Reject", SqlDbType.VarChar,50),
					new SqlParameter("@Descriptions", SqlDbType.VarChar,100),
					new SqlParameter("@Picture", SqlDbType.Image),
					new SqlParameter("@Notes", SqlDbType.VarChar,50)};
			parameters[0].Value = model.tb_RejectCode;
			parameters[1].Value = model.Reject;
			parameters[2].Value = model.Descriptions;
			parameters[3].Value = model.Picture;
			parameters[4].Value = model.Notes;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.Rejected model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Rejected set ");
			strSql.Append("tb_RejectCode=@tb_RejectCode,");
			strSql.Append("Reject=@Reject,");
			strSql.Append("Descriptions=@Descriptions,");
			strSql.Append("Picture=@Picture,");
			strSql.Append("Notes=@Notes");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@tb_RejectCode", SqlDbType.VarChar,20),
					new SqlParameter("@Reject", SqlDbType.VarChar,50),
					new SqlParameter("@Descriptions", SqlDbType.VarChar,100),
					new SqlParameter("@Picture", SqlDbType.Image),
					new SqlParameter("@Notes", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.tb_RejectCode;
			parameters[1].Value = model.Reject;
			parameters[2].Value = model.Descriptions;
			parameters[3].Value = model.Picture;
			parameters[4].Value = model.Notes;
			parameters[5].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Rejected ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Rejected ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.Rejected GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,tb_RejectCode,Reject,Descriptions,Picture,Notes from tb_Rejected ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.Rejected model=new Maticsoft.Model.Rejected();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
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
		public Maticsoft.Model.Rejected DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Rejected model=new Maticsoft.Model.Rejected();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["tb_RejectCode"]!=null)
				{
					model.tb_RejectCode=row["tb_RejectCode"].ToString();
				}
				if(row["Reject"]!=null)
				{
					model.Reject=row["Reject"].ToString();
				}
				if(row["Descriptions"]!=null)
				{
					model.Descriptions=row["Descriptions"].ToString();
				}
				if(row["Picture"]!=null && row["Picture"].ToString()!="")
				{
					model.Picture=(byte[])row["Picture"];
				}
				if(row["Notes"]!=null)
				{
					model.Notes=row["Notes"].ToString();
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
			strSql.Append("select ID,tb_RejectCode,Reject,Descriptions,Picture,Notes ");
			strSql.Append(" FROM tb_Rejected ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
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
			strSql.Append(" ID,tb_RejectCode,Reject,Descriptions,Picture,Notes ");
			strSql.Append(" FROM tb_Rejected ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_Rejected ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Rejected T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
			parameters[0].Value = "tb_Rejected";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

