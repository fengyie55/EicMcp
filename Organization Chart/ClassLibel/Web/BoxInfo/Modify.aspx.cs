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
namespace Maticsoft.Web.BoxInfo
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(decimal ID)
	{
		Maticsoft.BLL.BoxInfo bll=new Maticsoft.BLL.BoxInfo();
		Maticsoft.Model.BoxInfo model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtBatchNo.Text=model.BatchNo;
		this.txtBoxSN.Text=model.BoxSN;
		this.txtQty.Text=model.Qty;
		this.txtType.Text=model.Type;
		this.txtState.Text=model.State;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBatchNo.Text.Trim().Length==0)
			{
				strErr+="BatchNo不能为空！\\n";	
			}
			if(this.txtBoxSN.Text.Trim().Length==0)
			{
				strErr+="BoxSN不能为空！\\n";	
			}
			if(this.txtQty.Text.Trim().Length==0)
			{
				strErr+="Qty不能为空！\\n";	
			}
			if(this.txtType.Text.Trim().Length==0)
			{
				strErr+="Type不能为空！\\n";	
			}
			if(this.txtState.Text.Trim().Length==0)
			{
				strErr+="State不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal ID=decimal.Parse(this.lblID.Text);
			string BatchNo=this.txtBatchNo.Text;
			string BoxSN=this.txtBoxSN.Text;
			string Qty=this.txtQty.Text;
			string Type=this.txtType.Text;
			string State=this.txtState.Text;


			Maticsoft.Model.BoxInfo model=new Maticsoft.Model.BoxInfo();
			model.ID=ID;
			model.BatchNo=BatchNo;
			model.BoxSN=BoxSN;
			model.Qty=Qty;
			model.Type=Type;
			model.State=State;

			Maticsoft.BLL.BoxInfo bll=new Maticsoft.BLL.BoxInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
