<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sideblog.ascx.cs" Inherits="blog_usercontrols_sideblog" %>
<div class="right_listing right_sec">
   
    <div class="height_sec" id="divrecentpost" runat="server" visible="false">
     <h2>
        Recent Post</h2>
        <div class="bullet_list">
            <ul>
                <asp:Repeater ID="rptlatestblogs" runat="server" OnItemDataBound="rptlatestblogs_ItemDataBound">
                    <ItemTemplate>
                        <asp:Label ID="lblblogId" Visible="false" runat="server" Text='<%#Eval("blogId")%>'></asp:Label>
                        <li><a href="/blogs/<%#Eval("blogtitle").ToString().ToLower().Replace("  ", "-").Replace(" ", "-").Replace("--", "-").Replace("&", "").Replace("@", "").Replace("?", "") %>/<%#Eval("blogId")%>"><%# Eval("blogtitle")%> </a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
   
    <div class="height_sec" id="divcategories" runat="server" visible="false">
     <h2>
        Categories</h2>
        <div class="bullet_list">
            <ul>
                <asp:Repeater ID="rptblogcat" runat="server" OnItemDataBound="rptblogcat_ItemDataBound" OnItemCommand="rptblogcat_ItemCommand">
                    <ItemTemplate>
                        <asp:Label ID="lblbcatid" Visible="false" runat="server" Text='<%#Eval("bcatid")%>'></asp:Label>
                        <li>
                         <asp:LinkButton ID="lnkblogcat" runat="server" CommandName="blogcmd" CommandArgument='<%#Eval("bcatid")%>'>
                        <%# Eval("bcattitle")%> 
                       </asp:LinkButton></li>
                    </ItemTemplate>
                </asp:Repeater>
               <%-- <li><a href="#">Information Technology </a></li>
                <li><a href="#">Information Technology </a></li>--%>
            </ul>
        </div>
    </div>
      
   
    <div class="height_sec" id="divarcheive" runat="server" visible="false">
     <h2>
        Archives</h2>
        <div class="bullet_list">
            <ul>
                <asp:Repeater ID="rparcheive" runat="server" OnItemDataBound="rparcheive_ItemDataBound" OnItemCommand="rparcheive_ItemCommand">
                    <ItemTemplate>
                    <asp:Label ID="lblblogid" Visible="false" runat="server" Text='<%#Eval("blogid")%>'></asp:Label>
                        <li> 
                        <asp:LinkButton ID="lnkblogdate" runat="server" CommandName="blogdatecmd" CommandArgument='<%#Eval("blogdate")%>'>
                        Year <%# Eval("blogdate")%>  </asp:LinkButton></li>
                        <%--<li><a href="#">October 2020 </a></li>
                        <li><a href="#">October 2020 </a></li>
                        <li><a href="#">October 2020 </a></li>--%>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <h2>
        Search</h2>
    <div class="form-group">
        <label>
            Search for:</label>
       <%-- <input name="" type="text" id="" class="form-control" placeholder="">--%>
        <asp:Panel ID="Panel1" runat="server" DefaultButton="lnksearch">
            <asp:TextBox ID="txtsearch" runat="server" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsearch"
                Display="Dynamic" ErrorMessage="Enter Search" ValidationGroup="validsearch" Font-Size="Smaller"></asp:RequiredFieldValidator>
            <asp:LinkButton ID="lnksearch" class="footer-btn" ValidationGroup="validsearch"
                runat="server" OnClick="lnksearch_Click"> <img src="/images/arrow-w.svg"></asp:LinkButton>
        </asp:Panel>
    </div>
    
    
    
    <div id="left">
   		<div class="left_panel">
    <h2 class="mb-0 border-0">
        Contact Form</h2>
    <div class="form_sec">
        <div class="form-group">
            <label>
                Name</label>
            <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" Font-Size="Smaller"
                    ErrorMessage="Please Enter Name" ValidationGroup="krblogenquiry" ControlToValidate="txtname"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label>
                Email ID</label>
            <asp:TextBox ID="txtemail" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"  Font-Size="Smaller"
                    ErrorMessage="Please Enter Email Address" ValidationGroup="krblogenquiry" ControlToValidate="txtemail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter valid email."
                    ControlToValidate="txtemail" ValidationGroup="krblogenquiry" Display="Dynamic"  Font-Size="Smaller"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <label>
                Phone</label>
           <asp:TextBox ID="txtmobile" runat="server" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" Font-Size="Smaller"
                    ErrorMessage="Please Enter Phone Number" ValidationGroup="krblogenquiry" 
                    ControlToValidate="txtmobile"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Valid Phone Number."
                    ControlToValidate="txtmobile" ValidationGroup="krblogenquiry" Display="Dynamic" Font-Size="Smaller"
                    ValidationExpression="^([+][9][1]|[9][1]|[0]){0,1}([7-9]{1})([0-9]{9})$"></asp:RegularExpressionValidator>
                <ajaxToolkit:FilteredTextBoxExtender runat="server" ValidChars="Interger" FilterMode="ValidChars"
                    FilterType="Numbers" ID="filter_txtmobile" TargetControlID="txtmobile">
                </ajaxToolkit:FilteredTextBoxExtender>
        </div>
        <div class="form-group">
            <label>
                Message</label>
            <asp:TextBox ID="txtmsg" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" Font-Size="Smaller"
                    ErrorMessage="Please Enter Message" ValidationGroup="krblogenquiry" ControlToValidate="txtmsg"></asp:RequiredFieldValidator>
        </div>
        <div class="read-m">
            <%--<a href="#">Submit</a>--%>
            <asp:LinkButton ID="btnsubmit" runat="server" ValidationGroup="krblogenquiry"
                    OnClick="btnsubmit_Click">Submit</asp:LinkButton>
            </div>
    </div>
    </div>
    </div>
</div>
