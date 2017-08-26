<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="FollowupQuestions.aspx.cs" Inherits="GNHClientUI.Screens.FollowupQuestions" %>

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
            Followup Questions
        </small>
        </h1>
    </div>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="form-group col-sm-6 col-md-12">
                <label class="col-sm-4 control-label text-right">Select Question :</label>
                <div class="col-sm-8 control-block">
                    <asp:DropDownList runat="server" ID="ddlQuestion"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlQuestion" Text="Invalid Question" ErrorMessage="Invalid Question" ForeColor="Red" Display="Dynamic" InitialValue="-1"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group col-sm-6 col-md-12">
                <label class="col-sm-4 control-label text-right">Answer :</label>
                <div class="col-sm-8 control-block">
                    <asp:TextBox ID="txtQuestion" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="2" Width="100%" autocomplete="off"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Req1" ControlToValidate="txtQuestion" ErrorMessage="*" Text="*" ForeColor="Red" runat="server" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group col-sm-6 col-md-12">
                <div class="col-sm-4 control-block">
                </div>
                <div class="col-sm-4 control-block">
                    <asp:Button ID="btnFollowupQuestionsSave" runat="server" Text="SAVE" CssClass="btn btn-primary btn-md" OnClick="btnFollowupQuestionsSave_Click" CausesValidation="true" />
                </div>
            </div>
            <div style="width: 98%; align-content: center; padding-top: 10px">
                <asp:GridView ID="grdClient" runat="server" CssClass="table table-bordered table-striped dataTable" OnPageIndexChanging="grdClient_PageIndexChanging"
                    AutoGenerateColumns="False" PageSize="10" AllowPaging="true" ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found..">
                    <Columns>
                        <asp:TemplateField HeaderText="Sr No" HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cust ID" HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="lblCustId" Text='<%#Eval("FMnCustID") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Question Id" HeaderStyle-Width="15%">
                            <ItemTemplate>
                                <asp:Label ID="lblQid" Text='<%#Eval("FMnQid") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Answer" HeaderStyle-Width="50%">
                            <ItemTemplate>
                                <asp:Label ID="lblAnswer" Text='<%# Eval("FMsAnswer") %>' runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- Button trigger modal -->
    <%--<button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
  Launch demo modal
</button>--%>

    <!-- Modal -->
    <%--<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>
        </div>
    </div>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
