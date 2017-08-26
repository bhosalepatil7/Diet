<%@ Page Title="" Language="VB" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="false"
    CodeFile="AddNewUsers.aspx.vb" Inherits="admin_AddNewUsers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <style>
        .display {
            display: none;
        }
    </style>
    <script src="../assets/js/jquery.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= ddlGROUpID.ClientID()%>').change(function () {
                if ($(this).val().trim().toUpperCase() == "RECEPTIONIST") {
                    $('div .doctor').css('display', 'block');
                    $('div .superior').css('display', 'none');
                }
                else if ($(this).val().trim().toUpperCase() == "RESEARCH DOCTOR") {
                    $('div .doctor').css('display', 'none');
                    $('div .superior').css('display', 'block');
                }
                else {
                    $('div .doctor').css('display', 'none');
                    $('div .superior').css('display', 'none');
                }
            });
            if ($('#<%= ddlGROUpID.ClientID()%>').val().trim().toUpperCase() == "RECEPTIONIST") {
                $('div .doctor').css('display', 'block');
                $('div .superior').css('display', 'none');
            }
            else if ($('#<%= ddlGROUpID.ClientID()%>').val().trim().toUpperCase() == "RESEARCH DOCTOR") {
                $('div .doctor').css('display', 'none');
                $('div .superior').css('display', 'block');
            }
            else {
                $('div .doctor').css('display', 'none');
                $('div .superior').css('display', 'none');
            }
        });
    </script>
    <div class="page-header">
        <h1>Admin
        <small>
            <i class="ace-icon fa fa-angle-double-right"></i>
            Add New User
        </small>
        </h1>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <div class="col-sm-4 control-block"></div>
            <div class="col-sm-4 control-block">
                <asp:LinkButton CssClass="linkButton" ID="lnkEdit" runat="server" CausesValidation="false">Add New </asp:LinkButton>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="False" Font-Size="Small"
                    ForeColor="Red" Width="195px"></asp:Label>
            </div>
            <div class="col-sm-4 control-block">
                <asp:LinkButton ID="lnkSave" runat="server" CssClass="linkButton" Enabled="False">Save</asp:LinkButton>
            </div>
        </div>
    </div>
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">User ID </label>
            <div class="col-sm-4 control-block">
                <asp:TextBox ID="txtUSERID" runat="server" MaxLength="50"
                    ReadOnly="true" CssClass="DDTextBox"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">Login Id </label>
            <div class="col-sm-4 control-block">
                <asp:TextBox ID="txtUSERNAME" runat="server" MaxLength="50"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">Display Name </label>
            <div class="col-sm-4 control-block">
                <asp:TextBox ID="txtUserFullName" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">Password </label>
            <div class="col-sm-4 control-block">
                <asp:TextBox ID="txtpASSWORD" runat="server" MaxLength="60"
                    TextMode="password" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">Valid From </label>
            <div class="col-sm-6 control-block">
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="DDTextBox"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="cal" TargetControlID="txtFromDate" PopupButtonID="lnkFromDate" Format="dd-MMM-yy"></asp:CalendarExtender>
            </div>
            <div class="col-sm-2 control-block">
                <asp:ImageButton ID="lnkFromDate" runat="server"
                    ImageUrl="~/MASTER/Images/calendar.gif" CausesValidation="false" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">Valid Upto </label>
            <div class="col-sm-6 control-block">
                <asp:TextBox ID="txtToDate" runat="server" CssClass="DDTextBox"></asp:TextBox>
                <asp:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtToDate" PopupButtonID="lnkToDate" Format="dd-MMM-yy"></asp:CalendarExtender>
            </div>
            <div class="col-sm-2 control-block">
                <asp:ImageButton ID="lnkToDate" runat="server"
                    ImageUrl="~/MASTER/Images/calendar.gif" CausesValidation="false" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">Gender </label>
            <div class="col-sm-4 control-block">
                <asp:DropDownList CssClass="form-control" ID="ddlGender" runat="server">
                    <asp:ListItem Value="Select">Select</asp:ListItem>
                    <asp:ListItem Value="Male">Male</asp:ListItem>
                    <asp:ListItem Value="Female">Female</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" CssClass="err-block err-bottom" ID="ReqGender" ErrorMessage="Select Gender " Display="Dynamic" ControlToValidate="ddlGender" ForeColor="Red" InitialValue="Select" ValidationGroup="valid"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">
                Role :
            </label>
            <div class="col-sm-4 control-block">
                <asp:DropDownList ID="ddlGROUpID" runat="server" CssClass="DDDropDown" OnSelectedIndexChanged="ddlGROUpID_SelectedIndexChanged1" AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12 doctor">
            <label class="col-sm-4 control-label text-right">Select Doctor</label>
            <div class="col-sm-4 control-block">
                <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="DDDropDown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="val2" Text="Select Doctor" ForeColor="Red" Display="Dynamic" ControlToValidate="ddlDoctor" InitialValue="- -Select- -"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12 superior">
            <label class="col-sm-4 control-label text-right">Select Superior</label>
            <div class="col-sm-4 control-block">
                <asp:DropDownList ID="ddlSuperior" runat="server" CssClass="DDDropDown">
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="val3" Text="Select Superior" ForeColor="Red" Display="Dynamic" ControlToValidate="ddlSuperior" InitialValue="- -Select- -"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right">Check To Lock </label>
            <div class="col-sm-4 control-block">
                <asp:CheckBox ID="ChkBx_OpClk" runat="server" CssClass="DDTextBox"
                    ForeColor="#0066FF" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-sm-6 col-md-12">
            <label class="col-sm-4 control-label text-right"></label>
            <div class="col-sm-4 control-block">
                <asp:LinkButton ID="LinkSave1" runat="server" CssClass="DDLightHeader" Enabled="False" CausesValidation="true" ValidationGroup="valid"> Save</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
