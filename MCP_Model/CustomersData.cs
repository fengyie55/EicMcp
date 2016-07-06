/**  版本信息模板在安装目录下，可自行修改。
* CustomersData.cs
*
* 功 能： N/A
* 类 名： CustomersData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/11/21 9:50:08   N/A    初版
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
	/// CustomersData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CustomersData
	{
		public CustomersData()
		{}
		#region Model
		private int _id;
		private string _sn;
		private string _il_13nm;
		private string _rl_13nm;
		private string _il_15nm;
		private string _rl_15nm;
		private string _r1;
		private string _r2;
		private string _r3;
		private string _r4;
		/// <summary>
		/// 
		/// </summary>
		public int Id
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
		public string IL_13nm
		{
			set{ _il_13nm=value;}
			get{return _il_13nm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RL_13nm
		{
			set{ _rl_13nm=value;}
			get{return _rl_13nm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_15nm
		{
			set{ _il_15nm=value;}
			get{return _il_15nm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RL_15nm
		{
			set{ _rl_15nm=value;}
			get{return _rl_15nm;}
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
		#endregion Model

	}
}

