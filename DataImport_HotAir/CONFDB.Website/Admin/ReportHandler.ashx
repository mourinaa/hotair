<%@ WebHandler Language="C#" Class="ReportHandler" %>

using System;
using System.Web;

using System.Web.SessionState;

using CONFDB.Services;
using CONFDB.Entities;
using Newtonsoft.Json;


public class ReportHandler : IHttpHandler, IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        UserSession u = new UserSession();
        if (!u.IsAuthenicated)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Write("{ \"err\": { \"errcode\":\"-1\", \"msg\":\"session timeout\" } }");
            
            return;
            
            //u.LogOff();//stops all process and logs user out
        }

        var reportType = context.Request["reportType"];

        DateTime startDate, endDate;
        var mod = new Moderator();
        
        DateTime.TryParse(context.Request["endDate"], out endDate);
        
        if (DateTime.TryParse(context.Request["startDate"], out startDate))
        {
            UtilService utilSvc = new UtilService();
            var result=utilSvc.GetReportData(reportType, u.CustomerID,null, startDate, endDate);
            
            string json = JsonConvert.SerializeObject(result);

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.Write(json);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}