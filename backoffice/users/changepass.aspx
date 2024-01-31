<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true"
    CodeFile="changepass.aspx.cs" Inherits="backoffice_users_changepass" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<h2>Change Password</h2>
<div class="content-panel">
    <table border="0" cellpadding="2" cellspacing="0" width="100%" id="TABLE1">
        <tr>
            <td align="left" class="head1" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="h_dot_line">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" SkinID="redtext" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="right" class="txt1">
            </td>
            <td align="center">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
            </td>
        </tr>
        <tr>
            <td align="left" class="txt1" colspan="2">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnsubmit">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%" id="Table2">
                        <tr>
                            <td align="right" class="txt1">
                                User Id :&nbsp;</td>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="txt1">
                                Old Password<span class="star">*</span> :&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="oldpassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="oldpassword"
                                    Display="None" ErrorMessage="Old Password Required"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td align="right" class="txt1">
                                New Password<span class="star">*</span> :&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="Newpass" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Newpass"
                                    Display="None" ErrorMessage="New Password Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="Newpass" Display="None"
                                        ErrorMessage="Password must be between 8 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character." ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$"></asp:RegularExpressionValidator></td>
                        </tr>
                        <tr>
                            <td align="right" class="txt1">
                                Confirm Password<span class="star">*</span> :&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="confirmpass" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="confirmpass"
                                    Display="None" ErrorMessage="Confirm Password Required"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Newpass"
                                    ControlToValidate="confirmpass" Display="None" ErrorMessage="Confirm Password should be same as New Password"></asp:CompareValidator></td>
                        </tr>
                        <tr>
                            <td align="right" class="txt1" style="height: 20px">
                            </td>
                            <td align="left" style="height: 20px">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 21px">
                                &nbsp;</td>
                            <td align="left" style="height: 21px">
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Change" OnClick="btnsubmit_Click" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
