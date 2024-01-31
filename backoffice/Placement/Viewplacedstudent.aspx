<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"  Theme="backtheme" AutoEventWireup="true" CodeFile="Viewplacedstudent.aspx.cs" Inherits="backoffice_Placement_Viewplacedstudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2> View Placement Record</h2>
<div class="content-panel">
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <table id="TABLE1" cellpadding="2" cellspacing="0" width="100%">
              
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
                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>&nbsp;
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
                                Name
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtname" runat="server" CssClass="box"></asp:TextBox>
                            </td>
                            <td align="right">
                                College 
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="schoolid" runat="server" CssClass="box" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                      
                        <tr>
                            <td align="right">
                                Session
                            </td>
                            <td align="left">
                                   <asp:DropDownList ID="Placementssession" runat="server" CssClass="box" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnbg" OnClick="btnsearch_Click" />
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
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="GridView1" runat="server" PageSize="50" AllowPaging="True" Width="100%"
                            AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                             <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                             
                                <asp:TemplateField HeaderText="Name">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("name").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <%--    <asp:TemplateField HeaderText="Course">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("coursename1").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                  <asp:TemplateField HeaderText="School">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("collagename").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Branch">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("branch").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Session">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("Placementssession").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Package">
                                    <ItemStyle HorizontalAlign="center" Width="20%" />
                                    <ItemTemplate>
                                        <%#Eval("code").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Trdate" Visible="false" DataFormatString="{0: dd/MM/yyyy}" HeaderText="Upload Date">
                                    <ItemStyle Width="6%" />
                                </asp:BoundField>
                                   <asp:TemplateField HeaderText="Photo">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <ItemTemplate>
                                        <img id="imgimage" runat="server" width="75" height="69" />
                                        <asp:Label ID="lblimage" runat="server" Text='<%#Eval("photo") %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                                    <ItemStyle Width="6%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Publish">
                                    <ItemStyle Width="6%" />    
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status")%>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("spid")%>'
                                            CommandName="lnkstatus" />
                                    </ItemTemplate>
                           
                           </asp:TemplateField>
                               <asp:TemplateField HeaderText="Show On Home" >
                                    <ItemStyle Width="6%" />    
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtshowonhome" runat="server" Text='<%#Eval("showonhome")%>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkshowonhome" runat="server" CausesValidation="false" CommandArgument='<%#Eval("spid")%>'
                                            CommandName="lnkshowonhome" />
                                    </ItemTemplate>
                           
                           </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit" >
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("spid")%>'
                                            CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemStyle Width="6%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("spid")%>'
                                            CommandName="btndel" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                            TargetControlID="btndel">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle HorizontalAlign="Right" />
                            <PagerStyle HorizontalAlign="Right" ForeColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>

</asp:Content>

