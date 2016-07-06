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
using AvalonDock;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace UI
{
    /// <summary>
    /// frm_EquipmentMS_Main.xaml 的交互逻辑
    /// </summary>
    public partial class frm_EquipmentMS_Main : DocumentContent
    {
        public frm_EquipmentMS_Main()
        {
            InitializeComponent();
        }

        List<Maticsoft.Model.EquipmentInfo> _W_Equipment = new List<Maticsoft.Model.EquipmentInfo>();
        ObservableCollection<Maticsoft.Model.EquipmentInfo> _W_EquipmentTwo = new ObservableCollection<Maticsoft.Model.EquipmentInfo>();
        bool IsFuzzySearch = true;    //是否开启模糊查询



        //
        //particulars 设备详细信息
        //
        private void btn_Particulars_Click(object sender, RoutedEventArgs e)
        {
            frm_EquipmentInfo f = new frm_EquipmentInfo();            
            f.Show();
        }

        //
        //窗体载入
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_SearchConition.DisplayMemberPath = "Value";
            cmb_SearchConition.ItemsSource = MCP_CS._M_Equipment_TypeList.GetModelList("Type = '查询条件'");
            cmb_SearchConition.SelectedIndex = 0;
            SetDgvSou(MCP_CS._M_Equipment.GetModelList(""));                    
        }

        //
        //双击列表中的项目
        //
        private void dgv_EquipmentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgv_EquipmentList.SelectedItem != null)
            {
                frm_EquipmentInfo f = new frm_EquipmentInfo();
                f.Equipment = (Maticsoft.Model.EquipmentInfo)dgv_EquipmentList.SelectedItem;
                f.Show();
                f.showEquipmentInfo();
            }
        }

        //
        //刷新
        //
        private void btn_Flush_Click(object sender, RoutedEventArgs e)
        {
            SetDgvSou(MCP_CS._M_Equipment.GetModelList(""));         
        }

        //
        //查找
        //
        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            SetDgvSou(GetSearchResult((Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem, cmb_SerachValue.Text));       
        }

        //
        //选择查找条件
        //
        private void cmb_SearchConition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Maticsoft.Model.Equipment_TypeList _temEquipment_Typelist = (Maticsoft.Model.Equipment_TypeList)cmb_SearchConition.SelectedItem;
            DataSet temds = MCP_CS._M_Equipment.Get_Distinct_List(_temEquipment_Typelist.Remarks);
            cmb_SerachValue.DisplayMemberPath = _temEquipment_Typelist.Remarks;
           if(temds != null)
           {
               cmb_SerachValue.ItemsSource = temds.Tables[0].DefaultView;              
           }               
        }

        /// <summary>
        /// 获取查找结果
        /// </summary>
        /// <param name="_SearchConition">查找选项</param>
        /// <param name="_SearchValue">值</param>
        /// <param name="IsFuzzySearch">是否模糊查询</param>
        /// <returns></returns>
        private List<Maticsoft.Model.EquipmentInfo> GetSearchResult(Maticsoft.Model.Equipment_TypeList _SearchConition, string _SearchValue )
        {
            if (_SearchValue != "" || _SearchConition.Value != "所有设备")
            {
                if (IsFuzzySearch)
                {
                    return MCP_CS._M_Equipment.GetModelList(_SearchConition.Remarks + " = '" + _SearchValue + "'");
                }
                else { return MCP_CS._M_Equipment.GetModelList(_SearchConition.Remarks + " LIKE '%" + _SearchValue + "%'"); }
            }
            else { return MCP_CS._M_Equipment.GetModelList(""); }
        }


        /// <summary>
        /// 设置数据源
        /// </summary>
        /// <param name="_EquipmentList"></param>
        private void SetDgvSou(List<Maticsoft.Model.EquipmentInfo> _EquipmentList)
        {
            _W_Equipment = _EquipmentList;
            dgv_EquipmentList.ItemsSource = _EquipmentList;
            lab_Count.Content = "记录:" + (dgv_EquipmentList.Items.Count-1) + "条";
        }

        //
        //精确查询
        //
        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            IsFuzzySearch = true;
        }

        //
        //模糊查询
        //
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            IsFuzzySearch = false;
        }





        

           
       

       
    }
}
