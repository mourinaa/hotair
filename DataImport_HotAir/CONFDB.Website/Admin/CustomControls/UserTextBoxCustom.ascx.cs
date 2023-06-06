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
using CONFDB.Web.UI;
//NOTE2: Couldn't get this to work inside of the FormView control so had to put the code in the FormView on the Page. Left the code
// in case I could use it some where else.

public partial class UserTextBoxCustom : System.Web.UI.UserControl
{
    private string _UserName;

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    private string _Password;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Need to load the control from State info
        if (IsPostBack)
        {
            this.UserName = txtUserName.Text;
            this.Password = txtPassword.Text;
        }
        else
        {
            txtUserName.Text = this.UserName;
            txtPassword.Text = this.Password;
        }

    }

    /// <summary>
    /// Used to handle the Ajax check of the User Info when first created.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCheckUser_Click(object sender, EventArgs e)
    {
        //reset error messages.
        lblInvalidUserName.Visible = false;
        lblInvalidPassword.Visible = false;

        //Hack: Regardless of the UpdatePanel the UC inside the FormView does a full page refresh so 
        // set the focus to the Check User button to make it a bit more seemless.
        // THIS IS BY DESIGN WHEN USING DATASOURCE CONTROLS. SEE: 
        // http://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=292398
        FormUtil.SetDefaultFocus(btnCheckUser);
        //Check if the UserName is unique and Password is not less then 8 characters
        _UserName = txtUserName.Text;
        _Password = txtPassword.Text;

        try
        {
            UserGridCustom ucUserGridCustom = new UserGridCustom();

            //reset the insert button to make sure they can't insert the record, sinces its a UC, then look to the Parent for the FormView.
            Button _InsertButton = ((Button)FormUtil.FindControl(this.Parent, "InsertButton"));
            _InsertButton.Enabled = false; 

            if (!ucUserGridCustom.IsValidUserName(_UserName, null)) //New user so there will be no UserID
            {
                //Show some error message.
                lblInvalidUserName.Visible = true;
                //Make sure they can't insert the record
                return;
            }

            if (!ucUserGridCustom.IsValidPassword(_Password))
            {
                //Show some error message.
                lblInvalidPassword.Visible = true;
                //Make sure they can't insert the record
                return;
            }
            //Make sure they can insert the record
            _InsertButton.Enabled = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}
