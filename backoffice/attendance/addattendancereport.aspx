<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true" CodeFile="addattendancereport.aspx.cs" Inherits="backoffice_attendance_addattendancereport" Theme="backtheme" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=attendancedate.ClientID%>'));


        };
    </script>
    
    <h2>
        Add Attendance Report</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2" class="head1">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="h_dot_line">
                    &nbsp;
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
                <td align="right" colspan="2">
                    <asp:CheckBox ID="status" runat="server" Visible="False" Checked="True" />
                    <asp:TextBox ID="atid" runat="server" Visible="False" Width="33px"></asp:TextBox>Fields
                    with <span class="star">*</span>are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            
           
            <tr>
                <td align="right" valign="top">
                    Attendance Date <span class="star">*</span>:&nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="attendancedate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="attendancedate"
                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="validattandance"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="attendancedate"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format" ValidationGroup="validattandance"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td align="right">
                    Upload Attendance File<span class="star">*</span> :&nbsp;
                </td>
                <td align="left" colspan="3">
                    <input id="File2" runat="server" class="box" contenteditable="false" type="file" />
                    &nbsp;<asp:Label ID="Label5" runat="server" Text="(Upload Only XLS file)"
                        ForeColor="red" Font-Italic="true"></asp:Label>
                    <asp:TextBox ID="uploadfile" runat="server" Visible="False"></asp:TextBox>
                    <asp:LinkButton ID="lnkremovefile" runat="server" CausesValidation="false" Visible="false"
                        OnClick="lnkremovefile_Click">Remove File</asp:LinkButton>
                </td>
                
            </tr>

            <tr>
                <td align="right">
                   
                </td>
                 <td align="left" colspan="2">
                    &nbsp;<asp:LinkButton ID="lnkdownload" runat="server" OnClick="lnkdownload_Click"
                        Visible="true"><b> Download Sample file( For Wserver)</b></asp:LinkButton>

                        <asp:LinkButton ID="lnkdownlive" runat="server" OnClick="lnkdownlive_Click"
                        Visible="true"><b> Download Sample file( For live server)</b></asp:LinkButton>
                </td>
            </tr>

            <tr style="display:none">
                <td align="right">
                    Display Order :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="displayorder" runat="server" Width="50px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                        ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                        ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                </td>
            </tr>
            


            <tr>
                <td height="10">
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="validattandance"/>
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            
        </table>
    </div>
</asp:Content>
