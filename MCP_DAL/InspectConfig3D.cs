/**  版本信息模板在安装目录下，可自行修改。
* InspectConfig3D.cs
*
* 功 能： N/A
* 类 名： InspectConfig3D
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  11/3/2016 11:32:51 AM   N/A    初版
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
using MCP_DBUitility;

namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:InspectConfig3D
    /// </summary>
    public partial class InspectConfig3D
	{
		public InspectConfig3D()
		{}
        #region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(Maticsoft.Model.InspectConfig3D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_InspectConfig3D(");
			strSql.Append("ProductId,Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max)");
			strSql.Append(" values (");
			strSql.Append("ProductId,Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("Type", SqlDbType.VarChar,15),
					new SqlParameter("RCO_Min", SqlDbType.VarChar,15),
					new SqlParameter("RCO_Max", SqlDbType.VarChar,15),
					new SqlParameter("AO_Min", SqlDbType.VarChar,15),
					new SqlParameter("AO_Max", SqlDbType.VarChar,15),
					new SqlParameter("FH_Min", SqlDbType.VarChar,15),
					new SqlParameter("FH_Max", SqlDbType.VarChar,15),
					new SqlParameter("AE_Min", SqlDbType.VarChar,15),
					new SqlParameter("AE_Max", SqlDbType.VarChar,15)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.RCO_Min;
			parameters[3].Value = model.RCO_Max;
			parameters[4].Value = model.AO_Min;
			parameters[5].Value = model.AO_Max;
			parameters[6].Value = model.FH_Min;
			parameters[7].Value = model.FH_Max;
			parameters[8].Value = model.AE_Min;
			parameters[9].Value = model.AE_Max;

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
		public bool Update(Maticsoft.Model.InspectConfig3D model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_InspectConfig3D set ");
			strSql.Append("ProductId=ProductId,");
			strSql.Append("Type=Type,");
			strSql.Append("RCO_Min=RCO_Min,");
			strSql.Append("RCO_Max=RCO_Max,");
			strSql.Append("AO_Min=AO_Min,");
			strSql.Append("AO_Max=AO_Max,");
			strSql.Append("FH_Min=FH_Min,");
			strSql.Append("FH_Max=FH_Max,");
			strSql.Append("AE_Min=AE_Min,");
			strSql.Append("AE_Max=AE_Max");
			strSql.Append(" where ID_Key=ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("Type", SqlDbType.VarChar,15),
					new SqlParameter("RCO_Min", SqlDbType.VarChar,15),
					new SqlParameter("RCO_Max", SqlDbType.VarChar,15),
					new SqlParameter("AO_Min", SqlDbType.VarChar,15),
					new SqlParameter("AO_Max", SqlDbType.VarChar,15),
					new SqlParameter("FH_Min", SqlDbType.VarChar,15),
					new SqlParameter("FH_Max", SqlDbType.VarChar,15),
					new SqlParameter("AE_Min", SqlDbType.VarChar,15),
					new SqlParameter("AE_Max", SqlDbType.VarChar,15),
					new SqlParameter("ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.RCO_Min;
			parameters[3].Value = model.RCO_Max;
			parameters[4].Value = model.AO_Min;
			parameters[5].Value = model.AO_Max;
			parameters[6].Value = model.FH_Min;
			parameters[7].Value = model.FH_Max;
			parameters[8].Value = model.AE_Min;
			parameters[9].Value = model.AE_Max;
			parameters[10].Value = model.ID_Key;

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
		public bool Delete(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_InspectConfig3D ");
			strSql.Append(" where ID_Key=ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

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
		public bool DeleteList(string ID_Keylist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_InspectConfig3D ");
			strSql.Append(" where ID_Key in ("+ID_Keylist + ")  ");
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
		public Maticsoft.Model.InspectConfig3D GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductId,Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max,ID_Key from tb_InspectConfig3D ");
			strSql.Append(" where ID_Key=ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.InspectConfig3D model=new Maticsoft.Model.InspectConfig3D();
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
		public Maticsoft.Model.InspectConfig3D DataRowToModel(DataRow row)
		{
			Maticsoft.Model.InspectConfig3D model=new Maticsoft.Model.InspectConfig3D();
			if (row != null)
			{
				if(row["ProductId"]!=null)
				{
					model.ProductId=row["ProductId"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["RCO_Min"]!=null)
				{
					model.RCO_Min=row["RCO_Min"].ToString();
				}
				if(row["RCO_Max"]!=null)
				{
					model.RCO_Max=row["RCO_Max"].ToString();
				}
				if(row["AO_Min"]!=null)
				{
					model.AO_Min=row["AO_Min"].ToString();
				}
				if(row["AO_Max"]!=null)
				{
					model.AO_Max=row["AO_Max"].ToString();
				}
				if(row["FH_Min"]!=null)
				{
					model.FH_Min=row["FH_Min"].ToString();
				}
				if(row["FH_Max"]!=null)
				{
					model.FH_Max=row["FH_Max"].ToString();
				}
				if(row["AE_Min"]!=null)
				{
					model.AE_Min=row["AE_Min"].ToString();
				}
				if(row["AE_Max"]!=null)
				{
					model.AE_Max=row["AE_Max"].ToString();
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
			strSql.Append("select ProductId,Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max,ID_Key ");
			strSql.Append(" FROM tb_InspectConfig3D ");
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
			strSql.Append(" ProductId,Type,RCO_Min,RCO_Max,AO_Min,AO_Max,FH_Min,FH_Max,AE_Min,AE_Max,ID_Key ");
			strSql.Append(" FROM tb_InspectConfig3D ");
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
			strSql.Append("select count(1) FROM tb_InspectConfig3D ");
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
				strSql.Append("order by T.ID_Key desc");
			}
			strSql.Append(")AS Row, T.*  from tb_InspectConfig3D T ");
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
					new SqlParameter("tblName", SqlDbType.VarChar, 255),
					new SqlParameter("fldName", SqlDbType.VarChar, 255),
					new SqlParameter("PageSize", SqlDbType.Int),
					new SqlParameter("PageIndex", SqlDbType.Int),
					new SqlParameter("IsReCount", SqlDbType.Bit),
					new SqlParameter("OrderType", SqlDbType.Bit),
					new SqlParameter("strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_InspectConfig3D";
			parameters[1].Value = "ID_Key";
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

