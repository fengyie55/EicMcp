/* Rework.cs
*
* 功 能： N/A
* 类 名： Rework
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-22 10:50:39   N/A    初版  
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
	/// 数据访问类:Rework
	/// </summary>
	public partial class Rework
	{
		public Rework()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Rework model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Rework(");
			strSql.Append("SN,PigtailType,Count,RejectID,RejectDescribe,DisposeID,DisposeDescribe,Length,Result,ReworkID,VerifyID)");
			strSql.Append(" values (");
			strSql.Append("@SN,@PigtailType,@Count,@RejectID,@RejectDescribe,@DisposeID,@DisposeDescribe,@Length,@Result,@ReworkID,@VerifyID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@PigtailType", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@RejectID", SqlDbType.VarChar,50),
					new SqlParameter("@RejectDescribe", SqlDbType.VarChar,255),
					new SqlParameter("@DisposeID", SqlDbType.VarChar,50),
					new SqlParameter("@DisposeDescribe", SqlDbType.VarChar,255),
					new SqlParameter("@Length", SqlDbType.VarChar,50),
					new SqlParameter("@Result", SqlDbType.VarChar,50),
					new SqlParameter("@ReworkID", SqlDbType.VarChar,50),
					new SqlParameter("@VerifyID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.PigtailType;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.RejectID;
			parameters[4].Value = model.RejectDescribe;
			parameters[5].Value = model.DisposeID;
			parameters[6].Value = model.DisposeDescribe;
			parameters[7].Value = model.Length;
			parameters[8].Value = model.Result;
			parameters[9].Value = model.ReworkID;
			parameters[10].Value = model.VerifyID;

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
		public bool Update(Maticsoft.Model.Rework model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Rework set ");
			strSql.Append("SN=@SN,");
			strSql.Append("PigtailType=@PigtailType,");
			strSql.Append("Count=@Count,");
			strSql.Append("RejectID=@RejectID,");
			strSql.Append("RejectDescribe=@RejectDescribe,");
			strSql.Append("DisposeID=@DisposeID,");
			strSql.Append("DisposeDescribe=@DisposeDescribe,");
			strSql.Append("Length=@Length,");
			strSql.Append("Result=@Result,");
			strSql.Append("ReworkID=@ReworkID,");
			strSql.Append("VerifyID=@VerifyID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,50),
					new SqlParameter("@PigtailType", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@RejectID", SqlDbType.VarChar,50),
					new SqlParameter("@RejectDescribe", SqlDbType.VarChar,255),
					new SqlParameter("@DisposeID", SqlDbType.VarChar,50),
					new SqlParameter("@DisposeDescribe", SqlDbType.VarChar,255),
					new SqlParameter("@Length", SqlDbType.VarChar,50),
					new SqlParameter("@Result", SqlDbType.VarChar,50),
					new SqlParameter("@ReworkID", SqlDbType.VarChar,50),
					new SqlParameter("@VerifyID", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.PigtailType;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.RejectID;
			parameters[4].Value = model.RejectDescribe;
			parameters[5].Value = model.DisposeID;
			parameters[6].Value = model.DisposeDescribe;
			parameters[7].Value = model.Length;
			parameters[8].Value = model.Result;
			parameters[9].Value = model.ReworkID;
			parameters[10].Value = model.VerifyID;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from tb_Rework ");
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
			strSql.Append("delete from tb_Rework ");
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
		public Maticsoft.Model.Rework GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SN,PigtailType,Count,RejectID,RejectDescribe,DisposeID,DisposeDescribe,Length,Result,ReworkID,VerifyID from tb_Rework ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.Rework model=new Maticsoft.Model.Rework();
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
		public Maticsoft.Model.Rework DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Rework model=new Maticsoft.Model.Rework();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["PigtailType"]!=null)
				{
					model.PigtailType=row["PigtailType"].ToString();
				}
				if(row["Count"]!=null)
				{
					model.Count=row["Count"].ToString();
				}
				if(row["RejectID"]!=null)
				{
					model.RejectID=row["RejectID"].ToString();
				}
				if(row["RejectDescribe"]!=null)
				{
					model.RejectDescribe=row["RejectDescribe"].ToString();
				}
				if(row["DisposeID"]!=null)
				{
					model.DisposeID=row["DisposeID"].ToString();
				}
				if(row["DisposeDescribe"]!=null)
				{
					model.DisposeDescribe=row["DisposeDescribe"].ToString();
				}
				if(row["Length"]!=null)
				{
					model.Length=row["Length"].ToString();
				}
				if(row["Result"]!=null)
				{
					model.Result=row["Result"].ToString();
				}
				if(row["ReworkID"]!=null)
				{
					model.ReworkID=row["ReworkID"].ToString();
				}
				if(row["VerifyID"]!=null)
				{
					model.VerifyID=row["VerifyID"].ToString();
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
			strSql.Append("select ID,SN,PigtailType,Count,RejectID,RejectDescribe,DisposeID,DisposeDescribe,Length,Result,ReworkID,VerifyID ");
			strSql.Append(" FROM tb_Rework ");
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
			strSql.Append(" ID,SN,PigtailType,Count,RejectID,RejectDescribe,DisposeID,DisposeDescribe,Length,Result,ReworkID,VerifyID ");
			strSql.Append(" FROM tb_Rework ");
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
			strSql.Append("select count(1) FROM tb_Rework ");
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
			strSql.Append(")AS Row, T.*  from tb_Rework T ");
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
			parameters[0].Value = "tb_Rework";
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

