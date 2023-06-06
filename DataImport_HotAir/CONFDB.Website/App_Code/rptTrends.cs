using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

/// <summary>
/// Summary description for rptTrends
/// </summary>
public class rptTrends : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private dsTrends dsTrends1;
    private dsTrendsTableAdapters.p_UTIL_MGMTRPT_TrendsTableAdapter p_UTIL_MGMTRPT_TrendsTableAdapter1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell24;
    private XRTableCell xrTableCell26;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel1;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCellMonth1;
    private XRTableCell xrTableCellMonth2;
    private XRTableCell xrTableCellMonth3;
    private XRTableCell xrTableCellMonth4;
    private XRTableCell xrTableCellMonth5;
    private XRTableCell xrTableCellMonth6;
    private XRTableCell xrTableCellMonth7;
    private XRTableCell xrTableCellMonth8;
    private XRTableCell xrTableCellMonth9;
    private XRTableCell xrTableCellMonth10;
    private XRTableCell xrTableCellMonth11;
    private XRTableCell xrTableCellMonth12;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
 #region Added - Extra Public Properties for Binding the Report
    public string WholesalerID;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    public int? SalesPersonID;
    #endregion

    public rptTrends()
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
        p_UTIL_MGMTRPT_TrendsTableAdapter1.Fill(
            dsTrends1.p_UTIL_MGMTRPT_Trends, WholesalerID, SalesPersonID);

        int rows = dsTrends1.Tables[0].Rows.Count;
        if (rows > 0)
        {
            //If there data then we need to change the name of the columns to match the 12 month period
            //TODO: Get the first row and parse the startdate then loop for 12 months
            DataRow row = dsTrends1.Tables[0].Rows[0];
            DateTime dt1 = DateTime.Parse(row["StartDate"].ToString());
            string LabelFormat = "MMMyyyy"; //e.g Apr2008
           
            //loop thru and change the label names to MonthYear
            for (int i = 1; i <= 12; i++)
            {
                switch (i)
                {
                    case 1:
                        xrTableCellMonth1.Text = dt1.ToString(LabelFormat);
                        break;
                    case 2:
                        xrTableCellMonth2.Text = dt1.ToString(LabelFormat);
                        break;
                    case 3:
                        xrTableCellMonth3.Text = dt1.ToString(LabelFormat);
                        break;
                    case 4:
                        xrTableCellMonth4.Text = dt1.ToString(LabelFormat);
                        break;
                    case 5:
                        xrTableCellMonth5.Text = dt1.ToString(LabelFormat);
                        break;
                    case 6:
                        xrTableCellMonth6.Text = dt1.ToString(LabelFormat);
                        break;
                    case 7:
                        xrTableCellMonth7.Text = dt1.ToString(LabelFormat);
                        break;
                    case 8:
                        xrTableCellMonth8.Text = dt1.ToString(LabelFormat);
                        break;
                    case 9:
                        xrTableCellMonth9.Text = dt1.ToString(LabelFormat);
                        break;
                    case 10:
                        xrTableCellMonth10.Text = dt1.ToString(LabelFormat);
                        break;
                    case 11:
                        xrTableCellMonth11.Text = dt1.ToString(LabelFormat);
                        break;
                    case 12:
                        xrTableCellMonth12.Text = dt1.ToString(LabelFormat);
                        break;
                }
                //Add a month
                dt1 = dt1.AddMonths(1);
            }

            this.DataSource = dsTrends1;
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
        string resourceFileName = "rptTrends.resx";
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.dsTrends1 = new dsTrends();
        this.p_UTIL_MGMTRPT_TrendsTableAdapter1 = new dsTrendsTableAdapters.p_UTIL_MGMTRPT_TrendsTableAdapter();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCellMonth12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dsTrends1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.Height = 33;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
        this.xrTable2.Location = new System.Drawing.Point(6, 0);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.Size = new System.Drawing.Size(1877, 33);
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell13,
            this.xrTableCell7,
            this.xrTableCell9,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell10,
            this.xrTableCell12,
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell18,
            this.xrTableCell20,
            this.xrTableCell22,
            this.xrTableCell24,
            this.xrTableCell26});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Size = new System.Drawing.Size(1877, 33);
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.CanGrow = false;
        this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CompanyName", "")});
        this.xrTableCell2.Location = new System.Drawing.Point(0, 0);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell2.Size = new System.Drawing.Size(232, 33);
        this.xrTableCell2.StyleName = "DataField";
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.CanGrow = false;
        this.xrTableCell13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_Trends.DateProvisioned", "{0:dd/MM/yyyy}")});
        this.xrTableCell13.Location = new System.Drawing.Point(232, 0);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell13.Size = new System.Drawing.Size(131, 33);
        this.xrTableCell13.StyleName = "DataField";
        this.xrTableCell13.Text = "xrTableCell13";
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.CanGrow = false;
        this.xrTableCell7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_Trends.AccountManager", "")});
        this.xrTableCell7.Location = new System.Drawing.Point(363, 0);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell7.Size = new System.Drawing.Size(131, 33);
        this.xrTableCell7.StyleName = "DataField";
        this.xrTableCell7.Text = "xrTableCell7";
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.CanGrow = false;
        this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_UTIL_MGMTRPT_Trends.SalesPerson", "")});
        this.xrTableCell9.Location = new System.Drawing.Point(494, 0);
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell9.Size = new System.Drawing.Size(168, 33);
        this.xrTableCell9.StyleName = "DataField";
        this.xrTableCell9.Text = "xrTableCell9";
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.CanGrow = false;
        this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth01", "{0:$0.00}")});
        this.xrTableCell4.Location = new System.Drawing.Point(662, 0);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell4.Size = new System.Drawing.Size(102, 33);
        this.xrTableCell4.StyleName = "DataField";
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.CanGrow = false;
        this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth02", "{0:$0.00}")});
        this.xrTableCell6.Location = new System.Drawing.Point(764, 0);
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell6.Size = new System.Drawing.Size(92, 33);
        this.xrTableCell6.StyleName = "DataField";
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.CanGrow = false;
        this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth03", "{0:$0.00}")});
        this.xrTableCell8.Location = new System.Drawing.Point(856, 0);
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell8.Size = new System.Drawing.Size(111, 33);
        this.xrTableCell8.StyleName = "DataField";
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.CanGrow = false;
        this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth04", "{0:$0.00}")});
        this.xrTableCell10.Location = new System.Drawing.Point(967, 0);
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell10.Size = new System.Drawing.Size(102, 33);
        this.xrTableCell10.StyleName = "DataField";
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.CanGrow = false;
        this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth05", "{0:$0.00}")});
        this.xrTableCell12.Location = new System.Drawing.Point(1069, 0);
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell12.Size = new System.Drawing.Size(96, 33);
        this.xrTableCell12.StyleName = "DataField";
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.CanGrow = false;
        this.xrTableCell14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth06", "{0:$0.00}")});
        this.xrTableCell14.Location = new System.Drawing.Point(1165, 0);
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell14.Size = new System.Drawing.Size(111, 33);
        this.xrTableCell14.StyleName = "DataField";
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.CanGrow = false;
        this.xrTableCell16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth07", "{0:$0.00}")});
        this.xrTableCell16.Location = new System.Drawing.Point(1276, 0);
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell16.Size = new System.Drawing.Size(103, 33);
        this.xrTableCell16.StyleName = "DataField";
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.CanGrow = false;
        this.xrTableCell18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth08", "{0:$0.00}")});
        this.xrTableCell18.Location = new System.Drawing.Point(1379, 0);
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell18.Size = new System.Drawing.Size(93, 33);
        this.xrTableCell18.StyleName = "DataField";
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.CanGrow = false;
        this.xrTableCell20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth09", "{0:$0.00}")});
        this.xrTableCell20.Location = new System.Drawing.Point(1472, 0);
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell20.Size = new System.Drawing.Size(111, 33);
        this.xrTableCell20.StyleName = "DataField";
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.CanGrow = false;
        this.xrTableCell22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth10", "{0:$0.00}")});
        this.xrTableCell22.Location = new System.Drawing.Point(1583, 0);
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell22.Size = new System.Drawing.Size(103, 33);
        this.xrTableCell22.StyleName = "DataField";
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.CanGrow = false;
        this.xrTableCell24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth11", "{0:$0.00}")});
        this.xrTableCell24.Location = new System.Drawing.Point(1686, 0);
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell24.Size = new System.Drawing.Size(92, 33);
        this.xrTableCell24.StyleName = "DataField";
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.CanGrow = false;
        this.xrTableCell26.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "TotalRevenueMonth12", "{0:$0.00}")});
        this.xrTableCell26.Location = new System.Drawing.Point(1778, 0);
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell26.Size = new System.Drawing.Size(99, 33);
        this.xrTableCell26.StyleName = "DataField";
        // 
        // dsTrends1
        // 
        this.dsTrends1.DataSetName = "dsTrends";
        this.dsTrends1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // p_UTIL_MGMTRPT_TrendsTableAdapter1
        // 
        this.p_UTIL_MGMTRPT_TrendsTableAdapter1.ClearBeforeFill = true;
        // 
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
        this.reportHeaderBand1.Height = 33;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel1.Location = new System.Drawing.Point(6, 6);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(1010, 27);
        this.xrLabel1.StyleName = "Title";
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "Trends Report";
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.Height = 36;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable1
        // 
        this.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
        this.xrTable1.Location = new System.Drawing.Point(6, 0);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.Size = new System.Drawing.Size(1877, 36);
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell11,
            this.xrTableCell5,
            this.xrTableCell3,
            this.xrTableCellMonth1,
            this.xrTableCellMonth2,
            this.xrTableCellMonth3,
            this.xrTableCellMonth4,
            this.xrTableCellMonth5,
            this.xrTableCellMonth6,
            this.xrTableCellMonth7,
            this.xrTableCellMonth8,
            this.xrTableCellMonth9,
            this.xrTableCellMonth10,
            this.xrTableCellMonth11,
            this.xrTableCellMonth12});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Size = new System.Drawing.Size(1877, 36);
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.CanGrow = false;
        this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell1.Size = new System.Drawing.Size(232, 36);
        this.xrTableCell1.StyleName = "FieldCaption";
        this.xrTableCell1.Text = "Company Name";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.CanGrow = false;
        this.xrTableCell11.Location = new System.Drawing.Point(232, 0);
        this.xrTableCell11.Multiline = true;
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell11.Size = new System.Drawing.Size(131, 36);
        this.xrTableCell11.StyleName = "FieldCaption";
        this.xrTableCell11.Text = "Date \r\nProvisioned";
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.CanGrow = false;
        this.xrTableCell5.Location = new System.Drawing.Point(363, 0);
        this.xrTableCell5.Multiline = true;
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell5.Size = new System.Drawing.Size(131, 36);
        this.xrTableCell5.StyleName = "FieldCaption";
        this.xrTableCell5.Text = "Account\r\nManager";
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.CanGrow = false;
        this.xrTableCell3.Location = new System.Drawing.Point(494, 0);
        this.xrTableCell3.Multiline = true;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell3.Size = new System.Drawing.Size(168, 36);
        this.xrTableCell3.StyleName = "FieldCaption";
        this.xrTableCell3.Text = "Sales\r\nPerson";
        // 
        // xrTableCellMonth1
        // 
        this.xrTableCellMonth1.CanGrow = false;
        this.xrTableCellMonth1.Location = new System.Drawing.Point(662, 0);
        this.xrTableCellMonth1.Name = "xrTableCellMonth1";
        this.xrTableCellMonth1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth1.Size = new System.Drawing.Size(103, 36);
        this.xrTableCellMonth1.StyleName = "FieldCaption";
        this.xrTableCellMonth1.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth1.Text = "Total Revenue Month01";
        this.xrTableCellMonth1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth2
        // 
        this.xrTableCellMonth2.CanGrow = false;
        this.xrTableCellMonth2.Location = new System.Drawing.Point(765, 0);
        this.xrTableCellMonth2.Name = "xrTableCellMonth2";
        this.xrTableCellMonth2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth2.Size = new System.Drawing.Size(93, 36);
        this.xrTableCellMonth2.StyleName = "FieldCaption";
        this.xrTableCellMonth2.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth2.Text = "Total Revenue Month02";
        this.xrTableCellMonth2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth3
        // 
        this.xrTableCellMonth3.CanGrow = false;
        this.xrTableCellMonth3.Location = new System.Drawing.Point(858, 0);
        this.xrTableCellMonth3.Name = "xrTableCellMonth3";
        this.xrTableCellMonth3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth3.Size = new System.Drawing.Size(111, 36);
        this.xrTableCellMonth3.StyleName = "FieldCaption";
        this.xrTableCellMonth3.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth3.Text = "Total Revenue Month03";
        this.xrTableCellMonth3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth4
        // 
        this.xrTableCellMonth4.CanGrow = false;
        this.xrTableCellMonth4.Location = new System.Drawing.Point(969, 0);
        this.xrTableCellMonth4.Name = "xrTableCellMonth4";
        this.xrTableCellMonth4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth4.Size = new System.Drawing.Size(103, 36);
        this.xrTableCellMonth4.StyleName = "FieldCaption";
        this.xrTableCellMonth4.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth4.Text = "Total Revenue Month04";
        this.xrTableCellMonth4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth5
        // 
        this.xrTableCellMonth5.CanGrow = false;
        this.xrTableCellMonth5.Location = new System.Drawing.Point(1072, 0);
        this.xrTableCellMonth5.Name = "xrTableCellMonth5";
        this.xrTableCellMonth5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth5.Size = new System.Drawing.Size(93, 36);
        this.xrTableCellMonth5.StyleName = "FieldCaption";
        this.xrTableCellMonth5.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth5.Text = "Total Revenue Month05";
        this.xrTableCellMonth5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth6
        // 
        this.xrTableCellMonth6.CanGrow = false;
        this.xrTableCellMonth6.Location = new System.Drawing.Point(1165, 0);
        this.xrTableCellMonth6.Name = "xrTableCellMonth6";
        this.xrTableCellMonth6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth6.Size = new System.Drawing.Size(111, 36);
        this.xrTableCellMonth6.StyleName = "FieldCaption";
        this.xrTableCellMonth6.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth6.Text = "Total Revenue Month06";
        this.xrTableCellMonth6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth7
        // 
        this.xrTableCellMonth7.CanGrow = false;
        this.xrTableCellMonth7.Location = new System.Drawing.Point(1276, 0);
        this.xrTableCellMonth7.Name = "xrTableCellMonth7";
        this.xrTableCellMonth7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth7.Size = new System.Drawing.Size(103, 36);
        this.xrTableCellMonth7.StyleName = "FieldCaption";
        this.xrTableCellMonth7.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth7.Text = "Total Revenue Month07";
        this.xrTableCellMonth7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth8
        // 
        this.xrTableCellMonth8.CanGrow = false;
        this.xrTableCellMonth8.Location = new System.Drawing.Point(1379, 0);
        this.xrTableCellMonth8.Name = "xrTableCellMonth8";
        this.xrTableCellMonth8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth8.Size = new System.Drawing.Size(93, 36);
        this.xrTableCellMonth8.StyleName = "FieldCaption";
        this.xrTableCellMonth8.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth8.Text = "Total Revenue Month08";
        this.xrTableCellMonth8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth9
        // 
        this.xrTableCellMonth9.CanGrow = false;
        this.xrTableCellMonth9.Location = new System.Drawing.Point(1472, 0);
        this.xrTableCellMonth9.Name = "xrTableCellMonth9";
        this.xrTableCellMonth9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth9.Size = new System.Drawing.Size(111, 36);
        this.xrTableCellMonth9.StyleName = "FieldCaption";
        this.xrTableCellMonth9.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth9.Text = "Total Revenue Month09";
        this.xrTableCellMonth9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth10
        // 
        this.xrTableCellMonth10.CanGrow = false;
        this.xrTableCellMonth10.Location = new System.Drawing.Point(1583, 0);
        this.xrTableCellMonth10.Name = "xrTableCellMonth10";
        this.xrTableCellMonth10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth10.Size = new System.Drawing.Size(103, 36);
        this.xrTableCellMonth10.StyleName = "FieldCaption";
        this.xrTableCellMonth10.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth10.Text = "Total Revenue Month10";
        this.xrTableCellMonth10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth11
        // 
        this.xrTableCellMonth11.CanGrow = false;
        this.xrTableCellMonth11.Location = new System.Drawing.Point(1686, 0);
        this.xrTableCellMonth11.Name = "xrTableCellMonth11";
        this.xrTableCellMonth11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth11.Size = new System.Drawing.Size(92, 36);
        this.xrTableCellMonth11.StyleName = "FieldCaption";
        this.xrTableCellMonth11.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth11.Text = "Total Revenue Month11";
        this.xrTableCellMonth11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableCellMonth12
        // 
        this.xrTableCellMonth12.CanGrow = false;
        this.xrTableCellMonth12.Location = new System.Drawing.Point(1778, 0);
        this.xrTableCellMonth12.Name = "xrTableCellMonth12";
        this.xrTableCellMonth12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCellMonth12.Size = new System.Drawing.Size(99, 36);
        this.xrTableCellMonth12.StyleName = "FieldCaption";
        this.xrTableCellMonth12.StylePriority.UseTextAlignment = false;
        this.xrTableCellMonth12.Text = "Total Revenue Month12";
        this.xrTableCellMonth12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
        // xrPageInfo2
        // 
        this.xrPageInfo2.Format = "Page {0} of {1}";
        this.xrPageInfo2.Location = new System.Drawing.Point(656, 6);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.Size = new System.Drawing.Size(638, 23);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Location = new System.Drawing.Point(6, 6);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.Size = new System.Drawing.Size(638, 23);
        this.xrPageInfo1.StyleName = "PageInfo";
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
        this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
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
        // rptTrends
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.reportHeaderBand1,
            this.PageHeader,
            this.PageFooter});
        this.DataAdapter = this.p_UTIL_MGMTRPT_TrendsTableAdapter1;
        this.DataMember = "p_UTIL_MGMTRPT_Trends";
        this.DataSource = this.dsTrends1;
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        this.PageHeight = 850;
        this.PageWidth = 1900;
        this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dsTrends1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
