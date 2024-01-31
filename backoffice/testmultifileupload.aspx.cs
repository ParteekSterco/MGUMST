using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

public partial class backoffice_testmultifileupload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void AjaxFileUpload1_UploadComplete(object sender, AjaxFileUploadEventArgs e)
    {
        string fileNameWithPath = Server.MapPath("~/UploadedImages/") + e.FileName.ToString();
        AjaxFileUpload1.SaveAs(fileNameWithPath);

    }    
}
