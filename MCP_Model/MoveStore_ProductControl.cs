/* MoveStore_ProductControl.cs
*
* 功 能： N/A
* 类 名： MoveStore_ProductControl
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-6-11 11:20:22   N/A    初版  
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
	/// MoveStore_ProductControl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MoveStore_ProductControl
	{
		public MoveStore_ProductControl()
		{}
		#region Model
		private decimal _ms_id;
		private string _send_wk;
		private string _send_state;
		private string _send_usid;
		private string _receive_wk;
		private string _receive_state;
		private string _receive_usid;
		private string _count;
		private string _ord_id;
		private string _pb_id;
		private string _note;
        private DateTime? _datatime;
		/// <summary>
		/// 
		/// </summary>
		public decimal MS_ID
		{
			set{ _ms_id=value;}
			get{return _ms_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Send_WK
		{
			set{ _send_wk=value;}
			get{return _send_wk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Send_State
		{
			set{ _send_state=value;}
			get{return _send_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Send_USID
		{
			set{ _send_usid=value;}
			get{return _send_usid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Receive_WK
		{
			set{ _receive_wk=value;}
			get{return _receive_wk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Receive_State
		{
			set{ _receive_state=value;}
			get{return _receive_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Receive_USID
		{
			set{ _receive_usid=value;}
			get{return _receive_usid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ord_ID
		{
			set{ _ord_id=value;}
			get{return _ord_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PB_ID
		{
			set{ _pb_id=value;}
			get{return _pb_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Note
		{
			set{ _note=value;}
			get{return _note;}
		}


        /// <summary>
        /// 
        /// </summary>
        public DateTime? DataTime
        {
            set { _datatime = value; }
            get { return _datatime; } 
        }
		#endregion Model

	}
}

