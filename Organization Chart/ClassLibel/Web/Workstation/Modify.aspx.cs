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
namespace Maticsoft.Web.Workstation
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal Wo_ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(Wo_ID);
				}
			}
		}
			
	private void ShowInfo(decimal Wo_ID)
	{
		Maticsoft.BLL.Workstation bll=new Maticsoft.BLL.Workstation();
		Maticsoft.Model.Workstation model=bll.GetModel(Wo_ID);
		this.lblWo_ID.Text=model.Wo_ID.ToString();
		this.txtWorkstation.Text=model.Workstation;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtWorkstation.Text.Trim().Length==0)
			{
				strErr+="Workstation不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal Wo_ID=decimal.Parse(this.lblWo_ID.Text);
			string Workstation=this.txtWorkstation.Text;


			Maticsoft.Model.Workstation model=new Maticsoft.Model.Workstation();
			model.Wo_ID=Wo_ID;
			model.Workstation=Workstation;

			Maticsoft.BLL.Workstation bll=new Maticsoft.BLL.Workstation();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
