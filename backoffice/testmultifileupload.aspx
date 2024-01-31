<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testmultifileupload.aspx.cs" Inherits="backoffice_testmultifileupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>


     <asp:ScriptManager runat="server" ID="scriptmanager">
    </asp:ScriptManager>

    <ajaxtoolkit:ajaxfileupload width="400px" id="AjaxFileUpload1" runat="server" throbberid="myThrobber"         
        maximumnumberoffiles="10" onuploadcomplete="AjaxFileUpload1_UploadComplete" ></ajaxtoolkit:ajaxfileupload>
       
    </div>
    <hr />
    
    </form>
</body>
</html>
