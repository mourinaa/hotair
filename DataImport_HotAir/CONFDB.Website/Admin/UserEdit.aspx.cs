
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

public partial class UserEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "UserEdit.aspx?{0}", UserDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "UserEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "User.aspx");
		FormUtil.SetDefaultMode(FormView1, "UserId");
	}
    protected void GridViewModerator_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewModerator.SelectedDataKey.Values[0]);
        Response.Redirect("ModeratorEdit.aspx?" + urlParams, true);
    }
    protected void GridViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewCustomer.SelectedDataKey.Values[0]);
        Response.Redirect("CustomerEdit.aspx?" + urlParams, true);
    }	
    //protected void GridViewEventManager_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string urlParams = string.Format("Id={0}", GridViewEventManager.SelectedDataKey.Values[0]);
    //    Response.Redirect("EventManagerEdit.aspx?" + urlParams, true);		
    //}	
}


