<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="PatientDocs.aspx.cs" Inherits="GNHClientUI.PatientDocs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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

    <%--    <link href="../Scripts/bootstrap-3.3.6-dist/css/bootstrap.min.css" rel="stylesheet" />--%>
    <div class="page-header">
        <h1>Screening
		<small>
            <i class="ace-icon fa fa-angle-double-right"></i>
            Medical Examinations Upload
        </small>
        </h1>
    </div>
    <%--<asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="true" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
    --%>
    <div style="align-content: center;">

        <table class="table">
            <tr>
                <td align="right">Client Name </td>
                <td align="left">
                    <asp:TextBox ID="txtName" runat="server" TabIndex="1" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name  Required" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Desription" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,400}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Description </td>
                <td align="left">
                    <asp:TextBox ID="txtDescription" runat="server" TabIndex="2" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description  Required" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Desription" Display="Dynamic" ControlToValidate="txtDescription" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,400}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">Select File </td>
                <td align="left">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp; </td>
                <td align="left">
                    <asp:Button runat="server" ID="btnUpload" Text="Upload File" CssClass="btn btn-primary btn-md" OnClick="btnUpload_Click" CausesValidation="true" ValidationGroup="ValidationGroup" /></td>
                <%-- <td colspan="2" align="center">
                               
                            </td>--%>
            </tr>
        </table>
    </div>
    <div style="width: 98%; align-content: center; padding-top: 10px">
        <asp:GridView ID="grdClientDocs" runat="server" CssClass="table table-bordered table-striped dataTable" OnPageIndexChanging="grdClientDocs_PageIndexChanging"
            OnRowCommand="on_row" AutoGenerateColumns="False" PageSize="5" AllowPaging="true" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found.." OnRowDataBound="grdClientDocs_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Doc ID">
                    <ItemTemplate>
                        <asp:Label ID="lblId" Text='<%#Eval("CDnDocID") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblClientId" Text='<%#Eval("CDnPatientID") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client Name">
                    <ItemTemplate>
                        <asp:Label ID="lblName" Text='<%#Eval("CDsClientName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" Text='<%#Eval("CDsDescription") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="File Name">
                    <ItemTemplate>
                        <asp:Label ID="lblFileName" Text='<%# Eval("CDsFileName") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Upload Date">
                    <ItemTemplate>
                        <asp:Label ID="lblUploadDate" Text='<%# Eval("CDdtCreated","{0:dd-M-yyyy}") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnView" runat="server" Text="View" CausesValidation="False" CommandName="View" CommandArgument='<%# Eval("CDnDocID") %>'
                            ToolTip="View" Height="30px"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="pagination-ys" />
        </asp:GridView>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
