using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class WorkOrder
	{
		public WorkOrder()
		{}
		#region Model
		private string _orderid;
		private string _client;
		private string _productname;
		private string _model;
		private string _count;
        private E_InspectMethod _inspectmethod;
		private E_InspectType _inspecttype;
		private string _deliverydate;
		private string _labeltype;
		private string _modelno;
		private string _cablecordage;
		private string _nexanssap;
		private string _length;
		private string _datat;
		private string _qty;
		private string _workshop;
		private string _state;
        private decimal _id_key;
		
		/// <summary>
		/// 工单单号
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}

        /// <summary>
        /// 客户
        /// </summary>
		public string Client
		{
			set{ _client=value;}
			get{return _client;}
		}
		/// <summary>
		/// 品名
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 规格
		/// </summary>
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 工单总量
		/// </summary>
		public string Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 检测方法（线材类型）
		/// </summary>
		public E_InspectMethod InspectMethod
		{
			set{ _inspectmethod=value;}
			get{return _inspectmethod;}
		}
		/// <summary>
		/// 检测类型（3D 或 Exfo 或3D与Exfo）
		/// </summary>
		public E_InspectType InspectType
		{
			set{ _inspecttype=value;}
			get{return _inspecttype;}
		}
		/// <summary>
		/// 出货日期
		/// </summary>
		public string DeliveryDate
		{
			set{ _deliverydate=value;}
			get{return _deliverydate;}
		}
		/// <summary>
		/// 标签类型
		/// </summary>
		public string LabelType
		{
			set{ _labeltype=value;}
			get{return _labeltype;}
		}
		/// <summary>
		/// ModelNo
		/// </summary>
		public string ModelNo
		{
			set{ _modelno=value;}
			get{return _modelno;}
		}
		/// <summary>
		/// CableCordage
		/// </summary>
		public string CableCordage
		{
			set{ _cablecordage=value;}
			get{return _cablecordage;}
		}
		/// <summary>
		/// NexansSap
		/// </summary>
		public string NexansSap
		{
			set{ _nexanssap=value;}
			get{return _nexanssap;}
		}
		/// <summary>
		/// Length
		/// </summary>
		public string Length
		{
			set{ _length=value;}
			get{return _length;}
		}
		/// <summary>
		/// DataT
		/// </summary>
		public string DataT
		{
			set{ _datat=value;}
			get{return _datat;}
		}
		/// <summary>
		/// Qty
		/// </summary>
		public string Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 生产车间
		/// </summary>
		public string Workshop
		{
			set{ _workshop=value;}
			get{return _workshop;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
        /// <summary>
        ///  ID_Key
        /// </summary>
        public decimal ID_Key
        {
            set { _id_key = value; }
            get { return _id_key; }
        }


		
		#endregion Model

	}
}

