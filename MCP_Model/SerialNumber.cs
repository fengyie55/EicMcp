using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class SerialNumber
	{
		public SerialNumber()
		{}
		#region Model
		private string _sn;
		private string _type;
		private string _state;
		private string _batchno;
		private string _orderid;	
       


		/// <summary>
		/// 编号
		/// </summary>
		public string SN
		{
			set{ _sn=value;}
			get{return _sn;}
		}
		/// <summary>
		/// 类别
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
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
		/// 包装批号
		/// </summary>
		public string BatchNO
		{
			set{ _batchno=value;}
			get{return _batchno;}
		}
		/// <summary>
		/// 工单单号
		/// </summary>
		public string OrderID
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		
		#endregion Model

        public override string ToString()
        {
            string tem = "";
            tem += " 条码" + _sn;
            tem+=" 工单："+_orderid;
            tem += " 批号：" + _batchno;
            tem += " 类型：" + _type;
            tem += " 状态：" + _state;
            return tem;
        }
	}
}

