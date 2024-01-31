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
using System.Net;
using System.Net.Mail;
using Microsoft.VisualBasic;

public partial class backoffice_campus_centres : System.Web.UI.Page
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
            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["cmpid"], out p) == true)
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@campusid", Convert.ToInt32(Request.QueryString["cmpid"]));
                string strsql1 = "Select * From campus Where campusid=@campusid";
                clsm.MoveRecord_Parameter(this, campusid.Parent, strsql1, Parameters);
                campusid.Text = HttpUtility.HtmlDecode(campusid.Text);
                displayorder.Text = HttpUtility.HtmlDecode(displayorder.Text);
                campus_name.Text = HttpUtility.HtmlDecode(campus_name.Text);
                campus_code.Text = HttpUtility.HtmlDecode(campus_code.Text);
                
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;

                CKeditor1.Text = Server.HtmlDecode(details.Text);
                CKeditor2.Text = Server.HtmlDecode(shortdesc.Text);
                CKeditor3.Text = Server.HtmlDecode(details2.Text);
                CKeditor4.Text = Server.HtmlDecode(details3.Text);
                CKeditor5.Text = Server.HtmlDecode(details4.Text);
                if(banner.Text != "")
                {
                    Image1.ImageUrl = ("~/Uploads/SmallImages/" + banner.Text);
                    Image1.Visible = true;
                    lnkremove.Visible = true;
                }
                if(clogo.Text != "")
                {
                    Image2.ImageUrl = ("~/Uploads/SmallImages/" + clogo.Text);
                    Image2.Visible = true;
                    lnkremove1.Visible = true;
                }
                if (homebanner.Text != "")
                {
                    Image3.ImageUrl = ("~/Uploads/SmallImages/" + homebanner.Text);
                    Image3.Visible = true;
                    lnkremove2.Visible = true;
                }
                if (factimage.Text != "")
                {
                    Image4.ImageUrl = ("~/Uploads/SmallImages/" + factimage.Text);
                    Image4.Visible = true;
                    lnkremove3.Visible = true;
                }
            }
            
            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Updated Successfully.";
            }
        }


    }
   
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string StrFileName;

            details.Text = Server.HtmlDecode(CKeditor1.Text);
            shortdesc.Text = Server.HtmlDecode(CKeditor2.Text);
            details2.Text = Server.HtmlDecode(CKeditor3.Text);
            details3.Text = Server.HtmlDecode(CKeditor4.Text);
            details4.Text = Server.HtmlDecode(CKeditor5.Text);


            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            CKeditor3.ReadOnly = true;
            CKeditor4.ReadOnly = true;
            CKeditor5.ReadOnly = true;
            if (Convert.ToInt32(clsm.MasterSave(this, campusid.Parent, 23, mainclass.Mode.modeCheckDuplicate, "campusSP", Convert.ToString(Session["UserId"]))) > 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Duplicacy not allowed.";
                return;
            }

            if (string.IsNullOrEmpty(campusid.Text))
            {
                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName)) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png\'";
                        return;
                    }
                    banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName)) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png\'";
                        return;
                    }
                    clogo.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                if ((File3.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(Path.GetFileName(File3.PostedFile.FileName)) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png\'";
                        return;
                    }
                    homebanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                if ((File4.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(Path.GetFileName(File4.PostedFile.FileName)) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png\'";
                        return;
                    }
                    factimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }


                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                string var = clsm.MasterSave(this, campusid.Parent, 23, mainclass.Mode.modeAdd, "campusSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(campus_name.Text), Convert.ToString(var), Convert.ToString("Campus"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Campus");

                //*********************** end for log history*******************************
                
                if ((File1.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@campusid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select banner from campus where campusid=@campusid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + StrFileName)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + StrFileName)));
                }
                if ((File2.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@campusid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select clogo from campus where campusid=@campusid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + StrFileName)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + StrFileName)));
                }
                if ((File3.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@campusid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select homebanner from campus where campusid=@campusid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + StrFileName)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File3.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + StrFileName)));
                }
                if ((File4.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@campusid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select factimage from campus where campusid=@campusid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + StrFileName)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File4.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + StrFileName)));
                }

                clsm.ClearallPanel(this, campusid.Parent);
                
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            else
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                string var = clsm.MasterSave(this, campusid.Parent, 23, mainclass.Mode.modeModify, "campusSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(campus_name.Text), Convert.ToString(var), Convert.ToString("Campus"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Campus");

                //*********************** end for log history*******************************
               
                if (File1.PostedFile.FileName != "")
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(banner.Text))));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    banner.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("bvc_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(banner.Text))));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update campus set banner=@banner where campusid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@banner", Server.HtmlDecode(banner.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + Server.HtmlDecode(banner.Text))));
                }

                if(File2.PostedFile.FileName != "")
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(clogo.Text))));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    clogo.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("bvclogo_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(clogo.Text))));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                   
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update campus set clogo=@clogo where campusid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@clogo", Server.HtmlDecode(clogo.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + Server.HtmlDecode(clogo.Text))));
                }

                if (File3.PostedFile.FileName != "")
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(homebanner.Text))));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    homebanner.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("bvch_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(homebanner.Text))));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }


                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update campus set homebanner=@homebanner where campusid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@homebanner", Server.HtmlDecode(homebanner.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File3.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + Server.HtmlDecode(homebanner.Text))));
                }

                if (File4.PostedFile.FileName != "")
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(factimage.Text))));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    factimage.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("bvfh_" + Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(factimage.Text))));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }


                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update campus set factimage=@factimage where campusid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@factimage", Server.HtmlDecode(factimage.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File4.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + Server.HtmlDecode(factimage.Text))));
                }
                Response.Redirect("centres.aspx?edit=edit");
            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
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
        clsm.ClearallPanel(this, campusid.Parent);
    }
  
    
   
    protected void lnkremove_Click(object sender, System.EventArgs e)
    {
        if ((banner.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(banner.Text))));
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
        Parameters.Clear();
        Parameters.Add("@campusid", double.Parse(Request.QueryString["campusid"]));
        clsm.ExecuteQry_Parameter("update campus set banner='' where campusid=@campusid", Parameters);
        Image1.Visible = false;
        trsuccess.Visible = true;
        lnkremove.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
    protected void lnkremove1_Click(object sender, System.EventArgs e)
    {
        if ((clogo.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(clogo.Text))));
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
        Parameters.Clear();
        Parameters.Add("@campusid", double.Parse(Request.QueryString["campusid"]));
        clsm.ExecuteQry_Parameter("update campus set clogo='' where campusid=@campusid", Parameters);
        Image2.Visible = false;
        trsuccess.Visible = true;
        lnkremove1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
    protected void lnkremove2_Click(object sender, System.EventArgs e)
    {
        if ((homebanner.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(homebanner.Text))));
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
        Parameters.Clear();
        Parameters.Add("@campusid", double.Parse(Request.QueryString["campusid"]));
        clsm.ExecuteQry_Parameter("update campus set homebanner='' where campusid=@campusid", Parameters);
        Image3.Visible = false;
        trsuccess.Visible = true;
        lnkremove2.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }

    protected void lnkremove3_Click(object sender, System.EventArgs e)
    {
        if ((factimage.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + Server.HtmlDecode(factimage.Text))));
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
        Parameters.Clear();
        Parameters.Add("@campusid", double.Parse(Request.QueryString["campusid"]));
        clsm.ExecuteQry_Parameter("update campus set factimage='' where campusid=@campusid", Parameters);
        Image4.Visible = false;
        trsuccess.Visible = true;
        lnkremove3.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
}
