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

public partial class Admin_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    //TODO: This doesn't work because Edit page request return NULL so user is logged out.
        //    // Not what we want. Review later on.

        //    //BUGFIX: Menu control can be limited by Users/Roles but not enforced by ASP.NET
        //    // so we need to check the SiteMap global static and if the current node being accessed
        //    // is NULL then the user should be see this page. Log them out.
        //    UserSession us = new UserSession();
        //    if (us.IsAuthenicated)
        //    {
        //        if (SiteMap.CurrentNode == null)
        //        {
        //            //then user is logged in and trying to access a Menu item they can't
        //            //Sign them out.
        //            Response.Redirect("~/signout.aspx");
        //        }
        //    }

        //}
        //catch (Exception)
        //{
        //}

        if (Request.UserAgent.IndexOf("AppleWebKit") > 0)
        {
            Request.Browser.Adapters.Clear();
        } 
    }

    protected void scriptmanager1_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        scriptmanager1.AsyncPostBackErrorMessage = e.Exception.Message + e.Exception.StackTrace;
    }
}
