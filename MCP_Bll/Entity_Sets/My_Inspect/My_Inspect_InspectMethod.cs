using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace Maticsoft.BLL
{
    /// <summary>
    /// My_Inspect的分体类 检测方法
    /// </summary>
    public partial class My_Inspect
    {
        Maticsoft.Model.SerialNumber _GLL_SerialNumber = new Maticsoft.Model.SerialNumber();   //条码实体类     
        Maticsoft.BLL.SerialNumber _M_SerialNumber = new Maticsoft.BLL.SerialNumber();         //条码操作类 

    
        #region 无需配组线材检测
        /// <summary>
        /// 名称： 检测方法一
        /// 功能： 检测不需要配组的条码 
        /// </summary>
        /// <param name="e"></param>
        private void InspectMothod_One(InspectEventArgs e)
        {
            try
            {
                ResultEventArgs _Result = new ResultEventArgs();                                   //定义结果返回类 
                _Result.ErrorList = "";                                                            //异常列表 归零            
                _GLL_SerialNumber = _M_SerialNumber.GetModel(e.SN);                                //获取条码 实体 

                if (_GLL_SerialNumber == null || _GLL_SerialNumber.OrderID != _GLL_WorkOrder.OrderID || _GLL_SerialNumber.Type != Maticsoft.Model.E_SerialNumber_Type.ClientSN.ToString())//判断是否属于此工单
                {
                    _Result.ErrorList += "此条码：" + e.SN + "  不属于此工单：" + _GLL_WorkOrder.OrderID + "";
                }
                else if (_GLL_SerialNumber.State != Maticsoft.Model.E_Barcode_State.Not_Pack.ToString()) //判断是否已经包装
                {
                    _Result.ErrorList += "此条码：" + _GLL_SerialNumber.SN + "  已包装或已打印！包装批号：" + _GLL_SerialNumber.BatchNO + "";
                }
                else
                {
                    if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo) { Inspect_One_Inspect_3D(e, _Result); Inspect_One_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo) { _Result.Result_3D = true; Inspect_One_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D) { _Result.Result_Exfo = true; Inspect_One_Inspect_3D(e, _Result); }

                    //设置配组 为未完成 因为不需要进行配组
                    _Result.Combination = false;
                }
                e.InspectResult = _Result;
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }

        private void Inspect_One_Inspect_Exfo(InspectEventArgs e, ResultEventArgs _Result)
        {
            //检测-Exfo
            string temWhere_Exfo = _M_User_Exfo.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_Exfo_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_Exfo, e.SN);
            _Result.Data_Exfo = _GLL_TestData.Start_GetData_Exfo(GetData_Exfo_e);
            ArrayList Inspect_Exfo = isEqual(_GLL_Standard_PigtailList, GetData_Exfo_e.PigtailList);
            if (Inspect_Exfo.Count > 0)
            {
                _Result.Fill_Exfo = ArrayListToString(Inspect_Exfo);
                _Result.Result_Exfo = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_Exfo_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_Exfo_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.SN);
                _GLL_TestData.Start_UpData_Exfo(UpData_Exfo_e);
                _Result.Result_Exfo = true;

                //判断3D是否OK 进行添加打印数据
                if (_Result.Result_3D)
                {
                    //如果需要打印标签
                    if (My_Print.IsPrint)
                    {
                        //添加打印数据
                        My_Print.Add_PrintData(_M_Pack_Exfo.GetList("ClientSN='" + e.SN + "' AND (Wave = '1550nm')"));
                    }
                }
            }
        }

        private void Inspect_One_Inspect_3D(InspectEventArgs e, ResultEventArgs _Result)
        {
            //检测-3D
            string temWhere_3D = _M_User_3D.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_3D_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_3D, e.SN);
            _Result.Data_3D = _GLL_TestData.Start_GetData_3D(GetData_3D_e);
            ArrayList Inspect_3D = isEqual(_GLL_Standard_PigtailList, GetData_3D_e.PigtailList);
            if (Inspect_3D.Count > 0)
            {
                _Result.Fill_3D = ArrayListToString(Inspect_3D);
                _Result.Result_3D = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_3D_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_3D_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.SN);
                _GLL_TestData.Start_UpData_3D(UpData_3D_e);
                _Result.Result_3D = true;
            }
        }
        #endregion


        #region 配组线材检测
        /// <summary>
        ///  名称：检测方法二
        ///  功能：检测配组线材
        /// </summary>
        /// <param name="e"></param>
        private void InspectMethod_Two(InspectEventArgs e)
        {
            try
            {
                ResultEventArgs _Result = new ResultEventArgs();                                   //定义结果返回类 
                _Result.ErrorList = "";                                                            //异常列表 归零            
                _GLL_SerialNumber = _M_SerialNumber.GetModel(e.SN);                                //获取条码 实体 

                if (_GLL_SerialNumber == null || _GLL_SerialNumber.OrderID != _GLL_WorkOrder.OrderID || _GLL_SerialNumber.Type != Maticsoft.Model.E_SerialNumber_Type.PigtailSN.ToString())//判断是否属于此工单
                {
                    _Result.ErrorList += "此条码：" + e.SN + "  不属于此工单：" + _GLL_WorkOrder.OrderID + "";
                }
                else if (_GLL_SerialNumber.State != Maticsoft.Model.E_Barcode_State.Not_Pack.ToString()) //判断是否已经包装
                {
                    _Result.ErrorList += "此条码：" + _GLL_SerialNumber.SN + "  已包装或已打印！包装批号：" + _GLL_SerialNumber.BatchNO + "";
                }
                else
                {
                    //验证线号是否已经存在  
                    string PigtailNum = "";
                    if (e.SN.Length >= 13) { PigtailNum = e.SN.Substring(11, 2); }                       //获取线号                            
                    ArrayList YetPack_PigtailNum_List = _M_Pack_3D.Get_ClientSN_PigtailNum(e.ClientSN);   //获取已包装线号

                    //判断此线号是否已经包装
                    bool Cli_IN_Name = false;
                    if (IsUpdate)
                    {
                        Cli_IN_Name = YetPack_PigtailNum_List.Contains(PigtailNum);
                    }
                    if (Cli_IN_Name)
                    {
                        _Result.ErrorList += "客户编码：" + e.ClientSN + "  已存在此线号：" + PigtailNum + " ";
                    }
                    else
                    {
                        if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo) { Inspect_Two_Inspect_3D(e, _Result); Inspect_Two_Inspect_Exfo(e, _Result); }
                        else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo) { _Result.Result_3D = true; Inspect_Two_Inspect_Exfo(e, _Result); }
                        else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D) { _Result.Result_Exfo = true; Inspect_Two_Inspect_3D(e, _Result); }
                    }
                    //再次获取已包装线号 并与标准 客户编码数组进行比较
                    YetPack_PigtailNum_List = _M_Pack_3D.Get_ClientSN_PigtailNum(e.ClientSN);   //获取已包装线号
                    ArrayList Inspect_ClientNum = isEqual(_GLL_Standard_ClientList, YetPack_PigtailNum_List);
                    if (Inspect_ClientNum.Count > 0)
                    {
                        //设置配组 为未完成 因为不需要进行配组
                        _Result.Combination = false;
                        string temClientNum = ArrayListToString(Inspect_ClientNum);
                        _Result.Not_ClientSN_Name = temClientNum;
                    }
                    else
                    {
                        //设置配组 为已完成 因为不需要进行配组
                        _Result.Combination = true;
                        Maticsoft.Model.SerialNumber _TemClient = new Model.SerialNumber();
                        _TemClient = _M_SerialNumber.GetModel(e.ClientSN);
                        _TemClient.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _TemClient.BatchNO = _GLL_PackBatch.BatchNo;
                        _M_SerialNumber.Update(_TemClient);

                        _Result.Not_ClientSN_Name = ArrayListToString(_GLL_Standard_ClientList);
                    }
                }
                e.InspectResult = _Result;
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }

        private void Inspect_Two_Inspect_Exfo(InspectEventArgs e, ResultEventArgs _Result)
        {
            //检测-Exfo
            string temWhere_Exfo = _M_User_Exfo.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_Exfo_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_Exfo, e.ClientSN);
            _Result.Data_Exfo = _GLL_TestData.Start_GetData_Exfo(GetData_Exfo_e);
            ArrayList Inspect_Exfo = isEqual(_GLL_Standard_PigtailList, GetData_Exfo_e.PigtailList);
            if (Inspect_Exfo.Count > 0)
            {
                _Result.Fill_Exfo = ArrayListToString(Inspect_Exfo);
                _Result.Result_Exfo = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_Exfo_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_Exfo_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.ClientSN);
                _GLL_TestData.Start_UpData_Exfo(UpData_Exfo_e);
                _Result.Result_Exfo = true;

            }
        }

        private void Inspect_Two_Inspect_3D(InspectEventArgs e, ResultEventArgs _Result)
        {
            //检测-3D
            string temWhere_3D = _M_User_3D.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_3D_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_3D, e.SN);
            _Result.Data_3D = _GLL_TestData.Start_GetData_3D(GetData_3D_e);
            ArrayList Inspect_3D = isEqual(_GLL_Standard_PigtailList, GetData_3D_e.PigtailList);
            if (Inspect_3D.Count > 0)
            {
                _Result.Fill_3D = ArrayListToString(Inspect_3D);
                _Result.Result_3D = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_3D_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_3D_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.ClientSN);
                _GLL_TestData.Start_UpData_3D(UpData_3D_e);
                _Result.Result_3D = true;
            }
        }
        #endregion


        #region 特殊 8芯检测
        /// <summary>
        ///  名称：检测方法三
        ///  功能：特殊-8芯配组检测
        /// </summary>
        /// <param name="e"></param>
        private void InspectMethod_Three(InspectEventArgs e)
        {
            try
            {
                ResultEventArgs _Result = new ResultEventArgs();                                   //定义结果返回类 
                _Result.ErrorList = "";                                                            //异常列表 归零            
                _GLL_SerialNumber = _M_SerialNumber.GetModel(e.SN);                                //获取条码 实体 

                if (_GLL_SerialNumber == null || _GLL_SerialNumber.OrderID != _GLL_WorkOrder.OrderID || _GLL_SerialNumber.Type != Maticsoft.Model.E_SerialNumber_Type.PigtailSN.ToString())//判断是否属于此工单
                {
                    _Result.ErrorList += "此条码：" + e.SN + "  不属于此工单：" + _GLL_WorkOrder.OrderID + "";
                }
                else if (_GLL_SerialNumber.State != Maticsoft.Model.E_Barcode_State.Not_Pack.ToString()) //判断是否已经包装
                {
                    _Result.ErrorList += "此条码：" + _GLL_SerialNumber.SN + "  已包装或已打印！包装批号：" + _GLL_SerialNumber.BatchNO + "";
                }
                else
                {
                    if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo) { Inspect_Three_Inspect_3D(e, _Result); Inspect_Three_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo) { _Result.Result_3D = true; Inspect_Three_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D) { _Result.Result_Exfo = true; Inspect_Three_Inspect_3D(e, _Result); }


                    //--------------------------------------------------检测配组是否完成
                    ArrayList YetPack_PigtailNum_List = _M_Pack_3D.Get_ClientSN_PigtailNum(e.ClientSN, "8芯配组");   //获取已包装线号
                    ArrayList Inspect_ClientNum = isEqual(_GLL_Standard_ClientList, YetPack_PigtailNum_List);
                    if (Inspect_ClientNum.Count > 0)
                    {
                        //设置配组 为未完成 
                        _Result.Combination = false;
                        string temClientNum = ArrayListToString(Inspect_ClientNum);
                        _Result.Not_ClientSN_Name = temClientNum;
                    }
                    else
                    {
                        //设置配组 为已完成 
                        _Result.Combination = true;
                        Maticsoft.Model.SerialNumber _TemClient = new Model.SerialNumber();
                        _TemClient = _M_SerialNumber.GetModel(e.ClientSN);
                        _TemClient.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _TemClient.BatchNO = _GLL_PackBatch.BatchNo;
                        _M_SerialNumber.Update(_TemClient);

                        _Result.Not_ClientSN_Name = ArrayListToString(_GLL_Standard_ClientList);
                    }
                }
                e.InspectResult = _Result;
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }

        private void Inspect_Three_Inspect_Exfo(InspectEventArgs e, ResultEventArgs _Result)
        {
            //------------------------------------------------检测-Exfo
            string temWhere_Exfo = _M_User_Exfo.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_Exfo_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_Exfo, e.ClientSN);
            _Result.Data_Exfo = _GLL_TestData.Start_GetData_Exfo(GetData_Exfo_e);
            ArrayList Inspect_Exfo = isEqual(_GLL_Standard_PigtailList, GetData_Exfo_e.PigtailList);
            if (Inspect_Exfo.Count > 0)
            {
                _Result.Fill_Exfo = ArrayListToString(Inspect_Exfo);
                _Result.Result_Exfo = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_Exfo_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_Exfo_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.SN);
                _GLL_TestData.Start_UpData_Exfo(UpData_Exfo_e);
                _Result.Result_Exfo = true;
            }
        }

        private void Inspect_Three_Inspect_3D(InspectEventArgs e, ResultEventArgs _Result)
        {
            //------------------------------------------------检测-3D
            string temWhere_3D = _M_User_3D.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_3D_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_3D, e.SN);
            _Result.Data_3D = _GLL_TestData.Start_GetData_3D(GetData_3D_e);
            ArrayList Inspect_3D = isEqual(_GLL_Standard_PigtailList, GetData_3D_e.PigtailList);
            if (Inspect_3D.Count > 0)
            {
                _Result.Fill_3D = ArrayListToString(Inspect_3D);
                _Result.Result_3D = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_3D_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_3D_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.ClientSN);
                _GLL_TestData.Start_UpData_3D(UpData_3D_e);
                _Result.Result_3D = true;
            }
        }
        #endregion


        #region TFK12芯X2检测
        /// <summary>
        /// 名称: 检测方法四
        /// 功能: 检测TFK12芯X2 线材
        /// </summary>
        /// <param name="e"></param>
        private void InspectMothod_four(InspectEventArgs e)
        {
            try
            {
                ResultEventArgs _Result = new ResultEventArgs();                                   //定义结果返回类 
                _Result.ErrorList = "";                                                            //异常列表 归零            
                _GLL_SerialNumber = _M_SerialNumber.GetModel(e.SN);                                //获取条码 实体 

                if (_GLL_SerialNumber == null || _GLL_SerialNumber.OrderID != _GLL_WorkOrder.OrderID || _GLL_SerialNumber.Type != Maticsoft.Model.E_SerialNumber_Type.ClientSN.ToString())//判断是否属于此工单
                {
                    _Result.ErrorList += "此条码：" + e.SN + "  不属于此工单：" + _GLL_WorkOrder.OrderID + "";
                }
                else if (_GLL_SerialNumber.State != Maticsoft.Model.E_Barcode_State.Not_Pack.ToString()) //判断是否已经包装
                {
                    _Result.ErrorList += "此条码：" + _GLL_SerialNumber.SN + "  已包装或已打印！包装批号：" + _GLL_SerialNumber.BatchNO + "";
                }
                else
                {
                    if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo) { Inspect_four_Inspect_3D(e, _Result); Inspect_four_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo) { _Result.Result_3D = true; Inspect_four_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D) { _Result.Result_Exfo = true; Inspect_four_Inspect_3D(e, _Result); }

                    //设置配组 为未完成 因为不需要进行配组
                    _Result.Combination = false;
                }
                e.InspectResult = _Result;
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }         

        private void Inspect_four_Inspect_Exfo(InspectEventArgs e, ResultEventArgs _Result)
        {
            //检测-Exfo
            string temWhere_Exfo = _M_User_Exfo.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_Exfo_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_Exfo, e.SN);
            _Result.Data_Exfo = _GLL_TestData.Start_GetData_Exfo(GetData_Exfo_e);
            ArrayList Inspect_Exfo = isEqual(_GLL_Standard_PigtailList, GetData_Exfo_e.PigtailList);
            if (Inspect_Exfo.Count > 0)
            {
                _Result.Fill_Exfo = ArrayListToString(Inspect_Exfo);
                _Result.Result_Exfo = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_Exfo_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_Exfo_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.SN);
                _GLL_TestData.Start_UpData_Exfo(UpData_Exfo_e);
                _Result.Result_Exfo = true;

            }
        }

        private void Inspect_four_Inspect_3D(InspectEventArgs e, ResultEventArgs _Result)
        {
            //检测-3D
            string temWhere_3D = _M_User_3D.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList, e.SN);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_3D_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_3D, e.SN);
            _Result.Data_3D = _GLL_TestData.Start_GetData_3D(GetData_3D_e);
            ArrayList Inspect_3D = isEqual(_GLL_Standard_PigtailList, GetData_3D_e.PigtailList);
            if (Inspect_3D.Count > 0)
            {
                _Result.Fill_3D = ArrayListToString(Inspect_3D);
                _Result.Result_3D = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_3D_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_3D_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.SN);
                _GLL_TestData.Start_UpData_3D(UpData_3D_e);
                _Result.Result_3D = true;

                //如果需要打印标签
                if (My_Print.IsPrint)
                {
                    My_Print.IsBtPrint = true;
                    My_Print.SN = e.SN;
                    //添加打印数据
                    My_Print.Add_PrintData(_M_Pack_Exfo.GetList("ClientSN='" + e.SN + "' AND (Wave = '1550nm')"));
                }
            }
        }
        #endregion


        #region 跳线检测
        //------------------------------------------------------------------------------------------------------------------
        //  名称：检测方法四
        //  功能：跳线检测
        //
        //------------------------------------------------------------------------------------------------------------------

      
        
        /// <summary>
        ///  名称：检测方法四
        ///  功能：跳线检测
        /// </summary>
        /// <param name="e"></param>
        private void InspectMethod_TwoSnTwoLab(InspectEventArgs e)
        {
            try
            {
                Get_SN_List(e);

                ResultEventArgs _Result = new ResultEventArgs();                                   //定义结果返回类 
                _Result.ErrorList = "";                                                            //异常列表 归零            
                _GLL_SerialNumber = _M_SerialNumber.GetModel(e.SN);                                //获取条码 实体 

                if (_GLL_SerialNumber == null || _GLL_SerialNumber.OrderID != _GLL_WorkOrder.OrderID || _GLL_SerialNumber.Type != Maticsoft.Model.E_SerialNumber_Type.ClientSN.ToString())//判断是否属于此工单
                {
                    _Result.ErrorList += "此条码：" + e.SN + "  不属于此工单：" + _GLL_WorkOrder.OrderID + "";
                }
                else if (_GLL_SerialNumber.State != Maticsoft.Model.E_Barcode_State.Not_Pack.ToString()) //判断是否已经包装
                {
                    _Result.ErrorList += "此条码：" + _GLL_SerialNumber.SN + "  已包装或已打印！包装批号：" + _GLL_SerialNumber.BatchNO + "";
                }
                else
                {
                    if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo) { Inspect_TwoSnToLab_Inspect_3D(e, _Result); Inspect_TwoSnToLab_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo) { _Result.Result_3D = true; Inspect_TwoSnToLab_Inspect_Exfo(e, _Result); }
                    else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D) { _Result.Result_Exfo = true; Inspect_TwoSnToLab_Inspect_3D(e, _Result); }

                }
                e.InspectResult = _Result;
                if (IsUpdate)  //检测是否启用更新
                {
                    Up_SerialNumber(e);
                }
            }
            catch (Exception ex) { My_MessageBox.My_MessageBox_Message(ex.Message); }
        }

        /// <summary>
        /// 更新条码状态
        /// </summary>
        private void Up_SerialNumber(InspectEventArgs e)
        {            
            Maticsoft.Model.SerialNumber _serial = new Model.SerialNumber();           
            if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
            {
                if (e.InspectResult.Result_3D && e.InspectResult.Result_Exfo)
                {
                    //更新条码状态
                    foreach (string temSN in _GLL_Standard_PigtailList)
                    {
                        _serial = _M_SerialNumber.GetModel(temSN);
                        _serial.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _serial.BatchNO = _GLL_PackBatch.BatchNo.ToString();
                        _M_SerialNumber.Update(_serial);
                    }                                       
                }
            }
            else if (_GLL_WorkOrder.InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
            {
                if (e.InspectResult.Result_Exfo == true)
                {
                    //更新条码状态
                    foreach (string temSN in _GLL_Standard_PigtailList)
                    {
                        _serial = _M_SerialNumber.GetModel(temSN);
                        _serial.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _serial.BatchNO = _GLL_PackBatch.BatchNo.ToString();
                        _M_SerialNumber.Update(_serial);
                    }       
                }

            }
            else  //只检测3D
            {
                if (e.InspectResult.Result_3D == true)
                {
                    //更新条码状态
                    foreach (string temSN in _GLL_Standard_PigtailList)
                    {
                        _serial = _M_SerialNumber.GetModel(temSN);
                        _serial.State = Maticsoft.Model.E_Barcode_State.Yet_Pack.ToString();
                        _serial.BatchNO = _GLL_PackBatch.BatchNo.ToString();
                        _M_SerialNumber.Update(_serial);
                    }       
                }

            }
        }

        /// <summary>
        /// 两码两签 检测Exfo
        /// </summary>
        private void Inspect_TwoSnToLab_Inspect_Exfo(InspectEventArgs e, ResultEventArgs _Result)
        {
            //------------------------------------------------检测-Exfo
            string temWhere_Exfo = _M_User_Exfo.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_Exfo_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_Exfo, e.ClientSN);
            _Result.Data_Exfo = _GLL_TestData.Start_GetData_Exfo(GetData_Exfo_e);
            ArrayList Inspect_Exfo = isEqual(_GLL_Standard_PigtailList, GetData_Exfo_e.PigtailList);
            if (Inspect_Exfo.Count > 0)
            {
                _Result.Fill_Exfo = ArrayListToString(Inspect_Exfo);
                _Result.Result_Exfo = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_Exfo_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_Exfo_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.SN);
                _GLL_TestData.Start_UpData_Exfo(UpData_Exfo_e);
                _Result.Result_Exfo = true;

                if (_Result.Result_3D)  //如果3D为良品
                {
                    //如果需要打印标签
                    if (My_Print.IsPrint)
                    {
                        foreach (string temSN in _GLL_Standard_PigtailList)
                        {
                            //添加打印数据
                            DataSet temds = _M_Pack_Exfo.GetList("ClientSN='" + temSN + "' AND (Wave = '1550nm')");
                            My_Print.Add_PrintData(temds);
                        }
                    }
                }
            }

            //设置配组 为未完成 因为不需要进行配组
            _Result.Combination = false;
        }

        /// <summary>
        /// 两碼两签 检测3D
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_Result"></param>
        private void Inspect_TwoSnToLab_Inspect_3D(InspectEventArgs e, ResultEventArgs _Result)
        {
            //------------------------------------------------检测-3D
            string temWhere_3D = _M_User_3D.GetSql_Where(_GLL_WorkOrder, _GLL_Standard_PigtailList);
            Maticsoft.DAL.My_GetTestData.GetDataEventArgs GetData_3D_e = new Maticsoft.DAL.My_GetTestData.GetDataEventArgs(temWhere_3D, e.SN);
            _Result.Data_3D = _GLL_TestData.Start_GetData_3D(GetData_3D_e);
            ArrayList Inspect_3D = isEqual(_GLL_Standard_PigtailList, GetData_3D_e.PigtailList);
            if (Inspect_3D.Count > 0)
            {
                _Result.Fill_3D = ArrayListToString(Inspect_3D);
                _Result.Result_3D = false;
            }
            else
            {
                //更新数据
                Maticsoft.DAL.My_GetTestData.UpDataEventArgs UpData_3D_e =
                    new Maticsoft.DAL.My_GetTestData.UpDataEventArgs(GetData_3D_e.TestData, _GLL_WorkOrder, _GLL_PackBatch.BatchNo, e.ClientSN);
                _GLL_TestData.Start_UpData_3D(UpData_3D_e);
                _Result.Result_3D = true;
            }
        }

        /// <summary>
        /// 获取SN 列表  根据SN自动判断奇偶 并进行添加SN
        /// </summary>
        private void Get_SN_List(InspectEventArgs e)
        {
            ArrayList temlist = new ArrayList();
            temlist.Add(e.SN); //添加SN编码
            long temSN_One = long.Parse(e.SN);
            if (temSN_One % 2 == 0)
            {
                temlist.Add((temSN_One - 1).ToString());
            }
            else
            {
                temlist.Add((temSN_One + 1).ToString());
            }
            _GLL_Standard_PigtailList = temlist;
        }

        #endregion


        #region 共用方法

        //－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
        //  名称:共用方法
        //  功能：提供数组比较与转换为String
        //  日期：2014-02-27 13:54
        //
        //－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－

        /// <summary>
        /// 判断两个数组是否相等
        /// </summary>
        /// <param name="_Standard">标准数组</param>
        /// <param name="_User_3D_Data">Pigtail接头数组</param>
        /// <returns>Arraylist 数组 空 则表示产品为良品 Pass； 不为空则返回的数组为不良品接头 Fill</returns>    
        private ArrayList isEqual(ArrayList _standradlist, ArrayList _objectlist)  //比较标准头数的集合 与 测试数据的集合是否相等 符合则为良品 否则为不良
        {
            ArrayList _list3 = new ArrayList(_standradlist); //使用New构造函数对标准数组进行重构
            if (_objectlist != null)
            {
                for (int t = 0; t < _standradlist.Count; t++)    //用标准（集合1）中的元素与测试集合（集合2）中的每个元素进行比较
                {
                    for (int i = 0; i < _objectlist.Count; i++) //循环用集合1中的元素与集合2进行逐个比较
                    {
                        if (_standradlist[t].Equals(_objectlist[i].ToString()))  //如果相等
                        {
                            _list3.Remove(_standradlist[t]);    //移除重构标准数组中对应的元素
                            break; // 返回
                        }
                    }
                }
            }
            return _list3; //返回运算结果（数组为 0 标示产品为良品） （大于0 表示为不良品 其中的元素为不良品接头）
        }
        /// <summary>
        /// 数组转String
        /// </summary>
        /// <param name="_AList">数组</param>
        /// <returns></returns>
        private string ArrayListToString(ArrayList _AList)
        {
            string _TemAlst = "";
            foreach (string tem in _AList)
            {
                _TemAlst += " " + tem;
            }
            return _TemAlst;
        }

        /// <summary>
        /// 返回客户编码 待包装线号
        /// </summary>
        /// <param name="_ClientSN">客户编码</param>
        /// <returns></returns>
        public string Get_Client_NotPack_PigtailNum(string _ClientSN)
        {
            ArrayList YetPack_PigtailNum_List;
            if (_GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_四十八芯 ||
                _GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_九十六芯 ||
                _GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_二十四芯)
            {
                YetPack_PigtailNum_List = _M_Pack_3D.Get_ClientSN_PigtailNum(_ClientSN);   //获取已包装线号
                ArrayList Inspect_ClientNum = isEqual(_GLL_Standard_ClientList, YetPack_PigtailNum_List);
                return ArrayListToString(Inspect_ClientNum);
            }
           else if (_GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_八芯_SAMHALL
                || _GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_二十四芯_SAMHALL 
                || _GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_四十八芯_SAMHALL
                || _GLL_WorkOrder.InspectMethod == Model.E_InspectMethod.配组_九十六芯_SAMHALL)
            {
                YetPack_PigtailNum_List = _M_Pack_3D.Get_ClientSN_PigtailNum(_ClientSN, "8芯配组");   //获取已包装线号
                ArrayList Inspect_ClientNum = isEqual(_GLL_Standard_ClientList, YetPack_PigtailNum_List);
                return ArrayListToString(Inspect_ClientNum);
            }
            else
            {
                return "";
            }

        }

        #endregion
        //－－－－－－－－－ＥＮＤ
    }
}
