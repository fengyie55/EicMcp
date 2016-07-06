* Material_Receive.cs
*
* 功 能： N/A
* 类 名： Material_Receive
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
	/// Material_Receive:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Material_Receive
	{
		public Material_Receive()
		{}
		#region Model
		private decimal _re_id;
		private string _receiveid;
		private string _materialnum;
		private string _clientnum;
		private string _count;
		private string _userid;
		private string _workstationid;
		private DateTime? _datatime;
		/// <summary>
		/// 
		/// </summary>
		public decimal Re_ID
		{
			set{ _re_id=value;}
			get{return _re_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceiveID
		{
			set{ _receiveid=value;}
			get{return _receiveid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MaterialNum
		{
			set{ _materialnum=value;}
			get{return _materialnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClientNum
		{
			set{ _clientnum=value;}
			get{return _clientnum;}
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
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkStationID
		{
			set{ _workstationid=value;}
			get{return _workstationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DataTime
		{
			set{ _datatime=value;}
			get{return _datatime;}
		}
		#endregion Model

	}
}

