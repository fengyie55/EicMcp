using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
    public enum E_Order_State
    {
        /// <summary>
        /// 未完工
        /// </summary>
        Not_ComPlete = 0,

        /// <summary>
        /// 已完工
        /// </summary>
        Yet_ComPlete = 1,
    }

    /// <summary>
    /// 条码类型
    /// </summary>
    public enum E_SerialNumber_Type
    {
        PigtailSN = 0,
        ClientSN = 1,
        SackSN = 2,
        BoxSN = 3,
    }

    /// <summary>
    /// 条码状态
    /// </summary>
    public enum E_Barcode_State
    {
        Not_Pack = 0,   
        Yet_Pack = 1,       
        Not_Encasement = 2,
        Yet_Encasement = 3,
        Not_Print =4,
        Yet_Print =5,
    }
}
