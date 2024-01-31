using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

public partial class backoffice_Fee_map_course_hostelfee : System.Web.UI.Page
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
            clsm.Fillcombo_Parameter("select campus_name,campusid from campus  where status=1 order by displayorder", Parameters, campusid);
            campusid.Items[0].Text = "Select Campus";

            Fill_college();

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
        string stralbum = "select distinct ma.mapid,ma.courseid,ma.collageid,c.coursename,cp.campus_name,cm.collagename from map_course_institute ma inner join Course c on  ma.courseid=c.courseid inner join collage_master cm on ma.collageid=cm.collageid inner join campus cp on cm.campusid=cp.campusid where c.status=1   ";


        if (Conversion.Val(campusid.SelectedValue) > 0)
        {
            Parameters.Add("@campusid", Conversion.Val(campusid.SelectedValue));

            stralbum += " and cp.campusid=@campusid";
        }

        if (Conversion.Val(collageid.SelectedValue) > 0)
        {
            Parameters.Add("@collageid", Conversion.Val(collageid.SelectedValue));

            stralbum += " and ma.collageid=@collageid";
        }

        if (Conversion.Val(levelid.SelectedValue) > 0)
        {
            Parameters.Add("@levelid", Conversion.Val(levelid.SelectedValue));

            stralbum += " and c.levelid=@levelid";
        }


        if (Conversion.Val(dpid.SelectedValue) > 0)
        {
            Parameters.Add("@dpid", Conversion.Val(dpid.SelectedValue));

            stralbum += " and c.dpid=@dpid";
        }
        stralbum += " order by c.coursename";
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
            Label lblcourseid = item.FindControl("lblcourseid") as Label;
            Label lblcollageid = item.FindControl("lblcollageid") as Label;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;

            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_course_hostelfee  where cfid='" + Conversion.Val(Request.QueryString["eid"]) + "' and courseid= '" + Conversion.Val(lblcourseid.Text) + "' and collageid= '" + Conversion.Val(lblcollageid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select hostelfeeid from map_course_hostelfee where collageid=" + Conversion.Val(lblcollageid.Text) + " and courseid='"
                                    + (Conversion.Val(lblcourseid.Text) + "' and cfid='"
                                    + (Conversion.Val(Request.QueryString["cfid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_course_hostelfee (cfid,courseid,collageid)values(" + Conversion.Val(Request.QueryString["cfid"]) + "," + Conversion.Val(lblcourseid.Text) + "," + Conversion.Val(lblcollageid.Text) + ")", Parameters);


                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_course_hostelfee where  cfid=" + Conversion.Val(Request.QueryString["cfid"]) + " and courseid=" + Conversion.Val(lblcourseid.Text) + " and collageid=" + Conversion.Val(lblcollageid.Text) + "", Parameters);

            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Course Map Successfully.";
        }
        Filllocations();
        Fill_alldata();
    }

    private void Fill_alldata()
    {
        string strquery = "select * from map_course_hostelfee where cfid=@cfid";
        Parameters.Clear();
        Parameters.Add("@cfid", Conversion.Val(Request.QueryString["cfid"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in locationlist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblcentresname = (Label)li.FindControl("lblcentresname");
                Label lblcourseid = (Label)li.FindControl("lblcourseid");
                Label lblcollageid = (Label)li.FindControl("lblcollageid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["courseid"]) == Conversion.Val(lblcourseid.Text) && Conversion.Val(ds.Tables[0].Rows[index]["collageid"]) == Conversion.Val(lblcollageid.Text))
                    {

                        checkfeature.Checked = true;
                        lblcentresname.ForeColor = System.Drawing.Color.Green;


                    }


                }

            }

        }
        string strquery1 = "select * from map_course_hostelfee where cfid!=@cfid";
        Parameters.Clear();
        Parameters.Add("@cfid", Conversion.Val(Request.QueryString["cfid"]));
        DataSet ds1 = clsm.senddataset_Parameter(strquery1, Parameters);
        if ((ds1.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in locationlist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblcentresname = (Label)li.FindControl("lblcentresname");
                Label lblcourseid = (Label)li.FindControl("lblcourseid");
                Label lblcollageid = (Label)li.FindControl("lblcollageid");
                for (int index = 0; index <= ds1.Tables[0].Rows.Count - 1; index++)
                {

                    //if (Conversion.Val(ds1.Tables[0].Rows[index]["courseid"]) == Conversion.Val(lblcentresid.Text))
                    //{
                    if (Conversion.Val(ds1.Tables[0].Rows[index]["courseid"]) == Conversion.Val(lblcourseid.Text) && Conversion.Val(ds1.Tables[0].Rows[index]["collageid"]) == Conversion.Val(lblcollageid.Text))
                    {
                        checkfeature.Checked = false;
                        checkfeature.Enabled = false;
                        lblcentresname.ForeColor = System.Drawing.Color.Red;


                    }


                }

            }

        }



    }

    private void Fill_college()
    {

        Parameters.Clear();
        string strcollege = "select collagename,collageid from collage_master  where status=1";
        if (Conversion.Val(campusid.SelectedValue) > 0)
        {
            Parameters.Add("@campusid", Conversion.Val(campusid.SelectedValue));
            strcollege += " and campusid=@campusid";
        }
        clsm.Fillcombo_Parameter(strcollege, Parameters, collageid);
        collageid.Items[0].Text = "Select College";

    }

    protected void campusid_SelectedIndexChanged(object sender, System.EventArgs e)
    {

        Fill_college();
        Filllocations();
        Fill_alldata();
    }
    protected void collageid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Filllocations();
        Fill_alldata();
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
