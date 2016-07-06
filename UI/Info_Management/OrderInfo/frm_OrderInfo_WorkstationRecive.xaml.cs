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
using System.Xml;


namespace UI
{
    /// <summary>
    /// frm_OrderInfo_WorkstationRecive.xaml 的交互逻辑
    /// </summary>
    public partial class frm_OrderInfo_WorkstationRecive : Window
    {
        public frm_OrderInfo_WorkstationRecive()
        {
            InitializeComponent();
        }
        #region 全局变量     
        Maticsoft.Model.WorkOrder _WTT_WorkOrder = new Maticsoft.Model.WorkOrder();
        Maticsoft.Model.MoveStore_ProductControl _WTT_MoveStore_ProductControl = new Maticsoft.Model.MoveStore_ProductControl();
        Maticsoft.Model.sysUser _WTT_UserRcecive = new Maticsoft.Model.sysUser();
        Maticsoft.Model.sysUser _WTT_UserSend = new Maticsoft.Model.sysUser();
        Maticsoft.Model.WorkStation _WTT_WK_Receive = new Maticsoft.Model.WorkStation();
        Maticsoft.Model.WorkStation _WTT_WK_Send = new Maticsoft.Model.WorkStation();
        Maticsoft.Model.StateList _WTT_StateList_Receive = new Maticsoft.Model.StateList();
        Maticsoft.Model.StateList _WTT_StateList_Send = new Maticsoft.Model.StateList();
        //
        
        #endregion
        
        
        //
        //工单单号
        //
        private void txb_OrderID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_OrderID.IsFocused == true && txb_OrderID.Text!="")
            {
                _WTT_WorkOrder = MCP_CS._M_WorkOrder.GetModel(txb_OrderID.Text.Trim());
                if (_WTT_WorkOrder != null)
                {
                    txb_Info_ProductName.Text = _WTT_WorkOrder.ProductName;
                    txb_Info_Model.Text = _WTT_WorkOrder.Model;
                    txb_Info_DemandQuantity.Text = _WTT_WorkOrder.Count;
                    showInfo(_WTT_StateList_Receive);
                    txb_Quantity.Focus();                    
                }
                else
                {
                    My_MessageBox.My_MessageBox_Message("未找到此工单的任何信息！\r\n工单："+txb_OrderID.Text.Trim()+"\r\n请联系助理进行录入！");              
                }
            }
        }
        //
        //发料—工号
        //
        private void txb_JobNumber_Send_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && this.txb_JobNumber_Send.IsFocused == true && txb_JobNumber_Send.Text != ""
                && txb_JobNumber_Send.Text != "002222")
            {
                _WTT_UserSend = MCP_CS._M_User.GetModel(txb_JobNumber_Send.Text.Trim());
                if (_WTT_UserSend != null)
                {
                    int tem = -1;
                    int.TryParse(_WTT_UserSend.Workstation, out tem);
                    if (tem > -1) { cmb_Workstation_Send.SelectedIndex = tem - 1; }
                    txb_UserName_Send.Text = _WTT_UserSend.UserName;
                    txb_JobNumber_Receive.Focus();
                }
                else { txb_JobNumber_Send.SelectAll(); }
            }            
        }

        //
        //领料—工号
        //
        private void txb_JobNumber_Receive_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_JobNumber_Receive.IsFocused == true && txb_JobNumber_Receive.Text != "" 
                && txb_JobNumber_Receive.Text != "002222")
            {
                _WTT_UserRcecive = MCP_CS._M_User.GetModel(txb_JobNumber_Receive.Text.Trim());
                if (_WTT_UserRcecive != null)
                {
                    int tem = -1;
                    int.TryParse(_WTT_UserRcecive.Workstation, out tem);
                    if (tem > -1) { cmb_Workstation_Receive.SelectedIndex = tem - 1; }
                    txb_UserName_Receive.Text = _WTT_UserRcecive.UserName;
                    txb_OrderID.Focus();
                }
                else { txb_JobNumber_Receive.SelectAll(); }                               
            }            
        }

        //
        //窗体载入
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_Workstation_Send.ItemsSource = MCP_CS._M_Workstation.GetModelList("");
            cmb_Workstation_Receive.ItemsSource = MCP_CS._M_Workstation.GetModelList("");
            IsEn(false, true);
        }

        //
        //发料站别—改变站别
        //
        private void cmb_Workstation_Send_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _WTT_WK_Send = (Maticsoft.Model.WorkStation)cmb_Workstation_Send.SelectedItem;
                cmb_State_Send.ItemsSource = MCP_CS._M_StateList.GetModelList("Wk_ID='" + _WTT_WK_Send.Wo_ID + "'");
                if (cmb_State_Send.Items.Count > 0) { cmb_State_Send.SelectedIndex = 0; }             
            }
            catch (Exception) { throw; }
        }

        //
        //领料站别—改变站别
        //
        private void cmb_Workstation_Receive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _WTT_WK_Receive = (Maticsoft.Model.WorkStation)cmb_Workstation_Receive.SelectedItem;
                cmb_State_Receive.ItemsSource = MCP_CS._M_StateList.GetModelList("Wk_ID='" + _WTT_WK_Receive.Wo_ID + "'");
                if (cmb_State_Receive.Items.Count > 0) { cmb_State_Receive.SelectedIndex = 0; }       
            }
            catch (Exception) { throw; }
        }

        

        //
        //状态——Send
        //
        private void cmb_State_Send_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _WTT_StateList_Send = (Maticsoft.Model.StateList)cmb_State_Send.SelectedItem;
        }

        //
        //状态——Receive
        //
        private void cmb_State_Receive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _WTT_StateList_Receive = (Maticsoft.Model.StateList)cmb_State_Receive.SelectedItem;
            MCP_CS._M_MoveStore_ProductControl.GetAllList();
            txb_Info_YetQuantity.Text = "0";
            if (_WTT_WorkOrder != null) { showInfo(_WTT_StateList_Receive); }
        }

        //
        //添加记录
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            _WTT_MoveStore_ProductControl = new Maticsoft.Model.MoveStore_ProductControl()
            {
                Ord_ID = _WTT_WorkOrder.OrderID,
                Receive_USID = _WTT_UserRcecive.UserID,
                Receive_State = _WTT_StateList_Receive.Ste_ID.ToString(),
                Receive_WK = _WTT_WK_Receive.Wo_ID.ToString(),
                Send_USID = _WTT_UserSend.UserID,
                Send_State = _WTT_StateList_Send.Ste_ID.ToString(),
                Send_WK = _WTT_WK_Send.Wo_ID.ToString(),
                Count = txb_Quantity.Text.Trim(),
                DataTime = DateTime.Now
            };
            if (MCP_CS._M_MoveStore_ProductControl.Add(_WTT_MoveStore_ProductControl) > 0)
            {
                showInfo(_WTT_StateList_Receive);
                My_MessageBox.My_MessageBox_Message("添加成功！");
            }
            else { My_MessageBox.My_MessageBox_Message("添加失败！"); }
                  
        }

        /// <summary>
        /// 刷新信息
        /// </summary>
        private void showInfo(Maticsoft.Model.StateList _STList)
        {
            if (_STList != null)
            {
                dgv_Source.ItemsSource = MCP_CS._M_MoveStore_ProductControl.GetModelList(" (Ord_ID = '" +
                    _WTT_WorkOrder.OrderID + "') AND (Receive_WK = '" + _STList.Wk_ID + "') AND (Receive_State = '" + _STList.Ste_ID + "')");
                txb_Info_YetQuantity.Text = MCP_CS._M_MoveStore_ProductControl.GetSUM_StateCount(" (Ord_ID = '" +
                   _WTT_WorkOrder.OrderID + "') AND (Receive_WK = '" + _STList.Wk_ID + "') AND (Receive_State = '" + _STList.Ste_ID + "')").ToString();
            }
        }

        /// <summary>
        /// 启用控件
        /// </summary>
        private void IsEn(bool btn ,bool txb)
        {
            btn_Edit.IsEnabled = btn;
            btn_Delete.IsEnabled = btn;
            btn_Save.IsEnabled = btn;

            //
            txb_Quantity.IsEnabled = txb;
            txb_OrderID.IsEnabled = txb;
        }

        //
        //选择领线记录
        //
        private void dgv_Source_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgv_Source.SelectedIndex >= 0)
            {
                btn_Add.IsEnabled = false;
                IsEn(true, false);
                _WTT_MoveStore_ProductControl = (Maticsoft.Model.MoveStore_ProductControl)dgv_Source.SelectedItem;
                txb_Quantity.Text = _WTT_MoveStore_ProductControl.Count;
            }
        }

        //
        //编辑
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            IsEn(true, true);
        }

        //
        //删除
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (MCP_CS._M_MoveStore_ProductControl.Delete(_WTT_MoveStore_ProductControl.MS_ID))
            {
                showInfo(_WTT_StateList_Receive);
                My_MessageBox.My_MessageBox_Message("删除成功！");
            }
            else { My_MessageBox.My_MessageBox_Message("删除失败！"); }
        }


        //
        //保存更新
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
           
                _WTT_MoveStore_ProductControl.Ord_ID = _WTT_WorkOrder.OrderID;
                _WTT_MoveStore_ProductControl.Receive_USID = _WTT_UserRcecive.UserID;
                _WTT_MoveStore_ProductControl.Receive_State = _WTT_StateList_Receive.Ste_ID.ToString();
                _WTT_MoveStore_ProductControl.Receive_WK = _WTT_WK_Receive.Wo_ID.ToString();
                _WTT_MoveStore_ProductControl.Send_USID = _WTT_UserSend.UserID;
                _WTT_MoveStore_ProductControl.Send_State = _WTT_StateList_Send.Ste_ID.ToString();
                _WTT_MoveStore_ProductControl.Send_WK = _WTT_WK_Send.Wo_ID.ToString();
                _WTT_MoveStore_ProductControl.Count = txb_Quantity.Text.Trim();
                _WTT_MoveStore_ProductControl.DataTime = DateTime.Now;
           
            if (MCP_CS._M_MoveStore_ProductControl.Update(_WTT_MoveStore_ProductControl))
            {
                btn_Add.IsEnabled = true;
                showInfo(_WTT_StateList_Receive);
                My_MessageBox.My_MessageBox_Message("更新成功！");
            }
            else { My_MessageBox.My_MessageBox_Message("更新失败！"); }
        }
       
    }
}
