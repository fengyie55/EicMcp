using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Maticsoft.BLL
{
    public class SPC
    {
        Maticsoft.DAL.SPC dal = new DAL.SPC();

       
        /// <summary>
        /// 单表生成SPC
        /// </summary>
        /// <param name="_SavePatch">保存路径</param>
        /// <param name="_Parameter">列名</param>
        /// <param name="_Date">日期</param>
        public void Get_SPC_MPO(string _SavePatch, string _Parameter, string _Date)
        {
            dal.Get_SPC_MPO(_SavePatch, _Parameter, _Date);
        }
        string _TSavePatch, _TStartDate, _TEndDate;
        
        
        /// <summary>
        /// 自动生成
        /// </summary>
        /// <param name="_SavePatch">保存路径</param>
        /// <param name="_StartDate">开始日期</param>
        /// <param name="_EndDate">结束日期</param>
        public void Get_SPC_MPO_Auto(string _SavePatch, string _StartDate, string _EndDate)
        {
            _TSavePatch =_SavePatch;
            _TStartDate = _StartDate;
            _TEndDate = _EndDate;

            Thread thread = new Thread(new ThreadStart(ThreadProc));
            thread.IsBackground = true;
            thread.Start();                      
        }  
   
        private  void ThreadProc()
        {
            dal.Get_SPC_MPO_Auto(_TSavePatch, _TStartDate, _TEndDate);
        }
    }
}
