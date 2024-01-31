using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class backoffice_blogs_add_blogs : System.Web.UI.Page
{

    public mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();

    string StrFileName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter("Select distinct bcattitle,bcatid,displayorder from blogcategory where Status=1 order by displayorder", parameters, CatId);


            parameters.Clear();
            clsm.Fillcombo_Parameter("Select distinct AutName,AutId,displayorder from AuthorMaster where Status=1 order by displayorder", parameters, AutId);


            parameters.Clear();
            clsm.Fillcombo_Parameter("Select distinct btopstitle,btopsid,displayorder from blogtopics where Status=1 order by displayorder", parameters, topicId);


            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            parameters.Clear();
            parameters.Add("@blogId",Conversion.Val(Request.QueryString["blogId"]));
            clsm.MoveRecord_Parameter(this, blogId.Parent, "select * from Blogs where  blogId=@blogId", parameters);
            
            CKeditor1.ReadOnly = false;
            CKeditor2.ReadOnly = false;
            CKeditor1.Text = Server.HtmlDecode(smalldesc.Text);
            CKeditor2.Text = Server.HtmlDecode(longdesc.Text);
            if (BlogImage.Text.Trim() != "")
            {
                File1.Visible = true;
                Image1.ImageUrl = "~/Uploads/Blogs/" + BlogImage.Text;
                LinkButton1.Visible = true;
                Image1.Visible = true;
            }
            else
            {
                LinkButton1.Visible = false;
            }

            if (LargeImage.Text.Trim() != "")
            {
                File2.Visible = true;
                Image2.ImageUrl = "~/Uploads/Blogs/" + LargeImage.Text;
                LinkButton2.Visible = true;
                Image2.Visible = true;
            }
            else
            {
                LinkButton2.Visible = false;
            }
        }

    }

    public bool CheckImgType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower() ?? "")
        {
            case ".gif":
                {
                    return true;
                }

            case ".png":
                {
                    return true;
                }

            case ".jpg":
                {
                    return true;
                }

            case ".jpeg":
                {
                    return true;
                }

            case ".bmp":
                {
                    return true;
                }

            case ".swf":
                {
                    return true;
                }
            case ".webp":
                {
                    return true;
                }

            default:
                {
                    return false;
                }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            smalldesc.Text = Server.HtmlEncode(CKeditor1.Text);
            longdesc.Text = Server.HtmlEncode(CKeditor2.Text);
            //companyname.Text = companyid.SelectedItem.Text;
            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            if (Conversion.Val(blogId.Text) == 0)
            {
                if (Path.GetFileName(File1.PostedFile.FileName) != "")
                {
                    if (CheckImgType(Path.GetFileName(File1.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }

                    BlogImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                }

                if (Path.GetFileName(File2.PostedFile.FileName) != "")
                {
                    if (CheckImgType(Path.GetFileName(File2.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }

                    LargeImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                }

                status.Checked = true;
                //var var = clsm.MasterSave(this, blogId.Parent, 22, mainclass.Mode.modeAdd, "blogsSP", Convert.ToString(Session["UserId"]));
                var var = clsm.MasterSave(this, blogId.Parent, 22, mainclass.Mode.modeAdd, "blogsSP", Convert.ToString(Session["UserId"]));

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(blogtitle.Text), Convert.ToString(var), Convert.ToString("Blog"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Blog");

                //*********************** end for log history*******************************

                if (Path.GetFileName(File1.PostedFile.FileName) != "")
                {
                    parameters.Clear();
                    parameters.Add("@blogId", Conversion.Val(var));
                    StrFileName =Convert.ToString(clsm.SendValue_Parameter("Select BlogImage from Blogs where blogId=@blogId", parameters));
                    var F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + @"Uploads\Blogs\" + StrFileName);
                    if (F1.Exists)
                    {
                        parameters.Clear();
                        parameters.Add("@blogId", Conversion.Val(var));
                        clsm.ExecuteQry_Parameter("delete from BlogImage where blogId=@blogId", parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    else
                    {
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + @"\uploads\Blogs\" + StrFileName);
                    }
                }

                if (Path.GetFileName(File2.PostedFile.FileName) != "")
                {
                    parameters.Clear();
                    parameters.Add("@blogId", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select LargeImage from Blogs where blogId=@blogId", parameters));
                    var F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + @"Uploads\Blogs\" + StrFileName);
                    if (F1.Exists)
                    {
                        parameters.Clear();
                        parameters.Add("@blogId", Conversion.Val(var));
                        clsm.ExecuteQry_Parameter("delete from LargeImage where blogId=@blogId", parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    else
                    {
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + @"\uploads\Blogs\" + StrFileName);
                    }
                }

                clsm.ClearallPanel(this, blogId.Parent);
                trsuccess.Visible = true;
                lblsuccess.Text = "Blog added successfully.";
            }
            else
            {
                var var = clsm.MasterSave(this, blogId.Parent, 22, mainclass.Mode.modeModify, "blogsSP", Convert.ToString(Session["UserId"]));

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(blogtitle.Text), Convert.ToString(var), Convert.ToString("Blog"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Blog");

                //*********************** end for log history*******************************
                if (Path.GetFileName(File1.PostedFile.FileName) != "")
                {
                    BlogImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "bs_" + Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                    var F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + @"Uploads\Blogs\" + Server.HtmlDecode(BlogImage.Text));
                    if (F1.Exists)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }

                    var objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    var objcmd = new SqlCommand("update Blogs set BlogImage=@BlogImage where blogId=" + Conversion.Val(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@BlogImage", Server.HtmlDecode(BlogImage.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + @"\uploads\Blogs\" + Server.HtmlDecode(BlogImage.Text));
                }

                if (Path.GetFileName(File2.PostedFile.FileName) != "")
                {
                    LargeImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "bl_" + Path.GetFileName(File2.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                    var F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + @"Uploads\Blogs\" + Server.HtmlDecode(LargeImage.Text));
                    if (F1.Exists)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }

                    var objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    var objcmd = new SqlCommand("update Blogs set LargeImage=@LargeImage where blogId=" + Conversion.Val(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@LargeImage", Server.HtmlDecode(LargeImage.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + @"\uploads\Blogs\" + Server.HtmlDecode(LargeImage.Text));
                }

                Response.Redirect("view-blogs.aspx?edit=edit");
            }

            CKeditor1.ReadOnly = false;
            CKeditor2.ReadOnly = false;
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (Conversion.Val(Request.QueryString["blogId"]) > 0)
        {
            Response.Redirect("viewblogs.aspx");
        }

        clsm.ClearallPanel(this, blogId.Parent);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (BlogImage.Text != "")
        {
            var F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + @"Uploads\Blogs\" + BlogImage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }

        parameters.Clear();
        parameters.Add("@blogId", Conversion.Val(Request.QueryString["blogId"]));
        clsm.ExecuteQry_Parameter("update Blogs set BlogImage='' where blogId=@blogId", parameters);
        BlogImage.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (LargeImage.Text != "")
        {
            var F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + @"Uploads\Blogs\" + LargeImage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }

        parameters.Clear();
        parameters.Add("@blogId", Conversion.Val(Request.QueryString["blogId"]));
        clsm.ExecuteQry_Parameter("update Blogs set LargeImage='' where blogId=@blogId", parameters);
        LargeImage.Text = "";
        Image2.Visible = false;
        trsuccess.Visible = true;
        LinkButton2.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }

}