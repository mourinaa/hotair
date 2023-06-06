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
using System.Drawing;

public partial class ReportCustomerTransactionList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //Customer Admin DDL will load itself - NetTiers style
            //hide the report
            ReportViewerControl1.Visible = false;

        }

        #region Code to Check if Report is Paging, if so load from Session Var
        if (Request.UrlReferrer.ToString().Contains(@"/ReportCustomerTransactionList.aspx") == false) //put the name of the page 
            Session["rpt-custtrans"] = null;

        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {

            if (Session["rpt-custtrans"] != null)
            {
                //Cast to correct report type
                rptCustomerTransactions rpt = (rptCustomerTransactions)Session["rpt-custtrans"];
                ReportViewerControl1.Report = rpt;
            }
        }
        catch
        {
            Session["rpt-custtrans"] = null;
            btnSubmit_Click(null, null);
        }

        #endregion
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int numOfRecs = 0;

        rptCustomerTransactions rpt = new rptCustomerTransactions();

        //Get all the Parameter values
        DateTime StartDate = (string.IsNullOrEmpty(txtStartDate.Text) ? DateTime.Today.AddMonths(-1) : DateTime.Parse(txtStartDate.Text));
        DateTime EndDate = (string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Today : DateTime.Parse(txtEndDate.Text));

        //Move the EndDate to the end of the day
        EndDate = EndDate.AddHours(23).AddMinutes(59).AddSeconds(59);

        rpt.CustomerID = Convert.ToInt32(dataCustomerId.SelectedValue);
        rpt.StartDate = StartDate;
        rpt.EndDate = EndDate;

        numOfRecs = rpt.BindData();

        if (numOfRecs > 0)
        {
            lblMessage.Text = "";

            Session["rpt-custtrans"] = rpt;
            ReportViewerControl1.Report = rpt;
            ReportViewerControl1.ReportName = "CustomerTransactionsList";
            ReportViewerControl1.Visible = true;
        }
        else
        {
            lblMessage.Text = "There is no information for the selected criteria.";
            ReportViewerControl1.Visible = false;
        }

    }
}
