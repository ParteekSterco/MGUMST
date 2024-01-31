using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
public partial class backoffice_socialwall_addsocialwall : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    string StrFileName = null;
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        LinkButton1.Visible = false;
        if (!Page.IsPostBack)
        {
            
           
      

            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["sid"], out p) == true)
            {
             
                CKeditor1.ReadOnly = true;
                Parameters.Clear();


                Parameters.Clear();
                Parameters.Add("@sid", Convert.ToString(Request.QueryString["sid"]));
                clsm.MoveRecord_Parameter(this, sid.Parent, "select * from socialwall where sid=@sid", Parameters);
                CKeditor1.ReadOnly = false;


               
                CKeditor1.ReadOnly = true;
           
                Parameters.Clear();
                Parameters.Add("@sid", Convert.ToString(Request.QueryString["sid"]));
                clsm.MoveRecord_Parameter(this, sid.Parent, "select * from socialwall where sid=@sid", Parameters);

                CKeditor1.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(detail.Text);

                if (!string.IsNullOrEmpty(UploadAImage.Text))
                {
                    Image1.Visible = true;
                    Image1.ImageUrl = "../../Uploads/socialwall/" + UploadAImage.Text;
                }
                if (!string.IsNullOrEmpty(UploadAImage.Text))
                {
                    LinkButton1.Visible = true;
                    LinkButton1.Text = "Remove Image";
                }
                else
                {
                    LinkButton1.Text = "";
                }
            }
            if (Convert.ToString(Request.QueryString["add"]) == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
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



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (swdate.Text == String.Empty)
                {
                    swdate.Text = "01/01/1900";
                }

                detail.Text = Server.HtmlEncode(CKeditor1.Text);
                CKeditor1.ReadOnly = true;
                if (Convert.ToInt32(Convert.ToString(clsm.MasterSave(this, sid.Parent, 18, mainclass.Mode.modeCheckDuplicate, "socialwallSP", Convert.ToString(Session["UserId"])))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Post Already Exist.";
                    CKeditor1.ReadOnly = false;
                    return;
                }

                if (string.IsNullOrEmpty(sid.Text))
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
                        UploadAImage.Text = Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", ""));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    //    return;
                    //}

                    CKeditor1.ReadOnly = true;
                    string var = clsm.MasterSave(this, sid.Parent, 18, mainclass.Mode.modeAdd, "socialwallSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(title.Text), Convert.ToString(var), Convert.ToString("Socialwall"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Socialwall");

                    //*********************** end for log history*******************************

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {

                        Parameters.Clear();
                        Parameters.Add("@sid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select uploadaimage from socialwall where sid=@sid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\socialwall\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\socialwall\\" + StrFileName);
                    }

                    Response.Redirect("addsocialwall.aspx?add=add");
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
                    CKeditor1.ReadOnly = true;
                    string var = clsm.MasterSave(this, sid.Parent, 18, mainclass.Mode.modeModify, "socialwallSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(title.Text), Convert.ToString(var), Convert.ToString("Socialwall"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Socialwall");

                    //*********************** end for log history*******************************
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "sw_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\socialwall\\" + UploadAImage.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update socialwall set uploadaimage=@uploadaimage where sid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@uploadaimage", UploadAImage.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\socialwall\\" + UploadAImage.Text);
                    }
                    Response.Redirect("viewsocialwall.aspx?edit=edit");
                }
            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }
        }



    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(sid.Text))
        {
            clsm.ClearallPanel(this, sid.Parent);
        }
        else
        {
            Response.Redirect("viewsocialwall.aspx");
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(LinkButton1.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\socialwall\\" + UploadAImage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
        Parameters.Clear();
        Parameters.Add("@sid",Convert.ToString(Request.QueryString["sid"]));
        clsm.ExecuteQry_Parameter("update socialwall set UploadAImage='' WHERE sid=@sid", Parameters);
        UploadAImage.Text = "";
        Image1.Visible = false;
        LinkButton1.Text = "";


    }
}