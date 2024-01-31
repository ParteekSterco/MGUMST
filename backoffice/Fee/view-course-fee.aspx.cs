using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
public partial class backoffice_Fee_view_course_fee : System.Web.UI.Page
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

            griddata();

            if (Request.QueryString.HasKeys() == true)
            {
                if (Convert.ToString(Request.QueryString["edit"]) == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";

                }
            }

        }
    }

    protected void griddata()
    {

        string strq2 = string.Empty;
        DataSet ds = new DataSet();
        Parameters.Clear();
        strq2 = "Select * from coursefee t where 1=1  ";


        if (!string.IsNullOrEmpty(txttitle.Text))
        {
            Parameters.Add("@title", txttitle.Text);
            strq2 += " and t.title like '%'+@title+'%'";
        }


        strq2 += "  order by t.displayorder";

        ds = clsm.senddataset_Parameter(strq2, Parameters);

        if (ds.Tables[0].Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "No data found";
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


        if (e.CommandName == "del")
        {

            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblimagesmall = (Label)row.FindControl("lblimagesmall");

            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lblimagesmall.Text);
            if (F2.Exists)
            {
                F2.Delete();
            }


            Parameters.Clear();
            Parameters.Add("@cfid", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from coursefee where cfid=@cfid", Parameters);
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";

        }


        if (e.CommandName == "status")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");

            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@cfid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update coursefee set status=1 where cfid=@cfid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@cfid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update coursefee set status=0 where cfid=@cfid", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }



        if (e.CommandName == "edit")
        {
            Response.Redirect("add-course-fee.aspx?cfid=" + Convert.ToString(e.CommandArgument));

        }


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

            HtmlImage imgsmall = (HtmlImage)e.Row.FindControl("imgsmall");
            Label lblimagesmall = (Label)e.Row.FindControl("lblimagesmall");
            if (string.IsNullOrEmpty(lblimagesmall.Text))
            {
                imgsmall.Visible = false;
            }
            else
            {
                imgsmall.Src = "~/Uploads/SmallImages/" + lblimagesmall.Text;
                imgsmall.Visible = true;
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

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        griddata();
    }
}