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


public partial class backoffice_department_addpagesdept : System.Web.UI.Page
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
            if (Request.QueryString["add"] == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Page added successfully.";
            }

            Int32 p = 0;
            disablecontrol();


            if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
            {
                deptid.Text = Convert.ToString(Conversion.Val(Request.QueryString["depbtid"]));
                tr1.Visible = true;
                Parameters.Clear();
                Parameters.Add("@deptid", Convert.ToString(Conversion.Val(Request.QueryString["depbtid"])));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT DeptName FROM Department_Master WHERE deptid=@deptid", Parameters));
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
                string strsql = "select * from PageMasterdept where pageid=@pageid ";
                if (Conversion.Val(Request.QueryString["clid"]) > 0)
                {
                    Parameters.Add("@deptid", Convert.ToString(Request.QueryString["depbtid"]));
                    strsql += " and deptid=@deptid ";
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
                //**********
                //Array arrpageurl = pageurl.Text.Split('?');
            //    string strcheck = arrpageurl(0);
               // Response.Write(arrpageurl(0).ToString());
                //int k = 0;
                //for (k = 0; k <= arr.Length - 2; k++)
                //{
                //    strnew += arr.GetValue(k).ToString() + " ";
                //}

                //*********************
            

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
        Parameters.Add("@deptid", Convert.ToInt32(Convert.ToString(Request.QueryString["depbtid"])));
        int l = Convert.ToInt32(clsm.SendValue_Parameter("select ParentId from PageMasterdept where  deptid=@deptid and PageId=@PageId ", Parameters));
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
        Parameters.Add("@deptid", Conversion.Val(deptid.Text));
        DataSet ds1 = clsm.senddataset_Parameter("select * from PageMasterdept  where deptid=@deptid order by pageid", Parameters);
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
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                // parentid.SelectedValue = Convert.ToInt32(parentid.SelectedValue);
                string var;
                var = clsm.MasterSave(this, Pageid.Parent, 30, mainclass.Mode.modeAdd, "PageMasterdeptsp", Session["UserId"].ToString());
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                // '' for page url

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(pagename.Text), Convert.ToString(var), Convert.ToString("DPTCMS"), Convert.ToString(deptid.Text), Convert.ToString(lblcollage.Text));

                //*********************** end for log history*******************************


                Str = "";
                string purl = "";
                if (Convert.ToInt16(parentid.SelectedValue) == 0)
                {
                    purl = "dcpage.aspx?mpgid=" + Convert.ToInt16(var) + "&pgidtrail=" + Convert.ToInt16(var);
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
                        purl = "dcpage.aspx?mpgid=" + ar[0];
                        for (m = 1; m <= ar.Count - 1; m++)
                        {
                            purl += "&pgid" + m + "=" + ar[m];
                        }
                        purl += "&pgidtrail=" + Convert.ToString(var);
                    }
                    //Response.Write(str & purl & "##")
                }
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("update PageMasterdept set pageurl='" + purl + "' where pageid=" + Convert.ToString(var) + "", Parameters);
                // '' end page url
                if (Strrewriteid.Contains(",") == true)
                {
                    Strrewriteid = Strrewriteid.TrimEnd(',');
                    Strrewriteid = Strrewriteid.Replace(',', '/');
                }
                Parameters.Clear();
                clsm.ExecuteQry_Parameter("update PageMasterdept set rewriteid='" + Strrewriteid + "' where pageid=" + Convert.ToString(var) + "", Parameters);
                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    Parameters.Clear();
                    Parameters.Add("@pageid", Convert.ToString(var));
                    Parameters.Add("@deptid", Conversion.Val(deptid.Text));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select UploadBanner from PageMasterdept where deptid=@deptid and  pageid=@pageid", Parameters));
                    FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\banner\\" + StrFileName);
                    if (F1.Exists)
                    {
                        Parameters.Clear();
                        Parameters.Add("@pageid", Convert.ToString(var));
                        Parameters.Add("@deptid", Conversion.Val(deptid.Text));
                        clsm.ExecuteQry_Parameter("delete from PageMasterdept where deptid=@deptid and  pageid=@pageid", Parameters);
                        trnotice.Visible = true;
                        lblnotice.Text = "File already exist, Please choose another name.";
                        return;
                    }
                    else
                    {
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + StrFileName);
                    }
                }
               // clsm.ClearallPanel(this, Pageid.Parent);

                if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
                {
                    deptid.Text = Convert.ToString(Conversion.Val(Request.QueryString["depbtid"]));
                }
                //else
                //{
                //    deptid.Text = "0";
                //}


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

                pageurl.Text = Convert.ToString(clsm.SendValue_Parameter("select pageurl from PageMasterdept where pageid=@pageid", Parameters));




                string strcollageid = String.Empty;
                if (Conversion.Val(deptid.Text) > 0)
                {
                    strcollageid = "&depbtid=" + Conversion.Val(deptid.Text);
                }

                Response.Redirect("addpagesdept.aspx?add=add" + strcollageid);
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


                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                string var = clsm.MasterSave(this, Pageid.Parent, 30, mainclass.Mode.modeModify, "PageMasterdeptsp", Session["UserId"].ToString());
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(pagename.Text), Convert.ToString(var), Convert.ToString("DPTCMS"), Convert.ToString(deptid.Text), Convert.ToString(lblcollage.Text));

                //*********************** end for log history*******************************



                if (!string.IsNullOrEmpty(Path.GetFileName(File1.PostedFile.FileName)))
                {
                    UploadBanner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "dpb_" + Path.GetFileName(File1.PostedFile.FileName).Replace(" ", "").Replace("&", "")));
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
                    SqlCommand objcmd = new SqlCommand("update PageMasterdept set uploadbanner=@uploadbanner where deptid=" + Conversion.Val(deptid.Text) + " and  pageid=" + Convert.ToString(var) + "", objcon);
                    objcmd.Parameters.Add(new SqlParameter("@uploadbanner", UploadBanner.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    //' end
                    //StrFileName = clsm.SendValue("Select UploadBanner from pagemaster where pageid=" & var)
                    File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\banner\\" + UploadBanner.Text);
                }
                linkpositionstatus.EnableViewState = true;
                string strcollageid = String.Empty;
                if (Conversion.Val(deptid.Text) > 0)
                {
                    strcollageid = "&depbtid=" + Conversion.Val(deptid.Text);
                }

                Response.Redirect("viewpagesdept.aspx?edit=edit" + strcollageid);



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
        if (Conversion.Val(deptid.Text) > 0)
        {
            strcollageid = "?depbtid=" + Conversion.Val(deptid.Text);
        }
        if (Convert.ToInt32(Request.QueryString["pgid"]) > 0)
        {
            Response.Redirect("viewpagesdept.aspx" + strcollageid);
        }
        CKeditor1.Text = "";
        CKeditor2.Text = "";
        CKeditor3.Text = "";
        clsm.ClearallPanel(this, Pageid.Parent);
        if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
        {
            deptid.Text = Convert.ToString(Conversion.Val(Request.QueryString["depbtid"]));
        }
        else
        {
            deptid.Text = "0";
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
        Parameters.Add("@deptid", Conversion.Val(deptid.Text));
        clsm.ExecuteQry_Parameter("update PageMasterdept set UploadBanner='' where  deptid=@deptid and  pageid=@pageid", Parameters);
        UploadBanner.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
}
