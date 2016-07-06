using System;
namespace Maticsoft.Model
{
    /// <summary>
    /// MultiFiber:实体类
    /// </summary>
    [Serializable]
    public partial class MultiFiber
    {
        public MultiFiber()
        { }
        #region Model
        private int _id;
        private int? _scan_id;
        private DateTime? _scantime;
        private int? _user_id;
        private string _productid;
        private string _connectorid;
        private string _lightmode;
        private string _datasource;
        private string _microscope;
        private string _datafilepath;
        private int? _fibercount;
        private decimal? _fiberpitch;
        private int? _fibersperrow;
        private decimal? _fiberrowpitch;
        private decimal? _rowsverticaloffset;
        private string _fibercaptureshape;
        private string _shape;
        private decimal? _fiberdiameter;
        private string _ferruletype;
        private int? _ferrulecount;
        private string _guidestructuretype;
        private decimal? _guidestructurepitch;
        private decimal? _nominalyangle;
        private string _connectortype;
        private int? _scansegmentsnmb;
        private decimal? _roi_width;
        private decimal? _roi_height;
        private decimal? _avgdiameter;
        private decimal? _extractingdiameter;
        private int? _minmodulation;
        private int? _toppixremove;
        private int? _toppixleft;
        private string _sampletype;
        private int? _multimode;
        private string _measurementconfig;
        private int? _passfail;
        private decimal? _maxfibdiffh;
        private decimal? _maxfibdiffh_min;
        private decimal? _maxfibdiffh_max;
        private string _maxfibdiffh_pass;
        private decimal? _maxfibdiffadjh;
        private decimal? _maxfibdiffadjh_min;
        private decimal? _maxfibdiffadjh_max;
        private string _maxfibdiffadjh_pass;
        private decimal? _maxcoredip;
        private decimal? _maxcoredip_min;
        private decimal? _maxcoredip_max;
        private string _maxcoredip_pass;
        private decimal? _roc_x;
        private decimal? _roc_x_min;
        private decimal? _roc_x_max;
        private string _roc_x_pass;
        private decimal? _roc_y;
        private decimal? _roc_y_min;
        private decimal? _roc_y_max;
        private string _roc_y_pass;
        private decimal? _xendfaceangle;
        private decimal? _xendfaceangle_min;
        private decimal? _xendfaceangle_max;
        private string _xendfaceangle_pass;
        private decimal? _yendfaceangle;
        private decimal? _yendfaceangle_min;
        private decimal? _yendfaceangle_max;
        private string _yendfaceangle_pass;
        private decimal? _flatnessdeviation;
        private decimal? _flatnessdeviation_min;
        private decimal? _flatnessdeviation_max;
        private string _flatnessdeviation_pass;
        private decimal? _fiberprotrusion_min;
        private decimal? _fiberprotrusion_max;
        private string _fiberprotrusion_pass;
        private decimal? _fiberroc_min;
        private decimal? _fiberroc_max;
        private string _fiberroc_pass;
        private byte[] _fiberheight;
        private byte[] _fibercoredip;
        private byte[] _fiberroc;
        private string _testpassed;
        private decimal? _fibarrayxang;
        private decimal? _fibarrayxang_min;
        private decimal? _fibarrayxang_max;
        private string _fibarrayxang_pass;
        private decimal? _fibarrayyang;
        private decimal? _fibarrayyang_min;
        private decimal? _fibarrayyang_max;
        private string _fibarrayyang_pass;
        private decimal? _coplanarity;
        private decimal? _coplanarity_min;
        private decimal? _coplanarity_max;
        private string _coplanarity_pass;
        private decimal? _minuscoplanarity;
        private decimal? _minuscoplanarity_min;
        private decimal? _minuscoplanarity_max;
        private string _minuscoplanarity_pass;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Scan_ID
        {
            set { _scan_id = value; }
            get { return _scan_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ScanTime
        {
            set { _scantime = value; }
            get { return _scantime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? User_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConnectorID
        {
            set { _connectorid = value; }
            get { return _connectorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LightMode
        {
            set { _lightmode = value; }
            get { return _lightmode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DataSource
        {
            set { _datasource = value; }
            get { return _datasource; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Microscope
        {
            set { _microscope = value; }
            get { return _microscope; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DataFilePath
        {
            set { _datafilepath = value; }
            get { return _datafilepath; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FiberCount
        {
            set { _fibercount = value; }
            get { return _fibercount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FiberPitch
        {
            set { _fiberpitch = value; }
            get { return _fiberpitch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FibersPerRow
        {
            set { _fibersperrow = value; }
            get { return _fibersperrow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FiberRowPitch
        {
            set { _fiberrowpitch = value; }
            get { return _fiberrowpitch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RowsVerticalOffset
        {
            set { _rowsverticaloffset = value; }
            get { return _rowsverticaloffset; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FiberCaptureShape
        {
            set { _fibercaptureshape = value; }
            get { return _fibercaptureshape; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Shape
        {
            set { _shape = value; }
            get { return _shape; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FiberDiameter
        {
            set { _fiberdiameter = value; }
            get { return _fiberdiameter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FerruleType
        {
            set { _ferruletype = value; }
            get { return _ferruletype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FerruleCount
        {
            set { _ferrulecount = value; }
            get { return _ferrulecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GuideStructureType
        {
            set { _guidestructuretype = value; }
            get { return _guidestructuretype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GuideStructurePitch
        {
            set { _guidestructurepitch = value; }
            get { return _guidestructurepitch; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? NominalYAngle
        {
            set { _nominalyangle = value; }
            get { return _nominalyangle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConnectorType
        {
            set { _connectortype = value; }
            get { return _connectortype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ScanSegmentsNmb
        {
            set { _scansegmentsnmb = value; }
            get { return _scansegmentsnmb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROI_width
        {
            set { _roi_width = value; }
            get { return _roi_width; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROI_height
        {
            set { _roi_height = value; }
            get { return _roi_height; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AvgDiameter
        {
            set { _avgdiameter = value; }
            get { return _avgdiameter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ExtractingDiameter
        {
            set { _extractingdiameter = value; }
            get { return _extractingdiameter; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? MinModulation
        {
            set { _minmodulation = value; }
            get { return _minmodulation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TopPixRemove
        {
            set { _toppixremove = value; }
            get { return _toppixremove; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TopPixLeft
        {
            set { _toppixleft = value; }
            get { return _toppixleft; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SampleType
        {
            set { _sampletype = value; }
            get { return _sampletype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Multimode
        {
            set { _multimode = value; }
            get { return _multimode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MeasurementConfig
        {
            set { _measurementconfig = value; }
            get { return _measurementconfig; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PassFail
        {
            set { _passfail = value; }
            get { return _passfail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxFibDiffH
        {
            set { _maxfibdiffh = value; }
            get { return _maxfibdiffh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxFibDiffH_min
        {
            set { _maxfibdiffh_min = value; }
            get { return _maxfibdiffh_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxFibDiffH_max
        {
            set { _maxfibdiffh_max = value; }
            get { return _maxfibdiffh_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaxFibDiffH_Pass
        {
            set { _maxfibdiffh_pass = value; }
            get { return _maxfibdiffh_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxFibDiffAdjH
        {
            set { _maxfibdiffadjh = value; }
            get { return _maxfibdiffadjh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxFibDiffAdjH_min
        {
            set { _maxfibdiffadjh_min = value; }
            get { return _maxfibdiffadjh_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxFibDiffAdjH_max
        {
            set { _maxfibdiffadjh_max = value; }
            get { return _maxfibdiffadjh_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaxFibDiffAdjH_Pass
        {
            set { _maxfibdiffadjh_pass = value; }
            get { return _maxfibdiffadjh_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxCoreDip
        {
            set { _maxcoredip = value; }
            get { return _maxcoredip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxCoreDip_min
        {
            set { _maxcoredip_min = value; }
            get { return _maxcoredip_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxCoreDip_max
        {
            set { _maxcoredip_max = value; }
            get { return _maxcoredip_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaxCoreDip_Pass
        {
            set { _maxcoredip_pass = value; }
            get { return _maxcoredip_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROC_X
        {
            set { _roc_x = value; }
            get { return _roc_x; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROC_X_min
        {
            set { _roc_x_min = value; }
            get { return _roc_x_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROC_X_max
        {
            set { _roc_x_max = value; }
            get { return _roc_x_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ROC_X_Pass
        {
            set { _roc_x_pass = value; }
            get { return _roc_x_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROC_Y
        {
            set { _roc_y = value; }
            get { return _roc_y; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROC_Y_min
        {
            set { _roc_y_min = value; }
            get { return _roc_y_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ROC_Y_max
        {
            set { _roc_y_max = value; }
            get { return _roc_y_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ROC_Y_Pass
        {
            set { _roc_y_pass = value; }
            get { return _roc_y_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XEndFaceAngle
        {
            set { _xendfaceangle = value; }
            get { return _xendfaceangle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XEndFaceAngle_min
        {
            set { _xendfaceangle_min = value; }
            get { return _xendfaceangle_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? XEndFaceAngle_max
        {
            set { _xendfaceangle_max = value; }
            get { return _xendfaceangle_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string XEndFaceAngle_Pass
        {
            set { _xendfaceangle_pass = value; }
            get { return _xendfaceangle_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? YEndFaceAngle
        {
            set { _yendfaceangle = value; }
            get { return _yendfaceangle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? YEndFaceAngle_min
        {
            set { _yendfaceangle_min = value; }
            get { return _yendfaceangle_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? YEndFaceAngle_max
        {
            set { _yendfaceangle_max = value; }
            get { return _yendfaceangle_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string YEndFaceAngle_Pass
        {
            set { _yendfaceangle_pass = value; }
            get { return _yendfaceangle_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FlatnessDeviation
        {
            set { _flatnessdeviation = value; }
            get { return _flatnessdeviation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FlatnessDeviation_min
        {
            set { _flatnessdeviation_min = value; }
            get { return _flatnessdeviation_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FlatnessDeviation_max
        {
            set { _flatnessdeviation_max = value; }
            get { return _flatnessdeviation_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FlatnessDeviation_Pass
        {
            set { _flatnessdeviation_pass = value; }
            get { return _flatnessdeviation_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FiberProtrusion_min
        {
            set { _fiberprotrusion_min = value; }
            get { return _fiberprotrusion_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FiberProtrusion_max
        {
            set { _fiberprotrusion_max = value; }
            get { return _fiberprotrusion_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FiberProtrusion_Pass
        {
            set { _fiberprotrusion_pass = value; }
            get { return _fiberprotrusion_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FiberROC_min
        {
            set { _fiberroc_min = value; }
            get { return _fiberroc_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FiberROC_max
        {
            set { _fiberroc_max = value; }
            get { return _fiberroc_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FiberROC_Pass
        {
            set { _fiberroc_pass = value; }
            get { return _fiberroc_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] FiberHeight
        {
            set { _fiberheight = value; }
            get { return _fiberheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] FiberCoreDip
        {
            set { _fibercoredip = value; }
            get { return _fibercoredip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] FiberROC
        {
            set { _fiberroc = value; }
            get { return _fiberroc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestPassed
        {
            set { _testpassed = value; }
            get { return _testpassed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FibArrayXAng
        {
            set { _fibarrayxang = value; }
            get { return _fibarrayxang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FibArrayXAng_min
        {
            set { _fibarrayxang_min = value; }
            get { return _fibarrayxang_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FibArrayXAng_max
        {
            set { _fibarrayxang_max = value; }
            get { return _fibarrayxang_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FibArrayXAng_Pass
        {
            set { _fibarrayxang_pass = value; }
            get { return _fibarrayxang_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FibArrayYAng
        {
            set { _fibarrayyang = value; }
            get { return _fibarrayyang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FibArrayYAng_min
        {
            set { _fibarrayyang_min = value; }
            get { return _fibarrayyang_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? FibArrayYAng_max
        {
            set { _fibarrayyang_max = value; }
            get { return _fibarrayyang_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FibArrayYAng_Pass
        {
            set { _fibarrayyang_pass = value; }
            get { return _fibarrayyang_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Coplanarity
        {
            set { _coplanarity = value; }
            get { return _coplanarity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Coplanarity_min
        {
            set { _coplanarity_min = value; }
            get { return _coplanarity_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Coplanarity_max
        {
            set { _coplanarity_max = value; }
            get { return _coplanarity_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Coplanarity_Pass
        {
            set { _coplanarity_pass = value; }
            get { return _coplanarity_pass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinusCoplanarity
        {
            set { _minuscoplanarity = value; }
            get { return _minuscoplanarity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinusCoplanarity_min
        {
            set { _minuscoplanarity_min = value; }
            get { return _minuscoplanarity_min; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinusCoplanarity_max
        {
            set { _minuscoplanarity_max = value; }
            get { return _minuscoplanarity_max; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinusCoplanarity_Pass
        {
            set { _minuscoplanarity_pass = value; }
            get { return _minuscoplanarity_pass; }
        }
        #endregion Model

    }
}

