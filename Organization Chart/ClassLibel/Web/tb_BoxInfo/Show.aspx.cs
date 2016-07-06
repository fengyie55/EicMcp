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
namespace Maticsoft.Web.tb_BoxInfo
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
		Maticsoft.BLL.tb_BoxInfo bll=new Maticsoft.BLL.tb_BoxInfo();
		Maticsoft.Model.tb_BoxInfo model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblBoxSn.Text=model.BoxSn;
		this.lblQty.Text=model.Qty;
		this.lblType.Text=model.Type;

	}


    }
}
