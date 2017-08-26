<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" Inherits="Dashboard" CodeBehind="Dashboard.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <style type="text/css">
        .circle-tile {
            margin-bottom: 15px;
            text-align: center;
        }

        .circle-tile-heading {
            border: 3px solid rgba(255, 255, 255, 0.3);
            border-radius: 100%;
            color: #FFFFFF;
            height: 80px;
            margin: 0 auto -40px;
            position: relative;
            transition: all 0.3s ease-in-out 0s;
            width: 80px;
        }

            .circle-tile-heading .fa {
                line-height: 80px;
            }

        .circle-tile-content {
            padding-top: 50px;
        }

        .circle-tile-number {
            font-size: 26px;
            font-weight: 700;
            line-height: 1;
            padding: 5px 0 15px;
        }

        .circle-tile-description {
            text-transform: uppercase;
        }

        .circle-tile-footer {
            background-color: rgba(0, 0, 0, 0.1);
            color: rgba(255, 255, 255, 0.5);
            display: block;
            padding: 5px;
            transition: all 0.3s ease-in-out 0s;
        }

            .circle-tile-footer:hover {
                background-color: rgba(0, 0, 0, 0.2);
                color: rgba(255, 255, 255, 0.5);
                text-decoration: none;
            }

        .circle-tile-heading.dark-blue:hover {
            background-color: #2E4154;
        }

        .circle-tile-heading.green:hover {
            background-color: #138F77;
        }

        .circle-tile-heading.orange:hover {
            background-color: #DA8C10;
        }

        .circle-tile-heading.blue:hover {
            background-color: #2473A6;
        }

        .circle-tile-heading.red:hover {
            background-color: #CF4435;
        }

        .circle-tile-heading.purple:hover {
            background-color: #7F3D9B;
        }

        .tile-img {
            text-shadow: 2px 2px 3px rgba(0, 0, 0, 0.9);
        }

        .dark-blue {
            background-color: #34495E;
        }

        .light-blue {
            background-color: #438EB9;
        }

        .green {
            background-color: #16A085;
        }

        .blue {
            background-color: #2980B9;
        }

        .orange {
            background-color: #F39C12;
        }

        .light-orange {
            background-color: #FFB752;
        }
        .red {
            background-color: #E74C3C;
        }

        .pink {
            background-color: #D6487E;
        }
        .purple {
            background-color: #800080;
        }

        .dark-gray {
            background-color: #7F8C8D;
        }

        .gray {
            background-color: #95A5A6;
        }

        .light-gray {
            background-color: #BDC3C7;
        }

        .yellow {
            background-color: #F1C40F;
        }

        .text-dark-blue {
            color: #34495E;
        }

        .text-green {
            color: #16A085;
        }

        .text-blue {
            color: #2980B9;
        }

        .text-orange {
            color: #F39C12;
        }

        .text-red {
            color: #E74C3C;
        }

        .text-purple {
            color: #8E44AD;
        }

        .text-faded {
            color: rgba(255, 255, 255, 0.7);
        }
    </style>
    <div class="container bootstrap snippet">
        <div class="row">
            <div class="col-lg-2 col-sm-6">
                <div class="circle-tile ">
                    <a href="#">
                        <div class="circle-tile-heading light-blue"><i class="fa fa-calendar fa-fw fa-3x"></i></div>
                    </a>
                    <div class="circle-tile-content light-blue">
                        <div class="circle-tile-description text-faded">Today</div>
                        <div class="circle-tile-number text-faded ">10</div>
                        <a class="circle-tile-footer" href="ViewAppointments.aspx">More Info<i class="fa fa-chevron-circle-right"></i></a>
                    </div>
                </div>
            </div>

            <div class="col-lg-2 col-sm-6">
                <div class="circle-tile ">
                    <a href="#">
                        <div class="circle-tile-heading purple"><i class="fa fa-calendar fa-fw fa-3x"></i></div>
                    </a>
                    <div class="circle-tile-content purple">
                        <div class="circle-tile-description text-faded">This Week </div>
                        <div class="circle-tile-number text-faded ">50</div>
                        <a class="circle-tile-footer" href="Screens/DietPlan.aspx">More Info<i class="fa fa-chevron-circle-right"></i></a>
                    </div>
                </div>
            </div>

             <div class="col-lg-2 col-sm-6">
                <div class="circle-tile ">
                    <a href="#">
                        <div class="circle-tile-heading dark-blue"><i class="fa fa-calendar fa-fw fa-3x"></i></div>
                    </a>
                    <div class="circle-tile-content dark-blue">
                        <div class="circle-tile-description text-faded">This Month </div>
                        <div class="circle-tile-number text-faded ">120</div>
                        <a class="circle-tile-footer" href="ViewAppointments.aspx">More Info<i class="fa fa-chevron-circle-right"></i></a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>

