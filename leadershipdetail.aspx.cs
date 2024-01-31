using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leadershipdetail : System.Web.UI.Page
{
    Hashtable parameters = new Hashtable();
    mainclass clsm = new mainclass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Conversion.Val(Request.QueryString["lid"]) > 0)
            {
                parameters.Clear();
                parameters.Add("@lid", Conversion.Val(Request.QueryString["lid"]));
                clsm.repeaterDatashow_Parameter(rptdetail, "select teamid,ttypeid,name,qualification,industries,Uploadphoto,designation,detaildesc from ourteam where status=1 and teamid=@lid order by displayorder", parameters);
            }
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Literal littitlename = (Literal)Master.FindControl("littitle");

        parameters.Clear();
        parameters.Add("@lid", Conversion.Val(Request.QueryString["lid"]));
        littitlename.Text = Convert.ToString(clsm.SendValue_Parameter("select designation from ourteam where status=1 and teamid=@lid", parameters));
    }
}