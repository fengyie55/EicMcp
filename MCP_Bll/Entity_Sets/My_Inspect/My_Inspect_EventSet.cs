using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    /// <summary>
    /// My_Inspect的分体类 对事件赋值
    /// </summary>
    public partial class My_Inspect
    {
        //
        private Maticsoft.BLL.User_3D_Test_Good _M_User_3D = new Maticsoft.BLL.User_3D_Test_Good();
        private Maticsoft.BLL.User_JDS_Test_Good _M_User_Exfo = new Maticsoft.BLL.User_JDS_Test_Good();
        //
        private Maticsoft.BLL.Pack_3D _M_Pack_3D = new Maticsoft.BLL.Pack_3D();
        private Maticsoft.BLL.Pack_Exfo _M_Pack_Exfo = new Maticsoft.BLL.Pack_Exfo();

        /// <summary>
        /// 设置事件
        /// </summary>
        /// <param name="_InspectMethod"></param>
        private void EventSet(Maticsoft.Model.E_InspectMethod _InspectMethod, Maticsoft.Model.E_InspectType _InspectType)
        {
            //-------------------------------------------------------------------------------------------------------
            // 名称：事件赋值
            // 功能：检测不是配组类型的线材
            //--------------------------------------------------------------------------------------------------------
            if (_InspectMethod == Model.E_InspectMethod.配组_二十四芯||
                _InspectMethod == Model.E_InspectMethod.配组_四十八芯 ||
                _InspectMethod == Model.E_InspectMethod.配组_九十六芯
                )
            {

                Event_Inspect += InspectMethod_Two;
                if (_InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.Getdata_Method_Multicore;
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.Getdata_Method_Multicore;
                    //
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack2;
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测3D)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.Getdata_Method_Multicore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack2;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
                {
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.Getdata_Method_Multicore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
            }

            //-------------------------------------------------------------------------------------------------------
            // 名称：事件赋值
            // 功能：检测不是配组类型的线材
            //--------------------------------------------------------------------------------------------------------
            else if (_InspectMethod == Maticsoft.Model.E_InspectMethod.双并检测 ||
                _InspectMethod == Model.E_InspectMethod.一码一签_跳线||
                _InspectMethod == Model.E_InspectMethod.四芯检测||
                _InspectMethod == Model.E_InspectMethod.十二芯检测 ||                
                _InspectMethod == Model.E_InspectMethod.二十四芯检测||
                _InspectMethod == Model.E_InspectMethod.四十八芯检测 ||
                _InspectMethod == Model.E_InspectMethod.八芯检测||
                _InspectMethod == Model.E_InspectMethod.FFOS32_三十二芯双头 ||
                _InspectMethod == Model.E_InspectMethod.FFOS_四芯||
                _InspectMethod == Model.E_InspectMethod.FFOS_十六芯||
                _InspectMethod == Model.E_InspectMethod.FFOS_三十二芯||
                _InspectMethod == Model.E_InspectMethod.FFOS_二十四芯||
                _InspectMethod == Model.E_InspectMethod.FFOS_八芯
                )
            {
                 Event_Inspect += InspectMothod_One;   //检测方法
                if (_InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.Getdata_Method_TwainCore;
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.Getdata_Method_TwainCore;
                    //
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测3D)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.Getdata_Method_TwainCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
                {
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.Getdata_Method_TwainCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
            }
            //-------------------------------------------------------------------------------------------------------
            // 名称：事件赋值
            // 功能：MPO检测
            //--------------------------------------------------------------------------------------------------------
            else if (_InspectMethod == Model.E_InspectMethod.MPO检测)                  
            {
                MultiFiber _M_Multifiber = new MultiFiber();
                Event_Inspect += InspectMothod_One;   //检测方法
                if (_InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
                {
                    _GLL_TestData.GetData_3D += _M_Multifiber.Getdata_Method_MPO;
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_MPO;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //
                        //_GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测3D)
                {
                    _GLL_TestData.GetData_3D += _M_Multifiber.Getdata_Method_MPO;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        // _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
                {
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_MPO;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
            }
            //-------------------------------------------------------------------------------------------------------
            // 名称：事件赋值
            // 功能：检测
            //--------------------------------------------------------------------------------------------------------
            else if (_InspectMethod == Model.E_InspectMethod.配组_八芯_SAMHALL
                || _InspectMethod == Model.E_InspectMethod.配组_二十四芯_SAMHALL 
                || _InspectMethod == Model.E_InspectMethod.配组_四十八芯_SAMHALL
                || _InspectMethod == Model.E_InspectMethod.配组_九十六芯_SAMHALL)
            {
                Event_Inspect += InspectMethod_Three;
                if (_InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.GetData_Method_OneCore;
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_Method_OneCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack3;
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测3D)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.GetData_Method_OneCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack3;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
                {
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_Method_OneCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
            }
            //-------------------------------------------------------------------------------------------------------
            // 名称：事件赋值
            // 功能：检测12芯*2
            //--------------------------------------------------------------------------------------------------------
            else if (_InspectMethod == Model.E_InspectMethod.TFK十二芯检测x2 ||
                 _InspectMethod == Model.E_InspectMethod.TFK二十四芯检测x2 ||
                 _InspectMethod == Model.E_InspectMethod.TFK一芯检测x2)
            {
                Event_Inspect += InspectMothod_four;   //检测方法
                if (_InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.Getdata_Method_twentyFour;
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_Method_OneCore_TFK;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测3D)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.Getdata_Method_twentyFour;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
                {
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.Getdata_Method_TwainCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }

            }
            //-------------------------------------------------------------------------------------------------------
            // 名称：事件赋值
            // 功能：检测不是配组类型的线材
            //--------------------------------------------------------------------------------------------------------
            else if (_InspectMethod == Model.E_InspectMethod.一码一签) //_InspectMethod == Model.E_InspectMethod.两码一签 ||
            {            
                Event_Inspect += InspectMothod_One;   //检测方法
                if (_InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.GetData_Method_OneCore;
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_Method_OneCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测3D)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.GetData_Method_OneCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
                {
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_Method_OneCore;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack;
                    }
                }

            }
            else if (_InspectMethod == Model.E_InspectMethod.两码两签)
            {
                Event_Inspect += InspectMethod_TwoSnTwoLab;   //检测方法
                if (_InspectType == Maticsoft.Model.E_InspectType.检测3D与Exfo)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.GetData_Method_TwoSnToLab;
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_Method_TwoSnToLab;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        //
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack_TwoSnTwoLab;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测3D)
                {
                    _GLL_TestData.GetData_3D += _M_User_3D.GetData_Method_TwoSnToLab;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_3D += _M_Pack_3D.Add_Pack;
                    }
                }
                else if (_InspectType == Maticsoft.Model.E_InspectType.检测Exfo)
                {
                    _GLL_TestData.GetData_Exfo += _M_User_Exfo.GetData_Method_TwoSnToLab;
                    if (IsUpdate)  //检测是否启用更新
                    {
                        _GLL_TestData.UpData_Exfo += _M_Pack_Exfo.Add_Pack_TwoSnTwoLab;
                    }
                }
            }
        }

    }
}
