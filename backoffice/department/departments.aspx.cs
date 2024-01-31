using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.IO;
using System.Data;
public partial class backoffice_department_departments : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        if (!IsPostBack)
        {

            Parameters.Clear();
          
            fillcollege();

            //Parameters.Clear();
            //clsm.Fillcombo_Parameter("select cm.collagename+'-('+c.campus_name+')' as collagename,collageid from collage_master cm  inner join  campus c on cm.campusid=c.campusid where cm.status=1 order by cm.collagename", Parameters, schoolid);
            if (Conversion.Val(Request.QueryString["id"]) != 0)
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@deptid", Conversion.Val(Request.QueryString["id"]));
                clsm.MoveRecord_Parameter(this, deptid.Parent, "select * from Department_Master where deptid=@deptid", Parameters);
               

                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(departmentdetail.Text);
                CKeditor2.Text = Server.HtmlDecode(departmentshortdetail.Text);
                CKeditor3.Text = Server.HtmlDecode(deptfacilities.Text);
                CKeditor4.Text = Server.HtmlDecode(deptcontactus.Text);
                CKeditor5.Text = Server.HtmlDecode(admission.Text);
                CKeditor6.Text = Server.HtmlDecode(rearchimage.Text);
                CKeditor7.Text = Server.HtmlDecode(rearchcontent.Text);
                CKeditor8.Text = Server.HtmlDecode(rearchlink.Text);

                if (string.IsNullOrEmpty(banner.Text))
                {
                    Image1.Visible = false;
                    lnkremove.Visible = false;
                }
                else
                {
                    Image1.ImageUrl = "/Uploads/banner/" + banner.Text;
                    Image1.Visible = true;
                    lnkremove.Visible = true;
                }
                if (string.IsNullOrEmpty(admissionimg.Text))
                {
                    Image2.Visible = false;
                    lnkremove.Visible = false;
                }
                else
                {
                    Image2.ImageUrl = "/Uploads/banner/" + admissionimg.Text;
                    Image2.Visible = true;
                    LinkButton1.Visible = true;
                }
            }
        }
    }
    //public void bindcampus()
    //{
    //    Parameters.Clear();        
    //    string strsql = "select distinct c.campus_name,c.campusid from campus c left join  collage_master cm  on c.campusid=cm.campusid left join Department_Master dm on cm.collageid=dm.schoolid and dm.campusid=c.campusid left join department_management dm1 on dm1.deptid=dm.deptid where cm.status=1  ";
    //    if (Conversion.Val(AUserSession["Roleid"]) != 1)
    //    {
    //        strsql += " and isnull(dm1.roleid,0)=" + Conversion.Val(AUserSession["Roleid"]) + "";
    //    }

    //    strsql += " order by  c.campus_name";
    //    clsm.Fillcombo_Parameter(strsql, Parameters, campusid);

    //}
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
    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (Conversion.Val(deptid.Text) != 0)
        {
            Response.Redirect("viewdepartment.aspx");
        }
        else
        {
            clsm.ClearallPanel(this,deptid.Parent);
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       try
       {

            string  StrFileName ="";
            departmentdetail.Text = Server.HtmlEncode(CKeditor1.Text.Trim());
            departmentshortdetail.Text = Server.HtmlEncode(CKeditor2.Text.Trim());
            deptfacilities.Text = Server.HtmlEncode(CKeditor3.Text.Trim());
            deptcontactus.Text = Server.HtmlEncode(CKeditor4.Text.Trim());
            admission.Text = Server.HtmlEncode(CKeditor5.Text.Trim());
            rearchimage.Text = Server.HtmlEncode(CKeditor6.Text.Trim());
            rearchcontent.Text = Server.HtmlEncode(CKeditor7.Text.Trim());
            rearchlink.Text = Server.HtmlEncode(CKeditor8.Text.Trim());
            if( Page.IsValid==true)
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;
                if(Convert.ToInt32(clsm.MasterSave(this, deptid.Parent, 34, mainclass.Mode.modeCheckDuplicate, "Department_MasterSP", Session["UserId"].ToString()))>0) 
                {
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;
                    CKeditor5.ReadOnly = false;
                    CKeditor6.ReadOnly = false;
                    CKeditor7.ReadOnly = false;
                    CKeditor8.ReadOnly = false;
                    trnotice.Visible = true;
                    lblnotice.Text = "Duplicacy not allowed.";

                    return;
                }

                if (Conversion.Val(deptid.Text) == 0)
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
                        banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    //    return;

                    //}

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                        admissionimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                    }
                    //else
                    //{
                    //    trnotice.Visible = true;
                    //    lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                    //    return;

                    //}




                    status.Checked = true;
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    CKeditor4.ReadOnly = true;
                    CKeditor5.ReadOnly = true;
                    CKeditor6.ReadOnly = true;
                    CKeditor7.ReadOnly = true;
                    CKeditor8.ReadOnly = true;
                    var var = clsm.MasterSave(this, deptid.Parent, 34, mainclass.Mode.modeAdd, "Department_MasterSP", Session["UserId"].ToString());
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;
                    CKeditor5.ReadOnly = false;
                    CKeditor6.ReadOnly = false;
                    CKeditor7.ReadOnly = false;
                    CKeditor8.ReadOnly = false;

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(deptname.Text), Convert.ToString(var), Convert.ToString("Department"), Convert.ToString(schoolid.SelectedValue), Convert.ToString(schoolid.SelectedItem.Text));

                    //*********************** end for log history***********

                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@deptid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select banner from Department_Master where deptid=@deptid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                    }


                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        Parameters.Clear();
                        Parameters.Add("@deptid", var);
                        StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select admissionimg from Department_Master where deptid=@deptid", Parameters));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + StrFileName);
                    }

                    clsm.ClearallPanel(this, deptid.Parent);
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {

                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    CKeditor4.ReadOnly = true;
                    CKeditor5.ReadOnly = true;
                    CKeditor6.ReadOnly = true;
                    CKeditor7.ReadOnly = true;
                    CKeditor8.ReadOnly = true;



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
                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        if ((CheckImgType(File2.PostedFile.FileName)) == false)
                        {
                            trnotice.Visible = true;
                            lblnotice.Visible = true;
                            lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png'";
                            return;
                        }
                    }

                    var var = clsm.MasterSave(this, deptid.Parent, 34, mainclass.Mode.modeModify, "Department_MasterSP", Session["UserId"].ToString());
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;
                    CKeditor5.ReadOnly = false;
                    CKeditor6.ReadOnly = false;
                    CKeditor7.ReadOnly = false;
                    CKeditor8.ReadOnly = false;

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(deptname.Text), Convert.ToString(var), Convert.ToString("Department"), Convert.ToString(schoolid.SelectedValue), Convert.ToString(schoolid.SelectedItem.Text));

                    //*********************** end for log history***********




                    if (!string.IsNullOrEmpty(File1.PostedFile.FileName))
                    {
                        banner.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "deptbanner_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + banner.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update Department_Master set banner=@banner where deptid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@banner", banner.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File1.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + banner.Text);
                    }

                    if (!string.IsNullOrEmpty(File2.PostedFile.FileName))
                    {
                        admissionimg.Text = HttpUtility.HtmlEncode(Path.GetFileName(var + "deptadmin_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                        FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + admissionimg.Text);
                        if (F1.Exists)
                        {
                            F1.Delete();
                        }
                        SqlConnection objcon = new SqlConnection(clsm.strconnect);
                        objcon.Open();
                        SqlCommand objcmd = new SqlCommand("update Department_Master set admissionimg=@admissionimg where deptid=" + var + "", objcon);
                        objcmd.Parameters.Add(new SqlParameter("@admissionimg", admissionimg.Text));
                        objcmd.ExecuteNonQuery();
                        objcon.Close();

                        File2.PostedFile.SaveAs(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + admissionimg.Text);
                    }


                    clsm.ClearallPanel(this, deptid.Parent);
                    Response.Redirect("viewdepartment.aspx?edit=edit");
                }

            }
       }
       catch(Exception ex)
       {

       }
    }
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        if(Conversion.Val(deptid.Text) !=0)
        {
            Response.Redirect("viewdepartment.aspx");
        }
        else
        {
            clsm.ClearallPanel(this, deptname.Parent);
            CKeditor1.Text = "";
        }
    }
    protected void lnkremove_Click(object sender, EventArgs e)
    {

         if(banner.Text!="")
         {
             FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + banner.Text);
             if (F1.Exists)
             {
                F1.Delete();
             }
         }
        Parameters.Clear();
        Parameters.Add("@deptid", Conversion.Val(Request.QueryString["id"]));
        clsm.ExecuteQry_Parameter("update Department_Master set banner='' where deptid=@deptid", Parameters);
        banner.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        lnkremove.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
         if(admissionimg.Text!="")
         {
             FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\banner\\" + admissionimg.Text);
             if (F1.Exists)
             {
                F1.Delete();
             }
         }
        Parameters.Clear();
        Parameters.Add("@deptid", Conversion.Val(Request.QueryString["id"]));
        clsm.ExecuteQry_Parameter("update Department_Master set admissionimg='' where deptid=@deptid", Parameters);
        admissionimg.Text = "";
        Image2.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "Image deleted successfully.";
    }
  
    public void fillcollege()
    {
        Parameters.Clear();
        string str_college = "select distinct cm.collagename,collageid from collage_master cm  left join  campus c on cm.campusid=c.campusid left join Department_Master dm on cm.collageid=dm.schoolid left outer join department_management dm1 on dm1.deptid=dm.deptid where cm.status=1  ";
        if (Conversion.Val(campusid.SelectedValue) > 0)
        {
            Parameters.Add("@campusid", Conversion.Val(campusid.SelectedValue));
            str_college += " and cm.campusid=@campusid";
        }
        if (Conversion.Val(AUserSession["Roleid"]) != 1)
        {
            str_college += " and isnull(dm1.roleid,0)=" + Conversion.Val(AUserSession["Roleid"]) + "";
        }
        str_college += " order by collagename";
        clsm.Fillcombo_Parameter(str_college, Parameters, schoolid);
        
       
    }
}