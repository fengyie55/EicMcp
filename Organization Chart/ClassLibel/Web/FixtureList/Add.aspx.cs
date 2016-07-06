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
namespace Maticsoft.Web.FixtureList
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBarCode.Text.Trim().Length==0)
			{
				strErr+="BarCode不能为空！\\n";	
			}
			if(this.txtFixture_Name.Text.Trim().Length==0)
			{
				strErr+="Fixture_Name不能为空！\\n";	
			}
			if(this.txtInstallLocation.Text.Trim().Length==0)
			{
				strErr+="InstallLocation不能为空！\\n";	
			}
			if(this.txtF_State.Text.Trim().Length==0)
			{
				strErr+="F_State不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtLogDate.Text))
			{
				strErr+="LogDate格式错误！\\n";	
			}
			if(this.txtLogUser.Text.Trim().Length==0)
			{
				strErr+="LogUser不能为空！\\n";	
			}
			if(this.txtCareUser.Text.Trim().Length==0)
			{
				strErr+="CareUser不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtUseDate.Text))
			{
				strErr+="UseDate格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtScrapDate.Text))
			{
				strErr+="ScrapDate格式错误！\\n";	
			}
			if(this.txtFAY_ID.Text.Trim().Length==0)
			{
				strErr+="FAY_ID不能为空！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="Remark不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string BarCode=this.txtBarCode.Text;
			string Fixture_Name=this.txtFixture_Name.Text;
			string InstallLocation=this.txtInstallLocation.Text;
			string F_State=this.txtF_State.Text;
			DateTime LogDate=DateTime.Parse(this.txtLogDate.Text);
			string LogUser=this.txtLogUser.Text;
			string CareUser=this.txtCareUser.Text;
			DateTime UseDate=DateTime.Parse(this.txtUseDate.Text);
			DateTime ScrapDate=DateTime.Parse(this.txtScrapDate.Text);
			string FAY_ID=this.txtFAY_ID.Text;
			string Remark=this.txtRemark.Text;

			Maticsoft.Model.FixtureList model=new Maticsoft.Model.FixtureList();
			model.BarCode=BarCode;
			model.Fixture_Name=Fixture_Name;
			model.InstallLocation=InstallLocation;
			model.F_State=F_State;
			model.LogDate=LogDate;
			model.LogUser=LogUser;
			model.CareUser=CareUser;
			model.UseDate=UseDate;
			model.ScrapDate=ScrapDate;
			model.FAY_ID=FAY_ID;
			model.Remark=Remark;

			Maticsoft.BLL.FixtureList bll=new Maticsoft.BLL.FixtureList();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
