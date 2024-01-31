<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
        <div class="search_result">
            <div class="innerPageTitle">
                <h4>                 
                    <asp:Literal ID="litmess" runat="server"></asp:Literal>
                    <br />
                    <br />
                </h4>
            </div>        
            <ul>
                <asp:Repeater ID="rptrsearch" runat="server" OnItemDataBound="rptrsearch_ItemDataBound">
                    <ItemTemplate>
                        <li><a title="Click Here" href="/<%#Eval("pageurl")%>">
                            <%#Eval("stitle")%></a>
                            <asp:Literal ID="lbldesc" Visible="true" runat="server" Text='<%# Server.HtmlDecode(Eval("ldesc").ToString())%>'></asp:Literal>                          
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="page-num" id="divpaging" runat="server">
                <span class="prevnext" style="display: none;">
                    <asp:LinkButton ID="lbtnPre" runat="server" CssClass="prevnext" CausesValidation="false"> Previous</asp:LinkButton>
                </span>
                <asp:Repeater ID="dlPaging" runat="server" OnItemCommand="dlPaging_ItemCommand" OnItemDataBound="dlPaging_ItemDataBound">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%# Eval("PageIndex") %>'
                            CommandName="Paging" Text='<%# Eval("PageText") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
                <span class="prevnext" style="display: none">
                    <asp:LinkButton ID="lbtnNext" runat="server" CausesValidation="false">&nbsp;Next&nbsp; </asp:LinkButton>
                </span>
            </div>
        </div>
    </div>
</asp:Content>


