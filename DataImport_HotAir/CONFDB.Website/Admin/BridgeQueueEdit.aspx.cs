
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

public partial class BridgeQueueEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "BridgeQueueEdit.aspx?{0}", BridgeQueueDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "BridgeQueueEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "BridgeQueue.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


