/**  版本信息模板在安装目录下，可自行修改。
* e_Flow.cs
*
* 功 能： N/A
* 类 名： e_Flow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/1/16 8:41:10   N/A    初版
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
	/// e_Flow:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class e_Flow
	{
		public e_Flow()
		{}
		#region Model
		private string _drawnum;
		private string _processorder;
		private string _processnum;
		private string _processname;
		private string _isimportant;
		private string _isaffirm;
		private string _content;
		private string _remaks;
		private string _r1;
		private string _r2;
		private string _r3;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string DrawNum
		{
			set{ _drawnum=value;}
			get{return _drawnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcessOrder
		{
			set{ _processorder=value;}
			get{return _processorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcessNum
		{
			set{ _processnum=value;}
			get{return _processnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcessName
		{
			set{ _processname=value;}
			get{return _processname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsImportant
		{
			set{ _isimportant=value;}
			get{return _isimportant;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsAffirm
		{
			set{ _isaffirm=value;}
			get{return _isaffirm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remaks
		{
			set{ _remaks=value;}
			get{return _remaks;}
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
		public decimal ID_Key
		{
			set{ _id_key=value;}
			get{return _id_key;}
		}
		#endregion Model

	}
}

