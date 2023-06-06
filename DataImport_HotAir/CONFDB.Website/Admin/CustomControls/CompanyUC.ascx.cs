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
using CONFDB.Services;

public partial class CompanyUC : System.Web.UI.UserControl
{
    private TList<Company> CompanyCache = null; //Cache the COmpany List per request as it can be called multiple times

    private string _CompanyID;

    public string CompanyID
    {
        get { return _CompanyID; }
        set { _CompanyID = value; }
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

    public string SelectedValue
    {
        get { return dataCompanyId.SelectedValue; }
        set
        {
            if (dataCompanyId.DataSource == null)
            {
                BindData();
            }
            dataCompanyId.SelectedValue = value;
            CompanyID = value; //keep in sync
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //This is the pattern to use when you have a data source (DS) binding automatically.
        //Basically, the on loading the control on the ascx needs to be set as the DS uses it
        //to load the data. The IsPostBack check is used when the control goes into Edit, etc mode.
        // Since the hidden label control's viewstate is stored, it is used to rebind the control.
        // This is great when you also use the Ajax toolkit.
        if (IsPostBack && CompanyID == null)
        {
            this.CompanyID = this.SelectedValue; //get value from a control with viewstate
        }
        //else
        //{
        //    if (CompanyID != null)
        //    {
        //        this.SelectedValue = this.CompanyID;
        //    }
        //}
        SetPermissions();
    }

    /// <summary>
    /// Used to bind the data for data sources and data controls. If the values are invalid then hide and disable the control.
    /// NOTE: Not used when you have a DataSource (DS) control in the user control and done automatic binding. But left just in
    /// case there is a scenario where you need to force the databinding.
    /// </summary>
    public void BindData()
    {
        //Get the data to show all
        if (CompanyCache == null)
        {
            CompanyCache = DataRepository.CompanyProvider.GetAll();
            CompanyCache.Sort("Description asc");
        }
        dataCompanyId.DataSource = CompanyCache;
        dataCompanyId.DataBind();

        if (Visible && Enabled && CompanyID != null)
        {
            dataCompanyId.SelectedValue = CompanyID; //Set the value here as called by parent
        }
        SetPermissions();
    }

    public void SetPermissions()
    {
        //limit the controls
        dataCompanyId.Visible = this.Visible;
        btnAddNewCompany.Visible = this.Visible;
        dataCompanyId.Enabled = this.Enabled;
        btnAddNewCompany.Enabled = this.Enabled;
    }

    /// <summary>
    /// Adds a new company, refreshes the Company DDL, sets the item to it
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddNewCompany_Click(object sender, EventArgs e)
    {
        bool result;
        //TextBox txtNewCompany = ((TextBox)FormView1.FindControl("txtNewCompany"));
        //EntityDropDownList dataCompanyId = ((EntityDropDownList)FormView1.FindControl("dataCompanyId"));
        //Label lblErrorMessage = ((Label)FormView1.FindControl("lblErrorMessage"));

        //reset error msg
        lblErrorMessage.Text = "";
        lblErrorMessage.Visible = false;

        if (txtNewCompany.Text == "")
        {
            return;
        }

        Company comp = new Company();
        comp.WholesalerId = ConfigurationManager.AppSettings["WholesalerId"].ToString();
        comp.Description = txtNewCompany.Text;
        try
        {
            result = DataRepository.CompanyProvider.Insert(comp);
            if (result)
            {
                CompanyID = comp.Id.ToString();
                //force refresh of Company DDL control and set the value
                BindData();
                txtNewCompany.Text = ""; //reset
            }
            else
            {
                //must have error, probably already exists
                lblErrorMessage.Text = "Error: Company already exists.";
                lblErrorMessage.Visible = true;
            }

        }
        catch (Exception ex)
        {
            //must have error, probably already exists
            lblErrorMessage.Text = "Error: Company already exists.";
            lblErrorMessage.Visible = true;
        }

    }
}
