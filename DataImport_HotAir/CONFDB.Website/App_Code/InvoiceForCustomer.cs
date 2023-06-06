using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Configuration;
/// <summary>
/// Summary description for InvoiceForCustomer
/// </summary>
public class InvoiceForCustomer : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private System.Data.SqlClient.SqlConnection sqlConnection1;
    private System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
    private dsInvoice dsInvoice1;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel3;
    private XRPictureBox xrPictureBox1;
    private XRLabel xrLabelBPTop;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel16;
    private XRLine xrLine1;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRLabel xrLabel20;
    private XRLabel xrLabel21;
    private XRLabel xrLabel23;
    private XRLine xrLine2;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLine xrLine3;
    private XRLabel xrLabel27;
    private XRLabel xrLabel28;
    private XRLabel xrLabel31;
    private XRPictureBox xrPictureBox2;
    private XRLabel xrLabel34;
    private XRLabel xrLabel33;
    private XRLabel xrLabel32;
    private XRLabel xrLabel35;
    private XRLabel xrLabel36;
    private XRLabel xrLabel37;
    private XRLabel xrLabel38;
    private XRCrossBandBox xrCrossBandBox1;
    private XRLabel xrLabel42;
    private XRLabel xrLabel40;
    private XRLabel xrLabel43;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel xrLabel47;
    private XRLabel xrLabel46;
    private XRLabel xrLabel39;
    private XRLabel xrLabel41;
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

    private int customerID;
    private System.Data.SqlClient.SqlCommand sqlSelectCommand;
    private XRLabel xrLabel48;
    private XRLabel xrLabel50;
    private XRLabel xrLabel49;
    private XRLabel xrLabel55;
    private XRLabel xrLabel52;
    private XRLabel xrLabel51;
    private XRLabel xrLabel56;
    private XRLabel xrLabel15;
    private XRSubreport xrSubreport1;
    private XRLabel xrLabel24;
    private XRLabel xrLabel57;
    private XRPictureBox xrPictureBox3;
    private XRLabel xrLabel58;
    private XRLabel xrNewCharges;
    private XRLabel xrLabel53;
    private XRLabel xrLabel54;
    private XRLabel xrLabel59;
    private XRLabel xrLabelAmountOfLastBlanceCR;
    private XRLabel xrLabelPaymentCR;
    private XRLabel xrLabelTotalCreditCR;
    private XRLabel xrLabelBalForwardCR;
    private XRLabel xrLabelNewChargesCR;
    private XRLabel xrLabelBalanceForwardCR;
    private XRLabel xrLabel61;
    private XRLabel xrLabel60;
    private XRLabel xrLabel62;
    private XRLabel xrLabel63;
    private XRLabel xrLabel64;
    private XRLabel xrLabel65;
    private XRLabel xrLabel66;
    private XRLabel xrLabelTotalDueCR;
    private XRLabel xrLabel4;

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


	public InvoiceForCustomer()
	{

	}

    public int BindData()
    {
        //
        // TODO: Add constructor logic here
        //

        //string x = String.Format("{0:$#,##.00  ;$#,##.00;$0.00  }", (double) 4429.39);
        //string y = String.Format("{0:$#,##.00  ;$#,##.00;$0.00  }", (double)-4429.39);
        //string z = String.Format("{0:$#,##.00  ;$#,##.00;$0.00  }", (double)0);

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
        string resourceFileName = "InvoiceForCustomer.resx";
        System.Resources.ResourceManager resources = global::Resources.InvoiceForCustomer.ResourceManager;
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelTotalDueCR = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel66 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel65 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel64 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel63 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel60 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel61 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelBalanceForwardCR = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelNewChargesCR = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrLabelBPTop = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine2 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLine3 = new DevExpress.XtraReports.UI.XRLine();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel55 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel57 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrLabel58 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrNewCharges = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel53 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel59 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelAmountOfLastBlanceCR = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelPaymentCR = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelTotalCreditCR = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabelBalForwardCR = new DevExpress.XtraReports.UI.XRLabel();
        this.xrSubreport1 = new DevExpress.XtraReports.UI.XRSubreport();
        this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
        this.sqlSelectCommand = new System.Data.SqlClient.SqlCommand();
        this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
        this.dsInvoice1 = new dsInvoice();
        this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
        ((System.ComponentModel.ISupportInitialize)(this.dsInvoice1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabelTotalDueCR,
            this.xrLabel66,
            this.xrLabel65,
            this.xrLabel64,
            this.xrLabel63,
            this.xrLabel62,
            this.xrLabel60,
            this.xrLabel61,
            this.xrLabelBalanceForwardCR,
            this.xrLabelNewChargesCR,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel3,
            this.xrPictureBox1,
            this.xrLabelBPTop,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel11,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel16,
            this.xrLine1,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrLabel20,
            this.xrLabel21,
            this.xrLabel23,
            this.xrLine2,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLine3,
            this.xrLabel27,
            this.xrLabel28,
            this.xrLabel31,
            this.xrPictureBox2,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34,
            this.xrLabel35,
            this.xrLabel36,
            this.xrLabel37,
            this.xrLabel38,
            this.xrLabel40,
            this.xrLabel42,
            this.xrLabel43,
            this.xrLabel44,
            this.xrLabel45,
            this.xrLabel41,
            this.xrLabel39,
            this.xrLabel46,
            this.xrLabel47,
            this.xrLabel48,
            this.xrLabel49,
            this.xrLabel50,
            this.xrLabel51,
            this.xrLabel52,
            this.xrLabel55,
            this.xrLabel56,
            this.xrLabel15,
            this.xrLabel24,
            this.xrLabel57,
            this.xrLabel10,
            this.xrPictureBox3,
            this.xrLabel58,
            this.xrNewCharges,
            this.xrLabel53,
            this.xrLabel54,
            this.xrLabel59,
            this.xrLabelAmountOfLastBlanceCR,
            this.xrLabelPaymentCR,
            this.xrLabelTotalCreditCR,
            this.xrLabelBalForwardCR,
            this.xrSubreport1});
        this.Detail.Height = 1158;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel4.Location = new System.Drawing.Point(492, 67);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(125, 17);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.Text = "Billing Period:";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabelTotalDueCR
        // 
        this.xrLabelTotalDueCR.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelTotalDueCR.Location = new System.Drawing.Point(733, 283);
        this.xrLabelTotalDueCR.Name = "xrLabelTotalDueCR";
        this.xrLabelTotalDueCR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelTotalDueCR.Size = new System.Drawing.Size(42, 25);
        this.xrLabelTotalDueCR.StylePriority.UseFont = false;
        this.xrLabelTotalDueCR.StylePriority.UseTextAlignment = false;
        this.xrLabelTotalDueCR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabelTotalDueCR.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelTotalDueCR_BeforePrint);
        // 
        // xrLabel66
        // 
        this.xrLabel66.Font = new System.Drawing.Font("Arial", 8.25F);
        this.xrLabel66.Location = new System.Drawing.Point(500, 1083);
        this.xrLabel66.Name = "xrLabel66";
        this.xrLabel66.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel66.Size = new System.Drawing.Size(242, 17);
        this.xrLabel66.StylePriority.UseFont = false;
        this.xrLabel66.Text = "(Enter Customer Number as a Reference)";
        this.xrLabel66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel65
        // 
        this.xrLabel65.Font = new System.Drawing.Font("Arial", 8.25F);
        this.xrLabel65.Location = new System.Drawing.Point(433, 1083);
        this.xrLabel65.Name = "xrLabel65";
        this.xrLabel65.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel65.Size = new System.Drawing.Size(67, 17);
        this.xrLabel65.StylePriority.UseFont = false;
        this.xrLabel65.Text = "491946115 ";
        this.xrLabel65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel64
        // 
        this.xrLabel64.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
        this.xrLabel64.Location = new System.Drawing.Point(367, 1083);
        this.xrLabel64.Name = "xrLabel64";
        this.xrLabel64.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel64.Size = new System.Drawing.Size(58, 17);
        this.xrLabel64.StylePriority.UseFont = false;
        this.xrLabel64.Text = "Account:";
        this.xrLabel64.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel63
        // 
        this.xrLabel63.Font = new System.Drawing.Font("Arial", 8.25F);
        this.xrLabel63.Location = new System.Drawing.Point(300, 1083);
        this.xrLabel63.Name = "xrLabel63";
        this.xrLabel63.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel63.Size = new System.Drawing.Size(50, 17);
        this.xrLabel63.StylePriority.UseFont = false;
        this.xrLabel63.Text = "012003";
        this.xrLabel63.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel62
        // 
        this.xrLabel62.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
        this.xrLabel62.Location = new System.Drawing.Point(258, 1083);
        this.xrLabel62.Name = "xrLabel62";
        this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel62.Size = new System.Drawing.Size(33, 17);
        this.xrLabel62.StylePriority.UseFont = false;
        this.xrLabel62.Text = "BSB:";
        this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel60
        // 
        this.xrLabel60.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
        this.xrLabel60.Location = new System.Drawing.Point(17, 1083);
        this.xrLabel60.Name = "xrLabel60";
        this.xrLabel60.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel60.Size = new System.Drawing.Size(33, 17);
        this.xrLabel60.StylePriority.UseFont = false;
        this.xrLabel60.Text = "EFT:";
        this.xrLabel60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel61
        // 
        this.xrLabel61.Font = new System.Drawing.Font("Arial", 8.25F);
        this.xrLabel61.Location = new System.Drawing.Point(50, 1083);
        this.xrLabel61.Name = "xrLabel61";
        this.xrLabel61.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel61.Size = new System.Drawing.Size(192, 17);
        this.xrLabel61.StylePriority.UseFont = false;
        this.xrLabel61.Text = "Redback Conferencing PTY Ltd.";
        this.xrLabel61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabelBalanceForwardCR
        // 
        this.xrLabelBalanceForwardCR.BackColor = System.Drawing.Color.LightYellow;
        this.xrLabelBalanceForwardCR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelBalanceForwardCR.Location = new System.Drawing.Point(633, 483);
        this.xrLabelBalanceForwardCR.Name = "xrLabelBalanceForwardCR";
        this.xrLabelBalanceForwardCR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelBalanceForwardCR.Size = new System.Drawing.Size(33, 17);
        this.xrLabelBalanceForwardCR.StylePriority.UseBackColor = false;
        this.xrLabelBalanceForwardCR.StylePriority.UseFont = false;
        this.xrLabelBalanceForwardCR.Text = " ";
        this.xrLabelBalanceForwardCR.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.BalanceForwardDisplayCR);
        // 
        // xrLabelNewChargesCR
        // 
        this.xrLabelNewChargesCR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelNewChargesCR.Location = new System.Drawing.Point(633, 458);
        this.xrLabelNewChargesCR.Name = "xrLabelNewChargesCR";
        this.xrLabelNewChargesCR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelNewChargesCR.Size = new System.Drawing.Size(33, 17);
        this.xrLabelNewChargesCR.StylePriority.UseFont = false;
        this.xrLabelNewChargesCR.Text = " ";
        this.xrLabelNewChargesCR.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.NewChargesDisplayCR);
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel1.Location = new System.Drawing.Point(492, 8);
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
        this.xrLabel2.Location = new System.Drawing.Point(492, 25);
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
        this.xrLabel3.Location = new System.Drawing.Point(492, 42);
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
        this.xrPictureBox1.Location = new System.Drawing.Point(17, 8);
        this.xrPictureBox1.Name = "xrPictureBox1";
        this.xrPictureBox1.Size = new System.Drawing.Size(217, 67);
        // 
        // xrLabelBPTop
        // 
        this.xrLabelBPTop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelBPTop.Location = new System.Drawing.Point(625, 67);
        this.xrLabelBPTop.Name = "xrLabelBPTop";
        this.xrLabelBPTop.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelBPTop.Size = new System.Drawing.Size(142, 17);
        this.xrLabelBPTop.StylePriority.UseFont = false;
        this.xrLabelBPTop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabelBPTop.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelBPTop_BeforePrint);
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel5.Location = new System.Drawing.Point(500, 100);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.Size = new System.Drawing.Size(267, 17);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.Text = "Call Details Records";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel6.Location = new System.Drawing.Point(500, 117);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(267, 50);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.Text = "Use the Account Management Portal at www.redbackconferencing.com.au to access all" +
            " Call Detail Records";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel7
        // 
        this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BillingContactName", "")});
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel7.Location = new System.Drawing.Point(83, 175);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.Size = new System.Drawing.Size(558, 17);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.Text = "xrLabel7";
        // 
        // xrLabel8
        // 
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.ComanyName", "")});
        this.xrLabel8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel8.Location = new System.Drawing.Point(83, 192);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.Size = new System.Drawing.Size(558, 17);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.Text = "xrLabel8";
        // 
        // xrLabel9
        // 
        this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BillingContactAddress1", "")});
        this.xrLabel9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel9.Location = new System.Drawing.Point(83, 209);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.Size = new System.Drawing.Size(558, 17);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.Text = "xrLabel9";
        // 
        // xrLabel11
        // 
        this.xrLabel11.CanShrink = true;
        this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BillingContactCity", "")});
        this.xrLabel11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel11.Location = new System.Drawing.Point(83, 250);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.Size = new System.Drawing.Size(142, 17);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.Text = "xrLabel11";
        // 
        // xrLabel12
        // 
        this.xrLabel12.CanShrink = true;
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BillingContactRegion", "")});
        this.xrLabel12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel12.Location = new System.Drawing.Point(233, 250);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.Size = new System.Drawing.Size(75, 17);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.Text = "xrLabel12";
        // 
        // xrLabel13
        // 
        this.xrLabel13.CanShrink = true;
        this.xrLabel13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BillingContactCountry", "")});
        this.xrLabel13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel13.Location = new System.Drawing.Point(317, 250);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.Size = new System.Drawing.Size(92, 17);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.Text = "xrLabel13";
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel14.Location = new System.Drawing.Point(492, 283);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.Size = new System.Drawing.Size(108, 25);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Total Due:";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel16
        // 
        this.xrLabel16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel16.Location = new System.Drawing.Point(8, 325);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.Size = new System.Drawing.Size(125, 17);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.Text = "Account Activity";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLine1
        // 
        this.xrLine1.BorderWidth = 1;
        this.xrLine1.LineWidth = 3;
        this.xrLine1.Location = new System.Drawing.Point(0, 342);
        this.xrLine1.Name = "xrLine1";
        this.xrLine1.Size = new System.Drawing.Size(775, 8);
        this.xrLine1.StylePriority.UseBorderWidth = false;
        // 
        // xrLabel17
        // 
        this.xrLabel17.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel17.Location = new System.Drawing.Point(58, 358);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.Size = new System.Drawing.Size(442, 17);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.Text = "Opening Balance";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel18.Location = new System.Drawing.Point(58, 383);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.Size = new System.Drawing.Size(442, 17);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.Text = "Payments Received";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel19
        // 
        this.xrLabel19.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel19.Location = new System.Drawing.Point(58, 433);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.Size = new System.Drawing.Size(442, 17);
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.Text = "Balance";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel20.Location = new System.Drawing.Point(58, 408);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.Size = new System.Drawing.Size(442, 17);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.Text = "Credits";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel21
        // 
        this.xrLabel21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel21.Location = new System.Drawing.Point(58, 458);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.Size = new System.Drawing.Size(442, 17);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.Text = "New Charges (Including GST)";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel23
        // 
        this.xrLabel23.BackColor = System.Drawing.Color.LightYellow;
        this.xrLabel23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel23.Location = new System.Drawing.Point(58, 483);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.Size = new System.Drawing.Size(442, 17);
        this.xrLabel23.StylePriority.UseBackColor = false;
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.Text = "Total Amount Due";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLine2
        // 
        this.xrLine2.BorderWidth = 1;
        this.xrLine2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        this.xrLine2.LineWidth = 3;
        this.xrLine2.Location = new System.Drawing.Point(0, 783);
        this.xrLine2.Name = "xrLine2";
        this.xrLine2.Size = new System.Drawing.Size(783, 8);
        this.xrLine2.StylePriority.UseBorderWidth = false;
        // 
        // xrLabel25
        // 
        this.xrLabel25.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel25.Location = new System.Drawing.Point(8, 758);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.Size = new System.Drawing.Size(267, 17);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.Text = "Redback Conferencing ABN 22 122 754 554";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel26.Location = new System.Drawing.Point(300, 758);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.Size = new System.Drawing.Size(475, 17);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.Text = "Billing Enquiries: 1800 733 416 or accounting@redbackconferencing.com.au";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLine3
        // 
        this.xrLine3.Location = new System.Drawing.Point(0, 967);
        this.xrLine3.Name = "xrLine3";
        this.xrLine3.Size = new System.Drawing.Size(783, 25);
        // 
        // xrLabel27
        // 
        this.xrLabel27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel27.Location = new System.Drawing.Point(8, 1000);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.Size = new System.Drawing.Size(125, 17);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.Text = "Cheques Payable to:";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel28
        // 
        this.xrLabel28.Font = new System.Drawing.Font("Arial", 8.25F);
        this.xrLabel28.Location = new System.Drawing.Point(8, 1025);
        this.xrLabel28.Multiline = true;
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.Size = new System.Drawing.Size(175, 50);
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.Text = "Redback Conferencing PTY Ltd.\r\nLevel 3, 285 George Street\r\nSydney, NSW, 2000\r\n";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel31
        // 
        this.xrLabel31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel31.Location = new System.Drawing.Point(217, 800);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel31.Size = new System.Drawing.Size(392, 17);
        this.xrLabel31.StylePriority.UseFont = false;
        this.xrLabel31.Text = "Please return this section with your payment";
        this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrPictureBox2
        // 
        this.xrPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox2.Image")));
        this.xrPictureBox2.Location = new System.Drawing.Point(492, 825);
        this.xrPictureBox2.Name = "xrPictureBox2";
        this.xrPictureBox2.Size = new System.Drawing.Size(217, 67);
        // 
        // xrLabel32
        // 
        this.xrLabel32.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel32.Location = new System.Drawing.Point(492, 892);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel32.Size = new System.Drawing.Size(125, 17);
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.Text = "Customer Number:";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel33
        // 
        this.xrLabel33.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel33.Location = new System.Drawing.Point(492, 917);
        this.xrLabel33.Name = "xrLabel33";
        this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel33.Size = new System.Drawing.Size(125, 17);
        this.xrLabel33.StylePriority.UseFont = false;
        this.xrLabel33.Text = "Tax Invoice #:";
        this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel34
        // 
        this.xrLabel34.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel34.Location = new System.Drawing.Point(492, 942);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.Size = new System.Drawing.Size(125, 17);
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.Text = "Date of Issue:";
        this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel35
        // 
        this.xrLabel35.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.ComanyName", "")});
        this.xrLabel35.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel35.Location = new System.Drawing.Point(8, 825);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel35.Size = new System.Drawing.Size(408, 17);
        this.xrLabel35.StylePriority.UseFont = false;
        this.xrLabel35.Text = "xrLabel8";
        // 
        // xrLabel36
        // 
        this.xrLabel36.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel36.Location = new System.Drawing.Point(8, 850);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.Size = new System.Drawing.Size(117, 17);
        this.xrLabel36.StylePriority.UseFont = false;
        this.xrLabel36.Text = "Total Amount Due:";
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel37
        // 
        this.xrLabel37.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel37.Location = new System.Drawing.Point(8, 875);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.Size = new System.Drawing.Size(100, 17);
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.Text = "Please Pay By:";
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel38
        // 
        this.xrLabel38.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel38.Location = new System.Drawing.Point(25, 925);
        this.xrLabel38.Name = "xrLabel38";
        this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel38.Size = new System.Drawing.Size(258, 25);
        this.xrLabel38.StylePriority.UseFont = false;
        this.xrLabel38.Text = "Total Amount Remitted:";
        this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel40
        // 
        this.xrLabel40.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.PriCustomerNumber", "")});
        this.xrLabel40.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel40.Location = new System.Drawing.Point(625, 8);
        this.xrLabel40.Name = "xrLabel40";
        this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel40.Size = new System.Drawing.Size(100, 17);
        this.xrLabel40.StylePriority.UseFont = false;
        this.xrLabel40.Text = "xrLabel40";
        this.xrLabel40.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabel40_BeforePrint);
        // 
        // xrLabel42
        // 
        this.xrLabel42.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.InvoiceDate", "{0:MMMM dd, yyyy}")});
        this.xrLabel42.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel42.Location = new System.Drawing.Point(625, 42);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.Size = new System.Drawing.Size(142, 17);
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.Text = "xrLabel42";
        // 
        // xrLabel43
        // 
        this.xrLabel43.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel43.Location = new System.Drawing.Point(517, 308);
        this.xrLabel43.Name = "xrLabel43";
        this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel43.Size = new System.Drawing.Size(83, 17);
        this.xrLabel43.StylePriority.UseFont = false;
        this.xrLabel43.Text = "Please pay by";
        this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel44
        // 
        this.xrLabel44.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.DueDate", "{0:MMMM dd, yyyy}")});
        this.xrLabel44.Location = new System.Drawing.Point(600, 308);
        this.xrLabel44.Name = "xrLabel44";
        this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel44.Size = new System.Drawing.Size(167, 17);
        xrSummary1.FormatString = "{0:MMMM dd, yyyy}";
        this.xrLabel44.Summary = xrSummary1;
        this.xrLabel44.Text = "xrLabel44";
        // 
        // xrLabel45
        // 
        this.xrLabel45.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.DueDate", "{0:MMMM dd, yyyy}")});
        this.xrLabel45.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel45.Location = new System.Drawing.Point(117, 875);
        this.xrLabel45.Name = "xrLabel45";
        this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel45.Size = new System.Drawing.Size(200, 17);
        this.xrLabel45.StylePriority.UseFont = false;
        xrSummary2.FormatString = "{0:MMMM dd, yyyy}";
        this.xrLabel45.Summary = xrSummary2;
        this.xrLabel45.Text = "xrLabel45";
        // 
        // xrLabel41
        // 
        this.xrLabel41.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.InvoiceNumber", "")});
        this.xrLabel41.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel41.Location = new System.Drawing.Point(625, 25);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel41.Size = new System.Drawing.Size(100, 17);
        this.xrLabel41.StylePriority.UseFont = false;
        this.xrLabel41.Text = "xrLabel41";
        // 
        // xrLabel39
        // 
        this.xrLabel39.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.InvoiceNumber", "")});
        this.xrLabel39.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel39.Location = new System.Drawing.Point(617, 917);
        this.xrLabel39.Name = "xrLabel39";
        this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel39.Size = new System.Drawing.Size(125, 17);
        this.xrLabel39.StylePriority.UseFont = false;
        this.xrLabel39.Text = "xrLabel41";
        // 
        // xrLabel46
        // 
        this.xrLabel46.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.InvoiceDate", "{0:MMMM dd, yyyy}")});
        this.xrLabel46.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel46.Location = new System.Drawing.Point(617, 942);
        this.xrLabel46.Name = "xrLabel46";
        this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel46.Size = new System.Drawing.Size(158, 17);
        this.xrLabel46.StylePriority.UseFont = false;
        xrSummary3.FormatString = "{0:MMMM dd, yyyy}";
        this.xrLabel46.Summary = xrSummary3;
        this.xrLabel46.Text = "xrLabel46";
        // 
        // xrLabel47
        // 
        this.xrLabel47.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.PriCustomerNumber", "")});
        this.xrLabel47.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel47.Location = new System.Drawing.Point(617, 892);
        this.xrLabel47.Name = "xrLabel47";
        this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel47.Size = new System.Drawing.Size(125, 17);
        this.xrLabel47.StylePriority.UseFont = false;
        this.xrLabel47.Text = "xrLabel40";
        // 
        // xrLabel48
        // 
        this.xrLabel48.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BillingContactPostalCode", "")});
        this.xrLabel48.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel48.Location = new System.Drawing.Point(83, 267);
        this.xrLabel48.Name = "xrLabel48";
        this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel48.Size = new System.Drawing.Size(92, 17);
        this.xrLabel48.StylePriority.UseFont = false;
        this.xrLabel48.Text = "xrLabel48";
        // 
        // xrLabel49
        // 
        this.xrLabel49.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.AmountOfLastBill", "{0:$#,##.00  ;$#,##.00;$0.00}")});
        this.xrLabel49.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel49.Location = new System.Drawing.Point(533, 358);
        this.xrLabel49.Name = "xrLabel49";
        this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel49.Size = new System.Drawing.Size(100, 17);
        this.xrLabel49.StylePriority.UseFont = false;
        this.xrLabel49.Text = "xrLabel49";
        this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel50
        // 
        this.xrLabel50.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.Payment1", "{0:$#,##.00  ;$#,##.00;$0.00}")});
        this.xrLabel50.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel50.Location = new System.Drawing.Point(533, 383);
        this.xrLabel50.Name = "xrLabel50";
        this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel50.Size = new System.Drawing.Size(100, 17);
        this.xrLabel50.StylePriority.UseFont = false;
        this.xrLabel50.Text = "xrLabel50";
        this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel51
        // 
        this.xrLabel51.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.TotalCredits", "{0:$#,##.00  ;$#,##.00;$0.00}")});
        this.xrLabel51.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel51.Location = new System.Drawing.Point(533, 408);
        this.xrLabel51.Name = "xrLabel51";
        this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel51.Size = new System.Drawing.Size(100, 17);
        this.xrLabel51.StylePriority.UseFont = false;
        this.xrLabel51.Text = "xrLabel51";
        this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrLabel51.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AmountDisplay);
        // 
        // xrLabel52
        // 
        this.xrLabel52.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BalForward", "{0:$#,##.00  ;$#,##.00;$0.00}")});
        this.xrLabel52.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel52.Location = new System.Drawing.Point(533, 433);
        this.xrLabel52.Name = "xrLabel52";
        this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel52.Size = new System.Drawing.Size(100, 17);
        this.xrLabel52.StylePriority.UseFont = false;
        this.xrLabel52.Text = "xrLabel52";
        this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel55
        // 
        this.xrLabel55.BackColor = System.Drawing.Color.LightYellow;
        this.xrLabel55.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BalanceForward", "{0:$#,##.00  ;$#,##.00;$0.00}")});
        this.xrLabel55.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel55.Location = new System.Drawing.Point(500, 483);
        this.xrLabel55.Name = "xrLabel55";
        this.xrLabel55.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel55.Size = new System.Drawing.Size(133, 17);
        this.xrLabel55.StylePriority.UseBackColor = false;
        this.xrLabel55.StylePriority.UseFont = false;
        this.xrLabel55.Text = "xrLabel55";
        this.xrLabel55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel56
        // 
        this.xrLabel56.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BalanceForward", "{0:$#,##.00  ;$#,##.00 cr;$0.00}")});
        this.xrLabel56.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel56.Location = new System.Drawing.Point(125, 850);
        this.xrLabel56.Name = "xrLabel56";
        this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel56.Size = new System.Drawing.Size(133, 17);
        this.xrLabel56.StylePriority.UseFont = false;
        this.xrLabel56.Text = "xrLabel56";
        this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel15
        // 
        this.xrLabel15.CanShrink = true;
        this.xrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BalanceForward", "{0:$#,##0.00;$#,##0.00;$0.00}")});
        this.xrLabel15.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel15.Location = new System.Drawing.Point(608, 283);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.Size = new System.Drawing.Size(125, 25);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:$#,##0.00;$#,##0.00;$0.00}";
        this.xrLabel15.Summary = xrSummary4;
        this.xrLabel15.Text = "xrLabel15";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel24.Location = new System.Drawing.Point(533, 1000);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.Size = new System.Drawing.Size(75, 17);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.Text = "Biller Code:";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel57
        // 
        this.xrLabel57.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel57.Location = new System.Drawing.Point(533, 1025);
        this.xrLabel57.Name = "xrLabel57";
        this.xrLabel57.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel57.Size = new System.Drawing.Size(75, 17);
        this.xrLabel57.StylePriority.UseFont = false;
        this.xrLabel57.Text = "Ref:";
        this.xrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        // 
        // xrLabel10
        // 
        this.xrLabel10.CanShrink = true;
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BillingContactAddress2", "")});
        this.xrLabel10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel10.Location = new System.Drawing.Point(83, 226);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.Size = new System.Drawing.Size(558, 16);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.Text = "xrLabel10";
        // 
        // xrPictureBox3
        // 
        this.xrPictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox3.Image")));
        this.xrPictureBox3.Location = new System.Drawing.Point(458, 1000);
        this.xrPictureBox3.Name = "xrPictureBox3";
        this.xrPictureBox3.Size = new System.Drawing.Size(50, 67);
        // 
        // xrLabel58
        // 
        this.xrLabel58.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_InvoiceSummary_GetInvoiceSummary.BPayCustomerRefNumber", "")});
        this.xrLabel58.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel58.Location = new System.Drawing.Point(617, 1025);
        this.xrLabel58.Name = "xrLabel58";
        this.xrLabel58.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel58.Size = new System.Drawing.Size(150, 17);
        this.xrLabel58.StylePriority.UseFont = false;
        this.xrLabel58.Text = "xrLabel58";
        // 
        // xrNewCharges
        // 
        this.xrNewCharges.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrNewCharges.ForeColor = System.Drawing.Color.Black;
        this.xrNewCharges.Location = new System.Drawing.Point(533, 458);
        this.xrNewCharges.Name = "xrNewCharges";
        this.xrNewCharges.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrNewCharges.Size = new System.Drawing.Size(100, 17);
        this.xrNewCharges.StylePriority.UseFont = false;
        this.xrNewCharges.StylePriority.UseForeColor = false;
        this.xrNewCharges.Text = "xrNewCharges";
        this.xrNewCharges.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
        this.xrNewCharges.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrNewCharges_BeforePrint);
        // 
        // xrLabel53
        // 
        this.xrLabel53.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel53.Location = new System.Drawing.Point(617, 1000);
        this.xrLabel53.Name = "xrLabel53";
        this.xrLabel53.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel53.Size = new System.Drawing.Size(75, 17);
        this.xrLabel53.StylePriority.UseFont = false;
        this.xrLabel53.Text = "160796";
        this.xrLabel53.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel54
        // 
        this.xrLabel54.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel54.ForeColor = System.Drawing.Color.Black;
        this.xrLabel54.Location = new System.Drawing.Point(200, 1000);
        this.xrLabel54.Name = "xrLabel54";
        this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel54.Size = new System.Drawing.Size(233, 17);
        this.xrLabel54.StylePriority.UseFont = false;
        this.xrLabel54.StylePriority.UseForeColor = false;
        this.xrLabel54.Text = "Telephone & Internet Banking - BPAY";
        this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel59
        // 
        this.xrLabel59.Font = new System.Drawing.Font("Arial", 8F);
        this.xrLabel59.ForeColor = System.Drawing.Color.Black;
        this.xrLabel59.Location = new System.Drawing.Point(200, 1025);
        this.xrLabel59.Name = "xrLabel59";
        this.xrLabel59.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel59.Size = new System.Drawing.Size(233, 42);
        this.xrLabel59.StylePriority.UseFont = false;
        this.xrLabel59.StylePriority.UseForeColor = false;
        this.xrLabel59.Text = "Contact your bank or financial institution to make this payment from your cheque," +
            " or savings account. More info:www.bpay.com.au";
        this.xrLabel59.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabelAmountOfLastBlanceCR
        // 
        this.xrLabelAmountOfLastBlanceCR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelAmountOfLastBlanceCR.Location = new System.Drawing.Point(633, 358);
        this.xrLabelAmountOfLastBlanceCR.Name = "xrLabelAmountOfLastBlanceCR";
        this.xrLabelAmountOfLastBlanceCR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelAmountOfLastBlanceCR.Size = new System.Drawing.Size(33, 17);
        this.xrLabelAmountOfLastBlanceCR.StylePriority.UseFont = false;
        this.xrLabelAmountOfLastBlanceCR.Text = " ";
        this.xrLabelAmountOfLastBlanceCR.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.AmountofLastBalanceCRDisplay);
        // 
        // xrLabelPaymentCR
        // 
        this.xrLabelPaymentCR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelPaymentCR.Location = new System.Drawing.Point(633, 383);
        this.xrLabelPaymentCR.Name = "xrLabelPaymentCR";
        this.xrLabelPaymentCR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelPaymentCR.Size = new System.Drawing.Size(33, 17);
        this.xrLabelPaymentCR.StylePriority.UseFont = false;
        this.xrLabelPaymentCR.Text = " ";
        this.xrLabelPaymentCR.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.PaymentDisplayCR);
        // 
        // xrLabelTotalCreditCR
        // 
        this.xrLabelTotalCreditCR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelTotalCreditCR.Location = new System.Drawing.Point(633, 408);
        this.xrLabelTotalCreditCR.Name = "xrLabelTotalCreditCR";
        this.xrLabelTotalCreditCR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelTotalCreditCR.Size = new System.Drawing.Size(33, 17);
        this.xrLabelTotalCreditCR.StylePriority.UseFont = false;
        this.xrLabelTotalCreditCR.Text = " ";
        this.xrLabelTotalCreditCR.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.TotalCreditDisplayCR);
        // 
        // xrLabelBalForwardCR
        // 
        this.xrLabelBalForwardCR.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabelBalForwardCR.Location = new System.Drawing.Point(633, 433);
        this.xrLabelBalForwardCR.Name = "xrLabelBalForwardCR";
        this.xrLabelBalForwardCR.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabelBalForwardCR.Size = new System.Drawing.Size(33, 17);
        this.xrLabelBalForwardCR.StylePriority.UseFont = false;
        this.xrLabelBalForwardCR.Text = " ";
        this.xrLabelBalForwardCR.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.BalForwardDisplayCR);
        // 
        // xrSubreport1
        // 
        this.xrSubreport1.Location = new System.Drawing.Point(0, 517);
        this.xrSubreport1.Name = "xrSubreport1";
        this.xrSubreport1.Size = new System.Drawing.Size(775, 225);
        this.xrSubreport1.ParentChanged += new DevExpress.XtraReports.UI.ChangeEventHandler(this.xrSubreport1_ParentChanged);
        // 
        // sqlDataAdapter1
        // 
        this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand;
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
        // sqlSelectCommand
        // 
        this.sqlSelectCommand.CommandText = "dbo.p_InvoiceSummary_GetInvoiceSummary";
        this.sqlSelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
        this.sqlSelectCommand.Connection = this.sqlConnection1;
        this.sqlSelectCommand.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Current, null),
            new System.Data.SqlClient.SqlParameter("@StartDate", System.Data.SqlDbType.DateTime, 8),
            new System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.Int, 4)});
        // 
        // sqlConnection1
        // 
        this.sqlConnection1.ConnectionString = "Data Source=DEV;Initial Catalog=CONFDB;Integrated Security=True";
        this.sqlConnection1.FireInfoMessageEventOnUserErrors = false;
        // 
        // dsInvoice1
        // 
        this.dsInvoice1.DataSetName = "dsInvoice";
        this.dsInvoice1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // xrCrossBandBox1
        // 
        this.xrCrossBandBox1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
        this.xrCrossBandBox1.EndBand = this.Detail;
        this.xrCrossBandBox1.EndPoint = new System.Drawing.Point(8, 961);
        this.xrCrossBandBox1.Name = "xrCrossBandBox1";
        this.xrCrossBandBox1.StartBand = this.Detail;
        this.xrCrossBandBox1.StartPoint = new System.Drawing.Point(8, 917);
        this.xrCrossBandBox1.Width = 400;
        // 
        // InvoiceForCustomer
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
        this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox1});
        this.DataAdapter = this.sqlDataAdapter1;
        this.DataMember = "p_InvoiceSummary_GetInvoiceSummary";
        this.DataSource = this.dsInvoice1;
        this.Margins = new System.Drawing.Printing.Margins(50, 17, 0, 0);
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.dsInvoice1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

	}

	#endregion

    private void CreditDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        /*
        try
        {
            Double dollars = Double.Parse(this.GetCurrentColumnValue("TotalCredits").ToString());

            if (dollars < 0)
                (sender as XRLabel).Text = "cr";
            else
                (sender as XRLabel).Text = "";

        }
        catch { };
        */
    }

    private void AmountDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        try
        {
            Double dollars = Double.Parse(this.GetCurrentColumnValue("TotalCredits").ToString());

            (sender as XRLabel).Text = String.Format("{0:$#,##.00  ;$#,##.00;$0.00}", dollars);
        }
        catch { };

    }

    private void xrSubreport1_ParentChanged(object sender, ChangeEventArgs e)
    {

    }

    private void xrLabel40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        // Capture CustmerID, StartDate
        customerID = Int32.Parse(this.GetCurrentColumnValue("CustomerID").ToString());
        startDate = DateTime.Parse(this.GetCurrentColumnValue("StartDate").ToString());

        
        InvoiceForCustomerService servreport = new InvoiceForCustomerService();
        servreport.StartDate = startDate;
        servreport.CustomerID = customerID;
        servreport.BillingPeriod = BuildInvoiceDate();

        servreport.TotalNewChargesWithGST = String.Format("{0:$#,##.00  ;$#,##.00;$0.00}", CalculateNewCharges());
        servreport.GST = String.Format("{0:$#,##.00  ;$#,##.00;$0.00}", CalculateTax());


        servreport.BindData();

        xrSubreport1.ReportSource = servreport;

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

    private double CalculateTax()
    {
        double fedTax = Double.Parse(this.GetCurrentColumnValue("FederalTaxAmount").ToString());
        double localTax = Double.Parse(this.GetCurrentColumnValue("LocalTaxAmount").ToString());

        double totTax = fedTax + localTax;

        return totTax;
    }

    private void xrNewCharges_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        double newCharges = CalculateNewCharges();
        (sender as XRLabel).Text = String.Format("{0:$#,##.00  ;$#,##.00;$0.00}", newCharges);

    }



    private void xrTaxes_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        double totTax = CalculateTax();
        (sender as XRLabel).Text = String.Format("{0:$#,##.00  ;$#,##.00;$0.00}", totTax);
    }

    private void AmountofLastBalanceCRDisplay(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(this.GetCurrentColumnValue("AmountOfLastBill").ToString());

    }

    private void PaymentDisplayCR(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(this.GetCurrentColumnValue("Payment1").ToString());

    }

    private void TotalCreditDisplayCR(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(this.GetCurrentColumnValue("TotalCredits").ToString());

    }

    private void BalForwardDisplayCR(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(this.GetCurrentColumnValue("BalForward").ToString());

    }

    private void NewChargesDisplayCR(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(xrNewCharges.Text);

    }

    /*
    private void GSTDisplayCR(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(xrTaxes.Text);

    }
    */

    private void BalanceForwardDisplayCR(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(this.GetCurrentColumnValue("BalanceForward").ToString());
    }

    private string DisplayCR(string value)
    {
        string retStr = "";
        try
        {
            Double dollars = Double.Parse(value);

            if (dollars < 0)
                retStr = "cr";
            else
                retStr = "";

        }
        catch { };

        return retStr;
    }

    private string BuildInvoiceDate()
    {
        DateTime startDate = DateTime.Parse(this.GetCurrentColumnValue("StartDate").ToString());
        DateTime endDate = DateTime.Parse(this.GetCurrentColumnValue("EndDate").ToString());

        string outStr = startDate.ToString("MMMM d") + " - " + endDate.ToString("d, yyyy");

        return outStr;
    }

    private void xrLabelTotalDueCR_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        (sender as XRLabel).Text = DisplayCR(this.GetCurrentColumnValue("BalanceForward").ToString());
    }

    private void xrLabelBPTop_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        string billingPeriod = BuildInvoiceDate();
        //(sender as XRLabel).Text = (sender as XRLabel).Text + billingPeriod;
        (sender as XRLabel).Text = billingPeriod;
    }

}
