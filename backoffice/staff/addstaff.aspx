<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="addstaff.aspx.cs" Inherits="backoffice_staff_addstaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



 <script type="text/javascript">
     $(function () {
         CKEDITOR.replace('<%=CKeditor1.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor2.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor3.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor4.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor6.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor7.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor8.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor9.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor10.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor11.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor12.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor13.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor14.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor15.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor16.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor17.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
         CKEDITOR.replace('<%=CKeditor18.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });



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
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=dob.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=doj.ClientID%>'));

        };
    </script>
  
   <h2>Add Faculty</h2>
<div class="content-panel"> 
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            
                        </td>
                        <td align="right">
                            <asp:TextBox ID="staffid" runat="server" Width="122px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="fsignature" runat="server" Width="122px" Visible="false"></asp:TextBox>
                            <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="false" />
                            <asp:CheckBox ID="showonhome_school" runat="server" Visible="False" Checked="false" />
                            <asp:CheckBox ID="showonhome_campus" runat="server" Visible="False" Checked="true" />
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
                            Name Prefix<span class="star">*</span> : &nbsp;
                        </td>
                        <td width="85%">
                            <asp:DropDownList ID="nprefix" runat="server" Width="300px">
                                 <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nprefix"
                                Display="Dynamic" InitialValue="0" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td align="right" valign="top" width="15%">
                           Staff Type <%--Academic Designation--%> <span class="star">*</span> : &nbsp;
                        </td>
                        <td width="85%">
                            <asp:DropDownList ID="sid" runat="server" Width="300px">
                                 <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="sid"
                                Display="Dynamic" InitialValue="0" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        <td valign="top" align="right">
                            <span class="star"></span>School<span class="star">*</span> : &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="schid" runat="server" Width="300px">
                                <asp:ListItem Selected="True" Value="0">select</asp:ListItem>
                            </asp:DropDownList>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="schid"
                                Display="Dynamic"  InitialValue="0" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Department <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="deptid" runat="server" Width="300px">
                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top" width="15%">
                            Staff Name<span class="star">*</span> : &nbsp;
                        </td>
                        <td width="85%">
                            <asp:TextBox ID="fname" runat="server" CssClass="box" Width="300px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="fname"
                                Display="Dynamic" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right" valign="top" width="15%">
                            Date-Of-Birth<span class="star"></span> : &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="dob" runat="server" CssClass="box" Width="300px"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dob"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="dob"
                                CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right" valign="top" width="15%">
                            Date-Of-Joining<span class="star"></span> : &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="doj" runat="server" CssClass="box" Width="300px"></asp:TextBox>
                            <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dob"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="doj"
                                CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                            <%--Administrative--%> Designation  <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="Designation" runat="server" Width="300px">
                                 <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="Designation" runat="server" Width="300px"></asp:TextBox>--%>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Designation"
                                Display="Dynamic" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr >
                        <td valign="top" align="right">
                            Qualification <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="qualification" runat="server" CssClass="box" Width="300px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Designation"
                                Display="Dynamic" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>

                    <tr >
                        <td valign="top" align="right">
                            Department <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="Specialization" CssClass="box" runat="server" Width="300px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Designation"
                                Display="Dynamic" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>


                    <tr style="display: none" >
                        <td valign="top" align="right">
                            Years of Experience <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="YearsofExperience" runat="server"  Width="300px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Email <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="email" runat="server" Width="300px"></asp:TextBox>
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="email"
                                Display="Dynamic" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid email."
                                ControlToValidate="email" ValidationGroup="addfaculty" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                     <tr style="display: none" >
                        <td valign="top" align="right">
                           Mobile <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="mobile" runat="server" MaxLength="40" Width="300px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Linked In <span class="star"></span>: &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="password" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr style="display: none">
                        <td valign="top" align="right">
                            Registration No. : &nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="RegNo" runat="server" MaxLength="99" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr >
                        <td valign="top" align="right">
                            Email/Social link: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor11" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="patents" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr >
                        <td valign="top" align="right">
                           Interest Area(s) : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="detaildesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                        Staff Profile : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="fdetail" runat="server" Width="300px" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                   
                    <tr >
                        <td valign="top" align="right">
                             Education : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="smalldesc" runat="server" Width="600px" Height="250px" TextMode="MultiLine"
                                Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                  
                    <tr  >
                        <td valign="top" align="right">
                            Experience : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor5" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="work_experience" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Subjects Taught: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor6" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="subjects_taught" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                   
                    <tr style="display: none"  >
                        <td valign="top" align="right">
                            Research: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor7" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="research_initiatives" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none" >
                        <td valign="top" align="right">
                            Conferences: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor8" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="project_guidance" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr style="display:none">
                        <td valign="top" align="right">
                            Projects Carried out: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor10" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="projects_carried_out" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                  
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Technology Transfer : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor12" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="technology_transfer" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Consultancy : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor13" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="consultancy" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Grant : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor14" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="grants" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                  
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Society Membership: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor16" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="society_membership" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Industrial Training: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor17" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="industrial_training" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Any other Achievements: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor18" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="any_other_achievements" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                         Projects/Achievements : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="achivement" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr style="display: none" >
                        <td valign="top" align="right">
                            Publications: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor9" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="books_published" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                      <tr style="display: none" >
                        <td valign="top" align="right">
                            Core Competency & Academic : &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor15" runat="server" Height="250" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="revenue_earned" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                         Small Image : &nbsp;
                        </td>
                        <td>
                            <input id="File1" runat="server" class="box" style="width:300px" contenteditable="false" type="file" />
                            <asp:TextBox ID="fimage" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                        </td>
                        <td>
                            <asp:Image ID="Image1" runat="server" Visible="false" Width="100" Height="100" />
                            <asp:LinkButton ID="lnkremove" OnClick="lnkremove_Click" runat="server" CausesValidation="false" Visible="false">Remove</asp:LinkButton>&nbsp;&nbsp;<asp:Label
                                ID="Label1" runat="server" Text="" ForeColor="red" Font-Italic="true"></asp:Label>
                        </td>
                    </tr>

                       <tr>
                        <td valign="top" align="right">
                          Large Image : &nbsp;
                        </td>
                        <td>
                            <input id="File2" runat="server" class="box" style="width:300px" contenteditable="false" type="file" />
                            <asp:TextBox ID="limage" runat="server" Visible="False" Width="122px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" align="right">
                        </td>
                        <td>
                            <asp:Image ID="Image2" runat="server" Visible="false" Width="100" Height="100" />
                            <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click"  runat="server" CausesValidation="false" Visible="false">Remove</asp:LinkButton>&nbsp;&nbsp;<asp:Label
                                ID="Label2" runat="server" Text="" ForeColor="red" Font-Italic="true"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Reputed Faculty : &nbsp;
                        </td>
                        <td>
                            <asp:CheckBox ID="facultylist" runat="server" Visible="true" />
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top" align="right">
                            Affiliate Faculty : &nbsp;
                        </td>
                        <td>
                            <asp:CheckBox ID="affiliate_faculty" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Display order<span class="star"></span> :&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="displayorder" runat="server" CssClass="box" Width="50px"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="displayorder"
                                Display="Dynamic" ErrorMessage="Required" ValidationGroup="addfaculty"></asp:RequiredFieldValidator>--%>
                            <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                                ValidationExpression="^\d+?$" ValidationGroup="addfaculty"></asp:RegularExpressionValidator>
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
                        <td align="right">
                            Rewriteurl Sec :&nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="rewriteurl_sec" runat="server" Width="600px"></asp:TextBox>
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
                        <td valign="top">
                        </td>
                        <td>
                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnsubmit_Click" ValidationGroup="addfaculty" />&nbsp;<asp:Button
                                ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" OnClick="btncancel_Click" CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </div>


</asp:Content>

