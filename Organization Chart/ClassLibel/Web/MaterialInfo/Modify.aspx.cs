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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.MaterialInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string MaterialID= Request.Params["id"];
					ShowInfo(MaterialID);
				}
			}
		}
			
	private void ShowInfo(string MaterialID)
	{
		Maticsoft.BLL.MaterialInfo bll=new Maticsoft.BLL.MaterialInfo();
		Maticsoft.Model.MaterialInfo model=bll.GetModel(MaterialID);
		this.lblMaterialID.Text=model.MaterialID;
		this.txtAliasName.Text=model.AliasName;
		this.txtProductName.Text=model.ProductName;
		this.txtModel.Text=model.Model;
		this.txtMaterialPhoto.Text=model.MaterialPhoto.ToString();
		this.txtType.Text=model.Type;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtAliasName.Text.Trim().Length==0)
			{
				strErr+="AliasName不能为空！\\n";	
			}
			if(this.txtProductName.Text.Trim().Length==0)
			{
				strErr+="ProductName不能为空！\\n";	
			}
			if(this.txtModel.Text.Trim().Length==0)
			{
				strErr+="Model不能为空！\\n";	
			}
			if(this.txtType.Text.Trim().Length==0)
			{
				strErr+="Type不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string MaterialID=this.lblMaterialID.Text;
			string AliasName=this.txtAliasName.Text;
			string ProductName=this.txtProductName.Text;
			string Model=this.txtModel.Text;
			byte[] MaterialPhoto= new UnicodeEncoding().GetBytes(this.txtMaterialPhoto.Text);
			string Type=this.txtType.Text;


			Maticsoft.Model.MaterialInfo model=new Maticsoft.Model.MaterialInfo();
			model.MaterialID=MaterialID;
			model.AliasName=AliasName;
			model.ProductName=ProductName;
			model.Model=Model;
			model.MaterialPhoto=MaterialPhoto;
			model.Type=Type;

			Maticsoft.BLL.MaterialInfo bll=new Maticsoft.BLL.MaterialInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
