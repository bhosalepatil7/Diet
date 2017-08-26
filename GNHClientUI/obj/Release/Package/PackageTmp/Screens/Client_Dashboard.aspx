<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Client_Dashboard.aspx.cs" Inherits="GNHClientUI.Client_Dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js"></script>
    <script src="../Scripts/jquery-1.4.1.js"></script>

    <script src="../assets/js/jquery.js"></script>
    <script src="../assets/js/jquery-ui.custom.js"></script>
    <script src="../assets/js/jquery.ui.touch-punch.js"></script>
    <script src="../assets/js/chosen.jquery.js"></script>
    <script src="../assets/js/fuelux/fuelux.spinner.js"></script>
    <script src="../assets/js/bootstrap-colorpicker.js"></script>
    <script src="../assets/js/jquery.knob.js"></script>
    <script src="../assets/js/jquery.autosize.js"></script>
    <script src="../assets/js/bootstrap-tag.js"></script>
    <script src="../assets/js/jquery.addnew.js"></script>
    <style type="text/css">
      
    </style>
    <style>
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

        .cur {
            cursor: not-allowed;
        }
    </style>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <h1>Dashboard </h1>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="180000"></asp:Timer>
            </div>
            <div class="container align-center">
                <div style="border: solid 1px #c5d0dc;">
                    <ul class="nav nav-pills nav-justified" style="margin: 5px;">
                        <li class="active"><span>
                            <b>
                                <asp:Label ID="lblScheduled" runat="server" Text="0"></asp:Label></b></span><a href="#tab_a" data-toggle="pill"><b>Scheduled</b></a></li>

                        <li class=""><span>
                            <b>
                                <asp:Label ID="lblInooffice" runat="server" Text="0"></asp:Label></b></span><a href="#tab_b" data-toggle="pill"><b>In Office</b></a></li>

                        <li class=""><span>
                            <b>
                                <asp:Label ID="lblFinished" runat="server" Text="0"></asp:Label></b></span><a href="#tab_c" data-toggle="pill"><b>Finished</b></a></li>
                    </ul>
                </div>
                <div class="tab-content align-center" style="margin-top: 10px">
                    <div class="tab-pane active" id="tab_a">
                        <asp:GridView ID="grdScheduled" runat="server" AutoGenerateColumns="False" PageSize="10" AllowPaging="true" EmptyDataText="No Records Found.." ShowHeader="false" Width="100%" GridLines="None" OnRowDataBound="grdScheduled_RowDataBound" OnPageIndexChanging="grdScheduled_PageIndexChanging" OnRowCommand="grdScheduled_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Enroll Date" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <img class="nav-user-photo" src="../assets/avatars/avatar2.png" alt="User's Photo">
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# Eval("Id") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <span><b>
                                            <h5>
                                                <asp:Label ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server"></asp:Label></h5>
                                        </b></span>
                                        <asp:Label ID="lblstarttime" Text='<%# Eval("StartTime") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lbl1" Text="-" runat="server"></asp:Label>
                                        <asp:Label ID="lbl2" Text='<%# Eval("EndTime") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblDiff" Text='<%# Eval("MinuteDiff") %>' runat="server" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CustID" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustID" Text='<%# Eval("CustID") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" Text="View" CausesValidation="False" CommandName="View" CommandArgument='<%# Eval("Id") %>' Width="40%" Visible="false" OnClientClick="return false" />
                                        <span onclick="return confirm('Are you sure you want to mark as in office?')">
                                            <asp:Button ID="btnMark" runat="server" Text="Mark as Inoffice" CausesValidation="False" CommandName="Mark" CommandArgument='<%# Eval("Id") %>'
                                                ToolTip="Mark" Width="40%" Visible="false" />
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pagination-ys" />
                        </asp:GridView>
                    </div>
                    <div class="tab-pane" id="tab_b">
                        <asp:GridView ID="grdInoffice" runat="server" AutoGenerateColumns="False" PageSize="5" AllowPaging="true" EmptyDataText="No Records Found.." ShowHeader="false" Width="100%" GridLines="None" OnRowDataBound="grdInoffice_RowDataBound" OnRowCommand="grdInoffice_RowCommand" OnPageIndexChanging="grdInoffice_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Enroll Date" ItemStyle-Width="20%">
                                    <ItemTemplate>

                                        <img class="nav-user-photo" src="../assets/avatars/avatar2.png" alt="User's Photo">
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# Eval("Id") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <span><b>
                                            <h5>
                                                <asp:Label ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server"></asp:Label></h5>
                                        </b></span>
                                        <asp:Label ID="lbl" Text='<%# Eval("StartTime") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lbl1" Text="-" runat="server"></asp:Label>
                                        <asp:Label ID="lbl2" Text='<%# Eval("EndTime") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblonoff" Text='<%# Eval("OnOffIndicator") %>' runat="server" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CustID" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustID" Text='<%# Eval("CustID") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Button ID="btnVisit" runat="server" Text="Start Appointment" CausesValidation="False" CommandName="Visit" CommandArgument='<%# Eval("Id") %>' Width="40%" />
                                        <%--<span onclick="return confirm('Are you sure you want to end appointment?')">--%>
                                            <asp:Button runat="server" ID="btnEnd" Text="End Appointment" CausesValidation="False" CommandName="End" CommandArgument='<%# Eval("Id") %>' Width="40%" />
                                       <%-- </span>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pagination-ys" />
                        </asp:GridView>
                    </div>
                    <div class="tab-pane" id="tab_c">
                        <asp:GridView ID="grdFinished" runat="server" AutoGenerateColumns="False" PageSize="10" AllowPaging="true" EmptyDataText="No Records Found.." ShowHeader="false" Width="100%" GridLines="None" OnRowDataBound="grdFinished_RowDataBound" OnPageIndexChanging="grdFinished_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Enroll Date" ItemStyle-Width="20%">
                                    <ItemTemplate>
                                        <img class="nav-user-photo" src="../assets/avatars/avatar2.png" alt="User's Photo">
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <span><b>
                                            <h5>
                                                <asp:Label ID="lblSubject" Text='<%# Eval("Subject") %>' runat="server"></asp:Label></h5>
                                        </b></span>
                                        <asp:Label ID="lbl" Text='<%# Eval("StartTime") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lbl1" Text="-" runat="server"></asp:Label>
                                        <asp:Label ID="lbl2" Text='<%# Eval("EndTime") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblDescription" Text='<%# Eval("Description") %>' runat="server"></asp:Label>
                                        <asp:Label ID="lblDiff" Text='<%# Eval("MinuteDiff") %>' runat="server" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CustID" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustID" Text='<%# Eval("CustID") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:Button ID="btnView" runat="server" Text="View" CausesValidation="False" CommandName="View" CommandArgument='<%# Eval("Id")  %>' Width="60%" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="pagination-ys" />
                        </asp:GridView>
                    </div>

                </div>
                <!-- tab content -->
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
