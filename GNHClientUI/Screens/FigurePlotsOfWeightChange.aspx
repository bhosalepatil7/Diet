<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="FigurePlotsOfWeightChange.aspx.cs" Inherits="GNHClientUI.Screens.FigurePlotsOfWeightChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript" src="../assets/js/jquery.js"></script>
    <script type="text/javascript" src="../assets/js/Chart.js"></script>
    <div class="page-header">
        <h1>Figures, plots of weight-change</h1>
    </div>
    <div id="Nodatadiv" style="display: none; color: #8089a0" class="align-center">
        <h4>No records found</h4>
    </div>
    <div>
        <div>
            <canvas id="canvas" height="450" width="600"></canvas>
        </div>
        <%--<input type="button" id="btnLoadData" value="Load" />--%>
    </div>
    <%--  Dynamic fetching Weight Change Data --%>
    <script type="text/javascript">
        var dynamicLabels, dynamicData;

        var j = [];

        function GetWeightChangeData() {
            debugger;
            $.ajax({
                type: "POST",
                url: "FigurePlotsOfWeightChange.aspx/GetWeightChangeData",
                data: '{ClientID: "' + <%=Session["PatientID"].ToString()%> + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            //alert(response);

            // j = response.d;
            //var d1 = JSON.parse(j.labels);
            //response.d.labels;
            //alert(response.d.labels.length);
            //dynamicData = response.d.data;
            if (response.d.labels.length >= 1) {
                j = response.d;
                $("#Nodatadiv").css("display", "none");
            }
            else {
                $("#Nodatadiv").css("display", "block");
            }

        }

        //Dynamic fetching Weight Change Data 
        var temp = GetWeightChangeData();

        var randomScalingFactor = function () { return Math.round(Math.random() * 100) };
        //var lineChartData = {
        //    //labels: ["January", "February", "March", "April", "May", "June", "July"],
        //    //labels: ['1-Jan-2016', '8-Jan-2016', '15-Jan-2016', '22-Jan-2016', '29-Jan-2016', '4-Feb-2016', '11-Feb-2016'],
        //    labels: dynamicLabels,
        //    datasets: [
        //		{
        //		    label: "My First dataset",
        //		    fillColor: "rgba(220,220,220,0.2)",
        //		    strokeColor: "rgba(220,220,220,1)",
        //		    pointColor: "rgba(220,220,220,1)",
        //		    pointStrokeColor: "#fff",
        //		    pointHighlightFill: "#fff",
        //		    pointHighlightStroke: "rgba(220,220,220,1)",
        //		    //data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        //		    data: [59, 61, 63, 62, 62.5, 64, 63]
        //		    //data: dynamicData
        //		}
        //        //,
        //		//{
        //		//    label: "My Second dataset",
        //		//    fillColor: "rgba(151,187,205,0.2)",
        //		//    strokeColor: "rgba(151,187,205,1)",
        //		//    pointColor: "rgba(151,187,205,1)",
        //		//    pointStrokeColor: "#fff",
        //		//    pointHighlightFill: "#fff",
        //		//    pointHighlightStroke: "rgba(151,187,205,1)",
        //		//    data: [randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor(), randomScalingFactor()]
        //		//}
        //    ]

        //}
        var lineChartData = {
            labels: j.labels,
            datasets: j.datasets
        };

        window.onload = function () {
            var ctx = document.getElementById("canvas").getContext("2d");
            window.myLine = new Chart(ctx).Line(lineChartData, {
                responsive: true, emptyDataMessage: "chart has no data"
            });
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
