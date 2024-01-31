<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="coursedetail.aspx.cs" Inherits="coursedetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Repeater ID="rptdetail" runat="server" OnItemDataBound="rptdetail_ItemDataBound" Visible="false">
        <ItemTemplate>
            <asp:Literal ID="litcourseid" runat="server" Visible="false" Text='<%#Eval("courseid")%>'></asp:Literal>
            <asp:Literal ID="litprospectus" runat="server" Visible="false" Text='<%#Eval("coursebrochure")%>'></asp:Literal>
            <asp:Literal ID="litintership_prog" runat="server" Visible="false" Text='<%#Eval("intership_prog")%>'></asp:Literal>
            <asp:Literal ID="litshortdesc" runat="server" Visible="false" Text='<%#Eval("shortdesc")%>'></asp:Literal>
            <asp:Literal ID="lithighlights" runat="server" Visible="false" Text='<%#Eval("highlights")%>'></asp:Literal>
            <section class="course_detail_secOne">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-lg-10 col-xl-12">
                            <div class="row g-4 gy-lg-5">
                                <%#Server.HtmlDecode(Eval("eligiblitydetails").ToString())%>
                                <%#Server.HtmlDecode(Eval("feestructure").ToString())%>
                                <div class="col-sm-6 col-md-3 col-lg-3">
                                    <div class="course_detailOne_box">
                                        <p>Intake</p>
                                        <h4><%#Eval("coursedegree")%></h4>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3 col-lg-3" id="downloadpanel" runat="server" visible="false">
                                    <div class="d-flex align-items-center h-100">
                                        <a id="ankdownload" runat="server" class="brochure_btn">
                                            <img src="assets/images/icons/pdf-small.png" class="img-fluid" alt="">
                                            <!-- <img src="/uploads/prospectus/<%#Eval("coursebrochure")%>" class="img-fluid" alt=""> -->
                                            Download Brochure</a>
                                    </div>
                                </div>

                                <div class="col-12" id="paneltagline" runat="server" visible="false">

                                    <%#Server.HtmlDecode(Eval("intership_prog").ToString())%>
                                    <div class="custom_btn_group">
                                        <a href="#" class="btn_blue">Enquiry Now</a>
                                        <a href="#" class="btn_red">Apply Now</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <section class="course_detail_secTwo">
                <div class="container">
                    <div class="course_detailTwo_wraper" id="paneloverview" runat="server" visible="false">
                        <div class="row justify-content-center">
                            <div class="col-lg-10 col-xl-12">
                                <div class="sec_title mb-lg-4 mb-3">
                                    <h4 class="sub_title">Course Overview</h4>
                                </div>
                                <%#Server.HtmlDecode(Eval("shortdesc").ToString())%>
                                <div class="custom_btn_group">
                                    <a href="#" class="btn_blue">Enquiry Now</a>
                                    <a href="#" class="btn_red">Apply Now</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%#Server.HtmlDecode(Eval("highlights").ToString())%>
                    <div class="custom_btn_group mt-lg-5 mt-3 justify-content-center w-100" id="panelcareer" runat="server" visible="false">
                        <a href="#" class="btn_blue">Enquiry Now</a>
                        <a href="#" class="btn_red">Apply Now</a>
                    </div>
                </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>
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
                                <asp:Literal ID="litfid" runat="server" Visible="false" Text='<%#Eval("facultyid")%>'></asp:Literal>
                                <div class="item">
                                    <div class="facilities_item">
                                        <a id="ank" runat="server">
                                            <figure>
                                                <img src="/uploads/faculty/<%#Eval("fimage")%>" alt="" class="img-fluid w-100">
                                            </figure>
                                            <div class="facilities_caption">
                                                <h6 class="font-15 fw-bold text-blank"><%#Eval("nprefix")%> <%#Eval("fname")%></h6>
                                                <p><%#Eval("designationname")%></p>
                                                <p><%#Eval("deptname")%></p>
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
</asp:Content>

