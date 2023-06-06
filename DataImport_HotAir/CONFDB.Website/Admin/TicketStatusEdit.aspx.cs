
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

public partial class TicketStatusEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "TicketStatusEdit.aspx?{0}", TicketStatusDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "TicketStatusEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "TicketStatus.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewTicketStatusHistory_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("TicketId={0}", GridViewTicketStatusHistory.SelectedDataKey.Values[0]);
		Response.Redirect("TicketStatusHistoryEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewTicket_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewTicket.SelectedDataKey.Values[0]);
		Response.Redirect("TicketEdit.aspx?" + urlParams, true);		
	}	
}


