using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class search : System.Web.UI.Page
{
    Hashtable Parameters = new Hashtable();
    mainclass clsm = new mainclass();
    PagedDataSource _PageDataSource = new PagedDataSource();
    public Int32 totalcount = 0;
    public string strPageMetaDesc, strPageMeta, strpagetitle, strpagename;
    public string strmaxfirst, strmaxsecond, strmaxthr, strmaxfour;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindItemsList();
        }
    }
    private void BindItemsList()
    {
        DataTable dataTable = GetDataTable();
        _PageDataSource.DataSource = dataTable.DefaultView;
        _PageDataSource.AllowPaging = true;
        _PageDataSource.PageSize = 20;
        _PageDataSource.CurrentPageIndex = CurrentPage;
        ViewState["TotalPages"] = _PageDataSource.PageCount;
        if (_PageDataSource.PageCount == 1)
        {
            divpaging.Visible = false;
        }
        else
        {
            divpaging.Visible = true;
        }

        lbtnPre.Enabled = !_PageDataSource.IsFirstPage;

        if (_PageDataSource.IsFirstPage)
        {
            lbtnPre.Text = "<span class='prevnext'> Previous </span>";
        }
        else
        {
            lbtnPre.Text = "<span>Previous</span>";
        }
        lbtnNext.Enabled = !_PageDataSource.IsLastPage;

        if (_PageDataSource.IsLastPage)
        {
            lbtnNext.Text = "<span class='prevnext'> Next </span>";

        }
        else
        {
            lbtnNext.Text = "<span>Next</span>";
        }

        rptrsearch.DataSource = _PageDataSource;
        rptrsearch.DataBind();
        if (rptrsearch.Items.Count == 0)
        {
            rptrsearch.Visible = false;
            //trnotice.Visible = true;
            //lblnotice.Text = "There are no record for display.";

        }
        else
        {
        }
        doPaging();
        dataTable.Clear();
    }

    public DataTable GetDataTable()
    {
        DataTable dtItems = new DataTable();

        DataColumn dcpageid = new DataColumn();
        DataColumn dcstitle = new DataColumn();
        DataColumn dcsdesc = new DataColumn();
        DataColumn lngdesc = new DataColumn();
        DataColumn dcpageurl = new DataColumn();

        DataColumn pid = new DataColumn();
        DataColumn PName = new DataColumn();
        DataColumn shortdesc = new DataColumn();
        DataColumn pdetail = new DataColumn();

        dcpageid.ColumnName = "pageid";
        dcstitle.ColumnName = "stitle";
        dcsdesc.ColumnName = "sdesc";
        lngdesc.ColumnName = "ldesc";
        dcpageurl.ColumnName = "pageurl";

        dcpageid.DataType = System.Type.GetType("System.Int32");
        dcstitle.DataType = System.Type.GetType("System.String");
        dcsdesc.DataType = System.Type.GetType("System.String");
        lngdesc.DataType = System.Type.GetType("System.String");
        dcpageurl.DataType = System.Type.GetType("System.String");

        dtItems.Columns.Add(dcpageid);
        dtItems.Columns.Add(dcstitle);
        dtItems.Columns.Add(dcsdesc);
        dtItems.Columns.Add(lngdesc);
        dtItems.Columns.Add(dcpageurl);
        DataSet dsdata = new DataSet();
        DataRow row = default(DataRow);
        SqlConnection objcon = new SqlConnection(clsm.strconnect);
        objcon.Open();

        Parameters.Clear();
        string fullstring, innersql;
        innersql = "";
        string strqry = "";
        string strqrynew = "";
        strqry = "select distinct pageid,pagetitle,  LTRIM(PageName) stitle, PageMeta as sdesc,PageMetaDesc as ldesc,pageurl=case when rewriteurl<>'' then rewriteurl Else replace(pageurl,'~/','')   End from pagemaster where PageStatus=1 and collageid=0 ";
        strqrynew = "select distinct pageid,pagetitle, PageName stitle, PageMeta as sdesc,PageMetaDesc as ldesc,pageurl=case when rewriteurl<>'' then rewriteurl Else replace(pageurl,'~/','')   End from pagemaster where PageStatus=1 and collageid=0 ";
        if (!string.IsNullOrEmpty(Request.QueryString["search"]))
        {
            Parameters.Add("@PageMetaDesc", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@PageMeta", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@pagetitle", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@pagename", Server.UrlDecode(Request.QueryString["search"]));

            strqry += " and (PageMetaDesc like '%'+@PageMetaDesc+'%' or PageMeta like '%'+@PageMeta+'%' or pagetitle like '%'+@pagetitle+'%' or pagename like '%'+@pagename+'%')";
        }

        strqry += " order by LTRIM(PageName),ldesc";
        dsdata = clsm.senddataset_Parameter(strqry, Parameters);
        totalcount = dsdata.Tables[0].Rows.Count;
        int i = 0;
        if (dsdata.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i <= dsdata.Tables[0].Rows.Count - 1; i++)
            {
                row = dtItems.NewRow();
                row["pageid"] = dsdata.Tables[0].Rows[i]["pageid"];
                row["stitle"] = dsdata.Tables[0].Rows[i]["stitle"];
                row["sdesc"] = dsdata.Tables[0].Rows[i]["sdesc"];
                row["ldesc"] = dsdata.Tables[0].Rows[i]["ldesc"];
                row["pageurl"] = dsdata.Tables[0].Rows[i]["pageurl"];
                ViewState["pageid"] += dsdata.Tables[0].Rows[i]["pageid"] + ",";
                dtItems.Rows.Add(row);
            }
        }
        Parameters.Clear();
        strqry = "";
        strqry = "select distinct facultyid as pageid,fname as stitle, Designation as Designation, smalldesc as ldesc, pageurl='facultydetail.aspx?mpgid=34&pgidtrail=35&fid='+convert(varchar,facultyid) from Addfacultymaster where status=1";

        if (!string.IsNullOrEmpty(Request.QueryString["search"]))
        {
            Parameters.Add("@pagemetadesc", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@pagemeta", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@PageTitle", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@fname", Server.UrlDecode(Request.QueryString["search"]));

            strqry += " and (PageMetaDesc like '%'+@PageMetaDesc+'%' or PageMeta like '%'+@PageMeta+'%' or pagetitle like '%'+@pagetitle+'%' or fname like '%'+@fname+'%')";
        }

        dsdata = clsm.senddataset_Parameter(strqry, Parameters);
        totalcount = totalcount + dsdata.Tables[0].Rows.Count;
        if (dsdata.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i <= dsdata.Tables[0].Rows.Count - 1; i++)
            {
                row = dtItems.NewRow();
                row["pageid"] = dsdata.Tables[0].Rows[i]["pageid"];
                row["stitle"] = dsdata.Tables[0].Rows[i]["stitle"];
                row["ldesc"] = dsdata.Tables[0].Rows[i]["ldesc"];
                row["pageurl"] = dsdata.Tables[0].Rows[i]["pageurl"];
                ViewState["pageid"] += dsdata.Tables[0].Rows[i]["pageid"] + ",";
                dtItems.Rows.Add(row);
            }
        }

        // Course list
        Parameters.Clear();
        strqry = "";
        strqry = "select distinct courseid as pageid,coursename as stitle,coursedetail as ldesc, pageurl='coursedetail.aspx?mpgid=126&pgidtrail=126&courseid='+convert(varchar,courseid) from Course where status=1";

        if (!string.IsNullOrEmpty(Request.QueryString["search"]))
        {
            Parameters.Add("@PageMetaDesc", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@PageMeta", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@PageTitle", Server.UrlDecode(Request.QueryString["search"]));
            Parameters.Add("@coursename", Server.UrlDecode(Request.QueryString["search"]));

            strqry += " and (PageMetaDesc like '%'+@PageMetaDesc+'%' or PageMeta like '%'+@PageMeta+'%' or pagetitle like '%'+@pagetitle+'%' or coursename like '%'+@coursename+'%')";
        }

        dsdata = clsm.senddataset_Parameter(strqry, Parameters);
        totalcount = totalcount + dsdata.Tables[0].Rows.Count;
        if (dsdata.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i <= dsdata.Tables[0].Rows.Count - 1; i++)
            {
                row = dtItems.NewRow();
                row["pageid"] = dsdata.Tables[0].Rows[i]["pageid"];
                row["stitle"] = dsdata.Tables[0].Rows[i]["stitle"];
                row["ldesc"] = dsdata.Tables[0].Rows[i]["ldesc"];
                row["pageurl"] = dsdata.Tables[0].Rows[i]["pageurl"];
                ViewState["pageid"] += dsdata.Tables[0].Rows[i]["pageid"] + ",";
                dtItems.Rows.Add(row);
            }
        }


        //CODE FOR MEDIA SECTION 
        //*******************************************************************************

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["pageid"])))
        {
            ViewState["pageid"] = ViewState["pageid"].ToString().TrimEnd(',');
        }

        if (!string.IsNullOrEmpty(Server.UrlDecode(Request.QueryString["search"])))
        {
            string[] addrs = Request.QueryString["search"].Split(' ');
            if (addrs.Length > 1)
            {
                foreach (string addr in addrs)
                {
                    innersql += strqrynew;
                    innersql += " and (PageMetaDesc like '%" + addr.ToString() + "%' or PageMeta like '%" + addr.ToString() + "%' or pagetitle like '%" + addr.ToString() + "%' or pagename like '%" + addr.ToString() + "%')";
                    if (!string.IsNullOrEmpty(Convert.ToString(ViewState["pageid"])))
                    {
                        innersql += " and pageid not in (" + Convert.ToString(ViewState["pageid"]) + ")";
                    }
                    innersql += " union ";
                }

                if (!string.IsNullOrEmpty(innersql))
                {
                    int lp = innersql.Length;
                    innersql = innersql.Substring(0, lp - 7);
                    fullstring = innersql;
                    dsdata.Clear();
                    dsdata = clsm.senddataset_Parameter(fullstring, Parameters);
                }
                totalcount = totalcount + dsdata.Tables[0].Rows.Count;
                if (dsdata.Tables[0].Rows.Count > 0)
                {
                    for (i = 0; i <= dsdata.Tables[0].Rows.Count - 1; i++)
                    {
                        row = dtItems.NewRow();
                        row["pageid"] = dsdata.Tables[0].Rows[i]["pageid"];
                        row["stitle"] = dsdata.Tables[0].Rows[i]["stitle"];
                        row["sdesc"] = dsdata.Tables[0].Rows[i]["sdesc"];
                        row["ldesc"] = dsdata.Tables[0].Rows[i]["ldesc"];
                        row["pageurl"] = dsdata.Tables[0].Rows[i]["pageurl"];
                        dtItems.Rows.Add(row);
                    }
                }
            }
        }
        return dtItems;
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
            if (lnkbtnPaging.CommandArgument.ToString() == CurrentPage.ToString())
            {
                lnkbtnPaging.Enabled = false;

                lnkbtnPaging.CssClass = "active";
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
    protected void lbtnPre_Click(object sender, System.EventArgs e)
    {
        CurrentPage -= 1;
        this.BindItemsList();
    }
    protected void lbtnNext_Click(object sender, System.EventArgs e)
    {
        CurrentPage += 1;
        this.BindItemsList();
    }
    protected void Page_LoadComplete(object sender, System.EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["search"]))
        {
            litmess.Text = "There are " + totalcount.ToString() + " results for &nbsp;&#34;" + Server.HtmlDecode(Request.QueryString["search"]) + "&#34";

            if (Conversion.Val(totalcount) == 0)
            {
                litmess.Text = "No results found for &nbsp;&#34;" + Server.HtmlDecode(Request.QueryString["search"]) + "&#34";
            }
        }
        else
        {
            litmess.Text = "There are " + totalcount.ToString() + " results";
            if (Conversion.Val(totalcount) == 0)
            {
                litmess.Text = "No results found";
            }
        }
        //Literal littitle = (Literal)Master.FindControl("littitle");
        //littitle.Visible = false;

    }
    protected void rptrsearch_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lbldesc = (Literal)e.Item.FindControl("lbldesc");
            lbldesc.Text = lbldesc.Text.Replace("<p>&nbsp;</p>", "");
            if (!string.IsNullOrEmpty(lbldesc.Text))
            {
                if (lbldesc.Text.Length >= 500)
                {
                    lbldesc.Text = StripHtml(lbldesc.Text.ToString().Substring(0, 500));
                    lbldesc.Text = Getstring(lbldesc.Text);
                    lbldesc.Text = lbldesc.Text + " ...";
                    // lbldesc.Text = lbldesc.Text + " ...";
                    // lbldesc.Text = lbldesc.Text.Replace("src", "").Replace("images", "");
                }
            }
        }
    }
    public static string StripHtml(string target)
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

    public string replacestring(string str)
    {
        try
        {
            string strnew = str.ToString().TrimStart().TrimEnd().ToLower().Replace(".", "-").Replace(" ", "-").Replace("&", "-").Replace("@", "").Replace("'", "").Replace("/", "").Replace(",-", "").Replace("‘", "").Replace("“", "").Replace("”", "").Replace(":", "").Replace(":", "").Replace("-–-", "-").Replace("%", "").Replace("--", "-").Replace("---", "-").Replace("--", "-");

            return strnew;
        }
        catch (Exception err)
        {
            throw (err);
        }
    }
}