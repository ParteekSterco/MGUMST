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

public partial class usercontrols_mobilemenu : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptcourselevel, "select distinct cm.levelid,cm.levelname,cm.code,cm.rewrite_url,cm.displayorder from CourseLevel_Master cm inner join course c on c.levelid=cm.levelid where cm.status=1 and c.status=1 order by cm.displayorder", parameters);

            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptmobilemenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Footer%'  and collageid=0 order by displayorder", parameters);
    }
    protected void rptmobilemenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl ulinner = (HtmlContainerControl)e.Item.FindControl("ulinner");
            HtmlContainerControl l0 = (HtmlContainerControl)e.Item.FindControl("l0");
            Repeater rptinnermenu = (Repeater)e.Item.FindControl("rptinnermenu");
            Repeater rptcollage = (Repeater)e.Item.FindControl("rptcollage");

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
            if (Conversion.Val(litpageid.Text) == 33)
            {
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptcollage, "select collageid,collagename,rewrite_url from collage_master where status=1 order by displayorder", parameters);
                if (rptcollage.Items.Count > 0)
                {
                    ulinner.Visible = true;
                    rptcollage.Visible = true;
                    l0.Attributes.Add("class", "menu_item");
                    anchlink.HRef = "javascript:void(0)";
                }
            }
            else
            {
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(litpageid.Text));
                clsm.repeaterDatashow_Parameter(rptinnermenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid order by displayorder", parameters);
                if (rptinnermenu.Items.Count > 0)
                {
                    ulinner.Visible = true;
                    l0.Attributes.Add("class", "menu_item");
                    anchlink.HRef = "javascript:void(0)";
                }
            }
        }
    }
    protected void rptinnermenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlContainerControl l1 = (HtmlContainerControl)e.Item.FindControl("l1");
            HtmlContainerControl ul2 = (HtmlContainerControl)e.Item.FindControl("ul2");
            Repeater rptinner = (Repeater)e.Item.FindControl("rptinner");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

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
            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptinner, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid order by displayorder", parameters);
            if (rptinner.Items.Count > 0)
            {
                ul2.Visible = true;
                l1.Attributes.Add("class", "menu_item");
                anchlink.HRef = "javascript:void(0)";
            }
        }
    }
    protected void rptinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            HtmlContainerControl l2 = (HtmlContainerControl)e.Item.FindControl("l2");
            HtmlContainerControl ul4 = (HtmlContainerControl)e.Item.FindControl("ul4");
            Repeater rptmenu = (Repeater)e.Item.FindControl("rptmenu");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

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
            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(rptmenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid order by displayorder", parameters);
            if (rptmenu.Items.Count > 0)
            {
                ul4.Visible = true;
                l2.Attributes.Add("class", "menu_item");
                anchlink.HRef = "javascript:void(0)";
            }
        }
    }
    protected void rptcourselevel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewrite_url");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");


            if (!string.IsNullOrEmpty(litrewriteurl.Text))
            {
                anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
            }
            else
            {
                anchlink.HRef = "/course-list.aspx?mpgid=126&pgidtrail=126&levelid=" + Conversion.Val(litlevelid.Text);
            }
        }
    }
    protected void bindsearch(object sender, EventArgs e)
    {
        string courseid = Convert.ToString(clsm.SendValue_Parameter("select courseid from course where coursename like '%" + txtsearch.Text + "%'", parameters));

        if (!string.IsNullOrEmpty(courseid))
        {
            lblmsg.Text = "";
            Response.Redirect("/coursedetail.aspx?mpgid=126&pgidtrail=126&courseid=" + Conversion.Val(courseid));
        }
        else
        {
            lblmsg.Text = "Data not found";
        }
    }

    protected void rptcollage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/collage.aspx?collageid=" + Conversion.Val(litcollageid.Text);
        }

    }

}