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
using CONFDB.Entities;
using CONFDB.Web.UI;

public partial class ModeratorUserFields : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    void BindData()
    {
        //Fill the databound controls
        int UserId = Convert.ToInt32(FormUtil.GetRequestParameter("UserId", "-1"));
        if (UserId != -1)
        {
            //Get CustomerId from Moderator using the UserId
            TList<Moderator> modList = DataRepository.ModeratorProvider.GetByUserId(UserId);
            if (modList != null)
            {
                string customerID = modList[0].CustomerId.ToString();
                HyperLink lnkCustomerId = FormView1.FindControl("lnkCustomerId") as HyperLink;
                lnkCustomerId.NavigateUrl = string.Format("~/Admin/CustomerEdit.aspx?Id={0}", customerID);

                EntityDropDownList ddList = FormView1.FindControl("EntityDropDownList1") as EntityDropDownList;
                ddList.DataSource = DataRepository.Vw_CustomerListProvider.Get("CustomerId = " + customerID,"");
                ddList.DataBind();

            }
        }
    }

}
