using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.tb_PrintRecord
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtSN.Text.Trim().Length==0)
			{
				strErr+="SN不能为空！\\n";	
			}
			if(this.txtStaff.Text.Trim().Length==0)
			{
				strErr+="Staff不能为空！\\n";	
			}
			if(this.txtDataTime.Text.Trim().Length==0)
			{
				strErr+="DataTime不能为空！\\n";	
			}
			if(this.txtLabellMode.Text.Trim().Length==0)
			{
				strErr+="LabellMode不能为空！\\n";	
			}
			if(this.txtBatchNo.Text.Trim().Length==0)
			{
				strErr+="BatchNo不能为空！\\n";	
			}
			if(this.txtOrderID.Text.Trim().Length==0)
			{
				strErr+="OrderID不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string SN=this.txtSN.Text;
			string Staff=this.txtStaff.Text;
			string DataTime=this.txtDataTime.Text;
			string LabellMode=this.txtLabellMode.Text;
			string BatchNo=this.txtBatchNo.Text;
			string OrderID=this.txtOrderID.Text;

			Maticsoft.Model.tb_PrintRecord model=new Maticsoft.Model.tb_PrintRecord();
			model.SN=SN;
			model.Staff=Staff;
			model.DataTime=DataTime;
			model.LabellMode=LabellMode;
			model.BatchNo=BatchNo;
			model.OrderID=OrderID;

			Maticsoft.BLL.tb_PrintRecord bll=new Maticsoft.BLL.tb_PrintRecord();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
