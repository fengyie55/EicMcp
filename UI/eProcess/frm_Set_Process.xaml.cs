using AvalonDock;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace UI
{
    /// <summary>
    /// frm_Set_Process.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Set_Process : DocumentContent
    {
        public frm_Set_Process()
        {
            InitializeComponent();
        }
          
        ObservableCollection<Maticsoft.Model.e_Flow> eFlowList = new ObservableCollection<Maticsoft.Model.e_Flow>();
        ObservableCollection<Maticsoft.Model.e_ProcessFlow> _Yet_ProcessFlow = new ObservableCollection<Maticsoft.Model.e_ProcessFlow>();
        Maticsoft.BLL.IDraw_Process DrawProcess = new Maticsoft.BLL.Draw_Process();  
        //
        //窗体载入事件
        //
        private void DocumentContent_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {          
            lsv_FlowList.ItemsSource = eFlowList;                   //待保存的图纸工序列表        
            lsv_YetSaveFlow.ItemsSource = _Yet_ProcessFlow;         //搜索条码中已保存的工序
          //  MCP_CS.SetButtonIsEnabled(false, btn_Drw_Edit, btn_Drw_Save, btn_Drw_Delete);                //禁用图纸相应的Button
        }        
       

        //
        //图纸——查找图纸
        //
        private void txb_DrawNum_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                MCP_CS._e_ProcessDraw = MCP_CS.e_ProcessDraw.GetModel(txb_DrawNum.Text);
                if (MCP_CS._e_ProcessDraw != null)
                {
                    txb_DrawNum.Text = MCP_CS._e_ProcessDraw.DrawNum;
                    txb_ProductName.Text = MCP_CS._e_ProcessDraw.Name;
                    foreach (Maticsoft.Model.e_Flow temFlow in MCP_CS.e_Flow.GetModelList("DrawNum = '" + txb_DrawNum.Text + "'"))
                    {
                        eFlowList.Add(temFlow);
                    }
                }           
                else
                {
                    My_MessageBox.My_MessageBox_Message("未找到图纸编号为:" + txb_DrawNum.Text + " 的任何信息");
                }
            }
        }
       
        //工单——保存      
        private void btn_Ord_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(txb_Ord_Order.Text != "" && txb_DrawNum.Text != "" && eFlowList.Count >0)
            {
               if( MCP_CS.e_WorkOrder.Add(new Maticsoft.Model.e_WorkOrder() { WorkNum = txb_Ord_Order.Text, DrawNum = eFlowList[0].DrawNum })> 0)
               {
                   My_MessageBox.My_MessageBox_Message("添加成功！");
                   txb_Ord_Order.Text = "";
               }
            }else
            {
                My_MessageBox.My_MessageBox_Message("信息不完整！");
            }
        }

        //工单——删除
        private void btn_Ord_Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(txb_Ord_Order.Text!="")
            {
                if (MCP_CS.e_WorkOrder.Delete(txb_Ord_Order.Text))
                    My_MessageBox.My_MessageBox_Message("删除成功！");
                else
                    My_MessageBox.My_MessageBox_Message("删除失败！");
            }
        }

        //图纸——编辑
        private void btn_Drw_Edit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                DrawProcess.EditProcess(eFlowList);
            }
            catch(Exception ex) {My_MessageBox.My_MessageBox_Erry(ex.Message); }
        }

        //图纸——导入
        private void btn_Drw_Import_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DrawProcess.GetDraw_forExcel(ref eFlowList);           
        }

        //图纸——保存
        private void btn_Drw_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(txb_DrawNum.Text != "" && txb_ProductName.Text != "")
            {
                DrawProcess.SaveProcess(eFlowList);
                MCP_CS.e_ProcessDraw.Add(new Maticsoft.Model.e_ProcessDraw() { DrawNum = txb_DrawNum.Text, Name = txb_ProductName.Text });
                My_MessageBox.My_MessageBox_Message("添加完成！");
            }else
            {
                My_MessageBox.My_MessageBox_Message("信息不完整！");
            }
            
        }

        //图纸——删除
        private void btn_Drw_Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(txb_DrawNum.Text!= "")
            {
                if (MCP_CS.e_Flow.Delete(txb_DrawNum.Text) && MCP_CS.e_ProcessDraw.Delete(txb_DrawNum.Text))
                {
                    My_MessageBox.My_MessageBox_Message("图纸编号："+txb_DrawNum.Text+"删除成功！");
                    txb_DrawNum.Text = "";
                    eFlowList.Clear();
                }
                else
                {
                    My_MessageBox.My_MessageBox_Message("图纸编号：" + txb_DrawNum.Text + "未成功删除！");
                }
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("未指定图纸编号！请输入图纸便后按下Enter键加载图纸信息！");
            }
        }

        //查找
        private void btn_Search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (txb_SN_Or_Order_2.Text == "")
                {
                    Maticsoft.BLL.ICls_Flow I_Flow = new Maticsoft.BLL.Cls_Flow();
                    //获取已保存工序
                    int MaxProcessOrder = 0;
                    int YetOverFlowCount = 0;
                    I_Flow.Get_Bar_YetOverFlow(txb_SN_Or_Order.Text, out MaxProcessOrder, out YetOverFlowCount, ref  _Yet_ProcessFlow);
                }
                else
                {
                    ExportProcessFlow(txb_SN_Or_Order.Text, txb_SN_Or_Order_2.Text);
                }
            }
            catch(Exception ex) {My_MessageBox.My_MessageBox_Query(ex.Message); }
           
        }
       
        //导出
        private void btn_Export_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            /*
            if(_Yet_ProcessFlow.Count > 0)
            {
                string _ExcelPatch = "D:\\数据导出\\Report\\"+txb_SN_Or_Order.Text+".xlsx";
                System.IO.File.Copy("D:\\模板\\ProcessFlow.xlsx", _ExcelPatch,true);
                ZhuifengLib.EXCEL.ExcelControl_Model _M_excel = new ZhuifengLib.EXCEL.ExcelControl_Model();                   
                _M_excel.ModelToExcel<Maticsoft.Model.e_ProcessFlow>(_Yet_ProcessFlow.ToList(), _ExcelPatch);
                My_MessageBox.My_MessageBox_Query("导出完成！");
            }         
             */
            string _ExcelPatch = "D:\\数据导出\\Report\\" + txb_SN_Or_Order.Text + ".xlsx";
            System.IO.File.Copy("D:\\模板\\ProcessFlow.xlsx", _ExcelPatch, true);
            ZhuifengLib.EXCEL.ExcelControlModel _M_excel = new ZhuifengLib.EXCEL.ExcelControlModel();
            _M_excel.DataTabToExcel<Maticsoft.Model.e_ProcessFlow>(_Yet_ProcessFlow.ToList(), _ExcelPatch);
            My_MessageBox.My_MessageBox_Query("导出完成！");
            
        }

        private void ExportProcessFlow(string _stratSN,string _endSN)
        {

            Maticsoft.BLL.ICls_Flow I_Flow = new Maticsoft.BLL.Cls_Flow();
            //获取已保存工序
            int MaxProcessOrder = 0;
            int YetOverFlowCount = 0;
            long l_startSN = long.Parse(_stratSN);
            long l_endSN = long.Parse(_endSN);

            _Yet_ProcessFlow.Clear();
            for (long tem = l_startSN; tem <= l_endSN; tem++)
            {

                ObservableCollection<Maticsoft.Model.e_ProcessFlow> _TemYet_ProcessFlow = new ObservableCollection<Maticsoft.Model.e_ProcessFlow>();
                I_Flow.Get_Bar_YetOverFlow(tem.ToString(), out MaxProcessOrder, out YetOverFlowCount, ref  _TemYet_ProcessFlow);
               foreach(Maticsoft.Model.e_ProcessFlow te in  _TemYet_ProcessFlow)
                _Yet_ProcessFlow.Add(te);
            }
           
        }

    }
}
