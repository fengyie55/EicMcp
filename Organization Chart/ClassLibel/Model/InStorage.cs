* InStorage.cs
*
* 功 能： N/A
* 类 名： InStorage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:45   N/A    初版  
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
	/// InStorage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InStorage
	{
		public InStorage()
		{}
		#region Model
		private decimal _in_id;
		private string _instorageid;
		private string _count;
		private string _userid;
		private DateTime? _datatime;
		/// <summary>
		/// 
		/// </summary>
		public decimal In_ID
		{
			set{ _in_id=value;}
			get{return _in_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InStorageID
		{
			set{ _instorageid=value;}
			get{return _instorageid;}
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
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
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

