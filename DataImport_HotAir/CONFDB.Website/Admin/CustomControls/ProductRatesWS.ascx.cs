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
using System.Data.SqlClient;

public partial class ProductRatesWS : System.Web.UI.UserControl
{
    private string _sort = "";
    private string _filter = "";
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
        if (Visible && Enabled && WholesalerID != null)
        {
            lblWholesalerID.Text = WholesalerID; //Set the value here as called by parent
            WholesalerService WSService = new WholesalerService();
            DataSet dsWS = WSService.GetProductRates(WholesalerID);
            //Filter the list based ProductRateTypeDisplayName
            DataView dv = dsWS.Tables[0].DefaultView;
            //Set the filter if one is required, placed here as it needs to be called during paging
            SetFilter();
            dv.RowFilter = _filter;
            if (Session["ProductRatesWS_Sort"] != null)
            {
                dv.Sort = Session["ProductRatesWS_Sort"].ToString();
            }

            GridViewProductRateValue.DataSource = dv;
            GridViewProductRateValue.RecordsCount = dv.Count;
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

    }

    /// <summary>
    /// Save the Product rate for the Wholesaler when they press Save. This piggybacks on the "Select" command of the GridView object.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridViewProductRateValue_SelectedIndexChanged(object sender, EventArgs e)
    {
        int _ProductRateValueID = Convert.ToInt32(GridViewProductRateValue.SelectedDataKey.Value);
        decimal _SellRate = Convert.ToDecimal(((TextBox)GridViewProductRateValue.SelectedRow.FindControl("txtSellRate")).Text);
        decimal _BuyRate = Convert.ToDecimal(((TextBox)GridViewProductRateValue.SelectedRow.FindControl("txtBuyRate")).Text);
        //Used with Bulk edit to push the rates down.
        int _ProductRateID = Convert.ToInt32(((Label)GridViewProductRateValue.SelectedRow.FindControl("lblProductRateID")).Text);
        bool PushSellRates = ((CheckBox)GridViewProductRateValue.SelectedRow.FindControl("chkPushSellRates")).Checked;
        bool PushBuyRates = ((CheckBox)GridViewProductRateValue.SelectedRow.FindControl("chkPushBuyRates")).Checked;
        //reset the value
        ((CheckBox)GridViewProductRateValue.SelectedRow.FindControl("chkPushSellRates")).Checked = false;
        ((CheckBox)GridViewProductRateValue.SelectedRow.FindControl("chkPushBuyRates")).Checked = false;
        //MOD: Sept/2013 - Get the currencies, these are bound columns so using position
        string _SellRateCurrency = GridViewProductRateValue.SelectedRow.Cells[7].Text;
        string _BuyRateCurrency = GridViewProductRateValue.SelectedRow.Cells[9].Text;

        try
        {
            //If the rates don't need to be Push Down then just update the Wholesaler
            if (PushSellRates == false && PushBuyRates == false)
            {
                ProductRateValueService prvService = new ProductRateValueService();
                ProductRateValue eProductRateValue = prvService.GetById(_ProductRateValueID);
                eProductRateValue.SellRate = _SellRate;
                eProductRateValue.BuyRate = _BuyRate;
                prvService.Update(eProductRateValue);
                return;
            }
            ////Use Bulk Edit functions to update rates
            ////- @BulkEditType - 1 = All Customers, 2 = Wholesaler Only, 3 = Wholesaler and All Customers
            //UtilService Util = new UtilService();
            if (PushSellRates)
            {
                //Util.BulkEditProductRates(_ProductRateID, _SellRate, 3, null, null, null, WholesalerID);
                ///DEV NOTE: Seems to be an issue with NetTiers where the Command Timeout is not being honoured or an issue with their SQL 2005 server.
                /// Either way, Going to ADO.NET transaction method to get the job done.
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CONFDB.Data.ConnectionString"].ToString()))
                {
                    connection.Open();
                    // Start a local transaction.
                    SqlTransaction sqlTran = connection.BeginTransaction();

                    // Enlist a command in the current transaction.
                    SqlCommand command = new SqlCommand("p_UTIL_BulkEditProductRates", connection);
                    command.CommandTimeout = 300; //300 secs
                    try
                    {
                        command.Transaction = sqlTran;
                        command.CommandType = CommandType.StoredProcedure;
                        // 3. add parameter to command, which
                        //    will be passed to the stored procedure
                        command.Parameters.Add(new SqlParameter("@ProductRateID", _ProductRateID));
                        command.Parameters.Add(new SqlParameter("@SellRate", _SellRate));
                        command.Parameters.Add(new SqlParameter("@BulkEditType", 3));
                        command.Parameters.Add(new SqlParameter("@CustomerID", null));
                        command.Parameters.Add(new SqlParameter("@CompanyID", null));
                        command.Parameters.Add(new SqlParameter("@SalesPersonID", null));
                        command.Parameters.Add(new SqlParameter("@WholesalerID", WholesalerID));
                        command.Parameters.Add(new SqlParameter("@CurrencyID", _SellRateCurrency));
                        command.ExecuteNonQuery();

                        // Commit the transaction.
                        sqlTran.Commit();
                        ////Things are good
                        //lblExecuteBillingRun.Text = "Done.";
                        //lblExecuteBillingRun.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if the transaction fails to commit.
                        string ErrorMessage = ex.Message;
                        try
                        {
                            // Attempt to roll back the transaction.
                            sqlTran.Rollback();
                        }
                        catch (Exception exRollback)
                        {
                            // Throws an InvalidOperationException if the connection 
                            // is closed or the transaction has already been rolled 
                            // back on the server.
                            ErrorMessage += "<BR/>" + exRollback.Message;
                        }
                        throw new Exception(ErrorMessage);
                    }
                }
            }

            if (PushBuyRates)
            {
                //Util.BulkEditWSProductRates(_ProductRateID, _BuyRate, 3, null, null, null, WholesalerID);
                ///DEV NOTE: Seems to be an issue with NetTiers where the Command Timeout is not being honoured or an issue with their SQL 2005 server.
                /// Either way, Going to ADO.NET transaction method to get the job done.
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CONFDB.Data.ConnectionString"].ToString()))
                {
                    connection.Open();
                    // Start a local transaction.
                    SqlTransaction sqlTran = connection.BeginTransaction();

                    // Enlist a command in the current transaction.
                    SqlCommand command = new SqlCommand("p_UTIL_BulkEditWSProductRates", connection);
                    command.CommandTimeout = 300; //300 secs
                    try
                    {
                        command.Transaction = sqlTran;
                        command.CommandType = CommandType.StoredProcedure;
                        // 3. add parameter to command, which
                        //    will be passed to the stored procedure
                        command.Parameters.Add(new SqlParameter("@ProductRateID", _ProductRateID));
                        command.Parameters.Add(new SqlParameter("@BuyRate", _BuyRate));
                        command.Parameters.Add(new SqlParameter("@BulkEditType", 3));
                        command.Parameters.Add(new SqlParameter("@CustomerID", null));
                        command.Parameters.Add(new SqlParameter("@CompanyID", null));
                        command.Parameters.Add(new SqlParameter("@SalesPersonID", null));
                        command.Parameters.Add(new SqlParameter("@WholesalerID", WholesalerID));
                        command.Parameters.Add(new SqlParameter("@CurrencyID", _BuyRateCurrency));
                        command.ExecuteNonQuery();

                        // Commit the transaction.
                        sqlTran.Commit();
                        ////Things are good
                        //lblExecuteBillingRun.Text = "Done.";
                        //lblExecuteBillingRun.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception if the transaction fails to commit.
                        string ErrorMessage = ex.Message;
                        try
                        {
                            // Attempt to roll back the transaction.
                            sqlTran.Rollback();
                        }
                        catch (Exception exRollback)
                        {
                            // Throws an InvalidOperationException if the connection 
                            // is closed or the transaction has already been rolled 
                            // back on the server.
                            ErrorMessage += "<BR/>" + exRollback.Message;
                        }
                        throw new Exception(ErrorMessage);
                    }
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    //Paging thru items. need to impl. as no DataSource control is used.
    protected void GridViewProductRateValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewProductRateValue.PageIndex = e.NewPageIndex;
        BindData();
    }
    //Page Size change. need to impl. as no DataSource control is used.
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
            if (Session["ProductRatesWS_Sort"] != null)
            {
                _sort = Session["ProductRatesWS_Sort"].ToString();
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
        Session["ProductRatesWS_Sort"] = _sort.ToString();
        BindData();
    }

}
