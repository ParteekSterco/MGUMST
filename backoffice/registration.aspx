<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="backoffice_registration" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
   
    <script type="text/javascript">
        $(document).ready(function () {
            var i = 0;
            var toappno = document.getElementById("appno").value;
            for (i = 1; i <= toappno; i++) {
                $("#various" + i).fancybox({
                    'width': '45%',
                    'height': '40%',
                    'autoScale': true,
                    'scrolling': true,
                    'transitionIn': 'elastic',
                    'transitionOut': 'elastic',
                    'type': 'iframe'
                });
            }
        });
    </script>
    <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="head1">
                View Registration
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
                <asp:Label ID="Label1" runat="server" SkinID="redtext" ForeColor="Red"></asp:Label>
              
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr height="10">
            <td align="center" colspan="2">
                <asp:Panel ID="Panel3" runat="server" DefaultButton="btnSearch" GroupingText="Search"
                    Width="80%">
                     <table id="Table3" border="0" cellpadding="2" cellspacing="0" class="panelbg" width="100%">
                        <tr>
                            <td align="left" colspan="4" height="5">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Name:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="name" runat="server" CssClass="box" meta:resourcekey="nameResource1"></asp:TextBox>
                            </td>
                            <td align="right">
                                Email Id:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="email" runat="server" Width="150px" meta:resourcekey="EmailidResource1"></asp:TextBox>
                            </td>
                        </tr>
                      
                        <tr>
                            <td align="left" colspan="4" height="10">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" 
                                    meta:resourcekey="btnSearchResource1" onclick="btnSearch_Click"
                                    />
                              
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
        <tr height="10">
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        <tr height="10">
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" 
                    AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("name") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                        <asp:TemplateField HeaderText="Father name">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("fathername")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Date of birth">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("dob")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Mobile">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("mobile")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Email">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("email")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Address">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("address")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="District">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("district")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    



                      <asp:TemplateField HeaderText="State">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("state")%>
                            </ItemTemplate>
                        </asp:TemplateField>



                          <asp:TemplateField HeaderText="Payment">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("payment")%>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField HeaderText="Payment Mode">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("paymenttype")%>
                            </ItemTemplate>
                        </asp:TemplateField>



                         <asp:TemplateField HeaderText="Event Type">
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                            <ItemTemplate>
                                <%#Eval("event")%>
                            </ItemTemplate>
                        </asp:TemplateField>




                             <asp:TemplateField HeaderText="Delete">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("applyid") %>'
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
</asp:Content>

