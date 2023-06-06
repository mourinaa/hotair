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
using CONFDB.Entities;
using CONFDB.Services;


public partial class XeroExport : System.Web.UI.Page
{
    string WholesalerID = ConfigurationManager.AppSettings["WholesalerID"];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
            ReportViewerControl1.Visible = false;
        }

        if (Request.UrlReferrer == null || Request.UrlReferrer.ToString().Contains(@"/XeroExport.aspx") == false)
            Session["rpt-XeroExport"] = null;

        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {

            if (Session["rpt-XeroExport"] != null)
            {
                rptXeroExport rpt = (rptXeroExport)Session["rpt-XeroExport"];
                ReportViewerControl1.Report = rpt;
            }
        }
        catch
        {
            Session["rpt-XeroExport"] = null;
            btnSubmit_Click(null, null);
        }
    }

    private void BindData()
    {
        DateTime dt1 = DateTime.Parse("2008-09-01");
        DateTime dt2 = DateTime.Parse(String.Format("{0}-{1}-1", DateTime.Today.Year, DateTime.Today.Month));

        ddlInvoices.Items.Clear();
        while (dt1 < dt2)
        {
            ddlInvoices.Items.Insert(0, new ListItem(dt1.ToString("MMMM yyyy"), dt1.ToString()));
            dt1 = dt1.AddMonths(1);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int numOfRecs = 0;

        rptXeroExport rpt = new rptXeroExport();
        rpt.WholesalerID = WholesalerID;
        rpt.InvoiceDate = DateTime.Parse(ddlInvoices.SelectedValue);

        numOfRecs = rpt.BindData();

        if (numOfRecs > 0)
        {
            lblMessage.Text = "";

            Session["rpt-XeroExport"] = rpt;
            ReportViewerControl1.Visible = true;
            ReportViewerControl1.Report = rpt;
            ReportViewerControl1.ReportName = "rptXeroExport";
            ReportViewerControl1.Visible = true;
        }
        else
        {
            lblMessage.Text = "There are no invoices for the selected date";
            ReportViewerControl1.Visible = false;
        }

    }

    protected void btnExportXeroInvoice_Click(object sender, EventArgs e)
    {
        DateTime invoiceDate = DateTime.Parse(ddlInvoices.SelectedValue);

        UtilService utilService = new UtilService();
        DataSet ds = utilService.Accounting_ExportInvoicesXERO(WholesalerID, invoiceDate);

        ExportFile(ds);

    }

    private void ExportFile(DataSet ds)
    {
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            lblMessage.Text = "There are no invoices for the selected date";
            ReportViewerControl1.Visible = false;
        }
        else
        {
            lblMessage.Text = "";
            //Build the file to return
            Exporter exportXero = new Exporter();
            string file = exportXero.ConvertDataTable(ds.Tables[0], "XeroReport-", ",", true);
            if (string.IsNullOrEmpty(file))
            {
                lblMessage.Text = "The file couldn't be generated at this time. Please try again or contact your administrator.";
                ReportViewerControl1.Visible = false;
            }
            else
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = ConfigurationSettings.AppSettings["EXPORT_CONTENTTYPE"];
                // force the User to Open or Save the file
                Response.AddHeader("content-disposition", "attachment;filename=" + System.IO.Path.GetFileName(file));
                //Write the file to the stream so the AddHeader and ContentType settings are kept.
                Response.WriteFile(file);
                Response.End();
            }
        }
    }

}
