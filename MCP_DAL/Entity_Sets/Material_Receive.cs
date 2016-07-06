/* Material_Receive.cs
*
* 功 能： N/A
* 类 名： Material_Receive
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:48   N/A    初版  
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
	/// 数据访问类:Material_Receive
	/// </summary>
	public partial class Material_Receive
	{
		public Material_Receive()
		{}
        DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal Re_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Material_Receive");
			strSql.Append(" where Re_ID=@Re_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Re_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Re_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.Material_Receive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Material_Receive(");
			strSql.Append("Orm_ID,Client,ClientNum,Count,UserID,WorkStationID,DataTime)");
			strSql.Append(" values (");
			strSql.Append("@Orm_ID,@Client,@ClientNum,@Count,@UserID,@WorkStationID,@DataTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.VarChar,15),
					new SqlParameter("@Client", SqlDbType.VarChar,50),
					new SqlParameter("@ClientNum", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,15),
					new SqlParameter("@UserID", SqlDbType.VarChar,15),
					new SqlParameter("@WorkStationID", SqlDbType.VarChar,15),
					new SqlParameter("@DataTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Orm_ID;
			parameters[1].Value = model.Client;
			parameters[2].Value = model.ClientNum;
			parameters[3].Value = model.Count;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.WorkStationID;
			parameters[6].Value = model.DataTime;

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
		public bool Update(Maticsoft.Model.Material_Receive model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Material_Receive set ");
			strSql.Append("Orm_ID=@Orm_ID,");
			strSql.Append("Client=@Client,");
			strSql.Append("ClientNum=@ClientNum,");
			strSql.Append("Count=@Count,");
			strSql.Append("UserID=@UserID,");
			strSql.Append("WorkStationID=@WorkStationID,");
			strSql.Append("DataTime=@DataTime");
			strSql.Append(" where Re_ID=@Re_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Orm_ID", SqlDbType.VarChar,15),
					new SqlParameter("@Client", SqlDbType.VarChar,50),
					new SqlParameter("@ClientNum", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,15),
					new SqlParameter("@UserID", SqlDbType.VarChar,15),
					new SqlParameter("@WorkStationID", SqlDbType.VarChar,15),
					new SqlParameter("@DataTime", SqlDbType.DateTime),
					new SqlParameter("@Re_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Orm_ID;
			parameters[1].Value = model.Client;
			parameters[2].Value = model.ClientNum;
			parameters[3].Value = model.Count;
			parameters[4].Value = model.UserID;
			parameters[5].Value = model.WorkStationID;
			parameters[6].Value = model.DataTime;
			parameters[7].Value = model.Re_ID;

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
		public bool Delete(decimal Re_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Material_Receive ");
			strSql.Append(" where Re_ID=@Re_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Re_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Re_ID;

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
		public bool DeleteList(string Re_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Material_Receive ");
			strSql.Append(" where Re_ID in ("+Re_IDlist + ")  ");
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
		public Maticsoft.Model.Material_Receive GetModel(decimal Re_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Re_ID,Orm_ID,Client,ClientNum,Count,UserID,WorkStationID,DataTime from tb_Material_Receive ");
			strSql.Append(" where Re_ID=@Re_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Re_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = Re_ID;

			Maticsoft.Model.Material_Receive model=new Maticsoft.Model.Material_Receive();
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
		public Maticsoft.Model.Material_Receive DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Material_Receive model=new Maticsoft.Model.Material_Receive();
			if (row != null)
			{
				if(row["Re_ID"]!=null && row["Re_ID"].ToString()!="")
				{
					model.Re_ID=decimal.Parse(row["Re_ID"].ToString());
				}
				if(row["Orm_ID"]!=null)
				{
					model.Orm_ID=row["Orm_ID"].ToString();
				}
				if(row["Client"]!=null)
				{
					model.Client=row["Client"].ToString();
				}
				if(row["ClientNum"]!=null)
				{
					model.ClientNum=row["ClientNum"].ToString();
				}
				if(row["Count"]!=null)
				{
					model.Count=row["Count"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["WorkStationID"]!=null)
				{
					model.WorkStationID=row["WorkStationID"].ToString();
				}
				if(row["DataTime"]!=null && row["DataTime"].ToString()!="")
				{
					model.DataTime=DateTime.Parse(row["DataTime"].ToString());
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
            /*
			strSql.Append("select Re_ID,Orm_ID,Client,ClientNum,Count,UserID,WorkStationID,DataTime ");
			strSql.Append(" FROM tb_Material_Receive ");
            if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
             */
            strSql.Append("  SELECT tb_Material_Receive.Re_ID, tb_Material_Receive.Orm_ID, ");
    strSql.Append("  tb_Material_Receive.Client, tb_Material_Receive.ClientNum, ");
     strSql.Append(" tb_Material_Receive.Count, tb_Material_Receive.UserID, ");
    strSql.Append("  tb_Workstation.Workstation AS WorkStationID, tb_Material_Receive.DataTime ");
strSql.Append(" FROM tb_Material_Receive INNER JOIN ");
strSql.Append("      tb_Workstation ON tb_Material_Receive.WorkStationID = tb_Workstation.Wo_ID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbs.Query(strSql.ToString());
		}

        /// <summary>
        /// 获取已经领取数量
        /// </summary>
        public double Get_Count(string _Orm_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(CONVERT(float, Count)) FROM tb_Material_Receive ");
            if (_Orm_ID.Trim() != "")
            {
                strSql.Append(" where Orm_ID = '" + _Orm_ID+"'");
            }
            object obj = dbs.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }          
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
			strSql.Append(" Re_ID,Orm_ID,Client,ClientNum,Count,UserID,WorkStationID,DataTime ");
			strSql.Append(" FROM tb_Material_Receive ");
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
			strSql.Append("select count(1) FROM tb_Material_Receive ");
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
				strSql.Append("order by T.Re_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Material_Receive T ");
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
			parameters[0].Value = "tb_Material_Receive";
			parameters[1].Value = "Re_ID";
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

