using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class department : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["deptid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));                
                litdeptabout.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select departmentshortdetail from department_master where status=1 and deptid=@deptid ", parameters)));

                parameters.Clear();
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));                
                litmgu.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select departmentdetail from department_master where status=1 and deptid=@deptid ", parameters)));

                binddata();
                binddatadept();
                bindlist();

                a1.HRef = "/collage.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]);
                a2.HRef = "/department.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);

                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptevents, "select top 1 e.eventsid,eventstitle,eventsdate,ntypeid,shortdesc,uploadevents from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.ntypeid=2 and e.status=1 and map.showonhome=1 and map.collageid=@collageid and map.deptid=@deptid order by e.eventsdate desc", parameters);
                if (rptevents.Items.Count > 0)
                {
                    panelevents.Visible = true;
                }
                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptnews, "select top 4 e.eventsid,eventstitle,eventsdate,ntypeid,shortdesc,uploadevents from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.ntypeid=1 and e.status=1 and map.showonhome=1 and map.collageid=@collageid and map.deptid=@deptid order by e.eventsdate desc", parameters);
                if (rptnews.Items.Count > 0)
                {
                    panelnews.Visible = true;
                }
                if (rptevents.Items.Count > 0 || rptnews.Items.Count > 0)
                {
                    panelmain.Visible = true;
                }
                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptgallery, "select top 3 a.albumid,a.albumtitle,a.albumdesc,a.typeid,a.uploadaimage,a.albumdate from album a inner join map_photo_gallery map on map.albumid=a.Albumid where status=1 and map.collageid=@collageid and map.deptid=@deptid order by a.albumdate desc,a.displayorder", parameters);
                if (rptgallery.Items.Count > 0)
                {
                    panelgallery.Visible = true;
                }

                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(194));
                gallerytitle.Text = (Convert.ToString(clsm.SendValue_Parameter("select tagline from pagemaster where pageid=@pageid and pagestatus=1", parameters)));
            }
        }
    }
    private void bindlist()
    {
        parameters.Clear();
        parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        clsm.repeaterDatashow_Parameter(rptfaculty, "select afm.*,desig.designation [designationname],dept.DeptName [departmentname] from Addfacultymaster afm inner join map_institute_department_faculty map on map.facultyid=afm.facultyid inner join Facultydesignation desig on desig.fdid=afm.Designation inner join Department_Master dept on dept.deptid=afm.deptid where afm.status=1 and map.showonhome=1 and map.deptid=@deptid", parameters);
        if (rptfaculty.Items.Count > 0)
        {
            panelfaculty.Visible = true;
        }
    }
    private void binddatadept()
    {
        if (Conversion.Val(Request.QueryString["deptid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            littitlename.Text = Convert.ToString(clsm.SendValue_Parameter("select collagename from collage_master where status=1 and collageid=@collageid", parameters));

            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            litdeptname.Text = Convert.ToString(clsm.SendValue_Parameter("select deptname from Department_Master where status=1 and schoolid=@collageid and deptid=@deptid", parameters));
            if (!string.IsNullOrEmpty(litdeptname.Text))
            {
                paneldept.Visible = true;
            }

            parameters.Clear();
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            clsm.repeaterDatashow_Parameter(rptinnermenu, "select top 5  pageid,pagename,linkname,pageurl,rewriteurl,deptid from pagemasterdept where pagestatus=1 and  linkposition like'%Header%'  and deptid=@deptid ", parameters);
            if (rptinnermenu.Items.Count > 0)
            {
                ulinnermenu.Visible = true;
            }
            parameters.Clear();
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            double strpageno = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) from pagemasterdept where pagestatus=1 and  linkposition like'%Header%'  and deptid=@deptid ", parameters));
            if (strpageno > 5)
            {
                l1_menu.Visible = true;
            }
            binddropdownmenu();
        }
    }
    private void binddropdownmenu()
    {
        parameters.Clear();
        string sql = "select pageid,pagename,linkname,pageurl,rewriteurl,deptid from pagemasterdept where pagestatus=1  ";
        if (Conversion.Val(Request.QueryString["dept"]) > 0)
        {
            sql += " and linkposition like'%Header%'";
            sql += " and dept=" + Conversion.Val(Request.QueryString["dept"]);
        }
        else
        {
            sql += " and linkposition like'%Internal%'";

        }
        string strpageid = Convert.ToString(ViewState["pageid"]);
        strpageid = strpageid.TrimEnd(',');
        if (!string.IsNullOrEmpty(strpageid))
        {
            sql += " and pageid not in (" + strpageid + ")  order by displayorder";
            clsm.repeaterDatashow_Parameter(rptdropdownmenu, sql, parameters);
        }
    }
    private void binddata()
    {
        HttpContext context = HttpContext.Current;
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
            {
                parameters.Clear();
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from depthomebanner b inner join depthomebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.mobilestatus=1 and b.devicetype='mobile'  and b.deptid=@deptid  order by b.displayorder", parameters);
            }
            else
            {
                parameters.Clear();
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from depthomebanner b inner join depthomebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.status=1 and b.devicetype='desktop' and b.deptid=@deptid order by b.displayorder", parameters);
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
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
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
                    if (Conversion.Val(Request.QueryString["collageid"]) > 0)
                    {
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(litdeptid.Text);
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            if (Conversion.Val(litpageid.Text) == Conversion.Val(Request.QueryString["pgidtrail"]))
            {
                anchlink.Attributes.Add("class", "active");
            }
            ViewState["pageid"] += litpageid.Text + ",";
        }
    }
    protected void rptdropdownmenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
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
                    if (Conversion.Val(Request.QueryString["collageid"]) > 0)
                    {
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(litdeptid.Text);
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
        }
    }
    protected void rptevents_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            // ank.HRef = "/eventsdetail.aspx?mpgid=131&pgidtrail=131&eventsid=" + Conversion.Val(liteventsid.Text);
        }
    }
    protected void rptnews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/dept-news-detail.aspx?mpgid=3&pgidtrail=3&deptid=" + Conversion.Val(Request.QueryString["deptid"]) + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&eventsid=" + Conversion.Val(liteventsid.Text);

        }
    }
    protected void rptfaculty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfacultyid = (Literal)e.Item.FindControl("litfacultyid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/dept-facultydetail.aspx?mpgid=34&pgidtrail=35&deptid=" + Conversion.Val(Request.QueryString["deptid"]) + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&fid=" + Conversion.Val(litfacultyid.Text);
        }
    }
}