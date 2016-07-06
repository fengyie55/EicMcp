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
namespace Maticsoft.Web.Lapping_Receive
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal Lp_ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(Lp_ID);
				}
			}
		}
			
	private void ShowInfo(decimal Lp_ID)
	{
		Maticsoft.BLL.Lapping_Receive bll=new Maticsoft.BLL.Lapping_Receive();
		Maticsoft.Model.Lapping_Receive model=bll.GetModel(Lp_ID);
		this.lblLp_ID.Text=model.Lp_ID.ToString();
		this.txtCount.Text=model.Count;
		this.txtReceiveUserID.Text=model.ReceiveUserID;
		this.txtSendUserID.Text=model.SendUserID;
		this.txtLappingReceiveID.Text=model.LappingReceiveID;
		this.txtDataTime.Text=model.DataTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtCount.Text.Trim().Length==0)
			{
				strErr+="Count不能为空！\\n";	
			}
			if(this.txtReceiveUserID.Text.Trim().Length==0)
			{
				strErr+="ReceiveUserID不能为空！\\n";	
			}
			if(this.txtSendUserID.Text.Trim().Length==0)
			{
				strErr+="SendUserID不能为空！\\n";	
			}
			if(this.txtLappingReceiveID.Text.Trim().Length==0)
			{
				strErr+="LappingReceiveID不能为空！\\n";	
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
			decimal Lp_ID=decimal.Parse(this.lblLp_ID.Text);
			string Count=this.txtCount.Text;
			string ReceiveUserID=this.txtReceiveUserID.Text;
			string SendUserID=this.txtSendUserID.Text;
			string LappingReceiveID=this.txtLappingReceiveID.Text;
			DateTime DataTime=DateTime.Parse(this.txtDataTime.Text);


			Maticsoft.Model.Lapping_Receive model=new Maticsoft.Model.Lapping_Receive();
			model.Lp_ID=Lp_ID;
			model.Count=Count;
			model.ReceiveUserID=ReceiveUserID;
			model.SendUserID=SendUserID;
			model.LappingReceiveID=LappingReceiveID;
			model.DataTime=DataTime;

			Maticsoft.BLL.Lapping_Receive bll=new Maticsoft.BLL.Lapping_Receive();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
