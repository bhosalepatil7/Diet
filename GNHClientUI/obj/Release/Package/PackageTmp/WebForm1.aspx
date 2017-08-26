<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GNHClientUI.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<head>
    <title>Bootstrap Case</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <%--    <link href="http://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">--%>
    <%--<link href="../Scripts/css/jquery.dateselect.css" href rel="stylesheet" type="text/css">--%>
    <link href="Scripts/css/jquery.dateselect.css" rel="stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-1.12.3.min.js"></script>
    <%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery-mousewheel/3.1.12/jquery.mousewheel.js"></script>--%>
    <script src="Scripts/js/jquery.dateselect.js"></script>
    <script type="text/javascript">        window.history.forward(1)</script>
    <%--<script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>

    <link rel="stylesheet" href="../Scripts/jquery-ui.css">
    <script src="../Scripts/jquery-1.12.0.js"></script>
    <script src="../Scripts/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">--%>

    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta charset="utf-8" />


    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <!-- bootstrap & fontawesome -->
    <link rel="stylesheet" href="../assets/css/bootstrap.css" />
    <link rel="stylesheet" href="../assets/css/font-awesome.css" />

    <!-- page specific plugin styles -->

    <!-- text fonts -->
    <link rel="stylesheet" href="../assets/css/ace-fonts.css" />

    <!-- ace styles -->
    <link rel="stylesheet" href="../assets/css/ace.css" class="ace-main-stylesheet" id="mainacestyleNew" />

    <!--[if lte IE 9]>
			<link rel="stylesheet" href="../assets/css/ace-part2.css" class="ace-main-stylesheet" />
		<![endif]-->

    <!--[if lte IE 9]>
		  <link rel="stylesheet" href="../assets/css/ace-ie.css" />
		<![endif]-->

    <!-- inline styles related to this page -->

    <!-- ace settings handler -->
    <script src="../assets/js/ace-extra.js"></script>

    <!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

    <!--[if lte IE 8]>
		<script src="../assets/js/html5shiv.js"></script>
		<script src="../assets/js/respond.js"></script>
		<![endif]-->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=txtdate.ClientID%>').on('click', function (e) {
                e.preventDefault();
                $.dateSelect.show({
                    element: $('#<%= txtdate.ClientID %>')
                });
            });
        });

    </script>
    <style>
        .GridHeader {
            background-color: #009999;
            color: White;
            padding: 5px;
            text-align: center;
            font-family: Verdana;
            font-weight: bold;
            font-size: 12px;
        }

        .DataGrid {
            background-color: White;
            color: Black;
            font-family: verdana;
            font-size: small;
            border: solid 1px black;
        }

        .Alternate_Row {
            background-color: gainsboro;
        }

        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 450px;
            border: 3px solid #000000;
        }

            .modalPopup .header {
                background-color: #3366CC;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .footer {
                padding: 3px;
            }

            .modalPopup .yes, .modalPopup .no {
                height: 23px;
                color: White;
                line-height: 23px;
                text-align: center;
                font-weight: bold;
                cursor: pointer;
            }

            .modalPopup .yes {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

            .modalPopup .no {
                background-color: #9F9F9F;
                border: 1px solid #5C5C5C;
            }

        .width1 {
            width: 450px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                <%--  <input type="text" name="date2" id="date2" class="form-control" placeholder="Click On The Calendar Icon">--%>
                <span class="input-group-btn">
                    <button class="btn btn-primary btn-date" type="button"><i class="fa fa-calendar"></i></button>
                </span>
            </div>
        </div>
    </form>
</body>
