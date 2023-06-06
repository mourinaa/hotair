
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

public partial class CompanyEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterUpdate(FormView1, "CompanyEdit.aspx?{0}", CompanyDataSource);
        FormUtil.RedirectAfterAddNew(FormView1, "CompanyEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "Company.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
        string CompanyID = FormUtil.GetRequestParameter("Id", null);
        lblCompanyID.Text = CompanyID == null ? "" : CompanyID;
        SetControls();
        SetPermissions();
	}

    /// <summary>
    /// Used to set the value of controls.
    /// </summary>
    protected void SetControls()
    {
        UserSession us = new UserSession();
        if (us.SalesPersonID != null)
        {
            //if the sales is not null and it does match the SalesPersonID returned then disable the control
            Customer tmpCustomer = (CustomerDataSource1.GetCurrentEntity() as Customer);
            if (tmpCustomer == null)
            {
                return;
            }
            if (us.SalesPersonID != tmpCustomer.SalesPersonId)
            {
                //wipe the Grid
                GridViewCustomer.Enabled = false;
                //GridViewCustomer.DataSource = new TList<Customer>();
                //GridViewCustomer.DataBind();
                return;
            }
        }
        GridViewCustomer.Enabled = true;
        //GridViewCustomer.DataSource = CustomerDataSource1;
        //GridViewCustomer.DataBind();
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
            hypCustomer.Enabled = false;
        }
        else
        {
            hypCustomer.Enabled = true;
        }
    }

    protected void GridViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {
        string urlParams = string.Format("Id={0}", GridViewCustomer.SelectedDataKey.Values[0]);
        Response.Redirect("CustomerEdit.aspx?" + urlParams, true);
    }

    protected void hypCustomer_Click(object sender, EventArgs e)
    {
        string urlParams = "";
        if (lblCompanyID.Text != "")
            urlParams = string.Format("CompanyID={0}", lblCompanyID.Text);
        Response.Redirect("CustomerEdit.aspx?" + urlParams, true);
    }

    protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
         lblError.Visible = false;
        if (e.AffectedRows == 0)
        {
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
            lblError.Text = string.Format("Error: Company already exists.");
            lblError.Visible = true;
        }
        else
        {
            //Reload the items
            FormUtil.Redirect("CompanyEdit.aspx?{0}",CompanyDataSource);
        }
    }

    protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        //TODO: Pass errors back to user as this will not be shown due to DataSource reloading and Events from Page_Load();
        lblError.Visible = false;
        if (e.AffectedRows == 0)
        {
            e.ExceptionHandled = true;
            e.KeepInEditMode = true;
            lblError.Text = string.Format("Error: Company already exists.");
            lblError.Visible = true;
        }
    }
}


