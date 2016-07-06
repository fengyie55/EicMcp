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
namespace Maticsoft.Web.Material_FeedIntake
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
					decimal Fe_ID=(Convert.ToDecimal(strid));
					ShowInfo(Fe_ID);
				}
			}
		}
		
	private void ShowInfo(decimal Fe_ID)
	{
		Maticsoft.BLL.Material_FeedIntake bll=new Maticsoft.BLL.Material_FeedIntake();
		Maticsoft.Model.Material_FeedIntake model=bll.GetModel(Fe_ID);
		this.lblFe_ID.Text=model.Fe_ID.ToString();
		this.lblFeedIntakeID.Text=model.FeedIntakeID;
		this.lblMaterialNum.Text=model.MaterialNum;
		this.lblCount.Text=model.Count;
		this.lblUserID.Text=model.UserID;
		this.lblWorkstationID.Text=model.WorkstationID;
		this.lblDataTime.Text=model.DataTime.ToString();

	}


    }
}
