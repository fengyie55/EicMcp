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

namespace UI
{
    /// <summary>
    /// frm_HumanResources.xaml 的交互逻辑
    /// </summary>
    public partial class frm_HumanResources : DocumentContent
    {
        public frm_HumanResources()
        {
            InitializeComponent();
        }
 
        //
        //员工列表
        //
        private void btn_EmployeeEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //
        //人员配置
        //
        private void btn_WK_User_Click(object sender, RoutedEventArgs e)
        {
            frm_WK_SetUser f = new frm_WK_SetUser();
            f.Show();
        }


    }
}
