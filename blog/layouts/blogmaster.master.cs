using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;
using System.Configuration;

public partial class blog_layouts_blogmaster : System.Web.UI.MasterPage
{
    public string can;
    public mainclass clsm = new mainclass();
    public string StrMetakey;
    public string StrMetadesc;
    public HttpCookie UserSession;
    Hashtable parameters = new Hashtable();
    public string strurl = "";
    public string strnoindex = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            form1.Attributes.Add("Action", Request.RawUrl);
            strnoindex = "index, follow";
            strurl = ConfigurationManager.AppSettings["canonicaltag"] + Request.RawUrl;

            //ShowMetaData();

        }
    }
    //private void ShowMetaData()
    //{
    //    DataSet ds1 = new DataSet();
    //    if (Conversion.Val(Request.QueryString["blogid"]) != 0)
    //    {
    //        parameters.Clear();
    //        parameters.Add("@blogid", Conversion.Val(Request.QueryString["blogid"]));
    //        ds1 = clsm.senddataset_Parameter("select pagemeta,PageMetaDesc,PageTitle,canonical,no_indexfollow,pagescript from  Blogs where blogId =@blogid", parameters);
    //        if (ds1.Tables[0].Rows.Count > 0)
    //        {
    //            StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
    //            StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
    //            Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
    //            if (Convert.ToString(ds1.Tables[0].Rows[0]["no_indexfollow"]) == "True")
    //            {
    //                strnoindex = "noindex, nofollow";
    //            }
    //            litpagescript.Text = Convert.ToString(ds1.Tables[0].Rows[0]["pagescript"].ToString());

    //        }
    //        Page.MetaDescription = StrMetadesc;
    //        Page.MetaKeywords = StrMetakey;
    //    }
    //}
}
