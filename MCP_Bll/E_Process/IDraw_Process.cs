using System;
namespace Maticsoft.BLL  
{
 public   interface IDraw_Process
    {
        void EditProcess(System.Collections.ObjectModel.ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents);
        void GetDraw_forExcel(ref System.Collections.ObjectModel.ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents);
        void GetDraw_forDB(ref System.Collections.ObjectModel.ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents, string DrawNum);
        void SaveProcess(System.Collections.ObjectModel.ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents); 
    }
}
 