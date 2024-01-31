<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="uploadtype.aspx.cs" Inherits="backoffice_download_uploadtype" Theme="backtheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<h2>Add/Edit Upload Type</h2>
<div class="content-panel">
 <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td class="head1" colspan="2" style="height: 21px">
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
                <asp:TextBox ID="UTId" runat="server" Visible="false" Width="35px"></asp:TextBox>Fields
                with <span class="star">*</span>are mandatory</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
        </tr>
        <tr style="display:none">
            <td align="right" style="width: 15%">
                Type<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DropDownList ID="downloadtimes" runat="server" CssClass="box">
                    <asp:ListItem>select</asp:ListItem>
                    <asp:ListItem>single</asp:ListItem>
                    <asp:ListItem Selected="True">multiple</asp:ListItem>
                </asp:DropDownList>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="downloadtimes"
                    Display="Dynamic" ErrorMessage="Required" InitialValue="select"></asp:RequiredFieldValidator></td>--%>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                Title<span class="star">*</span> :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="Title" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="359px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Title"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Display Order :
            </td>
            <td align="left">
                <asp:TextBox ID="displayorder" runat="server" Width="33px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                    ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                    ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Status :&nbsp;
            </td>
            <td align="left">
                <asp:CheckBox ID="status" runat="server" Checked="True" /></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            </td>
        </tr>
        <tr>
            <td style="height: 10px;">
            </td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" TabIndex="15" OnClick="btnSubmit_Click" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" Text="Cancel" CssClass="btnbg" CausesValidation="False"
                    TabIndex="16" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td align="center" height="15" colspan="2">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50" Width="80%" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                 <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                     <%--   <asp:TemplateField HeaderText="Type">
                                 <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <%#Eval("Downloadtimes")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                      
                      <asp:TemplateField HeaderText="Title">
                                  <HeaderStyle HorizontalAlign="left" Width="30%" />
                            <ItemStyle HorizontalAlign="left" VerticalAlign="top" />
                            <ItemTemplate>
                                <%#Eval("Title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publish">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                            <asp:TextBox ID="txtstatus" runat="server" Text='<%# Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("UTId") %>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("UTId") %>'
                                    CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("UTId") %>'
                                    CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
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
</asp:Content>

