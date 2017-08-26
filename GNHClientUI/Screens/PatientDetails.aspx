<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" Inherits="Screens_PatientDetails" CodeBehind="PatientDetails.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <link href="../Scripts/Pagination.css" rel="stylesheet" />
    <style type="text/css">
        .table {
            border-bottom: 0px !important;
        }

            .table th, .table td {
                border: 0px !important;
            }

        .fixed-table-container {
            border: 0px !important;
        }

        .nopadding {
            padding: 2px !important;
            margin: 2px !important;
        }

        .btn {
            display: inline-block;
            padding: 6px 12px;
            margin-bottom: 0;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
        }
    </style>
    <div class="page-header">
        <h1>Screening
								<small>
                                    <i class="ace-icon fa fa-angle-double-right"></i>
                                    Client Details
                                </small>
        </h1>
    </div>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" UpdateMode="Conditional" runat="server">
        <ContentTemplate>

            <div class="container">
                <%--<h2 style="align-content: center">Search</h2>--%>
                <div class="form-group col-sm-6 col-md-4">
                    <label class="col-sm-4 control-label text-right">Search By:</label>
                    <div class="col-sm-8  control-block">
                        <asp:DropDownList runat="server" ID="ddlSearch" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged" TabIndex="1" CssClass="form-control">
                            <asp:ListItem Selected="True">ALL</asp:ListItem>
                            <asp:ListItem>ID</asp:ListItem>
                            <asp:ListItem>FIRSTNAME</asp:ListItem>
                            <asp:ListItem>LASTNAME</asp:ListItem>
                            <asp:ListItem>Email</asp:ListItem>
                            <asp:ListItem>Contact</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%--<asp:TextBox runat="server" ID="txtID" TabIndex="1" OnTextChanged="txtID_TextChanged" AutoPostBack="true"></asp:TextBox></td>--%>
                <%--<td style="font-weight: bold; text-align: right">By Email :</td>--%>
                <div class="form-group col-sm-6 col-md-8">
                    <div class="col-sm-8  control-block">
                        <asp:TextBox runat="server" ID="txtSearch" TabIndex="2" autocomplete="off"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-primary btn-sm" OnClick="btnSearch_Click" />&nbsp;&nbsp;&nbsp;
                        <asp:Button runat="server" ID="btnNew" Text="New Client" CssClass="btn btn-primary btn-sm" OnClick="btnNew_Click" />
                    </div>

                </div>

                <%-- <tr>
                        <td style="font-weight: bold; text-align: right">By Name :</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtName" TabIndex="2" OnTextChanged="txtName_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                        <td style="font-weight: bold; text-align: right">By Contact :</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtContact" TabIndex="2" OnTextChanged="txtContact_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                    </tr>--%>
                <%--</table>--%>
            </div>
            <div class="row align-center">
                <div class="align-center">
                    <%--     <asp:Button runat="server" ID="btnViewAll" Text="View All" CssClass="btn btn-primary btn-sm" Width="150px" OnClick="btnViewAll_Click" /></td>--%>
                    <div class="AlphabetPager">
                        <asp:Repeater ID="rptAlphabets" runat="server" OnItemCreated="rptAlphabets_ItemCreated">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkAlphabet" runat="server" Text='<%#Eval("Value")%>' Visible='<%# !Convert.ToBoolean(Eval("Selected"))%>' CssClass="btn btn-info" OnClick="lnkAlphabet_Click" />
                                <asp:Label runat="server" Text='<%#Eval("Value")%>' Visible='<%# Convert.ToBoolean(Eval("Selected"))%>' />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div style="width: 98%; align-content: center; padding-top: 10px">
                <asp:GridView ID="grdPatients" runat="server" CssClass="table table-bordered table-striped dataTable"
                    OnRowCommand="on_row" AutoGenerateColumns="False" AllowPaging="false" PageSize="10" OnRowDataBound="grdPatients_RowDataBound" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found..">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client ID">
                            <ItemTemplate>
                                <asp:Label ID="lblId" Text='<%#Eval("PatientID") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Client Name">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnView" runat="server" Text='<%#Eval("PatientName") +" "+ Eval("MiddleName")+" "+Eval("LastName")  %>' CausesValidation="False" CommandName="View" CommandArgument='<%# Eval("PatientID") %>'
                                    ToolTip="View"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="Middle Name">
                            <ItemTemplate>
                                <asp:Label ID="lblMiddlename" Text='<%#Eval("MiddleName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Last Name">
                            <ItemTemplate>
                                <asp:Label ID="lblLastname" Text='<%#Eval("LastName") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <asp:Label ID="lblGender" Text='<%#Eval("Gender") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress" Text='<%#Eval("Address1") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Area">
                            <ItemTemplate>
                                <asp:Label ID="lblAddress2" Text='<%#Eval("Locality") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Profession">
                            <ItemTemplate>
                                <asp:Label ID="lblProfession" Text='<%#Eval("Profession") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile">
                            <ItemTemplate>
                                <asp:Label ID="lblContact" Text='<%#Eval("Contact") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate>
                                <asp:Label ID="lblEmail" Text='<%#Eval("Email") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Enroll Date">
                            <ItemTemplate>
                                <asp:Label ID="lblEnrollDate" Text='<%# Eval("enrollDate","{0:dd-M-yyyy}") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visits">
                            <ItemTemplate>
                                <asp:Label ID="lblVisits" Text='<%#Eval("Visits") %>' runat="server"></asp:Label>
                                <%-- <asp:LinkButton ID="btnView" runat="server" Text="View" CausesValidation="False" CommandName="View" CommandArgument='<%# Eval("PatientID") %>'
                                    ToolTip="View" Height="30px"></asp:LinkButton>--%><%--|--%>
                                <%-- <span onclick="return confirm('Are you sure want to mark this as visit?')">
                                    <asp:LinkButton ID="btnVisit" runat="server" Text="Mark as Visit" CausesValidation="False" CommandName="Visit" CommandArgument='<%# Eval("PatientID") %>'
                                        ToolTip="Mark as Visit" Height="30px"></asp:LinkButton></span>--%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rptAlphabets" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

