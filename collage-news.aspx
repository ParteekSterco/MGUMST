<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="collage-news.aspx.cs" Inherits="collage_news" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="inner_common_title">
        <div class="container">
            <div class="row align-items-center justify-content-end">
                <div class="col-md-6 col-lg-4 col-xxl-5">
                    <h1 class="font-36">
                        <asp:Literal ID="littitle" runat="server"></asp:Literal>
                    </h1>
                </div>
                <div class="col-md-6 col-lg-6 col-xxl-7 text-end">
                    <div class="select_form d-inline-block">
                        <asp:DropDownList ID="ddlyear" runat="server" class="form-select"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="inner_news_secOne">
        <div class="container">
            <div class="row g-0">
                <asp:Repeater ID="rptnews" runat="server" OnItemDataBound="rptnews_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                        <div class="col-md-6 col-lg-6">
                            <h5 class="sub_title mb-lg-4 mb-3"><%#Eval("ntype")%></h5>
                            <div class="news_box_big institute_news_box_big">
                                <div class="news_box_inner">
                                    <span class="newsDate font-10 fw-bold d-block mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                    <h3 class="news_title mb-lg-4 mb-3"><%#Eval("eventstitle")%></h3>
                                    <p>
                                        <%#Eval("tagline")%>
                                    </p>
                                    <a id="ank" runat="server" class="arrowBtn">
                                        <img src="/assets/images/icons/arrowCircleDark.svg"
                                            class="img-fluid" alt=""></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-6">
                            <div class="news_box_img mt-0">
                                <figure class="mb-0">
                                    <img src="/uploads/smallimages/<%#Eval("uploadevents")%>" alt="" class="img-fluid w-100">
                                </figure>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </section>

    <section class="inner_news_secTwo">
        <div class="container">
            <div class="pe-xl-5 me-xl-4">
                <div class="row g-4 gy-lg-5 gx-lg-5">
                    <asp:Repeater ID="rptnewslist" runat="server" OnItemDataBound="rptnewslist_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                            <div class="col-md-6 col-lg-6">
                                <div class="row g-0">
                                    <div class="col-md-5">
                                        <div class="news_small_img">
                                            <figure class="mb-0">
                                                <img src="/uploads/smallimages/<%#Eval("uploadevents")%>" alt="<%#Eval("eventsid")%>" class="img-fluid w-100">
                                            </figure>
                                        </div>
                                    </div>
                                    <div class="col-md-7">
                                        <div class="news_box_small">
                                            <span class="newsDate font-10 fw-bold d-block mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                            <p><%#Eval("eventstitle")%></p>
                                            <a id="ank" runat="server" class="arrowBtn">
                                                <img src="/assets/images/icons/arrowCircleDark.svg" class="img-fluid" alt=""></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="col-12 text-center" id="panelloadmore" runat="server" visible="false">
                        <a href="#" class="arrowBtn"><span>Load More</span>
                            <img
                                src="assets/images/icons/arrowCircledowndark.svg" alt=""></a>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="inner_event_secOne bg-white">
        <div class="container">
            <div class="inner_event_width">
                <div class="row g-4 gy-lg-5 gx-lg-5 justify-content-center">
                    <div class="col-10">
                        <h5 class="sub_title mb-lg-4 mb-3">Event</h5>
                    </div>
                    <asp:Repeater ID="rptevents" runat="server" OnItemDataBound="rptevents_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                            <div class="col-md-6 col-lg-6">
                                <div class="news_item_box">
                                    <figure class="mb-0">
                                        <img src="/uploads/smallimages/<%#Eval("uploadevents")%>" alt="<%#Eval("eventsid")%>" class="img-fluid w-100">
                                    </figure>
                                    <div class="news_itemcaption text-white">
                                        <span class="newsDate font-10 fw-bold d-block mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                        <h5 class="text-white mb-xl-4 mb-3"><%#Eval("eventstitle")%></h5>
                                        <a id="ank" runat="server" class="arrowBtn">
                                            <img src="assets/images/icons/arrowCircle.svg" class="img-fluid" alt=""></a>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>


    <section class="institute_news_secThree">
        <div class="container">
            <div class="pe-xl-5 me-xl-4">
                <div class="row g-4 gy-lg-5 gx-lg-5">
                    <asp:Repeater ID="rpteventlist" runat="server" OnItemDataBound="rpteventlist_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                            <div class="col-md-6 col-lg-6">
                                <div class="row g-0">
                                    <div class="col-md-5">
                                        <div class="news_small_img">
                                            <figure class="mb-0">
                                                <img src="/uploads/smallimages/<%#Eval("uploadevents")%>" alt="<%#Eval("eventsid")%>" class="img-fluid w-100">
                                            </figure>
                                        </div>
                                    </div>
                                    <div class="col-md-7">
                                        <div class="news_box_small">
                                            <span class="newsDate font-10 fw-bold d-block mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                            <p><%#Eval("eventstitle")%></p>
                                            <a id="ank" runat="server" class="arrowBtn">
                                                <img src="/assets/images/icons/arrowCircleDark.svg" class="img-fluid" alt=""></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="col-12 text-center" id="panellaodevents" runat="server" visible="false">
                        <a href="#" class="arrowBtn"><span>Load More</span>
                            <img
                                src="/assets/images/icons/arrowCircledowndark.svg" alt=""></a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

