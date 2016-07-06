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

namespace UI
{
    /// <summary>
    /// frm_Employee_MS.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Employee_MS : DocumentContent
    {
        public frm_Employee_MS()
        {
            InitializeComponent();
        }

        //
        //新增作业员
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEditWindow f = new EmployeeEditWindow();
            f.IsAddNew = true;  //添加模式
            f.ShowDialog();
        }

        //
        //查找 
        //
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            //获取用于查询的Sql列名称
            Maticsoft.Model.Equipment_TypeList _temFindType = (Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem;          
            //给DataView 控件指定数据源
            if (cmb_SerachValue.Text != "")
            {
                dgv_Date.ItemsSource = MCP_CS.UserInfo.GetModelList(_temFindType.Remarks + " LIKE '%" + cmb_SerachValue.Text.Trim() + "%'");
            }
            else
            {
                dgv_Date.ItemsSource = MCP_CS.UserInfo.GetModelList("");
            }
            lab_UserCount.Content = "记录 " + (dgv_Date.Items.Count -1)+"条";
        }

        //
        //窗体载入事件
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            //HR_Find
           
            cmb_SearchConition.DisplayMemberPath = "Value";

            cmb_SearchConition.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type = 'HR_Find'");
        }

        //
        //选择查询条件
        //
        private void cmb_SearchConition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Maticsoft.Model.Equipment_TypeList _temEquipment_Typelist = (Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem;       
            DataSet temds = MCP_CS.UserInfo.Get_Distinct_List(_temEquipment_Typelist.Remarks);
            cmb_SerachValue.DisplayMemberPath = _temEquipment_Typelist.Remarks;
            if (temds != null)
            {
                cmb_SerachValue.ItemsSource = temds.Tables[0].DefaultView;
            }
        }

        //
        //选择员工 并双击
        //
        private void dgv_Date_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                EmployeeEditWindow f = new EmployeeEditWindow();
                f.IsAddNew = false;
                f.Employee = (Maticsoft.Model.UserInfo)dgv_Date.SelectedItem;
                f.Show();
            }
            catch { }
        }

       
    }
}
