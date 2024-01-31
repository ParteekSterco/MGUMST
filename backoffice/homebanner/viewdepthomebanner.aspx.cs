using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class backoffice_homebanner_viewdepthomebanner : System.Web.UI.Page
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
            Parameters.Clear();
            clsm.Fillcombo_Parameter(" select btype,btypeid from depthomebannertype where 1=1  and deptid=" + Conversion.Val(Request.QueryString["depbtid"]) + "  order by  displayorder", Parameters, btypeid);

            if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
            {
                deptid.Text = Convert.ToString(Conversion.Val(Request.QueryString["depbtid"]));
                tr1.Visible = true;
                Hashtable Parameters1 = new Hashtable();
                Parameters1.Clear();
                Parameters1.Add("@depbtid", Convert.ToString(Conversion.Val(Request.QueryString["depbtid"])));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT DeptName FROM Department_Master WHERE deptid=@depbtid", Parameters1));
            }
            else
            {
                deptid.Text = "0";
            }

            Label1.Visible = false;
            griddata();

            if (Request.QueryString.HasKeys() == true)
            {
                if (Request.QueryString["edit"] == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";
                }
            }
        }
    }

    protected void griddata()
    {
        DataSet ds = new DataSet();
        Label1.Visible = false;
        string strq2 = string.Empty;
        Parameters.Clear();
        strq2 = "select  hm.* ,bt.btype  from depthomebanner hm left join depthomebannertype bt on hm.btypeid=bt.btypeid  where 1=1 ";
        Parameters.Add("@depbtid", Conversion.Val(Request.QueryString["depbtid"]));
        strq2 += " and hm.deptid=@depbtid ";
        if (btypeid.SelectedValue != "0")
        {
            Parameters.Add("@btypeid", btypeid.SelectedValue);
            strq2 += " and hm.btypeid=@btypeid ";
        }
        if (devicetype.SelectedValue != "0")
        {
            Parameters.Add("@devicetype", devicetype.SelectedValue);
            strq2 += " and hm.devicetype=@devicetype ";
        }

        strq2 += "  order by hm.displayorder";
        ds = clsm.senddataset_Parameter(strq2, Parameters);
        if (ds.Tables[0].Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "No Record(s) Found.";
            GridView1.Visible = false;
        }
        else
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            griddata();
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }

    }



    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "btndel")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblimage = (Label)row.FindControl("lblimage");
            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"].ToString() + "Uploads\\banner\\" + lblimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }

            Parameters.Clear();
            Parameters.Add("@bid", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from depthomebanner where bid=@bid", Parameters);
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";

        }
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");

            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@bid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update depthomebanner set status=1 where bid=@bid", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@bid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update depthomebanner set status=0 where bid=@bid", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }

        if (e.CommandName == "btnedit")
        {
            string strcollageid = String.Empty;
            if ((double.Parse(deptid.Text) > 0))
            {
                strcollageid = ("&depbtid=" + double.Parse(deptid.Text));
            }
            Response.Redirect("adddepthomebanner.aspx?bid=" + Convert.ToString(e.CommandArgument) + strcollageid);
        }


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
            Label lblimage = (Label)e.Row.FindControl("lblimage");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");

            ImageButton lnkstatus1 = (ImageButton)e.Row.FindControl("lnkstatus1");

            ImageButton lnkstatus2 = (ImageButton)e.Row.FindControl("lnkstatus2");

            Label lbltype = (Label)e.Row.FindControl("lbltype");
            Literal lblvideo = (Literal)e.Row.FindControl("lblvideo");
            HtmlGenericControl pvideo = e.Row.FindControl("pvideo") as HtmlGenericControl;

            if (Convert.ToString(lbltype.Text) == "Video")
            {
                imgimage.Visible = false;
                pvideo.Visible = true;

            }
            else
            {
                imgimage.Visible = true;
                pvideo.Visible = false;
                if (string.IsNullOrEmpty(lblimage.Text))
                {
                    imgimage.Visible = false;
                }
                else
                {
                    imgimage.Src = "../../Uploads/banner/" + Server.HtmlDecode(lblimage.Text);
                    imgimage.Visible = true;
                }
            }


            if (txtstatus.Text == "True")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            griddata();
        }
        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ex.Message.ToString();
        }
    }
}