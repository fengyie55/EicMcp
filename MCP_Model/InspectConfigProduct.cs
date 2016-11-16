/**  版本信息模板在安装目录下，可自行修改。
* InspectConfigProduct.cs
*
* 功 能： N/A
* 类 名： InspectConfigProduct
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  11/5/2016 2:48:06 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// InspectConfigProduct:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class InspectConfigProduct
    {
        public InspectConfigProduct()
        { }
        #region Model
        private string _productid;
        private string _productname;
        private string _model;
        private string _inspectmethod;
        private string _inspecttype;
        private string _labelname;
        private string _threedimensionalconfig;
        private string _exfoconfig;
        private string _labelcontentconfig;
        private decimal _id_key;
        /// <summary>
        /// 
        /// </summary>
        public string ProductId
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductName
        {
            set { _productname = value; }
            get { return _productname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Model
        {
            set { _model = value; }
            get { return _model; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InspectMethod
        {
            set { _inspectmethod = value; }
            get { return _inspectmethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InspectType
        {
            set { _inspecttype = value; }
            get { return _inspecttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LabelName
        {
            set { _labelname = value; }
            get { return _labelname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThreeDimensionalConfig
        {
            set { _threedimensionalconfig = value; }
            get { return _threedimensionalconfig; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExfoConfig
        {
            set { _exfoconfig = value; }
            get { return _exfoconfig; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LabelContentConfig
        {
            set { _labelcontentconfig = value; }
            get { return _labelcontentconfig; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Id_Key
        {
            set { _id_key = value; }
            get { return _id_key; }
        }
        #endregion Model

    }
}

