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


public partial class backoffice_Testimonials_viewtestimonials : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    public int appno;


    protected void Page_Load(object sender, System.EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!Page.IsPostBack)
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("Select Testimonialtype,Tesid,displayorder from Testimonials_Type where Status=1 order by displayorder" +
                "", Parameters, Tesid);
            bind_college();
            gridshow();
            if ((Request.QueryString["edit"] == "edit"))
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated successfully.";
            }

        }

    }
    public void bind_college()
    {
        Parameters.Clear();
        string str_college = "select distinct cm.collagename+'-('+c.campus_name+')' as collagename,cm.collageid from collage_master cm  inner join  campus c on cm.campusid=c.campusid  left join map_institiute_testimonials  mf  on  cm.collageid=mf.collageid  where cm.status=1 order by cm.collagename+'-('+c.campus_name+')' ";
        clsm.Fillcombo_Parameter(str_college, Parameters, ddl_college);
    }
    protected void gridshow()
    {
        string strsql;
        strsql = "select distinct a.*,b.Testimonialtype,b.displayorder  from Testimonials a left outer join Testimonials_Type b on a.tesid=b.tesid left join map_institiute_testimonials mt on a.testimonialid=mt.testimonialid  where 1=1";
        Parameters.Clear();
        if ((TextBox4.Text != ""))
        {
            Parameters.Add("@Testimonialname", TextBox4.Text);
            strsql += " and a.Testimonialname like \'%\'+@Testimonialname+\'%\'";
        }
        if ((TextBox5.Text != ""))
        {
            Parameters.Add("@Trdate", TextBox5.Text);
            strsql += " and a.Trdate >=@Trdate";
        }

        if ((TextBox6.Text != ""))
        {
            Parameters.Add("@Trdateone", TextBox6.Text);
            strsql += " and a.Trdate <=@Trdateone";
        }

        if ((double.Parse(Tesid.SelectedValue) != 0))
        {
            Parameters.Add("@tesid", double.Parse(Tesid.SelectedValue));
            strsql += " and a.tesid =@tesid";
        }

        if ((drttype.SelectedValue != "0"))
        {
            Parameters.Add("@texttype", drttype.SelectedValue);
            strsql += " and a.texttype =@texttype";
        }
        if ((Conversion.Val(ddl_college.SelectedValue) > 0))
        {
            Parameters.Add("@collageid", double.Parse(ddl_college.SelectedValue));
            strsql += " and mt.collageid=@collageid";
        }

        strsql += " order by  b.displayorder,a.displayorder ";
        clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
        appno = GridView1.Rows.Count;
        if ((GridView1.Rows.Count == 0))
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
        }

    }

    protected void GridView1_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridshow();
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "del"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox Uploadphoto = (TextBox)row.FindControl("Uploadphoto");
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\TestimonialImage\\" + Server.HtmlDecode(Uploadphoto.Text)));
            if (F1.Exists)
            {
                F1.Delete();
            }

           
            Parameters.Clear();
            Parameters.Add("@testimonialid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Testimonials where testimonialid=@testimonialid", Parameters);
            gridshow();
            trnotice.Visible = true;
            lblnotice.Text = "Record deleted successfully.";
        }

        if ((e.CommandName == "status"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if ((txtstatus.Text == "False"))
            {
               
                Parameters.Clear();
                Parameters.Add("@testimonialid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Testimonials set status=1 where testimonialid=@testimonialid", Parameters);
            }
            else if ((txtstatus.Text == "True"))
            {
              
                Parameters.Clear();
                Parameters.Add("@testimonialid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Testimonials set status=0 where testimonialid=@testimonialid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "statush"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatush = (TextBox)row.FindControl("txtstatush");
            if ((txtstatush.Text == "False"))
            {
                
                Parameters.Clear();
                Parameters.Add("@testimonialid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Testimonials set showonhome=1 where testimonialid=@testimonialid", Parameters);
            }
            else if ((txtstatush.Text == "True"))
            {
               
                Parameters.Clear();
                Parameters.Add("@testimonialid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Testimonials set showonhome=0 where testimonialid=@testimonialid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "statush_right"))
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatush_right = (TextBox)row.FindControl("txtstatush_right");
            if ((txtstatush_right.Text == "False"))
            {
              
                Parameters.Clear();
                Parameters.Add("@testimonialid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Testimonials set showright=1 where testimonialid=@testimonialid", Parameters);
            }
            else if ((txtstatush_right.Text == "True"))
            {
               
                Parameters.Clear();
                Parameters.Add("@testimonialid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update Testimonials set showright=0 where testimonialid=@testimonialid", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if ((e.CommandName == "edit"))
        {
            Response.Redirect(("addTestimonials.aspx?tid=" + Conversion.Val(e.CommandArgument)));
        }

    }

    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
            ImageButton lnkstatush = (ImageButton)e.Row.FindControl("lnkstatush");
            TextBox txtstatush = (TextBox)e.Row.FindControl("txtstatush");
            TextBox txtuploadvedio = (TextBox)e.Row.FindControl("txtuploadvedio");
            HtmlImage imagevideo = (HtmlImage)e.Row.FindControl("imagevideo");
            HtmlImage image = (HtmlImage)e.Row.FindControl("image");
            TextBox txtTestimonialImage = (TextBox)e.Row.FindControl("txtTestimonialImage");
            HtmlImage imageTestimonial = (HtmlImage)e.Row.FindControl("imageTestimonial");
            ImageButton lnkstatush_right = (ImageButton)e.Row.FindControl("lnkstatush_right");
            TextBox txtstatush_right = (TextBox)e.Row.FindControl("txtstatush_right");
            if ((txtTestimonialImage.Text != ""))
            {
                imageTestimonial.Src = ("~/Uploads/TestimonialImage/" + txtTestimonialImage.Text);
            }

            if ((txtuploadvedio.Text != ""))
            {
                imagevideo.Visible = true;
                imagevideo.Src = "~/backoffice/assets/video-gallery-icon.png";
            }
            else
            {
                image.Visible = true;
                image.Src = "~/backoffice/assets/photo-gallery-icon.png";
            }

            if ((txtstatus.Text == "True"))
            {
                lnkstatus.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Yes";
            }
            else if ((txtstatus.Text == "False"))
            {
                lnkstatus.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkstatus.ToolTip = "No";
            }




            if ((txtstatush.Text == "True"))
            {
                lnkstatush.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkstatush.ToolTip = "Yes";
            }
            else if ((txtstatush.Text == "False"))
            {
                lnkstatush.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkstatush.ToolTip = "No";
            }



            if (txtstatush_right.Text == "True")
            {
                lnkstatush_right.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkstatush_right.ToolTip = "Yes";
            }
            else if ((txtstatush_right.Text == "False"))
            {
                lnkstatush_right.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkstatush.ToolTip = "No";
            }

            e.Row.Attributes.Add("onmouseover", ("this.style.backgroundColor=\'"
                            + (Server.HtmlDecode(Convert.ToString(Session["altColor"])) + "\'")));
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=\'#FFFFFF\'");
        }

        // If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
        //     e.Row.Cells(8).Visible = False
        // End If
    }

    protected void btnsearch_Click(object sender, System.EventArgs e)
    {
        gridshow();
    }
}