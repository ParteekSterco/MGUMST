using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eventsdetail : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["eventsid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rptdetail, "select Eventsid,eventsdate,largeimage,UploadEvents,EventsTitle,eventsdesc from events where status=1 and eventsid=@eventsid order by displayorder", parameters);

                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rpteventslist, "select Eventsid,eventsdate,largeimage,UploadEvents,EventsTitle,eventsdesc,tagline,shortdesc,largeimage from events where status=1 and ntypeid=2 and eventsid<>@eventsid order by displayorder", parameters);
            }
        }
    }
}