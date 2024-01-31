using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class collage : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["collageid"]) > 0)
            {

                parameters.Clear();
                clsm.Fillcombo_Parameter("select levelname,levelid from courselevel_master where status=1 order by displayorder", parameters, ddlprogramtype);
                ddlprogramtype.Items[0].Text = "Select Program Type";

                binddatacollage();
                binddata();


                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                litcollagename.Text = Convert.ToString(clsm.SendValue_Parameter("select collagename from collage_master where status=1 and collageid=@collageid", parameters));

                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                litwelcome.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select collageshortdescp from collage_master where status=1 and collageid=@collageid", parameters)));

                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                litmgu.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select collagedescp from collage_master where status=1 and collageid=@collageid", parameters)));

                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                clsm.repeaterDatashow_Parameter(rptdept, "select top 6 deptid,DeptName,banner,departmentdetail,departmentshortdetail from Department_Master where status=1 and schoolid=@collageid order by displayorder", parameters);
                if (rptdept.Items.Count > 0)
                {
                    paneldept.Visible = true;
                }
                if (rptdept.Items.Count >= 6)
                {
                    loadmore.Visible = true;
                    ankdept.HRef = "/collage-dept.aspx?mpgid=151&pgidtrail=151&collageid=" + Conversion.Val(Request.QueryString["collageid"]);
                }
                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                clsm.repeaterDatashow_Parameter(rptevents, "select top 1 e.eventsid,eventstitle,eventsdate,ntypeid,shortdesc,uploadevents from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.ntypeid=2 and e.status=1 and map.showonhome=1 and map.collageid=@collageid order by e.eventsdate desc", parameters);
                if (rptevents.Items.Count > 0)
                {
                    panelevents.Visible = true;
                }

                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                clsm.repeaterDatashow_Parameter(rptnews, "select top 4 e.eventsid,eventstitle,eventsdate,ntypeid,shortdesc,uploadevents from events e inner join map_institute_happenings map on map.eventsid=e.Eventsid where e.ntypeid=1 and e.status=1 and map.showonhome=1 and map.collageid=@collageid order by e.eventsdate desc", parameters);
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
                clsm.repeaterDatashow_Parameter(rptgallery, "select top 3 a.albumid,a.albumtitle,a.albumdesc,a.typeid,a.uploadaimage,a.albumdate from album a inner join map_photo_gallery map on map.albumid=a.Albumid where status=1 and map.collageid=@collageid order by a.albumdate desc,a.displayorder", parameters);
                if (rptgallery.Items.Count > 0)
                {
                    panelgallery.Visible = true;
                }

                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(194));
                gallerytitle.Text = (Convert.ToString(clsm.SendValue_Parameter("select tagline from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

                ank.HRef = "/collage-gallery.aspx?mpgid=194&pgidtrail=194&collageid=" + Conversion.Val(Request.QueryString["collageid"]);
                a1.HRef = "/collage.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]);
            }
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
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from homebanner b inner join homebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.mobilestatus=1 and b.devicetype='mobile'  and b.collageid=@collageid  order by b.displayorder", parameters);
            }
            else
            {
                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                clsm.repeaterDatashow_Parameter(rptbanner, "Select b.bannerimage,b.title,b.tagline1,b.tagline2,b.url,b.displayorder,b.bid,b.bannermobile,b.blogo,btype.btype from homebanner b inner join homebannertype btype on btype.btypeid=b.btypeid where b.status=1 and btype.status=1 and b.devicetype='desktop'  and b.collageid=@collageid order by b.displayorder", parameters);
            }
        }

    }
    private void binddatacollage()
    {
        if (Conversion.Val(Request.QueryString["collageid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            littitlename.Text = Convert.ToString(clsm.SendValue_Parameter("select collagename from collage_master where status=1 and collageid=@collageid", parameters));

            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            clsm.repeaterDatashow_Parameter(rptinnermenu, "select top 5  pageid,pagename,linkname,pageurl,rewriteurl,collageid from pagemaster where pagestatus=1 and  linkposition like'%Header%'  and collageid=@collageid order by displayorder ", parameters);
            if (rptinnermenu.Items.Count > 0)
            {
                panelinnermenu.Visible = true;
                ulinnermenu.Visible = true;
            }
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            double strpageno = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) from pagemaster where pagestatus=1 and  linkposition like'%Header%'  and collageid=@collageid ", parameters));
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
        string sql = "select pageid,pagename,linkname,pageurl,rewriteurl,collageid from pagemaster where pagestatus=1  ";
        if (Conversion.Val(Request.QueryString["collageid"]) > 0)
        {
            sql += " and linkposition like'%Header%'";
            sql += " and collageid=" + Conversion.Val(Request.QueryString["collageid"]);
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
    protected void rptinnermenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
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
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(litcollageid.Text);
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
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
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
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(litcollageid.Text);
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }

        }
    }

    protected void rptdept_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/department.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(litdeptid.Text);
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

            ank.HRef = "/collage-news-detail.aspx?mpgid=145&pgidtrail=145&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&eventsid=" + Conversion.Val(liteventsid.Text);

        }
    }

    #region Searching
    protected void course_click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(coursesearch.Text))
        {
            parameters.Clear();
            parameters.Add("@coursename", coursesearch.Text.Trim());
            string sql = "select distinct c.coursename,c.courseid,cm.collegetype,cm.cmpgid,cm.cpgidtrail,cm.collageid from course c left join collage_master cm on  c.collageid=cm.collageid  where 1=1 and c.coursename like '%'+@coursename+'%'  ";
            DataSet ds = clsm.senddataset_Parameter(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                string courseid = Convert.ToString(ds.Tables[0].Rows[0]["courseid"]);
                string collegetype = Convert.ToString(ds.Tables[0].Rows[0]["collegetype"]);
                string cmpgid = Convert.ToString(ds.Tables[0].Rows[0]["cmpgid"]);
                string cpgidtrail = Convert.ToString(ds.Tables[0].Rows[0]["cpgidtrail"]);
                string collageid = Convert.ToString(ds.Tables[0].Rows[0]["collageid"]);

                string qry = "/collage-coursedetail.aspx?mpgid=192&pgidtrail=192&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&courseid=" + Conversion.Val(courseid);
                Response.Redirect(qry);
            }
        }
    }
    [WebMethod]
    public static string GetGraduateCourse(string prefixText)
    {

        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        parameters.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "searchcourseSP";
        cmd.Parameters.AddWithValue("@coursename", Convert.ToString(prefixText));
        cmd.Parameters.AddWithValue("@levelid", 0);
        return GetData(cmd).GetXml();
    }
    private static DataSet GetData(SqlCommand cmd)
    {
        mainclass clsm = new mainclass();
        string strconnect = clsm.strconnect;
        using (SqlConnection con = new SqlConnection(strconnect))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "Customers");
                    return ds;
                }
            }
        }
    }

    #endregion
}