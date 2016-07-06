* Workstation.cs
*
* 功 能： N/A
* 类 名： Workstation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:50   N/A    初版  
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
	/// Workstation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Workstation
	{
		public Workstation()
		{}
		#region Model
		private decimal _wo_id;
		private string _workstation;
		/// <summary>
		/// 
		/// </summary>
		public decimal Wo_ID
		{
			set{ _wo_id=value;}
			get{return _wo_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Workstation
		{
			set{ _workstation=value;}
			get{return _workstation;}
		}
		#endregion Model

	}
}

