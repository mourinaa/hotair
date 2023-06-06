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

public partial class FeaturesCustomer : System.Web.UI.UserControl
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
        if (IsPostBack && CustomerID == null)
        {
            this.CustomerID = lblCustomerID.Text;
        }
    }

    /// <summary>
    /// Used to bind the data for data sources and data controls. If the values are invalid then hide and disable the control.
    /// </summary>
    public void BindData()
    {
        if (Visible && Enabled && CustomerID != null)
        {
            lblCustomerID.Text = CustomerID; //Set the value here as called by parent
            CustomerService custService = new CustomerService();
            DataSet dsCS = custService.GetProductFeatures(Convert.ToInt32(CustomerID));
            GridViewFeature.DataSource = dsCS;
            //Used for Paging as we aren't using the Typed DataSource so we need to filling the information
            GridViewFeature.RecordsCount = dsCS.Tables[0].Rows.Count;
            GridViewFeature.PageSize = GridViewFeature.PageSize; //does this get the value from Designer view?
            GridViewFeature.PageIndex = GridViewFeature.PageIndex;
            GridViewFeature.DataBind(); //Bind everything.
        }
        else //not valid so disable control
        {
            Visible = false;
            Enabled = false;
            GridViewFeature.Visible = Visible;
            GridViewFeature.Enabled = Enabled;
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
            GridViewFeature.Enabled = false;
        }
        else
        {
            GridViewFeature.Enabled = true;
        }
    }

    /// <summary>
    /// Returns the list of Feature Options for the give feature.
    /// </summary>
    /// <param name="FeatureID"></param>
    /// <returns>DataSet</returns>
    protected DataSet GetFeatureOptionByFeatureID(string FeatureID)
    {
        FeatureOptionService foService = new FeatureOptionService();
        //JS: Fix - Feature Option sorting
        TList<FeatureOption> featureList = foService.GetByFeatureId(Convert.ToInt32(FeatureID));
        featureList.Sort("DisplayOrder ASC");
        return featureList.ToDataSet(false);
    }
    
    /// <summary>
    /// Save the Customer_Feature Option for the Customer when they press Save. This piggybacks on the "Select" command of the GridView object.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewFeature_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _FeatureID = Convert.ToInt32(((Label)GridViewFeature.SelectedRow.FindControl("lblFeatureID")).Text);
        int _FeatureOptionID = Convert.ToInt32(((DropDownList)GridViewFeature.SelectedRow.FindControl("ddlFeatureOption")).SelectedValue);
        string _FeatureOptionValue = null; //not used currently
        bool UpdateModerators = ((CheckBox)GridViewFeature.SelectedRow.FindControl("chkUpdateModerators")).Checked;
        //reset the value
        ((CheckBox)GridViewFeature.SelectedRow.FindControl("chkUpdateModerators")).Checked = false;

        try
        {
            CustomerService CustService = new CustomerService();
            CustService.UpdateFeature(Convert.ToInt32(CustomerID), _FeatureID, _FeatureOptionID,_FeatureOptionValue, UpdateModerators);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    //Paging thru items
    protected void GridViewFeature_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewFeature.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GridViewFeature_PageSizeChanged(object sender, EventArgs e)
    {
        BindData();

    }
}
