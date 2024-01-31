using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class gallerydetail : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["gid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(Request.QueryString["gid"]));
                clsm.repeaterDatashow_Parameter(rptimagelist, "select photoid,albumid,phototitle,uploadphoto from albumphoto where status=1 and albumid=@albumid order by displayorder", parameters);

                parameters.Clear();
                parameters.Add("@albumid", Conversion.Val(Request.QueryString["gid"]));
                clsm.repeaterDatashow_Parameter(rptimage, "select ap.photoid,ap.albumid,a.albumtitle,ap.uploadphoto,a.albumdate from albumphoto ap inner join album a on a.albumid=ap.albumid where ap.albumid=@albumid order by ap.displayorder", parameters);
            }
        }
    }
}