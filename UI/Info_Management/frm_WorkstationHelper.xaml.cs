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
using AvalonDock;

namespace UI
{
    /// <summary>
    /// frm_WorkstationHelper.xaml 的交互逻辑
    /// </summary>
    public partial class frm_WorkstationHelper : DocumentContent
    {
        public frm_WorkstationHelper()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 停靠控件
        /// </summary>
        public DockingManager dockManager { get; set; }

        //
        //载入站别信息
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_WKList.ItemsSource = MCP_CS._M_Workstation.GetStringList("");
        }

        //
        //每日报表
        //
        private void btn_H_ReportForms_Click(object sender, RoutedEventArgs e)
        {
            frm_ReportForms f = new frm_ReportForms();                  
            f.Title = "报表录入";
            f.Show(dockManager);
            f.Activate();

        }

        //
        //员工管理
        //
        private void btn_H_UserWK_Click(object sender, RoutedEventArgs e)
        {
            frm_Employee_MS f = new frm_Employee_MS();
            f.Title = "员工管理";
            f.Show(dockManager);
            f.Activate();
        }
        
        //
        //治具管理
        //
        private void btn_E_FixtureMS_Click(object sender, RoutedEventArgs e)
        {
            frm_FixtureMS_Main f = new frm_FixtureMS_Main();
            f.Title = "治具管理";
            f.Show(dockManager);
            f.Activate();
        }

        //
        //设备管理
        //
        private void btn_E_EquipmentMS_Click(object sender, RoutedEventArgs e)
        {
            frm_EquipmentMS_Main f = new frm_EquipmentMS_Main();
            f.Title = "设备管理";
            f.Show(dockManager);
            f.Activate();
        }

        //
        //打开生产排程
        //
        private void btn_M_MPS_Click(object sender, RoutedEventArgs e)
        {
            string _Patch = "\\\\192.168.0.65\\制二不良统计表\\生产排程\\";
            System.Diagnostics.Process.Start("explorer.exe", _Patch); //打开文件夹
        }

        //
        //载入站别信息
        //
        private void btn_Lad_WkInfo_Click(object sender, RoutedEventArgs e)
        {
            //作业员
            lsv_UserList.ItemsSource = MCP_CS.UserInfo.GetModelList("Workstation = '" + cmb_WKList.SelectedValue + "'");
            txb_WK_InfoMessage.Text = "作业员：" + lsv_UserList.Items.Count + " 人\r\n";

            //设备
            lsv_EnquipmentList.ItemsSource = MCP_CS._M_Equipment.GetModelList("InstallationSite = '" + cmb_WKList.SelectedValue + "'");
            txb_WK_InfoMessage.Text += "设备：" + lsv_EnquipmentList.Items.Count + " 台\r\n";

            //工单
            string _WK_tem = cmb_WKList.SelectedValue.ToString().Substring(0, 1);
            string _Workshop = "";
            if (_WK_tem == "南")       _Workshop = "南车间";
            else if (_WK_tem == "北")  _Workshop = "北车间";
            else if (_WK_tem == "小")  _Workshop = "小车间";
            lsv_OrderInfoList.ItemsSource = MCP_CS._M_WorkOrder.GetModelList("(Workshop = '" + _Workshop + "') AND (State = '待生产')");
            txb_WK_InfoMessage.Text += "在制工单：" + lsv_OrderInfoList.Items.Count + " 个\r\n";
        }

       
    }
}
