using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seagull.BarTender.Print;
using System.Windows.Forms;


namespace Maticsoft.DAL
{
    public class ZebraPrint
    {

        string _PrintName, _LabellMode;
        Engine btEngine = new Engine();    //后台线程
        //定义委托
        public delegate void MyZebraPrintEventHandler(LabelFormatDocument e);
        //定义打印事件
        public event MyZebraPrintEventHandler MyZeberPrint;

        protected virtual void onMyZebraPint()
        {
            try
            {
                if (MyZeberPrint != null)
                {
                                   
                    Messages messages = null;

                    //设置打印模板
                    LabelFormatDocument btFormat = btEngine.Documents.Open(_LabellMode);
                    //设置打印机
                    btFormat.PrintSetup.PrinterName = _PrintName;
                    MyZeberPrint(btFormat);                   

                    // Set this format as the Active format for this // BarTender engine instance.
                    btFormat.Activate();

                    // Print the format.
                    // btEngine.ActiveDocument.Print();
                    Result result = btFormat.Print("PrintJob1", out messages);

                    // Close the current format, saving any changes.
                    btFormat.Close(SaveOptions.SaveChanges);
             
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 开始打印
        /// </summary>
        /// <param name="e"></param>
        public void StartPrint()
        {
            onMyZebraPint();
        }
        /// <summary>
        /// 打印模板
        /// </summary>
        public string labMode
        {
            set 
            { 
            _LabellMode = value;
            // Start the BarTender print engine.         
            btEngine.Start();
            }
        }
        /// <summary>
        /// 打印机设置
        /// </summary>
        public string PrintName
        {
            set { _PrintName = value; }
        }

    }
}
