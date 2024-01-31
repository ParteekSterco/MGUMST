<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"
    Theme="backtheme" AutoEventWireup="true" CodeFile="Placedstudents.aspx.cs" ValidateRequest="false" Inherits="backoffice_Placement_Placedstudents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Placement Record</h2>
    <div class="content-panel">
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <contenttemplate>--%>
        <asp:Panel ID="panel1" runat="server" DefaultButton="btnSubmit">
            <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td class="head1">
                        &nbsp;
                        <asp:TextBox ID="spid" runat="server" Visible="False" Width="33px"></asp:TextBox>
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
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right" style="width: 15%">
                        Year<span class="star"></span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:DropDownList ID="session" runat="server" Width="200px">
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="session"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                 <tr >
                    <td align="right" style="width: 15%" valign="top">
                        School:<span class="star"></span>&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:DropDownList ID="schoolid" runat="server" Width="250px" AutoPostBack="false">
                        </asp:DropDownList>
                  <%--     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="schoolid"
                            Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Name<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:TextBox ID="Name" runat="server" Width="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                            ControlToValidate="Name" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr >
                    <td align="right" style="width: 15%" valign="top">
                        Branch:<span class="star">*</span>&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:TextBox ID="branch" runat="server" Width="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="branch"
                    Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Placements Session<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                       <%-- <asp:DropDownList ID="Placementssession" runat="server" Width="250px">
                        </asp:DropDownList>--%>
                       
                           <asp:TextBox ID="Placementssession" runat="server"  Width="250" ></asp:TextBox>
                     <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Placementssession"
                            Display="Dynamic" InitialValue="0" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr style="display:none">
                    <td align="right" style="width: 15%">
                        Year<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:TextBox ID="year" runat="server" Width="250"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="year"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr >
                    <td align="right" style="width: 15%" valign="top">
                        Package:<span class="star">*</span>&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:TextBox ID="code" runat="server" Width="250"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="code"
                    Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
               
                <tr style="display:none">
                    <td align="right" style="width: 15%" valign="top">
                        Course:<span class="star">*</span>&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:DropDownList ID="Course" runat="server" Width="250px" AutoPostBack="false">
                        </asp:DropDownList>
                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Course"
                            Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <%-- <tr >
                        <td align="right" style="width: 15%" valign="top">
                           Session:&nbsp;
                        </td>
                        <td align="left" style="width: 85%">
                            <asp:TextBox ID="session" runat="server" Width="250" ></asp:TextBox>
                        </td>
                    </tr>--%>
                <tr>
                    <td align="right" style="width: 15%" valign="top">
                        company:&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:TextBox ID="company" runat="server" Width="250"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        Upload Photo<span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:FileUpload ID="File1" runat="server" />
                        <asp:Label ID="lbdimestion" runat="server" Text="Size(1350X660)" ForeColor="Red"></asp:Label>
                        <br />
                        <asp:Label ID="lblapl" runat="server" Text="" Font-Italic="true" ForeColor="#ff0000"></asp:Label>
                        <asp:TextBox ID="photo" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                    </td>
                    <td align="left" style="width: 85%">
                        <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
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
                        <asp:CheckBox ID="status" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        Show On Home :&nbsp;
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="showonhome" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left" height="10">
                    </td>
                </tr>
                <tr style="display: none">
                    <td colspan="2">
                        <b>SEO SECTION</b>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right">
                        <span class="star"></span>Page Title : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right">
                        <span class="star"></span>Page Meta : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="PageMeta" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right">
                        <span class="star"></span>Page Meta Desc : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="PageMetaDesc" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td valign="top" align="right">
                        <span class="star"></span>Canonical : &nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right" valign="top">
                        No Index Follow :
                    </td>
                    <td align="left" valign="top">
                        <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
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
                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                            TabIndex="15" CssClass="btnbg" />
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                            CausesValidation="False" TabIndex="16" CssClass="btnbg" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <%-- </contenttemplate>
    <triggers>
            <asp:PostBackTrigger ControlID="btnSubmit" />
        </triggers>
</asp:UpdatePanel>--%>
    </div>
</asp:Content>
