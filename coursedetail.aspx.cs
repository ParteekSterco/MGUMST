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

public partial class coursedetail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Conversion.Val(Request.QueryString["courseid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
            clsm.repeaterDatashow_Parameter(rptdetail, "select distinct c.*,cm.levelname from course c inner join Discipline_Master dm on dm.dpid=c.dpid inner join CourseLevel_Master cm on cm.levelid=c.levelid left join map_course_institute map on map.courseid=c.courseid where dm.status=1 and c.status=1 and c.courseid=@courseid ", parameters);

            parameters.Clear();
            parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
            clsm.repeaterDatashow_Parameter(rptfaculty, "select afm.*,d.DeptName,desig.designation[designationname] from Addfacultymaster afm inner join department_master d on d.deptid=afm.deptid inner join Facultydesignation desig on desig.fdid=afm.Designation inner join map_course_faculty map on map.fid=afm.facultyid where afm.status=1 and desig.status=1 and d.status=1 and map.courseid=@courseid order by afm.displayorder", parameters);
            if (rptfaculty.Items.Count > 0)
            {
                panelfaculty.Visible = true;
            }
        }
    }
    protected void rptdetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcourseid = (Literal)e.Item.FindControl("litcourseid");
            Literal litprospectus = (Literal)e.Item.FindControl("litprospectus");
            Literal litintership_prog = (Literal)e.Item.FindControl("litintership_prog");
            Literal litshortdesc = (Literal)e.Item.FindControl("litshortdesc");
            Literal lithighlights = (Literal)e.Item.FindControl("lithighlights");
            HtmlContainerControl downloadpanel = (HtmlContainerControl)e.Item.FindControl("downloadpanel");
            HtmlContainerControl paneltagline = (HtmlContainerControl)e.Item.FindControl("paneltagline");
            HtmlContainerControl panelcareer = (HtmlContainerControl)e.Item.FindControl("panelcareer");
            HtmlContainerControl paneloverview = (HtmlContainerControl)e.Item.FindControl("paneloverview");
            HtmlAnchor ankdownload = (HtmlAnchor)e.Item.FindControl("ankdownload");

            if (!string.IsNullOrEmpty(litprospectus.Text))
            {
                downloadpanel.Visible = true;
            }
            if (!string.IsNullOrEmpty(litintership_prog.Text))
            {
                paneltagline.Visible = true;
            }
            if (!string.IsNullOrEmpty(litshortdesc.Text))
            {
                paneloverview.Visible = true;
                rptdetail.Visible = true;
            }
            if (!string.IsNullOrEmpty(lithighlights.Text))
            {
                panelcareer.Visible = true;
            }
            ankdownload.HRef = "/Uploads/prospectus/" + litprospectus.Text;
        }
    }
    protected void rptfaculty_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfid = (Literal)e.Item.FindControl("litfid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "facultydetail.aspx?mpgid=35&pgidtrail=35&fid=" + Conversion.Val(litfid.Text);
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        if (Conversion.Val(Request.QueryString["courseid"]) > 0)
        {
            HtmlContainerControl panelcollage = (HtmlContainerControl)Master.FindControl("panelcollage");
            Literal littitle = (Literal)Master.FindControl("littitle");
            panelcollage.Visible = true;

            parameters.Clear();
            parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));

            littitle.Text = Convert.ToString(clsm.SendValue_Parameter("select coursename from course where status=1 and courseid=@courseid", parameters));
        }
    }
}