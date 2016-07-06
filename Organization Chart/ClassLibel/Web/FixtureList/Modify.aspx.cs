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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(decimal ID)
	{
		Maticsoft.BLL.FixtureList bll=new Maticsoft.BLL.FixtureList();
		Maticsoft.Model.FixtureList model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtBarCode.Text=model.BarCode;
		this.txtFixture_Name.Text=model.Fixture_Name;
		this.txtInstallLocation.Text=model.InstallLocation;
		this.txtF_State.Text=model.F_State;
		this.txtLogDate.Text=model.LogDate.ToString();
		this.txtLogUser.Text=model.LogUser;
		this.txtCareUser.Text=model.CareUser;
		this.txtUseDate.Text=model.UseDate.ToString();
		this.txtScrapDate.Text=model.ScrapDate.ToString();
		this.txtFAY_ID.Text=model.FAY_ID;
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			decimal ID=decimal.Parse(this.lblID.Text);
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
			model.ID=ID;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
