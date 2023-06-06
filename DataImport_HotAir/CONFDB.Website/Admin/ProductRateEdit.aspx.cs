
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

public partial class ProductRateEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "ProductRateEdit.aspx?{0}", ProductRateDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "ProductRateEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "ProductRate.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewAccessType_ProductRate_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewAccessType_ProductRate.SelectedDataKey.Values[0]);
		Response.Redirect("AccessType_ProductRateEdit.aspx?" + urlParams, true);		
	}

    protected void ProductRateDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        ////stupid NTiers is passing NULL instead of empty string so have to intercept it and change it
        //if (e.InputParameters["CountryId"] == null)
        //{
        //    e.InputParameters["CountryId"] = string.Empty;
        //}
    }
}


