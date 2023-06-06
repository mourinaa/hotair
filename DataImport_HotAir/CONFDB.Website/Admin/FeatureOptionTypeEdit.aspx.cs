
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

public partial class FeatureOptionTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "FeatureOptionTypeEdit.aspx?{0}", FeatureOptionTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "FeatureOptionTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "FeatureOptionType.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewFeatureOption_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewFeatureOption.SelectedDataKey.Values[0]);
		Response.Redirect("FeatureOptionEdit.aspx?" + urlParams, true);		
	}	
}


