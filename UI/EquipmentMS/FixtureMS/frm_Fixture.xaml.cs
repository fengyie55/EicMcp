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
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Collections;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// frm_Fixture.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Fixture : Window
    {
        public frm_Fixture()
        {
            InitializeComponent();
        }

        #region 全局变量

        ObservableCollection<PropertyNodeItem> itemList
           = new ObservableCollection<PropertyNodeItem>();
        Maticsoft.Model.FixtureInfo _W_FixtureInfo = new Maticsoft.Model.FixtureInfo();

        private bool Is_Add = false;   //是否为添加模式


        //定义TreeView 图片
        string TAG_ICON = "D:\\模板\\Images\\考评管理.png";
        string EDITABLE_ICON = "D:\\模板\\Images\\奖罚管理.png";
        string FOLDER_ICON = "D:\\模板\\Images\\工资管理.png";




        #endregion


        #region 属性

        /// <summary>
        /// 治具信息
        /// </summary>
        public  ArrayList FixtrueInfo { get; set; }

        #endregion


        #region 供外部调用的方法
        /// <summary>
        /// 加载治具视图
        /// </summary>
        public void Lading_FixtureViws()
        {           
            if (FixtrueInfo.Count > 0)
            {
                Maticsoft.Model.FixtureInfo _TemFixtureInfo = (Maticsoft.Model.FixtureInfo)FixtrueInfo[0];

                if (FixtrueInfo.Count == 1)  //如果只有一个总成 
                {                  
                    //治具总名称  
                    PropertyNodeItem node1 = new PropertyNodeItem()
                    {
                        DisplayName = _TemFixtureInfo.Assembly_Name,
                        Name = "总成名称",
                        Icon = TAG_ICON,
                       
                        Fixture = _TemFixtureInfo
                    };
                    itemList.Add(node1);
                }
                else //如果总成下面有很多的治具
                {                  
                    //治具总名称  
                    PropertyNodeItem node1 = new PropertyNodeItem()
                    {
                        DisplayName = _TemFixtureInfo.Assembly_Name,
                        Name = "总成名称",
                        Icon = TAG_ICON,
                       
                        Fixture = _TemFixtureInfo
                    };

                    foreach (object Fixture in FixtrueInfo)
                    {
                        Maticsoft.Model.FixtureInfo _tem = (Maticsoft.Model.FixtureInfo)Fixture;
                        PropertyNodeItem node1tag1 = new PropertyNodeItem()
                        {
                            DisplayName = _tem.Name,
                            Name = _tem.BarCode,
                            Icon = TAG_ICON,
                           
                            Fixture = _tem
                        };
                        node1.Children.Add(node1tag1);
                    }
                    itemList.Clear();
                    itemList.Add(node1);
                    SetControl_IsEn(false,false);
                }             
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("未找到治具信息！");
            }                   
        }

        #endregion


        #region 控件事件
        
        //
        //窗体载入事件
        //
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.trv_FixtureView.ItemsSource = itemList;
            cmb_Search_Type.DisplayMemberPath = "Value";
            cmb_Search_Type.ItemsSource =  MCP_CS._M_Equipment_TypeList.GetModelList("Type = 'Fix_查询'");
            cmb_Search_Type.SelectedIndex = 0;
        }

        //
        //TreeView 双击事件
        //
        private void trv_FixtureView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            PropertyNodeItem t = (PropertyNodeItem)trv_FixtureView.SelectedItem;
            _W_FixtureInfo = t.Fixture;
            ShowFixture(t.Fixture);
        }

        //
        //右键菜单-添加
        //
        private void Mei_Add_Checked(object sender, RoutedEventArgs e)
        {
            Is_Add = true;  //保存模式为添加模式
            Clear_Control(false);
            SetControl_IsEn(true, false);
        }

        //
        //右键菜单-删除
        //
        private void Mei_Delete_Checked(object sender, RoutedEventArgs e)
        {
            if (trv_FixtureView.SelectedItem != null)
            {
                PropertyNodeItem t = (PropertyNodeItem)trv_FixtureView.SelectedItem;
                if (MCP_CS.FixtureInfo.Delete(t.Fixture.FAY_ID))
                {
                    My_MessageBox.My_MessageBox_Message("删除成功！");
                    FixtrueInfo = GetFixInfoList(_W_FixtureInfo);
                    Lading_FixtureViws();                  
                }
                else { My_MessageBox.My_MessageBox_Message("删除失败！"); }
            }
            else { My_MessageBox.My_MessageBox_Message("请选择需要删除的项！"); }
        }

        //
        //测试按钮
        //
        private void btn_Test_Click(object sender, RoutedEventArgs e)
        {
            // ShowTreeView();
            Lading_FixtureViws();
        }

        //
        //保存更新
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (Is_Add)
            {             
                _W_FixtureInfo = MCP_CS.FixtureInfo.GetModel( MCP_CS.FixtureInfo.Add(GetModel()));
                FixtrueInfo = GetFixInfoList(_W_FixtureInfo);
                Lading_FixtureViws();
            }
            else
            {
                GetModel(_W_FixtureInfo);
                MCP_CS.FixtureInfo.Update(_W_FixtureInfo);
                Lading_FixtureViws();
            }
        }
        //
        //编辑信息
        //
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            Is_Add = false; //不是添加模式
            SetControl_IsEn(true,false);
        }

        //
        //新建治具
        //
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Is_Add = true;  //保存模式为添加模式
            Clear_Control(true);        
            SetControl_IsEn(true,true);
        }

        //
        //新增部件
        //
        private void btn_Add_Parts_Click(object sender, RoutedEventArgs e)
        {
            Is_Add = true;  //保存模式为添加模式
            Clear_Control(false);
            SetControl_IsEn(true, false);
        }

        //
        //查找
        //
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.Model.Equipment_TypeList _temFindType = (Maticsoft.Model.Equipment_TypeList)cmb_Search_Type.SelectedItem;
            dgv_FixInfo_List.ItemsSource = MCP_CS.FixtureInfo.GetModelList(_temFindType.Remarks + "= '" + txb_Search_Value.Text.Trim() + "'");
        }

        //
        //双击查找的治具
        //
        private void dgv_FixInfo_List_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clear_Control(true);

            _W_FixtureInfo = (Maticsoft.Model.FixtureInfo)dgv_FixInfo_List.SelectedItem;
            FixtrueInfo = GetFixInfoList(_W_FixtureInfo);
            Lading_FixtureViws();       
        }

       

        #endregion


        #region Method


        /// <summary>
        /// 显示治具的信息
        /// </summary>
        /// <param name="?"></param>
        private void ShowFixture(Maticsoft.Model.FixtureInfo _Fix)
        {
            
            if (_Fix != null)
            {
                txb_Assrt_Name.Text = _Fix.Assembly_Name;
                txb_AssetNumber.Text = _Fix.Assembly_BarCode;
                txb_BarCode.Text = _Fix.BarCode;
                txb_Name.Text = _Fix.Name;
                txb_AliasName.Text = _Fix.Alias;
                txb_Model.Text = _Fix.Model;
                txb_FunctionRemarks.Text = _Fix.FunctionRemarks;
                txb_Correlation.Text = _Fix.Correlation_ID;
                txb_SafeCount.Text = _Fix.SafeCount;
                cmb_Unit.Text = _Fix.Unit;
                cmb_Versions.Text = _Fix.Versions;
                txb_DrawingPatch.Text = _Fix.DrawingPatch;
                txb_PicID.Text = _Fix.Pic_ID;
            }
            else { My_MessageBox.My_MessageBox_Message("未找到此治具信息！"); }
        }

        /// <summary>
        /// 从窗体中获取一个 Fixture 用于添加
        /// </summary>
        /// <returns></returns>
        private Maticsoft.Model.FixtureInfo GetModel()
        {
            Maticsoft.Model.FixtureInfo _TemFixture = new Maticsoft.Model.FixtureInfo();

            _TemFixture.Assembly_BarCode = txb_AssetNumber.Text.Trim();
            _TemFixture.Assembly_Name = txb_Assrt_Name.Text.Trim();
            _TemFixture.BarCode = txb_BarCode.Text.Trim();
            _TemFixture.Name = txb_Name.Text.Trim();
            _TemFixture.Alias = txb_AliasName.Text.Trim();
            _TemFixture.FunctionRemarks = txb_FunctionRemarks.Text.Trim();
            _TemFixture.Model = txb_Model.Text.Trim();
            _TemFixture.Correlation_ID = txb_Correlation.Text.Trim();
            _TemFixture.SafeCount = txb_SafeCount.Text.Trim();
            _TemFixture.Unit = cmb_Unit.Text.Trim();
            _TemFixture.Versions = cmb_Versions.Text.Trim();
            _TemFixture.DrawingPatch = txb_DrawingPatch.Text.Trim();
            _TemFixture.Pic_ID = txb_PicID.Text.Trim();

            return _TemFixture;
        }

        /// <summary>
        /// 返回Fix 用于更新
        /// </summary>
        /// <param name="_TemFixture"></param>
        /// <returns></returns>
        private Maticsoft.Model.FixtureInfo GetModel(Maticsoft.Model.FixtureInfo _TemFixture) 
        {
            _TemFixture.Assembly_BarCode = txb_AssetNumber.Text.Trim();
            _TemFixture.Assembly_Name = txb_Assrt_Name.Text.Trim();
            _TemFixture.BarCode = txb_BarCode.Text.Trim();
            _TemFixture.Name = txb_Name.Text.Trim();
            _TemFixture.Alias = txb_AliasName.Text.Trim();
            _TemFixture.FunctionRemarks = txb_FunctionRemarks.Text.Trim();
            _TemFixture.Model = txb_Model.Text.Trim();
            _TemFixture.Correlation_ID = txb_Correlation.Text.Trim();
            _TemFixture.SafeCount = txb_SafeCount.Text.Trim();
            _TemFixture.Unit = cmb_Unit.Text.Trim();
            _TemFixture.Versions = cmb_Versions.Text.Trim();
            _TemFixture.DrawingPatch = txb_DrawingPatch.Text.Trim();
            _TemFixture.Pic_ID = txb_PicID.Text.Trim();
            return _TemFixture;
        }

        /// <summary>
        /// 设置控件 是否启用
        /// </summary>
        /// <param name="_IsEn"></param>
        private void SetControl_IsEn(bool _IsEn,bool _IsEn_Asset)
        {
            txb_AssetNumber.IsEnabled = _IsEn_Asset;
            txb_Assrt_Name.IsEnabled = _IsEn_Asset;
            txb_AliasName.IsEnabled = _IsEn;
            txb_BarCode.IsEnabled = _IsEn;
            txb_Name.IsEnabled = _IsEn;
            txb_AliasName.IsEnabled = _IsEn;
            txb_FunctionRemarks.IsEnabled = _IsEn;
            txb_Model.IsEnabled = _IsEn;
            txb_Correlation.IsEnabled = _IsEn;
            txb_SafeCount.IsEnabled = _IsEn;
            cmb_Unit.IsEnabled = _IsEn;
            cmb_Versions.IsEnabled = _IsEn;
            txb_DrawingPatch.IsEnabled = _IsEn;
            txb_PicID.IsEnabled = _IsEn;
            btn_Save.IsEnabled = _IsEn;
        }

        /// <summary>
        /// 清空控件中的内容
        /// </summary>
        private void Clear_Control(bool _IsCla_Asset)
        {
            if (_IsCla_Asset)
            {
                itemList.Clear();
                txb_AssetNumber.Text = "";
                txb_Assrt_Name.Text = "";
            }

            txb_AliasName.Text = "";
            txb_BarCode.Text = "";
            txb_Name.Text = "";
            txb_AliasName.Text = "";
            txb_FunctionRemarks.Text = "";
            txb_Model.Text = "";
            txb_Correlation.Text = "";
            txb_SafeCount.Text = "";
            cmb_Unit.Text = "";
            cmb_Versions.Text = "";
            txb_DrawingPatch.Text = "";
            txb_PicID.Text = "";
            
            btn_Save.IsEnabled = true;
        }

        /// <summary>
        /// 获取治具列表
        /// </summary>
        /// <param name="_Fix"></param>
        /// <returns></returns>
        private ArrayList GetFixInfoList(Maticsoft.Model.FixtureInfo _Fix)
        {
            ArrayList tem = new ArrayList();
            foreach (object _temFix in MCP_CS.FixtureInfo.GetModelList("(Assembly_BarCode = '" + _Fix.Assembly_BarCode + "')"))
            {
                tem.Add(_temFix);
            }
            return tem;
        }

        #endregion

        //
        //设置图纸路径
        //
        private void btn_SetDwingPatch_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog();
            txb_DrawingPatch.Text = f.SelectedPath;
           
        }

       

       

       

       

        
       

       

    }  //-----------END




    #region 定义结构体 
    internal class PropertyNodeItem
    {
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 编辑图标
        /// </summary>
        public string EditIcon { get; set; }
        /// <summary>
        /// 显示的内容
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 鼠标放上去后显示的内容
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 治具
        /// </summary>
        public Maticsoft.Model.FixtureInfo Fixture { get; set; }

        /// <summary>
        /// 子列表
        /// </summary>
        public ObservableCollection<PropertyNodeItem> Children { get; set; }

        public PropertyNodeItem()
        {
            Children = new ObservableCollection<PropertyNodeItem>();
        }

        public delegate void GetDataEventHandler();        //委托定义

        /// <summary>
        /// 支持调用的自定义事件
        /// </summary>
        public event GetDataEventHandler My_MouseDown;     //事件定义 

        /// <summary>
        /// 执行事件
        /// </summary>
        public void sta() { if (My_MouseDown != null) { My_MouseDown(); } }
    }
    #endregion


}
