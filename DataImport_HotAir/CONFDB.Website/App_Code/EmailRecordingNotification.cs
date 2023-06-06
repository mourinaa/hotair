using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CONFDB.Entities;
using CONFDB.Services;
using CONFDB.Data;
using System.Data;
using au.com.redbackconferencing.ws;
using System.Configuration;

namespace AdminSite
{
    /// <summary>
    /// Used to send email notifications to customers.
    /// </summary>
    public class EmailNotifier
    {
        private string wholesalerID = ConfigurationManager.AppSettings["WholesalerID"];

        public EmailNotifier()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Send recording email notifications out. This is used to sent emails from based on items added to the Recording table and used mainly
        /// for Audio recordings.
        /// DEVNOTE: 
        /// RecordingNotifications = send email to Primary Contact on WS, if set this overrides RecordingNotificationCustomerAdmin
        /// RecordingNotificationsModerator = send email to Moderator
        /// RecordingNotificationsCustomerAdmin = send email to Primary Contact
        /// </summary>
        /// <returns></returns>
        /// <remarks>See SendEmailNotifications for a more general use scenario.</remarks>
        public bool SendRecordingEmails()
        {
            try
            {
                string templateName = "RecordingConfirmation";
                //Email Template database            
                EmailTemplateService ets = new EmailTemplateService();
                //Email template web service
                EmailTemplateUtil etu = new EmailTemplateUtil();

                //Get the list of Recordings we need to send emails for.
                RecordingService recordingService = new RecordingService();
                TList<Recording> recordings = recordingService.Find("EmailSent = false");
                if (recordings == null || recordings.Count == 0)
                {
                    return true; //exit out
                }

                //for each one get the email information as we need figure out who to send the email to
                foreach (var recording in recordings)
                {
                    try
                    {
                        //Convert items to Null to pass to the DB
                        int moderatorID = recording.ModeratorId.Value;
                        int recordingID = recording.Id;

                        //Get the first Table
                        DataTable dtEmailInfo = ets.GetEmailInfo(wholesalerID, null, moderatorID, recordingID).Tables[0];
                        //Get the first Row (should only be 1 row)
                        DataRow drEmailInfo = dtEmailInfo.Rows[0];
                        int sendToContact = 0;
                        int sendToModerator = 0;
                        //this setting overrides the one below
                        if (drEmailInfo["RecordingNotifications"].ToString().ToLower() == "yes")
                        {
                            sendToContact = 1;
                        }

                        if (drEmailInfo["RecordingNotificationsModerator"].ToString().ToLower() == "yes")
                        {
                            sendToModerator = 1;
                        }
                        if (sendToContact == 0)
                        {
                            //check the moderator lvl rule
                            if (drEmailInfo["RecordingNotificationsCustomerAdmin"].ToString().ToLower() == "yes")
                            {
                                sendToContact = 1;
                            }
                        }
                        //FIX: JS Dec/2013 - if both the SendToContact and sendToModerator are 0 - false then the send of emails errors out and keeps retrying forever.
                        // The reason for both being 0 is to denote that someone doesn't want to get the notifications so we need to record this and mark it
                        // as "EmailSent = true" so as to not continue to retry
                        if (sendToContact == 0 && sendToModerator == 0)
                        {
                            //Mark as sent and add Notes
                            recording.Notes = "Send to Contact and Moderator both disabled. No email sent. Marking complete.".Substring(0, 100);
                            recording.EmailSent = true;
                            recordingService.Update(recording);
                            continue;
                        }

                        string CCList = ""; //string.Empty
                        string strMsgResult;
                        strMsgResult = etu.SendEmailByModeratorID(wholesalerID, moderatorID, templateName,
                            string.Empty, CCList, sendToContact, sendToModerator, 0, recordingID);
                        //If the result is blank then everything was good
                        if (strMsgResult == "")
                        {
                            //Mark the email as sent and update the database.
                            recording.EmailSent = true;
                            recordingService.Update(recording);
                        }
                    }
                    catch
                    {
                        //keep processing
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// Sends any type of email notification found in the EmailNotification table and based on the information provided there.
        /// This is a more general purpose email sending function.
        /// </summary>
        /// <returns></returns>
        /// <remarks>See SendRecordingEmails for specificing sending out Recording email notifications to customers.</remarks>
        public bool SendEmailNotifications()
        {
            try
            {
                //Email Notificiation table
                EmailNotificationService emailNotificationService = new EmailNotificationService();
                //Email template web service
                EmailTemplateUtil emailTemplateService = new EmailTemplateUtil();
                string strResult = null;

                //Get the list of Email to send out
                TList<EmailNotification> emailList = emailNotificationService.Find("EmailSent = false");
                if (emailList == null || emailList.Count == 0)
                {
                    return true; //exit out
                }

                //for each one get the email information as we need figure out who to send the email to
                foreach (var email in emailList)
                {
                    try
                    {
                        //Pass in default value which tells web service to use settings from email template settings
                        int sendToContact = -1;
                        int sendToModerator = -1;
                        string PriCustomerNumber = string.Empty;
                        string CCList = string.Empty;
                        //Send the email
                        strResult = emailTemplateService.SendEmailByModeratorID(wholesalerID, email.ModeratorId, email.TemplateName,
                            PriCustomerNumber, CCList, sendToContact, sendToModerator, -1, -1);
                        //If the result is blank then everything was good
                        if (string.IsNullOrEmpty(strResult))
                        {
                            //Mark the email as sent and update the database.
                            email.EmailSent = true;
                            email.SentDate = DateTime.Now;
                            email.ErrorInfo = null; //clear any error
                        }
                        else
                        {
                            email.EmailSent = false;
                            email.SentDate = null;
                            email.ErrorInfo = strResult;
                        }
                        emailNotificationService.Update(email);
                    }
                    catch (Exception ex)
                    {
                        //log error and keep processing
                        email.EmailSent = false;
                        email.SentDate = null;
                        email.ErrorInfo = string.Format("Exception occurred sending email. Result: {0} Error: {1}", strResult, ex);
                        emailNotificationService.Update(email);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }
    }
}