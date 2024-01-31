using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Data;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;

public partial class blog_usercontrols_sideblog : System.Web.UI.UserControl
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindtrecentblogs();
            bindtcatblogs();
            bindtarcheiveblogs();
        }
    }

    private void bindtrecentblogs()
    {
        string sqr = "select distinct top 10 b.bcattitle,c.* from Blogs c left join blogcategory b on b.bcatid=c.CatId where 1=1 and c.status=1 ";
        parameters.Clear();
        sqr += " order by c.blogdate desc";

        clsm.repeaterDatashow_Parameter(rptlatestblogs, sqr, parameters);
        if (rptlatestblogs.Items.Count > 0)
        {
            divrecentpost.Visible = true;
        }
    }
    protected void rptlatestblogs_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)))
        {
        }
    }

    private void bindtcatblogs()
    {
        parameters.Clear();
        string sqr = "Select distinct b.* from blogcategory b right join Blogs c on b.bcatid=c.CatId where b.status=1 order by b.displayorder ";
        clsm.repeaterDatashow_Parameter(rptblogcat, sqr, parameters);
        if (rptblogcat.Items.Count > 0)
        {
            divcategories.Visible = true;
        }
    }
    protected void rptblogcat_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)))
        {
            Label lblbcatid = (Label)e.Item.FindControl("lblbcatid");
           // Session["sesscatid"] = Conversion.Val(lblbcatid.Text);
        }
    }
    protected void rptblogcat_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "blogcmd")
        {
            Session["sesscatid"] = e.CommandArgument;
            // string blogcatid = Convert.ToString(Session["sesscatid"]);
            Response.Redirect("/blog/index.aspx");
        }


    }



    private void bindtarcheiveblogs()
    {
        parameters.Clear();
       // string sqr = "select distinct  DATENAME(year,blogdate) as blogdate,DATENAME(year,blogdate) as blogid  from blogs where status=1 and  DATENAME(year,blogdate) not in(year(getdate()))  ";
        string sqr = "select distinct  DATENAME(year,blogdate) as blogdate,DATENAME(year,blogdate) as blogid  from blogs where status=1 and  DATENAME(year,blogdate) not in(select distinct top 1 DATENAME(year,blogdate) from blogs  order by  DATENAME(year,blogdate) desc) ";
        sqr += " order by blogdate desc";

        clsm.repeaterDatashow_Parameter(rparcheive, sqr, parameters);
        if (rparcheive.Items.Count > 0)
        {
            divarcheive.Visible = true;
        }
    }

    protected void rparcheive_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)))
        {
            Label lblblogid = (Label)e.Item.FindControl("lblblogid");
        }
    }

    protected void rparcheive_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "blogdatecmd")
        {
            Session["sesblogdate"] = e.CommandArgument;
            // string blogcatid = Convert.ToString(Session["sesscatid"]);
            Response.Redirect("/blog/index.aspx");
        }


    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string var = string.Empty;
        string ID = string.Empty;
        try
        {
            SqlConnection cn = new SqlConnection(clsm.strconnect);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "blog_enquirysp";

            cmd.Parameters.AddWithValue("@FName", txtname.Text);
            cmd.Parameters.AddWithValue("@Emailid", txtemail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
            
            cmd.Parameters.AddWithValue("@FMessage", txtmsg.Text);
            cmd.Parameters.AddWithValue("@uname", "user");
            cmd.Parameters.AddWithValue("@mode", 1);
            cmd.Parameters.Add("@eid", SqlDbType.Int, 0, "@eid").Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();

            ID = cmd.Parameters["@eid"].Value.ToString();
            cn.Close();
            var = ID;

            clear();
            Response.Redirect("~/blog/thankyou.aspx?msg=enquiry");
        }
        catch (Exception ex)
        {

        }
    }
    public void clear()
    {
        txtname.Text = "";
        txtmobile.Text = "";
        txtemail.Text = "";
        txtmsg.Text = "";
    }

    protected void lnksearch_Click(object sender, EventArgs e)
    {
       // string strsearch = txtsearch.Text.Replace("drop", "").Replace("--", "").Replace("truncate", "").Replace("<script>", "").Replace("</script>", "").Trim();
         string strsearch = txtsearch.Text.Replace("'", "");
        Session["strsearch"] = strsearch;
        Response.Redirect("/blog/index.aspx");
       // Response.wr
    }

}