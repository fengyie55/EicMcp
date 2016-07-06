using System;
using System.Windows;
using AvalonDock;
using System.Data;
using Maticsoft.BLL;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;
using System.Collections;

namespace UI
{
    /// <summary>
    /// My_Control_OrderInfo.xaml 的交互逻辑
    /// </summary>
    public partial class My_Control_OrderInfo : DocumentContent
    {
        public My_Control_OrderInfo()
        {
            InitializeComponent();
        }
       

        public bool ShowOrderInfo(Maticsoft.Model.WorkOrder _OrderInfo)
        {
            return true;
        }
    }
}
