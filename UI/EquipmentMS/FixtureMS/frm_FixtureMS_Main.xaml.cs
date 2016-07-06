using AvalonDock;
using System.Collections.ObjectModel;
using System.Collections;
using System.Data;
using System.Collections.Generic;

namespace UI
{
    /// <summary>
    /// frm_FixtureMS_Main.xaml 的交互逻辑
    /// </summary>
    public partial class frm_FixtureMS_Main : DocumentContent
    {
        public frm_FixtureMS_Main()
        {
            InitializeComponent();
        }
        ObservableCollection<Maticsoft.Model.FixtureList> _W_FixtureList = new ObservableCollection<Maticsoft.Model.FixtureList>();
        bool Is_Add = false; //标示是否为添加模式
        Maticsoft.Model.FixtureList _W_FixList = new Maticsoft.Model.FixtureList(); //全局变量用于存储待更新的治具

        #region 控件事件


        //
        //刷新列表
        //
        private void btn_Flush_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _W_FixtureList =  MCP_CS.FixtureList.GetModelList1("");
            dgv_FixtureList.ItemsSource = _W_FixtureList;
          
        }

        //
        //窗体载入事件
        //
        private void DocumentContent_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            dgv_FixtureList.ItemsSource = _W_FixtureList;
            cmb_State.ItemsSource = System.Enum.GetNames(typeof(F_Stara));
            cmb_Install.DisplayMemberPath = "Workstation";
            cmb_Install.ItemsSource = MCP_CS._M_Workstation.GetModelList("");
            IsEnControl(false);

            cmb_Search_Type.DisplayMemberPath = "Value";
            cmb_SearchConition.DisplayMemberPath = "Value";
            cmb_Search_Type.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type = 'Fix_查询'");
            cmb_SearchConition.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type = 'FixList_查询'");
        }
          
        //
        //双击治具列表中的治具 
        //
        private void dgv_FixtureList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                frm_Fixture f = new frm_Fixture();
                f.FixtrueInfo = FixList((Maticsoft.Model.FixtureList)dgv_FixtureList.SelectedItem);
                f.Lading_FixtureViws();
                f.Show();
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }

        //
        //添加一个治具
        //
        private void btn_Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Is_Add = true;
            ClearControlValue();
            IsEnControl(true);
        }

        //
        //选择治具
        //
        private void dgv_FixtureList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                _W_FixList = (Maticsoft.Model.FixtureList)dgv_FixtureList.SelectedItem;
                SetControlValue(_W_FixList);
            }
            catch { }
        }


        //
        //编辑治具
        //
        private void btn_Edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Is_Add = false;
            IsEnControl(true);
        }

        //
        //保存治具
        //
        private void btn_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Is_Add)  //如果为添加模式
            { 
                MCP_CS.FixtureList.Add(Get_Fixture());               
            }
            else //否则为更新模式
            {
                MCP_CS.FixtureList.Update(Get_Fixture(_W_FixList));                
            }
            _W_FixtureList = MCP_CS.FixtureList.GetModelList1("");
            dgv_FixtureList.ItemsSource = _W_FixtureList;
            IsEnControl(false);
        }
        //
        //查找治具信息
        //
        private void btn_Search_Aseet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Maticsoft.Model.Equipment_TypeList _temFindType = (Maticsoft.Model.Equipment_TypeList)cmb_Search_Type.SelectedItem;
            dgv_FixtureInfo.ItemsSource = MCP_CS.FixtureInfo.GetModelList(_temFindType.Remarks + " LIKE '%" + txb_Search_Value.Text.Trim() + "%'");
            IsEnControl(false);
            ClearControlValue();
        }

        //
        //查找治具
        //
        private void btn_Search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Maticsoft.Model.Equipment_TypeList _tem = (Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem;
            dgv_FixtureList.ItemsSource = GetSearchResult(_tem, cmb_SerachValue.Text.Trim());
        }

        //
        //选择查询条件
        //
        private void cmb_SearchConition_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Maticsoft.Model.Equipment_TypeList _temEquipment_Typelist = (Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem;
            DataSet temds = MCP_CS.FixtureList.Get_Distinct_List(_temEquipment_Typelist.Remarks);
            cmb_SerachValue.DisplayMemberPath = _temEquipment_Typelist.Remarks;
            if (temds != null)
            {
                cmb_SerachValue.ItemsSource = temds.Tables[0].DefaultView;
            }
        }
       
        //
        //双击FixtureInfo
        //
        private void dgv_FixtureInfo_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frm_Fixture f = new frm_Fixture();
            Maticsoft.Model.FixtureInfo _fix = (Maticsoft.Model.FixtureInfo)dgv_FixtureInfo.SelectedItem;
            f.FixtrueInfo = FixList(_fix);     
            f.Lading_FixtureViws();
            f.Show();
        }
        #endregion



        #region Method
        /// <summary>
        /// 获取治具总表中的治具列表
        /// </summary>
        /// <param name="_Fix"></param>
        /// <returns></returns>
        private ArrayList FixList(Maticsoft.Model.FixtureList _Fix)
        {
            ArrayList tem = new ArrayList();
            /*
            foreach (object fix in MCP_CS.FixtureInfo.GetModelList("(Assembly_BarCode = '" + _Fix.Assembly_BarCode + "')"))
            {
                tem.Add(fix);
            }
             */
            return tem;
             
        }
        /// <summary>
        /// 获取治具总表中的治具列表
        /// </summary>
        /// <param name="_Fix"></param>
        /// <returns></returns>
        private ArrayList FixList(Maticsoft.Model.FixtureInfo _Fix)
        {
            ArrayList tem = new ArrayList();

            foreach (object fix in MCP_CS.FixtureInfo.GetModelList("(Assembly_BarCode = '" + _Fix.Assembly_BarCode + "')"))
            {
                tem.Add(fix);
            }
            return tem;
        }

        /// <summary>
        /// 获取一个 治具 从当前空间中 
        /// </summary>
        /// <returns></returns>
        private Maticsoft.Model.FixtureList Get_Fixture()
        {
            Maticsoft.Model.FixtureList _temFix = new Maticsoft.Model.FixtureList();
         
            _temFix.BarCode = txb_Barcode.Text.Trim();
            _temFix.Fixture_Name = txb_AssetName.Text.Trim();
            _temFix.FAY_ID = txb_AssetNumber.Text.Trim();
            _temFix.InstallLocation = cmb_Install.Text.Trim();
            _temFix.LogDate = dpk_LogDate.SelectedDate;
            _temFix.LogUser = txb_JobNum.Text.Trim();
            _temFix.F_State = cmb_State.Text.Trim();
            _temFix.UseDate = dpk_StateDate.SelectedDate;
            _temFix.ScrapDate = dpk_EndDate.SelectedDate;
            _temFix.CareUser = txb_userName.Text.Trim();
            
            return _temFix;
        }

        /// <summary>
        /// 获取一个 治具 用于更新 
        /// </summary>
        /// <returns></returns>
        private Maticsoft.Model.FixtureList Get_Fixture(Maticsoft.Model.FixtureList _temFix)
        {
            try
            {
                _temFix.BarCode = txb_Barcode.Text.Trim();
                _temFix.Fixture_Name = txb_AssetName.Text.Trim();
                _temFix.FAY_ID = txb_AssetNumber.Text.Trim();
                _temFix.InstallLocation = cmb_Install.Text.Trim();
                _temFix.LogDate = dpk_LogDate.SelectedDate;
                _temFix.LogUser = txb_JobNum.Text.Trim();
                _temFix.F_State = cmb_State.Text.Trim();
                _temFix.UseDate = dpk_StateDate.SelectedDate;
                _temFix.ScrapDate = dpk_EndDate.SelectedDate;
                _temFix.CareUser = txb_userName.Text.Trim();
            }
            catch (SyntaxErrorException ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
            return _temFix;
        }

        /// <summary>
        /// 设置控件的内容
        /// </summary>
        /// <param name="_temFix"></param>
        private void SetControlValue(Maticsoft.Model.FixtureList _temFix)
        {
            if (_temFix != null)
            {
                txb_Barcode.Text = _temFix.BarCode;
                txb_AssetName.Text = _temFix.Fixture_Name;
                txb_AssetNumber.Text = _temFix.FAY_ID;
                cmb_Install.Text = _temFix.InstallLocation;
                dpk_LogDate.SelectedDate = _temFix.LogDate;
                txb_JobNum.Text = _temFix.LogUser;
                cmb_State.Text = _temFix.F_State;
                dpk_StateDate.SelectedDate = _temFix.UseDate;
                dpk_EndDate.SelectedDate = _temFix.ScrapDate;
                if (_temFix.FAY_ID != "")
                {
                    txb_AssetName.Text = MCP_CS.FixtureInfo.GetModel(_temFix.FAY_ID).Assembly_Name;
                }
                if (_temFix.LogUser != "")
                {
                    txb_userName.Text = MCP_CS._M_User.Get_UserName(_temFix.LogUser);
                }
            }
        }

        /// <summary>
        /// 清空控件中的内容
        /// </summary>
        private void ClearControlValue()
        {
            txb_Barcode.Text = "";
            txb_AssetNumber.Text = "";
            cmb_Install.Text = "";
            dpk_LogDate.SelectedDate = null;
            txb_JobNum.Text = "";
            cmb_State.Text = "";
            dpk_StateDate.SelectedDate = null;
            dpk_EndDate.SelectedDate = null;
            txb_userName.Text = "";
            txb_AssetName.Text = "";
        }

        /// <summary>
        /// 是否启用控件
        /// </summary>
        /// <param name="Is_En"></param>
        private void IsEnControl(bool Is_En)
        {
            txb_AssetName.IsEnabled = false;
            txb_userName.IsEnabled = false;
            txb_Barcode.IsEnabled = Is_En;
            txb_AssetNumber.IsEnabled = Is_En;
            cmb_Install.IsEnabled = Is_En;
            dpk_LogDate.IsEnabled = Is_En;
            txb_JobNum.IsEnabled = Is_En;
            cmb_State.IsEnabled = Is_En;
            dpk_StateDate.IsEnabled = Is_En;
            dpk_EndDate.IsEnabled = Is_En;
            btn_Save.IsEnabled = Is_En;
        }


        private ObservableCollection<Maticsoft.Model.FixtureList> GetSearchResult(Maticsoft.Model.Equipment_TypeList _SearchConition, string _SearchValue)
        {
            if (_SearchConition != null)
            {
                if (_SearchValue != "" || _SearchConition.Value != "所有设备")
                {
                    return MCP_CS.FixtureList.GetModelList1(_SearchConition.Remarks + " LIKE '%" + _SearchValue + "%'");
                }
                else { return MCP_CS.FixtureList.GetModelList1(""); }
            }
            else { return MCP_CS.FixtureList.GetModelList1(""); }
        }

        //
        //添加新 治具信息
        //
        private void btn_Add_Asseet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            frm_Fixture f = new frm_Fixture();
            f.Show();
        }

        #endregion



        #region 枚举

        /// <summary>
        /// 设备状态
        /// </summary>
        private enum F_Stara
        {
            未使用,
            使用中,
            维修中,
            借出,
            报废
        }

        #endregion

        //
        //选择总成
        //
        private void dgv_FixtureInfo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                Maticsoft.Model.FixtureInfo _fixtureInfo = (Maticsoft.Model.FixtureInfo)dgv_FixtureInfo.SelectedItem;
                txb_AssetNumber.Text = _fixtureInfo.Assembly_BarCode;
                txb_AssetName.Text = _fixtureInfo.Assembly_Name;
            }
            catch { }
        }

        private void txb_JobNum_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_JobNum.IsFocused)
            {
                txb_userName.Text = MCP_CS._M_User.Get_UserName(txb_JobNum.Text.Trim());
            }
        }

      

       

       

       

        





    }
}
