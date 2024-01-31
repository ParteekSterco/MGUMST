<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="collage-dept.aspx.cs" Inherits="collage_dept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="dcms_sec dcms_inner_sec">
        <div class="container">
            <div class="row mt-0 g-2 g-md-3 gx-lg-5">
                <asp:Repeater ID="rptcollage_dept" runat="server" OnItemDataBound="rptcollage_dept_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="litdeptid" runat="server" Visible="false" Text='<%#Eval("deptid")%>'></asp:Literal>
                        <div class="col-6 col-sm-6 col-md-4">
                            <div class="dcms_box">
                                <a id="ank" runat="server">
                                    <figure class="mb-4">
                                        <img src="/uploads/banner/<%#Eval("banner")%>" alt="" class="img-fluid w-100">
                                    </figure>
                                    <h5><%#Eval("deptname")%></h5>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="col-12 text-center" id="panelloadmore" runat="server" visible="false">
                    <a href="#" class="arrowBtn"><span>Load More</span>
                        <img src="/assets/images/icons/arrowCircledowndark.svg" alt="" class="img-fluid"></a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

