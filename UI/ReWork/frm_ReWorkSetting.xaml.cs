using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace UI
{
    /// <summary>
    /// frm_ReWorkSetting.xaml 的交互逻辑
    /// </summary>
    public partial class frm_ReWorkSetting 
    {
        public frm_ReWorkSetting()
        {
            InitializeComponent();
        }

        /*********************  全局变量   ***********************/
        //处理方法
        ObservableCollection<Maticsoft.Model.Dispose> _Dispe = new ObservableCollection<Maticsoft.Model.Dispose>();
        private byte[] imBytes;

        Maticsoft.Model.Rejected _Rejected = new Maticsoft.Model.Rejected();
        Maticsoft.BLL.Rejected _M_Rejected = new Maticsoft.BLL.Rejected();
        Maticsoft.Model.Dispose _Dispose = new Maticsoft.Model.Dispose();
        Maticsoft.BLL.Dispose _M_Dispose = new Maticsoft.BLL.Dispose();    
      
        
        
        
        /*********************  控件方法   ***********************/
        //
        //选择图片
        //
        private void btn_Browse_Click(object sender, RoutedEventArgs e)
        {           
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "请选择客户端longin的图片";
            openfile.Filter = "Login图片(*.jpg;*.bmp;*png)|*.jpeg;*.jpg;*.bmp;*.png|AllFiles(*.*)|*.*";
            if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    //读成二进制
                    imBytes = File.ReadAllBytes(openfile.FileName);
                    //直接把这个存储到数据就行了cmd.Parameters.Add("@image", SqlDbType.Image).Value = bytes;

                    //显示图片路径
                    txb_Pic_Path.Text = openfile.FileName;
                   
                    //在控件中显示图片
                    BitmapImage BI = new BitmapImage();
                    BI.BeginInit();
                    BI.StreamSource = new MemoryStream(imBytes);  //bufPic是图片二进制，byte类型
                    BI.EndInit(); 
                    image1.Source = BI;//image是XAML页面上定义的Image控件                                   
                }
                catch { }
            }
        }
        //
        //添加处理
        //
        private void btn_Add_Dispose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txb_ReWorkMethod.Text != "" && cmb_LengthVerify.Text != "" && txb_ReWorkMethod.Text != "")
                {
                    if (txb_Pic_Path.Text != "")
                    {
                        _Dispe.Add(new Maticsoft.Model.Dispose()
                        {
                            RejectCode = txb_RejectCode.Text,
                            DisposeMethod = txb_ReWorkMethod.Text,
                            Descriptions = cmb_LengthVerify.Text.Trim()
                        });

                        //清空文本框
                        cmb_LengthVerify.Text = "";
                        txb_ReWorkMethod.Text = "";
                    }
                    else
                    {
                        My_MessageBox.My_MessageBox_Message("请选择不良图片后再进行添加操作！");
                    }
                }
                else { My_MessageBox.My_MessageBox_Message("信息不完整！"); }
            }
            catch { }
        }
        //
        //窗体载入事件
        //
        private void BaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgv_ReCordList.ItemsSource = _Dispe;
        }                    
        //
        //保存信息
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_M_Rejected.isEquals(txb_RejectCode.Text.Trim()))  //如果该记录已经存在
                {
                    if (System.Windows.Forms.MessageBox.Show("已经存在该不良代码！/r/n确定将继续保存并覆盖该不良代码", "危险操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                    {
                        _M_Rejected.Delete(txb_RejectCode.Text.Trim());
                        _M_Dispose.Delete(txb_RejectCode.Text.Trim());
                        SaveInfo_All();
                    }
                }
                else
                {
                    SaveInfo_All(); //保存
                }
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }
        //
        //删除信息
        //
        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("确定要删除此不良现象么？","危险操作",MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                if (_M_Dispose.Delete(txb_RejectCode.Text.Trim()) &&
                 _M_Rejected.Delete(txb_RejectCode.Text.Trim()))
                {
                    My_MessageBox.My_MessageBox_Message("删除成功！");
                    ClearControlInfo();
                }
            }
            
        }
        //
        //选择处理方法
        //
        private void dgv_ReCordList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                Maticsoft.Model.Dispose temdispe = (Maticsoft.Model.Dispose)dgv_ReCordList.SelectedItem;
                txb_ReWorkMethod.Text = temdispe.DisposeMethod;
                cmb_LengthVerify.Text = temdispe.Descriptions;
            }
            catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }
        //
        //查找
        //
        private void btn_Find_Click(object sender, RoutedEventArgs e)
        {
            _Rejected = _M_Rejected.GetModel(txb_RejectCode.Text.Trim());
            if (_Rejected != null)
            {
                //填充不良现象
                txb_Reject.Text = _Rejected.Reject;
                //在控件中显示图片
                BitmapImage BI = new BitmapImage();
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(_Rejected.Picture);  //bufPic是图片二进制，byte类型
                BI.EndInit();
                image1.Source = BI;//image是XAML页面上定义的Image控件    


                //加载不良处理方法
                _Dispe.Clear();
                foreach (Maticsoft.Model.Dispose disp in _M_Dispose.GetModelList(txb_RejectCode.Text.Trim()))
                {
                    _Dispe.Add(disp);
                }
            }
            else 
            { 
                My_MessageBox.My_MessageBox_Message("未找到该不良代码的记录！");
                ClearControlInfo();
            }
        }
        
        
        
        
        /*********************  Method   ***********************/
        /// <summary>
        /// 保存重工信息
        /// </summary>
        private void SaveInfo_All()
        {
            //不良现象赋值
            _Rejected.RejectCode = txb_RejectCode.Text.Trim();
            _Rejected.Reject = txb_Reject.Text.Trim();
            _Rejected.Picture = imBytes;
            //保存不良现象
            _M_Rejected.Add(_Rejected);  
            //保存处理方法
            foreach (Maticsoft.Model.Dispose disp in _Dispe)
            {
                _M_Dispose.Add(disp);
            }
            My_MessageBox.My_MessageBox_Message("保存完成！");
            ClearControlInfo();
        }
        /// <summary>
        /// 清空控件内容
        /// </summary>
        private void ClearControlInfo()
        {
            txb_RejectCode.Text = "";
            txb_Reject.Text = "";     
            txb_ReWorkMethod.Text = "";       
            image1.Source = null;
            _Dispe.Clear();
            txb_Pic_Path.Text = "";
            cmb_LengthVerify.SelectedIndex = -1;
        }

        //
        //不良代码按回车事件
        //
        private void txb_RejectCode_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_RejectCode.IsFocused)
            {
                txb_Reject.Focus();
            }
        }
        //
        //不良现象 按回车事件
        //
        private void txb_Reject_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_Reject.IsFocused)
            {
                txb_ReWorkMethod.Focus();
            }
        }
        //
        //处理方式 
        //
        private void txb_ReWorkMethod_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter && txb_ReWorkMethod.IsFocused)
            {
                cmb_LengthVerify.Focus();
            }
        }
        

       

        
    }
}
