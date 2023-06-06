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
using CONFDB.Services;
using CONFDB.Entities;

public partial class WalletCardRequestModerator : System.Web.UI.UserControl
{
    private string _ModeratorID;

    public string ModeratorID
    {
        get { return _ModeratorID; }
        set { _ModeratorID = value; }
    }

    private bool _Visible = true;

    public bool Visible
    {
        get { return _Visible; }
        set { _Visible = value; }
    }

    private bool _Enabled = true;

    public bool Enabled
    {
        get { return _Enabled; }
        set { _Enabled = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Used to bind the data for data sources and data controls. If the values are invalid then hide and disable the control.
    /// <remarks>Good article about DataSet filtering can be found here: http://www.akadia.com/services/dotnet_filter_sort.html</remarks>
    /// </summary>
    public void BindData()
    {
        if (Visible && Enabled && ModeratorID != null)
        {
            lblModeratorID.Text = ModeratorID;
            //Get the data
        }
        else //not valid so disable control
        {
            Visible = false;
            Enabled = false;
            tblWalletCardRequest.Visible = Visible;
        }

    }

    protected void cmdSend_Click(object sender, EventArgs e)
    {
        try
        {
            //Clear the Label msg
            lblResults.Text = "";
            //setting the moderator id for the control, get from hidden control
            ModeratorID = lblModeratorID.Text;

            //Delete any wallet card request that have not been process and add a new one.
            WelcomeKitRequestService wkrService = new WelcomeKitRequestService();
            wkrService.AddRequest(Convert.ToInt32(ModeratorID), "AdminSite", txtNotes.Text);
            lblResults.Text = "Request submitted successfully.";

        }
        catch (Exception ex)
        {
            lblResults.Text = "Error submitting request: " + ex.Message;
        }
    }
}
