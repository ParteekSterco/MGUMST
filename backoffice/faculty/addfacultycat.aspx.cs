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


public partial class backoffice_faculty_addfacultycat : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public int appno;
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        trerror.Visible = false;
        trnotice.Visible = false;
        trsuccess.Visible = false;
        if ((Page.IsPostBack == false))
        {
            faulityid.Text = Convert.ToInt32(Request.QueryString["facultyid"]).ToString();


            if ((Conversion.Val(Request.QueryString["fid"]) > 0))
            {
                CKeditor1.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@fid", double.Parse(Request.QueryString["fid"]));
                clsm.MoveRecord_Parameter(this, fid.Parent, "select * from faculity_cate where fid=@fid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(smalldesc.Text);
            }
            gridshow();
        }
    }
    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        try
        {
            smalldesc.Text = Server.HtmlEncode(CKeditor1.Text);
            CKeditor1.ReadOnly = true;
            //if (Convert.ToInt32(clsm.MasterSave(this, fid.Parent, 6, mainclass.Mode.modeCheckDuplicate, "facultycateSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
            //{
            //    trnotice.Visible = true;
            //    lblnotice.Text = "This faculty Category already exist.";
            //    return;
            //}
            if (Conversion.Val(fid.Text) == 0)
            {

                Status.Checked = true;
                clsm.MasterSave(this, fid.Parent, 6, mainclass.Mode.modeAdd, "facultycateSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                clsm.ClearallPanel(this, fid.Parent);

                gridshow();
                trsuccess.Visible = true;
                faulityid.Text = Convert.ToString(Request.QueryString["facultyid"]);
                lblsuccess.Text = "Record added successfully.";
            }
            else
            {

                clsm.MasterSave(this, fid.Parent, 6, mainclass.Mode.modeModify, "facultycateSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                clsm.ClearallPanel(this, fid.Parent);

                gridshow();
                trsuccess.Visible = true;
                faulityid.Text = Convert.ToString(Request.QueryString["facultyid"]);
                lblsuccess.Text = "Record updated successfully.";
            }
            CKeditor1.ReadOnly = false;
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }

    }
    protected void gridshow()
    {
        try
        {
            Parameters.Clear();
            string strq2 = "select * from faculity_cate where 1=1 ";
            if (Conversion.Val(Request.QueryString["facultyid"]) > 0)
            {
                strq2 += " and faulityid=" + Conversion.Val(Request.QueryString["facultyid"]);
            }
            strq2 += " order by displayorder";
            clsm.GridviewData_Parameter(GridView1, strq2, Parameters);
            appno = GridView1.Rows.Count;
            if ((GridView1.Rows.Count == 0))
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Record found.";
            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Response.Redirect(("addfacultycat.aspx?fid=" + e.CommandArgument + "&facultyid=" + Conversion.Val(Request.QueryString["facultyid"])));
        }

        if (e.CommandName == "status")
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@fid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update faculity_cate set status=1 where fid=@fid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@fid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update faculity_cate set status=0 where fid=@fid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if (e.CommandName == "del")
        {
            Parameters.Clear();
            Parameters.Add("@fid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from faculity_cate where fid=@fid", Parameters);
            gridshow();
            trnotice.Visible = true;
            lblnotice.Text = "Record deleted successfully.";
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");


            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                lnkstatus.ToolTip = "Yes";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "../assets/ico_block.png";
                lnkstatus.ToolTip = "No";
            }
        }

    }

    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        clsm.ClearallPanel(this, fid.Parent);
    }

}