﻿
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

public partial class BillableLegsEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "BillableLegsEdit.aspx?{0}", BillableLegsDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "BillableLegsEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "BillableLegs.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
}


