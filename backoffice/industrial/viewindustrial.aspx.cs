using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;
public partial class backoffice_industrial_viewindustrial : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    HttpCookie AUserSession;
    public int appno;


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if ((Request.Cookies["AUserSession"] == null))
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if ((Page.IsPostBack == false))
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", Parameters, collageid);

            //Parameters.Clear();
            //clsm.Fillcombo_Parameter("select levelname,levelid from CourseLevel_Master where status=1  order by displayorder", Parameters, levelid);

            binddepartment();
            gridshow();
            if ((Request.QueryString["edit"] == "edit"))
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }

        }

    }

    protected void collageid_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddepartment();
    }

    public void binddepartment()
    {
        Parameters.Clear();
        Parameters.Add("@collageid", Conversion.Val(collageid.SelectedValue));
        clsm.Fillcombo_Parameter("select distinct dm.DeptName,dm.deptid from Department_Master dm inner join course c on dm.deptid=c.deptid  where dm.status=1 and c.status=1 and c.collageid=@collageid order by dm.DeptName", Parameters, deptid);
        // clsm.Fillcombo_Parameter("select DeptName,deptid from department_Master where status=1 order by displayorder", Parameters, deptid);

    }

    protected void gridshow()
    {
        string strsql;
        strsql = @" select distinct a.*,b.indcattitle,dp.DeptName,cm.collagename  from Industrial a left  join  industrialcategory b on a.lcid=b.lcid  left join department_Master dp on a.deptid=dp.deptid left join collage_master cm on a.collageid=cm.collageid  where 1=1 ";
        Parameters.Clear();


        if (Conversion.Val(collageid.SelectedValue) > 0)
        {
            Parameters.Add("@collageid", Conversion.Val(collageid.SelectedValue));
            strsql += " and a.collageid =@collageid";
        }

        if (Conversion.Val(deptid.SelectedValue) > 0)
        {
            Parameters.Add("@deptid", Conversion.Val(deptid.SelectedValue));
            strsql += " and a.deptid =@deptid";
        }

        strsql += " order by  a.displayorder ";
        clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
        appno = GridView1.Rows.Count;
        if ((GridView1.Rows.Count == 0))
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
        }
        else
        {
            // btnexport.Visible = True
        }

    }


    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "lnkstatus"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if ((txtstatus.Text == "False"))
            {
                Parameters.Clear();
                Parameters.Add("@indid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Industrial set status=1 where indid=@indid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@indid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Industrial set status=0 where indid=@indid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "btnedit"))
        {
            Response.Redirect(("addindustrial.aspx?indid="
                            + (e.CommandArgument + "")));
        }

        if ((e.CommandName == "btndel"))
        {
            Parameters.Clear();
            Parameters.Add("@indid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Industrial where indid=@indid", Parameters);
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record deleted successfully.";
        }

    }

    protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridshow();
        }
        catch (Exception ex)
        {

        }

    }

    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

            if ((txtstatus.Text == "True"))
            {
                lnkstatus.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Yes";
            }
            else if ((txtstatus.Text == "False"))
            {
                lnkstatus.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkstatus.ToolTip = "No";
            }

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");

        }

    }

    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        gridshow();
    }
}