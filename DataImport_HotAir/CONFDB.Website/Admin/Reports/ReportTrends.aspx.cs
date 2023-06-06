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

public partial class ReportTrends : System.Web.UI.Page
{
    string WholesalerID;
    protected void Page_Load(object sender, EventArgs e)
    {
        WholesalerID = ConfigurationManager.AppSettings["WholesalerID"];

        if (!Page.IsPostBack)
        {
            BindData();
            ReportViewerControl1.Visible = false;
        }

        if (Request.UrlReferrer == null || Request.UrlReferrer.ToString().Contains(@"/ReportTrends.aspx") == false)
            Session["rpt-Trends"] = null;

        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {

            if (Session["rpt-Trends"] != null)
            {
                rptTrends rpt = (rptTrends)Session["rpt-Trends"];
                ReportViewerControl1.Report = rpt;
            }
        }
        catch
        {
            Session["rpt-Trends"] = null;
            btnSubmit_Click(null, null);
        }

        SetControls();
    }

    private void BindData()
    {

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
        rptTrends rpt = new rptTrends();
        rpt.WholesalerID = WholesalerID;
        string SalesID = dataSalesPersonId.SelectedValue;
        if (!string.IsNullOrEmpty(SalesID))
        {
            rpt.SalesPersonID = Convert.ToInt32(SalesID);
        }
        
        numOfRecs = rpt.BindData();

        if (numOfRecs > 0)
        {
            lblMessage.Text = "";

            Session["rpt-Trends"] = rpt;
            ReportViewerControl1.Report = rpt;
            ReportViewerControl1.ReportName = "TrendsReport";
            ReportViewerControl1.Visible = true;
        }
        else
        {
            lblMessage.Text = "There is no information for the selected criteria.";
            ReportViewerControl1.Visible = false;
        }
    }

}
