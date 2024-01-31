<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="addconvocation.aspx.cs" Inherits="backoffice_convocation_addconvocation" %>


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
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=convocationdate.ClientID%>'));


        };
    </script>
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
    <h2>
        Add Convocation</h2>
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
            <tr style="display: none">
                <td align="right">
                    show on main site :&nbsp;
                </td>
                <td align="left">
                    <asp:CheckBox ID="showonmainsite" runat="server" Checked="false" />
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    show on micro site :&nbsp;
                </td>
                <td align="left">
                    <asp:CheckBox ID="showonmicrosite" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:CheckBox ID="status" runat="server" Visible="False" Checked="True" />
                    <asp:TextBox ID="cid" runat="server" Visible="False" Width="33px"></asp:TextBox>Fields
                    with <span class="star">*</span>are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr style="display: none">
                <td align="right" style="width: 15%">
                    Category :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:DropDownList ID="Parentid" runat="server">
                    <asp:ListItem Value="0">0</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

             <tr style="display:none">
                <td align="right" style="width: 15%">
               Type :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:DropDownList ID="ntypeid" runat="server">
                    <asp:ListItem Value="0">0</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr style="display:none" >
                <td align="right">
                    Album Type<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <asp:DropDownList ID="typeid" runat="server" Width="359px">
                    <asp:ListItem Value="0">0</asp:ListItem>
                    </asp:DropDownList>
                       </td>
            </tr>
            <tr>
                <td align="right">
                    Convocation Title<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="convocationtitle" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                        Width="359px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="convocationtitle"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Picasa Code<%--<span class="star">*</span>--%>
                    :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="picasacode" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                        Width="359px"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="AlbumTitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" valign="top">
                    Select page To display :&nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:DropDownList ID="galpageid" runat="server">
                    <asp:ListItem Value="0">0</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Date <span class="star"></span>:&nbsp;
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="convocationdate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="convocationdate"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="convocationdate"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
               
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Small Desc :&nbsp;
                </td>
                <td align="left" valign="top">
                    <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="convocationSmallDesc" runat="server" Width="359px" Height="50px" TextMode="MultiLine"
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Description :&nbsp;
                </td>
                <td align="left" valign="top">
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="convocationDesc" runat="server" Width="359px" Height="50px" TextMode="MultiLine"
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td align="right">
                    Upload Image<span class="star">*</span> :&nbsp;
                </td>
                <td align="left">
                    <input id="File1" runat="server" class="box" contenteditable="false" onchange="showpreview(this);"
                        type="file" />&nbsp;<asp:Label ID="Label1" runat="server" Text="(Image should be of size : 288x209.)"
                            ForeColor="red" Font-Italic="true"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" Text="(Gallery Image show on homepage should be of size : 500 x 511.)"
                        ForeColor="red" Font-Italic="true"></asp:Label>
                    <asp:TextBox ID="UploadAImage" runat="server" Visible="False" Width="122px">
                    </asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td align="right">
                </td>
                <td align="left">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                </td>
            </tr>
            <tr style="display:none">
                <td align="right">
                </td>
                <td align="left">
                    <img id="imgpreview" height="100" width="100" src="" style="display: none;" />
                    <asp:Image ID="Image1" runat="server" Width="100" Height="100" Visible="false" />
                </td>
            </tr>
            <tr>
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
                <td align="left" colspan="2" height="10">
                    <b>SEO Section</b>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Rewrite Url:&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="rewriteurl" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Name :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageTitle" runat="server" Visible="true" Width="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Meta :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMeta" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Description :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMetaDesc" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Other Schema :
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
                <td height="10">
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnSubmit_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
            
        
        </table>
    </div>
</asp:Content>
