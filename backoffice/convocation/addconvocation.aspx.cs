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

public partial class backoffice_convocation_addconvocation : System.Web.UI.Page
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
            if (Int32.TryParse(Request.QueryString["cid"], out p) == true)
            {
               
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                Parameters.Clear();
               
               
                Parameters.Clear();
                Parameters.Add("@cid", Convert.ToString(Request.QueryString["cid"]));
                clsm.MoveRecord_Parameter(this, cid.Parent, "select * from convocation where cid=@cid", Parameters);
                              
              
                CKeditor1.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(convocationDesc.Text);
                CKeditor2.ReadOnly = false;
                CKeditor2.Text = Server.HtmlDecode(convocationSmallDesc.Text);

                if (!string.IsNullOrEmpty(UploadAImage.Text))
                {
                    Image1.Visible = true;
                    Image1.ImageUrl = "../../Uploads/LargeImages/" + UploadAImage.Text;
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
                convocationDesc.Text = Server.HtmlEncode(CKeditor1.Text);
                convocationSmallDesc.Text = Server.HtmlEncode(CKeditor2.Text);
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                if (Convert.ToInt32(Convert.ToString(clsm.MasterSave(this, cid.Parent, 22, mainclass.Mode.modeCheckDuplicate, "ConvocationSP", Convert.ToString(Session["UserId"])))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Convocation Already Exist.";
                    CKeditor1.ReadOnly = false;
                    return;
                }

                if (string.IsNullOrEmpty(cid.Text))
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
                    CKeditor2.ReadOnly = true;
                    string var = clsm.MasterSave(this, cid.Parent, 22, mainclass.Mode.modeAdd, "ConvocationSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                           Parameters.Clear();
                        Parameters.Add("@cid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select uploadaimage from convocation where cid=@cid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\LargeImages\\" + StrFileName);
                    }
                    Response.Redirect("addconvocation.aspx?add=add");
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
                    CKeditor2.ReadOnly = true;
                    string var = clsm.MasterSave(this, cid.Parent, 22, mainclass.Mode.modeModify, "ConvocationSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        UploadAImage.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "cv_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + UploadAImage.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        //' update banner file
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update convocation set uploadaimage=@uploadaimage where cid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@uploadaimage", UploadAImage.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\LargeImages\\" + UploadAImage.Text);
                    }
                    Response.Redirect("viewconvocation.aspx?edit=edit");
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

        if (string.IsNullOrEmpty(cid.Text))
        {
            clsm.ClearallPanel(this, cid.Parent);
        }
        else
        {
            Response.Redirect("viewconvocation.aspx");
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(LinkButton1.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\LargeImages\\" + UploadAImage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }

        }
         Parameters.Clear();
        Parameters.Add("@cid", Convert.ToString(Request.QueryString["cid"]));
        clsm.ExecuteQry_Parameter("update convocation set UploadAImage='' WHERE cid=@cid", Parameters);
        UploadAImage.Text = "";
        Image1.Visible = false;
        LinkButton1.Text = "";


    }

}