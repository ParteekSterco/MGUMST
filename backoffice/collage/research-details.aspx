<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" Theme="backtheme" AutoEventWireup="true" CodeFile="research-details.aspx.cs" Inherits="backoffice_collage_research_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script src="../../fancybox/jquery.mousewheel-3.0.4.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#various4").fancybox({
                'width': '50%',
                'height': '40%',
                'autoScale': false,
                'scrolling': 'no',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <h2>
        Research Details</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                       <asp:TextBox ID="mid" runat="server" Visible="false"></asp:TextBox>
                         <asp:TextBox ID="displayorder" runat="server" Visible="false"></asp:TextBox>
                        <asp:DropDownList ID="deptid" runat="server" Visible="false">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        </asp:DropDownList>
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
            <tr bgcolor="#6E83BA">
                <td colspan="2">
                    <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                padding-left: 10px;" width="30%">
                                <asp:Label ID="lblcollage" runat="server"></asp:Label>
                            </td>
                            <td width="70%" align="right">
                                <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To School</b></a>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                    <asp:TextBox ID="collageid" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
          
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
               <tr>
            <td align="right" valign="top">
                Description :&nbsp;
            </td>
            <td align="left">
                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="details" runat="server" Visible="False" Width="122px"></asp:TextBox>
            </td>
        </tr>
          
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnsubmit" runat="server" Text="Update" TabIndex="15" CssClass="btnbg"
                        ValidationGroup="addnew" onclick="btnsubmit_Click" />
                </td>
            </tr>
        </table>
    </div>






</asp:Content>

