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
namespace Maticsoft.Web.Rejected
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttb_RejectCode.Text.Trim().Length==0)
			{
				strErr+="tb_RejectCode不能为空！\\n";	
			}
			if(this.txtReject.Text.Trim().Length==0)
			{
				strErr+="Reject不能为空！\\n";	
			}
			if(this.txtDescriptions.Text.Trim().Length==0)
			{
				strErr+="Descriptions不能为空！\\n";	
			}
			if(this.txtNotes.Text.Trim().Length==0)
			{
				strErr+="Notes不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string tb_RejectCode=this.txttb_RejectCode.Text;
			string Reject=this.txtReject.Text;
			string Descriptions=this.txtDescriptions.Text;
			byte[] Picture= new UnicodeEncoding().GetBytes(this.txtPicture.Text);
			string Notes=this.txtNotes.Text;

			Maticsoft.Model.Rejected model=new Maticsoft.Model.Rejected();
			model.tb_RejectCode=tb_RejectCode;
			model.Reject=Reject;
			model.Descriptions=Descriptions;
			model.Picture=Picture;
			model.Notes=Notes;

			Maticsoft.BLL.Rejected bll=new Maticsoft.BLL.Rejected();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
