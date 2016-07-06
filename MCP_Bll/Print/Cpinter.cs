/**  版本信息模板在安装目录下，可自行修改。
* Cpinter.cs
*
* 功 能： 获取打印机列表
* 类 名： Cpinter
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
using System.Drawing.Printing;

namespace Maticsoft.BLL
{
   public class Cpinter
    {
        private  PrintDocument fPrintDocument = new PrintDocument();
        ///<summary>
        ///获取本地默认打印机名称
        ///</summary>
        public  string DefaultPrinter
        {
            get { return fPrintDocument.PrinterSettings.PrinterName; }
        }

        /// <summary>
        ///  获取本地打印机的列表，第一项就是默认打印机
        /// </summary>
        public List<string> GetLocalPrinter()
        {
            List<string> fPrinters = new List<string>();
            fPrinters.Add(DefaultPrinter);  //默认打印机出现在列表的第一项
            foreach (string fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                    fPrinters.Add(fPrinterName);
            }
            return fPrinters;
        }
    }
}
