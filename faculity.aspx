<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="faculity.aspx.cs" Inherits="faculity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="inner_common_title">
        <div class="container">
            <div class="row g-4 align-items-center justify-content-center">
                <div class="col-lg-10">
                    <div class="row g-4 align-items-center">
                        <div class="col-sm-6 col-md-6 form-group">
                            <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Faculty Name"></asp:TextBox>
                        </div>
                        <div class="col-sm-6 col-md-5 form-group">
                            <asp:DropDownList ID="ddldesignation" runat="server" class="form-select"></asp:DropDownList>

                        </div>
                        <div class="col-1">
                            <asp:LinkButton ID="lnk" runat="server" class="btn btn_searchNow" OnClick="btnsearch">
                                 <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-search" viewBox="0 0 20 20">
     <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0"></path>
 </svg></asp:LinkButton>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="deparFaculties_sec">
        <div class="container">
            <div class="row g-4 gy-lg-5 gx-lg-5">
                <asp:Repeater ID="rptfaculity" runat="server" OnItemDataBound="rptfaculity_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="litfaculityid" runat="server" Visible="false" Text='<%#Eval("facultyid")%>'></asp:Literal>
                        <asp:Literal ID="litfname" runat="server" Visible="false" Text='<%#Eval("fname")%>'></asp:Literal>
                        <asp:Literal ID="litshowonhome_school" runat="server" Visible="false" Text='<%#Eval("showonhome_school")%>'></asp:Literal>
                        <div class="col-sm-6 col-md-4 col-lg-3">
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



                <div class="col-12 text-center pt-lg-3" id="panelloadmore" runat="server" visible="false">
                    <a href="#" class="arrowBtn"><span>Load More</span>
                        <img src="/assets/images/icons/arrowCircledowndark.svg" alt="" class="img-fluid"></a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

