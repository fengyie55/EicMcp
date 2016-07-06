/**  
* User_JDS_Test_Good.cs
*
* 功 能： JDS测试信息
* 类 名： User_JDS_Test_Good
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-31 11:06:01   追风猎人    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人                    　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// User_JDS_Test_Good:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User_JDS_Test_Good
	{
		public User_JDS_Test_Good()
		{}
		#region Model
		private string _testdate;
		private string _partnumber;
		private string _sn;
		private string _result;
		private string _wave;
		private string _il_a;
		private string _refl_a;
		private string _il_b;
		private string _refl_b;		
		/// <summary>
		/// 
		/// </summary>
		public string TestDate
		{
			set{ _testdate=value;}
			get{return _testdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartNumber
		{
			set{ _partnumber=value;}
			get{return _partnumber;}
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
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wave
		{
			set{ _wave=value;}
			get{return _wave;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_A
		{
			set{ _il_a=value;}
			get{return _il_a;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Refl_A
		{
			set{ _refl_a=value;}
			get{return _refl_a;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_B
		{
			set{ _il_b=value;}
			get{return _il_b;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Refl_B
		{
			set{ _refl_b=value;}
			get{return _refl_b;}
		}
		
		#endregion Model

	}
}

