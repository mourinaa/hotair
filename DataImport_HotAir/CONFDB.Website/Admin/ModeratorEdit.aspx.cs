
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
using CONFDB.Data;
using CONFDB.Entities;
using CONFDB.Web.UI;
using CONFDB.Services;
#endregion

public partial class ModeratorEdit : System.Web.UI.Page
{
    int UserId = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        FormUtil.RedirectAfterInsertUpdate(FormView1, "ModeratorEdit.aspx?{0}", UserDataSource);
        FormUtil.RedirectAfterAddNew(FormView1, "ModeratorEdit.aspx");
        FormUtil.RedirectAfterCancel(FormView1, "Moderator.aspx");
        FormUtil.SetDefaultMode(FormView1, "UserId");
        UserId = Convert.ToInt32(FormUtil.GetRequestParameter("UserId", "-1"));

        if (!Page.IsPostBack)
        {
            BindData();
        }
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
        }
        else
        {
            ((Button)FormView1.FindControl("InsertButton")).Enabled = true;
            ((Button)FormView1.FindControl("UpdateButton")).Enabled = true;
        }

        //If the Customer is disabled then disable the buttons.
        //Get CustomerId from Moderator using the UserId
        TList<Moderator> modList = DataRepository.ModeratorProvider.GetByUserId(UserId);
        if (modList != null)
        {
            int customerID = modList[0].CustomerId;
            //Get the Customer info to pre-pop address info
            CONFDB.Entities.Customer cust = DataRepository.CustomerProvider.GetById(customerID);
            if (!cust.Enabled.Value)
            {
                ((Button)FormView1.FindControl("InsertButton")).Enabled = false;
                ((Button)FormView1.FindControl("UpdateButton")).Enabled = false;
            }
            else
            {
                ((Button)FormView1.FindControl("InsertButton")).Enabled = true;
                ((Button)FormView1.FindControl("UpdateButton")).Enabled = true;
            }
        }
    }

    protected void GridViewConference_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewConference.SelectedDataKey.Values[0]);
        Response.Redirect("ConferenceEdit.aspx?" + urlParams, true);
    }

    void BindData()
    {
        //Fill the databound controls
        if (UserId != -1)
        {
            //Get CustomerId from Moderator using the UserId
            TList<Moderator> modList = DataRepository.ModeratorProvider.GetByUserId(UserId);
            if (modList != null)
            {
                //Get CustomerId from Moderator using the UserId
                string customerID = modList[0].CustomerId.ToString();

                lnkCustomerId.NavigateUrl = string.Format("~/Admin/CustomerEdit.aspx?Id={0}", customerID);
                VList<Vw_CustomerList> custList = DataRepository.Vw_CustomerListProvider.Get("Id = " + customerID, "");
                lblDDLDescription.Text = custList[0].DdlDescription;
            }
        }
    }

    /// <summary>
    /// After updating, copy the Login name to the Email as for Moderators it should be the same.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void UserDataSource_AfterUpdated(object sender, CONFDB.Web.Data.LinkedDataSourceEventArgs e)
    {
        UserService us = new UserService();
        User user = us.GetByUserId(UserId);
        user.Email = user.Username;
        us.Save(user);
        //BindData();
    }

    /// <summary>
    /// Add a new Marketing Service and refresh Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddMarketingService_Click(object sender, EventArgs e)
    {
        UserSession us = new UserSession(); //used to track name of user that added the item
        User_MarketingService userMarketing = new User_MarketingService();

        userMarketing.UserId = UserId;
        userMarketing.MarketingServiceId = Convert.ToInt32(dataMarketingServiceId.SelectedValue);
        userMarketing.CreatedDate = DateTime.Now;
        userMarketing.LastModified = DateTime.Now;
        userMarketing.LastModifiedBy = us.LoginName;
        try
        {
            if (DataRepository.User_MarketingServiceProvider.Insert(userMarketing))
            {
                GridViewMarketingService.DataBind();
            }
        }
        catch (Exception ex)
        {
            //Do nothing
            //can't add duplicates so ignore error
            //throw ex;

        }
    }
}


