 <%@ Page Title="" Language="C#" MasterPageFile="~/blog/layouts/blogmaster.master"
    AutoEventWireup="true" CodeFile="blog_details.aspx.cs" Inherits="blog_blog_details" %>


<%@ Register Src="~/blog/usercontrols/sideblog.ascx" TagName="sideblog" TagPrefix="ucsideblog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="inner-space left_scroll_down inner_page_top">
        <div class="container">
            <div class="row">
                <div class="col-md-8">
                    <div class="right_listing blog-detail">
                        <div class="blog_part border-bottom-0">
                         <asp:Repeater ID="repblogdetails" runat="server" OnItemDataBound="repblogdetails_ItemDataBound">
            <ItemTemplate>
            <asp:Literal ID="litBlogImage" runat="server" Text='<%#Eval("BlogImage") %>' Visible="false"></asp:Literal>
                            <div class="row">
                                <div class="col-md-12">
                                    <h1>
                                       <%# Eval("blogtitle")%>
                                    </h1>
                                    <div class="postmeta">
                                        <div class="post-date">
                                            <%# Eval("blogdate", "{0:MMM dd, yyyy}")%></div>
                                       <%-- <div class="post-comment">
                                            <span>|</span> <a href="" class="no_comments">No Comments</a></div>--%>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <p>
                                        <img id="imgblog" runat="server" class="img-fluid w-100"></p>
                                </div>
                                 <asp:Literal ID="litlongdesc" runat="server" Text='<%#Server.HtmlDecode(Eval("longdesc").ToString())%>'></asp:Literal>
                                <%--<div class="col-md-12">
                                    <p>
                                        <img src="/blog/images/information1.jpg" class="img-fluid"></p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career.
                                    </p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career.</p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career. Information Technology
                                        (IT) is one of the popular domains of engineering which most engineering aspirants
                                        choose to make a rewarding and promising career.
                                    </p>
                                </div>
                                <div class="col-md-6">
                                    <p>
                                        <img src="/blog/images/information1.jpg" class="img-fluid"></p>
                                </div>
                                <div class="col-md-6">
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career..</p>
                                </div>
                                <div class="col-md-12">
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career. Information Technology
                                        (IT) is one of the popular domains of engineering which most engineering aspirants
                                        choose to make a rewarding and promising career.</p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career. Information Technology
                                        (IT) is one of the popular domains of engineering which most engineering aspirants
                                        choose to make a rewarding and promising career.</p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career.</p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career. Information Technology
                                        (IT) is one of the popular domains of engineering which most engineering aspirants
                                        choose to make a rewarding and promising career.</p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career. Information Technology
                                        (IT) is one of the popular domains of engineering which most engineering aspirants
                                        choose to make a rewarding and promising career.</p>
                                    <p>
                                        Information Technology (IT) is one of the popular domains of engineering which most
                                        engineering aspirants choose to make a rewarding and promising career. Information
                                        Technology (IT) is one of the popular domains of engineering which most engineering
                                        aspirants choose to make a rewarding and promising career.</p>
                                </div>--%>
                            </div>
                            </ItemTemplate>
                            </asp:Repeater>
                        </div>
                         <div class="button-list">
                        <div class="back-btn">
                            <a href="javascript:history.go(-1)">
                                <img src="/images/arrow-y.svg">
                                Back</a></div>
                    </div>
                    </div>
                   
                   
            
                </div>
                <div class="col-md-4">
                    <ucsideblog:sideblog ID="sideblog" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
