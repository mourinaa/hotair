
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

public partial class CharityEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CharityEdit.aspx?{0}", CharityDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CharityEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Charity.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewUser_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("UserId={0}", GridViewUser.SelectedDataKey.Values[0]);
		Response.Redirect("UserEdit.aspx?" + urlParams, true);		
	}	
}


