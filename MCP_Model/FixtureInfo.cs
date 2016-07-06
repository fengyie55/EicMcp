using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// FixtureInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FixtureInfo
	{
		public FixtureInfo()
		{}
		#region Model
		private decimal _fay_id;
		private string _assembly_barcode;
		private string _assembly_name;
		private string _barcode;
		private string _name;
		private string _alias;
		private string _makedev;
		private string _model;
		private string _functionremarks;
		private string _safecount;
		private string _unit;
		private string _versions;
		private string _up_id;
		private string _drawingpatch;
		private string _pic_id;
		private string _correlation_id;
		private string _remarks;
		
        /// <summary>
		///  治具ＩＤ
		/// </summary>
		public decimal FAY_ID
		{
			set{ _fay_id=value;}
			get{return _fay_id;}
		}
		/// <summary>
		/// 总成编号
		/// </summary>
		public string Assembly_BarCode
		{
			set{ _assembly_barcode=value;}
			get{return _assembly_barcode;}
		}
		/// <summary>
		/// 总成名称
		/// </summary>
		public string Assembly_Name
		{
			set{ _assembly_name=value;}
			get{return _assembly_name;}
		}
		/// <summary>
		/// 　治具编号
		/// </summary>
		public string BarCode
		{
			set{ _barcode=value;}
			get{return _barcode;}
		}
		/// <summary>
		/// 治具名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 别名
		/// </summary>
		public string Alias
		{
			set{ _alias=value;}
			get{return _alias;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Makedev
		{
			set{ _makedev=value;}
			get{return _makedev;}
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
		/// 功能描述
		/// </summary>
		public string FunctionRemarks
		{
			set{ _functionremarks=value;}
			get{return _functionremarks;}
		}
		/// <summary>
		/// 安全库存
		/// </summary>
		public string SafeCount
		{
			set{ _safecount=value;}
			get{return _safecount;}
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
		/// 版本
		/// </summary>
		public string Versions
		{
			set{ _versions=value;}
			get{return _versions;}
		}
		/// <summary>
		/// 更新ＩＤ
		/// </summary>
		public string Up_ID
		{
			set{ _up_id=value;}
			get{return _up_id;}
		}
		/// <summary>
		/// 图纸路径
		/// </summary>
		public string DrawingPatch
		{
			set{ _drawingpatch=value;}
			get{return _drawingpatch;}
		}
		/// <summary>
		/// 照片路径
		/// </summary>
		public string Pic_ID
		{
			set{ _pic_id=value;}
			get{return _pic_id;}
		}
		/// <summary>
		/// 　关联设备
		/// </summary>
		public string Correlation_ID
		{
			set{ _correlation_id=value;}
			get{return _correlation_id;}
		}
		/// <summary>
		/// 　备注
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

