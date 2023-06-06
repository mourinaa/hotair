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
using System.Data.SqlClient;
using CONFDB.Entities;
using CONFDB.Data;

public partial class BillingRun : System.Web.UI.Page
{
    string WholesalerID = ConfigurationManager.AppSettings["WholesalerID"].ToString();
    int BillingRunTimeoutSeconds = Int32.Parse(ConfigurationManager.AppSettings["BillingRunTimeoutSeconds"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnMarkLastBillingRunComplete_Click(object sender, EventArgs e)
    {
        try
        {
            //UtilService utilSvc = new UtilService();
            //utilSvc.INV_Mark_BillableCDRSEnd();
            //lblMarkLastBillingRunComplete.Visible = true; //show the done label

            ///DEV NOTE: Seems to be an issue with this call and the transaction or connection is reset and the Billing Run
            ///is not done. Going to ADO.NET transaction method to get the job done.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CONFDB.Data.ConnectionString"].ToString()))
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = new SqlCommand("p_UTIL_INV_Mark_BillableCDRSEnd", connection);
                command.CommandTimeout = BillingRunTimeoutSeconds;
                try
                {
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    // Commit the transaction.
                    sqlTran.Commit();
                    //Things are good
                    lblMarkLastBillingRunComplete.Text = "Done.";
                    lblMarkLastBillingRunComplete.Visible = true;
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    lblErrorMessage.Text = ex.Message;
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
                        lblErrorMessage.Text += "<BR/>" + exRollback.Message;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMarkLastBillingRunComplete.Visible = false;
            //Throw the error as we need to know what is going if something goes wrong
            throw ex;
        }
    }

    protected void btnBackupInvoiceTables_Click(object sender, EventArgs e)
    {
        try
        {
            //UtilService utilSvc = new UtilService();
            //utilSvc.INV_BACKUP_INVOICING_TABLES();
            //lblBackupInvoiceTables.Visible = true; // show the done label

            ///DEV NOTE: Seems to be an issue with this call and the transaction or connection is reset and the Billing Run
            ///is not done. Going to ADO.NET transaction method to get the job done.
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CONFDB.Data.ConnectionString"].ToString()))
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = new SqlCommand("p_UTIL_INV_BACKUP_INVOICING_TABLES", connection);
                command.CommandTimeout = BillingRunTimeoutSeconds;
                try
                {
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                    // Commit the transaction.
                    sqlTran.Commit();
                    //Things are good
                    lblBackupInvoiceTables.Text = "Done.";
                    lblBackupInvoiceTables.Visible = true;
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    lblErrorMessage.Text = ex.Message;
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
                        lblErrorMessage.Text += "<BR/>" + exRollback.Message;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblBackupInvoiceTables.Visible = false;
            //Throw the error as we need to know what is going if something goes wrong
            throw ex;
        }
    }

    protected void btnExecuteBillingRun_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtStartDate.Text) || string.IsNullOrEmpty(txtEndDate.Text))
            {
                lblExecuteBillingRun.Text = "ERROR: The start date or end date is invalid. Change the date and change your request again.";
                lblExecuteBillingRun.Visible = true;
                return;
            }
            lblExecuteBillingRun.Text = "Done.";
            lblExecuteBillingRun.Visible = false;
            lblErrorMessage.Text = "";

            //Get all the Parameter values
            DateTime StartDate = DateTime.Parse(txtStartDate.Text);
            DateTime EndDate = DateTime.Parse(txtEndDate.Text);
            int BillingPeriodCutoff = Convert.ToInt32(txtBillingCutoff.Text);

            ///DEV NOTE: Seems to be an issue with this call and the transaction or connection is reset and the Billing Run
            ///is not done. Going to ADO.NET transaction method to get the job done.
            //UtilService utilSvc = new UtilService();
            //utilSvc.INV_DoBillingRun(StartDate, EndDate, WholesalerID, BillingPeriodCutoff);

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CONFDB.Data.ConnectionString"].ToString()))
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = new SqlCommand("p_UTIL_INV_DoBillingRun", connection);
                command.CommandTimeout = BillingRunTimeoutSeconds;
                try
                {
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    // 3. add parameter to command, which
                    //    will be passed to the stored procedure
                    command.Parameters.Add(
                        new SqlParameter("@StartDate", StartDate));
                    command.Parameters.Add(
                        new SqlParameter("@EndDate", EndDate));
                    command.Parameters.Add(
                        new SqlParameter("@WholesalerID", WholesalerID));
                    command.Parameters.Add(
                        new SqlParameter("@BillingPeriodCutoff", BillingPeriodCutoff));

                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();
                    //Things are good
                    lblExecuteBillingRun.Text = "Done.";
                    lblExecuteBillingRun.Visible = true;
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    lblErrorMessage.Text = ex.Message;
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
                        lblErrorMessage.Text += "<BR/>" + exRollback.Message;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblExecuteBillingRun.Visible = false;
            //Throw the error as we need to know what is going if something goes wrong
            throw ex;
        }
    }

    protected void btnRollback_Click(object sender, EventArgs e)
    {
        try
        {
            //UtilService utilSvc = new UtilService();
            //utilSvc.INV_ROLLBACK_INVOICING_TABLES(WholesalerID);
            //lblRollback.Visible = true; // show the done label

            ///DEV NOTE: Seems to be an issue with this call and the transaction or connection is reset and the Billing Run
            ///is not done. Going to ADO.NET transaction method to get the job done.

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CONFDB.Data.ConnectionString"].ToString()))
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = new SqlCommand("p_UTIL_INV_ROLLBACK_INVOICING_TABLES", connection);
                command.CommandTimeout = BillingRunTimeoutSeconds;
                try
                {
                    command.Transaction = sqlTran;
                    command.CommandType = CommandType.StoredProcedure;
                    // 3. add parameter to command, which
                    //    will be passed to the stored procedure
                    command.Parameters.Add(
                        new SqlParameter("@WholesalerID", WholesalerID));

                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();
                    //Things are good
                    lblRollback.Text = "Done.";
                    lblRollback.Visible = true;
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    lblErrorMessage.Text = ex.Message;
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
                        lblErrorMessage.Text += "<BR/>" + exRollback.Message;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblRollback.Visible = false;
            //Throw the error as we need to know what is going if something goes wrong
            throw ex;
        }
    }

    protected void btnEmailInvoices_Click(object sender, EventArgs e)
    {
        lblErrorMessage.Text = string.Empty;
        Label1.Visible = false;
        //Add a billing date to the SystemSettings table, this is used by backend 
        // process to gen and email the invoices
        string invoiceDateFormat = "MMMddyyyy";
        if (string.IsNullOrEmpty(txtStartDate.Text))
        {
            lblMessage.Text = "Error: Start date is required.";
            return;
        }
        DateTime invoiceDate;
        try
        {
            invoiceDate = DateTime.Parse(txtStartDate.Text);
        }
        catch (Exception ex)
        {
            lblMessage.Text = "Error: Start date is invalid. " + ex.Message;
            return;
        }

        SystemSettingsKey sysSettingsKey = new SystemSettingsKey("EmailInvoicerInvoiceDate");
        SystemSettings systemSettings = null;
        //Get the Invoice Date from database
        systemSettings = DataRepository.SystemSettingsProvider.Get(sysSettingsKey);
        if (systemSettings == null)
        {
            lblMessage.Text = "Error: SystemSettingsKey is invalid or not found in database.";
            return;
        }
        //Save the value and save
        systemSettings.Value = invoiceDate.ToString(invoiceDateFormat);
        if (!DataRepository.SystemSettingsProvider.Update(systemSettings))
        {
            lblMessage.Text = "ERROR: Failed to update SystemSettings table database to set the date value.";
            return;
        }
        lblMessage.Text = "";
        Label1.Visible = true;
    }
}
