using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class backoffice_blogs_view_blogs : System.Web.UI.Page
{
    public mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            Label1.Visible = false;
            if (Request.QueryString["edit"] == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record(s) updated successfully.";
            }

            gridshow();
        }
    }
    public string Pad(int numberOfSpaces)
    {
        var Spaces = default(string);
        for (int items = 1, loopTo = numberOfSpaces; items <= loopTo; items++)
            Spaces += "&nbsp;&nbsp;&raquo;&nbsp;";
        return Server.HtmlDecode(Spaces);
    }

    private void gridshow()
    {
        string strq = "select distinct b.bcattitle,bt.btopstitle,a.AutName,c.* from Blogs c left join blogcategory b on b.bcatid=c.CatId left join blogtopics bt on bt.btopsid=c.topicId left join AuthorMaster a on a.AutId=c.AutId where 1=1";
        strq += " order by c.displayorder desc";
        clsm.GridviewDatashow(GridView1, strq);
        if (GridView1.Rows.Count == 0)
        {
            trnotice.Visible = true;
            lblnotice.Text = "Records not found.";
        }
    }

    protected void GridView1_RowCommand(object sender,System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "lnkstatus")
        {
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;


            Label lblstatus = (Label)row.FindControl("lblstatus");

            if (lblstatus.Text == "False")
            {
                parameters.Clear();
                parameters.Add("@blogId", Convert.ToInt32(e.CommandArgument));
                string strsql = "update Blogs set status=1 where blogId=@blogId";
                clsm.ExecuteQry_Parameter(strsql, parameters);

            }
            else if (lblstatus.Text == "True")
            {
                parameters.Clear();
                parameters.Add("@blogId", Convert.ToInt32(e.CommandArgument));
                string strsql = "update Blogs set status=0 where blogId=@blogId";
                clsm.ExecuteQry_Parameter(strsql, parameters);

            }

            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Status changed successfully !!!";
        }

        if (e.CommandName == "edit")
        {
          
            Response.Redirect("add-blogs.aspx?blogId=" + e.CommandArgument);
        }

        if (e.CommandName == "btndel")
        {
            parameters.Clear();
            parameters.Add("@blogId", Conversion.Val(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from Blogs where blogId=@blogId", parameters);
            gridshow();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record(s) deleted successfully.";
        }
    }

    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton lnkstatus = (ImageButton)e.Row.FindControl("lnkstatus");
            Label lblstatus = (Label)e.Row.FindControl("lblstatus");

            if ((lblstatus.Text == "True"))
            {
                lnkstatus.ImageUrl = "~/Backoffice/assets/ico_unblock.png";
                lnkstatus.ToolTip = "Yes";
            }
            else if ((lblstatus.Text == "False"))
            {
                lnkstatus.ImageUrl = "~/Backoffice/assets/ico_block.png";
                lnkstatus.ToolTip = "No";
            }


            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='" + Convert.ToString((Session["altColor"])) + "'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");
        }

        //if (e.Row.RowType == DataControlRowType.DataRow | e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[5].Visible = false;
        //}
    }
}