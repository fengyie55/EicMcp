﻿/* BoxInfo.cs
*
* 功 能： N/A
* 类 名： BoxInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-19 8:21:37   N/A    初版  
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
	/// 数据访问类:BoxInfo
	/// </summary>
	public partial class BoxInfo
	{
		public BoxInfo()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_Where(string strsql)
        {
            string strSql = "SELECT COUNT(1)  from tb_BoxInfo where " + strsql;
            bool t = dbs.Exists(strSql);
            return t;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="_SqlWhere">Where查询条件  批号 或箱号</param>
        /// <returns></returns>
        public int GetYetEncasementCount(string _SqlWhere)
        {
            string strSql = "SELECT COUNT(tb_Encasement.Qty) AS Qty ";
            strSql += "FROM tb_BoxInfo INNER JOIN  tb_Encasement ON tb_BoxInfo.ID = tb_Encasement.BoxID WHERE    " + _SqlWhere;
            return int.Parse(dbs.Query(strSql).Tables[0].Rows[0]["Qty"].ToString());
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.BoxInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_BoxInfo(");
			strSql.Append("BatchNo,BoxSN,Qty,Type,State)");
			strSql.Append(" values (");
			strSql.Append("@BatchNo,@BoxSN,@Qty,@Type,@State)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,30),
					new SqlParameter("@BoxSN", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.VarChar,30),
					new SqlParameter("@Type", SqlDbType.VarChar,30),
					new SqlParameter("@State", SqlDbType.VarChar,30)};
			parameters[0].Value = model.BatchNo;
			parameters[1].Value = model.BoxSN;
			parameters[2].Value = model.Qty;
			parameters[3].Value = model.Type;
			parameters[4].Value = model.State;

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
		public bool Update(Maticsoft.Model.BoxInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_BoxInfo set ");
			strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("BoxSN=@BoxSN,");
			strSql.Append("Qty=@Qty,");
			strSql.Append("Type=@Type,");
			strSql.Append("State=@State");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,30),
					new SqlParameter("@BoxSN", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.VarChar,30),
					new SqlParameter("@Type", SqlDbType.VarChar,30),
					new SqlParameter("@State", SqlDbType.VarChar,30),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.BatchNo;
			parameters[1].Value = model.BoxSN;
			parameters[2].Value = model.Qty;
			parameters[3].Value = model.Type;
			parameters[4].Value = model.State;
			parameters[5].Value = model.ID;

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
		public bool Delete(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_BoxInfo ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_BoxInfo ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Maticsoft.Model.BoxInfo GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BatchNo,BoxSN,Qty,Type,State from tb_BoxInfo ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.BoxInfo model=new Maticsoft.Model.BoxInfo();
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
        public Maticsoft.Model.BoxInfo GetModel(string  sqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TOP (1) ID, BatchNo, BoxSN, Qty, Type, State FROM tb_BoxInfo WHERE ");
            strSql.Append(sqlWhere); 
            strSql.Append( "ORDER BY ID");
            Maticsoft.Model.BoxInfo model = new Maticsoft.Model.BoxInfo();
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                Maticsoft.Model.BoxInfo tem = new Model.BoxInfo();
                return tem;
            }
        }


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.BoxInfo DataRowToModel(DataRow row)
		{
			Maticsoft.Model.BoxInfo model=new Maticsoft.Model.BoxInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["BoxSN"]!=null)
				{
					model.BoxSN=row["BoxSN"].ToString();
				}
				if(row["Qty"]!=null)
				{
					model.Qty=row["Qty"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
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
			strSql.Append("select ID,BatchNo,BoxSN,Qty,Type,State ");
			strSql.Append(" FROM tb_BoxInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbs.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList_BatchNo_Or_BoxSN(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  tb_BoxInfo.BoxSN, tb_Encasement.SN ");
            strSql.Append(" FROM tb_BoxInfo INNER JOIN tb_Encasement ON tb_BoxInfo.ID = tb_Encasement.BoxID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" ORDER BY tb_BoxInfo.BoxSN");
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
			strSql.Append(" ID,BatchNo,BoxSN,Qty,Type,State ");
			strSql.Append(" FROM tb_BoxInfo ");
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
			strSql.Append("select count(1) FROM tb_BoxInfo ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_BoxInfo T ");
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
			parameters[0].Value = "tb_BoxInfo";
			parameters[1].Value = "ID";
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

