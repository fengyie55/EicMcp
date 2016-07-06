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
namespace Maticsoft.Web.tb_EncasementSet
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBatchNo.Text.Trim().Length==0)
			{
				strErr+="BatchNo不能为空！\\n";	
			}
			if(this.txtDevice.Text.Trim().Length==0)
			{
				strErr+="Device不能为空！\\n";	
			}
			if(this.txtDeviceQty.Text.Trim().Length==0)
			{
				strErr+="DeviceQty不能为空！\\n";	
			}
			if(this.txtSqckQty.Text.Trim().Length==0)
			{
				strErr+="SqckQty不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string BatchNo=this.txtBatchNo.Text;
			string Device=this.txtDevice.Text;
			string DeviceQty=this.txtDeviceQty.Text;
			string SqckQty=this.txtSqckQty.Text;

			Maticsoft.Model.tb_EncasementSet model=new Maticsoft.Model.tb_EncasementSet();
			model.BatchNo=BatchNo;
			model.Device=Device;
			model.DeviceQty=DeviceQty;
			model.SqckQty=SqckQty;

			Maticsoft.BLL.tb_EncasementSet bll=new Maticsoft.BLL.tb_EncasementSet();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
