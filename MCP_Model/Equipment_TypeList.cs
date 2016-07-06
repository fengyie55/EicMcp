using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Equipment_TypeList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Equipment_TypeList
	{
		public Equipment_TypeList()
		{}
		#region Model
		private decimal? _id;
		private string _type;
		private string _value;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public decimal? ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 值
		/// </summary>
		public string Value
		{
			set{ _value=value;}
			get{return _value;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

