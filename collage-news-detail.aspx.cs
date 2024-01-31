using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class collage_news_detail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["eventsid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rptdetail, "select distinct e.Eventsid,eventsdate,largeimage,UploadEvents,EventsTitle,eventsdesc,tagline,shortdesc,largeimage from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where status=1 and e.eventsid=@eventsid ", parameters);

                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rptnewslist, "select distinct e.Eventsid,eventsdate,largeimage,UploadEvents,EventsTitle,eventsdesc,tagline,shortdesc,largeimage,e.displayorder from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.status=1 and e.ntypeid in (1,2) and e.eventsid<>@eventsid order by e.displayorder", parameters);
            }
        }
    }
}