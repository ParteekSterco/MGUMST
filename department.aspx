<%@ Page Language="C#" AutoEventWireup="true" CodeFile="department.aspx.cs" Inherits="department" %>

<!DOCTYPE html>
<%@ Register Src="~/usercontrols/mainmenu.ascx" TagName="mainmenu" TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/hamburger.ascx" TagName="hamburger" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/search.ascx" TagName="search" TagPrefix="uc3" %>
<%@ Register Src="~/usercontrols/homebanner.ascx" TagName="homebanner" TagPrefix="uc4" %>
<%@ Register Src="~/usercontrols/footer.ascx" TagName="footer" TagPrefix="uc5" %>
<%@ Register Src="~/usercontrols/mobilemenu.ascx" TagName="mobilemenu" TagPrefix="uc6" %>
<%@ Register Src="~/usercontrols/seosection.ascx" TagName="seosection" TagPrefix="uc7" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <uc7:seosection ID="seosection1" runat="server" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="description" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link type="text/css" href="/assets/css/homepage.css" rel="stylesheet">
    <link type="text/css" href="/assets/css/responsive.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                    <asp:ScriptReference Name="Common.Common.js" Assembly="AjaxControlToolkit" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>
        <uc1:mainmenu ID="mainmenu" runat="server" />
        <div class="sideMenu_btns">
            <button class="js-hamburger btn" type="button">
                <span class="bi bi-list bars"></span>
            </button>
            <a href="#" class="btn"><i class="bi bi-info-circle"></i></a>
            <button class="search_hamburger btn" type="button">
                <span class="bi bi-search srch"></span>
            </button>
            <a href="#" class="btn"><i class="bi bi-person"></i></a>
        </div>
        <uc2:hamburger ID="hamburger1" runat="server" />
        <uc3:search ID="search1" runat="server" />
        <div class="inner_menu">
            <div class="container-fluid">
                <h6 class="manu_title" id="panelinnermenu" runat="server" visible="true">
                    <a id="a1" runat="server">
                        <asp:Literal ID="littitlename" runat="server"></asp:Literal></a>
                </h6>
                <h6 class="manu_title" id="paneldept" runat="server" visible="false">
                    <a id="a2" runat="server">
                        <asp:Literal ID="litdeptname" runat="server"></asp:Literal></a>
                </h6>
                <div class="manu_list">
                    <ul id="ulinnermenu" runat="server" visible="false">
                        <asp:Repeater ID="rptinnermenu" runat="server" OnItemDataBound="rptinnermenu_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                <asp:Literal ID="litdeptid" runat="server" Visible="false" Text='<%#Eval("deptid")%>'></asp:Literal>
                                <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <li class="dropdown" id="l1_menu" runat="server" visible="false">
                            <a class="btn btn-secondary dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false"></a>
                            <ul class="dropdown-menu">
                                <asp:Repeater ID="rptdropdownmenu" runat="server" OnItemDataBound="rptdropdownmenu_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                        <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                        <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                        <asp:Literal ID="litdeptid" runat="server" Visible="false" Text='<%#Eval("deptid")%>'></asp:Literal>
                                        <li><a class="dropdown-item" id="ank" runat="server"><%#Eval("linkname")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <div class="admission_btn">
                        <a href="#">Admissions 2024</a>
                    </div>
                </div>
            </div>
        </div>
        <main>
            <section class="main_slider_sec" id="panelbanner" runat="server" visible="true">
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
            </section>
            <asp:Literal ID="litdeptabout" runat="server"></asp:Literal>
            <!-- Search Area Start -->

            <section class="facilities_sec" id="panelfaculty" runat="server" visible="false">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <div class="sec_title text-center mb-lg-5 mb-3">
                                <h4 class="sub_title">Our Faculties</h4>
                            </div>
                            <div class="facilities_carousel owl-carousel owl-theme">
                                <asp:Repeater ID="rptfaculty" runat="server" OnItemDataBound="rptfaculty_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litfacultyid" runat="server" Visible="false" Text='<%#Eval("facultyid")%>'></asp:Literal>
                                        <div class="item">
                                            <div class="facilities_item">
                                                <a id="ank" runat="server">
                                                    <figure>
                                                        <img src="/uploads/faculty/<%#Eval("fimage")%>" alt="" class="img-fluid w-100">
                                                    </figure>
                                                    <div class="facilities_caption">
                                                        <h6 class="font-15 fw-bold text-blank"><%#Eval("nprefix")%> <%#Eval("fname")%></h6>
                                                        <p><%#Eval("designationname")%></p>
                                                        <p><%#Eval("departmentname")%></p>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>


                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <asp:Literal ID="litmgu" runat="server"></asp:Literal>

            <section class="MGU_event_sec" id="panelmain" runat="server" visible="false">
                <div class="container">
                    <div class="row g-4">
                        <div class="col-md-5 col-lg-4" id="panelevents" runat="server" visible="false">
                            <div class="sec_title mb-xl-4 pb-lg-3 mb-3">
                                <h5 class="sub_title">Events@MGUMST</h5>
                            </div>
                            <asp:Repeater ID="rptevents" runat="server" OnItemDataBound="rptevents_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                    <div class="MGU_event_left">
                                        <figure class="mb-0">
                                            <img src="/uploads/smallimages/<%#Eval("uploadevents")%>" alt="" class="img-fluid w-100">
                                        </figure>
                                        <div class="mguEvent_leftCaption bg_01">
                                            <span class="text-white d-block font-10 mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                            <h5 class="text-white mb-xl-4 mb-3"><%#Eval("eventstitle")%></h5>
                                            <a id="ank" runat="server" class="arrowBtn">
                                                <img src="/assets/images/icons/arrowCircle.svg" alt=""></a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="col-md-7 col-lg-8" id="panelnews" runat="server" visible="false">
                            <div class="MGU_event_right ps-xl-5 ps-lg-3">
                                <div class="sec_title mb-xl-4 pb-lg-3 mb-3">
                                    <h5 class="sub_title">Recent News</h5>
                                </div>
                                <div class="row gy-lg-5 gy-4">
                                    <asp:Repeater ID="rptnews" runat="server" OnItemDataBound="rptnews_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                            <div class="col-sm-6 col-lg-6">
                                                <div class="news_box">
                                                    <span class="text-dark d-block font-10 mb-xl-4 mb-3"><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                                    <h6 class="text-dark mb-xl-4 mb-3 font-14"><%#Eval("eventstitle")%></h6>
                                                    <a id="ank" runat="server" class="arrowBtn">
                                                        <img src="/assets/images/icons/arrowCircleDark.svg"
                                                            alt="<%#Eval("eventsid")%>"></a>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                    <div class="col-12">
                                        <a href="#" class="btn_knowMore">Know More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- Gallery Area Start -->
            <section class="homeGallery_sec homeGallery_secTwo" id="panelgallery" runat="server" visible="false">
                <div class="container">
                    <div class="row g-4">
                        <div class="col-12">
                            <div class="sec_title text-center mb-xl-4 mb-3">
                                <h5 class="sub_title mb-xl-4 mb-3">Gallery</h5>
                                <h3 class="main_title">
                                    <asp:Literal ID="gallerytitle" runat="server"></asp:Literal></h3>
                            </div>
                        </div>
                        <asp:Repeater ID="rptgallery" runat="server">
                            <ItemTemplate>
                                <asp:Literal ID="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                                <asp:Literal ID="littypeid" runat="server" Visible="false" Text='<%#Eval("typeid")%>'></asp:Literal>
                                <asp:Literal ID="litalbumtitle" runat="server" Visible="false" Text='<%#Eval("albumtitle")%>'></asp:Literal>
                                <div class="col-md-4 col-lg-4">
                                    <div class="gallery_box">
                                        <figure class="mb-3">
                                            <img src="/uploads/LargeImages/<%#Eval("uploadaimage")%>" alt="" class="img-fluid w-100">
                                            <a id="ank" runat="server" visible="false" class="play_btn">
                                                <img src="/assets/images/icons/play.png" alt=""></a>
                                        </figure>
                                        <div class="ms-lg-3">
                                            <a id="a1" runat="server">
                                                <p><%#Eval("albumtitle")%></p>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="col-12 text-center">
                            <a id="ank" runat="server" class="btn_viewAll">View All</a>
                        </div>
                    </div>
                </div>
            </section>
        </main>
        <uc5:footer ID="footer1" runat="server" />
        <uc6:mobilemenu ID="mobilemenu1" runat="server" />

        <script src="/assets/js/jquery-3.7.1.min.js"></script>
        <script src="/assets/js/jquery.min.js"></script>
        <script src="/assets/js/bootstrap.bundle.min.js"></script>
        <script src="/assets/js/wow.min.js"></script>
        <script src="/assets/js/lightcase.js"></script>
        <script src="/assets/js/slick.js"></script>
        <script src="/assets/js/owl.carousel.min.js"></script>
        <script src="/assets/js/SmoothScroll.min.js"></script>
        <script src="/assets/js/custom.js"></script>
    </form>
</body>
</html>
