using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;

/// <summary>
/// Summary description for InvoiceForCustomerService
/// </summary>
public class InvoiceForCustomerService : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
    private System.Data.SqlClient.SqlConnection sqlConnection1;
    private dsInvoiceService dsInvoiceService1;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    private int customerID;
    private XRLine xrLine4;
    private XRLabel xrLabel24;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;

    public int CustomerID
    {
        get { return customerID; }
        set { customerID = value; }
    }

    public double TotalNewCharges
    {
        get { return totalNewCharges; }
        set { totalNewCharges = value; }
    }

    public string BillingPeriod
    {
        get { return billingPeriod; }
        set { billingPeriod = value; }
    }

    public string GST
    {
        get { return gst; }
        set { gst = value; }
    }

    public string TotalNewChargesWithGST
    {
        get { return totalNewChargesWithGST; }
        set { totalNewChargesWithGST = value; }
    }

    private DateTime startDate;
    private PageFooterBand PageFooter;
    private XRLabel xrLabelTNC;
    private double totalNewCharges;
    private XRLabel xrLabelBillingPeriod;
    private XRLabel xrLabel3;
    private XRLabel xrLabel7;
    private string billingPeriod;
    private string gst;
    private string totalNewChargesWithGST;

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }


	public InvoiceForCustomerService()
	{
        totalNewCharges = 0;
	}

    public int BindData()
    {
        //
        // TODO: Add constructor logic here
        //
        InitializeComponent();

        this.sqlConnection1.ConnectionString = ConfigurationManager.ConnectionStrings["CONFDBConnectionString"].ToString();

        sqlDataAdapter1.SelectCommand.Parameters["@CustomerID"].Value = customerID;
        sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = startDate;

        dsInvoiceService ds = new dsInvoiceService();
        ds.EnforceConstraints = false;
        sqlDataAdapter1.Fill(ds);
        this.DataSource = ds.Tables[0];
        //this.xrLabelTNC
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
        string resourceFileName = "InvoiceForCustomerService.resx";
        DevExpress.XtraReports.UI.XRLabel xrLabelTNCValue;
        DevExpress.XtraReports.UI.XRLabel xrLabelTGST;
        DevExpress.XtraReports.UI.XRLabel xrLabelTNCGST;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
        this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
        this.dsInvoiceService1 = new dsInvoiceService();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine4 = new DevExpress.XtraReports.UI.XRLine();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrLabelTNC = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelBillingPeriod = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        xrLabelTNCValue = new DevExpress.XtraReports.UI.XRLabel();
        xrLabelTGST = new DevExpress.XtraReports.UI.XRLabel();
        xrLabelTNCGST = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.dsInvoiceService1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // xrLabelTNCValue
        // 
        xrLabelTNCValue.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        xrLabelTNCValue.Location = new System.Drawing.Point(533, 8);
        xrLabelTNCValue.Name = "xrLabelTNCValue";
        xrLabelTNCValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        xrLabelTNCValue.Size = new System.Drawing.Size(100, 17);
        xrLabelTNCValue.StylePriority.UseFont = false;
        xrLabelTNCValue.StylePriority.UseForeColor = false;
        xrLabelTNCValue.Text = "xrLabelTNCValue";
        xrLabelTNCValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        xrLabelTNCValue.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.SetTotalNewCharges);
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4});
        this.Detail.Height = 19;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel2.Location = new System.Drawing.Point(633, 0);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.Size = new System.Drawing.Size(33, 17);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.Text = " ";
        this.xrLabel2.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.CreditDisplay);
        // 
        // xrLabel6
        // 
        this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetServiceSummary.TransactionAmount", "{0:C2}")});
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel6.Location = new System.Drawing.Point(533, 0);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(100, 17);
        this.xrLabel6.StyleName = "DataField";
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrLabel6.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AmountDisplay);
        // 
        // xrLabel5
        // 
        this.xrLabel5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetServiceSummary.ElapsedTimeSeconds", "")});
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel5.Location = new System.Drawing.Point(392, 0);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.Size = new System.Drawing.Size(100, 17);
        this.xrLabel5.StyleName = "DataField";
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrLabel5.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.ElapsedTimeDisplay);
        // 
        // xrLabel4
        // 
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetServiceSummary.InvoiceServiceName", "")});
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel4.Location = new System.Drawing.Point(58, 0);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(283, 17);
        this.xrLabel4.StyleName = "DataField";
        this.xrLabel4.StylePriority.UseFont = false;
        // 
        // sqlSelectCommand1
        // 
        this.sqlSelectCommand1.CommandText = "dbo.p_InvoiceSummary_GetServiceSummary";
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
            new System.Data.Common.DataTableMapping("Table", "p_InvoiceSummary_GetServiceSummary", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("StartDate", "StartDate"),
                        new System.Data.Common.DataColumnMapping("EndDate", "EndDate"),
                        new System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"),
                        new System.Data.Common.DataColumnMapping("Wholesaler_ProductName", "Wholesaler_ProductName"),
                        new System.Data.Common.DataColumnMapping("TransactionAmount", "TransactionAmount"),
                        new System.Data.Common.DataColumnMapping("ElapsedTimeSeconds", "ElapsedTimeSeconds"),
                        new System.Data.Common.DataColumnMapping("DisplayOrder", "DisplayOrder"),
                        new System.Data.Common.DataColumnMapping("InvoiceServiceName", "InvoiceServiceName")})});
        // 
        // dsInvoiceService1
        // 
        this.dsInvoiceService1.DataSetName = "dsInvoiceService";
        this.dsInvoiceService1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // Title
        // 
        this.Title.BackColor = System.Drawing.Color.White;
        this.Title.BorderColor = System.Drawing.SystemColors.ControlText;
        this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.Title.BorderWidth = 1;
        this.Title.Font = new System.Drawing.Font("Times New Roman", 24F);
        this.Title.ForeColor = System.Drawing.Color.Black;
        this.Title.Name = "Title";
        // 
        // FieldCaption
        // 
        this.FieldCaption.BackColor = System.Drawing.Color.White;
        this.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText;
        this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.FieldCaption.BorderWidth = 1;
        this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
        this.FieldCaption.ForeColor = System.Drawing.Color.Black;
        this.FieldCaption.Name = "FieldCaption";
        // 
        // PageInfo
        // 
        this.PageInfo.BackColor = System.Drawing.Color.White;
        this.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText;
        this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.PageInfo.BorderWidth = 1;
        this.PageInfo.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.PageInfo.ForeColor = System.Drawing.Color.Black;
        this.PageInfo.Name = "PageInfo";
        // 
        // DataField
        // 
        this.DataField.BackColor = System.Drawing.Color.White;
        this.DataField.BorderColor = System.Drawing.SystemColors.ControlText;
        this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.DataField.BorderWidth = 1;
        this.DataField.Font = new System.Drawing.Font("Times New Roman", 8F);
        this.DataField.ForeColor = System.Drawing.SystemColors.ControlText;
        this.DataField.Name = "DataField";
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel24.Location = new System.Drawing.Point(0, 0);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.Size = new System.Drawing.Size(125, 17);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.Text = "Service Summary";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLine4
        // 
        this.xrLine4.BorderWidth = 1;
        this.xrLine4.LineWidth = 3;
        this.xrLine4.Location = new System.Drawing.Point(0, 17);
        this.xrLine4.Name = "xrLine4";
        this.xrLine4.Size = new System.Drawing.Size(775, 8);
        this.xrLine4.StylePriority.UseBorderWidth = false;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelBillingPeriod,
            this.xrLabel1,
            this.xrLabel24,
            this.xrLine4});
        this.ReportHeader.Height = 30;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel1.Location = new System.Drawing.Point(408, 0);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(83, 17);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.Text = "Hr:Min:Sec";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            xrLabelTNCGST,
            xrLabelTGST,
            this.xrLabel7,
            this.xrLabel3,
            xrLabelTNCValue,
            this.xrLabelTNC});
        this.PageFooter.Height = 74;
        this.PageFooter.Name = "PageFooter";
        // 
        // xrLabelTNC
        // 
        this.xrLabelTNC.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabelTNC.Location = new System.Drawing.Point(58, 8);
        this.xrLabelTNC.Name = "xrLabelTNC";
        this.xrLabelTNC.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelTNC.Size = new System.Drawing.Size(283, 17);
        this.xrLabelTNC.StylePriority.UseFont = false;
        this.xrLabelTNC.Text = "Sub Total";
        // 
        // xrLabelBillingPeriod
        // 
        this.xrLabelBillingPeriod.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelBillingPeriod.Location = new System.Drawing.Point(142, 0);
        this.xrLabelBillingPeriod.Name = "xrLabelBillingPeriod";
        this.xrLabelBillingPeriod.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelBillingPeriod.Size = new System.Drawing.Size(250, 17);
        this.xrLabelBillingPeriod.StylePriority.UseFont = false;
        this.xrLabelBillingPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrLabelBillingPeriod.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelBillingPeriod_BeforePrint);
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.Location = new System.Drawing.Point(58, 25);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.Size = new System.Drawing.Size(283, 17);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.Text = "GST";
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.Location = new System.Drawing.Point(58, 50);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.Size = new System.Drawing.Size(283, 17);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseForeColor = false;
        this.xrLabel7.Text = "Total New Charges (Including GST)";
        // 
        // xrLabelTGST
        // 
        xrLabelTGST.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        xrLabelTGST.Location = new System.Drawing.Point(533, 25);
        xrLabelTGST.Name = "xrLabelTGST";
        xrLabelTGST.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        xrLabelTGST.Size = new System.Drawing.Size(100, 17);
        xrLabelTGST.StylePriority.UseFont = false;
        xrLabelTGST.StylePriority.UseForeColor = false;
        xrLabelTGST.Text = "xrLabelTGST";
        xrLabelTGST.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        xrLabelTGST.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelTGST_BeforePrint);
        // 
        // xrLabelTNCGST
        // 
        xrLabelTNCGST.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        xrLabelTNCGST.Location = new System.Drawing.Point(533, 50);
        xrLabelTNCGST.Name = "xrLabelTNCGST";
        xrLabelTNCGST.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        xrLabelTNCGST.Size = new System.Drawing.Size(100, 17);
        xrLabelTNCGST.StylePriority.UseFont = false;
        xrLabelTNCGST.StylePriority.UseForeColor = false;
        xrLabelTNCGST.Text = "xrLabelTNCGST";
        xrLabelTNCGST.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        xrLabelTNCGST.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelTNCGST_BeforePrint);
        // 
        // InvoiceForCustomerService
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.ReportHeader,
            this.PageFooter});
        this.DataAdapter = this.sqlDataAdapter1;
        this.DataMember = "p_InvoiceSummary_GetServiceSummary";
        this.DataSource = this.dsInvoiceService1;
        this.Margins = new System.Drawing.Printing.Margins(100, 1, 100, 100);
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dsInvoiceService1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void ElapsedTimeDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
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
        catch { };

    }

    private void CreditDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        try
        {
            Double dollars = Double.Parse(this.GetCurrentColumnValue("TransactionAmount").ToString());

            if (dollars < 0)
                (sender as XRLabel).Text = "cr";
            else
                (sender as XRLabel).Text = "";

        }
        catch { };

    }

    private void AmountDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        try
        {
            Double dollars = Double.Parse(this.GetCurrentColumnValue("TransactionAmount").ToString());
            totalNewCharges += dollars;

            (sender as XRLabel).Text = String.Format("{0:$#,##0.00;$#,##0.00;$0.00}", dollars);
        }
        catch { };

    }

    private void SetTotalNewCharges(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = String.Format("{0:$#,##0.00;$#,##0.00;$0.00}", this.totalNewCharges);
    }

    private void xrLabelBillingPeriod_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = "(" + this.BillingPeriod + ")";
    }

    private void xrLabelTGST_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = this.GST;      
    }

    private void xrLabelTNCGST_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = this.TotalNewChargesWithGST;      
    }
}
