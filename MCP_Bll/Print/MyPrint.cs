/**  版本信息模板在安装目录下，可自行修改。
* MyPrint.cs
*
* 功 能： 控制条码打印机进行标签打印
* 类 名： Myprint
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-3 16:43:30   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：追风猎人　　　　　　　　　　　　　                   　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
  public  class MyPrint
    {
      DAL.labellPrint _pt = new DAL.labellPrint();

      /// <summary>
      /// 设置工单号
      /// </summary>
      public string Set_OrderID
      {
          set { _pt.OrderID = value; }
      }
      /// <summary>
      /// 包装批号
      /// </summary>
      public string Set_PackBatch
      {
          set { _pt.PackBatch = value; }
      }
      /// <summary>
      /// SN编码
      /// </summary>
      public string Set_SN
      {
          set { _pt.SN = value; }
      }
      /// <summary>
      /// 打印模板
      /// </summary>
      public string LabellMode
      {
          set { _pt.labMode = value; }
      }
      /// <summary>
      /// 设置打印机
      /// </summary>
      public string PrintName
      {
          set { _pt.PrintName = value; }
      }
      /// <summary>
      /// 获取异常列表
      /// </summary>
      public string Get_ErroyList
      {
          get { return _pt.Get_ErroyList; }
      }
      /// <summary>
      /// 获取工单信息
      /// </summary>
      public Model.WorkOrder Get_OrderInfo
      {
          get { return _pt.OrderInfo; }
      }
      /// <summary>
      /// 已打印数
      /// </summary>
      public string Get_YetPrintCount
      {
          get { return _pt.YetPrintCount.ToString(); }
      }
      /// <summary>
      /// 获取指定方向已经打印的数量  
      /// 12芯*2线材类型有效
      /// </summary>
      public string Get_DirectionPrintCount
      {
          get { return _pt.DirectionPrintCount.ToString(); }
      }
      /// <summary>
      /// 开始打印
      /// </summary>
      public void StartPrint()
      {
          _pt.StartPrint();
      }
      
      
    }
}
