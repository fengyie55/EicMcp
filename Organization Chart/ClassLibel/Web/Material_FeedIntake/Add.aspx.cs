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
namespace Maticsoft.Web.Material_FeedIntake
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDecimal(txtFe_ID.Text))
			{
				strErr+="Fe_ID格式错误！\\n";	
			}
			if(this.txtFeedIntakeID.Text.Trim().Length==0)
			{
				strErr+="FeedIntakeID不能为空！\\n";	
			}
			if(this.txtMaterialNum.Text.Trim().Length==0)
			{
				strErr+="MaterialNum不能为空！\\n";	
			}
			if(this.txtCount.Text.Trim().Length==0)
			{
				strErr+="Count不能为空！\\n";	
			}
			if(this.txtUserID.Text.Trim().Length==0)
			{
				strErr+="UserID不能为空！\\n";	
			}
			if(this.txtWorkstationID.Text.Trim().Length==0)
			{
				strErr+="WorkstationID不能为空！\\n";	
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
			decimal Fe_ID=decimal.Parse(this.txtFe_ID.Text);
			string FeedIntakeID=this.txtFeedIntakeID.Text;
			string MaterialNum=this.txtMaterialNum.Text;
			string Count=this.txtCount.Text;
			string UserID=this.txtUserID.Text;
			string WorkstationID=this.txtWorkstationID.Text;
			DateTime DataTime=DateTime.Parse(this.txtDataTime.Text);

			Maticsoft.Model.Material_FeedIntake model=new Maticsoft.Model.Material_FeedIntake();
			model.Fe_ID=Fe_ID;
			model.FeedIntakeID=FeedIntakeID;
			model.MaterialNum=MaterialNum;
			model.Count=Count;
			model.UserID=UserID;
			model.WorkstationID=WorkstationID;
			model.DataTime=DataTime;

			Maticsoft.BLL.Material_FeedIntake bll=new Maticsoft.BLL.Material_FeedIntake();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
