<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" Theme="backtheme" AutoEventWireup="true" CodeFile="viewcoursedetails.aspx.cs" Inherits="backoffice_collage_viewcoursedetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



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
     <h2>View Course</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td colspan="2" class="h_dot_line">
                &nbsp;
            </td>
        </tr>
       
            <tr bgcolor="#6E83BA" id="tr1" runat="server" visible="false">
                <td colspan="2">
                    <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                padding-left: 10px;" width="30%">
                                <asp:Label ID="lblcollage" runat="server"></asp:Label>
                            </td>
                            <td width="70%" align="right">
                                <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To Colleges/Institutes</b></a>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
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
                <td align="center" colspan="2" style="height: 23px">
                    <asp:Label ID="Label1" runat="server" SkinID="redtext"></asp:Label>
                    <asp:TextBox ID="collageid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                    <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Programme Level:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="levelid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>

                            <td align="right">
                                Course Type:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ctid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                        <tr>
                         <td align="right">
                                Discipline:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="dpid" runat="server" Width="200px" >
                                </asp:DropDownList>
                            </td>

                            <td align="right" style="display:none">
                                Department
                            </td>
                            <td align="left" style="display:none">
                                <asp:DropDownList ID="deptid" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="right" >
                                Course
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtcourse" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
                                <%--<asp:Button ID="btnexport" runat="server" Text="Export To Excel" Visible="false"
                                    CssClass="btnbg" />--%>
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
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowPaging="True" PageSize="50" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" >
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                              <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:BoundField DataField="ctypename" HeaderText="Course Type" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                         <asp:BoundField DataField="coursename" HeaderText="Course">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="levelname" HeaderText="Programme Level">
                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="dpname" HeaderText="Discipline">
                            <HeaderStyle HorizontalAlign="left" Width="10%" />
                            <ItemStyle HorizontalAlign="left" Width="10%" />
                        </asp:BoundField>
                         <asp:TemplateField HeaderText="School" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="12%" />
                            <ItemStyle HorizontalAlign="Center"  Width="12%" />
                            <ItemTemplate>
                                <asp:Label ID="lblcollagename" runat="server" Text='<%#Eval("collagename")%>' Visible="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Stream" Visible="false" >
                            <HeaderStyle HorizontalAlign="Center" Width="12%" />
                            <ItemStyle HorizontalAlign="Center"  Width="12%" />
                            <ItemTemplate>
                                <asp:Label ID="lblStreamname" runat="server" Text='<%#Eval("streamname")%>' Visible="true"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DeptName" HeaderText="Department" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="15%" />
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Download File" Visible="false">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lbldown" runat="server" Text='<%#Eval("prospectus") %>'
                                    Visible="false"></asp:Label>
                                <asp:LinkButton ID="downbtn" runat="server" CausesValidation="false" CommandArgument='<%# (Eval("csid")) %>'
                                    CommandName="downbtn">
                                    <asp:Image ID="imgDown" runat="server" BorderWidth="0" ImageUrl="~/backoffice/assets/Download_24x24.png" /></asp:LinkButton>
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
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("s") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("csid")) %>' CommandName="lnkstatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Show Home" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblshowonhome" runat="server" Text='<%#Eval("showonhome") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkshowonhome" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("csid") %>' CommandName="lnkshowonhome"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Apply Online" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblapplyonline" runat="server" Text='<%#Eval("showlab") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkapplyonline" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#Eval("csid") %>' CommandName="lnkapplyonline"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="12%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("csid")) %>'
                                    CommandName="btnedit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>







                    

                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" Width="9%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("csid")) %>'
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

