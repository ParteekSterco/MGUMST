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

public partial class hostel_facilities : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter("select levelname,levelid from courselevel_master where status=1 order by displayorder", parameters, ddlprogram);
            ddlprogram.Items[0].Text = "Select Program";

            parameters.Clear();
            parameters.Add("@pageid", Conversion.Val(Request.QueryString["pgidtrail"]));
            litsmalldesc.Text = Server.HtmlDecode(Convert.ToString(clsm.SendValue_Parameter("select smalldesc from pagemaster where pageid=@pageid and pagestatus=1", parameters)));
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string var = string.Empty;
        string ID = string.Empty;
        try
        {
            SqlConnection cn = new SqlConnection(clsm.strconnect);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "enquiry_facilitiessp";

            cmd.Parameters.AddWithValue("@FName", txtname.Text);
            cmd.Parameters.AddWithValue("@Emailid", txtemail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtmobno.Text);
            cmd.Parameters.AddWithValue("@year", txtyear.Text);
            cmd.Parameters.AddWithValue("@collage", txtcollage.Text);
            cmd.Parameters.AddWithValue("@program", ddlprogram.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@fmessage", txtdesc.Text);
            cmd.Parameters.AddWithValue("@doc_type", "hostel facility");
            cmd.Parameters.AddWithValue("@uname", "user");
            cmd.Parameters.AddWithValue("@mode", 1);
            cmd.Parameters.Add("@eid", SqlDbType.Int, 0, "@eid").Direction = ParameterDirection.Output;
            cn.Open();
            cmd.ExecuteNonQuery();

            ID = cmd.Parameters["@eid"].Value.ToString();
            cn.Close();
            var = ID;

            Response.Redirect("~/thankyou.aspx?mpgid=124&pgidtrail=124&msg=thankyou");
        }
        catch (Exception ex)
        {
        }
    }
}