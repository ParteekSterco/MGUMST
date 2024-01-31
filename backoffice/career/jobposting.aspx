<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="jobposting.aspx.cs" Inherits="backoffice_career_jobposting" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />

    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>

    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=JobOpening_date.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=JobClosing_date.ClientID%>'));
        };
    </script>

    <h2>  Job Posting</h2>
    <div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td class="head1" colspan="4">
               <asp:TextBox ID="JobId" runat="server" Visible="False" Width="33px"></asp:TextBox><asp:CheckBox
                    ID="status" runat="server" Visible="False" Checked="True" />
            </td>
        </tr>
        <tr>
            <td colspan="4" class="h_dot_line">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingtext" colspan="4">
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
            <td align="right" colspan="4">
                Fields with <span class="star">*</span>are mandatory</td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Label ID="Label1" runat="server" SkinID="redtext" Visible="False"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Job closing date must be later than opening date"
                    ControlToCompare="JobOpening_date" ControlToValidate="JobClosing_date" Type="Date"
                    Operator="GreaterThan" Display="Dynamic">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr >
            <td align="right" >
                Job Type:&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <asp:DropDownList ID="jobcategory" runat="server" Width="100px"  >
                    <asp:ListItem>Full Time</asp:ListItem>
                    <asp:ListItem>Part Time</asp:ListItem>
                </asp:DropDownList></td>
            <td align="right" style="width: 20%">
                &nbsp;
            </td>
            <td align="left" style="width: 30%">
            </td>
        </tr>
         <tr >
            <td align="right" >
                Employee Type<span class="star">*</span>:&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <asp:DropDownList ID="emptypeid" runat="server" Width="200px"  >
                    
                </asp:DropDownList>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" ControlToValidate="emptypeid"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            <td align="right" style="width: 20%">
                &nbsp;
            </td>
            <td align="left" style="width: 30%">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                Job Code<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="JobCode" runat="server" MaxLength="100" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="JobCode"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
            <td align="right" style="width: 20%">
                Job Title<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="JobTitle" runat="server" MaxLength="100" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="JobTitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
        
        <tr>
            <td align="right" style="width: 20%">
                Min. Exp.<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:DropDownList ID="Min_Expyear" runat="server" Width="40px" >
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            Year&nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="Min_expmonth" runat="server" Width="40px" >
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            Month&nbsp;</td>
                    </tr>
                </table>
            </td>
            <td align="right" style="width: 20%">
                Max. Exp. :&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:DropDownList ID="Max_Expyear" runat="server" Width="40px" >
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            Year&nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="Max_expmonth" runat="server" Width="40px" >
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            Month&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>



        <tr>
            <td align="right" style="width: 20%">
                Job Opening Date<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="JobOpening_date" runat="server" contentEditable="false" MaxLength="100"
                    Width="200px" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="JobOpening_date"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
            </td>
            <td align="right" style="width: 20%">
                Job Closing Date<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="JobClosing_date" runat="server" contentEditable="false" MaxLength="100"
                    Width="200px" ></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="JobClosing_date"
                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                <strong><span style="font-size: 9pt; color: #ff0000"></span></strong>Age :&nbsp;
            </td>
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:DropDownList ID="Ageyear" runat="server" Width="40px" >
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            Year&nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="Agemonth" runat="server" Width="40px" >
                            </asp:DropDownList>&nbsp;</td>
                        <td>
                            Month&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">
              Department<span class="star">*</span>  :&nbsp;
            </td>
            <td align="left">
			 <asp:DropDownList ID="department" runat="server" Width="200px">
                </asp:DropDownList>
            <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="department"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
              </td>

              <td align="right" style="width: 20%">
                No. of Vacancy<span class="star"></span> :&nbsp;
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="noofvacancies" runat="server" Width="200px"></asp:TextBox>
             </td>
        </tr>

        <tr style="display: none">
             <td align="right" valign="top">
               
            </td>
            <td align="left" colspan="3">
              <asp:TextBox ID="company" runat="server" MaxLength="100"  visible="false"></asp:TextBox>
                </td>  
        </tr>

        <tr style="display: none">
            <td align="right">
                Salary &amp; Perks :&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:TextBox ID="salary" runat="server" Height="25px" MaxLength="100" Rows="2" 
                    TextMode="MultiLine" Width="475px"></asp:TextBox></td>
        </tr>
        <tr style="display: none" >
            <td align="right">
                Location <span class="star">*</span>  :&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:TextBox ID="Location" runat="server" Height="25px" MaxLength="100" Rows="2"
                    TextMode="MultiLine" Width="475px" ></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Location"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    
                    </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                Designation<span class="star">*</span>  :&nbsp;</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="designation" runat="server" Height="25px" MaxLength="100" Rows="3" 
                    TextMode="MultiLine" Width="475px"></asp:TextBox>
                   <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="designation"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    
                    </td>
        </tr>
        <tr style="display: none">
            <td align="right">
                Email:</td>
            <td align="left" colspan="3">
                <asp:TextBox ID="emailid" runat="server" Height="25px"  Width="475px"></asp:TextBox></td>
        </tr>
        
        <tr >
            <td align="right" valign="top">
                Job Description :&nbsp;
            </td>
            <td align="left" colspan="3">
                 <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="shortdesc" runat="server" Visible="false"></asp:TextBox></td>
        </tr>
        <tr style="display: none">
            <td align="right" valign="top">
                Qualification :&nbsp;
            </td>
            <td align="left" colspan="3">
                    <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="qualification" runat="server" Visible="false"></asp:TextBox></td>
        </tr>
        <tr style="display: none">
            <td align="right" valign="top">
                Job Specification/Eligibility :&nbsp;
            </td>
            <td align="left" colspan="3">
                  <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="Skills" runat="server" MaxLength="100"  Visible="false"></asp:TextBox></td>
        </tr>
        <tr style="display: none">
            <td align="right" valign="top">
                Desired Profile :&nbsp;
            </td>
            <td align="left" colspan="3">
                  <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>
                <asp:TextBox ID="JobDesc" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
        <tr>
            
                <%--<asp:RegularExpressionValidator ID="Regularexpressionvalidator3" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>--%>
            
        </tr>
        
        <tr style="display: none">
            <td align="right" valign="top">
                Re-writeurl :&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:TextBox ID="rewriteurl" runat="server" Width="222px"></asp:TextBox>
               
            </td>
        </tr>
        
        
        <tr>
            <td align="right" valign="top">
                Display Order :&nbsp;
            </td>
            <td align="left" colspan="3">
                <asp:TextBox ID="displayorder" runat="server" Width="90px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
            </td>
        </tr>
        <tr>
            <td style="width: 10px;">
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" 
                    onclick="btnSubmit_Click"  />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" 
                    CausesValidation="False" onclick="btnCancel_Click"
                     /></td>
        </tr>
    </table>
    </div>
</asp:Content>

