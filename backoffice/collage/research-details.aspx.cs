using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualBasic;
using System.Web.UI.HtmlControls;


public partial class backoffice_collage_research_details : System.Web.UI.Page
{
    HttpCookie AUserSession;
    mainclass clsm = new mainclass();
    Hashtable Parameters = new Hashtable();
    protected void Page_Load(object sender, EventArgs e)
    {
        trerror.Visible = false;
        trsuccess.Visible = false;
        trnotice.Visible = false;
        if ((Page.IsPostBack == false))
        {
            collageid.Text = Convert.ToString(Conversion.Val(Request.QueryString["clid"]));

            Parameters.Clear();
            Parameters.Add("@collageid", double.Parse(Request.QueryString["clid"]));
            lblcollage.Text = Convert.ToString(clsm.SendValue_Parameter("SELECT COLLAGENAME FROM COLLAGE_MASTER WHERE COLLAGEID=@COLLAGEID", Parameters));
            CKeditor1.ReadOnly = true;
            Parameters.Clear();
            Parameters.Add("@collageid", Request.QueryString["clid"]);
            clsm.MoveRecord_Parameter(this,mid.Parent, "Select * from map_institute_research_details where collageid=@collageid", Parameters);
            CKeditor1.ReadOnly = false;
            CKeditor1.Text = Server.HtmlDecode(details.Text);

            if (Convert.ToString(Request.QueryString["add"]) == "add")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record added successfully.";
            }
            if (Convert.ToString(Request.QueryString["edit"]) == "edit")
            {
                trsuccess.Visible = true;
                lblsuccess.Text = "Record Updated successfully.";
            }
        
        }
    }

    public void bindata()
    {


        try
        {

          

        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
        
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            details.Text = Server.HtmlEncode(CKeditor1.Text);

            if(string.IsNullOrEmpty(mid.Text))
            {
                CKeditor1.ReadOnly = true;
                string var = clsm.MasterSave(this,mid.Parent,5, mainclass.Mode.modeAdd, "map_institute_research_detailsSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                Response.Redirect("research-details.aspx?clid=" + Convert.ToString(Request.QueryString["clid"]) + "&add=add");
            }
            else
            {
                //Response.Write("aaaaaaaa");

                CKeditor1.ReadOnly = true;
                string var = clsm.MasterSave(this,mid.Parent,5, mainclass.Mode.modeModify, "map_institute_research_detailsSP", Convert.ToString(Session["UserId"]));
                CKeditor1.ReadOnly = false;
                Response.Redirect("research-details.aspx?clid=" + Convert.ToString(Request.QueryString["clid"]) + "&edit=edit");
            }
        }
        catch (Exception ex)
        {
            trerror.Visible = true;
            lblerror.Text = ex.Message.ToString();
        }
        
    }
}