using System.Data;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System;
using System.Collections.Generic;


namespace Maticsoft.DAL
{
    class Print_Excel
    {
        int Not_SN_Count = 0;


        /*
        private void AddData(Model.WorkOrder _Order, int _IndexNum, List<Model.Pack_Exfo> _PackExfo)
        {
            //如果已经添加的数量为0
            if (_IndexNum == 0)
            {
                string _OrignFile, _NewFile;
                _OrignFile = "D:\\模板\\Parallel.xls";  //模板文件
                _NewFile = "D:\\模板\\TemPrint.xls";    //临时模板文件 待打印文件
                File.Delete(_NewFile);                  //删除之前的临时模板
                File.Copy(_OrignFile, _NewFile);        //拷贝模板
            }

            //将数据添加到临时模板
            int _Row = 0;      //行变量
            int _Line = 0;     //列变量
            int _Left = 0;     //左
            int _Top = 0;      //上
            int _TemLine = 11, _TemRow = 12, _TemLeft = 318, _TemTop = 135; ;
            switch (_IndexNum)
            {
                case 0: { _Row = 0; _Line = 0; _Left = 0; _Top = 0; break; }
                case 1: { _Row = 0; _Line = _TemRow; _Left = _TemLeft; _Top = 0; break; }
                case 2: { _Row = _TemLine * 1; _Line = 0; _Left = 0; _Top = _TemTop * 1; break; }
                case 3: { _Row = _TemLine * 1; _Line = _TemRow; _Left = _TemLeft; _Top = _TemTop * 1; break; }
                case 4: { _Row = _TemLine * 2; _Line = 0; _Left = 0; _Top = _TemTop * 2; break; }
                case 5: { _Row = _TemLine * 2; _Line = _TemRow; _Left = _TemLeft; _Top = _TemTop * 2; break; }
                case 6: { _Row = _TemLine * 3; _Line = 0; _Left = 0; _Top = _TemTop * 3; break; }
                case 7: { _Row = _TemLine * 3; _Line = _TemRow; _Left = _TemLeft; _Top = _TemTop * 3; break; }
                case 8: { _Row = _TemLine * 4; _Line = 0; _Left = 0; _Top = _TemTop * 4; break; }
                case 9: { _Row = _TemLine * 4; _Line = _TemRow; _Left = _TemLeft; _Top = _TemTop * 4; break; }
                case 10: { _Row = _TemLine * 5; _Line = 0; _Left = 0; _Top = _TemTop * 5; break; }
                case 11: { _Row = _TemLine * 5; _Line = _TemRow; _Left = _TemLeft; _Top = _TemTop * 5; break; }
            }

            string NewFile;
            NewFile = "D:\\模板\\TemPrint.xls";
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null) { MessageBox.Show("Can’t open Excel!"); return; }
            xlApp.Workbooks._Open(NewFile);
            Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);

            //把DataGridView当前页的数据保存在Excel中       

            string _date = DateTime.Now.ToString("dd-MMM-yyyy", new System.Globalization.CultureInfo("en-US"));
            //****************************************************************************  设置Excel模板  ***

            //      
            oSheet.Shapes.AddPicture("D:\\模板\\NEXANS图标.bmp", Microsoft.Office.Core.MsoTriState.msoTrue,
                Microsoft.Office.Core.MsoTriState.msoTrue, _Left, _Top, 73, 20);           //设置Nexans 图标      
            //
            xlApp.Cells[_Row + 2, _Line + 1] = "MODEL NO:";
            xlApp.Cells[_Row + 3, _Line + 1] = "CABLE CORDAGE:";
            xlApp.Cells[_Row + 4, _Line + 1] = "NEXANS SAP P/N:";

            xlApp.Cells[_Row + 9, _Line + 1] = "DATE:";
            xlApp.Cells[_Row + 9, _Line + 7] = "Q'TY:";
            xlApp.Cells[_Row + 3, _Line + 9] = "   LENGTH:";
            //          
            xlApp.Cells[_Row + 5, _Line + 6] = "dB";
            xlApp.Cells[_Row + 6, _Line + 6] = "dB";
            xlApp.Cells[_Row + 7, _Line + 6] = "dB";
            xlApp.Cells[_Row + 8, _Line + 6] = "dB";
            //
            xlApp.Cells[_Row + 5, _Line + 11] = "dB";
            xlApp.Cells[_Row + 6, _Line + 11] = "dB";
            xlApp.Cells[_Row + 7, _Line + 11] = "dB";
            xlApp.Cells[_Row + 8, _Line + 11] = "dB";
            //           
            if (_Order.InspectMethod == Model.E_InspectMethod.双并检测)
            {
                xlApp.Cells[_Row + 5, _Line + 1] = "Insertion/Loss:A1";
                xlApp.Cells[_Row + 6, _Line + 1] = "                      A2";
                xlApp.Cells[_Row + 5, _Line + 9] = "B1";
                xlApp.Cells[_Row + 6, _Line + 9] = "B2";
                //
                xlApp.Cells[_Row + 7, _Line + 1] = "Return/Loss:   A1";
                xlApp.Cells[_Row + 8, _Line + 1] = "                      A2";
                xlApp.Cells[_Row + 7, _Line + 9] = "B1";
                xlApp.Cells[_Row + 8, _Line + 9] = "B2";


                //填充规格
                xlApp.Cells[_Row + 2, _Line + 3] = _Order.ModelNo;           //ModelNO
                xlApp.Cells[_Row + 3, _Line + 5] = _Order.CableCordage;      //CableCordage
                xlApp.Cells[_Row + 4, _Line + 5] = _Order.NexansSap;         //NexansSapLabel            
                xlApp.Cells[_Row + 9, _Line + 2] = _date.ToString();
                xlApp.Cells[_Row + 9, _Line + 9] = _Order.Qty;               //Qty
                xlApp.Cells[_Row + 3, _Line + 11] = _Order.Length;            //Length
                //****************************************************************************              
                for (int i = 0; i < PrintExfo.Rows.Count - 1; i++)
                {
                    foreach (Model.Pack_Exfo _pack in _PackExfo)
                    {

                    }
                    System.Windows.Forms.Application.DoEvents();
                    string Name = PrintExfo.Rows[i].Cells["PartNumber"].Value.ToString();
                    switch (Name)
                    {
                        case "A1":
                            xlApp.Cells[_Row + 5, _Line + 4] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 7, _Line + 4] = PrintExfo[5, i].Value.ToString();
                            break;
                        case "A2":
                            xlApp.Cells[_Row + 6, _Line + 4] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 8, _Line + 4] = PrintExfo[5, i].Value.ToString();
                            break;
                        case "B1":
                            xlApp.Cells[_Row + 5, _Line + 10] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 7, _Line + 10] = PrintExfo[5, i].Value.ToString();
                            break;
                        case "B2":
                            xlApp.Cells[_Row + 6, _Line + 10] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 8, _Line + 10] = PrintExfo[5, i].Value.ToString();
                            xlApp.Cells[_Row + 10, _Line + 9] = PrintExfo[0, i].Value.ToString();
                            break;
                    }
                }
            }
            else
            {
                xlApp.Cells[_Row + 5, _Line + 1] = "Insertion/Loss:1";
                xlApp.Cells[_Row + 6, _Line + 1] = ".                      2";
                xlApp.Cells[_Row + 5, _Line + 9] = "3";
                xlApp.Cells[_Row + 6, _Line + 9] = "4";
                //
                xlApp.Cells[_Row + 7, _Line + 1] = "Return/Loss:   1";
                xlApp.Cells[_Row + 8, _Line + 1] = ".                      2";
                xlApp.Cells[_Row + 7, _Line + 9] = "3";
                xlApp.Cells[_Row + 8, _Line + 9] = "4";


                //填充规格
                xlApp.Cells[_Row + 2, _Line + 3] = modelNoLabel1.Text.ToString();
                xlApp.Cells[_Row + 3, _Line + 5] = cableCordageLabel1.Text.ToString();
                xlApp.Cells[_Row + 4, _Line + 5] = nexansSapLabel1.Text.ToString();

                //  xlApp.Cells[t + 9, f + 2] = dateTLabel1.Text.ToString();
                xlApp.Cells[_Row + 9, _Line + 2] = _date.ToString();
                xlApp.Cells[_Row + 9, _Line + 9] = qtyLabel1.Text.ToString();
                xlApp.Cells[_Row + 3, _Line + 11] = lengthLabel1.Text.ToString();
                //****************************************************************************

                for (int i = 0; i < PrintExfo.Rows.Count - 1; i++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    string Name = PrintExfo.Rows[i].Cells["PartNumber"].Value.ToString();
                    switch (Name)
                    {
                        case "1":
                            xlApp.Cells[_Row + 5, _Line + 4] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 7, _Line + 4] = PrintExfo[5, i].Value.ToString();
                            break;
                        case "2":
                            xlApp.Cells[_Row + 6, _Line + 4] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 8, _Line + 4] = PrintExfo[5, i].Value.ToString();
                            break;
                        case "3":
                            xlApp.Cells[_Row + 5, _Line + 10] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 7, _Line + 10] = PrintExfo[5, i].Value.ToString();
                            break;
                        case "4":
                            xlApp.Cells[_Row + 6, _Line + 10] = PrintExfo[4, i].Value.ToString();
                            xlApp.Cells[_Row + 8, _Line + 10] = PrintExfo[5, i].Value.ToString();
                            xlApp.Cells[_Row + 10, _Line + 9] = PrintExfo[0, i].Value.ToString();
                            break;
                    }
                }
            }
            //设置禁止弹出保存和覆盖的询问提示框  
            xlApp.DisplayAlerts = false;
            xlApp.AlertBeforeOverwriting = false;
            //保存工作簿  
            xlApp.SaveWorkspace();
            //确保Excel进程关闭  
            xlApp.Quit();
            xlApp = null;
            System.GC.Collect();//如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出    
        }
        */


    }
}
