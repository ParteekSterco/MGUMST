<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"
    Theme="backtheme" AutoEventWireup="true" CodeFile="addcourse.aspx.cs" ValidateRequest="false" Inherits="backoffice_Course_addcourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <%--<script type="text/javascript">
     $(function()
      {
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
     });
</script>--%>


    <link href="../../App_Themes/backtheme/ajax_stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/backtheme/backoffice.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <h2>
        Add Course</h2>
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
                    <asp:TextBox ID="courseid" runat="server" Visible="false"></asp:TextBox>
                    <%--  <asp:TextBox ID="deptid" runat="server" Visible="false"></asp:TextBox>     --%>
                    <asp:CheckBox ID="showonhome" runat="server" Visible="False" Checked="false" />
                    <asp:CheckBox ID="showonhome_school" runat="server" Visible="False" Checked="true" />
                    <asp:CheckBox ID="showonhome_campus" runat="server" Visible="False" Checked="true" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td valign="top" width="15%" align="right">
                    Course Type<span class="star">*</span> : &nbsp;
                </td>
                <td width="85%">
                    <asp:DropDownList ID="ctid" runat="server" Width="350px" ></asp:DropDownList>                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ctid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
            <tr>
                <td valign="top" width="15%" align="right">
                    Course Level<span class="star">*</span> : &nbsp;
                </td>
                <td width="85%">
                    <asp:DropDownList ID="levelid" runat="server" Width="350px" AutoPostBack="false"
                        OnSelectedIndexChanged="levelid_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="levelid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
              <tr>
                <td valign="top" width="15%" align="right">
                    Discipline<span class="star">*</span> : &nbsp;
                </td>
                <td width="85%">
                    <asp:DropDownList ID="dpid" runat="server" Width="350px" ></asp:DropDownList>
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="dpid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="display:none" >
                <td valign="top" align="right">
                    Stream<span class="star"></span>: &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="streamid" runat="server" Width="350px">
                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="streamid"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    <span class="star"></span>College<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="collageid" runat="server" Width="350px" AutoPostBack="true"
                        OnSelectedIndexChanged="collageid_SelectedIndexChanged">
                    </asp:DropDownList>
                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="collageid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    Department<span class="star"></span>: &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="deptid" runat="server" Width="350px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="display: none">
                <td valign="top" align="right">
                    <span class="star"></span>Testimonial Category : &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="alertid" runat="server" Width="200px">
                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Course Name<span class="star">*</span> : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="coursename" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="coursename"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                   Course Short Name<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="coursesecondname" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td valign="top" align="right">
                    Course Code <span class="star"></span>: &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="coursecode" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    Duration<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <%--<CKEditor:CKEditorControl ID="CKeditor8" runat="server" Height="100" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>--%>
                    <asp:TextBox ID="noofsemestor" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td valign="top" align="right">
                    Intake per Annum <span class="star"></span>: &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="coursedegree" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td valign="top" align="right">
                    Course Overview :&nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="shortdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>


            <tr style="display: none;">
                <td valign="top" align="right">
                  Scholarship: &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor15" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="scholarships" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>

            <tr >
                <td valign="top" align="right">
                 Tagline: &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor16" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="intership_prog" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>





            <tr >
                <td align="right" valign="top">
                    Eligibility: &nbsp;
                </td>
                <td align="left">
                    <CKEditor:CKEditorControl ID="CKEditor14" runat="server" Height="100" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="eligiblitydetails" runat="server" Visible="false" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    Selection Procedure<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor9" runat="server" Height="100" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="admission_process" Visible="false" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    Course Details : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="coursedetail" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" valign="top">
                    Learning Perspectives: &nbsp;
                </td>
                <td align="left">
                    <CKEditor:CKEditorControl ID="CKeditor10" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="purl" runat="server" Visible="false" Width="350px"></asp:TextBox>
                </td>
            </tr>

             <tr style="display: none;">
                <td valign="top" align="right">
                    Syllabus<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKEditor13" runat="server" Height="150" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="Syllabus" Visible="false" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>




            
            <tr >
                <td valign="top" align="right">
                    Career : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="highlights" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>

            <tr style="display: none;">
                <td valign="top" align="right">
                    Curriculum<span class="star"></span> : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKEditor12" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="Curriculum" Visible="false" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>

           
            
           
            <tr style="display: none">
                <td align="right">
                    Choose Colour<span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="height: 19px">
                    <script type="text/javascript" src="../../jscolor/jscolor.js"></script>
                    <asp:TextBox ID="colorcode" runat="server" Width="243px" CssClass="color"></asp:TextBox>
                </td>
            </tr>
          
            <tr >
                <td valign="top" align="right">
                    Fee Structure : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor6" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="feestructure" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
               <tr style="display: none;">
                <td valign="top" align="right">
                   Total Credit: &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="tagline" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;" >
                <td valign="top" align="right">
                    Other <span class="star"></span> : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKEditor11" runat="server" Height="100" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="CareerPath" Visible="false" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td valign="top" align="right">
                    FAQ : &nbsp;
                </td>
                <td>
                    <CKEditor:CKEditorControl ID="CKeditor7" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="faq" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
              <tr style="display: none;">
                <td valign="top" align="right">
                    Fee type<span class="star"></span>: &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="feetype" runat="server" Width="350px">
                    <asp:ListItem Text="Semester Wise">Semester Wise</asp:ListItem>
                    <asp:ListItem Text="Year Wise">Year Wise</asp:ListItem>
                        <asp:ListItem Text="Other">Other</asp:ListItem>
                    </asp:DropDownList>
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
                    <asp:CheckBox ID="status" runat="server" Checked="True" Visible="false" />
                </td>
            </tr>
             <tr  >
                <td valign="top" align="right">
                    External Url : &nbsp;
                </td>
                <td>
                   
                    <asp:TextBox ID="externalurl" runat="server" Width="243px"></asp:TextBox>
                </td>
            </tr>
            <tr  >
                <td valign="top" align="right">
                    Email ID : &nbsp;
                </td>
                <td>
                    <%--<CKEditor:CKEditorControl ID="CKeditor5" runat="server" Height="250" BasePath="~/ckeditor">
                </CKEditor:CKEditorControl>--%>
                    <asp:TextBox ID="criteria" runat="server" Width="243px"></asp:TextBox>

                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                 ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="criteria" ErrorMessage="Enter valid email address" />--%>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" valign="top">
                    Admission Brochure:&nbsp;
                </td>
                <td align="left">
                    <input id="File1" runat="server" contenteditable="false" type="file" class="box" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CssClass="toptxt"
                        Visible="false">Remove Brochure</asp:LinkButton>
                    <asp:TextBox ID="prospectus" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Image ID="Image1" runat="server" Height="120px" Visible="False" Width="107px" />
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                  Download Syllabus:&nbsp;
                </td>
                <td align="left">
                    <input id="File2" runat="server" contenteditable="false" type="file" class="box" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" CssClass="toptxt"
                        Visible="false">Remove Download Syllabus</asp:LinkButton>
                    <asp:TextBox ID="coursebrochure" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td align="right" valign="top">
                    Curriculum:&nbsp;
                </td>
                <td align="left">
                    <input id="File3" runat="server" contenteditable="false" type="file" class="box" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="toptxt"
                        Visible="false">Remove Curriculum</asp:LinkButton>
                    <asp:TextBox ID="Curriculumbrochure" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none">
                <td align="right" valign="top">
                    Show Laboratory:&nbsp;
                </td>
                <td align="left">
                    <asp:CheckBox ID="showlab" runat="server" />
                </td>
            </tr>
           
            <tr >
                <td colspan="2">
                    <b>SEO SECTION</b>
                </td>
            </tr>
         
            <tr style="display: none;" >
                <td valign="top" align="right">
                    Group Rewrite Url
                    : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="rewriteurl_group" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>

             <tr style="display: none;" >
                <td valign="top" align="right">
                   School Rewrite Url
                    : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="rewrite_url" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>

            <tr style="display: none">
                <td valign="top" align="right">
                    Canoncial Url<%--<span class="star">*</span>--%>
                    : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canoncialURL" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td valign="top" align="right">
                    <span class="star"></span>Page Title : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td valign="top" align="right">
                    <span class="star"></span>Page Meta : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageMeta" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td valign="top" align="right">
                    <span class="star"></span>Page Meta Desc : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageMetaDesc" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr >
                <td align="right" valign="top">
                    Other Schema :
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="other_schema" runat="server" Height="50px" TextMode="MultiLine"
                        Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
                <td valign="top" align="right">
                    <span class="star"></span>Canonical : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr style="display: none;">
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
