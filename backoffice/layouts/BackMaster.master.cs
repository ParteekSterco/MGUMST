using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;

public partial class backoffice_layouts_BackMaster : System.Web.UI.MasterPage
{
    mainclass clsm = new mainclass();
    Enc_Decyption enc = new Enc_Decyption();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["AUserSession"] == null)
        {
            AUserSession = new HttpCookie("AUserSession");
        }
        else
        {
            AUserSession = Request.Cookies["AUserSession"];
        }

        Session["Trid"] = AUserSession["Trid"];
        Session["UserId"] = AUserSession["UserId"];
        Session["Name"] = AUserSession["Name"];
        Session["Uname"] = AUserSession["Uname"];




        if (Page.IsPostBack == false)
        {
            //************ ip start**********
            string strcheck = Convert.ToString(Request.Url);
            if (strcheck.Contains("http://web") == true || strcheck.Contains("http://wserver") == true)
            {
            }
            else
            {
                string strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
                if (string.IsNullOrEmpty(strip))
                {
                    strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
                }

                Parameters.Clear();
                Parameters.Add("@strip", enc.AES_Encrypt(strip, "@9899848281"));
                if (clsm.Checking_Parameter("select * from ipmaster where status=1 and  ip=@strip", Parameters) == false)
                {
                    //  Response.Write("ok");
                    Response.Redirect("/");
                }
            }



            //************role details **************

            string strrawurl = Convert.ToString(Request.RawUrl);
            strrawurl = strrawurl.Replace("/backoffice/", "");

            string[] arr = strrawurl.Split('?');
            strrawurl = Convert.ToString(arr[0]);

            //Response.Write(strrawurl);
            if (Conversion.Val(AUserSession["Roleid"]) == 1)
            {

            }
            else
            {

                if (strrawurl != "users/homepage.aspx" && strrawurl != "collage/index.aspx")
                {

                    if (Conversion.Val(Request.QueryString["clid"]) > 0)
                    {
                        Parameters.Clear();
                        Parameters.Add("@roleid", Conversion.Val(AUserSession["Roleid"]));
                        Parameters.Add("@collageid", Conversion.Val(Request.QueryString["clid"]));
                        if (clsm.Checking_Parameter("select cm.collageid from RoleMaster r  inner join collage_Management cm on r.roleid=cm.roleid  where cm.status=1  and cm.roleid=@roleid and cm.collageid=@collageid", Parameters) == false)
                        {

                            Response.Redirect("/backoffice/users/homepage.aspx");
                        }
                    }
                    else if (Conversion.Val(Request.QueryString["depbtid"]) > 0)
                    {
                        Parameters.Clear();
                        Parameters.Add("@roleid", Conversion.Val(AUserSession["Roleid"]));
                        Parameters.Add("@depbtid", Conversion.Val(Request.QueryString["depbtid"]));
                        if (clsm.Checking_Parameter("select cm.deptid from RoleMaster r  inner join Department_management cm on r.roleid=cm.roleid  where cm.status=1  and cm.roleid=@roleid and cm.deptid=@depbtid", Parameters) == false)
                        {

                            Response.Redirect("/backoffice/users/homepage.aspx");
                        }
                    }
                    else if (Conversion.Val(Request.QueryString["campusid"]) > 0)
                    {
                        Parameters.Clear();
                        Parameters.Add("@roleid", Conversion.Val(AUserSession["Roleid"]));
                        Parameters.Add("@campusid", Conversion.Val(Request.QueryString["campusid"]));
                        if (clsm.Checking_Parameter("select cm.campusid from RoleMaster r  inner join campusrole_Management cm on r.roleid=cm.roleid  where cm.status=1  and cm.roleid=@roleid and cm.campusid=@campusid", Parameters) == false)
                        {

                            Response.Redirect("/backoffice/users/homepage.aspx");
                        }
                    }
                    else
                    {
                        Parameters.Clear();
                        Parameters.Add("@roleid", Conversion.Val(AUserSession["Roleid"]));
                        Parameters.Add("@Formname", strrawurl);


                        if (clsm.Checking_Parameter("select f.Formname from FormMaster f inner join Role_details r on f.Formid=r.formid inner join RoleMaster rm on r.roleid=rm.roleid  where f.status=1 and r.viewform=1  and rm.rolestatus=1 and r.roleid=@roleid and f.Formname=@Formname", Parameters) == false)
                        {

                             Response.Redirect("/backoffice/users/homepage.aspx");
                        }
                    }





                }

            }

            //************end **************
            //SqlConnection cn = new SqlConnection(clsm.strconnect);
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cn;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "lastupdatelogSP";
            //cmd.Parameters.AddWithValue("@username", Convert.ToString(Session["Trid"]));
            //cn.Open();
            //cmd.ExecuteNonQuery();
            //cn.Close();

            lbldatetime.Text = DateTime.Today.ToString("dddd,MMMM dd,yyyy");
            Label1.Text = Convert.ToString(Session["Name"]);
            if (Session["UserId"] == null || Session["UserId"] == "")
            {
                Response.Redirect("~/backoffice/default.aspx");
            }
        }
        else
        {

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/backoffice/logout.aspx");

    }
    protected void LinkButton2_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("~/backoffice/users/homepage.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/backoffice/users/homepage.aspx");
    }
}
