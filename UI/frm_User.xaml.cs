using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using AvalonDock;

namespace UI
{
    /// <summary>
    /// frm_User.xaml 的交互逻辑
    /// </summary>
    public partial class frm_User : DocumentContent
    {
        public frm_User()
        {
            InitializeComponent();
        }
        Maticsoft.BLL.Workstation _M_Workstation = new Maticsoft.BLL.Workstation();       
        Maticsoft.BLL.sysUser _M_User = new Maticsoft.BLL.sysUser();

        Maticsoft.Model.sysUser _WTT_User = new Maticsoft.Model.sysUser();
        Maticsoft.Model.WorkStation _WTT_Workstation = new Maticsoft.Model.WorkStation();

        //
        //窗体载入事件
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {         
            List<string> PrivilegeList = new List<string>();
            PrivilegeList.Add("系统管理员");
            PrivilegeList.Add("经理");
            PrivilegeList.Add("主管");
            PrivilegeList.Add("工程师");
            PrivilegeList.Add("助理");
            PrivilegeList.Add("组长");
            PrivilegeList.Add("员工");

            cmb_Workstation.ItemsSource = _M_Workstation.GetListModel("");            
            cmb_Privilege.ItemsSource = PrivilegeList;
            dgv_Source.ItemsSource = _M_User.GetModelList("");
        }

        //
        //用户列表
        //
        private void dgv_Source_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
            if (dgv_Source.SelectedItem != null)
            {
                _WTT_User = (Maticsoft.Model.sysUser)dgv_Source.SelectedItem;
                //
                txb_Password.Text = _WTT_User.Password;
                txb_JobNum.Text = _WTT_User.UserID;
                txb_UserName.Text = _WTT_User.UserName;
                cmb_Privilege.Text = _WTT_User.Privilege;
                //               
                decimal _WK_ID = 0;
                if (decimal.TryParse(_WTT_User.Workstation, out _WK_ID))
                {
                  _WTT_Workstation =  _M_Workstation.GetModel(_WK_ID);
                  cmb_Workstation.Text = _WTT_Workstation.Workstation;
                }
            }
        }

        //
        //选择站别
        //
        private void cmb_Workstation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _WTT_Workstation = (Maticsoft.Model.WorkStation)cmb_Workstation.SelectedItem;
        }

        //
        // 添加
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (_WTT_Workstation != null && txb_Password.Text != "" && txb_JobNum.Text != "" && txb_UserName.Text != "" && cmb_Privilege.Text != "")
            {
                _WTT_User = new Maticsoft.Model.sysUser()
                {
                    Workstation = _WTT_Workstation.Wo_ID.ToString(),
                    UserName = txb_UserName.Text,
                    UserID = txb_JobNum.Text,
                    Password = txb_Password.Text,
                    Privilege = cmb_Privilege.Text
                };

                if (_M_User.Add(_WTT_User)) { My_MessageBox.My_MessageBox_Message("添加成功！");
                dgv_Source.ItemsSource = _M_User.GetModelList(""); } 
                else { My_MessageBox.My_MessageBox_Message("添加失败！"); }

            }
            else { My_MessageBox.My_MessageBox_Message("信息不完整！不能进行添加!"); }
        }

        //
        //删除
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (_M_User.Delete(_WTT_User.UserID))
            {
                My_MessageBox.My_MessageBox_Message("删除成功!");
            }
            else { My_MessageBox.My_MessageBox_Message("删除失败!"); }
        }


    }
}
