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
namespace Maticsoft.Web.sysUser
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserID.Text.Trim().Length==0)
			{
				strErr+="UserID不能为空！\\n";	
			}
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="UserName不能为空！\\n";	
			}
			if(this.txtPassword.Text.Trim().Length==0)
			{
				strErr+="Password不能为空！\\n";	
			}
			if(this.txtWorkstation.Text.Trim().Length==0)
			{
				strErr+="Workstation不能为空！\\n";	
			}
			if(this.txtPrivilege.Text.Trim().Length==0)
			{
				strErr+="Privilege不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtID_Key.Text))
			{
				strErr+="ID_Key格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string UserID=this.txtUserID.Text;
			string UserName=this.txtUserName.Text;
			string Password=this.txtPassword.Text;
			string Workstation=this.txtWorkstation.Text;
			string Privilege=this.txtPrivilege.Text;
			decimal ID_Key=decimal.Parse(this.txtID_Key.Text);

			Maticsoft.Model.sysUser model=new Maticsoft.Model.sysUser();
			model.UserID=UserID;
			model.UserName=UserName;
			model.Password=Password;
			model.Workstation=Workstation;
			model.Privilege=Privilege;
			model.ID_Key=ID_Key;

			Maticsoft.BLL.sysUser bll=new Maticsoft.BLL.sysUser();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
