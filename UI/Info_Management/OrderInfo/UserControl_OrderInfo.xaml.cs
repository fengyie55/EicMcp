using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using AvalonDock;
using Visifire.Charts;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace UI
{
    /// <summary>
    /// UserControl_Material.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_OrderInfo : DocumentContent
    {
        public UserControl_OrderInfo()
        {
            InitializeComponent();
        }

        #region 全局变量
        Maticsoft.BLL.WorkOrder _WorkOrder = new Maticsoft.BLL.WorkOrder();
        DataSet _WTT_MaterialList = new DataSet();
        #endregion


        #region 功能菜单
        /***************************** 功能菜单  ***********************************/

        //
        //查询工单信息
        //
        private void txb_OrderID_KeyUp(object sender, KeyEventArgs e)
        {
            if (txb_OrderID.IsFocused && e.Key == Key.Enter)
            {
                if (txb_OrderID.Text != "")
                {
                    showOrderInfo(txb_OrderID.Text); //控件中显示工单信息
                }
                else { My_MessageBox.My_MessageBox_Message("请输入工单单号!"); }
            }
        }

        //
        //工单领料
        //
        private void btn_OrderReceiveMaterial_Click(object sender, RoutedEventArgs e)
        {
            frm_OrderReciveMaterial f = new frm_OrderReciveMaterial();

            if (_WTT_MaterialList !=null && _WTT_MaterialList.Tables[0].Rows.Count > 0)
            {
                f.OrderID = txb_OrderID.Text.Trim();
                f.MaterialList = _WTT_MaterialList;

                f.Show();
                f.Activate();
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("未找到该工单料件列表！请确定该工单是否已经开工！");
            }
        }

        private void expander1_MouseLeave(object sender, MouseEventArgs e)
        {
            expander1.IsExpanded = false;
        }
        //
        //工单投料
        //
        private void btn_OrderInjectMaterial_Click(object sender, RoutedEventArgs e)
        {
            frm_OrderInject_Material f = new frm_OrderInject_Material();
            if (_WTT_MaterialList != null && _WTT_MaterialList.Tables[0].Rows.Count > 0)
            {
                f.OrderID = txb_OrderID.Text.Trim();
                
                f.Show();
                f.Activate();
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("未找到该工单料件列表！请确定该工单是否已经开工！");
            }
        }
        //
        //研磨领线材
        //
        private void btn_OrderGrindReceive_Click(object sender, RoutedEventArgs e)
        {
            frm_OrderInfo_WorkstationRecive f = new frm_OrderInfo_WorkstationRecive();
            f.Show();
            f.Activate();
        }
        //
        //成品入库
        //
        private void btn_OrderProduct_InStorage_Click(object sender, RoutedEventArgs e)
        {
            frm_OrderProduct_InStorage f = new frm_OrderProduct_InStorage();
            f.Show();
            f.Activate();
        }

        //
        //窗体初始化
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            _WTT_MaterialList = null;
            view.Source = customers;
            lsv_ShowOrderMaterialInfo.DataContext = view;
        }

        //
        //查询工单信息
        //
        private void btn_OrederLoading_Click(object sender, RoutedEventArgs e)
        {
            if (txb_OrderID.Text != "")
            {
                showOrderInfo(txb_OrderID.Text); //控件中显示工单信息
            }
            else { My_MessageBox.My_MessageBox_Message("请输入工单单号!"); }
        }

        #endregion


        #region Method
        /***************************  方法  ********************************************/

        /// <summary>
        /// 显示工单信息
        /// </summary>
        /// <param name="OrderID"></param>
        private void showOrderInfo(string OrderID)
        {
            #region 之前代码
            // DataSet _OrderInfo = _WorkOrder.GetOrderInfo(OrderID);                                          //工单基本信息
          
            // dgv_OrderInfo.ItemsSource = _WorkOrder.GetOrderMaterial(OrderID).Tables[0].DefaultView;      //工单物料需领用量
            //窗体控件显示
            /*
            txb_Info_OrderID.Text = _OrderInfo.Tables[0].Rows[0]["TA001"].ToString() +"-"+ _OrderInfo.Tables[0].Rows[0]["TA002"].ToString();
            txb_Info_Prodotto_Num.Text = _OrderInfo.Tables[0].Rows[0]["品号"].ToString();
            txb_Info_Prodotto_Name.Text = _OrderInfo.Tables[0].Rows[0]["品名"].ToString();
            txb_Info_Model.Text =_OrderInfo.Tables[0].Rows[0]["规格"].ToString();
            txb_Info_CommenceData.Text = _OrderInfo.Tables[0].Rows[0]["开工日期"].ToString().Trim();
            txb_Info_CompletionData.Text =_OrderInfo.Tables[0].Rows[0]["完工日期"].ToString();
            lab_Info_OrderCount.Text = _OrderInfo.Tables[0].Rows[0]["批量"].ToString().Trim();
             */
            #endregion
            Maticsoft.BLL.WorkOrder _M_OrderInfo = new Maticsoft.BLL.WorkOrder();
            Maticsoft.BLL.OrderMaterial _M_OrderMaterial = new Maticsoft.BLL.OrderMaterial();            
            Maticsoft.Model.WorkOrder _OrderInfo = new Maticsoft.Model.WorkOrder();
            //
            _OrderInfo = _M_OrderInfo.GetModel(OrderID);
            if (_OrderInfo != null)
            {
                txb_Info_OrderID.Text = _OrderInfo.OrderID;
                txb_Info_Prodotto_Name.Text = _OrderInfo.ProductName;
                txb_Info_Model.Text = _OrderInfo.Model;
                txb_Info_CompletionData.Text = _OrderInfo.DeliveryDate;
                
                //
                DataSet temMaterialList = _M_OrderMaterial.GetList("OrderID= N'" + OrderID + "'");   //工单物料需领用量
                _WTT_MaterialList = PressMaterialList(temMaterialList);
                dgv_OrderInfo_Material.ItemsSource = _WTT_MaterialList.Tables[0].DefaultView;
               

                //图表表示
                Show_OrderChart(_OrderInfo);
            }
            else
            { My_MessageBox.My_MessageBox_Message("未找到工单:"+OrderID+"的信息！请联系助理录入工单信息后重试！！！"); }
        }

        /// <summary>
        /// 在图表中显示工单信息
        /// </summary>
        private void Show_OrderChart(Maticsoft.Model.WorkOrder _Order)
        {
            DataSet temds =  MCP_CS._M_Material_Inject.GetInjectView(txb_OrderID.Text.Trim());
            DataSeries OrderInfoChart = new DataSeries();    //声明临时变量
            if (temds.Tables[0].Rows.Count > 0)
            {
                ShowInfo_MaterialControl(_Order, temds, OrderInfoChart);
            }

            /*
            OrderInfoChart.DataPoints.Add(new DataPoint { AxisXLabel = "已领取", YValue = 0 });
            OrderInfoChart.DataPoints.Add(new DataPoint { AxisXLabel = "已投入", YValue = 0 });
            OrderInfoChart.DataPoints.Add(new DataPoint { AxisXLabel = "已测试", YValue = 0 });
            OrderInfoChart.DataPoints.Add(new DataPoint { AxisXLabel = "待测Exfo", YValue = 0 });
            OrderInfoChart.DataPoints.Add(new DataPoint { AxisXLabel = "已包装", YValue = 0 });
            OrderInfoChart.DataPoints.Add(new DataPoint { AxisXLabel = "已出货", YValue = 0 });
            */
            Order_Chart(OrderInfoChart);                    //将Dataseries 类型的值 传递给方法 Order_Chart（） 进行图表显示
          
        }

        /// <summary>
        /// 显示工单跳线领取状况 列表显示
        /// </summary>
        /// <param name="_Order"></param>
        /// <param name="temds"></param>
        /// <param name="OrderInfoChart"></param>
        private void ShowInfo_MaterialControl(Maticsoft.Model.WorkOrder _Order ,DataSet temds, DataSeries OrderInfoChart)
        {
            MCP_CS.Cls_OrderInfo.Order = _WorkOrder.GetModel(txb_Info_OrderID.Text);
            string[] temOrd = new string[1] { txb_Info_OrderID.Text };
            lsv_ShowOrderMaterialInfo.DataContext = MCP_CS.Cls_OrderInfo.GetOrderInfo(temOrd);
            dgv_OrderMaterialInfo.ItemsSource = MCP_CS.Cls_OrderInfo.GetOrderMaterialInfo.Tables[0].DefaultView;
        }

        //在图表中显示信息
        private void Order_Chart(DataSeries series)
        {
            Chart chart = new Chart
            {
                //  Width = "Auto",
                //  Height = "Auto",
                View3D = true,
                Bevel = true 
            };
            chart.Titles.Add(new Title
            {
                Text = "在制品对比"
            });

            // X 坐标轴
            Axis xaxis = new Axis();
            // 设置坐标轴的背景色
            xaxis.Background = new SolidColorBrush(Colors.Gray);
            // 设置坐标轴上两点间的距离，这个属性不能和ScrollBarScale属性同时设置
            xaxis.ClosestPlotDistance = 2;
            // 坐标轴线的样式
            xaxis.LineStyle = LineStyles.Dashed;

            AxisLabels xal = new AxisLabels
            {
                Enabled = true,
                Angle = -45
            };
            xaxis.AxisLabels = xal;
            // Y 坐标轴
            Axis yaxis = new Axis();
            AxisLabels yal = new AxisLabels
            {
                Enabled = true,
                Angle = 45
            };
            yaxis.AxisLabels = yal;

            chart.AxesX.Add(xaxis);
            chart.AxesY.Add(yaxis);

            // 设置坐标轴的类型为 secondary
            series.AxisYType = AxisTypes.Secondary;
            series.RenderAs = RenderAs.Column;
            chart.Series.Add(series);
            chart.SetValue(Grid.ColumnProperty, 1);
            LayoutRoot.Children.Add(chart);
        }

        /// <summary>
        /// 去掉不需要的物料
        /// </summary>
        private DataSet PressMaterialList(DataSet _MaterialList)
        {
            foreach (DataRow dr in _MaterialList.Tables[0].Rows)
            {
                if (dr["品名"].ToString() == "粘贴纸" || dr["品名"].ToString() == "模带")
                {
                    dr.Delete();
                }
            }
            return _MaterialList;
        }


       

        #endregion

        //******************************** 临时类 ********************
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        CollectionViewSource view = new CollectionViewSource();
        class Customer
        {
            public string Type { get; set; }
            public string Count { get; set; }
        }

        //
        //获取车间在制品数量
        //
        private void btn_GetWorkShopOrderList_Click(object sender, RoutedEventArgs e)
        {

            string[] temOrd = MCP_CS._M_WorkOrder.GetOrdList("WorkShop = '"+cmb_WorkShopList.Text+"' AND State = '待生产'");
            lsv_ShowOrderMaterialInfo.DataContext = MCP_CS.Cls_OrderInfo.GetOrderInfo(temOrd);  //显示工单各站的领发料情况
            dgv_OrderMaterialInfo.ItemsSource = MCP_CS.Cls_OrderInfo.GetOrderMaterialInfo.Tables[0].DefaultView;  //显示工单的发料和领料明细

            dgv_OrderInfo_Material.ItemsSource = MCP_CS.Cls_OrderInfo.GetOrderMaterial_List().Tables[0].DefaultView;
        }

        
        }
        //***********************************************************
          
}
