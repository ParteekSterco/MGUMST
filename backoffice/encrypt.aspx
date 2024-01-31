<%@ Page Language="VB" AutoEventWireup="false" CodeFile="encrypt.aspx.vb" Inherits="backoffice_encrypt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    for encrypt
    <asp:TextBox ID="textencrypt" runat="server"></asp:TextBox>
    <asp:Literal ID="litencrypt" runat="server"></asp:Literal>
    <asp:Button ID="btnencrypt" runat="server" Text="Button" />
    <br />
    for decrypt
    <asp:TextBox ID="txtdecrypt" runat="server"></asp:TextBox>
    <asp:Literal ID="litdecrypt" runat="server"></asp:Literal>
    <asp:Button ID="btndecrypt" runat="server" Text="Button" />
    </form>
</body>
</html>
