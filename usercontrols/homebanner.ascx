<%@ Control Language="C#" AutoEventWireup="true" CodeFile="homebanner.ascx.cs" Inherits="usercontrols_homebanner" %>
<div class="home_slider owl-carousel owl-theme">
    <asp:Repeater ID="rptbanner" runat="server">
        <ItemTemplate>
            <asp:Literal ID="litbid" runat="server" Visible="false" Text='<%#Eval("bid")%>'></asp:Literal>
            <asp:Literal ID="litblogo" runat="server" Visible="false" Text='<%#Eval("blogo")%>'></asp:Literal>
            <asp:Literal ID="litbtype" runat="server" Visible="false" Text='<%#Eval("btype")%>'></asp:Literal>
            <div class="item">
                <div class="row justify-content-end align-items-center">
                    <div class="col-md-5">
                        <%#Server.HtmlDecode(Eval("tagline1").ToString())%>
                    </div>
                    <div class="col-md-6">
                        <div class="slider_figure">
                            <div class="admission_btn">
                                <a href="#">Admissions 2024</a>
                            </div>
                            <picture>
                                <source media="(min-width:700px)" srcset="/uploads/banner/<%#Eval("bannerimage")%>">
                                <source media="(min-width:200px)" srcset="/uploads/banner/<%#Eval("bannerimage")%>">
                                <img src="/uploads/banner/<%#Eval("bannerimage")%>" alt="" class="img-fluid">
                            </picture>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


</div>
