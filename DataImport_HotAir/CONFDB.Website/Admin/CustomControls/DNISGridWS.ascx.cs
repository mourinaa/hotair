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

/// <summary>
/// Used to display the DNIS numbers to the Wholesalers on a couple of different pages.
/// </summary>
public partial class DNISGridWS : System.Web.UI.UserControl
{  
    private bool _Visible = true;

    public bool Visible
    {
        get { return _Visible; }
        set { _Visible = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //FormUtil.RedirectAfterUpdate(GridViewDnisWholesaler, "Dnis.aspx?page={0}");
        FormUtil.SetPageIndex(GridViewDnisWholesaler, "page");
        if (!Page.IsPostBack)
        {
            ////set the default binding filter, not the best way to do it but required as GetPaged can only be used by SearchPanel.
            //GridViewSearchPanel1.Filter = string.Format("WholesalerID = '{0}'", ConfigurationManager.AppSettings["WholesalerID"]);
            //GridViewSearchPanel1.DataBind();
        }
    }

    protected void GridViewDnisWholesaler_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewDnisWholesaler.SelectedDataKey.Values[0]);
        Response.Redirect("DnisEdit.aspx?" + urlParams, true);
    }

    //protected void GridViewSearchPanel1_SearchButtonClicked(object sender, EventArgs e)
    //{
    //    GridViewSearchPanel1.Filter = string.Format("WholesalerID = '{0}'", ConfigurationManager.AppSettings["WholesalerID"]);
    //    GridViewSearchPanel1.DataBind();
    //}



}
