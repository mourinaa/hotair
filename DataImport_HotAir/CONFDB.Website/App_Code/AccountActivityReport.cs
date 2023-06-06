using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;

/// <summary>
/// Summary description for AccountActivityReport
/// </summary>
public class AccountActivityReport : DevExpress.XtraReports.UI.XtraReport
{
	private DevExpress.XtraReports.UI.DetailBand Detail;
	private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
    private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
    private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    private System.Data.SqlClient.SqlConnection sqlConnection1;
    private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
    private dsInvoice dsInvoice1;
    private XRLabel xrLabel4;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabelBPTop;
    private XRLabel xrLabel40;
    private XRLabel xrLabel41;
    private XRLabel xrLabel42;
    private XRLabel xrLabel16;
    private XRLabel xrLabel9;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabelNewCharges;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    private XRLabel xrLabel21;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    private int customerID;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private XRSubreport xrSubreportPayments;
    private XRSubreport xrSubreportCredits;
    private XRRichText xrRichText1;

    public int CustomerID
    {
        get { return customerID; }
        set { customerID = value; }
    }

    private DateTime startDate;

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }


	public AccountActivityReport()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int BindData()
    {
 
        InitializeComponent();
        this.sqlConnection1.ConnectionString = ConfigurationManager.ConnectionStrings["CONFDBConnectionString"].ToString();

        AccountActivityReportPayments paymentReport = new AccountActivityReportPayments();
        paymentReport.StartDate = startDate;
        paymentReport.CustomerID = customerID;
        paymentReport.ReqType = 3; 
        int numrecs = paymentReport.BindData();

        if (numrecs > 0)
            xrSubreportPayments.ReportSource = paymentReport;
        else
            xrSubreportPayments.Visible = false;

        AccountActivityReportPayments creditReport = new AccountActivityReportPayments();
        creditReport.StartDate = startDate;
        creditReport.CustomerID = customerID;
        creditReport.ReqType = 2;
        numrecs = creditReport.BindData();
        
        if (numrecs > 0)
            xrSubreportCredits.ReportSource = creditReport;
        else
            xrSubreportCredits.Visible = false;

        sqlDataAdapter1.SelectCommand.Parameters["@CustomerID"].Value = customerID;
        sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = startDate;

        dsInvoice ds = new dsInvoice();
        ds.EnforceConstraints = false;
        sqlDataAdapter1.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
            this.DataSource = ds.Tables[0];

        /*
        if (customerID != -1)
        {
            InvoiceForCustomerService servreport = new InvoiceForCustomerService();
            servreport.StartDate = startDate;
            servreport.CustomerID = customerID;
            servreport.BindData();

            xrSubreport1.ReportSource = servreport;
        }
        */

        return ds.Tables[0].Rows.Count;

    }
	
	/// <summary> 
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
        string resourceFileName = "AccountActivityReport.resx";
        System.Resources.ResourceManager resources = global::Resources.AccountActivityReport.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrSubreportCredits = new DevExpress.XtraReports.UI.XRSubreport();
        this.xrSubreportPayments = new DevExpress.XtraReports.UI.XRSubreport();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelNewCharges = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrLabelBPTop = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
        this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
        this.dsInvoice1 = new dsInvoice();
        this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
        ((System.ComponentModel.ISupportInitialize)(this.dsInvoice1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText1,
            this.xrSubreportCredits,
            this.xrSubreportPayments,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabelNewCharges,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10});
        this.Detail.Height = 425;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrSubreportCredits
        // 
        this.xrSubreportCredits.CanShrink = true;
        this.xrSubreportCredits.Location = new System.Drawing.Point(0, 75);
        this.xrSubreportCredits.Name = "xrSubreportCredits";
        this.xrSubreportCredits.Size = new System.Drawing.Size(775, 25);
        // 
        // xrSubreportPayments
        // 
        this.xrSubreportPayments.CanShrink = true;
        this.xrSubreportPayments.Location = new System.Drawing.Point(0, 42);
        this.xrSubreportPayments.Name = "xrSubreportPayments";
        this.xrSubreportPayments.Size = new System.Drawing.Size(775, 25);
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BalanceForward", "{0:$#,##0.00;$#,##0.00;$0.00}")});
        this.xrLabel21.Location = new System.Drawing.Point(642, 158);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.Size = new System.Drawing.Size(125, 25);
        this.xrLabel21.Text = "xrLabel21";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Location = new System.Drawing.Point(75, 158);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.Size = new System.Drawing.Size(175, 25);
        this.xrLabel20.Text = "Total Amount Due";
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.EndDate", "{0:MM/dd/yyyy}")});
        this.xrLabel19.Location = new System.Drawing.Point(0, 158);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.Size = new System.Drawing.Size(75, 25);
        this.xrLabel19.Text = "xrLabel19";
        // 
        // xrLabelNewCharges
        // 
        this.xrLabelNewCharges.Location = new System.Drawing.Point(642, 133);
        this.xrLabelNewCharges.Name = "xrLabelNewCharges";
        this.xrLabelNewCharges.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelNewCharges.Size = new System.Drawing.Size(125, 25);
        this.xrLabelNewCharges.Text = "xrLabelNewCharges";
        this.xrLabelNewCharges.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrLabelNewCharges.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelNewCharges_BeforePrint);
        // 
        // xrLabel18
        // 
        this.xrLabel18.Location = new System.Drawing.Point(75, 133);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.Size = new System.Drawing.Size(175, 25);
        this.xrLabel18.Text = "New Charges (Including GST)";
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.EndDate", "{0:MM/dd/yyyy}")});
        this.xrLabel17.Location = new System.Drawing.Point(0, 133);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.Size = new System.Drawing.Size(75, 25);
        this.xrLabel17.Text = "xrLabel17";
        // 
        // xrLabel15
        // 
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BalForward", "{0:$#,##0.00;$#,##0.00;$0.00}")});
        this.xrLabel15.Location = new System.Drawing.Point(642, 108);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.Size = new System.Drawing.Size(125, 25);
        this.xrLabel15.Text = "xrLabel15";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Location = new System.Drawing.Point(75, 108);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.Size = new System.Drawing.Size(175, 25);
        this.xrLabel14.Text = "Balance";
        // 
        // xrLabel13
        // 
        this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.EndDate", "{0:MM/dd/yyyy}")});
        this.xrLabel13.Location = new System.Drawing.Point(0, 108);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.Size = new System.Drawing.Size(75, 25);
        this.xrLabel13.Text = "xrLabel13";
        // 
        // xrLabel12
        // 
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.AmountOfLastBill", "{0:$#,##0.00;$#,##0.00;$0.00}")});
        this.xrLabel12.Location = new System.Drawing.Point(642, 8);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.Size = new System.Drawing.Size(125, 25);
        this.xrLabel12.Text = "xrLabel12";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Location = new System.Drawing.Point(75, 8);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.Size = new System.Drawing.Size(175, 25);
        this.xrLabel11.Text = "Open Balance";
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.StartDate", "{0:MM/dd/yyyy}")});
        this.xrLabel10.Location = new System.Drawing.Point(0, 8);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.Size = new System.Drawing.Size(75, 25);
        this.xrLabel10.Text = "xrLabel10";
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel9,
            this.xrLabel16,
            this.xrLabel4,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrPictureBox1,
            this.xrLabelBPTop,
            this.xrLabel40,
            this.xrLabel41,
            this.xrLabel42});
        this.PageHeader.Height = 143;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.ForeColor = System.Drawing.Color.Maroon;
        this.xrLabel8.Location = new System.Drawing.Point(642, 117);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.Size = new System.Drawing.Size(125, 25);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseForeColor = false;
        this.xrLabel8.Text = "Totals";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.ForeColor = System.Drawing.Color.Maroon;
        this.xrLabel7.Location = new System.Drawing.Point(517, 117);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.Size = new System.Drawing.Size(125, 25);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseForeColor = false;
        this.xrLabel7.Text = "Amount";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.ForeColor = System.Drawing.Color.Maroon;
        this.xrLabel6.Location = new System.Drawing.Point(250, 117);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(267, 25);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseForeColor = false;
        this.xrLabel6.Text = "Description";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.ForeColor = System.Drawing.Color.Maroon;
        this.xrLabel5.Location = new System.Drawing.Point(75, 117);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.Size = new System.Drawing.Size(175, 25);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseForeColor = false;
        this.xrLabel5.Text = "Type";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.ForeColor = System.Drawing.Color.Maroon;
        this.xrLabel9.Location = new System.Drawing.Point(0, 117);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.Size = new System.Drawing.Size(75, 25);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseForeColor = false;
        this.xrLabel9.Text = "Date";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel16
        // 
        this.xrLabel16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel16.Location = new System.Drawing.Point(0, 83);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.Size = new System.Drawing.Size(158, 17);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.Text = "Account Activity Detail";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel4.Location = new System.Drawing.Point(500, 67);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(125, 17);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.Text = "Billing Period:";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel1.Location = new System.Drawing.Point(500, 8);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(125, 17);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "Customer Number:";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel2.Location = new System.Drawing.Point(500, 25);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.Size = new System.Drawing.Size(125, 17);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.Text = "Tax Invoice #:";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel3.Location = new System.Drawing.Point(500, 42);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.Size = new System.Drawing.Size(125, 17);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.Text = "Date of Issue:";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrPictureBox1
        // 
        this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
        this.xrPictureBox1.Location = new System.Drawing.Point(0, 8);
        this.xrPictureBox1.Name = "xrPictureBox1";
        this.xrPictureBox1.Size = new System.Drawing.Size(217, 67);
        // 
        // xrLabelBPTop
        // 
        this.xrLabelBPTop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelBPTop.Location = new System.Drawing.Point(633, 67);
        this.xrLabelBPTop.Name = "xrLabelBPTop";
        this.xrLabelBPTop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelBPTop.Size = new System.Drawing.Size(142, 17);
        this.xrLabelBPTop.StylePriority.UseFont = false;
        this.xrLabelBPTop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabelBPTop.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelBPTop_BeforePrint);
        // 
        // xrLabel40
        // 
        this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.PriCustomerNumber", "")});
        this.xrLabel40.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel40.Location = new System.Drawing.Point(633, 8);
        this.xrLabel40.Name = "xrLabel40";
        this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel40.Size = new System.Drawing.Size(100, 17);
        this.xrLabel40.StylePriority.UseFont = false;
        this.xrLabel40.Text = "xrLabel40";
        // 
        // xrLabel41
        // 
        this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.InvoiceNumber", "")});
        this.xrLabel41.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel41.Location = new System.Drawing.Point(633, 25);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel41.Size = new System.Drawing.Size(100, 17);
        this.xrLabel41.StylePriority.UseFont = false;
        this.xrLabel41.Text = "xrLabel41";
        // 
        // xrLabel42
        // 
        this.xrLabel42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.InvoiceDate", "{0:MMMM dd, yyyy}")});
        this.xrLabel42.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel42.Location = new System.Drawing.Point(633, 42);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.Size = new System.Drawing.Size(142, 17);
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.Text = "xrLabel42";
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
        this.PageFooter.Height = 26;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrPageInfo2.Format = "Page 2 of 2";
        this.xrPageInfo2.Location = new System.Drawing.Point(433, 0);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.None;
        this.xrPageInfo2.Size = new System.Drawing.Size(313, 23);
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrPageInfo1.Location = new System.Drawing.Point(0, 0);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.Size = new System.Drawing.Size(313, 23);
        // 
        // sqlSelectCommand1
        // 
        this.sqlSelectCommand1.CommandText = "dbo.p_InvoiceSummary_GetInvoiceSummary";
        this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        this.sqlSelectCommand1.Connection = this.sqlConnection1;
        this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.Int, 4)});
        // 
        // sqlConnection1
        // 
        this.sqlConnection1.ConnectionString = "Data Source=DEV;Initial Catalog=CONFDB;Integrated Security=True";
        this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
        // 
        // sqlDataAdapter1
        // 
        this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
        this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "p_InvoiceSummary_GetInvoiceSummary", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
                        new System.Data.Common.DataColumnMapping("EndDate", "EndDate"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("PriCustomerNumber", "PriCustomerNumber"),
                        new System.Data.Common.DataColumnMapping("InvoiceNumber", "InvoiceNumber"),
                        new System.Data.Common.DataColumnMapping("AmountOfLastBill", "AmountOfLastBill"),
                        new System.Data.Common.DataColumnMapping("Payment1", "Payment1"),
                        new System.Data.Common.DataColumnMapping("TotalCredits", "TotalCredits"),
                        new System.Data.Common.DataColumnMapping("TotalLatePaymentCharges", "TotalLatePaymentCharges"),
                        new System.Data.Common.DataColumnMapping("BalForward", "BalForward"),
                        new System.Data.Common.DataColumnMapping("ProductCharges", "ProductCharges"),
                        new System.Data.Common.DataColumnMapping("MiscCharges", "MiscCharges"),
                        new System.Data.Common.DataColumnMapping("LocalTaxAmount", "LocalTaxAmount"),
                        new System.Data.Common.DataColumnMapping("FederalTaxAmount", "FederalTaxAmount"),
                        new System.Data.Common.DataColumnMapping("TotalCurrent", "TotalCurrent"),
                        new System.Data.Common.DataColumnMapping("BalanceForward", "BalanceForward"),
                        new System.Data.Common.DataColumnMapping("InvoiceDate", "InvoiceDate"),
                        new System.Data.Common.DataColumnMapping("DueDate", "DueDate"),
                        new System.Data.Common.DataColumnMapping("CurrencyID", "CurrencyID"),
                        new System.Data.Common.DataColumnMapping("WholesalerID", "WholesalerID"),
                        new System.Data.Common.DataColumnMapping("TotalFreeCredits", "TotalFreeCredits"),
                        new System.Data.Common.DataColumnMapping("Wholesaler_ProductID", "Wholesaler_ProductID"),
                        new System.Data.Common.DataColumnMapping("BPayCustomerRefNumber", "BPayCustomerRefNumber"),
                        new System.Data.Common.DataColumnMapping("BillingContactName", "BillingContactName"),
                        new System.Data.Common.DataColumnMapping("BillingContactPhoneNumber", "BillingContactPhoneNumber"),
                        new System.Data.Common.DataColumnMapping("BillingContactEmailAddress", "BillingContactEmailAddress"),
                        new System.Data.Common.DataColumnMapping("BillingContactAddress1", "BillingContactAddress1"),
                        new System.Data.Common.DataColumnMapping("BillingContactAddress2", "BillingContactAddress2"),
                        new System.Data.Common.DataColumnMapping("BillingContactCity", "BillingContactCity"),
                        new System.Data.Common.DataColumnMapping("BillingContactCountry", "BillingContactCountry"),
                        new System.Data.Common.DataColumnMapping("BillingContactRegion", "BillingContactRegion"),
                        new System.Data.Common.DataColumnMapping("BillingContactPostalCode", "BillingContactPostalCode"),
                        new System.Data.Common.DataColumnMapping("CompanyID", "CompanyID"),
                        new System.Data.Common.DataColumnMapping("BillingPeriodCutoff", "BillingPeriodCutoff"),
                        new System.Data.Common.DataColumnMapping("Enabled", "Enabled"),
                        new System.Data.Common.DataColumnMapping("ComanyName", "ComanyName")})});
        // 
        // dsInvoice1
        // 
        this.dsInvoice1.DataSetName = "dsInvoice";
        this.dsInvoice1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // xrRichText1
        // 
        this.xrRichText1.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrRichText1.Location = new System.Drawing.Point(25, 242);
        this.xrRichText1.Name = "xrRichText1";
        this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
        this.xrRichText1.Size = new System.Drawing.Size(725, 158);
        this.xrRichText1.StylePriority.UseBorders = false;
        this.xrRichText1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // AccountActivityReport
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter});
        this.DataAdapter = this.sqlDataAdapter1;
        this.DataMember = "p_InvoiceSummary_GetInvoiceSummary";
        this.DataSource = this.dsInvoice1;
        this.Margins = new System.Drawing.Printing.Margins(50, 17, 0, 0);
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dsInvoice1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void xrLabelNewCharges_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        double newCharges = CalculateNewCharges();
        (sender as XRLabel).Text = String.Format("{0:$#,##.00  ;$#,##.00;$0.00}", newCharges);
    }

    private double CalculateNewCharges()
    {
        double productCharges = Double.Parse(this.GetCurrentColumnValue("ProductCharges").ToString());
        double miscCharges = Double.Parse(this.GetCurrentColumnValue("MiscCharges").ToString());
        double totalFreeCredits = Double.Parse(this.GetCurrentColumnValue("TotalFreeCredits").ToString());
        double latePaymentCharges = Double.Parse(this.GetCurrentColumnValue("TotalLatePaymentCharges").ToString());
        double fedTax = Double.Parse(this.GetCurrentColumnValue("FederalTaxAmount").ToString());
        double localTax = Double.Parse(this.GetCurrentColumnValue("LocalTaxAmount").ToString());

        double newCharges = productCharges + miscCharges + latePaymentCharges + fedTax + localTax;

        return newCharges;
    }

    private string BuildInvoiceDate()
    {
        DateTime startDate = DateTime.Parse(this.GetCurrentColumnValue("StartDate").ToString());
        DateTime endDate = DateTime.Parse(this.GetCurrentColumnValue("EndDate").ToString());

        string outStr = startDate.ToString("MMMM d") + " - " + endDate.ToString("d, yyyy");

        return outStr;
    }

    private void xrLabelBPTop_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        string billingPeriod = BuildInvoiceDate();
        (sender as XRLabel).Text = billingPeriod;
    }
}
