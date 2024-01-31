using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Data;
using Microsoft.VisualBasic;

public partial class backoffice_career_viewgeneral : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {

        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            int i = 0;
            int j = 0;
            for (i = 0; i <= 30; i++)
            {
                Min_Expyear.Items.Insert(i, i.ToString());

            }
            for (j = 0; j <= 11; j++)
            {
                Min_expmonth.Items.Insert(j, j.ToString());

            }

            Search();
        }
    }


    private void Search()
    {
        try
        {
            Parameters.Clear();
            string Strsql = "SELECT a.* FROM PostedApplication a where a.jobid = 0";

            

            if (!string.IsNullOrEmpty(txtname.Text))
            {
                Parameters.Add("@FName", txtname.Text);
                Strsql += " and FName like '%'+@FName+'%'";
            }


            if (!string.IsNullOrEmpty(txtemailid.Text))
            {
                Parameters.Add("@App_Email", txtemailid.Text);
                Strsql += " and App_Email like '%'+@App_Email+'%'";
            }
           

            if (!string.IsNullOrEmpty(txtsodate.Text))
            {
                Parameters.Add("@Trdate", txtsodate.Text);
                Strsql += " and a.Trdate >= @Trdate";
            }
            if (!string.IsNullOrEmpty(txteodate.Text))
            {
                Parameters.Add("@Trdateone", txteodate.Text);
                Strsql += " and a.Trdate <= @Trdateone";
            }






            if (ddlminexp.SelectedItem.Text == "=")
            {
                Parameters.Add("@App_Expyear", Min_Expyear.SelectedValue);
                Parameters.Add("@App_Expmonth", Min_expmonth.SelectedValue);
                Strsql += " and a.App_Expyear = @App_Expyear and a.App_Expmonth= @App_Expmonth ";
            }
            else if (ddlminexp.SelectedItem.Text == ">=")
            {
                Parameters.Add("@App_Expyearone", Min_Expyear.SelectedValue);
                Parameters.Add("@App_Expmonthone", Min_expmonth.SelectedValue);
                Strsql += " and a.App_Expyear >=@App_Expyearone and a.App_Expmonth>= @App_Expmonthone";

            }
            else if (ddlminexp.SelectedItem.Text == "<=")
            {
                Parameters.Add("@App_Expyeartwo", Min_Expyear.SelectedValue);
                Parameters.Add("@App_Expmonthtwo", Min_expmonth.SelectedValue);
                Strsql += " and a.App_Expyear <=@App_Expyeartwo and a.App_Expmonth<= @App_Expmonthtwo";
            }
            Strsql = Strsql + " order by a.trdate desc";

            clsm.GridviewData_Parameter(GridView1, Strsql, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                GridView1.Visible = false;
                trnotice.Visible = true;
                btnExport.Visible = false;
                lblnotice.Text = "No Records Found";
            }
            else
            {
                GridView1.Visible = true;
                btnExport.Visible = true;
                trnotice.Visible = false;
            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message;
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
//        string strsql = @"select JobTitle [Job Title],FName +' '+ LName [Full Name],convert(varchar,App_DOB,107) 
//                        [Date of birth],Gender,MaritalStatus,Father_HusbandName [Father/Husband Name],App_Address [Address],
//                        State,City,Telephone,Mobile,App_Email [E-mail],convert(varchar,App_Expyear) +'.'+ 
//                        convert(varchar,App_Expmonth)[Experience],App_Qualification [Qualification],App_Skills [Skills],
//                        cemployer [Name of the Organization],csalary [Current Salary],cindustry [Current Industry],funarea 
//                        [Functional Area] from PostedApplication where jobid = 0";
        string strsql = @"select JobTitle [Designation],FName +' '+ LName [Name],funarea[Department],App_Email[Email ID],Mobile,Telephone[Alternate Contact No.],  App_Address [Address],PrefLocation [Location],Trdate[Applied Date] from PostedApplication where jobid = 0";

        Parameters.Clear();


        if (!string.IsNullOrEmpty(txtname.Text))
        {
            Parameters.Add("@FName", txtname.Text);
            strsql += " and FName like '%'+@FName+'%'";
        }

        if (!string.IsNullOrEmpty(txtemailid.Text))
        {
            Parameters.Add("@App_Email", txtemailid.Text);
            strsql += " and App_Email like '%'+@App_Email+'%'";
        }

        if (!string.IsNullOrEmpty(txtsodate.Text))
        {
            Parameters.Add("@Trdate", txtsodate.Text);
            strsql += " and Trdate >= @Trdate";
        }
        if (!string.IsNullOrEmpty(txteodate.Text))
        {
            Parameters.Add("@Trdateone", txteodate.Text);
            strsql += " and Trdate <= @Trdateone";
        }
        if (ddlminexp.SelectedItem.Text == "=")
        {
            Parameters.Add("@App_Expyear", Min_Expyear.SelectedValue);
            Parameters.Add("@App_Expmonth", Min_expmonth.SelectedValue);
            strsql += " and App_Expyear = @App_Expyear and App_Expmonth= @App_Expmonth ";
        }
        else if (ddlminexp.SelectedItem.Text == ">=")
        {
            Parameters.Add("@App_Expyearone", Min_Expyear.SelectedValue);
            Parameters.Add("@App_Expmonthone", Min_expmonth.SelectedValue);
            strsql += " and App_Expyear >=@App_Expyearone and App_Expmonth>= @App_Expmonthone";

        }
        else if (ddlminexp.SelectedItem.Text == "<=")
        {
            Parameters.Add("@App_Expyeartwo", Min_Expyear.SelectedValue);
            Parameters.Add("@App_Expmonthtwo", Min_expmonth.SelectedValue);
            strsql += " and App_Expyear <=@App_Expyeartwo and App_Expmonth<= @App_Expmonthtwo";
        }
        strsql = strsql + " order by trdate desc";
        DataSet ds = clsm.senddataset_Parameter(strsql, Parameters);
        Response.Clear();
        Response.ClearHeaders();
        Response.AddHeader("content-disposition", "attachment;filename=Resume.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        DataSetToExcel.Convert(ds, Response);
        Response.Write(stringWrite.ToString());
        Response.Buffer = true;
        Response.End();


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            Search();
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message.ToString();
        }


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "btndel")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Parameters.Clear();
            Parameters.Add("@app_id", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from PostedApplication where app_id=@app_id", Parameters);
            Search();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record(s) deleted successfully.";
        }


        if (e.CommandName == "downbtn")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lbldown = (Label )row.FindControl("lbldown");
            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "\\Uploads\\Files\\" + Strings.Trim(lbldown.Text));
            if (F2.Exists)
            {
                Response.Redirect("~/BackOffice/DownloadFile.aspx?D=~\\Uploads\\Files\\" + Strings.Trim(lbldown.Text));
            }
            else
            {
                Page.RegisterStartupScript("mykey", "<script>alert('File Does Not Exists')</script>");
            }

        }

        if (e.CommandName == "lnkdetail")
        {
            Label3.Visible = false;
            Parameters.Clear();
            Parameters.Add("@app_id", e.CommandArgument.ToString());
            clsm.MoveRecord_Parameter(this, Label1.Parent, "select pa.Jobid,pa.App_id,pa.designation,pa.FName,pa.LName,pa.App_DOB,pa.Gender,pa.MaritalStatus,pa.Father_HusbandName,pa.App_Address,pa.Telephone,pa.Mobile,pa.App_Email,pa.City,pa.State,pa.App_Qualification,pa.App_Expyear,pa.App_Expmonth,pa.App_Skills,pa.AttachCV,pa.funarea,pa.cindustry,pa.plocation,pa.cemployer,pa.csalary,pa.CurrIndustries,pa.FuntionalArea,pa.Areaofintrst,pa.prefLocation,pa.country,pa.empdetails from PostedApplication pa  where app_id=@app_id", Parameters);
            Parameters.Clear();

            FNamelbl.Text = FName.Text.ToString();
            LNamelbl.Text = LName.Text.ToString();
            App_DOBlbl.Text = App_DOB.Text;
            Genderlbl.Text = Gender.Text.ToString();
            empdetailslbl.Text = empdetails.Text.Replace(Environment.NewLine, "<br/>");
            Telephonelbl.Text = Telephone.Text.ToString();
            mobilelbl.Text = mobile.Text.ToString();
            emaillbl.Text = App_Email.Text.ToString();
            // App_Skillslbl.Text = App_Skills.Text.Replace(Environment.NewLine, "<br/>");
            qualificationslbl.Text = App_Qualification.Text.Replace(Environment.NewLine, "<br/>");
            cemployerlbl.Text = cemployer.Text.ToString();
            // csalarylbl.Text = csalary.Text.ToString();
            cdesignationlbl.Text = designation.Text.ToString();
            //funarealbl.Text = funarea.Text.Replace(Environment.NewLine, "<br/>");
            //plocationlbl.Text = plocation.Text.ToString();
            lblcountry.Text = country.Text.ToString();
            if (lblcountry.Text == "0")
            {
                lblcountry.Text = "";
            }
            Labelstate.Text = state.Text.ToString();
            lbl_city.Text = city.Text.ToString();
           // lblPostalCode.Text = postalcode.Text.ToString();
            //lblMarital.Text = MaritalStatus.Text.ToString();
            // lblareaint.Text = Areaofintrst.Text.ToString();
            //lblexp.Text = App_Expyear.Text.ToString() + "." + App_Expmonth.Text.ToString() + " " + "year";
            lbltitledegree.Text = App_Skills.Text.ToString();
            ModalPopupExtender1.Show();
        }

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Footer | e.Row.RowType == DataControlRowType.Header)
        {
            
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }




    }
}