<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true"
    CodeFile="addhomebanner.aspx.cs" Inherits="backoffice_homebanner_addhomebanner"
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
//            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=bannerstartdate.ClientID%>'));
//            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=bannerenddate.ClientID%>'));
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

     <script language="javascript" type="text/javascript">
         //this script will get the date selected from the given calendarextender (ie: "sender") and append the
         //current time to it.
         function AppendTime(sender, args) {
             var selectedDate = new Date();
             selectedDate = sender.get_selectedDate();
             var now = new Date();
             sender.get_element().value = selectedDate.format("MM/dd/yyyy") + " " + now.format("hh:mm:ss tt");
         }
    </script>

    <script language="javascript" type="text/javascript">
        //this script will get the date selected from the given calendarextender (ie: "sender") and append the
        //current time to it.
        function AppendTimeEND(sender, args) {
            var selectedDate = new Date();
            selectedDate = sender.get_selectedDate();
            var now = new Date();
            sender.get_element().value = selectedDate.format("MM/dd/yyyy") + " " + now.format("hh:mm:ss tt");
        }
    </script>
    <h2>
        Add Home Banner</h2>
    <div class="content-panel">
        <asp:Panel ID="panel1" runat="server" DefaultButton="btnSubmit">
            <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="head1" colspan="2">
                        <asp:TextBox ID="bid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                        <asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="h_dot_line">
                        &nbsp;
                    </td>
                </tr>
                <tr bgcolor="#6E83BA" id="tr1" runat="server" visible="false">
                    <td colspan="2">
                        <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                            <tr>
                                <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                    padding-left: 10px;" width="30%">
                                    <asp:Label ID="lblcollage" runat="server"></asp:Label>
                                </td>
                                <td width="70%" align="right">
                                    <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To Colleges/Institutes</b></a>&nbsp;
                                </td>
                            </tr>
                        </table>
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
                <tr>=
                    <td align="right" colspan="2">
                        Fields with <span class="star">*</span>are mandatory
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" height="10">
                     <%--  <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Banner start date must be before/equal than end date"
                            ControlToCompare="bannerstartdate" ControlToValidate="bannerenddate" Type="Date"
                            Operator="GreaterThan" Display="Dynamic">
                        </asp:CompareValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="Label1" runat="server" SkinID="redtext" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Type<span class="star">*</span>:&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:DropDownList ID="btypeid" runat="server" Width="350">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                            ControlToValidate="btypeid" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Device Type<span class="star">*</span>:&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:DropDownList ID="devicetype" runat="server" Width="350">
                            <asp:ListItem Selected="True" Value="Desktop">Desktop</asp:ListItem>
                            <asp:ListItem Value="Mobile">Mobile</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required"
                            ControlToValidate="devicetype" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Title<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:TextBox ID="title" runat="server" Width="350"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                            ControlToValidate="title" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        Banner Start Date<span class="star"></span> :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="bannerstartdate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="bannerstartdate"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>

                            <ajaxToolkit:CalendarExtender ID="ce1" runat="server" PopupButtonID="calImg" Enabled="true" Format="MM/dd/yyyy" TargetControlID="bannerstartdate" PopupPosition="TopRight" OnClientDateSelectionChanged="AppendTime"></ajaxToolkit:CalendarExtender>
                           <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="bannerstartdate"
                            CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                            ValidationExpression="/^(((0[13578]|1[02])[\/\.-](0[1-9]|[12]\d|3[01])[\/\.-]((19|[2-9]\d)\d{2})\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm))|((0[13456789]|1[012])[\/\.-](0[1-9]|[12]\d|30)[\/\.-]((19|[2-9]\d)\d{2})\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm))|((02)[\/\.-](0[1-9]|1\d|2[0-8])[\/\.-]((19|[2-9]\d)\d{2})\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm))|((02)[\/\.-](29)[\/\.-]((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))\s(0[0-9]|1[0-2]):(0[0-9]|[1-59]\d):(0[0-9]|[1-59]\d)\s(AM|am|PM|pm)))$/g"></asp:RegularExpressionValidator>
--%>



                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="bannerstartdate"
                            CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                            ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>--%>
                       
                     
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        Banner End Date<span class="star"></span> :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="bannerenddate" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="bannerenddate"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>

                            
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="calImg" Enabled="true" Format="MM/dd/yyyy" TargetControlID="bannerenddate" PopupPosition="TopRight" OnClientDateSelectionChanged="AppendTimeEND"></ajaxToolkit:CalendarExtender>
                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="bannerenddate"
                            CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                            ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>--%>

                       
                      
                    </td>
                    <%-- <td align="right" style="width: 15%">
                Event Date :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="eventedate" runat="server" CssClass="box" Width="120px"></asp:TextBox>
            </td>--%>
                </tr>
                <tr>
                    <td align="right" style="width: 15%" valign="top">
                        Tag Line:&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                        </CKEditor:CKEditorControl>
                        <asp:TextBox ID="tagline1" runat="server" Width="350" Height="50" TextMode="MultiLine"
                            Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right" style="width: 15%" valign="top">
                        Tag Line2:&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                        </CKEditor:CKEditorControl>
                        <asp:TextBox ID="tagline2" runat="server" Width="350" Height="50" TextMode="MultiLine"
                            Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Banner<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <input id="File1" runat="server" class="box" style="width: 350px" contenteditable="false"
                            onchange="showpreview(this);" type="file" />
                        <br />
                        <asp:Label ID="lblapl" runat="server" Font-Italic="true" ForeColor="#ff0000"></asp:Label>
                        <asp:TextBox ID="bannerimage" runat="server" Visible="false"></asp:TextBox>
                        <asp:LinkButton ID="lnkBanerremove" runat="server" Visible="false" OnClick="lnkBanerremove_Click">Remove Banner</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                    </td>
                    <td align="left" style="width: 85%">
                        <img id="imgpreview" height="100" width="100" src="" style="display: none;" />
                        <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
                        <video width="200px" height="200px" playsinline="playsinline" autoplay="autoplay"
                            muted="muted" loop="loop" runat="server" visible="false" id="pvideo">
                                                <source runat="server" id="showvideo" type="video/mp4" />
                                          </video>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right" style="width: 15%">
                        Mobile Banner<span class="star"></span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <input id="File2" runat="server" class="box" style="width: 350px" contenteditable="false"
                            onchange="showpreview1(this);" type="file" />
                        <br />
                        <asp:Label ID="Label2" runat="server" Font-Italic="true" ForeColor="#ff0000"></asp:Label>
                        <asp:TextBox ID="bannermobile" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right" style="width: 15%">
                    </td>
                    <td align="left" style="width: 85%">
                        <img id="imgpreview1" height="100" width="100" src="" style="display: none;" />
                        <asp:Image ID="Image2" runat="server" Height="100px" Visible="False" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Logo Banner<span class="star"></span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <input id="File3" runat="server" class="box" style="width: 350px" contenteditable="false"
                            onchange="showpreview1(this);" type="file" />
                        <br />
                        <asp:Label ID="Label3" runat="server" Font-Italic="true" ForeColor="#ff0000"></asp:Label>
                        <asp:TextBox ID="blogo" runat="server" Visible="false"></asp:TextBox>
                        <asp:LinkButton ID="lnkRemove" runat="server" Visible="false" OnClick="lnkremove_Click">Remove Banner</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                    </td>
                    <td align="left" style="width: 85%">
                        <img id="img3" height="100" width="100" src="" style="display: none;" />
                        <asp:Image ID="Image3" runat="server" Height="100px" Visible="False" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%" valign="top">
                        Url:&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:TextBox ID="url" runat="server" Width="350"></asp:TextBox>
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
                            ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        Status :&nbsp;
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="Status" runat="server" Checked="true" />
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
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="15" CssClass="btnbg"
                            OnClick="btnSubmit_Click" />
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="False"
                            TabIndex="16" CssClass="btnbg" OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
