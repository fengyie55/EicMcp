/* MaterialInfo.cs
*
* 功 能： N/A
* 类 名： MaterialInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:49   N/A    初版  
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
    /// 数据访问类:MaterialInfo
    /// </summary>
    public partial class MaterialInfo
    {
        public MaterialInfo()
        { }
        #region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string MaterialID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_MaterialInfo");
            strSql.Append(" where MaterialID=@MaterialID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30)			};
            parameters[0].Value = MaterialID;

            return dbs.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.MaterialInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_MaterialInfo(");
            strSql.Append("MaterialID,AliasName,ProductName,Model,MaterialPhoto,Type,Unit)");
            strSql.Append(" values (");
            strSql.Append("@MaterialID,@AliasName,@ProductName,@Model,@MaterialPhoto,@Type,@Unit)");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30),
					new SqlParameter("@AliasName", SqlDbType.VarChar,20),
					new SqlParameter("@ProductName", SqlDbType.VarChar,30),
					new SqlParameter("@Model", SqlDbType.VarChar,50),
					new SqlParameter("@MaterialPhoto", SqlDbType.Image),
					new SqlParameter("@Type", SqlDbType.VarChar,20),
					new SqlParameter("@Unit", SqlDbType.VarChar,20)};
            parameters[0].Value = model.MaterialID;
            parameters[1].Value = model.AliasName;
            parameters[2].Value = model.ProductName;
            parameters[3].Value = model.Model;
            parameters[4].Value = model.MaterialPhoto;
            parameters[5].Value = model.Type;
            parameters[6].Value = model.Unit;

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
        /// 增加一条数据
        /// </summary>
        public bool Add(DataRow dr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tb_MaterialInfo(");
            strSql.Append("MaterialID,AliasName,ProductName,Model,MaterialPhoto,Type,Unit)");
            strSql.Append(" values (");
            strSql.Append("@MaterialID,@AliasName,@ProductName,@Model,@MaterialPhoto,@Type,@Unit)");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30),
					new SqlParameter("@AliasName", SqlDbType.VarChar,20),
					new SqlParameter("@ProductName", SqlDbType.VarChar,30),
					new SqlParameter("@Model", SqlDbType.VarChar,50),
					new SqlParameter("@MaterialPhoto", SqlDbType.Image),
					new SqlParameter("@Type", SqlDbType.VarChar,20),
					new SqlParameter("@Unit", SqlDbType.VarChar,20)};
            parameters[0].Value = dr["材料品号"].ToString().Trim();
            parameters[1].Value = null;
            parameters[2].Value = dr["品名"].ToString();
            parameters[3].Value = dr["规格"].ToString();
            parameters[4].Value = null;
            parameters[5].Value = "生产料件";
            parameters[6].Value = dr["单位"].ToString();

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.MaterialInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_MaterialInfo set ");
            strSql.Append("AliasName=@AliasName,");
            strSql.Append("ProductName=@ProductName,");
            strSql.Append("Model=@Model,");
            strSql.Append("MaterialPhoto=@MaterialPhoto,");
            strSql.Append("Type=@Type,");
            strSql.Append("Unit=@Unit");
            strSql.Append(" where MaterialID=@MaterialID ");
            SqlParameter[] parameters = {
					new SqlParameter("@AliasName", SqlDbType.VarChar,20),
					new SqlParameter("@ProductName", SqlDbType.VarChar,30),
					new SqlParameter("@Model", SqlDbType.VarChar,50),
					new SqlParameter("@MaterialPhoto", SqlDbType.Image),
					new SqlParameter("@Type", SqlDbType.VarChar,20),
					new SqlParameter("@Unit", SqlDbType.VarChar,20),
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30)};
            parameters[0].Value = model.AliasName;
            parameters[1].Value = model.ProductName;
            parameters[2].Value = model.Model;
            parameters[3].Value = model.MaterialPhoto;
            parameters[4].Value = model.Type;
            parameters[5].Value = model.Unit;
            parameters[6].Value = model.MaterialID;

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
        public bool Delete(string MaterialID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_MaterialInfo ");
            strSql.Append(" where MaterialID=@MaterialID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30)			};
            parameters[0].Value = MaterialID;

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
        public bool DeleteList(string MaterialIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from tb_MaterialInfo ");
            strSql.Append(" where MaterialID in (" + MaterialIDlist + ")  ");
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
        public Maticsoft.Model.MaterialInfo GetModel(string MaterialID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MaterialID,AliasName,ProductName,Model,MaterialPhoto,Type,Unit from tb_MaterialInfo ");
            strSql.Append(" where MaterialID=@MaterialID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MaterialID", SqlDbType.VarChar,30)			};
            parameters[0].Value = MaterialID;

            Maticsoft.Model.MaterialInfo model = new Maticsoft.Model.MaterialInfo();
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
        public Maticsoft.Model.MaterialInfo DataRowToModel(DataRow row)
        {
            Maticsoft.Model.MaterialInfo model = new Maticsoft.Model.MaterialInfo();
            if (row != null)
            {
                if (row["MaterialID"] != null)
                {
                    model.MaterialID = row["MaterialID"].ToString();
                }
                if (row["AliasName"] != null)
                {
                    model.AliasName = row["AliasName"].ToString();
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["Model"] != null)
                {
                    model.Model = row["Model"].ToString();
                }
                if (row["MaterialPhoto"] != null && row["MaterialPhoto"].ToString() != "")
                {
                    model.MaterialPhoto = (byte[])row["MaterialPhoto"];
                }
                if (row["Type"] != null)
                {
                    model.Type = row["Type"].ToString();
                }
                if (row["Unit"] != null)
                {
                    model.Unit = row["Unit"].ToString();
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
            strSql.Append("select MaterialID,AliasName,ProductName,Model,MaterialPhoto,Type,Unit ");
            strSql.Append(" FROM tb_MaterialInfo ");
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
            strSql.Append(" MaterialID,AliasName,ProductName,Model,MaterialPhoto,Type,Unit ");
            strSql.Append(" FROM tb_MaterialInfo ");
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
            strSql.Append("select count(1) FROM tb_MaterialInfo ");
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
                strSql.Append("order by T.MaterialID desc");
            }
            strSql.Append(")AS Row, T.*  from tb_MaterialInfo T ");
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
            parameters[0].Value = "tb_MaterialInfo";
            parameters[1].Value = "MaterialID";
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

