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
using System.Net;
using System.Net.Mail;
using Microsoft.VisualBasic;

public partial class backoffice_campus_viewcentres : System.Web.UI.Page
{
    mainclass Clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    public HttpCookie AUserSession = null;
    protected void Page_Load(object sender, System.EventArgs e)
    {
        trsuccess.Visible = false;
        trnotice.Visible = false;
        trerror.Visible = false;
        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }
        if ((Page.IsPostBack == false))
        {
            gridshow();
            if ((Request.QueryString["edit"] == "edit"))
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully..";
            }
        }
    }
    protected void gridshow()
    {
        Parameters.Clear();
        string strsql = "select cp.* from campus cp left join campusrole_Management crm on cp.campusid=crm.campusid where 1=1 ";

        if (Conversion.Val(AUserSession["Roleid"]) != 1)
        {
            strsql += " and isnull(crm.roleid,0)=" + Conversion.Val(AUserSession["Roleid"]) + "";
        }
        strsql += " order by cp.displayorder";

        Clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record not found.";
        }
    }
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
            if (e.Row.Cells[4].Text == "True")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (e.Row.Cells[4].Text == "False")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
        if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[4].Visible = false;
        }
    }
    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnedit")
        {
            Response.Redirect("centres.aspx?cmpid=" + e.CommandArgument);
        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            string str = ((DataControlFieldCell)row.Cells[4]).Text;
            if (str == "False")
            {
                Parameters.Clear();
                Parameters.Add("@bid", Convert.ToInt32(e.CommandArgument.ToString()));
                string strsql = "update campus set status=1 where campusid=@bid";
                Clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            else if (str == "True")
            {
                Parameters.Clear();
                Parameters.Add("@bid", Convert.ToInt32(e.CommandArgument.ToString()));
                string strsql = "update campus set status=0 where campusid=@bid";
                Clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Campus Changed Successfully.";
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
}