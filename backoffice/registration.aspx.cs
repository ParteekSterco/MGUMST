using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;

using System.Collections;

public partial class backoffice_registration : System.Web.UI.Page
{
    public int appno;
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if (!IsPostBack)
        {
            Search();
        }
    }

    private void Search()
    {
        try
        {
            string Strsql = "SELECT applyid,name,fathername,dob,mobile, email,address , district ,state ,payment,uname,mode,regisnum,Paytmordernumber,paymenttype,event as eventid,(select eventsname from Eventsdetails e where r.applyid=e.applyid) as event  FROM resitration r ";
            Parameters.Clear();

            if (!string.IsNullOrEmpty(name.Text))
            {
                Parameters.Add("@name", name.Text);
                Strsql += " where name =@name";
            }
            if (!string.IsNullOrEmpty(email.Text))
            {
                Parameters.Add("@email", email.Text);


                if (!string.IsNullOrEmpty(name.Text))
                {
                    Strsql += " and email=@email";
                }
                else
                {
                    Strsql += " where email=@email";
                }


                
            }

            Strsql = Strsql + " order by name desc";

            clsm.GridviewData_Parameter(GridView1, Strsql, Parameters);
            if (GridView1.Rows.Count == 0)
            {
                trnotice.Visible = true;
                lblnotice.Text = "No Records Found.";
            }
            appno = GridView1.Rows.Count;
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {


        Search();


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Label1.Visible = false;
        if (e.CommandName == "btndel")
        {
            Parameters.Clear();
            Parameters.Add("@applyid", Convert.ToInt32(e.CommandArgument));
            clsm.ExecuteQry_Parameter("delete from resitration where applyid=@applyid", Parameters);
           
            Search();
            trsuccess.Visible = true;
            lblsuccess.Text = "Record Deleted Successfully !!!";
        }
    }
}