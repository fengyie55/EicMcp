/* OrderLabSet.cs
*
* 功 能： N/A
* 类 名： OrderLabSet
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-3-20 13:28:43   N/A    初版  
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
	/// OrderLabSet:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderLabSet
	{
		public OrderLabSet()
		{}
		#region Model
		private string _orderid;
		private string _bachno;
		private string _labname;
		private decimal _lab_id;
		private string _count;
		/// <summary>
		/// 
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BachNo
		{
			set{ _bachno=value;}
			get{return _bachno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LabName
		{
			set{ _labname=value;}
			get{return _labname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Lab_ID
		{
			set{ _lab_id=value;}
			get{return _lab_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		
		#endregion Model

	}
}

