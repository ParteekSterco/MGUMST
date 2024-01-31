using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class layouts_menumaster : System.Web.UI.MasterPage
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["deptid"]) > 0)
            {
                binddatadept();
            }
            else if (Conversion.Val(Request.QueryString["collageid"]) > 0)
            {
                binddatacollage();
            }
            else
            {
                binddata();
            }
            binddropdownmenu();
            if (Conversion.Val(Request.QueryString["collageid"]) > 0)
            {
                a1.HRef = "/collage.aspx?collageid=" + Conversion.Val(Request.QueryString["collageid"]);
            }

        }
    }
    private void binddatadept()
    {
        if (Conversion.Val(Request.QueryString["deptid"]) > 0)
        {
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            littitlename.Text = Convert.ToString(clsm.SendValue_Parameter("select collagename from collage_master where status=1 and collageid=@collageid", parameters));
            if (Conversion.Val(Request.QueryString["mpgid"]) > 0)
            {
                panelcollage.Visible = true;
            }


            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            littitle.Text = Convert.ToString(clsm.SendValue_Parameter("select linkname from pagemasterdept where pagestatus=1 and pageid=@pageid and collageid=@collageid and deptid=@deptid", parameters));

            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            clsm.repeaterDatashow_Parameter(rptinnermenu, "select top 5 pageid,pagename,linkname,pageurl,rewriteurl,collageid from pagemasterdept where pagestatus=1 and  linkposition like'%Header%'  and collageid=@collageid and deptid=@deptid order by displayorder ", parameters);
            if (rptinnermenu.Items.Count > 0)
            {
                panelinnermenu.Visible = true;
                ulinnermenu.Visible = true;
            }
            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            parameters.Add("@deptid", Conversion.Val(Request.QueryString["deptid"]));
            double strpageno = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) from pagemasterdept where pagestatus=1 and  linkposition like'%Header%'  and collageid=@collageid and deptid=@deptid ", parameters));

            if (strpageno > 5)
            {
                l1_menu.Visible = true;
            }
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
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            littitle.Text = Convert.ToString(clsm.SendValue_Parameter("select linkname from pagemaster where pagestatus=1 and pageid=@pageid and collageid=@collageid", parameters));

            parameters.Clear();
            parameters.Add("@collageid", Conversion.Val(Request.QueryString["collageid"]));
            clsm.repeaterDatashow_Parameter(rptinnermenu, "select top 5 pageid,pagename,linkname,pageurl,rewriteurl,collageid from pagemaster where pagestatus=1 and  linkposition like'%Header%'  and collageid=@collageid order by displayorder ", parameters);
            if (rptinnermenu.Items.Count > 0)
            {
                panelinnermenu.Visible = true;
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
    private void binddata()
    {
        parameters.Clear();
        if (Conversion.Val(Request.QueryString["courseid"]) > 0)
        {
            parameters.Add("@courseid", Conversion.Val(Request.QueryString["courseid"]));
            littitle.Text = Convert.ToString(clsm.SendValue_Parameter("select coursename from course where status=1 and courseid=@courseid", parameters));
        }
        else
        {
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            littitle.Text = Convert.ToString(clsm.SendValue_Parameter("select linkname from pagemaster where pagestatus=1 and pageid=@pageid", parameters));
            panelcollage.Visible = true;
        }

        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
        littitlename.Text = Convert.ToString(clsm.SendValue_Parameter("select linkname from pagemaster where pagestatus=1 and pageid=@pageid", parameters));

        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
        clsm.repeaterDatashow_Parameter(rptinnermenu, "select top 5 pageid,pagename,linkname,pageurl,rewriteurl,collageid from pagemaster where pagestatus=1 and parentid=@pageid and  linkposition like'%Internal%'  and collageid=0 order by displayorder ", parameters);
        if (rptinnermenu.Items.Count > 0)
        {
            panelinnermenu.Visible = true;
            ulinnermenu.Visible = true;
        }
        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
        double strpageno = Convert.ToDouble(clsm.SendValue_Parameter("select count(*) from pagemaster where pagestatus=1 and parentid=@pageid and  linkposition like'%Internal%'  and collageid=0 ", parameters));

        if (strpageno > 5)
        {
            l1_menu.Visible = true;
        }
    }
    private void binddropdownmenu()
    {
        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(Request.QueryString["mpgid"]));
        string sql = "select pageid,pagename,linkname,pageurl,rewriteurl,collageid from pagemaster where pagestatus=1  ";
        if (Conversion.Val(Request.QueryString["collageid"]) > 0)
        {
            sql += " and linkposition like'%Header%'";
            sql += " and collageid=" + Conversion.Val(Request.QueryString["collageid"]);
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
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
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
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(litcollageid.Text);
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
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
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
                        anchlink.HRef = "~/" + litpageurl.Text + "&collageid=" + Conversion.Val(litcollageid.Text);
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