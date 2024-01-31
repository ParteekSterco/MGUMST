<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        string strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
        if (string.IsNullOrEmpty(strip))
        {
            strip = Convert.ToString(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
        }

        Exception ex = Server.GetLastError().GetBaseException();
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("IP: {0}", strip);
        message += Environment.NewLine;
        message += string.Format("URL: {0}", Convert.ToString(Request.Url));
        message += Environment.NewLine;
        message += string.Format("Message: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        string path = Server.MapPath("~/Uploads/Files/ErrorLog.txt");
        using (var writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }


    }
    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.


    }


    protected void Application_BeginRequest(object sender, System.EventArgs e)
    {
       string requestUrl = Request.ServerVariables["REQUEST_URI"];
       string rewriteUrl = Request.ServerVariables["UNENCODED_URL"];

       rewriteUrl = rewriteUrl.Replace("http://","");
       rewriteUrl = rewriteUrl.Replace("https://", "");
       if (rewriteUrl.Contains("//") && !requestUrl.Contains("//"))
       {
          
         Response.RedirectPermanent(requestUrl);
       }
      

        string strurl = string.Empty;
        strurl = Request.RawUrl;
        if (!string.IsNullOrEmpty(strurl))
        {
            if (strurl.ToLower().Contains("script") || strurl.ToLower().Contains("<script") || strurl.ToLower().Contains("alert(") || strurl.ToLower().Contains("javascript") || strurl.ToLower().Contains("<script>") || strurl.ToLower().Contains("text/javascript") || strurl.ToLower().Contains("<") || strurl.ToLower().Contains(">") || strurl.ToLower().Contains("<div") || strurl.ToLower().Contains("<a") || strurl.ToLower().Contains("href=") || strurl.ToLower().Contains("onblur=") || strurl.ToLower().Contains("%22") || strurl.ToLower().Contains("%3E") || strurl.ToLower().Contains("%3C"))
            {


                //string newUrlred = "/404.aspx";
                //Response.Status = "301 Moved Permanently";

                // Response.AddHeader("Location", newUrlred);
            }
        }

        string strrawredirecturl = string.Empty;
        strrawredirecturl = Request.RawUrl;

        if (!string.IsNullOrEmpty(strrawredirecturl))
        {
            strrawredirecturl = strrawredirecturl.TrimStart('/');
            if (!string.IsNullOrEmpty(strrawredirecturl))
            {
                Hashtable parameters = new Hashtable();
                mainclass clsm = new mainclass();
                parameters.Add("@redirectFrom", strrawredirecturl);
                string strdbvalue = Convert.ToString(clsm.SendValue_Parameter("select redirectTo from  redirectmanagement where status=1 and redirectFrom=@redirectFrom", parameters));

                if (!string.IsNullOrEmpty(strdbvalue))
                {
                    if (strdbvalue.Contains("http") == true || strdbvalue.Contains("https") == true)
                    {
                        string newUrl = strdbvalue;
                        Response.Status = "301 Moved Permanently";
                        Response.AddHeader("Location", newUrl);
                    }
                    else
                    {
                        //Response.Write(strdbvalue);
                        string newUrl = "/" + strdbvalue;
                        Response.Status = "301 Moved Permanently";
                        Response.AddHeader("Location", newUrl);
                    }

                }
            }
        }
    }
       
</script>
