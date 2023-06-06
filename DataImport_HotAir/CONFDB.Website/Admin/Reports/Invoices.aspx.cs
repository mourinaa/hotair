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
//using AUSWebControlLibrary;
using CONFDB.Entities;
using CONFDB.Services;


public partial class Invoices : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindData();
            ReportViewerControl1.Visible = false;
        }

        if (Request.UrlReferrer.ToString().Contains(@"/Invoices.aspx") == false)
            Session["rpt-invoice"] = null;

        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {

            if (Session["rpt-invoice"] != null)
            {
                InvoiceForCustomer rpt = (InvoiceForCustomer)Session["rpt-invoice"];
                ReportViewerControl1.Report = rpt;
            }
        }
        catch
        {
            Session["rpt-invoice"] = null;
            btnSubmit_Click(null, null);
        }
    }

    protected void BindData()
    {
        //UserLoggedIn u = new UserLoggedIn();
        if (string.IsNullOrEmpty(dataCustomerId.SelectedValue))
        {
            ddlInvoices.Enabled = false;
            return;
        }

        ddlInvoices.Enabled = true;
        int CustomerID = Convert.ToInt32(dataCustomerId.SelectedValue);

        CustomerService cs = new CustomerService();
        Customer c = cs.GetById(CustomerID);

        string priCustomerNumber = c.PriCustomerNumber;
        string wholesalerId = c.WholesalerId;

        InvoiceSummaryService invService = new InvoiceSummaryService();
        TList<InvoiceSummary> iList = invService.GetByPriCustomerNumberWholesalerId(priCustomerNumber, wholesalerId);
        /*
        ddlInvoices.DataTextField = "InvoiceDate";
        ddlInvoices.DataValueField = "ID";
        ddlInvoices.DataSource = iList;
        ddlInvoices.DataBind();
         */
        ddlInvoices.Items.Clear();
        for (int i = 0; i < iList.Count; i++)
        {
            ddlInvoices.Items.Insert(0, new ListItem(iList[i].InvoiceDate.ToString("MMMM yyyy"), iList[i].StartDate.ToString()));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int numOfRecs = 0;

        //UserLoggedIn u = new UserLoggedIn();

        try
        {
            DetailInvoice rpt = new DetailInvoice(); //2nd page details
            rpt.CustomerID = Int32.Parse(dataCustomerId.SelectedValue);
            rpt.StartDate = DateTime.Parse(ddlInvoices.SelectedValue);
            rpt.BindData();
            rpt.CreateDocument();

            InvoiceForCustomer rpt2 = new InvoiceForCustomer();//Main report
            rpt2.CustomerID = Int32.Parse(dataCustomerId.SelectedValue);
            rpt2.StartDate = DateTime.Parse(ddlInvoices.SelectedValue);
            rpt2.BindData();
            rpt2.CreateDocument();

            // Add all pages of the 2nd report to the end of the 1st report.
            rpt2.Pages.AddRange(rpt.Pages);

            // Reset all page numbers in the resulting document.
            rpt2.PrintingSystem.ContinuousPageNumbering = true;

            //Old Code 
            //InvoiceForCustomer rpt = new InvoiceForCustomer();
            //rpt.CustomerID = Convert.ToInt32(dataCustomerId.SelectedValue);
            //rpt.StartDate = DateTime.Parse(ddlInvoices.SelectedValue);

            numOfRecs = rpt2.BindData();
            if (numOfRecs > 0)
            {
                //Show the report
                lblMessage.Text = "";
                Session["rpt-invoice"] = rpt2;
                ReportViewerControl1.Report = rpt2;
                ReportViewerControl1.ReportName = "InvoiceForCustomer";
                ReportViewerControl1.Visible = true;
            }
            else
            {
                lblMessage.Text = "There is no invoice for the selected date or the invoice balance is zero.";
                ReportViewerControl1.Visible = false;
            }

        }
        catch (Exception ex)
        {
            lblMessage.Text = "There is no invoice for the selected date or the invoice balance is zero.";
            ReportViewerControl1.Visible = false;

            //throw;
        }
    }

    protected void dataCustomerId_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Populate the list of invoices based on customer
        BindData();
    }
}
