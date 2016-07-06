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
namespace Maticsoft.Web.OrderMaterial
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
					decimal Orm_ID=(Convert.ToDecimal(strid));
					ShowInfo(Orm_ID);
				}
			}
		}
		
	private void ShowInfo(decimal Orm_ID)
	{
		Maticsoft.BLL.OrderMaterial bll=new Maticsoft.BLL.OrderMaterial();
		Maticsoft.Model.OrderMaterial model=bll.GetModel(Orm_ID);
		this.lblOrm_ID.Text=model.Orm_ID.ToString();
		this.lblMaterialID.Text=model.MaterialID;
		this.lblSendCount.Text=model.SendCount.ToString();
		this.lblOrderID.Text=model.OrderID;

	}


    }
}
