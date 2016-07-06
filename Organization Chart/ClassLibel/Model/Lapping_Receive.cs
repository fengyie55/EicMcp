* Lapping_Receive.cs
*
* 功 能： N/A
* 类 名： Lapping_Receive
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:47   N/A    初版  
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
	/// Lapping_Receive:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Lapping_Receive
	{
		public Lapping_Receive()
		{}
		#region Model
		private decimal _lp_id;
		private string _count;
		private string _receiveuserid;
		private string _senduserid;
		private string _lappingreceiveid;
		private DateTime? _datatime;
		/// <summary>
		/// 
		/// </summary>
		public decimal Lp_ID
		{
			set{ _lp_id=value;}
			get{return _lp_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiveUserID
		{
			set{ _receiveuserid=value;}
			get{return _receiveuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendUserID
		{
			set{ _senduserid=value;}
			get{return _senduserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LappingReceiveID
		{
			set{ _lappingreceiveid=value;}
			get{return _lappingreceiveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DataTime
		{
			set{ _datatime=value;}
			get{return _datatime;}
		}
		#endregion Model

	}
}

