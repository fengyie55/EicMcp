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
namespace Maticsoft.Web.ConsumableStorage
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal C_StoID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(C_StoID);
				}
			}
		}
			
	private void ShowInfo(decimal C_StoID)
	{
		Maticsoft.BLL.ConsumableStorage bll=new Maticsoft.BLL.ConsumableStorage();
		Maticsoft.Model.ConsumableStorage model=bll.GetModel(C_StoID);
		this.lblC_StoID.Text=model.C_StoID.ToString();
		this.txtC_Barcode.Text=model.C_Barcode;
		this.txtCount.Text=model.Count.ToString();
		this.txtUserName.Text=model.UserName;
		this.txtDatetime.Text=model.Datetime;
		this.txtRemarks.Text=model.Remarks;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtC_Barcode.Text.Trim().Length==0)
			{
				strErr+="C_Barcode不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCount.Text))
			{
				strErr+="Count格式错误！\\n";	
			}
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="UserName不能为空！\\n";	
			}
			if(this.txtDatetime.Text.Trim().Length==0)
			{
				strErr+="Datetime不能为空！\\n";	
			}
			if(this.txtRemarks.Text.Trim().Length==0)
			{
				strErr+="Remarks不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal C_StoID=decimal.Parse(this.lblC_StoID.Text);
			string C_Barcode=this.txtC_Barcode.Text;
			int Count=int.Parse(this.txtCount.Text);
			string UserName=this.txtUserName.Text;
			string Datetime=this.txtDatetime.Text;
			string Remarks=this.txtRemarks.Text;


			Maticsoft.Model.ConsumableStorage model=new Maticsoft.Model.ConsumableStorage();
			model.C_StoID=C_StoID;
			model.C_Barcode=C_Barcode;
			model.Count=Count;
			model.UserName=UserName;
			model.Datetime=Datetime;
			model.Remarks=Remarks;

			Maticsoft.BLL.ConsumableStorage bll=new Maticsoft.BLL.ConsumableStorage();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
