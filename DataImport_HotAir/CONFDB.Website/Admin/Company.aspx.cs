

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

public partial class Company : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
        //Added a check to restrict Sales Agents and less permissions
        SetPermissions();

		FormUtil.RedirectAfterUpdate(GridView1, "Company.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
        if (!Page.IsPostBack)
        {
            //set the default binding filter, not the best way to do it but required as GetPaged can only be used by SearchPanel.
            GridViewSearchPanel1.Filter = string.Format("WholesalerID = '{0}'", ConfigurationManager.AppSettings["WholesalerID"]);
            GridViewSearchPanel1.DataBind();
        }
    }

    /// <summary>
    /// Used to set the security permissions
    /// </summary>
    protected void SetPermissions()
    {
        //Any Mode
        //If the SalesPersonID is set for the user then set the Sales Person list to specific SP
        UserSession us = new UserSession();
        if (!us.IsAuthenicated)
        {
            us.LogOff();//stops all process and logs user out
        }

        //Sales Agents and less can't add or update
        if (us.UserLevel <= 50)
        {
            Response.Redirect("~/Admin/AccessDenied.aspx", true);
        }
    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("CompanyEdit.aspx?" + urlParams, true);
	}

    protected void GridViewSearchPanel1_SearchButtonClicked(object sender, EventArgs e)
    {
        GridViewSearchPanel1.Filter = string.Format("WholesalerID = '{0}'", ConfigurationManager.AppSettings["WholesalerID"]);
        GridViewSearchPanel1.DataBind();
    }		
}


