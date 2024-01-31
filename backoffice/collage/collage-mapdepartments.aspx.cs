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

public partial class backoffice_collage_collage_mapdepartments : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    HttpCookie AUserSession;


    protected void Page_Load(object sender, System.EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if ((Request.Cookies["AUserSession"] == null))
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        if ((Page.IsPostBack == false))
        {
            collageid.Text = Conversion.Val(Request.QueryString["clid"]).ToString();
            Parameters.Clear();
            Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));
            lblcollage.Text =Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
            fillgrid();
        }

    }

    public void fillgrid()
    {
        Parameters.Clear();
        string strsql = "Select deptid,DeptName from Department_Master where Status=1 ";
        strsql+= " order by displayorder";
        clsm.datalistDatashow_Parameter(dl_sgroup, strsql, Parameters);
        checkgrid();
    }

    public  void checkgrid()
    {
        //  **************for attribute check***************
        Parameters.Clear();
        Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));
        DataSet ds1 = clsm.senddataset_Parameter("select collageid,deptid from map_collage_departments where collageid=@collageid", Parameters);
        int j;
        if ((ds1.Tables[0].Rows.Count > 0))
        {
            for (j = 0; (j
                        <= (ds1.Tables[0].Rows.Count - 1)); j++)
            {
                foreach (DataListItem rptrsch in dl_sgroup.Items)
                {
                    Label lbldeptid = (Label)rptrsch.FindControl("lbldeptid");
                    Label lbldeptname = (Label)rptrsch.FindControl("lbldeptname");
                    CheckBox checkfeature = (CheckBox)rptrsch.FindControl("checkfeature");
                    if (((Conversion.Val(Request.QueryString["clid"]) == Conversion.Val(ds1.Tables[0].Rows[j]["collageid"]))
                                && (Conversion.Val(lbldeptid.Text) == Conversion.Val(ds1.Tables[0].Rows[j]["deptid"]))))
                    {
                        checkfeature.Checked = true;
                        lbldeptname.Attributes.Add("Style", "color: black;font-weight:bold;");
                    }

                }

            }

        }

        
    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        try
        {
            map_cat_product();
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    void map_cat_product()
    {
        bool flag = false;
        bool flag1 = false;
        string strdeptname = String.Empty;
        foreach (DataListItem row1 in dl_sgroup.Items)
        {
            Label lbldeptid = (Label)row1.FindControl("lbldeptid");
            Label lbldeptname =(Label) row1.FindControl("lbldeptname");
            CheckBox checkfeature =(CheckBox) row1.FindControl("checkfeature");
            if ((checkfeature.Checked == true))
            {
                Parameters.Clear();

                 if ((clsm.Checking_Parameter((" select mdeptid from map_collage_departments where collageid="
                                + (double.Parse(Request.QueryString["clid"]) + (" and deptid="
                                + (double.Parse(lbldeptid.Text) + "")))), Parameters) == false))
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter(("insert into map_collage_departments (collageid,deptid) values("
                                    + (double.Parse(Request.QueryString["clid"]) + (","
                                    + (double.Parse(lbldeptid.Text) + ")")))), Parameters);
                    flag1 = true;
                }
                else
                {
                    //  flag1 = True
                }

                
            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter(("delete from map_collage_departments where collageid="
                                + (double.Parse(Request.QueryString["clid"]) + (" and deptid="
                                + (double.Parse(lbldeptid.Text) + "  ")))), Parameters);
            }

        }
       
        strdeptname=(strdeptname.TrimEnd(','));
        // If flag = True Then
        // trnotice.Visible = True
        // lblnotice.Text = strdeptname & " Departments already mapped with other collage."
        // End If
        if ((flag1 == true))
        {
            trsuccess.Visible = true;
            lblsuccess.Text = "Department Map Successfully.";
        }

        fillgrid();
    }
}