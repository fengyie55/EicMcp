/* tb_EncasementSet.cs
*
* 功 能： N/A
* 类 名： tb_EncasementSet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-18 16:21:01   N/A    初版  
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
using MCP_DBUitility;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:tb_EncasementSet
	/// </summary>
	public partial class EncasementSet
	{
		public EncasementSet()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.EncasementSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_EncasementSet(");
			strSql.Append("BatchNo,Device,DeviceQty,SackQty)");
			strSql.Append(" values (");
			strSql.Append("@BatchNo,@Device,@DeviceQty,@SackQty)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,30),
					new SqlParameter("@Device", SqlDbType.VarChar,50),
					new SqlParameter("@DeviceQty", SqlDbType.VarChar,30),
					new SqlParameter("@SackQty", SqlDbType.VarChar,30)};
			parameters[0].Value = model.BatchNo;
			parameters[1].Value = model.Device;
			parameters[2].Value = model.DeviceQty;
			parameters[3].Value = model.SackQty;

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
		public bool Update(Maticsoft.Model.EncasementSet model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_EncasementSet set ");
			strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("Device=@Device,");
			strSql.Append("DeviceQty=@DeviceQty,");
			strSql.Append("SackQty=@SackQty");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,30),
					new SqlParameter("@Device", SqlDbType.VarChar,50),
					new SqlParameter("@DeviceQty", SqlDbType.VarChar,30),
					new SqlParameter("@SackQty", SqlDbType.VarChar,30),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.BatchNo;
			parameters[1].Value = model.Device;
			parameters[2].Value = model.DeviceQty;
			parameters[3].Value = model.SackQty;
			parameters[4].Value = model.ID;

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
			strSql.Append("delete from tb_EncasementSet ");
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
			strSql.Append("delete from tb_EncasementSet ");
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
		public Maticsoft.Model.EncasementSet GetModel(string _BatchNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BatchNo,Device,DeviceQty,SackQty from tb_EncasementSet ");
            strSql.Append(" where BatchNo=@BatchNo");
			SqlParameter[] parameters = {
					new SqlParameter("@BatchNo", SqlDbType.VarChar,30)
			};
            parameters[0].Value = _BatchNo;

			Maticsoft.Model.EncasementSet model=new Maticsoft.Model.EncasementSet();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
                Maticsoft.Model.EncasementSet tem = new Model.EncasementSet();
                return tem;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.EncasementSet DataRowToModel(DataRow row)
		{
			Maticsoft.Model.EncasementSet model=new Maticsoft.Model.EncasementSet();
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
				if(row["Device"]!=null)
				{
					model.Device=row["Device"].ToString();
				}
				if(row["DeviceQty"]!=null)
				{
					model.DeviceQty=row["DeviceQty"].ToString();
				}
				if(row["SackQty"]!=null)
				{
					model.SackQty=row["SackQty"].ToString();
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
			strSql.Append("select ID,BatchNo,Device,DeviceQty,SackQty ");
			strSql.Append(" FROM tb_EncasementSet ");
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
			strSql.Append(" ID,BatchNo,Device,DeviceQty,SackQty ");
			strSql.Append(" FROM tb_EncasementSet ");
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
			strSql.Append("select count(1) FROM tb_EncasementSet ");
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
			strSql.Append(")AS Row, T.*  from tb_EncasementSet T ");
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
			parameters[0].Value = "tb_EncasementSet";
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

