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

public partial class ProductRatesCustomer : System.Web.UI.UserControl
{
    private string _sort = "";
    private string _filter = "";
    private string _CustomerID;
    private UserSession us = new UserSession();

    public string CustomerID
    {
        get { return _CustomerID; }
        set { _CustomerID = value; }
    }

    string WholesalerID = ConfigurationManager.AppSettings["WholesalerID"].ToString();

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
        if (!IsPostBack)
        {
            Wholesaler_ProductService wps = new Wholesaler_ProductService();
            int totalCount;
            var ds = wps.GetPaged(string.Format("WholesalerID='{0}'", WholesalerID), "DisplayOrder", 0, 50, out totalCount);
            ddlFilterProductName.DataSource = ds;
            ddlFilterProductName.DataBind();
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
            DataSet dsCS = custService.GetProductRates(Convert.ToInt32(CustomerID));
            //Filter the list based ProductRateTypeDisplayName
            DataView dv = dsCS.Tables[0].DefaultView;
            //Set the filter if one is required, placed here as it needs to be called during paging
            SetFilter();
            dv.RowFilter = _filter;
            if (Session["ProductRatesCustomer_Sort"] != null)
            {
                dv.Sort = Session["ProductRatesCustomer_Sort"].ToString();
            }
            
            GridViewProductRateValue.DataSource = dv;
            GridViewProductRateValue.RecordsCount = dv.Count; //dsCS.Tables[0].Rows.Count;
            GridViewProductRateValue.PageSize = GridViewProductRateValue.PageSize; //does this get the value from Designer view?
            GridViewProductRateValue.PageIndex = GridViewProductRateValue.PageIndex;
            GridViewProductRateValue.DataBind(); //Bind everything.
        }
        else //not valid so disable control
        {
            Visible = false;
            Enabled = false;
            GridViewProductRateValue.Visible = Visible;
            GridViewProductRateValue.Enabled = Enabled;
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
        if (!us.IsAuthenicated)
        {
            us.LogOff();//stops all process and logs user out
        }

        //Sales Agents and less can't add or update
        if (us.UserLevel <= 50)
        {
            //Remove Save Column
            GridViewProductRateValue.Columns[0].Visible = false;
            GridViewProductRateValue.Enabled = true;
        }
        else
        {
            GridViewProductRateValue.Enabled = true;
        }
    }

    /// <summary>
    /// Save the Product rate for the Customer when they press Save. This piggybacks on the "Select" command of the GridView object.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewProductRateValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _ProductRateValueID = Convert.ToInt32(GridViewProductRateValue.SelectedDataKey.Value);
        decimal _SellRate = Convert.ToDecimal(((TextBox)GridViewProductRateValue.SelectedRow.FindControl("txtSellRate")).Text);
        try
        {
            ProductRateValueService prvService = new ProductRateValueService();
            ProductRateValue eProductRateValue = prvService.GetById(_ProductRateValueID);
            eProductRateValue.SellRate = _SellRate;
            prvService.Update(eProductRateValue);
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    //Paging thru items
    protected void GridViewProductRateValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewProductRateValue.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void GridViewProductRateValue_PageSizeChanged(object sender, EventArgs e)
    {
        BindData();
    }

    protected void ddlFilterProdRateTypeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set the filter and call BindData()
        BindData();
    }

    protected void ddlFilterProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set the filter and call BindData()
        BindData();
    }

    //Set the filter
    protected void SetFilter()
    {
        try
        {
            //If both are ALL then clear everything and return
            if (ddlFilterProdRateTypeName.SelectedItem.Text == "All" && ddlFilterProductName.SelectedItem.Text == "All") //Special case added to DDL
            {
                _filter = ""; //clear to show all
                _sort = ""; //clear to show default sort
                return;
            }

            string productRateTypeFilter = "";
            string productFilter = "";

            if (ddlFilterProdRateTypeName.SelectedItem.Text != "All") //Special case added to DDL
            {
                productRateTypeFilter = string.Format("ProductRateTypeDisplayName = '{0}'", ddlFilterProdRateTypeName.SelectedItem.Text);
            }

            if (ddlFilterProductName.SelectedItem.Text != "All") //Special case added to DDL
            {
                productFilter = string.Format("Wholesaler_ProductName = '{0}'", ddlFilterProductName.SelectedItem.Text);
            }

            if (!string.IsNullOrEmpty(productFilter) && !string.IsNullOrEmpty(productRateTypeFilter))
            {
                _filter = string.Format("{0} AND {1}", productFilter, productRateTypeFilter);
            }
            else
            {
                //Concatenate as one will be empty
                _filter = string.Format("{0}{1}", productFilter, productRateTypeFilter);
            }
        }
        catch (Exception)
        {
            _filter = "";
        }

    }

    protected void GridViewProductRateValue_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            if (Session["ProductRatesCustomer_Sort"] != null)
            {
                _sort = Session["ProductRatesCustomer_Sort"].ToString();
            }
            if (string.IsNullOrEmpty(_sort))
            {
                _sort = "ProductRateDisplayName asc";
            }
            else if (_sort.IndexOf("asc", StringComparison.InvariantCultureIgnoreCase) > 0) //asc so change to desc
            {
                _sort = "ProductRateDisplayName desc";
            }
            else if (_sort.IndexOf("desc", StringComparison.InvariantCultureIgnoreCase) > 0) //desc so change to asc
            {
                _sort = "ProductRateDisplayName asc";
            }
        }
        catch (Exception)
        {
            _sort = "";
        }
        Session["ProductRatesCustomer_Sort"] = _sort.ToString();
        BindData();
    }
}
