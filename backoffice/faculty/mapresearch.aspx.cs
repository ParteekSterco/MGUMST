using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;


public partial class backoffice_faculty_mapresearch : System.Web.UI.Page
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

            Fillresearch();
            Fill_alldata();
        }
    }

    private void Fillresearch()
    {
        Parameters.Clear();
        string stralbum = "select * from research WHERE status=1  order by DisplayOrder   ";
        DataSet ds = clsm.senddataset_Parameter(stralbum, Parameters);
        researchlist.DataSource = ds.Tables[0];
        researchlist.DataBind();
        if (researchlist.Items.Count > 0)
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
        foreach (DataListItem item in researchlist.Items)
        {
            Parameters.Clear();
            Label lblEventsid = item.FindControl("lblEventsid") as Label;
            TextBox lblEventsTitle = item.FindControl("lblEventsTitle") as TextBox;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;

            TextBox txtdisplayorder = (TextBox)item.FindControl("txtdisplayorder");

            if (checkfeature.Checked == true)
            {
                if (clsm.Checking("select * from map_research_faculty  where facultyid='" + Conversion.Val(Request.QueryString["facultyid"]) + "' and researchid= '" + Conversion.Val(lblEventsid.Text) + "' ") == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mfid from map_research_faculty where researchid='"
                                    + (Conversion.Val(lblEventsid.Text) + "' and facultyid='"
                                    + (Conversion.Val(Request.QueryString["facultyid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_research_faculty (facultyid,researchid,displayorder)values("
                                      + (Request.QueryString["facultyid"]) + ","
                                      + (Conversion.Val(lblEventsid.Text) + ","
                                      + (Conversion.Val(txtdisplayorder.Text) + ")")), Parameters);


                    }
                    
                }
                else
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update  map_research_faculty  set  displayorder=" + Conversion.Val(txtdisplayorder.Text) + " where facultyid=" + (Conversion.Val(Request.QueryString["facultyid"])) + " and researchid=" + Conversion.Val(lblEventsid.Text) + "", Parameters);
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_research_faculty where researchid="
                                + (Conversion.Val(lblEventsid.Text) + " and facultyid="
                                + (Conversion.Val(Request.QueryString["facultyid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Research Map Successfully.";
        }
        Fillresearch();
        Fill_alldata();
    }

    private void Fill_alldata()
    {
        string strquery = "select * from map_research_faculty where facultyid=@facultyid";
        Parameters.Clear();
        Parameters.Add("@facultyid", Conversion.Val(Request.QueryString["facultyid"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in researchlist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblEventsTitle = (Label)li.FindControl("lblEventsTitle");
                Label lblEventsid = (Label)li.FindControl("lblEventsid");
                TextBox txtdisplayorder = (TextBox)li.FindControl("txtdisplayorder");

                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["researchid"]) == Conversion.Val(lblEventsid.Text))
                    {

                        checkfeature.Checked = true;
                        lblEventsid.ForeColor = System.Drawing.Color.Red;

                        txtdisplayorder.Text = ds.Tables[0].Rows[index]["displayorder"].ToString();
                    }

                }

            }

        }

    }

}