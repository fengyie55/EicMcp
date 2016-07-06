using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace UI
{
    /// <summary>
    /// login.xaml 的交互逻辑
    /// </summary>
    public partial class login : Window
    {


        //
        //窗体载入事件
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txb_User.Focus();
            try
            {
                //string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "sysVersion.ini"; //获取当前版本号
                //string str2 = @"\\qqqqqq-ms2\McpSystem\sysVersion.ini";
                ////服务器版本
                //IniFiles ini_1 = new IniFiles(str2);
                //string z1 = ini_1.ReadString("Vsrsion", "z", "");
                //string f1 = ini_1.ReadString("Vsrsion", "f", "");
                //string c1 = ini_1.ReadString("Vsrsion", "c", "");
                //int _Remote = int.Parse(z1 + f1 + c1);

                ////本地版本
                //IniFiles ini_2 = new IniFiles(str);
                //string z2 = ini_2.ReadString("Vsrsion", "z", "");
                //string f2 = ini_2.ReadString("Vsrsion", "f", "");
                //string c2 = ini_2.ReadString("Vsrsion", "c", "");
                //int _Local = int.Parse(z2 + f2 + c2);
                //lab_Ver.Text = "版本：" + z2 + "." + f2 + "." + c2;

                //if (_Local != _Remote) //如果版本不同 说明服务器已经存在更新了  //启动更新
                //{
                //    ProcessStartInfo info = new ProcessStartInfo();
                //    info.FileName = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "UpSystem.exe";
                //    info.Arguments = "";
                //    info.WindowStyle = ProcessWindowStyle.Minimized;
                //    Process pro = Process.Start(info);
                //    //  pro.WaitForExit();
                //    //  pro.Start();
                //    this.Close();
                //}
            }
            catch { My_MessageBox.My_MessageBox_Message("在连接到更新服务器时失败，请手动更新或联系系统管理员！"); }
        }


        public login()
        {
            InitializeComponent();
        }
        //
        //登陆
        //       
        private void btnload_Click(object sender, RoutedEventArgs e)
        {
            load();  //登陆
        }
        //
        //取消登陆
        //
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //
        //用户框 按下Enter
        //
        private void txb_User_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_User.IsFocused)
            {
                txb_PassWord.Focus();
            }
        }
        //
        //密码框 按下Enter
        //
        private void txb_PassWord_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txb_PassWord.IsFocused)
            {
                load();
            }
        }
        
/***************** 登陆 ****************/
        //登陆
        int temLoadCount = 0;
        private void load()
        {
            if (txb_User.Text == "")
            {
                My_MessageBox.My_MessageBox_Message("用户名不能为空!");
            }
            else if (txb_PassWord.Password == "")
            {
                My_MessageBox.My_MessageBox_Message("密码不能为空!");
            }
            else
            {
                Maticsoft.BLL.sysUser _M_user = new Maticsoft.BLL.sysUser();
                if (_M_user.Exists(this.txb_User.Text, txb_PassWord.Password))
                {
                   
                    frm_Main f = new frm_Main();
                    f.User = _M_user.GetModel(txb_User.Text);
                    f.Show();
                    this.Close();
                }
                else
                {
                    temLoadCount++;
                    My_MessageBox.My_MessageBox_Message("账户或密码错误！\r\n您还有" + (3 - temLoadCount) + "次机会进行登陆！");
                    if (temLoadCount == 3)
                    {
                        this.Close();
                    }
                }
            }
        }
        
    }
}
