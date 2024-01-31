using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;

public partial class backoffice_Course_mapcoursetype : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    public int appno;
    string StrFileName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            courseid.Text = Convert.ToInt32(Request.QueryString["courseid"]).ToString();
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select ctypename,ctid from coursetype  where status=1 order by displayorder", Parameters, ctid);
            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["mctid"], out p) == true)
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@mctid", Convert.ToInt32(Request.QueryString["mctid"]));
                clsm.MoveRecord_Parameter(this, mctid.Parent, "Select * From mapcoursetype Where mctid=@mctid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(details.Text);
                CKeditor2.Text = Server.HtmlDecode(shortdesc.Text);
                CKeditor3.Text = Server.HtmlDecode(details1.Text);

            }
            griddata();
            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Updated Successfully.";
            }
        }
    }
    protected void griddata()
    {
        Parameters.Clear();
        string strq2 = string.Empty;
        DataSet ds = new DataSet();
        strq2 = "Select mct.*,ct.ctypename From mapcoursetype mct inner join coursetype ct on mct.ctid=ct.ctid   where 1=1  ";
        if (Conversion.Val(Request.QueryString["courseid"]) > 0)
        {
            Parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
            strq2 += " and mct.courseid=@courseid";
        }
        ds = clsm.senddataset_Parameter(strq2, Parameters);
        if (ds.Tables[0].Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "No Data";
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
            Parameters.Clear();
            Parameters.Add("@mctid", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from mapcoursetype where mctid=@mctid", Parameters);
           griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@mctid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update mapcoursetype set status=1 where mctid=@mctid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@mctid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update mapcoursetype set status=0 where mctid=@mctid", Parameters);
            }
           griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }
        if (e.CommandName == "btnedit")
        {
            Response.Redirect("mapcoursetype.aspx?courseid=" + Request.QueryString["courseid"] + "&mctid=" + e.CommandArgument);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");

            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

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
            //Label1.Visible = true;
            //Label1.Text = ex.Message.ToString();
        }
    }
  

    protected void ctid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            details.Text = Server.HtmlEncode(CKeditor1.Text);
            shortdesc.Text = Server.HtmlEncode(CKeditor2.Text);
            details1.Text = Server.HtmlEncode(CKeditor3.Text);
            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            CKeditor3.ReadOnly = true;
            if (string.IsNullOrEmpty(mctid.Text))
            {
                if (Convert.ToInt32(clsm.MasterSave(this, mctid.Parent, 9, mainclass.Mode.modeCheckDuplicate, "mapcoursetypeSp", Session["UserId"].ToString())) > 0)
                {
                    trerror.Visible = true;
                    lblerror.Text = "Duplicacy not allowed.";
                    return;
                }


                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                string var = clsm.MasterSave(this, mctid.Parent, 9, mainclass.Mode.modeAdd, "mapcoursetypeSp", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(ctid.SelectedItem.Text), Convert.ToString(var), Convert.ToString("CourseType"), Convert.ToString(0), Convert.ToString(""));

                //*********************** end for log history***********


                clsm.ClearallPanel(this, mctid.Parent);
                courseid.Text = Convert.ToInt32(Request.QueryString["courseid"]).ToString();
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            else
            {



                string var = clsm.MasterSave(this, mctid.Parent, 9, mainclass.Mode.modeModify, "mapcoursetypeSp", Convert.ToString(Session["UserId"]));

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(ctid.SelectedItem.Text), Convert.ToString(var), Convert.ToString("CourseType"), Convert.ToString(0), Convert.ToString(""));

                //*********************** end for log history***********
                Response.Redirect("mapcoursetype.aspx?courseid=" + Request.QueryString["courseid"] + "&edit=edit");

            }
        
         }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }


}