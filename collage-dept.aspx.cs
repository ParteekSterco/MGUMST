using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class collage_dept : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            clsm.repeaterDatashow_Parameter(rptcollage_dept, "select schoolid,deptid,DeptName,departmentdetail,displayname,banner from Department_Master where status=1 and schoolid=@collageid order by displayorder", parameters);
        }
    }
    protected void rptcollage_dept_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/department.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(litdeptid.Text);
        }
    }
}