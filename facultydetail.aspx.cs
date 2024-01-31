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

public partial class facultydetail : System.Web.UI.Page
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
                clsm.repeaterDatashow_Parameter(rptdetail, "select afm.*,d.DeptName,desig.designation[designationname] from Addfacultymaster afm inner join department_master d on d.deptid=afm.deptid inner join Facultydesignation desig on desig.fdid=afm.Designation where afm.status=1 and desig.status=1 and d.status=1 and facultyid=@fid order by afm.displayorder", parameters);

                binddata();

            }
        }
    }
    private void binddata()
    {
        parameters.Clear();        
        string sql = "select afm.facultyid,fcate.facultycate,fcate.smalldesc from faculity_cate fcate inner join Addfacultymaster afm on fcate.faulityid=afm.facultyid where afm.status=1 and fcate.status=1 ";

        if (Conversion.Val(Request.QueryString["fid"]) > 0)
        {
            parameters.Add("@fid", Conversion.Val(Request.QueryString["fid"]));
            sql += "  and afm.facultyid=@fid";
        }
        sql += " order by afm.displayorder";
        clsm.repeaterDatashow_Parameter(rptcategorylist, sql, parameters);
        clsm.repeaterDatashow_Parameter(rptcategorydetail, sql, parameters);
        if (rptcategorylist.Items.Count > 0)
        {
            panelcategory.Visible = true;
        }        
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        HtmlContainerControl panelcollage = (HtmlContainerControl)Master.FindControl("panelcollage");
        panelcollage.Visible = false;
    }
    protected void rptcategorylist_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfacultyid = (Literal)e.Item.FindControl("litfacultyid");
            HtmlButton btn1 = (HtmlButton)e.Item.FindControl("btn1");

            if (e.Item.ItemIndex == 0)
            {
                btn1.Attributes.Add("class", "nav-link active");
                btn1.Attributes.Add("aria-selected", "true");
            }
            else
            {
                btn1.Attributes.Add("class", "nav-link");
                btn1.Attributes.Add("aria-selected", "false");
            }
            btn1.Attributes.Add("data-bs-target", ".tab-pane01" + (e.Item.ItemIndex + 1));
        }
    }
    protected void rptcategorydetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litfacultyid = (Literal)e.Item.FindControl("litfacultyid");
            HtmlButton btn1 = (HtmlButton)e.Item.FindControl("btn1");
            HtmlContainerControl panel1 = (HtmlContainerControl)e.Item.FindControl("panel1");
            HtmlContainerControl panel2 = (HtmlContainerControl)e.Item.FindControl("panel2");

            if (e.Item.ItemIndex == 0)
            {
                panel1.Attributes.Add("class", "tab-pane fade accordion-item active show tab-pane01" + (e.Item.ItemIndex + 1));
                btn1.Attributes.Add("aria-selected", "true");
                btn1.Attributes.Add("class", "accordion-button");
                panel2.Attributes.Add("class", "accordion-collapse collapse d-lg-block collapse-01" + Conversion.Val(litfacultyid.Text) + (e.Item.ItemIndex + 1));
            }
            else
            {
                panel1.Attributes.Add("class", "tab-pane fade accordion-item tab-pane01" + (e.Item.ItemIndex + 1));
                btn1.Attributes.Add("aria-selected", "false");
                btn1.Attributes.Add("class", "accordion-button collapsed");
                panel2.Attributes.Add("class", "accordion-collapse collapsed d-lg-block collapse-01" + Conversion.Val(litfacultyid.Text) + (e.Item.ItemIndex + 1));
            }

            btn1.Attributes.Add("data-bs-target", ".collapse-01" + Conversion.Val(litfacultyid.Text) + (e.Item.ItemIndex + 1));
        }
    }
}