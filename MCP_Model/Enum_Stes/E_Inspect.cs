using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    /// <summary>
    /// 检测结果
    /// </summary>
    public enum E_InspectResult
    {
        PASS = 0,
        FALL = 1,
    }
    /// <summary>
    /// 检测类型
    /// </summary>
    public enum E_InspectType
    {
        检测3D与Exfo,
        检测3D,
        检测Exfo
    }
    /// <summary>
    /// 检测方法
    /// </summary>
    public enum E_InspectMethod
    {
        一码一签,
        一码一签_跳线,
        两码两签,
        双并检测,       
        FFOS_四芯,        
        FFOS_八芯,       
        FFOS_十六芯,       
        FFOS_二十四芯,
        FFOS_三十二芯,
        FFOS32_三十二芯双头,
        配组_八芯_SAMHALL,
        配组_九十六芯_SAMHALL,
        配组_二十四芯_SAMHALL,
        配组_四十八芯_SAMHALL,
        配组_二十四芯,
        配组_四十八芯,
        配组_九十六芯,
        四芯检测,            
        八芯检测,
        十二芯检测,     
        二十四芯检测,
        四十八芯检测, 
        TFK十二芯检测x2,
        TFK二十四芯检测x2, 
        TFK一芯检测x2,
        MPO检测
    }
    /// <summary>
    /// 导出报告类型
    /// </summary>
    public enum E_ReportType
    {
        Exfo,
        PhysicalProperty
    }
    /// <summary>
    /// Pigtail接头类型
    /// </summary>
    public enum E_PigtailType
    {       
        PC,
        APC,
        _Null,
    }
    /// <summary>
    /// 数据库列表
    /// </summary>
    public enum E_ConnectionList
    {
        ToLine,
        IQ12001B,
        TotalScanSQLDB,
        LightMaster,
        EquipmentMS
    }    
    /// <summary>
    /// SPC参数列表
    /// </summary>
    public enum E_Generate
    {
        APC_Curvature,
        APC_Spherucak,
        APC_Offset,
        APC_Angle,
        PC_Curvature,
        PC_Spherucak,
        PC_Offset,          
        IL_1310nm,
        IL_1550nm,
        IL_850nm,
        IL_1300nm,
        RL_1310nm,
        RL_1550nm,
        RL_850nm,
        RL_1300nm,     
        MPO_XEndFaceAngle,
        MPO_YEndFaceAngle_APC,
        MPO_YEndFaceAngle,
        MPO_MaxFibDiffAdjH,
        MPO_ROC_X,
        MPO_ROC_Y,   
        MPO_Il_850nm,
        MPO_Il_1310nm, 
        MPO_Refl_850nm,
        MPO_Refl_1310nm,
        Adapter_Test,
        Adapter_Testfour0,
        Adapter_Testfour90,
        Adapter_Testfour180,
        Adapter_Testfour270             
    }

  //-----------END  
}
