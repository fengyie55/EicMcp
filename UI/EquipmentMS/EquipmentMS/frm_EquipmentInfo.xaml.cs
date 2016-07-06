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
    /// frm_EquipmentInfo.xaml 的交互逻辑
    /// </summary>
    public partial class frm_EquipmentInfo : Window
    {
        public frm_EquipmentInfo()
        {
            InitializeComponent();
        }

        private Maticsoft.Model.EquipmentInfo _Equipment = new Maticsoft.Model.EquipmentInfo();
        #region 属性

        /// <summary>
        /// 设备
        /// </summary>
        public Maticsoft.Model.EquipmentInfo Equipment { get { return _Equipment; } set { _Equipment = value; } }


        public void showEquipmentInfo() { ShowEquipmentInfo(Equipment); }
        #endregion


        #region 控件

        //
        //设备维修
        //
        private void btn_Equipment_Maintenance_Click(object sender, RoutedEventArgs e)
        {
            List<Maticsoft.Model.Equipment_Maintain> _tem
                = MCP_CS.Enquipment_Maintain.GetModelList("Ass_Num = '" + Equipment.AssetNum + "' AND Check_result = '待维修'");
            if (_tem.Count > 0)  //如果已存在待维修
            {
                frm_Equipment_Maintenance f = new frm_Equipment_Maintenance(_tem[0]);
                f.Show();
            }
            else
            {
                frm_Equipment_Maintenance f = new frm_Equipment_Maintenance(Equipment);
                f.Show();
            }
        }

        //
        //窗体载入
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IsEn_Control(false); //禁用设备信息控件
            btn_Save.IsEnabled = false;

            cmb_AddMode.DisplayMemberPath = "Value";
            cmb_AddMode.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='增加方式'");
            cmb_AddMode.SelectedIndex = 0;
            //
            cmb_AssetType.DisplayMemberPath = "Value";
            cmb_AssetType.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='资产类别'");
            cmb_AssetType.SelectedIndex = 0;
            //
            cmb_State.DisplayMemberPath = "Value";
            cmb_State.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='状态'");
            cmb_State.SelectedIndex = 0;
            //
            cmb_Unit.DisplayMemberPath = "Value";
            cmb_Unit.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='单位'");
            cmb_Unit.SelectedIndex = 0;
            //
            cmb_Department.DisplayMemberPath = "Value";
            cmb_Department.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='部门'");
            cmb_Department.SelectedIndex = 0;
            //
            cmb_InstallationSite.DisplayMemberPath = "Workstation";
            cmb_InstallationSite.ItemsSource = MCP_CS._M_Workstation.GetModelList("");
            cmb_InstallationSite.SelectedIndex = 0;

        }

        //
        //设备添加
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            cmb_AddMode.DisplayMemberPath = "Value";
            cmb_AddMode.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='增加方式'");
            cmb_AddMode.SelectedIndex = 0;
            //
            cmb_AssetType.DisplayMemberPath = "Value";
            cmb_AssetType.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='资产类别'");
            cmb_AssetType.SelectedIndex = 0;
            //
            cmb_State.DisplayMemberPath = "Value";
            cmb_State.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='状态'");
            cmb_State.SelectedIndex = 0;
            //
            cmb_Unit.DisplayMemberPath = "Value";
            cmb_Unit.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='单位'");
            cmb_Unit.SelectedIndex = 0;
            //
            cmb_Department.DisplayMemberPath = "Value";
            cmb_Department.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type='部门'");
            cmb_Department.SelectedIndex = 0;
            //
            cmb_InstallationSite.DisplayMemberPath = "Workstation";
            cmb_InstallationSite.ItemsSource = MCP_CS._M_Workstation.GetModelList("");
            cmb_InstallationSite.SelectedIndex = 0;
        
            IsEn_Control(true);
            btn_Save.IsEnabled = true;
        }

        //
        //保存更改
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (txb_AssetNum.Text != "")
            {
                if (MCP_CS._M_Equipment.Exists(Equipment.Eqp_ID)) //判断记录是否存在
                {
                    Equipment = Get_Equipment_for_Control(Equipment);
                    if (MCP_CS._M_Equipment.Update(Equipment)) //存在则更新记录
                    {
                        My_MessageBox.My_MessageBox_Message("更新成功！");
                        btn_Edit.IsEnabled = true;
                        btn_Save.IsEnabled = false;
                        IsEn_Control(false);
                    }
                    else { My_MessageBox.My_MessageBox_Message("未更新！\r\n更新设备时失败，请确认信息是否完整！"); }
                }
                else //不存在则添加记录
                {
                    Equipment = Get_Equipment_for_Control();
                    if (MCP_CS._M_Equipment.Add(Equipment) > 0)
                    {
                        My_MessageBox.My_MessageBox_Message("添加成功！");
                        btn_Edit.IsEnabled = true;
                        btn_Save.IsEnabled = false;
                        IsEn_Control(false);
                    }
                    else { My_MessageBox.My_MessageBox_Message("未添加！\r\n添加设备时失败，请确认信息是否完整！"); }
                }
            }
            else { My_MessageBox.My_MessageBox_Message("未添加！\r\n添加设备时失败，请确认信息是否完整！"); }
        }


        //
        //编辑
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {       
            IsEn_Control(true);
            btn_Save.IsEnabled = true;
        }
        


        #endregion



        #region Method

        /// <summary>
        /// 显示设备信息
        /// </summary>
        /// <param name="_Equipment"></param>
        /// <returns></returns>
        private bool ShowEquipmentInfo(Maticsoft.Model.EquipmentInfo _Equipment)
        {
            if (_Equipment.AssetNum != null)
            {
                cmb_AssetType.Text = _Equipment.AssetType;
                cmb_Department.Text = _Equipment.Department;
                cmb_InstallationSite.Text = _Equipment.InstallationSite;
                cmb_AddMode.Text = _Equipment.AddMode;
                if (_Equipment.VerifyDate != null) { dtp_VerigyDate.DisplayDate = (DateTime)_Equipment.VerifyDate; }
                txb_VerifyInterval.Text = _Equipment.VerifyInterval;
                if (_Equipment.MaintenanceDate != null) { dtp_MaintenanceDate.DisplayDate = (DateTime)_Equipment.MaintenanceDate; }
                txb_MaintenanceInterval.Text = _Equipment.MaintenanceInterval;
                if (_Equipment.LoginDate != null) { dtp_LoginDate.DisplayDate = (DateTime)_Equipment.LoginDate; }
                txb_UsefulLife.Text = _Equipment.UsefulLife;
                txb_DeliveryUser.Text = _Equipment.DeliveryUser;
                txb_CheckUser.Text = _Equipment.CheckUser;
                txb_CareUser.Text = _Equipment.CareUser;
                //
                txb_AssetNum.Text = _Equipment.AssetNum;
                txb_AssetName.Text = _Equipment.AssetName;
                txb_AliasName.Text = _Equipment.AliasName;
                txb_MakeNum.Text = _Equipment.MakeNum;
                cmb_State.Text = _Equipment.State;
                txb_Count.Text = _Equipment.Count;
                cmb_Unit.Text = _Equipment.Unit;
                txb_Efficiency.Text = _Equipment.Efficiency;
                txb_EquipmentOee.Text = _Equipment.EquipentOEE;
                //
                txb_EquipmentModel.Text = _Equipment.EquipentModel;
                txb_EquipmentSpecification.Text = _Equipment.Specification;
                txb_FunctionDescription.Text = _Equipment.FunctionDescription;
                //
                txb_Supplier.Text = _Equipment.Supplier;
                if (_Equipment.ManufacturingDate != null) { dtp_ManufacturingDate.DisplayDate = (DateTime)_Equipment.ManufacturingDate; }
                txb_OfficialWedsite.Text = _Equipment.OfficialWedsite;
                txb_AferSaleTel.Text = _Equipment.AferSaleTel;
                txb_PhotoPatch.Text = _Equipment.PhotoPatch;
                txb_SafetySpecification.Text = _Equipment.SafetySpecification;
                txb_OI.Text = _Equipment.OI;
                txb_ChechSheet.Text = _Equipment.ChechSheet;

                dgv_Maintain.ItemsSource = MCP_CS.Enquipment_Maintain.GetModelList("Ass_Num = '"+_Equipment.AssetNum+"'");
                return true;
            }
            else
            {
                btn_Edit.IsEnabled = false;            
                return false;                
            }
        }

        /// <summary>
        /// 获取一台设备 用于更新
        /// </summary> 
        /// <param name="_Euipment"></param>
        /// <returns></returns>
        private Maticsoft.Model.EquipmentInfo Get_Equipment_for_Control(Maticsoft.Model.EquipmentInfo _Euipment)
        {
            _Euipment.AssetType = cmb_AssetType.Text.Trim();
            _Euipment.Department = cmb_Department.Text.Trim();
            _Euipment.InstallationSite = cmb_InstallationSite.Text.Trim();
            _Euipment.AddMode = cmb_AddMode.Text.Trim();
            _Euipment.VerifyDate = dtp_VerigyDate.DisplayDate;
            _Euipment.VerifyInterval = txb_VerifyInterval.Text.Trim();
            _Euipment.MaintenanceDate = dtp_MaintenanceDate.DisplayDate;
            _Euipment.MaintenanceInterval = txb_MaintenanceInterval.Text.Trim();
            _Euipment.LoginDate = dtp_LoginDate.DisplayDate;
            _Euipment.UsefulLife = txb_UsefulLife.Text.Trim();
            _Euipment.DeliveryUser = txb_DeliveryUser.Text.Trim();
            _Euipment.CheckUser = txb_CheckUser.Text.Trim();
            _Euipment.CareUser = txb_CareUser.Text.Trim();
            //
            _Euipment.AssetNum = txb_AssetNum.Text.Trim();
            _Euipment.AssetName = txb_AssetName.Text.Trim();
            _Euipment.AliasName = txb_AliasName.Text.Trim();
            _Euipment.MakeNum = txb_MakeNum.Text.Trim();
            _Euipment.State = cmb_State.Text.Trim();
            _Euipment.Count = txb_Count.Text.Trim();
            _Euipment.Unit = cmb_Unit.Text.Trim();
            _Euipment.Efficiency = txb_Efficiency.Text.Trim();
            _Euipment.EquipentOEE = txb_EquipmentOee.Text.Trim();
            //
            _Euipment.EquipentModel = txb_EquipmentModel.Text.Trim();
            _Euipment.Specification = txb_EquipmentSpecification.Text.Trim();
            _Euipment.FunctionDescription = txb_FunctionDescription.Text.Trim();
            //
            _Euipment.Supplier = txb_Supplier.Text.Trim();
            _Euipment.ManufacturingDate = dtp_ManufacturingDate.DisplayDate;
            _Euipment.OfficialWedsite = txb_OfficialWedsite.Text.Trim();
            _Euipment.AferSaleTel = txb_AferSaleTel.Text.Trim();
            _Euipment.PhotoPatch = txb_PhotoPatch.Text.Trim();
            _Euipment.SafetySpecification = txb_SafetySpecification.Text.Trim();
            _Euipment.OI = txb_OI.Text.Trim();
            _Euipment.ChechSheet = txb_ChechSheet.Text;

            return _Euipment;
        }

        /// <summary>
        /// 获取一台设备 用于新增
        /// </summary>
        /// <returns></returns>
        private Maticsoft.Model.EquipmentInfo Get_Equipment_for_Control()
        {
            Maticsoft.Model.EquipmentInfo _TemEquipment = new Maticsoft.Model.EquipmentInfo()
            {
                AssetType = cmb_AssetType.Text.Trim(),
                Department = cmb_Department.Text.Trim(),
                InstallationSite = cmb_InstallationSite.Text.Trim(),
                AddMode = cmb_AddMode.Text.Trim(),
                VerifyDate = dtp_VerigyDate.DisplayDate,
                VerifyInterval = txb_VerifyInterval.Text.Trim(),
                MaintenanceDate = dtp_MaintenanceDate.DisplayDate,
                MaintenanceInterval = txb_MaintenanceInterval.Text.Trim(),
                LoginDate = dtp_LoginDate.DisplayDate,
                UsefulLife = txb_UsefulLife.Text.Trim(),
                DeliveryUser = txb_DeliveryUser.Text.Trim(),
                CheckUser = txb_CheckUser.Text.Trim(),
                CareUser = txb_CareUser.Text.Trim(),
                //
                AssetNum = txb_AssetNum.Text.Trim(),
                AssetName = txb_AssetName.Text.Trim(),
                AliasName = txb_AliasName.Text.Trim(),
                MakeNum = txb_MakeNum.Text.Trim(),
                State = cmb_State.Text.Trim(),
                Count = txb_Count.Text.Trim(),
                Unit = cmb_Unit.Text.Trim(),
                Efficiency = txb_Efficiency.Text.Trim(),
                EquipentOEE = txb_EquipmentOee.Text.Trim(),
                //
                EquipentModel = txb_EquipmentModel.Text.Trim(),
                Specification = txb_EquipmentSpecification.Text.Trim(),
                FunctionDescription = txb_FunctionDescription.Text.Trim(),
                //
                Supplier = txb_Supplier.Text.Trim(),
                ManufacturingDate = dtp_ManufacturingDate.DisplayDate,
                OfficialWedsite = txb_OfficialWedsite.Text.Trim(),
                AferSaleTel = txb_AferSaleTel.Text.Trim(),
                PhotoPatch = txb_PhotoPatch.Text.Trim(),
                SafetySpecification = txb_SafetySpecification.Text.Trim(),
                OI = txb_OI.Text.Trim(),
                ChechSheet = txb_ChechSheet.Text.Trim()
            };
            return _TemEquipment;
        }


        /// <summary>
        /// 禁用或启用控件
        /// </summary>
        public void IsEn_Control(bool IsEn)
        {
            foreach (object C in grd_EquipmentInfo.Children)
            {
                if (C is TextBox)
                {
                    ((TextBox)C).IsEnabled = IsEn;
                }
                else if (C is Button)
                {
                    ((Button)C).IsEnabled = IsEn;
                }
                else if (C is ComboBox)
                {
                    ((ComboBox)C).IsEnabled = IsEn;
                }
                else if (C is DatePicker)
                {
                    ((DatePicker)C).IsEnabled = IsEn;
                }
            }
        }
        
        #endregion


        //
        //选择维修记录
        //
        private void dgv_Maintain_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (dgv_Maintain.SelectedItem != null)
                {
                    Maticsoft.Model.Equipment_Maintain _tem = (Maticsoft.Model.Equipment_Maintain)dgv_Maintain.SelectedItem;
                    frm_Equipment_Maintenance f = new frm_Equipment_Maintenance(_tem);
                    f.Show();
                }
            }
            catch { }
        }

       


       

        
    }
}
