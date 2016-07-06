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
namespace Maticsoft.Web.OrderMaterial
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal Orm_ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(Orm_ID);
				}
			}
		}
			
	private void ShowInfo(decimal Orm_ID)
	{
		Maticsoft.BLL.OrderMaterial bll=new Maticsoft.BLL.OrderMaterial();
		Maticsoft.Model.OrderMaterial model=bll.GetModel(Orm_ID);
		this.lblOrm_ID.Text=model.Orm_ID.ToString();
		this.txtMaterialID.Text=model.MaterialID;
		this.txtSendCount.Text=model.SendCount.ToString();
		this.txtOrderID.Text=model.OrderID;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtMaterialID.Text.Trim().Length==0)
			{
				strErr+="MaterialID不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSendCount.Text))
			{
				strErr+="SendCount格式错误！\\n";	
			}
			if(this.txtOrderID.Text.Trim().Length==0)
			{
				strErr+="OrderID不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal Orm_ID=decimal.Parse(this.lblOrm_ID.Text);
			string MaterialID=this.txtMaterialID.Text;
			int SendCount=int.Parse(this.txtSendCount.Text);
			string OrderID=this.txtOrderID.Text;


			Maticsoft.Model.OrderMaterial model=new Maticsoft.Model.OrderMaterial();
			model.Orm_ID=Orm_ID;
			model.MaterialID=MaterialID;
			model.SendCount=SendCount;
			model.OrderID=OrderID;

			Maticsoft.BLL.OrderMaterial bll=new Maticsoft.BLL.OrderMaterial();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
