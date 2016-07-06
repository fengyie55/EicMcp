/**  版本信息模板在安装目录下，可自行修改。
* e_WorkOrder.cs
*
* 功 能： N/A
* 类 名： e_WorkOrder
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/25 12:45:38   N/A    初版
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
	/// 数据访问类:e_WorkOrder
	/// </summary>
	public partial class e_WorkOrder
	{
		public e_WorkOrder()
		{}

        DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WorkNum)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_e_WorkOrder");
			strSql.Append(" where WorkNum=@WorkNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkNum", SqlDbType.VarChar,50)			};
			parameters[0].Value = WorkNum;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.e_WorkOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_e_WorkOrder(");
			strSql.Append("WorkNum,DrawNum)");
			strSql.Append(" values (");
			strSql.Append("@WorkNum,@DrawNum)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkNum", SqlDbType.VarChar,50),
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50)};
			parameters[0].Value = model.WorkNum;
			parameters[1].Value = model.DrawNum;

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
		public bool Update(Maticsoft.Model.e_WorkOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_e_WorkOrder set ");
			strSql.Append("DrawNum=@DrawNum");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@DrawNum", SqlDbType.VarChar,50),
					new SqlParameter("@ID_Key", SqlDbType.Decimal,9),
					new SqlParameter("@WorkNum", SqlDbType.VarChar,50)};
			parameters[0].Value = model.DrawNum;
			parameters[1].Value = model.ID_Key;
			parameters[2].Value = model.WorkNum;

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
			strSql.Append("delete from tb_e_WorkOrder ");
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
		public bool Delete(string WorkNum)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_e_WorkOrder ");
			strSql.Append(" where WorkNum=@WorkNum ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkNum", SqlDbType.VarChar,50)			};
			parameters[0].Value = WorkNum;

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
			strSql.Append("delete from tb_e_WorkOrder ");
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
		public Maticsoft.Model.e_WorkOrder GetModel(decimal ID_Key)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID_Key,WorkNum,DrawNum from tb_e_WorkOrder ");
			strSql.Append(" where ID_Key=@ID_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ID_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = ID_Key;

			Maticsoft.Model.e_WorkOrder model=new Maticsoft.Model.e_WorkOrder();
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
        public Maticsoft.Model.e_WorkOrder GetModel(string Order) 
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID_Key,WorkNum,DrawNum from tb_e_WorkOrder ");
            strSql.Append(" where WorkNum=@WorkNum");
            SqlParameter[] parameters = {
					new SqlParameter("@WorkNum", SqlDbType.VarChar,50)};
            parameters[0].Value = Order;

            Maticsoft.Model.e_WorkOrder model = new Maticsoft.Model.e_WorkOrder();
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
		public Maticsoft.Model.e_WorkOrder DataRowToModel(DataRow row)
		{
			Maticsoft.Model.e_WorkOrder model=new Maticsoft.Model.e_WorkOrder();
			if (row != null)
			{
				if(row["ID_Key"]!=null && row["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(row["ID_Key"].ToString());
				}
				if(row["WorkNum"]!=null)
				{
					model.WorkNum=row["WorkNum"].ToString();
				}
				if(row["DrawNum"]!=null)
				{
					model.DrawNum=row["DrawNum"].ToString();
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
			strSql.Append("select ID_Key,WorkNum,DrawNum ");
			strSql.Append(" FROM tb_e_WorkOrder ");
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
			strSql.Append(" ID_Key,WorkNum,DrawNum ");
			strSql.Append(" FROM tb_e_WorkOrder ");
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
			strSql.Append("select count(1) FROM tb_e_WorkOrder ");
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
			strSql.Append(")AS Row, T.*  from tb_e_WorkOrder T ");
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
			parameters[0].Value = "tb_e_WorkOrder";
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

