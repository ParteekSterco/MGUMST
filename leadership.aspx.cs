using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class leadership : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptleadership, "select teamid,ttypeid,name,qualification,industries,Uploadphoto,designation from ourteam where status=1 and ttypeid=5 order by displayorder", parameters);
        }
    }
    protected void rptleadership_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litteamid = (Literal)e.Item.FindControl("litteamid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/leadershipdetail.aspx?mpgid=2&pgid1=7&pgidtrail=7&lid=" + Conversion.Val(litteamid.Text);
        }
    }
}