<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="downloadfile.aspx.cs"
    Inherits="backoffice_downloadfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>SIAM India</title>
    <!-- Core CSS - Include with every page -->
    <link href="/backoffice/admincss/bootstrap.css" rel="stylesheet">
    <link href="/font-awesome/css/font-awesome.css" rel="stylesheet">
    <link href="/backoffice/admincss/plugins/dataTables/dataTables.bootstrap.css" rel="stylesheet">
    <!-- SB Admin CSS - Include with every page -->
    <link href="/backoffice/admincss/sb-admin.css" rel="stylesheet">
    <!-- Page-Level Plugin CSS - Dashboard -->
</head>
<body style="padding-top: 0px; overflow-x: hidden;">
    <form id="form1" runat="server">
    <div id="wrapper">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        download
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <table id="trpanel" runat="server" border="0" cellpadding="2" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <div class="alert alert-success" align="left" id="trsuccess" runat="server">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                                    </div>
                                    <div class="alert alert-warning" align="left" id="trnotice" runat="server">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblnotice" runat="server"></asp:Label>
                                    </div>
                                    <div class="alert alert-danger" align="left" id="trerror" runat="server">
                                        &nbsp;&nbsp;
                                        <asp:Label ID="lblerror" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
