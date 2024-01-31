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

public partial class backoffice_log_managemant_viewlog : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    public int appno;
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            Label1.Visible = false;
            Search();
            


        }
    }

   

    private void Search()
    {
        try
        {
            string Strsql = "select * from loghistory where 1=1";
            Parameters.Clear();

            if (!string.IsNullOrEmpty(sdate.Text))
            {

                Parameters.Add("@addeditdate", sdate.Text);
                Strsql = Strsql + " and addeditdate   >=@addeditdate";
            }
            if (!string.IsNullOrEmpty(edate.Text))
            {

                Parameters.Add("@addeditdatesec", edate.Text);
                Strsql = Strsql + " and addeditdate <=@addeditdatesec";
            }
            Strsql = Strsql + " order by addeditdate desc";

            clsm.GridviewData_Parameter(GridView1, Strsql, Parameters);
            if (GridView1.Rows.Count > 0)
            {
                Label1.Visible = false;
            }
            else
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Records Found.";
            }
            appno = GridView1.Rows.Count;
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();

        }
    }




    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
        {
            //    e.Row.Cells(5).Visible = False
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Label1.Visible = false;
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {

            GridView1.PageIndex = e.NewPageIndex;
            Label1.Visible = false;
            Search();
            
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message.ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    
}