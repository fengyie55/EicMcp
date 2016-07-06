using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MCP_DBUitility;
using Maticsoft.Model;
using System.Collections;
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:SerialNumber
	/// </summary>
	public partial class SerialNumber
	{
		public SerialNumber()
		{}
		#region  BasicMethod
        DbHelperSQL dbs = new DbHelperSQL();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists_Where(string strsql)
		{
            string strSql = "SELECT COUNT(1)  from tb_SerialNumber where " + strsql;
            bool   t  = dbs.Exists(strSql);
            return t;
		}

        /// <summary>
        /// 返回编码列表
        /// </summary>
        /// <param name="OrderID">工单单号</param>
        /// <returns></returns>
        public ArrayList Get_SN_List(string _orderid,Maticsoft.Model.E_SerialNumber_Type _type)
        {
            string strSql = "SELECT SN  FROM tb_SerialNumber  WHERE (OrderID = '" + _orderid + "') AND (Type = '" + _type + "') ";
            DataSet ds = dbs.Query(strSql);
            ArrayList temList = new ArrayList();
            foreach (DataRow dt in ds.Tables[0].Rows)
            {
                temList.Add(dt["SN"].ToString());                    
            }
            return temList;
        }
       
        /// <summary>
        /// 获取待包装最小SN编码
        /// </summary>
        /// <param name="_OrderID">工单单号</param>
        /// <param name="_Type">条码类型</param>
        /// <returns>最小SN</returns>
        public string  Get_MinSN(string _OrderID,Model.E_SerialNumber_Type _Type)
        {
            string strSql = "SELECT Min(SN) AS SN FROM tb_SerialNumber WHERE State ='Not_Pack' AND (OrderID = '" + _OrderID + "') AND (Type = '" + _Type + "') ";
            DataSet ds = dbs.Query(strSql);
            return ds.Tables[0].Rows[0]["SN"].ToString();
        }

        /// <summary>
        /// 获取待包装最小SN编码
        /// </summary>
        /// <param name="_OrderID">工单单号</param>
        /// <param name="_Type">条码类型</param>
        /// <returns>最小SN</returns>
        public string Get_MinSN(string _OrderID, Model.E_SerialNumber_Type _Type,string _FourCore)
        {
            string strSql = "SELECT Min(SN) AS SN FROM tb_SerialNumber WHERE State ='Not_Pack' AND (OrderID = '" + _OrderID + "') AND (Type = '" + _Type + "') ";
            DataSet ds = dbs.Query(strSql);
            return ds.Tables[0].Rows[0]["SN"].ToString();
        }
        /// <summary>
        /// 返回编码列表
        /// </summary>
        /// <param name="_orderid">工单单号</param>
        /// <param name="_type">条码类型</param>
        /// <param name="_Barcode_State">条码状态</param>
        /// <returns></returns>
        public ArrayList Get_SN_List(string _orderid, Maticsoft.Model.E_SerialNumber_Type _type,Maticsoft.Model.E_Barcode_State _Barcode_State)
        {
            string strSql = "SELECT SN  FROM tb_SerialNumber  WHERE (OrderID = '" + _orderid + "') AND (Type = '" + _type + "') AND (State = '" + _Barcode_State + "')";
            DataSet ds = dbs.Query(strSql);
            ArrayList temList = new ArrayList();
            foreach (DataRow dt in ds.Tables[0].Rows)
            {
                temList.Add(dt["SN"].ToString());
            }
            return temList;
        }

        /// <summary>
        /// 返回编码列表
        /// </summary>
        /// <param name="_orderid">工单单号</param>
        /// <param name="_type">条码类型</param>
        /// <param name="_Barcode_State">条码状态</param>
        /// <returns></returns>
        public ArrayList Get_SN_List(Maticsoft.Model.PackBatch _PackBatch, Maticsoft.Model.E_SerialNumber_Type _type, Maticsoft.Model.E_Barcode_State _Barcode_State)
        {
            string strSql = "SELECT SN  FROM tb_SerialNumber  WHERE (BatchNo = '" + _PackBatch.BatchNo + "') AND (Type = '" + _type + "') AND (State = '" + _Barcode_State + "')";
            DataSet ds = dbs.Query(strSql);
            ArrayList temList = new ArrayList();
            foreach (DataRow dt in ds.Tables[0].Rows)
            {
                temList.Add(dt["SN"].ToString());
            }
            return temList;
        }
        

        /// <summary>
        /// 返回条码列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public ArrayList Get_SN_List(string strWhere)
        {
            ArrayList temList = new ArrayList();
            string strSql = "SELECT SN  FROM tb_SerialNumber ";
            if (strWhere != "")
            {
                strSql += " WHERE " + strWhere;
                DataSet ds = dbs.Query(strSql);
                foreach (DataRow dt in ds.Tables[0].Rows)
                {
                    temList.Add(dt["SN"].ToString());
                }
            }
            return temList;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        /// <param name="strSql">查询条件</param>
        /// <returns></returns>
        public int Get_PackCount_Batch(string strsql)
        {
            string strSql = "SELECT COUNT(DISTINCT SN) AS Count from tb_SerialNumber where   " + strsql;
            return int.Parse( dbs.Query(strSql).Tables[0].Rows[0]["Count"].ToString());

        }

        /// <summary>
        /// 是否存在 介于最小值与最大值之间的记录
        /// </summary>
        /// <param name="_statrSN">起始编码</param>
        /// <param name="_endSN">结束编码</param>
        /// <returns></returns>
        public bool Exists(string _statrSN, string _endSN ,Model.E_SerialNumber_Type Type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from tb_SerialNumber");
            strSql.Append(" where Type=@Type AND SN>=@_statrSN AND SN<=@_endSN");
            SqlParameter[] parameters = {
                    new SqlParameter("@_statrSN", SqlDbType.VarChar,20),
					new SqlParameter("@_endSN", SqlDbType.VarChar,20),
                    new SqlParameter("@Type", SqlDbType.VarChar,20)};
            parameters[0].Value = _statrSN;
            parameters[1].Value = _endSN;
            parameters[2].Value = Type;

            return dbs.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.SerialNumber model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_SerialNumber(");
			strSql.Append("SN,Type,State,BatchNO,OrderID)");
			strSql.Append(" values (");
			strSql.Append("@SN,@Type,@State,@BatchNO,@OrderID)");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,20),
					new SqlParameter("@Type", SqlDbType.VarChar,20),
					new SqlParameter("@State", SqlDbType.VarChar,20),
					new SqlParameter("@BatchNO", SqlDbType.VarChar,20),
					new SqlParameter("@OrderID", SqlDbType.VarChar,20)};
					
			parameters[0].Value = model.SN;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.State;
			parameters[3].Value = model.BatchNO;
			parameters[4].Value = model.OrderID;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.SerialNumber model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_SerialNumber set ");
			strSql.Append("Type=@Type,");
			strSql.Append("State=@State,");
			strSql.Append("BatchNO=@BatchNO,");
			strSql.Append("OrderID=@OrderID");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@Type", SqlDbType.VarChar,20),
					new SqlParameter("@State", SqlDbType.VarChar,20),
					new SqlParameter("@BatchNO", SqlDbType.VarChar,20),
					new SqlParameter("@OrderID", SqlDbType.VarChar,20),
					new SqlParameter("@SN", SqlDbType.VarChar,20)};
			parameters[0].Value = model.Type;
			parameters[1].Value = model.State;
			parameters[2].Value = model.BatchNO;
			parameters[3].Value = model.OrderID;
			parameters[4].Value = model.SN;

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
		public bool Delete(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_SerialNumber ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,20)			};
			parameters[0].Value = SN;

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
		public bool DeleteList(string sqlWhere )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_SerialNumber ");
			strSql.Append(" where "+sqlWhere + "  ");
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
		public Maticsoft.Model.SerialNumber GetModel(string SN)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SN,Type,State,BatchNO,OrderID  from tb_SerialNumber ");
			strSql.Append(" where SN=@SN ");
			SqlParameter[] parameters = {
					new SqlParameter("@SN", SqlDbType.VarChar,20)			};
			parameters[0].Value = SN;

			Maticsoft.Model.SerialNumber model=new Maticsoft.Model.SerialNumber();
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
		public Maticsoft.Model.SerialNumber DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SerialNumber model=new Maticsoft.Model.SerialNumber();
			if (row != null)
			{
				if(row["SN"]!=null)
				{
					model.SN=row["SN"].ToString();
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["BatchNO"]!=null)
				{
					model.BatchNO=row["BatchNO"].ToString();
				}
				if(row["OrderID"]!=null)
				{
					model.OrderID=row["OrderID"].ToString();
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
			strSql.Append("select SN,Type,State,BatchNO,OrderID,ID_Key ");
			strSql.Append(" FROM tb_SerialNumber ");
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
			strSql.Append(" SN,Type,State,BatchNO,OrderID,ID_Key ");
			strSql.Append(" FROM tb_SerialNumber ");
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
			strSql.Append("select count(1) FROM tb_SerialNumber ");
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
				strSql.Append("order by T.SN desc");
			}
			strSql.Append(")AS Row, T.*  from tb_SerialNumber T ");
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
			parameters[0].Value = "tb_SerialNumber";
			parameters[1].Value = "SN";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        public string serialNumber_Value(Model.E_InspectMethod _InspectMethod, Model.SerialNumber _serialNumber, long _StartSN, int OrderCount)
        {

            switch (_InspectMethod)
            {
                case E_InspectMethod.一码一签: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.一码一签_跳线: { return add1(_serialNumber, _StartSN, OrderCount); }
               // case E_InspectMethod.两码一签: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.两码两签: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.双并检测: { return add1(_serialNumber, _StartSN, OrderCount); }

                case E_InspectMethod.FFOS_四芯: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.FFOS_八芯: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.FFOS_十六芯: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.FFOS_二十四芯: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.FFOS_三十二芯: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.FFOS32_三十二芯双头: { return add1(_serialNumber, _StartSN, OrderCount); }

                case E_InspectMethod.四芯检测: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.十二芯检测: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.八芯检测: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.TFK十二芯检测x2: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.TFK二十四芯检测x2: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.二十四芯检测: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.四十八芯检测: { return add1(_serialNumber, _StartSN, OrderCount); }
                case E_InspectMethod.MPO检测: { return add1(_serialNumber, _StartSN, OrderCount); }

               // case E_InspectMethod.配组_八芯:     { return add2(_serialNumber, _StartSN, _EndSN, 12); }     //配组
                case E_InspectMethod.配组_二十四芯: { return add2(_serialNumber, _StartSN, OrderCount, 3); }       //配组
                case E_InspectMethod.配组_四十八芯: { return add2(_serialNumber, _StartSN, OrderCount, 6); }       //配组
                case E_InspectMethod.配组_九十六芯: { return add2(_serialNumber, _StartSN, OrderCount, 12); }       //配组

                default:
                    {
                        return "未找到任何与已知检测方法匹配的项，\r\n由此引出的错误可能为检测方法设置不正确！\r\n请重试或联系管理员！";
                    }
            }
        }

        //一码一签 Pigtail类型
        private string add1(Model.SerialNumber serialNumber, long StartSN, int OrderCount)
        {
            string Pigtail_Info = "";
            int _Pass = 0, _Fill = 0;                                      //记录添加成功与添加失败的数量
            serialNumber.Type = E_SerialNumber_Type.ClientSN.ToString();   //条码类型  
            serialNumber.State = E_Barcode_State.Not_Pack.ToString();      //条码状态

            long endSn = StartSN + (OrderCount-1);
            //判断编码是否有重复的
            if (Exists(StartSN.ToString(), endSn.ToString(), Model.E_SerialNumber_Type.ClientSN))
            {
                Pigtail_Info = "Pigtail编码保存失败：现有编码与数据库中的编码有重复！";
            }
            else
            {
                for (long t = StartSN; t <= endSn; t++)
                {
                    serialNumber.SN = t.ToString();                            //SN 赋值            

                    if (Add(serialNumber)) { _Pass++; } else { _Fill++; }      //如果添加成功！_pass记录加1，否则_fill加1
                }
                Pigtail_Info = "操作完成！成功添加：" + _Pass + "条\r\n失败：" + _Fill + "条";
            }
            return Pigtail_Info;
        }

        //配组ClientSN 编码与 Pigtail编码
        private string add2(Model.SerialNumber serialNumber, long StartSN, int OrderCount, int PigtailCount)
        {
            int _Pass = 0, _Fill = 0;                                      //记录添加成功与添加失败的数量
            serialNumber.Type = E_SerialNumber_Type.ClientSN.ToString();   //条码类型  
            serialNumber.State = E_Barcode_State.Not_Pack.ToString();      //条码状态
            string ClinentSN_Info = "", Pigtail_Info = "";

            long _Endsn = StartSN + (OrderCount-1);
            /**********赋值 ClientSn  *********/
            //判断编码是否有重复的
            if (Exists(StartSN.ToString(), _Endsn.ToString(), E_SerialNumber_Type.ClientSN))
            {
                Pigtail_Info = "客户编码保存失败：现有编码与数据库中的编码有重复！";
            }
            else
            {
                for (long t = StartSN; t <= _Endsn; t++)
                {
                    serialNumber.SN = t.ToString();                            //SN 赋值                           
                    if (Add(serialNumber)) { _Pass++; } else { _Fill++; }      //如果添加成功！_pass记录加1，否则_fill加1             
                    ClinentSN_Info = "操作完成 客户编码——！成功添加：" + _Pass + "条\r\n失败：" + _Fill.ToString() + "条";
                }
            }
           
            /**********赋值 Pigtail  *********/
            serialNumber.Type = E_SerialNumber_Type.PigtailSN.ToString();  //条码类型  
            _Pass = 0;
            _Fill = 0;
            //判断编码是否有重复的
            if (Exists(StartSN.ToString(), _Endsn.ToString(), E_SerialNumber_Type.PigtailSN))
            {
                Pigtail_Info = "Pigtail编码保存失败：现有编码与数据库中的编码有重复！";
            }
            else
            {
                for (int f = 1; f <= PigtailCount ; f++)
                {
                    for (long t = StartSN; t <= _Endsn; t++)
                    {
                        if (f < 10)
                        {
                            serialNumber.SN = t.ToString() + "-0" + f.ToString(); ;  //SN 赋值     
                        }
                        else
                        {
                            serialNumber.SN = t.ToString() + "-" + f.ToString(); ;  //SN 赋值     
                        }
                        if (Add(serialNumber)) { _Pass++; } else { _Fill++; }   //如果添加成功！_pass记录加1，否则_fill加1             
                        Pigtail_Info = "操作完成 Pigtail编码——！成功添加：" + _Pass + "条\r\n失败：" + _Fill.ToString() + "条";
                    }
                }
            }
            return ClinentSN_Info + "\r\n" + Pigtail_Info;

        }
   

        /// <summary>
        /// 生成并保存外袋
        /// </summary>
        /// <returns></returns>
        public string Sack_SerialNumber(string ordrID, string sackQty)
        {
            /***********************************************************
             * 
             * 编码规则为：工单单号+00001
             * 外袋编码Demo ：130000100001
             *                    
             * *********************************************************/

            if (ordrID != "" && sackQty != "")
            {
                WorkOrder wo = new WorkOrder();
                Maticsoft.Model.WorkOrder Tem = wo.GetModel(ordrID);
                int orderCount = 0;
                if (Tem != null)
                {
                    orderCount = int.Parse(Tem.Count);              //总批量
                }
                int _TemSackQty = int.Parse(sackQty);               //单袋数量
                int _TemGenerateCount = orderCount / _TemSackQty;   //需要生成多少个外袋编码           

                long SN = long.Parse(ordrID.Substring(4, 7) + "00000");
                int Add_Yet = 0, Add_Not = 0;                          //记录添加成功的数量
                string message = "";

                //实体类赋值
                Maticsoft.Model.SerialNumber temSerialNumber = new Maticsoft.Model.SerialNumber();
                temSerialNumber.OrderID = ordrID;
                temSerialNumber.Type = Maticsoft.Model.E_SerialNumber_Type.SackSN.ToString();

                if (Exists_Where("(OrderID ='" + temSerialNumber.OrderID + "') AND ( Type ='" + temSerialNumber.Type + "')"))
                {
                    Add_Yet = GetRecordCount("(SN ='" + temSerialNumber.SN + "') AND ( Type ='" + temSerialNumber.OrderID + "')");
                    message = "工单:" + ordrID + "外袋编码已添加！";
                }
                else
                {
                    string tem_ExrrySnList = "";

                    for (int i = 1; i < _TemGenerateCount + 1; i++)
                    {
                        temSerialNumber.SN = (SN + i).ToString();
                        //判断是否重复
                        if (!Exists_Where("(OrderID ='" + temSerialNumber.OrderID + "') AND ( Type ='" + temSerialNumber.Type + "')"))
                        {
                            //判断是否添加成功
                            if (Add(temSerialNumber))
                            {
                                Add_Yet++; //记录添加成功数量
                            }
                            else { Add_Not++; tem_ExrrySnList += "\r\n：" + temSerialNumber.SN + "\r\n"; }
                        }
                        else { tem_ExrrySnList += "\r\n此编码重复：" + temSerialNumber.SN + "\r\n"; }
                    }
                    message = "外袋编码添加\r\n成功：" + Add_Yet + "条\r\n失败：" + Add_Not + "条" + tem_ExrrySnList;
                }
                return message;
            }
            else
            {
                string message = "未添加外袋条码！";
                return message;
            }
            

        }

		#endregion  ExtensionMethod
	}
}

