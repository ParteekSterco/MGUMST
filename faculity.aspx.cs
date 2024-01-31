using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class faculity : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter("select designation,fdid from Facultydesignation where status=1 order by designation asc,displayorder", parameters, ddldesignation);
            ddldesignation.Items[0].Text = "Filter by designation";


            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptfaculity, "select afm.*,d.DeptName,desig.designation[designationname] from Addfacultymaster afm inner join department_master d on d.deptid=afm.deptid inner join Facultydesignation desig on desig.fdid=afm.Designation where afm.status=1 and desig.status=1 and d.status=1 order by afm.displayorder", parameters);
    }
    protected void rptfaculity_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfaculityid = (Literal)e.Item.FindControl("litfaculityid");
            Literal litfname = (Literal)e.Item.FindControl("litfname");
            Literal litshowonhome_school = (Literal)e.Item.FindControl("litshowonhome_school");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            if (Convert.ToBoolean(litshowonhome_school.Text) == true)
            {
                ank.HRef = "/faculty-detail/" + clsm.replacestring(litfname.Text) + "/" + Conversion.Val(litfaculityid.Text);
            }
        }
    }
    protected void btnsearch(object sender, EventArgs e)
    {
        string sql = "select afm.*,d.DeptName,desig.designation[designationname] from Addfacultymaster afm inner join department_master d on d.deptid=afm.deptid inner join Facultydesignation desig on desig.fdid=afm.Designation where afm.status=1 and desig.status=1 and d.status=1 ";

        if (!string.IsNullOrEmpty(txtname.Text))
        {
            sql += " and afm.fname like '%" + txtname.Text + "%'";
        }
        if (Conversion.Val(ddldesignation.SelectedValue) > 0)
        {
            sql += " and afm.designation=" + Conversion.Val(ddldesignation.SelectedValue);
        }
        sql += " order by afm.displayorder";

        clsm.repeaterDatashow_Parameter(rptfaculity, sql, parameters);

    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelcollage = (HtmlContainerControl)Master.FindControl("panelcollage");
        panelcollage.Visible = false;
    }
}