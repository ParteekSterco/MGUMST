<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

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
    <link href="/assets/css/dynamic.css" rel="stylesheet" />
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
                width: 100% !important;
                z-index: 111;
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
                    url: "/index.aspx/getgraduatecourse",
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
                var xmlDoc = $.parseXML(response.d);<asp:SqlDataSource runat="server"></asp:SqlDataSource><asp:SqlDataSource runat="server"></asp:SqlDataSource>
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
            <a href="https://erp.mgumst.org/" target="_blank" class="btn"><i class="bi bi-person"></i></a>
        </div>
        <uc2:hamburger ID="hamburger1" runat="server" />
        <uc3:search ID="search1" runat="server" />
        <main>
            <section class="main_slider_sec">
                <uc4:homebanner ID="homebanner1" runat="server" />
                <div class="home_notification" id="panelnotification" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="row g-1">
                            <div class="col-md-12 col-lg-2">
                                <h5 class="sub_title mb-lg-0 mb-4">Notifications</h5>
                            </div>
                            <div class="col-md-12 col-lg-10">
                                <div class="notification_slider owl-carousel owl-theme">
                                    <asp:Repeater ID="rptnotification" runat="server" OnItemDataBound="rptnotification_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                            <asp:Literal ID="litntypeid" runat="server" Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                            <div class="item">
                                                <div class="notify_box">
                                                    <div class="notifyDate">
                                                        <p><%#Eval("eventsdate","{0:dd MMM yyyy}")%></p>
                                                    </div>
                                                    <div class="notifycaption">
                                                        <p>
                                                            <a href="/uploads/Files/<%#Eval("uploadfile")%>" target="_blank">
                                                                <%#Eval("eventstitle")%></a>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="home_notifyStyleTwo" id="notification_multiple" runat="server" visible="false">
                    <div class="container-fluid">
                        <div class="sec_title mb-xl-4 mb-3">
                            <h5 class="sub_title mb-0">Notifications</h5>
                            <div class="titleBorder"></div>
                        </div>
                        <div class="row g-4">
                            <asp:Repeater ID="rptmultiple" runat="server">
                                <ItemTemplate>
                                    <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Literal>
                                    <asp:Literal ID="litntypeid" runat="server" Visible="false" Text='<%#Eval("ntypeid")%>'></asp:Literal>
                                    <div class="col-sm-6 col-md-4">
                                        <div class="home_notifyBox">
                                            <span><%#Eval("eventsdate","{0:dd MMM yyyy}")%></span>
                                            <p>
                                                <a href="/uploads/Files/<%#Eval("uploadfile")%>" target="_blank">
                                                    <%#Eval("eventstitle")%></a>
                                            </p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </section>
            <section class="search_sec">
                <div class="container">
                    <div class="row g-4 justify-content-center">
                        <div class="col-md-10 col-lg-6">
                            <div class="search_box txtsearch1">
                                <asp:TextBox ID="coursesearch" runat="server" class="form-control" placeholder="Find Your Course"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None" ErrorMessage="Required"
                                    ValidationGroup="cs" ControlToValidate="coursesearch"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                                    TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight"
                                    CssClass="BlockPopup" />
                                <ul id='courselist' class="wordWheel listMain" style="display: none" onclick="check();">
                                </ul>
                                <asp:LinkButton ID="LinkButton1" CssClass="btn" ValidationGroup="cs" OnClick="course_click" runat="server"><img src="/assets/images/icons/searchIcon.svg" alt="" class="img-fluid"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-md-12 col-lg-10 d-lg-block d-none">
                            <div class="search_list">
                                <asp:Repeater ID="rptcourselevel" runat="server" OnItemDataBound="rptcourselevel_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
                                        <a id="ank" runat="server"><%#Eval("levelname")%></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <a href="/course-list.aspx?mpgid=126&pgidtrail=126&levelid=all">ViewAll Programs</a>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <asp:Literal ID="litexplorecollage" runat="server"></asp:Literal>

            <asp:Literal ID="litJournal" runat="server"></asp:Literal>

            <asp:Literal ID="litlifemgmust" runat="server"></asp:Literal>

            <asp:Literal ID="litabout" runat="server"></asp:Literal>

            <asp:Literal ID="litForeignCollab" runat="server"></asp:Literal>

            <section class="MGU_event_sec">
                <div class="container">
                    <div class="row g-4">
                        <div class="col-md-5 col-lg-4">
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
                        <div class="col-md-7 col-lg-8">
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
                                        <a href="/news.aspx?mpgid=130&pgidtrail=130" class="btn_knowMore">Know More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section class="homeGallery_sec">
                <div class="container">
                    <div class="row g-4">
                        <div class="col-12">
                            <div class="sec_title text-center mb-xl-4 mb-3">
                                <h5 class="sub_title mb-xl-4 mb-3">Gallery</h5>
                                <h3 class="main_title">
                                    <asp:Literal ID="gallerytitle" runat="server"></asp:Literal>
                                </h3>
                            </div>
                        </div>
                        <asp:Repeater ID="rptgallery" runat="server" OnItemDataBound="rptgallery_ItemDataBound">
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
                            <a href="/gallery.aspx?mpgid=119&pgidtrail=132" class="btn_viewAll mt-lg-5">View All</a>
                        </div>
                    </div>
                </div>
            </section>

        </main>
        <uc5:footer ID="footer1" runat="server" />
        <uc6:mobilemenu ID="mobile1" runat="server" />

        <div class="progress-wrap">
            <svg class="progress-circle svg-content" width="100%" height="100%" viewBox="-1 -1 102 102">
                <path d="M50,1 a49,49 0 0,1 0,98 a49,49 0 0,1 0,-98"></path>
            </svg>
        </div>
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
