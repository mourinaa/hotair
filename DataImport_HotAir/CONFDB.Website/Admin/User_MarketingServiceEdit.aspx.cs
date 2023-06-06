
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

public partial class User_MarketingServiceEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "User_MarketingServiceEdit.aspx?{0}", User_MarketingServiceDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "User_MarketingServiceEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "User_MarketingService.aspx");
		FormUtil.SetDefaultMode(FormView1, "MarketingServiceId");
	}
}


