using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;


public partial class backoffice_others_subscriber : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select  cm.collagename+' ('+cp.campus_name+')' as cname,cm.collageid from campus cp inner join collage_master cm on  cp.campusid=cm.campusid where cp.status=1 and cm.status=1 order by cp.campus_name,cm.collagename", Parameters, drpcollege);
            drpcollege.Items[0].Text = "Select College";
            Parameters.Clear();
            gridbind();
        }

    }
    protected void gridbind()
    {
        string strsql = "select s.subid,s.subemail,s.mobile,s.status,s.trdate,case when isnull(s.collegetype,0)='0' then 'Group' else cm.collagename+' ('+cp.campus_name+')' end as collagename from Subscribers s left join collage_master cm on s.collegetype=cm.collageid left join campus cp on  cp.campusid=cm.campusid where 1=1 ";
        if (!string.IsNullOrEmpty(txtemail.Text))
        {
            Parameters.Clear();
            Parameters.Add("@subemail", txtemail.Text);
            strsql += " and s.subemail like '%'+@subemail+'%'";
        }
        if (!string.IsNullOrEmpty(sdate.Text))
        {
            Parameters.Add("@trdate", sdate.Text);
            strsql += " and convert(varchar,s.trdate,101) > =Convert(datetime,@trdate,101)";
        }
        if (!string.IsNullOrEmpty(edate.Text))
        {
            DateTime dt = Convert.ToDateTime(edate.Text.Trim());
            dt = dt.AddDays(1);

            Parameters.Add("@trdateone", edate.Text);
            strsql += " and convert(varchar,s.trdate,101) <=Convert(datetime,@trdateone,101)";
        }
        if (Conversion.Val(drpcollege.SelectedValue) != 0)
        {
            Parameters.Add("@collegetype", Conversion.Val(drpcollege.SelectedValue));
            strsql += " and s.collegetype=@collegetype";
        }

        strsql += " order by s.trdate desc";
       // Response.Write(strsql);
        //clsm.GridviewDatashow(Me.GridView1, strsql)
        clsm.GridviewData_Parameter(this.GridView1, strsql, Parameters);
        if (this.GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            btnExport.Visible = false;
            lblnotice.Text = "Record(s) not found.";
        }
        else
        {
            trnotice.Visible = false;
            btnExport.Visible = true;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridbind();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string email = txtemail.Text;
       // string strsql = "select subemail [Email],convert(varchar,trdate,107) [Subscriber Date] from Subscribers where status=1";
        string strsql = "select s.subid,s.subemail[Email],s.status,s.trdate,case when isnull(s.collegetype,0)='0' then 'Group' else cm.collagename+' ('+cp.campus_name+')' end as collagename from Subscribers s left join collage_master cm on s.collegetype=cm.collageid left join campus cp on  cp.campusid=cm.campusid where 1=1  ";
        
        Parameters.Clear();


        if (!string.IsNullOrEmpty(txtemail.Text))
        {
            Parameters.Clear();
            Parameters.Add("@subemail", txtemail.Text);
            strsql += " and s.subemail like '%'+@subemail+'%'";
        }
        if (!string.IsNullOrEmpty(sdate.Text))
        {
            Parameters.Add("@trdate", sdate.Text);
            strsql += " and convert(varchar,s.trdate,101) > =Convert(datetime,@trdate,101)";
        }
        if (!string.IsNullOrEmpty(edate.Text))
        {
            DateTime dt = Convert.ToDateTime(edate.Text.Trim());
            dt = dt.AddDays(1);

            Parameters.Add("@trdateone", edate.Text);
            strsql += " and convert(varchar,s.trdate,101) <=Convert(datetime,@trdateone,101)";
        }
        if (Conversion.Val(drpcollege.SelectedValue) != 0)
        {
            Parameters.Add("@collegetype", Conversion.Val(drpcollege.SelectedValue));
            strsql += " and s.collegetype=@collegetype";
        }

        strsql += " order by s.trdate desc";


        //Dim ds As DataSet = clsm.sendDataset(strsql)
        DataSet ds = clsm.senddataset_Parameter(strsql, Parameters);
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("content-disposition", "attachment;filename=subscriber.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        DataSetToExcel.Convert(ds, Response);
        Response.Write(stringWrite.ToString());
        Response.Buffer = true;
        Response.End();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbldate = e.Row.FindControl("lbldate") as Label;
            lbldate.Text = Convert.ToDateTime(lbldate.Text).ToString("dd/MM/yyyy");
            if (lbldate.Text == "01/01/1900")
            {
                lbldate.Text = "";
            }
            ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
            TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;
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
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"])+ "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = row.FindControl("txtstatus") as TextBox;
            if (txtstatus.Text == "False")
            {
              
                Parameters.Clear();
                Parameters.Add("@subid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Subscribers set status=1 where subid=@subid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
              
                Parameters.Clear();
                Parameters.Add("@subid", Convert.ToInt32(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Subscribers set status=0 where subid=@subid", Parameters);
            }
            gridbind();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if (e.CommandName == "btndel")
        {
          
            Parameters.Clear();
            Parameters.Add("@subid", Convert.ToInt32(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Subscribers where subid=@subid", Parameters);
            gridbind();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record deleted successfully.";
        }


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridbind();
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }
}
