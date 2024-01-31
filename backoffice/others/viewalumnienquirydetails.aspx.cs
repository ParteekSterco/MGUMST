using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

public partial class backoffice_others_viewalumnienquirydetails : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    string sqrqry = null;
    DataSet ds = default(DataSet);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Bindenquirydetail();
        }
    }
    private void Bindenquirydetail()
    {
        if (Convert.ToInt32(Request.QueryString["eid"]) != 0)
        {
            Parameters.Clear();
            Parameters.Add("@eid", Convert.ToInt32(Request.QueryString["eid"]));
            sqrqry += @"select e.fname[Name],e.Emailid[Email],e.dob[Date of birth],e.Mobile,e.city[City],e.coursename[CourseName],e.yearpassout[Year of Passing-out],e.yearofadmission[Year Admission],fmessage[Message] from enquiry_alumni e where e.eid =@eid ";
        }
        ds = clsm.senddataset_Parameter(sqrqry, Parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            dtlview.DataSource = ds.Tables[0];
            dtlview.DataBind();

        }
    }
}