
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

public partial class AccessTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "AccessTypeEdit.aspx?{0}", AccessTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "AccessTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "AccessType.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewDnis_SelectedIndexChanged(object sender, EventArgs e)
	{
        string urlParams = string.Format("Id={0}", GridViewDnis.SelectedDataKey.Values[0]);
        Response.Redirect("DnisEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewAccessType_ProductRate_SelectedIndexChanged(object sender, EventArgs e)
	{
        string urlParams = string.Format("Id={0}", GridViewAccessType_ProductRate.SelectedDataKey.Values[0]);
        Response.Redirect("AccessType_ProductRateEdit.aspx?" + urlParams, true);		
	}	
}


