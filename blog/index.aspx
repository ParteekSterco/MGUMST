<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="blog_index" %>
<%@ Register Src="~/blog/usercontrols/sideblog.ascx" TagName="sideblog" TagPrefix="ucsideblog" %>
<%@ Register Src="~/blog/usercontrols/blogtopmenu.ascx" TagName="blogtopmenu" TagPrefix="ucblogtopmenu" %>
<%@ Register Src="~/blog/usercontrols/footer.ascx" TagName="footer" TagPrefix="ucfooter" %>
<%@ Register Src="~/usercontrols/seosection.ascx" TagName="seosection" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <title></title>
       <uc4:seosection ID="seosection1" runat="server" />
      <meta charset="utf-8">
      <link rel="shortcut icon" href="/blog/images/jnu-icon.png" />
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no user-scalable=no" />
      <!--------plugin css------>
      <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">
      <link rel="stylesheet" type="text/css" href="css/common.css">
      <link rel="stylesheet" type="text/css" href="css/header.css">
      <link rel="stylesheet" type="text/css" href="css/inner-page.css">
      <link rel="stylesheet" type="text/css" href="css/inner-responsive.css">
      <link rel="stylesheet" type="text/css" href="css/footer.css">
      <link rel="stylesheet" type="text/css" href="css/animate.css">
      <link rel="shortcut icon" type="image/x-icon" href="favicon.ico">
      <!-- Google Tag Manager -->
      <script async>    (function (w, d, s, l, i) {
         w[l] = w[l] || []; w[l].push({ 'gtm.start':
         new Date().getTime(), event: 'gtm.js'
         }); var f = d.getElementsByTagName(s)[0],
         j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
         'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
         })(window, document, 'script', 'dataLayer', 'GTM-58RMTCM');
      </script>
      <!-- End Google Tag Manager -->
   </head>
   <body>
      <!-- Google Tag Manager (noscript) -->
      <noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-58RMTCM"
         height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
      <!-- End Google Tag Manager (noscript) -->
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
         <div class="overlay-black"></div>
         
            <!--header section start here-->
  <header class="header group">
    <div class="container-fluid header-wrapper">
      <!-- Nav -->
      <nav class="navbar">
        <!-- Logo -->
        <div class="logo-home "> <a class="" href="/blog/index.aspx"> <img src="/images/bharati_vidyapeeth_logo.png" class="img-fluid" alt="bharati vidyapeeth"> </a> </div>
        <!-- End Logo -->
        <!-- Navigation -->
        <div id="navBar" class="navbar-menu">
          <ul>
            <li id=""> <a href="/cpage.aspx?mpgid=2&pgidtrail=6" id="">About</a> </li>
            <li id=""> <a href="/course-list.aspx?mpgid=31&pgidtrail=31&type=all" id="">Programmes</a> </li>
              <li id=""> <a href="/institutes.aspx?mpgid=21&pgidtrail=22" id="">Academics</a> </li>
            <li id=""> <a href="/cpage.aspx?mpgid=58&pgidtrail=59" id="">Research</a> </li>
            <li id=""> <a href="/alumni.aspx?mpgid=310&pgidtrail=310" id="">Alumni</a> </li>
            <li id="" class="drop-menu nav-item admission-btn"> <a href="https://bvuniversity.edu.in/apply/" target="_blank" id="">Admissions 2022</a>
               
            </li>
          </ul>
        </div>
        <!-- End Navigation -->
      </nav>
      <!-- End Nav -->
       
    </div>
  </header>
            <section class="banner">
               <img src="/blog/images/banner-2.jpg" class="lazy img-fluid w-100">
            </section>
            <!--header section end here-->
            <div class="inner-space left_scroll_down">
               <div class="container">
                  <div class="row">
                     <div class="col-md-8">
                        <div class="right_listing">
                           <h1>Our Blog</h1>
                           <asp:Repeater ID="rptblogs" runat="server" OnItemDataBound="rptblogs_ItemDataBound">
                              <ItemTemplate>
                                 <asp:Label ID="lblblogId" Visible="false" runat="server" Text='<%#Eval("blogId")%>'></asp:Label>
                                 <asp:Literal ID="litBlogImage" runat="server" Text='<%#Eval("BlogImage") %>' Visible="false"></asp:Literal>
                                 <div class="blog_part">
                                    <div class="row">
                                       <div class="col-md-12">
                                          <h3><a href="/blogs/<%#Eval("blogtitle").ToString().ToLower().Replace("  ", "-").Replace(" ", "-").Replace("--", "-").Replace("&", "").Replace("@", "").Replace("?", "") %>/<%#Eval("blogId")%>"><%# Eval("blogtitle")%> </a></h3>
                                          <div class="postmeta">
                                             <div class="post-date"><%# Eval("blogdate", "{0:MMM dd, yyyy}")%></div>
                                             <%-- <div class="post-comment"> <span>|</span> <a href="" class="no_comments">No Comments</a></div>--%>
                                             <div class="post-categories">
                                                <span>|</span>
                                                <a id="anchbcattitle" runat="server" href="" class="no_comments">
                                                   <asp:Literal Text='<%# Eval("bcattitle")%>' ID="litbcattitle" runat="server"></asp:Literal>
                                                </a>
                                                <a id="anchuncategory" runat="server" href="" class="no_comments">
                                                   <asp:Literal Text="Uncategorized" ID="litUncategorized" runat="server"></asp:Literal>
                                                </a>
                                             </div>
                                          </div>
                                       </div>
                                       <div class="col-md-4">
                                          <div class="img_blog" id="divimg" runat="server" style="background:  url(https://www.jnujaipur.ac.in/Uploads/blogs/2bs_talk-about-money.jpg) no-repeat; background-size: cover;">         
                                             <img id="imgblog" runat="server" visible="false" class="img-fluid">
                                          </div>
                                       </div>
                                       <div class="col-md-8">
                                          <asp:Literal ID="litsmalldesc" runat="server" Text='<%#Server.HtmlDecode(Eval("smalldesc").ToString())%>'></asp:Literal>
                                          <p><a href="/blogs/<%#Eval("blogtitle").ToString().ToLower().Replace("  ", "-").Replace(" ", "-").Replace("--", "-").Replace("&", "").Replace("@", "").Replace("?", "") %>/<%#Eval("blogId")%>">Read More</a></p>
                                       </div>
                                    </div>
                                 </div>
                              </ItemTemplate>
                           </asp:Repeater>
                           <%--<div class="blog_part">
                              <div class="row">
                              <div class="col-md-12">
                              <h3>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. </h3>
                              
                              <div class="postmeta">
                               <div class="post-date">June 29, 2021</div> 
                               <div class="post-comment"> <span>|</span> <a href="" class="no_comments">No Comments</a></div>
                              <div class="post-categories"> <span>|</span>
                              <a href="" class="no_comments">Engineering and Design,</a> <a href="" class="no_comments">Uncategorized</a>
                                
                                </div>
                                        
                              </div>
                              
                              </div>
                              
                              <div class="col-md-4"><img src="images/information.jpg" class="img-fluid"></div>
                              <div class="col-md-8"><p>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career.</p>
                                <p><a href="#">Read More</a></p>
                              </div>
                              </div>
                              
                              
                              </div>
                              
                              <div class="blog_part">
                              <div class="row">
                              <div class="col-md-12">
                              <h3>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. </h3>
                              
                              <div class="postmeta">
                               <div class="post-date">June 29, 2021</div> 
                               <div class="post-comment"> <span>|</span> <a href="" class="no_comments">No Comments</a></div>
                              <div class="post-categories"> <span>|</span>
                              <a href="" class="no_comments">Engineering and Design,</a> <a href="" class="no_comments">Uncategorized</a>
                                
                                </div>
                                        
                              </div>
                              
                              </div>
                              
                              <div class="col-md-4"><img src="images/information.jpg" class="img-fluid"></div>
                              <div class="col-md-8"><p>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career.</p>
                                <p><a href="#">Read More</a></p>
                              </div>
                              </div>
                              
                              
                              </div>
                              
                              <div class="blog_part">
                              <div class="row">
                              <div class="col-md-12">
                              <h3>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. </h3>
                              
                              <div class="postmeta">
                               <div class="post-date">June 29, 2021</div> 
                               <div class="post-comment"> <span>|</span> <a href="" class="no_comments">No Comments</a></div>
                              <div class="post-categories"> <span>|</span>
                              <a href="" class="no_comments">Engineering and Design,</a> <a href="" class="no_comments">Uncategorized</a>
                                
                                </div>
                                        
                              </div>
                              
                              </div>
                              
                              <div class="col-md-4"><img src="images/information.jpg" class="img-fluid"></div>
                              <div class="col-md-8"><p>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career.</p>
                                <p><a href="#">Read More</a></p>
                              </div>
                              </div>
                              
                              
                              </div>
                              
                              <div class="blog_part">
                              <div class="row">
                              <div class="col-md-12">
                              <h3>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. </h3>
                              
                              <div class="postmeta">
                               <div class="post-date">June 29, 2021</div> 
                               <div class="post-comment"> <span>|</span> <a href="" class="no_comments">No Comments</a></div>
                              <div class="post-categories"> <span>|</span>
                              <a href="" class="no_comments">Engineering and Design,</a> <a href="" class="no_comments">Uncategorized</a>
                                
                                </div>
                                        
                              </div>
                              
                              </div>
                              
                              <div class="col-md-4"><img src="images/information.jpg" class="img-fluid"></div>
                              <div class="col-md-8"><p>Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career. Information Technology (IT) is one of the popular domains of engineering which most engineering aspirants choose to make a rewarding and promising career.</p>
                                <p><a href="#">Read More</a></p>
                              </div>
                              </div>
                              
                              
                              </div>--%>
                        </div>
                        <div class="pagination-sec" id="divpaging" runat="server">
                           <nav aria-label="Page navigation">
                              <ul class="pagination">
                                 <li class="page-item" id="li_pre" runat="server" visible="false">
                                    <asp:LinkButton ID="lbtnPre" CssClass="page-link" runat="server" CausesValidation="false" OnClick="lbtnPre_Click"><span aria-hidden="true">&laquo;</span>
                                       <span class="sr-only">Previous</span>
                                    </asp:LinkButton>
                                 </li>
                                 <asp:Repeater ID="dlPaging" runat="server" OnItemCommand="dlPaging_ItemCommand" OnItemDataBound="dlPaging_ItemDataBound">
                                    <ItemTemplate>
                                       <li id="liactive" class="page-item" runat="server" >
                                          <asp:LinkButton ID="lnkbtnPaging" runat="server" CommandArgument='<%#Eval("PageIndex")%>'
                                             CommandName="Paging" CssClass="page-link" Text='<%#Eval("PageText")%>'></asp:LinkButton>
                                       </li>
                                    </ItemTemplate>
                                 </asp:Repeater>
                                 <li id="Li1" class="page-item" runat="server">
                                    <asp:LinkButton ID="lbtnNext" CssClass="page-link"  runat="server" CausesValidation="false" OnClick="lbtnNext_Click"><span aria-hidden="true">&raquo;</span>
                                       <span class="sr-only">Next</span>
                                    </asp:LinkButton>
                                 </li>
                              </ul>
                           </nav>
                        </div>
                        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                     </div>
                     <div class="col-md-4">
                        <ucsideblog:sideblog id="sideblog" runat="server"/>
                     </div>
                  </div>
               </div>
            </div>
         <!--------footer------>
         <ucfooter:footer id="footer" runat="server"/>
      </form>
      <!--------plugin js------>
      <script src="js/jquery-3.5.1.min.js" ></script>
      <script src="js/bootstrap.bundle.min.js" ></script>
      <script src="js/wow.min.js" ></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.touchswipe/1.6.19/jquery.touchSwipe.min.js"></script>
      <script src="js/main.js" ></script>
   </body>
</html>