
#region Imports...
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
using CONFDB.Web.UI;
using CONFDB.Web.Data;
using CONFDB.Entities;
using CONFDB.Services;
using CONFDB.Data;
#endregion

public partial class CustomerEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormUtil.RedirectAfterInsertUpdate(FormView1, "CustomerEdit.aspx?{0}", CustomerDataSource);
        FormUtil.RedirectAfterAddNew(FormView1, "CustomerEdit.aspx");
        FormUtil.RedirectAfterCancel(FormView1, "Customer.aspx");
        FormUtil.SetDefaultMode(FormView1, "Id");

        if (!IsPostBack)
        {
            BindData();
        }

        SetControls();
        SetPermissions();
    }

    /// <summary>
    /// Used to load User Controls and other items that our data bound.
    /// </summary>
    protected void BindData()
    {
        //if the companyid is passed in then set the CompanyUC to it, else just show them all
        string companyID = FormUtil.GetRequestParameter("CompanyId", null);
        if (!string.IsNullOrEmpty(companyID))
        {
            ((CompanyUC)FormView1.FindControl("ucCompanyId")).CompanyID = companyID;
        }
        ((CompanyUC)FormView1.FindControl("ucCompanyId")).BindData();
        //Get the CustomerID value, store it and use it to load related user controls
        string custID = FormUtil.GetRequestParameter("Id", null);
        lblCustomerID.Text = custID == null ? "" : custID;
        ucDNISCustomer.CustomerID = custID;
        ucDNISCustomer.BindData();
        ucProductRatesCustomer.CustomerID = custID;
        ucProductRatesCustomer.BindData();
        ucFeaturesCustomer.CustomerID = custID;
        ucFeaturesCustomer.BindData();
        ucEmailsCustomer.CustomerID = custID;
        ucEmailsCustomer.BindData();
    }

    /// <summary>
    /// Used to set the value of controls.
    /// </summary>
    protected void SetControls()
    {
        //Things to set when in Insert mode
        if (FormView1.DefaultMode == FormViewMode.Insert)
        {
            //Gen Password
            if (((TextBox)FormView1.FindControl("txtPassword")).Text == "")
            {
                string Password = "";
                DataRepository.UtilProvider.GeneratePassword(ConfigurationManager.AppSettings["WholesalerId"].ToString(),
                    null, null, null, ref Password);
                ((TextBox)FormView1.FindControl("txtPassword")).Text = Password;
            }
            //Default the Country to AU
            ((EntityDropDownList)FormView1.FindControl("dataPrimaryContactCountry")).SelectedValue = "AU";

        }
        //Any Mode
        //If the SalesPersonID is set for the user then set the Sales Person list to specific SP
        UserSession us = new UserSession();
        if (us.SalesPersonID != null)
        {
            EntityDropDownList dataSalesPersonId = FormView1.FindControl("dataSalesPersonId") as EntityDropDownList;
            dataSalesPersonId.SelectedValue = us.SalesPersonID.ToString();
        }

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
            ((Button)FormView1.FindControl("InsertButton")).Enabled = false;
            ((Button)FormView1.FindControl("UpdateButton")).Enabled = false;
            if (FormView1.DefaultMode == FormViewMode.Insert)
            {
                ((Button)FormView1.FindControl("btnCheckUser")).Enabled = false;
            }
            else
            {
                ((Button)FormView1.FindControl("btnAddNew")).Enabled = false;
                hypConference.Enabled = false;
            }
            //Disallow any less then a Sales Manager (60) to change this value
            ((EntityDropDownList)FormView1.FindControl("dataSalesPersonId")).ReadOnly = true;
            //Added the ReadOnly option to the ucCompany to limit SA premissions
            ((CompanyUC)FormView1.FindControl("ucCompanyId")).Enabled = false;
        }
        else
        {
            ((Button)FormView1.FindControl("InsertButton")).Enabled = true;
            ((Button)FormView1.FindControl("UpdateButton")).Enabled = true;
            if (FormView1.DefaultMode == FormViewMode.Insert)
            {
                ((Button)FormView1.FindControl("btnCheckUser")).Enabled = true;
            }
            else
            {
                ((Button)FormView1.FindControl("btnAddNew")).Enabled = true;
                hypConference.Enabled = true;
            }
            //Disallow any less then a Sales Manager (60) to change this value
            ((EntityDropDownList)FormView1.FindControl("dataSalesPersonId")).ReadOnly = false;
            //Added the ReadOnly option to the ucCompany to limit SA premissions
            ((CompanyUC)FormView1.FindControl("ucCompanyId")).Enabled = true;
        }
    }


    protected void GridViewDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewDepartment.SelectedDataKey.Values[0]);
        Response.Redirect("DepartmentEdit.aspx?" + urlParams, true);
    }
    protected void GridViewConference_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewConference.SelectedDataKey.Values[0]);
        Response.Redirect("ConferenceEdit.aspx?" + urlParams, true);
    }
    protected void hypConference_Click(object sender, EventArgs e)
    {
        string urlParams = string.Format("CustomerId={0}", lblCustomerID.Text);
        Response.Redirect("ConferenceEdit.aspx?" + urlParams, true);
    }


    /// <summary>
    /// Before inserting, enforce some biz rule:
    /// - Get the next Primary Customer Number 
    /// - copy over the Primary Contact info to the Billing Info
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //Get the next PriCustomerNumber value.
        //Doing it this way allows for cases where this rule could be changed.
        CustomerService CustService = new CustomerService();
        string PriCustNum = "";
        string WholesalerID = e.InputParameters["WholesalerId"].ToString();
        CustService.GetNextCustomerNumber(WholesalerID, ref PriCustNum);
        if (PriCustNum != "")
            e.InputParameters["PriCustomerNumber"] = PriCustNum;

        if (e.InputParameters["WebsiteUrl"].ToString() == "")
            e.InputParameters["WebsiteUrl"] = ((Label)FormView1.FindControl("lblResellerDefaultWebURL")).Text;

        //Copy over the Primary contact info if not set.
        if (e.InputParameters["BillingContactName"].ToString() == "")
            e.InputParameters["BillingContactName"] = e.InputParameters["PrimaryContactName"];
        if (e.InputParameters["BillingContactPhoneNumber"].ToString() == "")
            e.InputParameters["BillingContactPhoneNumber"] = e.InputParameters["PrimaryContactPhoneNumber"];
        if (e.InputParameters["BillingContactEmailAddress"].ToString() == "")
            e.InputParameters["BillingContactEmailAddress"] = e.InputParameters["PrimaryContactEmailAddress"];
        if (e.InputParameters["BillingContactAddress1"].ToString() == "")
            e.InputParameters["BillingContactAddress1"] = e.InputParameters["PrimaryContactAddress1"];
        if (e.InputParameters["BillingContactAddress2"].ToString() == "")
            e.InputParameters["BillingContactAddress2"] = e.InputParameters["PrimaryContactAddress2"];
        if (e.InputParameters["BillingContactCity"].ToString() == "")
            e.InputParameters["BillingContactCity"] = e.InputParameters["PrimaryContactCity"];
        if (e.InputParameters["BillingContactCountry"].ToString() == "")
            e.InputParameters["BillingContactCountry"] = e.InputParameters["PrimaryContactCountry"];
        if (e.InputParameters["BillingContactRegion"].ToString() == "")
            e.InputParameters["BillingContactRegion"] = e.InputParameters["PrimaryContactRegion"];
        if (e.InputParameters["BillingContactPostalCode"].ToString() == "")
            e.InputParameters["BillingContactPostalCode"] = e.InputParameters["PrimaryContactPostalCode"];
        if (e.InputParameters["BillingContactFaxNumber"].ToString() == "")
            e.InputParameters["BillingContactFaxNumber"] = e.InputParameters["PrimaryContactFaxNumber"];
        //Default the BillingPeriodCutoff
        if (e.InputParameters["BillingPeriodCutoff"].ToString() == "")
            e.InputParameters["BillingPeriodCutoff"] = "31";

    }

    /// <summary>
    /// Used to handle the Ajax check of the User Info when first created.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCheckUser_Click(object sender, EventArgs e)
    {
        //reset error messages.
        ((Label)FormView1.FindControl("lblInvalidUserName")).Visible = false;
        ((Label)FormView1.FindControl("lblInvalidPassword")).Visible = false;
        ((Label)FormView1.FindControl("CheckUserMsg")).Visible = false;

        //Hack: Regardless of the UpdatePanel the UC inside the FormView does a full page refresh so 
        // set the focus to the Check User button to make it a bit more seemless.
        // THIS IS BY DESIGN WHEN USING DATASOURCE CONTROLS. SEE: 
        // http://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=292398
        FormUtil.SetDefaultFocus(FormView1.FindControl("btnCheckUser"));

        //Check if the UserName is unique and Password is not less then 8 characters
        string _UserName = ((TextBox)FormView1.FindControl("txtUserName")).Text;
        string _Password = ((TextBox)FormView1.FindControl("txtPassword")).Text;

        try
        {
            UserGridCustom ucUserGridCustom = new UserGridCustom(); //Has method to test out User validity.

            //reset the insert button to make sure they can't insert the record, sinces its a UC, then look to the Parent for the FormView.
            Button _InsertButton = ((Button)FormView1.FindControl("InsertButton"));
            _InsertButton.Enabled = false;

            if (!ucUserGridCustom.IsValidUserName(_UserName, null)) //New user so there will be no UserID
            {
                //Show some error message.
                ((Label)FormView1.FindControl("lblInvalidUserName")).Visible = true;
                //Make sure they can't insert the record
                return;
            }

            if (!ucUserGridCustom.IsValidPassword(_Password))
            {
                //Show some error message.
                ((Label)FormView1.FindControl("lblInvalidPassword")).Visible = true;
                //Make sure they can't insert the record
                return;
            }
            //Make sure they can insert the record
            _InsertButton.Enabled = true;
            ((Label)FormView1.FindControl("CheckUserMsg")).Visible = true;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    /// <summary>
    /// Add a new Department and refresh Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDepartment_Click(object sender, EventArgs e)
    {
        if (txtDeptment.Text == "")
        {
            return;
        }
        Department dept = new Department();
        dept.WholesalerId = ConfigurationManager.AppSettings["WholesalerId"].ToString();
        dept.CustomerId = Convert.ToInt32(lblCustomerID.Text);
        dept.Name = txtDeptment.Text;
        try
        {
            if (DataRepository.DepartmentProvider.Insert(dept))
            {
                GridViewDepartment.DataBind();
                txtDeptment.Text = "";
            }
        }
        catch (Exception ex)
        {
            //Do nothing
        }
    }

    /// <summary>
    /// After the Customer is added, install the defaults, and create a User login
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerDataSource_AfterInserted(object sender, CONFDB.Web.Data.LinkedDataSourceEventArgs e)
    {
        CustomerService CustService = new CustomerService();
        //Get the inserted object from the args.
        Customer cust = (Customer)e.Entity;
        //Create the User Login
        string _UserName = ((TextBox)FormView1.FindControl("txtUserName")).Text;
        string _Password = ((TextBox)FormView1.FindControl("txtPassword")).Text;
        int? _UserId = null;
        CustService.CreateUser(cust.Id, _UserName, _Password, false, ref _UserId);
        //Copy the defaults down from Wholesaler
        CustService.InstallDefaults(cust.Id);

    }


}