<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="alumni-registration.aspx.cs" Inherits="alumni_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link rel="stylesheet" type="text/css" href="../../calendar_js/epoch_styles.css" />
    <script type="text/javascript" src="../../calendar_js/epoch_classes.js"></script>
    <script type="text/javascript">
        /*You can also place this code in a separate file and link to it like epoch_classes.js*/
        var dp_cal;
        window.onload = function () {
            dp_cal = new Epoch('epoch_popup', 'popup', document.getElementById('<%=albumdate.ClientID%>'));
        };
    </script>
    <section class="sec_padding bg_double03" aria-autocomplete="none">
        <div class="container">
            <div class="hostel_form bg_07">
                <div class="form_wraper">
                    <div class="row g-4">
                        <div class="col-lg-12">
                            <div class="notice" align="left" id="trnotice" runat="server">
                                <asp:Label ID="lblnotice" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <h4 class="sub_title color_03 mb-0 font-15">Personal Detail</h4>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Name*</label>
                                <asp:TextBox ID="txtname" runat="server" class="form-control" placeholder="Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator1" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">DOB*</label>
                                <asp:TextBox ID="albumdate" runat="server" CssClass="box form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="albumdate"
                                    Display="None" ErrorMessage="Required" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="albumdate"
                                    CssClass="msgvalidator" Display="Dynamic" ErrorMessage="Invalid Date Format"
                                    ValidationExpression="^((((((((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)) ((3[01])|29))|(((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)) ((30)|(29)))|(((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?))) (2[0-8]|(1\d)|(0?[1-9])))),? )|(((((1[02])|(0?[13578]))[\.\-/]((3[01])|29))|(((11)|(0?[469]))[\.\-/]((30)|(29)))|(((1[0-2])|(0?[1-9]))[\.\-/](2[0-8]|(1\d)|(0?[1-9]))))[\.\-/])|(((((3[01])|29)[ \-\./]((jan(uary)?)|(mar(ch)?)|(may)|(july?)|(aug(ust)?)|(oct(ober)?)|(dec(ember)?)))|(((30)|(29))[ \.\-/]((apr(il)?)|(june?)|(sep(tember)?)|(nov(ember)?)))|((2[0-8]|(1\d)|(0?[1-9]))[ \.\-/]((jan(uary)?)|(feb(ruary)?|(mar(ch)?)|(apr(il)?)|(may)|(june?)|(july?)|(aug(ust)?)|(sep(tember)?)|(oct(ober)?)|(nov(ember)?)|(dec(ember)?)))))[ \-\./])|((((3[01])|29)((jan)|(mar)|(may)|(jul)|(aug)|(oct)|(dec)))|(((30)|(29))((apr)|(jun)|(sep)|(nov)))|((2[0-8]|(1\d)|(0[1-9]))((jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec)))))(((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2}))|((((175[3-9])|(17[6-9]\d)|(1[89]\d{2})|[2-9]\d{3})|\d{2})((((1[02])|(0[13578]))((3[01])|29))|(((11)|(0[469]))((30)|(29)))|(((1[0-2])|(0[1-9]))(2[0-8]|(1\d)|(0[1-9])))))|(((29feb)|(29[ \.\-/]feb(ruary)?[ \.\-/])|(feb(ruary)? 29,? ?)|(0?2[\.\-/]29[\.\-/]))((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26]))))|(((((([2468][048])|([3579][26]))00)|(17((56)|([68][048])|([79][26])))|(((1[89])|([2-9]\d))(([2468][048])|([13579][26])|(0[48]))))|(([02468][048])|([13579][26])))(0229)))$"></asp:RegularExpressionValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server"
                                    Enabled="true" TargetControlID="RegularExpressionValidator3" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender16" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator11" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />

                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Mobile No*</label>
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
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Email*</label>
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
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Complete Address*</label>
                                <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Enter Your Address" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtaddress"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator7" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />

                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">City*</label>
                                <asp:TextBox ID="txtcity" runat="server" class="form-control" placeholder="Enter Your City"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcity"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator2" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">State*</label>
                                <asp:TextBox ID="txtstate" runat="server" class="form-control" placeholder="Enter Your State"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtstate"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator4" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Country*</label>
                                <asp:TextBox ID="txtcountry" runat="server" class="form-control" placeholder="Enter Your Country"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcountry"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator5" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Digital Photograph</label>
                                <div class="choose_file">
                                    <input class="form-control" id="file1" runat="server" name="" placeholder="Enter Your Country" type="file" />
                                    <div class="drop_file">
                                        <span>Choose a file</span>
                                    </div>
                                    <asp:TextBox ID="uploadfile" runat="server" Visible="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="file1"
                                        Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server"
                                        Enabled="true" TargetControlID="RequiredFieldValidator15" HighlightCssClass="validatorCalloutHighlight1"
                                        CssClass="BlockPopup" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Father Name*</label>
                                <asp:TextBox ID="txtfname" runat="server" class="form-control" placeholder="Enter Your Father Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtfname"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator6" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Mobile No*</label>
                                <asp:TextBox ID="txtfmobile" runat="server" MaxLength="10" class="form-control" placeholder="Enter Mobile No"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="None"
                                    Font-Size="Smaller" ErrorMessage="Enter Mobile No." ControlToValidate="txtfmobile"
                                    ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Font-Size="Smaller"
                                    Display="None" ErrorMessage="Enter Valid Mobile No." ControlToValidate="txtfmobile"
                                    ValidationGroup="validcontact" ValidationExpression="^(\+91[\-\s]?)?[0]?(91)?[6789]\d{9}$"
                                    runat="server" />
                                <ajaxToolkit:FilteredTextBoxExtender runat="server" ValidChars="Interger" FilterMode="ValidChars"
                                    FilterType="Numbers" ID="FilteredTextBoxExtender1" TargetControlID="txtfmobile">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator10" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server"
                                    Enabled="true" TargetControlID="RegularExpressionValidator2" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Email*</label>
                                <asp:TextBox ID="txtfemail" runat="server" class="form-control" placeholder="Email*"
                                    autocomplete="none"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtfemail"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter E-mail ID" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid E-mail ID"
                                    ControlToValidate="txtfemail" ValidationGroup="validcontact" Display="None" Font-Size="Smaller"
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator9" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server"
                                    Enabled="true" TargetControlID="RegularExpressionValidator1" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <h4 class="sub_title color_03 mb-0 font-15">Qualification Details</h4>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Name of the Institution*</label>
                                <asp:DropDownList ID="ddlcollage" runat="server" class="form-select"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlcollage" InitialValue="0"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator14" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Programme Admitted*</label>
                                <asp:TextBox ID="txtprogram" runat="server" class="form-control" placeholder="Enter Programme Admitted"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtprogram"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator12" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Year of Joining (Batch)*</label>
                                <asp:TextBox ID="txtyear" runat="server" class="form-control" placeholder="Enter Your Year of Joining (Batch)"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtyear"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator13" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-12">
                            <h4 class="sub_title color_03 mb-0 font-15">Present Working Status</h4>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Present Organization*</label>
                                <asp:TextBox ID="txtorgname" runat="server" class="form-control" placeholder="Enter Your Present Organization"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtorgname"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender21" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator16" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Present Designation*</label>
                                <asp:TextBox ID="txtdesignation" runat="server" class="form-control" placeholder="Enter Your Present Designation"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtdesignation"
                                    Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server"
                                    Enabled="true" TargetControlID="RequiredFieldValidator17" HighlightCssClass="validatorCalloutHighlight1"
                                    CssClass="BlockPopup" />
                            </div>
                        </div>
                        <div class="col-md-6 col-lg-4">
                            <div class="form-group">
                                <label class="form-label" for="">Appointment Letter/ Identity card</label>
                                <div class="choose_file">
                                    <input class="form-control" id="file2" runat="server" name="" placeholder="Enter Your Country" type="file" />
                                    <div class="drop_file">
                                        <span>Choose a file</span>
                                    </div>
                                    <asp:TextBox ID="txtletter" runat="server" Visible="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="file2"
                                        Font-Size="Smaller" Display="None" ErrorMessage="Enter Name" ValidationGroup="validcontact"></asp:RequiredFieldValidator>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server"
                                        Enabled="true" TargetControlID="RequiredFieldValidator15" HighlightCssClass="validatorCalloutHighlight1"
                                        CssClass="BlockPopup" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row mt-4 g-4 align-items-end">
                        <div class="col-md-12">
                            <h4 class="sub_title color_03 mb-0 font-15">Payment</h4>
                        </div>
                        <div class="col-md-12 col-lg-6">
                            <div class="form-group">
                                <label class="form-label" for="">Payment*</label>
                                <asp:TextBox ID="txtpayment" runat="server" class="form-control" placeholder="Enter Your Present Designation"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6 text-end">
                            <div class="btn-group">
                                <asp:Button ID="btnsave" runat="server" class="btn_thm" ValidationGroup="validcontact" Text="Submit" OnClick="btnSave" />
                                <asp:Button ID="Button1" runat="server" class="btn_thm" Text="Reset" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

