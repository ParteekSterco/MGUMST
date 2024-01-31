﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addfacultycat.aspx.cs" Theme="backtheme" Inherits="backoffice_faculty_addfacultycat" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                    <asp:ScriptReference Name="Common.Common.js" Assembly="AjaxControlToolkit" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>
        <input type="hidden" value="<%=appno%>" name="appno" id="appno">

        <script type="text/javascript" src="../../fancybox/jquery.mousewheel-3.0.4.pack.js"></script>

        <script type="text/javascript" src="../../fancybox/jquery.fancybox-1.3.4.pack.js"></script>

        <link rel="stylesheet" type="text/css" href="../../fancybox/jquery.fancybox-1.3.4.css"
            media="screen" />
        <%-- <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>--%>

        <script type="text/javascript">
            $(document).ready(function () {
                var i = 0;
                var toappno = document.getElementById("appno").value;
                for (i = 1; i <= toappno; i++) {
                    $("#various" + i).fancybox({
                        'width': '80%',
                        'height': '80%',
                        'autoScale': true,
                        'scrolling': true,
                        'transitionIn': 'elastic',
                        'transitionOut': 'elastic',
                        'type': 'iframe'
                    });
                }
            });
        </script>
        <h2>Add/Edit Faculty Category  </h2>
        <div class="content-panel">
            <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
                <tr>
                    <td align="left" colspan="2">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="head1"></td>
                                <td align="right">&nbsp;
                            <asp:TextBox ID="fid" runat="server" Visible="true" Width="33px"></asp:TextBox>
                                    <asp:TextBox ID="faulityid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                                    <asp:CheckBox ID="Status" runat="server" Visible="False" Checked="true" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="h_dot_line">&nbsp;
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
                    <td align="right" colspan="2">Fields with <span class="star">*</span> are mandatory</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" height="10"></td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%; height: 26px;">Faculty category  <span class="star">*</span> :&nbsp;
                    </td>
                    <td align="left" style="width: 85%; height: 26px;">
                        <asp:TextBox ID="facultycate" runat="server" CssClass="box" MaxLength="100" TabIndex="3"
                            Width="214px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="facultycate"
                            Display="Dynamic" ErrorMessage="Required" ValidationGroup="album"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td valign="top" align="right">Small Desc &nbsp;
                    </td>
                    <td>
                        <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                        </CKEditor:CKEditorControl>
                        <asp:TextBox ID="smalldesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">Display Order :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="displayorder" runat="server" Width="39px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator10" runat="server"
                            ControlToValidate="displayorder" Display="Dynamic" ErrorMessage="Enter Numeric"
                            ValidationExpression="^\d+?$" ValidationGroup="album"></asp:RegularExpressionValidator></td>
                </tr>


                <tr>
                    <td align="right"></td>
                    <td align="left">
                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="btnbg"
                            ValidationGroup="album" OnClick="btnsubmit_Click" />&nbsp;
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btnbg" OnClick="btncancel_Click" CausesValidation="False" /></td>
                </tr>
                <tr>
                    <td align="center" colspan="2" height="10"></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" height="10"></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                            OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">

                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%# ((GridViewRow)Container).DataItemIndex + 1%>.
                               <asp:Label ID="Label1" runat="server" Text='<%#(Eval("fid")) %>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" Faculty Type  ">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="center" />
                                    <ItemTemplate>
                                        <%#Eval("facultycate").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="displayorder" HeaderText="Display Order">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Publish">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtstatus" runat="server" Text='<%#Eval("status") %>' Visible="false"></asp:TextBox>
                                        <asp:ImageButton ID="lnkstatus" CssClass="toptxt" runat="server" CausesValidation="false"
                                            CommandArgument='<%#(Eval("fid")) %>' CommandName="status"></asp:ImageButton>
                                    </ItemTemplate>
                                </asp:TemplateField>



                                <asp:TemplateField HeaderText="Edit">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnedit" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("fid")) %>'
                                            CommandName="edit" ImageUrl="~/backoffice/assets/edit.png" ToolTip="Click to Edit" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete" Visible="false">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btndel" runat="server" CausesValidation="false" CommandArgument='<%#(Eval("fid")) %>'
                                            CommandName="del" ImageUrl="~/backoffice/assets/Remove_24x24.png" ToolTip="Click to Delete" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Are you sure you want to delete this?"
                                            TargetControlID="btndel">
                                        </ajaxToolkit:ConfirmButtonExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle HorizontalAlign="Right" />
                            <PagerStyle HorizontalAlign="Right" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

