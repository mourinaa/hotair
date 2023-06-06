using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;

/// <summary>
/// Summary description for CallDetailsForCustomer
/// </summary>
public class CallDetailsForCustomer : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
    private System.Data.SqlClient.SqlConnection sqlConnection1;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel8;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private XRLine xrLine2;
    private PageHeaderBand PageHeader;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private GroupHeaderBand groupHeaderBand1;
    private XRLabel xrLabel1;
    private GroupHeaderBand groupHeaderBand2;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel3;
    private ReportHeaderBand reportHeaderBand1;
    private ReportFooterBand reportFooterBand1;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    private bool displayinBrowser;
    private int customerID;

    public int CustomerID
    {
        get { return customerID; }
        set { customerID = value; }
    }

    private DateTime startTime;
    private XRLabel xrLabel13;
    private XRCrossBandBox xrCrossBandBox1;

    private int TotalSecsReport;
    private int TotalConfAudioMins;
    private int TotalConfWebMins;

    private DataSetCDRDetailsForCustomer dataSetCDRDetailsForCustomer1;
    private XRLabel xrLabel20;
    private XRLabel xrLabel22;
    private XRLabel xrLabel21;
    private XRLabel xrLabel4;
    private XRLabel xrLabel9;
    private XRLabel xrLabel2;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    private GroupFooterBand groupFooterBand1;
    private XRLabel xrLabel15;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLabel xrLabelTotAudioMins;
    private XRLabel xrLabelTotWebMins;
    private XRLabel xrLabel14;
    private XRLabel xrLabel16;
    private XRLabel xrLabel19;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;

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

    private string refNumber;

    public string RefNumber
    {
        get { return refNumber; }
        set { refNumber = value; }
    }

    private string meetingName;
    public string MeetingName
    {
        get { return meetingName; }
        set { meetingName = value; }
    }

    private int selectUserID;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;

    public int SelectedUserID
    {
        get { return selectUserID; }
        set { selectUserID = value; }
    }

    private int departmentID;

    public int DepartmentID
    {
        get { return departmentID; }
        set { departmentID = value; }
    }


	public CallDetailsForCustomer()
	{
        TotalSecsReport = 0;
        displayinBrowser = false;
	}

    public int BindData()
    {
        //
        // TODO: Add constructor logic here
        //
        InitializeComponent();

        this.sqlConnection1.ConnectionString = ConfigurationManager.ConnectionStrings["CONFDBConnectionString"].ToString();

        sqlDataAdapter1.SelectCommand.Parameters["@CustomerID"].Value = CustomerID;
        sqlDataAdapter1.SelectCommand.Parameters["@StartTime"].Value = startTime;
        sqlDataAdapter1.SelectCommand.Parameters["@EndTime"].Value = endTime;
        sqlDataAdapter1.SelectCommand.Parameters["@DepartmentID"].Value = departmentID;
        sqlDataAdapter1.SelectCommand.Parameters["@UserID"].Value = selectUserID;
        sqlDataAdapter1.SelectCommand.Parameters["@ReferenceNumber"].Value = refNumber;
        sqlDataAdapter1.SelectCommand.Parameters["@MeetingName"].Value = meetingName;

        DataSetCDRDetailsForCustomer ds = new DataSetCDRDetailsForCustomer();
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
        string resourceFileName = "CallDetailsForCustomer.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
        this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.groupHeaderBand1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.groupHeaderBand2 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.reportFooterBand1 = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
        this.groupFooterBand1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelTotAudioMins = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelTotWebMins = new DevExpress.XtraReports.UI.XRLabel();
        this.dataSetCDRDetailsForCustomer1 = new DataSetCDRDetailsForCustomer();
        ((System.ComponentModel.ISupportInitialize)(this.dataSetCDRDetailsForCustomer1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel8});
        this.Detail.Dpi = 254F;
        this.Detail.Height = 56;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.AccessTypeDisplayName", "")});
        this.xrLabel4.Dpi = 254F;
        this.xrLabel4.Location = new System.Drawing.Point(339, 0);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel4.Size = new System.Drawing.Size(339, 45);
        this.xrLabel4.StyleName = "DataField";
        this.xrLabel4.Text = "xrLabel4";
        this.xrLabel4.WordWrap = false;
        // 
        // xrLabel12
        // 
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.RetailTotal", "{0:C2}")});
        this.xrLabel12.Dpi = 254F;
        this.xrLabel12.Location = new System.Drawing.Point(1439, 0);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel12.Size = new System.Drawing.Size(196, 45);
        this.xrLabel12.StyleName = "DataField";
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrLabel12.WordWrap = false;
        // 
        // xrLabel11
        // 
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.CallerID", "")});
        this.xrLabel11.Dpi = 254F;
        this.xrLabel11.Location = new System.Drawing.Point(698, 0);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel11.Size = new System.Drawing.Size(444, 45);
        this.xrLabel11.StyleName = "DataField";
        this.xrLabel11.Text = "xrLabel11";
        this.xrLabel11.WordWrap = false;
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.ElapsedTime", "")});
        this.xrLabel10.Dpi = 254F;
        this.xrLabel10.Location = new System.Drawing.Point(1164, 0);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel10.Size = new System.Drawing.Size(254, 45);
        this.xrLabel10.StyleName = "DataField";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrLabel10.WordWrap = false;
        this.xrLabel10.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplay);
        // 
        // xrLabel8
        // 
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.StartTime", "{0:hh:mm tt}")});
        this.xrLabel8.Dpi = 254F;
        this.xrLabel8.Location = new System.Drawing.Point(21, 0);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel8.Size = new System.Drawing.Size(296, 45);
        this.xrLabel8.StyleName = "DataField";
        this.xrLabel8.Text = "xrLabel8";
        this.xrLabel8.WordWrap = false;
        // 
        // sqlSelectCommand1
        // 
        this.sqlSelectCommand1.CommandText = "dbo.p_RatedCDR_GetCallDetailsForCustomer";
        this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        this.sqlSelectCommand1.Connection = this.sqlConnection1;
        this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@StartTime", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@EndTime", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@DepartmentID", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@UserID", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@ReferenceNumber", System.Data.SqlDbType.VarChar, 50),
            new System.Data.SqlClient.SqlParameter("@MeetingName", System.Data.SqlDbType.VarChar, 100)});
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
            new System.Data.Common.DataTableMapping("Table", "p_RatedCDR_GetCallDetailsForCustomer", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("MeetingDate", "MeetingDate"),
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
                        new System.Data.Common.DataColumnMapping("UserDisplayName", "UserDisplayName"),
                        new System.Data.Common.DataColumnMapping("AccessTypeDisplayName", "AccessTypeDisplayName"),
                        new System.Data.Common.DataColumnMapping("CallerID", "CallerID")})});
        this.sqlDataAdapter1.RowUpdated += new System.Data.SqlClient.SqlRowUpdatedEventHandler(this.sqlDataAdapter1_RowUpdated);
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo2,
            this.xrPageInfo1,
            this.xrLine2});
        this.PageFooter.Dpi = 254F;
        this.PageFooter.Height = 79;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
        this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Dpi = 254F;
        this.xrPageInfo2.Format = "Page {0} of {1}";
        this.xrPageInfo2.Location = new System.Drawing.Point(841, 20);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrPageInfo2.Size = new System.Drawing.Size(795, 58);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Dpi = 254F;
        this.xrPageInfo1.Location = new System.Drawing.Point(15, 20);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.Size = new System.Drawing.Size(795, 58);
        this.xrPageInfo1.StyleName = "PageInfo";
        // 
        // xrLine2
        // 
        this.xrLine2.Dpi = 254F;
        this.xrLine2.LineWidth = 3;
        this.xrLine2.Location = new System.Drawing.Point(15, 0);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.Size = new System.Drawing.Size(1621, 5);
        // 
        // PageHeader
        // 
        this.PageHeader.Dpi = 254F;
        this.PageHeader.Height = 19;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
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
        // groupHeaderBand1
        // 
        this.groupHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel28,
            this.xrLabel27,
            this.xrLabel18,
            this.xrLabel17,
            this.xrLabel19,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel2,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel1});
        this.groupHeaderBand1.Dpi = 254F;
        this.groupHeaderBand1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("MeetingDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("UniqueConferenceID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("UserDisplayName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.groupHeaderBand1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
        this.groupHeaderBand1.Height = 503;
        this.groupHeaderBand1.Level = 1;
        this.groupHeaderBand1.Name = "groupHeaderBand1";
        this.groupHeaderBand1.RepeatEveryPage = true;
        // 
        // xrLabel28
        // 
        this.xrLabel28.CanShrink = true;
        this.xrLabel28.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.ReferenceNumber", "")});
        this.xrLabel28.Dpi = 254F;
        this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel28.Location = new System.Drawing.Point(381, 381);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.NavigateUrl = "www.microsoft.com";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel28.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink;
        this.xrLabel28.Size = new System.Drawing.Size(360, 42);
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.Text = "xrLabel28";
        this.xrLabel28.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel28_BeforePrint);
        // 
        // xrLabel27
        // 
        this.xrLabel27.Dpi = 254F;
        this.xrLabel27.Location = new System.Drawing.Point(21, 381);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel27.Size = new System.Drawing.Size(318, 42);
        this.xrLabel27.StyleName = "FieldCaption";
        this.xrLabel27.Text = "Cost Code:";
        // 
        // xrLabel18
        // 
        this.xrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.ModeratorName", "")});
        this.xrLabel18.Dpi = 254F;
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel18.Location = new System.Drawing.Point(381, 190);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel18.Size = new System.Drawing.Size(889, 42);
        this.xrLabel18.StyleName = "DataField";
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.Text = "xrLabel18";
        this.xrLabel18.WordWrap = false;
        // 
        // xrLabel17
        // 
        this.xrLabel17.Dpi = 254F;
        this.xrLabel17.Location = new System.Drawing.Point(21, 190);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel17.Size = new System.Drawing.Size(339, 42);
        this.xrLabel17.StyleName = "FieldCaption";
        this.xrLabel17.Text = "Conference Name:";
        // 
        // xrLabel19
        // 
        this.xrLabel19.Dpi = 254F;
        this.xrLabel19.Location = new System.Drawing.Point(21, 254);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel19.Size = new System.Drawing.Size(318, 42);
        this.xrLabel19.StyleName = "FieldCaption";
        this.xrLabel19.Text = "Moderator Code:";
        // 
        // xrLabel24
        // 
        this.xrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.MeetingDate", "{0:dddd, MMMM dd,  yyyy}")});
        this.xrLabel24.Dpi = 254F;
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel24.Location = new System.Drawing.Point(381, 64);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel24.Size = new System.Drawing.Size(889, 42);
        this.xrLabel24.StyleName = "DataField";
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.Text = "xrLabel24";
        this.xrLabel24.WordWrap = false;
        // 
        // xrLabel23
        // 
        this.xrLabel23.Dpi = 254F;
        this.xrLabel23.Location = new System.Drawing.Point(21, 64);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel23.Size = new System.Drawing.Size(318, 42);
        this.xrLabel23.StyleName = "FieldCaption";
        this.xrLabel23.Text = "Meeting Date:";
        // 
        // xrLabel2
        // 
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.UserDisplayName", "")});
        this.xrLabel2.Dpi = 254F;
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel2.Location = new System.Drawing.Point(381, 127);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel2.Size = new System.Drawing.Size(889, 42);
        this.xrLabel2.StyleName = "DataField";
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.Text = "xrLabel2";
        this.xrLabel2.WordWrap = false;
        // 
        // xrLabel22
        // 
        this.xrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.ModeratorCode", "")});
        this.xrLabel22.Dpi = 254F;
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel22.Location = new System.Drawing.Point(381, 254);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel22.Size = new System.Drawing.Size(889, 42);
        this.xrLabel22.StyleName = "DataField";
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.Text = "xrLabel21";
        this.xrLabel22.WordWrap = false;
        // 
        // xrLabel21
        // 
        this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.PassCode", "")});
        this.xrLabel21.Dpi = 254F;
        this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel21.Location = new System.Drawing.Point(381, 318);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel21.Size = new System.Drawing.Size(889, 42);
        this.xrLabel21.StyleName = "DataField";
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.Text = "xrLabel21";
        this.xrLabel21.WordWrap = false;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Dpi = 254F;
        this.xrLabel20.Location = new System.Drawing.Point(21, 318);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel20.Size = new System.Drawing.Size(318, 42);
        this.xrLabel20.StyleName = "FieldCaption";
        this.xrLabel20.Text = "Participant Code:";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Dpi = 254F;
        this.xrLabel1.Location = new System.Drawing.Point(21, 127);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel1.Size = new System.Drawing.Size(318, 42);
        this.xrLabel1.StyleName = "FieldCaption";
        this.xrLabel1.Text = "Moderator:";
        // 
        // groupHeaderBand2
        // 
        this.groupHeaderBand2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel9,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel3});
        this.groupHeaderBand2.Dpi = 254F;
        this.groupHeaderBand2.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WithFirstDetail;
        this.groupHeaderBand2.Height = 108;
        this.groupHeaderBand2.Name = "groupHeaderBand2";
        this.groupHeaderBand2.RepeatEveryPage = true;
        this.groupHeaderBand2.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.InitializeConfSummary);
        // 
        // xrLabel7
        // 
        this.xrLabel7.Dpi = 254F;
        this.xrLabel7.Location = new System.Drawing.Point(1439, 21);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel7.Size = new System.Drawing.Size(196, 45);
        this.xrLabel7.StyleName = "FieldCaption";
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Cost";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Dpi = 254F;
        this.xrLabel9.Location = new System.Drawing.Point(339, 21);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel9.Size = new System.Drawing.Size(280, 45);
        this.xrLabel9.StyleName = "FieldCaption";
        this.xrLabel9.Text = "Access Type";
        // 
        // xrLabel6
        // 
        this.xrLabel6.Dpi = 254F;
        this.xrLabel6.Location = new System.Drawing.Point(698, 21);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel6.Size = new System.Drawing.Size(339, 45);
        this.xrLabel6.StyleName = "FieldCaption";
        this.xrLabel6.Text = "Participant Info";
        // 
        // xrLabel5
        // 
        this.xrLabel5.Dpi = 254F;
        this.xrLabel5.Location = new System.Drawing.Point(1164, 21);
        this.xrLabel5.Multiline = true;
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel5.Size = new System.Drawing.Size(254, 85);
        this.xrLabel5.StyleName = "FieldCaption";
        this.xrLabel5.Text = "Duration\r\nHH:MM:SS";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Dpi = 254F;
        this.xrLabel3.Location = new System.Drawing.Point(21, 21);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel3.Size = new System.Drawing.Size(280, 45);
        this.xrLabel3.StyleName = "FieldCaption";
        this.xrLabel3.Text = "Connect Time";
        // 
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13});
        this.reportHeaderBand1.Dpi = 254F;
        this.reportHeaderBand1.Height = 130;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        // 
        // xrLabel13
        // 
        this.xrLabel13.Dpi = 254F;
        this.xrLabel13.Location = new System.Drawing.Point(20, 20);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel13.Size = new System.Drawing.Size(1621, 84);
        this.xrLabel13.StyleName = "Title";
        this.xrLabel13.Text = "Call Details";
        this.xrLabel13.HtmlItemCreated += new DevExpress.XtraReports.UI.HtmlEventHandler(this.xrLabel13_HtmlItemCreated);
        // 
        // reportFooterBand1
        // 
        this.reportFooterBand1.Dpi = 254F;
        this.reportFooterBand1.Height = 21;
        this.reportFooterBand1.Name = "reportFooterBand1";
        // 
        // xrCrossBandBox1
        // 
        this.xrCrossBandBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
        this.xrCrossBandBox1.BorderColor = System.Drawing.SystemColors.ControlLight;
        this.xrCrossBandBox1.Dpi = 254F;
        this.xrCrossBandBox1.EndBand = this.groupFooterBand1;
        this.xrCrossBandBox1.EndPoint = new System.Drawing.Point(11, 203);
        this.xrCrossBandBox1.Name = "xrCrossBandBox1";
        this.xrCrossBandBox1.StartBand = this.groupHeaderBand1;
        this.xrCrossBandBox1.StartPoint = new System.Drawing.Point(11, 42);
        this.xrCrossBandBox1.StylePriority.UseBorderColor = false;
        this.xrCrossBandBox1.Width = 1640;
        // 
        // groupFooterBand1
        // 
        this.groupFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabelTotAudioMins,
            this.xrLabelTotWebMins});
        this.groupFooterBand1.Dpi = 254F;
        this.groupFooterBand1.Height = 233;
        this.groupFooterBand1.Name = "groupFooterBand1";
        // 
        // xrLabel16
        // 
        this.xrLabel16.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_RatedCDR_GetCallDetailsForCustomer.ElapsedTime", "")});
        this.xrLabel16.Dpi = 254F;
        this.xrLabel16.Location = new System.Drawing.Point(720, 127);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel16.Size = new System.Drawing.Size(254, 42);
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel16.Summary = xrSummary1;
        this.xrLabel16.Text = "xrLabel16";
        this.xrLabel16.Visible = false;
        this.xrLabel16.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplaySummary);
        // 
        // xrLabel14
        // 
        this.xrLabel14.Dpi = 254F;
        this.xrLabel14.Location = new System.Drawing.Point(847, 64);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel14.Size = new System.Drawing.Size(529, 45);
        this.xrLabel14.StyleName = "FieldCaption";
        this.xrLabel14.Text = "Total Cost Before Discounts:";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel15
        // 
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RetailTotal", "{0:C2}")});
        this.xrLabel15.Dpi = 254F;
        this.xrLabel15.Location = new System.Drawing.Point(1397, 64);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel15.Size = new System.Drawing.Size(233, 45);
        this.xrLabel15.StyleName = "FieldCaption";
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:C2}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrLabel15.Summary = xrSummary2;
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel25
        // 
        this.xrLabel25.Dpi = 254F;
        this.xrLabel25.Location = new System.Drawing.Point(21, 64);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel25.Size = new System.Drawing.Size(360, 45);
        this.xrLabel25.StyleName = "FieldCaption";
        this.xrLabel25.Text = "Total Audio Minutes:";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Dpi = 254F;
        this.xrLabel26.Location = new System.Drawing.Point(21, 127);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabel26.Size = new System.Drawing.Size(360, 45);
        this.xrLabel26.StyleName = "FieldCaption";
        this.xrLabel26.Text = "Total Web Minutes:";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabelTotAudioMins
        // 
        this.xrLabelTotAudioMins.Dpi = 254F;
        this.xrLabelTotAudioMins.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabelTotAudioMins.Location = new System.Drawing.Point(381, 64);
        this.xrLabelTotAudioMins.Name = "xrLabelTotAudioMins";
        this.xrLabelTotAudioMins.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabelTotAudioMins.Size = new System.Drawing.Size(254, 42);
        this.xrLabelTotAudioMins.StylePriority.UseFont = false;
        this.xrLabelTotAudioMins.Text = "xrLabelTotAudioMins";
        this.xrLabelTotAudioMins.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplaySummary);
        // 
        // xrLabelTotWebMins
        // 
        this.xrLabelTotWebMins.Dpi = 254F;
        this.xrLabelTotWebMins.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabelTotWebMins.Location = new System.Drawing.Point(381, 127);
        this.xrLabelTotWebMins.Name = "xrLabelTotWebMins";
        this.xrLabelTotWebMins.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
        this.xrLabelTotWebMins.Size = new System.Drawing.Size(254, 42);
        this.xrLabelTotWebMins.StylePriority.UseFont = false;
        this.xrLabelTotWebMins.Text = "xrLabelTotWebMins";
        this.xrLabelTotWebMins.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplaySummary);
        // 
        // dataSetCDRDetailsForCustomer1
        // 
        this.dataSetCDRDetailsForCustomer1.DataSetName = "DataSetCDRDetailsForCustomer";
        this.dataSetCDRDetailsForCustomer1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // CallDetailsForCustomer
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter,
            this.PageHeader,
            this.groupHeaderBand1,
            this.groupHeaderBand2,
            this.reportHeaderBand1,
            this.reportFooterBand1,
            this.groupFooterBand1});
        this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox1});
        this.DataAdapter = this.sqlDataAdapter1;
        this.DataMember = "p_RatedCDR_GetCallDetailsForCustomer";
        this.DataSource = this.dataSetCDRDetailsForCustomer1;
        this.Dpi = 254F;
        this.Margins = new System.Drawing.Printing.Margins(254, 254, 254, 254);
        this.PageHeight = 2794;
        this.PageWidth = 2159;
        this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dataSetCDRDetailsForCustomer1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void ElapsedTimeDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        int numOfSecs = Int32.Parse(this.GetCurrentColumnValue("ElapsedTime").ToString());

        if (this.GetCurrentColumnValue("AccessTypeDisplayName").ToString().ToUpper().Contains("WEB"))
        {
            TotalConfWebMins += numOfSecs;
        }
        else
        {
            TotalConfAudioMins += numOfSecs;
        }
        
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
            //int numOfSecs = Int32.Parse(((XRLabel)sender).Summary.GetResult().ToString());

            //TotalSecsReport += numOfSecs;

            xrLabelTotAudioMins.Text = GetStringHHMMSS(TotalConfAudioMins);
            xrLabelTotWebMins.Text = GetStringHHMMSS(TotalConfWebMins);
            //xrLabel16.Text = GetStringHHMMSS(numOfSecs);
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

            //xrLabel17.Text =
            //    hrs.ToString().PadLeft(2, '0') + ":" +
            //    mins.ToString().PadLeft(2, '0') + ":" +
            //    secs.ToString().PadLeft(2, '0')
                ;
        }
        catch
        { }
    }

    private void sqlDataAdapter1_RowUpdated(object sender, System.Data.SqlClient.SqlRowUpdatedEventArgs e)
    {

    }

    private void InitializeConfSummary(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        TotalConfAudioMins = 0;
        TotalConfWebMins = 0;
    }

    public string GetStringHHMMSS(int numOfSecs)
    {
        int hrs = numOfSecs / 3600;
        int leftover = numOfSecs % 3600;
        int mins = leftover / 60;
        int secs = leftover % 60;

        return (hrs.ToString().PadLeft(2, '0') + ":" +
        mins.ToString().PadLeft(2, '0') + ":" +
        secs.ToString().PadLeft(2, '0'));

    }





    private void xrLabel13_HtmlItemCreated(object sender, HtmlEventArgs e)
    {
        displayinBrowser = true;
    }


    private void xrLabel28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        string curRefNum = xrLabel28.Text.Trim();

        if (curRefNum == "")
            xrLabel28.Text = "None";

        xrLabel28.NavigateUrl = @"javascript:window.open('changebillingcode.aspx?id=" + this.GetCurrentColumnValue("UniqueConferenceID").ToString() 
            + @"&refnum=" + curRefNum
            + @"','mywindow','toolbar=No,menubar=No,location=No,scrollbars=No,status=No,resizable=No,fullscreen=No,height=200,width=500')";
    }
}
