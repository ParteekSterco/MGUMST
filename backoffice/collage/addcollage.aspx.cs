using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.IO;
using System.Data;
public partial class backoffice_collage_addcollage : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }


         if(!IsPostBack)
         {

             Parameters.Clear();

             //string strsql = "select cp.campus_name,cp.campusid from campus cp left join campusrole_Management crm on cp.campusid=crm.campusid where 1=1 ";

             //if (Conversion.Val(AUserSession["Roleid"]) != 1)
             //{
             //    strsql += " and isnull(crm.roleid,0)=" + Conversion.Val(AUserSession["Roleid"]) + "";
             //}
             //clsm.Fillcombo_Parameter(strsql, Parameters, campusid);
            

            if(Conversion.Val(Request.QueryString["tid"]) != 0)
             {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;

                Parameters.Clear();
                Parameters.Add("@collageid",Conversion.Val(Request.QueryString["tid"]));
                clsm.MoveRecord_Parameter(this, collageid.Parent, "Select * From collage_Master where collageid=@collageid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;

                CKeditor1.Text = Server.HtmlDecode(collagedescp.Text.Trim());
                CKeditor2.Text = Server.HtmlDecode(collageshortdescp.Text.Trim());
                CKeditor3.Text = Server.HtmlDecode(infrastructure.Text.Trim());
                CKeditor4.Text = Server.HtmlDecode(director_mess.Text.Trim());
                CKeditor5.Text = Server.HtmlDecode(placements.Text.Trim());
                CKeditor6.Text = Server.HtmlDecode(admission.Text.Trim());
                CKeditor7.Text = Server.HtmlDecode(campaddress.Text.Trim());
                CKeditor8.Text = Server.HtmlDecode(factfigure.Text.Trim());
                if (string.IsNullOrEmpty(collage_banner.Text)) 
                {
                    Image1.Visible = false;
                    LinkButton1.Visible = false;
                }
                else
                {
                   Image1.ImageUrl = "/Uploads/banner/" + collage_banner.Text;
                   Image1.Visible = true;
                }

                if (string.IsNullOrEmpty(admissionimg.Text)) 
                {
                    Image2.Visible = false;
                    LinkButton2.Visible = false;
                }
                else
                {
                    Image2.ImageUrl = "/Uploads/banner/" +admissionimg.Text;
                    Image2.Visible = true;
                    LinkButton2.Visible = true;
                }
                if (string.IsNullOrEmpty(infrastructureimg.Text)) 
                {
                    Image3.Visible = false;
                    LinkButton3.Visible = false;
                }
                else
                {
                    Image3.ImageUrl = "/Uploads/banner/" + infrastructureimg.Text;
                    Image3.Visible = true;
                    LinkButton3.Visible = true;
                }
                if (string.IsNullOrEmpty(factfigureimg.Text))
                {
                    Image4.Visible = false;
                    LinkButton4.Visible = false;
                }
                else
                {
                    Image4.ImageUrl = "/Uploads/banner/" + factfigureimg.Text;
                    Image4.Visible = true;
                    LinkButton4.Visible = true;
                }
             }


            if(Request.QueryString["add"] == "add") 
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
         }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string  StrFileName="" ;
            collagedescp.Text = Server.HtmlEncode(CKeditor1.Text.Trim());
            collageshortdescp.Text = Server.HtmlEncode(CKeditor2.Text.Trim());
            infrastructure.Text = Server.HtmlDecode(CKeditor3.Text.Trim());
            director_mess.Text = Server.HtmlDecode(CKeditor4.Text.Trim());
            placements.Text = Server.HtmlDecode(CKeditor5.Text.Trim());
            admission.Text = Server.HtmlDecode(CKeditor6.Text.Trim());
            campaddress.Text = Server.HtmlDecode(CKeditor7.Text.Trim());
            factfigure.Text = Server.HtmlDecode(CKeditor8.Text.Trim());

            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            CKeditor3.ReadOnly = true;
            CKeditor4.ReadOnly = true;
            CKeditor5.ReadOnly = true;
            CKeditor6.ReadOnly = true;
            CKeditor7.ReadOnly = true;
            CKeditor8.ReadOnly = true;

          
            if(Convert.ToInt32(Convert.ToString( clsm.MasterSave(this, collageid.Parent, 35, mainclass.Mode.modeCheckDuplicate, "collage_MasterSP", Server.HtmlDecode(Session["UserId"].ToString())))) > 0 )
            {
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;

                trnotice.Visible = true;
                lblnotice.Text = "This College Name already exist.";
            }

            if(Conversion.Val(collageid.Text) == 0)
            {
                    if(!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        collage_banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    //    return;

                    //}

                    if(!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        admissionimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    //    return;

                    //}

                    if(!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        if ((CheckImgType(File3.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        infrastructureimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    //    return;

                    //}

                    if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                    {
                        if ((CheckImgType(File4.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        factfigureimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    //    return;

                    //}


                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;

                var var = clsm.MasterSave(this, collageid.Parent, 35, mainclass.Mode.modeAdd, "collage_MasterSP", Server.HtmlDecode(Session["UserId"].ToString()));

                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;


                //***************** for log history*********************
                
                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(collagename.Text), Convert.ToString(var), Convert.ToString("College"), Convert.ToString(var), Convert.ToString(collagename.Text));
               
                //*********************** end for log history***********




                     if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@collageid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select collage_banner from collage_Master where collageid=@collageid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@collageid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select admissionimg from collage_Master where collageid=@collageid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                    }
                    if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@collageid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select infrastructureimg from collage_Master where collageid=@collageid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                    }
                    if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@collageid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select factfigureimg from collage_Master where collageid=@collageid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                    }


                Response.Redirect("addcollage.aspx?add=add");
            }
            else
            {

                 if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        if ((CheckImgType(File1.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                    }
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                    }
                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                    {
                        if ((CheckImgType(File3.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                    }
                if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                {
                    if ((CheckImgType(File4.PostedFile.FileName)) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }

             

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;

                var var = clsm.MasterSave(this, collageid.Parent, 35, mainclass.Mode.modeModify, "collage_MasterSP", Server.HtmlDecode(Session["UserId"].ToString()));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;


                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(collagename.Text), Convert.ToString(var), Convert.ToString("College"), Convert.ToString(var), Convert.ToString(collagename.Text));

                //*********************** end for log history***********


                 if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                 {
                        collage_banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "sb_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + collage_banner.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update collage_Master set collage_banner=@collage_banner where collageid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@collage_banner", collage_banner.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + collage_banner.Text);
                  }

                 if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                 {
                        admissionimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "adm_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + admissionimg.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update collage_Master set admissionimg=@admissionimg where collageid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@admissionimg", admissionimg.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + admissionimg.Text);
                  }

                 if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                 {
                        infrastructureimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "infra_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + infrastructureimg.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update collage_Master set infrastructureimg=@infrastructureimg where collageid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@infrastructureimg", infrastructureimg.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + infrastructureimg.Text);
                  }
                 if (!string.IsNullOrEmpty(File4.PostedFile.FileName))
                 {
                     factfigureimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "ff_" + Path.GetFileName(File4.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                     FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + factfigureimg.Text);
                     if (F1.Exists)
                     {
                         F1.Delete();
                     }
                     SqlConnection objcon = new SqlConnection(clsm.strconnect);
                     objcon.Open();
                     SqlCommand objcmd = new SqlCommand("update collage_Master set factfigureimg=@factfigureimg where collageid=" + var + "", objcon);
                     objcmd.Parameters.Add(new SqlParameter("@factfigureimg", factfigureimg.Text));
                     objcmd.ExecuteNonQuery();
                     objcon.Close();

                     File4.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + factfigureimg.Text);
                 }
                Response.Redirect("viewcollage.aspx?edit=edit");
            }
        }
        catch(Exception ex)
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
            case ".svg":
                return true;
            default:
                return false;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
            if(Conversion.Val(collageid.Text)!=0)
            {
                Response.Redirect("viewcollage.aspx");
            }
            else
            {
                 clsm.ClearallPanel(this, collageid.Parent);
            }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
         if(infrastructureimg.Text!="")
         {
             FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + infrastructureimg.Text);
             if (F1.Exists)
             {
                F1.Delete();
             }
         }
        Parameters.Clear();
        Parameters.Add("@collageid", Conversion.Val(Request.QueryString["tid"]));
        clsm.ExecuteQry_Parameter("update collage_Master set infrastructureimg='' where collageid=@collageid", Parameters);
        infrastructureimg.Text = "";
        Image3.Visible = false;
        trsuccess.Visible = true;
        LinkButton3.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        
        if( admissionimg.Text != "" )
        {
             FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + admissionimg.Text);
             if (F1.Exists)
             {
                F1.Delete();
             }
        }
        Parameters.Clear();
        Parameters.Add("@collageid", Conversion.Val(Request.QueryString["tid"]));
        clsm.ExecuteQry_Parameter("update collage_Master set admissionimg='' where collageid=@collageid", Parameters);
        admissionimg.Text = "";
        Image2.Visible = false;
        trsuccess.Visible = true;
        LinkButton2.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if( collage_banner.Text != "" )
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + collage_banner.Text);
             if (F1.Exists)
             {
                F1.Delete();
             }
        }
        Parameters.Clear();
        Parameters.Add("@collageid", Conversion.Val(Request.QueryString["tid"]));
        clsm.ExecuteQry_Parameter("update collage_Master set collage_banner='' where collageid=@collageid", Parameters);
        collage_banner.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        if (factfigureimg.Text != "")
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + factfigureimg.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        Parameters.Clear();
        Parameters.Add("@collageid", Conversion.Val(Request.QueryString["tid"]));
        clsm.ExecuteQry_Parameter("update collage_Master set factfigureimg='' where collageid=@collageid", Parameters);
        factfigureimg.Text = "";
        Image4.Visible = false;
        trsuccess.Visible = true;
        LinkButton4.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
}