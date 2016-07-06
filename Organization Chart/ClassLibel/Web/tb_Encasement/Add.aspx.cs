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
namespace Maticsoft.Web.tb_Encasement
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBoxID.Text.Trim().Length==0)
			{
				strErr+="BoxID不能为空！\\n";	
			}
			if(this.txtSN.Text.Trim().Length==0)
			{
				strErr+="SN不能为空！\\n";	
			}
			if(this.txtQty.Text.Trim().Length==0)
			{
				strErr+="Qty不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string BoxID=this.txtBoxID.Text;
			string SN=this.txtSN.Text;
			string Qty=this.txtQty.Text;

			Maticsoft.Model.tb_Encasement model=new Maticsoft.Model.tb_Encasement();
			model.BoxID=BoxID;
			model.SN=SN;
			model.Qty=Qty;

			Maticsoft.BLL.tb_Encasement bll=new Maticsoft.BLL.tb_Encasement();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
