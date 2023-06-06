
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

public partial class TicketUserAssociationsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "TicketUserAssociationsEdit.aspx?{0}", TicketUserAssociationsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "TicketUserAssociationsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "TicketUserAssociations.aspx");
		FormUtil.SetDefaultMode(FormView1, "UserId");
	}
}


