
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

public partial class ProductTypeEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ProductTypeEdit.aspx?{0}", ProductTypeDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ProductTypeEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ProductType.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewProduct_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewProduct.SelectedDataKey.Values[0]);
		Response.Redirect("ProductEdit.aspx?" + urlParams, true);		
	}	
}


