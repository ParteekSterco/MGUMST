using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class dept_facultydetail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["fid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@fid", Conversion.Val(Request.QueryString["fid"]));
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptdetail, "select afm.*,d.DeptName,desig.designation[designationname] from Addfacultymaster afm inner join department_master d on d.deptid=afm.deptid inner join Facultydesignation desig on desig.fdid=afm.Designation where afm.status=1 and desig.status=1 and d.status=1 and facultyid=@fid and d.deptid=@deptid order by afm.displayorder", parameters);
            }
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelcollage = (HtmlContainerControl)Master.FindControl("panelcollage");
        panelcollage.Visible = false;
    }
}