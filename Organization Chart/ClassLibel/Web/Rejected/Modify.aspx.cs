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
namespace Maticsoft.Web.Rejected
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
		Maticsoft.BLL.Rejected bll=new Maticsoft.BLL.Rejected();
		Maticsoft.Model.Rejected model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txttb_RejectCode.Text=model.tb_RejectCode;
		this.txtReject.Text=model.Reject;
		this.txtDescriptions.Text=model.Descriptions;
		this.txtPicture.Text=model.Picture.ToString();
		this.txtNotes.Text=model.Notes;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txttb_RejectCode.Text.Trim().Length==0)
			{
				strErr+="tb_RejectCode不能为空！\\n";	
			}
			if(this.txtReject.Text.Trim().Length==0)
			{
				strErr+="Reject不能为空！\\n";	
			}
			if(this.txtDescriptions.Text.Trim().Length==0)
			{
				strErr+="Descriptions不能为空！\\n";	
			}
			if(this.txtNotes.Text.Trim().Length==0)
			{
				strErr+="Notes不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal ID=decimal.Parse(this.lblID.Text);
			string tb_RejectCode=this.txttb_RejectCode.Text;
			string Reject=this.txtReject.Text;
			string Descriptions=this.txtDescriptions.Text;
			byte[] Picture= new UnicodeEncoding().GetBytes(this.txtPicture.Text);
			string Notes=this.txtNotes.Text;


			Maticsoft.Model.Rejected model=new Maticsoft.Model.Rejected();
			model.ID=ID;
			model.tb_RejectCode=tb_RejectCode;
			model.Reject=Reject;
			model.Descriptions=Descriptions;
			model.Picture=Picture;
			model.Notes=Notes;

			Maticsoft.BLL.Rejected bll=new Maticsoft.BLL.Rejected();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
