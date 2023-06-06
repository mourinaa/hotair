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

public partial class cmdBack : System.Web.UI.UserControl
{
    private string _CssClass;

    public string CssClass
    {
        get { return _CssClass; }
        set { _CssClass = value; }
    }

    private string _Text = "Back";

    public string Text
    {
        get { return _Text; }
        set { _Text = value; }
    }
    private bool _Visible = false;

    public override bool Visible
    {
        get { return _Visible; }
        set { _Visible = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //Put user code to initialize the page here
        if (!Page.IsPostBack)
        {
            // Store URL Referrer to return to
            if (Request.UrlReferrer != null)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
                this.Visible = true;
            }
    //        else if ()
    //{
    //            ElseIf Not _UserSession.URLReferrer Is Nothing Then
    //            //LR: Added code to remove the referrer string as it shouldn't be present when jumping around via links.
    //            _UserSession.URLReferrer = Replace(_UserSession.URLReferrer, ENI_URLREFERRER_QUERYSTRING_URL, "")
    //            ViewState("UrlReferrer") = _UserSession.URLReferrer
    //            cmdBack.Visible = True
    //    }
            else
            {
                //Hide the Back button
                this.Visible = false;
            }
        }
        this.DataBind();//Force the control to evaluate Databinding function or else it won't.

    }
    protected void cmdBack_Click(object sender, EventArgs e)
    {
        this.Click();
    }
    /// <summary>
    /// Expose a Public method to force the Click action.
    /// </summary>
    public void Click()
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString(), true);
    }

}
