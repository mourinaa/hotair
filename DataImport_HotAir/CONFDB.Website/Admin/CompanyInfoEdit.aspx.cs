
#region Imports...
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
using CONFDB.Web.UI;
#endregion

public partial class CompanyInfoEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CompanyInfoEdit.aspx?{0}", CompanyInfoDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CompanyInfoEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CompanyInfo.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewCompanyLeadTracking_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewCompanyLeadTracking.SelectedDataKey.Values[0]);
		Response.Redirect("CompanyLeadTrackingEdit.aspx?" + urlParams, true);		
	}	
}


