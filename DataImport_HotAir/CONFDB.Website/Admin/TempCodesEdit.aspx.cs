
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
#endregion

public partial class TempCodesEdit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{		
		FormUtil.RedirectAfterInsertUpdate(FormView1, "TempCodesEdit.aspx?{0}", TempCodesDataSource);
		FormUtil.RedirectAfterAddNew(FormView1, "TempCodesEdit.aspx");
		FormUtil.RedirectAfterCancel(FormView1, "TempCodes.aspx");
		FormUtil.SetDefaultMode(FormView1, "Id");
	}

    protected void TempCodesDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //Trying to override default Insert, works but datasource still calls the Insert method ie. 2 inserts are done.
        CONFDB.Entities.TempCodes TC = new CONFDB.Entities.TempCodes();
        //TC.Id = Convert.ToInt32(e.InputParameters["Id"].ToString());
        //TC.Codes = e.InputParameters["Codes"].ToString();
        //TC.NewCode = Convert.ToBoolean(e.InputParameters["NewCode"].ToString());
        //TC.CreatedDate = Convert.ToDateTime(e.InputParameters["CreatedDate"].ToString());
        //TC.PriCustomerNumber = e.InputParameters["PriCustomerNumber"].ToString();
        //TC.SecCustomerNumber = e.InputParameters["SecCustomerNumber"].ToString();
        //TC.Location = e.InputParameters["Location"].ToString();

        //CONFDB.Services.TempCodesService tcs = new CONFDB.Services.TempCodesService();
        //tcs.Insert(TC);
    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        //Override the Insert Button to do our own thing. Remove CommandName="Insert" 
        //from the button as it will call the ODS and insert twice.
        //DOESN'T WORK. FormView does rebind correctly.
        //CONFDB.Entities.TempCodes TC = new CONFDB.Entities.TempCodes();
        //TC.Id = Convert.ToInt32(((TextBox)(FormView1.FindControl("dataId"))).Text.ToString());
        //TC.Codes = ((TextBox)(FormView1.FindControl("dataCodes"))).Text.ToString();
        //TC.NewCode = Convert.ToBoolean(((RadioButtonList)(FormView1.FindControl("dataNewCode"))).SelectedValue);
        //TC.CreatedDate = Convert.ToDateTime(((TextBox)(FormView1.FindControl("dataCreatedDate"))).Text.ToString());
        //TC.PriCustomerNumber = ((TextBox)(FormView1.FindControl("dataPriCustomerNumber"))).Text.ToString(); 
        //TC.SecCustomerNumber = ((TextBox)(FormView1.FindControl("dataSecCustomerNumber"))).Text.ToString(); 
        //TC.Location = ((TextBox)(FormView1.FindControl("dataLocation"))).Text.ToString(); 

        //CONFDB.Services.TempCodesService tcs = new CONFDB.Services.TempCodesService();
        //tcs.Insert(TC);

        //FormView1.ChangeMode(FormViewMode.Edit);

    }
    protected void TempCodesDataSource_AfterInserted(object sender, CONFDB.Web.Data.LinkedDataSourceEventArgs e)
    {
        //Make changes to the Insert object to see if this works
        CONFDB.Entities.TempCodes TC = (CONFDB.Entities.TempCodes)e.Entity;
        TC.CreatedDate = DateTime.Now;
        TC.Location = "Changed.";

        CONFDB.Services.TempCodesService tcs = new CONFDB.Services.TempCodesService();
        tcs.Update(TC);
    }
}


