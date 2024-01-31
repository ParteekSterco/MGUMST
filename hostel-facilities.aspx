<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="hostel-facilities.aspx.cs" Inherits="hostel_facilities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="sec_padding pt-0 bg_09">
        <div class="container">
            <div class="hostel_form bg-white">
                <div class="row g-0">
                    <div class="col-md-7">
                        <div class="form_wraper">
                            <div class="row g-4">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label" for="">Name*</label>
                                        <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name of the Student"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"
                                            Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                                            Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label" for="">College Name*</label>
                                        <asp:TextBox ID="txtcollage" runat="server" class="form-control" placeholder="Name of the College"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcollage"
                                            Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
                                            Enabled="true" TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label" for="">Program*</label>
                                        <asp:DropDownList ID="ddlprogram" runat="server" class="form-select"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlprogram" InitialValue="0" Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                                            Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label" for="">Year / Batch*</label>
                                        <asp:TextBox ID="txtyear" runat="server" class="form-control" placeholder="Enter Your year / Batch no."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtyear"
                                            Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server"
                                            Enabled="true" TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label" for="">Mobile No*</label>
                                        <asp:TextBox ID="txtmobno" runat="server" MaxLength="10" class="form-control" placeholder="Enter Your Mobile No"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="None"
                                            Font-Size="Smaller" ErrorMessage="Enter Mobile No." ControlToValidate="txtmobno"
                                            ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" Font-Size="Smaller"
                                            Display="None" ErrorMessage="Enter Valid Mobile No." ControlToValidate="txtmobno"
                                            ValidationGroup="validcontact" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[6789]\d{9}$"
                                            runat="server" />
                                        <ajaxToolkit:FilteredTextBoxExtender runat="server" ValidChars="Interger" FilterMode="ValidChars"
                                            FilterType="Numbers" ID="filter_txtmobile" TargetControlID="txtmobno">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server"
                                            Enabled="true" TargetControlID="RequiredFieldValidator8" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server"
                                            Enabled="true" TargetControlID="RegularExpressionValidator12" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label class="form-label" for="">Email ID*</label>
                                        <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Enter your email"
                                            autocomplete="none"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtemail"
                                            Font-Size="Smaller" Display="None" ErrorMessage="Enter E-mail ID" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Valid E-mail ID"
                                            ControlToValidate="txtemail" ValidationGroup="validcontact" Display="None" Font-Size="Smaller"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                            Enabled="true" TargetControlID="RequiredFieldValidator3" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server"
                                            Enabled="true" TargetControlID="RegularExpressionValidator5" HighlightCssClass="validatorCalloutHighlight1"
                                            CssClass="BlockPopup" />
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label class="form-label" for="">Description of Grievance</label>
                                        <asp:TextBox ID="txtdesc" runat="server" class="form-control" placeholder="Enter Description of Grievance" autocomplete="none" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="btn-group">
                                        <asp:Button ID="btnsave" Text="Submit" runat="server" class="btn_thm" ValidationGroup="validcontact" OnClick="btnsubmit_Click" />
                                        <button class="btn_thm" type="button">Reset</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Literal ID="litsmalldesc" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

