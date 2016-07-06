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
namespace Maticsoft.Web.ConsumableStorage
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
					decimal C_StoID=(Convert.ToDecimal(strid));
					ShowInfo(C_StoID);
				}
			}
		}
		
	private void ShowInfo(decimal C_StoID)
	{
		Maticsoft.BLL.ConsumableStorage bll=new Maticsoft.BLL.ConsumableStorage();
		Maticsoft.Model.ConsumableStorage model=bll.GetModel(C_StoID);
		this.lblC_StoID.Text=model.C_StoID.ToString();
		this.lblC_Barcode.Text=model.C_Barcode;
		this.lblCount.Text=model.Count.ToString();
		this.lblUserName.Text=model.UserName;
		this.lblDatetime.Text=model.Datetime;
		this.lblRemarks.Text=model.Remarks;

	}


    }
}
