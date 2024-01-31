<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hamburger.ascx.cs" Inherits="usercontrols_hamburger" %>
<div class="js-nav hamburger_nav">
    <div class="js-nav-menu">
        <div class="js-nav-item">
            <asp:Repeater ID="rptfirstpanel" runat="server" OnItemDataBound="rptfirstpanel_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                    <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                     <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                    <h6><%#Eval("linkname")%></h6>
                    <ul>
                        <asp:Repeater ID="rptinnerfirst" runat="server" OnItemDataBound="rptinnerfirst_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                 <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                                <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="js-nav-item">
            <asp:Repeater ID="rptsecondpanel" runat="server" OnItemDataBound="rptsecondpanel_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                    <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                     <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                    <h6><%#Eval("linkname")%></h6>
                    <ul>
                        <asp:Repeater ID="rptinnersecond" runat="server" OnItemDataBound="rptinnersecond_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                 <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                                <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="js-nav-item">
            <asp:Repeater ID="rptthirdpanel" runat="server" OnItemDataBound="rptthirdpanel_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                    <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                     <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                    <h6><%#Eval("linkname")%></h6>
                    <ul>
                        <asp:Repeater ID="rptinnerthird" runat="server" OnItemDataBound="rptinnerthrid_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                 <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                                <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rptcollage" runat="server" OnItemDataBound="rptcollage_ItemDataBound" Visible="false">
                            <ItemTemplate>
                                <asp:Literal ID="litcollageid" runat="server" Visible="false" Text='<%#Eval("collageid")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewrite_url")%>'></asp:Literal>
                                <li><a id="ank" runat="server"><%#Eval("collagename")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="js-nav-item">
            <asp:Repeater ID="rptfourpanel" runat="server" OnItemDataBound="rptfourpanel_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                    <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                     <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                    <h6><%#Eval("linkname")%></h6>
                    <ul>
                        <asp:Repeater ID="rptinnerfour" runat="server" OnItemDataBound="rptinnerfour_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                 <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                                <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>

        </div>
        <div class="js-nav-item">
            <asp:Repeater ID="rptfivepanel" runat="server" OnItemDataBound="rptfivepanel_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                    <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                     <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                    <h6><%#Eval("linkname")%></h6>
                    <ul>
                        <asp:Repeater ID="rptinnerfive" runat="server" OnItemDataBound="rptinnerfive_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                                <asp:Literal ID="litpageurl" runat="server" Visible="false" Text='<%#Eval("pageurl")%>'></asp:Literal>
                                <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                                 <asp:Literal ID="lituploadfile" runat="server" Visible="false" Text='<%#Eval("uploadfile")%>'></asp:Literal>
                                <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
            <ul>
                <li><a href="#"><strong>IQAC</strong></a></li>
                <li><a href="#"><strong>Resources</strong></a></li>
                <li><a href="#"><strong>Testimonials</strong></a></li>
                <li><a href="#"><strong>Alumni</strong></a></li>
                <li><a href="#"><strong>Careers</strong></a></li>
                <li><a href="#"><strong>Grievances</strong></a></li>
                <li><a href="#"><strong>Blog</strong></a></li>
                <li><a href="#"><strong>Cancellation & Refund policy</strong></a></li>
                <li><a href="#"><strong>Accesibility Statement</strong></a></li>
                <li><a href="#"><strong>Mandatory Disclosures</strong></a></li>
                <li><a href="/contact.aspx?mpgid=121&pgidtrail=121"><strong>Contact Us</strong></a></li>
            </ul>
        </div>
    </div>
</div>
