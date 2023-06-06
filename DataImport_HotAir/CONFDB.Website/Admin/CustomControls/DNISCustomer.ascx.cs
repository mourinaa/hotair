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

public partial class DNISCustomer : System.Web.UI.UserControl
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
    /// </summary>
    public void BindData()
    {
        if (Visible && Enabled && CustomerID != null)
        {
            lblCustomerID.Text = CustomerID;
            DnisDataSourceCustomer.Sort = "DnisTypeId, DisplayOrder";
            GridViewDnisCustomer.DataBind(); //Bind everything.
        }
        else //not valid so disable control
        {
            Visible = false;
            Enabled = false;
            GridViewDnisCustomer.Visible = Visible;
            GridViewDnisCustomer.Enabled = Enabled;
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
            GridViewDnisCustomer.Enabled = false;
        }
        else
        {
            GridViewDnisCustomer.Enabled = true;
        }
    }

   /// <summary>
   /// Get the DNIS Information with the custom field.
   /// </summary>
   /// <param name="DNISTypeID"></param>
   /// <returns></returns>
    public DataSet GetDNISByDNISTypeID(string DNISTypeID)
    {
        DnisService _dnisService = new DnisService();
        return _dnisService.GetByWholesalerIdDDL(ConfigurationManager.AppSettings["WholesalerID"], Convert.ToInt32(DNISTypeID));
    }

    /// <summary>
    /// Save the DNIS info for the Customer when they press Save. This piggybacks on the "Select" command of the GridView object.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewDnisCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        string DNISID = ((DropDownList)GridViewDnisCustomer.SelectedRow.FindControl("ddlDNIS")).SelectedItem.Value;
        string DNISTypeID = ((Label)GridViewDnisCustomer.SelectedRow.FindControl("lblDNISTypeID")).Text;
        bool UpdateModerators = ((CheckBox)GridViewDnisCustomer.SelectedRow.FindControl("chkUpdateModerators")).Checked;
        //reset the value
        ((CheckBox)GridViewDnisCustomer.SelectedRow.FindControl("chkUpdateModerators")).Checked = false;
        this.CustomerID = lblCustomerID.Text;
        try
        {
            CustomerService CustService = new CustomerService();
            CustService.UpdateDNIS(Convert.ToInt32(CustomerID), Convert.ToInt32(DNISID), Convert.ToInt32(DNISTypeID),UpdateModerators);

        }
        catch (Exception ex)
        {

            throw ex;
        }
   
    }
}
