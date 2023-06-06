
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

public partial class CompanyLeadTrackingNotesEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CompanyLeadTrackingNotesEdit.aspx?{0}", CompanyLeadTrackingNotesDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CompanyLeadTrackingNotesEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "CompanyLeadTrackingNotes.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


