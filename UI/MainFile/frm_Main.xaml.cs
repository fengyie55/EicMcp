using System.Windows;
using Fluent;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using System.Diagnostics;
namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Main : Window
    {
        public frm_Main()
        {
            InitializeComponent();
        }
/******************** Start *********************/


        private void window_Loaded(object sender, RoutedEventArgs e)                // 窗体载入处理事件
        {
            myTimer.Interval = 1000;                            //设置定时器 间隔1s执行一次
            myTimer.Start();                                    //启动定时器
            myTimer.Tick += new EventHandler(myTimer_Tick);     //指定定时器 处理事件
            lab_Time_Show.Visibility = System.Windows.Visibility.Hidden;  //隐藏时间控件

            //显示版本信息
            string str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "sysVersion.ini"; //获取当前版本号
            //本地版本
            IniFiles ini_2 = new IniFiles(str);
            string z2 = ini_2.ReadString("Vsrsion", "z", "");
            string f2 = ini_2.ReadString("Vsrsion", "f", "");
            string c2 = ini_2.ReadString("Vsrsion", "c", "");
            int _Local = int.Parse(z2 + f2 + c2);
            string ss  = "版本：" + z2 + "." + f2 + "." + c2;
       
            txb_Title.Text = "MCP制造与办公管控平台 " + ss;
        }
        
        /****************************  定义变量   ********************************/
       
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        /****************************  窗体处理   ********************************/

        #region 窗体处理
        //
        //关闭窗体
        //
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill(); 
           
        }

        //
        //窗体最小化
        //
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //
        //窗体最大化
        //
        private void btnMaxOrMin_Click(object sender, RoutedEventArgs e)
        {
            Rect rc = SystemParameters.WorkArea;//获取工作区大小
            if (this.Width == rc.Width)
            {
                this.Left = rcnormal.Left;
                this.Top = rcnormal.Top;
                this.Width = rcnormal.Width;
                this.Height = rcnormal.Height;
            }
            else
            {
                rcnormal = new Rect(this.Left, this.Top, this.Width, this.Height);//保存下当前位置与大小
                this.Left = 0;//设置位置
                this.Top = 0;

                this.Width = rc.Width;
                this.Height = rc.Height;
            }
        }

        //
        //移动窗体
        //
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //拖动改变窗体大小
        bool isWiden = false;
        Rect rcnormal;//定义一个全局rect记录还原状态下窗口的位置和大小。

        //
        //鼠标在窗体边缘按下
        //
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isWiden = true;
        }

        //
        //鼠标松开
        //
        private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isWiden = false;
            Border b = (Border)sender;
            b.ReleaseMouseCapture();
        }

        //
        //鼠标移动
        //
        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Border b = (Border)sender;
            if (isWiden)
            {
                b.CaptureMouse();
                double newWidth = e.GetPosition(this).X + 5;
                double newheight = e.GetPosition(this).Y + 5;
                if (newWidth > 0)
                {
                    this.Width = newWidth;

                }
                if (newheight > 0)
                {
                    this.Height = newheight;
                }
            }


        }
        #endregion

        


        /****************************   菜单栏   ********************************/
       
        //
        //信息设置
        //
        private void Setting_Storage_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (User.Privilege == "组长")
            {
                My_MessageBox.My_MessageBox_Message("Sorry！\r\n用户："+User.UserName+"\r\n您无权访问该模块，请更换账户或联系管理员！");
            }
            else
            {
                Setting_Storagle_Content f = new Setting_Storagle_Content();
                f.Title = "检测设置";
                f.Show(DockingManager);             
                f.Activate();               
            }
        }

        //
        //工单设置工序
        //
        private void Setting_Flow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_Set_Process f = new frm_Set_Process();
            f.Title = "工序设置";
            f.Show(DockingManager);
            f.Activate();       
        }
        //
        //包装检测
        //
        private void Inspect_Spackaging_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserControl_Inspect_Packaging f = new UserControl_Inspect_Packaging();
            f.Title = "包装检测";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //物料管控
        //
        private void Material_Stock_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserControl_Material_Management f = new UserControl_Material_Management();
            f.Title = "备料管控";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //标签打印
        //
        private void Label_Print_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserControl_PrintBarcode f = new UserControl_PrintBarcode();
            f.Title = "标签打印";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //成品装箱
        //
        private void Finished_Product_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserControl_Finished_Product f = new UserControl_Finished_Product();
            f.Title = "成品装箱";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //数据报告
        //
        private void Reports_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UserControl_Report f = new UserControl_Report();
            f.Title = "数据报告";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //工单信息
        //
        private void InformationCenter_OrderInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserControl_OrderInfo f = new UserControl_OrderInfo();
            f.Title = "工单信息";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //SPC 管制工具
        //
        private void Tools_SPC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_Tools_SPC f = new frm_Tools_SPC();
            f.Title = "SPC";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //管控设置
        //
        private void Setting_OrderMaterial_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_Setting_OrderMaterialControl f = new frm_Setting_OrderMaterialControl();
            f.Title = "管控设置";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //重工记录
        //
        private void ReWork_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_ReWork f = new frm_ReWork();
            f.Title = "返修记录";
            f.Show(DockingManager);
            f.Activate();
        }
        public Maticsoft.Model.sysUser User
        {
            get;
            set;
        }
        //
        //MPO数据3D数据验证程序
        //
        private void MPO_DataSearch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_SecarcInfo f = new frm_SecarcInfo();
            f.Title = "MPO_3D验证";
            f.Show(DockingManager);
            f.Activate();
        }
        //
        //帮助文档
        //
        private void Help_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string temPath = System.AppDomain.CurrentDomain.BaseDirectory;
            System.Diagnostics.Process.Start(temPath + "Help.CHM");
        }

        //
        //标签打印设置
        //
        private void Setting_LabPrint_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_Setting_Print f = new frm_Setting_Print();
            f.Title = "设置—标签模板";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        // 产品追溯
        //
        private void Info_ProductInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserControl_ProductInfo f = new UserControl_ProductInfo();
            f.Title = "信息中心-产品信息";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        //用户管理
        //
        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (User.Privilege == "系统管理员" || User.Privilege == "主管")
            {
                frm_User f = new frm_User();
                f.Title = "用户管理";
                f.Show(DockingManager);
                f.Activate();
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("Sorry！\r\n用户：" + User.UserName + "\r\n您无权访问该模块，请更换账户或联系管理员！");
            }
        }

        //
        //工单管理
        //
        private void OrderControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            UserControl_OrderControl f = new UserControl_OrderControl();
            f.Title = "工单管理";
            f.Show(DockingManager);
            f.Activate();

        }
        /****************************  事件处理   ********************************/
        
        #region 事件处理
       
        private void myTimer_Tick(object sender, EventArgs e)                       //myTimer处理事件
        {
           
                DateTime time = DateTime.Now;
                this.lab_Time_Show.Text = "当前时间:" + time.ToString();
               // lab_User.Text = User.Privilege + ":" + User.UserName + "欢迎使用本系统！";
                if (this.Topmost == true) { this.Topmost = false; }
          
           
        }
        #endregion

        //
        //产品预刷
        //
        private void Inspect_InspectPigtail_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserControl_Pigtail_Inspect f = new UserControl_Pigtail_Inspect();
            f.Title = "线材预检测";
            f.Show(DockingManager);
            f.Activate();
            My_MessageBox.My_MessageBox_Message("此模式为预检测模式，将不进行任何的更新操作！！！");
        }

        //
        //站长助手
        //
        private void Info_Wk_Helper_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_WorkstationHelper f = new frm_WorkstationHelper();
            f.dockManager = DockingManager;
            f.Title = "管理助手";
            f.Show(DockingManager);
            f.Activate();
        }

        #region 设备管理
        //
        //设备管理
        //
        private void EquipmentMS_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_EquipmentMS_Main f = new frm_EquipmentMS_Main();
            f.Title = "设备管理";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        //治具管理
        //
        private void FixtureMS_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_FixtureMS_Main f = new frm_FixtureMS_Main();
            f.Title = "治具管理";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        //耗材管理
        //
        private void ConsumableMS_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_ConsumableMS_Main f = new frm_ConsumableMS_Main();
            f.Title = "治具管理";
            f.Show(DockingManager);
            f.Activate();
        }

        #endregion

        //
        //生成测试报告
        //
        private void Report_Generate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_Generate_Repot f = new frm_Generate_Repot();
            f.Title = "生成测试报告";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        //员工平台
        //
        private void HR_Employee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_HumanResources f = new frm_HumanResources();
            f.Title = "员工平台";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        //员工列表
        //
        private void UserList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_Employee_MS f = new frm_Employee_MS();
            f.Title = "员工列表";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        //生产报表
        //
        private void ReportForms_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_ReportForms f = new frm_ReportForms();
            f.Title = "生产报表";
            f.Show(DockingManager);
            f.Activate();
        }

        //
        //更新履历
        //
        private void UpdateRecode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }


       
        




















        /******************  END  *****************/      
    }
}
