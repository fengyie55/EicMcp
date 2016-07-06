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
namespace Maticsoft.Web.Lapping_Receive
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
					decimal Lp_ID=(Convert.ToDecimal(strid));
					ShowInfo(Lp_ID);
				}
			}
		}
		
	private void ShowInfo(decimal Lp_ID)
	{
		Maticsoft.BLL.Lapping_Receive bll=new Maticsoft.BLL.Lapping_Receive();
		Maticsoft.Model.Lapping_Receive model=bll.GetModel(Lp_ID);
		this.lblLp_ID.Text=model.Lp_ID.ToString();
		this.lblCount.Text=model.Count;
		this.lblReceiveUserID.Text=model.ReceiveUserID;
		this.lblSendUserID.Text=model.SendUserID;
		this.lblLappingReceiveID.Text=model.LappingReceiveID;
		this.lblDataTime.Text=model.DataTime.ToString();

	}


    }
}
