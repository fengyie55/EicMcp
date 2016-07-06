/* MoveStore_Send.cs
*
* 功 能： N/A
* 类 名： MoveStore_Send
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-5-26 13:30:46   N/A    初版  
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
	/// 数据访问类:MoveStore_Send
	/// </summary>
	public partial class MoveStore_Send
	{
		public MoveStore_Send()
		{}
		#region  BasicMethod


        DbHelperSQL dbs = new DbHelperSQL();

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Mse_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_MoveStore_Send");
			strSql.Append(" where Mse_ID=@Mse_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Mse_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Mse_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.MoveStore_Send model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_MoveStore_Send(");
			strSql.Append("OrderID,Ste_ID,Count,JobNum,Wk_ID,Or_ID,DateTime)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@Ste_ID,@Count,@JobNum,@Wk_ID,@Or_ID,@DateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,20),
					new SqlParameter("@Ste_ID", SqlDbType.Decimal,9),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@JobNum", SqlDbType.VarChar,20),
					new SqlParameter("@Wk_ID", SqlDbType.VarChar,20),
					new SqlParameter("@Or_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.Ste_ID;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.JobNum;
			parameters[4].Value = model.Wk_ID;
			parameters[5].Value = model.Or_ID;
			parameters[6].Value = model.DateTime;

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
		public bool Update(Maticsoft.Model.MoveStore_Send model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_MoveStore_Send set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("Ste_ID=@Ste_ID,");
			strSql.Append("Count=@Count,");
			strSql.Append("JobNum=@JobNum,");
			strSql.Append("Wk_ID=@Wk_ID,");
			strSql.Append("Or_ID=@Or_ID,");
			strSql.Append("DateTime=@DateTime");
			strSql.Append(" where Mse_ID=@Mse_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,20),
					new SqlParameter("@Ste_ID", SqlDbType.Decimal,9),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@JobNum", SqlDbType.VarChar,20),
					new SqlParameter("@Wk_ID", SqlDbType.VarChar,20),
					new SqlParameter("@Or_ID", SqlDbType.Decimal,9),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@Mse_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.Ste_ID;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.JobNum;
			parameters[4].Value = model.Wk_ID;
			parameters[5].Value = model.Or_ID;
			parameters[6].Value = model.DateTime;
			parameters[7].Value = model.Mse_ID;

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
		public bool Delete(decimal Mse_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_MoveStore_Send ");
			strSql.Append(" where Mse_ID=@Mse_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Mse_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Mse_ID;

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
		public bool DeleteList(string Mse_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_MoveStore_Send ");
			strSql.Append(" where Mse_ID in ("+Mse_IDlist + ")  ");
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
		public Maticsoft.Model.MoveStore_Send GetModel(decimal Mse_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Mse_ID,OrderID,Ste_ID,Count,JobNum,Wk_ID,Or_ID,DateTime from tb_MoveStore_Send ");
			strSql.Append(" where Mse_ID=@Mse_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Mse_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Mse_ID;

			Maticsoft.Model.MoveStore_Send model=new Maticsoft.Model.MoveStore_Send();
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
		public Maticsoft.Model.MoveStore_Send DataRowToModel(DataRow row)
		{
			Maticsoft.Model.MoveStore_Send model=new Maticsoft.Model.MoveStore_Send();
			if (row != null)
			{
				if(row["Mse_ID"]!=null && row["Mse_ID"].ToString()!="")
				{
					model.Mse_ID=decimal.Parse(row["Mse_ID"].ToString());
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["Ste_ID"]!=null && row["Ste_ID"].ToString()!="")
				{
					model.Ste_ID=decimal.Parse(row["Ste_ID"].ToString());
				}
				if(row["Count"]!=null && row["Count"].ToString()!="")
				{
					model.Count=int.Parse(row["Count"].ToString());
				}
				if(row["JobNum"]!=null)
				{
					model.JobNum=row["JobNum"].ToString();
				}
				if(row["Wk_ID"]!=null)
				{
					model.Wk_ID=row["Wk_ID"].ToString();
				}
				if(row["Or_ID"]!=null && row["Or_ID"].ToString()!="")
				{
					model.Or_ID=decimal.Parse(row["Or_ID"].ToString());
				}
				if(row["DateTime"]!=null && row["DateTime"].ToString()!="")
				{
					model.DateTime=DateTime.Parse(row["DateTime"].ToString());
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
			strSql.Append("select Mse_ID,OrderID,Ste_ID,Count,JobNum,Wk_ID,Or_ID,DateTime ");
			strSql.Append(" FROM tb_MoveStore_Send ");
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
			strSql.Append(" Mse_ID,OrderID,Ste_ID,Count,JobNum,Wk_ID,Or_ID,DateTime ");
			strSql.Append(" FROM tb_MoveStore_Send ");
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
			strSql.Append("select count(1) FROM tb_MoveStore_Send ");
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
				strSql.Append("order by T.Mse_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_MoveStore_Send T ");
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
			parameters[0].Value = "tb_MoveStore_Send";
			parameters[1].Value = "Mse_ID";
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

