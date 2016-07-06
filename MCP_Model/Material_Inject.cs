/* Material_Inject.cs
*
* 功 能： N/A
* 类 名： Material_Inject
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-9 16:48:33   N/A    初版  
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
	/// Material_Inject:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Material_Inject
	{
		public Material_Inject()
		{}
		#region Model
		private decimal _in_id;
		private string _orm_id;
		private string _count;
		private string _userid;
		private string _wk_id;
		private DateTime? _datetime;
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
		public string Orm_ID
		{
			set{ _orm_id=value;}
			get{return _orm_id;}
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
		public string WK_ID
		{
			set{ _wk_id=value;}
			get{return _wk_id;}
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

