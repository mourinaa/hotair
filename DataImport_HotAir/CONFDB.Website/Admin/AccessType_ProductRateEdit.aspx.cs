
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
using CONFDB.Services;
using CONFDB.Entities;
#endregion

public partial class AccessType_ProductRateEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //FormUtil.RedirectAfterInsertUpdate(FormView1, "AccessType_ProductRateEdit.aspx?{0}", AccessType_ProductRateDataSource);
        //FormUtil.RedirectAfterAddNew(FormView1, "AccessType_ProductRateEdit.aspx");
        //FormUtil.RedirectAfterCancel(FormView1, "AccessType_ProductRate.aspx");
        //FormUtil.SetDefaultMode(FormView1, "Id");
    }

    /// <summary>
    /// Insert new AccessType_ProductRate item.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        //Test for selected item
        if (lstProductRates.SelectedIndex == -1)
        {
            lblMessage.Text = "Error: A Product Rate was not selected.";
            return; //Nothing selected
        }

        try
        {
            AccessType_ProductRateService ATPRService = new AccessType_ProductRateService();

            foreach (ListItem lstItem in lstProductRates.Items)
            {
                if (lstItem.Selected)
                {
                    //add a record
                    AccessType_ProductRate oATPR = new AccessType_ProductRate();
                    oATPR.AccessTypeId = Convert.ToInt32(dataAccessTypeId.SelectedValue);
                    oATPR.ProductRateId = Convert.ToInt32(lstItem.Value);
                    ATPRService.Save(oATPR);
                }
            }
            lblMessage.Text = "Record successfully added.";
            //Refresh the lower Grids data.
            EntityGridView1.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Jump back to the list of items.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        FormUtil.Redirect("AccessType_ProductRateEdit.aspx");
    }


    protected void EntityGridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            AccessType_ProductRateService ATPRService = new AccessType_ProductRateService();
            AccessType_ProductRate oATPR = ATPRService.GetById(Convert.ToInt32(e.Keys[0]));

            oATPR.AccessTypeId = Convert.ToInt32(e.NewValues[0]);
            oATPR.ProductRateId = Convert.ToInt32(e.NewValues[1]);
            ATPRService.Save(oATPR);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void EntityGridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            AccessType_ProductRateService ATPRService = new AccessType_ProductRateService();
            ATPRService.Delete(Convert.ToInt32(e.Keys[0]));

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Updating of the Datasource control. Need to override this as the DS tries to update but since it is based on a View
    /// or for some other strange reason, the end result is an error. So Cancel out of it as its handled in the GridView methods.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AccessType_ProductRateDataSource1_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.Cancel = true;
    }

    /// <summary>
    /// Deleting of the Datasource control. Need to override this as the DS tries to delete but since it is based on a View
    /// or for some other strange reason, the end result is an error. So Cancel out of it as its handled in the GridView methods.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AccessType_ProductRateDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        e.Cancel = true;
    }
}


