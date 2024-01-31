﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class backoffice_collage_collage_recruiter : System.Web.UI.Page
{
    HttpCookie AUserSession;
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();


    protected void Page_Load(object sender, System.EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        if (Page.IsPostBack == false)
        {
            collageid.Text = Conversion.Val(Request.QueryString["clid"]).ToString();
           


            Parameters.Clear();
            Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));
            clsm.Fillcombo_Parameter(" select DeptName,deptid from Department_Master where status=1 and schoolid=@collageid  order by  displayorder " +
                "", Parameters, drpdept);

            Parameters.Clear();
            Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));
            lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
            fillgrid();
             checkgrid();
        }

    }

    protected void Tesid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        fillgrid();
      checkgrid();
    }

    public void fillgrid()
    {

        Parameters.Clear();
        string strsql = "Select imgid,rqstid,imgtitle,uploadimage,displayorder from list_of_Recruiters where status=1 ";


        strsql += "  group by imgid,rqstid,imgtitle,uploadimage,displayorder   ";
        strsql += " order by displayorder ";
        //Response.Write(strsql);
        clsm.datalistDatashow_Parameter(dl_sgroup, strsql, Parameters);
        if ((dl_sgroup.Items.Count == 0))
        {
            btnsubmit.Visible = false;
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found";
            Panel2.Visible = false;
        }
        else
        {
            btnsubmit.Visible = true;
            Panel2.Visible = true;
            checkgrid();
            arrnage();
        }

        //checkgrid()
    }

    public void checkgrid()
    {
        Parameters.Clear();
        Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));

        string strsql = "select collageid,imgid,deptid,displayorder,showonhome from map_institute_recruiter where collageid=@collageid ";
        if (Conversion.Val(drpdept.SelectedValue) > 0)
        {
            Parameters.Add("@deptid", Conversion.Val(drpdept.SelectedValue));
            strsql += " and deptid=@deptid";
        }
        DataSet ds1 = clsm.senddataset_Parameter(strsql, Parameters);
        int j;
        if ((ds1.Tables[0].Rows.Count > 0))
        {
            for (j = 0; (j
                        <= (ds1.Tables[0].Rows.Count - 1)); j++)
            {
                foreach (DataListItem rptrsch in dl_sgroup.Items)
                {
                    Label lbltestimonialid = (Label)rptrsch.FindControl("lbltestimonialid");
                    Label lblcname = (Label)rptrsch.FindControl("lblcname");
                    CheckBox checkfeature = (CheckBox)rptrsch.FindControl("checkfeature");
                    TextBox txtdisplayorder = (TextBox)rptrsch.FindControl("txtdisplayorder");
                    CheckBox showcheck = (CheckBox)rptrsch.FindControl("showcheck");
                    if (((Conversion.Val(Request.QueryString["clid"]) == Conversion.Val(ds1.Tables[0].Rows[j]["collageid"]))
                                   && (double.Parse(lbltestimonialid.Text) == Conversion.Val(ds1.Tables[0].Rows[j]["imgid"])) && (Conversion.Val(drpdept.SelectedValue) == Conversion.Val(ds1.Tables[0].Rows[j]["deptid"]))))
                    {
                        checkfeature.Checked = true;
                        lblcname.Attributes.Add("Style", "color: black;font-weight:bold;");
                        txtdisplayorder.Text = ds1.Tables[0].Rows[j]["displayorder"].ToString();

                        if (Convert.ToString(ds1.Tables[0].Rows[j]["showonhome"]) == "True")
                        {
                            showcheck.Checked = true;
                        }
                        if (Convert.ToString(ds1.Tables[0].Rows[j]["showonhome"]) == "False")
                        {
                            showcheck.Checked = false;
                        }
                    }

                }

            }

        }

    }

    private void arrnage()
    {
        DataTable dtcheck = new DataTable();

        DataColumn Testimonialname = new DataColumn();
        DataColumn testimonialid = new DataColumn();
        DataColumn uploadphoto = new DataColumn();
        DataColumn Course = new DataColumn();

        Testimonialname.ColumnName = "imgtitle";
        testimonialid.ColumnName = "imgid";
        uploadphoto.ColumnName = "uploadimage";
       // Course.ColumnName = "Course";

        Testimonialname.DataType = System.Type.GetType("System.String");
        testimonialid.DataType = System.Type.GetType("System.Int32");
        uploadphoto.DataType = System.Type.GetType("System.String");
       // Course.DataType = System.Type.GetType("System.String");


        dtcheck.Columns.Add(Testimonialname);
        dtcheck.Columns.Add(testimonialid);
        dtcheck.Columns.Add(uploadphoto);
       // dtcheck.Columns.Add(Course);



        DataTable dtuncheck = new DataTable();
        dtuncheck = dtcheck.Clone();

        DataRow row;
        foreach (DataListItem grow in dl_sgroup.Items)
        {
            CheckBox checkfeature = grow.FindControl("checkfeature") as CheckBox;
            Label lblcname = grow.FindControl("lblcname") as Label;
            Label lbltestimonialid = grow.FindControl("lbltestimonialid") as Label;
            TextBox txtfacultyImage = grow.FindControl("txtfacultyImage") as TextBox;
            Label lblcourse = grow.FindControl("lblcourse") as Label;
            if (checkfeature.Checked == true)
            {
                row = dtcheck.NewRow();
                row["imgtitle"] = lblcname.Text;
                row["imgid"] = Conversion.Val(lbltestimonialid.Text);
                row["uploadimage"] = txtfacultyImage.Text;
                //row["Course"] = lblcourse.Text;
                dtcheck.Rows.Add(row);
            }
            else
            {
                row = dtuncheck.NewRow();
                row["imgtitle"] = lblcname.Text;
                row["imgid"] = Conversion.Val(lbltestimonialid.Text);
                row["uploadimage"] = txtfacultyImage.Text;
               // row["Course"] = lblcourse.Text;
                dtuncheck.Rows.Add(row);
            }
        }

        dtcheck.Merge(dtuncheck);
        dl_sgroup.DataSource = dtcheck;
        dl_sgroup.DataBind();
        checkgrid();

    }
    protected void dl_sgroup_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TextBox txtfacultyImage = e.Item.FindControl("txtfacultyImage") as TextBox;
            HtmlImage imagefaculty = e.Item.FindControl("imagefaculty") as HtmlImage;

            Label lblcollage = e.Item.FindControl("lblcollage") as Label;
            Label lbltestimonialid = e.Item.FindControl("lbltestimonialid") as Label;
            if (!string.IsNullOrEmpty(txtfacultyImage.Text))
            {
                imagefaculty.Src = "~/Uploads/Recruiters/" + txtfacultyImage.Text;
            }
            DataSet ds = new DataSet();
            ds = clsm.sendDataset("select collagename from collage_master cm inner join   map_institute_recruiter mp  on cm.collageid=mp.collageid where mp.deptid=0 and mp.imgid=" + Conversion.Val(lbltestimonialid.Text) + "", true);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                {
                    lblcollage.Text += Convert.ToString(ds.Tables[0].Rows[i]["collagename"]) + "<br/>";
                }
                lblcollage.Text = lblcollage.Text.TrimEnd(',');
            }


        }
    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        try
        {
            map_cat_product();
            checkgrid();
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    public void map_cat_product()
    {
        foreach (DataListItem row1 in dl_sgroup.Items)
        {
            Label lbltestimonialid = (Label)row1.FindControl("lbltestimonialid");
            CheckBox checkfeature = (CheckBox)row1.FindControl("checkfeature");
            TextBox txtdisplayorder = (TextBox)row1.FindControl("txtdisplayorder");

            CheckBox showcheck = (CheckBox)row1.FindControl("showcheck");

            if ((checkfeature.Checked == true))
            {

               
                if (Conversion.Val(drpdept.SelectedValue) != 0)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mtestimonialid from map_institute_recruiter where collageid="
                                    + (Conversion.Val(Request.QueryString["clid"]) + (" and imgid="
                                    + (Conversion.Val(lbltestimonialid.Text) + (" and deptid="
                                    + (Conversion.Val(drpdept.SelectedValue) + ""))))), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_institute_recruiter (collageid,imgid,deptid,displayorder) values("
                                        + (Conversion.Val(Request.QueryString["clid"]) + (","
                                        + (Conversion.Val(lbltestimonialid.Text) + (","
                                        + (Conversion.Val(drpdept.SelectedValue) + (","
                                        + (Conversion.Val(txtdisplayorder.Text) + ")"))))))), Parameters);
                    }
                    else
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("update  map_institute_recruiter  set  displayorder=" + txtdisplayorder.Text + " where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and imgid=" + Conversion.Val(lbltestimonialid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + " ", Parameters);

                    }
                }
                else
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mrecid from map_institute_recruiter where collageid="
                                   + Conversion.Val(Request.QueryString["clid"]) + " and imgid="
                                   + Conversion.Val(lbltestimonialid.Text) + " and deptid="
                                   + Conversion.Val(drpdept.SelectedValue) + "", Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_institute_recruiter (collageid,imgid,deptid,displayorder) values("
                                                  + (Conversion.Val(Request.QueryString["clid"]) + (","
                                                  + (Conversion.Val(lbltestimonialid.Text) + (","
                                                  + (Conversion.Val(0) + (","
                                                  + (Conversion.Val(txtdisplayorder.Text) + ")"))))))), Parameters);
                    }
                    else
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("update  map_institute_recruiter  set  displayorder='" + txtdisplayorder.Text + "' where collageid=" + Conversion.Val(Request.QueryString["clid"]) + " and imgid=" + Conversion.Val(lbltestimonialid.Text) + "  and deptid=" + Conversion.Val(drpdept.SelectedValue) + "  ", Parameters);

                    }
                }


                if (showcheck.Checked == true)
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update  map_institute_recruiter  set  showonhome=1 where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and imgid=" + Conversion.Val(lbltestimonialid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);
                }
                else
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update  map_institute_recruiter  set  showonhome=0 where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and imgid=" + Conversion.Val(lbltestimonialid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);
                }


            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from  map_institute_recruiter where  collageid=" + Conversion.Val(Request.QueryString["clid"]) + " and imgid=" + Conversion.Val(lbltestimonialid.Text) + "  and deptid=" + Conversion.Val(drpdept.SelectedValue) + "  ", Parameters);



            }

            trsuccess.Visible = true;
            lblsuccess.Text = "Recuriter Map Successfully.";
        }

        fillgrid();
    }

   

    protected void drpdept_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
       checkgrid();
    }
}