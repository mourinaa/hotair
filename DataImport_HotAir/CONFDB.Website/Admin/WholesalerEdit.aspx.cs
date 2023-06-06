
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
        FormUtil.RedirectAfterInsertUpdate(FormView1, "WholesalerEdit.aspx?{0}", WholesalerDataSource);
        FormUtil.RedirectAfterAddNew(FormView1, "WholesalerEdit.aspx");
        FormUtil.RedirectAfterCancel(FormView1, "Wholesaler.aspx");
        FormUtil.SetDefaultMode(FormView1, "Id");
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    /// <summary>
    /// Used to bind the data for data sources and data controls.
    /// </summary>
    public void BindData()
    {
        //Setup the User Controls and databind them. 
        // NOTE: Not required for DNIS UC as it is a based on a DataSource control pattern which handles data binding.
        ucProductRatesWS.WholesalerID = FormUtil.GetRequestParameter("Id",null);
        ucProductRatesWS.BindData();
        ucFeaturesWS.WholesalerID = FormUtil.GetRequestParameter("Id", null);
        ucFeaturesWS.BindData();

    }

    protected void GridViewEmailTemplate_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewEmailTemplate.SelectedDataKey.Values[0]);
		Response.Redirect("EmailTemplateEdit.aspx?" + urlParams, true);		
	}

    protected void GridViewWholesaler_Product_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewWholesaler_Product.SelectedDataKey.Values[0]);
        Response.Redirect("Wholesaler_ProductEdit.aspx?" + urlParams, true);
    }	

    //protected void GridViewProductRateValue_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string urlParams = string.Format("Id={0}", GridViewProductRateValue.SelectedDataKey.Values[0]);
    //    Response.Redirect("ProductRateValueEdit.aspx?" + urlParams, true);		
    //}	
    //protected void GridViewDnis_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string urlParams = string.Format("Id={0}", GridViewDnis.SelectedDataKey.Values[0]);
    //    Response.Redirect("DnisEdit.aspx?" + urlParams, true);		
    //}	
}


