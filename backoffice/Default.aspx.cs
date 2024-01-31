using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using Microsoft.VisualBasic;
using System.Net;
using System.Net.Mail;

public partial class backoffice_Default : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Random random = new Random();
    Hashtable Parameters = new Hashtable();
    Enc_Decyption enc = new Enc_Decyption();
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

        if (!Page.IsPostBack)
        {
           
            
            //string strurl = Convert.ToString(Request.RawUrl);

            //if (strurl != "/bveducation")
            //{
            //    Response.Redirect("/");

            //}

            //************ ip start**********

            //string strcheck = Convert.ToString(Request.Url);
            //if (strcheck.Contains("http://web") == true || strcheck.Contains("http://wserver") == true)
            //{



            //}
            //else
            //{

            //    string strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            //    if (string.IsNullOrEmpty(strip))
            //    {
            //        strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            //    }

            //    Parameters.Clear();
            //    Parameters.Add("@strip", enc.AES_Encrypt(strip, "@9899848281"));
            //    if (clsm.Checking_Parameter("select * from ipmaster where status=1 and  ip=@strip", Parameters) == false)
            //    {
                
            //        Response.Redirect("/");
            //    }
            //}

           

            //************ip end **************

            
        }
       
    }
}
