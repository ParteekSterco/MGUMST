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
using Microsoft.VisualBasic;


public partial class backoffice_homebanner_adddepthomebanner : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    string StrFileName = string.Empty;
    #region <<PAGE LOAD EVENT >>

    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;


        if (Page.IsPostBack == false)
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter(" select btype,btypeid from depthomebannertype where 1=1 and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "  order by  displayorder", Parameters, btypeid);

            if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
            {
                deptid.Text = Convert.ToString(Conversion.Val(Request.QueryString["depbtid"]));
                tr1.Visible = true;
                Parameters.Clear();
                Parameters.Add("@depbtid", Convert.ToString(Conversion.Val(Request.QueryString["depbtid"])));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT DeptName FROM Department_Master WHERE deptid=@depbtid", Parameters));
            }
            else
            {
                deptid.Text = "0";
            }



            Label1.Visible = false;
            if (Request.QueryString.HasKeys() == true)
            {
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["bid"], out p) == true)
                {
                    string newsidval = Convert.ToString(Request.QueryString["bid"]);
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    Parameters.Clear();
                    Parameters.Add("@bid", newsidval);
                    string strsql = "Select * from depthomebanner where bid=@bid  ";
                    if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
                    {
                        Parameters.Add("@depbtid", Convert.ToString(Request.QueryString["depbtid"]));
                        strsql += " and deptid=@depbtid ";
                    }
                    clsm.MoveRecord_Parameter(this, Label1.Parent, strsql, Parameters);


                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor1.Text = Server.HtmlDecode(tagline1.Text);
                    CKeditor2.Text = Server.HtmlDecode(tagline2.Text);

                    if (!string.IsNullOrEmpty(bannerimage.Text))
                    {
                        if (Convert.ToString(btypeid.SelectedItem.Text) == "Video")
                        {

                            pvideo.Visible = true;
                            Image1.Visible = false;
                            showvideo.Attributes.Add("src", "/Uploads/banner/" + bannerimage.Text);
                        }
                        else
                        {
                            pvideo.Visible = false;
                            Image1.ImageUrl = "~/Uploads/banner/" + Server.HtmlDecode(bannerimage.Text);
                            Image1.Visible = true;
                        }
                    }
                    //if (!string.IsNullOrEmpty(bannermobile.Text))
                    //{
                    //    Image2.ImageUrl = "~/Uploads/banner/" + Server.HtmlDecode(bannermobile.Text);
                    //    Image2.Visible = true;

                    //}
                    if (!string.IsNullOrEmpty(blogo.Text))
                    {
                        Image3.ImageUrl = "~/Uploads/banner/" + Server.HtmlDecode(blogo.Text);
                        Image3.Visible = true;

                    }
                    displayorder.Enabled = true;
                }

                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
            }
        }

    }

    #endregion

    #region <<BUTTON EVENT>>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            tagline1.Text = Server.HtmlEncode(CKeditor1.Text);
            tagline2.Text = Server.HtmlEncode(CKeditor2.Text);

            Label1.Visible = false;
            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            //if ( Convert.ToInt32( clsm.MasterSave(this, bid.Parent, 11, mainclass.Mode.modeCheckDuplicate, "homebannerSP", Session["UserId"].ToString()).ToString()) > 0)
            //{
            //    CKeditor1.ReadOnly = false;
            //    CKeditor2.ReadOnly = false;
            //    trnotice.Visible = true;
            //    lblnotice.Text = "This title already exist.";
            //    return;
            //}

            if (string.IsNullOrEmpty(bid.Text))
            {
                //******** for admin right check ********* clsm.CHECK_ADD();
                //string strmess = clsm.CHECK_ADD();
                //if (strmess.ToLower() == "yes")
                //{
                //    //string smess = "<script language='javascript'>alert('" + ConfigurationManager.AppSettings["AddUserRight"] + "');</script>";
                //    //ClientScript.RegisterStartupScript(this.GetType(), "JSScript", smess);
                //   // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "clentscript", "alert('" + ConfigurationManager.AppSettings["AddUserRight"] + "');", true);
                //  //  return;
                //}
                //******** end for admin right check *********
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                    bannerimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }
                else
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                    return;
                }

                //if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                //{
                //    if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                //    {
                //        trnotice.Visible = true;
                //        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                //        return;
                //    }
                //    bannermobile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                //}
                //else
                //{
                //    trnotice.Visible = true;
                //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                //    return;
                //}

                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    if ((CheckImgType(Path.GetFileName(File3.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                    blogo.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                string var = clsm.MasterSave(this, Label1.Parent, 13, mainclass.Mode.modeAdd, "depthomebannerSP", Session["UserId"].ToString()).ToString();
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(title.Text), Convert.ToString(var), Convert.ToString("Department Home banner"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), Convert.ToString(lblcollage.Text));

                //*********************** end for log history*******************************

                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    // StrFileName = clsm.SendValue("Select bannerimage from homebanner where bid=" & var)
                    Parameters.Clear();
                    Parameters.Add("@bid", var);
                    StrFileName = clsm.SendValue_Parameter("Select bannerimage from depthomebanner where bid=@bid", Parameters).ToString();
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + StrFileName);

                }

                //if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                //{
                //    Parameters.Clear();
                //    Parameters.Add("@bid", var);
                //    StrFileName = clsm.SendValue_Parameter("Select bannermobile from homebanner where bid=@bid", Parameters).ToString();
                //    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + StrFileName);
                //    if (F1.Exists)
                //    {
                //        //Parameters.Clear();
                //        //Parameters.Add("@bid", var);
                //        //clsm.ExecuteQry_Parameter("delete from homebanner where bid=@bid", Parameters);
                //        //trnotice.Visible = true;
                //        //lblnotice.Text = "Mobile Banner already exist, Please choose another name.";
                //        //return;
                //        F1.Delete();
                //    }

                //    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + StrFileName);

                //}

                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    Parameters.Clear();
                    Parameters.Add("@bid", var);
                    StrFileName = clsm.SendValue_Parameter("Select blogo from depthomebanner where bid=@bid", Parameters).ToString();
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + StrFileName);
                    if (F1.Exists)
                    {
                        //Parameters.Clear();
                        //Parameters.Add("@bid", var);
                        //clsm.ExecuteQry_Parameter("delete from homebanner where bid=@bid", Parameters);
                        //trnotice.Visible = true;
                        //lblnotice.Text = "Logo Banner already exist, Please choose another name.";
                        //return;

                        F1.Delete();
                    }

                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + StrFileName);

                }

                string strcollageid = String.Empty;
                if ((Conversion.Val(deptid.Text) > 0))
                {
                    strcollageid = ("&depbtid=" + double.Parse(deptid.Text));
                }

                Response.Redirect(("adddepthomebanner.aspx?add=add" + strcollageid));

            }
            else
            {

                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File1.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }

                }
                //if ((File2.PostedFile.FileName != ""))
                //{
                //    if ((CheckImgType(File2.PostedFile.FileName) == false))
                //    {
                //        trnotice.Visible = true;
                //        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                //        return;
                //    }

                //}

                if ((File3.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File3.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }

                }



                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                string var = clsm.MasterSave(this, Label1.Parent, 13, mainclass.Mode.modeModify, "depthomebannerSP", Session["UserId"].ToString()).ToString();
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(title.Text), Convert.ToString(var), Convert.ToString("Department Home banner"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), Convert.ToString(lblcollage.Text));

                //*********************** end for log history*******************************


                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    FileInfo F5 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannerimage.Text));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }
                    bannerimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "dptbanner_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannerimage.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update depthomebanner set bannerimage=@bannerimage where bid=" + var.ToString() + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@bannerimage", Server.HtmlDecode(bannerimage.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();

                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + bannerimage.Text);
                }

                //if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                //{
                //    FileInfo F6 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannermobile.Text));
                //    if (F6.Exists)
                //    {
                //        F6.Delete();
                //    }
                //    bannermobile.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "hmbanner_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                //    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(bannermobile.Text));
                //    if (F1.Exists)
                //    {
                //        F1.Delete();
                //    }
                //    //' update banner file
                //    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                //    objcon.Open();
                //    SqlCommand objcmd = new SqlCommand("update homebanner set bannermobile=@bannermobile where bid=" + var.ToString() + "", objcon);
                //    objcmd.Parameters.Add(new SqlParameter("@bannermobile", Server.HtmlDecode(bannermobile.Text)));
                //    objcmd.ExecuteNonQuery();
                //    objcon.Close();

                //    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + bannermobile.Text);
                //}

                if (!string.IsNullOrEmpty(File3.PostedFile.FileName))
                {
                    FileInfo F6 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(blogo.Text));
                    if (F6.Exists)
                    {
                        F6.Delete();
                    }
                    blogo.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "dptmbanner_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + Server.HtmlDecode(blogo.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update depthomebanner set blogo=@blogo where bid=" + var.ToString() + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@blogo", Server.HtmlDecode(blogo.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();

                    File3.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"].ToString() + "\\uploads\\banner\\" + blogo.Text);
                }


                string strcollageid = String.Empty;
                if (Conversion.Val(deptid.Text) > 0)
                {
                    strcollageid = ("&depbtid=" + double.Parse(deptid.Text));
                }

                Response.Redirect(("viewdepthomebanner.aspx?edit=edit" + strcollageid));
            }

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (string.IsNullOrEmpty(bid.Text))
        {
            clsm.ClearallPanel(this, Label1.Parent);
        }
        else
        {
            Response.Redirect("viewcampushomebanner.aspx");
            clsm.ClearallPanel(this, Label1.Parent);
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
            case ".mp4":
                return true;
            case ".webp":
                return true;
            case ".svg":
                return true;
            default:
                return false;
        }
    }


    #endregion
}