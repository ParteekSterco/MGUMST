<%@ Page Title="" Language="C#" MasterPageFile="~/blog/layouts/blogmaster.master"
    AutoEventWireup="true" CodeFile="thankyou.aspx.cs" Inherits="blog_thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container thankyou">
        <div class="row">
            <div class="col-md-12">
                <h2 class="d-none">
                    <asp:Label ID="lblsuccess1" runat="server" Visible="false"></asp:Label></h2>
                <p class=" text-center">
                    <asp:Label ID="lblsuccess" runat="server"></asp:Label></p>
                <div class="apply tankyou_btn">
                <h1>Thank You!</h1>
                    <p>For More Details Vist Our Offical website https://www.jnujaipur.ac.in</p>
                    <a href="/blog/index.aspx">Continue to Homepage</a>
                </div>
            </div>
        </div>
        <div class="row">
            <br />
        </div>
    </div>
</asp:Content>
