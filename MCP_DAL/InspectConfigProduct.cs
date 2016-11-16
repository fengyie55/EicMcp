/**  版本信息模板在安装目录下，可自行修改。
* InspectConfigProduct.cs
*
* 功 能： N/A
* 类 名： InspectConfigProduct
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  11/5/2016 2:54:57 PM   N/A    初版
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
	/// 数据访问类:InspectConfigProduct
	/// </summary>
	public partial class InspectConfigProduct
	{
		public InspectConfigProduct()
		{ }

		DbHelperSQL dbs = new DbHelperSQL();
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ProductId)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from tb_InspectConfigProduct");
			strSql.Append(" where ProductId=ProductId ");
			SqlParameter[] parameters = {
					new SqlParameter("ProductId", SqlDbType.NVarChar,50)         };
			parameters[0].Value = ProductId;

			return dbs.Exists(strSql.ToString(), parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.InspectConfigProduct model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tb_InspectConfigProduct(");
			strSql.Append("ProductId,ProductName,Model,InspectMethod,InspectType,LabelName,ThreeDimensionalConfig,ExfoConfig,LabelContentConfig)");
			strSql.Append(" values (");
			strSql.Append("@ProductId,@ProductName,@Model,@InspectMethod,@InspectType,@LabelName,@ThreeDimensionalConfig,@ExfoConfig,@LabelContentConfig)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("@ProductName", SqlDbType.NVarChar,150),
					new SqlParameter("@Model", SqlDbType.NVarChar,200),
					new SqlParameter("@InspectMethod", SqlDbType.NVarChar,100),
					new SqlParameter("@InspectType", SqlDbType.NVarChar,150),
					new SqlParameter("@LabelName", SqlDbType.NVarChar,200),
					new SqlParameter("@ThreeDimensionalConfig", SqlDbType.NVarChar,-1),
					new SqlParameter("@ExfoConfig", SqlDbType.NVarChar,-1),
					new SqlParameter("@LabelContentConfig", SqlDbType.NVarChar,-1)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.ProductName;
			parameters[2].Value = model.Model;
			parameters[3].Value = model.InspectMethod;
			parameters[4].Value = model.InspectType;
			parameters[5].Value = model.LabelName;
			parameters[6].Value = model.ThreeDimensionalConfig;
			parameters[7].Value = model.ExfoConfig;
			parameters[8].Value = model.LabelContentConfig;

			object obj = dbs.GetSingle(strSql.ToString(), parameters);
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
		public bool Update(Maticsoft.Model.InspectConfigProduct model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tb_InspectConfigProduct set ");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("Model=@Model,");
			strSql.Append("InspectMethod=@InspectMethod,");
			strSql.Append("InspectType=@InspectType,");
			strSql.Append("LabelName=@LabelName,");
			strSql.Append("ThreeDimensionalConfig=@ThreeDimensionalConfig,");
			strSql.Append("ExfoConfig=@ExfoConfig,");
			strSql.Append("LabelContentConfig=@LabelContentConfig");
			strSql.Append(" where Id_Key=@Id_Key");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductName", SqlDbType.NVarChar,150),
					new SqlParameter("@Model", SqlDbType.NVarChar,200),
					new SqlParameter("@InspectMethod", SqlDbType.NVarChar,100),
					new SqlParameter("@InspectType", SqlDbType.NVarChar,150),
					new SqlParameter("@LabelName", SqlDbType.NVarChar,200),
					new SqlParameter("@ThreeDimensionalConfig", SqlDbType.NVarChar,-1),
					new SqlParameter("@ExfoConfig", SqlDbType.NVarChar,-1),
					new SqlParameter("@LabelContentConfig", SqlDbType.NVarChar,-1),
					new SqlParameter("@ProductId", SqlDbType.NVarChar,50),
					new SqlParameter("@Id_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.ProductName;
			parameters[1].Value = model.Model;
			parameters[2].Value = model.InspectMethod;
			parameters[3].Value = model.InspectType;
			parameters[4].Value = model.LabelName;
			parameters[5].Value = model.ThreeDimensionalConfig;
			parameters[6].Value = model.ExfoConfig;
			parameters[7].Value = model.LabelContentConfig;
			parameters[8].Value = model.ProductId;
			parameters[9].Value = model.Id_Key;

			int rows = dbs.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Delete(decimal Id_Key)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tb_InspectConfigProduct ");
			strSql.Append(" where Id_Key=Id_Key");
			SqlParameter[] parameters = {
					new SqlParameter("Id_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = Id_Key;

			int rows = dbs.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Delete(string ProductId)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tb_InspectConfigProduct ");
			strSql.Append(" where ProductId=ProductId ");
			SqlParameter[] parameters = {
					new SqlParameter("ProductId", SqlDbType.NVarChar,50)         };
			parameters[0].Value = ProductId;

			int rows = dbs.ExecuteSql(strSql.ToString(), parameters);
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
		public bool DeleteList(string Id_Keylist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tb_InspectConfigProduct ");
			strSql.Append(" where Id_Key in (" + Id_Keylist + ")  ");
			int rows = dbs.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.InspectConfigProduct GetModel(decimal Id_Key)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ProductId,ProductName,Model,InspectMethod,InspectType,LabelName,ThreeDimensionalConfig,ExfoConfig,LabelContentConfig,Id_Key from tb_InspectConfigProduct ");
			strSql.Append(" where Id_Key=Id_Key");
			SqlParameter[] parameters = {
					new SqlParameter("Id_Key", SqlDbType.Decimal)
			};
			parameters[0].Value = Id_Key;

			Maticsoft.Model.InspectConfigProduct model = new Maticsoft.Model.InspectConfigProduct();
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
		public Maticsoft.Model.InspectConfigProduct GetModel(string productId)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 ProductId,ProductName,Model,InspectMethod,InspectType,LabelName,ThreeDimensionalConfig,ExfoConfig,LabelContentConfig,Id_Key from tb_InspectConfigProduct ");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId",SqlDbType.NVarChar,50)
			};
			parameters[0].Value = productId;

			Maticsoft.Model.InspectConfigProduct model = new Maticsoft.Model.InspectConfigProduct();
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
		public Maticsoft.Model.InspectConfigProduct DataRowToModel(DataRow row)
		{
			Maticsoft.Model.InspectConfigProduct model = new Maticsoft.Model.InspectConfigProduct();
			if (row != null)
			{
				if (row["ProductId"] != null)
				{
					model.ProductId = row["ProductId"].ToString();
				}
				if (row["ProductName"] != null)
				{
					model.ProductName = row["ProductName"].ToString();
				}
				if (row["Model"] != null)
				{
					model.Model = row["Model"].ToString();
				}
				if (row["InspectMethod"] != null)
				{
					model.InspectMethod = row["InspectMethod"].ToString();
				}
				if (row["InspectType"] != null)
				{
					model.InspectType = row["InspectType"].ToString();
				}
				if (row["LabelName"] != null)
				{
					model.LabelName = row["LabelName"].ToString();
				}
				if (row["ThreeDimensionalConfig"] != null)
				{
					model.ThreeDimensionalConfig = row["ThreeDimensionalConfig"].ToString();
				}
				if (row["ExfoConfig"] != null)
				{
					model.ExfoConfig = row["ExfoConfig"].ToString();
				}
				if (row["LabelContentConfig"] != null)
				{
					model.LabelContentConfig = row["LabelContentConfig"].ToString();
				}
				if (row["Id_Key"] != null && row["Id_Key"].ToString() != "")
				{
					model.Id_Key = decimal.Parse(row["Id_Key"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ProductId,ProductName,Model,InspectMethod,InspectType,LabelName,ThreeDimensionalConfig,ExfoConfig,LabelContentConfig,Id_Key ");
			strSql.Append(" FROM tb_InspectConfigProduct ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return dbs.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" ProductId,ProductName,Model,InspectMethod,InspectType,LabelName,ThreeDimensionalConfig,ExfoConfig,LabelContentConfig,Id_Key ");
			strSql.Append(" FROM tb_InspectConfigProduct ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return dbs.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM tb_InspectConfigProduct ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
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
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.Id_Key desc");
			}
			strSql.Append(")AS Row, T.*  from tb_InspectConfigProduct T ");
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
			parameters[0].Value = "tb_InspectConfigProduct";
			parameters[1].Value = "Id_Key";
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

