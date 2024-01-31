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
using System.Configuration;

public partial class blog_index : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    Hashtable parameters = new Hashtable();
    string str = string.Empty;
    double j = 0;
    PagedDataSource _PageDataSource = new PagedDataSource();

    public string StrMetakey;
    public string StrMetadesc;
    public HttpCookie UserSession;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["sesscatid"] = "";
        if (!IsPostBack)
        {
            form1.Attributes.Add("Action", Request.RawUrl);
            ShowMetaData();
           // bindtblogs();
            BindItemsList();
            Session["sesscatid"] = "";
            Session["sesblogdate"] = "";
            Session["strsearch"] = "";
        }
    }
    private void ShowMetaData()
    {
        
        DataSet ds1 = new DataSet();
        parameters.Clear();
        parameters.Add("@Pageid", Conversion.Val(243));
        ds1 = clsm.senddataset_Parameter("select PageName,pagemeta,PageMetaDesc,PageTitle,UploadBanner,pagename,PageDescription,smalldesc from PageMaster with (nolock) where pagestatus=1 and Pageid=@Pageid", parameters);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            StrMetakey = Server.HtmlDecode(ds1.Tables[0].Rows[0]["pagemeta"].ToString());
            StrMetadesc = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageMetaDesc"].ToString());
            Page.Title = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageTitle"].ToString());
            //litaboutus.Text = Server.HtmlDecode(ds1.Tables[0].Rows[0]["PageDescription"].ToString());
            //litadmission.Text = Server.HtmlDecode(ds1.Tables[0].Rows[0]["smalldesc"].ToString());
        }
        Page.MetaKeywords = StrMetakey;
        Page.MetaDescription = StrMetadesc;
    }
    private void bindtblogs()
    {
        parameters.Clear();
        //string sqr = "select distinct b.bcattitle,c.* from Blogs c left join blogcategory b on b.bcatid=c.CatId where 1=1 and c.status=1 and  DATENAME(year,c.blogdate) in(year(getdate())) order by blogdate desc";

        //string sqr1 = "select distinct b.bcattitle,c.* from Blogs c left join blogcategory b on b.bcatid=c.CatId where 1=1 and c.status=1 ";

        string sqr1 = "select distinct b.bcattitle,c.* from Blogs c left join blogcategory b on b.bcatid=c.CatId where 1=1 and c.status=1 and  DATENAME(year,c.blogdate) in(select distinct top 1 DATENAME(year,c.blogdate) from blogs c  order by  DATENAME(year,c.blogdate) desc)";

        if (Session["sesscatid"] != null)
        {
            if (Conversion.Val(Session["sesscatid"]) > 0)
            {
                parameters.Add("@blogcatid", Conversion.Val(Session["sesscatid"]));
                sqr1 += " and c.catid=@blogcatid";
            }
        }

        if (Session["sesblogdate"] != null)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["sesblogdate"])))
            {
                parameters.Add("@blogdate", Convert.ToString(Session["sesblogdate"]));
                sqr1 += " and DATENAME(year,c.blogdate)=@blogdate";
            }
        }

        if (Session["strsearch"] != "")
        {
            if (!string.IsNullOrEmpty(Convert.ToString(Session["strsearch"])))
            {
                parameters.Add("@blogtitle", Convert.ToString(Session["strsearch"]));
                sqr1 += " and c.blogtitle like '%'+@blogtitle+'%'";
            }
        }


        sqr1 += " order by c.blogdate desc ";
        //Response.Write(sqr1);
        clsm.repeaterDatashow_Parameter(rptblogs, sqr1, parameters);
    }
    protected void rptblogs_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)))
        {
            Label lblblogId = e.Item.FindControl("lblblogId") as Label;
            Literal litBlogImage = (Literal)e.Item.FindControl("litBlogImage");
           // HtmlImage imgblog = (HtmlImage)e.Item.FindControl("imgblog");
            HtmlGenericControl divimg = (HtmlGenericControl)e.Item.FindControl("divimg");

            HtmlAnchor anchbcattitle = (HtmlAnchor)e.Item.FindControl("anchbcattitle");
            HtmlAnchor anchuncategory = (HtmlAnchor)e.Item.FindControl("anchuncategory");

            Literal litbcattitle = (Literal)e.Item.FindControl("litbcattitle");

            //Literal litUncategorized = (Literal)e.Item.FindControl("litUncategorized");

            Literal litsmalldesc = (Literal)e.Item.FindControl("litsmalldesc");

            if (!string.IsNullOrEmpty(litbcattitle.Text))
            {
                anchbcattitle.Visible = true;
                anchuncategory.Visible = false;
                
            }
            else
            {
                anchbcattitle.Visible = false;
                anchuncategory.Visible = true;
            }

            //if (!string.IsNullOrEmpty(litBlogImage.Text))
            //{
            //    imgblog.Src = "~/Uploads/blogs/" + litBlogImage.Text;
            //}
            //else
            //{
            //    imgblog.Src = "~/blog/images/information.jpg";
            //}

            if (!string.IsNullOrEmpty(litBlogImage.Text))
            {
                string str = "background: url(/Uploads/Blogs/" + litBlogImage.Text.Trim() + ") no-repeat; background-size: cover;";
                divimg.Attributes.Add("style", str);
            }
            else
            {
                divimg.Attributes.Add("style", "background: url(/Uploads/Blogs/2bs_talk-about-money.jpg) no-repeat; background-size: cover;");
            }

            if (litsmalldesc.Text != "")
            {
                int charno = 215;
                litsmalldesc.Text = Strings.Left(StripHtml(litsmalldesc.Text), charno);
                if (litsmalldesc.Text.Length >= charno)
                {
                    litsmalldesc.Text = Getstring(litsmalldesc.Text);
                    litsmalldesc.Text = litsmalldesc.Text + " ...</p>";
                }
                litsmalldesc.Text = Server.HtmlDecode(litsmalldesc.Text).Replace("<p>", "").Replace("</p>", "");
            }
            
        }
    }

    private DataTable GetDataTable()
    {
        DataTable dtItems = new DataTable();
        DataRow row = default(DataRow);
        parameters.Clear();
        string sqr1 = "";

        sqr1 = "select distinct b.bcattitle,c.* from Blogs c left join blogcategory b on b.bcatid=c.CatId where 1=1 and c.status=1 ";
       // sqr1 = "select distinct b.bcattitle,c.* from Blogs c left join blogcategory b on b.bcatid=c.CatId where 1=1 and c.status=1";
        //if (string.IsNullOrEmpty(Convert.ToString(Session["sesscatid"])) && string.IsNullOrEmpty(Convert.ToString(Session["sesblogdate"])) && string.IsNullOrEmpty(Convert.ToString(Session["strsearch"])))
        //{
        //    sqr1 += " and  DATENAME(year,c.blogdate) in(select distinct top 1 DATENAME(year,c.blogdate) from blogs c  order by  DATENAME(year,c.blogdate) desc)";
        //}
        //else
        //{


            if (Session["sesscatid"] != null)
            {
                if (Conversion.Val(Session["sesscatid"]) > 0)
                {
                    parameters.Add("@blogcatid", Conversion.Val(Session["sesscatid"]));
                    sqr1 += " and c.catid=@blogcatid";
                }
            }

            if (Session["sesblogdate"] != null)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["sesblogdate"])))
                {
                    parameters.Add("@blogdate", Convert.ToString(Session["sesblogdate"]));
                    sqr1 += " and DATENAME(year,c.blogdate)=@blogdate";
                }
            }

            if (Session["strsearch"] != "")
            {
                if (!string.IsNullOrEmpty(Convert.ToString(Session["strsearch"])))
                {
                    parameters.Add("@blogtitle", Convert.ToString(Session["strsearch"]));
                    sqr1 += " and c.blogtitle like '%'+@blogtitle+'%'";
                }
            }

       // }
        sqr1 += " order by c.blogdate desc ";

        DataSet dsdata = clsm.senddataset_Parameter(sqr1, parameters);
        dtItems = dsdata.Tables[0].Copy();
        return dtItems;
    }

    private void BindItemsList()
    {
        DataTable dataTable = this.GetDataTable();
        _PageDataSource.DataSource = dataTable.DefaultView;
        _PageDataSource.AllowPaging = true;
        _PageDataSource.PageSize = 10;
        _PageDataSource.CurrentPageIndex = CurrentPage;
        ViewState["TotalPages"] = _PageDataSource.PageCount;
        if (_PageDataSource.PageCount > 1)
        {
            divpaging.Visible = true;
        }
        else
        {
            divpaging.Visible = false;
        }

        lbtnPre.Enabled = !_PageDataSource.IsFirstPage;

        if (_PageDataSource.IsFirstPage)
        {
            li_pre.Visible = true;
        }
        else
        {
            li_pre.Visible = true;

        }
        lbtnNext.Enabled = !_PageDataSource.IsLastPage;

        if (_PageDataSource.IsLastPage)
        {
        }
        else
        {

        }


        rptblogs.DataSource = _PageDataSource;
        rptblogs.DataBind();
        if (rptblogs.Items.Count == 0)
        {
            rptblogs.Visible = false;
           // trnotice.Visible = true;
           // lblnotice.Text = "There are no record(s) available for display.";

        }
        else
        {
        }

        doPaging();
        dataTable.Clear();
    }
    private int fistIndex
    {
        get
        {
            int _FirstIndex = 0;
            if (ViewState["_FirstIndex"] == null)
            {
                _FirstIndex = 0;
            }
            else
            {
                _FirstIndex = Convert.ToInt32(ViewState["_FirstIndex"]);
            }
            return _FirstIndex;
        }
        set { ViewState["_FirstIndex"] = value; }
    }
    private int lastIndex
    {
        get
        {
            int _LastIndex = 0;
            if (ViewState["_LastIndex"] == null)
            {
                _LastIndex = 0;
            }
            else
            {
                _LastIndex = Convert.ToInt32(ViewState["_LastIndex"]);
            }
            return _LastIndex;
        }
        set { ViewState["_LastIndex"] = value; }
    }
    private int CurrentPage
    {
        get
        {
            object objPage = ViewState["_CurrentPage"];
            int _CurrentPage = 0;
            if (objPage == null)
            {
                _CurrentPage = 0;
            }
            else
            {
                _CurrentPage = Convert.ToInt32(objPage);
            }
            return _CurrentPage;
        }
        set { ViewState["_CurrentPage"] = value; }
    }
    private void doPaging()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("PageIndex");
        dt.Columns.Add("PageText");

        fistIndex = CurrentPage - 1;

        if (CurrentPage > 1)
        {
            lastIndex = CurrentPage + 4;
        }
        else
        {
            lastIndex = 5;
        }
        if (lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            fistIndex = lastIndex - 5;
        }

        if (fistIndex < 0)
        {
            fistIndex = 0;
        }

        for (int i = fistIndex; i <= lastIndex - 1; i++)
        {
            DataRow dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }
        dlPaging.DataSource = dt;
        dlPaging.DataBind();
    }
    protected void dlPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lnkbtnPaging = (LinkButton)e.Item.FindControl("lnkbtnPaging");

            HtmlGenericControl liactive = (HtmlGenericControl)e.Item.FindControl("liactive");
            if (lnkbtnPaging.CommandArgument.ToString() == CurrentPage.ToString())
            {
                lnkbtnPaging.Enabled = false;
                liactive.Attributes.Add("class", " page-item active");

            }
            else
            {
                lnkbtnPaging.Text = lnkbtnPaging.Text;
            }
        }
    }
    protected void dlPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("Paging"))
        {
            CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
            BindItemsList();
        }
    }
    protected void lbtnPre_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        this.BindItemsList();
    }
    protected void lbtnNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        this.BindItemsList();
    }

    public string StripHtml(string target)
    {
        Regex StripHTMLExpression = new Regex("<\\S[^><]*>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        return StripHTMLExpression.Replace(target, string.Empty);
    }
    public string Getstring(string str)
    {
        try
        {
            string strnew = null;
            Array arr = str.Split(' ');
            int k = 0;
            for (k = 0; k <= arr.Length - 2; k++)
            {
                strnew += arr.GetValue(k).ToString() + " ";
            }
            return strnew;
        }
        catch (Exception err)
        {
            throw (err);
        }
    }
}