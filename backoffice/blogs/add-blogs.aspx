<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" Theme="backtheme" AutoEventWireup="true" CodeFile="add-blogs.aspx.cs" Inherits="backoffice_blogs_add_blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript" src="/fancybox/1.4/jquery.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".various4").fancybox({
                'width': '90%',
                'height': '90%',
                'autoScale': true,
                'scrolling': 'yes',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>


    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=blogdate.ClientID%>'));
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
     <script type="text/javascript">
         function showpreview1(input) {

             if (input.files && input.files[0]) {
                 document.getElementById("imgpreview1").style.display = 'inline';
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#imgpreview1').attr('src', e.target.result);
                 }
                 reader.readAsDataURL(input.files[0]);
             }
         }
    </script>
    
<h2>Add/Edit Blogs</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2" class="head1">
                
                <asp:TextBox ID="blogId" runat="server" Visible="False" Width="33px"></asp:TextBox>
                <asp:CheckBox ID="status" Checked="true" runat="server" Visible="false" />

                <asp:TextBox ID="tagid" runat="server" Visible="False" Width="33px"></asp:TextBox>
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
                Fields with <span class="star">*</span>are mandatory
                <br /> <br />
            </td>
        </tr>
       
         <%--<tr>
            <td align="right" colspan="2" >
                <a class="various4 btnbg" href="uploablogs.aspx">Upload Blogs</a> 
             
            </td>
        </tr>
--%>
        <tr >
            <td align="right" style="width: 15%">
                Blog Category<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="CatId" runat="server" Width="350px">
                <%--<asp:ListItem Value="0">0</asp:ListItem>--%>
                </asp:DropDownList>
                
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="0" runat="server" ControlToValidate="CatId"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Author<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="AutId" runat="server" Width="350px">
                      <%--<asp:ListItem Value="0">0</asp:ListItem>--%>
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" runat="server" ControlToValidate="AutId"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>

        <%--<tr>
            <td align="right" style="width: 15%">
                Tag<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="DropDownList1" runat="server" Width="350px">
                     
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server" ControlToValidate="AutId"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>

        <tr>
            <td align="right" style="width: 15%">
                Topic<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="topicId" runat="server" Width="350px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" InitialValue="0" runat="server" ControlToValidate="topicId"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
               
        <tr>
            <td align="right" style="width: 15%">
                Blog<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="blogtitle" runat="server" Width="350px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="blogtitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr style="display:none;">
            <td align="right" style="width: 15%">
                Company name<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="companyname" runat="server" Width="350px"></asp:TextBox>
                
            </td>
        </tr>


        <tr>
            <td align="right">
                <span class="star">*</span>Blog Date :&nbsp;
            </td>
            <td align="left">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <asp:TextBox ID="blogdate" runat="server" CssClass="box" Width="166px"></asp:TextBox>
                        </td>
                        <td>
                            <img src="../assets/calendar.png" border="0" alt="Select Order start date." runat="server"
                                id="Img1" onclick="dp_cal.toggle();" width="25" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="blogdate"
                                Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="blogdate"
                                CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

          <tr>
            <td align="right" valign="top">
              Small  Description :&nbsp;
                <br />
                <span style="font-style: italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="smalldesc" runat="server" Visible="False"></asp:TextBox>
                <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>

        <tr>
            <td align="right" valign="top">
              Long  Description :&nbsp;
                <br />
                <span style="font-style: italic; color: red;">(required wherever applicable)</span>
            </td>
            <td align="left">
                <asp:TextBox ID="longdesc" runat="server" Visible="False"></asp:TextBox>
                <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
       

        <tr>
            <td align="right">
                Blog Image :&nbsp;
            </td>
            <td align="left">
                <input id="File1" runat="server" contenteditable="false" type="file" onchange="showpreview(this);"
                    class="box" />
                <asp:TextBox ID="BlogImage" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <img id="imgpreview" height="100" width="100" src="" style="display: none;" />
                <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="toptxt" Visible="False">Remove Banner</asp:LinkButton>
            </td>
        </tr>



         <tr style="display:none;">
            <td align="right">
                Blog Large Image :&nbsp;
            </td>
            <td align="left">
                <input id="File2" runat="server" contenteditable="false" type="file" onchange="showpreview1(this);"
                    class="box" />
                <asp:TextBox ID="LargeImage" runat="server" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <img id="imgpreview1" height="100" width="100" src="" style="display: none;" />
                <asp:Image ID="Image2" runat="server" Height="100px" Visible="False" Width="100px" />
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:LinkButton ID="LinkButton2" OnClick="LinkButton2_Click" runat="server" CssClass="toptxt" Visible="False">Remove Banner</asp:LinkButton>
            </td>
        </tr>


        <tr style="display:none;">
            <td align="right">
               Url :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="urllink" runat="server" Width="33px"></asp:TextBox>
               
            </td>
        </tr>
      



        <tr>
            <td align="right">
                Display Order :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="33px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <%--<tr style="display:none;">
            <td align="right">
                Blog desc :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="blogdesc" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>--%>
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
                <asp:TextBox ID="PageTitle" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                Page Rewrite Url :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="rewriteurl" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Keywords :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemeta" runat="server" Height="50px" TextMode="MultiLine" Width="600px" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Description :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="pagemetadesc" runat="server" Height="50px" TextMode="MultiLine"
                    Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
                <td align="right" valign="top">
                    Other Schema :
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="pagescript" runat="server" Height="50px" TextMode="MultiLine"
                        Width="600px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>Canonical : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canonical" runat="server" Width="600px"></asp:TextBox>
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
            <td align="left">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btnbg" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" OnClick="btnCancel_Click" CausesValidation="False" />
            </td>
        </tr>
        
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

