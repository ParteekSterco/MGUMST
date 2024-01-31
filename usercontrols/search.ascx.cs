using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (!string.IsNullOrEmpty(txtsearch.Text.Trim()))
        {
            Response.Redirect("~/search.aspx?mpgid=614&pgidtrail=614&search=" + Server.UrlEncode(txtsearch.Text).Trim(), true);
        }

    }
}