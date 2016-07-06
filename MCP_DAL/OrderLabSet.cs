/* OrderLabSet.cs
*
* 功 能： N/A
* 类 名： OrderLabSet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-3-20 13:28:43   N/A    初版  
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
	/// 数据访问类:OrderLabSet
	/// </summary>
	public partial class OrderLabSet
	{
		public OrderLabSet()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BachNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_OrderLabSet");
			strSql.Append(" where BachNo=@BachNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@BachNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = BachNo;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.OrderLabSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_OrderLabSet(");
			strSql.Append("OrderID,BachNo,LabName,Count,ID_Key)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@BachNo,@LabName,@Count,@ID_Key)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@BachNo", SqlDbType.VarChar,50),
					new SqlParameter("@LabName", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.BachNo;
			parameters[2].Value = model.LabName;
			parameters[3].Value = model.Count;
			parameters[4].Value = model.ID_Key;

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
		public bool Update(Maticsoft.Model.OrderLabSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_OrderLabSet set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("LabName=@LabName,");
			strSql.Append("Count=@Count,");
			strSql.Append("ID_Key=@ID_Key");
			strSql.Append(" where Lab_ID=@Lab_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@LabName", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9),
					new SqlParameter("@BachNo", SqlDbType.VarChar,50),
					new SqlParameter("@Lab_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.LabName;
			parameters[2].Value = model.Count;
			parameters[3].Value = model.ID_Key;
			parameters[4].Value = model.BachNo;
			parameters[5].Value = model.Lab_ID;

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
		public bool Delete(decimal Lab_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderLabSet ");
			strSql.Append(" where Lab_ID=@Lab_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Lab_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Lab_ID;

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
		public bool Delete(string BachNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderLabSet ");
			strSql.Append(" where BachNo=@BachNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@BachNo", SqlDbType.VarChar,50)			};
			parameters[0].Value = BachNo;

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
		public bool DeleteList(string Lab_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_OrderLabSet ");
			strSql.Append(" where Lab_ID in ("+Lab_IDlist + ")  ");
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
		public Maticsoft.Model.OrderLabSet GetModel(decimal Lab_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrderID,BachNo,LabName,Lab_ID,Count,ID_Key from tb_OrderLabSet ");
			strSql.Append(" where Lab_ID=@Lab_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Lab_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Lab_ID;

			Maticsoft.Model.OrderLabSet model=new Maticsoft.Model.OrderLabSet();
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
        public Maticsoft.Model.OrderLabSet GetModel(string BatchNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 OrderID,BachNo,LabName,Lab_ID,Count,ID_Key from tb_OrderLabSet ");
            strSql.Append(" where BachNo=@BachNo");
            SqlParameter[] parameters = {
					new SqlParameter("@BachNo", SqlDbType.VarChar,50)
			};
            parameters[0].Value = BatchNo;

            Maticsoft.Model.OrderLabSet model = new Maticsoft.Model.OrderLabSet();
            DataSet ds = dbs.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
		public Maticsoft.Model.OrderLabSet DataRowToModel(DataRow row)
		{
			Maticsoft.Model.OrderLabSet model=new Maticsoft.Model.OrderLabSet();
			if (row != null)
			{
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
				}
				if(row["BachNo"]!=null)
				{
					model.BachNo=row["BachNo"].ToString();
				}
				if(row["LabName"]!=null)
				{
					model.LabName=row["LabName"].ToString();
				}
				if(row["Lab_ID"]!=null && row["Lab_ID"].ToString()!="")
				{
					model.Lab_ID=decimal.Parse(row["Lab_ID"].ToString());
				}
				if(row["Count"]!=null)
				{
					model.Count=row["Count"].ToString();
				}
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
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
			strSql.Append("select OrderID,BachNo,LabName,Lab_ID,Count,ID_Key ");
			strSql.Append(" FROM tb_OrderLabSet ");
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
			strSql.Append(" OrderID,BachNo,LabName,Lab_ID,Count,ID_Key ");
			strSql.Append(" FROM tb_OrderLabSet ");
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
			strSql.Append("select count(1) FROM tb_OrderLabSet ");
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
				strSql.Append("order by T.Lab_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_OrderLabSet T ");
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
			parameters[0].Value = "tb_OrderLabSet";
			parameters[1].Value = "Lab_ID";
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

