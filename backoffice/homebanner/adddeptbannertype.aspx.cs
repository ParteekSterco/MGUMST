using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;

public partial class backoffice_homebanner_adddeptbannertype : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public int appno;
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, System.EventArgs e)
    {
        trerror.Visible = false;
        trnotice.Visible = false;
        trsuccess.Visible = false;
        if ((Page.IsPostBack == false))
        {
            if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
            {
                deptid.Text = Convert.ToString(Conversion.Val(Request.QueryString["depbtid"]));
                tr1.Visible = true;
                Parameters.Clear();
                Parameters.Add("@depbtid", Convert.ToString(Conversion.Val(Request.QueryString["depbtid"])));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT DeptName FROM Department_Master WHERE deptid=@depbtid", Parameters));
            }
            else
            {
                deptid.Text = "0";
            }

            if ((Conversion.Val(Request.QueryString["btypeid"]) > 0))
            {
                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(Request.QueryString["btypeid"]));
                string strsql = "select * from depthomebannertype where btypeid=@btypeid  ";
                if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
                {
                    Parameters.Add("@depbtid", Convert.ToString(Request.QueryString["depbtid"]));
                    strsql += " and deptid=@depbtid ";
                }
                clsm.MoveRecord_Parameter(this, btypeid.Parent, strsql, Parameters);
            }
            if (Convert.ToString(Request.QueryString["add"]) == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Added Successfully.";
            }
            if (Convert.ToString(Request.QueryString["edit"]) == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record updated Successfully.";
            }
          gridshow();
        }
    }
    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {

                if (Convert.ToInt32(clsm.MasterSave(this, btypeid.Parent, 6, mainclass.Mode.modeCheckDuplicate, "depthomebannertypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])))) > 0)
                {
                    trnotice.Visible = true;
                    lblnotice.Text = "This Banner Type already exist.";
                    return;
                }
                if (Conversion.Val(btypeid.Text) == 0)
                {

                   string var=clsm.MasterSave(this, btypeid.Parent, 6, mainclass.Mode.modeAdd, "depthomebannertypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));

                   //***************** for log history*********************

                   clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Add", Convert.ToString(btype.SelectedValue), Convert.ToString(var), Convert.ToString("Department Banner Type"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), Convert.ToString(lblcollage.Text));

                   //*********************** end for log history*******************************

                    //Response.Redirect("addhomebannertype.aspx?add=add");
                    // Response.Redirect(("addhomebannertype.aspx?add=add&clid=" + Conversion.Val(Request.QueryString["clid"]) + ""));

                    string strcollageid = String.Empty;
                    if (Conversion.Val(deptid.Text) > 0)
                    {
                        strcollageid = "&depbtid=" + Conversion.Val(deptid.Text);
                    }
                    Response.Redirect("adddeptbannertype.aspx?add=add" + strcollageid);


                    //clsm.ClearallPanel(this, btypeid.Parent);
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record added successfully.";
                }
                else
                {
                    string var = clsm.MasterSave(this, btypeid.Parent, 6, mainclass.Mode.modeModify, "depthomebannertypeSP", Server.HtmlDecode(Convert.ToString(Session["UserId"])));


                    //***************** for log history*********************

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Edit", Convert.ToString(btype.SelectedValue), Convert.ToString(var), Convert.ToString("Department Banner Type"), Convert.ToString(Conversion.Val(Request.QueryString["clid"])), Convert.ToString(lblcollage.Text));

                    //*********************** end for log history*******************************
                    // Response.Redirect("addhomebannertype.aspx?edit=edit");

                    // Response.Redirect(("addhomebannertype.aspx?edit=edit&clid=" + Conversion.Val(Request.QueryString["clid"]) + ""));

                    string strcollageid = String.Empty;
                    if (Conversion.Val(deptid.Text) > 0)
                    {
                        strcollageid = "&depbtid=" + Conversion.Val(deptid.Text);
                    }
                    Response.Redirect("adddeptbannertype.aspx?edit=edit" + strcollageid);


                   
                    gridshow();
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record updated successfully.";
                }

            }
            catch (Exception ex)
            {
                trerror.Visible = true;
                lblerror.Text = ex.Message;
            }

        }

    }



    protected void gridshow()
    {
        try
        {
            Parameters.Clear();
            string strsql = "select * from depthomebannertype where 1=1 ";
            //if (Conversion.Val(Request.QueryString["clid"]) > 0)
            //{
            Parameters.Add("@depbtid", Conversion.Val(Request.QueryString["depbtid"]));
            strsql += " and deptid=@depbtid";
            //}
            //else
            //{
            //    strsql += " and collageid=0";
            //}
            strsql += " order by displayorder";


            clsm.GridviewData_Parameter(GridView1, strsql, Parameters);
            appno = GridView1.Rows.Count;
            if ((GridView1.Rows.Count == 0))
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Record found.";
            }

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            

            string strcollageid = String.Empty;
            if ((double.Parse(deptid.Text) > 0))
            {
                strcollageid = ("&depbtid=" + double.Parse(deptid.Text));
            }
            Response.Redirect("adddeptbannertype.aspx?btypeid=" + Convert.ToString(e.CommandArgument) + strcollageid);
        }

        if (e.CommandName == "status")
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");
            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update depthomebannertype set status=1 where btypeid=@btypeid and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "", Parameters);


                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));

                clsm.ExecuteQry_Parameter("update depthomebannertype set status=0 where btypeid!=@btypeid and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update depthomebannertype set status=0 where btypeid=@btypeid and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }


        if (e.CommandName == "mobilestatus")
        {
            GridViewRow row = ((GridViewRow)(((Control)(e.CommandSource)).NamingContainer));
            TextBox mobiletxtstatus = (TextBox)row.FindControl("mobiletxtstatus");
            if (mobiletxtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update depthomebannertype set mobilestatus=1 where btypeid=@btypeid and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "", Parameters);

                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update depthomebannertype set mobilestatus=0 where btypeid!=@btypeid and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "", Parameters);
            }
            else if (mobiletxtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
                clsm.ExecuteQry_Parameter("update depthomebannertype set mobilestatus=0 where btypeid=@btypeid and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "", Parameters);
            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if (e.CommandName == "del")
        {
            Parameters.Clear();
            Parameters.Add("@btypeid", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from depthomebannertype where btypeid=@btypeid", Parameters);
            gridshow();
            trnotice.Visible = true;
            lblnotice.Text = "Record deleted successfully.";
        }

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if ((e.Row.RowType == DataControlRowType.DataRow))
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

            ImageButton mobilelnkstatus = (ImageButton)e.Row.FindControl("mobilelnkstatus");
            TextBox mobiletxtstatus = (TextBox)e.Row.FindControl("mobiletxtstatus");


            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "../assets/ico_unblock.png";
                lnkstatus.ToolTip = "Yes";
            }
            else if (txtstatus.Text == "False")
            {
                lnkstatus.ImageUrl = "../assets/ico_block.png";
                lnkstatus.ToolTip = "No";
            }

            if (mobiletxtstatus.Text == "True")
            {
                mobilelnkstatus.ImageUrl = "../assets/ico_unblock.png";
                mobilelnkstatus.ToolTip = "Yes";
            }
            else if (mobiletxtstatus.Text == "False")
            {
                mobilelnkstatus.ImageUrl = "../assets/ico_block.png";
                mobilelnkstatus.ToolTip = "No";
            }
        }

    }

    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        //Response.Redirect("addhomebannertype.aspx");

        string strcollageid = String.Empty;
        if (Conversion.Val(deptid.Text) > 0)
        {
            strcollageid = "&depbtid=" + Conversion.Val(deptid.Text);
        }
        Response.Redirect("adddeptbannertype.aspx" + strcollageid);
       
    }
}