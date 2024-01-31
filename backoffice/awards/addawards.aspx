<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"
    AutoEventWireup="true" CodeFile="addawards.aspx.cs" Inherits="backoffice_awards_addawards"
    Theme="backtheme" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor3.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor4.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            



        });
    </script>
    <script type="text/javascript" src="../../fancybox/jquery.min.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <link href="../../App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
		$(document).ready(function() {
			
			$("#upload1").fancybox({
				'width'         : '6',
				'height'        : '5',				
				'autoScale'		: false,
				'scrolling'   	: 'no',
				'type'			: 'iframe',
				'transitionIn'	: 'elastic',
				'transitionOut'	: 'elastic',
			});
		});
    </script>
    
    <h2>
        Add Awards and Honors</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                            </td>
                            <td align="right">
                                <asp:TextBox ID="awardid" runat="server" Width="122px" Visible="false"></asp:TextBox>
                              
                                <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="false" />
                                <asp:CheckBox ID="showonhome_school" runat="server" Visible="False" Checked="false" />
                               
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
                <td colspan="2">
                    <table border="0" cellpadding="1" cellspacing="0" style="width: 100">
                        <tr>
                            <td align="right" valign="top" width="15%">
                                Faculty Member<span class="star">*</span> : &nbsp;
                            </td>
                            <td width="85%">
                                <asp:DropDownList ID="fid" runat="server" Width="200px">
                                    <%-- <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="fid"
                                    Display="Dynamic" InitialValue="0" ErrorMessage="Required" ValidationGroup="validaward"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="right">
                                <span class="star"></span>School<span class="star">*</span> : &nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="schid" runat="server" Width="200px">
                                    <asp:ListItem Selected="True" Value="0">select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="schid"
                                    Display="Dynamic" InitialValue="0" ErrorMessage="Required" ValidationGroup="validaward"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td valign="top" align="right">
                                Department <span class="star"></span>: &nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="deptid" runat="server" Width="200px">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" width="15%">
                                Award Name<span class="star">*</span> : &nbsp;
                            </td>
                            <td width="85%">
                                <asp:TextBox ID="awardname" runat="server" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="awardname"
                                    Display="Dynamic" ErrorMessage="Required" ValidationGroup="validaward"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                       

                        <tr>
                            <td valign="top" align="right">
                                Short Description  : &nbsp;
                            </td>
                            <td>
                                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="smalldesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td valign="top" align="right">
                                Detail(s) : &nbsp;
                            </td>
                            <td>
                                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="detaildesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td valign="top" align="right">
                                Awarding Authority : &nbsp;
                            </td>
                            <td>
                                <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="awardauthority" runat="server" Width="600px" Height="250px" TextMode="MultiLine"
                                    Visible="false"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td valign="top" align="right">
                                Year and other details : &nbsp;
                            </td>
                            <td>
                                <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                                </CKEditor:CKEditorControl>
                                <asp:TextBox ID="year_otherdetails" runat="server" Width="300px" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        
                       
                      
                        <tr style="display:none;">
                            <td valign="top" align="right">
                                Small Image : &nbsp;
                            </td>
                            <td>
                                <input id="File1" runat="server" class="box" contenteditable="false" type="file" />
                                <asp:TextBox ID="awardimage" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td valign="top" align="right">
                            </td>
                            <td>
                                <asp:Image ID="Image1" runat="server" Visible="false" Width="100" Height="100" />
                                <asp:LinkButton ID="lnkremove" runat="server" CausesValidation="false" Visible="false">Remove</asp:LinkButton>&nbsp;&nbsp;<asp:Label
                                    ID="Label1" runat="server" Text="" ForeColor="red" Font-Italic="true"></asp:Label>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td valign="top" align="right">
                                Large Image : &nbsp;
                            </td>
                            <td>
                                <input id="File2" runat="server" class="box" contenteditable="false" type="file" />
                                <asp:TextBox ID="largeimage" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display:none;">
                            <td valign="top" align="right">
                            </td>
                            <td>
                                <asp:Image ID="Image2" runat="server" Visible="false" Width="100" Height="100" />
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" Visible="false">Remove</asp:LinkButton>&nbsp;&nbsp;<asp:Label
                                    ID="Label2" runat="server" Text="" ForeColor="red" Font-Italic="true"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right">
                                Display order<span class="star"></span> :&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="displayorder" runat="server" Width="50px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="displayorder"
                                Display="Dynamic" ErrorMessage="Required" ValidationGroup="validaward"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                                    ValidationExpression="^\d+?$" ValidationGroup="validaward"></asp:RegularExpressionValidator>
                                <asp:CheckBox ID="status" runat="server" Checked="True" Visible="false" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right">
                                Re-writeurl :&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="rewriteurl" runat="server" Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr style="display: none">
                            <td class="head1" colspan="2" style="font-size: small;" nowrap>
                                SEO Information
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right">
                                Page Title :&nbsp;
                            </td>
                            <td align="left">
                                <asp:TextBox ID="PageTitle" runat="server" Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right" valign="top">
                                Meta Keywords :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="600px" />
                            </td>
                        </tr>
                        <tr style="display: none">
                            <td align="right" valign="top">
                                Meta Description :
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
                                    Width="600px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                            </td>
                            <td>
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnsubmit_Click"
                                    ValidationGroup="validaward" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                        CssClass="btnbg" OnClick="btncancel_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
