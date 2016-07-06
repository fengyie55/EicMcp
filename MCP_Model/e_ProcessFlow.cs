/**  版本信息模板在安装目录下，可自行修改。
* e_ProcessFlow.cs
*
* 功 能： N/A
* 类 名： e_ProcessFlow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/1/28 13:33:41   N/A    初版
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
    /// e_ProcessFlow:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class e_ProcessFlow
    {
        public e_ProcessFlow()
        { }
        #region Model
        private decimal _id_key;
        private string _barcode;
        private string _pronum;
        private string _processname;
        private string _processcontent;
        private string _value;
        private string _jobnum;
        private string _username;
        private DateTime? datetime;
        private string _state;
        private string _remarks;
        private string _r1;
        private string _r2;
        private string _r3;
        private string _r4;
        private string _r5;
        /// <summary>
        /// 
        /// </summary>
        public decimal ID_Key
        {
            set { _id_key = value; }
            get { return _id_key; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BarCode
        {
            set { _barcode = value; }
            get { return _barcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProNum
        {
            set { _pronum = value; }
            get { return _pronum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessName
        {
            set { _processname = value; }
            get { return _processname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProcessContent
        {
            set { _processcontent = value; }
            get { return _processcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value
        {
            set { _value = value; }
            get { return _value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string JobNum
        {
            set { _jobnum = value; }
            get { return _jobnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateTime
        {
            set { datetime = value; }
            get { return datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R1
        {
            set { _r1 = value; }
            get { return _r1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R2
        {
            set { _r2 = value; }
            get { return _r2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R3
        {
            set { _r3 = value; }
            get { return _r3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R4
        {
            set { _r4 = value; }
            get { return _r4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string R5
        {
            set { _r5 = value; }
            get { return _r5; }
        }
        #endregion Model

    }
}

