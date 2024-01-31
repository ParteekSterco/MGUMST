using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class backoffice_Fee_add_course_fee : System.Web.UI.Page
{

    public mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    string StrFileName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {

            if (Request.QueryString.HasKeys() == true)
            {
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["cfid"], out p) == true)
                {

                    string newsidval = Request.QueryString["cfid"].ToString();
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    parameters.Clear();
                    parameters.Add("@cfid", newsidval);
                    clsm.MoveRecord_Parameter(this, cfid.Parent, "Select * from coursefee p  where p.cfid=@cfid", parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(Uploadphoto.Text))
                    {
                        string photo1 = Uploadphoto.Text;

                        Image1.ImageUrl = "~/Uploads/SmallImages/" + Server.HtmlDecode(Uploadphoto.Text);
                        Image1.Visible = true;

                    }


                    CKeditor2.Text = details.Text;
                    CKeditor1.Text = shortdesc.Text;

                }

                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        details.Text = Server.HtmlEncode(CKeditor2.Text);
        shortdesc.Text = Server.HtmlEncode(CKeditor1.Text);


        if (string.IsNullOrEmpty(cfid.Text))
        {
            if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
            {
                if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                    return;
                }
                Uploadphoto.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
            }
            //else
            //{
            //    trnotice.Visible = true;
            //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
            //    return;
            //}




            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            string var = clsm.MasterSave(this, cfid.Parent, 12, mainclass.Mode.modeAdd, "coursefeeSP", Server.HtmlDecode(Session["UserId"].ToString()).ToString());
            CKeditor1.ReadOnly = false;
            CKeditor2.ReadOnly = false;

            //***************** for log history*********************

            clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(title.Text), Convert.ToString(var), Convert.ToString("Course Fee"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Course Fee");

            //*********************** end for log history*******************************
            if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
            {
                Uploadphoto.Text = HttpUtility.HtmlEncode(var + "cf_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
                if (F1.Exists)
                {
                    F1.Delete();
                }
                File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
            }



            Response.Redirect("add-course-fee.aspx?add=add");
        }
        else
        {
            if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
            {
                if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                    return;
                }
                Uploadphoto.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
            }



            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            string var = clsm.MasterSave(this, cfid.Parent, 12, mainclass.Mode.modeModify, "coursefeeSP", Session["UserId"].ToString()).ToString();
            CKeditor1.ReadOnly = false;
            CKeditor2.ReadOnly = false;

            //***************** for log history*********************

            clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(title.Text), Convert.ToString(var), Convert.ToString("Course Fee"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Course Fee");

            //*********************** end for log history*******************************

            if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
            {
                Uploadphoto.Text = HttpUtility.HtmlEncode(var + "cf_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
                if (F1.Exists)
                {
                    F1.Delete();
                }
                SqlConnection objcon = new SqlConnection(clsm.strconnect);
                objcon.Open();
                SqlCommand objcmd = new SqlCommand("update coursefee set Uploadphoto=@Uploadphoto where cfid=" + var.ToString() + "", objcon);
                objcmd.Parameters.Add(new SqlParameter("@Uploadphoto", Server.HtmlDecode(Uploadphoto.Text)));
                objcmd.ExecuteNonQuery();
                objcon.Close();
                File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
            }

            Response.Redirect("view-course-fee.aspx?edit=edit");

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
}