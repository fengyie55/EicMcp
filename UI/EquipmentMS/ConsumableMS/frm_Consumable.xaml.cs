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
using System.Windows.Forms;
using System.IO;

namespace UI
{
    /// <summary>
    /// frm_Consumable.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Consumable : Window
    {
        public frm_Consumable()
        {
            InitializeComponent();
            MCP_CS.SetControl(grd_ConsumableInfo, false, false); //设置控件为不可编辑模式
            btn_Edit.IsEnabled = false;
        }

        public frm_Consumable(Maticsoft.Model.ConsumableInfo _ConsumableInfo)
        {
            InitializeComponent();
            grd_ConsumableInfo.DataContext = _ConsumableInfo;
            btn_Edit.IsEnabled = true;
            MCP_CS.SetControl(grd_ConsumableInfo, false, false); //设置控件为不可编辑模式
            ShowImg(_ConsumableInfo.C_Picture);
        }

        #region 属性

        /// <summary>
        ///  是否为更新模式
        /// </summary>
        public bool IsAdd { get; set; }
        #endregion




        //
        //窗体初始化
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_Type.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = 'C_类别'");
            cmb_Type.SelectedIndex = 0;
            cmb_LifeUnit.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = 'C_寿命单位'");
            cmb_LifeUnit.SelectedIndex = 0;
            cmb_SafeUnit.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = '单位'");
            cmb_SafeUnit.SelectedIndex = 0;         
        }

        //新增
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.Model.ConsumableInfo _Consum = new Maticsoft.Model.ConsumableInfo();
            _Consum.C_Barcode = MCP_CS.ConsumableInfo.GetMaxID();
            grd_ConsumableInfo.DataContext = _Consum;           
            IsAdd = true;
            btn_Save.IsEnabled = true;
            btn_Add.IsEnabled = false;
            MCP_CS.SetControl(grd_ConsumableInfo, true, false); //设置控件为不可编辑模式
        }

        //
        //编辑
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            IsAdd = false;
            MCP_CS.SetControl(grd_ConsumableInfo, true, false); //设置控件为不可编辑模式
        }

        //
        //删除
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.Model.ConsumableInfo _Consum = (Maticsoft.Model.ConsumableInfo)grd_ConsumableInfo.DataContext;
            if (_Consum.Csm_ID > 0)
            {
                if (MCP_CS.ConsumableInfo.Delete(_Consum.Csm_ID))
                    My_MessageBox.My_MessageBox_Query("删除成功！");
                else
                    My_MessageBox.My_MessageBox_Query("删除失败！");
            }
            else
            {
                My_MessageBox.My_MessageBox_Query("删除不合法,请确认操作是否正确！");
            }

        }


        //
        //保存
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {           
            Maticsoft.Model.ConsumableInfo _Consum = (Maticsoft.Model.ConsumableInfo)grd_ConsumableInfo.DataContext;
            if (IsAdd) //添加模式
            {               
                MCP_CS.ConsumableInfo.Add(_Consum);
                btn_Add.IsEnabled = true;
                My_MessageBox.My_MessageBox_Query("添加成功！");
                grd_ConsumableInfo.DataContext = new Maticsoft.Model.ConsumableInfo();
            }
            else      //更新模式
            {            
                MCP_CS.ConsumableInfo.Update(_Consum);
            }
            MCP_CS.SetControl(grd_ConsumableInfo, false, false); //设置控件为不可编辑模式
        }

        private void btn_PhotoPatch_Click(object sender, RoutedEventArgs e)
        {
           // FolderBrowserDialog f = new FolderBrowserDialog();
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            txb_Picture.Text = f.FileName;
            if (f.FileName != null)
            {
                ShowImg(f.FileName);
            }

        }


        private byte[] imBytes;
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="Patch"></param>
        private void ShowImg(string Patch)
        {
            try
            {
                //读成二进制
                imBytes = File.ReadAllBytes(Patch);
                //直接把这个存储到数据就行了cmd.Parameters.Add("@image", SqlDbType.Image).Value = bytes;

                //在控件中显示图片
                BitmapImage BI = new BitmapImage();
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(imBytes);  //bufPic是图片二进制，byte类型
                BI.EndInit();            
                image1.UseLayoutRounding = true;
                image1.Source = BI;//image是XAML页面上定义的Image控件                                   
            }
            catch { }         
        }

        


    }
}
