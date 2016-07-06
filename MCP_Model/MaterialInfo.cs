/* MaterialInfo.cs
*
* 功 能： N/A
* 类 名： MaterialInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-23 13:51:48   N/A    初版  
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// MaterialInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MaterialInfo
	{
		public MaterialInfo()
		{}
		#region Model
		private string _materialid;
		private string _aliasname;
		private string _productname;
		private string _model;
		private byte[] _materialphoto;
		private string _type;
        private string _unit;
		/// <summary>
		/// 
		/// </summary>
		public string MaterialID
		{
			set{ _materialid=value;}
			get{return _materialid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AliasName
		{
			set{ _aliasname=value;}
			get{return _aliasname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] MaterialPhoto
		{
			set{ _materialphoto=value;}
			get{return _materialphoto;}
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
        public string Unit
        {
            set { _unit = value; }
            get { return _type; }
        }
		#endregion Model

	}
}

