
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
using CONFDB.Data.Bases;
using CONFDB.Web.UI;
using CONFDB.Entities;
using CONFDB.Services;
using CONFDB.Data;

using System.Collections.Specialized;
using System.Net;
using CommandEventArgs = System.Web.UI.WebControls.CommandEventArgs;

#endregion

public partial class ConferenceEdit : System.Web.UI.Page
{
    protected string CustomerID;
    //Add ModeratorID to make it easier to set in different scenarios as ie. after adding
    protected void Page_Load(object sender, EventArgs e)
    {
        FormUtil.RedirectAfterInsertUpdate(FormView1, "ConferenceEdit.aspx?{0}", ModeratorDataSource);
        FormUtil.RedirectAfterAddNew(FormView1, "ConferenceEdit.aspx");
        FormUtil.RedirectAfterCancel(FormView1, "Conference.aspx");
        FormUtil.SetDefaultMode(FormView1, "Id");
        CustomerID = FormUtil.GetRequestParameter("CustomerId", null);
        if (!IsPostBack)
        {
            BindData();
        }
        //Set the security based permissions on the form
        SetPermissions();
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
                ((EntityDropDownList)FormView1.FindControl("ddlUsers")).Enabled = false;
            }
            else
            {
                ((Button)FormView1.FindControl("btnAddNew")).Enabled = false;
            }
        }
        else
        {
            ((Button)FormView1.FindControl("InsertButton")).Enabled = true;
            ((Button)FormView1.FindControl("UpdateButton")).Enabled = true;
            if (FormView1.DefaultMode == FormViewMode.Insert)
            {
                ((Button)FormView1.FindControl("btnCheckUser")).Enabled = true;
                ((EntityDropDownList)FormView1.FindControl("ddlUsers")).Enabled = true;
            }
            else
            {
                ((Button)FormView1.FindControl("btnAddNew")).Enabled = true;
            }
        }
        //If the Customer is disabled then disable the buttons.
        string modID = FormUtil.GetRequestParameter("Id", null);
        Customer cust = null;

        if (!string.IsNullOrEmpty(modID))
        {
            int CustomerID = DataRepository.ModeratorProvider.GetById(Convert.ToInt32(modID)).CustomerId;
            cust = DataRepository.CustomerProvider.GetById(CustomerID);
        }
        else
        {
            cust = DataRepository.CustomerProvider.GetById(Convert.ToInt32(CustomerID));
        }

        if (!cust.Enabled.Value)
        {
            ((Button)FormView1.FindControl("btnAddNew")).Enabled = false;
            ((Button)FormView1.FindControl("InsertButton")).Enabled = false;
            ((Button)FormView1.FindControl("UpdateButton")).Enabled = false;
        }
        else
        {
            ((Button)FormView1.FindControl("btnAddNew")).Enabled = true;
            ((Button)FormView1.FindControl("InsertButton")).Enabled = true;
            ((Button)FormView1.FindControl("UpdateButton")).Enabled = true;
        }

    }

    /// <summary>
    /// Used to load User Controls and other items that our data bound.
    /// </summary>
    protected void BindData()
    {
        //Set the Customer DDL
        string CustomerID = FormUtil.GetRequestParameter("CustomerId", null);
        if (!string.IsNullOrEmpty(CustomerID))
        {
            ((EntityDropDownList)FormView1.FindControl("dataCustomerId")).SelectedValue = CustomerID;
            //Force Customer Change logic
            ChangeCustomer(CustomerID);
        }
        string modID = FormUtil.GetRequestParameter("Id", null);
        //Connect User Controls and force them to data bind
        ucDNISModerator.ModeratorID = modID;
        ucDNISModerator.BindData();
        ucFeaturesModerator.ModeratorID = modID;
        ucFeaturesModerator.BindData();
        ucEmailsModerator.ModeratorID = modID;
        ucEmailsModerator.BindData();
        ucWalletCardRequestModerator.ModeratorID = modID;
        ucWalletCardRequestModerator.BindData();
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
            UserGridModerator ucUserGridModerator = new UserGridModerator(); //Has method to test out User validity.

            //reset the insert button to make sure they can't insert the record, sinces its a UC, then look to the Parent for the FormView.
            Button _InsertButton = ((Button)FormView1.FindControl("InsertButton"));
            _InsertButton.Enabled = false;

            if (!ucUserGridModerator.IsValidUserName(_UserName, null)) //New user so there will be no UserID
            {
                //Show some error message.
                ((Label)FormView1.FindControl("lblInvalidUserName")).Visible = true;
                //Make sure they can't insert the record
                return;
            }

            if (!ucUserGridModerator.IsValidPassword(_Password))
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
    /// Generate the Mod Codes and other defaults on inserting as the DB requires them. This event fires just before saving to DB.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ModeratorDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //Create the Service layer to Gen the codes.
        ModeratorService ModService = new ModeratorService();
        //Get some codes
        string ModCode = "";
        string PassCode = "";
        string WholesalerID = ConfigurationManager.AppSettings["WholesalerID"];
        int CustomerID = Convert.ToInt32(e.InputParameters["CustomerId"].ToString());

        //Grab the values from the datasource. The inputparam's map to what the DB is expecting and not the control names.
        ModService.GenerateCodes(WholesalerID, CustomerID, null, null, null, ref ModCode, ref PassCode);
        e.InputParameters["ModeratorCode"] = ModCode;
        e.InputParameters["PassCode"] = PassCode;     //20141015 TK use seevogh meeting id as participant code

        //Put the setting of these in InstallDefaults as it too much work to do in the front-end for little reason.
        //e.InputParameters["PriCustomerNumber"] = ;
        //e.InputParameters["SecCustomerNumber"] = ;

    }
    
    /// <summary>
    /// After Moderator added, install defaults and fix any data items.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ModeratorDataSource_AfterInserted(object sender, CONFDB.Web.Data.LinkedDataSourceEventArgs e)
    {
        ModeratorService ModService = new ModeratorService();
        //Get the inserted object from the args.
        Moderator mod = (Moderator)e.Entity;
        //Create the User Login
        string ExistingUserId = ((EntityDropDownList)FormView1.FindControl("ddlUsers")).SelectedValue;

        int? UserId = null;
        //check if the user selected and existing user
        if (ExistingUserId != "")
        {
            //Update the moderator and save it
            mod.UserId = Convert.ToInt32(ExistingUserId);
            ModService.Save(mod);

        }
        else
        {
            //Create a new User linked to the Moderator
            string UserName = ((TextBox)FormView1.FindControl("txtUserName")).Text;
            string Password = ((TextBox)FormView1.FindControl("txtPassword")).Text;
            string DisplayName = ((TextBox)FormView1.FindControl("dataDisplayName")).Text;
            string Telephone = ((TextBox)FormView1.FindControl("dataTelephone")).Text;
            string Address1 = ((TextBox)FormView1.FindControl("dataAddress1")).Text;
            string Address2 = ((TextBox)FormView1.FindControl("dataAddress2")).Text;
            string City = ((TextBox)FormView1.FindControl("dataCity")).Text;
            string Country = ((EntityDropDownList)FormView1.FindControl("dataCountry")).SelectedValue;
            string Region = ((EntityDropDownList)FormView1.FindControl("dataRegion")).SelectedValue;
            string PostalCode = ((TextBox)FormView1.FindControl("dataPostalCode")).Text;
            string CharityId = ((EntityDropDownList)FormView1.FindControl("dataCharityId")).SelectedValue;

            //CreateUser updated the Moderator to link it to User, UserId pass back for info or future biz processes.
            ModService.CreateUser(mod.Id, UserName, Password, DisplayName, Telephone, Address1, Address2, City
                , Country, Region, PostalCode, Convert.ToInt32(CharityId), true, false, ref UserId);
        }

        //Copy the defaults down from Customer to Moderator
        ModService.InstallDefaults(mod.Id);
    }


    /// <summary>
    /// Generates new Code based on which button was clicked. This is used by the User to select new codes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGenCode_Click(object sender, CommandEventArgs e)
    {
        ModeratorService ModService = new ModeratorService();
        string ModCode = "";
        string PassCode = "";
        string SeeVoghMeetingId = "";
        int? ModeratorID = null;

        //Get the controls to retrieve info from and to set.
        if (FormView1.CurrentMode == FormViewMode.Edit)
        {
            ModeratorID = Convert.ToInt32(FormView1.DataKey.Value.ToString());
        }
        //int CustomerID = Convert.ToInt32(((EntityDropDownList)FormView1.FindControl("dataCustomerID")).Text);
        TextBox txtModeratorCode = FormView1.FindControl("dataModeratorCode") as TextBox;
        TextBox txtPassCode = FormView1.FindControl("dataPassCode") as TextBox;
        
        switch (e.CommandName)
        {
            case "GenModCode":
                ModService.GenerateCodes(null, null, ModeratorID, null, null, ref ModCode, ref PassCode);
                txtModeratorCode.Text = ModCode;
                ((Label)FormView1.FindControl("lblModCodeReminder")).Visible = true;
                FormUtil.SetDefaultFocus(txtModeratorCode);
                break;
            case "GenPassCode":
                ModService.GenerateCodes(null, null, ModeratorID, null, null, ref ModCode, ref PassCode);
                txtPassCode.Text = PassCode;
                ((Label)FormView1.FindControl("lblPassCodeReminder")).Visible = true;
                FormUtil.SetDefaultFocus(txtPassCode);
                break;
        }

    }

    /// <summary>
    /// When the Customer value is selected, enable the Existing User list as this is tied to it,  pre-populate
    /// User Address info as most of the time it is the same as the Customer, and Generate Password
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataCustomerId_SelectedIndexChanged(object sender, EventArgs e)
    {
        string CustomerID = ((EntityDropDownList)FormView1.FindControl("dataCustomerId")).SelectedValue;
        ChangeCustomer(CustomerID);
    }

    /// <summary>
    /// Update the screen to the correct Customer when a different one is selected from the dropdown list.
    /// Refactored Customer Change Logic here to be called from other places.
    /// </summary>
    /// <param name="CustomerID"></param>
    protected void ChangeCustomer(string CustomerID)
    {
        string DDLValue = CustomerID;
        EntityDropDownList ddlUsers = ((EntityDropDownList)FormView1.FindControl("ddlUsers"));
        //Test if Customer DDL has a Customer Selected.
        if (DDLValue != "")
        {
            int CustomerId = Convert.ToInt32(DDLValue);
            //Fill the list
            TList<User> UserList = DataRepository.UserProvider.GetAllModeratorsByCustomerID(CustomerId);

            //Get the Customer info to pre-pop address info
            Customer cust = DataRepository.CustomerProvider.GetById(CustomerId);
            ((TextBox)FormView1.FindControl("dataAddress1")).Text = cust.PrimaryContactAddress1;
            ((TextBox)FormView1.FindControl("dataAddress2")).Text = cust.PrimaryContactAddress2;
            ((TextBox)FormView1.FindControl("dataCity")).Text = cust.PrimaryContactCity;
            ((EntityDropDownList)FormView1.FindControl("dataCountry")).SelectedValue = cust.PrimaryContactCountry;
            ((EntityDropDownList)FormView1.FindControl("dataRegion")).SelectedValue = cust.PrimaryContactRegion;
            ((TextBox)FormView1.FindControl("dataPostalCode")).Text = cust.PrimaryContactPostalCode;

            //Gen Password
            string Password = "";
            DataRepository.UtilProvider.GeneratePassword(ConfigurationManager.AppSettings["WholesalerId"].ToString(),
                CustomerId, null, null, ref Password);
            ((TextBox)FormView1.FindControl("txtPassword")).Text = Password;

            if (UserList.Count != 0)
            {
                //enable the User DDL
                ddlUsers.Enabled = true;

                //Fill this list of Users, but user can still choose to add a new User.
                ddlUsers.Items.Clear();//need to clear everything as NTiers is duplicating the info.
                ddlUsers.DataSource = UserList;
                ddlUsers.DataBind();
                ((Button)FormView1.FindControl("btnCheckUser")).Enabled = true;
            }
            else
            {
                //No users exist so force the Adding of a New User.
                ddlUsers.Enabled = false;
                ((Button)FormView1.FindControl("btnCheckUser")).Enabled = true;
                ((HtmlTable)FormView1.FindControl("TblNewUser")).Visible = true;
                ((Label)FormView1.FindControl("CheckUserMsg")).Visible = false;

            }

        }
        else
        {
            ddlUsers.Enabled = false;
            ((Button)FormView1.FindControl("btnCheckUser")).Enabled = false;
            ((HtmlTable)FormView1.FindControl("TblNewUser")).Visible = true;
            ((Button)FormView1.FindControl("InsertButton")).Enabled = false;
            ((Label)FormView1.FindControl("CheckUserMsg")).Visible = false;

        }
    }

    /// <summary>
    /// If the User List is not set to a vaild User then don't allow the User to Insert.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        string DDLValue = ((EntityDropDownList)FormView1.FindControl("ddlUsers")).SelectedValue;
        if (DDLValue != "")
        {
            //User Selected
            ((HtmlTable)FormView1.FindControl("TblNewUser")).Visible = false;
            ((Button)FormView1.FindControl("InsertButton")).Enabled = true;
        }
        else
        {
            ((HtmlTable)FormView1.FindControl("TblNewUser")).Visible = true;
            ((Label)FormView1.FindControl("CheckUserMsg")).Visible = false;
            ((Button)FormView1.FindControl("InsertButton")).Enabled = false;
        }

    }

    /// <summary>
    /// Add logic when the Add New button is selected to load the same Customer Admin info.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        string CustomerID = ((EntityDropDownList)FormView1.FindControl("dataCustomerId")).SelectedValue;
        string urlParams = string.Format("CustomerId={0}", CustomerID);
        Response.Redirect("ConferenceEdit.aspx?" + urlParams, true);
    }

    protected void cmdSendEmail_Click(object sender, EventArgs e)
    {
        var ModService = new ModeratorService();
        var ModCode = "";
        var PassCode = "";
        int? ModeratorID = null;

        //Get the controls to retrieve info from and to set.
        if (FormView1.CurrentMode == FormViewMode.Edit)
        {
            ModeratorID = Convert.ToInt32(FormView1.DataKey.Value.ToString());
        }
        //int CustomerID = Convert.ToInt32(((EntityDropDownList)FormView1.FindControl("dataCustomerID")).Text);
        TextBox txtModeratorCode = FormView1.FindControl("dataModeratorCode") as TextBox;
        TextBox txtPassCode = FormView1.FindControl("dataPassCode") as TextBox;


    }
}


