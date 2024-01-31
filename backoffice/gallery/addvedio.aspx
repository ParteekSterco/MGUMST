<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="addvedio.aspx.cs" Inherits="backoffice_gallery_addvedio" Theme="backtheme" %>

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
 <h2>  Add/Edit Video</h2>
    <div class="content-panel">
<table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2" class="head1">
               <asp:TextBox ID="vedioid" runat="server" Visible="False"
                    Width="33px"></asp:TextBox>
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
            <td align="center" colspan="2" height="10">
            </td>
        </tr>

             <tr >
            <td align="right">
               Album<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
            <asp:DropDownList ID="Albumid" runat="server" Width="359px"></asp:DropDownList>
                
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Albumid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%></td>
        </tr>

        <tr>
            <td align="right">
                Video Title<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="vediotitle" runat="server" Width="359px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="vediotitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
         <tr  style="display:none">
            <td align="right">
               Tagline<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="tagline" runat="server" Width="359px"></asp:TextBox>
              </td>
        </tr>
        <tr style="display:none;">
            <td align="right" valign="top">
                Select page To display :&nbsp;
            </td>
            <td align="left" valign="top">
            <asp:DropDownList ID="galpageid" runat="server">
            </asp:DropDownList>
               </td>
        </tr>
        <tr>
            <td align="right">
                Thumbnail Image<span class="star">*</span> :&nbsp;
            </td>
            <td align="left">
                <input id="File2" runat="server" style="width:359px" contenteditable="false" type="file" onchange="showpreview(this);" class="box" />
                <asp:TextBox ID="thumbnailimage" runat="server" Width="200px" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:Label ID="Label1" runat="server" Text="(Image should be of size : 288x209px)"  ForeColor="red" Font-Italic="true">
               </asp:Label>
                 <asp:LinkButton ID="LinkButton2" runat="server" Visible="False" 
                    CausesValidation="False" onclick="LinkButton2_Click">Remove Thumbnail</asp:LinkButton></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
            </td>
            <td align="left" style="width: 85%">
             <img id="imgpreview" height="100" width="100" src="" style="display:none;" />
                <asp:Image ID="Image2" runat="server" Visible="False" Width="100" Height="100" />
                </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Upload Youtube Url :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="uploadvedio" runat="server" Width="359px"></asp:TextBox>
                 <%--<CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>--%>
                </td>
        </tr>
        <tr>
            <td align="right">Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="44px"></asp:TextBox>
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
                <asp:CheckBox ID="status" runat="server" Checked="True" />
                <asp:CheckBox ID="showhome" runat="server" Visible="false" />
                </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" 
                    onclick="btnSubmit_Click" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" 
                    CausesValidation="False" onclick="btnCancel_Click" /></td>
        </tr>
    </table>
    </div>
</asp:Content>

