using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_homebanner : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext context = HttpContext.Current;
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
                if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
                {
                    parameters.Clear();
                    clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from homebanner b inner join homebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.mobilestatus=1 and b.devicetype='mobile'  and b.collageid=0  order by b.displayorder", parameters);
                }
                else
                {
                    parameters.Clear();
                    clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from homebanner b inner join homebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.status=1 and b.devicetype='desktop'  and b.collageid=0 order by b.displayorder", parameters);
                }
            }
        }
    }
}