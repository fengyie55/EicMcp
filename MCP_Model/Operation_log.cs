using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Operation_log:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Operation_log
	{
		public Operation_log()
		{}
		#region Model
		private decimal _r_id;
		private string _username;
		private string _operation;
		private string _remarks;
		private DateTime? _datetime;
		/// <summary>
		/// 
		/// </summary>
		public decimal R_ID
		{
			set{ _r_id=value;}
			get{return _r_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Operation
		{
			set{ _operation=value;}
			get{return _operation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateTime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		#endregion Model

	}
}

