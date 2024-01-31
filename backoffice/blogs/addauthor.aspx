<%@ Page Title="" Language="VB" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="false" CodeFile="addauthor.aspx.vb" Inherits="backoffice_Blogs_addauthor" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <%--<script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=catdate.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=catenddate.ClientID%>'));
        };
    </script>--%>
    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {
                document.getElementById("imgpreview").style.display = 'inline';
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    
<h2>Add/Edit Author</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2" class="head1">
                
                <asp:TextBox ID="AutId" runat="server" Visible="False" Width="33px"></asp:TextBox>
                <asp:CheckBox ID="status" Checked="true" runat="server" Visible="false" />
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
                Fields with <span class="star">*</span>are mandatory
            </td>
        </tr>
       
        <tr>
            <td align="right" style="width: 15%">
                Author Name<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="AutName" runat="server" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="AutName"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>

         <tr style="display:none;">
            <td align="right" style="width: 15%">
                Title<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="Auttitle" runat="server" Width="350px"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Auttitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
       


        <tr>
            <td align="right" style="width: 15%">
                Designation<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="Autdesignation" runat="server" Width="350px"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Autdesignation"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
       


        <tr style="display:none;">
            <td align="right">
                Author Image :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" contenteditable="false" type="file" onchange="showpreview(this);"
                    class="box" />
                <asp:TextBox ID="AutImage" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none;">
            <td align="right">
            </td>
            <td align="left">
                <img id="imgpreview" height="100" width="100" src="" style="display: none;" />
                <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="toptxt" Visible="False">Remove Banner</asp:LinkButton>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" valign="top">
                Description :&nbsp;
                <br />
                <span style="font-style: italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="smalldesc" runat="server" Visible="False"></asp:TextBox>
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td align="right">
                Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="33px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
       
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False" />
            </td>
        </tr>
        
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

