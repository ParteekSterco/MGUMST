<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"  ValidateRequest="false" Theme="backtheme" AutoEventWireup="true" CodeFile="addcollage.aspx.cs" Inherits="backoffice_collage_addcollage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


 <script type="text/javascript">
     $(function () {
         CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor3.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor4.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor5.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor6.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
     });
</script>

  <h2>Add Colleges/Institutes</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                         
                        </td>
                        <td align="right">
                            &nbsp;<asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            
                            <asp:TextBox ID="cmpgid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="cpgidtrail" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="sprogrampgid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="sdeptpgid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="sfacultypgid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="shapppgid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="sreseachpgid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="False" Checked="true" />
                             <asp:CheckBox ID="showmegamenu" runat="server" Visible="False" Checked="true" />
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
                Fields with <span style="color: #ff0000">*</span> are mandatory
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr style="display:none">
            <td valign="top" width="15%" align="right">
                Campus <span class="star">*</span> : &nbsp;
            </td>
            <td width="85%">
                <asp:DropDownList ID="campusid" runat="server" Width="359px">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
               
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                College Name<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="collagename" runat="server" CssClass="box" MaxLength="100" Width="359px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="collagename"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                College Short Name <span class="star"></span>:&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="displayname" runat="server" CssClass="box" MaxLength="100" Width="359px"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td align="right" valign="top">
                Short Description :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="collageshortdescp" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Description :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="collagedescp" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        
        <tr style="display: none">
            <td align="right" valign="top">
                Infrastructure :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="infrastructure" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right" valign="top">
                Director Message :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="director_mess" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
       
        <tr style="display: none">
            <td align="right" valign="top">
                Admission/Helpline Details :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor6" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="admission" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
         <tr >
            <td align="right" style="width: 15%">
                Cantact Details<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
               <CKEditor:CKEditorControl ID="CKeditor7" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>

                <asp:TextBox ID="campaddress" runat="server" Visible="False"  CssClass="box" 
                    Width="359px"></asp:TextBox>
                   
                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="campaddress"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
               <%-- <asp:RegularExpressionValidator ID="regexpDesc" runat="server" ErrorMessage="Maximum of 500 characters allowed"
                    ControlToValidate="campaddress" Display="Dynamic" ValidationExpression=".{0,500}" />--%>
            </td>
        </tr>
         <tr>
            <td align="right" style="width: 15%">
              Home Page Facts Figures<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
               <CKEditor:CKEditorControl ID="CKeditor8" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>

                <asp:TextBox ID="factfigure" runat="server" Visible="False"  CssClass="box" 
                    Width="359px"></asp:TextBox>
                   
               <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="campaddress"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
               <%--<asp:RegularExpressionValidator ID="regexpDesc" runat="server" ErrorMessage="Maximum of 500 characters allowed"
                    ControlToValidate="campaddress" Display="Dynamic" ValidationExpression=".{0,500}" />--%>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right" valign="top">
                Read more Url<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="readmoreurl" runat="server" Width="359px"></asp:TextBox>
            </td>
        </tr>

         <tr >
            <td align="right" valign="top">
                College Url<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
              <asp:TextBox ID="collegetype" runat="server" Visible="true" Width="359px"></asp:TextBox>
            </td>
        </tr>

         <tr style="display: none">
            <td align="right" valign="top">
                Department Home :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor5" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="placements" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                College Banner<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" contenteditable="false" type="file" />
                <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" CssClass="toptxt"
                    OnClick="LinkButton1_Click">Remove Image</asp:LinkButton>
                <asp:TextBox ID="collage_banner" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image1" runat="server" Height="151px" Visible="false" Width="107px" />
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" valign="top">
                College Logo<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <input id="File2" runat="server" contenteditable="false" type="file" />
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="toptxt" Visible="false" OnClick="LinkButton2_Click">Remove Image</asp:LinkButton>
                <asp:TextBox ID="admissionimg" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image2" runat="server" Height="151px" Visible="false" Width="107px" />
            </td>
        </tr>
        <tr style="display:none">
            <td align="right" valign="top">
                Infra Image<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <input id="File3" runat="server" contenteditable="false" type="file" />
                <asp:LinkButton ID="LinkButton3" runat="server" CssClass="toptxt" Visible="false" OnClick="LinkButton3_Click">Remove Image</asp:LinkButton>
                <asp:TextBox ID="infrastructureimg" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image3" runat="server" Height="151px" Visible="false" Width="107px" />
            </td>
        </tr>
        <tr >
            <td align="right" valign="top">
                 Home Page fact and figure banner<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <input id="File4" runat="server" contenteditable="false" type="file" />
                <asp:LinkButton ID="LinkButton4" runat="server" CssClass="toptxt" Visible="false" OnClick="LinkButton4_Click">Remove Image</asp:LinkButton>
                <asp:TextBox ID="factfigureimg" runat="server" Visible="false"></asp:TextBox>
            </td>
        </tr>
        <tr >
            <td align="right">
            </td>
            <td align="left">
                <asp:Image ID="Image4" runat="server" Height="151px" Visible="false" Width="107px" />
            </td>
        </tr>

        <tr>
            <td align="right" valign="top">
                Display Order<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="50px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <b>SEO SECTION</b>
            </td>
        </tr>
        <tr>
            <td align="right">
                Page Title<span class="star"></span> :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Keywords :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemeta" runat="server" Height="39px" TextMode="MultiLine" Width="500px" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Description :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemetadesc" runat="server" Height="39px" TextMode="MultiLine"
                    Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Page Script :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="other_schema" runat="server" Height="50px" TextMode="MultiLine"
                    Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                <span class="star"></span>Canonical : &nbsp;
            </td>
            <td>
                <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                No Index Follow :
            </td>
            <td align="left" valign="top">
                <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right" valign="top">
                Re-writeurl:&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="rewrite_url" runat="server" Width="222"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />&nbsp;
                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false"
                    OnClick="btncancel_Click" />&nbsp;
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

