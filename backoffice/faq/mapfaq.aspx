<%@ Page Title="" Language="VB" MasterPageFile="~/backoffice/layouts/popblank.master" ValidateRequest="false" AutoEventWireup="false" CodeFile="mapfaq.aspx.vb" Inherits="backoffice_faq_mapfaq" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <h2> Map Course</h2>
<div class="content-panel">
    <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
       <%-- <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="head1">
                            Map Course
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>--%>
    <%--    <tr>
            <td colspan="2" class="h_dot_line">
                &nbsp;
            </td>
        </tr>--%>
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
       
       
    <%--    <tr>
            <td colspan="2" align="center">--%>
         <%--   <asp:Panel ID="Panel1" runat="server"  GroupingText="Search"  Width="70%" >
                <table id="TABLE3" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                    <tr>
                        <td  align="right" >
                            Course Level
                        </td>
                        <td align="left" >
                            <asp:DropDownList ID="levelid" runat="server" Width="200px" AutoPostBack="true">
                            </asp:DropDownList>
                           
                        </td>
                        <td  align="right">
                            Branch
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="streamid" runat="server" Width="200px" AutoPostBack="true">
                              
                            </asp:DropDownList>
                         
                        </td>
                    </tr>
                </table>
                </asp:Panel>--%>
            <%--</td>
           
        </tr>--%>
       <%-- <tr>
            <td colspan="2" >
                &nbsp;
            </td>
        </tr>--%>
        <%-- <tr>
          <td align="right" style="width: 15%" valign="top">
               <b> Department</b> <span class="star"></span>:&nbsp;
            </td>
           <td align="left" style="width: 85%">


             <asp:DataList ID="dl_depart" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="80%" align="left">
                                    <asp:CheckBox ID="checkfeaturedep" runat="server" />
                                    <asp:Label ID="lbldepart" runat="server" Text='<%# eval("DeptName") %>' Visible="true"></asp:Label>
                                    <asp:Label ID="lblsubdeptid" runat="server" Text='<%# Val(eval("subdeptid")) %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
--%>

             <%--
              <b>Select Department</b>&nbsp;<asp:DropDownList ID="sdeptid" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="sdeptid" ValidationGroup="addnew" InitialValue="0"></asp:RequiredFieldValidator>--%>
           <%-- </td>
            
        </tr>--%>
<%--
         <tr >
            <td colspan="2">
                <hr />
            </td>
        </tr>
--%>
        <tr>
            <td align="right" style="width: 15%" valign="top">
                <b>Course</b> <span class="star"></span>:&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:DataList ID="dl_sgroup" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td width="80%" align="left">
                                    <asp:CheckBox ID="checkfeature" runat="server" />
                                    <asp:Label ID="lblcourse" runat="server" Text='<%# eval("coursename") %>' Visible="true"></asp:Label>
                                    <asp:Label ID="lblcourseid" runat="server" Text='<%# Val(eval("courseid")) %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr>
            
            <td colspan="2" align="center">
                <asp:Button ID="btnsubmit" runat="server" Text="Submit" TabIndex="15" CssClass="btnbg"
                    ValidationGroup="addnew" />
            </td>
        </tr>
        <tr style="display: none">
            <td align="left" colspan="2">
                <asp:Repeater ID="Repeater1" runat="server" Visible="False">
                    <ItemTemplate>
                        <asp:TextBox ID="txt1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CatId") %>'
                            Visible="false">
                        </asp:TextBox>
                        <asp:TextBox ID="txt2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "parentid") %>'
                            Visible="false">
                        </asp:TextBox>
                        <asp:TextBox ID="txt3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Depth") %>'
                            Visible="false">
                        </asp:TextBox>
                        <img height="1" width='<%# Int32.Parse(DataBinder.Eval(Container.DataItem, "Depth")) * 20 %>' />
                        <asp:LinkButton ID="lnk1" runat="server" CausesValidation="False" CommandName="edit">
												<%#DataBinder.Eval(Container.DataItem, "CatName")%>
                        </asp:LinkButton>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
