

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

public partial class ConferencingSummary : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "ConferencingSummary.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("BilledDate={0}&ProductId={1}&Currency={2}", GridView1.SelectedDataKey.Values[0], GridView1.SelectedDataKey.Values[1], GridView1.SelectedDataKey.Values[2]);
		Response.Redirect("ConferencingSummaryEdit.aspx?" + urlParams, true);
	}
	
}


