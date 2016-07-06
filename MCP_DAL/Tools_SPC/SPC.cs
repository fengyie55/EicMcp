using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System;
using System.Data;
using System.Collections;
using System.Xml;

namespace Maticsoft.DAL
{
    /*****************************************************************************
     *  添加新项目时  
     *  1.在枚举类型  Maticsoft.Model.E_Generate 添加要进行SPC管制的项目
     *  2.在private DataSet GetData_SPC(string _Parameter ,string _date) 方法中添加 获取SPC 数据的方法 
     *  3.在private string Get_Parameter(string Old_Parametrt) 方法中添加 参数 转换 为 获取到的数据的列名
     *  完成添加 
     * **************************************************************************/


    public class SPC
    {
                   
      //单表生成
      public void Get_SPC_MPO(string _SavePatch, string _Parameter, string _Date)
      {
         // try
        //  {
              //从模板拷贝数据
              string _OrignFile, _NewFile;
              _OrignFile = "D:\\模板\\Template_SPC.xls";
              _NewFile = _SavePatch + "\\" + _Date + "_" + _Parameter + ".xls";
              File.Delete(_NewFile);
              File.Copy(_OrignFile, _NewFile);
                         

              //将数据填充到模板
              Excel.Application xlApp = new Excel.Application();
              if (xlApp == null) { MessageBox.Show("Can’t open Excel!"); return; }
              xlApp.Workbooks._Open(_NewFile);
              Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);

              //设置模板
              SetTempoler(xlApp, _Parameter);

              //获取指定日期的数据
              DateTime StartDate = DateTime.Parse(_Date);
              string temdata = StartDate.ToString("yyyy-MM-dd");
              DataSet temds = GetData_SPC(_Parameter,temdata );

              //填充数据
              FillData(xlApp, temds, _Parameter, 1);

              My_MessageBox.My_MessageBox_Message("导出完成！");

              System.Diagnostics.Process.Start("explorer.exe", _SavePatch); //打开文件夹
              
        //  }
        //  catch (System.Exception ex) { MessageBox.Show(ex.Message); }        
      }

      //自动生成多表
      public void Get_SPC_MPO_Auto(string _SavePatch, string _StartDate, string _EndDate)
      {
          try
          {
              string[] temList = System.Enum.GetNames(typeof(Maticsoft.Model.E_Generate));
              foreach (string _Parameter in temList)
              {
                  //从模板拷贝数据
                  string _OrignFile, _NewFile;
                  _OrignFile = "D:\\模板\\Template_SPC.xls";
                  _NewFile = _SavePatch + "\\" + _Parameter + ".xls";
                  File.Delete(_NewFile);
                  File.Copy(_OrignFile, _NewFile);

                  //将数据填充到模板
                  Excel.Application xlApp = new Excel.Application();
                  if (xlApp == null) { MessageBox.Show("Can’t open Excel!"); return; }
                  xlApp.Workbooks._Open(_NewFile);
                  Excel._Worksheet oSheet = (Excel._Worksheet)xlApp.Sheets.get_Item(1);

                  ArrayList temDataList = DateList(_StartDate, _EndDate);  //日期列表
                  //设置模板
                  SetTempoler(xlApp, _Parameter);
                  //填充数据
                  FillData(xlApp, _Parameter, temDataList);
              }
              My_MessageBox.My_MessageBox_Message("导出完成！");
              System.Diagnostics.Process.Start("explorer.exe", _SavePatch);
          }
          catch (System.Exception ex) { MessageBox.Show(ex.Message); }
      }
          
     
      /******** Method ********/
     
      //生成日期列表
      private ArrayList DateList(string _StartDate, string _End_Date)
      {
         DateTime StartDate= DateTime.Parse(_StartDate);
         DateTime End_Date = DateTime.Parse(_End_Date);
         ArrayList temList = new ArrayList();
          for (DateTime s = StartDate; StartDate < End_Date; )
          {                       
              temList.Add(StartDate.ToString("yyyy-MM-dd"));
              StartDate = DateTime.Parse(StartDate.AddDays(1).ToShortDateString());
          }
          return temList;
      }

      //填充Exceltemplate
      private void FillData(Excel.Application xlApp, DataSet ds, string _Parameter, int Option)
      {
          string tem_Paramenter = Get_Parameter(_Parameter);
          int _Row, _Line, _dataRow = 0;
          for (_Line = 3; _Line < 28; _Line++)  //填充列
          {
              for (_Row = 10; _Row < 15; _Row++)  //填充行            
              {
                  if (_dataRow == ds.Tables[0].Rows.Count) { break; }
                  xlApp.Cells[_Row, _Line] = ds.Tables[0].Rows[_dataRow][tem_Paramenter].ToString();
                  _dataRow++;
              }
          }
          //填充完成后的操作          
          xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
          xlApp.AlertBeforeOverwriting = false;
          xlApp.SaveWorkspace(); //保存工作簿  
          xlApp.Quit();          //确保Excel进程关闭  
          xlApp = null;
          GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出            
      }

      //填充ExcelTemplate 根据日期自动填充
      private void FillData(Excel.Application xlApp, string _Parameter, ArrayList DateList)
      {
          string tem_Paramenter = Get_Parameter(_Parameter);
          int _Row, _Line=3, _dataRow = 0;        
          int temvalue = 0;  //进度显示
          foreach (string dt in DateList)        
          {
              _dataRow = 0;
            
              //获取指定日期的数据            
              DataSet temds = GetData_SPC(_Parameter, dt);           
                          
              //如果此日期没有数据 跳过
              if (temds.Tables[0].Rows.Count < 6) { }
              else
              {
                  xlApp.Cells[8, _Line] = dt.ToString();
                  //填充行
                  for (_Row = 10; _Row < 15; _Row++)
                  {
                      if (_dataRow == temds.Tables[0].Rows.Count) { break; }
                      xlApp.Cells[_Row, _Line] = temds.Tables[0].Rows[_dataRow][tem_Paramenter].ToString();
                      _dataRow++;
                  }
                  //前往下一列
                  _Line++;
                  temvalue++; //进度显示
                  //如果列已经达到25列 则返回
                  if (_Line > 28) 
                  { 
                      break; }
              }
          }


          //填充完成后的操作          
          xlApp.DisplayAlerts = false;  //设置禁止弹出保存和覆盖的询问提示框  
          xlApp.AlertBeforeOverwriting = false;
          xlApp.SaveWorkspace(); //保存工作簿  
          xlApp.Quit();          //确保Excel进程关闭  
          xlApp = null;
          GC.Collect();          //如果不使用这条语句会导致excel进程无法正常退出，使用后正常退出     
      }

      //获取指定日期的数据
      private DataSet GetData_SPC(string _Parameter ,string _date)
      {
          Maticsoft.DAL.User_3D_Test_Good _M_GetTestData = new User_3D_Test_Good();
          Maticsoft.DAL.User_JDS_Test_Good _M_ExfoData = new User_JDS_Test_Good();

          //APC 3D数据
          if (_Parameter == Maticsoft.Model.E_Generate.APC_Angle.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.APC_Curvature.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.APC_Spherucak.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.APC_Offset.ToString()
              )
          {
              return _M_GetTestData.Get_SPC(_date, "APC");
          }
        //PC 3D数据
          else if ( _Parameter == Maticsoft.Model.E_Generate.PC_Curvature.ToString() ||
            _Parameter == Maticsoft.Model.E_Generate.PC_Spherucak.ToString() ||
            _Parameter == Maticsoft.Model.E_Generate.PC_Offset.ToString()
            )
          {
              return _M_GetTestData.Get_SPC(_date, "PC");
          }
        //Exfo测试数据 1300
          else if (_Parameter == Maticsoft.Model.E_Generate.IL_1300nm.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.RL_1300nm.ToString())
          {
              return _M_ExfoData.Get_SPC("1300nm", _date);
          }
          //Exfo测试数据 1300
          else if (_Parameter == Maticsoft.Model.E_Generate.IL_1310nm.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.RL_1310nm.ToString())
          {
              return _M_ExfoData.Get_SPC("1310nm", _date);
          }
          //Exfo测试数据 1300
          else if (_Parameter == Maticsoft.Model.E_Generate.IL_1550nm.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.RL_1550nm.ToString())
          {
              return _M_ExfoData.Get_SPC("1550nm", _date);
          }
          //Exfo测试数据 1300
          else if (_Parameter == Maticsoft.Model.E_Generate.IL_850nm.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.RL_850nm.ToString())
          {
              return _M_ExfoData.Get_SPC("850nm", _date);
          }
          //Adapter 测试 SPC
          else if (_Parameter == Maticsoft.Model.E_Generate.Adapter_Test.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.Adapter_Testfour0.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.Adapter_Testfour90.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.Adapter_Testfour180.ToString() ||
              _Parameter == Maticsoft.Model.E_Generate.Adapter_Testfour270.ToString()
              )
          {
              Maticsoft.DAL.AdapterTestData _M_adaTestdata = new AdapterTestData();
              return _M_adaTestdata.Get_SPC(_date);
          }

    //MPO_EXFO数据
          else if (_Parameter == "MPO_Il_850nm" || _Parameter == "MPO_Il_1310nm" || _Parameter == "MPO_Refl_850nm" || _Parameter == "MPO_Refl_1310nm")  //JDS数据
          {
              if (_Parameter == "MPO_Il_850nm" || _Parameter == "MPO_Refl_850nm")
              {
                  Maticsoft.DAL.User_JDS_Test_Good ujs = new User_JDS_Test_Good();
                  return ujs.Get_MPO_SPC("850nm", _date);
              }
              else
              {
                  Maticsoft.DAL.User_JDS_Test_Good ujs = new User_JDS_Test_Good();
                  return ujs.Get_MPO_SPC("1310nm", _date);
              }
          }

          //MPO_3D数据 APC
          else if (_Parameter == "MPO_YEndFaceAngle_APC")
          {
              _Parameter = "YEndFaceAngle";
              Maticsoft.DAL.MultiFiber _MultiFiber = new MultiFiber();
              return _MultiFiber.GetList(_Parameter, _date, "8"); //APC
          }
          // MPO_3D 数据
          else
          {
              _Parameter = Get_Parameter(_Parameter);
              Maticsoft.DAL.MultiFiber _MultiFiber = new MultiFiber();
              return _MultiFiber.GetList(_Parameter, _date, "0"); //PC
          }
          
      }

      //设置模板
      private void SetTempoler(Excel.Application xlApp, string _Parameter)
      {
          Maticsoft.Model.SPC_Config _TemConfig = new Model.SPC_Config();
          _TemConfig = Get_Config(_Parameter);

          xlApp.Cells[4, 3] = _TemConfig.Trad_Name;        //制品名
          xlApp.Cells[6, 3] = _TemConfig.Parameter;  //管制项目
          xlApp.Cells[7, 3] = _TemConfig.Units;        //测量单位
          xlApp.Cells[5, 11] = _TemConfig.Upper_Limit_USL;     //上限USL
          xlApp.Cells[6, 11] = _TemConfig.Center_Limit_USL;        //中心限CL
          xlApp.Cells[7, 11] = _TemConfig.Lower_Limit_USL;    //下限LSL
          xlApp.Cells[4, 23] = _TemConfig.Department;    //制造部门
          xlApp.Cells[6, 23] = _TemConfig.MachineName;    //机别
          xlApp.Cells[7, 23] = _TemConfig.OP_Name;    //测定者                  
          xlApp.Cells[6, 29] = _TemConfig.SamplingMethod;      //抽样方法

          #region Config
          /*
          xlApp.Cells[4, 3] = "3D";        //制品名
          xlApp.Cells[6, 3] = _Parameter;  //管制项目
          xlApp.Cells[7, 3] = "°";  //测量单位

          xlApp.Cells[5, 11] = "0.20";  //上限USL
          xlApp.Cells[6, 11] = "0";    //中心限CL
          xlApp.Cells[7, 11] = "-0.20";    //下限LSL

          xlApp.Cells[4, 23] = "制六部";    //制造部门
          xlApp.Cells[6, 23] = "MPO_3D";    //机别
          xlApp.Cells[7, 23] = "魏秀华";    //测定者

          xlApp.Cells[4, 29] = "制六部";    //时间
          xlApp.Cells[6, 29] = "随机";    //抽样方法
          xlApp.Cells[7, 29] = "制六部";    //日期
           
          switch (_Parameter)
          {
              case "XEndFaceAngle":
                  {
                      xlApp.Cells[4, 3] = "3D";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "°";        //测量单位
                      xlApp.Cells[5, 11] = "0.20";     //上限USL
                      xlApp.Cells[6, 11] = "0";        //中心限CL
                      xlApp.Cells[7, 11] = "-0.20";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "YEndFaceAngle_APC":
                  {
                      xlApp.Cells[4, 3] = "3D";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "°";        //测量单位
                      xlApp.Cells[5, 11] = "8.20";     //上限USL
                      xlApp.Cells[6, 11] = "8";        //中心限CL
                      xlApp.Cells[7, 11] = "7.8";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "YEndFaceAngle":
                  {
                      xlApp.Cells[4, 3] = "3D";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "°";        //测量单位
                      xlApp.Cells[5, 11] = "0.20";     //上限USL
                      xlApp.Cells[6, 11] = "0";        //中心限CL
                      xlApp.Cells[7, 11] = "-0.20";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "MaxFibDiffAdjH":
                  {
                      xlApp.Cells[4, 3] = "3D";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "um";        //测量单位
                      xlApp.Cells[5, 11] = "0.30";     //上限USL
                      xlApp.Cells[6, 11] = "-";        //中心限CL
                      xlApp.Cells[7, 11] = "0";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "ROC_X":
                  {
                      xlApp.Cells[4, 3] = "3D";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "mm";        //测量单位
                      xlApp.Cells[5, 11] = "-";     //上限USL
                      xlApp.Cells[6, 11] = "-";        //中心限CL
                      xlApp.Cells[7, 11] = "2000";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "ROC_Y":
                  {
                      xlApp.Cells[4, 3] = "3D";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "mm";        //测量单位
                      xlApp.Cells[5, 11] = "-";     //上限USL
                      xlApp.Cells[6, 11] = "-";        //中心限CL
                      xlApp.Cells[7, 11] = "5";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "Il_A_850nm":
                  {
                      xlApp.Cells[4, 3] = "EXFO";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "dB";        //测量单位
                      xlApp.Cells[5, 11] = "0.7";     //上限USL
                      xlApp.Cells[6, 11] = "-";        //中心限CL
                      xlApp.Cells[7, 11] = "0";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "Il_A_1310nm":
                  {
                      xlApp.Cells[4, 3] = "EXFO";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "dB";        //测量单位
                      xlApp.Cells[5, 11] = "0.70";     //上限USL
                      xlApp.Cells[6, 11] = "-";        //中心限CL
                      xlApp.Cells[7, 11] = "0";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "Refl_A_850nm":
                  {
                      xlApp.Cells[4, 3] = "EXFO";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "nm";        //测量单位
                      xlApp.Cells[5, 11] = "-25";     //上限USL
                      xlApp.Cells[6, 11] = "-";        //中心限CL
                      xlApp.Cells[7, 11] = "-";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }
              case "Refl_A_1310nm":
                  {
                      xlApp.Cells[4, 3] = "EXFO";        //制品名
                      xlApp.Cells[6, 3] = _Parameter;  //管制项目
                      xlApp.Cells[7, 3] = "nm";        //测量单位
                      xlApp.Cells[5, 11] = "-25";     //上限USL
                      xlApp.Cells[6, 11] = "-";        //中心限CL
                      xlApp.Cells[7, 11] = "-";    //下限LSL
                      xlApp.Cells[4, 23] = "制六部";    //制造部门
                      xlApp.Cells[6, 23] = "MPO_3D";    //机别
                      xlApp.Cells[7, 23] = "魏秀华";    //测定者                  
                      xlApp.Cells[6, 29] = "随机";      //抽样方法
                      break;
                  }           
          }
          return null;
           */
          #endregion
      }


      /// <summary>
      /// 获取配置文件的值
      /// </summary>
      /// <param name="_Parameter"></param>
      /// <returns></returns>
      private Maticsoft.Model.SPC_Config Get_Config(string _Parameter)
      {
          XmlDocument _xml = new XmlDocument();
          XmlReaderSettings settings = new XmlReaderSettings();
          settings.IgnoreComments = true;//忽略文档里面的注释
          XmlReader reader = XmlReader.Create("D:\\模板\\SPC_Config.xml ", settings);
          _xml.Load(reader);

          //得到根节点
          XmlNode xn = _xml.SelectSingleNode("SPC_Config");
          XmlNodeList xnl = xn.ChildNodes;

          Maticsoft.Model.SPC_Config _TemConfig = new Maticsoft.Model.SPC_Config();

          foreach (XmlNode xn1 in xnl)
          {
              Maticsoft.Model.SPC_Config spc = new Maticsoft.Model.SPC_Config();
              // 将节点转换为元素，便于得到节点的属性值
              XmlElement xe = (XmlElement)xn1;
              // 得到Type和ISBN两个属性的属性值
              spc.Name = xe.GetAttribute("Name").ToString();
              // 得到Book节点的所有子节点
              XmlNodeList xnl0 = xe.ChildNodes;
              spc.Trad_Name = xnl0.Item(0).InnerText;
              spc.Parameter = xnl0.Item(1).InnerText;

              spc.Upper_Limit_USL = xnl0.Item(2).InnerText;
              spc.Center_Limit_USL = xnl0.Item(3).InnerText;
              spc.Lower_Limit_USL = xnl0.Item(4).InnerText;

              spc.Units = xnl0.Item(5).InnerText; 
              spc.Department = xnl0.Item(6).InnerText;
              spc.MachineName = xnl0.Item(7).InnerText;
              spc.OP_Name = xnl0.Item(8).InnerText;
              spc.SamplingMethod = xnl0.Item(9).InnerText;

              if (spc.Name == _Parameter)
              {
                  _TemConfig = spc;
              }
          }

          return _TemConfig;
      }

      /// <summary>
      /// 返回可供调用的参数
      /// </summary>
      private string Get_Parameter(string Old_Parametrt)
      {          
          switch (Old_Parametrt)
          {
              case "APC_Curvature": return "Curvature";
              case "APC_Spherucak": return "Spherical";
              case "APC_Offset": return "Apex_Offset";
              case "APC_Angle": return "Tilt_Angle";
              case "PC_Curvature": return "Curvature";
              case "PC_Spherucak": return "Spherical";
              case "PC_Offset": return "Apex_Offset";
              case "PC_Angle": return "Tilt_Angle";
              case "IL_1310nm": return "Il_A";
              case "IL_1550nm": return "Il_A";
              case "IL_850nm": return "Il_A";
              case "IL_1300nm": return "Il_A";
              case "RL_1310nm": return "Refl_A";
              case "RL_1550nm": return "Refl_A";
              case "RL_850nm": return "Refl_A";
              case "RL_1300nm": return "Refl_A";
              case "MPO_XEndFaceAngle": return "XEndFaceAngle";
              case "MPO_YEndFaceAngle_APC": return "YEndFaceAngle";
              case "MPO_YEndFaceAngle": return "YEndFaceAngle";
              case "MPO_MaxFibDiffAdjH": return "MaxFibDiffAdjH";
              case "MPO_ROC_X": return "ROC_X";
              case "MPO_ROC_Y": return "ROC_Y";
              case "MPO_Il_850nm": return "Il_A";
              case "MPO_Il_1310nm": return "Il_A";
              case "MPO_Refl_850nm": return "Refl_A";
              case "MPO_Refl_1310nm": return "Refl_A";
              case "Adapter_Test": return "IL";
              case "Adapter_Testfour0": return "Testfour0";
              case "Adapter_Testfour90": return "Testfour90";
              case "Adapter_Testfour180": return "Testfour180";
              case "Adapter_Testfour270": return "Testfour270";
              default: return "";
          }

      }
    }
}
