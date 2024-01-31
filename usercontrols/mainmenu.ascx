<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mainmenu.ascx.cs" Inherits="usercontrols_mainmenu" %>
<header class="main_header">
    <nav class="navbar">
        <div class="container-fluid">
            <div class="brand-and-icon">
                <a href="/" class="navbar-brand">
                    <img src="/assets/images/site-logo.png" alt="" class="img-fluid"></a>
            </div>
            <div class="navbar-collapse">
                <ul class="navbar-nav">
                    <asp:Repeater ID="rptmainmenu" runat="server" OnItemDataBound="rptmainmenu_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                            <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                            <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                            <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                            <li id="l1" runat="server"><a id="ank" runat="server"><%#Eval("linkname")%></a>
                                <div class="sub-menu" id="submenu" runat="server" visible="false">
                                    <div class="sub-menu-inner">
                                        <!-- item -->
                                        <div class="sub-menu-item" runat="server" visible="false" id="panelprogram">
                                            <div class="sub-menu-item-box">
                                                <h6>Browse by Level</h6>
                                                <div class="menu_grid">
                                                    <asp:Repeater ID="rptcourseslevel" runat="server" OnItemDataBound="rptcourselevel_ItemDataBound">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
                                                            <asp:Literal ID="litrewrite_url" runat="server" Visible="false" Text='<%#Eval("rewrite_url")%>'></asp:Literal>
                                                            <div class="sub-menu-item-inner">
                                                                <span><%#Eval("code")%></span>
                                                                <ul>
                                                                    <asp:Repeater ID="rptcourse" runat="server" OnItemDataBound="rptcourse_ItemDataBound">
                                                                        <ItemTemplate>
                                                                            <asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
                                                                            <asp:Literal ID="litcourseid" runat="server" Visible="false" Text='<%#Eval("courseid")%>'></asp:Literal>
                                                                            <asp:Literal ID="litrewrite_url" runat="server" Visible="false" Text='<%#Eval("rewrite_url")%>'></asp:Literal>
                                                                            <li><a id="ank" runat="server"><%#Eval("coursename")%></a></li>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>


                                                                </ul>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                            <div class="sub-menu-item-box">
                                                <h6>Browse by Colleges/Institutes</h6>
                                                <div class="menu_grid">
                                                    <div class="sub-menu-item-inner collage-menu">
                                                        <ul>
                                                            <asp:Repeater ID="rptcollagemenu" runat="server" OnItemDataBound="rptcollage_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="litcollageid" runat="server" Visible="false" Text='<%#Eval("collageid")%>'></asp:Literal>
                                                                    <li><a id="ank" runat="server"><%#Eval("collagename")%> </a></li>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- end of item -->
                                        <div class="sub-menu-item" runat="server" visible="false" id="panelacademics">
                                            <div class="sub-menu-item-box">
                                                <div class="menu_grid">
                                                    <div class="sub-menu-item-inner">
                                                        <h6>Colleges/Institutes</h6>
                                                        <ul>
                                                            <asp:Repeater ID="rptcollage" runat="server" OnItemDataBound="rptcollage_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <asp:Literal ID="litcollageid" runat="server" Visible="false" Text='<%#Eval("collageid")%>'></asp:Literal>
                                                                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewrite_url")%>'></asp:Literal>
                                                                    <li><a id="ank" runat="server"><%#Eval("collagename")%></a></li>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </div>
                                                    <div class="sub-menu-item-inner">
                                                        <asp:Repeater ID="rptinner" runat="server" OnItemDataBound="rptinner_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                                                <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                                                                <h6><a id="ank" runat="server"><%#Eval("linkname")%></a></h6>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="sub-menu-item" runat="server" visible="false" id="paneladmission">
                                            <div class="sub-menu-item-box">
                                                <div class="menu_grid">
                                                    <div class="sub-menu-item-inner">
                                                        <asp:Repeater ID="rptadmission" runat="server" OnItemDataBound="rptadmission_ItemDataBound">
                                                            <ItemTemplate>
                                                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                                                <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                                                                <h6><a id="ank" runat="server"><%#Eval("linkname")%></a></h6>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                    <div class="sub-menu-item-inner">
                                                        <div class="admission_btn">
                                                            <a <a href="https://erp.mgumst.org/Enquiry/" target="_blank">Admissions 2024</a>
                                                        </div>
                                                        <h6><a href="#">Student Support</a></h6>
                                                        <ul>
                                                            <li><a href="#">Scholarships</a></li>
                                                            <li><a href="#">Financial Assistance</a></li>
                                                            <li><a href="#">Loan Assistance</a></li>
                                                        </ul>
                                                        <div class="download_btn">
                                                            <a href="#">
                                                                <img src="assets/images/icons/pdf-small.png" alt="">
                                                                <span>Admissions 2024</span></a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <%-- 

                     <li class="dropdown_menu"><a href="#" class="menu-link">Admissions</a>
                         <div class="sub-menu">
                             <div class="sub-menu-inner">
                                 <!-- item -->
                                 <div class="sub-menu-item">

                                     <div class="sub-menu-item-box">
                                         <div class="menu_grid">
                                             <div class="sub-menu-item-inner">
                                                 <h6><a href="#">Admission Enquiry </a></h6>
                                                 <h6><a href="#">Notifications - 2023-24</a></h6>
                                                 <h6><a href="#">Admisison Procedure</a></h6>
                                                 <h6><a href="#">Admission Cell</a></h6>
                                                 <h6><a href="#">International Students Cell</a></h6>
                                                 <h6><a href="#">Lateral entry</a></h6>
                                                 <h6><a href="#">Prevention and Prohibition of Ragging</a></h6>
                                                 <h6><a href="#">Campus Visit</a></h6>
                                                 <h6><a href="#">FAQ's</a></h6>
                                             </div>
                                             <div class="sub-menu-item-inner">
                                                 <div class="admission_btn">
                                                     <a href="#">Admissions 2024</a>
                                                 </div>
                                                 <h6><a href="#">Student Support</a></h6>
                                                 <ul>
                                                     <li><a href="#">Scholarships</a></li>
                                                     <li><a href="#">Financial Assistance</a></li>
                                                     <li><a href="#">Loan Assistance</a></li>
                                                 </ul>
                                                 <div class="download_btn">
                                                     <a href="#" target="_blank">
                                                         <img src="assets/images/icons/pdf-small.png" alt="">
                                                         <span>Admissions 2024</span></a>
                                                 </div>
                                             </div>
                                         </div>
                                     </div>
                                 </div>
                                 <!-- end of item -->
                             </div>
                         </div>
                     </li>
                     <li><a href="#" class="menu-link">Research</a></li>--%>
                </ul>
            </div>
        </div>
    </nav>
</header>
