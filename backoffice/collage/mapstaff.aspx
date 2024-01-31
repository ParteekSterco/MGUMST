<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"  Theme="backtheme" AutoEventWireup="true" CodeFile="mapstaff.aspx.cs" Inherits="backoffice_collage_mapstaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script src="../../fancybox/jquery.mousewheel-3.0.4.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#various4").fancybox({
                'width': '50%',
                'height': '40%',
                'autoScale': false,
                'scrolling': 'no',
                'transitionIn': 'elastic',
                'transitionOut': 'elastic',
                'type': 'iframe'
            });
        });
    </script>
    <h2>
        Map Staff</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
            <tr bgcolor="#6E83BA">
                <td colspan="2">
                    <table id="TABLE2" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="color: #ffffff; font-size: larger; font-weight: bolder; height: 30px;
                                padding-left: 10px;" width="30%">
                                <asp:Label ID="lblcollage" runat="server"></asp:Label>
                            </td>
                            <td width="70%" align="right">
                                <a href="/backoffice/collage/viewcollage.aspx" style="color: White"><b>Back To School</b></a>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                    <asp:TextBox ID="collageid" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                        Width="80%">
                        <table id="Table4" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                            <tr>
                                <td align="left" colspan="4" height="5">
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Staff Type
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="facultyid" runat="server" AutoPostBack="True" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    &nbsp;Title
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="box" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="4" height="10">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnSearch_Click" />
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
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" width="100%">
                    <asp:Panel ID="Panel1" runat="server" GroupingText="Map Staff" CssClass="mapping"
                        Width="100%" BorderStyle="Groove">
                        <table id="Table3" border="0" cellpadding="2" cellspacing="0" width="100%">
                            <tr width="100%">
                                <td align="right">
                                </td>
                                <td align="right">
                                 Map Department:<asp:DropDownList ID="drpdept" runat="server"  AutoPostBack="True" Width="200px"
                                        OnSelectedIndexChanged="drpdept_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr width="100%">
                                <td align="left" colspan="2">
                                    <asp:DataList ID="dl_sgroup" runat="server" RepeatDirection="Horizontal" RepeatColumns="1"
                                        Width="100% " OnItemDataBound="dl_sgroup_ItemDataBound" >
                                        <ItemTemplate>
                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                <tr>
                                                  <td width="5%">
                                                   <%# Container.ItemIndex + 1%>. 
                                                  </td>
                                                  
                                                    <td width="5%">
                                                        <asp:CheckBox ID="checkfeature" runat="server" />
                                                    </td>
                                                    <td class="faculty-name" width="10%">
                                                      <asp:Label ID="lblfname" runat="server" Text='<%# Eval("fname") %>' Visible="true"></asp:Label>
                                                        <asp:Label ID="lblfacultyid" runat="server" Text='<%#(Eval("staffid")) %>' Visible="false"></asp:Label>
                                                    </td>
                                                    <td width="10%">
                                     <asp:TextBox ID="txtfacultyImage" Visible="false" runat="server" Text='<%#Eval("fimage")%>'
                                 ></asp:TextBox>
                                         <img id="imagefaculty" runat="server"  width="50"  height="50" />
                                     
                                                    </td>
                                                    <td style="display:none" width="1%"  >
                                                        Display Order:
                                                    </td>
                                                    <td  width="30%">
                                                        <asp:TextBox ID="txtdisplayorder" runat="server" Width="70px" Visible="false"></asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                                                            ControlToValidate="txtdisplayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                                                            ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>--%>
                                                        <asp:Literal ID="litralschool" runat="server"></asp:Literal>

                                                    </td>
                                                    <td width="5%"   style="display:none">
                                                        <asp:CheckBox ID="showcheck" runat="server" />
                                                    </td>
                                                    <td width="10%"  style="display:none">
                                                        Show with picture
                                                    </td>
                                                    
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Width="50%" />
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" TabIndex="15" CssClass="btnbg"
                        ValidationGroup="addnew" OnClick="btnsubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
