using AvalonDock;
using System.Data;
using System.Windows.Forms;
using Seagull.BarTender.Print;
using System.Windows;
using System.Collections.ObjectModel;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Linq;
using Seagull.BarTender.Print.Database;
using System.Collections.Generic;

namespace UI
{
    /// <summary>
    /// frm_Setting_Print.xaml 的交互逻辑
    /// </summary>
    public partial class frm_Setting_Print : DocumentContent
    {
        Engine btEngine;
        ObservableCollection<Maticsoft.Model.LabInfo> _WTT_LabInfo = new ObservableCollection<Maticsoft.Model.LabInfo>();
        private byte[] imBytes;
        Maticsoft.Model.LabVerify _W_LabVerify = new Maticsoft.Model.LabVerify();

        public frm_Setting_Print()
        {
            InitializeComponent();
            try
            {
                btEngine = new Engine(true);
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message("启动BT线程时发生错误，请确定是否安装Bt软件!\r\n" + ex.Message); }

        }

        //
        //载入模板信息
        //
        private void btn_ChangeBT_Template_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _WTT_LabInfo.Clear(); //清空列表
                                      // string Patch = "D:\\模板\\PrintTemplates\\HP_Templates\\" + cmb_LabTemplate.Text.Trim();
                string Patch = "\\\\QQQQQQ-MS2\\Templates\\PrintTemplates\\HP_Templates\\" + cmb_LabTemplate.Text.Trim();

                btEngine.Start();
                LabelFormatDocument btFormat = btEngine.Documents.Open(Patch);
                DataSet ds = Maticsoft.BLL.XmlDatasetConvert.ConvertXMLToDataSet(btFormat.SubStrings.XML);
                //                                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)//遍历ds 
                    {
                        _WTT_LabInfo.Add(new Maticsoft.Model.LabInfo() { Name = dr["Name"].ToString(), Value = dr["Value"].ToString() });
                    }
                    //排序
                    // _WTT_LabInfo = new ObservableCollection<Maticsoft.Model.LabInfo>(_WTT_LabInfo.OrderBy(P=>P.Name));

                }
                else { My_MessageBox.My_MessageBox_Message("未找到要设置的模板信息，请确认模板设置是否正确！"); }
                //
                btFormat.Close(SaveOptions.DoNotSaveChanges);
                btEngine.Stop();
            }
            //获取异常信息
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message("加载模板信息过程中发生错误!\r\n" + ex.Message); }
        }
        //
        //窗体载入事件
        //
        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgv_TemplateInfo.ItemsSource = _WTT_LabInfo;

                //加载模板名称
                string[] browsingFormats; // 存放文件名 
                // browsingFormats = System.IO.Directory.GetFiles("D:\\模板\\PrintTemplates\\BT_Templates\\", "*.btw");   // FolderPath 文件夹路径  *.btw 文家后缀
                browsingFormats = System.IO.Directory.GetFiles("\\\\QQQQQQ-MS2\\Templates\\PrintTemplates\\HP_Templates\\", "*.btw");   // FolderPath 文件夹路径  *.btw 文家后缀
                int i = 0;
                foreach (string temName in browsingFormats)
                {
                    browsingFormats[i] = temName.Substring(51);
                    i++;
                }
                cmb_LabTemplate.ItemsSource = browsingFormats;
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Erry("未启动ＢＴ线程！此模式下只可进行标签核对功能！\r\n" + ex.Message); }
        }
        //
        //工单单号  事件：KeyUp
        //
        private void txb_OrderID_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Maticsoft.BLL.PackBatch _M_PackBatch = new Maticsoft.BLL.PackBatch();
            if (e.Key == System.Windows.Input.Key.Enter && txb_OrderID.IsFocused)
            {
                if (txb_OrderID.Text.Trim() != "")
                {
                    DataSet temDs = _M_PackBatch.GetList("OrderID = '" + txb_OrderID.Text.Trim() + "'");
                    if (temDs.Tables[0].Rows.Count > 0)
                    {
                        cmb_BatchNo.DataContext = temDs.Tables[0].DefaultView;
                        cmb_BatchNo.SelectedIndex = 0;
                    }
                    else { My_MessageBox.My_MessageBox_Message("未找到工单信息！"); }
                }
            }
        }
        //
        //提交单元格 的更改到类
        //
        private void dgv_TemplateInfo_CellEditEnding(object sender, System.Windows.Controls.DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == System.Windows.Controls.DataGridEditAction.Commit)
            {
                int i = e.Row.GetIndex();                           //Get Rows Index 获取行号索引
                Maticsoft.Model.LabInfo li = (Maticsoft.Model.LabInfo)e.Row.Item;                  // Convert to LabInfo  转换为LabInfo类型           
                _WTT_LabInfo[i] = li;                               // Assignment _WTT     修改全局变量
                My_MessageBox.My_MessageBox_Message(li.ToString()); //MessageShow   显示信息
            }
        }
        //
        //保存
        //
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Maticsoft.BLL.OrderLabSet _M_LabSetInfo = new Maticsoft.BLL.OrderLabSet();
            Maticsoft.BLL.LabInfo _M_LabInfo = new Maticsoft.BLL.LabInfo();
            Maticsoft.Model.OrderLabSet _LabSet = new Maticsoft.Model.OrderLabSet();

            _LabSet = _M_LabSetInfo.GetModel(cmb_BatchNo.Text.Trim());

            if (_LabSet == null) //如果未保存过此批号的信息
            {
                Save_LabInfo();
            }
            else
            {
                if (System.Windows.Forms.MessageBox.Show("工单：" + txb_OrderID.Text.ToString()
                         + "\r\n批号：" + cmb_BatchNo.Text.ToString()
                         + "已经存在，继续将替换原有工单！\r\n是否继续添加", "系统提示",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    lab_State.Content = "正在删除数据.....";
                    //删除原有数据   
                    _M_LabSetInfo.Delete(_LabSet.Lab_ID);
                    _M_LabInfo.Delete(_LabSet.Lab_ID.ToString());
                    //添加新数据数据
                    Save_LabInfo();

                }
            }
        }

        //
        //载入工单标签信息
        //
        private void btn_Lad_OrderLabInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _WTT_LabInfo.Clear(); //清空列表
                Maticsoft.Model.OrderLabSet _LabSet = MCP_CS._M_OrderLabSet.GetModel(cmb_BatchNo.Text.Trim());
                if (_LabSet != null)
                {
                    cmb_LabTemplate.Text = _LabSet.LabName;
                    txb_Batch_OptionCount.Text = _LabSet.Count;
                    DataSet ds = MCP_CS._M_labInfo.GetList("Lab_ID = '" + _LabSet.Lab_ID + "'");
                    //                                
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)//遍历ds 
                        {
                            _WTT_LabInfo.Add(new Maticsoft.Model.LabInfo() { Name = dr["Name"].ToString(), Value = dr["Value"].ToString() });
                        }
                    }
                }
                else { My_MessageBox.My_MessageBox_Message("未找到该工单的标签信息！"); }
                //              
            }
            //获取异常信息
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message("加载模板信息过程中发生错误!\r\n" + ex.Message); }
        }

        //
        //生产预览
        //
        private void btn_YL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Patch = "\\\\QQQQQQ-MS2\\Templates\\PrintTemplates\\HP_Templates\\" + cmb_LabTemplate.Text.Trim();
                btEngine.Start();
                LabelFormatDocument btFormat2 = btEngine.Documents.Open(Patch);
                //填充打印数据源
                foreach (Maticsoft.Model.LabInfo _lin in _WTT_LabInfo)
                {
                    string drName = _lin.Name;
                    btFormat2.SubStrings[drName].Value = _lin.Value;
                }
                string path = @"D:\Thumbnail.jpeg";

                File.Delete(path);


                Resolution t = new Resolution(ImageResolution.Screen);



                btFormat2.ExportImageToFile(path, ImageType.JPEG, Seagull.BarTender.Print.ColorDepth.ColorDepth256, new Resolution(3840, 2160), OverwriteOptions.Overwrite);

                btFormat2.Close(SaveOptions.DoNotSaveChanges);
                btEngine.Stop();
                lab_State.Content = "显示图片";
                try
                {
                    //读成二进制
                    imBytes = File.ReadAllBytes(path);
                    //直接把这个存储到数据就行了cmd.Parameters.Add("@image", SqlDbType.Image).Value = bytes;

                    //在控件中显示图片
                    BitmapImage BI = new BitmapImage();
                    BI.BeginInit();
                    BI.StreamSource = new MemoryStream(imBytes);  //bufPic是图片二进制，byte类型
                    BI.EndInit();

                    // image1.Width = BI.Width;
                    // image1.Height = BI.Height;

                    image1.UseLayoutRounding = true;
                    image1.Source = BI;//image是XAML页面上定义的Image控件                                   
                }
                catch { }
                lab_State.Content = "生成完成！";
                // System.Diagnostics.Process.Start("explorer.exe", FilePath); //打开指定文件夹
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Erry("错误\r\n" + ex.Message); }

        }

        //
        //选择待验证的项目
        //
        private void dgv_Not_Verify_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                //获取选定项目
                _W_LabVerify = (Maticsoft.Model.LabVerify)dgv_Not_Verify.SelectedItem;
                decimal picID = decimal.Parse(_W_LabVerify.LabPic_ID);
                imBytes = MCP_CS.ImageList.GetModel(picID).Im;

                //在控件中显示图片
                BitmapImage BI = new BitmapImage();
                BI.BeginInit();
                BI.StreamSource = new MemoryStream(imBytes);  //bufPic是图片二进制，byte类型
                BI.EndInit();
                image1.Source = BI;//image是XAML页面上定义的Image控件       
                                   // System.Diagnostics.Process.Start("explorer.exe", FilePath); //打开指定文件夹

                //显示工单中设置的检测标准
                dgv_InspecStandard.ItemsSource = MCP_CS.InseectStandaer.GetModelList(_W_LabVerify.Orm_ID);

            }
            catch { image1.Source = null; }
        }


        //
        //载入待验证
        //
        private void btn_Lading_NotVerify_Click(object sender, RoutedEventArgs e)
        {
            dgv_Not_Verify.ItemsSource = MCP_CS.LabVerify.GetModelList(" (IsVerify = '0') ");
        }

        //
        //进行验证
        //
        private void btn_Verify_Click(object sender, RoutedEventArgs e)
        {
            User_Verify f = new User_Verify();
            f.ShowDialog();
            if (f.Result_InspectUser == true && f.SysUser.Privilege == "工程师" || f.SysUser.Privilege == "系统管理员"
                || f.SysUser.Privilege == "助理" || f.SysUser.Privilege == "主管")
            {
                _W_LabVerify.UserID = f.SysUser.UserID;
                _W_LabVerify.IsVerify = "1";
                if (MCP_CS.LabVerify.Update(_W_LabVerify))
                {
                    My_MessageBox.My_MessageBox_Message("更新成功！");
                    dgv_Not_Verify.ItemsSource = MCP_CS.LabVerify.GetModelList(" (IsVerify = '0') ");
                    image1.Source = null;
                    dgv_InspecStandard.ItemsSource = null;
                }
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("未执行，操作被用户终止！或未通过验证 请确定您是否有权限进行此次操作！");
            }
        }



        # region Method

        /// <summary>
        /// 保存工单中此批号的标签信息
        /// </summary>
        private void Save_LabInfo()
        {
            lab_State.Content = "正在保存标签信息.....";
            Maticsoft.Model.OrderLabSet _OrderLabSet = new Maticsoft.Model.OrderLabSet();
            //                  
            Maticsoft.BLL.LabInfo _M_LabInfo = new Maticsoft.BLL.LabInfo();
            Maticsoft.BLL.OrderLabSet _M_OrderLabSet = new Maticsoft.BLL.OrderLabSet();

            // 标签打印信息设置
            _OrderLabSet = new Maticsoft.Model.OrderLabSet()
            {
                OrderID = txb_OrderID.Text.Trim(),
                BachNo = cmb_BatchNo.Text.Trim(),
                Count = txb_Batch_OptionCount.Text.Trim(),
                LabName = cmb_LabTemplate.Text.Trim()
            };

            //保存标签设置信息
            string labID = _M_OrderLabSet.GetModel(_M_OrderLabSet.Add(_OrderLabSet)).Lab_ID.ToString();
            foreach (Maticsoft.Model.LabInfo lab in _WTT_LabInfo)
            {
                lab.Lab_ID = labID;
                _M_LabInfo.Add(lab);
            }


            Save_LabVerify();
        }

        LabelFormatDocument btFormat2;
        private void Save_LabVerify()
        {
            //---------------------------生产图片
            string Patch = "\\\\QQQQQQ-MS2\\Templates\\PrintTemplates\\HP_Templates\\" + cmb_LabTemplate.Text.Trim();
            btEngine.Start();
            btFormat2 = btEngine.Documents.Open(Patch);
            //填充打印数据源
            foreach (Maticsoft.Model.LabInfo _lin in _WTT_LabInfo)
            {
                string drName = _lin.Name;
                btFormat2.SubStrings[drName].Value = _lin.Value;
            }
            string path = "\\\\QQQQQQ-MS2\\Templates\\PrintTemplates\\TemFile\\Tem.PNG";

            File.Delete(path);


            Resolution t = new Resolution(ImageResolution.Screen);

            btFormat2.ExportImageToFile(path,
                ImageType.PNG, Seagull.BarTender.Print.ColorDepth.ColorDepth256, t, OverwriteOptions.Overwrite);

            btFormat2.Close(SaveOptions.DoNotSaveChanges);
            btEngine.Stop();
            lab_State.Content = "显示图片";
            //----------------------------END
            //读成二进制
            imBytes = File.ReadAllBytes(path);
            string LabPicID = "";


            //---------------------------保存图片
            Maticsoft.Model.ImageList _ImageList = new Maticsoft.Model.ImageList()
            {
                Im = imBytes,
                Name = cmb_BatchNo.Text.Trim(),
                Remarks = cmb_LabTemplate.Text.Trim()
            };
            Maticsoft.Model.ImageList _tem = MCP_CS.ImageList.GetModel("Name = '" + cmb_BatchNo.Text.Trim() + "'");
            if (_tem != null)
            {
                _tem.Im = imBytes;
                _tem.Name = cmb_BatchNo.Text.Trim();
                _tem.Remarks = cmb_LabTemplate.Text.Trim();
                MCP_CS.ImageList.Update(_tem);
                LabPicID = _tem.ID.ToString();
            }
            else
            {
                LabPicID = MCP_CS.ImageList.Add(_ImageList).ToString();
            }
            //--------------------------END


            //--------------------------保存待核对标签数据
            Maticsoft.Model.LabVerify _Ver = new Maticsoft.Model.LabVerify()
            {
                Orm_ID = txb_OrderID.Text.Trim(),
                Pb_ID = cmb_BatchNo.Text.Trim(),
                IsVerify = "0",
                LabPic_ID = LabPicID,
                UserID = null
            };
            Maticsoft.Model.LabVerify _tem2 = MCP_CS.LabVerify.GetModel("Pb_ID = '" + cmb_BatchNo.Text.Trim() + "'");
            if (_tem2 != null)
            {
                _tem2.IsVerify = "0";
                _tem2.LabPic_ID = LabPicID;
                _tem2.UserID = null;
                MCP_CS.LabVerify.Update(_tem2);
            }
            else { MCP_CS.LabVerify.Add(_Ver); }

            //--------------------------END

            //清空控件信息
            _WTT_LabInfo.Clear();
            txb_Batch_OptionCount.Text = "";
            txb_OrderID.Text = "";
            cmb_BatchNo.Text = "";
            cmb_LabTemplate.Text = "";

            My_MessageBox.My_MessageBox_Message("标签设置成功！");
        }








        #endregion


        //打印外带标签
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string Patch = @"D:\模板\PrintTemplates\HP_Templates\" + cmb_LabTemplate.Text.Trim();
                btEngine.Start();
                btFormat2 = btEngine.Documents.Open(Patch);

                string patch = @"D:\模板\PrintTemplates\Data_Source\" + cmb_LabTemplate.Text.Trim().Substring(0, cmb_LabTemplate.Text.Trim().Length - 4) + ".xlsx";
                Install_data_ToExcel(patch);

                Messages messages = null;
                btFormat2.Print("PrintJob1", out messages);
                
                My_MessageBox.My_MessageBox_Message("打印完毕！");

                Maticsoft.DAL.My_Print.Delete_ExcelData(patch, int.Parse(txb_PrintCount.Text.Trim()));

            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }

        /// <summary>
        ///  install Data TO Excel
        ///  Export 
        /// </summary>
        private bool Install_data_ToExcel(string patch)
        {
            ZhuifengLib.ExcelHelper excelHelper = new ZhuifengLib.ExcelHelper(patch);
            var ParList = new List<ZhuifengLib.InsertExcelParameter>();
            int tem = int.Parse(txb_PrintCount.Text.Trim());

            foreach (Maticsoft.Model.LabInfo _lin in _WTT_LabInfo)
            {
                if (_lin.Name == "Qty") { _lin.Value = txb_QtyValue.Text.Trim(); }
                ParList.Add(new ZhuifengLib.InsertExcelParameter() { Type = _lin.Name, Paramenter = _lin.Value });
            }

            excelHelper.InsertRow(ParList, tem);

            return true;
        }


    }
}
