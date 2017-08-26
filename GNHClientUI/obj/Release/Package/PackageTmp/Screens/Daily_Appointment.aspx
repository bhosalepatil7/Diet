<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Daily_Appointment.aspx.cs" Inherits="GNHClientUI.Daily_Appointment" %>

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
    <div class="page-header">
        <h1>Today's Appointments</h1>
    </div>
    <div class="container">
        <%--<h2 style="align-content: center">Search</h2>--%>


        <div style="width: 90%; align-content: center; padding-top: 10px">
            <asp:GridView ID="grdClient" runat="server" CssClass="table table-bordered table-striped dataTable"
                AutoGenerateColumns="False" PageSize="10" AllowPaging="true" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found.." OnRowDataBound="grdClient_RowDataBound" OnRowCommand="grdClient_RowCommand" OnPageIndexChanging="grdClient_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Client ID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" Text='<%#Eval("Id") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <img class="nav-user-photo" src="../assets/avatars/avatar2.png" alt="User's Photo">
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                        <ItemTemplate>
                            <span><b>

                                <asp:Label ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server"></asp:Label>
                            </b></span>

                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
                        <ItemTemplate>
                            <asp:Label ID="lblstarttime" Text='<%# Eval("StartTime") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Description" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                            <asp:Label ID="lblStatus" Text='<%# Eval("Status") %>' runat="server" Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="left">
                        <ItemTemplate>
                            <span onclick="return confirm('Are you sure want to mak as in office?')">
                            <asp:Button ID="btnMark" runat="server" Text="Mark as Inoffice" CausesValidation="False" CommandName="Mark" CommandArgument='<%# Eval("Id") %>'
                                ToolTip="Mark" Width="80%"/>
                                </span>
                            <%--<asp:LinkButton ID="btnVisit" runat="server" Text="Mark as Visit" CausesValidation="False" CommandName="Visit" CommandArgument='<%# Eval("Id") %>'
                                        ToolTip="Mark as Visit" Height="30px"></asp:LinkButton></span>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
