
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

public partial class ExtensionTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ExtensionTypeEdit.aspx?{0}", ExtensionTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ExtensionTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ExtensionType.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewSystemExtensionLabel_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewSystemExtensionLabel.SelectedDataKey.Values[0]);
		Response.Redirect("SystemExtensionLabelEdit.aspx?" + urlParams, true);		
	}	
}


