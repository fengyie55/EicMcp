/* MoveStore_ProductControl.cs
*
* 功 能： N/A
* 类 名： MoveStore_ProductControl
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-11 11:20:22   N/A    初版  
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
	/// 数据访问类:MoveStore_ProductControl
	/// </summary>
	public partial class MoveStore_ProductControl
	{
		public MoveStore_ProductControl()
		{}
		#region  BasicMethod

        DbHelperSQL dbs = new DbHelperSQL();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal MS_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_MoveStore_ProductControl");
			strSql.Append(" where MS_ID=@MS_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MS_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = MS_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 获取工单中指定状态的数量
        /// </summary>
        /// <param name="whereOrderList">工单单号列表</param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public double GetView_Ord_StateCount(string whereOrderList, string strWhere)
        {
            string strSql = "SELECT tb_Workstation_1.Workstation AS SendWK, tb_StateList_1.State AS SendState,  ";
            strSql += "      SUM(CONVERT(int, tb_MoveStore_ProductControl.Count)) AS Count, ";
            strSql += " tb_Workstation.Workstation, tb_StateList.State ";
            strSql += "  FROM tb_MoveStore_ProductControl INNER JOIN  ";
            strSql += "    tb_StateList ON  ";
            strSql += " tb_MoveStore_ProductControl.Receive_State = tb_StateList.Ste_ID INNER JOIN  ";
            strSql += "  tb_Workstation ON tb_StateList.Wk_ID = tb_Workstation.Wo_ID INNER JOIN   ";
            strSql += "  tb_StateList AS tb_StateList_1 ON   ";
            strSql += "    tb_MoveStore_ProductControl.Send_State = tb_StateList_1.Ste_ID INNER JOIN  ";
            strSql += "   tb_Workstation AS tb_Workstation_1 ON  ";
            strSql += "   tb_StateList_1.Wk_ID = tb_Workstation_1.Wo_ID  ";
            strSql += " WHERE (tb_MoveStore_ProductControl.Ord_ID IN ("+whereOrderList+")) ";
            strSql += " GROUP BY tb_Workstation.Workstation, tb_StateList.State, tb_StateList_1.State,   ";
            strSql += " tb_Workstation_1.Workstation  ";
            strSql += " ORDER BY SendState  ";

            if (strWhere.Trim() != "")
            {
                strSql += (" HAVING " + strWhere);
            }
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string temCount = ds.Tables[0].Rows[0]["Count"].ToString();
                double tem = 0;
                double.TryParse(temCount, out tem);
                return tem;
            }
            else { return 0; }           
        }

        /// <summary>
        /// 获取个状态数量
        /// </summary>
        /// <param name="strWhere"> 可以查询各站 及 各状态 (tb_StateList.State = '待研磨') AND (tb_Workstation.Workstation = '南_第一站') </param>
        /// <returns></returns>
        public double GetView_StateCount(string _Ord_ID , string strWhere)
        {
            string strSql = "SELECT tb_Workstation.Workstation, tb_StateList.State, SUM(CONVERT(int,  ";
            strSql += "      tb_MoveStore_ProductControl.Count)) AS Count ";
            strSql += "FROM tb_MoveStore_ProductControl INNER JOIN ";
            strSql += "      tb_StateList ON  ";
            strSql += "      tb_MoveStore_ProductControl.Receive_State = tb_StateList.Ste_ID INNER JOIN ";
            strSql += "      tb_Workstation ON tb_StateList.Wk_ID = tb_Workstation.Wo_ID ";
            strSql += "WHERE (tb_MoveStore_ProductControl.Ord_ID = '"+_Ord_ID+"') ";
            strSql += "GROUP BY tb_Workstation.Workstation, tb_StateList.State ";            
            if (strWhere.Trim() != "")
            {
                strSql += (" HAVING " + strWhere);
            }
           DataSet ds  =  dbs.Query(strSql.ToString());
           if (ds.Tables[0].Rows.Count > 0)
           {
               string temCount = ds.Tables[0].Rows[0]["Count"].ToString();
               double tem = 0;
               double.TryParse(temCount, out tem);
               return tem;
           }
           else { return 0;  }           
        }

        /// <summary>
        /// 获取工单中物料在各站发送与接收的信息
        /// </summary>
        /// <param name="strWhere">工单单号：为IN 格式的查询语句 </param>
        /// <returns></returns>
        public DataSet GetOrderMaterialInfo(string[] OrderList) 
        {
            int temRecord = 0;
            string strWhere = "";
            if (OrderList.Length > 0)
            {
                foreach (string _order in OrderList)
                {
                    if (temRecord == 0) 
                        strWhere += "'" + _order + "'";
                    else
                        strWhere += ",'" + _order + "'";                       
                }
            }
            string strSql = "SELECT tb_StateList_1.State AS SendState, tb_Workstation_1.Workstation AS SendWK,   ";
            strSql += "      tb_StateList.State AS ReceiveState, tb_Workstation.Workstation AS ReceiveWK,  ";
            strSql += " SUM(CONVERT(int, tb_MoveStore_ProductControl.Count)) AS Count ";
            strSql += "     FROM tb_MoveStore_ProductControl INNER JOIN ";
            strSql += "      tb_StateList ON ";
            strSql += "  tb_MoveStore_ProductControl.Receive_State = tb_StateList.Ste_ID INNER JOIN ";
            strSql += " tb_Workstation ON tb_StateList.Wk_ID = tb_Workstation.Wo_ID INNER JOIN  ";
            strSql += " tb_StateList AS tb_StateList_1 ON   ";
            strSql += "   tb_MoveStore_ProductControl.Send_State = tb_StateList_1.Ste_ID INNER JOIN ";
            strSql += " tb_Workstation AS tb_Workstation_1 ON   ";
            strSql += "  tb_StateList_1.Wk_ID = tb_Workstation_1.Wo_ID  ";
            strSql += "  WHERE (tb_MoveStore_ProductControl.Ord_ID IN (" + strWhere + ")) ";
            strSql += "  GROUP BY tb_Workstation.Workstation, tb_StateList.State, tb_StateList_1.State,  ";
            strSql += "    tb_Workstation_1.Workstation ";         
            DataSet ds = dbs.Query(strSql.ToString());
            return ds;
        }

        /// <summary>
        /// 获取工单指定站别的发出数量
        /// </summary>
        /// <param name="OrderList">工单列表</param>
        /// <param name="_WK">站别</param>
        /// <returns></returns>
        public double GetWK_Count_Send(string[] OrderList, string _WK)
        {
            int temRecord = 0;
            string strWhere = "";
            if (OrderList.Length > 0)
            {
                foreach (string _order in OrderList)
                {
                    if (temRecord == 0)
                        strWhere += "'" + _order + "'";
                    else
                        strWhere += ",'" + _order + "'";
                }
            }
            string strSql = " SELECT SUM(CONVERT(int, tb_MoveStore_ProductControl.Count)) AS Count,  ";
            strSql += "       tb_StateList_1.State AS SendState, tb_Workstation_1.Workstation AS SendWK ";
            strSql += " FROM tb_MoveStore_ProductControl INNER JOIN ";
            strSql += "   tb_StateList AS tb_StateList_1 ON ";
            strSql += "  tb_MoveStore_ProductControl.Send_State = tb_StateList_1.Ste_ID INNER JOIN ";
            strSql += " tb_Workstation AS tb_Workstation_1 ON  ";
            strSql += "  tb_StateList_1.Wk_ID = tb_Workstation_1.Wo_ID ";
            strSql += " WHERE (tb_MoveStore_ProductControl.Ord_ID IN (" + strWhere + ")) ";
            strSql += "  GROUP BY tb_StateList_1.State, tb_Workstation_1.Workstation ";
            if (_WK != "")
            {
                strSql += (" HAVING (tb_Workstation_1.Workstation LIKE '%"+_WK+"')");
            }
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string temCount = ds.Tables[0].Rows[0]["Count"].ToString();
                double tem = 0;
                double.TryParse(temCount, out tem);
                return tem;
            }
            else { return 0; }           
        }

        /// <summary>
        /// 获取工单指定站别收到的数量
        /// </summary>
        /// <param name="OrderList">工单列表</param>
        /// <param name="_WK">工作站别</param>
        /// <returns></returns>
        public double GetWK_Count_Receive(string[] OrderList, string _WK)
        {
            int temRecord = 0;
            string strWhere = "";
            if (OrderList.Length > 0)
            {
                foreach (string _order in OrderList)
                {
                    if (temRecord == 0)
                        strWhere += "'" + _order + "'";
                    else
                        strWhere += ",'" + _order + "'";
                }
            }
            string strSql = " SELECT tb_StateList.State AS ReceiveState, tb_Workstation.Workstation AS ReceiveWK,  ";
            strSql += "    SUM(CONVERT(int, tb_MoveStore_ProductControl.Count)) AS Count   ";
            strSql += "    FROM tb_MoveStore_ProductControl INNER JOIN   ";
            strSql += "    tb_StateList ON    ";
            strSql += "    tb_MoveStore_ProductControl.Receive_State = tb_StateList.Ste_ID INNER JOIN   ";
            strSql += "    tb_Workstation ON tb_StateList.Wk_ID = tb_Workstation.Wo_ID  ";
            strSql += "    WHERE (tb_MoveStore_ProductControl.Ord_ID IN (" + strWhere + "))  ";
            strSql += "    GROUP BY tb_Workstation.Workstation, tb_StateList.State   ";         
            if (_WK != "")
            {
                strSql += (" HAVING (tb_Workstation.Workstation LIKE '%" + _WK + "')");
            }
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string temCount = ds.Tables[0].Rows[0]["Count"].ToString();
                double tem = 0;
                double.TryParse(temCount, out tem);
                return tem;
            }
            else { return 0; }        
        }


        /// <summary>
        /// 获取个状态数量
        /// </summary>
        /// <param name="strWhere"> 可以查询各站 及 各状态 (tb_StateList.State = '不良返回') AND (tb_Workstation.Workstation = '南_第三站') </param>
        /// <returns></returns>
        public double GetView_StateCount_Send(string _Ord_ID, string strWhere)
        {
            string strSql = "SELECT tb_Workstation.Workstation, tb_StateList.State, SUM(CONVERT(int,  ";
            strSql += "      tb_MoveStore_ProductControl.Count)) AS Count ";
            strSql += "FROM tb_MoveStore_ProductControl INNER JOIN ";
            strSql += "      tb_StateList ON  ";
            strSql += "      tb_MoveStore_ProductControl.Send_State = tb_StateList.Ste_ID INNER JOIN ";
            strSql += "      tb_Workstation ON tb_StateList.Wk_ID = tb_Workstation.Wo_ID ";
            strSql += "WHERE (tb_MoveStore_ProductControl.Ord_ID = '" + _Ord_ID + "') ";
            strSql += "GROUP BY tb_Workstation.Workstation, tb_StateList.State ";
            if (strWhere.Trim() != "")
            {
                strSql += (" HAVING " + strWhere);
            }
            DataSet ds = dbs.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string temCount = ds.Tables[0].Rows[0]["Count"].ToString();
                double tem = 0;
                double.TryParse(temCount, out tem);
                return tem;
            }
            else { return 0; }
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.MoveStore_ProductControl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_MoveStore_ProductControl(");
			strSql.Append("Send_WK,Send_State,Send_USID,Receive_WK,Receive_State,Receive_USID,Count,Ord_ID,PB_ID,Note,DataTime)");
			strSql.Append(" values (");
			strSql.Append("@Send_WK,@Send_State,@Send_USID,@Receive_WK,@Receive_State,@Receive_USID,@Count,@Ord_ID,@PB_ID,@Note,@DataTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Send_WK", SqlDbType.VarChar,50),
					new SqlParameter("@Send_State", SqlDbType.VarChar,50),
					new SqlParameter("@Send_USID", SqlDbType.VarChar,50),
					new SqlParameter("@Receive_WK", SqlDbType.VarChar,50),
					new SqlParameter("@Receive_State", SqlDbType.VarChar,50),
					new SqlParameter("@Receive_USID", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@Ord_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PB_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Note", SqlDbType.Text),
                    new SqlParameter("@DataTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Send_WK;
			parameters[1].Value = model.Send_State;
			parameters[2].Value = model.Send_USID;
			parameters[3].Value = model.Receive_WK;
			parameters[4].Value = model.Receive_State;
			parameters[5].Value = model.Receive_USID;
			parameters[6].Value = model.Count;
			parameters[7].Value = model.Ord_ID;
			parameters[8].Value = model.PB_ID;
			parameters[9].Value = model.Note;
            parameters[10].Value = model.DataTime;
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
		public bool Update(Maticsoft.Model.MoveStore_ProductControl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_MoveStore_ProductControl set ");
			strSql.Append("Send_WK=@Send_WK,");
			strSql.Append("Send_State=@Send_State,");
			strSql.Append("Send_USID=@Send_USID,");
			strSql.Append("Receive_WK=@Receive_WK,");
			strSql.Append("Receive_State=@Receive_State,");
			strSql.Append("Receive_USID=@Receive_USID,");
			strSql.Append("Count=@Count,");
			strSql.Append("Ord_ID=@Ord_ID,");
			strSql.Append("PB_ID=@PB_ID,");
			strSql.Append("Note=@Note,");
            strSql.Append("DataTime=@DataTime");
			strSql.Append(" where MS_ID=@MS_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Send_WK", SqlDbType.VarChar,50),
					new SqlParameter("@Send_State", SqlDbType.VarChar,50),
					new SqlParameter("@Send_USID", SqlDbType.VarChar,50),
					new SqlParameter("@Receive_WK", SqlDbType.VarChar,50),
					new SqlParameter("@Receive_State", SqlDbType.VarChar,50),
					new SqlParameter("@Receive_USID", SqlDbType.VarChar,50),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@Ord_ID", SqlDbType.VarChar,50),
					new SqlParameter("@PB_ID", SqlDbType.VarChar,50),
					new SqlParameter("@Note", SqlDbType.Text),
					new SqlParameter("@MS_ID", SqlDbType.Decimal,9),
                    new SqlParameter("@DataTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Send_WK;
			parameters[1].Value = model.Send_State;
			parameters[2].Value = model.Send_USID;
			parameters[3].Value = model.Receive_WK;
			parameters[4].Value = model.Receive_State;
			parameters[5].Value = model.Receive_USID;
			parameters[6].Value = model.Count;
			parameters[7].Value = model.Ord_ID;
			parameters[8].Value = model.PB_ID;
			parameters[9].Value = model.Note;
			parameters[10].Value = model.MS_ID;
            parameters[11].Value = model.DataTime;

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
		public bool Delete(decimal MS_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_MoveStore_ProductControl ");
			strSql.Append(" where MS_ID=@MS_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MS_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = MS_ID;

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
		public bool DeleteList(string MS_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_MoveStore_ProductControl ");
			strSql.Append(" where MS_ID in ("+MS_IDlist + ")  ");
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
		public Maticsoft.Model.MoveStore_ProductControl GetModel(decimal MS_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MS_ID,Send_WK,Send_State,Send_USID,Receive_WK,Receive_State,Receive_USID,Count,Ord_ID,PB_ID,Note,DataTime from tb_MoveStore_ProductControl ");
			strSql.Append(" where MS_ID=@MS_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MS_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = MS_ID;

			Maticsoft.Model.MoveStore_ProductControl model=new Maticsoft.Model.MoveStore_ProductControl();
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
		public Maticsoft.Model.MoveStore_ProductControl DataRowToModel(DataRow row)
		{
			Maticsoft.Model.MoveStore_ProductControl model=new Maticsoft.Model.MoveStore_ProductControl();
			if (row != null)
			{
				if(row["MS_ID"]!=null && row["MS_ID"].ToString()!="")
				{
					model.MS_ID=decimal.Parse(row["MS_ID"].ToString());
				}
				if(row["Send_WK"]!=null)
				{
					model.Send_WK=row["Send_WK"].ToString();
				}
				if(row["Send_State"]!=null)
				{
					model.Send_State=row["Send_State"].ToString();
				}
				if(row["Send_USID"]!=null)
				{
					model.Send_USID=row["Send_USID"].ToString();
				}
				if(row["Receive_WK"]!=null)
				{
					model.Receive_WK=row["Receive_WK"].ToString();
				}
				if(row["Receive_State"]!=null)
				{
					model.Receive_State=row["Receive_State"].ToString();
				}
				if(row["Receive_USID"]!=null)
				{
					model.Receive_USID=row["Receive_USID"].ToString();
				}
				if(row["Count"]!=null)
				{
					model.Count=row["Count"].ToString();
				}
				if(row["Ord_ID"]!=null)
				{
					model.Ord_ID=row["Ord_ID"].ToString();
				}
				if(row["PB_ID"]!=null)
				{
					model.PB_ID=row["PB_ID"].ToString();
				}
				if(row["Note"]!=null)
				{
					model.Note=row["Note"].ToString();
				}
                if (row["DataTime"] != null)
                {
                    model.Note = row["DataTime"].ToString();
                }
			}
			return model;
		}


        /// <summary>
        /// 获得总数量
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public int GetSUM_StateCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT SUM(CONVERT(float, Count)) AS Count FROM tb_MoveStore_ProductControl ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dbs.GetSUM_Count(strSql.ToString());
        }



		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MS_ID,Send_WK,Send_State,Send_USID,Receive_WK,Receive_State,Receive_USID,Count,Ord_ID,PB_ID,Note,DataTime ");
			strSql.Append(" FROM tb_MoveStore_ProductControl ");
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
			strSql.Append(" MS_ID,Send_WK,Send_State,Send_USID,Receive_WK,Receive_State,Receive_USID,Count,Ord_ID,PB_ID,Note,DataTime ");
			strSql.Append(" FROM tb_MoveStore_ProductControl ");
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
			strSql.Append("select count(1) FROM tb_MoveStore_ProductControl ");
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
				strSql.Append("order by T.MS_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_MoveStore_ProductControl T ");
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
			parameters[0].Value = "tb_MoveStore_ProductControl";
			parameters[1].Value = "MS_ID";
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

