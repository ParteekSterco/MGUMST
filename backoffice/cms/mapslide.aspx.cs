using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.IO;
using System.Data.SqlClient;

public partial class backoffice_cms_mapslide : System.Web.UI.Page
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
            pageid.Text = Convert.ToInt32(Request.QueryString["pageid"]).ToString();

            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["mapid"], out p) == true)
            {
                CKeditor1.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@mapid", Convert.ToInt32(Request.QueryString["mapid"]));
                clsm.MoveRecord_Parameter(this, mapid.Parent, "Select * From mappageslide Where mapid=@mapid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(details.Text);

                if (!string.IsNullOrEmpty(uploadimage.Text.Trim()))
                {
                    File1.Visible = true;
                    Image1.ImageUrl = "~/Uploads/banner/" + uploadimage.Text;
                    LinkButton1.Visible = true;
                    Image1.Visible = true;
                }
                else
                {
                    LinkButton1.Visible = false;
                }
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
        strq2 = "select * from mappageslide where 1=1  ";
        if (Conversion.Val(Request.QueryString["pageid"]) > 0)
        {
            Parameters.Add("@pageid", Conversion.Val(Request.QueryString["pageid"]));
            strq2 += " and pageid=@pageid";
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
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblimage = (Label)row.FindControl("lblimage");
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + lblimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }

            Parameters.Clear();
            Parameters.Add("@mapid", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from mappageslide where mapid=@mapid", Parameters);
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
                Parameters.Add("@mapid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update mappageslide set status=1 where mapid=@mapid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@mapid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update mappageslide set status=0 where mapid=@mapid", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }
        if (e.CommandName == "btnedit")
        {
            Response.Redirect("mapslide.aspx?pageid=" + Request.QueryString["pageid"] + "&mapid=" + e.CommandArgument);
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


            HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
            Label lblimage = (Label)e.Row.FindControl("lblimage");

            if (string.IsNullOrEmpty(lblimage.Text))
            {
                imgimage.Visible = false;
            }
            else
            {
                imgimage.Src = "../../Uploads/banner/" + Server.HtmlDecode(lblimage.Text);
                imgimage.Visible = true;
            }
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            details.Text = Server.HtmlEncode(CKeditor1.Text);
            CKeditor1.ReadOnly = true;
            if (string.IsNullOrEmpty(mapid.Text))
            {
                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    if (CheckImgType(Path.GetFileName(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                    uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                }
                else
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                    return;
                }

                CKeditor1.ReadOnly = true;
                string var = clsm.MasterSave(this,mapid.Parent, 8, mainclass.Mode.modeAdd, "mappageslideSp", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;

                if (File1.PostedFile.FileName != "")
                {
                    Parameters.Clear();
                    Parameters.Add("@mapid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select uploadimage from mappageslide where mapid=@mapid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + StrFileName));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\Uploads\\banner\\" + StrFileName)));
                }


                clsm.ClearallPanel(this, mapid.Parent);
                pageid.Text = Convert.ToInt32(Request.QueryString["pageid"]).ToString();
                griddata();
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            else
            {

                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                }

                string var = clsm.MasterSave(this, mapid.Parent, 8, mainclass.Mode.modeModify, "mappageslideSp", Convert.ToString(Session["UserId"]));

                if(File1.PostedFile.FileName != "")
                {
                    uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("pslide_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + Server.HtmlDecode(uploadimage.Text)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update mappageslide set uploadimage=@uploadimage where mapid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadimage", uploadimage.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + Server.HtmlDecode(uploadimage.Text)));
                }


                Response.Redirect("mapslide.aspx?pageid=" + Request.QueryString["pageid"] + "&edit=edit");

            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(uploadimage.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + uploadimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        Parameters.Clear();
        Parameters.Add("@pageid", Convert.ToInt32(Request.QueryString["pageid"]));
        Parameters.Add("@mapid", Conversion.Val(mapid.Text));
        clsm.ExecuteQry_Parameter("update mappageslide set uploadimage='' where  mapid=@mapid and  pageid=@pageid", Parameters);
        uploadimage.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
    public bool CheckImgType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".gif":
                return true;
            case ".png":
                return true;
            case ".jpg":
                return true;
            case ".jpeg":
                return true;
            case ".bmp":
                return true;
            case ".swf":
                return true;
            case ".webp":
                return true;
            case ".svg":
                return true;
            default:
                return false;
        }
    }
}