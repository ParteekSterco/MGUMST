<%@ Page Title="" Language="VB" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" AutoEventWireup="false" CodeFile="addfaq.aspx.vb" Inherits="backoffice_faq_addfaq" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../../App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
   
  <h2> Add Faq</h2>
<div class="content-panel">

    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
      
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
                Fields with <span style="color: #ff0000">*</span> are mandatory
                <asp:TextBox ID="cid" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="faqid" runat="server" Visible="false"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
       
       
        <tr>
            <td valign="top" align="right">
                Question<span class="star">*</span> : &nbsp;
            </td>
            <td>
                <asp:TextBox ID="question" runat="server" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="question"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
       
       
       
     
        <tr>
            <td valign="top" align="right">
                Answer: &nbsp;
            </td>
            <td>
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="description" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td valign="top" align="right">
                Displayorder<span class="star"></span> : &nbsp;
            </td>
            <td>
                <asp:TextBox ID="displayorder" runat="server" Width="50px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                <asp:CheckBox ID="status" runat="server" Checked="True" Visible="false" />
            </td>
        </tr>
        
        <tr>
            <td valign="top">
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False" />
            </td>
        </tr>
        <%--   </table>
            </td>
        </tr>--%>
    </table>
    </div>
</asp:Content>

