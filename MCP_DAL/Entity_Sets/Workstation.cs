/* Workstation.cs
*
* 功 能： N/A
* 类 名： Workstation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:50   N/A    初版  
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
using System.Collections;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Workstation
	/// </summary>
	public partial class Workstation
	{
		public Workstation()
		{}
        DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Wo_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Workstation");
			strSql.Append(" where Wo_ID=@Wo_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Wo_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Wo_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}

        public string[] GetStringList(string strWhere)
        {
            ArrayList _temModeList = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            DataSet temds = new DataSet();
            strSql.Append("select Wo_ID,Workstation ");
            strSql.Append(" FROM tb_Workstation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            temds = dbs.Query(strSql.ToString());
            string[] _tem = new string[temds.Tables[0].Rows.Count];
            int i = 0;
            foreach (DataRow dr in temds.Tables[0].Rows)
            {
                _tem[i] = dr["Workstation"].ToString();
                i++;
            }
            return _tem;
        }

        /// <summary>
        /// 获取Mode列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ArrayList GetListModel(string strWhere)
        {
            ArrayList _temModeList = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            DataSet temds = new DataSet();
            strSql.Append("select Wo_ID,Workstation ");
            strSql.Append(" FROM tb_Workstation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            temds = dbs.Query(strSql.ToString());
            foreach (DataRow dr in temds.Tables[0].Rows)
            {
                _temModeList.Add(DataRowToModel(dr));
            }
            return _temModeList;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.WorkStation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Workstation(");
			strSql.Append("Workstation)");
			strSql.Append(" values (");
			strSql.Append("@Workstation)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Workstation", SqlDbType.VarChar,15)};
			parameters[0].Value = model.Workstation;

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
		public bool Update(Maticsoft.Model.WorkStation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Workstation set ");
			strSql.Append("Workstation=@Workstation");
			strSql.Append(" where Wo_ID=@Wo_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Workstation", SqlDbType.VarChar,15),
					new SqlParameter("@Wo_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Workstation;
			parameters[1].Value = model.Wo_ID;

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
		public bool Delete(decimal Wo_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Workstation ");
			strSql.Append(" where Wo_ID=@Wo_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Wo_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Wo_ID;

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
		public bool DeleteList(string Wo_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Workstation ");
			strSql.Append(" where Wo_ID in ("+Wo_IDlist + ")  ");
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
		public Maticsoft.Model.WorkStation GetModel(decimal Wo_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Wo_ID,Workstation from tb_Workstation ");
			strSql.Append(" where Wo_ID=@Wo_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Wo_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Wo_ID;

			Maticsoft.Model.WorkStation model=new Maticsoft.Model.WorkStation();
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
        public Maticsoft.Model.WorkStation GetModel(string _workstation)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Wo_ID,Workstation from tb_Workstation ");
            strSql.Append(" where Workstation=@Workstation");
            SqlParameter[] parameters = {
					new SqlParameter("@Workstation", SqlDbType.VarChar)
			};
            parameters[0].Value = _workstation;

            Maticsoft.Model.WorkStation model = new Maticsoft.Model.WorkStation();
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
		public Maticsoft.Model.WorkStation DataRowToModel(DataRow row)
		{
			Maticsoft.Model.WorkStation model=new Maticsoft.Model.WorkStation();
			if (row != null)
			{
				if(row["Wo_ID"]!=null && row["Wo_ID"].ToString()!="")
				{
					model.Wo_ID=decimal.Parse(row["Wo_ID"].ToString());
				}
				if(row["Workstation"]!=null)
				{
					model.Workstation=row["Workstation"].ToString();
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
			strSql.Append("select Wo_ID,Workstation ");
			strSql.Append(" FROM tb_Workstation ");
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
			strSql.Append(" Wo_ID,Workstation ");
			strSql.Append(" FROM tb_Workstation ");
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
			strSql.Append("select count(1) FROM tb_Workstation ");
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
				strSql.Append("order by T.Wo_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Workstation T ");
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
			parameters[0].Value = "tb_Workstation";
			parameters[1].Value = "Wo_ID";
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

