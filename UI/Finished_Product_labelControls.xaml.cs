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

namespace UI
{
    /// <summary>
    /// Interaction logic for Finished_Product_labelControls.xaml
    /// </summary>
    public partial class Finished_Product_labelControls : UserControl
    {
        public LabelControlsModel vm = new LabelControlsModel();
        public Finished_Product_labelControls()
        {
            InitializeComponent();
            this.DataContext = vm;
            
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) { tb_sn1.Focus(); }
        }

      
    }
}
