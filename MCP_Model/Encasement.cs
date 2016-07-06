/* tb_Encasement.cs
*
* 功 能： N/A
* 类 名： tb_Encasement
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-2-18 16:20:56   N/A    初版  
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
	/// tb_Encasement:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Encasement
	{
		public Encasement()
		{}
		#region Model
		private decimal _id;
		private string _boxid;
		private string _sn;
		private string _qty;
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
		public string BoxID
		{
			set{ _boxid=value;}
			get{return _boxid;}
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
		public string Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		#endregion Model

	}
}

