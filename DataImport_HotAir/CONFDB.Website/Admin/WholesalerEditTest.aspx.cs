
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

public partial class WholesalerEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
        ////MOD LR: only support Edits here
        ////FormUtil.RedirectAfterInsertUpdate(FormView1, "WholesalerEdit.aspx?{0}", WholesalerDataSource);
        //FormUtil.RedirectAfterUpdate(FormView1, "WholesalerEdit.aspx", WholesalerDataSource);
        ////FormUtil.RedirectAfterAddNew(FormView1, "WholesalerEdit.aspx");
        //FormUtil.RedirectAfterCancel(FormView1, "WholesalerEdit.aspx");
        ////FormUtil.SetDefaultMode(FormView1, "Id");//MOD LR: Default is Insert mode, change to Edit

        FormUtil.RedirectAfterInsertUpdate(FormView1, "WholesalerEdit.aspx?{0}", WholesalerDataSource);
        FormUtil.RedirectAfterAddNew(FormView1, "WholesalerEdit.aspx");
        FormUtil.RedirectAfterCancel(FormView1, "Wholesaler.aspx");
        FormUtil.SetDefaultMode(FormView1, "Id");
	}

	protected void GridViewDnis_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewDnis.SelectedDataKey.Values[0]);
		Response.Redirect("DnisEdit.aspx?" + urlParams, true);		
	}	
}


