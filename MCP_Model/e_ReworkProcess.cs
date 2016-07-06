/**  版本信息模板在安装目录下，可自行修改。
* e_ReworkProcess.cs
*
* 功 能： N/A
* 类 名： e_ReworkProcess
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
	/// e_ReworkProcess:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class e_ReworkProcess
	{
		public e_ReworkProcess()
		{}
		#region Model
		private decimal _id_key;
		private string _rejectsnum;
		private string _pronum;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID_Key
		{
			set{ _id_key=value;}
			get{return _id_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RejectsNum
		{
			set{ _rejectsnum=value;}
			get{return _rejectsnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProNum
		{
			set{ _pronum=value;}
			get{return _pronum;}
		}
		#endregion Model

	}
}

