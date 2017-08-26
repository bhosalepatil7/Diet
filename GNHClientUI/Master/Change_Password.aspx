<%@ Page Language="VB" MasterPageFile="~/MASTER/MasterPage2.master" AutoEventWireup="false" CodeFile="Change_Password.aspx.vb" Inherits="MASTER_Change_Password" Title="Geeta Nutri Heal" EnableViewState="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">

    <script language="javascript" type="text/javascript">
        function keyEnterCheck() {
            if (event.keyCode == 13) {
                event.returnValue = false;
                return false;
            }
        }

        function passwordChanged() {
            var strength = document.getElementById('strength');
            var strongRegex = new RegExp("^(?=.{8,})(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*\\W).*$", "g");
            var mediumRegex = new RegExp("^(?=.{7,})(((?=.*[A-Z])(?=.*[a-z]))|((?=.*[A-Z])(?=.*[0-9]))|((?=.*[a-z])(?=.*[0-9]))).*$", "g");
            var enoughRegex = new RegExp("(?=.{6,}).*", "g");
            var pwd = document.getElementById("ctl00_ContentPlaceHolder1_txt_newpassword");

            if (pwd.value.length == 0) {
                strength.innerHTML = '';
            }
            else if (false == enoughRegex.test(pwd.value)) {
                strength.innerHTML = 'More Characters';
                Message.innerHTML = '';
            }
            else if (strongRegex.test(pwd.value)) {
                //strength.innerHTML = '<span style="color:green">  Strong  <br></span>';
                strength.innerHTML = '<span  style="height: 8px; width: 100px" > <asp:TextBox ID="Strong" runat="server" BackColor="Green" Height="7px" ReadOnly="True" Width="100px" ></asp:TextBox> </span>';
                Message.innerHTML = '<span style="color:Black">  &nbsp;&nbsp;Strong</span>';

                //style="height: 9px; width: 98px; background-color: red;" 
            }
            else if (mediumRegex.test(pwd.value)) {
                //strength.innerHTML = '<span style="color:orange">Medium!</span>';
                strength.innerHTML = '<span style="height: 8px; width: 100px" > <asp:TextBox ID="Medium" runat="server" BackColor="Orange" Height="7px" ReadOnly="True" Width="75px" ></asp:TextBox> </span>';
                Message.innerHTML = '<span style="color:Black">  &nbsp;&nbsp;Medium</span>';
            }
            else {
                //strength.innerHTML = '<span style="color:red">Weak!</span>';
                strength.innerHTML = '<span style="height: 8px; width: 100px" > <asp:TextBox ID="Weak" runat="server" BackColor="Red" Height="7px" ReadOnly="True" Width="50px" ></asp:TextBox> </span>';
                Message.innerHTML = '<span style="color:Black">  &nbsp;&nbsp;Weak</span>';
            }





        }
    </script>


    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table class="style15">
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label runat="server" ID="Label10" Font-Bold="True" Font-Size="Large"
                    ForeColor="#0066FF">Profile Settings</asp:Label>
            </td>
        </tr>

        <%--Display Name--%>

        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label1" runat="server"
                    CssClass="Label" Text="Display Name" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtName" runat="server" Visible="true" TabIndex="1" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtName" ErrorMessage="Please enter name"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid Name" Display="Dynamic"
                            ControlToValidate="txtName" ValidationGroup="b" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z ]{1,50}$"></asp:RegularExpressionValidator>--%>
                <br />
            </td>

            <%--Gender--%>

            <%--        <tr>--%>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label11" runat="server"
                    CssClass="Label" Text="Gender" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>
            <td style="height: 29px">
                <asp:DropDownList CssClass="form-control" ID="ddlGender" runat="server" TabIndex="2">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" CssClass="err-block err-bottom" ID="ReqGender" ErrorMessage="Select Gender " Display="Dynamic" ControlToValidate="ddlGender" ValidationGroup="b" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
            </td>

        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>

        <%--Clinic Name--%>

        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label15" runat="server"
                    CssClass="Label" Text="Clinic Name" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtClinicName" runat="server" Visible="true" TabIndex="3" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                    ControlToValidate="txtClinicName" ErrorMessage="Please enter clinic name"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid clinic name" Display="Dynamic"
                            ControlToValidate="txtClinicName" ValidationGroup="b" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z ]{1,50}$"></asp:RegularExpressionValidator>--%>
                <br />
            </td>


            <%--  <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>--%>

            <%--Report Heading--%>

            <td align="right" style="height: 29px">
                <asp:Label ID="Label16" runat="server"
                    CssClass="Label" Text="Report Heading" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtReportHeading" runat="server" Visible="true" TabIndex="4" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                    ControlToValidate="txtReportHeading" ErrorMessage="Please enter report heading"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Invalid report heading" Display="Dynamic"
                            ControlToValidate="txtReportHeading" ValidationGroup="b" ForeColor="Red"
                            ValidationExpression="^[a-zA-Z ]{1,50}$"></asp:RegularExpressionValidator>--%>
                <br />
            </td>
        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>

        <%--Contact--%>

        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label2" runat="server"
                    CssClass="Label" Text="Contact" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtContact" runat="server" Visible="true" TabIndex="5" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                    ControlToValidate="txtContact" ErrorMessage="Please enter contact"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Contact" Display="Dynamic"
                    ControlToValidate="txtContact" ValidationGroup="b" ForeColor="Red"
                    ValidationExpression="^((\+\d{1,3}(-| )?\(?\d\)?(-| )?\d{1,3})|(\(?\d{2,3}\)?))(-| )?(\d{3,4})(-| )?(\d{4})(( x| ext)\d{1,5}){0,1}$"></asp:RegularExpressionValidator>
                <br />
            </td>
            <%--<tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>--%>

            <%--Alternate Cotact--%>

            <td align="right" style="height: 29px">
                <asp:Label ID="Label3" runat="server"
                    CssClass="Label" Text="Alternate Contact" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtAlternateContact" runat="server" Visible="true" TabIndex="6" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                    ControlToValidate="txtAlternateContact" ErrorMessage="Please enter contact"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Contact" Display="Dynamic"
                    ControlToValidate="txtAlternateContact" ValidationGroup="b" ForeColor="Red"
                    ValidationExpression="^((\+\d{1,3}(-| )?\(?\d\)?(-| )?\d{1,3})|(\(?\d{2,3}\)?))(-| )?(\d{3,4})(-| )?(\d{4})(( x| ext)\d{1,5}){0,1}$"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>

        <%--Landline--%>

        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label4" runat="server"
                    CssClass="Label" Text="Landline" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtLandline" runat="server" Visible="true" TabIndex="7" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <%--                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                    ControlToValidate="txtLandline" ErrorMessage="Please enter landline"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid landline" Display="Dynamic"
                    ControlToValidate="txtLandline" ValidationGroup="b" ForeColor="Red"
                    ValidationExpression="^((\+\d{1,3}(-| )?\(?\d\)?(-| )?\d{1,3})|(\(?\d{2,3}\)?))(-| )?(\d{3,4})(-| )?(\d{4})(( x| ext)\d{1,5}){0,1}$"></asp:RegularExpressionValidator>--%>
                <br />
            </td>

            <%--  <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>--%>

            <%--STD Code--%>

            <td align="right" style="height: 29px">
                <asp:Label ID="Label6" runat="server"
                    CssClass="Label" Text="STD Code" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtStdCode" runat="server" Visible="true" TabIndex="8" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                    ControlToValidate="txtStdCode" ErrorMessage="Please enter STD code"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid STD code" Display="Dynamic"
                            ControlToValidate="txtStdCode" ValidationGroup="b" ForeColor="Red"
                            ValidationExpression="^\d{2,3}$"></asp:RegularExpressionValidator>
                --%>
                <br />
            </td>
        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>


        <%--Address--%>
        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label12" runat="server"
                    CssClass="Label" Text="Address" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtAddress" runat="server" Visible="true" TabIndex="9" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                    ControlToValidate="txtAddress" ErrorMessage="Please enter address"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid address" Display="Dynamic"
                    ControlToValidate="txtAddress" ValidationGroup="b" ForeColor="Red"
                    ValidationExpression="^[a-zA-Z ]{1,250}$"></asp:RegularExpressionValidator>--%>
                <br />
            </td>
            <%-- </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>--%>

            <%--Qualification--%>
            <%-- <tr>--%>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label14" runat="server"
                    CssClass="Label" Text="Qualification" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtQualification" runat="server" Visible="true" TabIndex="10" Width="185px"></asp:TextBox>
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                    ControlToValidate="txtQualification" ErrorMessage="Please enter qualification"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid qualification" Display="Dynamic"
                    ControlToValidate="txtQualification" ValidationGroup="b" ForeColor="Red"
                    ValidationExpression="^[a-zA-Z ]{1,250}$"></asp:RegularExpressionValidator>--%>
                <br />
            </td>
        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>

        <%--DOB--%>

        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label13" runat="server"
                    CssClass="Label" Text="DOB" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">&nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txtDOB" runat="server" TabIndex="11" autocomplete="off" PlaceHolder="dd/MM/yyyy" Style="cursor: auto !important"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="cal" TargetControlID="txtDOB" PopupButtonID="lnkFromDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                <asp:ImageButton ID="lnkFromDate" runat="server"
                    ImageUrl="~/MASTER/Images/calendar.gif" TabIndex="10" />
            </td>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator11" runat="server" ErrorMessage="DOB Required" Display="Dynamic" ControlToValidate="txtDOB" ValidationGroup="b" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                <br />
            </td>
            <%--</tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>--%>
            <%--    <td></td>--%>
            <%--Country--%>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label7" runat="server"
                    CssClass="Label" Text="Country" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>
            <td style="height: 29px">
                <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Country_Changed" CssClass="form-control" TabIndex="12">
                </asp:DropDownList>
                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Country" Display="Dynamic" ControlToValidate="ddlCountries" ValidationGroup="b" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
            </td>

        </tr>

        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>

        <%--State--%>

        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label8" runat="server"
                    CssClass="Label" Text="State" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>
            <td style="height: 29px">
                <asp:DropDownList ID="ddlStates" runat="server" AutoPostBack="true" OnSelectedIndexChanged="State_Changed" CssClass="form-control" TabIndex="13">
                </asp:DropDownList>
                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator66" runat="server" ErrorMessage="Select States " Display="Dynamic" ControlToValidate="ddlStates" ValidationGroup="b" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
            <td></td>
            <%--City--%>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label9" runat="server"
                    CssClass="Label" Text="City" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b></td>
            <td style="height: 29px">
                <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control" TabIndex="14">
                </asp:DropDownList>
                <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Select Cities " Display="Dynamic" ControlToValidate="ddlCities" ValidationGroup="b" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
        </tr>




        <%--        <tr>
            <td colspan="4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="txtName" ErrorMessage="Please enter name"
                    ValidationGroup="b" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid Name" Display="Dynamic"
                    ControlToValidate="txtName" ValidationGroup="b" ForeColor="Red"
                    ValidationExpression="^[a-zA-Z ]{1,50}$"></asp:RegularExpressionValidator>
                <br />
            </td>
        </tr>--%>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:Button ID="btnProfile" runat="server" CssClass="Button"
                    Text="Save Profile" ValidationGroup="b" Width="152px" OnClick="btnProfile_Click" />
                <br />
                <hr style="width: 60%;" size="2" />
            </td>
        </tr>


        <tr>
            <td align="right" style="height: 29px">
                <asp:Label ID="Label5" runat="server"
                    CssClass="Label" Text="Enter Old Password" Font-Bold="True" ForeColor="#204673"></asp:Label>
            </td>
            <td style="width: 6px; height: 29px;"><b>:</b></td>
            <td style="height: 29px">
                <asp:TextBox ID="txt_oldpassword" runat="server" AutoCompleteType="Disabled"
                    BackColor="White" CssClass="TextBox" TextMode="Password" Width="185px"
                    MaxLength="15" TabIndex="2"></asp:TextBox>
                &nbsp;<%--<asp:Button ID="btn_OldPassword" runat="server" CssClass="Button" Text="Ok" 
                    Width="48px" TabIndex="2" />--%>
                <asp:TextBox ID="txt_oldpwd" runat="server" AutoCompleteType="Disabled" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="height: 4px"></td>
            <td style="width: 6px; height: 4px;"></td>
            <td style="height: 4px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:LinkButton ID="lnk_passwordStrength" runat="server"
                    CausesValidation="False" CssClass="Link_password" Visible="False"
                    OnClientClick="window.open('Password_strength.aspx?textbox=txtFromDate','cal','width=520,height=575,left=350,top=50')">Password 
                Strength</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_NewPassword" runat="server" CssClass="Label"
                    Text="Enter New Password" Visible="False" Font-Bold="True" ForeColor="#204673"></asp:Label></td>
            <td style="width: 6px">
                <asp:Label ID="lbl_Dot_NewPassword" runat="server"
                    Font-Bold="True" Text=":"></asp:Label></td>
            <td>
                <asp:TextBox ID="txt_newpassword" runat="server" onkeyup="passwordChanged();"
                    BackColor="White" CssClass="TextBox" TextMode="Password" AutoCompleteType="Disabled"
                    Visible="False" Width="185px" MaxLength="15" ValidationGroup="a" TabIndex="3"></asp:TextBox>
                <span id="strength"></span>
                <span id="Message"></span>

                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="txt_newpassword" ErrorMessage="Please Enter New Password"
                    ValidationGroup="a" Visible="False" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_ConfirmPassword" runat="server"
                    CssClass="Label" Text="Confirm New Password" Visible="False" Font-Bold="True" ForeColor="#204673"></asp:Label></td>
            <td style="width: 6px">
                <asp:Label ID="lbl_Dot_ConfirmPassword" runat="server"
                    Font-Bold="True" Text=":"></asp:Label></td>
            <td>
                <asp:TextBox ID="txt_confirmpassword" runat="server" BackColor="White" AutoCompleteType="Disabled"
                    CssClass="TextBox" TextMode="Password" Visible="False" Width="185px"
                    MaxLength="15" ValidationGroup="a" TabIndex="4"></asp:TextBox>
                &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server"
                    ControlToCompare="txt_newpassword" ControlToValidate="txt_confirmpassword"
                    ErrorMessage="Password Does Not Match" Visible="False" ForeColor="Red"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                    ControlToValidate="txt_confirmpassword" ErrorMessage="Please Confirm Password"
                    ValidationGroup="a" Visible="False" ForeColor="Red"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">&nbsp;</td>
            <td style="width: 6px">&nbsp;</td>
            <td>
                <asp:Button ID="btn_ChangePassword" runat="server" CssClass="Button"
                    Text="Change Password" Visible="False" ValidationGroup="a" Width="152px"
                    TabIndex="5" /></td>
        </tr>
    </table>
</asp:Content>
