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
namespace Maticsoft.Web.FixtureList
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					decimal ID=(Convert.ToDecimal(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(decimal ID)
	{
		Maticsoft.BLL.FixtureList bll=new Maticsoft.BLL.FixtureList();
		Maticsoft.Model.FixtureList model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblBarCode.Text=model.BarCode;
		this.lblFixture_Name.Text=model.Fixture_Name;
		this.lblInstallLocation.Text=model.InstallLocation;
		this.lblF_State.Text=model.F_State;
		this.lblLogDate.Text=model.LogDate.ToString();
		this.lblLogUser.Text=model.LogUser;
		this.lblCareUser.Text=model.CareUser;
		this.lblUseDate.Text=model.UseDate.ToString();
		this.lblScrapDate.Text=model.ScrapDate.ToString();
		this.lblFAY_ID.Text=model.FAY_ID;
		this.lblRemark.Text=model.Remark;

	}


    }
}
