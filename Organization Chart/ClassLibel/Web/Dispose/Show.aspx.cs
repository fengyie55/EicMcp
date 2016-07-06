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
namespace Maticsoft.Web.Dispose
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
		Maticsoft.BLL.Dispose bll=new Maticsoft.BLL.Dispose();
		Maticsoft.Model.Dispose model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblRejectCode.Text=model.RejectCode;
		this.lblDisposeMethod.Text=model.DisposeMethod;
		this.lblDescriptions.Text=model.Descriptions;

	}


    }
}
