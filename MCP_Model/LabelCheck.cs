/* LabelCheck.cs
*
* 功 能： N/A
* 类 名： LabelCheck
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/24 14:17:46   张文明    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// LabelCheck:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LabelCheck
	{
		public LabelCheck()
		{}
		#region Model
		private string _sn;
		private string _lab;
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
		public string Lab
		{
			set{ _lab=value;}
			get{return _lab;}
		}
		#endregion Model

	}
}

