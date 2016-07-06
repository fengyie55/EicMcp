/* LabInfo.cs
*
* 功 能： N/A
* 类 名： LabInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-3-20 13:28:35   N/A    初版  
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
	/// LabInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LabInfo
	{
		public LabInfo()
		{}
		#region Model
		private string _lab_id;
		private string _name;
		private string _value;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string Lab_ID
		{
			set{ _lab_id=value;}
			get{return _lab_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Value
		{
			set{ _value=value;}
			get{return _value;}
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

        public override string ToString()
        {
            string tem = "";
            tem += "\r\n Name:" + _name;
            tem += "\r\n Value：" + _value;
            return tem;
        }

	}
}

