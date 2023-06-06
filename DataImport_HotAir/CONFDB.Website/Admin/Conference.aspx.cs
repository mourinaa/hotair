

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

public partial class Conference : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "Conference.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
        //set the default binding filter, not the best way to do it but required as GetPaged can only be used by SearchPanel.
        //also limit the list based on SalePersonID of the User or if it is Null (means can see all) then don't filter by this
        string filter;
        UserSession us = new UserSession();
        if (us.SalesPersonID != null)
        {
            filter = string.Format("WholesalerID = '{0}' AND SalesPersonID = {1}",
                ConfigurationManager.AppSettings["WholesalerID"], us.SalesPersonID);
        }
        else
        {
            filter = string.Format("WholesalerID = '{0}'", ConfigurationManager.AppSettings["WholesalerID"]);
        }
        GridViewSearchPanel1.Filter = filter;
        GridViewSearchPanel1.DataBind();

    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("ConferenceEdit.aspx?" + urlParams, true);
	}
	
}


