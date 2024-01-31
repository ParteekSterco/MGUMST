using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class backoffice_cms_addpages : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    string Str;
    string Strrewriteid;
    string StrFileName;

    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {
           
            Int32 p = 0;
            disablecontrol();

            
            if(Conversion.Val(Request.QueryString["clid"]) > 0)
            {
                 collageid.Text =Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
                 tr1.Visible = true;
                 Parameters.Clear();
                 Parameters.Add("@COLLAGEID",Convert.ToString(Conversion.Val(Request.QueryString["clid"])));
                 lblcollage.Text=Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID",Parameters));
            }
            dropboxbind();
            if (Int32.TryParse(Request.QueryString["pgid"], out p) == true)
            {
                linkpositionstatus.EnableViewState = false;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@pageid", Convert.ToString(Request.QueryString["pgid"]));
                string   strsql= "select * from pagemaster where pageid=@pageid ";
                if(Conversion.Val(Request.QueryString["clid"]) > 0)
                {
                     Parameters.Add("@collageid", Convert.ToString(Request.QueryString["clid"]));
                     strsql+=" and collageid=@collageid ";
                }

                clsm.MoveRecord_Parameter(this, Pageid.Parent, strsql, Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                parentid.Enabled = true;
                CKeditor1.Text = Server.HtmlDecode(Pagedescription.Text);
                CKeditor2.Text = Server.HtmlDecode(smalldesc.Text);
                CKeditor3.Text = Server.HtmlDecode(megamenu.Text);
                CKeditor4.Text = Server.HtmlDecode(PageDescription1.Text);
                CKeditor5.Text = Server.HtmlDecode(PageDescription2.Text);
                linkpositionstatus.EnableViewState = true;
                              int i = 0;
                int j = 0;
                ArrayList arrayposition = new ArrayList();
                if (!string.IsNullOrEmpty(linkposition.Text))
                {
                    arrayposition.AddRange(linkposition.Text.Split(','));
                    for (i = 0; i <= arrayposition.Count - 1; i++)
                    {
                        for (j = 0; j <= linkpositionstatus.Items.Count - 1; j++)
                        {
                            if (arrayposition[i].ToString() == linkpositionstatus.Items[j].Value)
                            {
                                linkpositionstatus.Items[j].Selected = true;
                                break; // TODO: might not be correct. Was : Exit For
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(UploadBanner.Text.Trim()))
                {
                    File1.Visible = true;
                    Image1.ImageUrl = "~/Uploads/banner/" + UploadBanner.Text;
                    LinkButton1.Visible = true;
                    Image1.Visible = true;
                }
                else
                {
                    LinkButton1.Visible = false;
                }
                disablecontrol();

               

            }
            if (Request.QueryString["add"] == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Page added successfully.";
            }
        }
    }

    private void disablecontrol()
    {
        if (Convert.ToInt32(Session["Trid"]) == 2)
        {
            pageurl.Enabled = false;
            parentid.Enabled = false;
            
            pagename.Enabled = false;
            linkname.Enabled = false;
            rewriteurl.Enabled = false;
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
            case ".swf":
                return true;
            case ".webp":
                return true;
            case ".svg":
                return true;
            default:
                return false;
        }
    }
    protected void Populate(int pid)
    {
        Parameters.Clear();

        Parameters.Add("@PageId", Convert.ToInt32(pid));
        Parameters.Add("@collageid", Convert.ToInt32(Convert.ToString(Request.QueryString["clid"])));
        int l = Convert.ToInt32(clsm.SendValue_Parameter("select ParentId from PageMaster where  collageid=@collageid and PageId=@PageId ", Parameters));
        if (l >= 0)
        {
            Str += pid.ToString() + ",";

            if (l != 0)
            {
                Populate(l);
            }
        }

    }

    private void dropboxbind()
    {
        
        DataTable tbl = GetData();
        DataSet ds = new DataSet();
        ds.Tables.Add(tbl);
        DataRelation rel = new DataRelation("ParentChild", tbl.Columns["pageid"], tbl.Columns["ParentId"], false);
        rel.Nested = true;
        ds.Relations.Add(rel);
        Repeater1.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
        Repeater1.DataBind();
        parentid.DataSource = Samples.OrderedHierarchy.GetOrderedTable(tbl, "ParentChild", "ParentId");
        parentid.DataTextField = "pagename";
        parentid.DataValueField = "pageid";
        parentid.DataBind();
        if (parentid.Items.Count > 0)
        {
            int j = 0;
            for (j = 0; j <= parentid.Items.Count - 1; j++)
            {
                TextBox txt3 = Repeater1.Items[j].FindControl("txt3") as TextBox;
                parentid.Items[j].Text = Pad(Convert.ToInt32(txt3.Text)) + parentid.Items[j].Text;
            }
        }
        parentid.Items.Insert(0, "Main Page");
        parentid.Items[0].Value = "0";
    }

    public DataTable GetData()
    {
        DataTable tbl = new DataTable();

        // Add columns to the table
        tbl.Columns.Add(new DataColumn("PageId", typeof(Int32)));
        tbl.Columns.Add(new DataColumn("ParentId", typeof(Int32)));
        tbl.Columns.Add(new DataColumn("PageName", typeof(string)));
        tbl.Columns.Add(new DataColumn("linkposition", typeof(string)));
        tbl.Columns.Add(new DataColumn("PageTitle", typeof(string)));
        tbl.Columns.Add(new DataColumn("PageStatus", typeof(string)));
        // Add the data to the table
        Int32 idx = default(Int32);
        Parameters.Clear();
        Parameters.Add("@collageid", Conversion.Val(collageid.Text));
        DataSet ds1 = clsm.senddataset_Parameter("select * from Pagemaster  where collageid=@collageid order by pageid", Parameters);
        for (idx = 0; idx <= ds1.Tables[0].Rows.Count - 1; idx++)
        {
            DataRow row = tbl.NewRow();
            row["PageId"] = ds1.Tables[0].Rows[idx]["pageid"].ToString();
            row["ParentId"] = ds1.Tables[0].Rows[idx]["ParentId"].ToString();
            row["PageName"] = ds1.Tables[0].Rows[idx]["PageName"].ToString();
            row["linkposition"] = ds1.Tables[0].Rows[idx]["linkposition"].ToString();
            row["PageTitle"] = ds1.Tables[0].Rows[idx]["PageTitle"].ToString();
            row["PageStatus"] = ds1.Tables[0].Rows[idx]["PageStatus"].ToString();
            tbl.Rows.Add(row);
        }

        return tbl;
    }
    private string Pad(Int32 numberOfSpaces)
    {
        string Spaces = string.Empty;

        for (Int32 items = 1; items <= numberOfSpaces; items++)
        {
            Spaces += "&nbsp;&nbsp;&raquo;&nbsp;";
        }
        return Server.HtmlDecode(Spaces);
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            Pagedescription.Text = Server.HtmlEncode(CKeditor1.Text);
            smalldesc.Text = Server.HtmlEncode(CKeditor2.Text);
            megamenu.Text = Server.HtmlEncode(CKeditor3.Text);
            PageDescription1.Text = Server.HtmlEncode(CKeditor4.Text);
            PageDescription2.Text = Server.HtmlEncode(CKeditor5.Text);
            int i = 0;
            linkposition.Text = "";
            for (i = 0; i <= linkpositionstatus.Items.Count - 1; i++)
            {
                if (linkpositionstatus.Items[i].Selected == true)
                {
                    linkposition.Text = linkposition.Text + (string.IsNullOrEmpty(linkposition.Text) ? "" : ",") + linkpositionstatus.Items[i].Value;
                }
            }

            if (String.IsNullOrEmpty(Pageid.Text))
            {
                Pagestatus.Checked = true;
                restricted.Checked = true;
                linkpositionstatus.EnableViewState = false;
                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                    UploadBanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                }
                if (!string.IsNullOrEmpty(Path.GetFileName(File2.PostedFile.FileName)))
                {
                    if ((CheckFileType(Path.GetFileName(File2.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                    uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                }
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                // parentid.SelectedValue = Convert.ToInt32(parentid.SelectedValue);
                string var;
                var = clsm.MasterSave(this, Pageid.Parent, 30, mainclass.Mode.modeAdd, "pagemastersp", Session["UserId"].ToString());
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                // '' for page url

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(pagename.Text), Convert.ToString(var), Convert.ToString("CMS"), Convert.ToString(collageid.Text), Convert.ToString(lblcollage.Text));

                //*********************** end for log history*******************************


                Str = "";
                string purl = "";
                if (Convert.ToInt16(parentid.SelectedValue) == 0)
                {
                    purl = "cpage.aspx?mpgid=" + Convert.ToInt16(var) + "&pgidtrail=" + Convert.ToInt16(var);
                    Strrewriteid = Convert.ToString(var);
                }
                else
                {
                    Populate(Convert.ToInt16(parentid.SelectedValue));
                    Str = Str.TrimEnd(',');
                    ArrayList ar = new ArrayList(Str.Split(','));
                    ar.Reverse();
                    //*************************
                    int n = 0;
                    if (ar.Count > 0)
                    {
                        Strrewriteid += ar[0] + ",";
                        for (n = 1; n <= ar.Count - 1; n++)
                        {
                            Strrewriteid += ar[n] + ",";
                        }
                    }
                    //**************************
                    int m = 0;
                    if (ar.Count > 0)
                    {
                        purl = "cpage.aspx?mpgid=" + ar[0];
                        for (m = 1; m <= ar.Count - 1; m++)
                        {
                            purl += "&pgid" + m + "=" + ar[m];
                        }
                        purl += "&pgidtrail=" + Convert.ToString(var);
                    }
                    //Response.Write(str & purl & "##")
                }
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("update pagemaster set pageurl='" + purl + "' where pageid=" + Convert.ToString(var) + "", Parameters);
                // '' end page url
                if (Strrewriteid.Contains(",") == true)
                {
                    Strrewriteid = Strrewriteid.TrimEnd(',');
                    Strrewriteid = Strrewriteid.Replace(',', '/');
                }
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("update pagemaster set rewriteid='" + Strrewriteid + "' where pageid=" + Convert.ToString(var) + "", Parameters);
                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    Parameters.Clear();
                    Parameters.Add("@pageid", Convert.ToString(var));
                    Parameters.Add("@collageid", Conversion.Val(collageid.Text));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadBanner from pagemaster where collageid=@collageid and  pageid=@pageid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + StrFileName);
                    if (F1.Exists)
                    {
                        Parameters.Clear();
                        Parameters.Add("@pageid", Convert.ToString(var));
                        Parameters.Add("@collageid", Conversion.Val(collageid.Text));
                        clsm.ExecuteQry_Parameter("delete from pagemaster where collageid=@collageid and  pageid=@pageid", Parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    else
                    {
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + StrFileName);
                    }
                }
                if (!string.IsNullOrEmpty(Path.GetFileName(File2.PostedFile.FileName)))
                {
                    Parameters.Clear();
                    Parameters.Add("@pageid", Convert.ToString(var));
                    Parameters.Add("@collageid", Conversion.Val(collageid.Text));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select Uploadfile from pagemaster where collageid=@collageid and  pageid=@pageid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\files\\" + StrFileName);
                    if (F1.Exists)
                    {
                        Parameters.Clear();
                        Parameters.Add("@pageid", Convert.ToString(var));
                        Parameters.Add("@collageid", Conversion.Val(collageid.Text));
                        clsm.ExecuteQry_Parameter("delete from pagemaster where collageid=@collageid and  pageid=@pageid", Parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    else
                    {
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\files\\" + StrFileName);
                    }
                }

                clsm.ClearallPanel(this, Pageid.Parent);

                if(Conversion.Val(Request.QueryString["clid"]) > 0)
                {
                  collageid.Text =Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
                }
                else
                {
                    collageid.Text = "0";
                }
                

                CKeditor1.Text = "";
                CKeditor2.Text = "";
                CKeditor3.Text = "";
                CKeditor4.Text = "";
                CKeditor5.Text = "";

                trsuccess.Visible = true;
                lblsuccess.Text = "Page added successfully.";

                ///to delte after work 
                ///
                Parameters.Clear();
                Parameters.Add("@pageid", var);

                pageurl.Text = Convert.ToString(clsm.SendValue_Parameter("select pageurl from pagemaster where pageid=@pageid", Parameters));

                string strcollageid = "";
                if (Conversion.Val(collageid.Text) > 0)
                {
                    strcollageid = "&clid=" + Conversion.Val(collageid.Text);
                }
                Response.Redirect("addpages.aspx?add=add" + strcollageid);

                //trnotice.Visible = true;
               // lblnotice.Text = "New page addition not allowed.";
               // linkpositionstatus.EnableViewState = true;

            }
            else
            {
                linkpositionstatus.EnableViewState = false;
                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    if ((CheckImgType(Path.GetFileName(File1.PostedFile.FileName))) == false)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif,swf or Png'";
                        return;
                    }
                }

                //string var = string.Empty;
                //SqlConnection cn = new SqlConnection(clsm.strconnect);
                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = cn;
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "pagemastersp";
                //cmd.Parameters.AddWithValue("@PageId", Convert.ToString(Pageid.Text));
                //cmd.Parameters.AddWithValue("@PageName", Convert.ToString(pagename.Text));
                //cmd.Parameters.AddWithValue("@PageTitle", Convert.ToString(PageTitle.Text));
                //cmd.Parameters.AddWithValue("@linkposition", Convert.ToString(linkposition.Text));
                //cmd.Parameters.AddWithValue("@linkname", Convert.ToString(linkname.Text));
                //cmd.Parameters.AddWithValue("@PageMeta", Convert.ToString(pagemeta.Text));
                //cmd.Parameters.AddWithValue("@PageMetaDesc", Convert.ToString(pagemetadesc.Text));
                //cmd.Parameters.AddWithValue("@PageDescription", Convert.ToString(Pagedescription.Text));
                //cmd.Parameters.AddWithValue("@megamenu", Convert.ToString(megamenu.Text));
                //cmd.Parameters.AddWithValue("@PageStatus", Pagestatus.Checked);
                //cmd.Parameters.AddWithValue("@parentid", Conversion.Val(parentid.Text));
                //cmd.Parameters.AddWithValue("@pageurl", Convert.ToString(pageurl.Text));
                //cmd.Parameters.AddWithValue("@rewriteid", Convert.ToString(rewriteid.Text));
                //cmd.Parameters.AddWithValue("@rewriteurl", Convert.ToString(rewriteurl.Text));
                //cmd.Parameters.AddWithValue("@UploadBanner", Convert.ToString(UploadBanner.Text));
                //cmd.Parameters.AddWithValue("@displayorder", Conversion.Val(displayorder.Text));
                //cmd.Parameters.AddWithValue("@quicklinks", quicklinks.Checked);
                //cmd.Parameters.AddWithValue("@smalldesc", Convert.ToString(smalldesc.Text));
                //cmd.Parameters.AddWithValue("@restricted", restricted.Checked);
                //cmd.Parameters.AddWithValue("@target", Convert.ToString(target.Text));
                //cmd.Parameters.AddWithValue("@tagline", Convert.ToString(tagline.Text));

                //cmd.Parameters.AddWithValue("@collageid", Conversion.Val(collageid.Text));
                //cmd.Parameters.AddWithValue("@canonical", Convert.ToString(canonical.Text));

                //cmd.Parameters.AddWithValue("@no_indexfollow", no_indexfollow.Checked);

                //cmd.Parameters.AddWithValue("@other_schema", Convert.ToString(other_schema.Text));

                //cmd.Parameters.AddWithValue("@uname", Convert.ToString(Session["UserId"]));
                //cmd.Parameters.AddWithValue("@mode", 2);
               
                //cn.Open();
                //cmd.ExecuteNonQuery();
              
                //cn.Close();
                //var = Convert.ToString(Pageid.Text);



                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                string var = clsm.MasterSave(this, Pageid.Parent, 30, mainclass.Mode.modeModify, "pagemastersp", Session["UserId"].ToString());
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(pagename.Text), Convert.ToString(var), Convert.ToString("CMS"), Convert.ToString(collageid.Text), Convert.ToString(lblcollage.Text));

                //*********************** end for log history*******************************



                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    UploadBanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "_" + Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + UploadBanner.Text);
                    if (F1.Exists)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    //' update banner file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update pagemaster set uploadbanner=@uploadbanner where collageid=" + Conversion.Val(collageid.Text) + " and  pageid=" + Convert.ToString(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadbanner", UploadBanner.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    //' end
                    //StrFileName = clsm.SendValue("Select UploadBanner from pagemaster where pageid=" & var)
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + UploadBanner.Text);
                }
                if (!string.IsNullOrEmpty(Path.GetFileName(File2.PostedFile.FileName)))
                {
                    uploadfile.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "_" + Path.GetFileName(File2.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\files\\" + uploadfile.Text);
                    if (F1.Exists)
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    //' update file
                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand("update pagemaster set uploadfile=@uploadfile where collageid=" + Conversion.Val(collageid.Text) + " and  pageid=" + Convert.ToString(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadfile", uploadfile.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    //' end
                    
                    File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\files\\" + uploadfile.Text);
                }
                linkpositionstatus.EnableViewState = true;
                string strcollageid = String.Empty;
                if (Conversion.Val(collageid.Text) > 0)
                {
                    strcollageid = "&clid=" + Conversion.Val(collageid.Text);
                }

                Response.Redirect("viewpages.aspx?edit=edit" + strcollageid);

                
              
            }
            dropboxbind();
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
       
        string strcollageid = String.Empty;
        if (Conversion.Val(collageid.Text) > 0)
        {
            strcollageid = "?clid=" + Conversion.Val(collageid.Text);
        }
        if (Convert.ToInt32(Request.QueryString["pgid"]) > 0)
        {
            Response.Redirect("viewpages.aspx" + strcollageid);
        }
        CKeditor1.Text = "";
        CKeditor2.Text = "";
        CKeditor3.Text = "";
        clsm.ClearallPanel(this, Pageid.Parent);
        if (Conversion.Val(Request.QueryString["clid"]) > 0)
        {
            collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
        }
        else
        {
            collageid.Text = "0";
        }
                

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(UploadBanner.Text))
        {
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + UploadBanner.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        Parameters.Clear();
        Parameters.Add("@pageid", Convert.ToInt32(Request.QueryString["pgid"]));
        Parameters.Add("@collageid", Conversion.Val(collageid.Text));
        clsm.ExecuteQry_Parameter("update pagemaster set UploadBanner='' where  collageid=@collageid and  pageid=@pageid", Parameters);
        UploadBanner.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
}
