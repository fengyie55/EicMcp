using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ImageList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ImageList
	{
		public ImageList()
		{}
		#region Model
		private decimal _id;
		private string _name;
		private string _remarks;
		private byte[] _im;
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
		/// <summary>
		/// 
		/// </summary>
		public byte[] Im
		{
			set{ _im=value;}
			get{return _im;}
		}
		#endregion Model

	}
}

