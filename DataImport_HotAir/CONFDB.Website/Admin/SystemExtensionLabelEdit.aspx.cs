
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

public partial class SystemExtensionLabelEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "SystemExtensionLabelEdit.aspx?{0}", SystemExtensionLabelDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "SystemExtensionLabelEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "SystemExtensionLabel.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewSystemExtension_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewSystemExtension.SelectedDataKey.Values[0]);
		Response.Redirect("SystemExtensionEdit.aspx?" + urlParams, true);		
	}	
}


