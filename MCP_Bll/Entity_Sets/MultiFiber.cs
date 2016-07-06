using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
    /// <summary>
    /// MultiFiber
    /// </summary>
    public partial class MultiFiber
    {
        private readonly Maticsoft.DAL.MultiFiber dal = new Maticsoft.DAL.MultiFiber();
        public MultiFiber()
        { }
        #region  BasicMethod

        /// <summary>
        /// 获取数据
        /// </summary>
        public void Getdata_Method_MPO(Maticsoft.DAL.My_GetTestData.GetDataEventArgs e)
        {
            dal.Getdata_Method_MPO(e);
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        public DataSet Getdata_Method_mpo(string SN)
        {
          return  dal.Getdata_Method_mpo(SN);
        }
        



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, string ConnectorID)
        {
            return dal.Exists(ID, ConnectorID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.MultiFiber model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.MultiFiber model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID, string ConnectorID)
        {

            return dal.Delete(ID, ConnectorID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string ConnectorID)
        {

            return dal.Delete( ConnectorID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.MultiFiber GetModel( string ConnectorID)
        {

            return dal.GetModel( ConnectorID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.MultiFiber GetModelByCache( string ConnectorID)
        {

            string CacheKey = "MultiFiberModel-"  + ConnectorID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ConnectorID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.MultiFiber)objModel;
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
        /// 获取SPC数据 当字段为空时 返回指定的三个 字段的数据
        /// </summary>
        /// <param name="_Field">字段</param>
        /// <param name="_Date">日期</param>
        /// <returns></returns>
        public DataSet GetList(string _Field, string _Date, string Angle)
        {
            return dal.GetList(_Field, _Date, Angle);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.MultiFiber> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.MultiFiber> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.MultiFiber> modelList = new List<Maticsoft.Model.MultiFiber>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.MultiFiber model;
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

