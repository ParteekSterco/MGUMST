using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;

public partial class backoffice_department_mapcoursedepartment : System.Web.UI.Page
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

            Filltestimonials();
            Fill_alldata();
        }
    }
    private void Filltestimonials()
    {
        Parameters.Clear();
        Parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        string stralbum = "select distinct  c.coursename,c.courseid  from Course c inner join map_course_institute mci on  c.courseid=mci.courseid inner join Department_Master d on mci.collageid=d.schoolid   where c.status=1 and d.deptid=@deptid   ";


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
        courselist.DataSource = ds.Tables[0];
        courselist.DataBind();
        if (courselist.Items.Count > 0)
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
        foreach (DataListItem item in courselist.Items)
        {
            Parameters.Clear();
            Label lblcourseid = item.FindControl("lblcourseid") as Label;
            TextBox lblcoursename = item.FindControl("lblcoursename") as TextBox;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_course_department  where deptid='" + Conversion.Val(Request.QueryString["deptid"]) + "' and courseid= '" + Conversion.Val(lblcourseid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mapid from map_course_department where courseid='"
                                    + (Conversion.Val(lblcourseid.Text) + "' and deptid='"
                                    + (Conversion.Val(Request.QueryString["deptid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_course_department (deptid,courseid)values("
                                      + (Request.QueryString["deptid"]) + ","
                                      + (Conversion.Val(lblcourseid.Text) + ")"), Parameters);
                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_course_department where courseid="
                                + (Conversion.Val(lblcourseid.Text) + " and deptid="
                                + (Conversion.Val(Request.QueryString["deptid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Course Map Successfully.";
        }
        Filltestimonials();
        Fill_alldata();
    }
    private void Fill_alldata()
    {
        string strquery = "select * from map_course_department where deptid=@deptid";
        Parameters.Clear();
        Parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in courselist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblcoursename = (Label)li.FindControl("lblcoursename");
                Label lblcourseid = (Label)li.FindControl("lblcourseid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["courseid"]) == Conversion.Val(lblcourseid.Text))
                    {
                        checkfeature.Checked = true;
                        lblcoursename.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
        }
    }
    protected void levelid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Filltestimonials();
        Fill_alldata();
    }
    protected void dpid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        Filltestimonials();
        Fill_alldata();
    }
}