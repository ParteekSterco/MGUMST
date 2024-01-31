using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class events : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            littitle.Text = Convert.ToString(clsm.SendValue_Parameter("select linkname from pagemaster where pageid=@pageid", parameters));

            parameters.Clear();
            clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", parameters, ddlcollage);
            ddlcollage.Items[0].Text = "Select Collage";

            parameters.Clear();
            clsm.Fillcombo_Parameter("select distinct year(Eventsdate) [eventsyear],year(Eventsdate) [yearid] from events where ntypeid=2 and status=1 order by year(Eventsdate) desc", parameters, ddlyear);
            ddlyear.Items[0].Text = "Select Year";

            parameters.Clear();
            clsm.Fillcombo_Parameter("select DATENAME(month, Eventsdate)[monthname],DATENAME(month, Eventsdate)[monthid] from events where ntypeid=2 and status=1 order by DATENAME(month, Eventsdate) ASC", parameters, ddlmonth);
            ddlmonth.Items[0].Text = "Select Month";

            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptevents, "select top 2 eventsid,eventsdate,eventstitle,tagline,uploadevents from events where ntypeid=2 and status=1 order by eventsdate desc", parameters);

            binddata();
        }
    }
    private void binddata()
    {
        string strsql = "select eventsid,eventsdate,eventstitle,tagline,uploadevents from events where ntypeid=2 and status=1 ";

        string streventsid = Convert.ToString(ViewState["eventsid"]);
        streventsid = streventsid.TrimEnd(',');
        if (!string.IsNullOrEmpty(streventsid))
        {
            strsql += " and Eventsid not in (" + streventsid + ")";
            strsql += "  order by eventsdate desc";
            clsm.repeaterDatashow_Parameter(rpteventlist, strsql, parameters);
        }
        if (rpteventlist.Items.Count > 12)
        {
            panelloadmore.Visible = true;
        }
    }
    protected void rptevents_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal liteventstitle = (Literal)e.Item.FindControl("liteventstitle");

            ViewState["eventsid"] += liteventsid.Text + ",";
            ank.HRef = "/events-detail/" + clsm.replacestring(liteventstitle.Text) + "/" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void rpteventlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal liteventstitle = (Literal)e.Item.FindControl("liteventstitle");

            ank.HRef = "/events-detail/" + clsm.replacestring(liteventstitle.Text) + "/" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelcollage = (HtmlContainerControl)Master.FindControl("panelcollage");
        panelcollage.Visible = false;
    }
}