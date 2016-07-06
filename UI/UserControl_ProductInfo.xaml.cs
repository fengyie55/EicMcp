using AvalonDock;
using System.Data;

namespace UI
{
    /// <summary>
    /// UserControl_PeoductInfo.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_ProductInfo : DocumentContent
    {
        public UserControl_ProductInfo()
        {
            InitializeComponent();
        }

        #region 全局变量

        Maticsoft.BLL.SerialNumber _M_SerialNumber = new Maticsoft.BLL.SerialNumber();
        Maticsoft.BLL.Pack_3D _M_Pack_3D = new Maticsoft.BLL.Pack_3D();
        Maticsoft.BLL.Pack_Exfo _M_Pack_Exfo = new Maticsoft.BLL.Pack_Exfo();
        Maticsoft.BLL.WorkOrder _M_WorkOrder = new Maticsoft.BLL.WorkOrder();
        Maticsoft.BLL.MultiFiber _M_MultiFiber = new Maticsoft.BLL.MultiFiber();


        #endregion

        //
        //查找数据
        //
        private void btn_Search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataSet ds_3D = new DataSet();
            DataSet ds_Exfo = new DataSet();
            Maticsoft.Model.SerialNumber _SerialNumber = new Maticsoft.Model.SerialNumber();
            Maticsoft.Model.WorkOrder _WorkOrder = new Maticsoft.Model.WorkOrder();
            Maticsoft.BLL.User_3D_Test_Good _M_Test_3D = new Maticsoft.BLL.User_3D_Test_Good();
            //
            _SerialNumber = _M_SerialNumber.GetModel(txb_Barcode.Text.Trim());
            _WorkOrder = _M_WorkOrder.GetModel(_SerialNumber.OrderID);
            //
            if (_WorkOrder.InspectMethod == Maticsoft.Model.E_InspectMethod.MPO检测)
            {
                ds_3D = _M_MultiFiber.Getdata_Method_mpo(_SerialNumber.SN);
            }
            else
            {
                ds_3D = _M_Pack_3D.GetList("ClientSN ='" + _SerialNumber.SN + "'");
            }
            
            ds_Exfo = _M_Pack_Exfo.GetList("ClientSN ='" + _SerialNumber.SN + "'");
            //

            dgv_3D.ItemsSource = ds_3D.Tables[0].DefaultView;
            dgv_Exfo.ItemsSource = ds_Exfo.Tables[0].DefaultView;
            
        }
    }
}
