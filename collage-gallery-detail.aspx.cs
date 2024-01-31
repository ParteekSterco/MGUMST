using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class collage_gallery_detail : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["collageid"]) > 0)
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
    protected void rptgallery_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litalbumtitle = (Literal)e.Item.FindControl("litalbumtitle");

            //ank.HRef = "/gallery-detail/" + clsm.replacestring(litalbumtitle.Text) + "/" + Conversion.Val(litalbumid.Text);

        }
    }
}