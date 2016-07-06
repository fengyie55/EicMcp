/* Rejected.cs
*
* 功 能： N/A
* 类 名： Rejected
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-12 15:19:29   N/A    初版  
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
	/// Rejected:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Rejected
	{
		public Rejected()
		{}
		#region Model
		
		private string _rejectcode;
		private string _reject;
		private string _descriptions;
		private byte[] _picture;
		private string _notes;
		
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
		public string Reject
		{
			set{ _reject=value;}
			get{return _reject;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Descriptions
		{
			set{ _descriptions=value;}
			get{return _descriptions;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Picture
		{
			set{ _picture=value;}
			get{return _picture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Notes
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		#endregion Model

	}
}

