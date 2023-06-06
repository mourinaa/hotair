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

public partial class UserGridCustom : System.Web.UI.UserControl
{
    private string _UserID;

    public string UserID
    {
        get { return _UserID; }
        set { _UserID = value; }
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
        //This is the pattern to use when you have a data source (DS) binding automatically.
        //Basically, the on loading the control on the ascx needs to be set as the DS uses it
        //to load the data. The IsPostBack check is used when the control goes into Edit, etc mode.
        // Since the hidden label control's viewstate is stored, it is used to rebind the control.
        // This is great when you also use the Ajax toolkit.
        if (IsPostBack && UserID == null)
        {
            this.UserID = lblUserID.Text;
        }
        else
        {
            lblUserID.Text = this.UserID;
        }
        SetPermissions();
    }

    /// <summary>
    /// Used to bind the data for data sources and data controls. If the values are invalid then hide and disable the control.
    /// NOTE: Not used when you have a DataSource (DS) control in the user control and done automatic binding. But left just in
    /// case there is a scenario where you need to force the databinding.
    /// </summary>
    public void BindData()
    {
        if (Visible && Enabled && UserID != null)
        {
            lblUserID.Text = UserID; //Set the value here as called by parent
            GridViewUser.DataBind(); //Bind everything.
        }
        else //not valid so disable control
        {
            Visible = false;
            Enabled = false;
            GridViewUser.Visible = Visible;
            GridViewUser.Enabled = Enabled;
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
            GridViewUser.Enabled = false;
        }
        else
        {
            GridViewUser.Enabled = true;
        }
    }

    /// <summary>
    /// Checks if the UserName is valid. Optionally, a UserID can be passed in to make sure that the UserName
    /// is belongs to the same UserID. If null is passed in for the UserID then the unique check is done just
    /// on the UserName value.
    /// </summary>
    /// <param name="UserName">The unique UserName.</param>
    /// <param name="UserID">Either the UserID associated with the User, or null.</param>
    /// <returns></returns>
    public bool IsValidUserName(string UserName,int? UserID)
    {
        //Check that UserName is unique in the system and its valid.
        if (UserName.Length > 0)
        {
            UserService uService = new UserService();
            User eUser = uService.GetByUsername(UserName); //check for the UserName

            if (eUser == null)
            {
                //User name is unique no more checks required.
                return true;
            }

            //Take UserID into account when checking, if not then someone has this username so its not valid.
            if (UserID != null)
            {
                //check if the UserIDs match, if so then everythings ok. 
                    //NOTE: This for scenarios were the check is done but it is for the same existing user. 
                    //This usually happens because the higher level component can't tell if the UserName 
                    //value was changed so it is checked to be safe.
                if (eUser.UserId == UserID)
                {
                    return true;
                }
            }
        }
        //UserName is taken or invalid so return false.
        return false;
    }
    /// <summary>
    /// Checks the Password for validity. Currently is only a length check but could be changed to do more like password strength checks.
    /// </summary>
    /// <param name="Password"></param>
    /// <returns></returns>
    public bool IsValidPassword(string Password)
    {
        //REMOVE min. 8 char check for Customer: Requested By JD Aug/2010
        ////Double check password in case javascript or something is turned off.
        //if (Password.Length < 8)
        //{
        //    return false;
        //}
        if (!(string.IsNullOrEmpty(Password)))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// When Updating in the Grid UserControl, Check that the User Name is unique and Password valid
    /// before allowing update else show the error message.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Get the row info to simplify the access
        GridViewRow gvr = GridViewUser.Rows[e.RowIndex];

        //reset error messages.
        ((Label)gvr.FindControl("lblInvalidUserName")).Visible = false;
        ((Label)gvr.FindControl("lblInvalidPassword")).Visible = false;

        //Check if the UserName is unique and Password is not less then 8 characters
        string _UserName = ((TextBox)gvr.FindControl("txtUserName")).Text;
        string _Password = ((TextBox)gvr.FindControl("txtPassword")).Text;

        try
        {
            if (!this.IsValidUserName(_UserName, Convert.ToInt32(UserID))) //Existing user so back in the UserID
            {
                //Show some error message.
                ((Label)gvr.FindControl("lblInvalidUserName")).Visible = true;
                //Make sure they can't insert the record
                e.Cancel = true;
                return;
            }

            if (!this.IsValidPassword(_Password))
            {
                //Show some error message.
                ((Label)gvr.FindControl("lblInvalidPassword")).Visible = true;
                //Make sure they can't insert the record
                e.Cancel = true;
                return;
            }
            //Make sure they can update the record
            e.Cancel = false;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}
