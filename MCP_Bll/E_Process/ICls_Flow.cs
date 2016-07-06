using System;
namespace Maticsoft.BLL
{
   public interface ICls_Flow
    {
        void Get_Bar_YetOverFlow(string Barcode, out int MaxProcessOrder, out int YetOverFlowCount, ref System.Collections.ObjectModel.ObservableCollection<Maticsoft.Model.e_ProcessFlow> eFlowList); 
        bool GetFlow(string FlowNum, ref System.Collections.ObjectModel.ObservableCollection<Maticsoft.Model.e_ProcessFlow> eFlowList,out string ErrMessage);
        bool SaveProcessFlow(string _BarCode, System.Collections.ObjectModel.ObservableCollection<Maticsoft.Model.e_ProcessFlow> _Yet_ProcessFlow); 
      
        /// <summary>
       /// 验证工序是否可以保存
       /// </summary>
        /// <param name="Barcode">条码</param>
       /// <param name="_ProcessFlow">待保存的工序信息</param>
       /// <param name="_MaxProcessOrder">已保存的最大工序的顺序编号</param>
       /// <param name="IsBelong">该工序是否属于此条码</param>
       /// <param name="IsYetSave">是否已经保存过此工序</param>
       /// <param name="IsUpProcessSave">上工序是否已经完成</param>
       /// <returns></returns>
        void VerifyBarcode(string Barcode, Maticsoft.Model.e_ProcessFlow _ProcessFlow, int _MaxProcessOrder, out bool IsBelong, out bool IsYetSave, out bool IsUpProcessSave, out bool IsBarcodeNull);
    }
}
