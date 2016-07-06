/**  版本信息模板在安装目录下，可自行修改。
* e_ProcessDraw.cs
*
* 功 能： N/A
* 类 名： e_ProcessDraw
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/25 12:45:34   N/A    初版
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
using MCP_DBUitility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:e_ProcessDraw
	/// </summary>
	public partial class e_ProcessDraw
	{
		public e_ProcessDraw()
		{}
        DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string DrawNum)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_e_ProcessDraw");
			strSql.Append(" where DrawNum=@DrawNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50)			};
			parameters[0].Value = DrawNum;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.e_ProcessDraw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_e_ProcessDraw(");
			strSql.Append("DrawNum,ProcessNum,Name,Model,Pic,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@DrawNum,@ProcessNum,@Name,@Model,@Pic,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50),
					new SqlParameter("@ProcessNum", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@Model", SqlDbType.Text),
					new SqlParameter("@Pic", SqlDbType.Image),
					new SqlParameter("@Remarks", SqlDbType.Text)};
			parameters[0].Value = model.DrawNum;
			parameters[1].Value = model.ProcessNum;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Model;
			parameters[4].Value = model.Pic;
			parameters[5].Value = model.Remarks;

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
		public bool Update(Maticsoft.Model.e_ProcessDraw model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_e_ProcessDraw set ");
			strSql.Append("ProcessNum=@ProcessNum,");
			strSql.Append("Name=@Name,");
			strSql.Append("Model=@Model,");
			strSql.Append("Pic=@Pic,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ProcessNum", SqlDbType.VarChar,50),
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@Model", SqlDbType.Text),
					new SqlParameter("@Pic", SqlDbType.Image),
					new SqlParameter("@Remarks", SqlDbType.Text),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9),
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ProcessNum;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Model;
			parameters[3].Value = model.Pic;
			parameters[4].Value = model.Remarks;
			parameters[5].Value = model.ID_Key;
			parameters[6].Value = model.DrawNum;

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
			strSql.Append("delete from tb_e_ProcessDraw ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string DrawNum)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_e_ProcessDraw ");
			strSql.Append(" where DrawNum=@DrawNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50)			};
			parameters[0].Value = DrawNum;

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
			strSql.Append("delete from tb_e_ProcessDraw ");
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
        public Maticsoft.Model.e_ProcessDraw GetModel(string DrawNum)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID_Key,DrawNum,ProcessNum,Name,Model,Pic,Remarks from tb_e_ProcessDraw ");
            strSql.Append(" where DrawNum=@DrawNum");
			SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50)
			};
            parameters[0].Value = DrawNum;

			Maticsoft.Model.e_ProcessDraw model=new Maticsoft.Model.e_ProcessDraw();
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
		public Maticsoft.Model.e_ProcessDraw DataRowToModel(DataRow row)
		{
			Maticsoft.Model.e_ProcessDraw model=new Maticsoft.Model.e_ProcessDraw();
			if (row != null)
			{
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
				}
				if(row["DrawNum"]!=null)
				{
					model.DrawNum=row["DrawNum"].ToString();
				}
				if(row["ProcessNum"]!=null)
				{
					model.ProcessNum=row["ProcessNum"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Model"]!=null)
				{
					model.Model=row["Model"].ToString();
				}
				if(row["Pic"]!=null && row["Pic"].ToString()!="")
				{
					model.Pic=(byte[])row["Pic"];
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
			strSql.Append("select ID_Key,DrawNum,ProcessNum,Name,Model,Pic,Remarks ");
			strSql.Append(" FROM tb_e_ProcessDraw ");
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
			strSql.Append(" ID_Key,DrawNum,ProcessNum,Name,Model,Pic,Remarks ");
			strSql.Append(" FROM tb_e_ProcessDraw ");
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
			strSql.Append("select count(1) FROM tb_e_ProcessDraw ");
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
			strSql.Append(")AS Row, T.*  from tb_e_ProcessDraw T ");
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
			parameters[0].Value = "tb_e_ProcessDraw";
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

