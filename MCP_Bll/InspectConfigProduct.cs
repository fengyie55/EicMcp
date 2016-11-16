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
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// InspectConfigProduct
    /// </summary>
    public partial class InspectConfigProduct
    {
        private readonly Maticsoft.DAL.InspectConfigProduct dal = new Maticsoft.DAL.InspectConfigProduct();
        public InspectConfigProduct()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string ProductId)
        {
            return dal.Exists(ProductId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public decimal Add(Model.InspectConfigProduct model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.InspectConfigProduct model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(decimal Id_Key)
        {

            return dal.Delete(Id_Key);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ProductId)
        {

            return dal.Delete(ProductId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string Id_Keylist)
        {
            return dal.DeleteList(Id_Keylist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.InspectConfigProduct GetModel(decimal Id_Key)
        {

            return dal.GetModel(Id_Key);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.InspectConfigProduct GetModel(string productId)
        {

            return dal.GetModel(productId);
        }



        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.InspectConfigProduct GetModelByCache(decimal Id_Key)
        {

            string CacheKey = "InspectConfigProductModel-" + Id_Key;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id_Key);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.InspectConfigProduct)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.InspectConfigProduct> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.InspectConfigProduct> DataTableToList(DataTable dt)
        {
            List<Model.InspectConfigProduct> modelList = new List<Model.InspectConfigProduct>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.InspectConfigProduct model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

        #endregion  ExtensionMethod
    }
}

