
#region Imports...
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
using CONFDB.Web.UI;
using CONFDB.Entities;
using CONFDB.Services;
#endregion

public partial class CustomerEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "CustomerEdit.aspx?{0}", CustomerDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "CustomerEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Customer.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}
	protected void GridViewProductRateValue_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewProductRateValue.SelectedDataKey.Values[0]);
		Response.Redirect("ProductRateValueEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewCustomer_Feature_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewCustomer_Feature.SelectedDataKey.Values[0]);
		Response.Redirect("Customer_FeatureEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewDepartment_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewDepartment.SelectedDataKey.Values[0]);
		Response.Redirect("DepartmentEdit.aspx?" + urlParams, true);		
	}	
	protected void GridViewModerator_SelectedIndexChanged(object sender, EventArgs e)
	{
		string urlParams = string.Format("Id={0}", GridViewModerator.SelectedDataKey.Values[0]);
		Response.Redirect("ModeratorEdit.aspx?" + urlParams, true);		
	}
    /// <summary>
    /// After the Customer is added, install the defaults
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerDataSource_AfterInserted(object sender, CONFDB.Web.Data.LinkedDataSourceEventArgs e)
    {
        CustomerService CustService = new CustomerService();

        //Get the inserted object from the args.
        Customer cust = (Customer)e.Entity;
        //Copy the defaults down from Wholesaler
        CustService.InstallDefaults(cust.Id);
    }

    /// <summary>
    /// Before inserting copy over the Primary Contact info to the Billing Info
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CustomerDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //Get the next PriCustomerNumber value.
        //Doing it this way allows for cases where this rule could be changed.
        CustomerService CustService = new CustomerService();
        string PriCustNum = "";
        string WholesalerID = e.InputParameters["WholesalerId"].ToString();
        CustService.GetNextCustomerNumber(WholesalerID, ref PriCustNum);
        if (PriCustNum != "")
            e.InputParameters["PriCustomerNumber"] = PriCustNum;
        
        //Copy over the Primary contact info if not set.
        if (e.InputParameters["BillingContactName"].ToString() == "")
            e.InputParameters["BillingContactName"] = e.InputParameters["PrimaryContactName"];
        if (e.InputParameters["BillingContactPhoneNumber"].ToString() == "")
            e.InputParameters["BillingContactPhoneNumber"] = e.InputParameters["PrimaryContactPhoneNumber"];
        if (e.InputParameters["BillingContactEmailAddress"].ToString() == "")
            e.InputParameters["BillingContactEmailAddress"] = e.InputParameters["PrimaryContactEmailAddress"];
        if (e.InputParameters["BillingContactAddress1"].ToString() == "")
            e.InputParameters["BillingContactAddress1"] = e.InputParameters["PrimaryContactAddress1"];
        if (e.InputParameters["BillingContactAddress2"].ToString() == "")
            e.InputParameters["BillingContactAddress2"] = e.InputParameters["PrimaryContactAddress2"];
        if (e.InputParameters["BillingContactCity"].ToString() == "")
            e.InputParameters["BillingContactCity"] = e.InputParameters["PrimaryContactCity"];
        if (e.InputParameters["BillingContactCountry"].ToString() == "")
            e.InputParameters["BillingContactCountry"] = e.InputParameters["PrimaryContactCountry"];
        if (e.InputParameters["BillingContactRegion"].ToString() == "")
            e.InputParameters["BillingContactRegion"] = e.InputParameters["PrimaryContactRegion"];
        if (e.InputParameters["BillingContactPostalCode"].ToString() == "")
            e.InputParameters["BillingContactPostalCode"] = e.InputParameters["PrimaryContactPostalCode"];
        if (e.InputParameters["BillingContactFaxNumber"].ToString() == "")
            e.InputParameters["BillingContactFaxNumber"] = e.InputParameters["PrimaryContactFaxNumber"];

    }
}