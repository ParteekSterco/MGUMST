<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=terms.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
    <section class="innerContact_sec">
        <div class="container">
            <div class="row justify-content-xxl-start justify-content-center">
                <div class="col-md-6 col-lg-4 col-xxl-5">
                    <div class="contactInfo_left">
                        <h3 class="mb-xl-4 mb-3">Mahatma Gandhi University of Medical Sciences & Technology</h3>
                        <p>Sitapura, Tonk Road, Jaipur, Rajasthan (India) – 302022</p>
                        <ul>
                            <li><span class="bi bi-telephone-fill"></span>0141-2771002, 2770798, 2771804</li>
                            <li><span class="bi bi-envelope-fill"></span><a href="mailto:info@mgumst.org">info@mgumst.org</a></li>
                        </ul>
                        <figure class="Info_figure">
                            <img src="/assets/images/home/placeholder-405.svg" alt="" class="img-fluid w-100">
                        </figure>
                    </div>
                </div>
                <div class="col-md-6 col-lg-4 col-xxl-5">
                    <div class="contactInfo_form ps-xl-5 ps-lg-4">
                        <h5 class="mb-xl-4 mb-3">Let's Connect</h5>
                        <p class="mb-3">Fill in the details below and our counselor will get in touch with you at the earliest.</p>

                        <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"
                            Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                            Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight1"
                            CssClass="BlockPopup" />

                        <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Email*"
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

                        <asp:TextBox ID="txtmobno" runat="server" MaxLength="10" class="form-control" placeholder="Mobile No"></asp:TextBox>
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
                        <asp:DropDownList ID="ddlstate" runat="server" class="form-select"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlstate" InitialValue="0"
                            Font-Size="Smaller" Display="None" ErrorMessage="State" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server"
                            Enabled="true" TargetControlID="RequiredFieldValidator15" HighlightCssClass="validatorCalloutHighlight1"
                            CssClass="BlockPopup" />
                        <asp:DropDownList ID="ddlcourse" runat="server" class="form-select"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlcourse" InitialValue="0"
                            Font-Size="Smaller" Display="None" ErrorMessage="State" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                            Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight1"
                            CssClass="BlockPopup" />
                        <%--    <select name="" id="" class="form-select">
                            <option value="" selected>Specialization</option>
                        </select>--%>

                        <div class="form-check">
                            <asp:CheckBox ID="terms" runat="server" class="form-check-input" />
                            I agree to receive information regarding my enquiry for MGUMST.                                          
 <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please accept terms &amp; conditions."
     ClientValidationFunction="ValidateCheckBox" ValidationGroup="validcontact" Font-Size="Small"></asp:CustomValidator>
                        </div>
                        <asp:LinkButton ID="lnk" runat="server" class="btn btnCircle" ValidationGroup="validcontact" OnClick="btnsubmit_Click">Submit</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <div class="info_map">
            <iframe
                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3561.9904369368874!2d75.82649627604152!3d26.776574765926725!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x396dca1b5038a9a9%3A0xa24dd2ea3059014c!2sTonk%20Rd%2C%20Jaipur%2C%20Rajasthan%20302022!5e0!3m2!1sen!2sin!4v1701748428700!5m2!1sen!2sin"
                width="100%" height="495" style="border: 0;" allowfullscreen="" loading="lazy"
                referrerpolicy="no-referrer-when-downgrade"></iframe>
        </div>
    </section>
</asp:Content>

