<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="uploadfiles.aspx.cs" Inherits="backoffice_download_uploadfiles" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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

<h2>Upload File</h2>
<div class="content-panel">
 <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td class="head1" colspan="2">
                <asp:TextBox ID="Fileid" runat="server" Visible="False" Width="33px"></asp:TextBox>
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
                Fields with <span class="star">*</span>are mandatory</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Upload Type<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="UTId" runat="server" CssClass="box"  Width="359px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UTId"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Title<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="FileTitle" runat="server" CssClass="box"  TabIndex="3"
                    Width="359px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileTitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td align="right" style="width: 15%">
                Admission Brochures(Year)<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="years" runat="server"  Width="359px">

                <asp:ListItem Value="0">Select Year</asp:ListItem>
                <asp:ListItem Value="2020">2020</asp:ListItem>
                <asp:ListItem Value="2021">2021</asp:ListItem>
                <asp:ListItem Value="2022">2022</asp:ListItem>
                <asp:ListItem Value="2023">2023</asp:ListItem>
                <asp:ListItem Value="2024">2024</asp:ListItem>
                <asp:ListItem Value="2025">2025</asp:ListItem>
                </asp:DropDownList>
            
               
                    
                    </td>
        </tr>

          <tr>
                        <td valign="top" align="right">
                            Detail : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="detail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                    </tr>

        <tr  >
            <td align="right">
                Upload File<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <input id="File1" runat="server" class="box" contenteditable="false" type="file" />
                            
                            <asp:TextBox    ID="UploadFile" runat="server" Visible="False" Width="122px"></asp:TextBox></td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton1" runat="server" Visible="False" CssClass="toptxt" OnClick="LinkButton1_Click">Remove File</asp:LinkButton></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display:none" >
            <td align="right">
                Upload Image:</td>
            <td align="left">
                <input id="File2" runat="server" class="box" contenteditable="false" onchange="showpreview(this);" type="file" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="uploadimage" runat="server" Visible="False" Width="122px"></asp:TextBox>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toptxt" Visible="False" OnClick="LinkButton2_Click">Remove Image</asp:LinkButton></td>
        </tr>
        <tr style="display:none" >
            <td align="right" >
            </td>
            <td align="left" >
             <img id="imgpreview" height="100" width="100" src="" style="display:none;" />
                <asp:Image ID="Image1" runat="server" Width="100" Height="100" Visible="false"  /></td>
        </tr>
        <tr>
            <td align="right">Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="50px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Status :&nbsp;
            </td>
            <td align="left">
                <asp:CheckBox ID="status" runat="server" Checked="True" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" TabIndex="15" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                    TabIndex="16" OnClick="btnCancel_Click" /></td>
        </tr>
    </table>
    </div>
</asp:Content>

