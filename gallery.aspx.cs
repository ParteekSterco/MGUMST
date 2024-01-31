using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class gallery : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptgallerytop, "select top 1 albumid,typeid,albumtitle,albumdate,uploadaimage from album where status=1 and typeid=1 order by albumdate desc,displayorder", parameters);

            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptgallery, "select albumid,typeid,albumtitle,albumdate,uploadaimage from album where status=1 and typeid=1 and albumid not in (" + Convert.ToString(ViewState["albumid"]) + ") order by albumdate desc,displayorder", parameters);
        if (rptgallery.Items.Count > 12)
        {
            panelloadmore.Visible = true;
        }

    }
    protected void rptgallerytop_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            Literal litalbumtitle = (Literal)e.Item.FindControl("litalbumtitle");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");


            ViewState["albumid"] = litalbumid.Text;
            ank.HRef = "/gallery-detail/" + clsm.replacestring(litalbumtitle.Text) + "/" + Conversion.Val(litalbumid.Text);

        }
    }
    protected void rptgallery_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            Literal litalbumtitle = (Literal)e.Item.FindControl("litalbumtitle");

            ank.HRef = "/gallery-detail/" + clsm.replacestring(litalbumtitle.Text) + "/" + Conversion.Val(litalbumid.Text);

        }
    }
}