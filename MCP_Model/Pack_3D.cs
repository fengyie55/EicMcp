﻿using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class Pack_3D
	{
		public Pack_3D()
		{}
		#region Model
		private string _sn;
		private string _name;
		private string _type;
		private string _result;
		private string _curvature;
		private string _curvature_result;
		private string _spherical;
		private string _spherical_result;
		private string _planar;
		private string _planar_result;
		private string _apex_offset;
		private string _apex_offset_result;
		private string _bearing;
		private string _bearing_result;
		private string _apex_angle;
		private string _apex_angle_result;
		private string _tilt_offset;
		private string _tilt_offset_result;
		private string _tilt_angle;
		private string _tilt_angle_result;
		private string _keyerror;
		private string _keyerror_result;
		private string _fiberrq;
		private string _fiberrq_result;
		private string _fiberra;
		private string _fiberra_result;
		private string _ferrulerq;
		private string _ferrulerq_result;
		private string _ferrulera;
		private string _ferrulera_result;
		private string _diameter;
		private string _diameter_result;
		private string _test_date;
		private string _test_time;
		private string _d;
		private string _e;
		private string _f;
		private string _a;
		private string _packlot;
		private string _packdate;
		private string _customername;
		private string _clientsn;
		private string _batchno;
		private string _orderid;
		private decimal _id_key;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
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
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Curvature
		{
			set{ _curvature=value;}
			get{return _curvature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Curvature_Result
		{
			set{ _curvature_result=value;}
			get{return _curvature_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spherical
		{
			set{ _spherical=value;}
			get{return _spherical;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Spherical_Result
		{
			set{ _spherical_result=value;}
			get{return _spherical_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Planar
		{
			set{ _planar=value;}
			get{return _planar;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Planar_Result
		{
			set{ _planar_result=value;}
			get{return _planar_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Apex_Offset
		{
			set{ _apex_offset=value;}
			get{return _apex_offset;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Apex_Offset_Result
		{
			set{ _apex_offset_result=value;}
			get{return _apex_offset_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Bearing
		{
			set{ _bearing=value;}
			get{return _bearing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Bearing_Result
		{
			set{ _bearing_result=value;}
			get{return _bearing_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Apex_Angle
		{
			set{ _apex_angle=value;}
			get{return _apex_angle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Apex_Angle_Result
		{
			set{ _apex_angle_result=value;}
			get{return _apex_angle_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tilt_Offset
		{
			set{ _tilt_offset=value;}
			get{return _tilt_offset;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tilt_Offset_Result
		{
			set{ _tilt_offset_result=value;}
			get{return _tilt_offset_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tilt_Angle
		{
			set{ _tilt_angle=value;}
			get{return _tilt_angle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tilt_Angle_Result
		{
			set{ _tilt_angle_result=value;}
			get{return _tilt_angle_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyError
		{
			set{ _keyerror=value;}
			get{return _keyerror;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string KeyError_Result
		{
			set{ _keyerror_result=value;}
			get{return _keyerror_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FiberRq
		{
			set{ _fiberrq=value;}
			get{return _fiberrq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FiberRq_Result
		{
			set{ _fiberrq_result=value;}
			get{return _fiberrq_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FiberRa
		{
			set{ _fiberra=value;}
			get{return _fiberra;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FiberRa_Result
		{
			set{ _fiberra_result=value;}
			get{return _fiberra_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FerruleRq
		{
			set{ _ferrulerq=value;}
			get{return _ferrulerq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FerruleRq_Result
		{
			set{ _ferrulerq_result=value;}
			get{return _ferrulerq_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FerruleRa
		{
			set{ _ferrulera=value;}
			get{return _ferrulera;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FerruleRa_Result
		{
			set{ _ferrulera_result=value;}
			get{return _ferrulera_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Diameter
		{
			set{ _diameter=value;}
			get{return _diameter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Diameter_Result
		{
			set{ _diameter_result=value;}
			get{return _diameter_result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Test_Date
		{
			set{ _test_date=value;}
			get{return _test_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Test_Time
		{
			set{ _test_time=value;}
			get{return _test_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string D
		{
			set{ _d=value;}
			get{return _d;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string E
		{
			set{ _e=value;}
			get{return _e;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F
		{
			set{ _f=value;}
			get{return _f;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string A
		{
			set{ _a=value;}
			get{return _a;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PackLot
		{
			set{ _packlot=value;}
			get{return _packlot;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PackDate
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
		public string ClientSN
		{
			set{ _clientsn=value;}
			get{return _clientsn;}
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

