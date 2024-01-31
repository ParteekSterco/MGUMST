<%@ Page Language="C#" AutoEventWireup="true" CodeFile="map_course_prospectus.aspx.cs"
    Inherits="backoffice_Course_map_course_prospectus" Theme="backtheme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="background-color: lavender">
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="left" colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="head1">
                                    Add/Edit Course Prospectus
                                    <asp:TextBox ID="mcoursemap" runat="server" Visible="false" Width="33px"></asp:TextBox>
                                    <asp:TextBox ID="courseid" runat="server" Visible="false" Width="33px"></asp:TextBox>
                                    <asp:CheckBox ID="status" runat="server" Visible="false" Checked="true" />
                                </td>
                                <td align="right">
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
                    <td valign="top" width="15%" align="right">
                        Title<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:TextBox ID="prospectustitle" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="prospectustitle"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
                        <asp:TextBox ID="prospectusfile" runat="server" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td valign="top" width="15%" align="right">
                        Display Order<span class="star">*</span> : &nbsp;
                    </td>
                    <td width="85%">
                        <asp:TextBox ID="displayorder" runat="server" MaxLength="3"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="displayorder"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" ControlToValidate="displayorder"
                            ErrorMessage="Enter Numeric" Display="Dynamic" ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" OnClick="btnSubmit_Click" />&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp; &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50"
                            Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging"
                            OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).RowIndex + 1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Eval("prospectustitle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Publish">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status")%>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("mcoursemap") %>'
                                            CommandName="lnkstatus" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Display Order">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Eval("displayorder")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Download File">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lbldown" runat="server" Text='<%#Eval("prospectusfile")%>' Visible="false"></asp:Label>
                              <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%#Eval("mcoursemap") %>'
                                    CommandName="downbtn">
                                    <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" /></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("mcoursemap") %>'
                                            CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("mcoursemap")%>'
                                            CommandName="del" ImageUrl="~/backoffice/assets/Remove_24x24.png" ToolTip="Click to Delete" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                            TargetControlID="btndel">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
