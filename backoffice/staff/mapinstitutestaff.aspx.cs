using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

public partial class backoffice_staff_mapinstitutestaff : System.Web.UI.Page
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
        string stralbum = "select * from collage_master WHERE status=1 order by DisplayOrder   ";
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
                if (clsm.Checking_Parameter("select * from map_staff_institute  where staffid=" + Conversion.Val(Request.QueryString["staffid"]) + " and collageid=" + Conversion.Val(lblcollageid.Text) + " ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mapid from map_staff_institute where collageid='"
                                    + (Conversion.Val(lblcollageid.Text) + "' and staffid='"
                                    + (Conversion.Val(Request.QueryString["staffid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_staff_institute (staffid,collageid)values("
                                      + (Request.QueryString["staffid"]) + ","
                                      + (Conversion.Val(lblcollageid.Text) + ")"), Parameters);
                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_staff_institute where collageid="
                                + (Conversion.Val(lblcollageid.Text) + " and staffid="
                                + (Conversion.Val(Request.QueryString["staffid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Institute Map Successfully.";
        }
        Filltestimonials();
        Fill_alldata();
    }
    private void Fill_alldata()
    {
        Parameters.Clear();
        Parameters.Add("@staffid", Conversion.Val(Request.QueryString["staffid"]));
        string strquery = "select * from map_staff_institute where staffid=@staffid";
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