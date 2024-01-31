<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"
    AutoEventWireup="true" CodeFile="viewApplications.aspx.cs" Inherits="backoffice_career_viewApplications"
  Theme="backtheme"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=txtsodate.ClientID%>'));
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=txteodate.ClientID%>'));

        };
    </script>
    <script type="text/javascript">
        function printPartOfPage(elementId) {
            var printContent = document.getElementById(elementId);
            var windowUrl = 'about:blank';
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(windowUrl, windowName, 'left=50000,top=50000,width=0,height=0');

            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
     <h2>  View Posted Applications</h2>
    <div class="content-panel">
    <table align="center" border="0" cellpadding="4" cellspacing="0" width="100%">
        <tr>
            <td class="head1" colspan="2">
                
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
            <td align="center" colspan="2">
                <asp:Label ID="Label2" runat="server" SkinID="redtext" Visible="False"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="End applied date must be later start Applied Date"
                    ControlToCompare="txtsodate" ControlToValidate="txteodate" Type="Date" Operator="GreaterThan"
                    Display="Dynamic">
                </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="center" colspan="7">
                            <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                                Width="80%">
                                <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                                    <tr>
                                        <td align="left" colspan="4" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Position/Job Title:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtposition" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right" style="display:none">
                                            Experience:
                                        </td>
                                        <td align="left" style="display:none">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlminexp" runat="server" Width="55px">
                                                            <asp:ListItem Selected="True">Select</asp:ListItem>
                                                            <asp:ListItem>=</asp:ListItem>
                                                            <asp:ListItem>&gt;=</asp:ListItem>
                                                            <asp:ListItem Value="&lt;=">&lt;=</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        &nbsp;Year&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Min_Expyear" runat="server" TabIndex="6" Width="40px">
                                                        </asp:DropDownList>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;Month&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="Min_expmonth" runat="server" TabIndex="7" Width="40px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                     <tr style="display:none">
                                        <td align="right" height="10">
                                         Department :&nbsp;
                                        </td>
                                        <td align="left" colspan="3" height="10">
                                            <asp:DropDownList ID="department" runat="server" Width="200" CssClass="box">
                                            </asp:DropDownList>
                                            <%--<asp:TextBox ID="department" runat="server"></asp:TextBox>--%>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="right">
                                            Applied Date From:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtsodate" runat="server" contentEditable="off" Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtsodate"
                                                CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="right">
                                            Applied Date To:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txteodate" runat="server" contentEditable="off" Width="200px"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txteodate"
                                                CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                                ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="4" height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" CssClass="btnbg"
                                                OnClick="btnExport_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4" height="5">
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label3" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AllowPaging="true" PageSize="100"
                    AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%#((GridViewRow)Container).RowIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JobTitle" HeaderText="Job Title">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("FName")+" "+ Eval("LName")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="E-Mail">
                            <ItemTemplate>
                                <%#Eval("App_Email")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile">
                            <ItemTemplate>
                                <%#Eval("Mobile")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Trdate" HeaderText="Applied Date" DataFormatString="{0: MM/dd/yyyy}">
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Download CV">
                            <ItemTemplate>
                                <asp:Label ID="lbldown" runat="server" Text='<%#Eval("attachcv")%>' Visible="false"></asp:Label>
                                <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%#Eval("App_Id")%>'
                                    CommandName="downbtn">
                                    <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("App_Id")%>'
                                    CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="View">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkstatus1" runat="server" CausesValidation="false" CommandArgument='<%#Eval("App_Id")%>'
                                    OnClick="lnkstatus1_Click"><img border="0" src="../assets/Preview_24x24.png" alt="" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle />
                    <PagerStyle ForeColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none"
                    Height="500px" ScrollBars="Vertical" Width="900px">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <tr>
                            <td colspan="2">
                                <div id="div1">
                                    <%-- <link href="../backoffice.css" rel="stylesheet" type="text/css" />--%>
                                    <table border="1" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td class="head1">
                                                Application Detail&nbsp;- <asp:Label ID="JobTitlelbl" runat="server"></asp:Label>
                                                <asp:TextBox ID="JobTitle" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>
                                                <asp:TextBox ID="Jobid" runat="server" Visible="False" Width="31px"></asp:TextBox><asp:TextBox
                                                    ID="App_id" runat="server" Visible="False" Width="31px"></asp:TextBox>
                                                <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                            </td>
                                            <td align="right">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="middle" colspan="2" height="20">
                                                <table border="1" cellpadding="4" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="left" class="head2" colspan="4" style="height: 14px">
                                                            Personal Information :&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label53" runat="server" Font-Bold="True">First Name :</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="FNamelbl" runat="server"></asp:Label><asp:TextBox ID="FName" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>

                                                       <%-- <td align="right">
                                                            <asp:Label ID="Label14" runat="server" Font-Bold="True">Middle Name :</asp:Label>
                                                        </td>
                                                        <td align="left" colspan="3">
                                                            <asp:Label ID="MNamelbl" runat="server"></asp:Label>
                                                            
                                                            <asp:TextBox ID="MName" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
--%>
                                                       
                                                    </tr>

                                                     <tr>
                                                      <td align="right">
                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True">Last Name :</asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="LNamelbl" runat="server"></asp:Label><asp:TextBox ID="LName" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True">Father's/ Husband's Name :</asp:Label>
                                                        </td>
                                                        <td align="left" >
                                                            <asp:Label ID="lblFather_HusbandName" runat="server"></asp:Label><asp:TextBox ID="Father_HusbandName" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        
                                                    </tr>




                                                    <tr >
                                                    <td align="right">
                                                            <asp:Label ID="Label54" runat="server" Font-Bold="True">Gender :</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="Genderlbl" runat="server"></asp:Label><asp:TextBox ID="Gender" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox><span style="color: #0000ff; text-decoration: underline"></span>
                                                        </td>


                                                         <td align="right">
                                                            <strong>Marital Status :&nbsp;</strong>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblMarital" runat="server"></asp:Label><asp:TextBox ID="MaritalStatus"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>
                                                        </td>

                                                       
                                                        
                                                    </tr>


                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="True">Mobile :</asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="mobilelbl" runat="server"></asp:Label><asp:TextBox ID="mobile" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>
                                                        </td>
                                                       
                                                        <td align="right">
                                                            <asp:Label ID="Label9" runat="server" Font-Bold="True">Email :</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="emaillbl" runat="server"></asp:Label><asp:TextBox ID="App_Email" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        
                                                         <td align="right">
                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True">Date of Birth :</asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="App_DOBlbl" runat="server"></asp:Label><asp:TextBox ID="App_DOB" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>

                                                       <%-- <td align="right">
                                                            <strong>Country :&nbsp;</strong>
                                                        </td>
                                                        <td id="lblcity" align="left">
                                                            <asp:Label ID="lblcountry" runat="server"></asp:Label><asp:TextBox ID="countryname"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>
                                                        </td>--%>
                                                    </tr>
                                                    <tr>
                                                       
                                                        <td align="right" >
                                                            <strong>State :&nbsp;</strong>
                                                        </td>
                                                        <td align="left" id="lblstate" >
                                                            <asp:Label ID="Labelstate" runat="server"></asp:Label><asp:TextBox ID="state" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>
                                                        </td>
                                                         <td align="right"  >
                                                            <strong>City:</strong>
                                                        </td>
                                                        <td align="left" >
                                                            <asp:Label ID="lbl_city" runat="server"></asp:Label><asp:TextBox ID="city" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                   <tr >
                                                        <td align="right" valign="top">
                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True">Address :</asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left" colspan="3" valign="top">
                                                            <asp:TextBox ID="App_Address" runat="server" Visible="False" Width="31px"></asp:TextBox><asp:Label
                                                                ID="App_Addresslbl" runat="server"></asp:Label>&nbsp;
                                                        </td>

                                                        
                                                    </tr>
                                                    
                                                    <tr >
                                                        <td align="right" valign="top">
                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True">Message :</asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left" colspan="3" valign="top">
                                                            <asp:TextBox ID="empdetails" runat="server" Visible="False" Width="31px"></asp:TextBox><asp:Label
                                                                ID="empdetailslbl" runat="server"></asp:Label>&nbsp;
                                                        </td>

                                                        
                                                    </tr>
                                                   
                                                    <%--<tr>
                                                        <td align="left"  class="head2" colspan="4" nowrap="nowrap">
                                                            <strong>Qualification :&nbsp;</strong>
                                                        </td>
                                                        
                                                    </tr>--%>
                                                    <tr>
                                                        <td align="right" style="display:none;">
                                                           <strong>Qualification :&nbsp;</strong>
                                                        </td>
                                                        <td align="left" style="display:none;">
                                                            <asp:Label ID="qualificationslbl" runat="server"></asp:Label>
                                                            <asp:TextBox ID="App_Qualification" runat="server" Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>

                                                        <%-- <td align="right">
                                                            <strong>Title Degree :&nbsp;</strong>
                                                        </td>
                                                       <td align="left">
                                                            <asp:Label ID="lbltitledegree" runat="server"></asp:Label><asp:TextBox ID="App_Skills"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>
                                                        </td>--%>


                                                        
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="head2" colspan="4" nowrap="nowrap">
                                                            <strong>Current Employment Detail :&nbsp;</strong>
                                                        </td>
                                                        
                                                    </tr>
                                                    

                                                    
                                                    <tr>
                                                        <td align="right">
                                                            <strong>Skills :&nbsp;</strong>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="App_Skillslbl" runat="server"></asp:Label>
                                                            <asp:TextBox ID="App_Skills" runat="server" Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <strong>Experience :&nbsp;</strong>
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;<asp:Label ID="lblexp" runat="server"></asp:Label><asp:TextBox ID="App_Expyear"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>
                                                            <asp:TextBox ID="App_Expmonth" runat="server" Visible="False" Width="31px"></asp:TextBox>
                                                        </td>
                                                    </tr>


                                                    <tr>
                                                     <td align="right">
                                                            <asp:Label ID="Label8" runat="server"><strong>Name of Organization :&nbsp;</strong></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="cemployerlbl" runat="server"></asp:Label><asp:TextBox ID="cemployer"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="Label11" runat="server"><strong>Salary :&nbsp;</strong></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="csalarylbl" runat="server"></asp:Label><asp:TextBox ID="csalary" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                       
                                                    </tr>




                                                   
                                                    <tr>
                                                     <td align="right">
                                                            <asp:Label ID="Label13" runat="server"><strong>Current Industry :&nbsp;</strong></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="cindustrylbl" runat="server"></asp:Label><asp:TextBox ID="cindustry"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="lablelf" runat="server"><strong>Functional Area :&nbsp;</strong></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="funarealbl" runat="server"></asp:Label><asp:TextBox ID="funarea" runat="server"
                                                                Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                     <td align="right">
                                                            <asp:Label ID="lblpreloc" runat="server"><strong>Preferred Location :&nbsp;</strong></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            &nbsp;
                                                            <asp:Label ID="plocationlbl" runat="server"></asp:Label><asp:TextBox ID="plocation"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>
                                                        </td>
                                                        <td align="right" nowrap="nowrap">
                                                            <asp:Label ID="lblareaint1" runat="server"><strong>Area of Interest:&nbsp;</strong></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblareaint" runat="server"></asp:Label><asp:TextBox ID="Areaofintrst"
                                                                runat="server" Visible="False" Width="31px"></asp:TextBox>&nbsp;
                                                        </td>
                                                        
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" height="20">
                                <table>
                                    <tr>
                                        <td valign="top">
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btnbg"
                                                TabIndex="20" Text="Close" />
                                        </td>
                                        <td valign="top">
                                            <%--<a href="JavaScript:printPartOfPage('div1');">
                                                    <asp:Image ID="img1" runat="server" border="0" ImageUrl="~/BackOffice/assets/btn_print.gif" />
                                                </a>--%>
                                            <asp:Button ID="btprint" runat="server" CausesValidation="False" CssClass="btnbg"
                                                TabIndex="20" Text="Print" OnClientClick="JavaScript:printPartOfPage('div1');" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground"
                    CancelControlID="btnCancel" DropShadow="false" PopupControlID="Panel1" PopupDragHandleControlID="panelDragHandle"
                    TargetControlID="btnShowModalPopup">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Button ID="btnShowModalPopup" runat="server" Style="display: none" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
