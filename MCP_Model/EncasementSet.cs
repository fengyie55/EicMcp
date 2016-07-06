/* tb_EncasementSet.cs
*
* 功 能： N/A
* 类 名： tb_EncasementSet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-18 16:21:01   N/A    初版  
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tb_EncasementSet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EncasementSet
	{
		public EncasementSet()
		{}
		#region Model
		private decimal _id;
		private string _batchno;
		private string _device;
		private string _deviceqty;
		private string _sackqty;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BatchNo
		{
			set{ _batchno=value;}
			get{return _batchno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Device
		{
			set{ _device=value;}
			get{return _device;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceQty
		{
			set{ _deviceqty=value;}
			get{return _deviceqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SackQty
		{
			set{ _sackqty=value;}
			get{return _sackqty;}
		}
		#endregion Model

	}
}

