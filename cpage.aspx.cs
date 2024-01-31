using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cpage : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["pgidtrail"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
                litdesc.Text =Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select pagedescription from pagemaster where pagestatus=1 and pageid=@pageid", parameters)));
            }
        }
    }
}