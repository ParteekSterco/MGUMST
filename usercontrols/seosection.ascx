<%@ Control Language="C#" AutoEventWireup="true" CodeFile="seosection.ascx.cs" Inherits="usercontrols_seosection" %>


<meta name="description" content="<%=StrMetadesc %>" />
<meta name="keywords" content="<%=StrMetakey %>" />
<!-- Open Graph / Facebook -->
<meta property="og:type" content="website" />
<meta property="og:url"  content="<%=strurl %>" />
<meta property="og:title"  content="<%=Strtitle %>" />
<meta property="og:description"  content="<%=StrMetadesc %>" />
<meta property="og:image" content="">
<!-- Twitter -->
<meta property="twitter:card"  content="summary_large_image" />
<meta property="twitter:url"  content="<%=strurl %>" />
<meta property="twitter:title"  content="<%=Strtitle %>" />
<meta property="twitter:description"  content="<%=StrMetadesc %>" />
<meta property="twitter:image" content="" />
<link rel="canonical" href="<%=strurl %>" />
<meta name="robots" content="<%=strnoindex %>">
<asp:Literal ID="litotherschema" runat="server"></asp:Literal>