using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


namespace InstallCompenent
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        /// <summary>   
        /// 应用程序入口   
        /// </summary>   
        public static void Main()
        {

        }

        public Installer()
        {
            InitializeComponent();
        }

        /// <summary>   
        /// 重写安装完成后函数   
        /// 实现安装完成后自动启动已安装的程序   
        /// </summary>   
        /// <param name="savedState"></param>   
        protected override void OnAfterInstall(IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            Assembly asm = Assembly.GetExecutingAssembly();
            string path = asm.Location.Remove(asm.Location.LastIndexOf("\\")) + "\\";
           // MessageBox.Show(path); 
           // System.Diagnostics.Process.Start(path + "\\MCP.UI.exe");
        }

        /// <summary>   
        /// 重写安装过程方法   
        /// </summary>   
        /// <param name="stateSaver"></param>   
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
    }
}
