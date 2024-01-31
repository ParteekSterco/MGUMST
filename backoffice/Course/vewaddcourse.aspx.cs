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


public partial class backoffice_Course_vewaddcourse : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    HttpCookie AUserSession;
    public int appno;


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if ((Request.Cookies["AUserSession"] ==null))
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
            bindcollage();
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select levelname,levelid from CourseLevel_Master where status=1  order by displayorder", Parameters, levelid);
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select dpname,dpid from Discipline_Master where status=1  order by displayorder", Parameters, dpid);

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select distinct c.campus_name,c.campusid from  collage_master cm inner join  map_course_institute mci on cm.collageid=mci.collageid  left join  campus c  on c.campusid=cm.campusid", Parameters, campusid);

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select ctypename,ctid from coursetype  where status=1 order by displayorder", Parameters, ctid);
            bindstream();
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
        Parameters.Add("@collageid",Conversion.Val(collageid.SelectedValue));
        clsm.Fillcombo_Parameter("select distinct dm.DeptName,dm.deptid from Department_Master dm inner join course c on dm.deptid=c.deptid  where dm.status=1 and c.status=1 and c.collageid=@collageid order by dm.DeptName", Parameters, deptid);
    }

    public void bindcollage()
    {
        Parameters.Clear();
      //  Parameters.Add("@campusid", Conversion.Val(campusid.SelectedValue));
        clsm.Fillcombo_Parameter("select distinct collagename,collageid from collage_master where status=1 ", Parameters, collageid);
    }

    public void bindstream()
    {
        Parameters.Clear();
        Parameters.Add("@levelid",Conversion.Val(levelid.SelectedValue));
        clsm.Fillcombo_Parameter("select distinct streamname,streamid from stream_master where levelid=@levelid ", Parameters, streamid);
    }

    protected void gridshow()
    {
        string strsql;
        strsql = @"select distinct a.*,isnull(a.coursesecondname,'') as cname ,b.levelname,s.streamname,dp.DeptName,dm.dpname,ct.ctypename  from Course a left  join  CourseLevel_Master b on a.levelid=b.levelid left join  stream_master s on a.streamid=s.streamid left join department_Master dp on a.deptid=dp.deptid left join coursetype ct on a.ctid=ct.ctid left join Discipline_Master dm  on a.dpid=dm.dpid left join map_course_institute mci on  a.courseid=mci.courseid  left join  collage_master cm on mci.collageid=cm.collageid  left join campus c on c.campusid=cm.campusid   where 1=1 ";
        Parameters.Clear();
        if (Conversion.Val(levelid.SelectedValue) > 0)
        {
            Parameters.Add("@levelid", Conversion.Val(levelid.SelectedValue));
          strsql+=  " and a.levelid=@levelid";
        }
        if (txtcourse.Text != "")
        {
            Parameters.Add("@coursename", txtcourse.Text);
            strsql += " and a.coursename like '%'+@coursename+'%'";
        }
        if (Conversion.Val(collageid.SelectedValue) > 0)
        {
            Parameters.Add("@collageid", Conversion.Val(collageid.SelectedValue));
            strsql += " and mci.collageid =@collageid";
        }
        if (Conversion.Val(deptid.SelectedValue) > 0)
        {
            Parameters.Add("@deptid", Conversion.Val(deptid.SelectedValue));
            strsql += " and a.deptid =@deptid";
        }
        if (Conversion.Val(dpid.SelectedValue) > 0)
        {
            Parameters.Add("@dpid", Conversion.Val(dpid.SelectedValue));
            strsql += " and a.dpid =@dpid";
        }
        if (Conversion.Val(campusid.SelectedValue) > 0)
        {
            Parameters.Add("@campusid", Conversion.Val(campusid.SelectedValue));
            strsql += " and c.campusid=@campusid";
        }
        if (Conversion.Val(streamid.SelectedValue) > 0)
        {
            Parameters.Add("@streamid", Conversion.Val(streamid.SelectedValue));
            strsql += " and a.streamid=@streamid";
        }
        if (Conversion.Val(ctid.SelectedValue) > 0)
        {
            Parameters.Add("@ctid", Conversion.Val(ctid.SelectedValue));
            strsql += " and a.ctid=@ctid";
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
                Parameters.Add("@courseid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Course set status=1 where courseid=@courseid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@courseid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Course set status=0 where courseid=@courseid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }
        if ((e.CommandName == "btnedit"))
        {
            Response.Redirect(("addcourse.aspx?cid="
                            + (e.CommandArgument + "")));
        }
        if ((e.CommandName == "btndel"))
        {
            Parameters.Clear();
            Parameters.Add("@courseid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Course where courseid=@courseid", Parameters);
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            Label lbldown = (Label)row.FindControl("lbldown");
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(lbldown.Text)));
            if (F1.Exists)
            {
                F1.Delete();
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record deleted successfully.";
        }
        if ((e.CommandName == "lnkshowonhome"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            Label lblshowonhome = (Label)row.FindControl("lblshowonhome");
            if ((lblshowonhome.Text == "False"))
            {
                 Parameters.Clear();
                 Parameters.Add("@courseid", Conversion.Val(e.CommandArgument));
                string strsql = "update Course set showonhome=1 where courseid=@courseid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            else if ((lblshowonhome.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@courseid", Conversion.Val(e.CommandArgument));
                string strsql = "update Course set showonhome=0 where courseid=@courseid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }
        if ((e.CommandName == "lnkapplyonline"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            Label lblapplyonline = (Label)row.FindControl("lblapplyonline");
            if ((lblapplyonline.Text == "False"))
            {
                Parameters.Clear();
                Parameters.Add("@courseid", Conversion.Val(e.CommandArgument));
                string strsql = "update Course set showlab=1 where courseid=@courseid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            else if ((lblapplyonline.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@courseid", Conversion.Val(e.CommandArgument));
                string strsql = "update Course set showlab=0 where courseid=@courseid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Apply Online changed successfully.";
        }
        if ((e.CommandName == "downbtn"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            Label lbldown = (Label)row.FindControl("lbldown");
            Response.Redirect(("~/BackOffice/DownloadFile.aspx?D=~/Uploads/prospectus/" + Server.HtmlDecode(lbldown.Text)));
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
                Label lbldown = (Label)e.Row.FindControl("lbldown");
                LinkButton downbtn = (LinkButton)e.Row.FindControl("downbtn");
                TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
                ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
                Label lblshowonhome = (Label)e.Row.FindControl("lblshowonhome");
                HtmlInputText txtcolor = (HtmlInputText)e.Row.FindControl("txtcolor");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");

                ImageButton lnkapplyonline = (ImageButton)e.Row.FindControl("lnkapplyonline");
                Label lblapplyonline = (Label)e.Row.FindControl("lblapplyonline");

                if ((lblcolor.Text != ""))
                {
                    txtcolor.Style.Add("background", ("#" + lblcolor.Text));
                    txtcolor.Disabled = true;
                }
                else
                {
                    txtcolor.Disabled = true;
                    lblcolor.Visible = false;
                    txtcolor.Visible = false;
                }
                if ((lbldown.Text == ""))
                {
                    downbtn.Visible = false;
                }
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
                if ((lblshowonhome.Text == "True"))
                {
                    lnkshowonhome.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                    lnkshowonhome.ToolTip = "Yes";
                }
                else if ((lblshowonhome.Text == "False"))
                {
                    lnkshowonhome.ImageUrl = "~/Backoffice/assets/ico_block.png";
                    lnkshowonhome.ToolTip = "No";
                }
                if ((lblapplyonline.Text == "True"))
                {
                    lnkapplyonline.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                    lnkapplyonline.ToolTip = "Yes";
                }
                else if ((lblapplyonline.Text == "False"))
                {
                    lnkapplyonline.ImageUrl = "~/Backoffice/assets/ico_block.png";
                    lnkapplyonline.ToolTip = "No";
                }
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
        }
    }
    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        gridshow();
    }
    protected void campusid_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcollage();
    }
    protected void levelid_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindstream();
    }
}