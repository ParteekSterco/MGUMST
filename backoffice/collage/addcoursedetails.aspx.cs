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

public partial class backoffice_collage_addcoursedetails : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    HttpCookie AUserSession;


    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (Request.Cookies["AUserSession"] == null)
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
        if ((Page.IsPostBack == false))
        {

            if (Conversion.Val(Request.QueryString["clid"]) > 0)
            {
                collegeid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
                tr1.Visible = true;
                Parameters.Clear();
                Parameters.Add("@COLLAGEID", Convert.ToString(Conversion.Val(Request.QueryString["clid"])));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
            }

            Parameters.Clear();
            Parameters.Add("@collageid", Convert.ToString(Conversion.Val(Request.QueryString["clid"])));
            clsm.Fillcombo_Parameter("select distinct c.coursename,c.courseid from  course c  inner join map_course_institute mc on c.courseid=c.courseid where c.status=1 and mc.collageid=@collageid", Parameters, courseid);

           
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select DeptName,deptid from department_Master where status=1 order by displayorder", Parameters, deptid);
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select levelname,levelid from CourseLevel_Master  where status=1 order by displayorder", Parameters, levelid);
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select ctypename,ctid from coursetype  where status=1 order by displayorder", Parameters, ctid);
            Parameters.Clear();
            clsm.Fillcombo_Parameter("select dpname,dpid from Discipline_Master  where status=1 order by displayorder", Parameters, dpid);

             bindbranch();
            // binddepartment();
            // branch()
            if ((Conversion.Val(Request.QueryString["cid"]) != 0))
            {
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
              //CKeditor8.ReadOnly = true;
                CKeditor9.ReadOnly = true;
                CKeditor10.ReadOnly = true;
                CKEditor11.ReadOnly = true;
                CKEditor12.ReadOnly = true;
                CKEditor13.ReadOnly = true;
                CKEditor14.ReadOnly = true;
                CKeditor15.ReadOnly = true;
                CKeditor16.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@csid", Conversion.Val(Request.QueryString["cid"]));
                clsm.MoveRecord_Parameter(this, csid.Parent, "select * from CourseDetails where csid=@csid", Parameters);
                bindbranch();
                //binddepartment();
                Parameters.Add("@csid", Conversion.Val(Request.QueryString["cid"]));
                clsm.MoveRecord_Parameter(this, csid.Parent, "select * from CourseDetails where csid=@csid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                //CKeditor8.ReadOnly = false;
                CKeditor9.ReadOnly = false;
                CKeditor10.ReadOnly = false;
                CKEditor11.ReadOnly = false;
                CKEditor12.ReadOnly = false;
                CKEditor13.ReadOnly = false;
                CKEditor14.ReadOnly = false;
                CKeditor15.ReadOnly = false;
                CKeditor16.ReadOnly = false;

                CKeditor1.Text = Server.HtmlDecode(coursedetail.Text);
                CKeditor2.Text = Server.HtmlDecode(shortdesc.Text);
                CKeditor3.Text = Server.HtmlDecode(tagline.Text);
                CKeditor4.Text = Server.HtmlDecode(highlights.Text);
                // CKeditor5.Text = Server.HtmlDecode(criteria.Text)
                CKeditor6.Text = Server.HtmlDecode(feestructure.Text);
                CKeditor7.Text = Server.HtmlDecode(faq.Text);
                // CKeditor8.Text = Server.HtmlDecode(noofsemestor.Text);
                CKeditor9.Text = Server.HtmlDecode(admission_process.Text);
                CKeditor10.Text = Server.HtmlDecode(purl.Text);
                CKEditor11.Text = Server.HtmlDecode(CareerPath.Text);
                CKEditor12.Text = Server.HtmlDecode(Curriculum.Text);
                CKEditor13.Text = Server.HtmlDecode(Syllabus.Text);
                CKEditor14.Text = Server.HtmlDecode(eligiblitydetails.Text);

                CKeditor15.Text = Server.HtmlDecode(scholarships.Text);
                CKeditor16.Text = Server.HtmlDecode(intership_prog.Text);

                if ((prospectus.Text.Trim() != ""))
                {
                    File1.Visible = true;
                    LinkButton1.Visible = true;
                    // Image1.Visible = false;
                }
                else
                {
                    LinkButton1.Visible = false;
                }
                if ((coursebrochure.Text.Trim() != ""))
                {
                    File2.Visible = true;
                    LinkButton2.Visible = true;
                    //Image1.Visible = false;
                }
                else
                {
                    LinkButton2.Visible = false;
                }
                if ((Curriculumbrochure.Text.Trim() != ""))
                {
                    File3.Visible = true;
                    LinkButton3.Visible = true;
                    // Image1.Visible = false;
                }
                else
                {
                    LinkButton3.Visible = false;
                }

            }

        }

    }
    public void bindbranch()
    {
        Parameters.Clear();
        Parameters.Add("@levelid", Conversion.Val(levelid.SelectedValue));
        clsm.Fillcombo_Parameter("select streamname,streamid from stream_master where status=1 and levelid=@levelid order by displayorder", Parameters, streamid);

    }

    //public void binddepartment()
    //{
    //    Parameters.Clear();
    //    Parameters.Add("@schoolid", Conversion.Val(collageid.SelectedValue));
    //    clsm.Fillcombo_Parameter("select DeptName,deptid from Department_Master where status=1 and schoolid=@schoolid order by displayorder", Parameters, deptid);

    //}

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //try
        //{
            string StrFileName;
            coursedetail.Text = Server.HtmlEncode(CKeditor1.Text.Trim());
            shortdesc.Text = Server.HtmlEncode(CKeditor2.Text.Trim());
            tagline.Text = Server.HtmlEncode(CKeditor3.Text.Trim());
            highlights.Text = Server.HtmlDecode(CKeditor4.Text.Trim());
            // criteria.Text = Server.HtmlEncode(CKeditor5.Text.Trim())
            feestructure.Text = Server.HtmlEncode(CKeditor6.Text.Trim());
            faq.Text = Server.HtmlDecode(CKeditor7.Text.Trim());
            // noofsemestor.Text = Server.HtmlDecode(CKeditor8.Text.Trim());
            admission_process.Text = Server.HtmlDecode(CKeditor9.Text.Trim());
            purl.Text = Server.HtmlDecode(CKeditor10.Text.Trim());
            CareerPath.Text = Server.HtmlDecode(CKEditor11.Text.Trim());
            Curriculum.Text = Server.HtmlDecode(CKEditor12.Text.Trim());
            Syllabus.Text = Server.HtmlDecode(CKEditor13.Text.Trim());
            eligiblitydetails.Text = Server.HtmlDecode(CKEditor14.Text.Trim());

            scholarships.Text = Server.HtmlDecode(CKeditor15.Text.Trim());
            intership_prog.Text = Server.HtmlDecode(CKeditor16.Text.Trim());

            CKeditor1.ReadOnly = true;
            CKeditor2.ReadOnly = true;
            CKeditor3.ReadOnly = true;
            CKeditor4.ReadOnly = true;
            CKeditor6.ReadOnly = true;
            CKeditor7.ReadOnly = true;
            // CKeditor8.ReadOnly = true;
            CKeditor9.ReadOnly = true;
            CKeditor10.ReadOnly = true;
            CKEditor11.ReadOnly = true;
            CKEditor12.ReadOnly = true;
            CKEditor13.ReadOnly = true;
            CKEditor14.ReadOnly = true;
            CKeditor15.ReadOnly = true;
            CKeditor16.ReadOnly = true;

            if (Convert.ToInt32(clsm.MasterSave(this, csid.Parent, 49, mainclass.Mode.modeCheckDuplicate, "CourseDetailsSP", Session["UserId"].ToString())) > 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "Duplicacy not allowed.";
                return;
            }
       
            if (Conversion.Val(csid.Text) == 0)
            {
               

                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File1.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                    prospectus.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }


                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                    coursebrochure.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                if ((File3.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File3.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                    Curriculumbrochure.Text = HttpUtility.HtmlEncode(Path.GetFileName(Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")));
                }

                
                status.Checked = true;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                //CKeditor8.ReadOnly = true;
                CKeditor9.ReadOnly = true;
                CKeditor10.ReadOnly = true;
                CKEditor11.ReadOnly = true;
                CKEditor12.ReadOnly = true;
                CKEditor13.ReadOnly = true;
                CKEditor14.ReadOnly = true;

                CKeditor15.ReadOnly = true;
                CKeditor16.ReadOnly = true;

                object var = clsm.MasterSave(this,csid.Parent, 49, mainclass.Mode.modeAdd, "CourseDetailsSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                // CKeditor8.ReadOnly = false;
                CKeditor9.ReadOnly = false;
                CKeditor10.ReadOnly = false;
                CKEditor11.ReadOnly = false;
                CKEditor12.ReadOnly = false;
                CKEditor13.ReadOnly = false;
                CKEditor14.ReadOnly = false;

                CKeditor15.ReadOnly = false;
                CKeditor16.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(courseid.SelectedItem.Text), Convert.ToString(var), Convert.ToString("CourseDetails"), Convert.ToString(collegeid.Text), Convert.ToString(lblcollage.Text));

                //*********************** end for log history***********

                if ((File1.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@csid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select prospectus from CourseDetails where csid=@csid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + StrFileName));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\prospectus\\" + StrFileName)));
                }
                if ((File2.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@csid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select coursebrochure from CourseDetails where csid=@csid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + StrFileName));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\prospectus\\" + StrFileName)));
                }
                if ((File3.PostedFile.FileName != ""))
                {
                    Parameters.Clear();
                    Parameters.Add("@csid", Conversion.Val(var));
                    StrFileName = Convert.ToString(clsm.SendValue_Parameter("Select Curriculumbrochure from CourseDetails where csid=@csid", Parameters));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + StrFileName));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    File3.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + ("\\uploads\\prospectus\\" + StrFileName)));
                }
                clsm.ClearallPanel(this, courseid.Parent);
                CKeditor1.Text = "";
                CKeditor2.Text = "";
                CKeditor3.Text = "";
                CKeditor4.Text = "";
                CKeditor6.Text = "";
                CKeditor7.Text = "";
                // CKeditor8.Text = "";
                CKeditor9.Text = "";
                CKeditor10.Text = "";
                CKEditor11.Text = "";
                CKEditor12.Text = "";
                CKEditor13.Text = "";
                CKEditor14.Text = "";

                CKeditor15.Text = "";
                CKeditor16.Text = "";
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
            else
            {
                if ((File1.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File1.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                }
                if ((File2.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File2.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                }
                if ((File3.PostedFile.FileName != ""))
                {
                    if ((CheckFileType(File3.PostedFile.FileName) == false))
                    {
                        trnotice.Visible = true;
                        lblnotice.Text = "Please select a file with a file format extension of either pdf, doc,docx,txt";
                        return;
                    }

                }

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                CKeditor6.ReadOnly = true;
                CKeditor7.ReadOnly = true;
                //CKeditor8.ReadOnly = true;
                CKeditor9.ReadOnly = true;
                CKeditor10.ReadOnly = true;
                CKEditor11.ReadOnly = true;
                CKEditor12.ReadOnly = true;
                CKEditor13.ReadOnly = true;
                CKEditor14.ReadOnly = true;
                CKeditor15.ReadOnly = true;
                CKeditor16.ReadOnly = true;
                object var = clsm.MasterSave(this, courseid.Parent, 49, mainclass.Mode.modeModify, "CourseDetailsSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor6.ReadOnly = false;
                CKeditor7.ReadOnly = false;
                //CKeditor8.ReadOnly = false;
                CKeditor9.ReadOnly = false;
                CKeditor10.ReadOnly = false;
                CKEditor11.ReadOnly = false;
                CKEditor12.ReadOnly = false;
                CKEditor13.ReadOnly = false;
                CKEditor14.ReadOnly = false;
                CKeditor15.ReadOnly = false;
                CKeditor16.ReadOnly = false;

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(courseid.SelectedItem.Text), Convert.ToString(var), Convert.ToString("CourseDetails"), Convert.ToString(collegeid.Text), Convert.ToString(lblcollage.Text));

                //*********************** end for log history***********


                if ((File1.PostedFile.FileName != ""))
                {
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(prospectus.Text)));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    prospectus.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("scpfile_" + Path.GetFileName(File1.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(prospectus.Text)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update CourseDetails set prospectus=@prospectus where csid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@prospectus", prospectus.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File1.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + Server.HtmlDecode(prospectus.Text)));
                }

                if ((File2.PostedFile.FileName != ""))
                {
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(coursebrochure.Text)));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    coursebrochure.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("scbfile_" + Path.GetFileName(File2.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(coursebrochure.Text)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update CourseDetails set coursebrochure=@coursebrochure where csid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@coursebrochure", coursebrochure.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File2.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + Server.HtmlDecode(coursebrochure.Text)));
                }
                if ((File3.PostedFile.FileName != ""))
                {
                    FileInfo F2 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(Curriculumbrochure.Text)));
                    if (F2.Exists)
                    {
                        F2.Delete();
                    }

                    Curriculumbrochure.Text = HttpUtility.HtmlEncode(Path.GetFileName((var + ("sccbfile_" + Path.GetFileName(File3.PostedFile.FileName.Replace(" ", "")).Replace("&", "")))));
                    FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(Curriculumbrochure.Text)));
                    if (F1.Exists)
                    {
                        F1.Delete();
                    }

                    SqlConnection objcon = new SqlConnection(clsm.strconnect);
                    objcon.Open();
                    SqlCommand objcmd = new SqlCommand(("update CourseDetails set Curriculumbrochure=@Curriculumbrochure where csid="
                                    + (Conversion.Val(var) + "")), objcon);
                    objcmd.Parameters.Add(new SqlParameter("@Curriculumbrochure", Curriculumbrochure.Text));
                    objcmd.ExecuteNonQuery();
                    objcon.Close();
                    File3.PostedFile.SaveAs((Request.ServerVariables["Appl_Physical_Path"] + "\\uploads\\prospectus\\" + Server.HtmlDecode(Curriculumbrochure.Text)));
                }
                string strcollageid = String.Empty;
                if (Conversion.Val(collegeid.Text) > 0)
                {
                    strcollageid = "&clid=" + Conversion.Val(collegeid.Text);
                }

                Response.Redirect("viewcoursedetails.aspx?edit=edit" + strcollageid);
               
            }

        //}
        //catch (Exception ex)
        //{
        //    trerror.Visible = true;
        //    lblerror.Text = ex.Message;
        //}

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if ((Conversion.Val(csid.Text) == 0))
        {
            clsm.ClearallPanel(this, csid.Parent);
        }
        else
        {
            Response.Redirect("viewcoursedetails.aspx");
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

    public bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".doc":
                return true;

            case ".pdf":
                return true;

            case ".docx":
                return true;

            case ".txt":
                return true;

            default:
                return false;

        }
    }

    protected void LinkButton1_Click(object sender, System.EventArgs e)
    {
        if ((prospectus.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(prospectus.Text)));
            if (F1.Exists)
            {
                F1.Delete();
            }

        }

        Parameters.Clear();
        Parameters.Add("@csid", double.Parse(Request.QueryString["cid"]));
        clsm.SendValue_Parameter("update CourseDetails set prospectus='' where csid=@csid", Parameters);
        prospectus.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton1.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
    protected void LinkButton2_Click(object sender, System.EventArgs e)
    {
        if ((coursebrochure.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(coursebrochure.Text)));
            if (F1.Exists)
            {
                F1.Delete();
            }
        }

        Parameters.Clear();
        Parameters.Add("@csid", double.Parse(Request.QueryString["cid"]));
        clsm.SendValue_Parameter("update CourseDetails set coursebrochure='' where csid=@csid", Parameters);
        coursebrochure.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton2.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }
    protected void LinkButton3_Click(object sender, System.EventArgs e)
    {
        if ((Curriculumbrochure.Text != ""))
        {
            FileInfo F1 = new FileInfo((Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\prospectus\\" + Server.HtmlDecode(Curriculumbrochure.Text)));
            if (F1.Exists)
            {
                F1.Delete();
            }
        }
        Parameters.Clear();
        Parameters.Add("@csid", double.Parse(Request.QueryString["cid"]));
        clsm.SendValue_Parameter("update CourseDetails set Curriculumbrochure='' where csid=@csid", Parameters);
        Curriculumbrochure.Text = "";
        Image1.Visible = false;
        trsuccess.Visible = true;
        LinkButton3.Visible = false;
        lblsuccess.Text = "File deleted successfully.";
    }

    protected void levelid_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        bindbranch();
    }

    //protected void collageid_SelectedIndexChanged(object sender, System.EventArgs e)
    //{
    //    binddepartment();
    //}
}