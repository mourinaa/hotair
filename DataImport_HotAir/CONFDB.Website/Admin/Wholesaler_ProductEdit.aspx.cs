
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
using CONFDB.Entities;
using CONFDB.Services;

#endregion

public partial class Wholesaler_ProductEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "Wholesaler_ProductEdit.aspx?{0}", Wholesaler_ProductDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "Wholesaler_ProductEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Wholesaler_Product.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewWholesaler_Product_Feature_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewWholesaler_Product_Feature.SelectedDataKey.Values[0]);
		Response.Redirect("Wholesaler_Product_FeatureEdit.aspx?" + urlParams, true);		
	}
    /// <summary>
    /// After the Wholesaler_Product is added, Install the Defaults.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Wholesaler_ProductDataSource_AfterInserted(object sender, CONFDB.Web.Data.LinkedDataSourceEventArgs e)
    {
        //Get the inserted object from the args.
        Wholesaler_Product WP = (Wholesaler_Product)e.Entity;
        //Copy the defaults down.
        Wholesaler_ProductService WPS = new Wholesaler_ProductService();
        WPS.InstallDefaults(WP.Id, WP.ProductId, WP.WholesalerId);

        //Push Rates down to everyone
        UtilService utilService = new UtilService();
        utilService.PushProductRatesThatDontExistToWholesalerAndAll(WP.WholesalerId, true, true, WP.ProductId);

        //Push Features down to everyone
        utilService.PushFeatureThatDontExistToWholesalerAndAll(WP.WholesalerId, true, true, true);

    }
}


