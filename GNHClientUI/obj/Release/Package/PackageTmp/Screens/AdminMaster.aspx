<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="AdminMaster.aspx.cs" Inherits="GNHClientUI.Screens.AdminMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script src="../assets/js/jquery.js"></script>
    <script src="../assets/js/jquery-ui.custom.js"></script>
    <script src="../assets/js/jquery.ui.touch-punch.js"></script>
    <script src="../assets/js/chosen.jquery.js"></script>
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
    <script type="text/javascript">
        $(document).ready(function () {

            $("body").keydown(function (event) {
                switch (event.which) {
                    case 37: //Arrow left
                        $('.nav-tabs > .active').prev('li').find('a.lnk').trigger('click');
                        break;
                    case 39: //Arrow left
                        $('.nav-tabs > .active').next('li').find('a.lnk').trigger('click');
                        break;
                }
            });

            SetTabs();
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        SetTabs();
                    }
                });
            };
        });
        function SetTabs() {

            if ($("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName1']").val() == "") {
                $("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName1']").val('tabs-1');
            }

            $("#tabs a.lnk").click(function () {
                $("[id*='ContentPlaceHolder1_ContentPlaceHolder3_TabName1']").val($(this).attr("href").replace("#", ""));
            });
            var tabName = $("#ContentPlaceHolder1_ContentPlaceHolder3_TabName1").val();
            $('#tabs a.lnk[href="#' + tabName + '"]').trigger('click');


        };

    </script>
    <style>
        #tabs {
            font-size: 14px;
        }

        .ui-widget-header {
            background: #b9cd6d;
            border: 1px solid #b9cd6d;
            color: #FFFFFF;
            font-weight: bold;
        }
    </style>
    <div class="page-header">
        <h1>Admin
		<small><i class="ace-icon fa fa-angle-double-right"></i>Diet Masters</small>
        </h1>
    </div>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="TabName1" runat="server" />

            <div id="tabs">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#tabs-1" data-toggle="tab" class="lnk">Food Master</a></li>
                    <li><a href="#tabs-2" data-toggle="tab" class="lnk">Disease Master</a></li>
                    <li><a href="#tabs-3" data-toggle="tab" class="lnk">Excercise Master</a></li>
                    <li><a href="#tabs-4" data-toggle="tab" class="lnk">DrugSupplement Master</a></li>
                    <li><a href="#tabs-5" data-toggle="tab" class="lnk">Season Master</a></li>
                    <li><a href="#tabs-6" data-toggle="tab" class="lnk">Allergy Master</a></li>
                    <li><a href="#tabs-7" data-toggle="tab" class="lnk">Unit Master</a></li>
                    <li><a href="#tabs-8" data-toggle="tab" class="lnk">Category Master</a></li>
                </ul>
                <div class="tab-content">
                    <div id="tabs-1" class="tab-pane fade in active">
                        <div style="padding-bottom: 6px">
                            <label class="text-center"><b>Search :</b></label>
                            <asp:TextBox runat="server" ID="txtSearch" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                        </div>
                        <div class="AlphabetPager">
                            <asp:Repeater ID="rptAlphabets" runat="server" OnItemCreated="rptAlphabets_ItemCreated">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkAlphabet" runat="server" Text='<%#Eval("Value")%>' Visible='<%# !Convert.ToBoolean(Eval("Selected"))%>' CssClass="btn btn-info" />
                                    <asp:Label runat="server" Text='<%#Eval("Value")%>' Visible='<%# Convert.ToBoolean(Eval("Selected"))%>' />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div style="width: 100%; align-content: center; overflow-y: auto">
                            <asp:GridView ID="GridFood" runat="server" AutoGenerateColumns="false" OnRowCommand="on_row_Food" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="GridFood_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." DataKeyNames="FMnFoodID" OnRowDataBound="GridFood_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("FMnFoodID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("FMnFoodID") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Food Name" SortExpression="FMsFoodName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFoodName" runat="server" Text='<%#Eval("FMsFoodName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditFoodName" Text='<%#Eval("FMsFoodName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ErrorMessage="FoodName  Required" Display="Dynamic" ControlToValidate="EditFoodName" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtFoodName" ToolTip="Enter Food Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ErrorMessage="FoodName Required" Display="Dynamic" ControlToValidate="txtFoodName" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("FMnQuantity") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditQuantity" Text='<%#Eval("FMnQuantity") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ErrorMessage="Quantity  Required" Display="Dynamic" ControlToValidate="EditQuantity" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator123" runat="server" ErrorMessage="Invalid Quantity " Display="Dynamic" ControlToValidate="EditQuantity" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtQuantity" Style="width: 80px" ToolTip="Enter Food Quantity"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator124" runat="server" ErrorMessage="Quantity Required" Display="Dynamic" ControlToValidate="txtQuantity" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator125" runat="server" ErrorMessage="Invalid Quantity " Display="Dynamic" ControlToValidate="txtQuantity" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("FMsUnit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblunit" Text='<%#Eval("FMsUnit") %>' Style="width: 80px" Visible="false"></asp:Label>
                                            <asp:DropDownList runat="server" ID="EditUnit" Style="width: 80px"></asp:DropDownList>
                                                                                        <asp:TextBox runat="server" ID="EditUnit" Text='<%#Eval("FMsUnit") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator126" runat="server" ErrorMessage="Unit  Required" Display="Dynamic" ControlToValidate="EditUnit" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator127" runat="server" ErrorMessage="Invalid Unit " Display="Dynamic" ControlToValidate="EditUnit" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList runat="server" ID="ddlUnit" Style="width: 80px"></asp:DropDownList>
                                                                                        <asp:TextBox runat="server" ID="txtUnit" Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator128" runat="server" ErrorMessage="Unit Required" Display="Dynamic" ControlToValidate="txtUnit" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator129" runat="server" ErrorMessage="Invalid Unit " Display="Dynamic" ControlToValidate="txtUnit" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Food Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFoodType" runat="server" Text='<%#Eval("FMsFoodType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblfoodtype" Text='<%#Eval("FMsFoodType") %>' Style="width: 80px" Visible="false"></asp:Label>
                                            <asp:DropDownList runat="server" ID="EditFoodType" Style="width: 80px"></asp:DropDownList>
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator201" runat="server" ErrorMessage="FoodType  Required" Display="Dynamic" ControlToValidate="EditFoodType" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator127" runat="server" ErrorMessage="Invalid FoodType " Display="Dynamic" ControlToValidate="EditFoodType" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>--%>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:DropDownList runat="server" ID="ddlFoodType" Style="width: 80px" ToolTip="Select Food Type"></asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator202" runat="server" ErrorMessage="Food Type Required" Display="Dynamic" ControlToValidate="ddlFoodType" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator203" runat="server" ErrorMessage="Invalid Food Type " Display="Dynamic" ControlToValidate="ddlFoodType" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Energy (kcal)" SortExpression="FMnEnergy" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEnergy" runat="server" Text='<%#Eval("FMnEnergy") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditEnergy" Text='<%#Eval("FMnEnergy") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator83" runat="server" ErrorMessage="Energy  Required" Display="Dynamic" ControlToValidate="EditEnergy" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator109" runat="server" ErrorMessage="Invalid Energy " Display="Dynamic" ControlToValidate="EditEnergy" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtEnergy" Style="width: 80px" ToolTip="Enter food Energy"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator84" runat="server" ErrorMessage="Energy Required" Display="Dynamic" ControlToValidate="txtEnergy" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator85" runat="server" ErrorMessage="Invalid Energy " Display="Dynamic" ControlToValidate="txtEnergy" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Protien (g)" SortExpression="FMnProtein" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProtien" runat="server" Text='<%#Eval("FMnProtein") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditProtien" Text='<%#Eval("FMnProtein") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator86" runat="server" ErrorMessage="Protien  Required" Display="Dynamic" ControlToValidate="EditProtien" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator110" runat="server" ErrorMessage="Invalid Protien " Display="Dynamic" ControlToValidate="EditProtien" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtProtien" Style="width: 80px" ToolTip="Enter food Protein"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ErrorMessage="Protien Required" Display="Dynamic" ControlToValidate="txtProtien" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator88" runat="server" ErrorMessage="Invalid Protien " Display="Dynamic" ControlToValidate="txtProtien" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Carbohydrate (g)" SortExpression="FMnCarbohydrate" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCarbohydrate" runat="server" Text='<%#Eval("FMnCarbohydrate") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditCarbohydrate" Text='<%#Eval("FMnCarbohydrate") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator80" runat="server" ErrorMessage="Carbohydrate  Required" Display="Dynamic" ControlToValidate="EditCarbohydrate" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator108" runat="server" ErrorMessage="Invalid Carbohydrate " Display="Dynamic" ControlToValidate="EditCarbohydrate" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtCarbohydrate" Style="width: 80px" ToolTip="Enter food Carbohydrate"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator81" runat="server" ErrorMessage="Carbohydrate Required" Display="Dynamic" ControlToValidate="txtCarbohydrate" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator82" runat="server" ErrorMessage="Invalid Carbohydrate " Display="Dynamic" ControlToValidate="txtCarbohydrate" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fiber (mcg)" SortExpression="FMnFibre" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFiber" runat="server" Text='<%#Eval("FMnFibre") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditFiber" Text='<%#Eval("FMnFibre") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ErrorMessage="Fiber  Required" Display="Dynamic" ControlToValidate="EditFiber" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator107" runat="server" ErrorMessage="Invalid Fiber " Display="Dynamic" ControlToValidate="EditFiber" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtFiber" Style="width: 80px" ToolTip="Enter food Fiber"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ErrorMessage="Fiber Required" Display="Dynamic" ControlToValidate="txtFiber" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator79" runat="server" ErrorMessage="Invalid Fiber " Display="Dynamic" ControlToValidate="txtFiber" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fat (g)" SortExpression="FMnFat" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFat" runat="server" Text='<%#Eval("FMnFat") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditFat" Text='<%#Eval("FMnFat") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" ErrorMessage="Fat  Required" Display="Dynamic" ControlToValidate="EditFat" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator111" runat="server" ErrorMessage="Invalid Fat " Display="Dynamic" ControlToValidate="EditFat" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtFat" Style="width: 80px" ToolTip="Enter food Fat"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ErrorMessage="Fat Required" Display="Dynamic" ControlToValidate="txtFat" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator91" runat="server" ErrorMessage="Invalid Fat " Display="Dynamic" ControlToValidate="txtFat" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Calories">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCalories" runat="server" Text='<%#Eval("FMnCalories") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditCalories" Text='<%#Eval("FMnCalories") %>' Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ErrorMessage="Calories  Required" Display="Dynamic" ControlToValidate="EditCalories" ValidationGroup="UpdateValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator112" runat="server" ErrorMessage="Invalid Calories " Display="Dynamic" ControlToValidate="EditCalories" ValidationGroup="UpdateValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtCalories" Style="width: 80px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ErrorMessage="Calories Required" Display="Dynamic" ControlToValidate="txtCalories" ValidationGroup="FooterValidation" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator94" runat="server" ErrorMessage="Invalid Calories " Display="Dynamic" ControlToValidate="txtCalories" ValidationGroup="FooterValidation" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate_Food" runat="server" CausesValidation="True" CommandName="Update_Food" ValidationGroup="UpdateValidation"
                                                CommandArgument='<%#Eval("FMnFoodID") %>' Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel_Food" runat="server" CausesValidation="False" CommandName="Cancel_Food"
                                                CommandArgument='<%#Eval("FMnFoodID") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit_Food" runat="server" CausesValidation="False" CommandName="Edit_Food"
                                                CommandArgument='<%#Eval("FMnFoodID") %>'>Edit</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete_Food" runat="server" CausesValidation="False" CommandName="Delete_Food"
                                            CommandArgument='<%# Eval("FMnFoodID") %>'>Delete</asp:LinkButton></span>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd_Food" CommandName="Insert_Food" runat="server" CausesValidation="true" ValidationGroup="FooterValidation">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>

                    </div>
                    <div id="tabs-2" class="tab-pane fade">
                        <div style="width: 100%; align-content: center">
                            <asp:GridView ID="GridDisease" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" OnRowCommand="on_row_Disease" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="GridDisease_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." AllowSorting="true" OnSorting="GridDisease_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Disease ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("DMnDiseaseID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("DMnDiseaseID") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Disease Name" SortExpression="DMsDiseaseName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDisease" runat="server" Text='<%#Eval("DMsDiseaseName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditDisease" Text='<%#Eval("DMsDiseaseName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="Disease Name Required" Display="Dynamic" ControlToValidate="EditDisease" ValidationGroup="UpdateValidation2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtDisease" ToolTip="Enter Disease Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="Disease Name Required" Display="Dynamic" ControlToValidate="txtDisease" ValidationGroup="FooterValidation2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Food Name" SortExpression="DMsFoodName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFoodName" runat="server" Text='<%#Eval("DMsFoodName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditFoodName" Text='<%#Eval("DMsFoodName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage="FoodName Type Required" Display="Dynamic" ControlToValidate="EditFoodName" ValidationGroup="UpdateValidation2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtFoodName" ToolTip="Enter Disease Food"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage="FoodName Required" Display="Dynamic" ControlToValidate="txtFoodName" ValidationGroup="FooterValidation2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exercise Name" SortExpression="DMsExersiceName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExersiceName" runat="server" Text='<%#Eval("DMsExersiceName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditExersiceName" Text='<%#Eval("DMsExersiceName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="ExersiceName Type Required" Display="Dynamic" ControlToValidate="EditExersiceName" ValidationGroup="UpdateValidation2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtExersiceName" ToolTip="Enter Disease Exercise"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="ExersiceName Required" Display="Dynamic" ControlToValidate="txtExersiceName" ValidationGroup="FooterValidation2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate_Disease" runat="server" CausesValidation="True" CommandName="Update_Disease" ValidationGroup="UpdateValidation2"
                                                CommandArgument='<%#Eval("DMnDiseaseID") %>' Text="Update" OnClientClick="SetTabs()"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel_Disease" runat="server" CausesValidation="False" CommandName="Cancel_Disease"
                                                CommandArgument='<%#Eval("DMnDiseaseID") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit_Disease" runat="server" CausesValidation="False" CommandName="Edit_Disease"
                                                CommandArgument='<%#Eval("DMnDiseaseID") %>'>Edit</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete_Disease" runat="server" CausesValidation="False" CommandName="Delete_Disease"
                                            CommandArgument='<%#Eval("DMnDiseaseID") %>'>Delete</asp:LinkButton></span>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd_Disease" CommandName="Insert_Disease" runat="server" CausesValidation="true" ValidationGroup="FooterValidation2">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="tabs-3" class="tab-pane fade">
                        <div style="width: 100%; align-content: center">
                            <asp:GridView ID="GridExercise" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" OnRowCommand="on_row_Exercise" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="GridExercise_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." AllowSorting="true" OnSorting="GridExercise_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Exercise ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("EMnExerciseID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("EMnExerciseID") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exercise Name" SortExpression="EMsExerciseName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExercise" runat="server" Text='<%#Eval("EMsExerciseName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditExercise" Text='<%#Eval("EMsExerciseName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Exercise Name Required" Display="Dynamic" ControlToValidate="EditExercise" ValidationGroup="UpdateValidation3" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtExercise" ToolTip="Enter Exercise Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Exercise Name Required" Display="Dynamic" ControlToValidate="txtExercise" ValidationGroup="FooterValidation3" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exercise Type" SortExpression="EMsExerciseType" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("EMsExerciseType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditType" Text='<%#Eval("EMsExerciseType") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="Exercise Type Required" Display="Dynamic" ControlToValidate="EditType" ValidationGroup="UpdateValidation3" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator117" runat="server" ErrorMessage="Invalid Exercise Type" Display="Dynamic" ControlToValidate="EditType" ValidationGroup="UpdateValidation3" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtType" ToolTip="Enter Exercise Type"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Exercise Type Required" Display="Dynamic" ControlToValidate="txtType" ValidationGroup="FooterValidation3" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Exercise Type" Display="Dynamic" ControlToValidate="txtType" ValidationGroup="FooterValidation3" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate_Exercise" runat="server" CausesValidation="True" CommandName="Update_Exercise" ValidationGroup="UpdateValidation3"
                                                CommandArgument='<%#Eval("EMnExerciseID") %>' Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel_Exercise" runat="server" CausesValidation="False" CommandName="Cancel_Exercise"
                                                CommandArgument='<%#Eval("EMnExerciseID") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit_Exercise" runat="server" CausesValidation="False" CommandName="Edit_Exercise"
                                                CommandArgument='<%#Eval("EMnExerciseID") %>'>Edit</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete_Exercise" runat="server" CausesValidation="False" CommandName="Delete_Exercise"
                                            CommandArgument='<%#Eval("EMnExerciseID") %>'>Delete</asp:LinkButton></span>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd_Exercise" CommandName="Insert_Exercise" runat="server" CausesValidation="true" ValidationGroup="FooterValidation3">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="tabs-4" class="tab-pane fade">
                        <div style="width: 100%; align-content: center">
                            <asp:GridView ID="GridDrugSupplement" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" OnRowCommand="on_row_DrugSupplement" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="GridDrugSupplement_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." AllowSorting="true" OnSorting="GridDrugSupplement_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="DrugSupplement ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("DSMnDrugID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("DSMnDrugID") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DrugSupplement Name" SortExpression="DSMsDrugName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrugSupplement" runat="server" Text='<%#Eval("DSMsDrugName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditDrugSupplement" Text='<%#Eval("DSMsDrugName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="DrugSupplement Name Required" Display="Dynamic" ControlToValidate="EditDrugSupplement" ValidationGroup="UpdateValidation4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtDrugSupplement" ToolTip="Enter Drug/supplement Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="DrugSupplement Name Required" Display="Dynamic" ControlToValidate="txtDrugSupplement" ValidationGroup="FooterValidation4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DrugSupplement Type" SortExpression="DSMsType" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDrugSupplementType" runat="server" Text='<%#Eval("DSMsType") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditDrugSupplementType" Text='<%#Eval("DSMsType") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="DrugSupplement Type Required" Display="Dynamic" ControlToValidate="EditDrugSupplementType" ValidationGroup="UpdateValidation4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator119" runat="server" ErrorMessage="Invalid DrugSupplement Type" Display="Dynamic" ControlToValidate="EditDrugSupplementType" ValidationGroup="UpdateValidation4" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$"></asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtDrugSupplementType" ToolTip="Enter Drug/supplement Type"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="DrugSupplement Type Required" Display="Dynamic" ControlToValidate="txtDrugSupplementType" ValidationGroup="FooterValidation4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid DrugSupplement Type" Display="Dynamic" ControlToValidate="txtDrugSupplementType" ValidationGroup="FooterValidation4" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate_DrugSupplement" runat="server" CausesValidation="True" CommandName="Update_DrugSupplement" ValidationGroup="UpdateValidation4"
                                                CommandArgument='<%#Eval("DSMnDrugID") %>' Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel_DrugSupplement" runat="server" CausesValidation="False" CommandName="Cancel_DrugSupplement"
                                                CommandArgument='<%#Eval("DSMnDrugID") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit_DrugSupplement" runat="server" CausesValidation="False" CommandName="Edit_DrugSupplement"
                                                CommandArgument='<%#Eval("DSMnDrugID") %>'>Edit</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete_DrugSupplement" runat="server" CausesValidation="False" CommandName="Delete_DrugSupplement"
                                            CommandArgument='<%#Eval("DSMnDrugID") %>'>Delete</asp:LinkButton></span>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd_DrugSupplement" CommandName="Insert_DrugSupplement" runat="server" CausesValidation="true" ValidationGroup="FooterValidation4">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="tabs-5" class="tab-pane fade">
                        <div style="width: 100%; align-content: center">
                            <asp:GridView ID="GridSeason" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" OnRowCommand="on_row_Season" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="GridSeason_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." AllowSorting="true" OnSorting="GridSeason_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Season ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("SMnSeasonID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("SMnSeasonID") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Season Name" SortExpression="SMsSeasonName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSeason" runat="server" Text='<%#Eval("SMsSeasonName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditSeason" Text='<%#Eval("SMsSeasonName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Season Name Required" Display="Dynamic" ControlToValidate="EditSeason" ValidationGroup="UpdateValidation5" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtSeason" ToolTip="Enter Season Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Season Name Required" Display="Dynamic" ControlToValidate="txtSeason" ValidationGroup="FooterValidation5" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate_Season" runat="server" CausesValidation="True" CommandName="Update_Season" ValidationGroup="UpdateValidation5"
                                                CommandArgument='<%#Eval("SMnSeasonID") %>' Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel_Season" runat="server" CausesValidation="False" CommandName="Cancel_Season"
                                                CommandArgument='<%#Eval("SMnSeasonID") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit_Season" runat="server" CausesValidation="False" CommandName="Edit_Season"
                                                CommandArgument='<%#Eval("SMnSeasonID") %>'>Edit</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete_Season" runat="server" CausesValidation="False" CommandName="Delete_Season"
                                            CommandArgument='<%#Eval("SMnSeasonID") %>'>Delete</asp:LinkButton></span>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd_Season" CommandName="Insert_Season" runat="server" CausesValidation="true" ValidationGroup="FooterValidation5">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>

                        </div>
                    </div>
                    <div id="tabs-6" class="tab-pane fade">
                        <div style="width: 100%; align-content: center">
                            <asp:GridView ID="GridEllergie" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" OnRowCommand="on_row" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="GridEllergie_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." AllowSorting="true" OnSorting="GridEllergie_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Allergy ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("AMnAllergyID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("AMnAllergyID") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allergy Name" SortExpression="AMsAllergyName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEllergie" runat="server" Text='<%#Eval("AMsAllergyName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditEllergie" Text='<%#Eval("AMsAllergyName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Allergy Name Required" Display="Dynamic" ControlToValidate="EditEllergie" ValidationGroup="UpdateValidation6" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>

                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtEllergie" ToolTip="Enter Allergy Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Allergy Name Required" Display="Dynamic" ControlToValidate="txtEllergie" ValidationGroup="FooterValidation6" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Food Name" SortExpression="AMsFoodName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFoodName" runat="server" Text='<%#Eval("AMsFoodName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditFoodName" Text='<%#Eval("AMsFoodName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Food Name Required" Display="Dynamic" ControlToValidate="EditFoodName" ValidationGroup="UpdateValidation6" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtFoodName" ToolTip="Enter Allergy Food"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Food Name Required" Display="Dynamic" ControlToValidate="txtFoodName" ValidationGroup="FooterValidation6" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update_Ellergie" ValidationGroup="UpdateValidation6"
                                                CommandArgument='<%#Eval("AMnAllergyID") %>' Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel_Ellergie"
                                                CommandArgument='<%#Eval("AMnAllergyID") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit_Ellergie"
                                                CommandArgument='<%#Eval("AMnAllergyID") %>'>Edit</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete_Ellergie"
                                            CommandArgument='<%#Eval("AMnAllergyID") %>'>Delete</asp:LinkButton></span>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd" CommandName="Insert_Ellergie" runat="server" CausesValidation="true" ValidationGroup="FooterValidation6">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="tabs-7" class="tab-pane fade">
                        <div style="width: 100%; align-content: center">
                            <asp:GridView ID="grdUnit" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" OnRowCommand="grdUnit_RowCommand" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="grdUnit_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." AllowSorting="true" OnSorting="grdUnit_Sorting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Allergy ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("UMnUnitID") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("UMnUnitID") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Name" SortExpression="UMsUnitName" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnit" runat="server" Text='<%#Eval("UMsUnitName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditUnit" Text='<%#Eval("UMsUnitName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="Unit Name Required" Display="Dynamic" ControlToValidate="EditUnit" ValidationGroup="UpdateValidation7" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtUnit" ToolTip="Enter Unit Name"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Unit Name Required" Display="Dynamic" ControlToValidate="txtUnit" ValidationGroup="FooterValidation7" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Grams Per Unit" SortExpression="UMnGramsPerUnit" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="GramsPerUnit" runat="server" Text='<%#Eval("UMnGramsPerUnit") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditGramsPerUnit" Text='<%#Eval("UMnGramsPerUnit") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="GramsPerUnit  Required" Display="Dynamic" ControlToValidate="EditGramsPerUnit" ValidationGroup="UpdateValidation7" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtGramsPerUnit" ToolTip="Enter Grams/Unit"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="GramsPerUnit Required" Display="Dynamic" ControlToValidate="txtGramsPerUnit" ValidationGroup="FooterValidation7" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid GramsPerUnit" Display="Dynamic" ControlToValidate="txtGramsPerUnit" ValidationGroup="FooterValidation7" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$"></asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update_Unit" ValidationGroup="UpdateValidation7"
                                                CommandArgument='<%#Eval("UMnUnitID") %>' Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel_Unit"
                                                CommandArgument='<%#Eval("UMnUnitID") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit_Unit"
                                                CommandArgument='<%#Eval("UMnUnitID") %>'>Edit</asp:LinkButton>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <%-- <span onclick="return confirm('Are you sure want to delete?')">
                                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete_Unit"
                                            CommandArgument='<%#Eval("UMnUnitID") %>'>Delete</asp:LinkButton></span>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd" CommandName="Insert_Unit" runat="server" CausesValidation="true" ValidationGroup="FooterValidation7">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>
                    </div>
                    <div id="tabs-8" class="tab-pane fade">
                        <div style="width: 100%; align-content: center">
                            <asp:GridView ID="grdCategory" runat="server" AutoGenerateColumns="False"
                                AllowPaging="True" OnRowCommand="grdCategory_RowCommand" ShowFooter="true" ShowHeaderWhenEmpty="true"
                                OnPageIndexChanging="grdCategory_PageIndexChanging" CssClass="table table-bordered table-striped dataTable" PageSize="10" EmptyDataText="No Records Found.." AllowSorting="true"
                                OnRowDataBound="grdCategory_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Group ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("FGnGroupId") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblID" Text='<%#Eval("FGnGroupId") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Group Name" HeaderStyle-Font-Underline="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGroup" runat="server" Text='<%#Eval("FGsGroupName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="EditGroup" Text='<%#Eval("FGsGroupName") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator222" runat="server" ErrorMessage="Group Name Required" Display="Dynamic" ControlToValidate="EditGroup" ValidationGroup="UpdateValidation8" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox runat="server" ID="txtGroup" ToolTip="Enter Food Group Type"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator220" runat="server" ErrorMessage="Unit Name Required" Display="Dynamic" ControlToValidate="txtGroup" ValidationGroup="FooterValidation8" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label ID="lblImage" runat="server" Text='<%#Eval("FGsImage") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblImage" runat="server" Text='<%#Eval("FGsImage") %>' Visible="false"></asp:Label>
                                            <asp:FileUpload runat="server" ID="imgUpload" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator331" runat="server" ErrorMessage="Image Required" Display="Dynamic" ControlToValidate="imgUpload" ValidationGroup="ImageGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator5" runat="server" ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed"
                                                ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"
                                                ControlToValidate="imgUpload" Display="Dynamic" ValidationGroup="ImageGroup" ForeColor="Red"> 
                                            </asp:RegularExpressionValidator>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:FileUpload runat="server" ID="imgUpload" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator222" runat="server" ErrorMessage="Image Required" Display="Dynamic" ControlToValidate="imgUpload" ValidationGroup="FooterValidation8" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator
                                                ID="RegularExpressionValidator5" runat="server" ErrorMessage="Only .jpg,.png,.jpeg,.gif Files are allowed"
                                                ValidationExpression="(.*?)\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$"
                                                ControlToValidate="imgUpload" Display="Dynamic" ValidationGroup="FooterValidation8" ForeColor="Red"> 
                                            </asp:RegularExpressionValidator>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update_Category" ValidationGroup="UpdateValidation8"
                                                CommandArgument='<%#Eval("FGnGroupId") %>' Text="Update"></asp:LinkButton>
                                            &nbsp;<asp:LinkButton ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel_Category"
                                                CommandArgument='<%#Eval("FGnGroupId") %>' Text="Cancel"></asp:LinkButton>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit_Category"
                                                CommandArgument='<%#Eval("FGnGroupId") %>'>Edit</asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="linkAdd" CommandName="Insert_Category" runat="server" CausesValidation="true" ValidationGroup="FooterValidation8">Add</asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>Data Not Found</EmptyDataTemplate>
                                <PagerStyle CssClass="pagination-ys" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rptAlphabets" />
            <%--<asp:PostBackTrigger ControlID="grdCategory" />--%>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
