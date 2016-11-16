/**  版本信息模板在安装目录下，可自行修改。
* InspectConfig3D.cs
*
* 功 能： N/A
* 类 名： InspectConfig3D
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
	/// InspectConfig3D:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class InspectConfig3D
	{
		public InspectConfig3D()
		{}
		#region Model
		private string _productid;
		private string _type;
		private string _rco_min;
		private string _rco_max;
		private string _ao_min;
		private string _ao_max;
		private string _fh_min;
		private string _fh_max;
		private string _ae_min;
		private string _ae_max;
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
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCO_Min
		{
			set{ _rco_min=value;}
			get{return _rco_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCO_Max
		{
			set{ _rco_max=value;}
			get{return _rco_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AO_Min
		{
			set{ _ao_min=value;}
			get{return _ao_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AO_Max
		{
			set{ _ao_max=value;}
			get{return _ao_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FH_Min
		{
			set{ _fh_min=value;}
			get{return _fh_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FH_Max
		{
			set{ _fh_max=value;}
			get{return _fh_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AE_Min
		{
			set{ _ae_min=value;}
			get{return _ae_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AE_Max
		{
			set{ _ae_max=value;}
			get{return _ae_max;}
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

