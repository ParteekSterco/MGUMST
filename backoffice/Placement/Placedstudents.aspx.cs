using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Configuration;


public partial class backoffice_Placement_Placedstudents : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    string StrFileName = string.Empty;

    double ImageSize = 0;
    string ImageSizeErrorMesage = "";
    double BannerImageSize = 0;
    string BannerSizeErrorMesage = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        bindyear();
        //bindSessionyear();

        if (Page.IsPostBack == false)
        {


            clsm.Fillcombo_Parameter("select  coursename as coursename,courseid from course where status=1 order by displayorder", Parameters, Course);


            clsm.Fillcombo_Parameter("select collagename,collageid from  collage_master where status=1 order by displayorder", Parameters, schoolid);


            if (Request.QueryString.HasKeys() == true)
            {
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["spid"], out p) == true)
                {
                    string newsidval = Request.QueryString["spid"].ToString();

                    Parameters.Clear();
                    Parameters.Add("@spid", newsidval);
                    clsm.MoveRecord_Parameter(this, spid.Parent, "Select * from Placedstudent p  where p.spid=@spid", Parameters);

                    if (!string.IsNullOrEmpty(photo.Text))
                    {
                        string photo1 = photo.Text;
                        if (photo1.Contains("http") == true)
                        {
                            Image1.ImageUrl = Server.HtmlDecode(photo.Text);
                            Image1.Visible = true;
                        }
                        else
                        {
                            Image1.ImageUrl = "~/Uploads/Placedstudent/" + Server.HtmlDecode(photo.Text);
                            Image1.Visible = true;
                        }
                    }
                    // displayorder.Enabled = true;
                }

                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
            }
        }

    }
    //public void bindSessionyear()
    //{
    //    int j = 0;
    //    int year = DateTime.Now.Year;
    //    for (int i = year; i >= 2000; i--)
    //    {
    //        j = i - 1;

    //        Placementssession.Items.Add(new ListItem(j.ToString() + "-" + i.ToString(), j.ToString() + "-" + i.ToString()));
    //        //ddlyear.Items.Add(i.ToString());
    //    }



    //}


    public void bindyear()
    {
        int year = DateTime.Now.Year - 1;
        for (int i = year; i >= 2014; i--)
        {
            session.Items.Add(new ListItem("Placements Year-" + i.ToString(), i.ToString()));
        }
    }
    #region <<BUTTON EVENT>>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
          

            if (string.IsNullOrEmpty(spid.Text))
            {
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                    photo.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }
                //else
                //{
                //    trnotice.Visible = true;
                //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                //    return;
                //}
                string var = clsm.MasterSave(this, spid.Parent, 19, mainclass.Mode.modeAdd, "PlacedstudentSP", Session["UserId"].ToString()).ToString();

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(Name.Text), Convert.ToString(var), Convert.ToString("Placement"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Placement");

                //*********************** end for log history*******************************

                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {

                    Parameters.Clear();
                    Parameters.Add("@spid", var);
                    StrFileName = clsm.SendValue_Parameter("Select photo from Placedstudent where spid=@spid", Parameters).ToString();
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\Placedstudent\\" + StrFileName);
                    if (F1.Exists)
                    {
                      
                        Parameters.Clear();
                        Parameters.Add("@spid", var);
                        clsm.ExecuteQry_Parameter("delete from Placedstudent where spid=@spid", Parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "photo already exist, Please choose another name.";
                        return;
                    }
                    else
                    {
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\Placedstudent\\" + StrFileName);
                    }
                }

                Response.Redirect("Placedstudents.aspx?add=add");

            }
            else
            {

                string var = clsm.MasterSave(this, spid.Parent, 19, mainclass.Mode.modeModify, "PlacedstudentSP", Session["UserId"].ToString()).ToString();

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(Name.Text), Convert.ToString(var), Convert.ToString("Placement"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Placement");

                //*********************** end for log history*******************************
                //if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                //{
                //    Parameters.Clear();
                //    Parameters.Add("@spid", var);
                //    StrFileName = clsm.SendValue_Parameter("Select photo from Placedstudent where spid=@spid", Parameters).ToString();
                //    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\Placedstudent\\" + StrFileName);
                //}
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    //FileInfo F5 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\Placedstudent\\" + Server.HtmlDecode(photo.Text));
                    //if (F5.Exists)
                    //{
                    //    F5.Delete();
                    //}
                    photo.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "ps_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\Placedstudent\\" + Server.HtmlDecode(photo.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update Placedstudent set photo=@photo where spid=" + var.ToString() + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@photo", Server.HtmlDecode(photo.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();

                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\Placedstudent\\" + photo.Text);
                }


                Response.Redirect("Viewplacedstudent.aspx?edit=edit");
            }

        }
        catch (Exception ex)
        {
            //trerror.Visible = true;
            //lblerror.Text = ex.Message;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        spid.Visible = false;
        if (string.IsNullOrEmpty(spid.Text))
        {
            clsm.ClearallPanel(this, spid.Parent);
        }
        else
        {
            Response.Redirect("Viewplacedstudent.aspx");
            clsm.ClearallPanel(this, spid.Parent);
        }


    }
    #endregion

    #region << methods >>


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


    #endregion
}