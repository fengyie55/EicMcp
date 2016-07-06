* Dispose.cs
*
* 功 能： N/A
* 类 名： Dispose
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-12 15:19:28   N/A    初版  
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
	/// Dispose:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Dispose
	{
		public Dispose()
		{}
		#region Model
		private decimal _id;
		private string _rejectcode;
		private string _disposemethod;
		private string _descriptions;
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
		public string RejectCode
		{
			set{ _rejectcode=value;}
			get{return _rejectcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisposeMethod
		{
			set{ _disposemethod=value;}
			get{return _disposemethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descriptions
		{
			set{ _descriptions=value;}
			get{return _descriptions;}
		}
		#endregion Model

	}
}

