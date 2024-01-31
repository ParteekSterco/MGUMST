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

public partial class backoffice_awards_viewawards : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    public int appno;


    protected void Page_Load(object sender, System.EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!Page.IsPostBack)
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", Parameters, drpSchool);

            Parameters.Clear();
            clsm.Fillcombo_Parameter("SELECT facultytype,fid FROM Facultymember where status=1 order by displayorder", Parameters, facultymember);


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
        strsql = "select ah.*,cm.collagename,fm.facultytype from Add_awarshonours ah inner join collage_master cm on ah.schid=cm.collageid inner join Facultymember fm on ah.fid=fm.fid where 1=1 and cm.status=1 and fm.status=1 and ah.status=1 ";
        Parameters.Clear();
        if ((TextBox4.Text != ""))
        {
            Parameters.Add("@awardname", TextBox4.Text);
            strsql += " and ah.awardname like '%'+@awardname+'%'";
        }

        if ((TextBox5.Text != ""))
        {
            Parameters.Add("@Trdate", TextBox5.Text);
            strsql += " and ah.Trdate >=@Trdate";
        }

        if ((TextBox6.Text != ""))
        {
            Parameters.Add("@Trdateone", TextBox6.Text);
            strsql += " and ah.Trdate <=@Trdateone";
        }

        if ((Conversion.Val(facultymember.SelectedValue) > 0))
        {
            Parameters.Add("@fid", Conversion.Val(facultymember.SelectedValue));
            strsql += " and ah.fid =@fid";
        }

        if (Conversion.Val(drpSchool.SelectedValue) > 0)
        {
            Parameters.Add("@schid", Conversion.Val(drpSchool.SelectedValue));
            strsql += " and ah.schid =@schid";
        }

        strsql += " order by ah.displayorder desc ";
        clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
        appno = GridView1.Rows.Count;
       // Response.Write(strsql);
        if ((GridView1.Rows.Count == 0))
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
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
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "del"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
           
            Parameters.Clear();
            Parameters.Add("@awardid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Add_awarshonours where awardid=@awardid", Parameters);
            gridshow();
            trnotice.Visible = true;
            lblnotice.Text = "Record deleted successfully.";
        }



        if ((e.CommandName == "status"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if ((txtstatus.Text == "False"))
            {
                Parameters.Clear();
                Parameters.Add("@awardid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Add_awarshonours set status=1 where awardid=@awardid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
                Parameters.Clear();
                Parameters.Add("@awardid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Add_awarshonours set status=0 where awardid=@awardid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

       
       
        if ((e.CommandName == "edit"))
        {
            Response.Redirect(("addawards.aspx?awardid=" + Conversion.Val(e.CommandArgument)));
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


            e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                            + (Server.HtmlDecode(Convert.ToString(Session["altColor"])) + "\'")));
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
        }
    }

    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        gridshow();
    }
}