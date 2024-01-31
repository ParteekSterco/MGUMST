using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;

public partial class backoffice_others_viewalumnienquiryall : System.Web.UI.Page
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
            Parameters.Clear();
            clsm.Fillcombo_Parameter("SELECT distinct  e.address,e.address as category FROM enquiry_alumni_ALL e", Parameters, QueryType);
            QueryType.Items[0].Text = "Select Enquiry Type";
            Search();
        }
    }
    private void Search()
    {
        try
        {
            string Strsql = "SELECT  e.eid,e.fname[Name],e.Emailid[Email],e.Mobile,e.city[City],e.coursename[CourseName],fmessage[Message],e.trdate,e.address as category,e.collageid,e.lname,e.yearofadmission FROM enquiry_alumni_ALL e where 1=1  ";
            Parameters.Clear();

            if (!string.IsNullOrEmpty(sdate.Text))
            {
                Parameters.Add("@trdate", sdate.Text);
                Strsql = Strsql + " and e.trdate +1  >=@trdate";
            }
            if (!string.IsNullOrEmpty(edate.Text))
            {
                Parameters.Add("@trdateone", edate.Text);
                Strsql = Strsql + " and e.trdate-1 <=@trdateone";
            }
            if (Conversion.Val(QueryType.SelectedIndex)>0)
            {
                Parameters.Add("@address", QueryType.SelectedValue);
                Strsql = Strsql + " and e.address=@address";
            }
          
            Strsql = Strsql + " order by e.trdate desc";

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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string Strsql = "SELECT  e.eid,e.fname[Name],e.Emailid[Email],e.Mobile,e.city[City],e.coursename[CourseName],fmessage[Message],e.trdate,e.address as category,e.collageid FROM enquiry_alumni_ALL e where 1=1  ";
        Parameters.Clear();

        if (!string.IsNullOrEmpty(sdate.Text))
        {
            Parameters.Add("@trdate", sdate.Text);
            Strsql = Strsql + " and e.trdate +1  >=@trdate";
        }
        if (!string.IsNullOrEmpty(edate.Text))
        {
            Parameters.Add("@trdateone", edate.Text);
            Strsql = Strsql + " and e.trdate-1 <=@trdateone";
        }
      
        Strsql = Strsql + " order by e.trdate desc";
        DataSet ds = clsm.senddataset_Parameter(Strsql, Parameters);
        //Dim ds As DataSet = clsm.sendDataset(strsql)
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("content-disposition", "attachment;filename=EnquiryDOEMumbai.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        DataSetToExcel.Convert(ds, Response);
        //DgExp.RenderControl(htmlWrite)
        Response.Write(stringWrite.ToString());
        Response.Buffer = true;
        Response.End();

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
            Image imgDown = (Image)e.Row.FindControl("imgDown");
            Literal lbldown = (Literal)e.Row.FindControl("lbldown");

            if (!string.IsNullOrEmpty(Convert.ToString(lbldown.Text)))
            {
                imgDown.Visible = true;
            }
            
        }
    }
    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "downbtn")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Literal lbldown = (Literal)row.FindControl("lbldown");
            Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~/Uploads/career/" + lbldown.Text);
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Label1.Visible = false;
        if (e.CommandName == "btndel")
        {
            Parameters.Clear();
            Parameters.Add("@eid", Convert.ToInt32(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from enquiry_alumni_all where eid=@eid", Parameters);
            
            Search();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully !!!";
        }
        if (e.CommandName == "downbtn")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Literal lbldown = (Literal)row.FindControl("lbldown");
            Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~/Uploads/career/" + lbldown.Text);
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            Search();
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }
    

}