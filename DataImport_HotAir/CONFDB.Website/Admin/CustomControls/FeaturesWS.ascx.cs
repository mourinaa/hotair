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

public partial class FeaturesWS : System.Web.UI.UserControl
{
    private string _WholesalerID;

    public string WholesalerID
    {
        get { return _WholesalerID; }
        set { _WholesalerID = value; }
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
        if (IsPostBack && WholesalerID == null)
        {
            this.WholesalerID = lblWholesalerID.Text;
        }
    }

    /// <summary>
    /// Used to bind the data for data sources and data controls. If the values are invalid then hide and disable the control.
    /// </summary>
    public void BindData()
    {
        if (Visible && Enabled && WholesalerID != null)
        {
            lblWholesalerID.Text = WholesalerID; //Set the value here as called by parent
            WholesalerService wsService = new WholesalerService();
            DataSet dsWS = wsService.GetProductFeatures(WholesalerID);
            GridViewFeature.DataSource = dsWS;
            //Used for Paging
            GridViewFeature.RecordsCount = dsWS.Tables[0].Rows.Count;
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
    /// Save the Wholesaler_Product_Feature Option for the Wholesaler when they press Save. This piggybacks on the "Select" command of the GridView object.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewFeature_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _Wholesaler_Proudct_FeatureID = Convert.ToInt32(GridViewFeature.SelectedDataKey.Value);
        //int _FeatureID = Convert.ToInt32(((Label)GridViewFeature.SelectedRow.FindControl("lblFeatureID")).Text);
        int _FeatureOptionID = Convert.ToInt32(((DropDownList)GridViewFeature.SelectedRow.FindControl("ddlFeatureOption")).SelectedValue);
        string _FeatureOptionValue = null; //not used currently
        //bool UpdateCustomers = ((CheckBox)GridViewFeature.SelectedRow.FindControl("chkUpdateCustomers")).Checked;
        //bool UpdateModerators = ((CheckBox)GridViewFeature.SelectedRow.FindControl("chkUpdateModerators")).Checked;
        ////reset the value
        //((CheckBox)GridViewFeature.SelectedRow.FindControl("chkUpdateCustomers")).Checked = false;
        //((CheckBox)GridViewFeature.SelectedRow.FindControl("chkUpdateModerators")).Checked = false;

        try
        {
            Wholesaler_Product_FeatureService wpfService = new Wholesaler_Product_FeatureService();
            //Get the Entity, update it, then save it back.
            Wholesaler_Product_Feature eWPF = wpfService.GetById(_Wholesaler_Proudct_FeatureID);
            eWPF.FeatureOptionId = _FeatureOptionID;
            wpfService.Update(eWPF);
            
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
