<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" Theme="backtheme" AutoEventWireup="true" CodeFile="view-blogs.aspx.cs" Inherits="backoffice_blogs_view_blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".toptxttag").fancybox({
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
    
<h2>View Blogs</h2>
<div class="content-panel">

    <table id="TABLE1" cellpadding="2" cellspacing="0" width="98%" language="javascript">
        <tr>
            <td class="head1" style="width: 20%">
            </td>
            <td align="right" style="width: 80%">
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
                <asp:Label ID="Label1" runat="server" SkinID="redtext"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">

                <asp:GridView ID="GridView1" runat="server" Width="100%"  OnRowCommand="GridView1_RowCommand" 
OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                            <ItemTemplate>
                              <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Blog Category" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                            <ItemTemplate>
                                <%# Eval("bcattitle")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Author" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                            <ItemTemplate>
                                <%# Eval("AutName")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Topic" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                            <ItemTemplate>
                                <%# Eval("btopstitle")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Blog" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                            <ItemTemplate>
                                <%# Eval("blogtitle")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="displayorder" HeaderText="Display Order" ItemStyle-Width="10%" />

                        <asp:BoundField DataField="blogdate" DataFormatString="{0: dd/MM/yyyy}" HeaderText="Blog Date">
                            <ItemStyle Width="5%" />
                        </asp:BoundField>

                        
                        <asp:TemplateField HeaderText="Publish">
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                            <ItemTemplate>
                             <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:Label>
                                          <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%#(Eval("blogId")) %>' CommandName="lnkstatus"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Map Tag">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Literal Text='<%# Eval("blogId")%>' ID="litsid" Visible="false" runat="server" />
                                <asp:Panel runat="server" ID="pnl_gallery" Visible="true">
                                    <a class="toptxttag" visible="false" href='mapblogtag.aspx?blogId=<%#Eval("blogId")%>'>
                                        <img border="0" src="../assets/Text Document_24x24.png" alt="" />
                                    </a>
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        
                       <asp:TemplateField HeaderText="Edit">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center"  />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false"  CommandArgument='<%#(Eval("blogId")) %>'
                                    CommandName="edit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="top" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%# Eval("blogId") %>'
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

