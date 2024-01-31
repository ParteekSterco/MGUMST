<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" Theme="backtheme" AutoEventWireup="true" CodeFile="viewdepartment.aspx.cs" Inherits="backoffice_department_viewdepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".toptxtclg").fancybox({
                'width': '90%',
                'height': '90%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <h2>View/Edit Departments</h2>
    <div class="content-panel">
        <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
            <tr>
                <td colspan="2" class="h_dot_line">&nbsp;
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
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                        Width="80%">
                        <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                            <tr>
                                <td align="left" colspan="4" height="5"></td>
                            </tr>
                            <tr>
                                <td align="right">College:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddl_college" runat="server" Width="300px">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="campusid" runat="server" Width="300px" Visible="false"></asp:DropDownList>
                                </td>
                                <td align="right">Department: 
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="deptname" runat="server" Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"></td>
                                <td align="left"></td>
                                <td align="right"></td>
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                    <%--<asp:Button ID="btnexport" runat="server" Text="Export To Excel" Visible="false"
                                    CssClass="btnbg" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4" height="5"></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal"
                        HorizontalAlign="Center" Width="100%" AllowPaging="true" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <HeaderStyle HorizontalAlign="Left" />
                        <RowStyle HorizontalAlign="Left" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container ).DataItemIndex + 1%>
                                        .
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:BoundField DataField="deptname" HeaderText="Department" ItemStyle-Width="25%">
                            <HeaderStyle HorizontalAlign="left" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="College Name" ItemStyle-Width="25%">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%# Eval("collagename")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Department" ItemStyle-Width="25%">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%# Eval("deptname")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                                <HeaderStyle HorizontalAlign="center" Width="2%" />
                                <ItemStyle HorizontalAlign="center" VerticalAlign="top" Width="2%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Status">
                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status")%>' Visible="false"></asp:TextBox>
                                    <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("deptid")) %>'
                                        CommandName="lnkstatus"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                <ItemStyle HorizontalAlign="Center" Width="2%" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("deptid")) %>'
                                        CommandName="redit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map Course Department" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a class="toptxtclg" href='mapcoursedepartment.aspx?deptid=<%#(Eval("deptid"))%>'>
                                        <img src="../assets/Preview_24x24.png" border="0"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add Details">
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Center" Width="7%" />
                                <ItemTemplate>
                                    <a href='/backoffice/homebanner/adddeptbannertype.aspx?depbtid=<%#(Eval("deptid")) %>'>
                                        <img src="../assets/Preview_24x24.png" border="0"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle HorizontalAlign="Right" />
                        <PagerStyle HorizontalAlign="Right" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2"></td>
            </tr>
            <tr>
                <td colspan="2"></td>
            </tr>
        </table>
    </div>
    <%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

