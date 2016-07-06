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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AvalonDock;
using System.Data;
using System.Collections.ObjectModel;

namespace UI
{
    /// <summary>
    /// frm_ConsumableMS_Main.xaml 的交互逻辑
    /// </summary>
    public partial class frm_ConsumableMS_Main : DocumentContent
    {
        public frm_ConsumableMS_Main()
        {
            InitializeComponent();
        }

        //
        //载入窗体事件
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {          
            cmb_SearchConition.DisplayMemberPath = "Value";
            cmb_SearchConition.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type = 'C_查询条件'");
            cmb_SearchConition.SelectedIndex = 0;
        }


        #region 耗材查找

        //
        //详细信息
        //
        private void btn_Consumable_Info_Click(object sender, RoutedEventArgs e)
        {
            frm_Consumable f = new frm_Consumable();
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Show();
        }
        

        //
        //双击弹出物料详细信息
        //
        private void dgv_ConsumableInfoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dgv_ConsumableInfoList.SelectedItem != null)
                {
                    Maticsoft.Model.ConsumableInfo _consum = (Maticsoft.Model.ConsumableInfo)dgv_ConsumableInfoList.SelectedItem;

                    frm_Consumable f = new frm_Consumable(_consum);
                    f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    f.Show();
                }
            }
            catch { }
        }

        //
        //选择耗材
        //
        private void dgv_ConsumableInfoList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (dgv_ConsumableInfoList.SelectedItem != null)
                {
                    Maticsoft.Model.ConsumableInfo _C_Info =  (Maticsoft.Model.ConsumableInfo)dgv_ConsumableInfoList.SelectedItem;
                    grd_ConsumableInfo.DataContext = _C_Info;
                    txb_Consumable_Barcode.Text = _C_Info.C_Barcode;
                    txb_ConsumableName.Text = _C_Info.C_Name;
                }
            }
            catch { }
        }

        //
        //查找
        //
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgv_ConsumableInfoList.ItemsSource = GetSearchResult((Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem, cmb_SerachValue.Text);
            }
            catch { }
        }
        //
        //选择查询条件
        //
        private void cmb_SearchConition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Maticsoft.Model.Equipment_TypeList _temEquipment_Typelist = (Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem;
            DataSet temds = MCP_CS.ConsumableInfo.Get_Distinct_List(_temEquipment_Typelist.Remarks);
            cmb_SerachValue.DisplayMemberPath = _temEquipment_Typelist.Remarks;
            if (temds != null)
            {
                cmb_SerachValue.ItemsSource = temds.Tables[0].DefaultView;
            }             
        }

        #endregion


        #region Method

        /// <summary>
        /// 获取查找结果
        /// </summary>
        /// <param name="_SearchConition">查找选项</param>
        /// <param name="_SearchValue">值</param>
        /// <param name="IsFuzzySearch">是否模糊查询</param>
        /// <returns></returns>
        private List<Maticsoft.Model.ConsumableInfo> GetSearchResult(Maticsoft.Model.Equipment_TypeList _SearchConition, string _SearchValue)
        {
            if (_SearchValue != "" || _SearchConition.Value != "所有耗材")
            {
                return MCP_CS.ConsumableInfo.GetModelList(_SearchConition.Remarks + " LIKE '%" + _SearchValue + "%'");
            }
            else { return MCP_CS.ConsumableInfo.GetModelList(""); }
        }

        #endregion


        #region 领料与入库

        ObservableCollection<Maticsoft.Model.ConsumableReceive> _dataList_Receive
            = new ObservableCollection<Maticsoft.Model.ConsumableReceive>();

        ObservableCollection<Maticsoft.Model.ConsumableStorage> _dataList_Storage 
            = new ObservableCollection<Maticsoft.Model.ConsumableStorage>(); 

        Maticsoft.BLL.cls_Consumable _ConsumOperation = new Maticsoft.BLL.cls_Consumable();


        //
        //领料
        //
        private void btn_Receive_Click(object sender, RoutedEventArgs e)
        {
            _ConsumOperation.Operation = Maticsoft.BLL.cls_Consumable.ConsumableOperation.Receive; //模式为领料模式
            MCP_CS.SetControl(grd_Rec_Or_Stog, true, true);   //Text控件可编辑
            MCP_CS.SetControl_Button(grd_Rec_Or_Stog, true, false); //按钮可编辑          
            grd_Rec_Or_Stog.DataContext = new Maticsoft.Model.ConsumableReceive(); //数据显示控件指定数据源
            dgv_ConsumableList.ItemsSource = _dataList_Receive;
            lab_title.Content = "耗材领料";
            lab_User.Content = "领用人:";
            txb_Consumable_Barcode.IsEnabled = false;
            txb_ConsumableName.IsEnabled = false;
        }


        //
        //入库
        //
        private void btn_Storage_Click(object sender, RoutedEventArgs e)
        {
            _ConsumOperation.Operation = Maticsoft.BLL.cls_Consumable.ConsumableOperation.Storage;  //模式为入库模式
            MCP_CS.SetControl(grd_Rec_Or_Stog, true, true);
            MCP_CS.SetControl_Button(grd_Rec_Or_Stog, true, false);
            grd_Rec_Or_Stog.DataContext = new Maticsoft.Model.ConsumableStorage();
            dgv_ConsumableList.ItemsSource = _dataList_Storage;
            lab_title.Content = "耗材入库";
            lab_User.Content = "入库人:";
            txb_Consumable_Barcode.IsEnabled = false;
            txb_ConsumableName.IsEnabled = false;
        }

        //
        // 验证工号
        //
        private void txb_R_UserID_PreviewKeyUp(object sender, KeyEventArgs e)
        {          
            if (e.Key == Key.Enter)
            {
                Maticsoft.BLL.sysUser _M_user = new Maticsoft.BLL.sysUser();
                txb_R_UserName.Text = _M_user.Get_UserName(txb_R_UserID.Text.Trim());              
            }
        }
     
        //
        //添加
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.Model.ConsumableReceive _Receive = new Maticsoft.Model.ConsumableReceive();
          //  _Receive = (Maticsoft.Model.ConsumableReceive)dgv_ConsumableList.DataContext;

            Maticsoft.Model.ConsumableStorage _Storage = new Maticsoft.Model.ConsumableStorage();
          //  _Storage = (Maticsoft.Model.ConsumableStorage)dgv_ConsumableList.DataContext;

            bool IsOk = true;
            MCP_CS.CheckTextBoxNotNull(ref IsOk, txb_Consumable_Barcode, txb_R_Count, txb_R_Remaks, txb_R_UserID, txb_R_UserName);
            if (IsOk)
            {
                if (_ConsumOperation.Operation == Maticsoft.BLL.cls_Consumable.ConsumableOperation.Receive)
                {                   
                    _Receive.C_Barcode = txb_Consumable_Barcode.Text.Trim();
                    _Receive.C_Name = txb_ConsumableName.Text.Trim();
                    _Receive.Datetime = DateTime.Now.ToString();
                    _Receive.Count = int.Parse(txb_R_Count.Text.Trim());
                    _Receive.UserName = txb_R_UserName.Text.Trim();
                    _Receive.Remarks = txb_R_Remaks.Text.Trim();

                    _dataList_Receive.Add(_Receive);                  
                }
                else
                {                   
                    _Storage.C_Barcode = txb_Consumable_Barcode.Text.Trim();
                    _Storage.C_Name = txb_ConsumableName.Text.Trim();
                    _Storage.Datetime = DateTime.Now.ToString();
                    _Storage.Count = int.Parse(txb_R_Count.Text.Trim());
                    _Storage.UserName = txb_R_UserName.Text.Trim();
                    _Storage.Remarks = txb_R_Remaks.Text.Trim();

                    _dataList_Storage.Add(_Storage);
                }
                //               
                txb_R_Count.Text = "";
                txb_Consumable_Barcode.Text = "";
            }
        }

        //
        //保存
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int tem = _ConsumOperation.ConsumableSave(dgv_ConsumableList);
            if (tem > 0)
            {
                My_MessageBox.My_MessageBox_Message("保存成功记录 " + tem + "条！");
                _dataList_Receive.Clear();
                _dataList_Storage.Clear();
                MCP_CS.SetControl(grd_Rec_Or_Stog, false, true);
                MCP_CS.SetControl_Button(grd_Rec_Or_Stog, false, false);
            }
            else
                My_MessageBox.My_MessageBox_Message("保存失败！请重试");    
   
        }
        #endregion

       

       
    }
}
