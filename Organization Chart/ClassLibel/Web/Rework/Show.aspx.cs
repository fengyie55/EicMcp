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
namespace Maticsoft.Web.Rework
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
		Maticsoft.BLL.Rework bll=new Maticsoft.BLL.Rework();
		Maticsoft.Model.Rework model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblSN.Text=model.SN;
		this.lblPigtailType.Text=model.PigtailType;
		this.lblCount.Text=model.Count;
		this.lblRejectID.Text=model.RejectID;
		this.lblRejectDescribe.Text=model.RejectDescribe;
		this.lblDisposeID.Text=model.DisposeID;
		this.lblDisposeDescribe.Text=model.DisposeDescribe;
		this.lblLength.Text=model.Length;
		this.lblResult.Text=model.Result;
		this.lblReworkID.Text=model.ReworkID;
		this.lblVerifyID.Text=model.VerifyID;

	}


    }
}
