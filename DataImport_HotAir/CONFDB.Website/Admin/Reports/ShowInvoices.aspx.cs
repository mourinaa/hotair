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
using CONFDB.Data;

public partial class Invoices : System.Web.UI.Page
{
    string WholesalerID = ConfigurationManager.AppSettings["WholesalerId"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
            ReportViewerControl1.Visible = false;
        }

        if (Request.UrlReferrer == null || Request.UrlReferrer.ToString().Contains(@"/ShowInvoices.aspx") == false)
            Session["rpt-invoice"] = null;

        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {

            if (Session["rpt-invoice"] != null)
            {
                BigReport rpt = (BigReport)Session["rpt-invoice"];
                ReportViewerControl1.Report = rpt;
            }
        }
        catch
        {
            Session["rpt-invoice"] = null;
            btnSubmit_Click(null, null);
        }
    }

    private void BindData()
    {
        //UserLoggedIn u = new UserLoggedIn();

        //CustomerService cs = new CustomerService();
        //Customer c = cs.GetById(Int32.Parse(u.CustomerID));

        //string priCustomerNumber = "-1"; // Show All Customers
        /*
        string wholesalerId = ConfigurationManager.AppSettings["WholesalerID"]; //u.WholesalerID;
        InvoiceSummaryService invService = new InvoiceSummaryService();
        TList<InvoiceSummary> iList = invService.GetByWholesalerId(wholesalerId);
        ddlInvoices.DataTextField = "InvoiceDate";
        ddlInvoices.DataValueField = "ID";
        ddlInvoices.DataSource = iList;
        ddlInvoices.DataBind();
         */
        DateTime dt1 = DateTime.Parse("2008-09-01");
        DateTime dt2 = DateTime.Parse(String.Format("{0}-{1}-1", DateTime.Today.Year, DateTime.Today.Month));

        ddlInvoices.Items.Clear();
        while (dt1 < dt2)
        {
            ddlInvoices.Items.Insert(0, new ListItem(dt1.ToString("MMMM yyyy"), dt1.ToString()));
            dt1 = dt1.AddMonths(1);
        }

        //Load Invoice Delivery Options.FeatureID = 18
        int featureID = 18;
        FeatureOptionService foService = new FeatureOptionService();
        TList<FeatureOption> invDeliveryOptions = foService.GetByFeatureId(featureID);
        ddlInvoiceDeliveryMethod.DataSource = invDeliveryOptions;
        ddlInvoiceDeliveryMethod.DataBind();

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int numOfRecs = 0;

        //UserLoggedIn u = new UserLoggedIn();
        //InvoiceForCustomer rpt = new InvoiceForCustomer();
        //rpt.CustomerID = -1; //Get All Invoices
        //rpt.StartDate = DateTime.Parse(ddlInvoices.SelectedValue);

        //numOfRecs = rpt.BindData();

        //if (numOfRecs > 0)
        //{
        //    lblMessage.Text = "";

        //    Session["rpt-invoice"] = rpt;
        //    ReportViewerControl1.Visible = true;
        //    ReportViewerControl1.Report = rpt;
        //    ReportViewerControl1.ReportName = "InvoiceForCustomer";
        //    ReportViewerControl1.Visible = true;
        //}
        //else
        //{
        //    lblMessage.Text = "There are no invoices for the selected date";
        //    ReportViewerControl1.Visible = false;
        //}
        BigReport bigReport = new BigReport();
        DateTime invoiceDate = DateTime.Parse(ddlInvoices.SelectedValue);

        //Get each customer to invoice
        InvoiceSummaryService invSummary = new InvoiceSummaryService();
        DataSet dsCustomersToInvoice = invSummary.GetInvoiceSummaryForInvoiceEmail(WholesalerID, invoiceDate, -1);
        DataRow[] custInvoices = null;

        try
        {
            //Filter Items based on Invoice Delivery Method
            string deliveryMethod = ddlInvoiceDeliveryMethod.SelectedValue;
            if (deliveryMethod.ToLower() != "both")
            {
                string filter = string.Format("InvoiceDeliveryMethod = '{0}'", deliveryMethod);
                custInvoices = dsCustomersToInvoice.Tables[0].Select(filter);
            }
            else
            {   //All
                custInvoices = dsCustomersToInvoice.Tables[0].Select();
            }

            numOfRecs = custInvoices.Length;
            if (numOfRecs > 0)
            {
                lblMessage.Text = "";
                foreach (DataRow item in custInvoices)
                {
                    int customerID = Convert.ToInt32(item["CustomerID"].ToString());
                    //New Code from AMP site, but had to rework to build per customer
                    AccountActivityReport rpt = new AccountActivityReport();
                    rpt.CustomerID = customerID;
                    rpt.StartDate = invoiceDate;
                    rpt.BindData();
                    rpt.CreateDocument();

                    InvoiceForCustomer rpt2 = new InvoiceForCustomer();
                    rpt2.CustomerID = customerID;
                    rpt2.StartDate = invoiceDate;
                    rpt2.BindData();
                    rpt2.CreateDocument();

                    // Add all pages of the 2nd report to the end of the 1st report.
                    rpt2.Pages.AddRange(rpt.Pages);

                    // Reset all page numbers in the resulting document.
                    rpt2.PrintingSystem.ContinuousPageNumbering = true;

                    bigReport.Pages.AddRange(rpt2.Pages);
                    bigReport.PrintingSystem.ContinuousPageNumbering = true;
                }

                Session["rpt-invoice"] = bigReport;
                ReportViewerControl1.Report = bigReport;
                ReportViewerControl1.ReportName = "InvoiceForCustomer";
                ReportViewerControl1.Visible = true;

            }
            else
            {
                lblMessage.Text = "There are no invoices for the selected date";
                ReportViewerControl1.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = "There are no invoices for the selected date";
            ReportViewerControl1.Visible = false;

            //throw ex;
        }

    }
}
