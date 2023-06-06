using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;
/// <summary>
/// Summary description for AccountActivityReportPayments
/// </summary>
public class AccountActivityReportPayments : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
    private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
    private System.Data.SqlClient.SqlConnection sqlConnection1;
    private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel6;
    private XRLabel xrLabel10;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    private int customerID;
    public int CustomerID
    {
        get { return customerID; }
        set { customerID = value; }
    }

    private DateTime startDate;
    private XRLabel xrLabel1;
    private dsAccountActivityDetails dsAccountActivityDetails1;

    public DateTime StartDate
    {
        get { return startDate; }
        set { startDate = value; }
    }

    private int reqType;

    public int ReqType
    {
        get { return reqType; }
        set { reqType = value; }
    }
	public AccountActivityReportPayments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int BindData()
    {


        InitializeComponent();

        this.sqlConnection1.ConnectionString = ConfigurationManager.ConnectionStrings["CONFDBConnectionString"].ToString();

        //customerID = -1;// DEBUG!!!!!!!!!!!!!!!!

        sqlDataAdapter1.SelectCommand.Parameters["@CustomerID"].Value = customerID;
        sqlDataAdapter1.SelectCommand.Parameters["@StartDate"].Value = startDate;
        sqlDataAdapter1.SelectCommand.Parameters["@reqtype"].Value = reqType;

        dsAccountActivityDetails ds = new dsAccountActivityDetails();
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
        string resourceFileName = "AccountActivityReportPayments.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
        this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
        this.dsAccountActivityDetails1 = new dsAccountActivityDetails();
        ((System.ComponentModel.ISupportInitialize)(this.dsAccountActivityDetails1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2});
        this.Detail.Height = 26;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Invoice_PaymentsCredits.TrasactionDate", "{0:MM/dd/yyyy}")});
        this.xrLabel1.Location = new System.Drawing.Point(0, 0);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(75, 25);
        this.xrLabel1.Text = "xrLabel1";
        this.xrLabel1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel1_BeforePrint);
        // 
        // xrLabel4
        // 
        this.xrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Invoice_PaymentsCredits.TransactionAmount", "{0:$0.00}")});
        this.xrLabel4.Location = new System.Drawing.Point(517, 0);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(125, 25);
        this.xrLabel4.Text = "xrLabel4";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel3
        // 
        this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Invoice_PaymentsCredits.TransactionDescription", "")});
        this.xrLabel3.Location = new System.Drawing.Point(250, 0);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.Size = new System.Drawing.Size(258, 25);
        this.xrLabel3.Text = "xrLabel3";
        // 
        // xrLabel2
        // 
        this.xrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Invoice_PaymentsCredits.TransactionType", "")});
        this.xrLabel2.Location = new System.Drawing.Point(75, 0);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.Size = new System.Drawing.Size(175, 25);
        this.xrLabel2.Text = "xrLabel2";
        // 
        // PageFooter
        // 
        this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel10});
        this.PageFooter.Height = 27;
        this.PageFooter.Name = "PageFooter";
        this.PageFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Location = new System.Drawing.Point(250, 0);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(250, 25);
        this.xrLabel6.Text = "Total Payments Received";
        this.xrLabel6.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel6_BeforePrint);
        // 
        // xrLabel10
        // 
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_Invoice_PaymentsCredits.TransactionAmount", "{0:$0.00}")});
        this.xrLabel10.Location = new System.Drawing.Point(642, 0);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.Size = new System.Drawing.Size(125, 25);
        xrSummary1.FormatString = "{0:$0.00}";
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrLabel10.Summary = xrSummary1;
        this.xrLabel10.Text = "xrLabel10";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // sqlSelectCommand1
        // 
        this.sqlSelectCommand1.CommandText = "dbo.p_Invoice_PaymentsCredits";
        this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
        this.sqlSelectCommand1.Connection = this.sqlConnection1;
        this.sqlSelectCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.Int, 4),
            new System.Data.SqlClient.SqlParameter("@reqtype", System.Data.SqlDbType.Int, 4)});
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
            new System.Data.Common.DataTableMapping("Table", "p_Invoice_PaymentsCredits", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TrasactionDate", "TrasactionDate"),
                        new System.Data.Common.DataColumnMapping("TransactionType", "TransactionType"),
                        new System.Data.Common.DataColumnMapping("TransactionDescription", "TransactionDescription"),
                        new System.Data.Common.DataColumnMapping("TransactionAmount", "TransactionAmount"),
                        new System.Data.Common.DataColumnMapping("SortOrder", "SortOrder")}),
            new System.Data.Common.DataTableMapping("Table1", "Table1", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TrasactionDate", "TrasactionDate"),
                        new System.Data.Common.DataColumnMapping("TransactionType", "TransactionType"),
                        new System.Data.Common.DataColumnMapping("TransactionDescription", "TransactionDescription"),
                        new System.Data.Common.DataColumnMapping("TransactionAmount", "TransactionAmount"),
                        new System.Data.Common.DataColumnMapping("SortOrder", "SortOrder")}),
            new System.Data.Common.DataTableMapping("Table2", "Table2", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TransactionDate", "TransactionDate"),
                        new System.Data.Common.DataColumnMapping("TransactionType", "TransactionType"),
                        new System.Data.Common.DataColumnMapping("TransactionDescription", "TransactionDescription"),
                        new System.Data.Common.DataColumnMapping("TransactionAmount", "TransactionAmount"),
                        new System.Data.Common.DataColumnMapping("SortOrder", "SortOrder")}),
            new System.Data.Common.DataTableMapping("Table3", "Table3", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("TransactionDate", "TransactionDate"),
                        new System.Data.Common.DataColumnMapping("TransactionType", "TransactionType"),
                        new System.Data.Common.DataColumnMapping("TransactionDescription", "TransactionDescription"),
                        new System.Data.Common.DataColumnMapping("TransactionAmount", "TransactionAmount"),
                        new System.Data.Common.DataColumnMapping("SortOrder", "SortOrder")})});
        // 
        // dsAccountActivityDetails1
        // 
        this.dsAccountActivityDetails1.DataSetName = "dsAccountActivityDetails";
        this.dsAccountActivityDetails1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // AccountActivityReportPayments
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageFooter});
        this.DataAdapter = this.sqlDataAdapter1;
        this.DataMember = "p_Invoice_PaymentsCredits";
        this.DataSource = this.dsAccountActivityDetails1;
        this.Margins = new System.Drawing.Printing.Margins(50, 17, 0, 0);
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dsAccountActivityDetails1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void xrLabel6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        if (reqType == 3)
            (sender as XRLabel).Text = "Total Payments Received";
        else if (reqType == 2)
            (sender as XRLabel).Text = "Total Credits Issued";
        else
            (sender as XRLabel).Text = "Total";
    }

    private void xrLabel1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        DateTime tdate = DateTime.Parse(this.GetCurrentColumnValue("TransactionDate").ToString());
        (sender as XRLabel).Text = String.Format("{0:MM/dd/yyyy}", tdate);
    }
}
