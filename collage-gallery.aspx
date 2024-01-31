<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="collage-gallery.aspx.cs" Inherits="collage_gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="inner_gallery_secOne">
    <div class="container">
        <asp:Repeater ID="rptgallerytop" runat="server" OnItemDataBound="rptgallerytop_ItemDataBound">
            <ItemTemplate>
                <asp:Literal ID="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                <asp:Literal ID="litalbumtitle" runat="server" Visible="false" Text='<%#Eval("albumtitle")%>'></asp:Literal>
                <div class="row g-0">
                    <div class="col-md-6 col-lg-6">
                        <div class="gallery_box_big">
                            <div class="gallery_box_inner">
                                <h3 class="gallery_title mb-lg-4 mb-3"><%#Eval("albumtitle")%></h3>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 col-lg-6">
                        <div class="gallery_box_img">
                            <figure class="mb-0">
                                <a id="ank" runat="server">
                                <img src="/uploads/largeimages/<%#Eval("uploadaimage")%>" alt="<%#Eval("albumid")%>" class="img-fluid w-100"></a>
                            </figure>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</section>
<section class="inner_gallery_secTwo">
    <div class="container">
        <div class="pe-xl-5 me-xl-4">
            <div class="row g-2 g-md-4 g-lg-5">
                <asp:Repeater ID="rptgallery" runat="server" OnItemDataBound="rptgallery_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                        <asp:Literal ID="litalbumtitle" runat="server" Visible="false" Text='<%#Eval("albumtitle")%>'></asp:Literal>
                        <div class="col-6 col-md-6 col-lg-4">
                            <a id="ank" runat="server">
                                <div class="gallery_small_img">
                                    <figure class="mb-0">
                                        <img src="/uploads/largeimages/<%#Eval("uploadaimage")%>" alt="<%#Eval("albumid")%>" class="img-fluid w-100">
                                    </figure>
                                </div>
                                <div class="gallery_box_small">
                                    <p><%#Eval("albumtitle")%></p>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="col-12 text-center" id="panelloadmore" runat="server" visible="false">
                    <a href="#" class="arrowBtn"><span>Load More</span>
                        <img src="/assets/images/icons/arrowCircledowndark.svg" alt=""></a>
                </div>

            </div>
        </div>
    </div>
</section>
</asp:Content>

