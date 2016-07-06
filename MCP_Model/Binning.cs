using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class Binning
	{
		public Binning()
		{}
		#region Model
		private string _sackid;
		private string _boxid;
		private string _batchno;
		private string _orderid;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string SackID
		{
			set{ _sackid=value;}
			get{return _sackid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BoxID
		{
			set{ _boxid=value;}
			get{return _boxid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BatchNO
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

