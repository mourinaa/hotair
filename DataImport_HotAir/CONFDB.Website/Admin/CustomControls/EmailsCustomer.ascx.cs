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
using au.com.redbackconferencing.ws;

public partial class EmailsCustomer : System.Web.UI.UserControl
{
    private string _CustomerID;

    public string CustomerID
    {
        get { return _CustomerID; }
        set { _CustomerID = value; }
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
        if (Visible && Enabled && CustomerID != null)
        {
            try
            {
                lblCustomerID.Text = CustomerID;
                //Get the data
                DataSet ds;
                EmailTemplateUtil etu = new EmailTemplateUtil();
                ds = etu.GetEmailTemplateInfo(ConfigurationManager.AppSettings["WholesalerID"]);
                //Filter for only Customer email templates
                ds.Tables[0].DefaultView.RowFilter = "SendToContact = true";
                ddlEmailTemplate.DataSource = ds.Tables[0].DefaultView;
                ddlEmailTemplate.DataBind(); //Bind everything.

            }
            catch (Exception ex)
            {
                //disable control if there is an error
                Visible = false;
                Enabled = false;
                tblEmailTemplate.Visible = Visible;
            }
        }
        else //not valid so disable control
        {
            Visible = false;
            Enabled = false;
            tblEmailTemplate.Visible = Visible;
            //ddlEmailTemplate.Visible = Visible;
            //ddlEmailTemplate.Enabled = Enabled;
        }

    }

    protected void cmdSendEmail_Click(object sender, EventArgs e)
    {
        try
        {
            string strTemplateName;
            string strMsgResult;
            //Clear the Label msg
            lblResults.Text = "";
            //Get the templatename to send.
            strTemplateName = ddlEmailTemplate.SelectedValue;
            //setting the Customer id for the control, get from hidden control
            CustomerID = lblCustomerID.Text;
            //get the primary customer number and pass to Template engine in case there is Customer specific branding
            CustomerService custService = new CustomerService();
            Customer cust = custService.GetById(Convert.ToInt32(CustomerID));

            //Send the template and get the return msg - which might contain an error msg
            EmailTemplateUtil etu = new EmailTemplateUtil();

            //JS Mod: Dec 9/2014 - use default from database settings, so don't pass anything to web services.
            strMsgResult = etu.SendEmailByCustomerID(ConfigurationManager.AppSettings["WholesalerID"], cust.Id,
                strTemplateName, cust.PriCustomerNumber, txtCCList.Text, chkSendToCustomer.Checked ? 1 : 0,
                0, //don't send to moderator
                -1);//pass -1 IncludeAttachment to use default settings

            //If the result is blank then everything was good
            if (strMsgResult == "")
            {
                lblResults.Text = "Email sent successfully.";
            }
            else
            {
                //Handles Error cases and cases when the email was sent but no attachment was found
                lblResults.Text = strMsgResult;
            }

        }
        catch (Exception ex)
        {
            lblResults.Text = "Error sending email: " + ex.Message;
        }
    }
}
