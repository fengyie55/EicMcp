using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL 
{
   public class Draw_Process : Maticsoft.BLL.IDraw_Process 
    {
       Maticsoft.BLL.e_Flow M_Flow = new e_Flow();
       Maticsoft.BLL.e_ProcessDraw M_ProcessDraw = new e_ProcessDraw();
       string _ExcelPatch = "D:\\模板\\FlowList.xlsx";

       /// <summary>
       /// 获取来自Excel中的工序列表
       /// </summary>
       /// <param name="eFlowList_Contents"></param>
       /// <param name="DrawNum"></param>
       public void GetDraw_forExcel(ref ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents)
       {          
           ZhuifengLib.EXCEL.ExcelControl _M_excel = new ZhuifengLib.EXCEL.ExcelControl();
           DataSet temds = _M_excel.ExcelReader(_ExcelPatch);
           eFlowList_Contents.Clear();

           ZhuifengLib.Model.ModelHandler<Maticsoft.Model.e_Flow> te = new ZhuifengLib.Model.ModelHandler<Model.e_Flow>();

           foreach (Maticsoft.Model.e_Flow tem in M_Flow.DataTableToList(temds.Tables[0]))
           {
               eFlowList_Contents.Add(tem);             
           }
         
       }


       /// <summary>
       /// 获取来自数据库中的工序列表
       /// </summary>
       /// <param name="eFlowList_Contents"></param>
       /// <param name="DrawNum"></param>
       public void GetDraw_forDB(ref ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents, string DrawNum)
       {
           eFlowList_Contents = M_Flow.GetModelList("DrawNum = '" + DrawNum + "'");
       }

       /// <summary>
       /// 编辑
       /// </summary>
       /// <param name="eFlowList_Contents"></param>
        public void EditProcess(ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents)
        {
            if(eFlowList_Contents != null)
            {
                ZhuifengLib.EXCEL.ExcelControl _M_excel = new ZhuifengLib.EXCEL.ExcelControl();
                string err;
                _M_excel.ClearDate(_ExcelPatch, 500); //清空模板中的数据
                _M_excel.ModelToExcel<Maticsoft.Model.e_Flow>(eFlowList_Contents.ToList(), _ExcelPatch);
                _M_excel.OpenExcel(_ExcelPatch, out err);
            }
            else
            {             
                ZhuifengLib.EXCEL.ExcelControl _M_excel = new ZhuifengLib.EXCEL.ExcelControl();
                string err;
                _M_excel.ClearDate(_ExcelPatch, 500);
                _M_excel.OpenExcel(_ExcelPatch, out err);
            }
        }

       /// <summary>
       /// 保存
       /// </summary>
       /// <param name="eFlowList_Contents"></param>
        public void SaveProcess(ObservableCollection<Maticsoft.Model.e_Flow> eFlowList_Contents)
        {
            M_Flow.Delete(eFlowList_Contents[0].DrawNum); //删除工序列表
            M_ProcessDraw.Delete(eFlowList_Contents[0].DrawNum);//删除图纸
            foreach(Maticsoft.Model.e_Flow eFlow in eFlowList_Contents)
            {
                M_Flow.Add(eFlow);
            }
            eFlowList_Contents.Clear();           
        }

    }
}
