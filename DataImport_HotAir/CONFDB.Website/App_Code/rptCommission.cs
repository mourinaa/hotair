using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptCommission
/// </summary>
public class rptCommission : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private dsCommissionReport dsCommissionReport1;
    private dsCommissionReportTableAdapters.p_Commission_GetCommissionReportTableAdapter p_Commission_GetCommissionReportTableAdapter1;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private PageHeaderBand PageHeader;
    private XRLine xrLine2;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private GroupFooterBand groupFooterBand1;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel22;
    private ReportFooterBand reportFooterBand1;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private XRLabel xrLabel25;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Added - Extra Public Properties for Binding the Report
    public string WholesalerID;
    public int? SalesPersonID;
    public DateTime? InvoiceDate;
    #endregion

    public rptCommission()
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
        p_Commission_GetCommissionReportTableAdapter1.Fill(
            dsCommissionReport1.p_Commission_GetCommissionReport, WholesalerID, SalesPersonID, InvoiceDate);

        int rows = dsCommissionReport1.Tables[0].Rows.Count;
        if (rows > 0)
        {
            this.DataSource = dsCommissionReport1;
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
        string resourceFileName = "rptCommission.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.dsCommissionReport1 = new dsCommissionReport();
        this.p_Commission_GetCommissionReportTableAdapter1 = new dsCommissionReportTableAdapters.p_Commission_GetCommissionReportTableAdapter();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.dsCommissionReport1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel19,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel16});
        this.Detail.Height = 18;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // dsCommissionReport1
        // 
        this.dsCommissionReport1.DataSetName = "dsCommissionReport";
        this.dsCommissionReport1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // p_Commission_GetCommissionReportTableAdapter1
        // 
        this.p_Commission_GetCommissionReportTableAdapter1.ClearBeforeFill = true;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1});
        this.PageFooter.Height = 29;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine2,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel1});
        this.PageHeader.Height = 45;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
        this.xrLabel1.Location = new System.Drawing.Point(8, 2);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(108, 36);
        this.xrLabel1.StyleName = "FieldCaption";
        this.xrLabel1.Text = "Sales Person";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
        this.xrLabel3.Location = new System.Drawing.Point(125, 2);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.Size = new System.Drawing.Size(169, 36);
        this.xrLabel3.StyleName = "FieldCaption";
        this.xrLabel3.Text = "Company Name";
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
        this.xrLabel4.Location = new System.Drawing.Point(299, 2);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(83, 36);
        this.xrLabel4.StyleName = "FieldCaption";
        this.xrLabel4.Text = "Customer Number";
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 10F);
        this.xrLabel5.Location = new System.Drawing.Point(383, 2);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.Size = new System.Drawing.Size(94, 36);
        this.xrLabel5.StyleName = "FieldCaption";
        this.xrLabel5.Text = "Total Credits";
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 10F);
        this.xrLabel6.Location = new System.Drawing.Point(483, 2);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(108, 36);
        this.xrLabel6.StyleName = "FieldCaption";
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Product Charges";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 10F);
        this.xrLabel7.Location = new System.Drawing.Point(592, 2);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.Size = new System.Drawing.Size(103, 36);
        this.xrLabel7.StyleName = "FieldCaption";
        this.xrLabel7.Text = "Misc Charges";
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Arial", 10F);
        this.xrLabel8.Location = new System.Drawing.Point(697, 2);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.Size = new System.Drawing.Size(117, 36);
        this.xrLabel8.StyleName = "FieldCaption";
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Total Commission";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLine2
        // 
        this.xrLine2.Location = new System.Drawing.Point(8, 42);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.Size = new System.Drawing.Size(808, 2);
        // 
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLabel9});
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("SalesPersonFullName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("BilledDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.Height = 23;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        // 
        // xrLabel9
        // 
        this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.SalesPersonFullName", "")});
        this.xrLabel9.Location = new System.Drawing.Point(6, 0);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.Size = new System.Drawing.Size(112, 23);
        this.xrLabel9.StyleName = "DataField";
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.BilledDate", "{0:MMMM yyyy}")});
        this.xrLabel10.Location = new System.Drawing.Point(125, 0);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.Size = new System.Drawing.Size(133, 23);
        this.xrLabel10.StyleName = "DataField";
        // 
        // groupFooterBand1
        // 
        this.groupFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel12,
            this.xrLabel11});
        this.groupFooterBand1.Height = 18;
        this.groupFooterBand1.Name = "groupFooterBand1";
        // 
        // xrLabel11
        // 
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalCredits", "{0:C2}")});
        this.xrLabel11.Location = new System.Drawing.Point(383, 0);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.Size = new System.Drawing.Size(94, 18);
        this.xrLabel11.StyleName = "FieldCaption";
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:C2}";
        xrSummary4.IgnoreNullValues = true;
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel11.Summary = xrSummary4;
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel12
        // 
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ProductCharges", "{0:C2}")});
        this.xrLabel12.Location = new System.Drawing.Point(483, 0);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.Size = new System.Drawing.Size(108, 18);
        this.xrLabel12.StyleName = "FieldCaption";
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:C2}";
        xrSummary3.IgnoreNullValues = true;
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel12.Summary = xrSummary3;
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MiscCharges", "{0:C2}")});
        this.xrLabel13.Location = new System.Drawing.Point(592, 0);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.Size = new System.Drawing.Size(103, 18);
        this.xrLabel13.StyleName = "FieldCaption";
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:C2}";
        xrSummary2.IgnoreNullValues = true;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel13.Summary = xrSummary2;
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalCommission", "{0:C2}")});
        this.xrLabel14.Location = new System.Drawing.Point(697, 0);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.Size = new System.Drawing.Size(117, 18);
        this.xrLabel14.StyleName = "FieldCaption";
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:C2}";
        xrSummary1.IgnoreNullValues = true;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel14.Summary = xrSummary1;
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel15
        // 
        this.xrLabel15.Location = new System.Drawing.Point(8, 0);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.Size = new System.Drawing.Size(164, 18);
        this.xrLabel15.StyleName = "FieldCaption";
        this.xrLabel15.Text = "SubTotal";
        // 
        // xrLabel16
        // 
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.CompanyName", "")});
        this.xrLabel16.Location = new System.Drawing.Point(125, 0);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.Size = new System.Drawing.Size(169, 18);
        this.xrLabel16.StyleName = "DataField";
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.PriCustomerNumber", "")});
        this.xrLabel17.Location = new System.Drawing.Point(299, 0);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.Size = new System.Drawing.Size(83, 18);
        this.xrLabel17.StyleName = "DataField";
        // 
        // xrLabel18
        // 
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.TotalCredits", "{0:C2}")});
        this.xrLabel18.Location = new System.Drawing.Point(383, 0);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.Size = new System.Drawing.Size(94, 18);
        this.xrLabel18.StyleName = "DataField";
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.ProductCharges", "{0:C2}")});
        this.xrLabel19.Location = new System.Drawing.Point(483, 0);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.Size = new System.Drawing.Size(108, 18);
        this.xrLabel19.StyleName = "DataField";
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel20
        // 
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.MiscCharges", "{0:C2}")});
        this.xrLabel20.Location = new System.Drawing.Point(592, 0);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.Size = new System.Drawing.Size(103, 18);
        this.xrLabel20.StyleName = "DataField";
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Commission_GetCommissionReport.TotalCommission", "{0:C2}")});
        this.xrLabel21.Location = new System.Drawing.Point(697, 0);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.Size = new System.Drawing.Size(117, 18);
        this.xrLabel21.StyleName = "DataField";
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Location = new System.Drawing.Point(6, 6);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.Size = new System.Drawing.Size(319, 23);
        this.xrPageInfo1.StyleName = "PageInfo";
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Format = "Page {0} of {1}";
        this.xrPageInfo2.Location = new System.Drawing.Point(331, 6);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.Size = new System.Drawing.Size(444, 23);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22});
        this.reportHeaderBand1.Height = 38;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
        this.xrLabel22.Location = new System.Drawing.Point(6, 2);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.Size = new System.Drawing.Size(638, 33);
        this.xrLabel22.StyleName = "Title";
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.Text = "Commission Report";
        // 
        // reportFooterBand1
        // 
        this.reportFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel27,
            this.xrLabel26,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel23});
        this.reportFooterBand1.Height = 18;
        this.reportFooterBand1.Name = "reportFooterBand1";
        // 
        // xrLabel23
        // 
        this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalCredits", "{0:C2}")});
        this.xrLabel23.Location = new System.Drawing.Point(383, 0);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.Size = new System.Drawing.Size(94, 18);
        this.xrLabel23.StyleName = "FieldCaption";
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:C2}";
        xrSummary8.IgnoreNullValues = true;
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel23.Summary = xrSummary8;
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel24
        // 
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ProductCharges", "{0:C2}")});
        this.xrLabel24.Location = new System.Drawing.Point(483, 0);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.Size = new System.Drawing.Size(108, 18);
        this.xrLabel24.StyleName = "FieldCaption";
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:C2}";
        xrSummary7.IgnoreNullValues = true;
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel24.Summary = xrSummary7;
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel25
        // 
        this.xrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MiscCharges", "{0:C2}")});
        this.xrLabel25.Location = new System.Drawing.Point(592, 0);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.Size = new System.Drawing.Size(103, 18);
        this.xrLabel25.StyleName = "FieldCaption";
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:C2}";
        xrSummary6.IgnoreNullValues = true;
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel25.Summary = xrSummary6;
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel26
        // 
        this.xrLabel26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalCommission", "{0:C2}")});
        this.xrLabel26.Location = new System.Drawing.Point(697, 0);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.Size = new System.Drawing.Size(117, 18);
        this.xrLabel26.StyleName = "FieldCaption";
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:C2}";
        xrSummary5.IgnoreNullValues = true;
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel26.Summary = xrSummary5;
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Location = new System.Drawing.Point(6, 0);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.Size = new System.Drawing.Size(164, 18);
        this.xrLabel27.StyleName = "FieldCaption";
        this.xrLabel27.Text = "Grand Total";
        // 
        // rptCommission
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter,
            this.PageHeader,
            this.groupHeaderBand1,
            this.groupFooterBand1,
            this.reportHeaderBand1,
            this.reportFooterBand1});
        this.DataAdapter = this.p_Commission_GetCommissionReportTableAdapter1;
        this.DataMember = "p_Commission_GetCommissionReport";
        this.DataSource = this.dsCommissionReport1;
        this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dsCommissionReport1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
