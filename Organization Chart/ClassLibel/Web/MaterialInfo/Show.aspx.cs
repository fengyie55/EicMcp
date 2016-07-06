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
namespace Maticsoft.Web.MaterialInfo
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
					string MaterialID= strid;
					ShowInfo(MaterialID);
				}
			}
		}
		
	private void ShowInfo(string MaterialID)
	{
		Maticsoft.BLL.MaterialInfo bll=new Maticsoft.BLL.MaterialInfo();
		Maticsoft.Model.MaterialInfo model=bll.GetModel(MaterialID);
		this.lblMaterialID.Text=model.MaterialID;
		this.lblAliasName.Text=model.AliasName;
		this.lblProductName.Text=model.ProductName;
		this.lblModel.Text=model.Model;
		this.lblMaterialPhoto.Text=model.MaterialPhoto.ToString();
		this.lblType.Text=model.Type;

	}


    }
}
