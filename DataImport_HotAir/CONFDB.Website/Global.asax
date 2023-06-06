<%@ Application Language="C#" %>

<script RunAt="server">
    /// <summary>
    /// Place to store all the constants in case string change
    /// </summary>
    private struct Const
    {
        public const string EmailRecordingNotifications = "EmailRecordingNotifications";
        public const string EmailRecordingNotificationsSeconds = "EmailRecordingNotificationsSeconds";
        public const string SendEmailNotifications = "SendEmailNotifications";
        public const string SendEmailNotificationsSeconds = "SendEmailNotificationsSeconds";
        //Used to skip over sending if already in progress
        public const string SendingRecordings = "SendingRecordings";
        public const string SendingEmails = "SendingEmails";
    }
    
    void Application_Start(object sender, EventArgs e)
    {
        //TODO: come up with a better Cache Wrapper class for all of these as we need to 
        // figure out items to cache, how long for each, data types, what to refactor, etc.
        if (HttpContext.Current.Cache != null)
        {
            HttpRuntime.Cache[Const.SendingRecordings] = false;
            HttpRuntime.Cache[Const.SendingEmails] = false;
        }
    
        // Code that runs on application startup
        int defaultTime;
        if (int.TryParse(ConfigurationManager.AppSettings[Const.EmailRecordingNotificationsSeconds].ToString(), out defaultTime))
        {
            AddTask(Const.EmailRecordingNotifications, defaultTime);
        }

        if (int.TryParse(ConfigurationManager.AppSettings[Const.SendEmailNotificationsSeconds].ToString(), out defaultTime))
        {
            AddTask(Const.SendEmailNotifications, defaultTime);
        }
    }

    #region Email Notification Background Worker
    //Used to add a cache item so as to trigger a process in a timely manner
    private static CacheItemRemovedCallback OnCacheRemove = null;

    private void AddTask(string name, int seconds)
    {
        OnCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
        HttpRuntime.Cache.Insert(name, seconds, null,
            DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
            CacheItemPriority.NotRemovable, OnCacheRemove);
    }

    public void CacheItemRemoved(string key, object value, CacheItemRemovedReason reason)
    {
        // do stuff here if it matches our taskname, like WebRequest
        try
        {
            bool sendingRec = (bool)HttpRuntime.Cache[Const.SendingRecordings];
            if (key == Const.EmailRecordingNotifications && sendingRec == false)
            {
                HttpRuntime.Cache[Const.SendingRecordings] = true;
                AdminSite.EmailNotifier emailNotifier = new AdminSite.EmailNotifier();
                emailNotifier.SendRecordingEmails();
                HttpRuntime.Cache[Const.SendingRecordings] = false;
            }

            bool sendingEmails = (bool)HttpRuntime.Cache[Const.SendingEmails];
            if (key == Const.SendEmailNotifications && sendingEmails == false)
            {
                HttpRuntime.Cache[Const.SendingEmails] = true;
                AdminSite.EmailNotifier emailNotifier2 = new AdminSite.EmailNotifier();
                emailNotifier2.SendEmailNotifications();
                HttpRuntime.Cache[Const.SendingEmails] = false;
            }
        }
        catch
        {
        }
        // re-add our task so it recurs
        AddTask(key, Convert.ToInt32(value));
    }

    #endregion

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

