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
namespace Maticsoft.Web.Dispose
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtRejectCode.Text.Trim().Length==0)
			{
				strErr+="RejectCode不能为空！\\n";	
			}
			if(this.txtDisposeMethod.Text.Trim().Length==0)
			{
				strErr+="DisposeMethod不能为空！\\n";	
			}
			if(this.txtDescriptions.Text.Trim().Length==0)
			{
				strErr+="Descriptions不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string RejectCode=this.txtRejectCode.Text;
			string DisposeMethod=this.txtDisposeMethod.Text;
			string Descriptions=this.txtDescriptions.Text;

			Maticsoft.Model.Dispose model=new Maticsoft.Model.Dispose();
			model.RejectCode=RejectCode;
			model.DisposeMethod=DisposeMethod;
			model.Descriptions=Descriptions;

			Maticsoft.BLL.Dispose bll=new Maticsoft.BLL.Dispose();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
