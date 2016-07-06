using AvalonDock;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Collections.ObjectModel;


namespace UI
{
    /// <summary>
    /// frm_Tools_SPC.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Tools_SPC : DocumentContent
    {
        public frm_Tools_SPC()
        {
            InitializeComponent();
        }
        Maticsoft.BLL.SPC _spc = new Maticsoft.BLL.SPC();
        //
        //保存路径
        //
        private void btn_SavePath_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FolderBrowserDialog sd = new FolderBrowserDialog();
            sd.ShowDialog();
            txb_SavePath.Text = sd.SelectedPath;
        }
        //
        //单表生成
        //
        private void btn_Generate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btn_Generate.IsEnabled = false;
            btn_Generate.Content = "正在生成...";
            _spc.Get_SPC_MPO(txb_SavePath.Text, cmb_Parameter.Text, dat_Date_Start.Text);
            btn_Generate.IsEnabled = true;
            btn_Generate.Content = "自动生成";
        }
        //
        //自动生成
        //
        private void btn_Generate_Auto_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            btn_Generate_Auto.IsEnabled = false;
            btn_Generate_Auto.Content = "正在生成...";
            Maticsoft.BLL.SPC _Temspc = new Maticsoft.BLL.SPC();
            _Temspc.Get_SPC_MPO_Auto(txb_SavePath.Text, dat_Date_Start.Text, dat_Date_End.Text);
            
           // btn_Generate_Auto.Content = "自动生成";
           // btn_Generate_Auto.IsEnabled = true;

        }

        /******* Method ******/
        /// <summary>
        ///窗体载入事件 
        /// </summary>
        private void DocumentContent_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            string[] temList = System.Enum.GetNames(typeof(Maticsoft.Model.E_Generate));
            cmb_Parameter.ItemsSource = temList;
            txb_SavePath.Text = "D:\\数据导出\\SPC";
        }

      



    }
}
