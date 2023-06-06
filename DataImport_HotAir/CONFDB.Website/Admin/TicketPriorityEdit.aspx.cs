
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

public partial class TicketPriorityEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "TicketPriorityEdit.aspx?{0}", TicketPriorityDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "TicketPriorityEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "TicketPriority.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewTicket_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewTicket.SelectedDataKey.Values[0]);
		Response.Redirect("TicketEdit.aspx?" + urlParams, true);		
	}	
}


