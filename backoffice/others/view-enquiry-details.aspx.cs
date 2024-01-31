using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;

public partial class backoffice_others_view_enquiry_details : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    string sqrqry = null;
    DataSet ds = default(DataSet);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Parameters.Clear();
            Bindenquirydetail();
        }
    }

    private void Bindenquirydetail()
    {
        if (Convert.ToInt32(Request.QueryString["eid"]) != 0)
        {
            Parameters.Clear();
            Parameters.Add("@eid", Convert.ToInt32(Request.QueryString["eid"]));
            sqrqry += @"select Fname[Name] ,Emailid,Mobile,State, organizationname[Course] from enquiry where eid =@eid ";
        }
        ds = clsm.senddataset_Parameter(sqrqry, Parameters);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            dtlview.DataSource = ds.Tables[0];
            dtlview.DataBind();

        }
    }

    //    private void Bindenquirydetail()
    //    {
    //        if (Convert.ToInt32(Request.QueryString["eid"]) != 0)
    //        {
    //            if (Convert.ToString(Request.QueryString["enqtpid"]) == "1")
    //            {
    //                Parameters.Clear();
    //                Parameters.Add("@eid", Convert.ToInt32(Request.QueryString["eid"]));
    //                sqrqry += @"select e.fname[Name],e.emailid[Email Id],e.mobile[Mobile Number],e.state [State],e.city[City],e.enquiry_type[Enquiry Type],
    //                          e.fmessage[Message] from enquiry e left join Enquirytype et on e.ETtid = et.ETtid where e.ETtid = 1 and e.eid =@eid ";
    //            }
    //            else if (Convert.ToString(Request.QueryString["enqtpid"]) == "2")
    //            {
    //                Parameters.Clear();
    //                Parameters.Add("@eid", Convert.ToInt32(Request.QueryString["eid"]));
    //                sqrqry += @"select  e.FName[Name],cl.levelname[Level Name],crs.coursename[Course Name], e.Emailid[Email Id],e.Mobile,e.Address,
    //                          e.enquiry_type[Enquiry Type],e.companyname[Company Name],e.companyprofile[Company Profile],e.FMessage[Message] 
    //                          from enquiry e left join Course crs on e.levelid = crs.courseid left join CourseLevel_Master cl on e.courseid = cl.levelid left join
    //                          Enquirytype et on e.ETtid = et.ETtid where et.ETtid = 2 and e.eid =@eid ";
    //            }
    //            else if (Convert.ToString(Request.QueryString["enqtpid"]) == "3")
    //            {
    //                Parameters.Clear();
    //                Parameters.Add("@eid", Convert.ToInt32(Request.QueryString["eid"]));
    //                sqrqry += @"select e.FName[Name], e.Emailid[Email Id],e.Mobile[Mobile Number],e.enquiry_type[Enquiry Type],
    //                          e.FMessage[Message] from enquiry e left join Enquirytype et on e.ETtid = et.ETtid where et.ETtid = 3 and e.eid =@eid";
    //            }
    //            ds = clsm.senddataset_Parameter(sqrqry, Parameters);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                lblname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
    //                lbltype.Text = ds.Tables[0].Rows[0]["Enquiry Type"].ToString();
    //                dtlview.DataSource = ds.Tables[0];
    //                dtlview.DataBind();
    //            }
    //        }
    //    }
}
