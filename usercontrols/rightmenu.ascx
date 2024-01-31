<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rightmenu.ascx.cs" Inherits="usercontrols_rightmenu" %>
<div class="col-md-12 col-lg-4 col-xl-3">
    <div class="side_menu_list">
        <a href="javascript:void(0)" class="Filter_btn">Filter</a>
        <div class="side_menu_inner">
        <a href="javascript:void(0)" class="close"></a>
        <ul>
            <asp:Repeater ID="rptrightmenu" runat="server" OnItemDataBound="rptrightmenu_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                    <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                    <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                </ItemTemplate>
            </asp:Repeater>


        </ul>
        </div>
    </div>
</div>
