using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

/// <summary>
/// Summary description for rptWalletCard
/// </summary>
public class rptWalletCard : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private XRLabel xrLabel10;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel6;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRControlStyle Title;
    private XRControlStyle FieldCaption;
    private XRControlStyle PageInfo;
    private XRControlStyle DataField;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRRichText xrRichText1;
    private XRRichText xrRichText2;
    private dsWelcomeKitRequest dsWelcomeKitRequest1;
    private XRRichText xrRichText3;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptWalletCard()
    {
        #region Move the Init code to the BindData() as it runs before Parameters are passed in
        //InitializeComponent();
        ////
        //// TODO: Add constructor logic here
        ////
        #endregion

    }

    /// <summary>
    /// This BindData differs from other as it takes dataset (object) of dsWelcomeKitRequest and use that
    /// to bind to.
    /// </summary>
    /// <returns></returns>
    public int BindData(object dsWelcomeKitReq)
    {

        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
        if (dsWelcomeKitReq != null)
        {
            dsWelcomeKitRequest1 = (dsWelcomeKitRequest)dsWelcomeKitReq;
        }
        
        //p_WelcomeKitRequest_ProcessRequestTableAdapter1.Fill(
        //    dsWelcomeKitRequest1.p_WelcomeKitRequest_ProcessRequest, StartDate, EndDate, RequestCompletedBy, MarkAsProcessed);

        int rows = dsWelcomeKitRequest1.Tables[0].Rows.Count;
        if (rows > 0)
        {
            this.DataSource = dsWelcomeKitRequest1;
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
        string resourceFileName = "rptWalletCard.resx";
        System.Resources.ResourceManager resources = global::Resources.rptWalletCard.ResourceManager;
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrRichText3 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText2 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrRichText1 = new DevExpress.XtraReports.UI.XRRichText();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
        this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
        this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
        this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
        this.dsWelcomeKitRequest1 = new dsWelcomeKitRequest();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dsWelcomeKitRequest1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrRichText3,
            this.xrRichText2,
            this.xrRichText1,
            this.xrLabel12,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
        this.Detail.Font = new System.Drawing.Font("Arial", 9.75F);
        this.Detail.Height = 225;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrRichText3
        // 
        this.xrRichText3.CanGrow = false;
        this.xrRichText3.Font = new System.Drawing.Font("Arial", 8F);
        this.xrRichText3.Location = new System.Drawing.Point(10, 192);
        this.xrRichText3.Name = "xrRichText3";
        this.xrRichText3.SerializableRtfString = resources.GetString("xrRichText3.SerializableRtfString");
        this.xrRichText3.Size = new System.Drawing.Size(325, 18);
        this.xrRichText3.StylePriority.UseFont = false;
        this.xrRichText3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrRichText2
        // 
        this.xrRichText2.Font = new System.Drawing.Font("Arial", 7.5F);
        this.xrRichText2.Location = new System.Drawing.Point(177, 142);
        this.xrRichText2.Name = "xrRichText2";
        this.xrRichText2.SerializableRtfString = resources.GetString("xrRichText2.SerializableRtfString");
        this.xrRichText2.Size = new System.Drawing.Size(158, 49);
        // 
        // xrRichText1
        // 
        this.xrRichText1.Font = new System.Drawing.Font("Arial", 7.5F);
        this.xrRichText1.Location = new System.Drawing.Point(10, 135);
        this.xrRichText1.Name = "xrRichText1";
        this.xrRichText1.SerializableRtfString = resources.GetString("xrRichText1.SerializableRtfString");
        this.xrRichText1.Size = new System.Drawing.Size(165, 57);
        // 
        // xrLabel12
        // 
        this.xrLabel12.CanGrow = false;
        this.xrLabel12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_WelcomeKitRequest_ProcessRequest.CustomerAdminWebSiteURL", "")});
        this.xrLabel12.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel12.Location = new System.Drawing.Point(131, 94);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel12.Size = new System.Drawing.Size(210, 18);
        this.xrLabel12.StyleName = "DataField";
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UsePadding = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "xrLabel12";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel12.WordWrap = false;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Arial", 8F);
        this.xrLabel11.Location = new System.Drawing.Point(8, 94);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel11.Size = new System.Drawing.Size(120, 18);
        this.xrLabel11.StyleName = "FieldCaption";
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UsePadding = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "Webconferencing URL:";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel11.WordWrap = false;
        // 
        // xrLabel10
        // 
        this.xrLabel10.CanGrow = false;
        this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_WelcomeKitRequest_ProcessRequest.ConferenceName", "")});
        this.xrLabel10.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.Location = new System.Drawing.Point(131, 113);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel10.Size = new System.Drawing.Size(210, 18);
        this.xrLabel10.StyleName = "DataField";
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UsePadding = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel10.WordWrap = false;
        // 
        // xrLabel9
        // 
        this.xrLabel9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_WelcomeKitRequest_ProcessRequest.Local", "")});
        this.xrLabel9.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel9.Location = new System.Drawing.Point(233, 69);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel9.Size = new System.Drawing.Size(108, 17);
        this.xrLabel9.StyleName = "DataField";
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UsePadding = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel8
        // 
        this.xrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_WelcomeKitRequest_ProcessRequest.TollFree", "")});
        this.xrLabel8.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.Location = new System.Drawing.Point(233, 50);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel8.Size = new System.Drawing.Size(108, 17);
        this.xrLabel8.StyleName = "DataField";
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UsePadding = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel7
        // 
        this.xrLabel7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_WelcomeKitRequest_ProcessRequest.ParticipantCode", "")});
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.Location = new System.Drawing.Point(233, 31);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel7.Size = new System.Drawing.Size(108, 17);
        this.xrLabel7.StyleName = "DataField";
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UsePadding = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel6
        // 
        this.xrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "p_WelcomeKitRequest_ProcessRequest.ModeratorCode", "")});
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.Location = new System.Drawing.Point(233, 12);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel6.Size = new System.Drawing.Size(108, 17);
        this.xrLabel6.StyleName = "DataField";
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UsePadding = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel5
        // 
        this.xrLabel5.CanGrow = false;
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 8F);
        this.xrLabel5.Location = new System.Drawing.Point(8, 113);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel5.Size = new System.Drawing.Size(120, 18);
        this.xrLabel5.StyleName = "FieldCaption";
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UsePadding = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Conference Name:";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel5.WordWrap = false;
        // 
        // xrLabel4
        // 
        this.xrLabel4.CanGrow = false;
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 8F);
        this.xrLabel4.Location = new System.Drawing.Point(141, 69);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel4.Size = new System.Drawing.Size(90, 17);
        this.xrLabel4.StyleName = "FieldCaption";
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UsePadding = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Local Dial In:";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel4.WordWrap = false;
        // 
        // xrLabel3
        // 
        this.xrLabel3.CanGrow = false;
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 8F);
        this.xrLabel3.Location = new System.Drawing.Point(141, 50);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel3.Size = new System.Drawing.Size(90, 17);
        this.xrLabel3.StyleName = "FieldCaption";
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UsePadding = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Toll Free Dial In:";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel3.WordWrap = false;
        // 
        // xrLabel2
        // 
        this.xrLabel2.CanGrow = false;
        this.xrLabel2.Font = new System.Drawing.Font("Arial", 8F);
        this.xrLabel2.Location = new System.Drawing.Point(141, 31);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel2.Size = new System.Drawing.Size(90, 17);
        this.xrLabel2.StyleName = "FieldCaption";
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UsePadding = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Participant Code:";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel2.WordWrap = false;
        // 
        // xrLabel1
        // 
        this.xrLabel1.CanGrow = false;
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 8F);
        this.xrLabel1.Location = new System.Drawing.Point(141, 12);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.xrLabel1.Size = new System.Drawing.Size(90, 17);
        this.xrLabel1.StyleName = "FieldCaption";
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UsePadding = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "Moderator Code:";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        this.xrLabel1.WordWrap = false;
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
        this.FieldCaption.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
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
        // dsWelcomeKitRequest1
        // 
        this.dsWelcomeKitRequest1.DataSetName = "dsWelcomeKitRequest";
        this.dsWelcomeKitRequest1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        // 
        // rptWalletCard
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
        this.DataMember = "p_WelcomeKitRequest_ProcessRequest";
        this.DataSource = this.dsWelcomeKitRequest1;
        this.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
        this.PageHeight = 215;
        this.PageWidth = 343;
        this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
        this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField});
        this.Version = "8.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrRichText1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dsWelcomeKitRequest1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
