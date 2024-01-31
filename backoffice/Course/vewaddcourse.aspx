<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" Theme="backtheme" AutoEventWireup="true" CodeFile="vewaddcourse.aspx.cs" Inherits="backoffice_Course_vewaddcourse" %>

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
                    'width': '90%',
                    'height': '99%',
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
                    'width': '75%',
                    'height': '75%',
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
                $("#various2" + i).fancybox({
                    'width': '75%',
                    'height': '75%',
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
            $(".toptxttest").fancybox({
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
            $(".toptxtsem").fancybox({
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
    <script type="text/javascript">
        $(document).ready(function () {
            $(".toptxtmct").fancybox({
                'width': '90%',
                'height': '95%',
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
            $(".toptxtmctpros").fancybox({
                'width': '90%',
                'height': '95%',
                'autoScale': true,
                'scrolling': true,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <h2>View Course</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
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
                                <td align="right">Course Type:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ctid" runat="server" Width="200px"></asp:DropDownList>
                                    <asp:DropDownList ID="deptid" runat="server" Width="200px" Visible="false">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="campusid" runat="server" Width="200px"
                                        AutoPostBack="true" OnSelectedIndexChanged="campusid_SelectedIndexChanged" Visible="false">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">College:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="collageid" runat="server" Width="200px" OnSelectedIndexChanged="collageid_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">Course Level:
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="levelid" runat="server" Width="200px"
                                        AutoPostBack="true" OnSelectedIndexChanged="levelid_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>

                                <td align="right">Discipline:
                                </td>

                                <td align="left">
                                    <asp:DropDownList ID="dpid" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </td>

                            </tr>

                            <tr style="display: none">
                                <td align="right">Stream :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="streamid" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>

                                <td align="right">Course :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtcourse" runat="server" Width="200px"></asp:TextBox>
                                </td>
                                <td align="right"></td>
                                <td align="left"></td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" height="10"></td>
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
                <td align="center" colspan="2">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="True" PageSize="50" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                             
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="levelname" HeaderText="Course Level">
                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                <ItemStyle HorizontalAlign="left" Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="dpname" HeaderText="Discipline">
                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                <ItemStyle HorizontalAlign="left" Width="10%" />
                            </asp:BoundField>

                            <asp:BoundField DataField="ctypename" HeaderText="Course Type" Visible="false">
                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                <ItemStyle HorizontalAlign="left" Width="10%" />
                            </asp:BoundField>


                            <%--<asp:TemplateField HeaderText="School" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="12%" />
                            <ItemStyle HorizontalAlign="Center"  Width="12%" />
                            <ItemTemplate>
                                <asp:Label ID="lblcollagename" runat="server" Text='<%#Eval("collagename")%>' Visible="true"></asp:Label>
                             
                            </ItemTemplate>
                        </asp:TemplateField>--%>



                            <asp:TemplateField HeaderText="Stream" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblStreamname" runat="server" Text='<%#Eval("streamname")%>' Visible="true"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:BoundField DataField="DeptName" HeaderText="Department" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ctypename" HeaderText="Course Type">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="coursename" HeaderText="Course">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Download File" Visible="false">
                                <ItemStyle Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lbldown" runat="server" Text='<%#Eval("prospectus") %>'
                                        Visible="false"></asp:Label>
                                    <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%# (Eval("courseid")) %>'
                                        CommandName="downbtn">
                                        <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" />
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                                <HeaderStyle HorizontalAlign="center" Width="7%" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Color" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="5%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblcolor" runat="server" Text='<%#Eval("colorcode")%>' Visible="false"></asp:Label>
                                    <input id="txtcolor" runat="server" style="border-style: none" class="txtbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Publish">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                    <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%#(Eval("courseid")) %>' CommandName="lnkstatus"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Show Home" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblshowonhome" runat="server" Text='<%#Eval("showonhome") %>' Visible="false"></asp:Label>
                                    <asp:ImageButton ID="lnkshowonhome" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%#Eval("courseid") %>' CommandName="lnkshowonhome"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Apply Online" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblapplyonline" runat="server" Text='<%#Eval("showlab") %>' Visible="false"></asp:Label>
                                    <asp:ImageButton ID="lnkapplyonline" CssClass="toptxt" runat="server" CausesValidation="false"
                                        CommandArgument='<%#Eval("courseid") %>' CommandName="lnkapplyonline"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("courseid")) %>'
                                        CommandName="btnedit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map Testimonials" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Literal Text='<%# Eval("courseid")%>' ID="litcid" Visible="false" runat="server" />
                                    <asp:Panel runat="server" ID="pnl_gallery" Visible="true">
                                        <a class="toptxttest" visible="false"
                                            href='mapcourse_testimonials.aspx?courseid=<%#Eval("courseid")%>'>
                                            <img border="0" src="../assets/Preview_24x24.png" alt="" />
                                        </a>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map Faculty" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a class="toptxtsem" href='mapcourse_faculty.aspx?courseid=<%#(Eval("courseid"))%>'>
                                        <img src="../assets/Preview_24x24.png" border="0"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map College" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a class="toptxtclg" href='mapcoursecollege.aspx?courseid=<%#(Eval("courseid"))%>'>
                                        <img src="../assets/Preview_24x24.png" border="0"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Map CourseType" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a class="toptxtmct" href='mapcoursetype.aspx?courseid=<%#(Eval("courseid"))%>'>
                                        <img src="../assets/Preview_24x24.png" border="0"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add Prospectus" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <a class="toptxtmctpros" href='map_course_prospectus.aspx?courseid=<%#(Eval("courseid"))%>'>
                                        <img src="../assets/Preview_24x24.png" border="0"></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="9%" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("courseid")) %>' CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
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

