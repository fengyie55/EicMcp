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
namespace Maticsoft.Web.Equipment_Maintain
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal Mat_ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(Mat_ID);
				}
			}
		}
			
	private void ShowInfo(decimal Mat_ID)
	{
		Maticsoft.BLL.Equipment_Maintain bll=new Maticsoft.BLL.Equipment_Maintain();
		Maticsoft.Model.Equipment_Maintain model=bll.GetModel(Mat_ID);
		this.lblMat_ID.Text=model.Mat_ID.ToString();
		this.txtFormNum.Text=model.FormNum;
		this.txtAss_Num.Text=model.Ass_Num;
		this.txtAss_Name.Text=model.Ass_Name;
		this.txtAss_MakeNum.Text=model.Ass_MakeNum;
		this.txtAss_Type.Text=model.Ass_Type;
		this.txtApply_Date.Text=model.Apply_Date;
		this.txtApply_Describe.Text=model.Apply_Describe;
		this.txtApply_User.Text=model.Apply_User;
		this.txtMaintain_Cause.Text=model.Maintain_Cause;
		this.txtMaintain_Describe.Text=model.Maintain_Describe;
		this.txtmaintain_User.Text=model.maintain_User;
		this.txtMaintain_Date.Text=model.Maintain_Date;
		this.txtCheck_Deseribe.Text=model.Check_Deseribe;
		this.txtCheck_Result.Text=model.Check_Result;
		this.txtCheck_Date.Text=model.Check_Date;
		this.txtCheck_User.Text=model.Check_User;
		this.txtRemarks.Text=model.Remarks;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtFormNum.Text.Trim().Length==0)
			{
				strErr+="FormNum不能为空！\\n";	
			}
			if(this.txtAss_Num.Text.Trim().Length==0)
			{
				strErr+="Ass_Num不能为空！\\n";	
			}
			if(this.txtAss_Name.Text.Trim().Length==0)
			{
				strErr+="Ass_Name不能为空！\\n";	
			}
			if(this.txtAss_MakeNum.Text.Trim().Length==0)
			{
				strErr+="Ass_MakeNum不能为空！\\n";	
			}
			if(this.txtAss_Type.Text.Trim().Length==0)
			{
				strErr+="Ass_Type不能为空！\\n";	
			}
			if(this.txtApply_Date.Text.Trim().Length==0)
			{
				strErr+="Apply_Date不能为空！\\n";	
			}
			if(this.txtApply_Describe.Text.Trim().Length==0)
			{
				strErr+="Apply_Describe不能为空！\\n";	
			}
			if(this.txtApply_User.Text.Trim().Length==0)
			{
				strErr+="Apply_User不能为空！\\n";	
			}
			if(this.txtMaintain_Cause.Text.Trim().Length==0)
			{
				strErr+="Maintain_Cause不能为空！\\n";	
			}
			if(this.txtMaintain_Describe.Text.Trim().Length==0)
			{
				strErr+="Maintain_Describe不能为空！\\n";	
			}
			if(this.txtmaintain_User.Text.Trim().Length==0)
			{
				strErr+="maintain_User不能为空！\\n";	
			}
			if(this.txtMaintain_Date.Text.Trim().Length==0)
			{
				strErr+="Maintain_Date不能为空！\\n";	
			}
			if(this.txtCheck_Deseribe.Text.Trim().Length==0)
			{
				strErr+="Check_Deseribe不能为空！\\n";	
			}
			if(this.txtCheck_Result.Text.Trim().Length==0)
			{
				strErr+="Check_Result不能为空！\\n";	
			}
			if(this.txtCheck_Date.Text.Trim().Length==0)
			{
				strErr+="Check_Date不能为空！\\n";	
			}
			if(this.txtCheck_User.Text.Trim().Length==0)
			{
				strErr+="Check_User不能为空！\\n";	
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
			decimal Mat_ID=decimal.Parse(this.lblMat_ID.Text);
			string FormNum=this.txtFormNum.Text;
			string Ass_Num=this.txtAss_Num.Text;
			string Ass_Name=this.txtAss_Name.Text;
			string Ass_MakeNum=this.txtAss_MakeNum.Text;
			string Ass_Type=this.txtAss_Type.Text;
			string Apply_Date=this.txtApply_Date.Text;
			string Apply_Describe=this.txtApply_Describe.Text;
			string Apply_User=this.txtApply_User.Text;
			string Maintain_Cause=this.txtMaintain_Cause.Text;
			string Maintain_Describe=this.txtMaintain_Describe.Text;
			string maintain_User=this.txtmaintain_User.Text;
			string Maintain_Date=this.txtMaintain_Date.Text;
			string Check_Deseribe=this.txtCheck_Deseribe.Text;
			string Check_Result=this.txtCheck_Result.Text;
			string Check_Date=this.txtCheck_Date.Text;
			string Check_User=this.txtCheck_User.Text;
			string Remarks=this.txtRemarks.Text;


			Maticsoft.Model.Equipment_Maintain model=new Maticsoft.Model.Equipment_Maintain();
			model.Mat_ID=Mat_ID;
			model.FormNum=FormNum;
			model.Ass_Num=Ass_Num;
			model.Ass_Name=Ass_Name;
			model.Ass_MakeNum=Ass_MakeNum;
			model.Ass_Type=Ass_Type;
			model.Apply_Date=Apply_Date;
			model.Apply_Describe=Apply_Describe;
			model.Apply_User=Apply_User;
			model.Maintain_Cause=Maintain_Cause;
			model.Maintain_Describe=Maintain_Describe;
			model.maintain_User=maintain_User;
			model.Maintain_Date=Maintain_Date;
			model.Check_Deseribe=Check_Deseribe;
			model.Check_Result=Check_Result;
			model.Check_Date=Check_Date;
			model.Check_User=Check_User;
			model.Remarks=Remarks;

			Maticsoft.BLL.Equipment_Maintain bll=new Maticsoft.BLL.Equipment_Maintain();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
