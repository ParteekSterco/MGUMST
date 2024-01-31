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

public partial class backoffice_layouts_sigininmaster : System.Web.UI.MasterPage
{
   
    public HttpCookie AUserSession = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

      

        if (Page.IsPostBack == false)
        {
            lbldatetime.Text =DateTime.Today.ToString("dddd,MMMM dd,yyyy");
        }
    }
}
