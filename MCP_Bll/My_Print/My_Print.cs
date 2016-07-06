using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Maticsoft.BLL
{
    public class My_Print
    {
        Maticsoft.DAL.My_Print dal = new Maticsoft.DAL.My_Print();
        public My_Print() { }
        public My_Print(string OrderID, string BatchNo)
        {
            Maticsoft.DAL.My_Print dal = new Maticsoft.DAL.My_Print(OrderID, BatchNo);
            this.dal = dal;              
        }

        //针对跳线设计
        public My_Print(Maticsoft.Model.PackBatch _packBatch)
        {
            Maticsoft.DAL.My_Print dal = new DAL.My_Print(_packBatch);
            this.dal = dal;
        }
        /// <summary>
        /// 是否启用BT打印 默认为不启用
        /// </summary>
        public bool IsBtPrint { set { dal.IsBtPrint = value; } }

        /// <summary>
        /// 获取或设置是否启用标签打印
        /// </summary>
        public bool IsPrint { get { return dal.IsPrint; } set { dal.IsPrint = value; } }
        
        /// <summary>
        /// 获取标签数量
        /// </summary>
        public int LabCount { get { return dal.LabCount; } }

        /// <summary>
        /// 标签ＳＮ编码 为Bt打印时 启用
        /// </summary>
        public string SN { get { return dal.SN; } set { dal.SN = value; } }



         /// <summary>
        ///  添加待打印数据
        /// </summary>
        public void Add_PrintData(DataSet _notprintdata)
        {
            dal.Add_PrintData(_notprintdata);
        }

        /// <summary>
        /// 重置标签 
        /// 本方法主要功能为 重置标签名称以及标签信息 主要为同一个批号存在两种标签的工单设计 如 12芯*2
        /// </summary>
        /// <param name="_labName">标签名称</param>
        public bool SetLab(string _labName)
        {
           return  dal.SetLab(_labName);
        }

        /// <summary>
        /// 打印标签
        /// </summary>
        public void Print()
        {
            dal.Print();
        }
        
        /// <summary>
        /// BT打印
        /// </summary>
        public void BtPrint()
        {
            dal.BtPrint();
        }

        /// <summary>
        /// 设置或获取标签名称
        /// </summary>
        public string LabName { get { return dal.LabName; } set { dal.LabName = value; } }


    }
}
