using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CONFDB.Entities;
using CONFDB.Services;
using CONFDB.Data;

using System.Web.SessionState;
//using AUSWebControlLibrary;


/// <summary>
/// Summary description for DataAccessHelper
/// </summary>
public class DataAccessHelper
{
    public static VList<Vw_ModeratorList> GetModerators(string searchName, string sortBy, string ascdesc)
    {
        //UserLoggedIn u = new UserLoggedIn();
        UserSession u = new UserSession();

        //ModeratorService mds = new ModeratorService();
        //TList<Moderator> mlist = null;

        Vw_ModeratorListService mls = new Vw_ModeratorListService();
        VList<Vw_ModeratorList> mlist = null;
        string whereStr = "";

        //if (u.UserProfile.RoleIdSource.Name == "Moderator")
        if (u.RoleName == "Moderator")
        {
            //mlist = mds.DeepLoadByUserId(u.UserProfile.UserId, true, DeepLoadType.IncludeChildren, typeof(Department), typeof(User));
            whereStr = "UserID = " + u.UserProfile.UserId.ToString();

            if (searchName != "")
                whereStr = whereStr + " AND UPPER(DisplayName) LIKE '%" + searchName.ToUpper() + "%'";
            mlist = mls.Get(whereStr, "ModeratorCode");
        }
        else if (u.RoleName == "Customer")
        {
            //mlist = mds.DeepLoadByCustomerId(Int32.Parse(u.CustomerID), true, DeepLoadType.IncludeChildren, typeof(Department), typeof(User));
            whereStr = "CustomerID = " + u.CustomerID.ToString();

            if (searchName != "")
                whereStr = whereStr + " AND UPPER(DisplayName) LIKE '%" + searchName.ToUpper() + "%'";
            mlist = mls.Get(whereStr, "UserName");        
        }
        else if (u.UserProfile.RoleIdSource.Name == "Company Admin")
        {
            whereStr = "CustomerID = " + u.CustomerID.ToString();

            if (searchName != "")
                whereStr = whereStr + " AND UPPER(DisplayName) LIKE '%" + searchName.ToUpper() + "%'";
            mlist = mls.Get(whereStr, "UserName");
        }
        else
        {
            //mlist = mds.DeepLoadByUserId(u.UserProfile.UserId, true, DeepLoadType.IncludeChildren, typeof(Department), typeof(User));
        }

        
        /*
        if (searchName != "")
        {
            searchName = searchName.ToUpper();
            
            //mlist.ApplyFilter(delegate(Moderator m) { return m.Name.ToUpper().Contains(searchName); });
            mlist.ApplyFilter(delegate(Moderator m) { return m.UserIdSource.DisplayName.ToUpper().Contains(searchName); });

        }
        

       
        if (sortBy != "")
        {
            mlist.Sort(sortBy + " " + ascdesc);
        }
        */

        return (mlist);
    }

 }
