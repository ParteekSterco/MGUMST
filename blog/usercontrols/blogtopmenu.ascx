<%@ Control Language="C#" AutoEventWireup="true" CodeFile="blogtopmenu.ascx.cs" Inherits="blog_usercontrols_blogtopmenu" %>
<div class="main-menu">
    <ul>
        <li class="drop-down_menu about-menu "><a href="/admissions/important-dates" class="mm-arr Admissions-menu">Admissions
            <b>2021</b></a> </li>
        <li class="drop-down_menu about-menu"><a href="/programmes/ug-programmes" class="mm-arr">Academics</a> </li>
        <li class="drop-down_menu about-menu"><a href="/campuslife/classsrooms" class="mm-arr">Life @ JNU</a> </li>
        <li class="drop-down_menu about-menu"><a href="/about-the-university" class="mm-arr">About Us</a> </li>
        <li class="mobile_menu_sec">
            <div class="humburger-menu">
                <div class="mobile_nav group_menu">
                    <a href="javascript:void(0);" class="mobile_nav_icon"></a>
                    <div class="collapse navbar-collapse main-menu " id="navbarResponsive2">
                        <div class="others-menu">
                            <ul>
                                <li><a href="/placement/overview">Placements</a></li>
                                <li><a href="/happenings/events">Happenings</a></li>
                                <li><a href="/student-corner/student-support">Student's Corner</a></li>
                                <li><a href="/placement/testimonials">Testimonials</a></li>
                                <li><a href="/blog/index.aspx">Blog</a></li>
                                <li><a href="/academics/online-resources">Online Education through Swayam</a></li>
                                <li><a href="/career">Careers</a></li>
                                <li><a href="/admissions/downloads">Downloads</a></li>
                                <li><a href="/academics/online-resources">Online Resources</a></li>
                                <li><a href="/contact-us">Contact Us</a></li>
                            </ul>
                        </div>
                        <div class="contact-link">
                            <p>
                                <a href="tel:1800-102-1900">1800-102-1900</a></p>
                            <p>
                                <a href="mailto:info@jnujaipur.ac.in">info@jnujaipur.ac.in</a></p>
                        </div>
                        <div id="accordion">
                            <ul class="navbar-nav ml-auto">
                                <li class="nav-item-mobile only-mobile"><a href="/about-the-university" class="">About us</a></li>
                                <li class="nav-item-mobile only-mobile"><a href="/why-jnu" class="">Why</a></li>
                                <li class="nav-item-mobile only-mobile"><a class="submenu collapsed"
                                    data-toggle="collapse" data-target=".submenu0" aria-expanded="false">Academics</a>
                                    <div aria-expanded="false" class="submenu0 collapse" data-parent="#accordion" data-toggle="#accordion">
                                        <ul>
                                            <li><a href="/happenings/events">News</a></li>
                                        </ul>
                                    </div>
                                </li>
                                <li class="nav-item only-mobile"><a class="submenu collapsed" data-toggle="collapse"
                                    data-target=".submenu1" aria-expanded="false">Programmes</a>
                                    <div aria-expanded="false" class="submenu1 collapse" data-parent="#accordion" data-toggle="#accordion">
                                        <ul>
                                            <li><a href="/programmes/ug-programmes">Programmes</a></li>
                                        </ul>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </li>
    </ul>
</div>
