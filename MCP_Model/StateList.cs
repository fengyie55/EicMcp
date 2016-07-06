/* StateList.cs
*
* 功 能： N/A
* 类 名： StateList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-5-27 10:24:37   N/A    初版  
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
	/// StateList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StateList
	{
		public StateList()
		{}
		#region Model
		private decimal _ste_id;
		private string _type;
		private string _wk_id;
		private string _state;
		/// <summary>
		/// 
		/// </summary>
		public decimal Ste_ID
		{
			set{ _ste_id=value;}
			get{return _ste_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
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
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

