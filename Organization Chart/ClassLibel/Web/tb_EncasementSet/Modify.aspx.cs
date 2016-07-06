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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					decimal ID=(Convert.ToDecimal(Request.Params["id"]));
					ShowInfo(ID);
				}
			}
		}
			
	private void ShowInfo(decimal ID)
	{
		Maticsoft.BLL.tb_EncasementSet bll=new Maticsoft.BLL.tb_EncasementSet();
		Maticsoft.Model.tb_EncasementSet model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.txtBatchNo.Text=model.BatchNo;
		this.txtDevice.Text=model.Device;
		this.txtDeviceQty.Text=model.DeviceQty;
		this.txtSqckQty.Text=model.SqckQty;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			decimal ID=decimal.Parse(this.lblID.Text);
			string BatchNo=this.txtBatchNo.Text;
			string Device=this.txtDevice.Text;
			string DeviceQty=this.txtDeviceQty.Text;
			string SqckQty=this.txtSqckQty.Text;


			Maticsoft.Model.tb_EncasementSet model=new Maticsoft.Model.tb_EncasementSet();
			model.ID=ID;
			model.BatchNo=BatchNo;
			model.Device=Device;
			model.DeviceQty=DeviceQty;
			model.SqckQty=SqckQty;

			Maticsoft.BLL.tb_EncasementSet bll=new Maticsoft.BLL.tb_EncasementSet();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
