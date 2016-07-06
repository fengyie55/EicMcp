/**  版本信息模板在安装目录下，可自行修改。
* FixtureList.cs
*
* 功 能： N/A
* 类 名： FixtureList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-09 13:26:22   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
using System.Collections.ObjectModel;
namespace Maticsoft.BLL
{
	/// <summary>
	/// FixtureList
	/// </summary>
	public partial class FixtureList
	{
		private readonly Maticsoft.DAL.FixtureList dal=new Maticsoft.DAL.FixtureList();
		public FixtureList()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.FixtureList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.FixtureList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.FixtureList GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.FixtureList GetModelByCache(decimal ID)
		{
			
			string CacheKey = "FixtureListModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.FixtureList)objModel;
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
		public List<Maticsoft.Model.FixtureList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.FixtureList> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.FixtureList> modelList = new List<Maticsoft.Model.FixtureList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.FixtureList model;
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
		#region  ExtensionMethod

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public ObservableCollection<Maticsoft.Model.FixtureList> GetModelList1(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList1(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public ObservableCollection<Maticsoft.Model.FixtureList> DataTableToList1(DataTable dt)
        {
            ObservableCollection<Maticsoft.Model.FixtureList> modelList = new ObservableCollection<Maticsoft.Model.FixtureList>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.FixtureList model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.FixtureList();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = decimal.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["BarCode"] != null && dt.Rows[n]["BarCode"].ToString() != "")
                    {
                        model.BarCode = dt.Rows[n]["BarCode"].ToString();
                    }
                    if (dt.Rows[n]["Fixture_Name"] != null && dt.Rows[n]["Fixture_Name"].ToString() != "")
                    {
                        model.Fixture_Name = dt.Rows[n]["Fixture_Name"].ToString();
                    }
                    if (dt.Rows[n]["InstallLocation"] != null && dt.Rows[n]["InstallLocation"].ToString() != "")
                    {
                        model.InstallLocation = dt.Rows[n]["InstallLocation"].ToString();
                    }
                    if (dt.Rows[n]["F_State"] != null && dt.Rows[n]["F_State"].ToString() != "")
                    {
                        model.F_State = dt.Rows[n]["F_State"].ToString();
                    }
                    if (dt.Rows[n]["LogDate"] != null && dt.Rows[n]["LogDate"].ToString() != "")
                    {
                        model.LogDate = DateTime.Parse(dt.Rows[n]["LogDate"].ToString());
                    }
                    if (dt.Rows[n]["LogUser"] != null && dt.Rows[n]["LogUser"].ToString() != "")
                    {
                        model.LogUser = dt.Rows[n]["LogUser"].ToString();
                    }
                    if (dt.Rows[n]["CareUser"] != null && dt.Rows[n]["CareUser"].ToString() != "")
                    {
                        model.CareUser = dt.Rows[n]["CareUser"].ToString();
                    }
                    if (dt.Rows[n]["UseDate"] != null && dt.Rows[n]["UseDate"].ToString() != "")
                    {
                        model.UseDate = DateTime.Parse(dt.Rows[n]["UseDate"].ToString());
                    }
                    if (dt.Rows[n]["ScrapDate"] != null && dt.Rows[n]["ScrapDate"].ToString() != "")
                    {
                        model.ScrapDate = DateTime.Parse(dt.Rows[n]["ScrapDate"].ToString());
                    }
                    if (dt.Rows[n]["FAY_ID"] != null && dt.Rows[n]["FAY_ID"].ToString() != "")
                    {
                        model.FAY_ID = dt.Rows[n]["FAY_ID"].ToString();
                    }
                    if (dt.Rows[n]["Remark"] != null && dt.Rows[n]["Remark"].ToString() != "")
                    {
                        model.Remark = dt.Rows[n]["Remark"].ToString();
                    }

                  
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获取字段不重复记录
        /// </summary>
        /// <param name="_Value">字段名</param>
        /// <returns></returns>
        public DataSet Get_Distinct_List(string _Value)
        {
            return dal.Get_Distinct_List(_Value);
        }
		#endregion  ExtensionMethod
	}
}

