<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="eventsdetail.aspx.cs" Inherits="eventsdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="rptdetail" runat="server">
        <ItemTemplate>
            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
            <section class="inner_newsdetailSecOne inner_eventdetailSecOne">
                <div class="container">
                    <div class="row g-4 justify-content-end">
                        <div class="col-lg-10 col-xxl-12">
                            <div class="news_detailBox_big">
                                <span class="newsDate font-10 fw-bold d-block mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                <h3 class="news_title mb-0"><%#Eval("eventstitle")%></h3>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <figure class="mb-0">
                                <img src="/uploads/Largeimages/<%#Eval("largeimage")%>" alt="" class="img-fluid w-100">
                            </figure>
                        </div>
                    </div>
                    <%#Server.HtmlDecode(Eval("eventsdesc").ToString())%>
                </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>


    <section class="inner_newsdetailSecTwo">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-lg-11">
                    <div class="newsTwoItems_carousel owl-carousel owl-theme">
                        <asp:Repeater ID="rpteventslist" runat="server">
                            <ItemTemplate>
                                <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                <div class="item">
                                    <div class="news_item_box">
                                        <figure class="mb-0">
                                            <img src="/uploads/smallimages/<%#Eval("uploadevents")%>" alt="" class="img-fluid w-100">
                                        </figure>
                                        <div class="news_itemcaption">
                                            <span class="newsDate font-10 fw-bold d-block mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                            <p><%#Eval("eventstitle")%></p>
                                            <a href="#" class="arrowBtn stretched-link">
                                                <img src="/assets/images/icons/arrowCircleDark.svg" class="img-fluid" alt=""></a>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

