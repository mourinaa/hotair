

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

public partial class SeeVoghMeetingTracker : System.Web.UI.Page
{	
    protected void Page_Load(object sender, EventArgs e)
	{
		FormUtil.RedirectAfterUpdate(GridView1, "SeeVoghMeetingTracker.aspx?page={0}");
		FormUtil.SetPageIndex(GridView1, "page");
    }

	protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridView1.SelectedDataKey.Values[0]);
		Response.Redirect("SeeVoghMeetingTrackerEdit.aspx?" + urlParams, true);
	}
	
	
	[System.Web.Script.Services.ScriptMethod]
	[System.Web.Services.WebMethod]
	public static string GetNotesContent(string contextKey)
	{        
		System.Int32 key;
		System.Int32.TryParse(contextKey, out key);
        
        CONFDB.Entities.SeeVoghMeetingTracker content 
			= CONFDB.Data.DataRepository.SeeVoghMeetingTrackerProvider.GetById(key);
        
        if (content == null)
            return "No Content Found!";

        return string.Format("<div id='previewContent'>{0}</div>", content.Notes);
	}
}


