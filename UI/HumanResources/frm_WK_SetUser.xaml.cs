using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
	/// <summary>
	/// frm_WK_SetUser.xaml 的交互逻辑
	/// </summary>
	public partial class frm_WK_SetUser : Window
	{
		public frm_WK_SetUser()
		{
			this.InitializeComponent();			
			// 在此点之下插入创建对象所需的代码。
		}

        bool IsAdd = false;


        //
        //窗体载入事件 
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_WorkList.ItemsSource = MCP_CS._M_Workstation.GetStringList("");
            cmb_WK.ItemsSource = MCP_CS._M_Workstation.GetStringList("");
            cmb_ClassType.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = '班别'");
            grd_User.DataContext = MCP_CS._User_WK;
            SetControl(false, false);
   
            btn_Save.IsEnabled = false;
            btn_Edit.IsEnabled = false;
            btn_Delete.IsEnabled = false;
        }

        //
        //查找
        //
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            lst_WK_UserList.ItemsSource = MCP_CS.User_WK.GetModelList("WK = '"+cmb_WorkList.SelectedValue+"'");
        }

        //
        //添加
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            SetControl(true, true);
            btn_Save.IsEnabled = true;
            IsAdd = true;
        }

        //
        //编辑
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            SetControl(true, false);
            btn_Save.IsEnabled = true;
            IsAdd = false;
        }

        //
        //删除
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            MCP_CS._User_WK = (Maticsoft.Model.User_WK)grd_User.DataContext;
            MCP_CS.User_WK.Delete(MCP_CS._User_WK.WU_ID);
        }
      
        //
        //保存
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (IsAdd)
            {
                Maticsoft.Model.User_WK _User_Wk = (Maticsoft.Model.User_WK)grd_User.DataContext;
                MCP_CS.User_WK.Add(_User_Wk);
            }
            else
            {
                Maticsoft.Model.User_WK _User_Wk = (Maticsoft.Model.User_WK)grd_User.DataContext;
                MCP_CS.User_WK.Update(_User_Wk);
            }
            lst_WK_UserList.ItemsSource = MCP_CS.User_WK.GetModelList("WK = '" + cmb_WK.SelectedValue + "'");
            btn_Save.IsEnabled = false;
            SetControl(false, true);
           
        }


        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="IsEn"></param>
        /// <param name="IsNull"></param>
        private void SetControl(bool IsEn, bool IsNull)
        {
            foreach (UIElement c in grd_User.Children)
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
           
        }

        //
        //双击选择
        //
        private void lst_WK_UserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lst_WK_UserList.SelectedIndex != -1)
            {
                MCP_CS._User_WK = (Maticsoft.Model.User_WK)lst_WK_UserList.SelectedItem;
                grd_User.DataContext = MCP_CS._User_WK;
                btn_Edit.IsEnabled = true;
            }
        }
 
        //
        //工号按下Enter
        //
        private void txb_JobNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_JobNum.IsFocused)
            {
                MCP_CS._UserInfo = MCP_CS.UserInfo.GetModel(txb_JobNum.Text);
                if (MCP_CS._UserInfo != null)
                {
                    MCP_CS._User_WK.Name = MCP_CS._UserInfo.Name;
                    
                }
                else { My_MessageBox.My_MessageBox_Message("未找到该工号员工的任何信息，请确认工号是否有误"); }
            }
        }
	}
}