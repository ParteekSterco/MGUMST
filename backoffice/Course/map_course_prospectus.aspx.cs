using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;
using System.IO;
using System.Data.SqlClient;


public partial class backoffice_Course_map_course_prospectus : System.Web.UI.Page
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

            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["mcoursemap"], out p) == true)
            {
              
                Parameters.Clear();
                Parameters.Add("@mcoursemap", Convert.ToInt32(Request.QueryString["mcoursemap"]));
                clsm.MoveRecord_Parameter(this, mcoursemap.Parent, "Select * From map_course_prospectus Where mcoursemap=@mcoursemap", Parameters);
               

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
        strq2 = "select * from map_course_prospectus where 1=1  ";
        if (Conversion.Val(Request.QueryString["courseid"]) > 0)
        {
            Parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
            strq2 += " and courseid=@courseid";
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
            Parameters.Add("@mcoursemap", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from map_course_prospectus where mcoursemap=@mcoursemap", Parameters);


            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            Label lbldown = (Label)row.FindControl("lbldown");
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(lbldown.Text)));
            if (F1.Exists)
            {
                F1.Delete();
            }

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
                Parameters.Add("@mcoursemap", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update map_course_prospectus set status=1 where mcoursemap=@mcoursemap", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@mcoursemap", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update map_course_prospectus set status=0 where mcoursemap=@mcoursemap", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }

        if (e.CommandName == "downbtn")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lbldown = row.FindControl("lbldown") as Label;
            Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~/Uploads/prospectus/" + lbldown.Text);
        }
       


        if (e.CommandName == "btnedit")
        {
            Response.Redirect("map_course_prospectus.aspx?courseid=" + Request.QueryString["courseid"] + "&mcoursemap=" + e.CommandArgument);
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

            Image imgDown = e.Row.FindControl("imgDown") as Image;
            Label lbldown = e.Row.FindControl("lbldown") as Label;
            if (string.IsNullOrEmpty(lbldown.Text))
            {
                imgDown.Visible = false;
            }
            else
            {
                imgDown.Visible = true;
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
    protected void LinkButton2_Click(object sender, System.EventArgs e)
    {
        if ((prospectusfile.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(prospectusfile.Text)));
            if (F1.Exists)
            {
                F1.Delete();
            }
        }

        Parameters.Clear();
        Parameters.Add("@courseid", double.Parse(Request.QueryString["cid"]));
        clsm.SendValue_Parameter("update Course set coursebrochure='' where courseid=@courseid", Parameters);
        prospectusfile.Text = "";
       // Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton2.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
    public bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".doc":
                return true;

            case ".pdf":
                return true;

            case ".docx":
                return true;

            case ".txt":
                return true;

            default:
                return false;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(mcoursemap.Text))
            {

                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                    prospectusfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                string var = clsm.MasterSave(this, mcoursemap.Parent, 6, mainclass.Mode.modeAdd, "map_course_prospectusSP", Convert.ToString(Session["UserId"]));

                if ((File2.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@mcoursemap", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select prospectusfile from map_course_prospectus where mcoursemap=@mcoursemap", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + StrFileName));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\prospectus\\" + StrFileName)));
                }


                clsm.ClearallPanel(this, mcoursemap.Parent);
                courseid.Text = Convert.ToString(Conversion.Val(Request.QueryString["courseid"]));
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            else
            {

                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                }

                string var = clsm.MasterSave(this, mcoursemap.Parent, 6, mainclass.Mode.modeModify, "map_course_prospectusSP", Convert.ToString(Session["UserId"]));

                if ((File2.PostedFile.FileName != ""))
                {
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(prospectusfile.Text)));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    prospectusfile.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("cprosfile_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(prospectusfile.Text)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update map_course_prospectus set prospectusfile=@prospectusfile where mcoursemap="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@prospectusfile", prospectusfile.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + Server.HtmlDecode(prospectusfile.Text)));
                }

                Response.Redirect("map_course_prospectus.aspx?courseid=" + Request.QueryString["courseid"] + "&edit=edit");

            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }
}