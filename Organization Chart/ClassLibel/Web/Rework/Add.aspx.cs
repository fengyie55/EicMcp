﻿using System;
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
namespace Maticsoft.Web.Rework
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtSN.Text.Trim().Length==0)
			{
				strErr+="SN不能为空！\\n";	
			}
			if(this.txtPigtailType.Text.Trim().Length==0)
			{
				strErr+="PigtailType不能为空！\\n";	
			}
			if(this.txtCount.Text.Trim().Length==0)
			{
				strErr+="Count不能为空！\\n";	
			}
			if(this.txtRejectID.Text.Trim().Length==0)
			{
				strErr+="RejectID不能为空！\\n";	
			}
			if(this.txtRejectDescribe.Text.Trim().Length==0)
			{
				strErr+="RejectDescribe不能为空！\\n";	
			}
			if(this.txtDisposeID.Text.Trim().Length==0)
			{
				strErr+="DisposeID不能为空！\\n";	
			}
			if(this.txtDisposeDescribe.Text.Trim().Length==0)
			{
				strErr+="DisposeDescribe不能为空！\\n";	
			}
			if(this.txtLength.Text.Trim().Length==0)
			{
				strErr+="Length不能为空！\\n";	
			}
			if(this.txtResult.Text.Trim().Length==0)
			{
				strErr+="Result不能为空！\\n";	
			}
			if(this.txtReworkID.Text.Trim().Length==0)
			{
				strErr+="ReworkID不能为空！\\n";	
			}
			if(this.txtVerifyID.Text.Trim().Length==0)
			{
				strErr+="VerifyID不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string SN=this.txtSN.Text;
			string PigtailType=this.txtPigtailType.Text;
			string Count=this.txtCount.Text;
			string RejectID=this.txtRejectID.Text;
			string RejectDescribe=this.txtRejectDescribe.Text;
			string DisposeID=this.txtDisposeID.Text;
			string DisposeDescribe=this.txtDisposeDescribe.Text;
			string Length=this.txtLength.Text;
			string Result=this.txtResult.Text;
			string ReworkID=this.txtReworkID.Text;
			string VerifyID=this.txtVerifyID.Text;

			Maticsoft.Model.Rework model=new Maticsoft.Model.Rework();
			model.SN=SN;
			model.PigtailType=PigtailType;
			model.Count=Count;
			model.RejectID=RejectID;
			model.RejectDescribe=RejectDescribe;
			model.DisposeID=DisposeID;
			model.DisposeDescribe=DisposeDescribe;
			model.Length=Length;
			model.Result=Result;
			model.ReworkID=ReworkID;
			model.VerifyID=VerifyID;

			Maticsoft.BLL.Rework bll=new Maticsoft.BLL.Rework();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
