using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

public partial class backoffice_awards_addawards : System.Web.UI.Page
{
    HttpCookie AUserSession;
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if ((Request.Cookies["AUserSession"] == null))
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;

        if ((Page.IsPostBack == false))
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", Parameters, schid);
            bind_fmember();
            if ((Conversion.Val(Request.QueryString["awardid"]) != 0))
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
               
                Parameters.Clear();
                Parameters.Add("@awardid", double.Parse(Request.QueryString["awardid"]));
                clsm.MoveRecord_Parameter(this, awardid.Parent, "select * from Add_awarshonours where awardid=@awardid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;

                CKeditor1.Text = Server.HtmlDecode(smalldesc.Text);
                CKeditor2.Text = Server.HtmlDecode(detaildesc.Text);
                CKeditor3.Text = Server.HtmlDecode(awardauthority.Text);
                CKeditor4.Text = Server.HtmlDecode(year_otherdetails.Text);
                
                if ((awardimage.Text != ""))
                {
                    Image1.Visible = true;
                    lnkremove.Visible = true;
                    Image1.ImageUrl = ("~/Uploads/SmallImages/" + awardimage.Text);
                }

                if ((largeimage.Text != ""))
                {
                    Image2.Visible = true;
                    LinkButton1.Visible = true;
                    Image2.ImageUrl = ("~/Uploads/LargeImages/" + largeimage.Text);
                }

                displayorder.Enabled = true;
            }

        }

    }

    public void bind_fmember()
    {
        Parameters.Clear();
        clsm.Fillcombo_Parameter("SELECT facultytype,fid FROM Facultymember where status=1 order by displayorder", Parameters, fid);
    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        try
        {


            smalldesc.Text = Server.HtmlEncode(CKeditor1.Text);
            detaildesc.Text = Server.HtmlEncode(CKeditor2.Text);
            awardauthority.Text = Server.HtmlEncode(CKeditor3.Text);
            year_otherdetails.Text = Server.HtmlEncode(CKeditor4.Text);
            
            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            CKeditor3.ReadOnly = true;
            CKeditor4.ReadOnly = true;
            
          

            if ((Conversion.Val(awardid.Text) == 0))
            {
                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File1.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                    awardimage.Text = Path.GetFileName(File1.PostedFile.FileName.Replace(" ", ""));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                    largeimage.Text = Path.GetFileName(File2.PostedFile.FileName.Replace(" ", ""));
                }

                status.Checked = true;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;

                object var = clsm.MasterSave(this, awardid.Parent, 19, mainclass.Mode.modeAdd, "Add_awarshonoursSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(awardname.Text), Convert.ToString(var), Convert.ToString("Award"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Award");

                //*********************** end for log history*******************************


                if ((File1.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@awardid", Conversion.Val(var));
                    string strhomeimg = Convert.ToString(clsm.SendValue_Parameter("Select awardimage from Add_awarshonours where awardid=@awardid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + strhomeimg));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\SmallImages\\" + strhomeimg)));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@awardid", Conversion.Val(var));
                    string strhomeimg1 = Convert.ToString(clsm.SendValue_Parameter("Select largeimage from Add_awarshonours where awardid=@awardid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + strhomeimg1));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + strhomeimg1));
                }

                clsm.ClearallPanel(this, awardid.Parent);
                CKeditor1.Text = "";
                CKeditor2.Text = "";
                CKeditor3.Text = "";
                CKeditor4.Text = "";
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
            else
            {
                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File1.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                }

                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                }

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;

                object var = clsm.MasterSave(this, awardid.Parent, 19, mainclass.Mode.modeModify, "Add_awarshonoursSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(awardname.Text), Convert.ToString(var), Convert.ToString("Award"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Award");

                //*********************** end for log history*******************************

                if ((File1.PostedFile.FileName != ""))
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + awardimage.Text));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    awardimage.Text = (var + ("awimg_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", ""))));
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + awardimage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();
                    SqlCommand objcmd2 = new SqlCommand(("update Add_awarshonours set awardimage=@awardimage where awardid=" + (Conversion.Val(var) + "")), objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@awardimage", awardimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + awardimage.Text));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + largeimage.Text));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    largeimage.Text = (var + ("awlimg_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", ""))));
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + largeimage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();
                    SqlCommand objcmd2 = new SqlCommand(("update Add_awarshonours set largeimage=@largeimage where awardid="
                                    + (Conversion.Val(var) + "")), objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@largeimage", largeimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + largeimage.Text));
                }

                Response.Redirect("viewawards.aspx?edit=edit");
            }

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }

    }

    bool CheckImgType(string fileName)
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

    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        if ((double.Parse(awardid.Text) == 0))
        {
            clsm.ClearallPanel(this, awardid.Parent);
        }
        else
        {
            Response.Redirect("viewawards.aspx");
        }

    }

    protected void lnkremove_Click(object sender, System.EventArgs e)
    {
        Parameters.Clear();
        Parameters.Add("@awardid", double.Parse(awardid.Text));
        clsm.ExecuteQry_Parameter("update Add_awarshonours set awardimage='' where awardid=@awardid", Parameters);
        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\SmallImages\\" + awardimage.Text)));
        awardimage.Text = "";
        if (F1.Exists)
        {
            F1.Delete();
        }

        lnkremove.Visible = false;
        Image1.Visible = false;
    }

    protected void LinkButton1_Click(object sender, System.EventArgs e)
    {
        Parameters.Clear();
        Parameters.Add("@awardid", double.Parse(awardid.Text));
        clsm.ExecuteQry_Parameter("update Add_awarshonours set largeimage='' where awardid=@awardid", Parameters);
        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\LargeImages\\" + largeimage.Text)));
        largeimage.Text = "";
        if (F1.Exists)
        {
            F1.Delete();
        }

        LinkButton1.Visible = false;
        Image2.Visible = false;
    }
}