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
namespace Maticsoft.Web.sysUser
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
					string UserID= strid;
					ShowInfo(UserID);
				}
			}
		}
		
	private void ShowInfo(string UserID)
	{
		Maticsoft.BLL.sysUser bll=new Maticsoft.BLL.sysUser();
		Maticsoft.Model.sysUser model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID;
		this.lblUserName.Text=model.UserName;
		this.lblPassword.Text=model.Password;
		this.lblWorkstation.Text=model.Workstation;
		this.lblPrivilege.Text=model.Privilege;
		this.lblID_Key.Text=model.ID_Key.ToString();

	}


    }
}
