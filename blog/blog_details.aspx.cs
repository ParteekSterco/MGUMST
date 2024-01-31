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

public partial class blog_blog_details : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    string str = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindblogs();
        }
    }
    private void bindblogs()
    {
        string currentdate = "";
        parameters.Clear();
        parameters.Add("@blogid", Conversion.Val(Request.QueryString["blogid"]));
        string sqr = "select distinct top 1  b.* from Blogs b where b.status=1 and b.blogId=@blogid";

        clsm.repeaterDatashow_Parameter(repblogdetails, sqr, parameters);


        //DataSet ds = new DataSet();
        //parameters.Clear();
        //parameters.Add("@bid", Conversion.Val(Request.QueryString["bid"]));
        //ds = clsm.senddataset_Parameter("select distinct top 1  b.blogdate from Blogs b where b.status=1 and b.blogId=@bid ", parameters);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    currentdate = ds.Tables[0].Rows[0]["blogdate"].ToString();
        //}
    }

    protected void repblogdetails_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)))
        {
          
            Literal litBlogImage = (Literal)e.Item.FindControl("litBlogImage");
             HtmlImage imgblog = (HtmlImage)e.Item.FindControl("imgblog");

             if (!string.IsNullOrEmpty(litBlogImage.Text))
             {
                 imgblog.Src = "~/Uploads/blogs/" + litBlogImage.Text;
             }
             else
             {
                 imgblog.Visible = false;
             }

        }
    }
}