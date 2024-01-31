<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="facultydetail.aspx.cs" Inherits="facultydetail" %>

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
                                        <%#Server.HtmlDecode(Eval("work_experience").ToString())%>
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
        </ItemTemplate>
    </asp:Repeater>
    <section class="departFaculties_dtl_tab" id="panelcategory" runat="server" visible="false">
        <div class="container">
            <div class="departFaculties_tab_wraper">
                <div class="row">
                    <div class="col-lg-3 d-none d-lg-block">
                        <div class="tab_designTwo">
                            <ul class="nav nav-tabs d-block" id="myTab" role="tablist">
                                <asp:Repeater ID="rptcategorylist" runat="server" OnItemDataBound="rptcategorylist_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litfacultyid" runat="server" Visible="false" Text='<%#Eval("facultyid")%>'></asp:Literal>
                                        <li class="nav-item" role="presentation">
                                            <button id="btn1" runat="server" aria-controls="tab-pane01" data-bs-toggle="tab" role="tab" type="button">
                                                <%#Eval("facultycate")%></button>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-9">
                        <div class="tab_DetailTwo ps-lg-3">
                            <div class="tab-content accordion" id="myTabContent">
                                <asp:Repeater ID="rptcategorydetail" runat="server" OnItemDataBound="rptcategorydetail_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litfacultyid" runat="server" Visible="false" Text='<%#Eval("facultyid")%>'></asp:Literal>
                                        <div id="panel1" runat="server" aria-labelledby="tab-01" role="tabpanel" tabindex="<%#Container.ItemIndex+1 %>">
                                            <h2 class="accordion-header d-lg-none" id="heading-01">
                                                <button id="btn1" runat="server" aria-controls="collapse-01" data-bs-toggle="collapse" type="button">
                                                    <%#Eval("facultycate")%>
                                                </button>
                                            </h2>
                                            <div aria-labelledby="heading-01" data-bs-parent="#myTabContent" id="panel2" runat="server">
                                                <div class="accordion-body p-lg-0 p-3">
                                                    <div class="tab_Detail_wraper">
                                                        <ul class="custom_bullets">
                                                             <%#Server.HtmlDecode(Eval("smalldesc").ToString())%>
                                                        </ul>
                                                    </div>
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
        </div>
    </section>
</asp:Content>

