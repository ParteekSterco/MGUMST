<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mapresearch.aspx.cs"  Inherits="backoffice_faculty_mapresearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .mapping table tr td table tr td table tr td
        {
            padding-right: 5px;
            padding-left: 5px;
        }
        
        .mapping table tr td table tr td table tr td.faculty-name
        {
          width:auto !important;
        }
        .mapping table tr td table tr td table tr td.display-name
        {
            padding-left: 30px;
            padding-left: 15px;
        }
        .mapping table tr td
        {
            padding-bottom: 0;
        }
    </style>


</head>
<body style="background-color: lavender">
    <form id="form1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <%-- <tr>
            <td colspan="2" align="center" class="head1">
                <img id="image" runat="server" width="110" height="110" style="display: none" />
                <h3>
                    Map Research
                </h3>
                <b></b>
            </td>
        </tr>--%>
        <tr>
            <td class="headingtext" colspan="2">
                <div class="error" align="left" id="trerror" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </div>
                <div class="success" align="left" id="trsuccess" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                </div>
                <div class="notice" align="left" id="trnotice" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblnotice" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        <br />
        <tr>
            <td align="center">
                <table border="0" cellpadding="2" cellspacing="2" width="90%">
                   
                    <tr>
                        <td colspan="2" align="center" width="100%">
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Map Research" CssClass="mapping"
                                Width="100%">
                                <table id="Table3" border="0" cellpadding="2" cellspacing="0" width="100%">
                                    <tr width="100%">
                                        <td align="left" colspan="2">
                                            <asp:DataList ID="researchlist" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                                <ItemTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                                <asp:CheckBox ID="checkfeature" runat="server" />
                                                            </td>
                                                            <td class="faculty-name">
                                                                <asp:Label ID="lblEventsTitle" runat="server" Text='<%#Eval("researchTitle")%>' Visible="true"></asp:Label>
                                                                <asp:Label ID="lblEventsid" runat="server" Text='<%#Eval("researchid")%>' Visible="false"></asp:Label>
                                                            </td>
                                                            <td class="display-name">
                                                                Display Order:
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtdisplayorder" runat="server" Width="70px"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                                                    ControlToValidate="txtdisplayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                                                                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                                <ItemStyle Width="25%" />
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                        </td>
                        <td align="center">
                            <asp:Button ID="Button1" Visible="false" runat="server" Text="Submit" TabIndex="15"
                                class="btnbg" ValidationGroup="addnew" OnClick="Button1_Click" />
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
