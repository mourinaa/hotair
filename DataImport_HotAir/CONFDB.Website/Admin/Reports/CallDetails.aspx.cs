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
//using DevExpress.XtraReports.Web;
//using System.IO;

//using AUSWebControlLibrary;
using CONFDB.Entities;
using CONFDB.Services;

/// <summary>
/// NOTE: The main change here from the AMP site is that the report is ALWAYS for the Customer Admin which 
/// they can filter down to a moderator if they want.
/// Also, Sales Agents can only see their own customers.
/// </summary>
public partial class calldetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //UserLoggedIn u = new UserLoggedIn();

        if (!Page.IsPostBack)
        {
            //if (u.UserProfile.RoleIdSource.Name == "Customer" || u.UserProfile.RoleIdSource.Name == "Company Admin")
            //{
            //    panelCustomerAdmin.Visible = true;
            //    UserService us = new UserService();
            //    TList<User> ulist = us.GetAllModeratorsByCustomerID(Int32.Parse(u.CustomerID));

            //    ddlUsers.DataTextField = "DisplayName";
            //    ddlUsers.DataValueField = "UserId";
            //    ddlUsers.DataSource = ulist;
            //    ddlUsers.DataBind();

            //    ddlUsers.Items.Insert(0, new ListItem("All", "-1"));
            //}
            //else
            //{
            //    panelCustomerAdmin.Visible = false;
            //}
            BindData();
            ReportViewerControl1.Visible = false;
        }


        if (Request.UrlReferrer.ToString().Contains(@"/CallDetails.aspx") == false)
        {
            Session["rpt-calldetails"] = null;
        }


        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {

            if (Session["rpt-calldetails"] != null)
            {
                //if (u.UserProfile.RoleIdSource.Name == "Moderator")
                //{
                //    CallDetailsForModerator rpt = (CallDetailsForModerator)Session["rpt-calldetails"];
                //    ReportViewerControl1.Report = rpt;
                //}
                //else if (u.UserProfile.RoleIdSource.Name == "Customer" || u.UserProfile.RoleIdSource.Name == "Company Admin")
                //{
                if (ddlReports.SelectedValue == "CDRDETAILRPT")
                {
                    CallDetailsForCustomer rpt = (CallDetailsForCustomer)Session["rpt-calldetails"];
                    ReportViewerControl1.Report = rpt;
                }
                else
                {
                    CallSummaryForCustomer2 rpt = (CallSummaryForCustomer2)Session["rpt-calldetails"];
                    ReportViewerControl1.Report = rpt;
                }
                //}

            }
        }
        catch
        {
            Session["rpt-calldetails"] = null;
            btnSubmit_Click(null, null);
        }
    }

    protected void BindData()
    {
        //Limit Customer Admin based on Role and SalesAgentID
        string filter;
        int CustomerID;

        UserSession u = new UserSession();
        if (!u.IsAuthenicated)
        {
            u.LogOff();//stops all process and logs user out
        }
        if (u.SalesPersonID != null)
        {
            filter = string.Format("WholesalerID = '{0}' AND SalesPersonID = {1}",
                ConfigurationManager.AppSettings["WholesalerID"], u.SalesPersonID);
            CustomerListDataSource1.Filter = filter;
            CustomerListDataSource1.DataBind();
        }

        //Checks to do if Customer Admin selected
        if (string.IsNullOrEmpty(dataCustomerId.SelectedValue))
        {
            //No Customer selected so disable some controls
            ddlDepts.Enabled = false;
            ddlUsers.Enabled = false;
            ddlReports.Enabled = false;
            return;
        }
        else
        {
            CustomerID = Int32.Parse(dataCustomerId.SelectedValue);
            ddlDepts.Enabled = true;
            ddlUsers.Enabled = true;
            ddlReports.Enabled = true;
        }

        //Load the list of Departments
        DepartmentService ds = new DepartmentService();
        TList<Department> dlist = ds.GetByCustomerId(CustomerID);
        dlist.Sort("Name");
        ddlDepts.DataTextField = "Name";
        ddlDepts.DataValueField = "Id";
        ddlDepts.DataSource = dlist;
        ddlDepts.DataBind();
        ddlDepts.Items.Insert(0, new ListItem("All", "-1"));

        //Load the list of Users (moderators)
        UserService us = new UserService();
        TList<User> ulist = us.GetAllModeratorsByCustomerID(CustomerID);

        ddlUsers.DataTextField = "DisplayName";
        ddlUsers.DataValueField = "UserId";
        ddlUsers.DataSource = ulist;
        ddlUsers.DataBind();
        ddlUsers.Items.Insert(0, new ListItem("All", "-1"));

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int numOfRecs = 0;
        //UserLoggedIn u = new UserLoggedIn();
        string CustomerID = dataCustomerId.SelectedValue;

        //if (u.UserProfile.RoleIdSource.Name == "Moderator")
        //{
        //numOfRecs = GenRptCallDetailForModerator(u);
        if (ddlReports.SelectedValue == "CDRDETAILRPT")
            numOfRecs = GenRptCallDetailsForCustomer(CustomerID);
        else
            numOfRecs = GenRptCallSummaryForCustomer(CustomerID);

        //}
        //else if (u.UserProfile.RoleIdSource.Name == "Customer" || u.UserProfile.RoleIdSource.Name == "Company Admin")
        //{
        //    if (ddlReports.SelectedValue == "CDRDETAILRPT")
        //        numOfRecs = GenRptCallDetailsForCustomer(CustomerID);
        //    else
        //        numOfRecs = GenRptCallSummaryForCustomer(CustomerID);
        //}

        if (numOfRecs == 0)
        {
            ReportViewerControl1.Visible = false;
            lblMessage.Text = "No Records Found";
            lblMessage.Visible = true;
        }
        else
        {
            ReportViewerControl1.Visible = true;
            lblMessage.Text = "";
            lblMessage.Visible = false;
        }
    }

    //private int GenRptCallDetailForModerator(UserLoggedIn u)
    //{
    //    int numOfRecs = 0;

    //    CallDetailsForModerator rpt = new CallDetailsForModerator();
    //    rpt.UserID = u.UserProfile.UserId;
    //    try
    //    {
    //        rpt.StartTime = DateTime.Parse(txtDateFrom.Text);
    //    }
    //    catch
    //    {
    //        rpt.StartTime = DateTime.Today;
    //        txtDateFrom.Text = rpt.StartTime.ToShortDateString();
    //    }

    //    try
    //    {
    //        rpt.EndTime = DateTime.Parse(txtDateTo.Text);
    //    }
    //    catch
    //    {
    //        rpt.EndTime = rpt.StartTime;
    //        txtDateTo.Text = rpt.EndTime.ToShortDateString();
    //    }

    //    rpt.EndTime = rpt.EndTime.AddHours(23).AddMinutes(59).AddSeconds(59);

    //    numOfRecs = rpt.BindData();
    //    Session["rpt-calldetails"] = rpt;
    //    ReportViewerControl1.Report = rpt;
    //    ReportViewerControl1.ReportName = "CallDetailsForModerator";

    //    return numOfRecs;
    //}

    //private int GenRptCallDetailsForCustomer(UserLoggedIn u)

    private int GenRptCallDetailsForCustomer(string CustomerID)
    {
        int numOfRecs = 0;

        CallDetailsForCustomer rpt = new CallDetailsForCustomer();
        //rpt.CustomerID = Int32.Parse(u.CustomerID);
        rpt.CustomerID = Int32.Parse(CustomerID);

        try
        {
            rpt.StartTime = DateTime.Parse(txtDateFrom.Text);
        }
        catch
        {
            rpt.StartTime = DateTime.Today;
            txtDateFrom.Text = rpt.StartTime.ToShortDateString();
        }

        try
        {
            rpt.EndTime = DateTime.Parse(txtDateTo.Text);
        }
        catch
        {
            rpt.EndTime = rpt.StartTime;
            txtDateTo.Text = rpt.EndTime.ToShortDateString();
        }


        rpt.EndTime = rpt.EndTime.AddHours(23).AddMinutes(59).AddSeconds(59);

        //if (u.UserProfile.RoleIdSource.Name == "Moderator")
        //    rpt.SelectedUserID =u.UserProfile.UserId;
        //else
        rpt.SelectedUserID = Int32.Parse(ddlUsers.SelectedValue);
        rpt.DepartmentID = Int32.Parse(ddlDepts.SelectedValue);

        rpt.RefNumber = txtRefNum.Text.Trim();
        rpt.MeetingName = txtMeetingName.Text.Trim();
        numOfRecs = rpt.BindData();

        Session["rpt-calldetails"] = rpt;
        ReportViewerControl1.Report = rpt;
        ReportViewerControl1.ReportName = "CallDetailsForCustomer";

        return numOfRecs;
    }

    //private int GenRptCallSummaryForCustomer(UserLoggedIn u)
    private int GenRptCallSummaryForCustomer(string CustomerID)
    {
        int numOfRecs = 0;

        CallSummaryForCustomer2 rpt = new CallSummaryForCustomer2();
        //rpt.CustomerID = Int32.Parse(u.CustomerID);
        rpt.CustomerID = Int32.Parse(CustomerID);
        try
        {
            rpt.StartTime = DateTime.Parse(txtDateFrom.Text);
        }
        catch
        {
            rpt.StartTime = DateTime.Today;
            txtDateFrom.Text = rpt.StartTime.ToShortDateString();
        }

        try
        {
            rpt.EndTime = DateTime.Parse(txtDateTo.Text);
        }
        catch
        {
            rpt.EndTime = rpt.StartTime;
            txtDateTo.Text = rpt.EndTime.ToShortDateString();
        }


        rpt.EndTime = rpt.EndTime.AddHours(23).AddMinutes(59).AddSeconds(59);

        //if (u.UserProfile.RoleIdSource.Name == "Moderator")
        //    rpt.SelectedUserID = u.UserProfile.UserId;
        //else
        rpt.DepartmentID = Int32.Parse(ddlDepts.SelectedValue);
        rpt.SelectedUserID = Int32.Parse(ddlUsers.SelectedValue);

        rpt.RefNumber = txtRefNum.Text.Trim();
        rpt.MeetingName = txtMeetingName.Text.Trim();

        numOfRecs = rpt.BindData();

        Session["rpt-calldetails"] = rpt;
        ReportViewerControl1.Report = rpt;
        ReportViewerControl1.ReportName = "CallSummaryForCustomer";

        return numOfRecs;
    }

    protected void dataCustomerId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Populate the list of invoices based on customer
        BindData();
    }

}
