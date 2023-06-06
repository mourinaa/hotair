using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ReportWalletCards : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //hide the report
            ReportViewerControl1.Visible = false;
            ReportViewerControl2.Visible = false;
            SetPermissions();
        }

        #region Code to Check if Report is Paging, if so load from Session Var
        if (Request.UrlReferrer.ToString().Contains(@"/ReportWalletCards.aspx") == false) //put the name of the page 
        {
            Session["rpt-walletcardlist"] = null;
            Session["rpt-walletcard"] = null;
        }

        try // restoring from session, however it will die here if the report type has changed
        // on he catch clear the session variable and query will be re-excuted
        {
            if (Session["rpt-walletcardlist"] != null)
            {
                //Cast to correct report type
                rptWalletCardList rpt1 = (rptWalletCardList)Session["rpt-walletcardlist"];
                ReportViewerControl1.Report = rpt1;
            }
            if (Session["rpt-walletcard"] != null)
            {
                //Cast to correct report type
                rptWalletCard rpt2 = (rptWalletCard)Session["rpt-walletcard"];
                ReportViewerControl2.Report = rpt2;
            }

        }
        catch
        {
            Session["rpt-walletcardlist"] = null;
            Session["rpt-walletcard"] = null;
            btnSubmit_Click(null, null);
        }

        #endregion
    }

    /// <summary>
    /// Used to set the security permissions
    /// </summary>
    protected void SetPermissions()
    {
        //Any Mode
        //If the SalesPersonID is set for the user then set the Sales Person list to specific SP
        UserSession us = new UserSession();
        if (!us.IsAuthenicated)
        {
            us.LogOff();//stops all process and logs user out
        }

        //Sales Agents and less can't add or update
        if (us.UserLevel <= 50)
        {
            if (ddlRequestType.Items.Count == 3)
            {
                ddlRequestType.Items[2].Enabled = false;
            }
        }
        else
        {
            if (ddlRequestType.Items.Count == 3)
            {
                ddlRequestType.Items[2].Enabled = true;
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            int numOfRecs = 0;

            //Two reports are used but only the rptWalletCardList Dataset is used as the
            // information needs to be the same for both reports.
            rptWalletCardList rptWalletList = new rptWalletCardList();
            rptWalletCard rptWCard = new rptWalletCard();

            //Get all the Parameter values
            DateTime StartDate = (string.IsNullOrEmpty(txtStartDate.Text) ? DateTime.Today.AddDays(-1) : DateTime.Parse(txtStartDate.Text));
            DateTime EndDate = (string.IsNullOrEmpty(txtEndDate.Text) ? DateTime.Today : DateTime.Parse(txtEndDate.Text));
            int MarkAsProcessed = Convert.ToInt32(ddlRequestType.SelectedValue);
            UserSession us = new UserSession();
            string strRequestedBy = us.UserProfile.Username;
            //DON"T NEED THIS AS SP TAKES CARE OF IT
            //Move the EndDate to the end of the day
            //EndDate = EndDate.AddHours(23).AddMinutes(59).AddSeconds(59);

            rptWalletList.MarkAsProcessed = MarkAsProcessed;
            rptWalletList.StartDate = StartDate;
            rptWalletList.EndDate = EndDate;
            rptWalletList.RequestCompletedBy = strRequestedBy;

            numOfRecs = rptWalletList.BindData();
            Session["rpt-walletcardlist"] = rptWalletList;
            ReportViewerControl1.Report = rptWalletList;
            ReportViewerControl1.ReportName = "WalletCardList";
            ReportViewerControl1.Visible = true;
            //Build the WalletCard items off of the WalletList dataset information
            rptWCard.BindData(rptWalletList.DataSource);
            Session["rpt-walletcard"] = rptWCard;
            ReportViewerControl2.Report = rptWCard;
            ReportViewerControl2.ReportName = "WalletCard";
            ReportViewerControl2.Visible = true;

        }
        catch (Exception ex)
        {
            lblMessage.Text = "Invalid date range or date format.";
            lblMessage.Text += ex.Message;
            //throw;
        }
    }
}
