/* AdapterTestData.cs
*
* 功 能： N/A
* 类 名： AdapterTestData
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-3-26 13:54:41   N/A    初版  
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
	/// AdapterTestData:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AdapterTestData
	{
		public AdapterTestData()
		{}
		#region Model
		private string _orderid;
		private string _productname;
		private decimal? _testrl1;
		private decimal? _testrl2;
		private decimal? _testrl3;
		private decimal? _testrl4;
		private decimal? _testrl5;
		private decimal? _modelrl;
		private decimal? _testfour0;
		private decimal? _testfour90;
		private decimal? _testfour180;
		private decimal? _testfour270;
		private decimal? _modelfour;
		private DateTime _testtime;
		private string _scline;
		private string _p_value;
		private string _br_value;
		private string _recordtestop;
		private string _machineid;
		private string _machinename;
		private string _testresult;
		private decimal _id_key;
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
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TestRL1
		{
			set{ _testrl1=value;}
			get{return _testrl1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TestRL2
		{
			set{ _testrl2=value;}
			get{return _testrl2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TestRL3
		{
			set{ _testrl3=value;}
			get{return _testrl3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TestRL4
		{
			set{ _testrl4=value;}
			get{return _testrl4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TestRL5
		{
			set{ _testrl5=value;}
			get{return _testrl5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ModelRl
		{
			set{ _modelrl=value;}
			get{return _modelrl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Testfour0
		{
			set{ _testfour0=value;}
			get{return _testfour0;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Testfour90
		{
			set{ _testfour90=value;}
			get{return _testfour90;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Testfour180
		{
			set{ _testfour180=value;}
			get{return _testfour180;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Testfour270
		{
			set{ _testfour270=value;}
			get{return _testfour270;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ModelFour
		{
			set{ _modelfour=value;}
			get{return _modelfour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime TestTime
		{
			set{ _testtime=value;}
			get{return _testtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SCLine
		{
			set{ _scline=value;}
			get{return _scline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_Value
		{
			set{ _p_value=value;}
			get{return _p_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BR_Value
		{
			set{ _br_value=value;}
			get{return _br_value;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RecordTestOp
		{
			set{ _recordtestop=value;}
			get{return _recordtestop;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineID
		{
			set{ _machineid=value;}
			get{return _machineid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MachineName
		{
			set{ _machinename=value;}
			get{return _machinename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TestResult
		{
			set{ _testresult=value;}
			get{return _testresult;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ID_key
		{
			set{ _id_key=value;}
			get{return _id_key;}
		}
		#endregion Model

	}
}

