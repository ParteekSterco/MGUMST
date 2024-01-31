using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections;


public partial class backoffice_faculty_mapfacultycategory : System.Web.UI.Page
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
        string stralbum = "select * from faculity_cate WHERE status=1 order by DisplayOrder   ";
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
            Label lblfid = item.FindControl("lblfid") as Label;
            TextBox lblfaculitycate = item.FindControl("lblfaculitycate") as TextBox;
            CheckBox checkfeature = item.FindControl("checkfeature") as CheckBox;
            if (checkfeature.Checked == true)
            {
                Parameters.Clear();
                if (clsm.Checking_Parameter("select * from map_faculty_category  where facultyid='" + Conversion.Val(Request.QueryString["facultyid"]) + "' and fid= '" + Conversion.Val(lblfid.Text) + "' ", Parameters) == false)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mapid from map_faculty_category where fid='"
                                    + (Conversion.Val(lblfid.Text) + "' and facultyid='"
                                    + (Conversion.Val(Request.QueryString["facultyid"])) + "'"), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_faculty_category (facultyid,fid)values("
                                      + (Request.QueryString["facultyid"]) + ","
                                      + (Conversion.Val(lblfid.Text) + ")"), Parameters);
                    }
                }
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from map_faculty_category where fid="
                                + (Conversion.Val(lblfid.Text) + " and facultyid="
                                + (Conversion.Val(Request.QueryString["facultyid"]) + "  ")), Parameters);
            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Category Map Successfully.";
        }
        Filltestimonials();
        Fill_alldata();
    }
    private void Fill_alldata()
    {
        Parameters.Clear();
        Parameters.Add("@facultyid", Conversion.Val(Request.QueryString["facultyid"]));
        string strquery = "select * from map_faculty_category where facultyid=@facultyid";
        DataSet ds = clsm.senddataset_Parameter(strquery, Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            foreach (DataListItem li in collegelist.Items)
            {
                CheckBox checkfeature = (CheckBox)li.FindControl("checkfeature");
                Label lblfaculitycate = (Label)li.FindControl("lblfaculitycate");
                Label lblfid = (Label)li.FindControl("lblfid");
                for (int index = 0; index <= ds.Tables[0].Rows.Count - 1; index++)
                {
                    if (Conversion.Val(ds.Tables[0].Rows[index]["fid"]) == Conversion.Val(lblfid.Text))
                    {
                        checkfeature.Checked = true;
                        lblfaculitycate.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
        }
    }
}