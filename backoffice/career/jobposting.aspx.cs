using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;

public partial class backoffice_career_jobposting : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!Page.IsPostBack)
        {
            Label1.Visible = false;
            int i = 0;
            int j = 0;
            for (i = 0; i <= 60; i++)
            {
                Ageyear.Items.Insert(i, i.ToString());
                Min_Expyear.Items.Insert(i, i.ToString());
                Max_Expyear.Items.Insert(i, i.ToString());
            }
            for (j = 0; j <= 11; j++)
            {
                Agemonth.Items.Insert(j, j.ToString());
                Min_expmonth.Items.Insert(j, j.ToString());
                Max_expmonth.Items.Insert(j, j.ToString());
            }
            Parameters.Clear();
            clsm.Fillcombo_Parameter("Select DeptName,DeptName as ids From Department_Master where status=1 order by DeptName", Parameters, department);

            Parameters.Clear();
            clsm.Fillcombo_Parameter("select emptype,emptypeid from employeetype where status=1 order by displayorder", Parameters, emptypeid);

            Int32 p = 0;
            if (Int32.TryParse(Request.QueryString["jid"], out p) == true)
            {

                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                Parameters.Clear();
                Parameters.Add("@jobid", Request.QueryString["jid"]);
                clsm.MoveRecord_Parameter(this, Label1.Parent, "select * from postedjobs where jobid=@jobid", Parameters);
                CKeditor1.ReadOnly = false;
                CKeditor2.ReadOnly = false;
                CKeditor3.ReadOnly = false;
                CKeditor4.ReadOnly = false;
                CKeditor1.Text = Server.HtmlDecode(JobDesc.Text);
                CKeditor2.Text = Server.HtmlDecode(Skills.Text);
                CKeditor3.Text = Server.HtmlDecode(qualification.Text);
                CKeditor4.Text = Server.HtmlDecode(shortdesc.Text);

            }
            if (Convert.ToString(Request.QueryString["add"]) == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
        }
    }



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if(Page.IsValid)
        {
            try
            {

                JobDesc.Text = Server.HtmlEncode(CKeditor1.Text);
                Skills.Text = Server.HtmlEncode(CKeditor2.Text);
                qualification.Text = Server.HtmlEncode(CKeditor3.Text);
                shortdesc.Text = Server.HtmlEncode(CKeditor4.Text);

                Label1.Visible = false;
                CKeditor1.ReadOnly = true;
                CKeditor2.ReadOnly = true;
                CKeditor3.ReadOnly = true;
                CKeditor4.ReadOnly = true;
                if (Convert.ToInt32(clsm.MasterSave(this, Label1.Parent, 27, mainclass.Mode.modeCheckDuplicate, "Postedjobssp", Convert.ToString(Session["UserId"]))) > 0)
                {
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;
                    trnotice.Visible = true;
                    lblnotice.Text = "Duplicate Job Code Not Allowed !!!";
                    return;
                }
                if (string.IsNullOrEmpty(JobId.Text))
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    CKeditor4.ReadOnly = true;
                    string var = clsm.MasterSave(this, Label1.Parent, 27, mainclass.Mode.modeAdd, "PostedJobsSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(JobTitle.Text), Convert.ToString(var), Convert.ToString("Posted Job"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Posted Job");

                    //*********************** end for log history*******************************

                    Response.Redirect("jobposting.aspx?add=add");

                }
                else
                {
                    CKeditor1.ReadOnly = true;
                    CKeditor2.ReadOnly = true;
                    CKeditor3.ReadOnly = true;
                    CKeditor4.ReadOnly = true;
                    string var = clsm.MasterSave(this, Label1.Parent, 27, mainclass.Mode.modeModify, "PostedJobsSP", Convert.ToString(Session["UserId"]));
                    CKeditor1.ReadOnly = false;
                    CKeditor2.ReadOnly = false;
                    CKeditor3.ReadOnly = false;
                    CKeditor4.ReadOnly = false;

                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(JobTitle.Text), Convert.ToString(var), Convert.ToString("Posted Job"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), "Posted Job");

                    //*********************** end for log history*******************************
                    Response.Redirect("viewpostedjob.aspx?edit=edit");
                }

            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = ex.Message;
            }
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Label1.Visible = false;
        if (string.IsNullOrEmpty(JobId.Text))
        {
            clsm.ClearallPanel(this, Label1.Parent);
        }
        else
        {
            Response.Redirect("viewpostedjob.aspx");
        }

    }
}