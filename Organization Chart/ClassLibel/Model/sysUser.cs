/**  版本信息模板在安装目录下，可自行修改。
* sysUser.cs
*
* 功 能： N/A
* 类 名： sysUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-3 16:43:30   N/A    初版
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
	/// sysUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class sysUser
	{
		public sysUser()
		{}
		#region Model
		private string _userid;
		private string _username;
		private string _password;
		private string _workstation;
		private string _privilege;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Workstation
		{
			set{ _workstation=value;}
			get{return _workstation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Privilege
		{
			set{ _privilege=value;}
			get{return _privilege;}
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

