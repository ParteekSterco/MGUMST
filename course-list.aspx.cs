using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class course_list : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptcourselevel, "select levelid,levelname,code,tagname from courselevel_master where status=1 order by displayorder", parameters);

            parameters.Clear();
            clsm.repeaterDatashow_Parameter(rptcollage, "select collageid,collagename,displayname from collage_master where status=1 order by displayorder", parameters);

            if (Conversion.Val(Request.QueryString["levelid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@levelid", Conversion.Val(Request.QueryString["levelid"]));
                litlevelname.Text = Convert.ToString(clsm.SendValue_Parameter("select tagname from courselevel_master where levelid=@levelid", parameters));
            }

            bindcourse();
        }
    }
    private void bindcourse()
    {
        parameters.Clear();

        string sql = "select distinct dm.* from course c inner join Discipline_Master dm on dm.dpid=c.dpid inner join CourseLevel_Master cm on cm.levelid=c.levelid left join map_course_institute map on map.courseid=c.courseid where dm.status=1 and c.status=1 ";
        if (Conversion.Val(Request.QueryString["levelid"]) > 0)
        {
            sql += " and c.levelid=" + Conversion.Val(Request.QueryString["levelid"]);
        }
        if (Conversion.Val(Request.QueryString["collageid"]) > 0)
        {
            sql += " and map.collageid=" + Conversion.Val(Request.QueryString["collageid"]);
        }
        sql += " order by dm.displayorder";        
        clsm.repeaterDatashow_Parameter(rptcourselist, sql, parameters);

    }
    protected void rptcourselevel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            HtmlContainerControl l1 = (HtmlContainerControl)e.Item.FindControl("l1");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            

            if (Conversion.Val(Request.QueryString["levelid"]) == Conversion.Val(litlevelid.Text))
            {
                l1.Attributes.Add("class", "active");
            }

            if (Conversion.Val(Request.QueryString["collageid"]) > 0)
            {
                ank.HRef = "/course-list.aspx?mpgid=126&pgidtrail=126&levelid=" + Conversion.Val(litlevelid.Text) + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]);
            }
            else
            {
                ank.HRef = "/course-list.aspx?mpgid=126&pgidtrail=126&levelid=" + Conversion.Val(litlevelid.Text);
            }
            
             
        }
    }

    protected void rptcollage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
            HtmlContainerControl l1 = (HtmlContainerControl)e.Item.FindControl("l1");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            if (Conversion.Val(Request.QueryString["collageid"]) == Conversion.Val(litcollageid.Text))
            {
                l1.Attributes.Add("class", "active");
            }
            ank.HRef = "/course-list.aspx?mpgid=126&pgidtrail=126&levelid=" + Conversion.Val(Request.QueryString["levelid"]) + "&collageid=" + Conversion.Val(litcollageid.Text);

            

        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl ulinnermenu = (HtmlContainerControl)Master.FindControl("ulinnermenu");
        HtmlContainerControl panelinnermenu = (HtmlContainerControl)Master.FindControl("panelinnermenu");

        ulinnermenu.Visible = false;
        panelinnermenu.Visible = false;
    }

    protected void rptcourselist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litdpid = (Literal)e.Item.FindControl("litdpid");
            Repeater rptinner = (Repeater)e.Item.FindControl("rptinner");
            Literal litlevelname = (Literal)e.Item.FindControl("litlevelname");

            parameters.Clear();
            parameters.Add("@dpid", Conversion.Val(litdpid.Text));
            string sql = "select distinct c.*,cm.levelname from course c inner join Discipline_Master dm on dm.dpid=c.dpid inner join CourseLevel_Master cm on cm.levelid=c.levelid left join map_course_institute map on map.courseid=c.courseid where dm.status=1 and c.status=1 ";
            if (Conversion.Val(Request.QueryString["levelid"]) > 0)
            {
                sql += " and c.levelid=" + Conversion.Val(Request.QueryString["levelid"]);
            }
            if (Conversion.Val(Request.QueryString["collageid"]) > 0)
            {
                sql += " and map.collageid=" + Conversion.Val(Request.QueryString["collageid"]);
            }
            sql += " and c.dpid=" + Conversion.Val(litdpid.Text);
            sql += " order by c.displayorder";

            clsm.repeaterDatashow_Parameter(rptinner, sql, parameters);

            if (Conversion.Val(Request.QueryString["levelid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@levelid", Conversion.Val(Request.QueryString["levelid"]));
                litlevelname.Text = Convert.ToString(clsm.SendValue_Parameter("select levelname from courselevel_master where levelid=@levelid", parameters));
            }

        }
    }
    protected void rptinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litdpid = (Literal)e.Item.FindControl("litdpid");
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            Literal litcourseid = (Literal)e.Item.FindControl("litcourseid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlAnchor ank1 = (HtmlAnchor)e.Item.FindControl("ank1");
            HtmlAnchor ank2 = (HtmlAnchor)e.Item.FindControl("ank2");

            ank.HRef = "javascript:void(0)";
            ank1.HRef = "javascript:void(0)";

            ank2.HRef = "/coursedetail.aspx?mpgid=126&pgidtrail=126&courseid=" + Conversion.Val(litcourseid.Text);
        }
    }
}