/**  版本信息模板在安装目录下，可自行修改。
* InspectConfigExfo.cs
*
* 功 能： N/A
* 类 名： InspectConfigExfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  11/3/2016 11:32:51 AM   N/A    初版
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
	/// InspectConfigExfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InspectConfigExfo
	{
		public InspectConfigExfo()
		{}
		#region Model
		private string _productid;
		private string _wave;
		private string _type;
		private string _il_min;
		private string _il_max;
		private string _rl_min;
		private string _rl_max;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
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
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_Min
		{
			set{ _il_min=value;}
			get{return _il_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_Max
		{
			set{ _il_max=value;}
			get{return _il_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RL_Min
		{
			set{ _rl_min=value;}
			get{return _rl_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RL_Max
		{
			set{ _rl_max=value;}
			get{return _rl_max;}
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

