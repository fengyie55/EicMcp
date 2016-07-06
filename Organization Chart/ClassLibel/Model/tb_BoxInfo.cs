* tb_BoxInfo.cs
*
* 功 能： N/A
* 类 名： tb_BoxInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-18 16:21:01   N/A    初版  
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
	/// tb_BoxInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tb_BoxInfo
	{
		public tb_BoxInfo()
		{}
		#region Model
		private decimal _id;
		private string _boxsn;
		private string _qty;
		private string _type;
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
		public string BoxSn
		{
			set{ _boxsn=value;}
			get{return _boxsn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

