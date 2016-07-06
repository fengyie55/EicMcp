using Microsoft.Practices.Prism.ViewModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;


namespace UI
{
    public class LabelControlsModel : NotificationObject
    {
        Maticsoft.Model.LabelCheck model = new Maticsoft.Model.LabelCheck();

        
        /*
        public delegate void SetLabEventHadler();
        public event SetLabEventHadler SetSN_One;
        public event SetLabEventHadler SetSN_Two;
        public event SetLabEventHadler SetLab_One;
        public event SetLabEventHadler SetLab_Two;
        public event SetLabEventHadler SetLab_Three; 
        */
         
        #region Property
        private string orderid;

        /// <summary>
        /// 工单单号
        /// </summary>
        public string OrderID
        {
            get { return orderid; }
            set 
            {
                if (value.Length > 11)
                {
                    value = value.Substring(0, 11);
                }
                orderid = value;
            }
        }
        

        private string sn1;

        public string SN1 
        {
            get { return sn1; }
            set
            {
                sn1 = value;
                this.RaisePropertyChanged("SN1");
            }
        }

        private string sn2;

        public string SN2
        {
            get { return sn2; }
            set
            {
                sn2 = value;
                this.RaisePropertyChanged("SN2");
            }
        }

        private bool isEnSN2 = false;

        public bool IsEnSN2
        {
            get { return isEnSN2; }
            set
            {
                isEnSN2 = value;
                this.RaisePropertyChanged("IsEnSN2");
            }
        }
        


        /*
         * Lab采用数组存储，中间以逗号隔开
         * Demo：141A0001010101000,512-1504003,512-1400005
         */
        private string lab1;

        public string Lab1
        {
            get { return lab1; }
            set
            {
                lab1 = value;
                this.RaisePropertyChanged("Lab1");
               
            }
        }

        private string lab2;
        private bool isOklab2 = false;
        public string Lab2
        {
            get { return lab2; }
            set
            {
                lab2 = value;
                this.RaisePropertyChanged("Lab2");
                if (value != null && (value.Length < 11 || value.Substring(0, 11) != orderid)) { isOklab2 = false; My_MessageBox.My_MessageBox_Message("标签与工单不符！"); } else { isOklab2 = true; }
            }
        }

        private string lab3;
        private bool isOklab3 = false;
        public string Lab3
        {
            get { return lab3; }
            set
            {
                lab3 = value;
                this.RaisePropertyChanged("Lab3");
                if (value != null)
                {
                    if (value.Length < 11 || value.Substring(0, 11) != orderid) { isOklab3 = false; My_MessageBox.My_MessageBox_Message("标签与工单不符！"); } else { isOklab3 = true; AddToDB(); }
                }
           
            }
        }

      
        #endregion

        /// <summary>
        /// 判断值是否为空
        /// </summary>
        /// <returns></returns>
        private bool IsNull() 
        {
            if(sn2!=null)
            {
                return (lab1 != null && lab2 != null && lab3 != null && sn1 != null && sn2 != null && isOklab2 && isOklab3);
            }
            else if(sn1!=null)
            {
                return (lab1 != null && lab2 != null && lab3 != null && sn1 != null && isOklab2 && isOklab3);
            }
            else { return false; }
        }

        public ICommand Add
        {
            get { return new DelegateCommand<string>((lab) => { Lab3 = lab; AddToDB(); }); }
        }

        
        /// <summary>
        /// 添加标签检测记录 到数据库中
        /// </summary>
        public void AddToDB() 
        {
            if (IsNull())
            {
                if (sn2 != null) //如果SN2!="" 保存SN1与SN2的信息
                {
                    model.Lab = lab1 + "," + lab2 + "," + lab3;
                    model.SN = sn1;
                    Maticsoft.BLL.LabelCheck labcheck = new Maticsoft.BLL.LabelCheck();
                    labcheck.Add(model);  //添加SN1
                    model.SN = sn2;
                    labcheck.Add(model);  //添加SN2
                }
                else
                {
                    model.Lab = lab1 + "," + lab2 + "," + lab3;
                    model.SN = sn1;
                    Maticsoft.BLL.LabelCheck labcheck = new Maticsoft.BLL.LabelCheck();
                    labcheck.Add(model);  //添加SN1
                }
                ClearPropertyValue();
            }
            else
            {
                My_MessageBox.My_MessageBox_Message("标签不完整");
            }
          
        }


      

        public ICommand KeyTab
        {
            get { return new DelegateCommand(() => { Keyboard.Press(Key.Tab); }); }
        }
        


        
        
        

        /// <summary>
        /// 清空属性值  
        /// </summary>
        private void ClearPropertyValue()
        {
             SN1 = null; SN2 = null; Lab1 = null; Lab2 = null; Lab3 = null;
            /*
            foreach (System.Reflection.PropertyInfo p in this.GetType().GetProperties())
            {
               // p.SetValue(null, "", null);
                System.Reflection.PropertyInfo piShared = typeof(LabelControlsModel).GetProperty(p.Name);
                piShared.SetValue(null, 76, null);
            }
             */
        }

        

        
        
    }
}
