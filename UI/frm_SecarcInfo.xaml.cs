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
    /// frm_SecarcInfo.xaml 的交互逻辑
    /// </summary>
    public partial class frm_SecarcInfo : DocumentContent
    {
        public frm_SecarcInfo()
        {
            InitializeComponent();
        }
        //
        //
        //
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.BLL.MultiFiber _M_MultiFiber = new Maticsoft.BLL.MultiFiber();
            Maticsoft.Model.MultiFiber _MultiFiber = new Maticsoft.Model.MultiFiber();
            _MultiFiber = _M_MultiFiber.GetModel(txb_SerialNumber.Text.Trim());
            
            foreach (object ob in _MultiFiber.FiberHeight)
            {
                lst_FiberH.Items.Add(ob);
            }


        }

    }
}
