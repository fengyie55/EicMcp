/**  版本信息模板在安装目录下，可自行修改。
* Equipment_Maintain.cs
*
* 功 能： N/A
* 类 名： Equipment_Maintain
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-08 9:14:35   N/A    初版
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
	/// Equipment_Maintain:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Equipment_Maintain
	{
		public Equipment_Maintain()
		{}
		#region Model
		private decimal _mat_id;
		private string _formnum;
		private string _ass_num;
		private string _ass_name;
		private string _ass_makenum;
		private string _ass_type;
		private string _apply_date;
		private string _apply_describe;
		private string _apply_user;
		private string _maintain_cause;
		private string _maintain_describe;
		private string _maintain_user;
		private string _maintain_date;
		private string _check_deseribe;
		private string _check_result;
		private string _check_date;
		private string _check_user;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public decimal Mat_ID
		{
			set{ _mat_id=value;}
			get{return _mat_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FormNum
		{
			set{ _formnum=value;}
			get{return _formnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ass_Num
		{
			set{ _ass_num=value;}
			get{return _ass_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ass_Name
		{
			set{ _ass_name=value;}
			get{return _ass_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ass_MakeNum
		{
			set{ _ass_makenum=value;}
			get{return _ass_makenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ass_Type
		{
			set{ _ass_type=value;}
			get{return _ass_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Apply_Date
		{
			set{ _apply_date=value;}
			get{return _apply_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Apply_Describe
		{
			set{ _apply_describe=value;}
			get{return _apply_describe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Apply_User
		{
			set{ _apply_user=value;}
			get{return _apply_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Maintain_Cause
		{
			set{ _maintain_cause=value;}
			get{return _maintain_cause;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Maintain_Describe
		{
			set{ _maintain_describe=value;}
			get{return _maintain_describe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maintain_User
		{
			set{ _maintain_user=value;}
			get{return _maintain_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Maintain_Date
		{
			set{ _maintain_date=value;}
			get{return _maintain_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Check_Deseribe
		{
			set{ _check_deseribe=value;}
			get{return _check_deseribe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Check_Result
		{
			set{ _check_result=value;}
			get{return _check_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Check_Date
		{
			set{ _check_date=value;}
			get{return _check_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Check_User
		{
			set{ _check_user=value;}
			get{return _check_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

