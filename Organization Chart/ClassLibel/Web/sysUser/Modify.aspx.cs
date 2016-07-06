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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string UserID= Request.Params["id"];
					ShowInfo(UserID);
				}
			}
		}
			
	private void ShowInfo(string UserID)
	{
		Maticsoft.BLL.sysUser bll=new Maticsoft.BLL.sysUser();
		Maticsoft.Model.sysUser model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID;
		this.txtUserName.Text=model.UserName;
		this.txtPassword.Text=model.Password;
		this.txtWorkstation.Text=model.Workstation;
		this.txtPrivilege.Text=model.Privilege;
		this.txtID_Key.Text=model.ID_Key.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			string UserID=this.lblUserID.Text;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
