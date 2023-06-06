using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;

/// <summary>
/// Summary description for CallDetailsForModerator
/// </summary>
public class CallDetailsForModerator : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    private System.Data.SqlClient.SqlConnection sqlConnection1;
    private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;



    private int TotalSecsReport;

    private DateTime startTime;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private XRLine xrLine2;
    private ReportFooterBand reportFooterBand1;
    private XRLabel xrLabel17;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private ReportHeaderBand reportHeaderBand1;
    private XRLine xrLine3;
    private GroupFooterBand groupFooterBand2;
    private XRLabel xrLabel19;
    private XRLabel xrLabel18;
    private XRLabel xrLabel13;
    private XRCrossBandBox xrCrossBandBox1;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;

    private int userID;
    private dsCallDetailsForModerator dsCallDetailsForModerator1;
    private XRLabel xrLabel16;
    private XRLabel xrLabel20;

    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    public DateTime StartTime
    {
        get { return startTime; }
        set { startTime = value; }
    }

    private DateTime endTime;

    public DateTime EndTime
    {
        get { return endTime; }
        set { endTime = value; }
    }
	
	public CallDetailsForModerator()
	{
		//
		// TODO: Add construc
        TotalSecsReport = 0;
	}

    public int BindData()
    {
        //
        // TODO: Add constructor logic here
        //
        InitializeComponent();

        this.sqlConnection1.ConnectionString = ConfigurationManager.ConnectionStrings["CONFDBConnectionString"].ToString();

        sqlDataAdapter1.SelectCommand.Parameters["@UserID"].Value = userID;
        sqlDataAdapter1.SelectCommand.Parameters["@StartTime"].Value = startTime;
        sqlDataAdapter1.SelectCommand.Parameters["@EndTime"].Value = endTime;

        dsCallDetailsForModerator ds = new dsCallDetailsForModerator();
        ds.EnforceConstraints = false;
        sqlDataAdapter1.Fill(ds);
        this.DataSource = ds.Tables[0];

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
        string resourceFileName = "CallDetailsForModerator.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
        this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
        this.groupFooterBand2 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
        this.dsCallDetailsForModerator1 = new dsCallDetailsForModerator();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.dsCallDetailsForModerator1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8});
        this.Detail.Height = 18;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel12
        // 
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForModerator.RetailTotal", "{0:C2}")});
        this.xrLabel12.Location = new System.Drawing.Point(533, 0);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.Size = new System.Drawing.Size(106, 18);
        this.xrLabel12.StyleName = "DataField";
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel11
        // 
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForModerator.CallerID", "")});
        this.xrLabel11.Location = new System.Drawing.Point(392, 0);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.Size = new System.Drawing.Size(133, 18);
        this.xrLabel11.StyleName = "DataField";
        this.xrLabel11.Text = "xrLabel11";
        this.xrLabel11.WordWrap = false;
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForModerator.ElapsedTime", "")});
        this.xrLabel10.Location = new System.Drawing.Point(283, 0);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.Size = new System.Drawing.Size(92, 18);
        this.xrLabel10.StyleName = "DataField";
        this.xrLabel10.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplay);
        // 
        // xrLabel9
        // 
        this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForModerator.EndTime", "")});
        this.xrLabel9.Location = new System.Drawing.Point(142, 0);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.Size = new System.Drawing.Size(134, 18);
        this.xrLabel9.StyleName = "DataField";
        this.xrLabel9.WordWrap = false;
        // 
        // xrLabel8
        // 
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForModerator.StartTime", "")});
        this.xrLabel8.Location = new System.Drawing.Point(6, 0);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.Size = new System.Drawing.Size(135, 18);
        this.xrLabel8.StyleName = "DataField";
        this.xrLabel8.WordWrap = false;
        // 
        // sqlSelectCommand1
        // 
        this.sqlSelectCommand1.CommandText = "dbo.p_RatedCDR_GetCallDetailsForModerator";
        this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        this.sqlSelectCommand1.Connection = this.sqlConnection1;
        this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8)});
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
            new System.Data.Common.DataTableMapping("Table", "p_RatedCDR_GetCallDetailsForModerator", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("ID", "ID"),
                        new System.Data.Common.DataColumnMapping("ConferenceID", "ConferenceID"),
                        new System.Data.Common.DataColumnMapping("ModeratorID", "ModeratorID"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("WholesalerID", "WholesalerID"),
                        new System.Data.Common.DataColumnMapping("ModeratorCode", "ModeratorCode"),
                        new System.Data.Common.DataColumnMapping("PassCode", "PassCode"),
                        new System.Data.Common.DataColumnMapping("ModeratorName", "ModeratorName"),
                        new System.Data.Common.DataColumnMapping("Moderator", "Moderator"),
                        new System.Data.Common.DataColumnMapping("ExternalCustomerNumber", "ExternalCustomerNumber"),
                        new System.Data.Common.DataColumnMapping("ExternalModeratorNumber", "ExternalModeratorNumber"),
                        new System.Data.Common.DataColumnMapping("ReferenceNumber", "ReferenceNumber"),
                        new System.Data.Common.DataColumnMapping("ConferenceStartTime", "ConferenceStartTime"),
                        new System.Data.Common.DataColumnMapping("ConferenceEndTime", "ConferenceEndTime"),
                        new System.Data.Common.DataColumnMapping("ConferenceElapsedTime", "ConferenceElapsedTime"),
                        new System.Data.Common.DataColumnMapping("StartTime", "StartTime"),
                        new System.Data.Common.DataColumnMapping("EndTime", "EndTime"),
                        new System.Data.Common.DataColumnMapping("ElapsedTime", "ElapsedTime"),
                        new System.Data.Common.DataColumnMapping("BridgeID", "BridgeID"),
                        new System.Data.Common.DataColumnMapping("UniqueConferenceID", "UniqueConferenceID"),
                        new System.Data.Common.DataColumnMapping("AuxiliaryConferenceID", "AuxiliaryConferenceID"),
                        new System.Data.Common.DataColumnMapping("DNIS", "DNIS"),
                        new System.Data.Common.DataColumnMapping("DialNumber", "DialNumber"),
                        new System.Data.Common.DataColumnMapping("ANI", "ANI"),
                        new System.Data.Common.DataColumnMapping("ParticipantName", "ParticipantName"),
                        new System.Data.Common.DataColumnMapping("Destination", "Destination"),
                        new System.Data.Common.DataColumnMapping("AccessTypeID", "AccessTypeID"),
                        new System.Data.Common.DataColumnMapping("ConnectProductRateID", "ConnectProductRateID"),
                        new System.Data.Common.DataColumnMapping("BridgeProductRateID", "BridgeProductRateID"),
                        new System.Data.Common.DataColumnMapping("LDProductRateID", "LDProductRateID"),
                        new System.Data.Common.DataColumnMapping("ProductRateTaxableValue", "ProductRateTaxableValue"),
                        new System.Data.Common.DataColumnMapping("CustomerTaxableValue", "CustomerTaxableValue"),
                        new System.Data.Common.DataColumnMapping("WSTaxableValue", "WSTaxableValue"),
                        new System.Data.Common.DataColumnMapping("RetailConnectCharge", "RetailConnectCharge"),
                        new System.Data.Common.DataColumnMapping("RetailBridgeRate", "RetailBridgeRate"),
                        new System.Data.Common.DataColumnMapping("RetailLDRate", "RetailLDRate"),
                        new System.Data.Common.DataColumnMapping("RetailCurrency", "RetailCurrency"),
                        new System.Data.Common.DataColumnMapping("RetailBillingInterval", "RetailBillingInterval"),
                        new System.Data.Common.DataColumnMapping("RetailTotalConnectCharge", "RetailTotalConnectCharge"),
                        new System.Data.Common.DataColumnMapping("RetailTotalBridge", "RetailTotalBridge"),
                        new System.Data.Common.DataColumnMapping("RetailTotalLD", "RetailTotalLD"),
                        new System.Data.Common.DataColumnMapping("RetailTotal", "RetailTotal"),
                        new System.Data.Common.DataColumnMapping("RetailTotalCredit", "RetailTotalCredit"),
                        new System.Data.Common.DataColumnMapping("RetailLocalTaxRate", "RetailLocalTaxRate"),
                        new System.Data.Common.DataColumnMapping("RetailFederalTaxRate", "RetailFederalTaxRate"),
                        new System.Data.Common.DataColumnMapping("RetailLocalTax", "RetailLocalTax"),
                        new System.Data.Common.DataColumnMapping("RetailFederalTax", "RetailFederalTax"),
                        new System.Data.Common.DataColumnMapping("RetailTotalTax", "RetailTotalTax"),
                        new System.Data.Common.DataColumnMapping("WSConnectCharge", "WSConnectCharge"),
                        new System.Data.Common.DataColumnMapping("WSBridgeRate", "WSBridgeRate"),
                        new System.Data.Common.DataColumnMapping("WSLDRate", "WSLDRate"),
                        new System.Data.Common.DataColumnMapping("WSCurrency", "WSCurrency"),
                        new System.Data.Common.DataColumnMapping("WSBillingInterval", "WSBillingInterval"),
                        new System.Data.Common.DataColumnMapping("WSTotalConnectCharge", "WSTotalConnectCharge"),
                        new System.Data.Common.DataColumnMapping("WSTotalBridge", "WSTotalBridge"),
                        new System.Data.Common.DataColumnMapping("WSTotalLD", "WSTotalLD"),
                        new System.Data.Common.DataColumnMapping("WSTotal", "WSTotal"),
                        new System.Data.Common.DataColumnMapping("WSLocalTaxRate", "WSLocalTaxRate"),
                        new System.Data.Common.DataColumnMapping("WSFederalTaxRate", "WSFederalTaxRate"),
                        new System.Data.Common.DataColumnMapping("WSLocalTax", "WSLocalTax"),
                        new System.Data.Common.DataColumnMapping("WSFederalTax", "WSFederalTax"),
                        new System.Data.Common.DataColumnMapping("WSTotalTax", "WSTotalTax"),
                        new System.Data.Common.DataColumnMapping("BillingStatus", "BillingStatus"),
                        new System.Data.Common.DataColumnMapping("BilledDate", "BilledDate"),
                        new System.Data.Common.DataColumnMapping("ProcessedDate", "ProcessedDate"),
                        new System.Data.Common.DataColumnMapping("CallerID", "CallerID")})});
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1,
            this.xrLine2});
        this.PageFooter.Height = 31;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Format = "Page {0} of {1}";
        this.xrPageInfo2.Location = new System.Drawing.Point(331, 8);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.Size = new System.Drawing.Size(313, 23);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Location = new System.Drawing.Point(6, 8);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.Size = new System.Drawing.Size(313, 23);
        this.xrPageInfo1.StyleName = "PageInfo";
        // 
        // xrLine2
        // 
        this.xrLine2.Location = new System.Drawing.Point(6, 0);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.Size = new System.Drawing.Size(638, 2);
        // 
        // reportFooterBand1
        // 
        this.reportFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel17,
            this.xrLabel14});
        this.reportFooterBand1.Height = 42;
        this.reportFooterBand1.Name = "reportFooterBand1";
        this.reportFooterBand1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplayFooterSummary);
        // 
        // xrLabel17
        // 
        this.xrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RetailTotal", "{0:C2}")});
        this.xrLabel17.Location = new System.Drawing.Point(492, 8);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.Size = new System.Drawing.Size(150, 18);
        this.xrLabel17.StyleName = "FieldCaption";
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        xrSummary1.FormatString = "{0:C2}";
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel17.Summary = xrSummary1;
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel14.ForeColor = System.Drawing.Color.Maroon;
        this.xrLabel14.Location = new System.Drawing.Point(283, 8);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.Size = new System.Drawing.Size(100, 17);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseForeColor = false;
        this.xrLabel14.Text = "xrLabel14";
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
            this.xrLabel20,
            this.xrLabel16,
            this.xrLabel1,
            this.xrLabel2});
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("UniqueConferenceID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
        this.groupHeaderBand1.Height = 42;
        this.groupHeaderBand1.KeepTogether = true;
        this.groupHeaderBand1.Level = 1;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Location = new System.Drawing.Point(8, 8);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(108, 25);
        this.xrLabel1.StyleName = "FieldCaption";
        this.xrLabel1.Text = "Conference ID:";
        // 
        // xrLabel2
        // 
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForModerator.UniqueConferenceID", "")});
        this.xrLabel2.Location = new System.Drawing.Point(117, 8);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.Size = new System.Drawing.Size(150, 25);
        this.xrLabel2.StyleName = "DataField";
        // 
        // groupHeaderBand2
        // 
        this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3});
        this.groupHeaderBand2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
        this.groupHeaderBand2.Height = 26;
        this.groupHeaderBand2.KeepTogether = true;
        this.groupHeaderBand2.Name = "groupHeaderBand2";
        // 
        // xrLabel7
        // 
        this.xrLabel7.Location = new System.Drawing.Point(494, 6);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.Size = new System.Drawing.Size(150, 18);
        this.xrLabel7.StyleName = "FieldCaption";
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Amount";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Location = new System.Drawing.Point(392, 8);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(67, 18);
        this.xrLabel6.StyleName = "FieldCaption";
        this.xrLabel6.Text = "Caller ID";
        // 
        // xrLabel5
        // 
        this.xrLabel5.Location = new System.Drawing.Point(283, 8);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.Size = new System.Drawing.Size(101, 18);
        this.xrLabel5.StyleName = "FieldCaption";
        this.xrLabel5.Text = "Duration";
        // 
        // xrLabel4
        // 
        this.xrLabel4.Location = new System.Drawing.Point(142, 8);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(125, 18);
        this.xrLabel4.StyleName = "FieldCaption";
        this.xrLabel4.Text = "End Time";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Location = new System.Drawing.Point(6, 6);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.Size = new System.Drawing.Size(135, 18);
        this.xrLabel3.StyleName = "FieldCaption";
        this.xrLabel3.Text = "Start Time";
        // 
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel15,
            this.xrLine3});
        this.reportHeaderBand1.Height = 56;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        this.reportHeaderBand1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplayFooterSummary);
        // 
        // xrLabel15
        // 
        this.xrLabel15.Location = new System.Drawing.Point(6, 2);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.Size = new System.Drawing.Size(638, 33);
        this.xrLabel15.StyleName = "Title";
        this.xrLabel15.Text = "Call Details ";
        // 
        // xrLine3
        // 
        this.xrLine3.Location = new System.Drawing.Point(6, 0);
        this.xrLine3.Name = "xrLine3";
        this.xrLine3.Size = new System.Drawing.Size(638, 2);
        // 
        // groupFooterBand2
        // 
        this.groupFooterBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabel19,
            this.xrLabel18});
        this.groupFooterBand2.Height = 49;
        this.groupFooterBand2.KeepTogether = true;
        this.groupFooterBand2.Name = "groupFooterBand2";
        // 
        // xrLabel13
        // 
        this.xrLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel13.ForeColor = System.Drawing.Color.Maroon;
        this.xrLabel13.Location = new System.Drawing.Point(283, 8);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.Size = new System.Drawing.Size(100, 17);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseForeColor = false;
        this.xrLabel13.Text = "xrLabel13";
        this.xrLabel13.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplaySummary);
        // 
        // xrLabel19
        // 
        this.xrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RetailTotal", "{0:C2}")});
        this.xrLabel19.Location = new System.Drawing.Point(494, 6);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.Size = new System.Drawing.Size(150, 18);
        this.xrLabel19.StyleName = "FieldCaption";
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:C2}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel19.Summary = xrSummary2;
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel18
        // 
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ElapsedTime", "")});
        this.xrLabel18.Location = new System.Drawing.Point(150, 8);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.Size = new System.Drawing.Size(83, 18);
        this.xrLabel18.StyleName = "FieldCaption";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel18.Summary = xrSummary3;
        this.xrLabel18.Visible = false;
        this.xrLabel18.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplaySummary);
        // 
        // xrCrossBandBox1
        // 
        this.xrCrossBandBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
        this.xrCrossBandBox1.BorderColor = System.Drawing.SystemColors.ControlLight;
        this.xrCrossBandBox1.EndBand = this.groupFooterBand2;
        this.xrCrossBandBox1.EndPoint = new System.Drawing.Point(0, 30);
        this.xrCrossBandBox1.Name = "xrCrossBandBox1";
        this.xrCrossBandBox1.StartBand = this.groupHeaderBand1;
        this.xrCrossBandBox1.StartPoint = new System.Drawing.Point(0, 0);
        this.xrCrossBandBox1.StylePriority.UseBorderColor = false;
        this.xrCrossBandBox1.Width = 650;
        // 
        // dsCallDetailsForModerator1
        // 
        this.dsCallDetailsForModerator1.DataSetName = "dsCallDetailsForModerator";
        this.dsCallDetailsForModerator1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // xrLabel16
        // 
        this.xrLabel16.Location = new System.Drawing.Point(317, 8);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.Size = new System.Drawing.Size(83, 25);
        this.xrLabel16.StyleName = "FieldCaption";
        this.xrLabel16.Text = "Cost Code:";
        // 
        // xrLabel20
        // 
        this.xrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForModerator.ReferenceNumber", "")});
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Underline);
        this.xrLabel20.Location = new System.Drawing.Point(400, 8);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.Size = new System.Drawing.Size(217, 25);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.Text = "xrLabel20";
        this.xrLabel20.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel20_BeforePrint);
        // 
        // CallDetailsForModerator
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter,
            this.reportFooterBand1,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.reportHeaderBand1,
            this.groupFooterBand2});
        this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox1});
        this.DataAdapter = this.sqlDataAdapter1;
        this.DataMember = "dsCallDeatailsForModerator1";
        this.DataSource = this.dsCallDetailsForModerator1;
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dsCallDetailsForModerator1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void ElapsedTimeDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        int numOfSecs = Int32.Parse(this.GetCurrentColumnValue("ElapsedTime").ToString());

        int hrs = numOfSecs / 3600;
        int leftover = numOfSecs % 3600;
        int mins = leftover / 60;
        int secs = leftover % 60;

        (sender as XRLabel).Text =
            hrs.ToString().PadLeft(2, '0') + ":" +
            mins.ToString().PadLeft(2, '0') + ":" + 
            secs.ToString().PadLeft(2, '0')            
            ;


    }
    private void ElapsedTimeDisplaySummary(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        try
        {
            //int numOfSecs = Int32.Parse(this.GetCurrentColumnValue("ElapsedTime").ToString());
            int numOfSecs = Int32.Parse(((XRLabel)sender).Summary.GetResult().ToString());

            TotalSecsReport += numOfSecs;

            int hrs = numOfSecs / 3600;
            int leftover = numOfSecs % 3600;
            int mins = leftover / 60;
            int secs = leftover % 60;

            xrLabel13.Text =
                hrs.ToString().PadLeft(2, '0') + ":" +
                mins.ToString().PadLeft(2, '0') + ":" +
                secs.ToString().PadLeft(2, '0')
                ;
        }
        catch
        { }


    }

    private void ElapsedTimeDisplayFooterSummary(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        try
        {
            //int numOfSecs = Int32.Parse(this.GetCurrentColumnValue("ElapsedTime").ToString());
            int numOfSecs = TotalSecsReport;

            int hrs = numOfSecs / 3600;
            int leftover = numOfSecs % 3600;
            int mins = leftover / 60;
            int secs = leftover % 60;

            xrLabel14.Text =
                hrs.ToString().PadLeft(2, '0') + ":" +
                mins.ToString().PadLeft(2, '0') + ":" +
                secs.ToString().PadLeft(2, '0')
                ;
        }
        catch
        { }
    }

    private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        string curRefNum = xrLabel20.Text.Trim();

        if (curRefNum == "")
            xrLabel20.Text = "None";

        xrLabel20.NavigateUrl = @"javascript:window.open('changebillingcode.aspx?id=" + this.GetCurrentColumnValue("UniqueConferenceID").ToString()
            + @"&refnum=" + curRefNum
            + @"','mywindow','toolbar=No,menubar=No,location=No,scrollbars=No,status=No,resizable=No,fullscreen=No,height=200,width=500')";

    }

}
