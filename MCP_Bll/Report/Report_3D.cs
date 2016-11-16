using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace Maticsoft.BLL
{
   public class Report_3D
   {

       #region TFK
       /// <summary>
        /// TFK十二芯检测x2数据导出
       /// </summary>
       /// <param name="e"></param>
       public void TFK十二芯检测x2(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\"+e.Template;
               _NewFile = e.SavePath + "_3D.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { MessageBox.Show("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);

               //开始填充数据            
               DataSet temdata = e.ImportData;              
               int rowIndex = 10;
               int colIndex = 0;
              
               //填充数据
               foreach (DataRow row in temdata.Tables[0].Rows)
               {
                   rowIndex++;
                   colIndex = 0;
                   foreach (DataColumn col in temdata.Tables[0].Columns)
                   {
                       colIndex++;
                       xlApp.Cells[rowIndex, colIndex] = row[col.ColumnName];
                   }
                   e.StatUpProgressBar(0, temdata.Tables[0].Rows.Count, rowIndex-1);
               }

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");             
           }
           catch (System.Exception ex) { MessageBox.Show(ex.Message); }              
       }
       #endregion


       #region 装箱报告
       /// <summary>
       /// 装箱报告导出
       /// </summary>
       /// <param name="e"></param>
       public void Encasement(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath + e.Template;
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { MessageBox.Show("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);

               //开始填充数据
               DataSet temdata = e.ImportData;
               int rowIndex = 1;
               int colIndex = 0;
              
               //填充数据
               foreach (DataRow row in temdata.Tables[0].Rows)
               {
                   rowIndex++;
                   colIndex = 0;
                   foreach (DataColumn col in temdata.Tables[0].Columns)
                   {
                       colIndex++;
                       xlApp.Cells[rowIndex, colIndex] = row[col.ColumnName];
                   }
                   e.StatUpProgressBar(0, temdata.Tables[0].Rows.Count, rowIndex - 1);
               }

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { MessageBox.Show(ex.Message); }    
       }
       #endregion 


       #region 8芯

       /// <summary>
       /// 配组-8芯
       /// </summary>
       /// <param name="e"></param>
       public void peizu(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath + "_3D.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { MessageBox.Show("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);

               padding_putu(e, xlApp);

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { MessageBox.Show(ex.Message); }    
       }

       /// <summary>
       ///  普通填充
       /// </summary>
       private static void padding_putu(Maticsoft.BLL.Report.ImportEventArgs e, Excel.Application xlApp)
       {
           //开始填充数据
           DataSet temdata = e.ImportData;
           int rowIndex = 10;
           int colIndex = 0;

           //填充数据
           foreach (DataRow row in temdata.Tables[0].Rows)
           {
               rowIndex++;
               colIndex = 0;
               foreach (DataColumn col in temdata.Tables[0].Columns)
               {
                   colIndex++;
                   xlApp.Cells[rowIndex, colIndex] = row[col.ColumnName];
               }
               e.StatUpProgressBar(0, temdata.Tables[0].Rows.Count, rowIndex - 1);
           }
       }

       #endregion


       #region 多芯
       /// <summary>
       /// 多芯导出
       /// </summary>
       /// <param name="e"></param>
       public void Multicore(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath + "_3D.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { MessageBox.Show("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);

               //开始填充数据
               DataSet temdata = e.ImportData;
               int rowIndex = 10;
               int colIndex = 0;

               //填充数据
               foreach (DataRow row in temdata.Tables[0].Rows)
               {
                   rowIndex++;
                   colIndex = 0;
                   foreach (DataColumn col in temdata.Tables[0].Columns)
                   {
                       colIndex++;
                       xlApp.Cells[rowIndex, colIndex] = row[col.ColumnName];
                   }
                   e.StatUpProgressBar(0, temdata.Tables[0].Rows.Count, rowIndex - 1);
               }

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

              // My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { MessageBox.Show(ex.Message); }    
       }


       #endregion

    }
}
