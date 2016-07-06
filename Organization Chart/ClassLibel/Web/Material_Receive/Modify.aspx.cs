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
namespace Maticsoft.Web.Material_Receive
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal Re_ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(Re_ID);
				}
			}
		}
			
	private void ShowInfo(decimal Re_ID)
	{
		Maticsoft.BLL.Material_Receive bll=new Maticsoft.BLL.Material_Receive();
		Maticsoft.Model.Material_Receive model=bll.GetModel(Re_ID);
		this.lblRe_ID.Text=model.Re_ID.ToString();
		this.txtReceiveID.Text=model.ReceiveID;
		this.txtMaterialNum.Text=model.MaterialNum;
		this.txtClientNum.Text=model.ClientNum;
		this.txtCount.Text=model.Count;
		this.txtUserID.Text=model.UserID;
		this.txtWorkStationID.Text=model.WorkStationID;
		this.txtDataTime.Text=model.DataTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtReceiveID.Text.Trim().Length==0)
			{
				strErr+="ReceiveID不能为空！\\n";	
			}
			if(this.txtMaterialNum.Text.Trim().Length==0)
			{
				strErr+="MaterialNum不能为空！\\n";	
			}
			if(this.txtClientNum.Text.Trim().Length==0)
			{
				strErr+="ClientNum不能为空！\\n";	
			}
			if(this.txtCount.Text.Trim().Length==0)
			{
				strErr+="Count不能为空！\\n";	
			}
			if(this.txtUserID.Text.Trim().Length==0)
			{
				strErr+="UserID不能为空！\\n";	
			}
			if(this.txtWorkStationID.Text.Trim().Length==0)
			{
				strErr+="WorkStationID不能为空！\\n";	
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
			decimal Re_ID=decimal.Parse(this.lblRe_ID.Text);
			string ReceiveID=this.txtReceiveID.Text;
			string MaterialNum=this.txtMaterialNum.Text;
			string ClientNum=this.txtClientNum.Text;
			string Count=this.txtCount.Text;
			string UserID=this.txtUserID.Text;
			string WorkStationID=this.txtWorkStationID.Text;
			DateTime DataTime=DateTime.Parse(this.txtDataTime.Text);


			Maticsoft.Model.Material_Receive model=new Maticsoft.Model.Material_Receive();
			model.Re_ID=Re_ID;
			model.ReceiveID=ReceiveID;
			model.MaterialNum=MaterialNum;
			model.ClientNum=ClientNum;
			model.Count=Count;
			model.UserID=UserID;
			model.WorkStationID=WorkStationID;
			model.DataTime=DataTime;

			Maticsoft.BLL.Material_Receive bll=new Maticsoft.BLL.Material_Receive();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
