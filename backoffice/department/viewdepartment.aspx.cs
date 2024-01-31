using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.IO;
using System.Data;

public partial class backoffice_department_viewdepartment : System.Web.UI.Page
{
    public int appno;
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }
        if (!IsPostBack)
        {
            Parameters.Clear();
            //clsm.Fillcombo_Parameter("select campus_name,campusid from campus  where status=1 order by displayorder", Parameters, campusid);
           
           // campusid.Items[0].Text = "Select Campus";
           
            bindcollage();

            gridshow();
            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }

        }

    }
 
    public void bindcollage()
    {
        Parameters.Clear();
        string str_college = "select distinct cm.collagename,collageid from collage_master cm  left join  campus c on cm.campusid=c.campusid inner join Department_Master dm on cm.collageid=dm.schoolid left outer join department_management dm1 on dm1.deptid=dm.deptid where cm.status=1  ";
        if (Conversion.Val(campusid.SelectedValue) > 0)
        {
            Parameters.Add("@campusid", Conversion.Val(campusid.SelectedValue));
            str_college += " and cm.campusid=@campusid";
        }
        if (Conversion.Val(AUserSession["Roleid"]) != 1)
        {
            str_college += " and isnull(dm1.roleid,0)=" + Conversion.Val(AUserSession["Roleid"]) + "";
        }
        str_college += " order by collagename";
        clsm.Fillcombo_Parameter(str_college, Parameters, ddl_college);
    }



    public void gridshow()
    {
        string str_list = "";
        Parameters.Clear();
        str_list = "select distinct d.*,cm.collagename from Department_Master d inner join  collage_master cm on d.schoolid=cm.collageid left join  campus c on cm.campusid=c.campusid left outer join department_management dm on dm.deptid=d.deptid where 1=1";

        if (Conversion.Val(campusid.SelectedValue) > 0)
        {
            Parameters.Add("@campusid", Conversion.Val(campusid.SelectedValue));
            str_list += " and cm.campusid=@campusid";
        }
        
        if (ddl_college.SelectedValue != "0")
        {
            Parameters.Add("@collageid", Conversion.Val(ddl_college.SelectedValue));
            str_list += "  and d.schoolid=@collageid";
        }
        if (deptname.Text != "")
        {
            Parameters.Add("@DeptName", deptname.Text);
            str_list += " and d.DeptName like '%'+@DeptName+'%'";
        }
        if (Conversion.Val(AUserSession["Roleid"]) != 1)
        {
            str_list += " and isnull(dm.roleid,0)=" + Conversion.Val(AUserSession["Roleid"]) + "";
        }
        
        str_list += "  order by d.displayorder ";


        clsm.GridviewData_Parameter(GridView1, str_list, Parameters);
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridshow(); ;
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "redit")
        {
            Response.Redirect("departments.aspx?id=" + Conversion.Val(e.CommandArgument));
        }
        if (e.CommandName == "lnkstatus")
        {


            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");

            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@deptid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Department_Master set status=1 where deptid=@deptid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {

                Parameters.Clear();
                Parameters.Add("@deptid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Department_Master set status=0 where deptid=@deptid", Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
            gridshow();

        }


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
            if (txtstatus.Text == "True")
            {

                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Server.HtmlDecode(Convert.ToString(Session["altColor"])) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

        }
    }


    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        gridshow();
    }

    
}