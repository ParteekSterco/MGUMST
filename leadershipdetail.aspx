<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/menumaster.master" AutoEventWireup="true" CodeFile="leadershipdetail.aspx.cs" Inherits="leadershipdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Repeater ID="rptdetail" runat="server">
        <ItemTemplate>
            <asp:Literal ID="litteamid" runat="server" Visible="false" Text='<%#Eval("teamid")%>'></asp:Literal>
            <div class="leader_detail ps-lg-4 mb-lg-4">
                <div class="leader_left">
                    <div class="main_leader_figure">
                        <img src="/uploads/SmallImages/<%#Eval("uploadphoto")%>" alt="<%#Eval("teamid")%>" class="img-fluid w-100">
                    </div>
                    <div class="main_leader_caption">
                        <h5><%#Eval("name")%></h5>
                        <p><%#Eval("designation ")%></p>
                        <p><%#Eval("industries")%></p>
                        <p><%#Eval("qualification")%></p>
                    </div>
                </div>
                <%#Server.HtmlDecode(Eval("detaildesc").ToString())%>
                
            </div>
            <div class="text-end btn_wrap border-top">
                <a href="leadership.aspx?mpgid=2&pgid1=7&pgidtrail=8" class="btn_back">Back</a>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

