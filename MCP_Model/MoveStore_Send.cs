/* MoveStore_Send.cs
*
* 功 能： N/A
* 类 名： MoveStore_Send
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-5-26 13:30:46   N/A    初版  
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
	/// MoveStore_Send:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MoveStore_Send
	{
		public MoveStore_Send()
		{}
		#region Model
		private decimal _mse_id;
		private string _orderid;
		private decimal? _ste_id;
		private int? _count;
		private string _jobnum;
		private string _wk_id;
		private decimal? _or_id;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public decimal Mse_ID
		{
			set{ _mse_id=value;}
			get{return _mse_id;}
		}
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
		public decimal? Ste_ID
		{
			set{ _ste_id=value;}
			get{return _ste_id;}
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
		public string JobNum
		{
			set{ _jobnum=value;}
			get{return _jobnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wk_ID
		{
			set{ _wk_id=value;}
			get{return _wk_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Or_ID
		{
			set{ _or_id=value;}
			get{return _or_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

