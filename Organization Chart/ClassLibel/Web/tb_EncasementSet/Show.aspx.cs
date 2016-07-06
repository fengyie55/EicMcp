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
namespace Maticsoft.Web.tb_EncasementSet
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
		Maticsoft.BLL.tb_EncasementSet bll=new Maticsoft.BLL.tb_EncasementSet();
		Maticsoft.Model.tb_EncasementSet model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblBatchNo.Text=model.BatchNo;
		this.lblDevice.Text=model.Device;
		this.lblDeviceQty.Text=model.DeviceQty;
		this.lblSqckQty.Text=model.SqckQty;

	}


    }
}
