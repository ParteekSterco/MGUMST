using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;

public partial class backoffice_staff_addstaff : System.Web.UI.Page
{
    HttpCookie AUserSession;
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if ((Request.Cookies["AUserSession"] == null))
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;

        // displayorder.Text = Convert.ToString(Conversion.Val(clsm.SendValue("select isnull(max(displayorder),0) from Addfacultymaster")) + 1);
        // displayorder.Enabled = false;

        if ((Page.IsPostBack == false))
        {
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select collagename,collageid from collage_master where status=1 order by displayorder", Parameters, schid);
            bind_nameprefix();
            bind_ftype();
            bind_designation();

            if ((Conversion.Val(Request.QueryString["fid"]) != 0))
            {
                // displayorder.Enabled = true;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;
                CKeditor9.ReadOnly = true;
                CKeditor10.ReadOnly = true;
                CKeditor11.ReadOnly = true;
                CKeditor12.ReadOnly = true;
                CKeditor13.ReadOnly = true;
                CKeditor14.ReadOnly = true;
                CKeditor15.ReadOnly = true;
                CKeditor16.ReadOnly = true;
                CKeditor17.ReadOnly = true;
                CKeditor18.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@staffid", double.Parse(Request.QueryString["fid"]));
                clsm.MoveRecord_Parameter(this, staffid.Parent, "select * from addstaffmaster where staffid=@staffid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;
                CKeditor9.ReadOnly = false;
                CKeditor10.ReadOnly = false;
                CKeditor11.ReadOnly = false;
                CKeditor12.ReadOnly = false;
                CKeditor13.ReadOnly = false;
                CKeditor14.ReadOnly = false;
                CKeditor15.ReadOnly = false;
                CKeditor16.ReadOnly = false;
                CKeditor17.ReadOnly = false;
                CKeditor18.ReadOnly = false;
                CKeditor2.Text = Server.HtmlDecode(detaildesc.Text);
                CKeditor1.Text = Server.HtmlDecode(achivement.Text);
                CKeditor3.Text = Server.HtmlDecode(smalldesc.Text);
                CKeditor4.Text = Server.HtmlDecode(fdetail.Text);
                CKeditor5.Text = Server.HtmlDecode(work_experience.Text);
                CKeditor6.Text = Server.HtmlDecode(subjects_taught.Text);
                CKeditor7.Text = Server.HtmlDecode(research_initiatives.Text);
                CKeditor8.Text = Server.HtmlDecode(project_guidance.Text);
                CKeditor9.Text = Server.HtmlDecode(books_published.Text);
                CKeditor10.Text = Server.HtmlDecode(projects_carried_out.Text);
                CKeditor11.Text = Server.HtmlDecode(patents.Text);
                CKeditor12.Text = Server.HtmlDecode(technology_transfer.Text);
                CKeditor13.Text = Server.HtmlDecode(consultancy.Text);
                CKeditor14.Text = Server.HtmlDecode(grants.Text);
                CKeditor15.Text = Server.HtmlDecode(revenue_earned.Text);
                CKeditor16.Text = Server.HtmlDecode(society_membership.Text);
                CKeditor17.Text = Server.HtmlDecode(industrial_training.Text);
                CKeditor18.Text = Server.HtmlDecode(any_other_achievements.Text);
                if ((fimage.Text != ""))
                {
                    Image1.Visible = true;
                    lnkremove.Visible = true;
                    Image1.ImageUrl = ("~/Uploads/staff/" + fimage.Text);
                }

                if ((limage.Text != ""))
                {
                    Image2.Visible = true;
                    LinkButton1.Visible = true;
                    Image2.ImageUrl = ("~/Uploads/staff/" + limage.Text);
                }

                // displayorder.Enabled = true;
            }

        }

    }

    public void bind_nameprefix()
    {
        Parameters.Clear();
        clsm.Fillcombo_Parameter("SELECT ntitle,ntitle as nameprefix FROM Facultytitle where status=1 order by displayorder", Parameters, nprefix);
    }

    public void bind_designation()
    {
        Parameters.Clear();
        clsm.Fillcombo_Parameter("SELECT designation,fdid FROM staffdesignation where status=1 order by displayorder", Parameters, Designation);
    }


    public void bind_ftype()
    {
        Parameters.Clear();
        clsm.Fillcombo_Parameter("SELECT stafftype,sid FROM stafftype where status=1 order by displayorder", Parameters, sid);
    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        try
        {
            achivement.Text = Server.HtmlEncode(CKeditor1.Text);
            detaildesc.Text = Server.HtmlEncode(CKeditor2.Text);
            smalldesc.Text = Server.HtmlEncode(CKeditor3.Text);
            fdetail.Text = Server.HtmlEncode(CKeditor4.Text);
            work_experience.Text = Server.HtmlEncode(CKeditor5.Text);
            subjects_taught.Text = Server.HtmlEncode(CKeditor6.Text);
            research_initiatives.Text = Server.HtmlEncode(CKeditor7.Text);
            project_guidance.Text = Server.HtmlEncode(CKeditor8.Text);
            books_published.Text = Server.HtmlEncode(CKeditor9.Text);
            projects_carried_out.Text = Server.HtmlEncode(CKeditor10.Text);
            patents.Text = Server.HtmlEncode(CKeditor11.Text);
            technology_transfer.Text = Server.HtmlEncode(CKeditor12.Text);
            consultancy.Text = Server.HtmlEncode(CKeditor13.Text);
            grants.Text = Server.HtmlEncode(CKeditor14.Text);
            revenue_earned.Text = Server.HtmlEncode(CKeditor15.Text);
            society_membership.Text = Server.HtmlEncode(CKeditor16.Text);
            industrial_training.Text = Server.HtmlEncode(CKeditor17.Text);
            any_other_achievements.Text = Server.HtmlEncode(CKeditor18.Text);
            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            CKeditor3.ReadOnly = true;
            CKeditor4.ReadOnly = true;
            CKeditor5.ReadOnly = true;
            CKeditor6.ReadOnly = true;
            CKeditor7.ReadOnly = true;
            CKeditor8.ReadOnly = true;
            CKeditor9.ReadOnly = true;
            CKeditor10.ReadOnly = true;
            CKeditor11.ReadOnly = true;
            CKeditor12.ReadOnly = true;
            CKeditor13.ReadOnly = true;
            CKeditor14.ReadOnly = true;
            CKeditor15.ReadOnly = true;
            CKeditor16.ReadOnly = true;
            CKeditor17.ReadOnly = true;
            CKeditor18.ReadOnly = true;
            if ((dob.Text == ""))
            {
                dob.Text = "1900-1-1 00:00:00.000";
            }

            if ((doj.Text == ""))
            {
                doj.Text = "1900-1-1 00:00:00.000";
            }

            if ((Conversion.Val(staffid.Text) == 0))
            {
                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File1.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                    fimage.Text = Path.GetFileName(File1.PostedFile.FileName.Replace(" ", ""));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                    limage.Text = Path.GetFileName(File2.PostedFile.FileName.Replace(" ", ""));
                }

                status.Checked = true;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;
                CKeditor9.ReadOnly = true;
                CKeditor10.ReadOnly = true;
                CKeditor11.ReadOnly = true;
                CKeditor12.ReadOnly = true;
                CKeditor13.ReadOnly = true;
                CKeditor14.ReadOnly = true;
                CKeditor15.ReadOnly = true;
                CKeditor16.ReadOnly = true;
                CKeditor17.ReadOnly = true;
                CKeditor18.ReadOnly = true;
                object var = clsm.MasterSave(this, staffid.Parent, 52, mainclass.Mode.modeAdd, "addstaffmastersp", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;
                CKeditor9.ReadOnly = false;
                CKeditor10.ReadOnly = false;
                CKeditor11.ReadOnly = false;
                CKeditor12.ReadOnly = false;
                CKeditor13.ReadOnly = false;
                CKeditor14.ReadOnly = false;
                CKeditor15.ReadOnly = false;
                CKeditor16.ReadOnly = false;
                CKeditor17.ReadOnly = false;
                CKeditor18.ReadOnly = false;


                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(fname.Text), Convert.ToString(var), Convert.ToString("Staffmaster"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Staffmaster");

                //*********************** end for log history*******************************
                if ((File1.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@staffid", Conversion.Val(var));
                    string strhomeimg = Convert.ToString(clsm.SendValue_Parameter("Select fimage from addstaffmaster where staffid=@staffid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\staff\\" + strhomeimg));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\staff\\" + strhomeimg)));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@staffid", Conversion.Val(var));
                    string strhomeimg1 = Convert.ToString(clsm.SendValue_Parameter("Select limage from addstaffmaster where staffid=@staffid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\staff\\" + strhomeimg1));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\staff\\" + strhomeimg1));
                }

                clsm.ClearallPanel(this, staffid.Parent);
                CKeditor2.Text = "";
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
            else
            {

                //******************for display order**************
                //ViewState["displayorder"] = Convert.ToString(clsm.SendValue("select displayorder from Addfacultymaster where facultyid=" + Conversion.Val(Request.QueryString["fid"]) + ""));
                //if (clsm.Checking("select facultyid from Addfacultymaster where displayorder=" + Conversion.Val(displayorder.Text) + "") == false)
                //{
                //    displayorder.Text = Convert.ToString(ViewState["displayorder"]);

                //}

                //************************************


                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File1.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                }

                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckImgType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either Bmp, Jpg, Jpeg, Gif or Png\'";
                        return;
                    }

                }

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor5.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                CKeditor8.ReadOnly = true;
                CKeditor9.ReadOnly = true;
                CKeditor10.ReadOnly = true;
                CKeditor11.ReadOnly = true;
                CKeditor12.ReadOnly = true;
                CKeditor13.ReadOnly = true;
                CKeditor14.ReadOnly = true;
                CKeditor15.ReadOnly = true;
                CKeditor16.ReadOnly = true;
                CKeditor17.ReadOnly = true;
                CKeditor18.ReadOnly = true;
                object var = clsm.MasterSave(this, staffid.Parent, 52, mainclass.Mode.modeModify, "addstaffmastersp", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor5.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                CKeditor8.ReadOnly = false;
                CKeditor9.ReadOnly = false;
                CKeditor10.ReadOnly = false;
                CKeditor11.ReadOnly = false;
                CKeditor12.ReadOnly = false;
                CKeditor13.ReadOnly = false;
                CKeditor14.ReadOnly = false;
                CKeditor15.ReadOnly = false;
                CKeditor16.ReadOnly = false;
                CKeditor17.ReadOnly = false;
                CKeditor18.ReadOnly = false;


                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(fname.Text), Convert.ToString(var), Convert.ToString("Staffmaster"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Staffmaster");

                //*********************** end for log history*******************************

               



                if ((File1.PostedFile.FileName != ""))
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\staff\\" + fimage.Text));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    fimage.Text = (var + ("frt_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", ""))));
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\staff\\" + fimage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();
                    SqlCommand objcmd2 = new SqlCommand(("update addstaffmaster set fimage=@fimage where staffid=" + (Conversion.Val(var) + "")), objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@fimage", fimage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\staff\\" + fimage.Text));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    FileInfo F5 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\staff\\" + limage.Text));
                    if (F5.Exists)
                    {
                        F5.Delete();
                    }

                    limage.Text = (var + ("largefrt_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", ""))));
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\staff\\" + limage.Text));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    SqlConnection objcon2 = new SqlConnection(clsm.strconnect);
                    objcon2.Open();
                    SqlCommand objcmd2 = new SqlCommand(("update addstaffmaster set limage=@limage where staffid="
                                    + (Conversion.Val(var) + "")), objcon2);
                    objcmd2.Parameters.Add(new SqlParameter("@limage", limage.Text));
                    objcmd2.ExecuteNonQuery();
                    objcon2.Close();
                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\staff\\" + limage.Text));
                }

                Response.Redirect("viewstaff.aspx?edit=edit");
            }

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }

    }

    bool CheckImgType(string fileName)
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

    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        if ((double.Parse(staffid.Text) == 0))
        {
            clsm.ClearallPanel(this, staffid.Parent);
        }
        else
        {
            Response.Redirect("viewstaff.aspx");
        }

    }

    protected void lnkremove_Click(object sender, System.EventArgs e)
    {
        Parameters.Clear();
        Parameters.Add("@staffid", double.Parse(staffid.Text));
        clsm.ExecuteQry_Parameter("update addstaffmaster set fimage='' where staffid=@staffid", Parameters);
        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\staff\\" + fimage.Text)));
        fimage.Text = "";
        if (F1.Exists)
        {
            F1.Delete();
        }

        lnkremove.Visible = false;
        Image1.Visible = false;
    }

    protected void LinkButton1_Click(object sender, System.EventArgs e)
    {
        Parameters.Clear();
        Parameters.Add("@staffid", double.Parse(staffid.Text));
        clsm.ExecuteQry_Parameter("update addstaffmaster set limage='' where staffid=@staffid", Parameters);
        FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + ("Uploads\\staff\\" + limage.Text)));
        limage.Text = "";
        if (F1.Exists)
        {
            F1.Delete();
        }

        LinkButton1.Visible = false;
        Image2.Visible = false;
    }
}