/**  版本信息模板在安装目录下，可自行修改。
* e_Reworks.cs
*
* 功 能： N/A
* 类 名： e_Reworks
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/25 12:45:36   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// e_Reworks:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class e_Reworks
	{
		public e_Reworks()
		{}
		#region Model
		private decimal _id;
		private byte[] _barcord;
		private byte[] _reworkcount;
		private byte[] _rejectsnum;
		private string _r_describe;
		private string _s_describe;
		private string _result;
		private DateTime? _date;
		private byte[] _operator;
		private byte[] _verify;
		private string _r1;
		private string _r2;
		private string _r3;
		private string _r4;
		private string _r5;
		/// <summary>
		/// 
		/// </summary>
		public decimal Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Barcord
		{
			set{ _barcord=value;}
			get{return _barcord;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] ReworkCount
		{
			set{ _reworkcount=value;}
			get{return _reworkcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] RejectsNum
		{
			set{ _rejectsnum=value;}
			get{return _rejectsnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R_Describe
		{
			set{ _r_describe=value;}
			get{return _r_describe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string S_Describe
		{
			set{ _s_describe=value;}
			get{return _s_describe;}
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
		public DateTime? Date
		{
			set{ _date=value;}
			get{return _date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Operator
		{
			set{ _operator=value;}
			get{return _operator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Verify
		{
			set{ _verify=value;}
			get{return _verify;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R1
		{
			set{ _r1=value;}
			get{return _r1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R2
		{
			set{ _r2=value;}
			get{return _r2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R3
		{
			set{ _r3=value;}
			get{return _r3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R4
		{
			set{ _r4=value;}
			get{return _r4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string R5
		{
			set{ _r5=value;}
			get{return _r5;}
		}
		#endregion Model

	}
}

