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

public partial class BackOffice_team_our_team : System.Web.UI.Page
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
            if (Conversion.Val(Request.QueryString["clid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["clid"]));
                clsm.Fillcombo_Parameter("select ttype,ttypeid from teamtype where status=1 and collageid=@collageid order by  displayorder", parameters, ttypeid);

                parameters.Clear();
                clsm.Fillcombo_Parameter(" select subtype,tsubtypeid from teamsubtype where status=1 order by  displayorder", parameters, tsubtypeid);
            }
            else
            {
                parameters.Clear();
                clsm.Fillcombo_Parameter(" select ttype,ttypeid from teamtype where status=1 and collageid=0    order by  displayorder", parameters, ttypeid);

                parameters.Clear();
                clsm.Fillcombo_Parameter(" select subtype,tsubtypeid from teamsubtype where status=1 order by  displayorder", parameters, tsubtypeid);
            }

            if (Conversion.Val(Request.QueryString["clid"]) > 0)
            {
                collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
                tr1.Visible = true;
                parameters.Clear();
                parameters.Add("@COLLAGEID", Convert.ToString(Conversion.Val(Request.QueryString["clid"])));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", parameters));
            }
            else
            {
                collageid.Text = "0";
            }

            if (Request.QueryString.HasKeys() == true)
            {
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["teamid"], out p) == true)
                {

                    string newsidval = Request.QueryString["teamid"].ToString();
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    parameters.Clear();
                    parameters.Add("@teamid", newsidval);
                    string strsql = "Select * from ourteam p  where p.teamid=@teamid ";
                    if (Conversion.Val(Request.QueryString["clid"]) > 0)
                    {
                        parameters.Add("@collageid", Convert.ToString(Request.QueryString["clid"]));
                        strsql += " and p.collageid=@collageid ";
                    }
                    clsm.MoveRecord_Parameter(this, teamid.Parent, strsql, parameters);
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(Uploadphoto.Text))
                    {
                        string photo1 = Uploadphoto.Text;

                        Image1.ImageUrl = "~/Uploads/SmallImages/" + Server.HtmlDecode(Uploadphoto.Text);
                        Image1.Visible = true;

                    }

                    if (!string.IsNullOrEmpty(Uploadphoto1.Text))
                    {
                        string photo2 = Uploadphoto1.Text;

                        Image2.ImageUrl = "~/Uploads/SmallImages/" + Server.HtmlDecode(Uploadphoto1.Text);
                        Image2.Visible = true;

                    }
                    //CKeditor1.Text = detaildesc.Text;
                    //CKeditor2.Text = shortdesc.Text;

                    CKeditor1.Text = Server.HtmlDecode(detaildesc.Text);
                    CKeditor2.Text = Server.HtmlDecode(shortdesc.Text);

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
        detaildesc.Text = Server.HtmlEncode(CKeditor1.Text);
        shortdesc.Text = Server.HtmlEncode(CKeditor2.Text);


        if (string.IsNullOrEmpty(teamid.Text))
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

            if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
            {
                if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                    return;
                }
                Uploadphoto1.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
            }
            //else
            //{
            //    trnotice.Visible = true;
            //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
            //    return;
            //}


            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            string var = clsm.MasterSave(this, teamid.Parent, 25, mainclass.Mode.modeAdd, "ourteamSP", Server.HtmlDecode(Session["UserId"].ToString()).ToString());
            CKeditor1.ReadOnly = false;
            CKeditor2.ReadOnly = false;
            //***************** for log history*********************

            clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(name.Text), Convert.ToString(var), Convert.ToString("Ourteam"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Ourteam");

            //*********************** end for log history*******************************

            if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
            {
                Uploadphoto.Text = HttpUtility.HtmlEncode(var + "t_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
                if (F1.Exists)
                {
                    F1.Delete();
                }
                File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
            }
            if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
            {
                Uploadphoto1.Text = HttpUtility.HtmlEncode(var + "tp_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + Uploadphoto1.Text.ToString());
                if (F1.Exists)
                {
                    F1.Delete();
                }
                File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Uploadphoto1.Text.ToString());
            }

            string strcollageid = String.Empty;
            if ((Conversion.Val(collageid.Text) > 0))
            {
                strcollageid = ("&clid=" + double.Parse(collageid.Text));
            }
            Response.Redirect("our-team.aspx?add=add" + strcollageid);
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

            if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
            {
                if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                    return;
                }
                Uploadphoto1.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
            }
            //else
            //{
            //    trnotice.Visible = true;
            //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
            //    return;
            //}

            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            string var = clsm.MasterSave(this, teamid.Parent, 25, mainclass.Mode.modeModify, "ourteamSP", Session["UserId"].ToString()).ToString();
            CKeditor1.ReadOnly = false;
            CKeditor2.ReadOnly = false;
            //***************** for log history*********************

            clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(name.Text), Convert.ToString(var), Convert.ToString("Ourteam"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Ourteam");

            //*********************** end for log history*******************************


            if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
            {
                Uploadphoto.Text = HttpUtility.HtmlEncode(var + "t_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
                if (F1.Exists)
                {
                    F1.Delete();
                }
                SqlConnection objcon = new SqlConnection(clsm.strconnect);
                objcon.Open();
                SqlCommand objcmd = new SqlCommand("update ourteam set Uploadphoto=@Uploadphoto where teamid=" + var.ToString() + "", objcon);
                objcmd.Parameters.Add(new SqlParameter("@Uploadphoto", Server.HtmlDecode(Uploadphoto.Text)));
                objcmd.ExecuteNonQuery();
                objcon.Close();
                File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Uploadphoto.Text.ToString());
            }
            if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
            {
                Uploadphoto1.Text = HttpUtility.HtmlEncode(var + "tp_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\SmallImages\\" + Uploadphoto1.Text.ToString());
                if (F1.Exists)
                {
                    F1.Delete();
                }
                SqlConnection objcon = new SqlConnection(clsm.strconnect);
                objcon.Open();
                SqlCommand objcmd = new SqlCommand("update ourteam set Uploadphoto1=@Uploadphoto1 where teamid=" + var.ToString() + "", objcon);
                objcmd.Parameters.Add(new SqlParameter("@Uploadphoto1", Server.HtmlDecode(Uploadphoto1.Text)));
                objcmd.ExecuteNonQuery();
                objcon.Close();
                File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + Uploadphoto1.Text.ToString());
            }
            string strcollageid = String.Empty;
            if (Conversion.Val(collageid.Text) > 0)
            {
                strcollageid = ("&clid=" + double.Parse(collageid.Text));
            }
            Response.Redirect("view-team.aspx?edit=edit" + strcollageid);

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