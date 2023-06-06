
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

public partial class BridgeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "BridgeEdit.aspx?{0}", BridgeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "BridgeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Bridge.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewBridgeQueue_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewBridgeQueue.SelectedDataKey.Values[0]);
		Response.Redirect("BridgeQueueEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewRatedCdr_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewRatedCdr.SelectedDataKey.Values[0]);
		Response.Redirect("RatedCdrEdit.aspx?" + urlParams, true);		
	}	
}


