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

public partial class backoffice_collage_collage_happenings : System.Web.UI.Page
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
            collageid.Text =Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select ntype,ntypeid from newstype where status=1  order by  displayorder " +
                "", Parameters, ntypeid);
          


            Parameters.Clear();
            Parameters.Add("@collageid", Conversion.Val(Request.QueryString["clid"]));
            clsm.Fillcombo_Parameter("select DeptName,deptid from Department_Master where status=1 and schoolid=@collageid  order by  displayorder " +
                "", Parameters, drpdept);



            Parameters.Clear();
            Parameters.Add("@collageid", Conversion.Val(Request.QueryString["clid"]));
            lblcollage.Text =Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
            fillgrid();
          //  checkgrid();
          //  arrange();
        }

    }

    protected void ntypeid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        fillgrid();
        checkgrid();
        //arrange();
    }
    protected void drpdept_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        fillgrid();
        checkgrid();
        //arrange();
    }

    void fillgrid()
    {
        string strsql;
        Parameters.Clear();
        strsql = "select distinct a.*,b.ntype from    Events a  left join newstype b on a.ntypeid=b.ntypeid     where 1=1";
        //if ((Conversion.Val(Request.QueryString["clid"])) > 0)
        //{
        //    Parameters.Add("@collageid",Conversion.Val(Request.QueryString["clid"]));
        //    strsql += " and cm.collageid =@collageid";
        //}
        if ((TextBox4.Text != ""))
        {
            Parameters.Add("@EventsTitle", TextBox4.Text.Replace("\'", ""));
          strsql+=  " and a.EventsTitle like \'%\'+@EventsTitle+\'%\'";
        }
        if ((TextBox5.Text != ""))
        {
            Parameters.Add("@EventsDate", TextBox5.Text.Replace("\'", ""));
            strsql += " and a.EventsDate >=@EventsDate";
        }
        if ((TextBox6.Text != ""))
        {
            DateTime dt = Convert.ToDateTime(TextBox6.Text);
            dt = dt.AddDays(0);
            strsql += (" and a.EventsDate <=\'"
                        + (dt + "\'"));
        }
        if ((Conversion.Val(ntypeid.SelectedValue) > 0))
        {
            Parameters.Add("@ntypeid", Conversion.Val(ntypeid.SelectedValue));
            strsql += " and a.ntypeid =@ntypeid";
        }
        strsql += " order by  a.EventsDate desc ,a.EventsTitle";
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
            arrange();
        }
        //checkgrid();
    }
    public void checkgrid()
    {
        //  **************for attribute check***************
        Parameters.Clear();
        Parameters.Add("@collageid", Conversion.Val(Request.QueryString["clid"]));
      //  Parameters.Add("@deptid", double.Parse(drpdept.SelectedValue));


        string strsql = "select collageid,Eventsid,deptid,displayorder,showonhome from map_institute_happenings where collageid=@collageid  ";

        if (Conversion.Val(drpdept.SelectedValue) > 0)
        {
            Parameters.Add("@deptid", Conversion.Val(drpdept.SelectedValue));
            strsql += " and deptid=@deptid";
        }

        DataSet ds1 = clsm.senddataset_Parameter(strsql, Parameters);
        int j;
        if ((ds1.Tables[0].Rows.Count > 0))
        {
            for (j = 0; (j<= (ds1.Tables[0].Rows.Count - 1)); j++)
            {
                foreach (DataListItem rptrsch in dl_sgroup.Items)
                {
                    Label lblEventsid = (Label)rptrsch.FindControl("lblEventsid");
                    Label lblcname = (Label)rptrsch.FindControl("lblcname");
                    CheckBox checkfeature = (CheckBox)rptrsch.FindControl("checkfeature");
                    TextBox txtdisplayorder = (TextBox)rptrsch.FindControl("txtdisplayorder");

                    CheckBox showcheck = (CheckBox)rptrsch.FindControl("showcheck");


                    if (((Conversion.Val(Request.QueryString["clid"]) == Conversion.Val(ds1.Tables[0].Rows[j]["collageid"]))
                                && (Conversion.Val(lblEventsid.Text) == Conversion.Val(ds1.Tables[0].Rows[j]["Eventsid"])) && (Conversion.Val(drpdept.SelectedValue) == Conversion.Val(ds1.Tables[0].Rows[j]["deptid"]))))
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


                    
                    //Response.Write(ds1.Tables[0].Rows[j]["displayorder"].ToString());
                }
            }
        }
        //  **************************************
    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        try
        {

            map_cat_product();
            checkgrid();
            //arrange();
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

           
            Label lblEventsid = (Label)row1.FindControl("lblEventsid");
            CheckBox checkfeature = (CheckBox)row1.FindControl("checkfeature");
            TextBox txtdisplayorder = (TextBox)row1.FindControl("txtdisplayorder");

            CheckBox showcheck = (CheckBox)row1.FindControl("showcheck");

            



            if ((checkfeature.Checked == true))
            {

                if (Conversion.Val(drpdept.SelectedValue) != 0)
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select meventid from map_institute_happenings where collageid="
                                    + (Conversion.Val(Request.QueryString["clid"]) + (" and Eventsid="
                                    + (Conversion.Val(lblEventsid.Text) + (" and deptid="
                                    + (Conversion.Val(drpdept.SelectedValue) + ""))))), Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_institute_happenings (collageid,Eventsid,deptid,displayorder) values("
                                        + (Conversion.Val(Request.QueryString["clid"]) + (","
                                        + (Conversion.Val(lblEventsid.Text) + (","
                                        + (Conversion.Val(drpdept.SelectedValue) + (","
                                        + (Conversion.Val(txtdisplayorder.Text) + ")"))))))), Parameters);
                    }
                    else
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("update  map_institute_happenings  set  displayorder=" + txtdisplayorder.Text + " where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and Eventsid=" + Conversion.Val(lblEventsid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);

                    }
                }
                else
                {
                    Parameters.Clear();
                    if (clsm.Checking_Parameter("select meventid from map_institute_happenings where collageid="
                                   + Conversion.Val(Request.QueryString["clid"]) + " and Eventsid="
                                   + Conversion.Val(lblEventsid.Text) + " and deptid="
                                   + Conversion.Val(drpdept.SelectedValue) + "", Parameters) == false)
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("insert into map_institute_happenings (collageid,Eventsid,deptid,displayorder) values("
                                                  + (Conversion.Val(Request.QueryString["clid"]) + (","
                                                  + (Conversion.Val(lblEventsid.Text) + (","
                                                  + (Conversion.Val(0) + (","
                                                  + (Conversion.Val(txtdisplayorder.Text) + ")"))))))), Parameters);
                    }
                    else
                    {
                        Parameters.Clear();
                        clsm.ExecuteQry_Parameter("update  map_institute_happenings  set  displayorder='" + txtdisplayorder.Text + "' where collageid=" + Conversion.Val(Request.QueryString["clid"]) + " and Eventsid=" + Conversion.Val(lblEventsid.Text) + "  and deptid=" + Conversion.Val(drpdept.SelectedValue) + "  ", Parameters);

                    }


                }
                if (showcheck.Checked == true)
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update  map_institute_happenings  set  showonhome=1 where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and Eventsid=" + Conversion.Val(lblEventsid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);
                }
                else
                {
                    Parameters.Clear();
                    clsm.ExecuteQry_Parameter("update  map_institute_happenings  set  showonhome=0 where collageid=" + (Conversion.Val(Request.QueryString["clid"])) + " and Eventsid=" + Conversion.Val(lblEventsid.Text) + " and deptid=" + Conversion.Val(drpdept.SelectedValue) + "", Parameters);
                }

            }
            else
            {
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("delete from  map_institute_happenings where  collageid=" + Conversion.Val(Request.QueryString["clid"]) + " and Eventsid=" + Conversion.Val(lblEventsid.Text) + "  and deptid=" + Conversion.Val(drpdept.SelectedValue) + "  ", Parameters);

            }

           
          

            trsuccess.Visible = true;
            lblsuccess.Text = "Happening Map Successfully.";
        }

        fillgrid();
        checkgrid();
       // arrange();
    }

    protected void btnSearch_Click(object sender, System.EventArgs e)
    {
        fillgrid();
        checkgrid();
      
    }

    private void arrange()
    {
        DataTable dtItems = new DataTable();
        DataColumn Eventsid = new DataColumn();
        DataColumn EventsTitle = new DataColumn();
        Eventsid.ColumnName = "Eventsid";
        EventsTitle.ColumnName = "EventsTitle";
        Eventsid.DataType = System.Type.GetType("System.Int32");
        EventsTitle.DataType = System.Type.GetType("System.String");

        dtItems.Columns.Add(Eventsid);
        dtItems.Columns.Add(EventsTitle);
        DataTable dtitemsanother = new DataTable();
        dtitemsanother = dtItems.Clone();
        DataRow row;
        foreach (DataListItem row1 in dl_sgroup.Items)
        {
            Label lblEventsid = (Label)row1.FindControl("lblEventsid");
            Label lblcname = (Label)row1.FindControl("lblcname");
            CheckBox checkfeature = (CheckBox)row1.FindControl("checkfeature");
            if ((checkfeature.Checked == true))
            {
                row = dtItems.NewRow();
                row["Eventsid"] = Conversion.Val(lblEventsid.Text);
                row["EventsTitle"] = lblcname.Text;
                dtItems.Rows.Add(row);
            }
            else
            {
                row = dtitemsanother.NewRow();
                row["Eventsid"] = Conversion.Val(lblEventsid.Text);
                row["EventsTitle"] = lblcname.Text;
                dtitemsanother.Rows.Add(row);
            }

        }

        dtItems.Merge(dtitemsanother);
        dl_sgroup.DataSource = dtItems;
        dl_sgroup.DataBind();
        checkgrid();
    }
}