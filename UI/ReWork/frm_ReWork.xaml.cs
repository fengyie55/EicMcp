using AvalonDock;
using System.Windows.Controls;
using System.Data;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;

namespace UI
{
    /// <summary>
    /// frm_ReWork.xaml 的交互逻辑
    /// </summary>
    public partial class frm_ReWork : DocumentContent
    {
        public frm_ReWork()
        {
            InitializeComponent();
        }



        /*********************************  全局变量  *************************************/
        Maticsoft.Model.Rejected _Rejected = new Maticsoft.Model.Rejected();
        Maticsoft.BLL.Rejected _M_Rejected = new Maticsoft.BLL.Rejected();
        Maticsoft.Model.Dispose _Dispose = new Maticsoft.Model.Dispose();
        Maticsoft.BLL.Dispose _M_Dispose = new Maticsoft.BLL.Dispose();
        Maticsoft.Model.Rework _Rework = new Maticsoft.Model.Rework();
        Maticsoft.BLL.Rework _M_Rework = new Maticsoft.BLL.Rework();

        DataSet TemRejectList = new DataSet();
        DataSet TemDisposeList = new DataSet();

        ObservableCollection<Maticsoft.Model.Rework> _Rek = new ObservableCollection<Maticsoft.Model.Rework>();
        private byte[] imBytes;
        /*********************************  控件事件  *************************************/
        //
        //管理不良现象
        //
        private void btn_AddReWork_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            frm_ReWorkSetting f = new frm_ReWorkSetting();
            f.Show();
        }
      
        //
        //选择不良
        //
        private void cmb_Reject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_Reject.SelectedIndex != -1)  //为空时为-1
            {
               // txb_Reject_Description.Text = TemRejectList.Tables[0].Rows[cmb_Reject.SelectedIndex]["Descriptions"].ToString();
                txb_Search_RejectCode.Text = TemRejectList.Tables[0].Rows[cmb_Reject.SelectedIndex]["RejectCode"].ToString();
                if (TemRejectList.Tables[0].Rows[cmb_Reject.SelectedIndex]["Picture"] != null && TemRejectList.Tables[0].Rows[cmb_Reject.SelectedIndex]["Picture"].ToString() != "")
                {
                    byte[] tembytes = (byte[])TemRejectList.Tables[0].Rows[cmb_Reject.SelectedIndex]["Picture"];
                    
                    //在控件中显示图片
                    BitmapImage BI = new BitmapImage();
                    BI.BeginInit();
                    BI.StreamSource = new MemoryStream(tembytes);  //bufPic是图片二进制，byte类型
                    BI.EndInit();
                    image1.Source = BI;//image是XAML页面上定义的Image控件  

                    //为处理方法赋值
                    TemDisposeList = _M_Dispose.GetList("RejectCode = '" + txb_Search_RejectCode.Text.Trim() + "'");
                    cmbDataSource(cmb_DesposeMethod, TemDisposeList, "DisposeMethod");
                    lab_ID.Content = TemDisposeList.Tables[0].Rows[0]["ID"].ToString();
                }
            }
        }
       
       
        //
        //保存记录
        //
        private void btn_Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (ControlVerify())
                {
                    _Rework.PigtailType = cmb_PigtaiType.Text.Trim();
                    _Rework.SN = txb_SerialNumber.Text.Trim();
                    _Rework.Count = "1";
                    _Rework.RejectID = txb_Search_RejectCode.Text.Trim();
                    _Rework.DisposeID = lab_ID.Content.ToString();
                    _Rework.Result = cmb_Result.Text.Trim();
                    _Rework.ReworkID = txb_Operator.Text.Trim();
                    _Rework.VerifyID = txb_Verify.Text.Trim();
                    _Rework.Length = txb_Length.Text.Trim();
                    _M_Rework.Add(_Rework);
                    My_MessageBox.My_MessageBox_Message("记录添加成功！");
                    //搜素重工记录
                    SearchSNRewokList(txb_SerialNumber.Text.Trim());

                    ControlClear(); //清空控件内容
                }
                else { My_MessageBox.My_MessageBox_Message("信息不完整，请将信息填写完整后重试！"); }
            }
            catch (SyntaxErrorException ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }
        //
        //窗体载入
        //
        private void DocumentContent_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        //
        //查找
        //
        private void btn_Search_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SearchSNRewokList(txb_FindSerialNumber.Text.Trim());
        }
        //
        //查看重工记录
        //
        private void dgv_Info_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Maticsoft.Model.Rework temRek = (Maticsoft.Model.Rework)dgv_Info.SelectedItem;
                Maticsoft.Model.Rejected temRej = new Maticsoft.Model.Rejected();
                Maticsoft.Model.Dispose temDis = new Maticsoft.Model.Dispose();
                temRej = _M_Rejected.GetModel(temRek.RejectID);
                temDis = _M_Dispose.GetModel(decimal.Parse(temRek.DisposeID));
                
                //不良显示              
                cmb_Reject.Text = temRej.Reject;
                txb_Search_RejectCode.Text = temRej.RejectCode;
                //在控件中显示图片
                BitmapImage BI = new BitmapImage();
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(temRej.Picture);  //bufPic是图片二进制，byte类型
                BI.EndInit();
                image1.Source = BI;//image是XAML页面上定义的Image控件  
              

                //处理方法显示
                cmb_DesposeMethod.Text = temDis.DisposeMethod;           
                lab_ID.Content = temDis.ID;
                
                //处理结果
                txb_SerialNumber.Text = temRek.SN;
                cmb_PigtaiType.Text = temRek.PigtailType;
                cmb_Result.Text = temRek.Result;
                txb_Operator.Text = temRek.ReworkID;
                txb_Verify.Text = temRek.VerifyID;
                txb_Length.Text = temRek.Length;
                
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }
        //
        //处理方式下拉菜单
        //
        private void cmb_DesposeMethod_DropDownClosed(object sender, System.EventArgs e)
        {
            int t = cmb_DesposeMethod.SelectedIndex;
            if (cmb_DesposeMethod.SelectedIndex != -1)
            {
                if (TemDisposeList.Tables[0].Rows[t]["Descriptions"].ToString() == "是")
                {
                    lab_Length.Visibility = System.Windows.Visibility.Visible;
                    lab_MM.Visibility = System.Windows.Visibility.Visible;
                    txb_Length.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    lab_Length.Visibility = System.Windows.Visibility.Hidden;
                    lab_MM.Visibility = System.Windows.Visibility.Hidden;
                    txb_Length.Visibility = System.Windows.Visibility.Hidden;
                }
                lab_ID.Content = TemDisposeList.Tables[0].Rows[t]["ID"].ToString();
            }
        }

        //
        //按代码搜索
        //
        private void txb_Search_RejectCode_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Search_RejectCode.IsFocused)
            {
                TemRejectList = _M_Rejected.GetList("RejectCode = '" + txb_Search_RejectCode.Text.Trim() + "'");
                cmbDataSource(cmb_Reject, TemRejectList, "Reject");
                cmb_Result.Focus();
            }
        }
        //
        //按不良原因搜索
        //
        private void txb_Search_Reject_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Search_Reject.IsFocused)
            {
                TemRejectList = _M_Rejected.GetList("Reject LIKE '%" + txb_Search_Reject.Text.Trim() + "%'");
                cmbDataSource(cmb_Reject, TemRejectList, "Reject");
            }
        }


        /*********************************  共用事件  *************************************/
        /// <summary>
        /// 为控件设置数据源
        /// </summary>
        /// <param name="cm">控件</param>
        /// <param name="ds">数据源</param>
        /// <param name="field">字段</param>
        private void cmbDataSource(ComboBox cm,DataSet ds,string field)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                cm.DisplayMemberPath = field;
                cm.DataContext = ds.Tables[0].DefaultView;
                cm.DisplayMemberPath = field;
                cm.SelectedIndex = 0;
            }
            else { My_MessageBox.My_MessageBox_Message("未找到与此相关的任何记录！"); }
        }
        /// <summary>
        /// 验证控件是否不为空
        /// </summary>
        private bool ControlVerify()
        {
            if (
                cmb_PigtaiType.Text != ""
                && txb_Search_RejectCode.Text != ""
                && cmb_Reject.Text != ""
                && cmb_DesposeMethod.Text != ""
                && cmb_Result.Text != ""
                &&txb_Operator.Text!=""
                &&txb_Verify.Text!=""
                &&txb_SerialNumber.Text!="")
            {
                if (txb_Length.IsVisible && txb_Length.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else { return false; }            
        }
      
        /// <summary>
        /// 搜索重工记录
        /// </summary>
        private void SearchSNRewokList(string _serialNumber)
        {
            dgv_Info.ItemsSource = _Rek;
            _Rek.Clear();
            foreach (Maticsoft.Model.Rework temRek in _M_Rework.GetModelList("SN ='" + _serialNumber + "'"))
            {
                _Rek.Add(temRek);
            }         
        }
        /// <summary>
        /// 清空控件内容
        /// </summary>
        private void ControlClear()
        {
            cmb_PigtaiType.Text = "";
            txb_Search_RejectCode.Text = "";
            cmb_Reject.Text = "";
            cmb_DesposeMethod.Text = "";
            cmb_Result.Text = "";
            txb_Operator.Text = "";
            txb_Verify.Text = "";
            txb_SerialNumber.Text = "";
            txb_Length.Text = "";
            image1.Source = null;
        }
        //
        //处理结果
        //
        private void cmb_Result_DropDownClosed(object sender, System.EventArgs e)
        {
            txb_Length.Focus();
        }

        //
        //长度控件
        //
        private void txb_Length_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Length.IsFocused)
            {
                txb_Operator.Focus();
            }
        }
        //
        //操作员
        //
        private void txb_Operator_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Operator.IsFocused)
            {
                txb_Verify.Focus();
            }
        }
        //
        //确认人
        //
        private void txb_Verify_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Verify.IsFocused)
            {
                btn_Save.Focus();
            }
        }
        

      
       

       
       
        
       


    }
}
