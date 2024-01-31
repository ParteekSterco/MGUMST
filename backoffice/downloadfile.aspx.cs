using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class backoffice_downloadfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        trsuccess.Visible = false;
        trnotice.Visible = false;
        trerror.Visible = false;

        string pa = null;
        pa = Request.QueryString["d"];
        string strRequest = pa;
      
        if (!string.IsNullOrEmpty(strRequest))
        {
            string path = Server.MapPath(strRequest.Replace("*", "+"));
            //get file object as FileInfo
            System.IO.FileInfo file = new System.IO.FileInfo(path);
            //-- if the file exists on the server
            //set appropriate headers
            if (file.Exists)
            {
                if ((CheckFileType(file.FullName)) == false)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "Download not allowed.";
                    return;
                }
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
                //if file does not exist
            }
            else
            {
                // clsmaster.ShowMessage(frm, "This file does not exist.")
                trnotice.Visible = true;
                lblnotice.Text = "This file does not exist.";
                return;
            }
            //nothing in the URL as HTTP GET
        }
        else
        {
            trnotice.Visible = true;
            lblnotice.Text = "Please provide a file to download.";           
        }

    }

    public bool CheckFileType(string fileName)
	{
		string ext = Path.GetExtension(fileName);
		switch (ext.ToLower()) {
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
			case ".jpg":
				return true;
			case ".jpeg":
				return true;
			case ".gif":
				return true;
			case ".bmp":
				return true;
			case ".png":
				return true;
			case ".pps":
				return true;
			case ".ppsx":
				return true;
			case ".ppt":
				return true;
			case ".pptx":
				return true;
			case ".zip":
				return true;
			case ".rar":
				return true;
            case ".msg":
                return true; 
            case ".mp3":
                return true;
			default:
				return false;
		}
	}
	
}