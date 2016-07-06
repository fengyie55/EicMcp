* Material_FeedIntake.cs
*
* 功 能： N/A
* 类 名： Material_FeedIntake
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:48   N/A    初版  
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
	/// 数据访问类:Material_FeedIntake
	/// </summary>
	public partial class Material_FeedIntake
	{
		public Material_FeedIntake()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Fe_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Material_FeedIntake");
			strSql.Append(" where Fe_ID=@Fe_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Fe_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = Fe_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Material_FeedIntake model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Material_FeedIntake(");
			strSql.Append("Fe_ID,FeedIntakeID,MaterialNum,Count,UserID,WorkstationID,DataTime)");
			strSql.Append(" values (");
			strSql.Append("@Fe_ID,@FeedIntakeID,@MaterialNum,@Count,@UserID,@WorkstationID,@DataTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@Fe_ID", SqlDbType.Decimal,9),
					new SqlParameter("@FeedIntakeID", SqlDbType.VarChar,15),
					new SqlParameter("@MaterialNum", SqlDbType.VarChar,30),
					new SqlParameter("@Count", SqlDbType.VarChar,15),
					new SqlParameter("@UserID", SqlDbType.VarChar,15),
					new SqlParameter("@WorkstationID", SqlDbType.VarChar,15),
					new SqlParameter("@DataTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Fe_ID;
			parameters[1].Value = model.FeedIntakeID;
			parameters[2].Value = model.MaterialNum;
			parameters[3].Value = model.Count;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.WorkstationID;
			parameters[6].Value = model.DataTime;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.Material_FeedIntake model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Material_FeedIntake set ");
			strSql.Append("FeedIntakeID=@FeedIntakeID,");
			strSql.Append("MaterialNum=@MaterialNum,");
			strSql.Append("Count=@Count,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("WorkstationID=@WorkstationID,");
			strSql.Append("DataTime=@DataTime");
			strSql.Append(" where Fe_ID=@Fe_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@FeedIntakeID", SqlDbType.VarChar,15),
					new SqlParameter("@MaterialNum", SqlDbType.VarChar,30),
					new SqlParameter("@Count", SqlDbType.VarChar,15),
					new SqlParameter("@UserID", SqlDbType.VarChar,15),
					new SqlParameter("@WorkstationID", SqlDbType.VarChar,15),
					new SqlParameter("@DataTime", SqlDbType.DateTime),
					new SqlParameter("@Fe_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.FeedIntakeID;
			parameters[1].Value = model.MaterialNum;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.UserID;
			parameters[4].Value = model.WorkstationID;
			parameters[5].Value = model.DataTime;
			parameters[6].Value = model.Fe_ID;

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
		public bool Delete(decimal Fe_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Material_FeedIntake ");
			strSql.Append(" where Fe_ID=@Fe_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Fe_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = Fe_ID;

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
		public bool DeleteList(string Fe_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Material_FeedIntake ");
			strSql.Append(" where Fe_ID in ("+Fe_IDlist + ")  ");
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
		public Maticsoft.Model.Material_FeedIntake GetModel(decimal Fe_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Fe_ID,FeedIntakeID,MaterialNum,Count,UserID,WorkstationID,DataTime from tb_Material_FeedIntake ");
			strSql.Append(" where Fe_ID=@Fe_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Fe_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = Fe_ID;

			Maticsoft.Model.Material_FeedIntake model=new Maticsoft.Model.Material_FeedIntake();
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
		public Maticsoft.Model.Material_FeedIntake DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Material_FeedIntake model=new Maticsoft.Model.Material_FeedIntake();
			if (row != null)
			{
				if(row["Fe_ID"]!=null && row["Fe_ID"].ToString()!="")
				{
					model.Fe_ID=decimal.Parse(row["Fe_ID"].ToString());
				}
				if(row["FeedIntakeID"]!=null)
				{
					model.FeedIntakeID=row["FeedIntakeID"].ToString();
				}
				if(row["MaterialNum"]!=null)
				{
					model.MaterialNum=row["MaterialNum"].ToString();
				}
				if(row["Count"]!=null)
				{
					model.Count=row["Count"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["WorkstationID"]!=null)
				{
					model.WorkstationID=row["WorkstationID"].ToString();
				}
				if(row["DataTime"]!=null && row["DataTime"].ToString()!="")
				{
					model.DataTime=DateTime.Parse(row["DataTime"].ToString());
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
			strSql.Append("select Fe_ID,FeedIntakeID,MaterialNum,Count,UserID,WorkstationID,DataTime ");
			strSql.Append(" FROM tb_Material_FeedIntake ");
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
			strSql.Append(" Fe_ID,FeedIntakeID,MaterialNum,Count,UserID,WorkstationID,DataTime ");
			strSql.Append(" FROM tb_Material_FeedIntake ");
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
			strSql.Append("select count(1) FROM tb_Material_FeedIntake ");
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
				strSql.Append("order by T.Fe_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Material_FeedIntake T ");
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
			parameters[0].Value = "tb_Material_FeedIntake";
			parameters[1].Value = "Fe_ID";
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

