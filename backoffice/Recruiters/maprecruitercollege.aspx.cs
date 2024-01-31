using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

public partial class backoffice_Recruiters_maprecruitercollege : System.Web.UI.Page
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
        string stralbum = "select distinct cm.collagename+' ('+c.campus_name+')' as collagename,cm.collageid,cm.displayorder from collage_master cm inner join campus c on   cm.campusid=c.campusid where cm.status=1 and c.status=1  order by cm.DisplayOrder   ";
        DataSet ds = clsm.senddataset_Parameter(stralbum, Parameters);
        collegelist.DataSource = ds.Tables[0];
        collegelist.DataBind();
        if (collegelist.Items.Count > 0)
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
        foreach (DataListItem item in collegelist.Items)
        {
            Parameters.Clear();
            Label lblcollageid = item.FindControl("lblcollageid") as Label;
            TextBox lblcollagename = item.FindControl("lblcollagename") as TextBox;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_recruiters_institute  where imgid='" + Conversion.Val(Request.QueryString["imgid"]) + "' and collageid= '" + Conversion.Val(lblcollageid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mapid from map_recruiters_institute where collageid='"
                                    + (Conversion.Val(lblcollageid.Text) + "' and imgid='"
                                    + (Conversion.Val(Request.QueryString["imgid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_recruiters_institute (imgid,collageid)values("
                                      + (Request.QueryString["imgid"]) + ","
                                      + (Conversion.Val(lblcollageid.Text) + ")"), Parameters);
                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_recruiters_institute where collageid="
                                + (Conversion.Val(lblcollageid.Text) + " and imgid="
                                + (Conversion.Val(Request.QueryString["imgid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "College Map Successfully.";
        }
        Filltestimonials();
        Fill_alldata();
    }
    private void Fill_alldata()
    {
        string strquery = "select * from map_recruiters_institute where imgid=@imgid";
        Parameters.Clear();
        Parameters.Add("@imgid", Conversion.Val(Request.QueryString["imgid"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in collegelist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblcollagename = (Label)li.FindControl("lblcollagename");
                Label lblcollageid = (Label)li.FindControl("lblcollageid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["collageid"]) == Conversion.Val(lblcollageid.Text))
                    {
                        checkfeature.Checked = true;
                        lblcollagename.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
        }
    }
}