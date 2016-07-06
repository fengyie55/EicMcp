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
namespace Maticsoft.Web.tb_PrintRecord
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
					decimal ID_Key=(Convert.ToDecimal(strid));
					ShowInfo(ID_Key);
				}
			}
		}
		
	private void ShowInfo(decimal ID_Key)
	{
		Maticsoft.BLL.tb_PrintRecord bll=new Maticsoft.BLL.tb_PrintRecord();
		Maticsoft.Model.tb_PrintRecord model=bll.GetModel(ID_Key);
		this.lblSN.Text=model.SN;
		this.lblStaff.Text=model.Staff;
		this.lblDataTime.Text=model.DataTime;
		this.lblLabellMode.Text=model.LabellMode;
		this.lblBatchNo.Text=model.BatchNo;
		this.lblOrderID.Text=model.OrderID;
		this.lblID_Key.Text=model.ID_Key.ToString();

	}


    }
}
