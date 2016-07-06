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
    /// frm_OrderInject_Material.xaml 的交互逻辑
    /// </summary>
    public partial class frm_OrderInject_Material 
    {
        public frm_OrderInject_Material()
        {
            InitializeComponent();
        }

        double  YetReceiveCount = 0 ,YetInjectCount;

        string Orm_ID = "";
        Maticsoft.Model.WorkStation _WTT_WK = new Maticsoft.Model.WorkStation();
        Maticsoft.Model.sysUser _WTT_User_Receive = new Maticsoft.Model.sysUser();
        Maticsoft.Model.Material_Inject _WTT_Material_Inject = new Maticsoft.Model.Material_Inject();

        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID { get; set; }

        //
        //窗体载入事件
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("(dbo.tb_OrderMaterial.OrderID = '"+OrderID+"') ");
            strSql.Append("  AND (dbo.tb_MaterialInfo.AliasName = 'APC' OR dbo.tb_MaterialInfo.AliasName = 'PC' OR dbo.tb_MaterialInfo.AliasName = 'SUS')");
            cmb_MaterialNum.ItemsSource = MCP_CS._M_OrderMaterial.GetList(strSql.ToString()).Tables[0].DefaultView;
            cmb_Workstation_Receive.ItemsSource = MCP_CS._M_Workstation.GetListModel("");
            dgv_InjectView.ItemsSource = MCP_CS._M_Material_Inject.GetInjectView(OrderID).Tables[0].DefaultView;
            cmb_MaterialNum.SelectedIndex = 0;
            isEn(false,true);
        }

        //
        //添加投料数量
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.Model.Material_Inject _Material_Inject = new Maticsoft.Model.Material_Inject()
            {
                Count = txb_Count.Text,
                DateTime = DateTime.Now,
                Orm_ID = Orm_ID,
                UserID = _WTT_User_Receive.UserID,
                WK_ID = _WTT_WK.Wo_ID.ToString()
            };
            if (MCP_CS._M_Material_Inject.Add(_Material_Inject) > 0)
            {
                ShowUp();
                My_MessageBox.My_MessageBox_Message("添加成功！");
            }
            else { My_MessageBox.My_MessageBox_Message("添加失败！"); }
        }      
        //
        //料号选择 
        //
        private void cmb_MaterialNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView drv = (DataRowView)cmb_MaterialNum.SelectedItem;
            txb_ProductName.Text = drv["品名"].ToString();
            txb_Model.Text = drv["规格"].ToString();
            Orm_ID = drv["Orm_ID"].ToString();

            txb_WantCount_Receive.Text = drv["需领数量"].ToString();
            double.TryParse(drv["已领数量"].ToString() ,out YetReceiveCount);
            txb_YetCount_Receive.Text = YetReceiveCount.ToString();

            ShowUp();
            isEn(false,true);
            btn_Add.IsEnabled = true;
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
                }
                else { txb_JobNumber_Receive.SelectAll(); }
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

        /// <summary>
        /// 是否启用btn
        /// </summary>
        private void isEn(bool btn_isen , bool txb_isen)
        {   //btn
            btn_Edit.IsEnabled = btn_isen;
            btn_Save.IsEnabled = btn_isen;
            btn_Delete.IsEnabled = btn_isen;
            //txb
            txb_Count.IsEnabled = txb_isen;
            txb_JobNumber_Receive.IsEnabled = txb_isen;

        }

        //
        //选择投料记录
        //
        private void dgv_source_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                btn_Add.IsEnabled = false;
                isEn(true ,false);
                _WTT_Material_Inject = (Maticsoft.Model.Material_Inject)dgv_source.SelectedItem;
                txb_Count.Text = _WTT_Material_Inject.Count;
                txb_JobNumber_Receive.Text = _WTT_Material_Inject.UserID;
                _WTT_WK = MCP_CS._M_Workstation.GetModel(decimal.Parse(_WTT_Material_Inject.WK_ID));
                cmb_Workstation_Receive.Text = _WTT_WK.Workstation;
            }
            catch { }
        }

        //
        //编辑
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            txb_JobNumber_Receive.Text = "";
            _WTT_User_Receive = null;
            isEn(true, true);
        }

        //
        //删除
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (_WTT_Material_Inject != null)
            {
                if (MCP_CS._M_Material_Inject.Delete(_WTT_Material_Inject.In_ID))
                {
                    ShowUp();
                    My_MessageBox.My_MessageBox_Message("删除成功！");
                }
            }
        }

        //
        //保存
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (_WTT_Material_Inject != null)
            {
                _WTT_Material_Inject.UserID = txb_JobNumber_Receive.Text.Trim();
                _WTT_Material_Inject.Count = txb_Count.Text.Trim();
                _WTT_Material_Inject.DateTime = DateTime.Now;

                if (_WTT_User_Receive != null)
                {
                    if (MCP_CS._M_Material_Inject.Update(_WTT_Material_Inject))
                    {
                        ShowUp();
                        My_MessageBox.My_MessageBox_Message("更新成功！");
                    }
                }
                else { My_MessageBox.My_MessageBox_Message("请输入您的工号后按回车键确认！"); }
            }
        }

        /// <summary>
        /// 刷新控件显示
        /// </summary>
        public void ShowUp()
        {          
            dgv_InjectView.ItemsSource = MCP_CS._M_Material_Inject.GetInjectView(OrderID).Tables[0].DefaultView;

            double.TryParse(MCP_CS._M_Material_Inject.GetInjectCount(Orm_ID).ToString(), out YetInjectCount);
            txb_YetCount_Inject.Text = YetInjectCount.ToString();            
            dgv_source.ItemsSource = MCP_CS._M_Material_Inject.GetModelList("Orm_ID = '" + Orm_ID + "'");
        }

        //
        //验证投料数量
        //
        private void txb_Count_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            double count = 0;
            if (double.TryParse(txb_Count.Text.Trim(), out count))
            {
                count = YetInjectCount + count;
                if (YetReceiveCount < count )
                {
                    txb_Count.SelectAll();
                    My_MessageBox.My_MessageBox_Message("投入数量 不能大于 已领取数量！ 请重新输入");
                }
            }          
        }

    }
}
