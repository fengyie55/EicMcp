using AvalonDock;
using System.Collections;
using System;
using System.IO;

namespace UI
{
    /// <summary>
    /// frm_Generate_Repot.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Generate_Repot : DocumentContent
    {
        public frm_Generate_Repot()
        {
            InitializeComponent();
        }

        //*********************************************  全局变量
        Maticsoft.Model.WorkOrder _W_OrderInfo = new Maticsoft.Model.WorkOrder();
        ArrayList _W_SNList = new ArrayList();
        ArrayList _W_DataList = new ArrayList();
        Random _W_GenerateData = new Random(); 


        //******************************************************



        //
        //调取工单信息
        //
        private void txb_OrderID_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_OrderID.IsFocused)
            {
                _W_OrderInfo = MCP_CS._M_WorkOrder.GetModel(txb_OrderID.Text.Trim());
                if (_W_OrderInfo != null)
                {
                    txb_Note.Text += "线材类型:" + _W_OrderInfo.InspectMethod + "\r\v";
                }
                else { My_MessageBox.My_MessageBox_Message("未找到工单信息，请确实工单已经存在！"); }
            }
        }

        //
        //生成SN列表
        //
        private void btn_Generate_SNList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            long tem_StataSN =0,tem_EndSN=0;
            long.TryParse(txb_Start_SN.Text.Trim(),out tem_StataSN);
            long.TryParse(txb_EndSN.Text.Trim(),out tem_EndSN);
            
            _W_SNList = GenerateSN(_W_OrderInfo, tem_StataSN, tem_EndSN);
            lst_SNList.ItemsSource = _W_SNList;

            lab_SNCount.Content = "条码：" + _W_SNList.Count + "条";
        }

        //
        //清空数据列表
        //
        private void btn_ClearList_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ClearList();  
        }

        //
        //生成数据
        //
        private void btn_Generate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //定义变量
            string _conectionType = txb_Conection.Text.Trim();
            int IL_Min = 0, IL_Main = 0, RL_Min = 0 , RL_Max = 0 ;

            if (txb_IL_Max.Text != "" && txb_IL_Min.Text != "" && txb_RL_Max.Text != "" && txb_RL_Min.Text != null &&
                _W_OrderInfo != null && _W_SNList != null)
            {
                //变量赋值
                int.TryParse(txb_IL_Min.Text.Trim().Substring(2, txb_IL_Min.Text.Trim().Length - 2), out IL_Min);  //IL_Min
                int.TryParse(txb_IL_Max.Text.Trim().Substring(2, txb_IL_Max.Text.Trim().Length - 2), out IL_Main);  //IL_Man
                int.TryParse(txb_RL_Min.Text.Trim(), out RL_Min);    //RL_Min
                int.TryParse(txb_RL_Max.Text.Trim(), out RL_Max);    //RL_Max

                _W_DataList = GenerateDataList(_W_OrderInfo, _W_SNList, _conectionType, IL_Min, IL_Main, RL_Min, RL_Max);
                dgv_dataList.ItemsSource = _W_DataList;
                lab_dataCount.Content = "数据记录：" + _W_DataList.Count + "条";
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("信息不完整！请补全信息后重试！");
            }
        }

        //
        //导出至Txt文件
        //
        private void btn_Export_To_txt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            to_txt();
        }

        //
        //保存至数据库
        //
        private void btn_Save_To_Server_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int Count = 0;
            foreach(object testJsd in _W_DataList)
            {
                
                Maticsoft.Model.User_JDS_Test_Good _UserJDSTestData = (Maticsoft.Model.User_JDS_Test_Good)testJsd;
                MCP_CS._M_User_JDS_Test_Good.Delete(_UserJDSTestData.SN.ToString());
                if (MCP_CS._M_User_JDS_Test_Good.Add(_UserJDSTestData) > 0)
                {
                    Count++;
                }
            }
            ClearList();
            My_MessageBox.My_MessageBox_Message("保存完成！共添加" + Count + "条记录！");
        }

        #region Method
       
        /// <summary>
        /// 生成SN列表
        /// </summary>
        /// <param name="_OrderInfo">工单信息</param>
        /// <param name="_StatSN">开始编码</param>
        /// <param name="_EndSN">结束编码</param>
        /// <returns></returns>
        private ArrayList GenerateSN(Maticsoft.Model.WorkOrder _OrderInfo, long _StatSN, long _EndSN)
        {
            ArrayList _tem = new ArrayList();
            if (_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.双并检测)
            {
                for(long sn = _StatSN ;sn <= _EndSN;sn++)
                {
                    _tem.Add(sn.ToString() + "-A1");
                    _tem.Add(sn.ToString() + "-A2");
                    _tem.Add(sn.ToString() + "-B1");
                    _tem.Add(sn.ToString() + "-B2");
                }
            }
            else if (_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.一码一签_跳线)
            {
                Generate_SN_MoreCode(_StatSN, _EndSN, _tem, 2);
            }
            else if (_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.四芯检测)
            {
                Generate_SN_MoreCode(_StatSN, _EndSN, _tem, 4);
            }
            else if (_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.八芯检测)
            {
                Generate_SN_MoreCode(_StatSN, _EndSN, _tem, 8);
            }
            else if (_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.十二芯检测)
            {
                Generate_SN_MoreCode(_StatSN, _EndSN, _tem, 12);
            }
            else if (_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.二十四芯检测)
            {
                Generate_SN_MoreCode(_StatSN, _EndSN, _tem, 24);
            }
            else if (_OrderInfo.InspectMethod == Maticsoft.Model.E_InspectMethod.四十八芯检测)
            {
                Generate_SN_MoreCode(_StatSN, _EndSN, _tem,48);
            }
           
            else
            {
                for (long sn = _StatSN; sn <= _EndSN; sn++)
                {
                    _tem.Add(sn.ToString());
                }
            }

            Note("生产SN列表，ＳＮ　" + _tem.Count + " 条");
            return _tem;
        }

        private static void Generate_SN_MoreCode(long _StatSN, long _EndSN, ArrayList _tem,int MoreCode_Count)
        {
            for (long sn = _StatSN; sn <= _EndSN; sn++)
            {
                for (int tem = 1; tem <= MoreCode_Count; tem++)
                {
                    _tem.Add(sn.ToString() + "-" + tem.ToString());
                }
            }
        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="_OrderInfo">工单信息</param>
        /// <param name="_SN_List">SN列表</param>
        /// <param name="_ConectionType">接头类型</param>
        /// <param name="_IL_Min">IL_Min</param>
        /// <param name="_IL_Max">IL_Max</param>
        /// <param name="_RL_Min">RL_Min</param>
        /// <param name="_RL_Man">RL_Max</param>
        /// <returns></returns>
        private ArrayList GenerateDataList(Maticsoft.Model.WorkOrder _OrderInfo, ArrayList _SN_List,
            string _ConectionType, int _IL_Min, int _IL_Max, int _RL_Min, int _RL_Man)
        {
            ArrayList _temList = new ArrayList();
            try
            {
                double _temIL_1310nm = 0, _temIL_1550nm = 0;
                //计算接续值
                foreach (string _SN in _SN_List)
                {
                    bool TemV = true;
                    while (TemV)
                    {
                        _temIL_1310nm = _W_GenerateData.Next(_IL_Min, _IL_Max);
                        _temIL_1550nm = _W_GenerateData.Next(_IL_Min, _IL_Max);
                        if ((_temIL_1310nm - _temIL_1550nm) < 10 && (_temIL_1310nm - _temIL_1550nm) > -10)
                        {
                            TemV = false;
                        }

                    }

                    //对生成的数值进行处理
                    if (_temIL_1310nm >= 10) { _temIL_1310nm = double.Parse("0." + _temIL_1310nm); }
                    else { _temIL_1310nm = double.Parse("0.0" + _temIL_1310nm); }
                    if (_temIL_1550nm >= 10) { _temIL_1550nm = double.Parse("0." + _temIL_1550nm); }
                    else { _temIL_1550nm = double.Parse("0.0" + _temIL_1550nm); }

                    #region 添加数据
                    //循环添加 1310nm 和 1550nm 
                    for (int i = 1; i <= 2; i++)
                    {
                        //定义变量
                        string temWave = "";
                        double temIL_A = 0;
                        double temRL_A = _W_GenerateData.Next(_RL_Min, _RL_Man);

                        //变量赋值
                        if (i == 1) { temWave = "1310nm"; temIL_A = _temIL_1310nm; }
                        else { temWave = "1550nm"; temIL_A = _temIL_1550nm; }

                        //添加至列表
                        Maticsoft.Model.User_JDS_Test_Good _jdsTest = new Maticsoft.Model.User_JDS_Test_Good()
                        {
                            SN = _SN,
                            PartNumber = "",
                            Wave = temWave,
                            Result = "Passed",
                            TestDate = DateTime.Now.Date.ToString(),
                            IL_A = temIL_A.ToString("0.00"),
                            Refl_A = temRL_A.ToString("0"),
                             IL_B = "null",
                             Refl_B = "null"
                             
                        };
                        _temList.Add(_jdsTest);
                    }

                   
                    #endregion
                }

                Note("生成数据记录" + _W_DataList.Count + "条");
            }
            catch (SystemException ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
            return _temList;
        }

        /// <summary>
        /// 清空列表
        /// </summary>
        private void ClearList()
        {
            lst_SNList.ItemsSource = null;
            _W_SNList.Clear();
            //
            dgv_dataList.ItemsSource = null;
            _W_DataList.Clear();
            lab_dataCount.Content = "数据记录：" + _W_DataList.Count + "条";
            //
            txb_Note.Text = "";
        }

        /// <summary>
        /// 导出至txt文件
        /// </summary>
        public void to_txt()
        {
            FileStream fs1 = new FileStream("D:\\数据导出\\Tem\\"+txb_OrderID.Text.Trim()+".txt", FileMode.Create, FileAccess.Write);//创建写入文件 
            StreamWriter sw = new StreamWriter(fs1);

            sw.WriteLine("TestDate,TestType,SerialNumber,Result,WaveType,ILA,RLA,ILB,RLB");//开始写入值             
            foreach (object _temJda in _W_DataList)
            {
                Maticsoft.Model.User_JDS_Test_Good JsdData = (Maticsoft.Model.User_JDS_Test_Good)_temJda;
                string _str = JsdData.TestDate + "," + "Type,";
                _str += JsdData.SN + ",";
                _str += JsdData.Result + ",";
                _str += JsdData.Wave + ",";
                _str += JsdData.IL_A + ",";
                _str += JsdData.Refl_A + ",";
                _str += JsdData.IL_B + ",";
                _str += JsdData.Refl_B;
                sw.WriteLine(_str);//开始写入值             
            }      

            sw.Close();
            fs1.Close();
            Note("导出数据至 D:\\数据导出\\Tem\\ ");
            My_MessageBox.My_MessageBox_Message("导出完成！\r\n文件存放路径 \r\n D:\\数据导出\\Tem\\");        
        }

        /// <summary>
        /// 用户操作记录
        /// </summary>
        /// <param name="_ControlRecode">要显示的记录</param>
        private void Note(string _ControlRecode) 
        {
            txb_Note.Text += _ControlRecode + "\r\n";
        }

        #endregion

        

      

        
    }
}
