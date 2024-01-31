using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
public partial class BackOffice_team_view_team : System.Web.UI.Page
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
            if (Conversion.Val(Request.QueryString["clid"]) > 0)
            {
                Parameters.Clear();
                Parameters.Add("@collageid", Conversion.Val(Request.QueryString["clid"]));
                clsm.Fillcombo_Parameter(" select ttype,ttypeid from teamtype where status=1 and collageid=@collageid order by  displayorder", Parameters, typeid);
            }
            else
            {
                Parameters.Clear();
                clsm.Fillcombo_Parameter(" select ttype,ttypeid from teamtype where status=1  and ttypeid=1 and collageid=0  order by  displayorder", Parameters, typeid);
            }

            if (Conversion.Val(Request.QueryString["clid"]) > 0)
            {
                collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));
                tr1.Visible = true;
                Hashtable Parameters1 = new Hashtable();
                Parameters1.Clear();
                Parameters1.Add("@COLLAGEID", Convert.ToString(Conversion.Val(Request.QueryString["clid"])));
                lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters1));
            }
            else
            {
                collageid.Text = "0";
            }
           


            griddata();
            if (Request.QueryString.Count>0)
            {
                if (Convert.ToString(Request.QueryString["edit"]) == "edit")
                {
                    trsuccess.Visible = true;
                    lblsuccess.Text = "Record Updated Successfully.";
                }
            }

        }
    }
    protected void griddata()
    {
        string strq2 = string.Empty;
        DataSet ds = new DataSet();
        Parameters.Clear();
        strq2 = "select t.*,tt.ttype from ourteam t  inner join teamtype tt on t.ttypeid=tt.ttypeid where 1=1  ";
        if(Conversion.Val(typeid.SelectedValue) != 0)
        {
            Parameters.Add("@type",Conversion.Val( typeid.SelectedValue));
            strq2 += " and t.ttypeid=@type ";
        }
        if (!string.IsNullOrEmpty(TextBox4.Text))
        {
            Parameters.Add("@name",TextBox4.Text);
            strq2 += " and t.name like '%'+@name+'%'";
        }

        if (!string.IsNullOrEmpty(txtdesignation.Text))
        {
            Parameters.Add("@Designation", txtdesignation.Text);
            strq2 += " and t.industries like '%'+@Designation+'%'";
        }
        //if (Conversion.Val(Request.QueryString["clid"]) > 0)
        //{
        Parameters.Add("@collageid", Conversion.Val(Request.QueryString["clid"]));
            strq2 += " and t.collageid=@collageid ";
       // }
        strq2 += "  order by t.displayorder";
        ds = clsm.senddataset_Parameter(strq2, Parameters);
        if (ds.Tables[0].Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "No data found";
            GridView1.Visible = false;
        }
        else
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            GridView1.Visible = true;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    

        if (e.CommandName=="del")
        {

            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblimagesmall = (Label)row.FindControl("lblimagesmall");
            Label lbllargeimage = (Label)row.FindControl("lbllargeimage");
            FileInfo F2 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lblimagesmall.Text);
            if (F2.Exists)
            {
                F2.Delete();
            }

            FileInfo F1 = new FileInfo(Request.ServerVariables["Appl_Physical_Path"] + "Uploads\\SmallImages\\" + lbllargeimage.Text);
            if (F1.Exists)
            {
                F1.Delete();
            }
            Parameters.Clear();
            Parameters.Add("@teamid", e.CommandArgument.ToString());
            clsm.ExecuteQry_Parameter("delete from ourteam where teamid=@teamid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully.";
          
        }


        if (e.CommandName == "status")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            TextBox txtstatus = (TextBox)row.FindControl("txtstatus");

            if (txtstatus.Text == "False")
            {
                Parameters.Clear();
                Parameters.Add("@teamid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update ourteam set status=1 where teamid=@teamid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);
            }
            else if (txtstatus.Text == "True")
            {
                Parameters.Clear();
                Parameters.Add("@teamid", e.CommandArgument.ToString());
                clsm.ExecuteQry_Parameter("update ourteam set status=0 where teamid=@teamid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "", Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status Changed Successfully !!!";
        }

        if (e.CommandName == "lnkshowonhome")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblshowonhome = (Label)row.FindControl("lblshowonhome");

            if (lblshowonhome.Text == "False")
            {

                Parameters.Clear();
                Parameters.Add("@teamid", Convert.ToInt32(e.CommandArgument));
                string strsql = "update ourteam set showonhome=1 where teamid=@teamid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "";
                clsm.ExecuteQry_Parameter(strsql, Parameters);

            }
            else if (lblshowonhome.Text == "True")
            {

                Parameters.Clear();
                Parameters.Add("@teamid", Convert.ToInt32(e.CommandArgument));
                string strsql = "update ourteam set showonhome=0 where teamid=@teamid and collageid=" + Conversion.Val(Request.QueryString["clid"]) + "";
                clsm.ExecuteQry_Parameter(strsql, Parameters);
            }
            griddata();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully.";
        }

        if (e.CommandName == "edit")
        {
            string strcollageid = String.Empty;
            if ((double.Parse(collageid.Text) > 0))
            {
                strcollageid = ("&clid=" + double.Parse(collageid.Text));
            }
            Response.Redirect("our-team.aspx?teamid=" + Convert.ToString(e.CommandArgument) + strcollageid);

        }


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkshowonhome = (ImageButton)e.Row.FindControl("lnkshowonhome");
            Label lblshowonhome = (Label)e.Row.FindControl("lblshowonhome");
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            HtmlImage imgimage = (HtmlImage)e.Row.FindControl("imgimage");
            TextBox txtstatus = (TextBox)e.Row.FindControl("txtstatus");
            HtmlImage imgsmall = (HtmlImage)e.Row.FindControl("imgsmall");
            Label lblimagesmall = (Label)e.Row.FindControl("lblimagesmall");
            if (string.IsNullOrEmpty(lblimagesmall.Text))
            {
                imgsmall.Visible = false;
            }
            else
            {
                imgsmall.Src = "~/Uploads/SmallImages/" + lblimagesmall.Text;
                imgsmall.Visible = true;
            }
            if(txtstatus.Text=="True")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Active";
            }
            else if(txtstatus.Text=="False")
            {
                lnkstatus.ImageUrl = "~/BackOffice/assets/ico_block.png";
                lnkstatus.ToolTip = "Inactive";
            }
            if (lblshowonhome.Text == "True")
            {
                lnkshowonhome.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkshowonhome.ToolTip = "Yes";
            }
            else if (lblshowonhome.Text == "False")
            {
                lnkshowonhome.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkshowonhome.ToolTip = "No";
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
            
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        griddata();
    }
}