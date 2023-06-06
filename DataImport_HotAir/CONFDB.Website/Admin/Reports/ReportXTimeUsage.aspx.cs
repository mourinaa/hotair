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
using CONFDB.Services;
using CONFDB.Entities;

public partial class ReportXTimeUsage : System.Web.UI.Page
{
    string WholesalerID = ConfigurationManager.AppSettings["WholesalerID"];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ReportViewerControl1.Visible = false;
        }

        #region Code to Check if Report is Paging, if so load from Session Var
        if (Request.UrlReferrer.ToString().Contains(@"/ReportXTimeUsage.aspx") == false) //put the name of the page 
            Session["rpt-XTimeUsageReport"] = null;

        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {

            if (Session["rpt-XTimeUsageReport"] != null)
            {
                //Cast to correct report type
                rptXTimeUser rpt = (rptXTimeUser)Session["rpt-XTimeUsageReport"];
                ReportViewerControl1.Report = rpt;
            }
        }
        catch
        {
            Session["rpt-XTimeUsageReport"] = null;
            btnSubmit_Click(null, null);
        }

        SetControls();
        #endregion
    }

    /// <summary>
    /// Used to set the value of controls.
    /// </summary>
    protected void SetControls()
    {
        //Any Mode
        //If the SalesPersonID is set for the user then set the Sales Person list to specific SP
        UserSession us = new UserSession();
        if (!us.IsAuthenicated)
        {
            us.LogOff();//stops all process and logs user out
        }

        if (us.SalesPersonID != null)
        {
            //EntityDropDownList dataSalesPersonId = FormView1.FindControl("dataSalesPersonId") as EntityDropDownList;
            dataSalesPersonId.SelectedValue = us.SalesPersonID.ToString();
            //Disallow any less then a Sales Manager (60) to change this value
            if (us.UserLevel < 60)
            {
                dataSalesPersonId.ReadOnly = true; //will display the DDL as a label
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int numOfRecs = 0;

        rptXTimeUser rpt = new rptXTimeUser();
        //Get all the Parameter values
        string SalesID = dataSalesPersonId.SelectedValue;
        if (!string.IsNullOrEmpty(SalesID))
        {
            rpt.SalesPersonID = Convert.ToInt32(SalesID);
        }
        int ReportNumber = Convert.ToInt32(ddlReportType.SelectedValue);
        DateTime StartDate = (string.IsNullOrEmpty(txtStartDate.Text) ? DateTime.Today.AddDays(-1) : DateTime.Parse(txtStartDate.Text));
        DateTime EndDate = (string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Today : DateTime.Parse(txtEndDate.Text));
        //Move the EndDate to the end of the day
        EndDate = EndDate.AddHours(23).AddMinutes(59).AddSeconds(59);

        rpt.WholesalerID = WholesalerID;
        rpt.StartDate = StartDate;
        rpt.EndDate = EndDate;
        rpt.ReportNumber = ReportNumber;

        numOfRecs = rpt.BindData();
        if (numOfRecs > 0)
        {
            lblMessage.Text = "";

            Session["rpt-XTimeUsageReport"] = rpt;
            ReportViewerControl1.Report = rpt;
            ReportViewerControl1.ReportName = "XTimeUsageReport";
            ReportViewerControl1.Visible = true;
        }
        else
        {
            lblMessage.Text = "There is no information for the selected criteria.";
            ReportViewerControl1.Visible = false;
        }

    }
}
