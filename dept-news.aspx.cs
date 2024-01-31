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

public partial class dept_news : System.Web.UI.Page
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
            clsm.Fillcombo_Parameter("select distinct year(Eventsdate) [eventsyear],year(Eventsdate) [yearid] from events where ntypeid in (1,2) and status=1 order by year(Eventsdate) desc", parameters, ddlyear);
            ddlyear.Items[0].Text = "Select Year";


            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            clsm.repeaterDatashow_Parameter(rptnews, "select top 1 e.eventsid,eventsdate,eventstitle,tagline,uploadevents,n.ntype from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid inner join newstype n on n.ntypeid=e.ntypeid where e.ntypeid=1 and e.status=1 and map.collageid=@collageid and map.deptid=@deptid order by e.eventsdate desc", parameters);

            binddata();

            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            clsm.repeaterDatashow_Parameter(rptevents, "select top 2 e.eventsid,eventsdate,eventstitle,tagline,uploadevents,n.ntype from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid inner join newstype n on n.ntypeid=e.ntypeid where e.ntypeid=2 and e.status=1 and map.collageid=@collageid and map.deptid=@deptid order by e.eventsdate desc", parameters);
        }
    }
    private void binddata()
    {
        // News
        parameters.Clear();
        parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        string strsql = "select distinct e.eventsid,eventsdate,eventstitle,tagline,uploadevents from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.ntypeid=1 and e.status=1 and map.collageid=@collageid and map.deptid=@deptid ";

        string streventsid = Convert.ToString(ViewState["eventsid"]);
        streventsid = streventsid.TrimEnd(',');
        if (!string.IsNullOrEmpty(streventsid))
        {
            strsql += " and e.Eventsid not in (" + streventsid + ")";
            strsql += "  order by e.eventsdate desc";
            clsm.repeaterDatashow_Parameter(rptnewslist, strsql, parameters);
        }
        if (rptnewslist.Items.Count > 12)
        {
            panelloadmore.Visible = true;
        }

        // events
        parameters.Clear();
        parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        strsql = "select distinct e.eventsid,eventsdate,eventstitle,tagline,uploadevents from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.ntypeid=2 and e.status=1 and map.collageid=@collageid and map.deptid=@deptid ";

        string strevents = Convert.ToString(ViewState["events"]);
        streventsid = streventsid.TrimEnd(',');
        if (!string.IsNullOrEmpty(strevents))
        {
            strsql += " and e.Eventsid not in (" + strevents + ")";
            strsql += "  order by e.eventsdate desc";
            clsm.repeaterDatashow_Parameter(rpteventlist, strsql, parameters);
        }
        if (rpteventlist.Items.Count > 12)
        {
            panellaodevents.Visible = true;
        }
    }
    protected void rptnews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ViewState["eventsid"] += liteventsid.Text + ",";
            ank.HRef = "/dept-news-detail.aspx?mpgid=" + Conversion.Val(Request.QueryString["mpgid"]) + "&pgidtrail=" + Conversion.Val(Request.QueryString["pgidtrail"]) + "&eventsid=" + Conversion.Val(liteventsid.Text) + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);
        }
    }
    protected void rptnewslist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/dept-news-detail.aspx?mpgid=" + Conversion.Val(Request.QueryString["mpgid"]) + "&pgidtrail=" + Conversion.Val(Request.QueryString["pgidtrail"]) + "&eventsid=" + Conversion.Val(liteventsid.Text) + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);
        }
    }
    protected void rptevents_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ViewState["events"] += liteventsid.Text + ",";
            ank.HRef = "/dept-news-detail.aspx?mpgid=" + Conversion.Val(Request.QueryString["mpgid"]) + "&pgidtrail=" + Conversion.Val(Request.QueryString["pgidtrail"]) + "&eventsid=" + Conversion.Val(liteventsid.Text) + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);
        }
    }
    protected void rpteventlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/dept-news-detail.aspx?mpgid=" + Conversion.Val(Request.QueryString["mpgid"]) + "&pgidtrail=" + Conversion.Val(Request.QueryString["pgidtrail"]) + "&eventsid=" + Conversion.Val(liteventsid.Text) + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelcollage = (HtmlContainerControl)Master.FindControl("panelcollage");
        panelcollage.Visible = false;
    }
}