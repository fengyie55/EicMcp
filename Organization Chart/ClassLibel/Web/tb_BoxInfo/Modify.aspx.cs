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
namespace Maticsoft.Web.tb_BoxInfo
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
		Maticsoft.BLL.tb_BoxInfo bll=new Maticsoft.BLL.tb_BoxInfo();
		Maticsoft.Model.tb_BoxInfo model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtBoxSn.Text=model.BoxSn;
		this.txtQty.Text=model.Qty;
		this.txtType.Text=model.Type;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBoxSn.Text.Trim().Length==0)
			{
				strErr+="BoxSn不能为空！\\n";	
			}
			if(this.txtQty.Text.Trim().Length==0)
			{
				strErr+="Qty不能为空！\\n";	
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
			decimal ID=decimal.Parse(this.lblID.Text);
			string BoxSn=this.txtBoxSn.Text;
			string Qty=this.txtQty.Text;
			string Type=this.txtType.Text;


			Maticsoft.Model.tb_BoxInfo model=new Maticsoft.Model.tb_BoxInfo();
			model.ID=ID;
			model.BoxSn=BoxSn;
			model.Qty=Qty;
			model.Type=Type;

			Maticsoft.BLL.tb_BoxInfo bll=new Maticsoft.BLL.tb_BoxInfo();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
