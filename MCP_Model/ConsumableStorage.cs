/**  版本信息模板在安装目录下，可自行修改。
* ConsumableStorage.cs
*
* 功 能： N/A
* 类 名： ConsumableStorage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-09-26 10:32:35   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ConsumableStorage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ConsumableStorage
	{
		public ConsumableStorage()
		{}
		#region Model
		private decimal _c_stoid;
		private string _c_barcode;
        private string _c_Name;
		private int? _count;
		private string _username;
		private string _datetime;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public decimal C_StoID
		{
			set{ _c_stoid=value;}
			get{return _c_stoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Barcode
		{
			set{ _c_barcode=value;}
			get{return _c_barcode;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string C_Name
        {
            set { _c_Name = value; }
            get { return _c_Name; }
        }

		/// <summary>
		/// 
		/// </summary>
		public int? Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Datetime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

