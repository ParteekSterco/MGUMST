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


public partial class backoffice_download_uploadfiles : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    string strtype;
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {
            
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select title,utid from uploadtype where status=1 order by displayorder", Parameters, UTId);
            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["fid"], out p) == true)
            {
                CKeditor1.ReadOnly = true;
                // clsm.MoveRecord(Me, Label1.Parent, "Select * from uploadedfiles where fileid=" & Val(Request.QueryString("fid")) & "")
                Parameters.Clear();
                Parameters.Add("@fileid", Convert.ToInt32(Request.QueryString["fid"]));
                clsm.MoveRecord_Parameter(this, Label1.Parent, "Select * from uploadedfiles where fileid=@fileid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(detail.Text);
                if (!string.IsNullOrEmpty(UploadFile.Text))
                {
                    LinkButton1.Visible = true;
                }

                if (!string.IsNullOrEmpty(uploadimage.Text))
                {
                    LinkButton2.Visible = true;
                    Image1.ImageUrl = "~/Uploads/SmallImages/" + uploadimage.Text;
                    Image1.Visible = true;
                }
            }
            if (Request.QueryString["add"] == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "File Added Successfully.";
            }
        }
    }
    public bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".pdf":
                return true;
            case ".doc":
                return true;
            case ".docx":
                return true;
            case ".xls":
                return true;
            case ".xlsx":
                return true;
            case ".txt":
                return true;
            default:
                return false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + UploadFile.Text);
        if (F1.Exists)
        {
            F1.Delete();
        }
      
        Parameters.Clear();
        Parameters.Add("@fileid", Convert.ToInt32(Fileid.Text));
        clsm.ExecuteQry_Parameter("update uploadedfiles set uploadfile='' where fileid=@fileid", Parameters);
        UploadFile.Text = "";
        LinkButton1.Visible = false;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + uploadimage.Text);
        if (F1.Exists)
        {
            F1.Delete();
        }
     
        Parameters.Clear();
        Parameters.Add("@fileid", Convert.ToInt32(Fileid.Text));
        clsm.ExecuteQry_Parameter("update uploadedfiles set uploadimage='' where fileid=@fileid", Parameters);
        uploadimage.Text = "";
        LinkButton2.Visible = false;
        Image1.Visible = false;


    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            Array ArrFileName1 = default(Array);
            string StrFileName = null;
            Array ArrFileName2 = default(Array);
            string StrFileName2 = null;
            Label1.Visible = false;
            detail.Text = Server.HtmlEncode(CKeditor1.Text);
            CKeditor1.ReadOnly = true;
            if (Convert.ToInt32(clsm.MasterSave(this, Fileid.Parent,9, mainclass.Mode.modeCheckDuplicate, "UploadedFilesSP", Convert.ToString(Session["UserId"]))) > 0)
            {
                CKeditor1.ReadOnly = false;
                trnotice.Visible = true;
                lblnotice.Text = "Duplicacy not allowed.";
                return;
            }
            if (string.IsNullOrEmpty(Fileid.Text))
            {
                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckFileType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt";
                        return;
                    }
                    UploadFile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }
                else
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt";
                    return;

                }

                //*******************************************************
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                    uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                //***********************************************************

                //***********************some ammendmend****************
                DataSet dss = fetchdownloadtype(Convert.ToString(UTId.SelectedItem.Value));
                if (dss.Tables[0].Rows.Count > 0)
                {
                    strtype = "";
                    strtype = dss.Tables[0].Rows[0]["downloadtimes"].ToString();

                    if (strtype.Trim() == "single")
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Only single file upload is allowed, to change file Click [View/Edit File] in left panel!!!";
                        return;
                    }


                }
                else
                {
                }

                //*************************************
                CKeditor1.ReadOnly = true;
                string var = clsm.MasterSave(this, Label1.Parent,9, mainclass.Mode.modeAdd, "UploadedFilesSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(FileTitle.Text), Convert.ToString(var), Convert.ToString("Download"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Download");

                //*********************** end for log history*******************************


                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    //StrFileName = clsm.SendValue("Select UploadFile from UploadedFiles where fileid=" & var)
                    Parameters.Clear();
                    Parameters.Add("@fileid", Convert.ToInt32(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadFile from UploadedFiles where fileid=@fileid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + StrFileName);
                    if (F1.Exists)
                    {
                      
                        Parameters.Clear();
                        Parameters.Add("@fileid", Convert.ToInt32(var));
                        clsm.ExecuteQry_Parameter("delete from UploadedFiles where fileid=@fileid", Parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    else
                    {
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Files\\" + StrFileName);
                    }
                }

                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    //StrFileName2 = clsm.SendValue("Select uploadimage from UploadedFiles where fileid=" & var)
                    Parameters.Clear();
                    Parameters.Add("@fileid", Convert.ToInt32(var));
                    StrFileName2 = Convert.ToString(clsm.SendValue_Parameter("Select uploadimage from UploadedFiles where fileid=@fileid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + StrFileName2);
                    if (F1.Exists)
                    {
                        
                        Parameters.Clear();
                        Parameters.Add("@fileid", Convert.ToInt32(var));
                        clsm.ExecuteQry_Parameter("delete from UploadedFiles where fileid=@fileid", Parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "Image already exist, Please choose another Image.";
                        return;
                    }
                    else
                    {
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + StrFileName2);
                    }
                }
                Response.Redirect("uploadfiles.aspx?add=add");
                CKeditor1.Text = "";
            }
            else
            {

                //******************for display order**************
                ViewState["displayorder"] = Convert.ToString(clsm.SendValue("select displayorder from UploadedFiles where fileid=" + Conversion.Val(Request.QueryString["fid"]) + ""));
                //if (clsm.Checking("select fileid from UploadedFiles where utid=" + Conversion.Val(UTId.SelectedValue) + " and  displayorder=" + Conversion.Val(displayorder.Text) + "") == false)
                //{
                //    displayorder.Text = Convert.ToString(ViewState["displayorder"]);

                //}

                //************************************


                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {
                    if ((CheckFileType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Pdf or Doc,Docx or txt";
                        return;
                    }
                }


                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    if ((CheckImgType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                        return;
                    }
                }

                CKeditor1.ReadOnly = true;
                string var = clsm.MasterSave(this, Label1.Parent, 9, mainclass.Mode.modeModify, "UploadedFilesSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(FileTitle.Text), Convert.ToString(var), Convert.ToString("Download"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Download");

                //*********************** end for log history*******************************

               




                if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                {

                    UploadFile.Text = HttpUtility.HtmlEncode(Path.GetFileName(var +"uf_"+ Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + UploadFile.Text);
                    if (F1.Exists)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update UploadedFiles set UploadFile=@UploadFile where fileid=" + Convert.ToInt32(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@UploadFile", UploadFile.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();

                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Files\\" + UploadFile.Text);
                }




                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    uploadimage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "ui_"+Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + uploadimage.Text);
                    if (F1.Exists)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    //' update banner file
                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();
                    SqlCommand objcmd2 = new SqlCommand("update UploadedFiles set uploadimage=@uploadimage where fileid=" + Convert.ToInt32(var) + "", objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@uploadimage", uploadimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();

                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\SmallImages\\" + uploadimage.Text);
                }

                Response.Redirect("viewuploadfiles.aspx?edit=edit");
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
        if (Conversion.Val(Fileid.Text) == 0)
        {
            clsm.ClearallPanel(this, Label1.Parent);
        }
        else
        {
            Response.Redirect("viewuploadfiles.aspx");
        }

    }
    protected DataSet fetchdownloadtype(string strnew)
    {
        Parameters.Clear();
        string str3 = "select a.* from uploadtype a inner join   UploadedFiles b on a.utid=b.utid  where b.utid='" + strnew + "' ";
        DataSet ds = clsm.senddataset_Parameter(str3, Parameters);
        return ds;

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
