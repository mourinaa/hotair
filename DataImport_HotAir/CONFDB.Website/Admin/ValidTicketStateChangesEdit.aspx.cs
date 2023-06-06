
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

public partial class ValidTicketStateChangesEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ValidTicketStateChangesEdit.aspx?{0}", ValidTicketStateChangesDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ValidTicketStateChangesEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ValidTicketStateChanges.aspx");
		FormUtil.SetDefaultMode(FormView1, "FromStatusId");
	}
}


