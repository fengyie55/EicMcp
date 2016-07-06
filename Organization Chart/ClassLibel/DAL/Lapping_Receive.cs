* Lapping_Receive.cs
*
* 功 能： N/A
* 类 名： Lapping_Receive
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:47   N/A    初版  
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
	/// 数据访问类:Lapping_Receive
	/// </summary>
	public partial class Lapping_Receive
	{
		public Lapping_Receive()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Lp_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Lapping_Receive");
			strSql.Append(" where Lp_ID=@Lp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Lp_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Lp_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Lapping_Receive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Lapping_Receive(");
			strSql.Append("Count,ReceiveUserID,SendUserID,LappingReceiveID,DataTime)");
			strSql.Append(" values (");
			strSql.Append("@Count,@ReceiveUserID,@SendUserID,@LappingReceiveID,@DataTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Count", SqlDbType.VarChar,15),
					new SqlParameter("@ReceiveUserID", SqlDbType.VarChar,15),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,15),
					new SqlParameter("@LappingReceiveID", SqlDbType.VarChar,15),
					new SqlParameter("@DataTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Count;
			parameters[1].Value = model.ReceiveUserID;
			parameters[2].Value = model.SendUserID;
			parameters[3].Value = model.LappingReceiveID;
			parameters[4].Value = model.DataTime;

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
		public bool Update(Maticsoft.Model.Lapping_Receive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Lapping_Receive set ");
			strSql.Append("Count=@Count,");
			strSql.Append("ReceiveUserID=@ReceiveUserID,");
			strSql.Append("SendUserID=@SendUserID,");
			strSql.Append("LappingReceiveID=@LappingReceiveID,");
			strSql.Append("DataTime=@DataTime");
			strSql.Append(" where Lp_ID=@Lp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Count", SqlDbType.VarChar,15),
					new SqlParameter("@ReceiveUserID", SqlDbType.VarChar,15),
					new SqlParameter("@SendUserID", SqlDbType.VarChar,15),
					new SqlParameter("@LappingReceiveID", SqlDbType.VarChar,15),
					new SqlParameter("@DataTime", SqlDbType.DateTime),
					new SqlParameter("@Lp_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Count;
			parameters[1].Value = model.ReceiveUserID;
			parameters[2].Value = model.SendUserID;
			parameters[3].Value = model.LappingReceiveID;
			parameters[4].Value = model.DataTime;
			parameters[5].Value = model.Lp_ID;

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
		public bool Delete(decimal Lp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Lapping_Receive ");
			strSql.Append(" where Lp_ID=@Lp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Lp_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Lp_ID;

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
		public bool DeleteList(string Lp_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Lapping_Receive ");
			strSql.Append(" where Lp_ID in ("+Lp_IDlist + ")  ");
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
		public Maticsoft.Model.Lapping_Receive GetModel(decimal Lp_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Lp_ID,Count,ReceiveUserID,SendUserID,LappingReceiveID,DataTime from tb_Lapping_Receive ");
			strSql.Append(" where Lp_ID=@Lp_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Lp_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Lp_ID;

			Maticsoft.Model.Lapping_Receive model=new Maticsoft.Model.Lapping_Receive();
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
		public Maticsoft.Model.Lapping_Receive DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Lapping_Receive model=new Maticsoft.Model.Lapping_Receive();
			if (row != null)
			{
				if(row["Lp_ID"]!=null && row["Lp_ID"].ToString()!="")
				{
					model.Lp_ID=decimal.Parse(row["Lp_ID"].ToString());
				}
				if(row["Count"]!=null)
				{
					model.Count=row["Count"].ToString();
				}
				if(row["ReceiveUserID"]!=null)
				{
					model.ReceiveUserID=row["ReceiveUserID"].ToString();
				}
				if(row["SendUserID"]!=null)
				{
					model.SendUserID=row["SendUserID"].ToString();
				}
				if(row["LappingReceiveID"]!=null)
				{
					model.LappingReceiveID=row["LappingReceiveID"].ToString();
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
			strSql.Append("select Lp_ID,Count,ReceiveUserID,SendUserID,LappingReceiveID,DataTime ");
			strSql.Append(" FROM tb_Lapping_Receive ");
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
			strSql.Append(" Lp_ID,Count,ReceiveUserID,SendUserID,LappingReceiveID,DataTime ");
			strSql.Append(" FROM tb_Lapping_Receive ");
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
			strSql.Append("select count(1) FROM tb_Lapping_Receive ");
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
				strSql.Append("order by T.Lp_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Lapping_Receive T ");
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
			parameters[0].Value = "tb_Lapping_Receive";
			parameters[1].Value = "Lp_ID";
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

