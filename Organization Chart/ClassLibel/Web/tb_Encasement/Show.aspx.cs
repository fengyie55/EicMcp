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
namespace Maticsoft.Web.tb_Encasement
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
		Maticsoft.BLL.tb_Encasement bll=new Maticsoft.BLL.tb_Encasement();
		Maticsoft.Model.tb_Encasement model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblBoxID.Text=model.BoxID;
		this.lblSN.Text=model.SN;
		this.lblQty.Text=model.Qty;

	}


    }
}
