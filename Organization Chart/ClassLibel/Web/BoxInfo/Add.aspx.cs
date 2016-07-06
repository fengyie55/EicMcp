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
namespace Maticsoft.Web.BoxInfo
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBatchNo.Text.Trim().Length==0)
			{
				strErr+="BatchNo不能为空！\\n";	
			}
			if(this.txtBoxSN.Text.Trim().Length==0)
			{
				strErr+="BoxSN不能为空！\\n";	
			}
			if(this.txtQty.Text.Trim().Length==0)
			{
				strErr+="Qty不能为空！\\n";	
			}
			if(this.txtType.Text.Trim().Length==0)
			{
				strErr+="Type不能为空！\\n";	
			}
			if(this.txtState.Text.Trim().Length==0)
			{
				strErr+="State不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string BatchNo=this.txtBatchNo.Text;
			string BoxSN=this.txtBoxSN.Text;
			string Qty=this.txtQty.Text;
			string Type=this.txtType.Text;
			string State=this.txtState.Text;

			Maticsoft.Model.BoxInfo model=new Maticsoft.Model.BoxInfo();
			model.BatchNo=BatchNo;
			model.BoxSN=BoxSN;
			model.Qty=Qty;
			model.Type=Type;
			model.State=State;

			Maticsoft.BLL.BoxInfo bll=new Maticsoft.BLL.BoxInfo();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
