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
namespace Maticsoft.Web.InStorage
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
					decimal In_ID=(Convert.ToDecimal(strid));
					ShowInfo(In_ID);
				}
			}
		}
		
	private void ShowInfo(decimal In_ID)
	{
		Maticsoft.BLL.InStorage bll=new Maticsoft.BLL.InStorage();
		Maticsoft.Model.InStorage model=bll.GetModel(In_ID);
		this.lblIn_ID.Text=model.In_ID.ToString();
		this.lblInStorageID.Text=model.InStorageID;
		this.lblCount.Text=model.Count;
		this.lblUserID.Text=model.UserID;
		this.lblDataTime.Text=model.DataTime.ToString();

	}


    }
}
