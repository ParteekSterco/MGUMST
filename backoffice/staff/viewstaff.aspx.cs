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

public partial class backoffice_staff_viewstaff : System.Web.UI.Page
{
    HttpCookie AUserSession;
    mainclass clsm = new mainclass();
    public int appno;
    Hashtable Parameters = new Hashtable();


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Request.Cookies["AUserSession"] == null)
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
            facultytype();
            bind_college();
            bind_departments();
            binddesignation();

            //clsm.Fillcombo_Parameter("select distinct dm.DeptName,dm.deptid from Department_Master dm inner join addfacultymaster afm on afm.deptid=dm.deptid where dm.status=1 order by dm.DeptName ", Parameters, ddldepartement)
            //ddldepartement.Items.RemoveAt(0)
            //ddldepartement.Items.Insert(0, "-- Select Department --")
            gridshow();
            if ((Request.QueryString["edit"] == "edit"))
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }
        }
    }

    public void facultytype()
    {
        Parameters.Clear();
        string str_college = "  SELECT stafftype,sid FROM stafftype WHERE STATUS=1 ORDER BY DISPLAYORDER";
        clsm.Fillcombo_Parameter(str_college, Parameters, drpfacultytype);
    }


    public void binddesignation()
    {
        Parameters.Clear();
        string str_college = " SELECT designation,fdid FROM staffdesignation WHERE STATUS=1 ORDER BY DISPLAYORDER";
        clsm.Fillcombo_Parameter(str_college, Parameters, drpdesignation);
    }

    public void bind_college()
    {
        Parameters.Clear();
        string str_college = "SELECT distinct  c.COLLAGENAME,c.COLLAGEID FROM collage_master c left join map_staff_institute  mf  on  c.collageid=mf.collageid WHERE c.STATUS=1 ";
        clsm.Fillcombo_Parameter(str_college, Parameters, ddl_college);
    }

    public void bind_departments()
    {
        Parameters.Clear();
        string str_department = "SELECT d.deptname,d.deptid from Department_Master d join map_collage_departments mcd on d.deptid=mc";
        str_department += "d.deptid   where 1=1 ";
        if ((ddl_college.SelectedIndex != 0))
        {
            Parameters.Add("@collageid", double.Parse(ddl_college.SelectedValue));
            str_department += " and mcd.collageid=@collageid ";
        }

        clsm.Fillcombo_Parameter(str_department, Parameters, ddldepartement);
    }

    protected void ddl_college_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        bind_departments();
    }

    protected void gridshow()
    {
        string strsql;
        strsql = " select distinct a.*,fd.designation as staffdesignation,fty.stafftype from addstaffmaster a  left join staffdesignation fd on a.Designation=fd.fdid left join stafftype fty on a.sid=fty.sid left join map_staff_institute  mf  on  a.staffid=mf.staffid  where 1=1 ";
        Parameters.Clear();
        if ((faculty.Text.Trim() != ""))
        {
            Parameters.Add("@fname", faculty.Text);
            strsql += " and a.fname  like '%'+@fname+'%'";
        }
        if ((Conversion.Val(drpfacultytype.SelectedValue) > 0))
        {
            Parameters.Add("@ftype", double.Parse(drpfacultytype.SelectedValue));
            strsql += " and a.sid=@ftype";
        }
        if ((Conversion.Val(drpdesignation.SelectedValue) > 0))
        {
            Parameters.Add("@designation", double.Parse(drpdesignation.SelectedValue));
            strsql += " and a.designation =@designation";
        }
        if ((Conversion.Val(ddl_college.SelectedValue) > 0))
        {
            Parameters.Add("@collageid", double.Parse(ddl_college.SelectedValue));
            strsql += " and mf.collageid=@collageid";
        }

        if ((Conversion.Val(ddldepartement.SelectedValue) > 0))
        {
            Parameters.Add("@deptid", double.Parse(ddldepartement.SelectedValue));
            strsql += " and b.deptid =@deptid";
        }

        if (CheckBox1.Checked)
        {
            Parameters.Add("@showonhome_school", Conversion.Val(1));
            strsql += " and a.showonhome_school=@showonhome_school ";
        }
        if (CheckBox2.Checked)
        {
            Parameters.Add("@showonhome", Conversion.Val(1));
            strsql += " and  a.showonhome=@showonhome ";
        }
        if (txtqualification.Text.Trim() != "")
        {
            Parameters.Add("@qualification", txtqualification.Text);
            strsql += " and a.qualification  like '%'+@qualification+'%'";
        }
        if (txtspecialization.Text.Trim() != "")
        {
            Parameters.Add("@Specialization", txtspecialization.Text);
            strsql += " and a.Specialization  like '%'+@Specialization+'%'";
        }

        strsql += " order by a.displayorder";

        clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
        appno = GridView1.Rows.Count;
        if ((GridView1.Rows.Count == 0))
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
            btnexport.Visible = false;
        }
        else
        {
            // btnexport.Visible = true;
        }

    }

    protected void btnexport_Click(object sender, System.EventArgs e)
    {
        string strsql;
        strsql = "select    fname [Name],email [Email] from addstaffmaster   where 1=1";
        Parameters.Clear();
        if ((faculty.Text.Trim() != ""))
        {
            Parameters.Add("@fname", faculty.Text);
            strsql += " and fname  like \'%\'+@fname+\'%\'";
        }
        //if ((txtemail.Text.Trim() != ""))
        //{
        //    Parameters.Add("@email", txtemail.Text);
        //    strsql += " and email =@email";
        //}

        strsql += " order by displayorder ";
        DataSet dsdata = clsm.senddataset_Parameter(strsql, Parameters);
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("content-disposition", "attachment;filename=stafflist.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        DataSetToExcel.Convert(dsdata, Response);
        Response.Write(stringWrite.ToString());
        Response.Buffer = true;
        Response.End();
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
                Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Addstaffmaster set status=1 where staffid=@staffid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Addstaffmaster set status=0 where staffid=@staffid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "btnedit"))
        {
            Response.Redirect(("addstaff.aspx?fid="
                            + (Conversion.Val(e.CommandArgument) + "")));
        }

        if ((e.CommandName == "lnkshowonhome"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            Label lblshowonhome = (Label)row.FindControl("lblshowonhome");
            if ((lblshowonhome.Text == "False"))
            {
                Parameters.Clear();
                Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
                string strsql = "update Addstaffmaster set showonhome=1 where staffid=@staffid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            else if ((lblshowonhome.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
                string strsql = "update Addstaffmaster set showonhome=0 where staffid=@staffid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "lnkReputed"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            Label lblReputed = (Label)row.FindControl("lblReputed");
            if ((lblReputed.Text == "False"))
            {
                Parameters.Clear();
                Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
                string strsql = "update Addstaffmaster set showonhome_school=1 where staffid=@staffid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            else if ((lblReputed.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
                string strsql = "update Addstaffmaster set showonhome_school=0 where staffid=@staffid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "btndel"))
        {

            Parameters.Clear();
            Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
            string fimage = Convert.ToString(clsm.SendValue_Parameter("select fimage from Addstaffmaster where staffid=@staffid", Parameters));
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\staff\\" + fimage));
            if (F1.Exists)
            {
                F1.Delete();
            }

            Parameters.Clear();
            Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from map_institute_department_staff where staffid=@staffid", Parameters);



            Parameters.Clear();
            Parameters.Add("@staffid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Addstaffmaster where staffid=@staffid", Parameters);



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
            Label lblpass = (Label)e.Row.FindControl("lblpass");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
            ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
            Label lblshowonhome = (Label)e.Row.FindControl("lblshowonhome");
            ImageButton lnkReputed = (ImageButton)e.Row.FindControl("lnkReputed");
            Label lblReputed = (Label)e.Row.FindControl("lblReputed");


            TextBox txtfacultyImage = (TextBox)e.Row.FindControl("txtfacultyImage");
            HtmlImage imagefaculty = (HtmlImage)e.Row.FindControl("imagefaculty");

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




            if ((lblReputed.Text == "True"))
            {
                lnkReputed.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkReputed.ToolTip = "Yes";
            }
            else if ((lblReputed.Text == "False"))
            {
                lnkReputed.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkReputed.ToolTip = "No";
            }
            if ((txtfacultyImage.Text != ""))
            {
                imagefaculty.Src = ("~/Uploads/staff/" + txtfacultyImage.Text);
            }


            e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                            + (Server.HtmlDecode(Convert.ToString(Session["altColor"])) + "\'")));
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
        }

        // If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
        //     e.Row.Cells(6).Visible = False
        // End If
    }

    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        gridshow();
    }

    protected void btnupdate_Click(object sender, System.EventArgs e)
    {
        foreach (GridViewRow row1 in GridView1.Rows)
        {
            TextBox txtfacultyid = (TextBox)row1.FindControl("txtfacultyid");
            TextBox txtdsiplau = (TextBox)row1.FindControl("txtdsiplau");
            Parameters.Clear();
            clsm.ExecuteQry_Parameter("update  addstaffmaster  set  displayorder=" + Conversion.Val(txtdsiplau.Text) + " where staffid=" + Conversion.Val(txtfacultyid.Text) + "", Parameters);
        }
        trsuccess.Visible = true;
        lblsuccess.Text = "Record Update successfully.";
        gridshow();
        

    }
}