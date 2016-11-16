using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;


namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:WorkOrder
	/// </summary>
	public partial class WorkOrder
	{
		DbHelperSQL dbs = new DbHelperSQL();
		DbHelperSQL ligMat = new DbHelperSQL(Model.E_ConnectionList.LightMaster);
		public WorkOrder()
		{ }

		/// <summary>
		/// 获取工单须发料件
		/// </summary>
		/// <param name="OrderID">512-1311001</param>
		/// <returns></returns>
		public DataSet GetOrderMaterial(string OrderID)
		{
			string _orderTyep = OrderID.Substring(0, 3);
			string _orderid = OrderID.Substring(4, 7);
			return ligMat.Query("select TB003 AS 材料品号,TB012 as 品名,TB013 as 规格,TB007 as 单位,TB004 as 需领用量 from MOCTB where TB001='" + _orderTyep + "' and TB002='" + _orderid + "' and TB012<>'PE袋' and TB012 not like '隔板%' and TB012 not like '纸箱%'");
		}



		/// <summary>
		/// 获取工单信息
		/// </summary>
		/// <param name="OrderID">512-1311001</param>
		/// <returns></returns>
		public DataSet GetOrderInfo(string OrderID)
		{
			if (OrderID.Length >= 11)
			{
				string _orderTyep = OrderID.Substring(0, 3);
				string _orderid = OrderID.Substring(4, 7);
				return ligMat.Query("select TA001,TA002,TA006 AS 品号,TA028,TA034 AS 品名,TA035 AS 规格,TA015 AS 批量,TA026,TA009 AS 开工日期,TA010 AS 完工日期,TA029,TA026,TA027 from MOCTA where TA001='" + _orderTyep + "' and TA002='" + _orderid + "'");
			}
			else return null;
			
		}


		/// <summary>
		/// 获取产品品号
		/// </summary>
		/// <param name="orderId"></param>
		/// <returns></returns>
		public string GetProductId(string orderId)
		{
			DataSet _OrderInfo = GetOrderInfo(orderId);
			if (_OrderInfo == null || _OrderInfo.Tables[0].Rows.Count < 1)
				return string.Empty;                 //工单是否存在
			var productId = _OrderInfo.Tables[0].Rows[0]["品号"].ToString();
			return productId.Length > 0 ? productId : string.Empty;
		}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.WorkOrder model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into tb_WorkOrder(");
			strSql.Append("OrderID,Client,ProductName,Model,Count,InspectMethod,InspectType,DeliveryDate,LabelType,ModelNo,CableCordage,NexansSap,Length,DataT,Qty,Workshop,State)");
			strSql.Append(" values (");
			strSql.Append("@OrderID,@Client,@ProductName,@Model,@Count,@InspectMethod,@InspectType,@DeliveryDate,@LabelType,@ModelNo,@CableCordage,@NexansSap,@Length,@DataT,@Qty,@Workshop,@State)");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@Client", SqlDbType.VarChar,50),
					new SqlParameter("@ProductName", SqlDbType.VarChar,255),
					new SqlParameter("@Model", SqlDbType.VarChar,100),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@InspectMethod", SqlDbType.VarChar,50),
					new SqlParameter("@InspectType", SqlDbType.VarChar,50),
					new SqlParameter("@DeliveryDate", SqlDbType.VarChar,50),
					new SqlParameter("@LabelType", SqlDbType.VarChar,50),
					new SqlParameter("@ModelNo", SqlDbType.VarChar,50),
					new SqlParameter("@CableCordage", SqlDbType.VarChar,50),
					new SqlParameter("@NexansSap", SqlDbType.VarChar,50),
					new SqlParameter("@Length", SqlDbType.VarChar,50),
					new SqlParameter("@DataT", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.VarChar,50),
					new SqlParameter("@Workshop", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.VarChar,50)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.Client;
			parameters[2].Value = model.ProductName;
			parameters[3].Value = model.Model;
			parameters[4].Value = model.Count;
			parameters[5].Value = model.InspectMethod;
			parameters[6].Value = model.InspectType;
			parameters[7].Value = model.DeliveryDate;
			parameters[8].Value = model.LabelType;
			parameters[9].Value = model.ModelNo;
			parameters[10].Value = model.CableCordage;
			parameters[11].Value = model.NexansSap;
			parameters[12].Value = model.Length;
			parameters[13].Value = model.DataT;
			parameters[14].Value = model.Qty;
			parameters[15].Value = model.Workshop;
			parameters[16].Value = model.State;

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
		public bool Update(Maticsoft.Model.WorkOrder model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update tb_WorkOrder set ");
			strSql.Append("OrderID=@OrderID,");
			strSql.Append("Client=@Client,");
			strSql.Append("ProductName=@ProductName,");
			strSql.Append("Model=@Model,");
			strSql.Append("Count=@Count,");
			strSql.Append("InspectMethod=@InspectMethod,");
			strSql.Append("InspectType=@InspectType,");
			strSql.Append("DeliveryDate=@DeliveryDate,");
			strSql.Append("LabelType=@LabelType,");
			strSql.Append("ModelNo=@ModelNo,");
			strSql.Append("CableCordage=@CableCordage,");
			strSql.Append("NexansSap=@NexansSap,");
			strSql.Append("Length=@Length,");
			strSql.Append("DataT=@DataT,");
			strSql.Append("Qty=@Qty,");
			strSql.Append("Workshop=@Workshop,");
			strSql.Append("State=@State");
			strSql.Append(" where ID_Key=@ID_Key ");
			SqlParameter[] parameters = {
					new SqlParameter("@OrderID", SqlDbType.VarChar,50),
					new SqlParameter("@Client", SqlDbType.VarChar,50),
					new SqlParameter("@ProductName", SqlDbType.VarChar,255),
					new SqlParameter("@Model", SqlDbType.VarChar,100),
					new SqlParameter("@Count", SqlDbType.VarChar,50),
					new SqlParameter("@InspectMethod", SqlDbType.VarChar,50),
					new SqlParameter("@InspectType", SqlDbType.VarChar,50),
					new SqlParameter("@DeliveryDate", SqlDbType.VarChar,50),
					new SqlParameter("@LabelType", SqlDbType.VarChar,50),
					new SqlParameter("@ModelNo", SqlDbType.VarChar,100),
					new SqlParameter("@CableCordage", SqlDbType.VarChar,50),
					new SqlParameter("@NexansSap", SqlDbType.VarChar,50),
					new SqlParameter("@Length", SqlDbType.VarChar,50),
					new SqlParameter("@DataT", SqlDbType.VarChar,50),
					new SqlParameter("@Qty", SqlDbType.VarChar,50),
					new SqlParameter("@Workshop", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.VarChar,50),
										new SqlParameter("@ID_Key", SqlDbType.Decimal,9)};
			parameters[0].Value = model.OrderID;
			parameters[1].Value = model.Client;
			parameters[2].Value = model.ProductName;
			parameters[3].Value = model.Model;
			parameters[4].Value = model.Count;
			parameters[5].Value = model.InspectMethod;
			parameters[6].Value = model.InspectType;
			parameters[7].Value = model.DeliveryDate;
			parameters[8].Value = model.LabelType;
			parameters[9].Value = model.ModelNo;
			parameters[10].Value = model.CableCordage;
			parameters[11].Value = model.NexansSap;
			parameters[12].Value = model.Length;
			parameters[13].Value = model.DataT;
			parameters[14].Value = model.Qty;
			parameters[15].Value = model.Workshop;
			parameters[16].Value = model.State;
			parameters[17].Value = model.ID_Key;

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
		/// 删除一条记录
		/// </summary>
		/// <param name="_OrderID">工单单号</param>
		/// <returns></returns>
		public bool Delete(string _OrderID)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from tb_WorkOrder ");
			strSql.Append(" where OrderID ='" + _OrderID + "'");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		/// <param name="_orderID">工单单号</param>
		/// <returns></returns>
		public Maticsoft.Model.WorkOrder GetModel(string _orderID)
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 OrderID,Client,ProductName,Model,Count,InspectMethod,InspectType,DeliveryDate,LabelType,ModelNo,CableCordage,NexansSap,Length,DataT,Qty,Workshop,State,ID_Key from tb_WorkOrder ");
			strSql.Append(" where OrderID ='" + _orderID + "' ");
			SqlParameter[] parameters = {
			};

			Maticsoft.Model.WorkOrder model = new Maticsoft.Model.WorkOrder();
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
		public Maticsoft.Model.WorkOrder DataRowToModel(DataRow row)
		{
			Maticsoft.Model.WorkOrder model = new Maticsoft.Model.WorkOrder();
			if (row != null)
			{
				if (row["OrderID"] != null)
				{
					model.OrderID = row["OrderID"].ToString();
				}
				if (row["Client"] != null)
				{
					model.Client = row["Client"].ToString();
				}
				if (row["ProductName"] != null)
				{
					model.ProductName = row["ProductName"].ToString();
				}
				if (row["Model"] != null)
				{
					model.Model = row["Model"].ToString();
				}
				if (row["Count"] != null)
				{
					model.Count = row["Count"].ToString();
				}


				//检测方法
				if (row["InspectMethod"] != null)
				{
					string _temInspectMethod = row["InspectMethod"].ToString();
					model.InspectMethod = (Maticsoft.Model.E_InspectMethod)Enum.Parse(typeof(Maticsoft.Model.E_InspectMethod),
				   _temInspectMethod, false);
				}
				if (row["InspectType"] != null)
				{
					string _temInspectType = row["InspectType"].ToString();
					model.InspectType = (Maticsoft.Model.E_InspectType)Enum.Parse(typeof(Maticsoft.Model.E_InspectType), _temInspectType, false);

				}
				if (row["DeliveryDate"] != null)
				{
					model.DeliveryDate = row["DeliveryDate"].ToString();
				}
				if (row["LabelType"] != null)
				{
					model.LabelType = row["LabelType"].ToString();
				}
				if (row["ModelNo"] != null)
				{
					model.ModelNo = row["ModelNo"].ToString();
				}
				if (row["CableCordage"] != null)
				{
					model.CableCordage = row["CableCordage"].ToString();
				}
				if (row["NexansSap"] != null)
				{
					model.NexansSap = row["NexansSap"].ToString();
				}
				if (row["Length"] != null)
				{
					model.Length = row["Length"].ToString();
				}
				if (row["DataT"] != null)
				{
					model.DataT = row["DataT"].ToString();
				}
				if (row["Qty"] != null)
				{
					model.Qty = row["Qty"].ToString();
				}
				if (row["Workshop"] != null)
				{
					model.Workshop = row["Workshop"].ToString();
				}
				if (row["State"] != null)
				{
					model.State = row["State"].ToString();
				}

				if (row["ID_Key"] != null && row["ID_Key"].ToString() != "")
				{
					model.ID_Key = decimal.Parse(row["ID_Key"].ToString());
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
			strSql.Append("select OrderID,Client,ProductName,Model,Count,InspectMethod,InspectType,DeliveryDate,LabelType,ModelNo,CableCordage,NexansSap,Length,DataT,Qty,Workshop,State,ID_Key ");
			strSql.Append(" FROM tb_WorkOrder ");
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
			strSql.Append(" OrderID,Client,ProductName,Model,Count,InspectMethod,InspectType,DeliveryDate,LabelType,ModelNo,CableCordage,NexansSap,Length,DataT,Qty,Workshop,State,ID_Key ");
			strSql.Append(" FROM tb_WorkOrder ");
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
			strSql.Append("select count(1) FROM tb_WorkOrder ");
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
		/// 获取工单的总批量
		/// </summary>
		/// <param name="_OrderList"></param>
		/// <returns></returns>
		public double GetOrderListCount(string[] _OrderList)
		{
			int temRecord = 0;
			string strWhere = "";
			if (_OrderList.Length > 0)
			{
				foreach (string _order in _OrderList)
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
				strSql.Append("order by T.ID_Key desc");
			}
			strSql.Append(")AS Row, T.*  from tb_WorkOrder T ");
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
			parameters[0].Value = "tb_WorkOrder";
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

