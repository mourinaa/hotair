using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;
/// <summary>
/// Summary description for DetailInvoice
/// </summary>
public class DetailInvoice : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
    private System.Data.SqlClient.SqlConnection sqlConnection1;
    private dsDetailInvoice dsDetailInvoice1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell6;
    private PageFooterBand PageFooter;
    private XRPageInfo xrPageInfo2;
    private XRPageInfo xrPageInfo1;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell5;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private ReportHeaderBand reportHeaderBand1;
    private XRLabel xrLabel13;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	public DetailInvoice()
	{
	}


    private int customerID;
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



    public int BindData()
    {
        //
        // TODO: Add constructor logic here
        //
        InitializeComponent();

        this.sqlConnection1.ConnectionString = ConfigurationManager.ConnectionStrings["CONFDBConnectionString"].ToString();

        //customerID = -1;// DEBUG!!!!!!!!!!!!!!!!

        sqlDataAdapter1.SelectCommand.Parameters["@CustomerID"].Value = customerID;
        sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = startDate;

        dsInvoice ds = new dsInvoice();
        ds.EnforceConstraints = false;
        sqlDataAdapter1.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
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
        string resourceFileName = "DetailInvoice.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
        this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
        this.dsDetailInvoice1 = new dsDetailInvoice();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.reportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dsDetailInvoice1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.Height = 20;
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
        this.xrTable2.Size = new System.Drawing.Size(637, 20);
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell6});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Size = new System.Drawing.Size(637, 20);
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.CanGrow = false;
        this.xrTableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "InvoiceServiceName", "")});
        this.xrTableCell2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrTableCell2.Location = new System.Drawing.Point(0, 0);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell2.Size = new System.Drawing.Size(461, 20);
        this.xrTableCell2.StyleName = "DataField";
        this.xrTableCell2.StylePriority.UseFont = false;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.CanGrow = false;
        this.xrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ElapsedTimeSeconds", "")});
        this.xrTableCell4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrTableCell4.Location = new System.Drawing.Point(461, 0);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell4.Size = new System.Drawing.Size(92, 20);
        this.xrTableCell4.StyleName = "DataField";
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell4.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell4_BeforePrint);
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.CanGrow = false;
        this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
			new DevExpress.XtraReports.UI.XRBinding("Text", null, "TransactionAmount", "{0:$#,##0.00;$#,##0.00;$0.00}")});
        this.xrTableCell6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrTableCell6.Location = new System.Drawing.Point(553, 0);
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell6.Size = new System.Drawing.Size(84, 20);
        this.xrTableCell6.StyleName = "DataField";
        this.xrTableCell6.StylePriority.UseFont = false;
        xrSummary1.FormatString = "{0:$#,##0.00;$#,##0.00;$0.00}";
        this.xrTableCell6.Summary = xrSummary1;
        this.xrTableCell6.Text = "xrTableCell6";
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // sqlSelectCommand1
        // 
        this.sqlSelectCommand1.CommandText = "dbo.p_InvoiceSummary_GetServiceDetails";
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
            new System.Data.Common.DataTableMapping("Table", "p_InvoiceSummary_GetServiceDetails", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
                        new System.Data.Common.DataColumnMapping("EndDate", "EndDate"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("Wholesaler_ProductName", "Wholesaler_ProductName"),
                        new System.Data.Common.DataColumnMapping("TransactionAmount", "TransactionAmount"),
                        new System.Data.Common.DataColumnMapping("ElapsedTimeSeconds", "ElapsedTimeSeconds"),
                        new System.Data.Common.DataColumnMapping("DisplayOrder", "DisplayOrder"),
                        new System.Data.Common.DataColumnMapping("InvoiceServiceName", "InvoiceServiceName")})});
        // 
        // dsDetailInvoice1
        // 
        this.dsDetailInvoice1.DataSetName = "dsDetailInvoice";
        this.dsDetailInvoice1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrPageInfo2});
        this.PageFooter.Height = 28;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrPageInfo1
        // 
        this.xrPageInfo1.Location = new System.Drawing.Point(0, 0);
        this.xrPageInfo1.Name = "xrPageInfo1";
        this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
        this.xrPageInfo1.Size = new System.Drawing.Size(313, 23);
        this.xrPageInfo1.StyleName = "PageInfo";
        // 
        // xrPageInfo2
        // 
        this.xrPageInfo2.Format = "Page {0} of {1}";
        this.xrPageInfo2.Location = new System.Drawing.Point(433, 0);
        this.xrPageInfo2.Name = "xrPageInfo2";
        this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrPageInfo2.Size = new System.Drawing.Size(313, 23);
        this.xrPageInfo2.StyleName = "PageInfo";
        this.xrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.Height = 38;
        this.PageHeader.Name = "PageHeader";
        this.PageHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable1
        // 
        this.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
        this.xrTable1.Location = new System.Drawing.Point(6, 2);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.Size = new System.Drawing.Size(637, 36);
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell3,
            this.xrTableCell5});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Size = new System.Drawing.Size(637, 36);
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.CanGrow = false;
        this.xrTableCell1.Location = new System.Drawing.Point(0, 0);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell1.Size = new System.Drawing.Size(461, 36);
        this.xrTableCell1.StyleName = "FieldCaption";
        this.xrTableCell1.Text = "Item";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrTableCell1_BeforePrint);
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.CanGrow = false;
        this.xrTableCell3.Location = new System.Drawing.Point(461, 0);
        this.xrTableCell3.Multiline = true;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell3.Size = new System.Drawing.Size(92, 36);
        this.xrTableCell3.StyleName = "FieldCaption";
        this.xrTableCell3.Text = "Duration\r\nHH:MM:SS";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.CanGrow = false;
        this.xrTableCell5.Location = new System.Drawing.Point(553, 0);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTableCell5.Size = new System.Drawing.Size(84, 36);
        this.xrTableCell5.StyleName = "FieldCaption";
        this.xrTableCell5.Text = "Amount";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
        // reportHeaderBand1
        // 
        this.reportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13});
        this.reportHeaderBand1.Height = 33;
        this.reportHeaderBand1.Name = "reportHeaderBand1";
        // 
        // xrLabel13
        // 
        this.xrLabel13.Location = new System.Drawing.Point(0, 0);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.Size = new System.Drawing.Size(638, 33);
        this.xrLabel13.StyleName = "Title";
        this.xrLabel13.Text = "Invoice Details";
        // 
        // DetailInvoice
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter,
            this.PageHeader,
            this.reportHeaderBand1});
        this.DataAdapter = this.sqlDataAdapter1;
        this.DataMember = "p_InvoiceSummary_GetServiceDetails";
        this.DataSource = this.dsDetailInvoice1;
        this.Margins = new System.Drawing.Printing.Margins(100, 0, 100, 100);
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dsDetailInvoice1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        /*
        InvoiceForCustomer servreport = new InvoiceForCustomer();
        servreport.StartDate = startDate;
        servreport.CustomerID = customerID;
        //servreport.TotalNewCharges = tnc;

        servreport.BindData();

        xrSubreport1.ReportSource = servreport;
         */
    }

    private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        try
        {
            int numOfSecs = Int32.Parse(this.GetCurrentColumnValue("ElapsedTimeSeconds").ToString());

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
        catch (Exception ex)
        {
        }


    }
}
