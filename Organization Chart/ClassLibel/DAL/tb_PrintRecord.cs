/**  版本信息模板在安装目录下，可自行修改。
* tb_PrintRecord.cs
*
* 功 能： N/A
* 类 名： tb_PrintRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-29 9:31:22   N/A    初版
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
	/// 数据访问类:tb_PrintRecord
	/// </summary>
	public partial class tb_PrintRecord
	{
		public tb_PrintRecord()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SN)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_PrintRecord");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,20)			};
			parameters[0].Value = SN;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.tb_PrintRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_PrintRecord(");
			strSql.Append("SN,Staff,DataTime,LabellMode,BatchNo,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@SN,@Staff,@DataTime,@LabellMode,@BatchNo,@OrderID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,20),
					new SqlParameter("@Staff", SqlDbType.VarChar,20),
					new SqlParameter("@DataTime", SqlDbType.VarChar,30),
					new SqlParameter("@LabellMode", SqlDbType.VarChar,30),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,30),
					new SqlParameter("@OrderID", SqlDbType.VarChar,30)};
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Staff;
			parameters[2].Value = model.DataTime;
			parameters[3].Value = model.LabellMode;
			parameters[4].Value = model.BatchNo;
			parameters[5].Value = model.OrderID;

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
		public bool Update(Maticsoft.Model.tb_PrintRecord model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_PrintRecord set ");
			strSql.Append("Staff=@Staff,");
			strSql.Append("DataTime=@DataTime,");
			strSql.Append("LabellMode=@LabellMode,");
			strSql.Append("BatchNo=@BatchNo,");
			strSql.Append("OrderID=@OrderID");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@Staff", SqlDbType.VarChar,20),
					new SqlParameter("@DataTime", SqlDbType.VarChar,30),
					new SqlParameter("@LabellMode", SqlDbType.VarChar,30),
					new SqlParameter("@BatchNo", SqlDbType.VarChar,30),
					new SqlParameter("@OrderID", SqlDbType.VarChar,30),
					new SqlParameter("@SN", SqlDbType.VarChar,20),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Staff;
			parameters[1].Value = model.DataTime;
			parameters[2].Value = model.LabellMode;
			parameters[3].Value = model.BatchNo;
			parameters[4].Value = model.OrderID;
			parameters[5].Value = model.SN;
			parameters[6].Value = model.ID_Key;

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
		public bool Delete(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_PrintRecord ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

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
		public bool Delete(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_PrintRecord ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,20)			};
			parameters[0].Value = SN;

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
		public bool DeleteList(string ID_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_PrintRecord ");
			strSql.Append(" where ID_Key in ("+ID_Keylist + ")  ");
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
		public Maticsoft.Model.tb_PrintRecord GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,Staff,DataTime,LabellMode,BatchNo,OrderID,ID_Key from tb_PrintRecord ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.tb_PrintRecord model=new Maticsoft.Model.tb_PrintRecord();
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
		public Maticsoft.Model.tb_PrintRecord DataRowToModel(DataRow row)
		{
			Maticsoft.Model.tb_PrintRecord model=new Maticsoft.Model.tb_PrintRecord();
			if (row != null)
			{
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["Staff"]!=null)
				{
					model.Staff=row["Staff"].ToString();
				}
				if(row["DataTime"]!=null)
				{
					model.DataTime=row["DataTime"].ToString();
				}
				if(row["LabellMode"]!=null)
				{
					model.LabellMode=row["LabellMode"].ToString();
				}
				if(row["BatchNo"]!=null)
				{
					model.BatchNo=row["BatchNo"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
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
			strSql.Append("select SN,Staff,DataTime,LabellMode,BatchNo,OrderID,ID_Key ");
			strSql.Append(" FROM tb_PrintRecord ");
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
			strSql.Append(" SN,Staff,DataTime,LabellMode,BatchNo,OrderID,ID_Key ");
			strSql.Append(" FROM tb_PrintRecord ");
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
			strSql.Append("select count(1) FROM tb_PrintRecord ");
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
				strSql.Append("order by T.ID_Key desc");
			}
			strSql.Append(")AS Row, T.*  from tb_PrintRecord T ");
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
			parameters[0].Value = "tb_PrintRecord";
			parameters[1].Value = "ID_Key";
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

