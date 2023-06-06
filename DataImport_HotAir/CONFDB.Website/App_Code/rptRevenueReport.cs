using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptRevenueReport
/// </summary>
public class rptRevenueReport : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private XRLabel xrLabel25;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    private XRLabel xrLabel22;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private GroupFooterBand groupFooterBand1;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel26;
    private XRLine xrLine2;
    private XRLabel xrLabel40;
    private XRLabel xrLabel39;
    private XRLabel xrLabel38;
    private XRLabel xrLabel37;
    private XRLabel xrLabel36;
    private XRLabel xrLabel35;
    private XRLabel xrLabel34;
    private XRLabel xrLabel44;
    private XRLabel xrLabel43;
    private XRLabel xrLabel42;
    private XRLabel xrLabel41;
    private dsRevenueReport dsRevenueReport1;
    private dsRevenueReportTableAdapters.p_UTIL_MGMTRPT_GrossProfitTableAdapter p_UTIL_MGMTRPT_GrossProfitTableAdapter1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private XRLine xrLine1;
    private XRLabel xrLabel3;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel29;

    #region Added - Extra Public Properties for Binding the Report
    public string WholesalerID;
    public DateTime? StartDate;
    public DateTime? EndDate;
    public DateTime? InvoiceDate;
    private XRLabel xrLabel30;
    private XRLabel xrLabel31;
    public int? SalesPersonID;
    #endregion

    public rptRevenueReport()
    {
        #region Move the Init code to the BindData() as it runs before Parameters are passed in
        //InitializeComponent();
        ////
        //// TODO: Add constructor logic here
        ////
        #endregion
    }

    public int BindData()
    {

        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
        p_UTIL_MGMTRPT_GrossProfitTableAdapter1.Fill(
            dsRevenueReport1.p_UTIL_MGMTRPT_GrossProfit, WholesalerID, StartDate, EndDate, InvoiceDate, SalesPersonID);

        int rows = dsRevenueReport1.Tables[0].Rows.Count;
        if (rows > 0)
        {
            this.DataSource = dsRevenueReport1;
        }
        return rows;
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        string resourceFileName = "rptRevenueReport.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary11 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary12 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary13 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary14 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.dsRevenueReport1 = new dsRevenueReport();
        this.p_UTIL_MGMTRPT_GrossProfitTableAdapter1 = new dsRevenueReportTableAdapters.p_UTIL_MGMTRPT_GrossProfitTableAdapter();
        ((System.ComponentModel.ISupportInitialize)(this.dsRevenueReport1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19});
        this.Detail.Height = 25;
        this.Detail.KeepTogether = true;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel27
        // 
        this.xrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.MiscCredit", "")});
        this.xrLabel27.Location = new System.Drawing.Point(994, 0);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.Size = new System.Drawing.Size(86, 18);
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "xrLabel27";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel25
        // 
        this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.LDMinutes", "{0:#,#}")});
        this.xrLabel25.Location = new System.Drawing.Point(1174, 0);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.Size = new System.Drawing.Size(109, 18);
        this.xrLabel25.StyleName = "DataField";
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel24
        // 
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.BridgeMinutes", "{0:#,#}")});
        this.xrLabel24.Location = new System.Drawing.Point(1080, 0);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.Size = new System.Drawing.Size(92, 18);
        this.xrLabel24.StyleName = "DataField";
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel23
        // 
        this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.MiscRevenue", "{0:C2}")});
        this.xrLabel23.Location = new System.Drawing.Point(900, 0);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.Size = new System.Drawing.Size(92, 18);
        this.xrLabel23.StyleName = "DataField";
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel22
        // 
        this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.LDRevenue", "{0:C2}")});
        this.xrLabel22.Location = new System.Drawing.Point(817, 0);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.Size = new System.Drawing.Size(79, 18);
        this.xrLabel22.StyleName = "DataField";
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.BridgeRevenue", "{0:C2}")});
        this.xrLabel21.Location = new System.Drawing.Point(725, 0);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.Size = new System.Drawing.Size(85, 18);
        this.xrLabel21.StyleName = "DataField";
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel20
        // 
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.Calls", "{0:#,#}")});
        this.xrLabel20.Location = new System.Drawing.Point(664, 0);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.Size = new System.Drawing.Size(58, 18);
        this.xrLabel20.StyleName = "DataField";
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.Product", "")});
        this.xrLabel19.Location = new System.Drawing.Point(362, 0);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.Size = new System.Drawing.Size(292, 18);
        this.xrLabel19.StyleName = "DataField";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
        this.PageFooter.Height = 31;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Format = "Page {0} of {1}";
        this.xrPageInfo2.Location = new System.Drawing.Point(658, 8);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.Size = new System.Drawing.Size(413, 23);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Location = new System.Drawing.Point(6, 6);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.Size = new System.Drawing.Size(413, 23);
        this.xrPageInfo1.StyleName = "PageInfo";
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel30,
            this.xrLabel3,
            this.xrLabel44,
            this.xrLabel43,
            this.xrLine2,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel2,
            this.xrLabel1});
        this.PageHeader.Height = 42;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Location = new System.Drawing.Point(525, 0);
        this.xrLabel30.Multiline = true;
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.Size = new System.Drawing.Size(139, 36);
        this.xrLabel30.StyleName = "FieldCaption";
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = "Sales\r\nPerson";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Location = new System.Drawing.Point(994, 0);
        this.xrLabel3.Multiline = true;
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.Size = new System.Drawing.Size(86, 36);
        this.xrLabel3.StyleName = "FieldCaption";
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Credits";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel44
        // 
        this.xrLabel44.Location = new System.Drawing.Point(399, 0);
        this.xrLabel44.Multiline = true;
        this.xrLabel44.Name = "xrLabel44";
        this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel44.Size = new System.Drawing.Size(125, 36);
        this.xrLabel44.StyleName = "FieldCaption";
        this.xrLabel44.StylePriority.UseTextAlignment = false;
        this.xrLabel44.Text = "Account\r\nManager";
        this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel43
        // 
        this.xrLabel43.Location = new System.Drawing.Point(299, 0);
        this.xrLabel43.Multiline = true;
        this.xrLabel43.Name = "xrLabel43";
        this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel43.Size = new System.Drawing.Size(92, 36);
        this.xrLabel43.StyleName = "FieldCaption";
        this.xrLabel43.StylePriority.UseTextAlignment = false;
        this.xrLabel43.Text = "Vertical";
        this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLine2
        // 
        this.xrLine2.Location = new System.Drawing.Point(0, 38);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.Size = new System.Drawing.Size(1283, 2);
        // 
        // xrLabel9
        // 
        this.xrLabel9.Location = new System.Drawing.Point(1174, 0);
        this.xrLabel9.Multiline = true;
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.Size = new System.Drawing.Size(109, 36);
        this.xrLabel9.StyleName = "FieldCaption";
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "LD \r\nMinutes";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Location = new System.Drawing.Point(1080, 0);
        this.xrLabel8.Multiline = true;
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.Size = new System.Drawing.Size(92, 36);
        this.xrLabel8.StyleName = "FieldCaption";
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Bridge \r\nMinutes";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Location = new System.Drawing.Point(900, 0);
        this.xrLabel7.Multiline = true;
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.Size = new System.Drawing.Size(92, 36);
        this.xrLabel7.StyleName = "FieldCaption";
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Misc \r\nRevenue";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Location = new System.Drawing.Point(817, 0);
        this.xrLabel6.Multiline = true;
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(79, 36);
        this.xrLabel6.StyleName = "FieldCaption";
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "LD \r\nRevenue";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Location = new System.Drawing.Point(727, 0);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.Size = new System.Drawing.Size(85, 36);
        this.xrLabel5.StyleName = "FieldCaption";
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Bridge Revenue";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Location = new System.Drawing.Point(664, 0);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(58, 36);
        this.xrLabel4.StyleName = "FieldCaption";
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Calls";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Location = new System.Drawing.Point(172, 0);
        this.xrLabel2.Multiline = true;
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.Size = new System.Drawing.Size(120, 36);
        this.xrLabel2.StyleName = "FieldCaption";
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Customer \r\nNumber";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Location = new System.Drawing.Point(0, 0);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(167, 36);
        this.xrLabel1.StyleName = "FieldCaption";
        this.xrLabel1.Text = "Company Name";
        // 
        // Title
        // 
        this.Title.BackColor = System.Drawing.Color.White;
        this.Title.BorderColor = System.Drawing.SystemColors.ControlText;
        this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.Title.BorderWidth = 1;
        this.Title.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold);
        this.Title.ForeColor = System.Drawing.Color.Maroon;
        this.Title.Name = "Title";
        // 
        // FieldCaption
        // 
        this.FieldCaption.BackColor = System.Drawing.Color.White;
        this.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText;
        this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.FieldCaption.BorderWidth = 1;
        this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.FieldCaption.ForeColor = System.Drawing.Color.Maroon;
        this.FieldCaption.Name = "FieldCaption";
        // 
        // PageInfo
        // 
        this.PageInfo.BackColor = System.Drawing.Color.White;
        this.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText;
        this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.PageInfo.BorderWidth = 1;
        this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.PageInfo.ForeColor = System.Drawing.SystemColors.ControlText;
        this.PageInfo.Name = "PageInfo";
        // 
        // DataField
        // 
        this.DataField.BackColor = System.Drawing.Color.White;
        this.DataField.BorderColor = System.Drawing.SystemColors.ControlText;
        this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.DataField.BorderWidth = 1;
        this.DataField.Font = new System.Drawing.Font("Times New Roman", 10F);
        this.DataField.ForeColor = System.Drawing.SystemColors.ControlText;
        this.DataField.Name = "DataField";
        // 
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel31,
            this.xrLabel42,
            this.xrLabel41,
            this.xrLabel11,
            this.xrLabel10});
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Company", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("PriCustomerNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("Vertical", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("SalesPerson", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
        this.groupHeaderBand1.Height = 25;
        this.groupHeaderBand1.KeepTogether = true;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        // 
        // xrLabel31
        // 
        this.xrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.SalesPerson", "")});
        this.xrLabel31.Location = new System.Drawing.Point(526, 0);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel31.Size = new System.Drawing.Size(149, 25);
        this.xrLabel31.Text = "xrLabel31";
        this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel42
        // 
        this.xrLabel42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.AccountManager", "")});
        this.xrLabel42.Location = new System.Drawing.Point(400, 0);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.Size = new System.Drawing.Size(125, 25);
        this.xrLabel42.Text = "xrLabel42";
        this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel41
        // 
        this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.Vertical", "")});
        this.xrLabel41.Location = new System.Drawing.Point(292, 0);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel41.Size = new System.Drawing.Size(108, 25);
        this.xrLabel41.Text = "xrLabel41";
        this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel11
        // 
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.PriCustomerNumber", "")});
        this.xrLabel11.Location = new System.Drawing.Point(172, 0);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.Size = new System.Drawing.Size(117, 23);
        this.xrLabel11.StyleName = "DataField";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_GrossProfit.Company", "")});
        this.xrLabel10.Location = new System.Drawing.Point(0, 0);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.Size = new System.Drawing.Size(167, 23);
        this.xrLabel10.StyleName = "DataField";
        // 
        // groupFooterBand1
        // 
        this.groupFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel28,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12});
        this.groupFooterBand1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
        this.groupFooterBand1.Height = 22;
        this.groupFooterBand1.KeepTogether = true;
        this.groupFooterBand1.Name = "groupFooterBand1";
        // 
        // xrLabel28
        // 
        this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MiscCredit", "{0:C2}")});
        this.xrLabel28.Location = new System.Drawing.Point(993, 0);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.Size = new System.Drawing.Size(87, 18);
        this.xrLabel28.StyleName = "FieldCaption";
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:C2}";
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel28.Summary = xrSummary1;
        this.xrLabel28.Text = "xrLabel28";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel18
        // 
        this.xrLabel18.Location = new System.Drawing.Point(8, 0);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.Size = new System.Drawing.Size(228, 18);
        this.xrLabel18.StyleName = "FieldCaption";
        this.xrLabel18.Text = "SubTotal";
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LDMinutes", "")});
        this.xrLabel17.Location = new System.Drawing.Point(1173, 0);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.Size = new System.Drawing.Size(109, 18);
        this.xrLabel17.StyleName = "FieldCaption";
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:#,0}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel17.Summary = xrSummary2;
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel16
        // 
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BridgeMinutes", "")});
        this.xrLabel16.Location = new System.Drawing.Point(1080, 0);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.Size = new System.Drawing.Size(92, 18);
        this.xrLabel16.StyleName = "FieldCaption";
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:#,0}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel16.Summary = xrSummary3;
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel15
        // 
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MiscRevenue", "{0:C2}")});
        this.xrLabel15.Location = new System.Drawing.Point(900, 0);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.Size = new System.Drawing.Size(92, 18);
        this.xrLabel15.StyleName = "FieldCaption";
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:C2}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel15.Summary = xrSummary4;
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LDRevenue", "{0:C2}")});
        this.xrLabel14.Location = new System.Drawing.Point(816, 0);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.Size = new System.Drawing.Size(79, 18);
        this.xrLabel14.StyleName = "FieldCaption";
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:C2}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel14.Summary = xrSummary5;
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BridgeRevenue", "{0:C2}")});
        this.xrLabel13.Location = new System.Drawing.Point(725, 0);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.Size = new System.Drawing.Size(85, 18);
        this.xrLabel13.StyleName = "FieldCaption";
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:C2}";
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel13.Summary = xrSummary6;
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel12
        // 
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Calls", "")});
        this.xrLabel12.Location = new System.Drawing.Point(664, 0);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.Size = new System.Drawing.Size(58, 18);
        this.xrLabel12.StyleName = "FieldCaption";
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:#,0}";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel12.Summary = xrSummary7;
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.xrLine1,
            this.xrLabel40,
            this.xrLabel39,
            this.xrLabel38,
            this.xrLabel37,
            this.xrLabel36,
            this.xrLabel35,
            this.xrLabel34,
            this.xrLabel26});
        this.reportHeaderBand1.Height = 69;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        // 
        // xrLabel29
        // 
        this.xrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MiscCredit", "")});
        this.xrLabel29.Location = new System.Drawing.Point(994, 42);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.Size = new System.Drawing.Size(86, 18);
        this.xrLabel29.StyleName = "FieldCaption";
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:C2}";
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel29.Summary = xrSummary8;
        this.xrLabel29.Text = "xrLabel29";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLine1
        // 
        this.xrLine1.Location = new System.Drawing.Point(0, 67);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.Size = new System.Drawing.Size(1283, 2);
        // 
        // xrLabel40
        // 
        this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LDMinutes", "")});
        this.xrLabel40.Location = new System.Drawing.Point(1174, 42);
        this.xrLabel40.Name = "xrLabel40";
        this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel40.Size = new System.Drawing.Size(109, 18);
        this.xrLabel40.StyleName = "FieldCaption";
        this.xrLabel40.StylePriority.UseTextAlignment = false;
        xrSummary9.FormatString = "{0:#,0}";
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel40.Summary = xrSummary9;
        this.xrLabel40.Text = "xrLabel40";
        this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel39
        // 
        this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BridgeMinutes", "")});
        this.xrLabel39.Location = new System.Drawing.Point(1080, 42);
        this.xrLabel39.Name = "xrLabel39";
        this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel39.Size = new System.Drawing.Size(92, 18);
        this.xrLabel39.StyleName = "FieldCaption";
        this.xrLabel39.StylePriority.UseTextAlignment = false;
        xrSummary10.FormatString = "{0:#,0}";
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel39.Summary = xrSummary10;
        this.xrLabel39.Text = "xrLabel39";
        this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel38
        // 
        this.xrLabel38.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MiscRevenue", "{0:C2}")});
        this.xrLabel38.Location = new System.Drawing.Point(900, 42);
        this.xrLabel38.Name = "xrLabel38";
        this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel38.Size = new System.Drawing.Size(92, 18);
        this.xrLabel38.StyleName = "FieldCaption";
        this.xrLabel38.StylePriority.UseTextAlignment = false;
        xrSummary11.FormatString = "{0:C2}";
        xrSummary11.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel38.Summary = xrSummary11;
        this.xrLabel38.Text = "xrLabel38";
        this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel37
        // 
        this.xrLabel37.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LDRevenue", "{0:C2}")});
        this.xrLabel37.Location = new System.Drawing.Point(817, 42);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.Size = new System.Drawing.Size(79, 18);
        this.xrLabel37.StyleName = "FieldCaption";
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        xrSummary12.FormatString = "{0:C2}";
        xrSummary12.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel37.Summary = xrSummary12;
        this.xrLabel37.Text = "xrLabel37";
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel36
        // 
        this.xrLabel36.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BridgeRevenue", "{0:C2}")});
        this.xrLabel36.Location = new System.Drawing.Point(725, 42);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.Size = new System.Drawing.Size(85, 18);
        this.xrLabel36.StyleName = "FieldCaption";
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        xrSummary13.FormatString = "{0:C2}";
        xrSummary13.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel36.Summary = xrSummary13;
        this.xrLabel36.Text = "xrLabel36";
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel35
        // 
        this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Calls", "")});
        this.xrLabel35.Location = new System.Drawing.Point(664, 42);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel35.Size = new System.Drawing.Size(58, 18);
        this.xrLabel35.StyleName = "FieldCaption";
        this.xrLabel35.StylePriority.UseTextAlignment = false;
        xrSummary14.FormatString = "{0:#,0}";
        xrSummary14.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel35.Summary = xrSummary14;
        this.xrLabel35.Text = "xrLabel35";
        this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel34
        // 
        this.xrLabel34.Location = new System.Drawing.Point(0, 40);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.Size = new System.Drawing.Size(228, 18);
        this.xrLabel34.StyleName = "FieldCaption";
        this.xrLabel34.Text = "Grand Total:";
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel26.Location = new System.Drawing.Point(0, 0);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.Size = new System.Drawing.Size(838, 33);
        this.xrLabel26.StyleName = "Title";
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.Text = "Revenue Report";
        // 
        // dsRevenueReport1
        // 
        this.dsRevenueReport1.DataSetName = "dsRevenueReport";
        this.dsRevenueReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // p_UTIL_MGMTRPT_GrossProfitTableAdapter1
        // 
        this.p_UTIL_MGMTRPT_GrossProfitTableAdapter1.ClearBeforeFill = true;
        // 
        // rptRevenueReport
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter,
            this.PageHeader,
            this.groupHeaderBand1,
            this.groupFooterBand1,
            this.reportHeaderBand1});
        this.DataAdapter = this.p_UTIL_MGMTRPT_GrossProfitTableAdapter1;
        this.DataMember = "p_UTIL_MGMTRPT_GrossProfit";
        this.DataSource = this.dsRevenueReport1;
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        this.PageHeight = 850;
        this.PageWidth = 1300;
        this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dsRevenueReport1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
