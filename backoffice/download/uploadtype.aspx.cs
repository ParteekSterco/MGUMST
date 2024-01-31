using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;


public partial class backoffice_download_uploadtype : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {
            if (Convert.ToInt32(Request.QueryString["mid"]) > 0)
            {
                Parameters.Clear();
                Parameters.Add("@UTId", Convert.ToInt32(Request.QueryString["mid"]));
                clsm.MoveRecord_Parameter(this, UTId.Parent, "select * from UploadType where UTId=@UTId", Parameters);
                UTId.Text = HttpUtility.HtmlDecode(UTId.Text);
                downloadtimes.SelectedValue = HttpUtility.HtmlDecode(downloadtimes.SelectedValue);
                Title.Text = HttpUtility.HtmlDecode(Title.Text);
                displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);
            }
            griddata();
            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record  Updated Successfully.";
            }
        }

    }

    private void griddata()
    {
        Parameters.Clear();
        clsm.GridviewData_Parameter(GridView1, "select * from UploadType order by displayorder", Parameters);
        //clsm.GridviewDatashow(GridView1, "select * from UploadType order by displayorder")
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "Record(s) not found.";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            Label1.Visible = false;

            if (Convert.ToInt32(clsm.MasterSave(this, UTId.Parent, 5, mainclass.Mode.modeCheckDuplicate, "UploadTypeSP", Convert.ToString(Session["UserId"]))) > 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "This Upload Type Already Exist.";
                return;
            }

            if (string.IsNullOrEmpty(UTId.Text))
            {
                status.Checked = true;
                string var = clsm.MasterSave(this, UTId.Parent, 5, mainclass.Mode.modeAdd, "UploadTypeSP", Convert.ToString(Session["UserId"]));
                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(Title.Text), Convert.ToString(var), Convert.ToString("Download Type"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Download");

                //*********************** end for log history*******************************

                clsm.ClearallPanel(this, UTId.Parent);
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            else
            {
                string var = clsm.MasterSave(this, UTId.Parent, 5, mainclass.Mode.modeModify, "UploadTypeSP", Convert.ToString(Session["UserId"]));
                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(Title.Text), Convert.ToString(var), Convert.ToString("Download Type"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Download");

                //*********************** end for log history*******************************
                Response.Redirect("uploadtype.aspx?edit=edit");
            }


        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clsm.ClearallPanel(this, UTId.Parent);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = e.Row.FindControl("lnkstatus") as ImageButton;
            TextBox txtstatus = e.Row.FindControl("txtstatus") as TextBox;
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
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "btnedit")
        {
            Response.Redirect("uploadtype.aspx?mid=" + e.CommandArgument);
        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = row.FindControl("txtstatus")as TextBox;
            if (txtstatus.Text == "False")
            {
               
                Parameters.Clear();
                Parameters.Add("@UTId", Convert.ToInt32(e.CommandArgument.ToString()));
                clsm.ExecuteQry_Parameter("update UploadType set status=1 where UTId=@UTId", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                
                Parameters.Clear();
                Parameters.Add("@UTId", Convert.ToInt32(e.CommandArgument.ToString()));
                clsm.ExecuteQry_Parameter("update UploadType set status=0 where UTId=@UTId", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully.";
        }

        if (e.CommandName == "btndel")
        {
          
            Parameters.Clear();
            Parameters.Add("@UTId", Convert.ToInt32(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from UploadType where UTId=@UTId", Parameters);
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";

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
            Label1.Visible = true;
            Label1.Text = ex.Message.ToString();
        }


    }
}
