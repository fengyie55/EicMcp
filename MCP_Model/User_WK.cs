using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// User_WK:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User_WK
	{
		public User_WK()
		{}
		#region Model
		private decimal _wu_id;
		private string _wk;
		private string _classtype;
		private string _jobnum;
		private string _name;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public decimal WU_ID
		{
			set{ _wu_id=value;}
			get{return _wu_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WK
		{
			set{ _wk=value;}
			get{return _wk;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClassType
		{
			set{ _classtype=value;}
			get{return _classtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobNum
		{
			set{ _jobnum=value;}
			get{return _jobnum;}
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
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

