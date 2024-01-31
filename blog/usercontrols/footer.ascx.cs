using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class blog_usercontrols_footer : System.Web.UI.UserControl
{
    mainclass clsm = new mainclass();
    HttpCookie UserSession = default(HttpCookie);
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindmenu();
        }
    }
    protected void lnksubscribe_Click(object sender, EventArgs e)
    {
        if (clsm.Checking("select * from Subscribers where subemail='" + txtsubEmail.Text + "' and collegetype=0 ") == false)
        {
            SqlConnection cn = new SqlConnection(clsm.strconnect);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SubscribersSP";
            cmd.Parameters.AddWithValue("@subid", 0);
            cmd.Parameters.AddWithValue("@mobile", "");
            cmd.Parameters.AddWithValue("@subemail", txtsubEmail.Text);
            cmd.Parameters.AddWithValue("@collegetype","0");
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@uname", "user");
            cmd.Parameters.AddWithValue("@Mode", 1);
            cn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect("~/thankyou.aspx?mpgid=112&pgidtrail=112&msg=Sub");
        }
        else
        {
            Response.Redirect("~/thankyou.aspx?mpgid=112&pgidtrail=112&msg=Sub");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This email-id already registered.')", true);
        }
    }

    public void bindmenu()
    {
        Parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptrMenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Header%' or linkposition like'%Left Side Menu%'  or linkposition like'%Right Side Menu%'  and collageid=0 order by displayorder", Parameters);

        //Mobile Start
        HttpContext context = HttpContext.Current;
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
            {
                //Response.Write("mobile");
            }
            else
            {
                // Response.Write("dektop");
            }
        }
        //Mobile End
    }
    protected void rptrMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litdynamicrewrite = (Literal)e.Item.FindControl("litdynamicrewrite");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("anchlink");
            HtmlGenericControl limain = (HtmlGenericControl)e.Item.FindControl("limain");
            Repeater repinnermenu = (Repeater)e.Item.FindControl("repinnermenu");
            HtmlGenericControl divinnermenu = (HtmlGenericControl)e.Item.FindControl("divinnermenu");
            HtmlGenericControl divcampusmenu = (HtmlGenericControl)e.Item.FindControl("divcampusmenu");
            HtmlGenericControl divcollege = (HtmlGenericControl)e.Item.FindControl("divcollege");
            
            Repeater repleft = (Repeater)e.Item.FindControl("repleft");
            Repeater repcampus = (Repeater)e.Item.FindControl("repcampus");
            Parameters.Clear();
            Parameters.Add("@pageid", Conversion.Val(litpageid.Text));
            clsm.repeaterDatashow_Parameter(repinnermenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid   and collageid=0 order by displayorder ", Parameters);
            if (repinnermenu.Items.Count > 0)
            {
                limain.Attributes.Add("class", "m-drop");
                divinnermenu.Visible = true;
                
            }
            //college
            if (Conversion.Val(litpageid.Text) == 32)
            {
                limain.Attributes.Add("class", "m-drop");
                divcollege.Visible = true;
                divinnermenu.Visible = false;
                Parameters.Clear();
                clsm.repeaterDatashow_Parameter(repcampus, "select campus_name,campusid,rewriteurl from campus with (nolock) where status=1  order by displayorder ", Parameters);
            
            }
            //college
            //campus 
            if (Conversion.Val(litpageid.Text) == 30)
            {
                limain.Attributes.Add("class", "m-drop");
                divinnermenu.Visible = false;
                divcampusmenu.Visible = true;
                Parameters.Clear();
                clsm.repeaterDatashow_Parameter(repleft, "select campus_name,campusid,rewriteurl from campus with (nolock) where status=1  order by displayorder ", Parameters);
            }
            //campus 
            if (repinnermenu.Items.Count > 0)
            {
                anchlink.HRef = "javascript:void(0);";
            }
            else
            {
                if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
                {
                    anchlink.HRef = litpageurl.Text;
                    anchlink.Target = "_blank";
                }
                else
                {
                    if (!string.IsNullOrEmpty(litrewriteurl.Text))
                    {
                        anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                    }
                    else if (!string.IsNullOrEmpty(litdynamicrewrite.Text))
                    {
                        anchlink.HRef = "~" + litdynamicrewrite.Text.Trim();
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            if (Conversion.Val(litpageid.Text) == 30)
            {
                anchlink.HRef = "javascript:void(0);";
            }
            if (Conversion.Val(litpageid.Text) == 32)
            {
                anchlink.HRef = "javascript:void(0);";
            }

        }
    }
    protected void repinnermenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litdynamicrewrite = (Literal)e.Item.FindControl("litdynamicrewrite");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("anchlink");
            if (litpageurl.Text.Contains("http") == true || litpageurl.Text.Contains("https") == true)
            {
                anchlink.HRef = litpageurl.Text;
                anchlink.Target = "_blank";
            }
            else
            {
                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                }
                else if (!string.IsNullOrEmpty(litdynamicrewrite.Text))
                {
                    anchlink.HRef = "~" + litdynamicrewrite.Text.Trim();
                }
                else
                {
                    anchlink.HRef = "~/" + litpageurl.Text;
                }
            }
        }
    }
    protected void repleft_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcampusid = (Literal)e.Item.FindControl("litcampusid");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("anchlink");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");

                if (!string.IsNullOrEmpty(litrewriteurl.Text))
                {
                    anchlink.HRef = "~/" + litrewriteurl.Text.Trim();
                }
                else
                {
                    anchlink.HRef = "/campus.aspx?mpgid=30&pgidtrail=30&campusid=" + litcampusid.Text + "";
                }
            


            }
    }
    protected void repcampus_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater repcollegeleft = (Repeater)e.Item.FindControl("repcollegeleft");
            Literal litcampusid = (Literal)e.Item.FindControl("litcampusid");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("anchlink");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");

            Parameters.Clear();
            Parameters.Add("@campusid", Conversion.Val(litcampusid.Text));
            clsm.repeaterDatashow_Parameter(repcollegeleft, "select * from collage_master where status=1 and campusid=@campusid  order by displayorder ", Parameters);
        }
    }
    protected void repcollegeleft_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcollegetype = (Literal)e.Item.FindControl("litcollegetype");
            Literal litrewrite_url = (Literal)e.Item.FindControl("litrewrite_url");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("anchlink");
            if (litcollegetype.Text.Contains("http") == true || litcollegetype.Text.Contains("https") == true)
            {
                anchlink.HRef = litcollegetype.Text;
                anchlink.Target = "_blank";
            }
            else
            {
                if (!string.IsNullOrEmpty(litrewrite_url.Text))
                {
                    anchlink.HRef = "~/" + litrewrite_url.Text.Trim();
                }
                else
                {
                    anchlink.HRef = "~/" + litcollegetype.Text;
                }
            }
        }
    }
}