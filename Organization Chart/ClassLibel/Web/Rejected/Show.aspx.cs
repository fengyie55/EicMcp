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
namespace Maticsoft.Web.Rejected
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
		Maticsoft.BLL.Rejected bll=new Maticsoft.BLL.Rejected();
		Maticsoft.Model.Rejected model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lbltb_RejectCode.Text=model.tb_RejectCode;
		this.lblReject.Text=model.Reject;
		this.lblDescriptions.Text=model.Descriptions;
		this.lblPicture.Text=model.Picture.ToString();
		this.lblNotes.Text=model.Notes;

	}


    }
}
