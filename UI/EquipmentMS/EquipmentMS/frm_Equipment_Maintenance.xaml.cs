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

namespace UI
{
    /// <summary>
    /// frm_Equipment_Maintenance.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Equipment_Maintenance : Window
    {
        private Maticsoft.Model.Equipment_Maintain _Maintain = new Maticsoft.Model.Equipment_Maintain();
        private Maticsoft.Model.EquipmentInfo _Equipment = new Maticsoft.Model.EquipmentInfo();

        /// <summary>
        /// 默认初始化函数
        /// </summary>
        public frm_Equipment_Maintenance()
        {
            InitializeComponent();
            cmb_ResultCode.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = 'Ma_验收结果'");          
            grd_Maintain.DataContext = Maintain;
        }

        /// <summary>
        /// 由申请单进行初始化
        /// </summary>
        /// <param name="_Maintain"></param>
        public frm_Equipment_Maintenance(Maticsoft.Model.Equipment_Maintain _Maintain)
        {
            InitializeComponent();
            cmb_ResultCode.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = 'Ma_验收结果'");
            btn_Apply.IsEnabled = false;
            Maintain = _Maintain;
            grd_Maintain.DataContext = Maintain;
        }

        /// <summary>
        /// 由设备进行初始化
        /// </summary>
        /// <param name="_Equipment"></param>
        public frm_Equipment_Maintenance(Maticsoft.Model.EquipmentInfo _Equipment)
        {
            InitializeComponent();
            this._Equipment = _Equipment;
            cmb_ResultCode.ItemsSource = MCP_CS._M_Equipment_TypeList.GetStringList("Type = 'Ma_验收结果'");
            Maintain.Ass_Num = _Equipment.AssetNum;
            Maintain.Ass_Name = _Equipment.AssetName;
            Maintain.Ass_MakeNum = _Equipment.MakeNum;
            Maintain.Ass_Type = _Equipment.AssetType;
            Maintain.Apply_Date = DateTime.Now.ToString();
            grd_Maintain.DataContext = Maintain;
        }

        /// <summary>
        /// 设备维修单
        /// </summary>
        public Maticsoft.Model.Equipment_Maintain Maintain { get { return _Maintain; } 
            set { _Maintain = value; grd_Maintain.DataContext = Maintain; } }


        //
        //申请维修
        //
        private void btn_Apply_Click(object sender, RoutedEventArgs e)
        {
            Maintain.Check_Result = "待维修";
            Maintain.FormNum = MCP_CS.Enquipment_Maintain.GetMaxID(); //设置表单编号           
            if (MCP_CS.Enquipment_Maintain.Add(Maintain) > 0 && _Equipment.AssetNum!= "")
            {
                _Equipment.State = "停机待修";
                MCP_CS._M_Equipment.Update(_Equipment);
                My_MessageBox.My_MessageBox_Message("提交成功！\r\n请电话通知维修人员进行维修！");
            }
            else { My_MessageBox.My_MessageBox_Message("提交失败！"); }
            grd_Maintain.DataContext = Maintain; //更新数据源在窗体的显示
        }


        /// <summary>
        /// 操作模式
        /// </summary>
        public enum OperationMode
        {
            Add,
            Edit,
            Delete,
            Save
        }

        //
        //维修完成提交
        //
        private void btn_Maintain_Click(object sender, RoutedEventArgs e)
        {          
            Maintain.Maintain_Date = DateTime.Now.ToString();
            if (MCP_CS.Enquipment_Maintain.Update(Maintain))
                My_MessageBox.My_MessageBox_Message("提交成功！\r\n请通知申请人进行表单确认");
            else { My_MessageBox.My_MessageBox_Message("提交失败！"); }
            grd_Maintain.DataContext = Maintain; //更新数据源在窗体的显示
        }

        //
        //验收
        //
        private void btn_Check_Click(object sender, RoutedEventArgs e)
        {
            _Equipment = MCP_CS._M_Equipment.GetModel(Maintain.Ass_Num);
            _Equipment.State = "使用中";
            Maintain.Check_Date = DateTime.Now.ToString();
            if (MCP_CS.Enquipment_Maintain.Update(Maintain))
            {
                MCP_CS._M_Equipment.Update(_Equipment);
                My_MessageBox.My_MessageBox_Message("提交成功！\r\n本次维修完成！");
            }
            else { My_MessageBox.My_MessageBox_Message("提交失败！"); }
            grd_Maintain.DataContext = Maintain; //更新数据源在窗体的显示
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }  
}
