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
namespace Maticsoft.Web.Dispose
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
		Maticsoft.BLL.Dispose bll=new Maticsoft.BLL.Dispose();
		Maticsoft.Model.Dispose model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtRejectCode.Text=model.RejectCode;
		this.txtDisposeMethod.Text=model.DisposeMethod;
		this.txtDescriptions.Text=model.Descriptions;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtRejectCode.Text.Trim().Length==0)
			{
				strErr+="RejectCode不能为空！\\n";	
			}
			if(this.txtDisposeMethod.Text.Trim().Length==0)
			{
				strErr+="DisposeMethod不能为空！\\n";	
			}
			if(this.txtDescriptions.Text.Trim().Length==0)
			{
				strErr+="Descriptions不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal ID=decimal.Parse(this.lblID.Text);
			string RejectCode=this.txtRejectCode.Text;
			string DisposeMethod=this.txtDisposeMethod.Text;
			string Descriptions=this.txtDescriptions.Text;


			Maticsoft.Model.Dispose model=new Maticsoft.Model.Dispose();
			model.ID=ID;
			model.RejectCode=RejectCode;
			model.DisposeMethod=DisposeMethod;
			model.Descriptions=Descriptions;

			Maticsoft.BLL.Dispose bll=new Maticsoft.BLL.Dispose();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
