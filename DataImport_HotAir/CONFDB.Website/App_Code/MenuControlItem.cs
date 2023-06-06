using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MenuControlItem
/// </summary>
public class MenuControlItem
{
    private string label;
    private string url;
    private string options;

    private string [] levels;

    public MenuControlItem()
    {
    }

    public MenuControlItem(string title, string url, string options)
    {
        this.label = title;
        this.url = url;
        this.options = options;
    }


    public string Label
    {
        get
        {
            return label;
        }
    }

    public string Url
    {
        get
        {
            return url;
        }
    }

    public string Options
    {
        get
        {
            return options;
        }
    }
}
