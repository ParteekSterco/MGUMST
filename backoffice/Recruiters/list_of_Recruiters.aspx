<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master" Theme="backtheme" AutoEventWireup="true" CodeFile="list_of_Recruiters.aspx.cs" Inherits="backoffice_Recruiters_list_of_Recruiters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script type="text/javascript" src="/fancybox/jquery-1.4.3.min.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />

 <script type="text/javascript">
     function showpreview(input) {

         if (input.files && input.files[0]) {
             document.getElementById("imgpreview").style.display = 'inline';
             var reader = new FileReader();
             reader.onload = function (e) {
                 $('#imgpreview').attr('src', e.target.result);
             }
             reader.readAsDataURL(input.files[0]);
         }

     }

    </script>

      <script type="text/javascript">
          $(document).ready(function () {
              $(".toptxtrclg").fancybox({
                  'width': '90%',
                  'height': '90%',
                  'autoScale': true,
                  'scrolling': true,
                  'transitionIn': 'elastic',
                  'transitionOut': 'elastic',
                  'type': 'iframe'
              });
          });
    </script>
    <h2>

        
Add/Edit Recruiters</h2>
    <div class="content-panel">
<table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
        <tr>
            <td align="left" colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="right">
                        <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            &nbsp;<asp:TextBox ID="imgid" runat="server" Visible="false" Width="33px"></asp:TextBox>
                            <asp:TextBox ID="rqstid" runat="server" Visible="false"></asp:TextBox>
                            <asp:CheckBox ID="status" runat="server" Visible="False" Checked="true" />
                             <asp:CheckBox ID="showonhome" runat="server" Checked="false" />
                              <asp:CheckBox ID="showongroup" runat="server" Visible="False" />
                           
                            &nbsp;&nbsp; &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="h_dot_line">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="headingtext" colspan="2">
                <div class="error" align="left" id="trerror" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </div>
                <div class="success" align="left" id="trsuccess" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblsuccess" runat="server"></asp:Label>
                </div>
                <div class="notice" align="left" id="trnotice" runat="server">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblnotice" runat="server"></asp:Label>
                </div>
            </td>
        </tr>
        

        <tr>
            <td align="right" colspan="2">
                Fields with <span style="color: #ff0000">*</span> are mandatory
            </td>
            <td align="center" colspan="2">
                
                </td>
        </tr>
        <tr>
            <td align="center" colspan="2" height="10">
            </td>
        </tr>
        
        <tr>
            <td align="right" style="width: 15%">
               <span class="star"></span>Recruiters Name :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="imgtitle" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                    Width="359px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="imgtitle"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="star"></span>Home Page Logo :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <input id="File1" runat="server" class="box" contenteditable="false" type="file" /><asp:TextBox
                    ID="uploadimage" runat="server" Visible="false" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
            </td>
            <td>
                <img id="imgpreview" height="100" width="100" src="" runat="server" visible="false" />
                <asp:Image ID="Image1" runat="server" Width="100" Height="100"  Visible="false" />
            </td>
        </tr>

         <tr>
            <td align="right" style="width: 15%">
                <span class="star"></span>List Page Logo :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <input id="File2" runat="server" class="box" contenteditable="false" type="file" /><asp:TextBox
                    ID="imagelist" runat="server" Visible="false" Width="122px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
            </td>
            <td>
                <img id="imgpreview1" height="100" width="100" src="" runat="server" visible="false" />
                <asp:Image ID="Image2" runat="server" Width="100" Height="100"  Visible="false" />
            </td>
        </tr>

         <tr>
                    <td align="right">
                        Display Order :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="displayorder" runat="server" Width="39px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                            ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                            ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
      
<%--
         <tr>
            <td class="head1" colspan="2" style="font-size: small;" nowrap>
                SEO Information
            </td>
        </tr>
        <tr>
            <td align="right">
                Page Title :&nbsp;
            </td>
            <td align="left">
                <asp:TextBox ID="PageTitle" runat="server" Width="600px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Keywords :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="PageMeta" runat="server" Height="50px" TextMode="MultiLine"
                    Width="600px" />
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Meta Description :
            </td>
            <td align="left" valign="top">
                <asp:TextBox ID="PageMetaDesc" runat="server" Height="50px" TextMode="MultiLine"
                    Width="600px"></asp:TextBox>
            </td>
        </tr>--%>

        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />&nbsp;
                <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false"
                    OnClick="btncancel_Click" />
            </td>
        </tr>
        <tr>
        <td>
        </td>

        
        </tr>

        <tr >
        
        <td colspan="2"><asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" 
                onrowdatabound="GridView1_RowDataBound" 
                onrowcommand="GridView1_RowCommand" Width="100%">
           <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                            <ItemTemplate>
                                <%# ((GridViewRow)Container ).RowIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Recruiters Name">
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lbtitle" runat="server" Text='<%#Eval("imgtitle")%>'></asp:Label>
                                
                            </ItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Home Page Logo">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <img id="imgimage" runat="server" width="75" height="69" />
                                <asp:Label ID="lblimage" runat="server" Text='<%# Eval("uploadimage")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="List Page Logo">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <img id="imgimage1" runat="server" width="75" height="69" />
                                <asp:Label ID="lblimage1" runat="server" Text='<%# Eval("imagelist")%>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Status">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%#Eval("imgid")%>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Show on Group" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:Label ID="lblshowongroup" runat="server" Text='<%#Eval("showongroup") %>' Visible="false"></asp:Label>
                                <asp:ImageButton ID="lnkshowongroup" CssClass="toptxt" runat="server" CausesValidation="false"
                                    CommandArgument='<%# Eval("imgid") %>' CommandName="lnkshowongroup"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Show On Home" >
                                    <ItemStyle Width="6%" />    
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtshowonhome" runat="server" Text='<%#Eval("showonhome")%>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkshowonhome" runat="server" CausesValidation="false" CommandArgument='<%#Eval("imgid")%>'
                                            CommandName="lnkshowonhome" />
                                    </ItemTemplate>
                           
                           </asp:TemplateField>

                            <asp:TemplateField HeaderText="Map College"  Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                          <a class="toptxtrclg" href='maprecruitercollege.aspx?imgid=<%#(Eval("imgid"))%>'>
                                    <img src="../assets/Preview_24x24.png" border="0"></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#Eval("imgid")%>'
                                    CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <ItemStyle Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("imgid")%>'
                                    CommandName="del" ImageUrl="~/backoffice/assets/Remove_24x24.png" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>




                       </Columns>
        


        
        </asp:GridView></td>
        
        </tr>
    </table>
    </div>
</asp:Content>

