<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="GNH_Dashboard.aspx.cs" Inherits="GNHClientUI.GNH_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript" src="../assets/js/jquery.js"></script>
    <script type="text/javascript" src="../assets/js/Chart.js"></script>
    <div class="page-header">
        <h1>GNH Dashboard</h1>
    </div>
    <div id="sb-info" class="row">
        <div class="col-sm-4">
            <h5 style="align-content:center">Today's Appointments</h5>
            <table id="tblPatient"  class="table table-bordered table-striped dataTable" cellpadding="2" cellspacing="0" border="1">
                <tr>

                    <td align="center">
                        <b>Sr.No </b>
                    </td>
                    <td align="center">
                        <b>Name </b></td>
                    <td align="center">
                        <b>Time </b>

                    </td>

                </tr>
            </table>
        </div>
        <div class="col-sm-4">
            <h5 style="align-content:center">Appointments in Current Month</h5>
            <canvas id="CanvasMonth"></canvas>
        </div>
        <div class="col-sm-4">
            <h5 style="align-content:center">Appointments in Last 12 Months</h5>
            <canvas id="CanvasYear"></canvas>
        </div>
    </div>
    <%--<div style="width: 100%">
        <div style="width: 45%">
            <canvas id="CanvasDaily"></canvas>
        </div>
    </div>
    <div style="width: 100%;">
        <div style="width: 45% ;float:left">
            <h5>Appointments in Current Month</h5>
            <canvas id="CanvasMonth"></canvas>
        </div>
        <div style="width: 45%;float:right">
            <h5>Appointments in Last 12 Months</h5>
            <canvas id="CanvasYear"></canvas>
        </div>
    </div>
    --%><script type="text/javascript">
            var dynamicLabels, dynamicData;

            var j = [];
            var k = [];

            function GetChartData1() {
                debugger;
                $.ajax({
                    type: "POST",
                    url: "GNH_Dashboard.aspx/GetDailyData",
                <%--data: '{ClientID: "' + <%=Session["PatientID"].ToString()%> + '" }',--%>
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        j = response.d;
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }
            function GetChartData2() {
                debugger;
                $.ajax({
                    type: "POST",
                    url: "GNH_Dashboard.aspx/Get12MonthsData",
                <%--data: '{ClientID: "' + <%=Session["PatientID"].ToString()%> + '" }',--%>
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (response) {
                        k = response.d;
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            }



            //Dynamic fetching monthly Data 
            var temp1 = GetChartData1();
            var temp2 = GetChartData2();

            var barChartData1 = {
                labels: j.labels,
                datasets: j.datasets
            };
            var barChartData2 = {
                labels: k.labels,
                datasets: k.datasets
            };

            window.onload = function () {

                var ctx = document.getElementById("CanvasMonth").getContext("2d");
                //if (1 < barChartData1.labels.length) {
                window.myLine = new Chart(ctx).Bar(barChartData1, {
                    responsive: true,
                    isFixedWidth: true,
                    barMaxWidth: 10,
                    scaleBeginAtZero: true
                });
                //}
                //else {
                //    ctx.font = "20px " + Chart.defaults.global.tooltipTitleFontFamily;
                //    ctx.textAlign = "center";
                //    ctx.textBaseline = "middle";
                //    ctx.fillStyle = Chart.defaults.global.scaleFontColor;
                //    ctx.fillText("No data in chart.", ctx.canvas.clientWidth / 2, ctx.canvas.clientHeight / 2);
                //}
                var ctx1 = document.getElementById("CanvasYear").getContext("2d");
                window.myLine = new Chart(ctx1).Bar(barChartData2, {
                    responsive: true,
                    isFixedWidth: true,
                    barMaxWidth: 10,
                    scaleBeginAtZero: true
                });


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "GNH_Dashboard.aspx/GetPatientData",
                    data: "",
                    dataType: "json",
                    success: function (data) {
                        $.map(data.d, function (product) {
                            $("<tr> <td align='center'>" + product.Sr + "</td> <td align='center'>" + product.Name + "</td> <td align='center'>" + product.Time + "</td> </tr>").appendTo("#tblPatient");
                        });
                    },
                    error: function (response) {
                        alert("Error" + response.responseText);
                    }
                });
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
