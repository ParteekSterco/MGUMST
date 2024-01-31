<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" AutoEventWireup="true" CodeFile="homepage.aspx.cs" Inherits="backoffice_users_homepage" Theme="backtheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



  <link href="/App_Themes/backtheme/bootstrap.min.css" rel="stylesheet" type="text/css" />
  <script src="/App_Themes/backtheme/jquery-3.3.1.slim.min.js" type="text/javascript"></script>
  <script src="/App_Themes/backtheme/bootstrap.min.js" type="text/javascript"></script>
  <link href="/App_Themes/backtheme/dynamic.css" rel="stylesheet" type="text/css" />

  <h2>Welcome To MGUMST - Admin Panel</h2>
<div class="content-panel">
   <table border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td>&nbsp;
                
            </td>
        </tr>
        <tr>
            <td height="35" colspan="2">&nbsp;
                </td>
        </tr>
    </table>
    
     <ul class="ulbackoffice" runat="server" visible="true" id="divdashboard">
     <li>
            <a href="/backoffice/others/viewenquiry.aspx">
                <div class="border-colm">
                    <span>
                        <img src="../assets/enquiry-icon.png" /></span><h2>
                            Contact Us(<asp:Literal ID="litenquiries" Text="0" runat="server"></asp:Literal>)</h2>
                </div>
                
                </a>
            </li>


            <li><a href="/backoffice/career/viewApplications.aspx">
                <div class="border-colm">
                    <span>
                        <img src="../assets/customer.png" /></span><h2>
                            Posted Applications(<asp:Literal ID="litpostapp"  Text="0"  runat="server"></asp:Literal>)</h2>
                </div>
            </a></li>
            
            <li>
            <a href="/backoffice/others/subscriber.aspx">
                <div class="border-colm">
                    <span>
                        <img src="../assets/enquiry-icon.png" /></span><h2>
                            Subscribers(<asp:Literal ID="litsubscribers"  Text="0"  runat="server"></asp:Literal>)</h2>
                </div>
                </a>
            </li>

         <%--   <li>
            <a href="#">
                <div class="border-colm">
                    <span>
                        <img src="/images/enquiry-icon.png" /></span><h2>
                            Blog Inquiries(<asp:Literal ID="litblogenquiry" runat="server"></asp:Literal>)</h2>
                </div>
                </a>
            </li>--%>
           
           
            
            
        </ul>
    
    
    
    
    
    
    
    </div>

 
</asp:Content>
