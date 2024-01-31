using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;

public partial class backoffice_socialwall_viewsocialwall : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    public int appno;
    protected void Page_Load(object sender, EventArgs e)
    {

        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!Page.IsPostBack)
        {
            Label1.Visible = false;
         
            bindata();

            if (Convert.ToString(Request.QueryString["edit"]) == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Updated Successfully.";
            }
        }

    }




    public void bindata()
    {

        Parameters.Clear();
        string strqry = "";
        strqry = "select a.* from socialwall a  where 1=1  ";
        if (ddlAlbum.SelectedValue != "0")
        {
            Parameters.Add("@type", ddlAlbum.SelectedValue);
            strqry += " and a.type=@type ";
        }
        strqry += " order by a.displayorder ";

        clsm.GridviewData_Parameter(GridView1, strqry, Parameters);
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "NO Record Found";

        }


    }



    protected void btn_Click(object sender, EventArgs e)
    {
        bindata();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        Label1.Visible = false;
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@sid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update socialwall set status=1 where sid=@sid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@sid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update socialwall set status=0 where sid=@sid", Parameters);
            }
            bindata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";

        }

        if (e.CommandName == "lnkstatus1")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtshowonmainsite = (TextBox)row.FindControl("txtshowonmainsite");

            if (txtshowonmainsite.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@sid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update socialwall set showonmainsite=1 where sid=@sid", Parameters);
            }
            else if (txtshowonmainsite.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@sid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update socialwall set showonmainsite=0 where sid=@sid", Parameters);
            }
            bindata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }

        if (e.CommandName == "lnkstatus2")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtshowonmicrosite = (TextBox)row.FindControl("txtshowonmicrosite");

            if (txtshowonmicrosite.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@sid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update socialwall set showonmicrosite=1 where sid=@sid", Parameters);
            }
            else if (txtshowonmicrosite.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@sid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update socialwall set showonmicrosite=0 where sid=@sid", Parameters);
            }
            bindata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }

        if (e.CommandName == "btnedit")
        {
            Response.Redirect("addsocialwall.aspx?sid=" + e.CommandArgument);
        }
        if (e.CommandName == "del")
        {
           
            Parameters.Clear();
            Parameters.Add("@sid", Convert.ToString(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from socialwall where sid=@sid", Parameters);
            Parameters.Clear();
            Parameters.Add("@sid", Convert.ToString(e.CommandArgument));
            string str = Convert.ToString(clsm.SendValue_Parameter("select UploadAImage from socialwall where sid=@sid", Parameters));
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\socialwall\\" + str);
            if (F1.Exists)
            {
                F1.Delete();
            }
            bindata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
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
            TextBox txtshowonmainsite = (TextBox)e.Row.FindControl("txtshowonmainsite");
            ImageButton lnkstatus1 = (ImageButton)e.Row.FindControl("lnkstatus1");
            TextBox txtshowonmicrosite = (TextBox)e.Row.FindControl("txtshowonmicrosite");
            ImageButton lnkstatus2 = (ImageButton)e.Row.FindControl("lnkstatus2");
            if (string.IsNullOrEmpty(lblimage.Text))
            {
                imgimage.Visible = false;
            }
            else
            {
                imgimage.Src = "../../Uploads/socialwall/" + lblimage.Text;
                imgimage.Visible = true;
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
            if (txtshowonmainsite.Text == "True")
            {
                lnkstatus1.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus1.ToolTip = "Active";
            }
            else if (txtshowonmainsite.Text == "False")
            {
                lnkstatus1.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus1.ToolTip = "Inactive";
            }


            if (txtshowonmicrosite.Text == "True")
            {
                lnkstatus2.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus2.ToolTip = "Active";
            }
            else if (txtshowonmicrosite.Text == "False")
            {
                lnkstatus2.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus2.ToolTip = "Inactive";
            }



            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

        }

    }
}