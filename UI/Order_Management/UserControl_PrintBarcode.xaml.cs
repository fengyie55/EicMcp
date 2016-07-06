using AvalonDock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// UserControl_PrintBarcode.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_PrintBarcode : DocumentContent
    {
        public UserControl_PrintBarcode()
        {
            InitializeComponent(); 
        }
        Maticsoft.BLL.My_Print MyPrint = new Maticsoft.BLL.My_Print(); 
        

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            PrintSN();
        }

        private void DocumentContent_Loaded(object sender, RoutedEventArgs e)
        {
            MyPrint.IsBtPrint = true;
            MyPrint.IsPrint = true;
            MyPrint.LabName = "条码.btw";
        }

        private void PrintSN()
        {
            string temSN = txb_Barcode_Q.Text + txb_Barcodr_H.Text;
            if(temSN!="")
            {
                lab_State.Content = "状态:" + temSN;
                MyPrint.SN = temSN;
                MyPrint.BtPrint();
                txb_Barcodr_H.Text = "";
            }
            else { lab_State.Content = "状态:条码不能为空"; }
        }

        private void txb_Barcodr_H_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                PrintSN();
            }
        }

        // 标签打印
        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OnPrint_Two();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnPrint_Two();
        }


        private void OnPrint_Two()
        {
            /*
            ZhuifengLib.EXCEL.ExcelControl excel = new ZhuifengLib.EXCEL.ExcelControl();
            DataSet ds =  excel.ExcelReader("D:\\模板\\PrintRecode.xlsx");
             */
              MyPrint.LabName = "TKF8芯.btw";
              string temSN = tb_SN_Two.Text.Trim();
              if (IsNumberINorder(temSN))
              {
                  if (temSN != "")
                  {
                      tb_SN_Two.Text = "";
                      lab_State.Content = "状态:" + temSN;
                      MyPrint.SN = temSN;
                      MyPrint.BtPrint();
                    
                      ExportExcel(_order, temSN);
                  }
                  else { lab_State.Content = "状态:条码不能为空"; }
              }
              else { MessageBox.Show("条码不属于此工单"); }
             
        }


        private void ExportExcel(string _order,string _sn)
        {
            try
            {
                string _Path = "D:\\模板\\PrintRecode.xlsx";
                string strCon = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + _Path + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=0'";


                //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;  HDR=yes; ";
                OleDbConnection conn = new OleDbConnection(strCon);
                conn.Open();
                System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO [sheet1$] (OrderID,SN) VALUES ('"+_order+"','"+_sn+"')";
                cmd.ExecuteNonQuery();


                conn.Close();
               
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show("写入Excel发生错误：" + ex.Message);
            }
           
        }

        private void TextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                TextBox tb = sender as TextBox;
                _order = tb.Text.Trim();
                tb.IsEnabled = false;
            }
        }
        string _order = "";
        private bool IsNumberINorder(string _sn)
        {
            Maticsoft.BLL.SerialNumber sr = new Maticsoft.BLL.SerialNumber();
            return sr.Exists_where("  (OrderID = '"+_order+"') AND (SN = '"+_sn+"')");
        }
      

      
    }
}
