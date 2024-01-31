using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_thankyou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Request.QueryString["msg"] == "thankyou")
            {
                lblsuccess1.Text = "Thank you !";
                lblsuccess.Text = "Your Enquiry has been successfully submitted. <br>Our representative will contact you soon.<br><br>";
            }

           

        }
    }
}