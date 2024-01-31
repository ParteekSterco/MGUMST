<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"
    AutoEventWireup="true" CodeFile="addlaboratories.aspx.cs" Inherits="backoffice_Laboratories_addlaboratories"
    Theme="backtheme" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="/App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="/calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=labdate.ClientID%>'));
        };
    </script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
            CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
        });
    </script>
    <h2>
        Add Laboratories</h2>
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
                    <asp:TextBox ID="labid" runat="server" Visible="false"></asp:TextBox>
                    <asp:CheckBox ID="status" runat="server" Visible="False" Checked="true" />
                    <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="false" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>School<span class="star">*</span> : &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="collageid" runat="server" Width="350px" AutoPostBack="true"
                        OnSelectedIndexChanged="collageid_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="collageid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Department<span class="star"></span>: &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="deptid" runat="server" Width="350px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Laboratories Category<span class="star"></span>: &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="lcid" runat="server" Width="350px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right" style="width: 15%">
                    Title<span class="star">*</span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="labTitle" runat="server" CssClass="box" Width="500"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="labTitle"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Tagline<span class="star"></span> :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="tagline" runat="server" CssClass="box" Width="359px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right">
                    Date<span class="star"></span> :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="labdate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Eventsdate"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Eventsdate"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                    --%>
                </td>
            </tr>
            <tr style="display:none;">
                <td valign="top" align="right">
                    Short desc :&nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="shortdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Detail : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="longDesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right">
                    Upload Small Image :&nbsp;
                </td>
                <td align="left">
                    <input id="File4" runat="server" contenteditable="false" type="file" class="box" />
                    <br />
                    <%--    <asp:Label
                    ID="Label3" runat="server" Text="(Events and News Image should be of size : 405 x 264.)"
                    ForeColor="red" Font-Italic="true"></asp:Label>--%>
                    <br />
                    <asp:TextBox ID="UploadEvents" runat="server" Visible="False"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="Image2" runat="server" Visible="False" Width="100" Height="100" />
                    <asp:LinkButton ID="lnkremove" runat="server" Visible="False" Style="color: Black"
                        CausesValidation="False" OnClick="lnkremove_Click">Remove Image</asp:LinkButton>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right">
                    Upload Large Image :&nbsp;
                </td>
                <td align="left">
                    <input id="File5" runat="server" contenteditable="false" type="file" class="box" />
                    &nbsp;
                    <%--   <asp:Label
                    ID="Label2" runat="server" Text="(News Detail Image should be of size : 900 x 586.)"
                    ForeColor="red" Font-Italic="true"></asp:Label>--%>
                    <asp:TextBox Visible="false" ID="largeimage" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="imglarge" runat="server" Visible="False" Width="100" Height="100" />
                    <asp:LinkButton ID="lnklarge" Visible="False" runat="server" Style="color: Black"
                        OnClick="lnklarge_Click">Remove Image</asp:LinkButton>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right">
                    Upload File :&nbsp;
                </td>
                <td align="left" colspan="3">
                    <input id="File6" runat="server" class="box" contenteditable="false" type="file" />
                    &nbsp;<asp:Label ID="Label5" runat="server" Text="(Upload file for Press Release)"
                        ForeColor="red" Font-Italic="true"></asp:Label>
                    <asp:TextBox ID="uploadfile" runat="server" Visible="False"></asp:TextBox>
                    <asp:LinkButton ID="lnkremovefile" runat="server" CausesValidation="false" Visible="false"
                        OnClick="lnkremovefile_Click">Remove File</asp:LinkButton>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right">
                    Url :&nbsp;
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="url" runat="server" Width="243px"></asp:TextBox>
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
                    
                </td>
            </tr>
            <tr style="display:none;">
                <td align="left" colspan="2" height="10">
                    <b>SEO Section</b>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Rewrite URL :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="rewriteurl" runat="server" Visible="true"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Name :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageTitle" runat="server" Visible="true" Width="500"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Meta :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMeta" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right" style="width: 15%; height: 26px;" valign="top">
                    <span class="star"></span>Page Description :&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="PageMetaDesc" runat="server" Visible="true" Width="500" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td valign="top" align="right">
                    <span class="star"></span>Canonical : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none;">
                <td align="right" valign="top">
                    No Index Follow :
                </td>
                <td align="left" valign="top">
                    <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td valign="top">
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnsubmit_Click" />&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
            <%--   </table>
            </td>
        </tr>--%>
        </table>
    </div>
</asp:Content>
