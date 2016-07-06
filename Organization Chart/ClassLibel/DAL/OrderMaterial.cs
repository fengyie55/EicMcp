﻿* OrderMaterial.cs
*
* 功 能： N/A
* 类 名： OrderMaterial
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:49   N/A    初版  
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
	/// 数据访问类:OrderMaterial
	/// </summary>
	public partial class OrderMaterial
	{
		public OrderMaterial()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Orm_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_OrderMaterial");
			strSql.Append(" where Orm_ID=@Orm_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = Orm_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.OrderMaterial model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_OrderMaterial(");
			strSql.Append("Orm_ID,MaterialID,SendCount,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@Orm_ID,@MaterialID,@SendCount,@OrderID)");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.Decimal,9),
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30),
					new SqlParameter("@SendCount", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Orm_ID;
			parameters[1].Value = model.MaterialID;
			parameters[2].Value = model.SendCount;
			parameters[3].Value = model.OrderID;

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
		public bool Update(Maticsoft.Model.OrderMaterial model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_OrderMaterial set ");
			strSql.Append("MaterialID=@MaterialID,");
			strSql.Append("SendCount=@SendCount,");
			strSql.Append("OrderID=@OrderID");
			strSql.Append(" where Orm_ID=@Orm_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30),
					new SqlParameter("@SendCount", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.VarChar,20),
					new SqlParameter("@Orm_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.MaterialID;
			parameters[1].Value = model.SendCount;
			parameters[2].Value = model.OrderID;
			parameters[3].Value = model.Orm_ID;

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
		public bool Delete(decimal Orm_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderMaterial ");
			strSql.Append(" where Orm_ID=@Orm_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = Orm_ID;

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
		public bool DeleteList(string Orm_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderMaterial ");
			strSql.Append(" where Orm_ID in ("+Orm_IDlist + ")  ");
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
		public Maticsoft.Model.OrderMaterial GetModel(decimal Orm_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Orm_ID,MaterialID,SendCount,OrderID from tb_OrderMaterial ");
			strSql.Append(" where Orm_ID=@Orm_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.Decimal,9)			};
			parameters[0].Value = Orm_ID;

			Maticsoft.Model.OrderMaterial model=new Maticsoft.Model.OrderMaterial();
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
		public Maticsoft.Model.OrderMaterial DataRowToModel(DataRow row)
		{
			Maticsoft.Model.OrderMaterial model=new Maticsoft.Model.OrderMaterial();
			if (row != null)
			{
				if(row["Orm_ID"]!=null && row["Orm_ID"].ToString()!="")
				{
					model.Orm_ID=decimal.Parse(row["Orm_ID"].ToString());
				}
				if(row["MaterialID"]!=null)
				{
					model.MaterialID=row["MaterialID"].ToString();
				}
				if(row["SendCount"]!=null && row["SendCount"].ToString()!="")
				{
					model.SendCount=int.Parse(row["SendCount"].ToString());
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
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
			strSql.Append("select Orm_ID,MaterialID,SendCount,OrderID ");
			strSql.Append(" FROM tb_OrderMaterial ");
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
			strSql.Append(" Orm_ID,MaterialID,SendCount,OrderID ");
			strSql.Append(" FROM tb_OrderMaterial ");
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
			strSql.Append("select count(1) FROM tb_OrderMaterial ");
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
				strSql.Append("order by T.Orm_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_OrderMaterial T ");
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
			parameters[0].Value = "tb_OrderMaterial";
			parameters[1].Value = "Orm_ID";
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

