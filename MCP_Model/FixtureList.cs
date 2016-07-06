/**  版本信息模板在安装目录下，可自行修改。
* FixtureList.cs
*
* 功 能： N/A
* 类 名： FixtureList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-10-09 13:26:21   N/A    初版
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
	/// FixtureList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FixtureList
	{
		public FixtureList()
		{}
		#region Model
		private decimal _id;
		private string _barcode;
		private string _fixture_name;
		private string _installlocation;
		private string _f_state;
		private DateTime? _logdate;
		private string _loguser;
		private string _careuser;
		private DateTime? _usedate;
		private DateTime? _scrapdate;
		private string _fay_id;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BarCode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fixture_Name
		{
			set{ _fixture_name=value;}
			get{return _fixture_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InstallLocation
		{
			set{ _installlocation=value;}
			get{return _installlocation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_State
		{
			set{ _f_state=value;}
			get{return _f_state;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LogDate
		{
			set{ _logdate=value;}
			get{return _logdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LogUser
		{
			set{ _loguser=value;}
			get{return _loguser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CareUser
		{
			set{ _careuser=value;}
			get{return _careuser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UseDate
		{
			set{ _usedate=value;}
			get{return _usedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ScrapDate
		{
			set{ _scrapdate=value;}
			get{return _scrapdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FAY_ID
		{
			set{ _fay_id=value;}
			get{return _fay_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

