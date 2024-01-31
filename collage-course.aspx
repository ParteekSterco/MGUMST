<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="collage-course.aspx.cs" Inherits="collage_course" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="mgu_course_sec">
    <div class="container">
        <div class="row">          
            <div class="col-lg-12">
                <div class="mgu_course_tab">
                    <div class="program_list">
                        <ul>
                            <li id="l1_all" runat="server"><a id="ankall" runat="server">All <span>Programs</span></a></li>
                            <asp:Repeater ID="rptcourselevel" runat="server" OnItemDataBound="rptcourselevel_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
                                    <li id="l1" runat="server"><a id="ank" runat="server"><%#Eval("tagname")%> <span>Programs</span></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                    <div class="course_search_box">
                        <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Find Your Course" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:LinkButton ID="lnk" runat="server" class="btn" OnClick="btnSearch">
                              <img src="/assets/images/icons/searchIcon.svg" alt="" class="img-fluid">
                        </asp:LinkButton>
                    </div>
                    <div class="mgu_course_wraper">
                        <div class="sec_title mb-lg-5 mb-4">
                            <h2 class="font-36">
                                <asp:Literal ID="litlevelname" runat="server"></asp:Literal>
                                Programs</h2>
                        </div>
                        <asp:Repeater ID="rptcourselist" runat="server" OnItemDataBound="rptcourselist_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litdpid" runat="server" Visible="false" Text='<%#Eval("dpid")%>'></asp:Literal>
                                <div class="title_bg">
                                    <h6 class="fw-bold font-15">
                                        <asp:Literal ID="litlevelname" runat="server"></asp:Literal>
                                         <%#Eval("dpname")%> in</h6>
                                </div>
                                <asp:Repeater ID="rptinner" runat="server" OnItemDataBound="rptinner_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litdpid" runat="server" Visible="false" Text='<%#Eval("dpid")%>'></asp:Literal>
                                        <asp:Literal ID="litlevelid" runat="server" Visible="false" Text='<%#Eval("levelid")%>'></asp:Literal>
                                        <asp:Literal ID="litcourseid" runat="server" Visible="false" Text='<%#Eval("courseid")%>'></asp:Literal>
                                        <div class="mgu_course_box">
                                            <div class="row">
                                                <div class="col-10 col-md-10">
                                                    <a id="ank2" runat="server">
                                                    <h5 class="font-18"><%#Eval("coursename")%></h5></a>
                                                </div>
                                                <div class="col-2 col-md-2 text-end">
                                                    <a href="#" class="arrowBtn">
                                                        <img src="/assets/images/icons/arrowCircledowndark.svg" alt="" class="img-fluid"></a>
                                                </div>
                                                <div class="col-md-4">
                                                    <p><strong>Duration</strong> <%#Eval("noofsemestor")%> years</p>
                                                </div>
                                                <div class="col-md-4">
                                                    <p><strong>Intake per Annum</strong> <%#Eval("coursedegree")%></p>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="custom_btn_group">
                                                        <a id="ank" runat="server" class="btn_blue">Enquiry Now</a>
                                                        <a id="ank1" runat="server" class="btn_red">Apply Now</a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                </div>
            </div>
        </div>
    </div>
</section>
</asp:Content>

