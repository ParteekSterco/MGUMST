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

public partial class backoffice_attendance_addattendancereport : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    string StrFileName = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
      
        if (Page.IsPostBack == false)
        {

            Response.Write(DateTime.Now.ToString("dd-mm-yyyy"));
            if (Request.QueryString.HasKeys() == true)
            {
                Int32 p = 0;
                if (Int32.TryParse(Request.QueryString["atid"], out p) == true)
                {
                    string newsidval = Request.QueryString["atid"].ToString();

                    Parameters.Clear();
                    Parameters.Add("@atid", newsidval);
                    clsm.MoveRecord_Parameter(this, atid.Parent, "Select * from attendancereport where atid=@atid", Parameters);

                    if (uploadfile.Text != "")
                    {
                        lnkremovefile.Visible = true;
                    }
                }

                if (Convert.ToString(Request.QueryString["add"]) == "add")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Added Successfully.";
                }
            }
        }

    }
   

    #region <<BUTTON EVENT>>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {


            if (string.IsNullOrEmpty(atid.Text))
            {
                if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                {
                    if ((CheckfileType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension extension of xls. or .xlsx";
                        return;
                    }
                    uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }
                else
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension extension of xls. or .xlsx";
                    return;
                }
                string var = clsm.MasterSave(this, atid.Parent, 5, mainclass.Mode.modeAdd, "attendancereportSP", Session["UserId"].ToString()).ToString();

                if (File2.PostedFile.FileName != "")
                {
                    Parameters.Clear();
                    Parameters.Add("@atid", Convert.ToInt32((var)));
                    string StrFileName = clsm.SendValue_Parameter("Select uploadfile from attendancereport where atid=@atid", Parameters).ToString();

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Attendance\\" + StrFileName);
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Attendance\\" + StrFileName);
                }

                Response.Redirect("addattendancereport.aspx?add=add");

            }
            else
            {
                if (File2.PostedFile.FileName != "")
                {
                    if ((CheckfileType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension extension of xls. or .xlsx";
                        return;
                    }
                }
                string var = clsm.MasterSave(this, atid.Parent, 5, mainclass.Mode.modeModify, "attendancereportSP", Session["UserId"].ToString()).ToString();


                if (File2.PostedFile.FileName != "")
                {
                    string strdate = DateTime.Now.ToString("dd-mm-yyyy")+"-";
                    uploadfile.Text =strdate+HttpUtility.HtmlEncode(Path.GetFileName(var + "afl_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));

                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Attendance\\" + Convert.ToString(uploadfile.Text));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }
                    // update file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();

                    SqlCommand objcmd = new SqlCommand("update attendancereport set uploadfile=@uploadfile where atid=" + var + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadfile", Server.HtmlDecode(uploadfile.Text)));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\Attendance\\" + Convert.ToString(uploadfile.Text));
                }
                Response.Redirect("viewattendancerepots.aspx?edit=edit");
            }

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    protected void lnkremovefile_Click(object sender, EventArgs e)
    {

        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Attendance\\" + Convert.ToString(uploadfile.Text));
        if (F1.Exists)
        {
            F1.Delete();
        }
        Parameters.Clear();
        Parameters.Add("@atid", Convert.ToInt32(atid.Text));
        clsm.ExecuteQry_Parameter("update attendancereport set uploadfile='' where atid=@atid", Parameters);
        lnkremovefile.Visible = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        atid.Visible = false;
        if (string.IsNullOrEmpty(atid.Text))
        {
            clsm.ClearallPanel(this, atid.Parent);
        }
        else
        {
            Response.Redirect("viewattendancerepots.aspx");
            clsm.ClearallPanel(this, atid.Parent);
        }
    }

    protected void lnkdownload_Click(object sender, System.EventArgs e)
    {
        string strfile;
        strfile = "attendance.xls";
        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\Files\\SampleFile\\" + strfile)));
        if (F1.Exists)
        {
            Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~/Uploads/Files/SampleFile/" + strfile);
        }

    }

    protected void lnkdownlive_Click(object sender, System.EventArgs e)
    {
        string strfile;
        strfile = "liveattendance.xlsx";
        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\Files\\SampleFile\\" + strfile)));
        if (F1.Exists)
        {
            Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~/Uploads/Files/SampleFile/" + strfile);
        }

    }

    #endregion

    #region << methods >>


    public bool CheckfileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".xls":
                return true;
            case ".xlsx":
                return true;
            default:
                return false;
        }
    }

   

    #endregion
   
}