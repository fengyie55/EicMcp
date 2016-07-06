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
namespace Maticsoft.Web.InStorage
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal In_ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(In_ID);
				}
			}
		}
			
	private void ShowInfo(decimal In_ID)
	{
		Maticsoft.BLL.InStorage bll=new Maticsoft.BLL.InStorage();
		Maticsoft.Model.InStorage model=bll.GetModel(In_ID);
		this.lblIn_ID.Text=model.In_ID.ToString();
		this.txtInStorageID.Text=model.InStorageID;
		this.txtCount.Text=model.Count;
		this.txtUserID.Text=model.UserID;
		this.txtDataTime.Text=model.DataTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtInStorageID.Text.Trim().Length==0)
			{
				strErr+="InStorageID不能为空！\\n";	
			}
			if(this.txtCount.Text.Trim().Length==0)
			{
				strErr+="Count不能为空！\\n";	
			}
			if(this.txtUserID.Text.Trim().Length==0)
			{
				strErr+="UserID不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDataTime.Text))
			{
				strErr+="DataTime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal In_ID=decimal.Parse(this.lblIn_ID.Text);
			string InStorageID=this.txtInStorageID.Text;
			string Count=this.txtCount.Text;
			string UserID=this.txtUserID.Text;
			DateTime DataTime=DateTime.Parse(this.txtDataTime.Text);


			Maticsoft.Model.InStorage model=new Maticsoft.Model.InStorage();
			model.In_ID=In_ID;
			model.InStorageID=InStorageID;
			model.Count=Count;
			model.UserID=UserID;
			model.DataTime=DataTime;

			Maticsoft.BLL.InStorage bll=new Maticsoft.BLL.InStorage();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
