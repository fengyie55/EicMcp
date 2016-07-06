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
namespace Maticsoft.Web.Workstation
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
					decimal Wo_ID=(Convert.ToDecimal(strid));
					ShowInfo(Wo_ID);
				}
			}
		}
		
	private void ShowInfo(decimal Wo_ID)
	{
		Maticsoft.BLL.Workstation bll=new Maticsoft.BLL.Workstation();
		Maticsoft.Model.Workstation model=bll.GetModel(Wo_ID);
		this.lblWo_ID.Text=model.Wo_ID.ToString();
		this.lblWorkstation.Text=model.Workstation;

	}


    }
}
