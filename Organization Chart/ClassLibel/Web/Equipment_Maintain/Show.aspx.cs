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
namespace Maticsoft.Web.Equipment_Maintain
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					decimal Mat_ID=(Convert.ToDecimal(strid));
					ShowInfo(Mat_ID);
				}
			}
		}
		
	private void ShowInfo(decimal Mat_ID)
	{
		Maticsoft.BLL.Equipment_Maintain bll=new Maticsoft.BLL.Equipment_Maintain();
		Maticsoft.Model.Equipment_Maintain model=bll.GetModel(Mat_ID);
		this.lblMat_ID.Text=model.Mat_ID.ToString();
		this.lblFormNum.Text=model.FormNum;
		this.lblAss_Num.Text=model.Ass_Num;
		this.lblAss_Name.Text=model.Ass_Name;
		this.lblAss_MakeNum.Text=model.Ass_MakeNum;
		this.lblAss_Type.Text=model.Ass_Type;
		this.lblApply_Date.Text=model.Apply_Date;
		this.lblApply_Describe.Text=model.Apply_Describe;
		this.lblApply_User.Text=model.Apply_User;
		this.lblMaintain_Cause.Text=model.Maintain_Cause;
		this.lblMaintain_Describe.Text=model.Maintain_Describe;
		this.lblmaintain_User.Text=model.maintain_User;
		this.lblMaintain_Date.Text=model.Maintain_Date;
		this.lblCheck_Deseribe.Text=model.Check_Deseribe;
		this.lblCheck_Result.Text=model.Check_Result;
		this.lblCheck_Date.Text=model.Check_Date;
		this.lblCheck_User.Text=model.Check_User;
		this.lblRemarks.Text=model.Remarks;

	}


    }
}
