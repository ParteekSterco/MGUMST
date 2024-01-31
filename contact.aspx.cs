using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            parameters.Clear();
            clsm.Fillcombo_Parameter("select statename,sid from states_master where status=1 order by statename asc", parameters, ddlstate);
            ddlstate.Items[0].Text = "State";

            parameters.Clear();
            clsm.Fillcombo_Parameter("select coursename,courseid from course where status=1 order by coursename asc,displayorder", parameters, ddlcourse);
            ddlcourse.Items[0].Text = "Course";
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
            cmd.CommandText = "enquirysp";

            cmd.Parameters.AddWithValue("@FName", txtname.Text);
            cmd.Parameters.AddWithValue("@Emailid", txtemail.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtmobno.Text);
            cmd.Parameters.AddWithValue("@organizationname", ddlcourse.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@state", ddlstate.SelectedItem.Text);
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