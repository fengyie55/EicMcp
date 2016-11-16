using System;
using System.Data;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace Maticsoft.BLL
{
   public  class Report_Exfo
    {
       /// <summary>
       /// 导出报告 Pigtail
       /// </summary>
       /// <param name="e"></param>
       public void Export_Exfo_One(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath +"_Exfo.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { My_MessageBox.My_MessageBox_Message("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);             
               //进行填充
               Padding_Data_One(e, xlApp);

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }

       }

       public void Export_Exfo_MPO(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath + "_Exfo.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { My_MessageBox.My_MessageBox_Message("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
               //进行填充             
               padding_MPO(e, xlApp);

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
       }
      
       /// <summary>
       /// 双并线导出
       /// </summary>
       /// <param name="e"></param>
       public void Export_Twin(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath + "_Exfo.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { My_MessageBox.My_MessageBox_Message("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
               //进行填充
               Padding_TwinPigtail(e, xlApp);

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
       }

       /// <summary>
       /// 4芯数据导出
       /// </summary>
       public void Export_fourCore(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath + "_Exfo.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { My_MessageBox.My_MessageBox_Message("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
               //进行填充
               padding_fourCore(e, xlApp);

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
       }

       /// <summary>
       /// 8芯数据导出
       /// </summary>
       /// <param name="e"></param>
       public void Export_EightCore(Maticsoft.BLL.Report.ImportEventArgs e)
       {
           try
           {
               //从模板拷贝数据
               string _OrignFile, _NewFile;
               _OrignFile = "D:\\模板\\ReportTemplates\\" + e.Template;
               _NewFile = e.SavePath + "_Exfo.xls";
               File.Delete(_NewFile);
               File.Copy(_OrignFile, _NewFile);

               //将数据填充到模板
               Excel.Application xlApp = new Excel.Application();
               if (xlApp == null) { My_MessageBox.My_MessageBox_Message("Can’t open Excel!"); return; }
               xlApp.Workbooks._Open(_NewFile);
               Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);
               //进行填充             
               padding_EightCore(e, xlApp);

               //填充完成后的操作          
               xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
               xlApp.AlertBeforeOverwriting = false;
               xlApp.SaveWorkspace(); //保存工作簿  
               xlApp.Quit();          //确保Excel进程关闭  
               xlApp = null;
               GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出      

               My_MessageBox.My_MessageBox_Message("导出完成！");
           }
           catch (System.Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
       }

       #region Padding List
       /// <summary>
       /// 填充普通类型的数据
       /// </summary>
       /// <param name="e"></param>
       /// <param name="xlApp"></param>
       private static void Padding_Data_One(Maticsoft.BLL.Report.ImportEventArgs e, Excel.Application xlApp)
       {
           //开始填充数据            
           DataSet temdata = e.ImportData;
           int rowIndex = 10;
           int colIndex = 0;

           //填充数据
           foreach (DataRow row in temdata.Tables[0].Rows)
           {
               rowIndex++;
               colIndex = 1;
               foreach (DataColumn col in temdata.Tables[0].Columns)
               {
                   colIndex++;
                   xlApp.Cells[rowIndex, colIndex] = row[col.ColumnName];
               }
               e.StatUpProgressBar(0, temdata.Tables[0].Rows.Count, rowIndex - 7);
           }
       }

       /// <summary>
       /// 双并填充
       /// </summary>
       /// <param name="e"></param>
       /// <param name="xlApp"></param>
       private static void Padding_TwinPigtail(Maticsoft.BLL.Report.ImportEventArgs e, Excel.Application xlApp)
       {
           //开始填充数据            
           ArrayList _SN_Data = e.SN_DataList;
           int rowIndex = 10;  
           int maxcount = e.SN_DataList.Count;

           foreach (DataSet temds in _SN_Data)
           {
               rowIndex++;
               //填充数据
               foreach (DataRow row in temds.Tables[0].Rows)
               {                
                   string PigtailNum = row["Name"].ToString();
                   switch (PigtailNum)
                   {
                       case "A1":
                           {                             
                               xlApp.Cells[rowIndex , 2] = row["SN"];
                               xlApp.Cells[rowIndex, 3] = row["IL_A"];
                               xlApp.Cells[rowIndex , 4] = row["Refl_A"];                             
                               break;
                           }
                       case "A2":
                           {
                               xlApp.Cells[rowIndex , 5] = row["IL_A"];
                               xlApp.Cells[rowIndex , 6] = row["Refl_A"];                             
                               break;
                           }
                       case "B1":
                           {
                               xlApp.Cells[rowIndex , 7] = row["IL_A"];
                               xlApp.Cells[rowIndex , 8] = row["Refl_A"];                              
                               break;
                           }
                       case "B2":
                           {
                               xlApp.Cells[rowIndex, 9] = row["IL_A"];
                               xlApp.Cells[rowIndex, 10] = row["Refl_A"];                            
                               break;
                           }
                   }

                     e.StatUpProgressBar(0, maxcount,rowIndex-7);
               }

           }
       }

       /// <summary>
       ///  4芯数据导出
       /// </summary>
       private static void padding_fourCore(Maticsoft.BLL.Report.ImportEventArgs e, Excel.Application xlApp)
       {
           //开始填充数据            
           ArrayList _SN_Data = e.SN_DataList;
           int rowIndex = 10;  
           int maxcount =e.SN_DataList.Count;
         
           foreach (DataSet temds in _SN_Data)
           {
               rowIndex++;
               //colIndex = 1;
               //填充数据
               foreach (DataRow row in temds.Tables[0].Rows)
               {

                   string PigtailNum = row["Name"].ToString();
                   switch (PigtailNum)
                   {
                       case "1":
                           {
                               xlApp.Cells[rowIndex, 2] = row["SN"];
                               xlApp.Cells[rowIndex, 3] = row["IL_A"];
                               xlApp.Cells[rowIndex, 4] = row["Refl_A"];                         
                               break;
                           }
                       case "2":
                           {
                               xlApp.Cells[rowIndex, 5] = row["IL_A"];
                               xlApp.Cells[rowIndex, 6] = row["Refl_A"];
                               break;
                           }
                       case "3":
                           {
                               xlApp.Cells[rowIndex, 7] = row["IL_A"];
                               xlApp.Cells[rowIndex, 8] = row["Refl_A"];
                               break;
                           }
                       case "4":
                           {
                               xlApp.Cells[rowIndex, 9] = row["IL_A"];
                               xlApp.Cells[rowIndex, 10] = row["Refl_A"];
                               break;
                           }
                   }
                   e.StatUpProgressBar(0, maxcount, rowIndex - 7);
               }
           }
       }


       /// <summary>
       ///  MPO数据导出
       /// </summary>
       private static void padding_MPO(Maticsoft.BLL.Report.ImportEventArgs e, Excel.Application xlApp)
       {
           Maticsoft.BLL.Pack_Exfo _M_PackExfo = new Pack_Exfo();
           SerialNumber _M_SerialNumber = new SerialNumber();
           ArrayList _SN_Data = _M_SerialNumber.Get_SN_List(" BatchNo = '" + e.BatchNo.BatchNo + "' AND State = 'Yet_Pack'");
           int temcount =0;
           int _exRow = 3;              
           foreach(string _SN  in _SN_Data)
           {
               xlApp.Cells[_exRow, 1] = _SN;
               // 1            
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-1"+"'   AND (Wave = '850nm')" ), _exRow, 3);            
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-1" + "' AND (Wave = '1300nm')"), _exRow, 4);
               // 2
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-2" + "'   AND (Wave = '850nm')"), _exRow, 5);
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-2" + "' AND (Wave = '1300nm')"), _exRow, 6);
               // 3
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-3" + "'   AND (Wave = '850nm')"), _exRow, 7);
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-3" + "' AND (Wave = '1300nm')"), _exRow, 8);
               // 4
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-4" + "'   AND (Wave = '850nm')"), _exRow, 9);
                PaddingMpo(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-4" + "' AND (Wave = '1300nm')"), _exRow, 10);
               temcount ++;
               _exRow = _exRow + 12;
               e.StatUpProgressBar(0, _SN_Data.Count, temcount);
           }
       }
             
       /// <summary>
       /// 填充数据
       /// </summary>
       /// <param name="ds">数据源</param>
       /// <param name="roindex">行坐标</param>
       /// <param name="colIndex">列坐标</param>
       private static void PaddingMpo( Excel.Application xlApp ,DataSet ds, int roindex, int colIndex )
       {
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               xlApp.Cells[roindex, colIndex] = dr["IL_A"].ToString();
               roindex++;
           }                                         
       }

       private static void padding_EightCore(Maticsoft.BLL.Report.ImportEventArgs e, Excel.Application xlApp)
       {
           Maticsoft.BLL.Pack_Exfo _M_PackExfo = new Pack_Exfo();
           SerialNumber _M_SerialNumber = new SerialNumber();
           ArrayList _SN_Data = _M_SerialNumber.Get_SN_List(" BatchNo = '" + e.BatchNo.BatchNo + "' AND State = 'Yet_Pack'");
           int temcount = 0;
           int _exRow = 5;
           foreach (string _SN in _SN_Data)
           {
               xlApp.Cells[_exRow, 1] = _SN;
               // 1            
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-1" + "'   AND (Wave = '1550nm')"), _exRow, 3);
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-2" + "'   AND (Wave = '1550nm')"), _exRow, 5);
               // 2
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-3" + "'   AND (Wave = '1550nm')"), _exRow, 7);
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-4" + "'   AND (Wave = '1550nm')"), _exRow, 9);
               // 3
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-5" + "'   AND (Wave = '1550nm')"), _exRow, 11);
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-6" + "' AND (Wave = '1550nm')"), _exRow, 13);
               // 4
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-7" + "'   AND (Wave = '1550nm')"), _exRow, 15);
               PaddingEightCore(xlApp, _M_PackExfo.GetList("SN = '" + _SN + "-8" + "' AND (Wave = '1550nm')"), _exRow, 17);
               temcount++;
               _exRow++;
               e.StatUpProgressBar(0, _SN_Data.Count, temcount);
           }
       }

       /// <summary>
       /// 填充数据
       /// </summary>
       /// <param name="ds">数据源</param>
       /// <param name="roindex">行坐标</param>
       /// <param name="colIndex">列坐标</param>
       private static void PaddingEightCore(Excel.Application xlApp, DataSet ds, int roindex, int colIndex)
       {
           foreach (DataRow dr in ds.Tables[0].Rows)
           {
               xlApp.Cells[roindex, colIndex] = dr["IL_A"].ToString();
               colIndex++;
               xlApp.Cells[roindex, colIndex] = dr["Refl_A"].ToString();
               roindex++;
           }
       }



       #endregion

    }
}
