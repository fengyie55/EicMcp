using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace UI
{
    class MCP_CS
    {
        //之前定义的 _M_ 标示方法
        public static Maticsoft.BLL.MaterialInfo      _M_MaterialInfo = new Maticsoft.BLL.MaterialInfo();
        public static Maticsoft.BLL.OrderMaterial     _M_OrderMaterial = new Maticsoft.BLL.OrderMaterial();
        public static Maticsoft.BLL.Material_Inject   _M_Material_Inject = new Maticsoft.BLL.Material_Inject();
        public static Maticsoft.BLL.Workstation       _M_Workstation = new Maticsoft.BLL.Workstation();
        public static Maticsoft.BLL.WorkOrder         _M_WorkOrder = new Maticsoft.BLL.WorkOrder();
        public static Maticsoft.BLL.PackBatch         _M_PackBatch = new Maticsoft.BLL.PackBatch();
        public static Maticsoft.BLL.sysUser           _M_User = new Maticsoft.BLL.sysUser();
        public static Maticsoft.BLL.StateList         _M_StateList = new Maticsoft.BLL.StateList();
        public static Maticsoft.BLL.MoveStore_ProductControl 
                                                      _M_MoveStore_ProductControl = new Maticsoft.BLL.MoveStore_ProductControl();
        public static Maticsoft.BLL.OrderLabSet       _M_OrderLabSet = new Maticsoft.BLL.OrderLabSet();
        public static Maticsoft.BLL.LabInfo           _M_labInfo = new Maticsoft.BLL.LabInfo();
        public static Maticsoft.BLL.EquipmentInfo     _M_Equipment = new Maticsoft.BLL.EquipmentInfo();
        public static Maticsoft.BLL.Equipment_TypeList _M_Equipment_TypeList  = new Maticsoft.BLL.Equipment_TypeList();
        public static Maticsoft.BLL.User_3D_Test_Good _M_User_3D_Test_Good = new Maticsoft.BLL.User_3D_Test_Good();
        public static Maticsoft.BLL.User_JDS_Test_Good _M_User_JDS_Test_Good = new Maticsoft.BLL.User_JDS_Test_Good();
       

        //二次定义的 不加 _M_ 直接命名
        public static Maticsoft.BLL.InspectStandard       InseectStandaer = new Maticsoft.BLL.InspectStandard();
        public static Maticsoft.BLL.SerialNumber          SerialNumber = new Maticsoft.BLL.SerialNumber();
        public static Maticsoft.BLL.ImageList             ImageList = new Maticsoft.BLL.ImageList();
        public static Maticsoft.BLL.LabVerify             LabVerify = new Maticsoft.BLL.LabVerify();
        public static Maticsoft.BLL.FixtureList           FixtureList = new Maticsoft.BLL.FixtureList();
        public static Maticsoft.BLL.FixtureInfo           FixtureInfo = new Maticsoft.BLL.FixtureInfo();
        public static Maticsoft.BLL.UserInfo              UserInfo = new Maticsoft.BLL.UserInfo();
        public static Maticsoft.BLL.User_WK               User_WK = new Maticsoft.BLL.User_WK();
        public static Maticsoft.BLL.Operation_log         Operation_Log = new Maticsoft.BLL.Operation_log();
        public static Maticsoft.BLL.Cls_OrderInfo         Cls_OrderInfo = new Maticsoft.BLL.Cls_OrderInfo();
        public static Maticsoft.BLL.ConsumableInfo        ConsumableInfo = new Maticsoft.BLL.ConsumableInfo();
        public static Maticsoft.BLL.Equipment_Maintain    Enquipment_Maintain = new Maticsoft.BLL.Equipment_Maintain();
        public static Maticsoft.BLL.CustomersData         CustomersData = new Maticsoft.BLL.CustomersData();
        public static Maticsoft.BLL.e_Flow                e_Flow = new Maticsoft.BLL.e_Flow();
        public static Maticsoft.BLL.e_ProcessDraw         e_ProcessDraw = new Maticsoft.BLL.e_ProcessDraw();
        public static Maticsoft.BLL.e_ProcessFlow         e_ProcessFlow = new Maticsoft.BLL.e_ProcessFlow();
        public static Maticsoft.BLL.e_Rejects             e_Rejects = new Maticsoft.BLL.e_Rejects();
        public static Maticsoft.BLL.e_ReworkProcess       e_ReworkProcess = new Maticsoft.BLL.e_ReworkProcess();
        public static Maticsoft.BLL.e_Reworks             e_Reworks = new Maticsoft.BLL.e_Reworks();
        public static Maticsoft.BLL.e_Solution            e_Solution = new Maticsoft.BLL.e_Solution();
        public static Maticsoft.BLL.e_WorkOrder           e_WorkOrder = new Maticsoft.BLL.e_WorkOrder();
        



       /*****************************************************       
        * 
        *   Model
        *         
        *****************************************************/
        
        public static Maticsoft.Model.MaterialInfo        _MaterialInfo = new Maticsoft.Model.MaterialInfo();
        public static Maticsoft.Model.OrderMaterial       _OrderMaterial = new Maticsoft.Model.OrderMaterial();       
        public static Maticsoft.Model.Material_Inject     _MaterialInject = new Maticsoft.Model.Material_Inject();
        public static Maticsoft.Model.WorkStation         _WorkStation = new Maticsoft.Model.WorkStation();
        public static Maticsoft.Model.WorkOrder           _WorkOrder = new Maticsoft.Model.WorkOrder();
        public static Maticsoft.Model.sysUser             _User = new Maticsoft.Model.sysUser();
        public static Maticsoft.Model.StateList           _StateList = new Maticsoft.Model.StateList();
        public static Maticsoft.Model.MoveStore_ProductControl
                                                          _MoveStore_ProductControl = new Maticsoft.Model.MoveStore_ProductControl();
        public static Maticsoft.Model.OrderLabSet         _OrderLabSet = new Maticsoft.Model.OrderLabSet();
        public static Maticsoft.Model.LabInfo             _LabInfo = new Maticsoft.Model.LabInfo();
        public static Maticsoft.Model.EquipmentInfo       _Equipment = new Maticsoft.Model.EquipmentInfo();
        public static Maticsoft.Model.E_ConnectionList    _Equipment_TypeList = new Maticsoft.Model.E_ConnectionList();
        public static Maticsoft.Model.User_3D_Test_Good   _User_3D_Test_Good = new Maticsoft.Model.User_3D_Test_Good();
        public static Maticsoft.Model.User_JDS_Test_Good  _User_JDS_Test_Good = new Maticsoft.Model.User_JDS_Test_Good();
        public static Maticsoft.Model.User_WK             _User_WK = new Maticsoft.Model.User_WK();
        public static Maticsoft.Model.UserInfo            _UserInfo = new Maticsoft.Model.UserInfo();
        public static Maticsoft.Model.Operation_log       _Operation_log = new Maticsoft.Model.Operation_log();
        public static Maticsoft.Model.ConsumableInfo      _ConsumableInfo = new Maticsoft.Model.ConsumableInfo();
        public static Maticsoft.Model.Equipment_Maintain _Enquipment_Maintain = new Maticsoft.Model.Equipment_Maintain();
        public static Maticsoft.Model.CustomersData      _CustomersData = new Maticsoft.Model.CustomersData();
        public static Maticsoft.Model.e_Flow             _e_Flow = new Maticsoft.Model.e_Flow();
        public static Maticsoft.Model.e_ProcessDraw      _e_ProcessDraw = new Maticsoft.Model.e_ProcessDraw();
        public static Maticsoft.Model.e_ProcessFlow      _e_ProcessFlow = new Maticsoft.Model.e_ProcessFlow();
        public static Maticsoft.Model.e_Rejects          _e_Rejects = new Maticsoft.Model.e_Rejects();
        public static Maticsoft.Model.e_ReworkProcess    _e_ReworkProcess = new Maticsoft.Model.e_ReworkProcess();
        public static Maticsoft.Model.e_Reworks          _e_Reworks = new Maticsoft.Model.e_Reworks();
        public static Maticsoft.Model.e_Solution         _e_Solution = new Maticsoft.Model.e_Solution();
        public static Maticsoft.Model.e_WorkOrder        _e_WorkOrder = new Maticsoft.Model.e_WorkOrder();




      /*****************************************************       
      * 
      *   Method
      *         
      *****************************************************/

        /// <summary>
        /// 检查非空字段
        /// </summary>
        /// <param name="IsOk">是否为空</param>
        /// <param name="textboxes"></param>
        public static void CheckTextBoxNotNull(ref bool IsOk, params TextBox[] textboxes)
        {
            foreach (TextBox txtBox in textboxes)
            {
                txtBox.Background = Brushes.White;
                if (txtBox.Text.Length <= 0)
                {
                    IsOk = false;
                    txtBox.Background = Brushes.Red;
                }
                else
                {
                    txtBox.Background = Brushes.White;                  
                }
            }
        }

        /// <summary>
        /// 设置Button是否启用编辑
        /// </summary>
        /// <param name="_IsEnabled">是否启用编辑</param>
        /// <param name="buttions"></param>
        public static void SetButtonIsEnabled(bool _IsEnabled,params Button[] buttions)
        {
            foreach(Button button in buttions)
            {
                button.IsEnabled = _IsEnabled;
            }
        }

        /// <summary>
        /// 设置TextBox是否启用编辑
        /// </summary>
        /// <param name="_IsEnabled">是否启用编辑</param>
        /// <param name="buttions"></param>
        public static void SetTextBoxIsEnabled(bool _IsEnabled,bool IsNull , params TextBox[] buttions)
        {
            foreach (TextBox textBox in buttions)
            {
                textBox.IsEnabled = _IsEnabled;
                if (IsNull) textBox.Text = "";
            }
        }


        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="IsEn">是否启用编辑</param>
        /// <param name="IsNull">是否为空</param>
        public static void SetControl(Grid _grd ,bool IsEn, bool IsNull )
        {
            foreach (UIElement c in _grd.Children)
            {
                if (c is TextBox)
                {
                    c.IsEnabled = IsEn;
                    if (IsNull)
                    {
                        ((TextBox)c).Text = "";
                    }
                }
                if (c is ComboBox)
                {
                    c.IsEnabled = IsEn;
                    if (IsNull)
                    {
                        ((ComboBox)c).SelectedIndex = -1;
                    }
                }
                if (c is DatePicker)
                {
                    c.IsEnabled = IsEn;
                    if (IsNull)
                    {
                        ((DatePicker)c).SelectedDate = null;
                    }
                }
            }           
        }

       

        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="IsEn">是否启用编辑</param>
        /// <param name="IsNull">是否为空</param>
        public static void SetControl_Button(Grid _grd, bool IsEn, bool IsNull)
        {
            foreach (UIElement c in _grd.Children)
            {
                if (c is Button)
                {
                    c.IsEnabled = IsEn;
                    if (IsNull)
                    {
                        ((TextBox)c).Text = "";
                    }
                }            
            }
        }



    }
}
