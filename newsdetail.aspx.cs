using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newsdetail : System.Web.UI.Page
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
                clsm.repeaterDatashow_Parameter(rptdetail, "select Eventsid,eventsdate,largeimage,UploadEvents,EventsTitle,eventsdesc,tagline,shortdesc,largeimage from events where status=1 and eventsid=@eventsid order by displayorder", parameters);

                parameters.Clear();
                parameters.Add("@eventsid", Conversion.Val(Request.QueryString["eventsid"]));
                clsm.repeaterDatashow_Parameter(rptnewslist, "select Eventsid,eventsdate,largeimage,UploadEvents,EventsTitle,eventsdesc,tagline,shortdesc,largeimage from events where status=1 and ntypeid=1 and eventsid<>@eventsid order by displayorder", parameters);
            }
        }
    }
}