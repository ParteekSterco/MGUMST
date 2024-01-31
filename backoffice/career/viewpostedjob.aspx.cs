using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class backoffice_career_viewpostedjob : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!Page.IsPostBack)
        {
            gridshow();
            int i = 0;
            int j = 0;
            for (i = 0; i <= 60; i++)
            {
                Min_Expyear.Items.Insert(i, i.ToString());
                Max_Expyear.Items.Insert(i, i.ToString());
            }
            for (j = 0; j <= 11; j++)
            {
                Min_expmonth.Items.Insert(j, j.ToString());
                Max_expmonth.Items.Insert(j, j.ToString());
            }
            Parameters.Clear();
            clsm.Fillcombo_Parameter("Select DeptName,DeptName as ids From Department_Master where status=1 order by DeptName", Parameters, department);
            if ( Convert.ToString(Request.QueryString["edit"]) == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Updated Successfully.";
            }
        }
    }
    
    private void gridshow()
    {
        string strq = "SELECT * FROM PostedJobs where 1=1";
        Parameters.Clear();
        if (!string.IsNullOrEmpty(txtjob.Text))
        {
            //strq &= " and jobtitle like '" & txtjob.Text & "%'"
            Parameters.Add("@jobtitle", txtjob.Text);
            strq += " and jobtitle like '%'+@jobtitle+'%'";
        }
        if (!string.IsNullOrEmpty(txtqualification.Text))
        {
            //strq &= " and Qualification like '%" & txtqualification.Text.Replace("'", "") & "%'"
            Parameters.Add("@Qualification", txtqualification.Text);
            strq += " and Qualification like '%'+@Qualification+'%'";
        }
        if (!string.IsNullOrEmpty(txtsodate.Text))
        {
            // strq &= " and JobOpening_date >= '" & txtsodate.Text & "'"
            Parameters.Add("@JobOpening_date", txtsodate.Text);
            strq += " and JobOpening_date >= @JobOpening_date";
        }
        if (!string.IsNullOrEmpty(txteodate.Text))
        {
            //strq &= " and JobOpening_date <= '" & txteodate.Text & "'"
            Parameters.Add("@JobOpening_dateone", txteodate.Text);
            strq += " and JobOpening_date <= @JobOpening_dateone";
        }
        if (!string.IsNullOrEmpty(txtscdate.Text))
        {
            // strq &= " and JobClosing_date >= '" & txtscdate.Text & "'"
            Parameters.Add("@JobClosing_date", txtscdate.Text);
            strq += " and JobClosing_date >= @JobClosing_date";
        }
        if (!string.IsNullOrEmpty(txtecdate.Text))
        {
            //strq &= " and JobClosing_date <= '" & txtecdate.Text & "'"
            Parameters.Add("@JobClosing_dateone", txtecdate.Text);
            strq += " and JobClosing_date <=@JobClosing_dateone";
        }
        if (department.SelectedIndex > 0)
        {
            // strq &= " and department ='" & department.SelectedValue.ToString() & "'"
            Parameters.Add("@department", department.Text);
            strq += " and department =@department";
        }
        if (ddlminexp.Text == "=")
        {
            //strq += " and Min_Expyear=" & Min_Expyear.SelectedValue & " and Min_expmonth=" & Min_expmonth.SelectedValue & " "
            Parameters.Add("@Min_Expyear", Min_Expyear.SelectedValue);
            Parameters.Add("@Min_expmonth", Min_expmonth.SelectedValue);
            strq += " and Min_Expyear=@Min_Expyear and Min_expmonth=@Min_expmonth";
        }
        else if (ddlminexp.Text == ">=")
        {
            // strq += " and Min_Expyear>=" & Min_Expyear.SelectedValue & " and Min_expmonth>=" & Min_expmonth.SelectedValue & ""
            Parameters.Add("@Min_Expyearone", Min_Expyear.SelectedValue);
            Parameters.Add("@Min_expmonthone", Min_expmonth.SelectedValue);
            strq += " and Min_Expyear>=@Min_Expyearone and Min_expmonth>=@Min_expmonthone";
        }
        else if (ddlminexp.Text == "<=")
        {
            //strq += " and Min_Expyear<=" & Min_Expyear.SelectedValue & " and Min_expmonth<=" & Min_expmonth.SelectedValue & ""
            Parameters.Add("@Min_Expyeartwo", Min_Expyear.SelectedValue);
            Parameters.Add("@Min_expmonthtwo", Min_expmonth.SelectedValue);
            strq += " and Min_Expyear<=@Min_Expyeartwo and Min_expmonth<=@Min_expmonthtwo";
        }
        if (ddlmaxexp.Text == "=")
        {
            //strq += " and Max_Expyear=" & Max_Expyear.SelectedValue & " and Max_expmonth=" & Max_expmonth.SelectedValue & " "
            Parameters.Add("@Max_Expyear", Max_Expyear.SelectedValue);
            Parameters.Add("@Max_expmonth", Max_expmonth.SelectedValue);
            strq += " and Max_Expyear=@Max_Expyear and Max_expmonth=@Max_expmonth";
        }
        else if (ddlminexp.Text == ">=")
        {
            //strq += " and Max_Expyear>=" & Max_Expyear.SelectedValue & " and Max_expmonth>=" & Max_expmonth.SelectedValue & ""
            Parameters.Add("@Max_Expyearone", Max_Expyear.SelectedValue);
            Parameters.Add("@Max_expmonthone", Max_expmonth.SelectedValue);
            strq += " and Max_Expyear>=@Max_Expyearone and Max_expmonth>=@Max_expmonthone";
        }
        else if (ddlminexp.Text == "<=")
        {
            //strq += " and Max_Expyear<=" & Max_Expyear.SelectedValue & " and Max_expmonth<=" & Max_expmonth.SelectedValue & ""
            Parameters.Add("@Max_Expyeartwo", Max_Expyear.SelectedValue);
            Parameters.Add("@Max_expmonthtwo", Max_expmonth.SelectedValue);
            strq += " and Max_Expyear<=@Max_Expyeartwo and Max_expmonth<=@Max_expmonthtwo";
        }
        strq += " order by displayorder";
        //clsm.GridviewDatashow(GridView1, strq)
        clsm.GridviewData_Parameter(GridView1, strq, Parameters);
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "No records";
        }
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        gridshow();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnedit")
        {
            Response.Redirect("jobposting.aspx?jid=" +Convert.ToString(e.CommandArgument));
        }
        if (e.CommandName == "btndel")
        {
           
            Parameters.Clear();
            Parameters.Add("@jobid",Convert.ToString(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from postedjobs where jobid=@jobid", Parameters);
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus =(TextBox) row.FindControl("txtstatus");
            if (txtstatus.Text == "True")
            {
               
                Parameters.Clear();
                Parameters.Add("@jobid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update postedjobs set status = 0 where jobid=@jobid", Parameters);
            }
            else if (txtstatus.Text == "False")
            {
               
                Parameters.Clear();
                Parameters.Add("@jobid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update postedjobs set status = 1 where jobid=@jobid", Parameters);
            }
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully.";
        }       

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus =(ImageButton) e.Row.FindControl("lnkstatus");
            TextBox txtstatus =(TextBox) e.Row.FindControl("txtstatus");
            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString(Session["altColor"]) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

        }
       
    }
}