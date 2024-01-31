using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;


public partial class backoffice_users_homepage : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
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
        if (Conversion.Val(AUserSession["Roleid"]) == 1)
        {
            divdashboard.Visible = true;

        }
        if (!IsPostBack)
        {
            litpostapp.Text = (clsm.SendValue_Parameter("select Count(*) from PostedApplication where 1=1", Parameters)).ToString();


            litsubscribers.Text = (clsm.SendValue_Parameter("select Count(*) from Subscribers where status=1", Parameters)).ToString();

            //litblogenquiry.Text = (clsm.SendValue_Parameter("select Count(*) from blog_enquiry where Status=1", Parameters)).ToString();


            litenquiries.Text = (clsm.SendValue_Parameter("select Count(*) from Enquiry", Parameters)).ToString();

            if (Conversion.Val(Convert.ToString(Session["Trid"])) != 1)
            {
                divdashboard.Visible = false;
            }

        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
       
    }
}