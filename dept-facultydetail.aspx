<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/department.master" AutoEventWireup="true" CodeFile="dept-facultydetail.aspx.cs" Inherits="dept_facultydetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Repeater ID="rptdetail" runat="server">
        <ItemTemplate>
            <asp:Literal ID="litfacultyid" runat="server" Visible="false" Text='<%#Eval("facultyid")%>'></asp:Literal>
            <section class="departFaculties_dtl_sec">
                <div class="container">
                    <div class="row g-4">
                        <div class="col-md-4 col-lg-4">
                            <div class="faculAauth_left">
                                <div class="faculAauth_dtl">
                                    <h1 class="font-36"><%#Eval("nprefix")%> <%#Eval("fname")%></h1>
                                    <p><%#Eval("designationname")%></p>
                                    <p><%#Eval("deptname")%></p>
                                </div>
                                <figure class="mb-0">
                                    <img src="/uploads/faculty/<%#Eval("fimage")%>" alt="" class="img-fluid w-100">
                                </figure>
                            </div>
                        </div>
                        <div class="col-md-8 col-lg-8">
                            <div class="faculAauth_right ps-lg-3">
                                <div class="faculAauth_discription">
                                    <%#Server.HtmlDecode(Eval("fdetail").ToString())%>
                                  </div>
                               
                                <div class="faculAauth_rightDtl">
                                    <div class="row g-4">
                                        <div class="col-md-6">
                                            <h6>Experience</h6>
                                            <p><%#Eval("yearsofexperience")%></p>
                                        </div>                                    
                                        <div class="col-md-6">
                                            <h6>Qualification</h6>
                                            <p><%#Eval("Qualification")%></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-5">
                            <div class="faculAauth_social">
                                <ul>
                                    <li><a href="mailto:<%#Eval("email")%>" target="_blank"><span class="bi bi-envelope-fill"></span><%#Eval("email")%></a></li>
                                    <li><a href="in.linkedin.com/in/rohin-bhatia-3584721aa" target="_blank"><span class="bi bi-linkedin"></span><%#Eval("password")%></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <section class="departFaculties_dtl_tab">
                <div class="container">
                    <div class="departFaculties_tab_wraper">
                        <div class="row">
                            <div class="col-lg-3 d-none d-lg-block">
                                <div class="tab_designTwo">
                                    <ul class="nav nav-tabs d-block" id="myTab" role="tablist">
                                        <li class="nav-item" role="presentation">
                                            <button aria-controls="tab-pane01" aria-selected="true" class="nav-link active"
                                                data-bs-target="#tab-pane01" data-bs-toggle="tab" id="tab-01" role="tab"
                                                type="button">
                                                Award & Recognition</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button aria-controls="tab-pane02" aria-selected="false" class="nav-link"
                                                data-bs-target="#tab-pane02" data-bs-toggle="tab" id="tab-02" role="tab" tabindex="-1"
                                                type="button">
                                                International</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button aria-controls="tab-pane03" aria-selected="false" class="nav-link"
                                                data-bs-target="#tab-pane03" data-bs-toggle="tab" id="tab-03" role="tab" tabindex="-1"
                                                type="button">
                                                Membership</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button aria-controls="tab-pane04" aria-selected="false" class="nav-link"
                                                data-bs-target="#tab-pane04" data-bs-toggle="tab" id="tab-04" role="tab" tabindex="-1"
                                                type="button">
                                                Research</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button aria-controls="tab-pane05" aria-selected="false" class="nav-link"
                                                data-bs-target="#tab-pane05" data-bs-toggle="tab" id="tab-05" role="tab" tabindex="-1"
                                                type="button">
                                                Books Published</button>
                                        </li>
                                        <li class="nav-item" role="presentation">
                                            <button aria-controls="tab-pane06" aria-selected="false" class="nav-link"
                                                data-bs-target="#tab-pane06" data-bs-toggle="tab" id="tab-06" role="tab" tabindex="-1"
                                                type="button">
                                                Certifications</button>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-lg-9">
                                <div class="tab_DetailTwo ps-lg-3">
                                    <div class="tab-content accordion" id="myTabContent">
                                        <div aria-labelledby="tab-01" class="tab-pane fade accordion-item active show" id="tab-pane01" role="tabpanel" tabindex="0">
                                            <h2 class="accordion-header d-lg-none" id="heading-01">
                                                <button aria-controls="collapse-01" aria-expanded="false" class="accordion-button collapsed" data-bs-target="#collapse-01"
                                                    data-bs-toggle="collapse" type="button">
                                                    Award & Recognition
                                                </button>
                                            </h2>
                                            <div aria-labelledby="heading-01" class="accordion-collapse collapse d-lg-block" data-bs-parent="#myTabContent" id="collapse-01">
                                                <div class="accordion-body p-lg-0 p-3">
                                                    <div class="tab_Detail_wraper">
                                                        <%#Server.HtmlDecode(Eval("smalldesc").ToString())%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div aria-labelledby="tab-02" class="tab-pane fade accordion-item" id="tab-pane02" role="tabpanel" tabindex="0">
                                            <h2 class="accordion-header d-lg-none" id="heading-02">
                                                <button aria-controls="collapse-02" aria-expanded="false" class="accordion-button collapsed"
                                                    data-bs-target="#collapse-02" data-bs-toggle="collapse" type="button">
                                                    International
                                                </button>
                                            </h2>
                                            <div aria-labelledby="heading-02" class="accordion-collapse collapse d-lg-block" data-bs-parent="#myTabContent"
                                                id="collapse-02">
                                                <div class="accordion-body p-lg-0 p-3">
                                                    <div class="tab_Detail_wraper">
                                                        <%#Server.HtmlDecode(Eval("project_guidance").ToString())%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div aria-labelledby="tab-03" class="tab-pane fade accordion-item" id="tab-pane03" role="tabpanel" tabindex="0">
                                            <h2 class="accordion-header d-lg-none" id="heading-03">
                                                <button aria-controls="collapse-03" aria-expanded="false" class="accordion-button collapsed"
                                                    data-bs-target="#collapse-03" data-bs-toggle="collapse" type="button">
                                                    Membership
                                                </button>
                                            </h2>
                                            <div aria-labelledby="heading-03" class="accordion-collapse collapse d-lg-block" data-bs-parent="#myTabContent"
                                                id="collapse-03">
                                                <div class="accordion-body p-lg-0 p-3">
                                                    <div class="tab_Detail_wraper">
                                                        <%#Server.HtmlDecode(Eval("society_membership").ToString())%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div aria-labelledby="tab-04" class="tab-pane fade accordion-item" id="tab-pane04" role="tabpanel" tabindex="0">
                                            <h2 class="accordion-header d-lg-none" id="heading-04">
                                                <button aria-controls="collapse-04" aria-expanded="false" class="accordion-button collapsed"
                                                    data-bs-target="#collapse-04" data-bs-toggle="collapse" type="button">
                                                    Research
                                                </button>
                                            </h2>
                                            <div aria-labelledby="heading-04" class="accordion-collapse collapse d-lg-block" data-bs-parent="#myTabContent"
                                                id="collapse-04">
                                                <div class="accordion-body p-lg-0 p-3">
                                                    <div class="tab_Detail_wraper">
                                                        <%#Server.HtmlDecode(Eval("research_initiatives").ToString())%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div aria-labelledby="tab-05" class="tab-pane fade accordion-item" id="tab-pane05" role="tabpanel" tabindex="0">
                                            <h2 class="accordion-header d-lg-none" id="heading-05">
                                                <button aria-controls="collapse-05" aria-expanded="false" class="accordion-button collapsed"
                                                    data-bs-target="#collapse-05" data-bs-toggle="collapse" type="button">
                                                    Books Published
                                                </button>
                                            </h2>
                                            <div aria-labelledby="heading-05" class="accordion-collapse collapse d-lg-block" data-bs-parent="#myTabContent"
                                                id="collapse-05">
                                                <div class="accordion-body p-lg-0 p-3">
                                                    <div class="tab_Detail_wraper">
                                                        <%#Server.HtmlDecode(Eval("books_published").ToString())%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div aria-labelledby="tab-06" class="tab-pane fade accordion-item" id="tab-pane06" role="tabpanel" tabindex="0">
                                            <h2 class="accordion-header d-lg-none" id="heading-06">
                                                <button aria-controls="collapse-06" aria-expanded="false" class="accordion-button collapsed"
                                                    data-bs-target="#collapse-06" data-bs-toggle="collapse" type="button">
                                                    Certifications
                                                </button>
                                            </h2>
                                            <div aria-labelledby="heading-06" class="accordion-collapse collapse d-lg-block" data-bs-parent="#myTabContent"
                                                id="collapse-06">
                                                <div class="accordion-body p-lg-0 p-3">
                                                    <div class="tab_Detail_wraper">
                                                        <%#Server.HtmlDecode(Eval("revenue_earned").ToString())%>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

