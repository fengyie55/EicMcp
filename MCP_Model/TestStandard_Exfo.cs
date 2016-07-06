using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class TestStandard_Exfo
	{
		public TestStandard_Exfo()
		{}
		#region Model
		private string _type;
		private string _wave;
		private string _il_min;
		private string _il_max;
		private string _rl_min;
		private string _rl_max;
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
		public string Wave
		{
			set{ _wave=value;}
			get{return _wave;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_Min
		{
			set{ _il_min=value;}
			get{return _il_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IL_Max
		{
			set{ _il_max=value;}
			get{return _il_max;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RL_Min
		{
			set{ _rl_min=value;}
			get{return _rl_min;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RL_Max
		{
			set{ _rl_max=value;}
			get{return _rl_max;}
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

