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
namespace Maticsoft.Web.Material_Receive
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
					decimal Re_ID=(Convert.ToDecimal(strid));
					ShowInfo(Re_ID);
				}
			}
		}
		
	private void ShowInfo(decimal Re_ID)
	{
		Maticsoft.BLL.Material_Receive bll=new Maticsoft.BLL.Material_Receive();
		Maticsoft.Model.Material_Receive model=bll.GetModel(Re_ID);
		this.lblRe_ID.Text=model.Re_ID.ToString();
		this.lblReceiveID.Text=model.ReceiveID;
		this.lblMaterialNum.Text=model.MaterialNum;
		this.lblClientNum.Text=model.ClientNum;
		this.lblCount.Text=model.Count;
		this.lblUserID.Text=model.UserID;
		this.lblWorkStationID.Text=model.WorkStationID;
		this.lblDataTime.Text=model.DataTime.ToString();

	}


    }
}
