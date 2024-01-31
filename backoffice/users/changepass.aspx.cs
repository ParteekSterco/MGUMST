using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public partial class backoffice_users_changepass : System.Web.UI.Page
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Hashtable parameters = new Hashtable();
    Enc_Decyption enc = new Enc_Decyption();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Label2.Text=Session["UserId"].ToString();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        try
        {
            Label1.Visible = false;
            oldpassword.Text = oldpassword.Text.Replace("'", "");
            oldpassword.Text = oldpassword.Text.Replace(";", "");
            oldpassword.Text = oldpassword.Text.Replace("=", "");
            oldpassword.Text = oldpassword.Text.Replace("drop", "");

            Newpass.Text = Newpass.Text.Replace("'", "");
            Newpass.Text = Newpass.Text.Replace(";", "");
            Newpass.Text = Newpass.Text.Replace("=", "");
            Newpass.Text = Newpass.Text.Replace("drop", "");

            if (Page.IsValid)
            {
                
                string Upwd = null;
                parameters.Clear();
                parameters.Add("Userid", Session["UserId"]);
                Upwd = clsm.SendValue_SP("select_userpassword", parameters).ToString();
                string dbpwd = enc.AES_Decrypt(Upwd, "@9899848281");
                if (dbpwd == oldpassword.Text.Trim())
                {
                    parameters.Clear();
                    clsm.ExecuteQry_Parameter("Update BOUserMaster set Userpassword='" + enc.AES_Encrypt(Newpass.Text, "@9899848281") + "' where Userid='" + Session["UserId"] + "'", parameters);
                    Label1.Visible = true;
                    Label1.Text = "Password Changed Successfully.";

                    clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Password", Convert.ToString(enc.AES_Encrypt(oldpassword.Text, "@9899848281")), Convert.ToString(Convert.ToString(Session["Trid"])), Convert.ToString("Change Password"), Convert.ToString("0"), Convert.ToString(enc.AES_Encrypt(Newpass.Text, "@9899848281")));
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Invalid Old Password.";
                    return;
                }
            }
        }
        catch (Exception er)
        {
            Label1.Visible = true;
            Label1.Text = er.Message.ToString();
        }


    }
}
