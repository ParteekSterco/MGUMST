using System;
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

public partial class backoffice_collage_mapstaff : System.Web.UI.Page
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

        if ((Page.IsPostBack == false))
        {
            collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
            Parameters.Clear();
            clsm.Fillcombo_Parameter(" select stafftype,sid from stafftype where status=1   order by  displayorder " +
                "", Parameters, facultyid);
            //facultyid.SelectedValue = "1";



            Parameters.Clear();
            Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));
            clsm.Fillcombo_Parameter(" select DeptName,deptid from Department_Master where status=1 and schoolid=@collageid  order by  displayorder " +
                "", Parameters, drpdept);



            Parameters.Clear();
            Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));
            lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
            fillgrid();
            // checkgrid();
            //arrnage();


        }

    }

    protected void ntypeid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        fillgrid();
        checkgrid();
    }
    protected void drpdept_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        fillgrid();
        checkgrid();

    }

    void fillgrid()
    {
        string strsql;
        Parameters.Clear();
        strsql = "select distinct a.*,b.stafftype from Addstaffmaster a left join stafftype b on a.sid=b.sid  where 1=1 and  a.status=1";
        if ((TextBox4.Text != ""))
        {
            Parameters.Add("@fname", TextBox4.Text.Replace("\'", ""));
            strsql += " and fname like \'%\'+@fname+\'%\'";
        }



        if ((Conversion.Val(facultyid.SelectedValue) > 0))
        {
            Parameters.Add("@sid", double.Parse(facultyid.SelectedValue));
            strsql += " and a.sid =@sid";
        }

        strsql += " order by fname";
        clsm.datalistDatashow_Parameter(dl_sgroup, strsql, Parameters);
        if ((dl_sgroup.Items.Count == 0))
        {
            btnsubmit.Visible = false;
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found";
        }
        else
        {
            btnsubmit.Visible = true;
            checkgrid();
            arrnage();
        }

        //checkgrid();
    }

    public void checkgrid()
    {
        //  **************for attribute check***************
        Parameters.Clear();
        Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));


        string strsql = "select collageid,staffid,deptid,displayorder,showonhome from map_institute_department_staff where collageid=@collageid ";

        if (Conversion.Val(drpdept.SelectedValue) > 0)
        {
            Parameters.Add("@deptid", Conversion.Val(drpdept.SelectedValue));
            strsql += " and deptid=@deptid";
        }
        DataSet ds1 = clsm.senddataset_Parameter(strsql, Parameters);
        int j;
        if ((ds1.Tables[0].Rows.Count > 0))
        {
            for (j = 0; (j <= (ds1.Tables[0].Rows.Count - 1)); j++)
            {
                foreach (DataListItem rptrsch in dl_sgroup.Items)
                {
                    Label lblfacultyid = (Label)rptrsch.FindControl("lblfacultyid");
                    Label lblfname = (Label)rptrsch.FindControl("lblfname");
                    CheckBox checkfeature = (CheckBox)rptrsch.FindControl("checkfeature");
                    TextBox txtdisplayorder = (TextBox)rptrsch.FindControl("txtdisplayorder");
                    CheckBox showcheck = (CheckBox)rptrsch.FindControl("showcheck");


                    if (((double.Parse(Request.QueryString["clid"]) == Conversion.Val(ds1.Tables[0].Rows[j]["collageid"]))
                                && (double.Parse(lblfacultyid.Text) == Conversion.Val(ds1.Tables[0].Rows[j]["staffid"]))
                                && (double.Parse(drpdept.SelectedValue) == Conversion.Val(ds1.Tables[0].Rows[j]["deptid"]))))

                    //if (((double.Parse(Request.QueryString["clid"]) == Conversion.Val(ds1.Tables[0].Rows[j]["collageid"]))
                    //           && (double.Parse(lblfacultyid.Text) == Conversion.Val(ds1.Tables[0].Rows[j]["facultyid"]))))
                    {
                        checkfeature.Checked = true;
                        lblfname.Attributes.Add("Style", "color: black;font-weight:bold;");
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
        //  **************************************
    }

    protected void dl_sgroup_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            TextBox txtfacultyImage = e.Item.FindControl("txtfacultyImage") as TextBox;
            HtmlImage imagefaculty = e.Item.FindControl("imagefaculty") as HtmlImage;
            Label lblfacultyid = e.Item.FindControl("lblfacultyid") as Label;
            Literal litralschool = e.Item.FindControl("litralschool") as Literal;
            if (!string.IsNullOrEmpty(txtfacultyImage.Text))
            {
                imagefaculty.Src = "~/Uploads/faculty/" + txtfacultyImage.Text;
            }
            DataSet ds = new DataSet();

            ds = clsm.sendDataset("select collagename from collage_master cm inner join   map_institute_department_staff mp  on cm.collageid=mp.collageid where mp.deptid=0 and mp.staffid=" + Conversion.Val(lblfacultyid.Text) + "", true);


            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
                {

                    litralschool.Text += Convert.ToString(ds.Tables[0].Rows[i]["collagename"]) + "<br/>";
                }

                litralschool.Text = litralschool.Text.TrimEnd(',');
            }


        }
    }


    private void arrnage()
    {
        DataTable dtcheck = new DataTable();

        DataColumn fname = new DataColumn();
        DataColumn facultyid = new DataColumn();
        DataColumn fimage = new DataColumn();

        fname.ColumnName = "fname";
        facultyid.ColumnName = "staffid";
        fimage.ColumnName = "fimage";

        fname.DataType = System.Type.GetType("System.String");
        fimage.DataType = System.Type.GetType("System.String");
        facultyid.DataType = System.Type.GetType("System.Int32");


        dtcheck.Columns.Add(fname);
        dtcheck.Columns.Add(facultyid);
        dtcheck.Columns.Add(fimage);



        DataTable dtuncheck = new DataTable();

        dtuncheck = dtcheck.Clone();

        DataRow row;
        foreach (DataListItem grow in dl_sgroup.Items)
        {
            CheckBox checkfeature = grow.FindControl("checkfeature") as CheckBox;
            Label lblfname = grow.FindControl("lblfname") as Label;
            Label lblfacultyid = grow.FindControl("lblfacultyid") as Label;
            TextBox txtfacultyImage = grow.FindControl("txtfacultyImage") as TextBox;




            if (checkfeature.Checked == true)
            {
                row = dtcheck.NewRow();
                row["fname"] = lblfname.Text;
                row["staffid"] = Conversion.Val(lblfacultyid.Text);
                row["fimage"] = txtfacultyImage.Text;


                dtcheck.Rows.Add(row);
            }
            else
            {
                row = dtuncheck.NewRow();
                row["fname"] = lblfname.Text;
                row["staffid"] = Conversion.Val(lblfacultyid.Text);
                row["fimage"] = txtfacultyImage.Text;


                dtuncheck.Rows.Add(row);
            }
        }


        dtcheck.Merge(dtuncheck);
        dl_sgroup.DataSource = dtcheck;
        dl_sgroup.DataBind();
        checkgrid();





    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        try
        {

            map_cat_product();
            checkgrid();
            // ' clsm.SendMail(HttpContext.Current.Request.Url.AbsoluteUri.ToString())
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    void map_cat_product()
    {
        foreach (DataListItem row1 in dl_sgroup.Items)
        {


            Label lblfacultyid = (Label)row1.FindControl("lblfacultyid");
            CheckBox checkfeature = (CheckBox)row1.FindControl("checkfeature");
            TextBox txtdisplayorder = (TextBox)row1.FindControl("txtdisplayorder");

            CheckBox showcheck = (CheckBox)row1.FindControl("showcheck");


            if ((checkfeature.Checked == true))
            {

                if (Conversion.Val(drpdept.SelectedValue) != 0)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mfid from map_institute_department_staff where collageid="
                                    + (Conversion.Val(Request.QueryString["clid"]) + (" and staffid="
                                    + (Conversion.Val(lblfacultyid.Text) + (" and deptid="
                                    + (Conversion.Val(drpdept.SelectedValue) + ""))))), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_institute_department_staff (collageid,staffid,deptid,displayorder) values("
                                        + (Conversion.Val(Request.QueryString["clid"]) + (","
                                        + (Conversion.Val(lblfacultyid.Text) + (","
                                        + (Conversion.Val(drpdept.SelectedValue) + (","
                                        + (Conversion.Val(txtdisplayorder.Text) + ")"))))))), Parameters);
                    }
                    else
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("update  map_institute_department_staff  set  displayorder=" + txtdisplayorder.Text + " where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and staffid=" + Conversion.Val(lblfacultyid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);

                    }
                }
                else
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select mfid from map_institute_department_staff where collageid="
                                   + Conversion.Val(Request.QueryString["clid"]) + " and staffid="
                                   + Conversion.Val(lblfacultyid.Text) + " and deptid="
                                   + Conversion.Val(drpdept.SelectedValue) + "", Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_institute_department_staff (collageid,staffid,deptid,displayorder) values("
                                                  + (Conversion.Val(Request.QueryString["clid"]) + (","
                                                  + (Conversion.Val(lblfacultyid.Text) + (","
                                                  + (Conversion.Val(0) + (","
                                                  + (Conversion.Val(txtdisplayorder.Text) + ")"))))))), Parameters);
                    }
                    else
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("update  map_institute_department_staff  set  displayorder='" + txtdisplayorder.Text + "' where collageid=" + Conversion.Val(Request.QueryString["clid"]) + " and staffid=" + Conversion.Val(lblfacultyid.Text) + "  and deptid=" + Conversion.Val(drpdept.SelectedValue) + "  ", Parameters);

                    }
                }
                if (showcheck.Checked == true)
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update  map_institute_department_staff  set  showonhome=1 where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and staffid=" + Conversion.Val(lblfacultyid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);
                }
                else
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update  map_institute_department_staff  set  showonhome=0 where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and staffid=" + Conversion.Val(lblfacultyid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);
                }

            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from  map_institute_department_staff where  collageid=" + Conversion.Val(Request.QueryString["clid"]) + " and staffid=" + Conversion.Val(lblfacultyid.Text) + "  and deptid=" + Conversion.Val(drpdept.SelectedValue) + "  ", Parameters);

                

            }
            trsuccess.Visible = true;
            lblsuccess.Text = "Staff Map Successfully.";
        }

        fillgrid();
        checkgrid();
    }

    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        fillgrid();
        checkgrid();
    }


}