using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.HtmlControls;

public partial class backoffice_Course_addcoursesemester : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    public int appno;
    string StrFileName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            courseid.Text = Convert.ToInt32(Request.QueryString["courseid"]).ToString();

            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["mcsid"], out p) == true)
            {
                CKeditor1.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@mcsid", Convert.ToInt32(Request.QueryString["mcsid"]));
                clsm.MoveRecord_Parameter(this, mcsid.Parent, "Select * From coursesemester Where mcsid=@mcsid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(details.Text);
             
            }
            griddata();
            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Updated Successfully.";
            }


        }
    }
    protected void griddata()
    {
        Parameters.Clear();
        string strq2 = string.Empty;
        DataSet ds = new DataSet();
        strq2 = "select * from coursesemester where 1=1  ";
        if (Conversion.Val(Request.QueryString["courseid"]) > 0)
        {
            Parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
            strq2 += " and courseid=@courseid";
        }
        ds = clsm.senddataset_Parameter(strq2, Parameters);
        if (ds.Tables[0].Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "No Data";
            GridView1.Visible = false;
        }
        else
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            Parameters.Clear();
            Parameters.Add("@mcsid", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from coursesemester where mcsid=@mcsid", Parameters);
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@mcsid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update coursesemester set status=1 where mcsid=@mcsid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@mcsid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update coursesemester set status=0 where mcsid=@mcsid", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }
        if (e.CommandName == "btnedit")
        {
            Response.Redirect("addcoursesemester.aspx?courseid=" + Request.QueryString["courseid"] + "&mcsid=" + e.CommandArgument);
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

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            griddata();
        }
        catch (Exception ex)
        {
            //Label1.Visible = true;
            //Label1.Text = ex.Message.ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            details.Text = Server.HtmlEncode(CKeditor1.Text);
            CKeditor1.ReadOnly = true;
            if (string.IsNullOrEmpty(mcsid.Text))
            {
              
                CKeditor1.ReadOnly = true;
                string var = clsm.MasterSave(this, mcsid.Parent, 7, mainclass.Mode.modeAdd, "coursesemesterSp", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;


                clsm.ClearallPanel(this, mcsid.Parent);
                courseid.Text = Convert.ToInt32(Request.QueryString["courseid"]).ToString();
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            else
            {



                string var = clsm.MasterSave(this, mcsid.Parent,7, mainclass.Mode.modeModify, "coursesemesterSp", Convert.ToString(Session["UserId"]));

                Response.Redirect("addcoursesemester.aspx?courseid=" + Request.QueryString["courseid"] + "&edit=edit");

            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }
    
}