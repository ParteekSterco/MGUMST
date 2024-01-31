using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class backoffice_Placement_Viewplacedstudent : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;

        if (!Page.IsPostBack)
        {
            Label1.Visible = false;

            Parameters.Clear();
            string str_college = "  select collagename,collageid from collage_master WHERE STATUS=1 ORDER BY DISPLAYORDER";
            clsm.Fillcombo_Parameter(str_college, Parameters, schoolid);

            Parameters.Clear();
            string str_college1 = "  select distinct placementssession,placementssession as sid from  Placedstudent order by  placementssession desc";
            clsm.Fillcombo_Parameter(str_college1, Parameters, Placementssession);

        

            griddata();

            if (Request.QueryString.HasKeys() == true)
            {
                if (Request.QueryString["edit"].ToString() == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";

                }
            }

        }
    }
    public void bindSessionyear()
    {
        int j = 0;
        int year = DateTime.Now.Year;
        for (int i = year; i >= 2000; i--)
        {
            j = i - 1;

            Placementssession.Items.Add(new ListItem(j.ToString() + "-" + i.ToString(), j.ToString() + "-" + i.ToString()));
            //ddlyear.Items.Add(i.ToString());
        }



    }

    protected void griddata()
    {
        Label1.Visible = false;
        string strq2 = string.Empty;
        DataSet ds = new DataSet();
        Parameters.Clear();

        strq2 = "Select c.coursename+''+c.coursesecondname as coursename1  ,p.*,cm.collagename from Placedstudent p left join course c on c.courseid=p.course left join collage_master cm on p.schoolid=cm.collageid  where 1=1   ";
        if ((Conversion.Val(schoolid.SelectedValue) != 0))
        {
            Parameters.Add("@schoolid", Conversion.Val(schoolid.SelectedValue));
            strq2 += " and p.schoolid=@schoolid";
        }
        if ((txtname.Text != ""))
        {
            Parameters.Add("@name", txtname.Text);
            strq2 += " and p.name like \'%\'+@name+\'%\'";
        }
        if ((Conversion.Val(Placementssession.SelectedValue) != 0))
        {
            Parameters.Add("@Placementssession",Placementssession.SelectedValue);
            strq2 += " and p.Placementssession=@Placementssession";
        }
        strq2 += " order by p.displayorder ";
        ds = clsm.senddataset_Parameter(strq2, Parameters);

        //clsm.GridviewData_Parameter(GridView1, strq2, Parameters);
        //clsm.GridviewDatashow(GridView1, strq2)
        if (ds.Tables[0].Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not data found";
            GridView1.Visible = false;
        }
        else
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "btndel")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            //Label lblimage = (Label)row.FindControl("lblimage");
            //FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + lblimage.Text);
            //if (F1.Exists)
            //{
            //    F1.Delete();
            //}
           
            Parameters.Clear();
            Parameters.Add("@aaid", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from Placedstudent where spid=@aaid", Parameters);
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
            //Label1.Visible = True
            //Label1.Text = "Record Deleted Successfully !!!"
        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");

            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@aaid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update Placedstudent set status=1 where spid=@aaid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@aaid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update Placedstudent set status=0 where spid=@aaid", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }
        if (e.CommandName == "lnkshowonhome")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtshowonhome = (TextBox)row.FindControl("txtshowonhome");

            if (txtshowonhome.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@aaid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update Placedstudent set showonhome=1 where spid=@aaid", Parameters);
            }
            else if (txtshowonhome.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@aaid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update Placedstudent set showonhome=0 where spid=@aaid", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }









        if (e.CommandName == "btnedit")
        {
            Response.Redirect("Placedstudents.aspx?spid=" + Convert.ToString(e.CommandArgument));
        }


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
            Label lblimage = (Label)e.Row.FindControl("lblimage");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
            TextBox txtshowonhome = (TextBox)e.Row.FindControl("txtshowonhome");
            ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
            string img = lblimage.Text;


            if (string.IsNullOrEmpty(lblimage.Text))
            {
                imgimage.Visible = false;
            }
            else
            {
                if (img.Contains("http") == true)
                {
                    imgimage.Src = Server.HtmlDecode(lblimage.Text);
                    imgimage.Visible = true;
                }
                else
                {
                    imgimage.Src = "../../Uploads/Placedstudent/" + Server.HtmlDecode(lblimage.Text);
                    imgimage.Visible = true;
                }



            }
            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }

            if (txtshowonhome.Text == "True")
            {
                lnkshowonhome.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkshowonhome.ToolTip = "Active";
            }
            else if (txtshowonhome.Text == "False")
            {
                lnkshowonhome.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkshowonhome.ToolTip = "Inactive";
            }



            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");


        }


    }
    protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            griddata();
        }
        catch (Exception ex)
        {
        }

    }

 
    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        griddata();
    }
}