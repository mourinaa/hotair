
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

public partial class SystemSettingsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SystemSettingsEdit.aspx?{0}", SystemSettingsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SystemSettingsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SystemSettings.aspx");
		FormUtil.SetDefaultMode(FormView1, "Name");
	}
}


