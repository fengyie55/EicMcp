﻿/**  版本信息模板在安装目录下，可自行修改。
* FixtureList.cs
*
* 功 能： N/A
* 类 名： FixtureList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-09 13:26:22   N/A    初版
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

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:FixtureList
	/// </summary>
	public partial class FixtureList
	{
		public FixtureList()
		{}
		#region  BasicMethod
        MCP_DBUitility.DbHelperSQL dbs = new MCP_DBUitility.DbHelperSQL(Model.E_ConnectionList.EquipmentMS);
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_FixtureList");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.FixtureList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_FixtureList(");
			strSql.Append("BarCode,Fixture_Name,InstallLocation,F_State,LogDate,LogUser,CareUser,UseDate,ScrapDate,FAY_ID,Remark)");
			strSql.Append(" values (");
			strSql.Append("@BarCode,@Fixture_Name,@InstallLocation,@F_State,@LogDate,@LogUser,@CareUser,@UseDate,@ScrapDate,@FAY_ID,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Fixture_Name", SqlDbType.VarChar,50),
					new SqlParameter("@InstallLocation", SqlDbType.VarChar,50),
					new SqlParameter("@F_State", SqlDbType.VarChar,50),
					new SqlParameter("@LogDate", SqlDbType.DateTime),
					new SqlParameter("@LogUser", SqlDbType.VarChar,50),
					new SqlParameter("@CareUser", SqlDbType.VarChar,50),
					new SqlParameter("@UseDate", SqlDbType.DateTime),
					new SqlParameter("@ScrapDate", SqlDbType.DateTime),
					new SqlParameter("@FAY_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,255)};
			parameters[0].Value = model.BarCode;
			parameters[1].Value = model.Fixture_Name;
			parameters[2].Value = model.InstallLocation;
			parameters[3].Value = model.F_State;
			parameters[4].Value = model.LogDate;
			parameters[5].Value = model.LogUser;
			parameters[6].Value = model.CareUser;
			parameters[7].Value = model.UseDate;
			parameters[8].Value = model.ScrapDate;
			parameters[9].Value = model.FAY_ID;
			parameters[10].Value = model.Remark;

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
		public bool Update(Maticsoft.Model.FixtureList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_FixtureList set ");
			strSql.Append("BarCode=@BarCode,");
			strSql.Append("Fixture_Name=@Fixture_Name,");
			strSql.Append("InstallLocation=@InstallLocation,");
			strSql.Append("F_State=@F_State,");
			strSql.Append("LogDate=@LogDate,");
			strSql.Append("LogUser=@LogUser,");
			strSql.Append("CareUser=@CareUser,");
			strSql.Append("UseDate=@UseDate,");
			strSql.Append("ScrapDate=@ScrapDate,");
			strSql.Append("FAY_ID=@FAY_ID,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@BarCode", SqlDbType.VarChar,50),
					new SqlParameter("@Fixture_Name", SqlDbType.VarChar,50),
					new SqlParameter("@InstallLocation", SqlDbType.VarChar,50),
					new SqlParameter("@F_State", SqlDbType.VarChar,50),
					new SqlParameter("@LogDate", SqlDbType.DateTime),
					new SqlParameter("@LogUser", SqlDbType.VarChar,50),
					new SqlParameter("@CareUser", SqlDbType.VarChar,50),
					new SqlParameter("@UseDate", SqlDbType.DateTime),
					new SqlParameter("@ScrapDate", SqlDbType.DateTime),
					new SqlParameter("@FAY_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,255),
					new SqlParameter("@ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.BarCode;
			parameters[1].Value = model.Fixture_Name;
			parameters[2].Value = model.InstallLocation;
			parameters[3].Value = model.F_State;
			parameters[4].Value = model.LogDate;
			parameters[5].Value = model.LogUser;
			parameters[6].Value = model.CareUser;
			parameters[7].Value = model.UseDate;
			parameters[8].Value = model.ScrapDate;
			parameters[9].Value = model.FAY_ID;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from tb_FixtureList ");
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
			strSql.Append("delete from tb_FixtureList ");
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
		public Maticsoft.Model.FixtureList GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,BarCode,Fixture_Name,InstallLocation,F_State,LogDate,LogUser,CareUser,UseDate,ScrapDate,FAY_ID,Remark from tb_FixtureList ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Decimal)
			};
			parameters[0].Value = ID;

			Maticsoft.Model.FixtureList model=new Maticsoft.Model.FixtureList();
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
		public Maticsoft.Model.FixtureList DataRowToModel(DataRow row)
		{
			Maticsoft.Model.FixtureList model=new Maticsoft.Model.FixtureList();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["BarCode"]!=null)
				{
					model.BarCode=row["BarCode"].ToString();
				}
				if(row["Fixture_Name"]!=null)
				{
					model.Fixture_Name=row["Fixture_Name"].ToString();
				}
				if(row["InstallLocation"]!=null)
				{
					model.InstallLocation=row["InstallLocation"].ToString();
				}
				if(row["F_State"]!=null)
				{
					model.F_State=row["F_State"].ToString();
				}
				if(row["LogDate"]!=null && row["LogDate"].ToString()!="")
				{
					model.LogDate=DateTime.Parse(row["LogDate"].ToString());
				}
				if(row["LogUser"]!=null)
				{
					model.LogUser=row["LogUser"].ToString();
				}
				if(row["CareUser"]!=null)
				{
					model.CareUser=row["CareUser"].ToString();
				}
				if(row["UseDate"]!=null && row["UseDate"].ToString()!="")
				{
					model.UseDate=DateTime.Parse(row["UseDate"].ToString());
				}
				if(row["ScrapDate"]!=null && row["ScrapDate"].ToString()!="")
				{
					model.ScrapDate=DateTime.Parse(row["ScrapDate"].ToString());
				}
				if(row["FAY_ID"]!=null)
				{
					model.FAY_ID=row["FAY_ID"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select ID,BarCode,Fixture_Name,InstallLocation,F_State,LogDate,LogUser,CareUser,UseDate,ScrapDate,FAY_ID,Remark ");
			strSql.Append(" FROM tb_FixtureList ");
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
			strSql.Append(" ID,BarCode,Fixture_Name,InstallLocation,F_State,LogDate,LogUser,CareUser,UseDate,ScrapDate,FAY_ID,Remark ");
			strSql.Append(" FROM tb_FixtureList ");
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
			strSql.Append("select count(1) FROM tb_FixtureList ");
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
			strSql.Append(")AS Row, T.*  from tb_FixtureList T ");
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
			parameters[0].Value = "tb_FixtureList";
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
        /// <summary>
        /// 获取字段不重复记录
        /// </summary>
        /// <param name="_Value">字段名</param>
        /// <returns></returns>
        public DataSet Get_Distinct_List(string _Value)
        {
            DataSet ds = new DataSet();
            try
            {
                if (_Value.Trim() != "")
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(" SELECT DISTINCT ");
                    strSql.Append(_Value);
                    strSql.Append(" FROM tb_FixtureList ");
                    ds = dbs.Query(strSql.ToString());
                }
            }
            catch { ds = null; };
            return ds;
        }
		#endregion  ExtensionMethod
	}
}

