<%@ Control Language="C#" AutoEventWireup="true" CodeFile="search.ascx.cs" Inherits="usercontrols_search" %>
<asp:Panel ID="Panel1" runat="server" CssClass="search" DefaultButton="LinkButton1">

    <div class="js-search">
        <div class="searchform_box">
            <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Enter Keyword"></asp:TextBox>
            <%-- <button class="srch_btn bi bi-search" type="search"></button>
           <button class="search_close btn" type="button">
                <span class="bi bi-x-lg"></span>
            </button>--%>
            <asp:LinkButton ID="LinkButton1" runat="server" class="srch_btn bi bi-search" OnClick="LinkButton1_Click"
                CausesValidation="false"></asp:LinkButton>
            <button class="search_close btn" type="button">
                <span class="bi bi-x-lg"></span>
            </button>
        </div>
    </div>
</asp:Panel>
