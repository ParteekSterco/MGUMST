using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class usercontrols_hamburger : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptfirstpanel, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Panel 1%'  and collageid=0 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptsecondpanel, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Panel 2%'  and collageid=0 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptthirdpanel, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Panel 3%'  and collageid=0 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptfourpanel, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Panel 4%'  and collageid=0 order by displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptfivepanel, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Panel 5%'  and collageid=0 order by displayorder", parameters);
    }
    protected void rptfirstpanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Repeater rptinnerfirst = (Repeater)e.Item.FindControl("rptinnerfirst");


            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptinnerfirst, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,uploadfile,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);
        }
    }
    protected void rptinnerfirst_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            if (string.IsNullOrEmpty(lituploadfile.Text))
            {
                if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
                {
                    anchlink.HRef = litpageurl.Text;
                    anchlink.Target = "_blank";
                }
                else
                {
                    if (!string.IsNullOrEmpty(litrewriteurl.Text))
                    {
                        anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
        }
    }

    protected void rptsecondpanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Repeater rptinnersecond = (Repeater)e.Item.FindControl("rptinnersecond");


            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptinnersecond, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);
        }
    }
    protected void rptinnersecond_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");

            if (string.IsNullOrEmpty(lituploadfile.Text))
            {
                if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
                {
                    anchlink.HRef = litpageurl.Text;
                    anchlink.Target = "_blank";
                }
                else
                {
                    if (!string.IsNullOrEmpty(litrewriteurl.Text))
                    {
                        anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
        }
    }

    protected void rptthirdpanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Repeater rptinnerthird = (Repeater)e.Item.FindControl("rptinnerthird");
            Repeater rptcollage = (Repeater)e.Item.FindControl("rptcollage");

            if (Conversion.Val(litpageid.Text) == 33)
            {
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptcollage, "select collageid,collagename,displayname,rewrite_url from collage_master where status=1 order by displayorder", parameters);
                rptcollage.Visible = true;
            }
            else
            {
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(litpageid.Text));
                clsm.repeaterDatashow_Parameter(rptinnerthird, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);
                
            }


        }
    }
    protected void rptinnerthrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");

            if (string.IsNullOrEmpty(lituploadfile.Text))
            {
                if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
                {
                    anchlink.HRef = litpageurl.Text;
                    anchlink.Target = "_blank";
                }
                else
                {
                    if (!string.IsNullOrEmpty(litrewriteurl.Text))
                    {
                        anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
        }
    }
    protected void rptcollage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            anchlink.HRef = "/collage.aspx?collageid=" + Conversion.Val(litcollageid.Text);
        }

    }
    protected void rptfourpanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Repeater rptinnerfour = (Repeater)e.Item.FindControl("rptinnerfour");


            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptinnerfour, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);
        }
    }
    protected void rptinnerfour_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");

            if (string.IsNullOrEmpty(lituploadfile.Text))
            {
                if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
                {
                    anchlink.HRef = litpageurl.Text;
                    anchlink.Target = "_blank";
                }
                else
                {
                    if (!string.IsNullOrEmpty(litrewriteurl.Text))
                    {
                        anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
        }
    }
    protected void rptfivepanel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Repeater rptinnerfive = (Repeater)e.Item.FindControl("rptinnerfive");


            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptinnerfive, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);
        }
    }
    protected void rptinnerfive_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");

            if (string.IsNullOrEmpty(lituploadfile.Text))
            {
                if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
                {
                    anchlink.HRef = litpageurl.Text;
                    anchlink.Target = "_blank";
                }
                else
                {
                    if (!string.IsNullOrEmpty(litrewriteurl.Text))
                    {
                        anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
        }
    }
}