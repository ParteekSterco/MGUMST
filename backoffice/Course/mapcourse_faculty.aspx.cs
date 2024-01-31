using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

public partial class backoffice_Course_mapcourse_testimonials : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {

            Filltestimonials();
            Fill_alldata();
        }
    }

    private void Filltestimonials()
    {
        Parameters.Clear();
        string stralbum = "select * from Addfacultymaster WHERE status=1 order by DisplayOrder   ";
        DataSet ds = clsm.senddataset_Parameter(stralbum, Parameters);
        testimoniallist.DataSource = ds.Tables[0];
        testimoniallist.DataBind();
        if (testimoniallist.Items.Count > 0)
        {
            Button1.Visible = true;
        }
        else
        {
            Button1.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (DataListItem item in testimoniallist.Items)
        {
            Parameters.Clear();
            Label lbltestimonialid = item.FindControl("lbltestimonialid") as Label;
            TextBox lbltestimonial = item.FindControl("lbltestimonial") as TextBox;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_course_faculty  where courseid='" + Conversion.Val(Request.QueryString["courseid"]) + "' and fid= '" + Conversion.Val(lbltestimonialid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mfid from map_course_faculty where fid='"
                                    + (Conversion.Val(lbltestimonialid.Text) + "' and courseid='"
                                    + (Conversion.Val(Request.QueryString["courseid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_course_faculty (courseid,fid)values("
                                      + (Request.QueryString["courseid"]) + ","
                                      + (Conversion.Val(lbltestimonialid.Text) + ")"), Parameters);


                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_course_faculty where fid="
                                + (Conversion.Val(lbltestimonialid.Text) + " and courseid="
                                + (Conversion.Val(Request.QueryString["courseid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Faculty Map Successfully.";
        }
        Filltestimonials();
        Fill_alldata();
    }

    private void Fill_alldata()
    {
        string strquery = "select * from map_course_faculty where courseid=@courseid";
        Parameters.Clear();
        Parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in testimoniallist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lbltestimonial = (Label)li.FindControl("lbltestimonial");
                Label lbltestimonialid = (Label)li.FindControl("lbltestimonialid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["fid"]) == Conversion.Val(lbltestimonialid.Text))
                    {
                        checkfeature.Checked = true;
                        lbltestimonial.ForeColor = System.Drawing.Color.Red;
                    }

                }

            }

        }

    }

}