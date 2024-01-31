<%@ Page Language="C#" MasterPageFile="~/backoffice/layouts/sigininmaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="backoffice_Default" Theme="backtheme" %>
<%@ Register Src="usercontrols/uc_backlogin.ascx" TagName="uc_backlogin" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:uc_backlogin ID="Uc_backlogin1" runat="server" />
  
</asp:Content>

