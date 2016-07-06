/**  版本信息模板在安装目录下，可自行修改。
* tb_PrintRecord.cs
*
* 功 能： N/A
* 类 名： tb_PrintRecord
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-29 9:31:22   N/A    初版
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
	/// tb_PrintRecord:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PrintRecord
	{
		public PrintRecord()
		{}
		#region Model
		private string _sn;
		private string _staff;
		private string _datatime;
		private string _labellmode;
		private string _batchno;
		private string _orderid;
		private decimal _id_key;
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
		public string Staff
		{
			set{ _staff=value;}
			get{return _staff;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DataTime
		{
			set{ _datatime=value;}
			get{return _datatime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LabellMode
		{
			set{ _labellmode=value;}
			get{return _labellmode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BatchNo
		{
			set{ _batchno=value;}
			get{return _batchno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
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

