<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="GNHClientUI.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:TextBox ID="DateTextbox" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime"></asp:TextBox>


    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#DateTextbox");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd.mm.yyyy",
                language: "tr"
            });
        });
    </script>
</asp:Content>
