/* OrderMaterial.cs
*
* 功 能： N/A
* 类 名： OrderMaterial
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:49   N/A    初版  
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
	/// OrderMaterial:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderMaterial
	{
		public OrderMaterial()
		{}
		#region Model
		private decimal _orm_id;
		private string _materialid;
		private string _sendcount;
		private string _orderid;
		/// <summary>
		/// 
		/// </summary>
		public decimal Orm_ID
		{
			set{ _orm_id=value;}
			get{return _orm_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialID
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendCount
		{
			set{ _sendcount=value;}
			get{return _sendcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

