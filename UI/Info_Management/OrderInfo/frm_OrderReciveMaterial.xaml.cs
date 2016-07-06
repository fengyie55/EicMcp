using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace UI
{
    /// <summary>
    /// frm_OrderReciveMaterial.xaml 的交互逻辑
    /// </summary>
    public partial class frm_OrderReciveMaterial 
    {
        public frm_OrderReciveMaterial()
        {
            InitializeComponent();
        }
        
       Maticsoft.Model.sysUser _WTT_User_Receive = new Maticsoft.Model.sysUser();
       Maticsoft.BLL.Material_Receive _M_MaterReceive = new Maticsoft.BLL.Material_Receive();
       Maticsoft.Model.Material_Receive _MRce = null;

        double _wantCount = 0, _yetCount = 0;
        string _WTT_Orm_ID = "";
        decimal _WTT_Rece_ID = 0;
        Maticsoft.Model.WorkStation _WTT_WK = new Maticsoft.Model.WorkStation();

        /// <summary>
        /// 工单物料清单
        /// </summary>
        public DataSet MaterialList { get; set; }

        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID { get; set; }

        //
        //窗体初始化
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // DataSet temds =  PressMaterialList(_WTT_MaterialList );
            dgv_Source.ItemsSource = MaterialList.Tables[0].DefaultView;

            //加载站别
            Maticsoft.BLL.Workstation _M_Workstation = new Maticsoft.BLL.Workstation();
            cmb_Workstation_Receive.ItemsSource = _M_Workstation.GetListModel("");
            txb_OrderID.Text = OrderID;  
        }      

        //
        //选择物料
        //
        private void dgv_Source_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txb_AliasName.Text = "";
                txb_AliasName.IsEnabled = false;
                btn_Save_AliasName.Visibility = System.Windows.Visibility.Hidden;
                lab_Emphasis.Visibility = System.Windows.Visibility.Hidden;
                //

               // int selectIndex = dgv_Source.SelectedIndex;
                DataRowView dr = (DataRowView)dgv_Source.SelectedItem;
                _WTT_Orm_ID = dr["Orm_ID"].ToString();

                //
                txb_AliasName.Text = dr["别名"].ToString();
                txb_MaterialNum.Text = dr["料号"].ToString();
                txb_ProductName.Text = dr["品名"].ToString();
                txb_Model.Text = dr["规格"].ToString();
                lab_Unit.Content = dr["单位"].ToString();

                
                double.TryParse(dr["需领数量"].ToString(),out _wantCount);   //需领用量
                txb_WantCount.Text = _wantCount.ToString("0.00");
                _yetCount = _M_MaterReceive.Get_Count(_WTT_Orm_ID);         //已领用量
                txb_YetCount.Text = _yetCount.ToString("0.00");
              
                //
                DataSet temds = _M_MaterReceive.GetList("Orm_ID = '" + _WTT_Orm_ID + "'");
                dgv_Receive_Record.ItemsSource = temds.Tables[0].DefaultView;

                // 判断是否是重点管控料件
                string product = dr["品名"].ToString();
                if (product.Contains("FERRULE"))
                {
                    lab_Emphasis.Visibility = System.Windows.Visibility.Visible;
                    if (txb_AliasName.Text == "")
                    {
                        txb_AliasName.IsEnabled = true;
                        btn_Save_AliasName.Visibility = System.Windows.Visibility.Visible;                       
                        My_MessageBox.My_MessageBox_Message("重点管控料件,出现此提示的原因是此料件未设置别名；\r\n请在别名设置窗口中设置别名后点击保存！");
                    }                  
                }
                //
                Set_IsEn(false, true);                
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Erry(ex.Message + "\r\n弹出此错题的原因是您选择的列为空列！"); }
        }


        //
        //领料—工号
        //
        private void txb_JobNumber_Receive_KeyUp(object sender, KeyEventArgs e)
        {
            Maticsoft.BLL.sysUser _M_User = new Maticsoft.BLL.sysUser();
            if (e.Key == Key.Enter && txb_JobNumber_Receive.IsFocused == true && txb_JobNumber_Receive.Text != ""
                && txb_JobNumber_Receive.Text != "002222")
            {
                 _WTT_User_Receive = _M_User.GetModel(txb_JobNumber_Receive.Text.Trim());
                if (_WTT_User_Receive != null)
                {
                    int tem = -1; int.TryParse(_WTT_User_Receive.Workstation, out tem);                   
                    if (tem > -1)
                    { 
                        cmb_Workstation_Receive.SelectedIndex = tem - 1;
                        _WTT_WK = (Maticsoft.Model.WorkStation)cmb_Workstation_Receive.SelectedItem;
                    }
                    txb_UserName_Receive.Text = _WTT_User_Receive.UserName;
                    txb_Client.Focus();
                }
                else { txb_JobNumber_Receive.SelectAll(); }
            }
        }

        //
        //供应商编号
        //
        private void txb_MaterialPath_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Maticsoft.BLL.Material_Receive _M_Material_Receive = new Maticsoft.BLL.Material_Receive();
                string dt = DateTime.Now.ToString();
                if (txb_Count.Text != "" && _WTT_User_Receive != null)
                {
                    Maticsoft.Model.Material_Receive _Material_receive = new Maticsoft.Model.Material_Receive()
                    {
                        Client = txb_Client.Text.Trim(),
                        ClientNum = txb_MaterialPath.Text.Trim(),
                        Count = txb_Count.Text.Trim(),
                        Orm_ID = _WTT_Orm_ID,
                        UserID = txb_JobNumber_Receive.Text.Trim(),
                        WorkStationID = _WTT_WK.Wo_ID.ToString(),
                        DataTime = DateTime.Now
                    };
                    _M_Material_Receive.Add(_Material_receive);
                    
                    //
                    txb_MaterialPath.Text = "";
                    DataSet temds = _M_MaterReceive.GetList("Orm_ID = '" + _WTT_Orm_ID + "'");
                    dgv_Receive_Record.ItemsSource = temds.Tables[0].DefaultView;
                   
                    _yetCount = _M_MaterReceive.Get_Count(_WTT_Orm_ID);         //已领用量
                    txb_YetCount.Text = _yetCount.ToString("0.00");
                }
                else { My_MessageBox.My_MessageBox_Message("数量未设置，或领用人未验证，完成后重试！ "); }
            }
        }

        //
        //供应商
        //
        private void txb_Client_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                txb_Count.Focus();
            }
        }

        /// <summary>
        /// 控件启用状态
        /// </summary>
        /// <param name="btn_isEn">btn控件</param>
        /// <param name="txb_isEn">txb控件</param>
        private void Set_IsEn(bool btn_isEn ,bool txb_isEn )
        {
            //btn
            btn_Add.IsEnabled = btn_isEn;
            btn_Edit.IsEnabled = btn_isEn;
            btn_Delete.IsEnabled = btn_isEn;
            btn_Save.IsEnabled = btn_isEn;
            //txb
            txb_Client.IsEnabled = txb_isEn;
            txb_MaterialPath.IsEnabled = txb_isEn;
            txb_Count.IsEnabled = txb_isEn;
            txb_UserName_Receive.IsEnabled = txb_isEn;
            cmb_Workstation_Receive.IsEditable = txb_isEn;

        }
        //
        //领取数量
        //
        private void txb_Count_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txb_MaterialPath.Focus();
            }
        }
         
        //
        //领取记录
        //
        private void dgv_Receive_Record_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {                           
                Set_IsEn(true, false);
                DataRowView dr = (DataRowView)dgv_Receive_Record.SelectedItem;
               
                decimal.TryParse( dr["Re_ID"].ToString(),out _WTT_Rece_ID);
                 _MRce = _M_MaterReceive.GetModel(_WTT_Rece_ID);
                if (_MRce != null)
                {
                    txb_Client.Text = _MRce.Client;
                    txb_MaterialPath.Text = _MRce.ClientNum;
                    txb_Count.Text = _MRce.Count;                    
                }

            }
            catch 
            { 
               // My_MessageBox.My_MessageBox_Erry(ex.Message + "\r\n弹出此错题的原因是您选择的列为空列！"); 
            }
        }

        //
        //编辑
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Set_IsEn(true, true);
        }

        //
        //保存
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (txb_UserName_Receive.Text != "")
            {
                Maticsoft.BLL.Material_Receive _M_Material_Receive = new Maticsoft.BLL.Material_Receive();
                string dt = DateTime.Now.ToString();
                if (txb_Count.Text != "" && _WTT_User_Receive != null)
                {
                    Maticsoft.Model.Material_Receive _Material_receive = new Maticsoft.Model.Material_Receive()
                    {
                        Client = txb_Client.Text.Trim(),
                        ClientNum = txb_MaterialPath.Text.Trim(),
                        Count = txb_Count.Text.Trim(),
                        Orm_ID = _WTT_Orm_ID,
                        UserID = txb_JobNumber_Receive.Text.Trim(),
                        WorkStationID = _WTT_WK.Wo_ID.ToString(),
                        DataTime = DateTime.Now,
                        Re_ID =  _WTT_Rece_ID
                    };
                    _M_Material_Receive.Update(_Material_receive);

                    //
                    txb_MaterialPath.Text = "";
                    DataSet temds = _M_MaterReceive.GetList("Orm_ID = '" + _WTT_Orm_ID + "'");
                    dgv_Receive_Record.ItemsSource = temds.Tables[0].DefaultView;                   
                    _yetCount = _M_MaterReceive.Get_Count(_WTT_Orm_ID);         //已领用量
                    txb_YetCount.Text = _yetCount.ToString("0.00");
                }
                else { My_MessageBox.My_MessageBox_Message("数量未设置，或领用人未验证，完成后重试！ "); }
            }
            else
            {
                My_MessageBox.My_MessageBox_Erry("请先输入修改人的工号！");
            }
        }

        //
        //选择站别
        //
        private void cmb_Workstation_Receive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_Workstation_Receive.SelectedItem != null)
            {
                _WTT_WK = (Maticsoft.Model.WorkStation)cmb_Workstation_Receive.SelectedItem;
            }
        }

        //
        //设置物料别名
        //
        private void btn_Save_AliasName_Click(object sender, RoutedEventArgs e)
        {          
            Maticsoft.BLL.MaterialInfo _M_MaterialInfo = new Maticsoft.BLL.MaterialInfo();
            Maticsoft.Model.MaterialInfo _MaterialInfo = new Maticsoft.Model.MaterialInfo()
            {
                AliasName = txb_AliasName.Text,
                MaterialID = txb_MaterialNum.Text,
                Model = txb_Model.Text,
                ProductName = txb_ProductName.Text,
                Type = "",
                Unit = lab_Unit.Content.ToString()
            };

            if (_M_MaterialInfo.Update(_MaterialInfo))
            {
                My_MessageBox.My_MessageBox_Message("添加成功！");
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("添加失败！");
            }
        }

        //
        //数量输入验证
        //
        private void txb_Count_KeyUp(object sender, KeyEventArgs e)
        {
            double count = 0;
            if (double.TryParse(txb_Count.Text.Trim(), out count))
            {
                count = count + _yetCount;
                if (_wantCount < count)
                {
                    txb_Count.SelectAll();
                    My_MessageBox.My_MessageBox_Message("领取数量 不能大于 需领数量！ 请重新输入");
                }
            }
        }

        //
        //删除
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.BLL.Material_Receive _Mr = new Maticsoft.BLL.Material_Receive();
            _Mr.Delete(_MRce.Re_ID);
            //
            DataSet temds = _M_MaterReceive.GetList("Orm_ID = '" + _WTT_Orm_ID + "'");
            dgv_Receive_Record.ItemsSource = temds.Tables[0].DefaultView;
        }
    }
}
