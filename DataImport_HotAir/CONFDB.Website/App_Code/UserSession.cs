using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CONFDB.Data;
using CONFDB.Entities;

/// <summary>
/// Summary description for UserSession
/// Contains user profile information and properties used to pass information from one web page to another.
/// </summary>
/// <remarks>
/// The class wraps around the HTTP Session object to store its information.
/// </remarks>
public class UserSession
{
    private struct Const
    {
        public const string EmailRecordingNotifications = "EmailRecordingNotifications";
        public const string EmailRecordingNotificationsSeconds = "EmailRecordingNotificationsSeconds";
        public const string SendEmailNotifications = "SendEmailNotifications";
        public const string SendEmailNotificationsSeconds = "SendEmailNotificationsSeconds";
        //Used to skip over sending if already in progress
        public const string SendingRecordings = "SendingRecordings";
        public const string SendingEmails = "SendingEmails";
    }

    System.Web.SessionState.HttpSessionState _Session;

    public UserSession()
    {
        //Grap the current users session
        _Session = HttpContext.Current.Session;

    }

    /// <summary>
    /// Used to authenticate the User and sets up the session cookie correctly.
    /// </summary>
    /// <remarks>
    /// Generate the authentication ticket, encrypt it, create a cookie, add it to the response,
    /// and redirect the user. This gives you more control in how you create the cookie. 
    /// TODO: You can also include custom data along with the FormsAuthenticationTicket in this case.
    /// </remarks>
    /// <param name="UserName"></param>
    /// <param name="Password"></param>
    /// <returns></returns>
    public bool AuthenticateUser(string UserName)
    {
        User user = DataRepository.UserProvider.GetByUsername(UserName);

        //NOTE: Similar to this: http://support.microsoft.com/kb/301240/EN-US/
        // Create the authentication ticket
        FormsAuthenticationTicket authTicket = new
            FormsAuthenticationTicket(1,// version
            UserName,// user name
            DateTime.Now,//	creation
            DateTime.Now.AddMinutes(60),//Expiration
            false,                      //Persistent
            ""   //User data
            );
        // Now encrypt the ticket.
        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

        // Create a cookie and add the encrypted ticket to the
        // cookie as data.
        HttpCookie authCookie =
            new HttpCookie(FormsAuthentication.FormsCookieName,
            encryptedTicket);

        // Add the cookie to the outgoing cookies collection.
        HttpContext.Current.Response.Cookies.Add(authCookie);

        //Load Users Info
        //Deepload items
        DataRepository.UserProvider.DeepLoad(user, false, DeepLoadType.IncludeChildren, typeof(Role));

        //User valid, so store the user object and some info
        _Session["user"] = user;

        _Session["userid"] = user.UserId;
        _Session["salespersonid"] = user.SalesPersonId;
        _Session["rolename"] = user.RoleIdSource.Name;
        _Session["roleid"] = user.RoleIdSource.Id;
        _Session["userlevel"] = user.RoleIdSource.UserLevel;
        //Adding CustomerID but it doesn't store anything
        _Session["customerid"] = -1;
        return true;

    }

    public string LoginName
    {
        get
        {
            return HttpContext.Current.User.Identity.Name;
        }
    }

    public bool IsAuthenicated
    {
        get
        {
            try
            {
                return HttpContext.Current.User.Identity.IsAuthenticated;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public User UserProfile
    {
        get
        {
            try
            {
                User user = _Session["user"] as User;
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public int? UserID
    {
        get
        {
            return (int)(_Session["userid"] ?? null);
        }
    }

    public int? SalesPersonID
    {
        get
        {
            try
            {
                return (int)_Session["salespersonid"];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public string RoleName
    {
        get
        {
            try
            {
                return _Session["rolename"] as string;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public int? RoleID
    {
        get
        {
            try
            {
                return (int)_Session["roleid"];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Used with the Users Role to provide logic based on levels.
    /// </summary>
    public int? UserLevel
    {
        get
        {
            try
            {
                return (int)_Session["userlevel"];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public int? CustomerID
    {
        get
        {
            try
            {
                return (int)_Session["customerid"];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public void LogOff()
    {
        _Session.Clear();
        _Session.Abandon();
        HttpContext.Current.Response.Redirect("~/signout.aspx");

    }
}
