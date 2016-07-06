using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace UI 
{
    /// <summary>
    /// EmployeeEditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeEditWindow : Window
    {
        public EmployeeEditWindow()
        {
            InitializeComponent();
        }

        #region 属性

        public Guid EdittingId { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public Maticsoft.Model.UserInfo Employee { get; set; }

        /// <summary>
        /// 是否为添加模式
        /// </summary>
        public bool IsAddNew { get; set; }

        #endregion


        #region 控件事件
        //
        //窗体载入事件
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_Workstation.ItemsSource = MCP_CS._M_Workstation.GetStringList("");
            cmb_Job_Title.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = '职位'");
            cmb_IsJob.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = '是否在职'");
            cmb_IsWedding.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = '是否已婚'");
            cmb_Politics.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = '政治面貌'");
            cmb_Sex.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = '性别'");

            dpk_Entry_Date.SelectedDate = DateTime.Now;
            dpk_Termination_Date.SelectedDate = DateTime.Now;

            if (IsAddNew)  //添加模式
            {
                Maticsoft.Model.UserInfo use = new Maticsoft.Model.UserInfo();
                grd_UserInfo.DataContext = use;
                btn_Edit.IsEnabled = false;
            }
            else  //更新模式
            {
                if (Employee != null)
                {
                    grd_UserInfo.DataContext = Employee;
                    SetControl(false, false);
                    btn_Add.IsEnabled = false;
                    btn_Save.IsEnabled = false;
                }

            }
        }

      
      
        //
        //选择照片
        //
        private void btnChoosePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "JPG图片|*.jpg|PNG图片|*.png";
            if (op.ShowDialog().Value)
            {               
                string filename = op.FileName;
                byte[] _temPhoto = File.ReadAllBytes(filename);
                imgPhoto.Source = new BitmapImage(new Uri(filename));
            }
        }

        //
        //新建
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            SetControl(true, true);
        }

        //
        //编辑
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            SetControl(true, false);
            btn_Save.IsEnabled = true;
        }


        //
        //保存
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            bool IsOk = true;
            CheckTextBoxNotNull(ref IsOk, txb_JobNum, txb_Name, txb_Age);
            if (!IsOk)
            {
                return;
            }
            else
            {
                try
                {
                    if (IsAddNew)   //添加模式
                    {
                        Maticsoft.Model.UserInfo use = (Maticsoft.Model.UserInfo)grd_UserInfo.DataContext;
                        MCP_CS.UserInfo.Add(use);
                    }
                    else       //更新模式
                    {
                        Maticsoft.Model.UserInfo use = (Maticsoft.Model.UserInfo)grd_UserInfo.DataContext;
                        MCP_CS.UserInfo.Update(use);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            btn_Save.IsEnabled = false;
        }


        #endregion





        #region  Method

        /// <summary>
        /// 显示照片
        /// </summary>
        /// <param name="imgBytes"></param>
        private void ShowImg(byte[] imgBytes)
        {
            MemoryStream stream = new MemoryStream(imgBytes);
            BitmapImage bmpImg = new BitmapImage();
            bmpImg.BeginInit();
            bmpImg.StreamSource = stream;
            bmpImg.EndInit();
            imgPhoto.Source = bmpImg;
        }

        /// <summary>
        /// 检查非空字段
        /// </summary>
        /// <param name="IsOk"></param>
        /// <param name="textboxes"></param>
        private void CheckTextBoxNotNull(ref bool IsOk, params TextBox[] textboxes)
        {
            foreach (TextBox txtBox in textboxes)
            {
                txtBox.Background = Brushes.White;
                if (txtBox.Text.Length <= 0)
                {
                    IsOk = false;
                    txtBox.Background = Brushes.Red;
                }
                else
                {
                    txtBox.Background = null;
                }
            }
        }

        /// <summary>
        /// 检查非空字段
        /// </summary>
        /// <param name="IsOk"></param>
        /// <param name="cmbs"></param>
        private void CheckComboBoxNotNull(ref bool IsOk, params ComboBox[] cmbs)
        {
            foreach (ComboBox cmb in cmbs)
            {
                if (cmb.SelectedIndex < 0)
                {
                    IsOk = false;
                    cmb.Effect = new DropShadowEffect { Color = Colors.Red };
                }
                else
                {
                    cmb.Effect = null;
                }
            }
        }

        /// <summary>
        /// 检查Grid 中 所有的 TextBox控件 的内容是否为空
        /// </summary>
        /// <param name="IsOk"></param>
        /// <param name="_Grid"></param>
        private void CheckTextBoxNotNull(ref bool IsOk , Grid _Grid)
        {
            foreach (UIElement c in grd_UserInfo.Children)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Background = Brushes.White;
                    if (((TextBox)c).Text.Length <= 0)
                    {
                        IsOk = false;
                        ((TextBox)c).Background = Brushes.Red;
                    }
                }
            }
        }


        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="IsEn"></param>
        /// <param name="IsNull"></param>
        private void SetControl(bool IsEn ,bool IsNull)
        {
            foreach (UIElement c in grd_UserInfo.Children)
            {
                if (c is TextBox)
                {
                    c.IsEnabled = IsEn;
                    if (IsNull)
                    {
                        ((TextBox)c).Text = "";
                    }
                }
                if (c is ComboBox)
                {
                    c.IsEnabled = IsEn;
                    if (IsNull)
                    {
                        ((ComboBox)c).SelectedIndex = -1;
                    }
                }
                if (c is DatePicker)
                {
                    c.IsEnabled = IsEn;
                    if (IsNull)
                    {
                        ((DatePicker)c).SelectedDate = null;
                    }
                }
            }
            btn_ChoosePhoto.IsEnabled = IsEn;
        }
        

        /// <summary>
        /// 验证邮箱输入是否合法
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        private bool IsValidEmail(string strIn)
        {
            return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }


        #endregion


        


    }
}