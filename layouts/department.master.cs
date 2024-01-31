using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class layouts_department : System.Web.UI.MasterPage
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["collageid"]) > 0 && Conversion.Val(Request.QueryString["deptid"]) > 0)
            {
                binddatacollage();

                a1.HRef = "/collage.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]);
                a2.HRef = "/department.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(Request.QueryString["deptid"]);
            }
            binddropdownmenu();
        }
    }
    private void binddatacollage()
    {
        if (Conversion.Val(Request.QueryString["collageid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            littitlename.Text = Convert.ToString(clsm.SendValue_Parameter("select collagename from collage_master where status=1 and collageid=@collageid", parameters));
            if (Conversion.Val(Request.QueryString["mpgid"]) > 0)
            {
                panelcollage.Visible = true;
            }

            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            litdeptname.Text = Convert.ToString(clsm.SendValue_Parameter("select deptname from Department_Master where status=1 and schoolid=@collageid and deptid=@deptid", parameters));
            if (!string.IsNullOrEmpty(litdeptname.Text))
            {
                paneldept.Visible = true;
            }

            if (Conversion.Val(Request.QueryString["mpgid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                littitle.Text = Convert.ToString(clsm.SendValue_Parameter("select linkname from pagemasterdept where pagestatus=1 and pageid=@pageid and deptid=@deptid", parameters));
            }
            if (Conversion.Val(Request.QueryString["deptid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
                clsm.repeaterDatashow_Parameter(rptinnermenu, "select top 5 pageid,pagename,linkname,pageurl,rewriteurl,deptid from pagemasterdept where pagestatus=1 and  linkposition like'%Header%' and deptid=@deptid order by displayorder ", parameters);
                if (rptinnermenu.Items.Count > 0)
                {
                    ulinnermenu.Visible = true;
                }
                parameters.Clear();
                parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
                double strpageno = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) from pagemaster where pagestatus=1 and  linkposition like'%Header%'  and collageid=@collageid ", parameters));

                if (strpageno > 5)
                {
                    l1_menu.Visible = true;
                }
            }

        }
    }
    private void binddropdownmenu()
    {
        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
        string sql = "select pageid,pagename,linkname,pageurl,rewriteurl,deptid from pagemasterdept where pagestatus=1  ";
        if (Conversion.Val(Request.QueryString["deptid"]) > 0)
        {
            sql += " and linkposition like'%Header%'";
            sql += " and deptid=" + Conversion.Val(Request.QueryString["deptid"]);
        }
        else
        {
            sql += " and linkposition like'%Internal%'";
            sql += " and parentid=@pageid";
        }
        string strpageid = Convert.ToString(ViewState["pageid"]);
        strpageid = strpageid.TrimEnd(',');
        if (!string.IsNullOrEmpty(strpageid))
        {
            sql += " and pageid not in (" + strpageid + ")  order by displayorder";
            //Response.Write(sql);
            clsm.repeaterDatashow_Parameter(rptdropdownmenu, sql, parameters);
        }
    }
    protected void rptinnermenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");


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
                else
                {
                    if (Conversion.Val(Request.QueryString["collageid"]) > 0)
                    {
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(litdeptid.Text);
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            if (Conversion.Val(litpageid.Text) == Conversion.Val(Request.QueryString["pgidtrail"]))
            {
                anchlink.Attributes.Add("class", "active");
            }
            ViewState["pageid"] += Convert.ToString(litpageid.Text) + ",";
        }
    }
    protected void rptdropdownmenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal litdeptid = (Literal)e.Item.FindControl("litdeptid");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

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
                else
                {
                    if (Conversion.Val(Request.QueryString["collageid"]) > 0)
                    {
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(Request.QueryString["collageid"]) + "&deptid=" + Conversion.Val(litdeptid.Text);
                    }
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }

        }
    }
}
