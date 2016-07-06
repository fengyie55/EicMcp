using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class Pack_Exfo
	{
		public Pack_Exfo()
		{}
		#region Model
		private string _testdate;
		private string _partnumber;
		private string _sn;
		private string _result;
		private string _wave;
		private string _il_a;
		private string _refl_a;
		private string _il_b;
		private string _refl_b;
        private string _clientsn;
		private string _orderid;
		private string _batchno;
		private DateTime? _packdate;
		private string _customername;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string TestDate
		{
			set{ _testdate=value;}
			get{return _testdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartNumber
		{
			set{ _partnumber=value;}
			get{return _partnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Wave
		{
			set{ _wave=value;}
			get{return _wave;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_A
		{
			set{ _il_a=value;}
			get{return _il_a;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Refl_A
		{
			set{ _refl_a=value;}
			get{return _refl_a;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_B
		{
			set{ _il_b=value;}
			get{return _il_b;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Refl_B
		{
			set{ _refl_b=value;}
			get{return _refl_b;}
		}

        /// <summary>
        /// 
        /// </summary>
        public string ClientSN
        {
            set { _clientsn = value; }
            get { return _clientsn; }
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
		public string BatchNo
		{
			set{ _batchno=value;}
			get{return _batchno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PackDate
		{
			set{ _packdate=value;}
			get{return _packdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerName
		{
			set{ _customername=value;}
			get{return _customername;}
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

