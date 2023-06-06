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
using CONFDB.Services;
using CONFDB.Entities;
using CONFDB.Web.UI;

public partial class PostMiscellaneousCharges : System.Web.UI.Page
{
    //set global items
    string WholesalerID = ConfigurationManager.AppSettings["WholesalerID"];
    string CustomerID;
    bool DisplayPrimaryNumbers;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide the list of Customer Transaction until a Customer Admin is selected
        gvCustomerTransactions.Visible = false;
        //set globals
        DisplayPrimaryNumbers = chkDisplayByPrimaryNumber.Checked;
        if (DisplayPrimaryNumbers)
        {
            CustomerID = dataCustomerId2.SelectedValue;
        }
        else
        {
            CustomerID = dataCustomerId.SelectedValue;
        }
        if (!Page.IsPostBack)
        {
            //set the Quantity
            numQuantity.Text = "1";
        }
    }

    /// <summary>
    /// Update the Customer information displayed.
    /// </summary>
    protected void RefreshCustomer()
    {
        //If value is invalid, or first item in the list
        if (string.IsNullOrEmpty(CustomerID))
        {
            lblCurrentBalance.Text = "";
            dataConferenceList.Items.Clear();
            dataConferenceList.Enabled = false;
            dataConferenceCallList.Items.Clear();
            dataConferenceCallList.Enabled = false;
            lblCurrentBalance.Text = "";
            txtTransactionDate.Text = "";
            txtRetailAmount.Text = "";
            txtWSAmount.Text = "";
            txtDescription.Text = "";
            gvCustomerTransactions.Visible = false;
        }
        else
        {
            //Enable the control but if there is an error then the control will be disabled
            dataConferenceList.Enabled = true;
            RefreshConferenceList(CustomerID);
            //Get the Customers Balance, return 0.00 if there's an error
            RefreshCustomersBalance(WholesalerID, CustomerID);
            //Enable the control but if there is an error then the control will be disabled
            gvCustomerTransactions.Visible = true;
            RefreshCustomerTransactions(CustomerID);
            //Refresh the Miscellaneous Product Rate Types
            RefreshMiscProductRateTypes(CustomerID);
        }
    }

    protected void ClearAllControls()
    {
        lblCurrentBalance.Text = "";
        dataConferenceList.Items.Clear();
        dataConferenceList.Enabled = false;
        dataConferenceCallList.Items.Clear();
        dataConferenceCallList.Enabled = false;
        lblCurrentBalance.Text = "";
        txtTransactionDate.Text = "";
        numQuantity.Text = "1";
        txtRetailAmount.Text = "";
        txtWSAmount.Text = "";
        txtDescription.Text = "";
        gvCustomerTransactions.Visible = false;
    }

    /// <summary>
    /// Fills the Company List by Primary Number. The default is by Company Name
    /// if there is an error.
    /// </summary>
    /// <param name="ModeratorID"></param>
    protected void FillCompanyListByPrimaryNumber()
    {
        try
        {
            string WhereClause = string.Format("WholesalerID={0}", WholesalerID);
            //Fill the Company DropDown
            VList<Vw_CustomerList> CompanyList = DataRepository.Vw_CustomerListProvider.Get(WhereClause, "PriCustomerNumber,CompanyName");
            dataCustomerId2.Items.Clear();
            dataCustomerId2.DataSource = CompanyList;
            dataCustomerId2.DataBind();

            ListItem listItem;
            //Add the first item as this is an optional list
            listItem = new ListItem("< Please Choose ...>", "");
            dataCustomerId2.Items.Insert(0, listItem);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Fills the Moderator/Conference list by combining several columns of information. Disables itself
    /// if there is an error.
    /// </summary>
    /// <param name="CustomerID"></param>
    protected void RefreshConferenceList(string CustomerID)
    {
        try
        {
            string WhereClause = string.Format("CustomerID={0}", CustomerID);
            //Fill the Moderator/Conference DropDown
            VList<Vw_ConferenceList> ConferenceList = DataRepository.Vw_ConferenceListProvider.Get(WhereClause, "ModeratorName,ConferenceName");
            //TODO: convert over to ListItem and combine multiple text column values
            dataConferenceList.Items.Clear();
            ListItem listItem;
            foreach (Vw_ConferenceList ConfList in ConferenceList)
            {
                listItem = new ListItem();
                listItem.Value = ConfList.Id.ToString(); //ID is the value item
                //Combine the column text items and place in the text value
                listItem.Text = string.Format("{0} - {1}", ConfList.ModeratorName, ConfList.ConferenceName);
                dataConferenceList.Items.Add(listItem);
            }
            //Add the first item as this is an optional list
            listItem = new ListItem("Not Applicable", "");
            dataConferenceList.Items.Insert(0, listItem);
        }
        catch (Exception ex)
        {
            //If there is an error, disable the control
            dataConferenceList.Enabled = false;
        }
    }

    /// <summary>
    /// Fills the Conference Call list by combining several columns of information. Disables itself
    /// if there is an error.
    /// </summary>
    /// <param name="ModeratorID"></param>
    protected void RefreshConferenceCallList(string ModeratorID)
    {
        try
        {
            string WhereClause = string.Format("ModeratorID={0}", ModeratorID);
            //Fill the Conference Call DropDown
            VList<Vw_ConferenceCallList_Unique> ConferenceCallList = DataRepository.Vw_ConferenceCallList_UniqueProvider.Get(WhereClause, "ConferenceStartTime Desc");
            //TODO: convert over to ListItem and combine multiple text column values
            dataConferenceCallList.Items.Clear();
            ListItem listItem;
            foreach (Vw_ConferenceCallList_Unique item in ConferenceCallList)
            {
                listItem = new ListItem();
                listItem.Value = item.UniqueConferenceId.ToString(); //ID is the value item
                //Combine the column text items and place in the text value
                listItem.Text = string.Format("{0:dd/MMM/yyyy h:mm tt} - {1} {2}", item.ConferenceStartTime.Value, item.NumberPeopleOnCall.ToString(), (item.NumberPeopleOnCall == 1 ? "person" : "people"));
                dataConferenceCallList.Items.Add(listItem);
            }
            //Add the first item as this is an optional list
            listItem = new ListItem("Not Applicable", "");
            dataConferenceCallList.Items.Insert(0, listItem);
            dataConferenceCallList.Enabled = true;
        }
        catch (Exception ex)
        {
            //If there is an error, disable the control
            dataConferenceCallList.Enabled = false;
        }
    }

    /// <summary>
    /// Update the Customer's balance displayed on the screen. Done when Customer changes and when
    /// transaction posted. Returns 0.00 if there is an error.
    /// </summary>
    /// <param name="WholesalerID"></param>
    /// <param name="CustomerID"></param>
    protected void RefreshCustomersBalance(string WholesalerID, string CustomerID)
    {
        try
        {
            DataSet ds;
            DataRow row;
            //Returns a one row dataset with example data: 
            //ID	PriCustomerNumber	PrimaryContactName	CompanyDescription	CurrentBalance	CurrencyID
            //8	    9900000	            Jeff Downs	        Redback Internal Use	3095.38	     AUD
            ds = DataRepository.CustomerProvider.GetBalanceInfoDataSet(WholesalerID, Convert.ToInt32(CustomerID), null);
            row = ds.Tables[0].Rows[0];
            lblCurrentBalance.Text = string.Format("${0} {1}", row["CurrentBalance"].ToString(), row["CurrencyID"].ToString());
        }
        catch (Exception)
        {
            lblCurrentBalance.Text = string.Format("${0} {1}", "0.00", "AUD");
        }
    }

    /// <summary>
    /// Update the list of Customer Transactions
    /// </summary>
    /// <param name="CustomerID"></param>
    protected void RefreshCustomerTransactions(string CustomerID)
    {
        try
        {
            string WhereClause = string.Format("CustomerID={0} AND WholesalerID='{1}'", CustomerID, WholesalerID);
            //Fill the Customer Transactions
            VList<Vw_CustomerTransactionList> CustomerTransactionList = DataRepository.Vw_CustomerTransactionListProvider.Get(WhereClause, "Id desc");
            //sort as it didn't seem to work correctly from Repository
            CustomerTransactionList.Sort("Id desc");
            gvCustomerTransactions.DataSource = CustomerTransactionList;
            //Used for Paging as we aren't using the Typed DataSource so we need to filling the information
            gvCustomerTransactions.RecordsCount = CustomerTransactionList.Count;
            gvCustomerTransactions.PageSize = gvCustomerTransactions.PageSize; //does this get the value from Designer view?
            gvCustomerTransactions.PageIndex = gvCustomerTransactions.PageIndex;
            gvCustomerTransactions.DataBind();

            ////Add to Data to Cache
            //Session.Add(string.Format("wholesaler{0}_customer{1}_misctranslist", WholesalerID, CustomerID), CustomerTransactionList);

        }
        catch (Exception ex)
        {
            //If there is an error, load nothing
            gvCustomerTransactions.DataSource = null;
            gvCustomerTransactions.DataBind();
        }
    }

    /// <summary>
    /// Get the list of Misc. Product Rate Types for the Customer.
    /// </summary>
    /// <param name="CustomerID"></param>
    protected void RefreshMiscProductRateTypes(string CustomerID)
    {
        try
        {
            groupedDDLProductRateDisplayTypes.Items.Clear();
            //'Miscellaneous'
            CustomerService custService = new CustomerService();
            DataSet dsCS = custService.GetProductRatesByProductRateTypeDisplayName(Convert.ToInt32(CustomerID), "Miscellaneous");
            groupedDDLProductRateDisplayTypes.DataSource = dsCS;
            groupedDDLProductRateDisplayTypes.DataBind();
            //Add top item as the default
            ListItem listItem = new ListItem("Select Miscellaneous Charge","");
            groupedDDLProductRateDisplayTypes.Items.Insert(0,listItem);
        }
        catch (Exception ex)
        {
            //If there is an error, load nothing
            groupedDDLProductRateDisplayTypes.DataSource = null;
            groupedDDLProductRateDisplayTypes.DataBind();
        }
    }

    //Paging thru items. need to impl. as no DataSource control is used.
    protected void gvCustomerTransactions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCustomerTransactions.PageIndex = e.NewPageIndex;
        ////Get from cache, doesn't work, could be Updated Panel thing??
        //VList<Vw_CustomerTransactionList> CustomerTransactionList = (VList<Vw_CustomerTransactionList>)Session[string.Format("wholesaler{0}_customer{1}_misctranslist", WholesalerID, CustomerID)];
        //if (CustomerTransactionList != null)
        //{
        //    gvCustomerTransactions.DataSource = CustomerTransactionList;
        //    gvCustomerTransactions.DataBind();
        //}
        //else
        //{
        RefreshCustomer();
        //}

    }
    //Page Size changed. need to impl. as no DataSource control is used.
    protected void gvCustomerTransactions_PageSizeChanged(object sender, EventArgs e)
    {
        //gvCustomerTransactions.PageSize = 30; //force to 30

        RefreshCustomer();
    }

    /// <summary>
    /// Inserts a new Customer Transaction. This is done in two steps:
    /// 1. Insert a new record into the CustomerTransactionImport table. This is used to store the initial info and
    /// is used as a staging area to allow the data to be cleaned up.
    /// 2. Call a special stored procedure that posts the individual items over to the CustomerTransaction table. This
    /// SP does all the work of calculating taxes, totaling amounts, and cleaning up data if missing.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        //Test for selected item
        if (string.IsNullOrEmpty(CustomerID))
        {
            lblMessage.Text = "Error: A Customer Admin was not selected.";
            return; //Nothing selected
        }
        try
        {
            CustomerTransactionImportService ctiService = new CustomerTransactionImportService();
            CustomerTransactionImport cti = new CustomerTransactionImport();
            //Set the Items from Web page into the Entity and save it.
            cti.WholesalerId = WholesalerID;
            cti.CustomerId = Convert.ToInt32(CustomerID);
            if (!string.IsNullOrEmpty(dataConferenceList.SelectedValue) && dataConferenceList.Enabled == true)
            {
                cti.ModeratorId = Convert.ToInt32(dataConferenceList.SelectedValue);
            }
            if (!string.IsNullOrEmpty(dataConferenceCallList.SelectedValue) && dataConferenceCallList.Enabled == true)
            {
                cti.UniqueConferenceId = dataConferenceCallList.SelectedValue;
            }
            //Transaction Type
            cti.CustomerTransactionTypeId = Convert.ToInt32(dataCustomerTransactionType.SelectedValue);
            //Misc Charges tras
            cti.ProductRateId = Convert.ToInt32(groupedDDLProductRateDisplayTypes.SelectedValue);
            cti.Quantity = Convert.ToInt32(numQuantity.Text);
            cti.TransactionAmount = Convert.ToDecimal(txtRetailAmount.Text);
            if (!string.IsNullOrEmpty(txtWSAmount.Text))
            {
                cti.WsTransactionAmount = Convert.ToDecimal(txtWSAmount.Text);
            }
            cti.TransactionDescription = txtDescription.Text;
            cti.TransactionDate = DateTime.Parse(txtTransactionDate.Text);
            //Extra items - useful info
            UserSession us = new UserSession();
            cti.ModifiedBy = us.LoginName;
            cti.ImportType = "AdminSite"; //Used to identify where the transaction came from as SP's post to this table also.
            //Save CustomerTransactionImport Item to get back an ID as it is used to post the specific item
            ctiService.Save(cti);

            //Post item to CustomerTransaction table
            ctiService.PostCustomerTransactionCharges(us.LoginName, cti.Id, null, null, null);

            lblMessage.Text = "Record successfully added.";
            RefreshCustomer();

        }
        catch (Exception ex)
        {
            lblMessage.Text = "ERROR: Please contact the administrator and reference this error message. ";
            lblMessage.Text += "<BR/>" + ex.Message;
        }
    }

    /// <summary>
    /// Jump back to the list of items.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        FormUtil.Redirect("PostMiscellaneousCharges.aspx");
    }

    protected void dataConferenceList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Moderator changed to get a list of Conference calls
        string moderatorID = dataConferenceList.SelectedValue;
        RefreshConferenceCallList(moderatorID);
    }

    /// <summary>
    /// When the Customer value is selected, update the Customer's Balance, Refresh the Moderator/Conference list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataCustomerId2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Customer Admin changed 
        ClearAllControls();
        RefreshCustomer();
    }

    /// <summary>
    /// When the Customer value is selected, update the Customer's Balance, Refresh the Moderator/Conference list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dataCustomerId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearAllControls();
        RefreshCustomer();
    }

    protected void chkDisplayByPrimaryNumber_CheckedChanged(object sender, EventArgs e)
    {
        ClearAllControls();
        if (chkDisplayByPrimaryNumber.Checked)
        {
            //hide the Company list and Display Pri Number list
            dataCustomerId.Visible = false;
            //Fill Primary Number Customer List
            FillCompanyListByPrimaryNumber();
            dataCustomerId2.Visible = true;
        }
        else
        {
            //hide the Company list and Display Pri Number list
            dataCustomerId.Visible = true; //Databound by DataSource control
            dataCustomerId2.Visible = false;
        }
    }
    protected void groupedDDLProductRateDisplayTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Update the totals based on the rate.
        RefreshTransactionTotal();
    }

    protected void RefreshTransactionTotal()
    {
        lblMessage.Text = "";

        int productRateId = 0;
        int quantity = 1;
        decimal transactionAmount = 0;
        decimal wsTransactionAmount = 0;

        //Test for CustomerID
        if (string.IsNullOrEmpty(CustomerID))
        {
            lblMessage.Text = "Error: A Customer Admin was not selected.";
            return; //Nothing selected
        }

        int customerId = Convert.ToInt32(CustomerID);
        //Test for selected item
        if (string.IsNullOrEmpty(groupedDDLProductRateDisplayTypes.SelectedValue))
        {
            lblMessage.Text = "Error: No miscellaneous charge was selected.";
            return; //Nothing selected
        }

        if (!string.IsNullOrEmpty(numQuantity.Text))
        {
            quantity = Convert.ToInt32(numQuantity.Text);
        }

        if (quantity <= 0)
        {
            lblMessage.Text = "Error: Quantity amount is invalid.";
            numQuantity.Text = "1";
            return; 
        }

        try
        {
            productRateId = Convert.ToInt32(groupedDDLProductRateDisplayTypes.SelectedValue);
            //Look up Customers cost of product
            ProductRateValueService prvService = new ProductRateValueService();
            TList<ProductRateValue> prvValues = prvService.GetByCustomerIdProductRateId(customerId, productRateId);
            transactionAmount = quantity * prvValues[0].SellRate;
            wsTransactionAmount = quantity * prvValues[0].BuyRate;
            txtRetailAmount.Text = transactionAmount.ToString("N");
            txtWSAmount.Text = wsTransactionAmount.ToString("N");
        }
        catch (Exception ex)
        {
            lblMessage.Text = "ERROR: Please contact the administrator and reference this error message. ";
            lblMessage.Text += "<BR/>" + ex.Message;
        }


    }

    protected void numQuantity_TextChanged(object sender, EventArgs e)
    {
        RefreshTransactionTotal();
    }
}
