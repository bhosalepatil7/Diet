<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserHistory.ascx.cs" Inherits="GNHClientUI.UserHistory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<script src="../assets/js/jquery.js"></script>--%>
<style type="text/css">
    .contentAccordion {
        padding: 4px;
        background-color: Olive;
    }

    .headerAccordion {
        color: white;
        background-color: Navy;
        padding: 4px;
        border: solid 1px black;
    }

    #accClientHistory {
        cursor: pointer;
    }

    .accordionHeader {
        cursor: pointer;
    }
</style>
<%--<script type="text/javascript">
    function load() {
        if ($('<%=accClientHistory.ClientID %>').is(':empty')) {
          //  alert();
        }
    }
    window.onload = load;
    //$(document).ready(function () {

    //    alert();
    //    if ($('#divhistory').is(':empty')) {
    //                alert();
    //         }
    //});

</script>--%>
<%--<div class="page-header">
    <h1>Screening
								<small>
                                    <i class="ace-icon fa fa-angle-double-right"></i>
                                    Client History
                                </small>
    </h1>
</div>--%>
<div id="divhistory" style="width: 100%">
    <div id="Nodatadiv" style="display: none; color: #8089a0" runat="server" class="align-center">
        <h4>No records found</h4>
    </div>
    <asp:Accordion runat="server" ID="accClientHistory" HeaderCssClass="ui-accordion-header ui-state-default ui-accordion-icons ui-accordion-header-active ui-state-active ui-corner-top accordionHeader"
        ContentCssClass="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active"
        CssClass="ui-accordion ui-widget ui-helper-reset" SelectedIndex="-1">
        <Panes></Panes>
    </asp:Accordion>
</div>
