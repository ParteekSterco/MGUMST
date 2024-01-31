<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true" CodeFile="add_hostel_fee.aspx.cs" Inherits="backoffice_Fee_add_hostel_fee" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">




<script type="text/javascript">
    $(function () {
        CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
    });
</script>
 <h2>Add Hostel fee</h2>
<div class="content-panel">
 <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>

                        <td align="right">
                            &nbsp;
                            <asp:TextBox ID="cfid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="false" Checked="true" Width="122px"></asp:CheckBox>
                            &nbsp;&nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
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
                Fields with <span style="color: #ff0000">*</span> are mandatory</td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>

        
        <tr>
            <td align="right" style="width: 15%">
                Title <span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="title" runat="server" CssClass="box"  TabIndex="3"
                    Width="359px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="title"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
            
       


      
         <tr style="display:none" >
            <td align="right" valign="top">
                Short Desc.:&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" BasePath="~/ckeditor/" Height="200px"
                    Width="100%">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="shortdesc" runat="server" Visible="False" Width="122px"></asp:TextBox></td>
        </tr>
        <tr >
            <td align="right" valign="top">
                 Desc. :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" BasePath="~/ckeditor/" Height="350px"
                    Width="90%">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="details" runat="server" Visible="False" Width="122px"></asp:TextBox></td>
        </tr>
        
       
        <tr style="display:none">
            <td align="right" style="width: 15%">
                Upload Small Image :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <input id="File1" runat="server" class="box" contenteditable="false" type="file" />
                <asp:TextBox ID="Uploadphoto" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="359px" Visible="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" style="width: 15%">
            </td>
            <td align="left" style="width: 85%">
                <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" Visible="false" />
            </td>
        </tr>
         
        <tr>
            <td align="right">
                Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="39px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator></td>
        </tr>
          <tr style="display:none">
            <td class="head1" colspan="2" style="font-size: small;" nowrap>
                SEO Information
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
                Page Title :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" valign="top">
                Meta Keywords :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="500px" />
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" valign="top">
                Meta Description :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
                    Width="500px"></asp:TextBox>
            </td>
        </tr>



         <tr style="display:none">
             <td valign="top" align="right">
                 <span class="star"></span>Canonical : &nbsp;
             </td>
             <td>
                 <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
             </td>
         </tr>
         <tr style="display:none">
             <td align="right" valign="top">
                 No Index Follow :
             </td>
             <td align="left" valign="top">
                 <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
             </td>
         </tr>

        
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td align="right">
                
            </td>
            <td align="left">
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" 
                    onclick="btnsubmit_Click" />&nbsp;
              

        </tr>
    </table>

    </div>




</asp:Content>

