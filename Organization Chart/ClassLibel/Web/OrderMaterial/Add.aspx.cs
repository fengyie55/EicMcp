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
namespace Maticsoft.Web.OrderMaterial
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDecimal(txtOrm_ID.Text))
			{
				strErr+="Orm_ID格式错误！\\n";	
			}
			if(this.txtMaterialID.Text.Trim().Length==0)
			{
				strErr+="MaterialID不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSendCount.Text))
			{
				strErr+="SendCount格式错误！\\n";	
			}
			if(this.txtOrderID.Text.Trim().Length==0)
			{
				strErr+="OrderID不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			decimal Orm_ID=decimal.Parse(this.txtOrm_ID.Text);
			string MaterialID=this.txtMaterialID.Text;
			int SendCount=int.Parse(this.txtSendCount.Text);
			string OrderID=this.txtOrderID.Text;

			Maticsoft.Model.OrderMaterial model=new Maticsoft.Model.OrderMaterial();
			model.Orm_ID=Orm_ID;
			model.MaterialID=MaterialID;
			model.SendCount=SendCount;
			model.OrderID=OrderID;

			Maticsoft.BLL.OrderMaterial bll=new Maticsoft.BLL.OrderMaterial();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
