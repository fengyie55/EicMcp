using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Maticsoft.BLL
{
   public class cls_Consumable
   {
       #region 变量
      
       /// <summary>
        /// 操作模式
        /// </summary>
        public enum ConsumableOperation { Receive, Storage }

       /// <summary>
       /// 操作模式 领料 Or 入库
       /// </summary>
       public ConsumableOperation Operation;
     
       #endregion

       /// <summary>
       /// 保存领料记录 并更改库存
       /// </summary>
       private int Add_Receive(DataGrid _Grid)
       {
           ConsumableReceive _M_ConsumableReceive = new ConsumableReceive();
           ConsumableInfo _M_ConsumableInfo = new ConsumableInfo();
           int _recode = 0;
           string _Message = "";
           foreach (object tem in _Grid.ItemsSource)
           {
             Maticsoft.Model.ConsumableReceive _tem =  (Maticsoft.Model.ConsumableReceive)tem;
             Maticsoft.Model.ConsumableInfo _ConsumableInfo = _M_ConsumableInfo.GetModel(_tem.C_Barcode);
            
             int _Count = 0, _SaftCount = 0, Stock = 0;
             int.TryParse(_tem.Count.ToString(), out _Count);   //领取数量
             int.TryParse(_ConsumableInfo.C_SafeStock, out _SaftCount); //安全库存
             int.TryParse(_ConsumableInfo.Stock, out Stock);          //当前剩余数量

             if (_Count < Stock) //如果领取数量小于库存数量
             {
                 if ((Stock - _Count) <= _SaftCount)
                 {
                     _Message += "编号：" + _ConsumableInfo.C_Barcode + "名称：" + _ConsumableInfo.C_Name + "库存不足，请立即请购！";
                 }
                 _tem.Datetime = DateTime.Now.ToString();
                 if (_M_ConsumableReceive.Add(_tem) > 0) { _recode++; }
             }
             else
             {
                 _Message += "\r\n保存失败警告：编号：" + _ConsumableInfo.C_Barcode + "名称：" + _ConsumableInfo.C_Name + "库存不足,未进行保存";
             }           
           }
           if (_Message.Length > 2) { My_MessageBox.My_MessageBox_Message(_Message); }
           return _recode;
       }
      
       /// <summary>
       /// 保存入库记录 并更改库存
       /// </summary>
       /// <param name="lis"></param>
       private int Add_Stotage(DataGrid _Grid)
       {
           ConsumableStorage _M_ConsumableReceive = new ConsumableStorage();
           int _recode = 0;
           foreach (object tem in _Grid.ItemsSource)
           {
               Maticsoft.Model.ConsumableStorage _tem = (Maticsoft.Model.ConsumableStorage)tem;
               _tem.Datetime = DateTime.Now.ToString();
               if (_M_ConsumableReceive.Add(_tem) > 0) { _recode++; }
           }
           return _recode;
       }

       /// <summary>
       /// 保存 并返回操作成功的记录数量
       /// </summary>
       /// <returns></returns>
       public int ConsumableSave(DataGrid _Grid)
       {
           if (Operation == ConsumableOperation.Receive) //领取模式              
               return Add_Receive(_Grid);
           else //入库模式
               return Add_Stotage(_Grid);
       }

      
    }

   
}
