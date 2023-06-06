using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace AdminSite
{
    /// <summary>
    /// NOTE: DOESN'T WORK AS IT SHOWS TOO MUCH. LEFT HERE AS A SAMPLE.
    /// Had to override some basic functionality of the XML SiteMap Provider as nodes were being shown to Roles
    /// that shouldn't see them. At the root level the XMLSiteMap "security trimmings" works but not on child nodes
    /// where a list of roles is specified.
    /// Used these posts to figure it all out:
    /// Feedback web.sitemap ignores Roles attributes
    /// http://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=102168
    /// Custom Site Map Provider - Role Based Security
    /// http://www.blazeapps.com/Default.aspx?pid=blg_blogviewer&id=C675FAC2-781D-4191-8FED-8D5E1D99A149
    /// Changes to make to reference this class from the web.config
    /// http://p2p.wrox.com/book-professional-asp-net-2-0-security-membership-role-management-isbn-978-0-7645-9698-8/65459-implementing-custom-xmlsitemapprovider.html
    /// 
    /// </summary>
    public class AdminSiteXMLSiteMapProvider : XmlSiteMapProvider
    {
        //public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        //{
        //    //Check to see if the node has roles associated to it.  If not allow access to that node
        //    if (node.Roles != null)
        //    {
        //        //Check to see if the user is authenticated.  If not do not allow access to a secured node
        //        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            //Loop through the roles associated to the node and see if the user belongs to any of them
        //            for (int i = 0; i <= node.Roles.Count; i++)
        //            {
        //                //If they are in the role return true
        //                return Roles.IsUserInRole(node.Roles[i].ToString().Trim());
        //            }
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

    //    public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
    //    {
    //        try
    //        {
    //            //Check to see if the node has roles associated to it.  If not, allow access as it allows for sub-nodes
    //            // to be seen without a "roles" element defined. In essence, the parent info is used.
    //            if (node.Roles != null)
    //            {
    //                //Check to see if the user is authenticated.  If not do not allow access to a secured node
    //                if (!HttpContext.Current.User.Identity.IsAuthenticated)
    //                {
    //                    return false;
    //                }
    //                else
    //                {
    //                    //Loop through the roles associated to the node and see if the user belongs to any of them
    //                    for (int i = 0; i <= node.Roles.Count; i++)
    //                    {
    //                        string UserName = HttpContext.Current.User.Identity.Name;
    //                        string Role = node.Roles[i].ToString().Trim();

    //                        ///Add check here for * roles, which means let everyone see it. Placed the logic
    //                        ///here as this is a SiteMap Provider thing so I didn't want to place it in the Roles provider
    //                        ///but we could have done that too. Just change the Roles.IsUserInRole() to check for the * role
    //                        if (Role == "*")
    //                        {
    //                            return true;
    //                        }
    //                        if (string.IsNullOrEmpty(Role))
    //                        {
    //                            //"role" is defined but blank so this should be hidden from the user, remove it from showing
    //                            base.RemoveNode(node);
    //                            return false;
    //                        }

    //                        //If they are in the role return true
    //                        if (Roles.IsUserInRole(UserName, Role))
    //                        {
    //                            return true;
    //                        }
    //                    }
    //                    return false;
    //                }
    //            }
    //            else
    //            {
    //                return true;
    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            //usually due to the "role" not being there so return true as it is usually a child node case and should be 
    //            // shown except if explicitly denied. i.e. "roles = XXX"
    //            return true;
    //            //throw ex;
    //        }
    //    }
    }
}