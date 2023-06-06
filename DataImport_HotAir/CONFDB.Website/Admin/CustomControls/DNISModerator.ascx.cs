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

public partial class DNISModerator : System.Web.UI.UserControl
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
    /// </summary>
    public void BindData()
    {
        if (Visible && Enabled && ModeratorID != null)
        {
            lblModeratorID.Text = ModeratorID;
            DnisDataSourceModerator.Sort = "DnisTypeId, DisplayOrder";
            GridViewDnisModerator.DataBind(); //Bind everything.
        }
        else //not valid so disable control
        {
            Visible = false;
            Enabled = false;
            GridViewDnisModerator.Visible = Visible;
            GridViewDnisModerator.Enabled = Enabled;
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
            GridViewDnisModerator.Enabled = false;
        }
        else
        {
            GridViewDnisModerator.Enabled = true;
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
    /// Save the DNIS info for the Moderator when press the Save press. This piggybacks on the "Select" command of the GridView object.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewDnisModerator_SelectedIndexChanged(object sender, EventArgs e)
    {
        string DNISID = ((DropDownList)GridViewDnisModerator.SelectedRow.FindControl("ddlDNIS")).SelectedItem.Value;
        string DNISTypeID = ((Label)GridViewDnisModerator.SelectedRow.FindControl("lblDNISTypeID")).Text;

        //setting the moderator id for the control, get from hidden control
        this.ModeratorID = lblModeratorID.Text;

        try
        {
            ModeratorService ModService = new ModeratorService();
            ModService.UpdateDNIS(Convert.ToInt32(ModeratorID), Convert.ToInt32(DNISID), Convert.ToInt32(DNISTypeID));
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}
