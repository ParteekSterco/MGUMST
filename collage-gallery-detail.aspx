<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="collage-gallery-detail.aspx.cs" Inherits="collage_gallery_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="gallery_detail_sec">
    <div class="container">
        <div class="rtl-slider-flex">
            <div class="rtl-slider">
                <asp:Repeater ID="rptimage" runat="server">
                    <ItemTemplate>
                        <asp:Literal ID="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                        <div class="rtl-slider-slide">
                            <div class="row gx-lg-5 g-4">
                                <div class="col-md-6 col-lg-5">
                                    <div class="gallery_detail_big d-flex flex-column h-100 pb-md-5 justify-content-between">
                                        <h3 class="gallery_title text-black mb-lg-4 mb-3"><%#Eval("albumtitle")%></h3>
                                        <span class="d-block border-top pt-3 fw-bold font-10"><%#Eval("albumdate","{0:dd MMM yyyy}")%></span>
                                    </div>
                                </div>
                                <div class="col-md-6 col-lg-7">
                                    <figure class="mb-0 gallery_detail_img">
                                        <a href="/uploads/LargeImages/<%#Eval("uploadphoto")%>" class="showcase bi bi-arrows-fullscreen" data-rel="lightcase"></a>
                                        <img src="/uploads/LargeImages/<%#Eval("uploadphoto")%>" alt="">
                                    </figure>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </div>
    <div class="container-fluid mt-2 mb-2 p-0 m-0">
        <div class="rtl-slider-nav">
            <asp:Repeater ID="rptimagelist" runat="server">
                <ItemTemplate>
                    <asp:Literal ID="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                    <div class="rtl-slider-slide">
                        <img src="/uploads/LargeImages/<%#Eval("uploadphoto")%>" alt="">
                    </div>
                </ItemTemplate>
            </asp:Repeater>


        </div>
    </div>
</section>
</asp:Content>

