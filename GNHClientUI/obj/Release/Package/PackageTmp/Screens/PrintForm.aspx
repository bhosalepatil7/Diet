<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintForm.aspx.cs" Inherits="GNHClientUI.PrintForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../assets/js/jquery.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }

        .display {
            display: none;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: 'HistoryHelper.aspx/GetPrintDetails',
                data: JSON.stringify({ FileName: $(<%=hdnFileName.ClientID%>).val() }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    $('div[id="divContent"]').html(data.d[0]);
                    $("#pgSupplements").text('Nil');
                    $("#pgInvestigations").text('');
                },
                error: function (data) {
                }
            });
            $(<%=btnPrint.ClientID%>).click(function () {

            })
        });

        function ManageEditableContents(varManageTag) {
            /*
                This will manage edited contents according to placeholders and store them in hidden field
                //pgSupplements
                //pgInvestigations

            */
            debugger;
            var supplements = '<Supplements>' + $("#pgSupplements").text() + '</Supplements>';
            var investigations = '<Investigations>' + $("#pgInvestigations").text() + '</Investigations>';
            var contents = "";

            if ($("#pgSupplements").text() == 'Nil') {

                $('#ThingsRemember').text("Nil");
            }


            if (supplements != "" || investigations != "") {
                contents = "<EditableFields>" + supplements + investigations + "</EditableFields>";
            }

            if (contents != "") {
                //Encode and maitain edited fields data
                $(<%=hdnEditedContents.ClientID%>).val($('<div/>').text(contents).html());
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hdnFileName" />
        <asp:HiddenField runat="server" ID="hdnEditedContents" Value="EMPTY" />
        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print" CssClass="display" />
        <div id="ReportData" runat="server">
            <table style="width: 100%">
                <tr>
                    <td rowspan="2">
                        <%--<img src="../Images/Logo.jpg" style="height: 76px" />--%>
                        <img src="../../Images/Logo.jpg" style="height: 76px; left: 35%; text-align: left" />
                    </td>
                    <td>
                        <%--<span id='lbl' style='color:Lime;font-family:Calibri;font-size:XX-Large;font-weight:bold;'>Right Nutrition for Health</span>--%>
                        <span id='lbl' style='color: #0b6b3b; font-family: Impact; font-size: 40px; font-size: x-large; /* font-weight: bold; */'>Right Nutrition for Health</span>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td colspan="2">
                        <div id="divContent"></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <span id="lb2" style="color: #6699FF; font-family: Calibri; font-weight: bold;">+91 7722 0070 68|info@geetanutriheal.com|www.geetanutriheal.com</span>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
