using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class TestStandard_3D
	{
		public TestStandard_3D()
		{}
		#region Model
		private string _type;
		private string _rco_min;
		private string _rco_max;
		private string _ao_min;
		private string _ao_max;
		private string _fh_min;
		private string _fh_max;
		private string _ae_min;
		private string _ae_max;
		private string _orderid;
		private decimal _id_key;
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCO_Min
		{
			set{ _rco_min=value;}
			get{return _rco_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RCO_Max
		{
			set{ _rco_max=value;}
			get{return _rco_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AO_Min
		{
			set{ _ao_min=value;}
			get{return _ao_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AO_Max
		{
			set{ _ao_max=value;}
			get{return _ao_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FH_Min
		{
			set{ _fh_min=value;}
			get{return _fh_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FH_Max
		{
			set{ _fh_max=value;}
			get{return _fh_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AE_Min
		{
			set{ _ae_min=value;}
			get{return _ae_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AE_Max
		{
			set{ _ae_max=value;}
			get{return _ae_max;}
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

