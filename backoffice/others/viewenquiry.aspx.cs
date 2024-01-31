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

public partial class backoffice_others_viewenquiry : System.Web.UI.Page
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
            clsm.Fillcombo_Parameter("select  cm.collagename+' ('+cp.campus_name+')' as cname,cm.collageid from campus cp inner join collage_master cm on  cp.campusid=cm.campusid where cp.status=1 and cm.status=1 order by cp.campus_name,cm.collagename", Parameters, drpcollege);
            drpcollege.Items[0].Text = "Select College";
            Parameters.Clear();
            Search();
        }
    }
    private void Search()
    {
        try
        {
            string Strsql = "SELECT  e.eid,e.fname[Name],e.Emailid[Email],e.Mobile,FMessage[Message],e.trdate,case when isnull(e.category,0)='0' then 'Group' else cm.collagename+' ('+cp.campus_name+')' end as collagename FROM enquiry  e left join collage_master cm on e.category=cm.collageid left join campus cp on  cp.campusid=cm.campusid where 1=1  ";
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
            if (Conversion.Val(drpcollege.SelectedValue) != 0)
            {
                Parameters.Add("@category", Conversion.Val(drpcollege.SelectedValue));
                Strsql += " and e.category=@category";
            }
          
            if (!string.IsNullOrEmpty(txtemailid.Text))
            {
               
                Parameters.Add("@Emailid", txtemailid.Text);
                Strsql += " and e.Emailid like '%'+@Emailid+'%'";
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

    protected void lnkreply_Click(object sender, EventArgs e)
    {
        Label4.Visible = false;
        LinkButton lb = sender as LinkButton;
        string feedbackid = lb.CommandArgument;
        txtemail.Text = "";
        txtreply.Text = "";
        Parameters.Clear();
        Parameters.Add("@eid", Convert.ToInt32(feedbackid));
        txtemail.Text = clsm.SendValue_Parameter("select femail from enquiry where eid=@eid", Parameters).ToString();

        //txtemail.Text = clsm.SendValue("select femail from enquiry where eid=" & feedbackid)

        ModalPopupExtender2.Show();
    }


    protected void lnkdetail_Click(object sender, EventArgs e)
    {
        Label3.Visible = false;
        LinkButton lb = sender as LinkButton;
        string feedbackid = lb.CommandArgument;
        Parameters.Clear();
        Parameters.Add("@eid", Convert.ToInt32(feedbackid));
        DataSet ds = clsm.senddataset_Parameter("select enq.*, c.CountryName from enquiry enq left outer join country c on enq.country=c.Countryid where enq.eid=@eid", Parameters);
        string Message = "";
        string project_interset = "";
        //Dim ds As DataSet = clsm.sendDataset("select enq.*, c.CountryName from enquiry enq left outer join country c on enq.country=c.Countrycode where enq.eid=" & feedbackid)
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblquery.Text = ds.Tables[0].Rows[0]["enquiry_type"].ToString();
            lblGender.Text = ds.Tables[0].Rows[0]["gender"].ToString();
            lblMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            lblTelephone.Text = ds.Tables[0].Rows[0]["TelNo"].ToString();
            lblFName.Text = ds.Tables[0].Rows[0]["FName"].ToString() + " " + ds.Tables[0].Rows[0]["LName"].ToString();
            lblCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
            lblState.Text = ds.Tables[0].Rows[0]["State"].ToString();
            project_interset = ds.Tables[0].Rows[0]["Address"].ToString();
            lblAddress.Text = lblAddress.Text.Replace(Environment.NewLine, "<br/>").ToString();

            lblState.Text = ds.Tables[0].Rows[0]["state"].ToString();
            lblCity.Text = ds.Tables[0].Rows[0]["city"].ToString();
            lblEmail.Text = ds.Tables[0].Rows[0]["Emailid"].ToString();
            Message = ds.Tables[0].Rows[0]["fMessage"].ToString();

            lblPostedDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["Trdate"]).ToString("dd/MM/yyyy");
            if (!string.IsNullOrEmpty(Message))
            {
                lblMessage.Text = Message;
                lblMessage.Text = lblMessage.Text.Replace(Environment.NewLine, "<br/>").ToString();
                tr_message.Visible = true;
            }

            if (!string.IsNullOrEmpty(project_interset))
            {
                lblAddress.Text = project_interset;
                tr_Project.Visible = true;
            }

        }
        ModalPopupExtender1.Show();
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        string Strsql = "SELECT  e.eid,e.fname[Name],e.Emailid[Email],e.Mobile,FMessage[Message],e.trdate,case when isnull(e.category,0)='0' then 'Group' else cm.collagename+' ('+cp.campus_name+')' end as collagename FROM enquiry  e left join collage_master cm on e.category=cm.collageid left join campus cp on  cp.campusid=cm.campusid where 1=1  ";
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
        if (Conversion.Val(drpcollege.SelectedValue) != 0)
        {
            Parameters.Add("@category", Conversion.Val(drpcollege.SelectedValue));
            Strsql += " and e.category=@category";
        }
        if (!string.IsNullOrEmpty(txtemailid.Text))
        {
       
            Parameters.Add("@Emailid", txtemailid.Text);
            Strsql += " and e.Emailid like '%'+@Emailid+'%'";
        }
        Strsql = Strsql + " order by e.trdate desc";

        DataSet ds = clsm.senddataset_Parameter(Strsql, Parameters);
        //Dim ds As DataSet = clsm.sendDataset(strsql)

        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("content-disposition", "attachment;filename=ContactEnquiry.xls");
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
        if (e.CommandName == "btndel")
        {
            Parameters.Clear();
            Parameters.Add("@eid", Convert.ToInt32(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from enquiry where eid=@eid", Parameters);
          
            Search();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully !!!";
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Mailing();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    public void Mailing()
    {

        MailMessage oMessage = new MailMessage();
        oMessage.Subject = "Reply of Query";
        oMessage.Body = txtreply.Text;
        oMessage.IsBodyHtml = true;
        oMessage.From = new MailAddress("a@a.com");
        oMessage.To.Add(new MailAddress(txtemail.Text));
        oMessage.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient("localhost");
        client.Send(oMessage);
        client.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
    }

}
