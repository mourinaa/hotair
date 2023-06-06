

#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CONFDB.Web.UI;
#endregion

public partial class Vertical : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
        //FormUtil.RedirectAfterUpdate(GridView1, "Vertical.aspx?page={0}");
        FormUtil.RedirectAfterUpdate(GridView1, "Vertical.aspx"); //show all as default
		FormUtil.SetPageIndex(GridView1, "page");
        if (!Page.IsPostBack)
        {
            //set the default binding filter, not the best way to do it but required as GetPaged can only be used by SearchPanel.
            GridViewSearchPanel1.Filter = string.Format("WholesalerID = '{0}'", ConfigurationManager.AppSettings["WholesalerID"]);
            GridViewSearchPanel1.DataBind();

        }
    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("VerticalEdit.aspx?" + urlParams, true);
	}

    protected void GridViewSearchPanel1_SearchButtonClicked(object sender, EventArgs e)
    {
        GridViewSearchPanel1.Filter = string.Format("WholesalerID = '{0}'", ConfigurationManager.AppSettings["WholesalerID"]);
        GridViewSearchPanel1.DataBind();
    }
}


