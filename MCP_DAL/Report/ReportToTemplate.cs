using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.DAL
{
    class ReportToTemplate
    {
        readonly string _OrderID, _PatchNo, _TemPlate, _SavePatch;

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="OrderID">工单</param>
        /// <param name="PacthNo">批号</param>
        /// <param name="Template">模板</param>
        /// <param name="SavePath">导出路径</param>
        public ReportToTemplate(string OrderID, string PacthNo, string Template, string SavePath)
        {
            this._OrderID = OrderID;
            this._PatchNo = PacthNo;
            this._SavePatch = SavePath;
            this._TemPlate = Template;
            this._SavePatch = SavePath;
        }

        private bool OptionType(string PatchNo)
        {
            bool temReturn = false;
            switch (PatchNo)
            {
                case "":
                    break;
                default :
                    temReturn = false;
                    break;
            }
            return temReturn;
        }

    }
}
