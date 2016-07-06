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
namespace Maticsoft.Web.ConsumableReceive
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtC_Barcode.Text.Trim().Length==0)
			{
				strErr+="C_Barcode不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCount.Text))
			{
				strErr+="Count格式错误！\\n";	
			}
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="UserName不能为空！\\n";	
			}
			if(this.txtDatetime.Text.Trim().Length==0)
			{
				strErr+="Datetime不能为空！\\n";	
			}
			if(this.txtRemarks.Text.Trim().Length==0)
			{
				strErr+="Remarks不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string C_Barcode=this.txtC_Barcode.Text;
			int Count=int.Parse(this.txtCount.Text);
			string UserName=this.txtUserName.Text;
			string Datetime=this.txtDatetime.Text;
			string Remarks=this.txtRemarks.Text;

			Maticsoft.Model.ConsumableReceive model=new Maticsoft.Model.ConsumableReceive();
			model.C_Barcode=C_Barcode;
			model.Count=Count;
			model.UserName=UserName;
			model.Datetime=Datetime;
			model.Remarks=Remarks;

			Maticsoft.BLL.ConsumableReceive bll=new Maticsoft.BLL.ConsumableReceive();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
