using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;

public partial class backoffice_gallery_mapevents : System.Web.UI.Page
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
        string stralbum = "select * from events WHERE status=1  and ntypeid=2 order by DisplayOrder   ";
        DataSet ds = clsm.senddataset_Parameter(stralbum, Parameters);
        eventslist.DataSource = ds.Tables[0];
        eventslist.DataBind();
        if (eventslist.Items.Count > 0)
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
        foreach (DataListItem item in eventslist.Items)
        {
            Parameters.Clear();
            Label lbleventsid = item.FindControl("lbleventsid") as Label;
            Label lbleventstitle = item.FindControl("lbleventstitle") as Label;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_album_events  where Albumid='" + Conversion.Val(Request.QueryString["Albumid"]) + "' and eventsid= '" + Conversion.Val(lbleventsid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mapid from map_album_events where eventsid='"
                                    + (Conversion.Val(lbleventsid.Text) + "' and Albumid='"
                                    + (Conversion.Val(Request.QueryString["Albumid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_album_events (Albumid,eventsid)values("
                                      + (Request.QueryString["Albumid"]) + ","
                                      + (Conversion.Val(lbleventsid.Text) + ")"), Parameters);


                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_album_events where eventsid="
                                + (Conversion.Val(lbleventsid.Text) + " and Albumid="
                                + (Conversion.Val(Request.QueryString["Albumid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Events Map Successfully.";
        }
        Filltestimonials();
        Fill_alldata();
    }

    private void Fill_alldata()
    {
        string strquery = "select * from map_album_events where Albumid=@Albumid";
        Parameters.Clear();
        Parameters.Add("@Albumid", Conversion.Val(Request.QueryString["Albumid"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in eventslist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lbleventstitle = (Label)li.FindControl("lbleventstitle");
                Label lbleventsid = (Label)li.FindControl("lbleventsid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["eventsid"]) == Conversion.Val(lbleventsid.Text))
                    {

                        checkfeature.Checked = true;
                        lbleventstitle.ForeColor = System.Drawing.Color.Red;
                    }

                }

            }

        }

    }

}