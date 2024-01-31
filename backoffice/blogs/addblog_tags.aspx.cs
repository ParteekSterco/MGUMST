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

public partial class backoffice_blogs_addblog_tags : System.Web.UI.Page
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
            if ((Conversion.Val(Request.QueryString["btid"]) > 0))
            {
                Parameters.Clear();
                Parameters.Add("@btid", double.Parse(Request.QueryString["btid"]));
                clsm.MoveRecord_Parameter(this, btid.Parent, "select * from blogtag where btid=@btid", Parameters);
            }
            gridshow();
        }
    }
    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                if (Convert.ToInt32(clsm.MasterSave(this, btid.Parent, 4, mainclass.Mode.modeCheckDuplicate, "blogtagSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Record already exist.";
                    return;
                }
                if (Conversion.Val(btid.Text) == 0)
                {
                    Status.Checked = true;
                    clsm.MasterSave(this, btid.Parent, 4, mainclass.Mode.modeAdd, "blogtagSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                    clsm.ClearallPanel(this, btid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {
                    clsm.MasterSave(this, btid.Parent, 4, mainclass.Mode.modeModify, "blogtagSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));
                    clsm.ClearallPanel(this, btid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }

        }

    }



    protected void gridshow()
    {
        try
        {
            Parameters.Clear();
            clsm.GridviewData_Parameter(GridView1, "select * from blogtag order by displayorder", Parameters);
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
            Response.Redirect(("addblog_tags.aspx?btid=" + e.CommandArgument));
        }

        if (e.CommandName == "status")
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@btid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update blogtag set status=1 where btid=@btid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@btid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update blogtag set status=0 where btid=@btid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if (e.CommandName == "del")
        {
            Parameters.Clear();
            Parameters.Add("@btid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from blogtag where btid=@btid", Parameters);
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
        Response.Redirect("addblog_tags.aspx");
    }
}