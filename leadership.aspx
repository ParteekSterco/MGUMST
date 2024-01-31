<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/menumaster.master" AutoEventWireup="true" CodeFile="leadership.aspx.cs" Inherits="leadership" %>

<%@ Register Src="~/usercontrols/rightmenu.ascx" TagName="rightmenu" TagPrefix="ucr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row g-4">
        <asp:Repeater ID="rptleadership" runat="server" OnItemDataBound="rptleadership_ItemDataBound">
            <ItemTemplate>
                <asp:Literal ID="litteamid" runat="server" Visible="false" Text='<%#Eval("teamid")%>'></asp:Literal>
                <div class="col-sm-6 col-md-6 col-lg-6 col-xl-4">
                    <div class="leadership_bx">
                        <figure class="leadership_figure">
                            <img src="/uploads/SmallImages/<%#Eval("uploadphoto")%>" alt="<%#Eval("name")%>" class="img-fluid w-100">
                        </figure>
                        <div class="leadership_caption">
                            <h6><%#Eval("name")%></h6>
                            <p><%#Eval("designation")%></p>
                            <!-- <p><%#Eval("industries")%></p> -->
                        </div>
                        <a id="ank" runat="server" class="btn_knowMore">Read More</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>

