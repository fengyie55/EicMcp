using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// LabVerify:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LabVerify
	{
		public LabVerify()
		{}
		#region Model
		private decimal _lbv_id;
		private string _orm_id;
		private string _pb_id;
		private string _isverify;
		private string _userid;
		private string _labpic_id;
		/// <summary>
		/// 
		/// </summary>
		public decimal LBV_ID
		{
			set{ _lbv_id=value;}
			get{return _lbv_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Orm_ID
		{
			set{ _orm_id=value;}
			get{return _orm_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pb_ID
		{
			set{ _pb_id=value;}
			get{return _pb_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsVerify
		{
			set{ _isverify=value;}
			get{return _isverify;}
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
		public string LabPic_ID
		{
			set{ _labpic_id=value;}
			get{return _labpic_id;}
		}
		#endregion Model

	}
}

