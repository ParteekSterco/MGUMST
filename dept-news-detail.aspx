<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/department.master" AutoEventWireup="true" CodeFile="dept-news-detail.aspx.cs" Inherits="dept_news_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <section class="inner_newsdetailSecOne">
     <div class="container">
         <asp:Repeater ID="rptdetail" runat="server">
             <ItemTemplate>
                 <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                 <div class="row g-xl-5 g-4">
                     <div class="col-md-6 col-lg-6">
                         <div class="news_detailBox_big">
                             <span class="newsDate font-10 fw-bold d-block mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                             <h3 class="news_title mb-lg-4 mb-3"><%#Eval("eventstitle")%></h3>
                             <%#Server.HtmlDecode(Eval("shortdesc").ToString())%>
                         </div>
                     </div>
                     <div class="col-md-6 col-lg-6">
                         <div class="news_box_img">
                             <figure class="mb-0">
                                 <img src="/uploads/largeimages/<%#Eval("largeimage")%>" alt="<%#Eval("eventsid")%>" class="img-fluid w-100">
                             </figure>
                         </div>
                     </div>
                     <%#Server.HtmlDecode(Eval("eventsdesc").ToString())%>
                 </div>
             </ItemTemplate>
         </asp:Repeater>

     </div>
 </section>

 <section class="inner_newsdetailSecTwo">
     <div class="container">
         <div class="row">
             <div class="col-md-12 col-lg-11">
                 <div class="newsTwoItems_carousel owl-carousel owl-theme">
                     <asp:Repeater ID="rptnewslist" runat="server">
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
                                         <a href="#" class="arrowBtn">
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

