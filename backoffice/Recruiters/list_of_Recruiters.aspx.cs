using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

public partial class backoffice_Recruiters_list_of_Recruiters : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {

            bindgridview();
            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["imgid"], out p) == true)
            {

                Parameters.Add("@imgid", Convert.ToString(Request.QueryString["imgid"]));
                clsm.MoveRecord_Parameter(this, imgid.Parent, "select * from list_of_Recruiters where imgid=@imgid", Parameters);
                if (!string.IsNullOrEmpty(uploadimage.Text))
                {

                    Image1.Visible = true;
                    Image1.ImageUrl = "../../Uploads/Recruiters/" + uploadimage.Text;
                }
                if (!string.IsNullOrEmpty(imagelist.Text))
                {
                    Image2.Visible = true;
                    Image2.ImageUrl = "../../Uploads/Recruiters/" + imagelist.Text;
                }

            }
            if (Convert.ToString(Request.QueryString["add"]) == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            if (Convert.ToString(Request.QueryString["edit"]) == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated Successfully.";
            }
        }

    }
    private void bindgridview()
    {

        clsm.GridviewDatashow(GridView1, "select * from list_of_Recruiters");
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "No record Found";
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            try
            {

                if (string.IsNullOrEmpty(imgid.Text))
                {

                    if (Convert.ToInt32(clsm.MasterSave(this, imgid.Parent,9, mainclass.Mode.modeCheckDuplicate, "list_of_RecruitersSP", Convert.ToString(Session["UserId"]))) > 0)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Duplicacy not allowed.";
                        return;
                    }

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of  .bmp, .jpg, .jpeg, .gif or .png'";
                            return;
                        }
                        uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    else
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of  .bmp, .jpg, .jpeg, .gif or .png'";
                        return;
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of  .bmp, .jpg, .jpeg, .gif or .png'";
                            return;
                        }
                        imagelist.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of  .bmp, .jpg, .jpeg, .gif or .png'";
                    //    return;
                    //}

                    string var = clsm.MasterSave(this, imgid.Parent,9, mainclass.Mode.modeAdd, "list_of_RecruitersSP", Convert.ToString(Session["UserId"]));

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(imgtitle.Text), Convert.ToString(var), Convert.ToString("Recruiters"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Recruiters");

                    //*********************** end for log history*******************************
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        string strhomeimg = clsm.SendValue("Select uploadimage from list_of_Recruiters where imgid=" + Convert.ToInt32(var)).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Recruiters\\" + strhomeimg);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Recruiters\\" + strhomeimg);
                        trsuccess.Visible = true;
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        string strhomeimg = clsm.SendValue("Select imagelist from list_of_Recruiters where imgid=" + Convert.ToInt32(var)).ToString();
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Recruiters\\" + strhomeimg);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Recruiters\\" + strhomeimg);
                        trsuccess.Visible = true;
                    }


                    Response.Redirect("list_of_Recruiters.aspx?&add=add");


                }
                else if (!string.IsNullOrEmpty(imgid.Text))
                {
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of  .bmp, .jpg, .jpeg, .gif or .png'";
                            return;
                        }
                        uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of  .bmp, .jpg, .jpeg, .gif or .png'";
                            return;
                        }
                        imagelist.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }



                    string var = clsm.MasterSave(this, imgid.Parent,9, mainclass.Mode.modeModify, "list_of_RecruitersSP", Convert.ToString(Session["UserId"]));

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(imgtitle.Text), Convert.ToString(var), Convert.ToString("Recruiters"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Recruiters");

                    //*********************** end for log history*******************************

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "hlogo_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Recruiters\\" + uploadimage.Text.ToString());
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update list_of_Recruiters set uploadimage=@uploadimage where imgid=" + var.ToString() + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@uploadimage", Server.HtmlDecode(uploadimage.Text)));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Recruiters\\" + uploadimage.Text.ToString());
                        trsuccess.Visible = true;
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        imagelist.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "llogo_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Recruiters\\" + imagelist.Text.ToString());
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update list_of_Recruiters set imagelist=@imagelist where imgid=" + var.ToString() + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@imagelist", Server.HtmlDecode(imagelist.Text)));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Recruiters\\" + imagelist.Text.ToString());
                        trsuccess.Visible = true;
                    }

                    Response.Redirect("list_of_Recruiters.aspx?edit=edit");
                }

            }
            catch (Exception Err)
            {
                trerror.Visible = true;
                lblerror.Text = Err.Message;

            }
        }


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
            case ".webp":
                return true;
            default:
                return false;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("list_of_Recruiters.aspx");
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
            HtmlImage imgimage1 = (HtmlImage)e.Row.FindControl("imgimage1");
            Label lblimage1 = (Label)e.Row.FindControl("lblimage1");
            ImageButton lnkshowongroup = (ImageButton)e.Row.FindControl("lnkshowongroup");
            Label lblshowongroup = (Label)e.Row.FindControl("lblshowongroup");

            if (string.IsNullOrEmpty(lblimage.Text))
            {
                imgimage.Visible = false;
            }
            else
            {
                imgimage.Src = "../../Uploads/Recruiters/" + lblimage.Text;
                imgimage.Visible = true;
            }

           

            if (string.IsNullOrEmpty(lblimage1.Text))
            {
                imgimage1.Visible = false;
            }
            else
            {
                imgimage1.Src = "../../Uploads/Recruiters/" + lblimage1.Text;
                imgimage1.Visible = true;
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

            if (lblshowongroup.Text == "True")
            {
                lnkshowongroup.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkshowongroup.ToolTip = "Yes";
            }
            else if (lblshowongroup.Text == "False")
            {
                lnkshowongroup.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkshowongroup.ToolTip = "No";
            }


            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        imgid.Visible = false;
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@imgid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update list_of_Recruiters set status=1 where imgid=@imgid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@imgid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update list_of_Recruiters set status=0 where imgid=@imgid", Parameters);
            }



            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";

            


        }



        if (e.CommandName == "btnedit")
        {
            Response.Redirect("list_of_Recruiters.aspx?imgid=" + e.CommandArgument);
        }
        if (e.CommandName == "del")
        {
            Parameters.Clear();
            Parameters.Add("@imgid", Convert.ToString(e.CommandArgument));
            string str = Convert.ToString(clsm.SendValue_Parameter("select uploadimage from list_of_Recruiters where imgid=@imgid", Parameters));
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Recruiters\\" + str);
            if (F1.Exists)
            {
                F1.Delete();
            }
            Parameters.Clear();
            Parameters.Add("@imgid", Convert.ToString(e.CommandArgument));
            string str1 = Convert.ToString(clsm.SendValue_Parameter("select imagelist from list_of_Recruiters where imgid=@imgid", Parameters));
            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Recruiters\\" + str);
            if (F2.Exists)
            {
                F2.Delete();
            }

            Parameters.Clear();
            Parameters.Add("@imgid", Convert.ToString(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from list_of_Recruiters where imgid=@imgid", Parameters);
            Parameters.Clear();

            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
        }

        if (e.CommandName == "lnkshowonhome")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtshowonhome = (TextBox)row.FindControl("txtshowonhome");

            if (txtshowonhome.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@imgid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update list_of_Recruiters set showonhome=1 where imgid=@imgid", Parameters);
            }
            else if (txtshowonhome.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@imgid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update list_of_Recruiters set showonhome=0 where imgid=@imgid", Parameters);
            }
           
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }

        if (e.CommandName == "lnkshowongroup")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;

            Label lblshowongroup = (Label)row.FindControl("lblshowongroup");

            if (lblshowongroup.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@imgid", Convert.ToInt32(e.CommandArgument));
                string strsql = "update list_of_Recruiters set showongroup=1 where imgid=@imgid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);

            }
            else if (lblshowongroup.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@imgid", Convert.ToInt32(e.CommandArgument));
                string strsql = "update list_of_Recruiters set showongroup=0 where imgid=@imgid";
                clsm.ExecuteQry_Parameter(strsql, Parameters);

            }
           
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        bindgridview();
    }
}