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


public partial class backoffice_collage_viewcoursedetails : System.Web.UI.Page
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
            if (Conversion.Val((Request.QueryString["clid"])) > 0)
            {
                collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
                tr1.Visible = true;
                Parameters.Clear();
                Parameters.Add("@COLLAGEID", double.Parse(Request.QueryString["clid"]));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
            }
            else
            {
                collageid.Text = "0";
            }

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select distinct cm.levelname,cm.levelid from CourseLevel_Master cm inner join course c on cm.levelid=c.levelid  inner join CourseDetails cd on c.courseid=cd.courseid where cm.status=1 and c.status=1  ", Parameters, levelid);
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select distinct dm.dpname,dm.dpid from Discipline_Master dm inner join course c on dm.dpid=c.dpid  inner join CourseDetails cd on c.courseid=cd.courseid where dm.status=1 and c.status=1  ", Parameters, dpid);
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select distinct ct.ctypename,ct.ctid from coursetype ct inner join CourseDetails cd on ct.ctid=cd.ctid where ct.status=1", Parameters, ctid);

            
            gridshow();
            if ((Request.QueryString["edit"] == "edit"))
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }

        }

    }

  
  

    protected void gridshow()
    {
        string strsql;
        Parameters.Clear();
        Parameters.Add("@COLLAGEID", Conversion.Val(Request.QueryString["clid"]));
        strsql = @"select distinct c.coursename ,b.levelname,s.streamname,dp.DeptName,cm.collagename,dm.dpname,ct.ctypename,a.csid,a.status as s ,a.prospectus,a.colorcode,a.showonhome,a.showlab,a.displayorder from  course c  left  join CourseDetails a on c.courseid=a.courseid   left  join  CourseLevel_Master b on c.levelid=b.levelid left join stream_master s on c.streamid=s.streamid left join department_Master dp on c.deptid=dp.deptid left join collage_master cm on a.collegeid=cm.collageid left join coursetype ct on a.ctid=ct.ctid left join Discipline_Master dm on c.dpid=dm.dpid   where 1=1  and c.status=1 and a.collegeid=@COLLAGEID ";
        
        if (Conversion.Val(levelid.SelectedValue) > 0)
        {
            Parameters.Add("@levelid", Conversion.Val(levelid.SelectedValue));
            strsql += " and c.levelid=@levelid";
        }
        if (txtcourse.Text !="")
        {
            Parameters.Add("@coursename", txtcourse.Text);
            strsql += " and c.coursename like '%'+@coursename+'%'";
        }
        if (Conversion.Val(deptid.SelectedValue) > 0)
        {
            Parameters.Add("@deptid", Conversion.Val(deptid.SelectedValue));
            strsql += " and c.deptid =@deptid";
        }
        if (Conversion.Val(dpid.SelectedValue) > 0)
        {
            Parameters.Add("@dpid", Conversion.Val(dpid.SelectedValue));
            strsql += " and dm.dpid =@dpid";
        }
        if (Conversion.Val(ctid.SelectedValue) > 0)
        {
            Parameters.Add("@ctid", Conversion.Val(ctid.SelectedValue));
            strsql += " and a.ctid =@ctid";
        }

        
        clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
        appno = GridView1.Rows.Count;
        if ((GridView1.Rows.Count == 0))
        {
            Panel1.Visible = false;
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
        }
        else
        {
            Panel1.Visible = true;
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
                Parameters.Add("@csid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update CourseDetails set status=1 where csid=@csid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@csid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update CourseDetails set status=0 where csid=@csid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "btnedit"))
        {
            string strcollageid = String.Empty;
            if ((Conversion.Val(collageid.Text) > 0))
            {
                strcollageid = ("&clid=" + double.Parse(collageid.Text));
            }
            Response.Redirect("addcoursedetails.aspx?cid=" + e.CommandArgument + strcollageid);
        }

        if ((e.CommandName == "btndel"))
        {
            Parameters.Clear();
            Parameters.Add("@csid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from CourseDetails where csid=@csid", Parameters);
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
                Parameters.Add("@csid", Conversion.Val(e.CommandArgument));
                string strsql = "update CourseDetails set showonhome=1 where csid=@csid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            else if ((lblshowonhome.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@csid", Conversion.Val(e.CommandArgument));
                string strsql = "update CourseDetails set showonhome=0 where csid=@csid";
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
                Parameters.Add("@csid", Conversion.Val(e.CommandArgument));
                string strsql = "update CourseDetails set showlab=1 where csid=@csid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            else if ((lblapplyonline.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@csid", Conversion.Val(e.CommandArgument));
                string strsql = "update CourseDetails set showlab=0 where csid=@csid";
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
}