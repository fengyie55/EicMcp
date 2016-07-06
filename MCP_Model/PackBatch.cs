using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class PackBatch
	{
		public PackBatch()
		{}
		#region Model
		private string _batchno;
		private int? _count;
		private string _sackqty;
		private string _boxqty;
		private string _orderid;
		private string _state;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string BatchNo
		{
			set{ _batchno=value;}
			get{return _batchno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SackQty
		{
			set{ _sackqty=value;}
			get{return _sackqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BoxQty
		{
			set{ _boxqty=value;}
			get{return _boxqty;}
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
		public string State
		{
			set{ _state=value;}
			get{return _state;}
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

