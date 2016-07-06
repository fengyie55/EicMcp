/* Rework.cs
*
* 功 能： N/A
* 类 名： Rework
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-22 10:50:39   N/A    初版  
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
	/// Rework:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Rework
	{
		public Rework()
		{}
		#region Model
		private decimal _id;
		private string _sn;
		private string _pigtailtype;
		private string _count;
		private string _rejectid;
		private string _rejectdescribe;
		private string _disposeid;
		private string _disposedescribe;
		private string _length;
		private string _result;
		private string _reworkid;
		private string _verifyid;
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
		public string SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PigtailType
		{
			set{ _pigtailtype=value;}
			get{return _pigtailtype;}
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
		public string RejectID
		{
			set{ _rejectid=value;}
			get{return _rejectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RejectDescribe
		{
			set{ _rejectdescribe=value;}
			get{return _rejectdescribe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisposeID
		{
			set{ _disposeid=value;}
			get{return _disposeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisposeDescribe
		{
			set{ _disposedescribe=value;}
			get{return _disposedescribe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReworkID
		{
			set{ _reworkid=value;}
			get{return _reworkid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VerifyID
		{
			set{ _verifyid=value;}
			get{return _verifyid;}
		}
		#endregion Model

	}
}

