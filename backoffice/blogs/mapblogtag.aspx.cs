using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;

public partial class backoffice_blogs_mapblogtag : System.Web.UI.Page
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

            Fillblogtag();
            Fill_alldata();
        }
    }

    private void Fillblogtag()
    {
        Parameters.Clear();
        string strblogtag = "select * from blogtag WHERE status=1 order by DisplayOrder   ";
        DataSet ds = clsm.senddataset_Parameter(strblogtag, Parameters);
        taglist.DataSource = ds.Tables[0];
        taglist.DataBind();
        if (taglist.Items.Count > 0)
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
        foreach (DataListItem item in taglist.Items)
        {
            Parameters.Clear();
            Label lblbtid = item.FindControl("lblbtid") as Label;
            Label lblbtagtitle = item.FindControl("lblbtagtitle") as Label;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_blog_tag  where blogId='" + Conversion.Val(Request.QueryString["blogId"]) + "' and btid= '" + Conversion.Val(lblbtid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select msid from map_blog_tag where btid='"
                                    + (Conversion.Val(lblbtid.Text) + "' and blogId='"
                                    + (Conversion.Val(Request.QueryString["blogId"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_blog_tag (blogId,btid)values("
                                      + (Request.QueryString["blogId"]) + ","
                                      + (Conversion.Val(lblbtid.Text) + ")"), Parameters);


                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_blog_tag where btid="
                                + (Conversion.Val(lblbtid.Text) + " and blogId="
                                + (Conversion.Val(Request.QueryString["blogId"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Tag Map Successfully.";
        }
        Fillblogtag();
        Fill_alldata();
    }

    private void Fill_alldata()
    {
        string strquery = "select * from map_blog_tag where blogId=@blogId";
        Parameters.Clear();
        Parameters.Add("@blogId", Conversion.Val(Request.QueryString["blogId"]));
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in taglist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");

                Label lblbtid = (Label)li.FindControl("lblbtid");
                Label lblbtagtitle = (Label)li.FindControl("lblbtagtitle"); 
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["btid"]) == Conversion.Val(lblbtid.Text))
                    {

                        checkfeature.Checked = true;
                        lblbtagtitle.ForeColor = System.Drawing.Color.Red;
                    }

                }

            }

        }

    }

}