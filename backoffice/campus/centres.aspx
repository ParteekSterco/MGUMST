<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice/layouts/BackMaster.master"
    AutoEventWireup="true" CodeFile="centres.aspx.cs" Inherits="backoffice_campus_centres"
    Theme="backtheme" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>
        Add Campus</h2>
    <div class="content-panel">
        <table id="TABLE1" border="0" cellpadding="1" cellspacing="0" style="width: 100%">
            <tr>
                <td align="left" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td class="head1">
                            </td>
                            <td align="right">
                                &nbsp; &nbsp;<asp:TextBox ID="campusid" runat="server" Visible="False" Width="33px"></asp:TextBox>
                               
                                &nbsp; &nbsp;&nbsp; &nbsp;
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
                    Fields with <span class="star">*</span> are mandatory
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" height="10">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 15%">
                  Campus Name :  <span class="star">*</span>&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:TextBox ID="campus_name" runat="server" CssClass="box" TabIndex="3" Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="campus_name"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
              <tr>
                <td align="right" style="width: 15%">
                    MegaMenu Position:<span class="star"></span>&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:DropDownList ID="position" runat="server" Width="122px">
                      <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Left">Left</asp:ListItem>
                    <asp:ListItem Value="Middle">Middle</asp:ListItem>
                    <asp:ListItem Value="Right">Right</asp:ListItem>
                    </asp:DropDownList>
                  <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ControlToValidate="position"
                        Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
        <tr  >
            <td align="right" style="width: 15%">
                <span class="star">*</span>Short Name :&nbsp;
            </td>
            <td align="left" style="width: 85%">
                <asp:TextBox ID="campus_code" runat="server" CssClass="box" TabIndex="3" Width="500px"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="campus_code"
                    Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr >
                <td align="right" width="15%" valign="top">
                    Campus Desc : &nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <CKEditor:CKEditorControl ID="CKeditor4" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="details3" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
          <tr>
                <td align="right" width="15%" valign="top">
                    Campus Short Desc. : &nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <CKEditor:CKEditorControl ID="CKeditor2" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="shortdesc" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>

            
            <tr>
                <td align="right" width="15%" valign="top">
                    Campus About City. : &nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <CKEditor:CKEditorControl ID="CKeditor1" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="details" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>


          



             <tr style="display:none" >
                <td align="right" width="15%" valign="top">
                    Campus fact and figure : &nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <CKEditor:CKEditorControl ID="CKeditor3" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="details2" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>
            
             <tr  style="display:none">
                <td align="right" width="15%" valign="top">
                    Campus Desc4. : &nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <CKEditor:CKEditorControl ID="CKeditor5" runat="server" Height="250" BasePath="~/ckeditor">
                    </CKEditor:CKEditorControl>
                    <asp:TextBox ID="details4" runat="server" Visible="False" Width="122px"></asp:TextBox>
                </td>
            </tr>

          
            <tr>
                <td align="right" style="width: 15%">
                    Upload Banner<span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:FileUpload ID="File1" runat="server" />
                    <asp:TextBox ID="banner" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image1" runat="server" Height="100px" Visible="False" Width="100px" />
                    <asp:LinkButton ID="lnkremove" runat="server" OnClick="lnkremove_Click" Visible="false">Remove Image</asp:LinkButton>
                </td>
            </tr>

             <tr>
                <td align="right" style="width: 15%">
                    Upload Logo<span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:FileUpload ID="File2" runat="server" />
                    <asp:TextBox ID="clogo" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image2" runat="server" Height="100px" Visible="False" Width="100px" />
                    <asp:LinkButton ID="lnkremove1" runat="server" OnClick="lnkremove1_Click" Visible="false">Remove Image</asp:LinkButton>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                    Homepage Slide Banner <span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:FileUpload ID="File3" runat="server" />
                    <asp:TextBox ID="homebanner" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image3" runat="server" Height="100px" Visible="False" Width="100px" />
                    <asp:LinkButton ID="lnkremove2" runat="server" OnClick="lnkremove2_Click" Visible="false">Remove Image</asp:LinkButton>
                </td>
            </tr>

             <tr style="display:none">
                <td align="right" style="width: 15%">
                    Homepage fact and figure Banner <span class="star"></span> :&nbsp;
                </td>
                <td align="left" style="width: 85%">
                    <asp:FileUpload ID="File4" runat="server" />
                    <asp:TextBox ID="factimage" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td align="right" style="width: 15%">
                </td>
                <td align="left" style="width: 85%">
                    <asp:Image ID="Image4" runat="server" Height="100px" Visible="False" Width="100px" />
                    <asp:LinkButton ID="lnkremove3" runat="server" OnClick="lnkremove3_Click" Visible="false">Remove Image</asp:LinkButton>
                </td>
            </tr>


              <tr >
                <td align="right">
                    Display order :&nbsp;
                </td>
                <td align="left" height="10">
                 <asp:TextBox ID="displayorder" runat="server" Width="150px" Visible="true"></asp:TextBox>
                </td>
            </tr>
             <tr >
                <td align="right">
                  Home Display order :&nbsp;
                </td>
                <td align="left" height="10">
                 <asp:TextBox ID="homedisplayorder" runat="server" Width="150px" Visible="true"></asp:TextBox>
                </td>
            </tr>

             
            <tr style="display: none">
                <td align="right">
                    Status :&nbsp;
                </td>
                <td align="left" height="10">
                    <asp:CheckBox ID="status" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <b>SEO SECTION</b>
                </td>
            </tr>
            <tr style="display: none">
                <td valign="top" align="right">
                    <span class="star"></span>Rewrite Url : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="rewriteurl" CssClass="box" runat="server" Width="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>Page Title : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageTitle" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>Page Meta : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageMeta" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>Page Meta Desc : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="PageMetaDesc" runat="server" Width="500px" Height="100" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Page Script :
                </td>
                <td align="left" valign="top">
                    <asp:TextBox ID="pagescript" runat="server" Height="50px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    <span class="star"></span>Canonical : &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="canonical" runat="server" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    No Index Follow :
                </td>
                <td align="left" valign="top">
                    <asp:CheckBox ID="no_indexfollow" runat="server"></asp:CheckBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left" height="10">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="left">
                    <asp:Button ID="btnsubmit" runat="server" CssClass="btnbg" Text="Submit" OnClick="btnsubmit_Click" />
                    <asp:Button ID="btncancel" runat="server" CssClass="btnbg" Text="Cancel" CausesValidation="false"
                        OnClick="btncancel_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    &nbsp; &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
