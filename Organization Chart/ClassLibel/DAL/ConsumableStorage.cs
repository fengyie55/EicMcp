/**  版本信息模板在安装目录下，可自行修改。
* ConsumableStorage.cs
*
* 功 能： N/A
* 类 名： ConsumableStorage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-09-26 10:32:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
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
	/// 数据访问类:ConsumableStorage
	/// </summary>
	public partial class ConsumableStorage
	{
		public ConsumableStorage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal C_StoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_ConsumableStorage");
			strSql.Append(" where C_StoID=@C_StoID");
			SqlParameter[] parameters = {
					new SqlParameter("@C_StoID", SqlDbType.Decimal)
			};
			parameters[0].Value = C_StoID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.ConsumableStorage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_ConsumableStorage(");
			strSql.Append("C_Barcode,Count,UserName,Datetime,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@C_Barcode,@Count,@UserName,@Datetime,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Barcode", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Datetime", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.Text)};
			parameters[0].Value = model.C_Barcode;
			parameters[1].Value = model.Count;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Datetime;
			parameters[4].Value = model.Remarks;

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
		public bool Update(Maticsoft.Model.ConsumableStorage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_ConsumableStorage set ");
			strSql.Append("C_Barcode=@C_Barcode,");
			strSql.Append("Count=@Count,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Datetime=@Datetime,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where C_StoID=@C_StoID");
			SqlParameter[] parameters = {
					new SqlParameter("@C_Barcode", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@Datetime", SqlDbType.VarChar,50),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@C_StoID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.C_Barcode;
			parameters[1].Value = model.Count;
			parameters[2].Value = model.UserName;
			parameters[3].Value = model.Datetime;
			parameters[4].Value = model.Remarks;
			parameters[5].Value = model.C_StoID;

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
		public bool Delete(decimal C_StoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ConsumableStorage ");
			strSql.Append(" where C_StoID=@C_StoID");
			SqlParameter[] parameters = {
					new SqlParameter("@C_StoID", SqlDbType.Decimal)
			};
			parameters[0].Value = C_StoID;

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
		public bool DeleteList(string C_StoIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ConsumableStorage ");
			strSql.Append(" where C_StoID in ("+C_StoIDlist + ")  ");
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
		public Maticsoft.Model.ConsumableStorage GetModel(decimal C_StoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 C_StoID,C_Barcode,Count,UserName,Datetime,Remarks from tb_ConsumableStorage ");
			strSql.Append(" where C_StoID=@C_StoID");
			SqlParameter[] parameters = {
					new SqlParameter("@C_StoID", SqlDbType.Decimal)
			};
			parameters[0].Value = C_StoID;

			Maticsoft.Model.ConsumableStorage model=new Maticsoft.Model.ConsumableStorage();
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
		public Maticsoft.Model.ConsumableStorage DataRowToModel(DataRow row)
		{
			Maticsoft.Model.ConsumableStorage model=new Maticsoft.Model.ConsumableStorage();
			if (row != null)
			{
				if(row["C_StoID"]!=null && row["C_StoID"].ToString()!="")
				{
					model.C_StoID=decimal.Parse(row["C_StoID"].ToString());
				}
				if(row["C_Barcode"]!=null)
				{
					model.C_Barcode=row["C_Barcode"].ToString();
				}
				if(row["Count"]!=null && row["Count"].ToString()!="")
				{
					model.Count=int.Parse(row["Count"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Datetime"]!=null)
				{
					model.Datetime=row["Datetime"].ToString();
				}
				if(row["Remarks"]!=null)
				{
					model.Remarks=row["Remarks"].ToString();
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
			strSql.Append("select C_StoID,C_Barcode,Count,UserName,Datetime,Remarks ");
			strSql.Append(" FROM tb_ConsumableStorage ");
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
			strSql.Append(" C_StoID,C_Barcode,Count,UserName,Datetime,Remarks ");
			strSql.Append(" FROM tb_ConsumableStorage ");
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
			strSql.Append("select count(1) FROM tb_ConsumableStorage ");
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
				strSql.Append("order by T.C_StoID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_ConsumableStorage T ");
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
			parameters[0].Value = "tb_ConsumableStorage";
			parameters[1].Value = "C_StoID";
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

