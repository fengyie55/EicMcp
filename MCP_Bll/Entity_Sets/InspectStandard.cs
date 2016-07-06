


using System.Collections.Generic;
using System.Data;
using System.Collections.ObjectModel;
namespace Maticsoft.BLL
{
    public partial class InspectStandard
    {
        Maticsoft.DAL.InspectStandard dal = new Maticsoft.DAL.InspectStandard();
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_isd"></param>
        /// <returns></returns>
        public bool Add(Maticsoft.Model.InspectStandard isd)
        {
          return  dal.Add(isd);
        }

        /// <summary>
        /// 确定数据库中是否存在该记录
        /// </summary>
        /// <param name="orderID">工单单号</param>
        /// <param name="type">接头类型</param>
        /// <returns></returns>
        public bool Exists(string orderID,string type)
        {
            return dal.Exists(orderID, type);
        }

        /// <summary>
        /// 删除数据库中的记录
        /// </summary>
        /// <param name="orderID">工单单号</param>
        /// <param name="type">接头类型</param>
        /// <returns></returns>
        public bool Delete(string orderID, string type)
        {
            return dal.Delete(orderID, type);
        }

        /// <summary>
        /// 删除数据库中的记录
        /// </summary>
        /// <param name="orderID">工单单号</param>
        /// <returns></returns>
        public bool Delete(string orderID)
        {
            return dal.Delete(orderID);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public ObservableCollection<Maticsoft.Model.InspectStandard> GetModelList(string orderID)
        {
            DataSet ds = dal.GetList(orderID);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public ObservableCollection<Maticsoft.Model.InspectStandard> DataTableToList(DataTable dt)
        {
            ObservableCollection<Maticsoft.Model.InspectStandard> modelList = new ObservableCollection<Maticsoft.Model.InspectStandard>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.InspectStandard model;
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
    }
}
