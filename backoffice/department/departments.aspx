<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"
    Theme="backtheme" AutoEventWireup="true" CodeFile="departments.aspx.cs" ValidateRequest="false"
    Inherits="backoffice_department_departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor3.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor4.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });

        });
    </script>
    <h2>
        Add Departments</h2>
    <div class="content-panel">
        <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
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
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <table id="Table2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">

                    <tr style="display:none">
                            <td valign="top" align="right">
                                <span class="star"></span>Campus<span class="star">*</span> : &nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="campusid" runat="server" Width="350px">
                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>
                        </tr>

                        <tr>
                            <td valign="top" align="right">
                                <span class="star"></span>College<span class="star">*</span> : &nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="schoolid" runat="server" Width="350px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="schoolid"
                                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Department Name<span class="star">*</span> :&nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:TextBox ID="deptname" CssClass="box" runat="server" Width="350px"></asp:TextBox>
                                <asp:TextBox ID="deptid" runat="server" Visible="False" Width="23px"></asp:TextBox>

                                <asp:TextBox ID="sprogrampgid" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                <asp:TextBox ID="sdeptpgid" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                <asp:TextBox ID="sfacultypgid" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                <asp:TextBox ID="shapppgid" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                <asp:TextBox ID="sreseachpgid" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                 <asp:TextBox ID="stestimonial" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                 <asp:TextBox ID="deptfolder" runat="server" Visible="False" Width="23px"></asp:TextBox>
                                 <asp:TextBox ID="shapppgidevent" runat="server" Visible="False" Width="23px"></asp:TextBox>

                                <asp:TextBox ID="rewriteurl" CssClass="box" runat="server" Width="330" Visible="False"></asp:TextBox>
                                <asp:TextBox ID="rewriteurl_sec" CssClass="box" runat="server" Width="330" Visible="False"></asp:TextBox>
                                <asp:CheckBox ID="status" runat="server" Visible="False" Checked="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="deptname"
                                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="display:none">
                            <td align="right" width="16%">
                                Department Short Name<span class="star"></span> :&nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:TextBox ID="displayname" CssClass="box" runat="server" Width="350px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%" valign="top">
                                Short Description : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="120" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="departmentshortdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%" valign="top">
                                Description : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="departmentdetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%" valign="top">
                                Department HOD : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor5" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="admission" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%" valign="top">
                                Research section Image : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor6" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="rearchimage" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%" valign="top">
                                Research section Content : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor7" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="rearchcontent" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%" valign="top">
                                Research Link : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor8" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="rearchlink" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr >
                            <td align="right" width="15%" valign="top">
                              Infrastructure Facilities : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="deptfacilities" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right" width="15%" valign="top">
                                Contact Details : &nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="deptcontactus" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right" width="15%">
                                Mega Menu Display Order
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:TextBox ID="megamenudisplayorder" CssClass="box" runat="server" Width="50px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" ControlToValidate="megamenudisplayorder"
                                    ErrorMessage="Enter Numeric" Display="Dynamic" ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%">
                                Upload Banner<span class="star"></span> :&nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:FileUpload ID="File1" runat="server" />
                                <asp:TextBox ID="banner" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%">
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
                                <asp:LinkButton ID="lnkremove" runat="server" Visible="false" OnClick="lnkremove_Click">Remove Image</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                Display Order
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:TextBox ID="displayorder" CssClass="box" runat="server" Width="50px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right" style="width: 15%">
                                List Image<span class="star"></span> :&nbsp;
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:FileUpload ID="File2" runat="server" />
                                <asp:TextBox ID="admissionimg" runat="server" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 15%">
                            </td>
                            <td align="left" style="width: 85%">
                                <asp:Image ID="Image2" runat="server" Height="100px" Visible="False" Width="100px" />
                                <asp:LinkButton ID="LinkButton1" runat="server" Visible="false" OnClick="LinkButton1_Click">Remove Image</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="head1" colspan="2" style="font-size: small;" nowrap>
                                SEO Information
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Page Title :&nbsp;
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
                                <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                Meta Description :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
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
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />
                                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="False"
                                    OnClick="btncancel_Click1" />
                            </td>
                        </tr>
                    </table>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
