
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

public partial class LanguageEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "LanguageEdit.aspx?{0}", LanguageDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "LanguageEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Language.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewCustomerDocument_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewCustomerDocument.SelectedDataKey.Values[0]);
		Response.Redirect("CustomerDocumentEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewEmailTemplate_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewEmailTemplate.SelectedDataKey.Values[0]);
		Response.Redirect("EmailTemplateEdit.aspx?" + urlParams, true);		
	}	
}


