using Maticsoft.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using ZhuifengLib;

namespace Maticsoft.Bll
{
    /// <summary>
    /// 检测配置管理
    /// </summary>
    public class InspectConfigManage
    {
        WorkOrder _M_WorkOrder = new WorkOrder();                   //工单基本信息
        InspectConfigProduct _M_InspectConfig = new InspectConfigProduct();

        /// <summary>
        /// 检测配置是否存在
        /// </summary>
        /// <param name="orderId">工单单号</param>
        /// <returns></returns>
        public bool IsExist(string orderId)
        {
            return GetInspectConfigBy(orderId) == null ? false : true;
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="orderId">工单单号</param>
        /// <returns></returns>
        public Model.InspectConfigProduct GetInspectConfigBy(string orderId)
        {
            var productId = _M_WorkOrder.GetProductId(orderId);

            return _M_InspectConfig.GetModel(productId);
        }

        public bool SavaInspectConfig(Model.InspectConfigProduct model)
        {
            //_M_InspectConfig.Add(model);
            //_M_InspectConfig.Update(model);

            ////TODO:保存配置信息到数据库 Note：需要处理添加还是修改
            //List<Model.InspectConfigProduct> temList = new List<Model.InspectConfigProduct>();

            //var str = EntityString<Model.InspectConfigProduct>.GetEntityToStringJson(temList);
            //var listModel = EntityString<Model.InspectConfigProduct>.GetEntityStringToEntityJson(str);

            return true;
        }

        /// <summary>
        /// 保存基础信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SavaBaseInspectConfigInfo(string orderId, Model.InspectConfigProduct model)
        {
            var orderInspectConfig = GetInspectConfigBy(orderId);
            if (orderInspectConfig != null)
            {
                orderInspectConfig.InspectMethod = model.InspectMethod;
                orderInspectConfig.InspectType = model.InspectType;
                return _M_InspectConfig.Update(orderInspectConfig);
            }
            else
            {
                return _M_InspectConfig.Add(model) > 0;
            }
        }

        /// <summary>
        /// 保存检测信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="inspectStandardList"></param>
        /// <returns></returns>
        public bool SavaInspectStandard(string orderId, List<Maticsoft.Model.InspectStandard> inspectStandardList)
        {
            var orderInspectConfig = GetInspectConfigBy(orderId);
            if (orderInspectConfig != null)
            {
                orderInspectConfig.ThreeDimensionalConfig = EntityString<Model.InspectStandard>.GetEntityToStringJson(inspectStandardList);

                return _M_InspectConfig.Update(orderInspectConfig);
            }
            else
            {
                var orderInfo = _M_WorkOrder.GetOrderInfo(orderId);
                Model.InspectConfigProduct productInspectConfig = new Model.InspectConfigProduct();
                if (orderInfo?.Tables[0]?.Rows.Count > 0)
                {
                    productInspectConfig.ProductId = orderInfo.Tables[0].Rows[0]["品号"].ToString();
                    productInspectConfig.ProductName = orderInfo.Tables[0].Rows[0]["品名"].ToString();
                    productInspectConfig.Model = orderInfo.Tables[0].Rows[0]["规格"].ToString();
                    productInspectConfig.ThreeDimensionalConfig = EntityString<Model.InspectStandard>.GetEntityToStringJson(inspectStandardList);

                    return _M_InspectConfig.Add(productInspectConfig) > 0;
                }
                else return false;
            }
        }

        /// <summary>
        /// 保存打印信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="labName"></param>
        /// <param name="labContentList"></param>
        /// <returns></returns>
        public bool SavaPrintConfig(string orderId, string labName, List<Model.LabInfo> labContentList)
        {
            var orderInspectConfig = GetInspectConfigBy(orderId);
            if (orderInspectConfig != null)
            {
                orderInspectConfig.LabelName = labName;
                orderInspectConfig.LabelContentConfig = EntityString<Model.LabInfo>.GetEntityToStringJson(labContentList);

                return _M_InspectConfig.Update(orderInspectConfig);
            }
            else
            {
                var orderInfo = _M_WorkOrder.GetOrderInfo(orderId);
                Model.InspectConfigProduct productInspectConfig = new Model.InspectConfigProduct();
                if (orderInfo?.Tables[0]?.Rows.Count > 0)
                {
                    productInspectConfig.ProductId = orderInfo.Tables[0].Rows[0]["品号"].ToString();
                    productInspectConfig.ProductName = orderInfo.Tables[0].Rows[0]["品名"].ToString();
                    productInspectConfig.Model = orderInfo.Tables[0].Rows[0]["规格"].ToString();
                    productInspectConfig.LabelName = labName;
                    productInspectConfig.LabelContentConfig = EntityString<Model.LabInfo>.GetEntityToStringJson(labContentList);

                    return _M_InspectConfig.Add(productInspectConfig) > 0;
                }
                else return false;
            }
        }

        /// <summary>
        /// 获取检测标准
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<Model.InspectStandard> GetInspectStandard(string orderId)
        {
            var orderInspectConfig = GetInspectConfigBy(orderId);
            if (orderInspectConfig != null)
            {
                var inspectStandardList = EntityString<Model.InspectStandard>.GetEntityStringToEntityJson(orderInspectConfig.ThreeDimensionalConfig);
                return inspectStandardList;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取标签内容
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<Model.LabInfo> GetLabContent(string orderId)
        {
            var orderInspectConfig = GetInspectConfigBy(orderId);
            if (orderInspectConfig != null)
            {
                var labContentList = EntityString<Model.LabInfo>.GetEntityStringToEntityJson(orderInspectConfig.LabelContentConfig);
                return labContentList;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取标签模板
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string GetLabName(string orderId)
        {
           return  GetInspectConfigBy(orderId)?.LabelName;
        }
    }




}
