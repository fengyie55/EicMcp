/**  
* User_3D_Test_Good.cs
*
* 功 能： N/A
* 类 名： User_3D_Test_Good
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-31 11:06:00   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人                    　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Collections;
namespace Maticsoft.BLL
{
	/// <summary>
	/// User_3D_Test_Good
	/// </summary>
	public partial class User_3D_Test_Good
	{
		private readonly Maticsoft.DAL.User_3D_Test_Good dal=new Maticsoft.DAL.User_3D_Test_Good();
		public User_3D_Test_Good()
		{}

        /// <summary>
        /// 获取SPC数据
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public DataSet Get_SPC(string Date,string Type)
        {
            return dal.Get_SPC(Date,Type);
        }


        #region Generate Sql Where 

        //--------------------------------------------------------------------------------------------------------------------------
        //  名称：生成Where语句
        //
        //
        //--------------------------------------------------------------------------------------------------------------------------
      
        /// <summary>
        /// 获取3D WHERE 查询语句
        /// </summary>
        public string GetSql_Where(Maticsoft.Model.WorkOrder _WorkOrder,ArrayList _PigtailList, string SN)
        {
            Maticsoft.BLL.TestStandard_3D _M_TestStandard = new Maticsoft.BLL.TestStandard_3D();      
            //生成SN 的ＩＮ　查询条件
            string TemSNList = "";
            TemSNList = Get_SNList(SN, _PigtailList);
            //   
            ArrayList _testStandard = _M_TestStandard.GetArrayList("(OrderID = '" + _WorkOrder.OrderID + "')");
            string srt_testStadard = Generate_Where(_testStandard);
            //
            if (!srt_testStadard.Equals(""))  //如果不为空
            {
                TemSNList = TemSNList + " AND " + srt_testStadard;
            }
            return "SN IN" + TemSNList;
        }

        /// <summary>
        /// 生产跳线查询语句
        /// </summary>
        /// <param name="_WorkOrder"></param>
        /// <param name="_SNList"></param>
        /// <returns></returns>
        public string GetSql_Where(Maticsoft.Model.WorkOrder _WorkOrder, ArrayList _SNList)
        {
            Maticsoft.BLL.TestStandard_3D _M_TestStandard = new Maticsoft.BLL.TestStandard_3D();      
            //生成SN 的ＩＮ　查询条件
            string TemSNList = "";
            TemSNList = Get_SNList(_SNList);                   
            //   
            ArrayList _testStandard = _M_TestStandard.GetArrayList("(OrderID = '" + _WorkOrder.OrderID + "')");
            string srt_testStadard = Generate_Where(_testStandard);
            //
            if (!srt_testStadard.Equals(""))  //如果不为空
            {
                TemSNList = TemSNList +" AND " +srt_testStadard;
            }
            return "SN IN" + TemSNList;
        }

        /// <summary>
        /// 根据测试标准生成 Where 条件查询语句
        /// </summary>
        private string Generate_Where(ArrayList _standard)
        {
            string sql_1 ="",sql_2="";
            foreach (Maticsoft.Model.TestStandard_3D _tsetStandard in _standard)
            {                            
                if (_tsetStandard != null)
                {
                    if (_tsetStandard.Type == Maticsoft.Model.E_PigtailType.APC.ToString())
                    {
                        sql_1 += " ( (CONVERT(float, Curvature) >= " + _tsetStandard.RCO_Min + ") AND (CONVERT(float,Curvature ) <= " + _tsetStandard.RCO_Max + ") ";
                        sql_1 += " AND (CONVERT(float,Apex_Offset) >= " + _tsetStandard.AO_Min + ") AND (CONVERT(float,Apex_Offset) <= " + _tsetStandard.AO_Max + ")  ";
                        sql_1 += " AND (CONVERT(float,Spherical) >= " + _tsetStandard.FH_Min + ")   AND (CONVERT(float,Spherical) <= " + _tsetStandard.FH_Max + ")  ";
                        sql_1 += " AND (CONVERT(float,(CASE Tilt_Angle WHEN 'P' THEN '0' ELSE Tilt_Angle END)) >= " + _tsetStandard.AE_Min + ")  AND (CONVERT(float,(CASE Tilt_Angle WHEN 'P' THEN '0' ELSE Tilt_Angle END)) <= " + _tsetStandard.AE_Max + ") )";
                    }
                    else  //PC
                    {
                        sql_2 += " ( (CONVERT(float, Curvature) >= " + _tsetStandard.RCO_Min + ") AND (CONVERT(float,Curvature ) <= " + _tsetStandard.RCO_Max + ") ";
                        sql_2 += " AND (CONVERT(float,Apex_Offset) >= " + _tsetStandard.AO_Min + ") AND (CONVERT(float,Apex_Offset) <= " + _tsetStandard.AO_Max + ")  ";
                        sql_2 += " AND (CONVERT(float,Spherical) >= " + _tsetStandard.FH_Min + ")   AND (CONVERT(float,Spherical) <= " + _tsetStandard.FH_Max + ") )  ";                       
                    }
                }                                            
            }
            string tem = "";
            if (sql_1 != "" && sql_2 != "")
            {
                tem = "("+sql_1 + " OR " + sql_2+")" ;
            }
            else if (sql_1 != "")
            {
                tem = sql_1;
            }
            else if (sql_2 != "")
            {
                tem = sql_2;
            }
            return tem;
        }

      
        /// <summary>
        /// 生成IN 查询语句  适用于不带线号的线材
        /// </summary>
        /// <param name="SN">SN</param>
        /// <param name="PigtailList">接头列表</param>
        /// <returns></returns>
        private string Get_SNList(string SN, ArrayList PigtailList)
        {
            string tem = "";
            if (PigtailList.Count > 1)
            {
                tem += "(";
                int temCount = 0;
                foreach (string TemSN in PigtailList)
                {
                    if (temCount == 0) { tem += "'" + SN + "-" + TemSN + "'"; }
                    else
                    {
                        tem += ",'" + SN + "-" + TemSN + "'";
                    }
                    temCount++;
                }
                tem += ")";
            }
            else { tem = "('"+SN+"')"; }
            return tem;
        }

       
        /// <summary>
        /// 生成IN 查询语句  适用于不带线号的线材
        /// </summary>
        /// <param name="SN">SN</param>
        /// <param name="PigtailList">接头列表</param>
        /// <returns></returns>
        private string Get_SNList(ArrayList PigtailList)
        {
            string tem = "";
            if (PigtailList.Count > 0)
            {
                tem += "(";
                int temCount = 0;
                foreach (string TemSN in PigtailList)
                {
                    if (temCount == 0) { tem += "'"+ TemSN + "'"; }
                    else
                    {
                        tem += ",'" + TemSN + "'";
                    }
                    temCount++;
                }
                tem += ")";
            }
        
            return tem;
        }

        #endregion



        #region Get User 3D data

        //--------------------------------------------------------------------------------------------------------------------------
        //   名称：
        //  
        //
        //--------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 双并查询
        /// 适合条码类型 Demo：2130100001-10
        /// Name 处理 10
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_TwainCore(Maticsoft.DAL.My_GetTestData.GetDataEventArgs e)
        {
            dal.Getdata_Method_TwainCore(e);
        }

        /// <summary>
        /// TFK十二芯检测x2
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_twentyFour(Maticsoft.DAL.My_GetTestData.GetDataEventArgs e)
        {
            dal.Getdata_Method_twentyFour(e);
        }
         /// <summary>
        /// 多芯查询 有 IN条件
        /// 适合条码类型 Demo：2130100001-12-8
        /// PigtailNum  = 12
        /// Name = 8
        /// </summary>
        /// <param name="e"></param>
        public void Getdata_Method_Multicore(Maticsoft.DAL.My_GetTestData.GetDataEventArgs e)
        {
            dal.Getdata_Method_Multicore(e);
        }

        /// <summary>
        /// 单芯查询 无 IN条件  
        /// 可用于 单芯 或 配组的8芯查询
        /// </summary>
        /// <param name="e"></param>
        public void GetData_Method_OneCore(Maticsoft.DAL.My_GetTestData.GetDataEventArgs e)
        {
            dal.GetData_Method_OneCore(e);
        }

        // <summary>
        /// 两码两标签 查询方法
        /// </summary>
        /// <param name="e"></param>
        public void GetData_Method_TwoSnToLab(Maticsoft.DAL.My_GetTestData.GetDataEventArgs e)
        {
            dal.GetData_Method_TwoSnToLab(e);
        }

        #endregion


        #region  BasicMethod
       
        /// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.User_3D_Test_Good model)
		{
			return dal.Add(model);
		}

        /// <summary>
        /// 获取SN编码类型
        /// </summary>
        /// <param name="_SqlIN"></param>
        /// <returns></returns>
        public Maticsoft.Model.E_PigtailType Get_PigtailType(string _SqlIN)
        {
            return dal.Get_PigtailType(_SqlIN);
        }

        /// <summary>
        /// 获取线号
        /// </summary>
        /// <param name="_SN">SN</param>
        /// <returns></returns>
        public string Get_PigtailNum(string _SN)
        {
            return dal.Get_PigtailNum(_SN);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.User_3D_Test_Good model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID_Key)
		{
			
			return dal.Delete(ID_Key);
		}
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="Option">精确查询=1；  模糊查询=2</param>
        /// <returns></returns>
        public bool Delete(string SN, int Option)
        {
          return  dal.Delete(SN, Option);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ID_Keylist )
		{
			return dal.DeleteList(ID_Keylist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.User_3D_Test_Good GetModel(decimal ID_Key)
		{
			
			return dal.GetModel(ID_Key);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.User_3D_Test_Good GetModelByCache(decimal ID_Key)
		{
			
			string CacheKey = "User_3D_Test_GoodModel-" + ID_Key;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID_Key);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.User_3D_Test_Good)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.User_3D_Test_Good> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.User_3D_Test_Good> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.User_3D_Test_Good> modelList = new List<Maticsoft.Model.User_3D_Test_Good>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.User_3D_Test_Good model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
	}
}

