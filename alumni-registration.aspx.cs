using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class alumni_registration : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", parameters, ddlcollage);
            ddlcollage.Items[0].Text = "Select Collage";
        }
    }
    protected void btnSave(object sender, EventArgs e)
    {
        string var = string.Empty;
        string ID = string.Empty;
        try
        {
            SqlConnection cn = new SqlConnection(clsm.strconnect);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "enquiryalumnisp";

            cmd.Parameters.AddWithValue("@FName", txtname.Text);
            cmd.Parameters.AddWithValue("@dob", albumdate.Text);
            cmd.Parameters.AddWithValue("@Emailid", txtemail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtmobno.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@country", txtcountry.Text);
            if (file1.PostedFile.FileName != "")
            {
                if ((CheckImgType(file1.PostedFile.FileName)) == false)
                {
                    trnotice.Visible = true;
                    lblnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    return;
                }
                uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(file1.PostedFile.FileName.Replace(" ", "").Replace("&", "")));
            }
            cmd.Parameters.AddWithValue("@file1", uploadfile.Text);
            cmd.Parameters.AddWithValue("@fathername", txtfname.Text);
            cmd.Parameters.AddWithValue("@fmobile", txtfmobile.Text);
            cmd.Parameters.AddWithValue("@femail", txtfemail.Text);
            cmd.Parameters.AddWithValue("@collageid", ddlcollage.SelectedValue);
            cmd.Parameters.AddWithValue("@course", txtprogram.Text);
            cmd.Parameters.AddWithValue("@yearpassout", txtyear.Text);
            cmd.Parameters.AddWithValue("@orgname", txtorgname.Text);
            cmd.Parameters.AddWithValue("@designation", txtdesignation.Text);

            if (file2.PostedFile.FileName != "")
            {
                if ((CheckFileType(Path.GetFileName(file2.PostedFile.FileName))) == false)
                {
                    trnotice.Visible = true;
                    lblnotice.Visible = true;
                    lblnotice.Text = "Please select a file with a file format extension of Pdf, doc, docx,xls,xlsx, txt";
                    return;
                }
                txtletter.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(file2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
            }
            cmd.Parameters.AddWithValue("@file2", txtletter.Text);
            //cmd.Parameters.AddWithValue("@payment", txtpayment.Text);
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@uname", "user");
            cmd.Parameters.AddWithValue("@mode", 1);
            cmd.Parameters.Add("@eid", SqlDbType.Int, 0, "@eid").Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();

            ID = cmd.Parameters["@eid"].Value.ToString();
            cn.Close();
            var = ID;

            if (file1.PostedFile.FileName != "")
            {
                string strhomeimg = clsm.SendValue("Select photograph from enquiry_alumni where eid=" + Convert.ToInt32(var)).ToString();
                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + strhomeimg);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                file1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + strhomeimg);
            }
            if (file2.PostedFile.FileName != "")
            {
                parameters.Clear();
                parameters.Add("@eid", Convert.ToInt32((var)));
                string StrFileName = clsm.SendValue_Parameter("Select letter from enquiry_alumni where eid=@eid", parameters).ToString();

                FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + StrFileName);
                if (F1.Exists)
                {
                    F1.Delete();
                }
                file2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\Files\\" + StrFileName);
            }

            Response.Redirect("~/thankyou.aspx?mpgid=124&pgidtrail=124&msg=thankyou");
        }
        catch (Exception ex)
        {
            lblnotice.Visible = true;
            lblnotice.Text = ex.Message.ToString();
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
            case ".txt":
                return true;
            default:
                return false;
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
}