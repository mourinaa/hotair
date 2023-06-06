
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

public partial class AccountManagerEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AccountManagerEdit.aspx?{0}", AccountManagerDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AccountManagerEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AccountManager.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewCustomer.SelectedDataKey.Values[0]);
		Response.Redirect("CustomerEdit.aspx?" + urlParams, true);		
	}	
}


