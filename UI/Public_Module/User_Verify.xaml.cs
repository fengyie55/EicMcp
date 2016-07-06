using System.Windows;
using Maticsoft.BLL;

namespace UI
{
    /// <summary>
    /// User_Verify.xaml 的交互逻辑
    /// </summary>
    public partial class User_Verify
    {
        private bool _TemResult_InspectUser = false;
        Maticsoft.Model.sysUser _SysUser = new Maticsoft.Model.sysUser();
        sysUser _Method_SysUser = new sysUser();
        public User_Verify()
        {
            _TemResult_InspectUser = false;
            InitializeComponent();         
        }
       
        /// <summary>
        /// 返回验证结果
        /// </summary>
        public bool Result_InspectUser
        {
            get { return _TemResult_InspectUser; }
        }
        /// <summary>
        /// 返回验证用户
        /// </summary>
        public Maticsoft.Model.sysUser SysUser
        {
            get { return _SysUser; }
        }
            
        //开始验证
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (txb_UserID.Text == "") { My_MessageBox.My_MessageBox_Message("用户名不能为空"); }
            else if (txb_Password.Password == "") { My_MessageBox.My_MessageBox_Message("密码不能为空"); }
            else if (_Method_SysUser.Exists(txb_UserID.Text,txb_Password.Password))
            {
                _SysUser = _Method_SysUser.GetModel(txb_UserID.Text);
                _TemResult_InspectUser = true;
                this.Close();
            }
            else { _TemResult_InspectUser = false; this.Close(); }
          
        }

        //取消
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            _TemResult_InspectUser = false;
            this.Close();
        }

        //
        //UserID  按下Enter
        //
        private void txb_UserID_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                txb_Password.Focus();
            }
        }

        //
        //载入事件
        //
        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txb_UserID.Focus();
        }

       
    }
}
