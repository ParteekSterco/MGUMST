<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mapcoursetype.aspx.cs" Inherits="backoffice_Course_mapcoursetype" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="background-color:lavender">
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div>
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                               <%-- Add/Edit Course Type--%>
                                <asp:TextBox ID="courseid" runat="server" Visible="false" Width="33px"></asp:TextBox>
                                <asp:TextBox ID="mctid" runat="server" Visible="false" Width="33px"></asp:TextBox>
                                <asp:CheckBox ID="status" runat="server" Visible="false" Checked="true" />
                            </td>
                            <td align="right">
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
           
            <tr></tr>
              <tr style="display:none">
                        <td valign="top" width="15%" align="right">
                            Title<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:TextBox ID="title" runat="server"  ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="title"
                                Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                     <tr>
                        <td valign="top" width="15%" align="right">
                           Course Type<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                                 <asp:DropDownList ID="ctid" runat="server" Width="350px" AutoPostBack="false"
                        OnSelectedIndexChanged="ctid_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ctid"
                        Display="Dynamic" ErrorMessage="Required" InitialValue="0"></asp:RequiredFieldValidator>
     
                        </td>
                    </tr>


                     <tr>
                        <td valign="top" align="right">
                            Short Description: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="100" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="shortdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                    </tr>


                       <tr>
                        <td valign="top" align="right">
                            Description: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="100" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="details" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                    </tr>
<tr>
                        <td valign="top" align="right">
                            Description1: &nbsp;
                        </td>
                        <td>
                            <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="100" BasePath="~/ckeditor">
                            </CKEditor:CKEditorControl>
                            <asp:TextBox ID="details1" runat="server" Visible="False" Width="122px"></asp:TextBox>
                            </td>
                    </tr>


                      <tr style="display:none">
                        <td valign="top" width="15%" align="right">
                            Display Order<span class="star">*</span> : &nbsp;</td>
                        <td width="85%">
                            <asp:TextBox ID="displayorder" runat="server" MaxLength="3" Text="0" ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="displayorder"
                                Display="Dynamic" ErrorMessage="Required" ></asp:RequiredFieldValidator>
--%>
                                 <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server"
                                ControlToValidate="displayorder" ErrorMessage="Enter Numeric" Display="Dynamic"
                                ValidationExpression="^\d+?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnbg" 
                                onclick="btnSubmit_Click"  />&nbsp;
                        </td>
                    </tr>
                      <tr>
            <td align="center" colspan="2">
                &nbsp; &nbsp;</td>
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
            <td align="center" colspan="2">
                &nbsp;<asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="50"
                    Width="100%" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                          >
                    <Columns>
                        <asp:TemplateField HeaderText="S.No.">
                         <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# ((GridViewRow)Container).RowIndex + 1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                    
                        <%--   <asp:TemplateField HeaderText="Title">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("title")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    
                     <asp:TemplateField HeaderText="Course Type">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("ctypename")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                         
                     
                     
                         
                 
                        
                        <asp:BoundField DataField="Status" Visible="false" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Publish">
                        <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status")%>' Visible="false"></asp:TextBox>
                                <asp:ImageButton ID="lnkstatus" runat="server" CausesValidation="false" CommandArgument='<%# Eval("mctid") %>'
                                    CommandName="lnkstatus" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Display Order">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%#Eval("displayorder")%>
                             
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%# Eval("mctid") %>'
                                    CommandName="btnedit" ImageUrl="~/backoffice/assets/Edit.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Delete" >
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#Eval("mctid")%>'
                                    CommandName="del" ImageUrl="~/backoffice/assets/Remove_24x24.png" ToolTip="Click to Delete" />
                                <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                    TargetControlID="btndel">
                                </ajaxToolkit:ConfirmButtonExtender>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
               
               

            
        </table>
    </div>

    
    </div>
    </form>
</body>
</html>