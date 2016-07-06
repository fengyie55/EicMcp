using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maticsoft.BLL
{
  public  class Cls_Flow : Maticsoft.BLL.ICls_Flow
    {
        /// <summary>
        /// 获取已经完成的工序列表
        /// </summary>
        /// <param name="Barcode">条码</param>
        /// <param name="MaxProcessOrder">最大的工序序列号</param>
        /// <param name="YetOverFlowCount">已完成的工序总数量</param>
        /// <param name="eFlowList">已完成工序列表</param>
        public void Get_Bar_YetOverFlow(string Barcode, out int MaxProcessOrder, out int YetOverFlowCount, ref ObservableCollection<Maticsoft.Model.e_ProcessFlow> _Yet_ProcessFlow)
        {
            _Yet_ProcessFlow.Clear();
            YetOverFlowCount = 0;
            MaxProcessOrder = 0;
            //获取已经完成的工序并根据工序的顺序号  排序
            Maticsoft.BLL.e_ProcessFlow MprocessFlow = new Maticsoft.BLL.e_ProcessFlow();
            ObservableCollection<Maticsoft.Model.e_ProcessFlow> TemFlowList = new ObservableCollection<Maticsoft.Model.e_ProcessFlow>(MprocessFlow.GetModelList("BarCode = '" + Barcode + "'"));
            TemFlowList.OrderBy(x => x.R1); 
            //对已经完成的工序列表进行处理，得到最大工序号和获取已经完成了多少道工序
            string temFlowNum = "";
            foreach (Maticsoft.Model.e_ProcessFlow tem in TemFlowList)
            {               
                YetOverFlowCount = ((tem.ProNum == temFlowNum) ? YetOverFlowCount : YetOverFlowCount++);  //计算此条码已经做了多少道工序
                temFlowNum = tem.ProNum; //将工序编号存储在此变量中，以备和下一个工序编号进行比较
                MaxProcessOrder = ((int.Parse(tem.R1) < MaxProcessOrder) ? MaxProcessOrder : int.Parse(tem.R1));  //获取最大工序序列号
                _Yet_ProcessFlow.Add(tem);
            }                      
        }

        /// <summary>
        /// 获取工序
        /// </summary>
        /// <param name="FlowNum">工序编号</param>
        /// <param name="eFlowList">工序列表</param>
        /// <returns></returns>
        public bool GetFlow(string FlowNum, ref ObservableCollection<Maticsoft.Model.e_ProcessFlow> eProcessFlowList,out string ErrMessage )
        {
            if (FlowNum != "")
            {
                eProcessFlowList.Clear();  //清空工序列表
                Maticsoft.BLL.e_Flow eFlow = new Maticsoft.BLL.e_Flow();
                ObservableCollection<Maticsoft.Model.e_Flow> FlowList =  eFlow.GetModelList("ProcessNum = '" + FlowNum + "'");
                if (FlowList.Count > 0)
                {                  
                    foreach(Maticsoft.Model.e_Flow temFlow  in FlowList)
                    {
                        eProcessFlowList.Add(new Maticsoft.Model.e_ProcessFlow()
                        {
                            ProNum = temFlow.ProcessNum,
                            ProcessName = temFlow.ProcessName,
                            ProcessContent = temFlow.Content,
                            R1= temFlow.ProcessOrder,
                            Value =((temFlow.Content == "日期")? DateTime.Now.ToString():"")
                        });
                    }
                    ErrMessage = "";
                    return true;
                }
                else
                { ErrMessage = "未找到此工序编号的任何信息！"; return false; }
               
            }
            else { ErrMessage = "工序编号不能为空！"; return false; }
            
        }

       /// <summary>
       /// 验证工序是否可以保存
       /// </summary>
        /// <param name="Barcode">条码</param>
       /// <param name="_ProcessFlow">待保存的工序信息</param>
       /// <param name="_MaxProcessOrder">已保存的最大工序的顺序编号</param>
       /// <param name="IsBelong">该工序是否属于此条码</param>
       /// <param name="IsYetSave">是否已经保存过此工序</param>
       /// <param name="IsUpProcessSave">上工序是否已经完成</param>
        /// <param name="IsBarcodeNull">条码是否为空</param>
       /// <returns></returns>
        public void VerifyBarcode(string Barcode, Maticsoft.Model.e_ProcessFlow _ProcessFlow,int _MaxProcessOrder,out bool IsBelong,out bool IsYetSave,out bool IsUpProcessSave ,out bool IsBarcodeNull)
        {
       
            /*1.根据条码获取工单
             * 2.根据工单获取图纸编号
             * 3.根据图纸编号获取工序列表
             * 4.验证 此工序是否属于该工单
             * 5.验证 此工序的上工序是否已经完成
             * 6.验证 此工序是否已经做过 目前设定（如果做过忽略警告，正常保存）
             */      
            Maticsoft.BLL.SerialNumber MserialNumber = new Maticsoft.BLL.SerialNumber();
            Maticsoft.BLL.e_Flow Mflow = new Maticsoft.BLL.e_Flow();
            Maticsoft.BLL.e_WorkOrder MworkOrder = new Maticsoft.BLL.e_WorkOrder();
            Maticsoft.BLL.e_ProcessFlow MprocessFlow = new Maticsoft.BLL.e_ProcessFlow();

            Maticsoft.Model.SerialNumber SerialNumber = MserialNumber.GetModel(Barcode); //条码
            if(SerialNumber!=null)
            {
                Maticsoft.Model.e_WorkOrder WorkOrder = MworkOrder.GetModel(SerialNumber.OrderID); //工单
            
                //根据条码获取的工单中对应的图纸编号 获取该编号所有的工序
                List<Maticsoft.Model.e_Flow> flowList = Mflow.GetModelList("DrawNum = '" + WorkOrder.DrawNum + "'").ToList();

                IsBelong = false;
                foreach (Maticsoft.Model.e_Flow tem in flowList)
                {
                    if (tem.ProcessNum == _ProcessFlow.ProNum) { IsBelong = true; } //该工序是否存在
                }
                IsYetSave = (int.Parse(_ProcessFlow.R1) == _MaxProcessOrder ? true : false);  //是否已经保存此工序
                IsUpProcessSave = (int.Parse(_ProcessFlow.R1) - 1 == _MaxProcessOrder ? true : false); //上工序是否已完成  
                IsBarcodeNull = true;
            }
            else
            {
                IsBarcodeNull = false;
                IsYetSave = true;
                IsBelong = true;
                IsUpProcessSave = true;
            }
             
        }
     
        /// <summary>
        /// 保存此条码工序
        /// </summary>
        /// <param name="ErrMessage">异常信息</param>
        /// <param name="_BarCode">条码</param>
        /// <returns></returns>
        public bool SaveProcessFlow(string _BarCode, ObservableCollection<Maticsoft.Model.e_ProcessFlow> _ProcessFlow) 
        {
            try
            {
                Maticsoft.BLL.e_ProcessFlow MprocessFlow = new Maticsoft.BLL.e_ProcessFlow();
                ObservableCollection<Maticsoft.Model.e_ProcessFlow> _TemProcessFlow = new ObservableCollection<Maticsoft.Model.e_ProcessFlow>(_ProcessFlow);
                foreach (Maticsoft.Model.e_ProcessFlow tem in _TemProcessFlow)
                {
                    tem.BarCode = _BarCode;
                    MprocessFlow.Add(tem);
                }
                return true;
            }
            catch { return false; }                     
        }

    }
}
