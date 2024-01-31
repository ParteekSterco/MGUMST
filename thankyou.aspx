<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="thankyou.aspx.cs" Inherits="thankyou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section class="thankyou">
  <div class="container ">
        <div class="row">
            <div class="col-md-12">
                <h2>
                    <asp:Label ID="lblsuccess1" runat="server" Visible="false"></asp:Label>
                </h2>
                <p class="text-center">
                    <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                </p>
                <div class="apply tankyou_btn" style="text-align:center;">
                    <a href="/"> Back to Homepage </a>
                    
                </div>
            </div>
        </div>
        <div class="row">
            <br />
        </div>
    </div>
</section>

</asp:Content>
