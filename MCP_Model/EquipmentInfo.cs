using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// EquipmentInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EquipmentInfo
	{
		public EquipmentInfo()
		{}
		#region Model
		private decimal _eqp_id;
		private string _assettype;
		private string _department;
		private string _installationsite;
		private string _addmode;
		private DateTime? _verifydate;
		private string _verifyinterval;
		private DateTime? _maintenancedate;
		private string _maintenanceinterval;
		private DateTime? _logindate;
		private string _usefullife;
		private string _deliveryuser;
		private string _checkuser;
		private string _careuser;
		private string _assetnum;
		private string _assetname;
		private string _aliasname;
		private string _makenum;
		private string _equipentmodel;
		private string _specification;
		private string _functiondescription;
		private string _supplier;
		private DateTime? _manufacturingdate;
		private string _officialwedsite;
		private string _suppliertel;
		private string _afersaletel;
		private string _state;
		private string _count;
		private string _unit;
		private string _efficiency;
		private string _equipentoee;
		private string _photopatch;
		private string _safetyspecification;
		private string _oi;
		private string _chechsheet;
		
		/// <summary>
		///  资产类别
		/// </summary>
		public string AssetType
		{
			set{ _assettype=value;}
			get{return _assettype;}
		}
		/// <summary>
		///  所属部门
		/// </summary>
		public string Department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 安装位置
		/// </summary>
		public string InstallationSite
		{
			set{ _installationsite=value;}
			get{return _installationsite;}
		}
        /// <summary>
        /// 状态
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 财产编号
        /// </summary>
        public string AssetNum
        {
            set { _assetnum = value; }
            get { return _assetnum; }
        }
        /// <summary>
        /// 资产名称
        /// </summary>
        public string AssetName
        {
            set { _assetname = value; }
            get { return _assetname; }
        }
        /// <summary>
        /// 别名
        /// </summary>
        public string AliasName
        {
            set { _aliasname = value; }
            get { return _aliasname; }
        }
        /// <summary>
        /// 制造编号
        /// </summary>
        public string MakeNum
        {
            set { _makenum = value; }
            get { return _makenum; }
        }
        /// <summary>
        /// 设备型号
        /// </summary>
        public string EquipentModel
        {
            set { _equipentmodel = value; }
            get { return _equipentmodel; }
        }
        /// <summary>
        /// 设备规格
        /// </summary>
        public string Specification
        {
            set { _specification = value; }
            get { return _specification; }
        }
        /// <summary>
        /// 功能描述
        /// </summary>
        public string FunctionDescription
        {
            set { _functiondescription = value; }
            get { return _functiondescription; }
        }
        /// <summary>
        /// 效率
        /// </summary>
        public string Efficiency
        {
            set { _efficiency = value; }
            get { return _efficiency; }
        }
        /// <summary>
        /// 设备OEE
        /// </summary>
        public string EquipentOEE
        {
            set { _equipentoee = value; }
            get { return _equipentoee; }
        }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
		/// <summary>
		/// 添加方式
		/// </summary>
		public string AddMode
		{
			set{ _addmode=value;}
			get{return _addmode;}
		}
		/// <summary>
		/// 校验日期
		/// </summary>
		public DateTime? VerifyDate
		{
			set{ _verifydate=value;}
			get{return _verifydate;}
		}
		/// <summary>
		/// 校验间隔
		/// </summary>
		public string VerifyInterval
		{
			set{ _verifyinterval=value;}
			get{return _verifyinterval;}
		}
		/// <summary>
		/// 保养日期
		/// </summary>
		public DateTime? MaintenanceDate
		{
			set{ _maintenancedate=value;}
			get{return _maintenancedate;}
		}
		/// <summary>
		/// 保养间隔
		/// </summary>
		public string MaintenanceInterval
		{
			set{ _maintenanceinterval=value;}
			get{return _maintenanceinterval;}
		}
		/// <summary>
		/// 登陆日期
		/// </summary>
		public DateTime? LoginDate
		{
			set{ _logindate=value;}
			get{return _logindate;}
		}
		/// <summary>
		/// 耐用年限
		/// </summary>
		public string UsefulLife
		{
			set{ _usefullife=value;}
			get{return _usefullife;}
		}
		/// <summary>
		/// 交付人员
		/// </summary>
		public string DeliveryUser
		{
			set{ _deliveryuser=value;}
			get{return _deliveryuser;}
		}
		/// <summary>
		/// 验收人员
		/// </summary>
		public string CheckUser
		{
			set{ _checkuser=value;}
			get{return _checkuser;}
		}
		/// <summary>
		/// 保管人员
		/// </summary>
		public string CareUser
		{
			set{ _careuser=value;}
			get{return _careuser;}
		}
		
		/// <summary>
		/// 生产日期
		/// </summary>
		public DateTime? ManufacturingDate
		{
			set{ _manufacturingdate=value;}
			get{return _manufacturingdate;}
		}
		/// <summary>
		/// 官方网址
		/// </summary>
		public string OfficialWedsite
		{
			set{ _officialwedsite=value;}
			get{return _officialwedsite;}
		}
		/// <summary>
		/// 供应商电话
		/// </summary>
		public string SupplierTel
		{
			set{ _suppliertel=value;}
			get{return _suppliertel;}
		}
		/// <summary>
		/// 售后电话
		/// </summary>
		public string AferSaleTel
		{
			set{ _afersaletel=value;}
			get{return _afersaletel;}
		}
		
		/// <summary>
		/// 数量
		/// </summary>
		public string Count
		{
			set{ _count=value;}
			get{return _count;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		
		/// <summary>
		/// 图片路径
		/// </summary>
		public string PhotoPatch
		{
			set{ _photopatch=value;}
			get{return _photopatch;}
		}
		/// <summary>
		/// 安全规程路径
		/// </summary>
		public string SafetySpecification
		{
			set{ _safetyspecification=value;}
			get{return _safetyspecification;}
		}
		/// <summary>
		/// 操作说明书路径
		/// </summary>
		public string OI
		{
			set{ _oi=value;}
			get{return _oi;}
		}
		/// <summary>
		/// 点检表路径
		/// </summary>
		public string ChechSheet
		{
			set{ _chechsheet=value;}
			get{return _chechsheet;}
		}
        /// <summary>
        ///  ID
        /// </summary>
        public decimal Eqp_ID
        {
            set { _eqp_id = value; }
            get { return _eqp_id; }
        }
		#endregion Model

	}
}

