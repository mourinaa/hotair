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
using CONFDB.Data;
using CONFDB.Entities;

public partial class signon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session.Clear();
            Session.Abandon();
        }
        catch (Exception)
        {
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string UserName = txtBoxUserID.Text.Trim();
        string Password = txtBoxPwd.Text.Trim();

        User user = DataRepository.UserProvider.GetByUsername(UserName);
        ///Dev Note: RoleID used to filter out Mods, Customers, etc.
        if (user == null || user.Password != Password || user.Enabled == false || user.RoleId < 5)
            lblMessage.Text = "Invalid login credentials.";
        else
        {
            //User Session object initializer and security checker
            UserSession us = new UserSession();
            us.AuthenticateUser(UserName);
            //FormsAuthentication.RedirectFromLoginPage(UserName, false);
            //Force to this default page as User info need to be reloaded into Session
            //BUGFIX: Some strange bug with FormAuth as Signon page is not in /Admin folder
            Response.Redirect("~/admin/default.aspx",false);
        }

    }
}
