<%@ Page Language="C#" AutoEventWireup="true" CodeFile="collage.aspx.cs" Inherits="collage" %>

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

        <style>
            ul.wordWheel {
                background-color: #fff;
                text-align: left;
                overflow-y: scroll;
                font-size: 12px;
                color: #000;
                vertical-align: top;
                margin: 0;
                height: 250px;
                padding: 0;
                border: 1px solid #dedede;
                cursor: pointer;
                position: absolute;
                width: 100%;
                z-index: 1;
                top: 100%;
            }

                ul.wordWheel li {
                    list-style: none;
                    padding: 8px 10px;
                    margin: 0;
                    border-bottom: 1px solid #dedede;
                    -webkit-transition: all 0.32s ease-out;
                    -moz-transition: all 0.32s ease-out;
                    -o-transition: all 0.32s ease-out;
                    transition: all 0.32s ease-out;
                }

                    ul.wordWheel li:hover {
                        background: #c4b16b;
                        color: #000;
                    }
        </style>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.close').click(function () {
                    $("#clearmySound").attr('src', '');
                });
                $('.txtsearch1').keyup(function () {
                    GetGraduateCourse();
                });
                $('html').click(function () {
                    $("#courselist").attr("style", "display:none");
                });
            });
            function graduate(e) {
                $("#coursesearch").val(e.text())
                $("#courselist").attr("style", "display:none");
            }

            function SearchTerm() {
                return jQuery.trim($("[id*=coursesearch]").val());
            };
            function GetGraduateCourse() {
                $.ajax({
                    type: "POST",
                    url: "/collage.aspx/getgraduatecourse",
                    data: '{prefixText: "' + SearchTerm() + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {

                    },
                    error: function (response) {
                        // alert("Error : " + response.d);
                    }
                });
            }
            var row;
            function OnSuccess(response) {
                var row = 0;
                var xmlDoc = $.parseXML(response.d);
                <asp:SqlDataSource runat="server"></asp:SqlDataSource><asp:SqlDataSource runat="server"></asp:SqlDataSource>
                var xml = $(xmlDoc);
                var customers = xml.find("Customers");
                if (customers.length > 0) {
                    $("#courselist").removeAttr("style");
                    $('#courselist li').remove();
                    $.each(customers, function () {
                        row = row + 1;
                        var list = $("#courselist");
                        list.append('<li onClick="graduate($(this))" id="' + row + '" >' + $(this).find("coursename").text() + '</li>');
                    });
                }
                else {
                    $('#courselist li').remove();
                    $("#courselist").removeAttr("style");
                    var list = $("#courselist");
                    list.append('<li id="' + row + '" >There are no programmes found.</li>');

                }
            };
        </script>

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
                <h6 class="manu_title" id="panelinnermenu" runat="server" visible="false">
                    <a id="a1" runat="server">
                        <asp:Literal ID="littitlename" runat="server"></asp:Literal></a>
                </h6>
                <div class="manu_list">
                    <ul id="ulinnermenu" runat="server" visible="false">
                        <asp:Repeater ID="rptinnermenu" runat="server" OnItemDataBound="rptinnermenu_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                <asp:Literal ID="litcollageid" runat="server" Visible="false" Text='<%#Eval("collageid")%>'></asp:Literal>
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
                                        <asp:Literal ID="litcollageid" runat="server" Visible="false" Text='<%#Eval("collageid")%>'></asp:Literal>
                                        <li><a class="dropdown-item" id="ank" runat="server"><%#Eval("linkname")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </li>
                    </ul>
                    <div class="admission_btn">
                            <a href="https://erp.mgumst.org/Enquiry/" target="_blank">Admissions 2024</a>
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
            <!-- Search Area Start -->

            <!-- Search Area Start -->
            <section class="home_two_search_sec">
                <div class="container">
                    <div class="input-group g-4 justify-content-center">
                        <div class="col-md-12">
                            <div class="input-group align-items-center">
                                <div class="col-4 search_box txtsearch1">
                                    <asp:TextBox ID="coursesearch" runat="server" class="form-control" placeholder="Find Your Course"></asp:TextBox>                                  
                                    <ul id='courselist' class="wordWheel listMain" style="display: none" onClick="check();">
                                    </ul>
                                 <asp:LinkButton ID="LinkButton1" CssClass="btn" OnClick="course_click" runat="server"><img src="/assets/images/icons/searchIcon.svg" alt="" class="img-fluid" /></asp:LinkButton>
                                </div>
                                <h3 class="mb-0 color_04">or</h3>
                                <div class="col-3 form-group">
                                    <asp:DropDownList ID="ddlprogramtype" runat="server" class="form-select"></asp:DropDownList>
                                </div>
                                <div class="col-3 form-group">
                                    <select name="" id="" class="form-select">
                                        <option selected>Select Specialization</option>
                                        <option value=""></option>
                                    </select>
                                </div>
                                <button class="btn btn_searchNow" type="search">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                                        class="bi bi-search" viewBox="0 0 20 20">
                                        <path
                                            d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0" />
                                    </svg>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- Search Area End -->


            <asp:Literal ID="litwelcome" runat="server"></asp:Literal>

            <section class="dcms_sec" id="paneldept" runat="server" visible="false">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-md-5 col-lg-4">
                            <div class="sec_title text-center">
                                <h5 class="sub_title">Departments at <span class="d-block">
                                    <asp:Literal ID="litcollagename" runat="server"></asp:Literal>
                                </span>
                                </h5>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-0 g-4 gy-lg-5 gx-lg-5">
                        <asp:Repeater ID="rptdept" runat="server" OnItemDataBound="rptdept_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litdeptid" runat="server" Visible="false" Text='<%#Eval("deptid")%>'></asp:Literal>
                                <div class="col-sm-6 col-md-4">
                                    <div class="dcms_box">
                                        <a id="ank" runat="server">
                                            <figure class="mb-4">
                                                <img src="/uploads/banner/<%#Eval("banner")%>" alt="" class="img-fluid w-100">
                                            </figure>
                                            <h5><%#Eval("deptname")%></h5>
                                        </a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>


                        <div class="col-12 text-center" id="loadmore" runat="server" visible="false">
                            <a id="ankdept" runat="server" class="btn_viewAll">View All Departments</a>
                        </div>
                    </div>
                </div>
            </section>

            <asp:Literal ID="litmgu" runat="server"></asp:Literal>

            <!-- Events@MGUMST Area Start -->
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
            <!-- Events@MGUMST Area End -->

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
                                            <a id="ank" runat="server" visible="false" href="#" class="play_btn">
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
