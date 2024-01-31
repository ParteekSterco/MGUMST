<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" Theme="backtheme" AutoEventWireup="true" CodeFile="viewfaculty.aspx.cs" Inherits="backoffice_faculty_viewfaculty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <input type="hidden" value="<%=appno%>" name="appno" id="appno">
    <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#various" + i).fancybox({
                    'width': '80%',
                    'height': '80%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#various1" + i).fancybox({
                    'width': '80%',
                    'height': '80%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            $(".toptxtresearch").fancybox({
                'width': '80%',
                'height': '80%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".toptxtfaculty").fancybox({
                'width': '80%',
                'height': '80%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>

    <h2>View/Edit Faculty</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1"></td>
                            <td align="right"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="h_dot_line">&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10"></td>
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
                        Width="80%" meta:resourcekey="Panel1Resource1">
                        <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                            <tr>
                                <td align="left" colspan="4" height="5"></td>
                            </tr>


                            <tr>
                                <td align="right">Faculty Type :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpfacultytype" runat="server" Width="280px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Faculty:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="faculty" runat="server" Width="280px"></asp:TextBox>
                                </td>

                                <td align="right">Designation :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="drpdesignation" runat="server" Width="280px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Qualification:
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtqualification" runat="server" Width="280px"></asp:TextBox>
                                </td>
                                <td align="right" style="display: none">Specialization:
                                </td>
                                <td align="left" style="display: none">
                                    <asp:TextBox ID="txtspecialization" runat="server" Width="280px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">College:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddl_college" runat="server" Width="280px">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" style="display: none">Department:
                                </td>
                                <td align="left" style="display: none">
                                    <asp:DropDownList ID="ddldepartement" AutoPostBack="true" runat="server" Width="250px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td align="right">Show Detail:
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox1" runat="server" />



                                </td>

                                <td align="right">Show With Picture:</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                </td>
                            </tr>



                            <tr>
                                <td align="left" colspan="4" height="10"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnexport" runat="server" Text="Export To Excel" Visible="false"
                                        CssClass="btnbg" />

                                    <asp:Button ID="btnupdate" runat="server" ValidationGroup="adddisplayorder" Text="Update Displayorder" CssClass="btnbg" OnClick="btnupdate_Click" />
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
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Faculty Type" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="10%" />
                                <ItemStyle HorizontalAlign="center" Width="10%" />
                                <ItemTemplate>
                                    <%#Eval("facultytype").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <HeaderStyle HorizontalAlign="center" Width="16%" />
                                <ItemStyle HorizontalAlign="center" Width="16%" />
                                <ItemTemplate>
                                    <%#Eval("nprefix")%> <%#Eval("fname").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <HeaderStyle HorizontalAlign="center" Width="10%" />
                                <ItemStyle HorizontalAlign="center" Width="10%" />
                                <ItemTemplate>
                                    <%#Eval("facultydesignation").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%-- <asp:TemplateField HeaderText="Qualification">
                            <HeaderStyle HorizontalAlign="center" Width="16%" />
                            <ItemStyle HorizontalAlign="center" Width="16%" />
                            <ItemTemplate>
                                <%#Eval("qualification").ToString()%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Specialization" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="16%" />
                                <ItemStyle HorizontalAlign="center" Width="16%" />
                                <ItemTemplate>
                                    <%#Eval("Specialization").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Photo">
                                <HeaderStyle HorizontalAlign="center" Width="10%" />
                                <ItemStyle HorizontalAlign="center" Width="10%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtfacultyImage" runat="server" Text='<%#Eval("fimage")%>'
                                        Visible="false"></asp:TextBox>
                                    <img id="imagefaculty" runat="server" width="50" height="50" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Email" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="16%" />
                                <ItemStyle HorizontalAlign="center" Width="16%" />
                                <ItemTemplate>
                                    <%#Eval("email").ToString()%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Password" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                                <ItemStyle HorizontalAlign="center" Width="7%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblpass" runat="server" Text='<%#Eval("password")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Display Order">
                                <HeaderStyle HorizontalAlign="center" Width="10%" />
                                <ItemStyle HorizontalAlign="center" Width="10%" />
                                <ItemTemplate>
                                    <%-- <%#Eval("displayorder").ToString()%>--%>
                                    <asp:TextBox ID="txtdsiplau" runat="server" Text='<%#Eval("displayorder")%>'></asp:TextBox>
                                    <asp:TextBox ID="txtfacultyid" runat="server" Visible="false" Text='<%#Eval("facultyid")%>'></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                        ControlToValidate="txtdsiplau" ErrorMessage="Enter Numeric" Display="Dynamic"
                                        ValidationExpression="^\d+?$" ValidationGroup="adddisplayorder"></asp:RegularExpressionValidator>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="displayorder" HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Publish">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                    <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%#(Eval("facultyid")) %>' CommandName="lnkstatus"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Upload Achievements" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="17%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a id='various<%# CType(Container, GridViewRow).RowIndex + 1 %>' class="toptxt" href='photoachivement.aspx?facultyid=<%# Eval("facultyid") %>'>
                                    <img border="0" src="../assets/Preview_24x24.png" alt="" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Publication File" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <a id='various1<%# CType(Container, GridViewRow).RowIndex + 1 %>' class="toptxt"
                                    visible="false" href='uploadfiledetails.aspx?facultyid=<%# Val(Eval("facultyid")) %>'>
                                    <img border="0" src="../assets/Preview_24x24.png" alt="" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Show With Picture" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblshowonhome" runat="server" Text='<%#Eval("showonhome") %>' Visible="false"></asp:Label>
                                    <asp:ImageButton ID="lnkshowonhome" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%# Eval("facultyid") %>' CommandName="lnkshowonhome"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Show on Group" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblshowonhome_campus" runat="server" Text='<%#Eval("showonhome_campus") %>' Visible="false"></asp:Label>
                                    <asp:ImageButton ID="lnkshowonhome_campus" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%# Eval("facultyid") %>' CommandName="lnkshowonhome_campus"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>



                            <asp:TemplateField HeaderText="Show Details" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblReputed" runat="server" Text='<%#Eval("showonhome_school") %>'
                                        Visible="false"></asp:Label>
                                    <asp:ImageButton ID="lnkReputed" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%# Eval("facultyid") %>' CommandName="lnkReputed"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("facultyid")) %>'
                                        CommandName="btnedit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map Campus" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Literal Text='<%# Eval("facultyid")%>' ID="litcid1" Visible="false" runat="server" />
                                    <asp:Panel runat="server" ID="pnl_research1" Visible="true">
                                        <a class="toptxtfaculty" visible="false"
                                            href='mapfacultycampus.aspx?facultyid=<%#Eval("facultyid")%>'>
                                            <img border="0" src="../assets/Preview_24x24.png" alt="" />
                                        </a>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map Research" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Literal Text='<%# Eval("facultyid")%>' ID="litcid" Visible="false" runat="server" />
                                    <asp:Panel runat="server" ID="pnl_research" Visible="true">
                                        <a class="toptxtresearch" visible="false"
                                            href='mapresearch.aspx?facultyid=<%#Eval("facultyid")%>'>
                                            <img border="0" src="../assets/Preview_24x24.png" alt="" />
                                        </a>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map Details Category" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Literal Text='<%# Eval("facultyid")%>' ID="litcid2" Visible="false" runat="server" />
                                    <asp:Panel runat="server" ID="pnl_research2" Visible="true">
                                        <a class="toptxtfaculty" visible="false"
                                            href='addfacultycat.aspx?facultyid=<%#Eval("facultyid")%>'>
                                            <img border="0" src="../assets/Preview_24x24.png" alt="" />
                                        </a>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("facultyid")) %>'
                                        CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                        TargetControlID="btndel">
                                    </ajaxToolkit:ConfirmButtonExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--    <asp:TemplateField HeaderText="Detail">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <a href='/backoffice/faculty/faculty-achievement.aspx?facultyid=<%#Val(eval("facultyid")) %>'>
                                    <img src="../assets/Preview_24x24.png" border="0"></a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>




</asp:Content>

