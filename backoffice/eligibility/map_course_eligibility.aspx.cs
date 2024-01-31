using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

public partial class backoffice_eligibility_map_course_eligibility : System.Web.UI.Page
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
           
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select levelname,levelid from CourseLevel_Master  where status=1 order by displayorder", Parameters, levelid);
            levelid.Items[0].Text = "Select Level";

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select dpname,dpid from Discipline_Master  where status=1 order by displayorder", Parameters, dpid);
            dpid.Items[0].Text = "Select Discipline";
            Filllocations();
            Fill_alldata();
        }
    }

    private void Filllocations()
    {
        Parameters.Clear();
        string stralbum = "select * from course WHERE status=1    ";
        if (Conversion.Val(levelid.SelectedValue) > 0)
        {
            Parameters.Add("@levelid", Conversion.Val(levelid.SelectedValue));

            stralbum += " and levelid=@levelid";
        }
        if (Conversion.Val(dpid.SelectedValue) > 0)
        {
            Parameters.Add("@dpid", Conversion.Val(dpid.SelectedValue));

            stralbum += " and dpid=@dpid";
        }
        stralbum += " order by DisplayOrder";
        DataSet ds = clsm.senddataset_Parameter(stralbum, Parameters);
        locationlist.DataSource = ds.Tables[0];
        locationlist.DataBind();
        if (locationlist.Items.Count > 0)
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
        foreach (DataListItem item in locationlist.Items)
        {
            Parameters.Clear();
            Label lblcentresid = item.FindControl("lblcentresid") as Label;
            TextBox lbltestimonial = item.FindControl("lbltestimonial") as TextBox;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_course_eligibility  where eid='" + Conversion.Val(Request.QueryString["eid"]) + "' and courseid= '" + Conversion.Val(lblcentresid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mapid from map_course_eligibility where courseid='"
                                    + (Conversion.Val(lblcentresid.Text) + "' and eid='"
                                    + (Conversion.Val(Request.QueryString["eid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_course_eligibility (eid,courseid)values("
                                      + (Request.QueryString["eid"]) + ","
                                      + (Conversion.Val(lblcentresid.Text) + ")"), Parameters);


                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_course_eligibility where courseid="
                                + (Conversion.Val(lblcentresid.Text) + " and eid="
                                + (Conversion.Val(Request.QueryString["eid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Course Map Successfully.";
        }
        Filllocations();
        Fill_alldata();
    }

    private void Fill_alldata()
    {
        string strquery = "select * from map_course_eligibility where eid=@eid";
        Parameters.Clear();
        Parameters.Add("@eid", Conversion.Val(Request.QueryString["eid"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in locationlist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblcentresname = (Label)li.FindControl("lblcentresname");
                Label lblcentresid = (Label)li.FindControl("lblcentresid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["courseid"]) == Conversion.Val(lblcentresid.Text))
                    {

                        checkfeature.Checked = true;
                        lblcentresname.ForeColor = System.Drawing.Color.Green;


                    }
                  

                }

            }

        }

        string strquery1 = "select * from map_course_eligibility where eid!=@eid";
        Parameters.Clear();
        Parameters.Add("@eid", Conversion.Val(Request.QueryString["eid"]));
        DataSet ds1 = clsm.senddataset_Parameter(strquery1, Parameters);
        if ((ds1.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in locationlist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblcentresname = (Label)li.FindControl("lblcentresname");
                Label lblcentresid = (Label)li.FindControl("lblcentresid");
                for (int index = 0; index <= ds1.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds1.Tables[0].Rows[index]["courseid"]) == Conversion.Val(lblcentresid.Text))
                    {

                        checkfeature.Checked = false;
                        checkfeature.Enabled = false;
                        lblcentresname.ForeColor = System.Drawing.Color.Red;


                    }


                }

            }

        }


    }

    protected void levelid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Filllocations();
        Fill_alldata();
    }
    protected void dpid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Filllocations();
        Fill_alldata();
    }

}
