using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class index : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            binddata();
        }
    }
    private void binddata()
    {
        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(81));
        litJournal.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(23));
        litlifemgmust.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(2));
        litabout.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(146));
        litForeignCollab.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(33));
        litexplorecollage.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and pagestatus=1", parameters)));

        parameters.Clear();
        parameters.Add("@pageid", Conversion.Val(132));
        gallerytitle.Text = (Convert.ToString(clsm.SendValue_Parameter("select tagline from pagemaster where pageid=@pageid and pagestatus=1", parameters)));



        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptevents, "select top 1 eventsid,eventstitle,eventsdate,ntypeid,shortdesc,uploadevents from events where ntypeid=2 and status=1 and showonhome=1 order by eventsdate desc", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptnews, "select top 4 eventsid,eventstitle,eventsdate,ntypeid,shortdesc,uploadevents from events where ntypeid=1 and status=1 and showonhome=1 order by eventsdate desc", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptgallery, "select top 3 albumid,albumtitle,albumdesc,typeid,uploadaimage,albumdate from album where status=1 and showonmainsite=1 order by albumdate desc,displayorder", parameters);

        parameters.Clear();
        clsm.repeaterDatashow_Parameter(rptcourselevel, "select levelid,levelname,code from courselevel_master where status=1 order by displayorder", parameters);

        bindnotification();

    }

    private void bindnotification()
    {
        string sql = "select top 3 eventsid,eventstitle,eventsdate,ntypeid,shortdesc,uploadfile from events where ntypeid=5 and status=1 and showonhome=1 order by eventsdate desc";

        bool strmultiple = Convert.ToBoolean(clsm.SendValue_Parameter("select chklist from newstype where status=1 and ntypeid=5", parameters));
        parameters.Clear();
        if (strmultiple == false)
        {
            panelnotification.Visible = true;
            clsm.repeaterDatashow_Parameter(rptnotification, sql, parameters);
        }
        else
        {
            clsm.repeaterDatashow_Parameter(rptmultiple, sql, parameters);
            notification_multiple.Visible = true;
        }        
    }

    #region Searching
    protected void course_click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(coursesearch.Text))
        {
            parameters.Clear();
            parameters.Add("@coursename", coursesearch.Text.Trim());
            string sql = "select distinct c.coursename,c.courseid,cm.collegetype,cm.cmpgid,cm.cpgidtrail,cm.collageid from course c left join collage_master cm on  c.collageid=cm.collageid  where 1=1 and c.coursename like '%'+@coursename+'%'  ";
            DataSet ds = clsm.senddataset_Parameter(sql, parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {

                string courseid = Convert.ToString(ds.Tables[0].Rows[0]["courseid"]);
                string collegetype = Convert.ToString(ds.Tables[0].Rows[0]["collegetype"]);
                string cmpgid = Convert.ToString(ds.Tables[0].Rows[0]["cmpgid"]);
                string cpgidtrail = Convert.ToString(ds.Tables[0].Rows[0]["cpgidtrail"]);
                string collageid = Convert.ToString(ds.Tables[0].Rows[0]["collageid"]);

                string qry = "/coursedetail.aspx?mpgid=126&pgidtrail=126&courseid=" + Conversion.Val(courseid);
                Response.Redirect(qry);
            }

        }
    }

    [WebMethod]
    public static string GetGraduateCourse(string prefixText)
    {

        mainclass clsm = new mainclass();
        Hashtable parameters = new Hashtable();
        parameters.Clear();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "searchcourseSP";
        cmd.Parameters.AddWithValue("@coursename", Convert.ToString(prefixText));
        cmd.Parameters.AddWithValue("@levelid", 0);
        return GetData(cmd).GetXml();
    }
    private static DataSet GetData(SqlCommand cmd)
    {
        mainclass clsm = new mainclass();
        string strconnect = clsm.strconnect;
        using (SqlConnection con = new SqlConnection(strconnect))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = con;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "Customers");
                    return ds;
                }
            }
        }
    }

    #endregion

    protected void rptnotification_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
        
        }
    }
    protected void rptevents_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/eventsdetail.aspx?mpgid=131&pgidtrail=131&eventsid=" + Conversion.Val(liteventsid.Text);

        }
    }
    protected void rptnews_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal liteventsid = (Literal)e.Item.FindControl("liteventsid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/newsdetail.aspx?mpgid=130&pgidtrail=130&eventsid=" + Conversion.Val(liteventsid.Text);

        }
    }

    protected void rptgallery_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litalbumid = (Literal)e.Item.FindControl("litalbumid");
            Literal littypeid = (Literal)e.Item.FindControl("littypeid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");
            HtmlAnchor a1 = (HtmlAnchor)e.Item.FindControl("a1");
            Literal litalbumtitle = (Literal)e.Item.FindControl("litalbumtitle");

            if (Conversion.Val(littypeid.Text) == 2)
            {
                ank.Visible = true;
            }

            a1.HRef = "/gallery-detail/" + clsm.replacestring(litalbumtitle.Text) + "/" + Conversion.Val(litalbumid.Text);

        }
    }
    protected void rptcourselevel_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item | e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal litlevelid = (Literal)e.Item.FindControl("litlevelid");
            HtmlAnchor ank = (HtmlAnchor)e.Item.FindControl("ank");

            ank.HRef = "/course-list.aspx?mpgid=126&pgidtrail=126&levelid=" + Conversion.Val(litlevelid.Text);

        }
    }

}