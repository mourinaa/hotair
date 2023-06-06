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

//using AUSWebControlLibrary;
using CONFDB.Entities;
using CONFDB.Services;

public partial class ChangeBillingCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            txtBillingCode.Text = Request.QueryString["refnum"].ToString().Trim();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //UserLoggedIn u = new UserLoggedIn();

        //RatedCdrService rs = new RatedCdrService();

        //string newBillingCode = txtBillingCode.Text.Trim();

        //rs.SetBillingCode(Int32.Parse(u.CustomerID), Request.QueryString["id"].ToString(), newBillingCode);

        //if (newBillingCode != "")
        //    lblMessage.Text = "Cost code has been updated to " + newBillingCode;
        //else
        //    lblMessage.Text = "Cost code has removed ";
        //// Set the session variable so data will be reloaded by the report
        //Session["rpt-calldetails"] = "";
    }
}
