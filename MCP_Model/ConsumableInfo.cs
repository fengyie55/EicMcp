using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// ConsumableInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ConsumableInfo
	{
		public ConsumableInfo()
		{}
		#region Model
		private decimal _csm_id;
		private string _c_type;
		private string _c_barcode;
		private string _c_name;
		private string _c_aliasname;
		private string _c_model;
		private string _c_address;
		private string _c_function;
		private string _c_lifetime;
		private string _c_lifeunit;
		private string _c_safestock;
		private string _c_unit;
		private string _c_picture;
		private string _c_manufacturer;
		private string _c_official_website;
		private string _c_tel;
		private string _c_after_sale;
		private string _c_purchascycle;
		private string _c_remarks;
        private string _Stock;
		/// <summary>
		/// 
		/// </summary>
		public decimal Csm_ID
		{
			set{ _csm_id=value;}
			get{return _csm_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Type
		{
			set{ _c_type=value;}
			get{return _c_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Barcode
		{
			set{ _c_barcode=value;}
			get{return _c_barcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Name
		{
			set{ _c_name=value;}
			get{return _c_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_AliasName
		{
			set{ _c_aliasname=value;}
			get{return _c_aliasname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Model
		{
			set{ _c_model=value;}
			get{return _c_model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Address
		{
			set{ _c_address=value;}
			get{return _c_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Function
		{
			set{ _c_function=value;}
			get{return _c_function;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Lifetime
		{
			set{ _c_lifetime=value;}
			get{return _c_lifetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_LifeUnit
		{
			set{ _c_lifeunit=value;}
			get{return _c_lifeunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_SafeStock
		{
			set{ _c_safestock=value;}
			get{return _c_safestock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Unit
		{
			set{ _c_unit=value;}
			get{return _c_unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Picture
		{
			set{ _c_picture=value;}
			get{return _c_picture;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Manufacturer
		{
			set{ _c_manufacturer=value;}
			get{return _c_manufacturer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Official_Website
		{
			set{ _c_official_website=value;}
			get{return _c_official_website;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Tel
		{
			set{ _c_tel=value;}
			get{return _c_tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_After_Sale
		{
			set{ _c_after_sale=value;}
			get{return _c_after_sale;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_PurchasCycle
		{
			set{ _c_purchascycle=value;}
			get{return _c_purchascycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string C_Remarks
		{
			set{ _c_remarks=value;}
			get{return _c_remarks;}
		}

        /// <summary>
        /// 库存数量
        /// </summary>
        public string Stock
        {
            set { _Stock = value; }
            get { return _Stock; }
        }

		#endregion Model

	}
}

