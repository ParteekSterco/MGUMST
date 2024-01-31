<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"  Theme="backtheme" AutoEventWireup="true" CodeFile="collage-mapdepartments.aspx.cs" Inherits="backoffice_collage_collage_mapdepartments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<h2>Map Departments</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
      
        <tr bgcolor="#6E83BA">
            <td colspan="2">
                <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                    <tr>
                        <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                            padding-left: 10px;" width="30%">
                            <asp:Label ID="lblcollage" runat="server"></asp:Label>
                        </td>
                        <td width="70%" align="right">
                            <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To School</b></a>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       
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
        <tr>
            <td align="center" colspan="2" height="10">
                <asp:TextBox ID="collageid" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%" valign="top">
                Departments <span class="star"></span>:&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DataList ID="dl_sgroup" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="80%" align="left">
                                    <asp:CheckBox ID="checkfeature" runat="server" />
                                     <asp:Label ID="lbldeptid" runat="server" Text='<%#(Eval("deptid"))%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lbldeptname" runat="server" Text='<%#Eval("DeptName")%>' Visible="true"></asp:Label>
                                   
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" TabIndex="15" CssClass="btnbg"
                    ValidationGroup="addnew" OnClick="btnsubmit_Click" />
            </td>
        </tr>
    </table>
    </div>

</asp:Content>

