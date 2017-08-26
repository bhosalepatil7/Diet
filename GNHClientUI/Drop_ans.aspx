<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="Drop_ans.aspx.cs" Inherits="GNHClientUI.Drop_ans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <script src="Scripts/jquery-1.12.0.js"></script>
    <style type="text/css">
        .drop
        {
            border-radius: 0px;
            box-shadow: none !important;
            color: #858585;
            width: 50%;
            padding: 4px;
        }
        
        .button
        {
            background: #499849;
            filter: progid:DXImageTr-ansform.Microsoft.gradient( startColorstr='#e72f4a', endColorstr='#cf1733', GradientType=0 );
            color: #fff;
            height: 45px;
            padding: 8px 25px;
            margin: 20px 0;
            text-shadow: 0px -1px 0px rgba(0, 0, 0, 0.25);
            border: none;
        }
        .answer
        {
            padding: 4px;
            width: 30%;
        }
        .QueHeading
        {
            width: 20%;
        }
        .txtError
        {
            color:Red;
            font-size:14px;
        }
    </style>
    <label class="QueHeading">
        Que 1:</label>
 <%--   <select name="dropdown1" id="drop1" runat="server" class="drop">
    </select>--%> 
    <asp:DropDownList runat="server" name="dropdown1" ID="drop1" class="drop"></asp:DropDownList>
    <p class="txtError">
        Please Select Que 1</p>
    <input type="text" runat="server" id="Text1" class="answer" />
    <p class="txtError">
        Please Answer Que 1</p>
    <br />
    Que 2:
    <select name="dropdown2" id="drop2" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 2</p>
    <input type="text" runat="server" id="Text2" class="answer" />
    <p class="txtError">
        Please Answer Que 2</p>
    <br />
    Que 3:
    <select name="dropdown3" id="drop3" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 3</p>
    <input type="text" runat="server" id="Text3" class="answer" />
    <p class="txtError">
        Please Answer Que 3</p>
    <br />
    Que 4:
    <select name="dropdown4" id="drop4" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 4</p>
    <input type="text" runat="server" id="Text4" class="answer" />
    <p class="txtError">
        Please Answer Que 4</p>
    <br />
    Que 5:
    <select name="dropdown5" id="drop5" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 5</p>
    <input type="text" runat="server" id="Text5" class="answer" />
    <p class="txtError">
        Please Answer Que 5</p>
    <br />
    Que 6:
    <select name="dropdown6" id="drop6" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 6</p>
    <input type="text" runat="server" id="Text6" class="answer" />
    <p class="txtError">
        Please Answer Que 6</p>
    <br />
    Que 7:
    <select name="dropdown7" id="drop7" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 7</p>
    <input type="text" runat="server" id="Text7" class="answer" />
    <p class="txtError">
        Please Answer Que 7</p>
    <br />
    Que 8:
    <select name="dropdown8" id="drop8" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 8</p>
    <input type="text" runat="server" id="Text8" class="answer" />
    <p class="txtError">
        Please Answer Que 8</p>
    <br />
    Que 9:
    <select name="dropdown9" id="drop9" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 9</p>
    <input type="text" runat="server" id="Text9" class="answer" />
    <p class="txtError">
        Please Answer Que 9</p>
    <br />
    Que 10:
    <select name="dropdown10" id="drop10" runat="server" class="drop">
    </select>
    <p class="txtError">
        Please Select Que 10</p>
    <input type="text" runat="server" id="Text10" class="answer" /><br />
    <p class="txtError">
        Please Answer Que 10</p>
        <asp:Button ID="btnSave"  class="button" runat="server"  Text="Save" 
        onclick="btnSave_Click" />

    <script type="text/javascript">
        var $dropdown1 = $("select[name='drop1']");
        var $dropdown2 = $("select[name='drop2']");
        var $dropdown3 = $("select[name='drop3']");
        var $dropdown4 = $("select[name='drop4']");
        var $dropdown5 = $("select[name='drop5']");
        var $dropdown6 = $("select[name='drop6']");
        var $dropdown7 = $("select[name='drop7']");
        var $dropdown8 = $("select[name='drop8']");
        var $dropdown9 = $("select[name='drop9']");
        var $dropdown10 = $("select[name='drop10']");


        var ExitsVal = "";
        var ExitsVal2 = "";
        var ExitsVal3 = "";
        var ExitsVal4 = "";
        var ExitsVal5 = "";
        var ExitsVal6 = "";
        var ExitsVal7 = "";
        var ExitsVal8 = "";
        var ExitsVal9 = "";
        var ExitsVal10 = "";



        function HideMethode(control, parameter) {
            $('select[name="' + control + '"] option[value="' + parameter + '"]').hide();

        }

        function ShowMethode(control, parameter) {
            $('select[name="' + control + '"] option[value="' + parameter + '"]').show();

        }

        $dropdown1.change(function () {
            if (ExitsVal == "") {
                ExitsVal = $($dropdown1).val();
                if (ExitsVal != "") {
                    HideMethode("drop2", ExitsVal);
                    HideMethode("drop3", ExitsVal);
                    HideMethode("drop4", ExitsVal);
                    HideMethode("drop5", ExitsVal);
                    HideMethode("drop6", ExitsVal);
                    HideMethode("drop7", ExitsVal);
                    HideMethode("drop8", ExitsVal);
                    HideMethode("drop9", ExitsVal);
                    HideMethode("drop10", ExitsVal);

                }

            }
            else {

                var newNewVal = $($dropdown1).val();
                if (newNewVal != "") {
                    if (newNewVal != ExitsVal) {

                        ShowMethode("drop2", ExitsVal);
                        ShowMethode("drop3", ExitsVal);
                        ShowMethode("drop4", ExitsVal);
                        ShowMethode("drop5", ExitsVal);
                        ShowMethode("drop6", ExitsVal);
                        ShowMethode("drop7", ExitsVal);
                        ShowMethode("drop8", ExitsVal);
                        ShowMethode("drop9", ExitsVal);
                        ShowMethode("drop10", ExitsVal);


                        HideMethode("drop2", newNewVal);
                        HideMethode("drop3", newNewVal);
                        HideMethode("drop4", newNewVal);
                        HideMethode("drop5", newNewVal);
                        HideMethode("drop6", newNewVal);
                        HideMethode("drop7", newNewVal);
                        HideMethode("drop8", newNewVal);
                        HideMethode("drop9", newNewVal);
                        HideMethode("drop10", newNewVal);


                        ShowMethode("drop1", ExitsVal);
                        ShowMethode("drop1", newNewVal);


                        //                    $('select[name="drop2"] option[value="' + ExitsVal + '"]').show();
                        //                    $('select[name="drop3"] option[value="' + ExitsVal + '"]').show();
                        //                    $('select[name="drop4"] option[value="' + ExitsVal + '"]').show();

                        //                    $('select[name="drop2"] option[value="' + newNewVal + '"]').hide();
                        //                    $('select[name="drop3"] option[value="' + newNewVal + '"]').hide();
                        //                    $('select[name="drop4"] option[value="' + newNewVal + '"]').hide();

                        //                    $('select[name="drop1"] option[value="' + ExitsVal + '"]').show();
                        //                    $('select[name="drop1"] option[value="' + newNewVal + '"]').show();
                        //$drop1.children().show();
                    }

                }
                else {

                    ShowMethode("drop2", ExitsVal);
                    ShowMethode("drop3", ExitsVal);
                    ShowMethode("drop4", ExitsVal);
                    ShowMethode("drop5", ExitsVal);
                    ShowMethode("drop6", ExitsVal);
                    ShowMethode("drop7", ExitsVal);
                    ShowMethode("drop8", ExitsVal);
                    ShowMethode("drop9", ExitsVal);
                    ShowMethode("drop10", ExitsVal);

                    //                $('select[name="drop2"] option[value="' + ExitsVal + '"]').show();
                    //                $('select[name="drop3"] option[value="' + ExitsVal + '"]').show();
                    //                $('select[name="drop4"] option[value="' + ExitsVal + '"]').show();

                }
                ExitsVal = newNewVal;
            }

        });


        $dropdown2.change(function () {
            if (ExitsVal2 == "") {
                ExitsVal2 = $($dropdown2).val();
                if (ExitsVal2 != "") {

                    HideMethode("drop1", ExitsVal2);
                    HideMethode("drop3", ExitsVal2);
                    HideMethode("drop4", ExitsVal2);
                    HideMethode("drop5", ExitsVal2);
                    HideMethode("drop6", ExitsVal2);
                    HideMethode("drop7", ExitsVal2);
                    HideMethode("drop8", ExitsVal2);
                    HideMethode("drop9", ExitsVal2);
                    HideMethode("drop10", ExitsVal2);

                }

            }
            else {

                var newNewVal = $($dropdown2).val();
                if (newNewVal != "") {
                    if (newNewVal != ExitsVal2) {

                        HideMethode("drop1", newNewVal);
                        HideMethode("drop3", newNewVal);
                        HideMethode("drop4", newNewVal);
                        HideMethode("drop5", newNewVal);
                        HideMethode("drop6", newNewVal);
                        HideMethode("drop7", newNewVal);
                        HideMethode("drop8", newNewVal);
                        HideMethode("drop9", newNewVal);
                        HideMethode("drop10", newNewVal);

                        ShowMethode("drop1", ExitsVal2);
                        ShowMethode("drop3", ExitsVal2);
                        ShowMethode("drop4", ExitsVal2);
                        ShowMethode("drop5", ExitsVal2);
                        ShowMethode("drop6", ExitsVal2);
                        ShowMethode("drop7", ExitsVal2);
                        ShowMethode("drop8", ExitsVal2);
                        ShowMethode("drop9", ExitsVal2);
                        ShowMethode("drop10", ExitsVal2);

                        ShowMethode("drop2", ExitsVal2);
                        ShowMethode("drop2", newNewVal);

                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal2);
                    ShowMethode("drop3", ExitsVal2);
                    ShowMethode("drop4", ExitsVal2);
                    ShowMethode("drop5", ExitsVal2);
                    ShowMethode("drop6", ExitsVal2);
                    ShowMethode("drop7", ExitsVal2);
                    ShowMethode("drop8", ExitsVal2);
                    ShowMethode("drop9", ExitsVal2);
                    ShowMethode("drop10", ExitsVal2);

                }
                ExitsVal2 = newNewVal;
            }

        });



        $dropdown3.change(function () {
            if (ExitsVal3 == "") {
                ExitsVal3 = $($dropdown3).val();
                if (ExitsVal3 != "") {

                    HideMethode("drop1", ExitsVal3);
                    HideMethode("drop2", ExitsVal3);
                    HideMethode("drop4", ExitsVal3);
                    HideMethode("drop5", ExitsVal3);
                    HideMethode("drop6", ExitsVal3);
                    HideMethode("drop7", ExitsVal3);
                    HideMethode("drop8", ExitsVal3);
                    HideMethode("drop9", ExitsVal3);
                    HideMethode("drop10", ExitsVal3);

                }

            }
            else {
                var newNewVal = $($dropdown3).val();
                if (newNewVal != "") {
                    if (newNewVal != ExitsVal3) {


                        ShowMethode("drop1", ExitsVal3);
                        ShowMethode("drop2", ExitsVal3);
                        ShowMethode("drop4", ExitsVal3);
                        ShowMethode("drop5", ExitsVal3);
                        ShowMethode("drop6", ExitsVal3);
                        ShowMethode("drop7", ExitsVal3);
                        ShowMethode("drop8", ExitsVal3);
                        ShowMethode("drop9", ExitsVal3);
                        ShowMethode("drop10", ExitsVal3);

                        HideMethode("drop1", newNewVal);
                        HideMethode("drop2", newNewVal);
                        HideMethode("drop4", newNewVal);
                        HideMethode("drop5", newNewVal);
                        HideMethode("drop6", newNewVal);
                        HideMethode("drop7", newNewVal);
                        HideMethode("drop8", newNewVal);
                        HideMethode("drop9", newNewVal);
                        HideMethode("drop10", newNewVal);

                        ShowMethode("drop3", ExitsVal3);
                        ShowMethode("drop3", newNewVal);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal3);
                    ShowMethode("drop2", ExitsVal3);
                    ShowMethode("drop4", ExitsVal3);
                    ShowMethode("drop5", ExitsVal3);
                    ShowMethode("drop6", ExitsVal3);
                    ShowMethode("drop7", ExitsVal3);
                    ShowMethode("drop8", ExitsVal3);
                    ShowMethode("drop9", ExitsVal3);
                    ShowMethode("drop10", ExitsVal3);
                }
                ExitsVal3 = newNewVal;
            }

        });



        $dropdown4.change(function () {
            if (ExitsVal4 == "") {
                ExitsVal4 = $($dropdown4).val();
                if (ExitsVal4 != "") {


                    HideMethode("drop1", ExitsVal4);
                    HideMethode("drop2", ExitsVal4);
                    HideMethode("drop3", ExitsVal4);
                    HideMethode("drop5", ExitsVal4);
                    HideMethode("drop6", ExitsVal4);
                    HideMethode("drop7", ExitsVal4);
                    HideMethode("drop8", ExitsVal4);
                    HideMethode("drop9", ExitsVal4);
                    HideMethode("drop10", ExitsVal4);
                }

            }
            else {
                var newnewval = $($dropdown4).val();
                if (newnewval != "") {
                    if (newnewval != ExitsVal4) {

                        ShowMethode("drop1", ExitsVal4);
                        ShowMethode("drop2", ExitsVal4);
                        ShowMethode("drop3", ExitsVal4);
                        ShowMethode("drop5", ExitsVal4);
                        ShowMethode("drop6", ExitsVal4);
                        ShowMethode("drop7", ExitsVal4);
                        ShowMethode("drop8", ExitsVal4);
                        ShowMethode("drop9", ExitsVal4);
                        ShowMethode("drop10", ExitsVal4);

                        HideMethode("drop1", newnewval);
                        HideMethode("drop2", newnewval);
                        HideMethode("drop3", newnewval);
                        HideMethode("drop5", newnewval);
                        HideMethode("drop6", newnewval);
                        HideMethode("drop7", newnewval);
                        HideMethode("drop8", newnewval);
                        HideMethode("drop9", newnewval);
                        HideMethode("drop10", newnewval);

                        ShowMethode("drop4", ExitsVal4);
                        ShowMethode("drop4", newnewval);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal4);
                    ShowMethode("drop2", ExitsVal4);
                    ShowMethode("drop3", ExitsVal4);
                    ShowMethode("drop5", ExitsVal4);
                    ShowMethode("drop6", ExitsVal4);
                    ShowMethode("drop7", ExitsVal4);
                    ShowMethode("drop8", ExitsVal4);
                    ShowMethode("drop9", ExitsVal4);
                    ShowMethode("drop10", ExitsVal4);

                }
                ExitsVal4 = newnewval;
            }

        });


        $dropdown5.change(function () {
            if (ExitsVal5 == "") {
                ExitsVal5 = $($dropdown5).val();
                if (ExitsVal5 != "") {


                    HideMethode("drop1", ExitsVal5);
                    HideMethode("drop2", ExitsVal5);
                    HideMethode("drop3", ExitsVal5);
                    HideMethode("drop4", ExitsVal5);
                    HideMethode("drop6", ExitsVal5);
                    HideMethode("drop7", ExitsVal5);
                    HideMethode("drop8", ExitsVal5);
                    HideMethode("drop9", ExitsVal5);
                    HideMethode("drop10", ExitsVal5);
                }

            }
            else {
                var newnewval = $($dropdown5).val();
                if (newnewval != "") {
                    if (newnewval != ExitsVal5) {

                        ShowMethode("drop1", ExitsVal5);
                        ShowMethode("drop2", ExitsVal5);
                        ShowMethode("drop3", ExitsVal5);
                        ShowMethode("drop4", ExitsVal5);
                        ShowMethode("drop6", ExitsVal5);
                        ShowMethode("drop7", ExitsVal5);
                        ShowMethode("drop8", ExitsVal5);
                        ShowMethode("drop9", ExitsVal5);
                        ShowMethode("drop10", ExitsVal5);

                        HideMethode("drop1", newnewval);
                        HideMethode("drop2", newnewval);
                        HideMethode("drop3", newnewval);
                        HideMethode("drop4", newnewval);
                        HideMethode("drop6", newnewval);
                        HideMethode("drop7", newnewval);
                        HideMethode("drop8", newnewval);
                        HideMethode("drop9", newnewval);
                        HideMethode("drop10", newnewval);

                        ShowMethode("drop5", ExitsVal5);
                        ShowMethode("drop5", newnewval);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal5);
                    ShowMethode("drop2", ExitsVal5);
                    ShowMethode("drop3", ExitsVal5);
                    ShowMethode("drop4", ExitsVal5);
                    ShowMethode("drop6", ExitsVal5);
                    ShowMethode("drop7", ExitsVal5);
                    ShowMethode("drop8", ExitsVal5);
                    ShowMethode("drop9", ExitsVal5);
                    ShowMethode("drop10", ExitsVal5);

                }
                ExitsVal5 = newnewval;
            }

        });


        $dropdown6.change(function () {
            if (ExitsVal6 == "") {
                ExitsVal6 = $($dropdown6).val();
                if (ExitsVal6 != "") {


                    HideMethode("drop1", ExitsVal6);
                    HideMethode("drop2", ExitsVal6);
                    HideMethode("drop3", ExitsVal6);
                    HideMethode("drop4", ExitsVal6);
                    HideMethode("drop5", ExitsVal6);
                    HideMethode("drop7", ExitsVal6);
                    HideMethode("drop8", ExitsVal6);
                    HideMethode("drop9", ExitsVal6);
                    HideMethode("drop10", ExitsVal6);
                }

            }
            else {
                var newnewval = $($dropdown6).val();
                if (newnewval != "") {
                    if (newnewval != ExitsVal6) {

                        ShowMethode("drop1", ExitsVal6);
                        ShowMethode("drop2", ExitsVal6);
                        ShowMethode("drop3", ExitsVal6);
                        ShowMethode("drop4", ExitsVal6);
                        ShowMethode("drop5", ExitsVal6);
                        ShowMethode("drop7", ExitsVal6);
                        ShowMethode("drop8", ExitsVal6);
                        ShowMethode("drop9", ExitsVal6);
                        ShowMethode("drop10", ExitsVal6);

                        HideMethode("drop1", newnewval);
                        HideMethode("drop2", newnewval);
                        HideMethode("drop3", newnewval);
                        HideMethode("drop4", newnewval);
                        HideMethode("drop5", newnewval);
                        HideMethode("drop7", newnewval);
                        HideMethode("drop8", newnewval);
                        HideMethode("drop9", newnewval);
                        HideMethode("drop10", newnewval);

                        ShowMethode("drop6", ExitsVal6);
                        ShowMethode("drop6", newnewval);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal6);
                    ShowMethode("drop2", ExitsVal6);
                    ShowMethode("drop3", ExitsVal6);
                    ShowMethode("drop4", ExitsVal6);
                    ShowMethode("drop5", ExitsVal6);
                    ShowMethode("drop7", ExitsVal6);
                    ShowMethode("drop8", ExitsVal6);
                    ShowMethode("drop9", ExitsVal6);
                    ShowMethode("drop10", ExitsVal6);

                }
                ExitsVal6 = newnewval;
            }

        });





        $dropdown7.change(function () {
            if (ExitsVal7 == "") {
                ExitsVal7 = $($dropdown7).val();
                if (ExitsVal7 != "") {


                    HideMethode("drop1", ExitsVal7);
                    HideMethode("drop2", ExitsVal7);
                    HideMethode("drop3", ExitsVal7);
                    HideMethode("drop4", ExitsVal7);
                    HideMethode("drop5", ExitsVal7);
                    HideMethode("drop6", ExitsVal7);
                    HideMethode("drop8", ExitsVal7);
                    HideMethode("drop9", ExitsVal7);
                    HideMethode("drop10", ExitsVal7);
                }

            }
            else {
                var newnewval = $($dropdown7).val();
                if (newnewval != "") {
                    if (newnewval != ExitsVal7) {

                        ShowMethode("drop1", ExitsVal7);
                        ShowMethode("drop2", ExitsVal7);
                        ShowMethode("drop3", ExitsVal7);
                        ShowMethode("drop4", ExitsVal7);
                        ShowMethode("drop5", ExitsVal7);
                        ShowMethode("drop6", ExitsVal7);
                        ShowMethode("drop8", ExitsVal7);
                        ShowMethode("drop9", ExitsVal7);
                        ShowMethode("drop10", ExitsVal7);

                        HideMethode("drop1", newnewval);
                        HideMethode("drop2", newnewval);
                        HideMethode("drop3", newnewval);
                        HideMethode("drop4", newnewval);
                        HideMethode("drop5", newnewval);
                        HideMethode("drop6", newnewval);
                        HideMethode("drop8", newnewval);
                        HideMethode("drop9", newnewval);
                        HideMethode("drop10", newnewval);

                        ShowMethode("drop7", ExitsVal7);
                        ShowMethode("drop7", newnewval);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal7);
                    ShowMethode("drop2", ExitsVal7);
                    ShowMethode("drop3", ExitsVal7);
                    ShowMethode("drop4", ExitsVal7);
                    ShowMethode("drop5", ExitsVal7);
                    ShowMethode("drop6", ExitsVal7);
                    ShowMethode("drop8", ExitsVal7);
                    ShowMethode("drop9", ExitsVal7);
                    ShowMethode("drop10", ExitsVal7);

                }
                ExitsVal7 = newnewval;
            }

        });






        $dropdown8.change(function () {
            if (ExitsVal8 == "") {
                ExitsVal8 = $($dropdown8).val();
                if (ExitsVal8 != "") {


                    HideMethode("drop1", ExitsVal8);
                    HideMethode("drop2", ExitsVal8);
                    HideMethode("drop3", ExitsVal8);
                    HideMethode("drop4", ExitsVal8);
                    HideMethode("drop5", ExitsVal8);
                    HideMethode("drop6", ExitsVal8);
                    HideMethode("drop7", ExitsVal8);
                    HideMethode("drop9", ExitsVal8);
                    HideMethode("drop10", ExitsVal8);
                }

            }
            else {
                var newnewval = $($dropdown8).val();
                if (newnewval != "") {
                    if (newnewval != ExitsVal8) {

                        ShowMethode("drop1", ExitsVal8);
                        ShowMethode("drop2", ExitsVal8);
                        ShowMethode("drop3", ExitsVal8);
                        ShowMethode("drop4", ExitsVal8);
                        ShowMethode("drop5", ExitsVal8);
                        ShowMethode("drop6", ExitsVal8);
                        ShowMethode("drop7", ExitsVal8);
                        ShowMethode("drop9", ExitsVal8);
                        ShowMethode("drop10", ExitsVal8);

                        HideMethode("drop1", newnewval);
                        HideMethode("drop2", newnewval);
                        HideMethode("drop3", newnewval);
                        HideMethode("drop4", newnewval);
                        HideMethode("drop5", newnewval);
                        HideMethode("drop6", newnewval);
                        HideMethode("drop7", newnewval);
                        HideMethode("drop9", newnewval);
                        HideMethode("drop10", newnewval);

                        ShowMethode("drop8", ExitsVal8);
                        ShowMethode("drop8", newnewval);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal8);
                    ShowMethode("drop2", ExitsVal8);
                    ShowMethode("drop3", ExitsVal8);
                    ShowMethode("drop4", ExitsVal8);
                    ShowMethode("drop5", ExitsVal8);
                    ShowMethode("drop6", ExitsVal8);
                    ShowMethode("drop7", ExitsVal8);
                    ShowMethode("drop9", ExitsVal8);
                    ShowMethode("drop10", ExitsVal8);

                }
                ExitsVal8 = newnewval;
            }

        });



        $dropdown9.change(function () {
            if (ExitsVal9 == "") {
                ExitsVal9 = $($dropdown9).val();
                if (ExitsVal9 != "") {


                    HideMethode("drop1", ExitsVal9);
                    HideMethode("drop2", ExitsVal9);
                    HideMethode("drop3", ExitsVal9);
                    HideMethode("drop4", ExitsVal9);
                    HideMethode("drop5", ExitsVal9);
                    HideMethode("drop6", ExitsVal9);
                    HideMethode("drop7", ExitsVal9);
                    HideMethode("drop8", ExitsVal9);
                    HideMethode("drop10", ExitsVal9);
                }

            }
            else {
                var newnewval = $($dropdown9).val();
                if (newnewval != "") {
                    if (newnewval != ExitsVal9) {

                        ShowMethode("drop1", ExitsVal9);
                        ShowMethode("drop2", ExitsVal9);
                        ShowMethode("drop3", ExitsVal9);
                        ShowMethode("drop4", ExitsVal9);
                        ShowMethode("drop5", ExitsVal9);
                        ShowMethode("drop6", ExitsVal9);
                        ShowMethode("drop7", ExitsVal9);
                        ShowMethode("drop8", ExitsVal9);
                        ShowMethode("drop10", ExitsVal9);

                        HideMethode("drop1", newnewval);
                        HideMethode("drop2", newnewval);
                        HideMethode("drop3", newnewval);
                        HideMethode("drop4", newnewval);
                        HideMethode("drop5", newnewval);
                        HideMethode("drop6", newnewval);
                        HideMethode("drop7", newnewval);
                        HideMethode("drop8", newnewval);
                        HideMethode("drop10", newnewval);

                        ShowMethode("drop9", ExitsVal9);
                        ShowMethode("drop9", newnewval);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal9);
                    ShowMethode("drop2", ExitsVal9);
                    ShowMethode("drop3", ExitsVal9);
                    ShowMethode("drop4", ExitsVal9);
                    ShowMethode("drop5", ExitsVal9);
                    ShowMethode("drop6", ExitsVal9);
                    ShowMethode("drop7", ExitsVal9);
                    ShowMethode("drop8", ExitsVal9);
                    ShowMethode("drop10", ExitsVal9);

                }
                ExitsVal9 = newnewval;
            }

        });



        $dropdown10.change(function () {
            if (ExitsVal10 == "") {
                ExitsVal10 = $($dropdown10).val();
                if (ExitsVal10 != "") {


                    HideMethode("drop1", ExitsVal10);
                    HideMethode("drop2", ExitsVal10);
                    HideMethode("drop3", ExitsVal10);
                    HideMethode("drop4", ExitsVal10);
                    HideMethode("drop5", ExitsVal10);
                    HideMethode("drop6", ExitsVal10);
                    HideMethode("drop7", ExitsVal10);
                    HideMethode("drop8", ExitsVal10);
                    HideMethode("drop9", ExitsVal10);
                }

            }
            else {
                var newnewval = $($dropdown10).val();
                if (newnewval != "") {
                    if (newnewval != ExitsVal10) {

                        ShowMethode("drop1", ExitsVal10);
                        ShowMethode("drop2", ExitsVal10);
                        ShowMethode("drop3", ExitsVal10);
                        ShowMethode("drop4", ExitsVal10);
                        ShowMethode("drop5", ExitsVal10);
                        ShowMethode("drop6", ExitsVal10);
                        ShowMethode("drop7", ExitsVal10);
                        ShowMethode("drop8", ExitsVal10);
                        ShowMethode("drop9", ExitsVal10);

                        HideMethode("drop1", newnewval);
                        HideMethode("drop2", newnewval);
                        HideMethode("drop3", newnewval);
                        HideMethode("drop4", newnewval);
                        HideMethode("drop5", newnewval);
                        HideMethode("drop6", newnewval);
                        HideMethode("drop7", newnewval);
                        HideMethode("drop8", newnewval);
                        HideMethode("drop9", newnewval);

                        ShowMethode("drop10", ExitsVal10);
                        ShowMethode("drop10", newnewval);
                    }

                }
                else {

                    ShowMethode("drop1", ExitsVal10);
                    ShowMethode("drop2", ExitsVal10);
                    ShowMethode("drop3", ExitsVal10);
                    ShowMethode("drop4", ExitsVal10);
                    ShowMethode("drop5", ExitsVal10);
                    ShowMethode("drop6", ExitsVal10);
                    ShowMethode("drop7", ExitsVal10);
                    ShowMethode("drop8", ExitsVal10);
                    ShowMethode("drop9", ExitsVal10);

                }
                ExitsVal10 = newnewval;
            }

        });
    </script>
    <script type="text/javascript">
        $(function () {
            $('.txtError').hide();
        });
        $("#btnSave").click(function () {
            $('.txtError').hide();
            var Flag = true;
            if ($("#drop1").val() == "") {
                $("#drop1").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text1").val() == "") {
                $("#Text1").next('.txtError').show();
                Flag = false;
            }
            if ($("#drop2").val() == "") {
                $("#drop2").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text2").val() == "") {
                $("#Text2").next('.txtError').show();
                Flag = false;
            }

            if ($("#drop3").val() == "") {
                $("#drop3").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text3").val() == "") {
                $("#Text3").next('.txtError').show();
                Flag = false;
            }

            if ($("#drop4").val() == "") {
                $("#drop4").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text4").val() == "") {
                $("#Text4").next('.txtError').show();
                Flag = false;
            }

            if ($("#drop5").val() == "") {
                $("#drop5").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text5").val() == "") {
                $("#Text5").next('.txtError').show();
                Flag = false;
            }

            if ($("#drop6").val() == "") {
                $("#drop6").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text6").val() == "") {
                $("#Text6").next('.txtError').show();
                Flag = false;
            }
            if ($("#drop7").val() == "") {
                $("#drop7").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text7").val() == "") {
                $("#Text7").next('.txtError').show();
                Flag = false;
            }

            if ($("#drop8").val() == "") {
                $("#drop8").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text8").val() == "") {
                $("#Text8").next('.txtError').show();
                Flag = false;
            }

            if ($("#drop9").val() == "") {
                $("#drop9").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text9").val() == "") {
                $("#Text9").next('.txtError').show();
                Flag = false;
            }

            if ($("#drop10").val() == "") {
                $("#drop10").next('.txtError').show();
                Flag = false;
            }
            if ($("#Text10").val() == "") {
                $("#Text10").next('.txtError').show();
                Flag = false;
            }

            if (Flag == true) {
                return true;
            }
            else {
                return false;
            }

        });
        //    function comboInit(thelist)
        //     { theinput = document.getElementById(theinput); var idx = thelist.selectedIndex; 
        //     var content = thelist.options[idx].innerHTML; if(theinput.value == "") theinput.value = content;	
        //     }
        //      function combo(thelist, theinput) 
        //      { theinput = document.getElementById(theinput); 
        //      var idx = thelist.selectedIndex; 
        //      var content = thelist.options[idx].innerHTML; theinput.value = content;	
        //      }
        //    onChange="combo(this, 'theinput')" onMouseOut="comboInit(this, 'theinput')"  
        //    


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     
</asp:Content>
