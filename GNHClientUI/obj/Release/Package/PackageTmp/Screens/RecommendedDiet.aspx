<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="RecommendedDiet.aspx.cs" Inherits="GNHClientUI.Screens.RecommendedDiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <style>
        .c-btn {
            font-size: 12px;
            padding: 4px;
        }

        .addNewrow {
            position: relative;
            padding-right: 40px;
            margin: 0 0 5px 0;
        }

        .addnewForm .input-text {
            width: 24%;
            margin: 0 0 0 1%;
            display: inline-block;
        }

        .btn-addNew {
            position: absolute;
            top: 0;
            right: 0;
            padding: 2px 5px;
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

        #dietplan-form {
        }

            #dietplan-form .label-block,
            #dietplan-form .time-block {
                float: left;
                width: 150px;
                margin-right: 10px;
            }

            #dietplan-form .label-block {
                width: 100%;
                text-align: center;
            }

        .history-btn-block {
            float: left;
        }

        #dietplan-form .days-block {
            margin-right: 10px;
        }

        #dietplan-form .days-col {
            width: 300px;
            float: left;
            margin: 0 10px 0 0;
        }

        .btn-addnewmodal {
            padding: 0 5px;
            position: absolute;
            bottom: 5px;
            right: 5px;
        }

        button.btn-addnewmodal.btn:active {
            top: auto;
        }

        .day-col {
            width: 285px;
        }

        .days-block .table {
            border: 1px solid #ccc;
        }

        .days-block th {
            background: #ddd;
        }

        .form-horizontal .days-block .control-label {
            text-align: left;
            padding: 5px;
        }

        .days-table {
            border: 1px solid #ddd;
            border-collapse: collapse;
            margin-bottom: 10px;
        }

            .days-table th {
                text-align: center;
                padding: 5px 0;
            }

            .days-table td {
                border: 1px solid #ddd;
                vertical-align: top;
                padding: 5px;
                position: relative;
                padding-bottom: 40px;
            }

        #diet-table, #diet-table-Meal1, #diet-table-Meal2, #diet-table-Meal3, #diet-table-Meal4, #diet-table-Meal4,, #diet-table-Meal6, #diet-table-Meal7, #diet-table-Meal8, #diet-table-Meal9, #diet-table-Meal10, #diet-table-Meal11, #diet-table-Meal12 {
            width: 100%;
        }

        table.chkList tr input {
            margin-left: 10px !important;
        }

        @media screen and (max-width:1200px) {
            #diet-table, #diet-table-Meal1, #diet-table-Meal2, #diet-table-Meal3, #diet-table-Meal4, #diet-table-Meal4,, #diet-table-Meal6, #diet-table-Meal7, #diet-table-Meal8, #diet-table-Meal9, #diet-table-Meal10, #diet-table-Meal11, #diet-table-Meal12 {
                width: 1000px;
            }
        }
    </style>

    <div class="page-header">
        <div class="widget-box">
            <div class="widget-header">
                <h4 class="widget-title">Recommended Diet</h4>
            </div>

            <div class="widget-body hidden">
                <div class="widget-main">
                    <div class="form-inline">
                        <span class="label label-lg label-primary arrowed-right">Type&nbsp;</span>
                        <label class="inline">
                            <span>&nbsp;&nbsp;&nbsp;</span>
                            <input type="checkbox" class="ace" disabled checked />
                            <span class="lbl">&nbsp;24 Hour</span>
                        </label>
                        <label class="inline">
                            <span>&nbsp;&nbsp;&nbsp;</span>
                            <input type="checkbox" class="ace" id="chk48DietRecall" onchange="setDietRecallType()" checked/>
                            <span class="lbl">&nbsp;48 Hour</span>
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.page-header -->
    <div class="row">
        <div class="col-xs-12" style="overflow: auto;">
            <!-- PAGE CONTENT BEGINS -->
            <div class="form-horizontal" id="dietplan-form" role="form">
                <!-- #section:elements.form -->

                <div class="form-group">
                    <table class="table table-bordered table-striped" id="tblFoodListTotal">
                        <tbody>
                            <tr>
                                <th rowspan="2">Total</th>
                                <th>Energy (kcal)</th>
                                <th>Protein (g)</th>
                                <th>Fat (g)</th>
                                <th>Fibre (mcg)</th>
                                <th rowspan="2">
                                    <input type="button" id="btnSaveAllMeals" onclick="saveAllMeals()" value="Save All" class="btn btn-primary btn-xlg" />
                                    <input type="button" id="btnChooseFromHistory" class="btn btn-primary btn-xlg hidden" value="Choose from History" data-toggle="modal" data-target="#myModal" />
                                </th>
                            </tr>
                            <tr>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                                <td>0</td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <div id="divRecommendedDietMeals" runat="server">
                    <%--<div class="form-group">
                        <div class="days-block pull-left">
                            <table id="diet-table" class="table table-striped">
                                <tbody>
                                    <tr>
                                        <td>
                                            <label class="label-block control-label text-left" for="txtMeal1">Meal 1</label>
                                            <div class="time-block">
                                                <div class="input-group bootstrap-timepicker">
                                                    <input id="txtTimePickerMeal1" type="text" class="form-control" runat="server" />
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-clock-o bigger-110"></i>
                                                    </span>

                                                </div>
                                            </div>
                                        </td>
                                        <td>
                                            <asp:CheckBoxList ID="chkDaysMeal1" runat="server" RepeatDirection="Horizontal" CssClass="chkList">
                                                <asp:ListItem>Monday</asp:ListItem>
                                                <asp:ListItem>Tuesday</asp:ListItem>
                                                <asp:ListItem>Wednesday</asp:ListItem>
                                                <asp:ListItem>Thursday</asp:ListItem>
                                                <asp:ListItem>Friday</asp:ListItem>
                                                <asp:ListItem>Saturday</asp:ListItem>
                                                <asp:ListItem>Sunday</asp:ListItem>
                                            </asp:CheckBoxList>
                                            <div class='checkbox'>
                                                <label>
                                                    <input id="chkDaysMeal" type='checkbox' class='ace' value="Monday" checked>
                                                    <span class='lbl'> Monday</span>
                                                </label>
                                            </div>

                                            <div style="margin-top: 10px;">
                                                <table class="table table-bordered table-striped dataTable">
                                                    <tr>
                                                        <td>
                                                            <input type="text" class="FoodItem scrollable" id="txtFoodItemMeal1" placeholder="Food" style="min-width: 175px; font-size: 16px;"></td>
                                                        <td>
                                                            <input type="text" class="FoodQuantity scrollable" id="txtFoodQuantityMeal1" placeholder="Quantity"></td>
                                                        <td>
                                                            <input type="text" class="FoodMeasure scrollable" id="txtFoodMeasureMeal1" placeholder="Measure" style="min-width: 175px; font-size: 16px;"></td>
                                                        <td>
                                                            <input type="text" class="FoodRemark scrollable" id="txtFoodRemarkMeal1" placeholder="Remark"></td>
                                                        <td>
                                                            <input name="add_button" type="button" id="add_button" value="Add" onclick="addFoodRow('Meal1')" class="btn btn-primary btn-sm" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="margin-top: 10px;">
                                                <table id="tblFoodListMeal1" class="table table-bordered table-striped dataTable" runat="server">
                                                    <thead>
                                                        <tr class="titleRow">
                                                            <th class="hidden">FoodID</th>
                                                            <th colspan="2">Food</th>
                                                            <th>Quantity</th>
                                                            <th>Unit</th>
                                                            <th>Remark</th>
                                                            <th>Energy (kcal)</th>
                                                            <th>Protein (g)</th>
                                                            <th>Fat (g)</th>
                                                            <th>Fibre (mcg)</th>
                                                            <th>Action</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                    </tbody>
                                                    <tfoot>
                                                        <tr class="totalRow">
                                                            <td colspan="4"></td>
                                                            <td>Total</td>
                                                            <td class="totalCol">0</td>
                                                            <td class="totalCol">0</td>
                                                            <td class="totalCol">0</td>
                                                            <td class="totalCol">0</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </tfoot>
                                                </table>
                                            </div>
                                        </td>
                                        <td>
                                            <input type="button" class="btn btn-primary btn-sm" value="Save" onclick="saveMeal('Meal1')" />
                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>--%>
                </div>


                <div class="space-4"></div>

                <div class="widget-box">
                    <div class="widget-header">
                        <h4 class="widget-title">Notes</h4>
                    </div>

                    <div class="widget-body">
                        <div class="widget-main">
                            <asp:TextBox ID="txtRecallDietNotes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /section:elements.form -->
        </div>
    </div>
    <div class="row">
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Food History</h4>
                    </div>
                    <div class="modal-body">
                        <div class="accordion-style1 panel-group" id="accordion">

                            <%--default panel--%>
                            

                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#pnlVisit2">
                                            <i data-icon-show="ace-icon fa fa-plus" data-icon-hide="ace-icon fa fa-minus" class="bigger-110 ace-icon fa fa-plus"></i>
                                            Visit #1
                                        </a>
                                    </h4>
                                </div>
                                <div id="pnlVisit2" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <%--Scrollable Widget--%>

                                            <div class="col-sm-12 widget-container-col">
                                                <div class="widget-box widget-color-blue">
                                                    <div class="widget-header">
                                                        <h6 class="widget-title">Meal 2</h6>
                                                        <div class="widget-toolbar">

                                                            <label>
                                                                <input name="form-field-checkbox" type="checkbox" class="ace" title="Select All" />
                                                                <span class="lbl">&nbsp;</span>
                                                            </label>

                                                            <a href="#" data-action="collapse">
                                                                <i class="ace-icon fa fa-chevron-up"></i>
                                                            </a>

                                                            <a href="#" data-action="close">
                                                                <i class="ace-icon fa fa-times"></i>
                                                            </a>

                                                        </div>
                                                    </div>

                                                    <div class="widget-body">
                                                        <!-- #section:custom/scrollbar -->
                                                        <div class="widget-main padding-4 scrollable" data-size="150">
                                                            <div class="content">
                                                                <div class="control-group">
                                                                    <table class="table table-bordered table-striped dataTable">
                                                                        <thead>
                                                                            <tr class="titleRow">
                                                                                <th></th>
                                                                                <th class="hidden">FoodID</th>
                                                                                <th colspan="2">Food</th>
                                                                                <th>Quantity</th>
                                                                                <th>Unit</th>
                                                                                <th>Remark</th>
                                                                                <th>Energy (kcal)</th>
                                                                                <th>Protein (g)</th>
                                                                                <th>Fat (g)</th>
                                                                                <th>Fibre (mcg)</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <input name="form-field-checkbox" type="checkbox"  />
                                                                                </td>
                                                                                <td colspan="2">ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <input name="form-field-checkbox" type="checkbox"  />
                                                                                </td>
                                                                                <td colspan="2">ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <input name="form-field-checkbox" type="checkbox"  />
                                                                                </td>
                                                                                <td colspan="2">ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                                <td>ONE</td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <!-- /section:custom/scrollbar -->
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Button ID="btnGenerateDietPlanReport" runat="server" Text="Print" OnClick="btnGenerateDietPlanReport_click" CssClass="btn btn-primary btn-lg hidden" />
    <!-- /.modal -->
    <!-- page specific plugin scripts -->

    <!--[if lte IE 8]>
		  <script src="../assets/js/excanvas.js"></script>
		<![endif]-->

    <script src="../assets/js/jquery.js"></script>
    <script src="../assets/js/jquery-ui.custom.js"></script>
    <script src="../assets/js/jquery.ui.touch-punch.js"></script>
    <script src="../assets/js/chosen.jquery.js"></script>
    <script src="../assets/js/fuelux/fuelux.spinner.js"></script>
    <script src="../assets/js/date-time/bootstrap-datepicker.js"></script>
    <script src="../assets/js/date-time/bootstrap-timepicker.js"></script>
    <script src="../assets/js/date-time/moment.js"></script>
    <script src="../assets/js/date-time/daterangepicker.js"></script>
    <script src="../assets/js/date-time/bootstrap-datetimepicker.js"></script>
    <script src="../assets/js/bootstrap-colorpicker.js"></script>
    <script src="../assets/js/jquery.knob.js"></script>
    <script src="../assets/js/jquery.autosize.js"></script>
    <script src="../assets/js/jquery.inputlimiter.1.3.1.js"></script>
    <script src="../assets/js/jquery.maskedinput.js"></script>
    <script src="../assets/js/bootstrap-tag.js"></script>
    <script src="../assets/js/typeahead.jquery.js"></script>
    <script src="../assets/js/ace/elements.typeahead.js"></script>
    <script src="../Scripts/notify.min.js"></script>
    <!-- inline scripts related to this page -->
    <script>

        var itemCount = 0;

        $(document).ready(function () {
            setDietRecallType();
        });

        var objs = [];
        var temp_objs = [];

        function addFoodRow(MealId) {
            //$("#add_button").click(function () {

            var html = "";
            //var foodName = $("#txtFoodItemMeal1").val();
            var foodName = $("#txtFoodItem" + MealId).val();
            var foodQuantity = $("#txtFoodQuantity" + MealId).val();
            var foodUnit = $("#txtFoodMeasure" + MealId).val();

            if (foodName == '')
                return;

            var foodNutrients;


            debugger;
            $.ajax({
                type: "POST",
                url: "../Screens/RecommendedDiet.aspx/GetFoodNutrients",
                data: '{FoodName: "' + foodName + '",foodQuantity: "' + foodQuantity + '",foodUnit: "' + foodUnit + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    //alert(response.d);
                    //notie.alert(1, 'Success!', 2);
                    foodNutrients = response.d;
                },
                failure: function (response) {
                    //alert(response.d);
                }
            });

            var obj = {
                "ROW_ID": itemCount,
                "FOOD_ID": foodNutrients.foodID,
                "FOOD_NAME": $("#txtFoodItem" + MealId).val(),
                "FOOD_QUANTITY": $("#txtFoodQuantity" + MealId).val(),
                "FOOD_UNIT": $("#txtFoodMeasure" + MealId).val(),
                "FOOD_REMARK": $("#txtFoodRemark" + MealId).val(),
                "FOOD_ENERGY": foodNutrients.energy,
                "FOOD_PROTEIN": foodNutrients.protein,
                "FOOD_FAT": foodNutrients.fat,
                "FOOD_FIBRE": foodNutrients.fibre,
            }

            // add object
            objs.push(obj);

            itemCount++;
            // dynamically create rows in the table
            html += "<tr id='tr" + itemCount + "'>";
            html += "   <td class='mealInput hidden'>" + obj['FOOD_ID'] + "</td>";
            html += "   <td colspan='2'>" + obj['FOOD_NAME'] + "</td>";
            html += "   <td class='mealInput'>" + obj['FOOD_QUANTITY'] + " </td>";
            html += "   <td class='mealInput'>" + obj['FOOD_UNIT'] + " </td>";
            html += "   <td class='mealInput'>" + obj['FOOD_REMARK'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_ENERGY'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_PROTEIN'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_FAT'] + " </td>";
            html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_FIBRE'] + " </td>";
            html += "   <td class='action'><input type='button'  id='" + itemCount + "' value='remove' onclick='removeFoodRow(&quot;" + MealId + "&quot; , this)'></td>";
            html += "</tr>";



            //add to the table
            $("table[id$='tblFoodList" + MealId + "'] > tbody:last").append(html);

            calculateTotal(MealId);

            $("#txtFoodItem" + MealId).val("");
            $("#txtFoodQuantity" + MealId).val("");
            $("#txtFoodMeasure" + MealId).val("");
            $("#txtFoodRemark" + MealId).val("");



        }

        function removeFoodRow(MealId, removeButton) {
            $(removeButton).parent().parent().remove();
            calculateTotal(MealId);
        }

        function calculateTotal(MealId) {
            var totals = [0, 0, 0, 0];

            var $dataRows = $("table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");

            $dataRows.each(function () {
                $(this).find('.rowDataSd').each(function (i) {
                    totals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            });

            $("table[id$='tblFoodList" + MealId + "'] td.totalCol").each(function (i) {
                $(this).html(totals[i].toFixed(2));
            });

            //Overall Total
            calculateAllTotal();
        }

        function calculateAllTotal() {
            var totals = [0, 0, 0, 0];
            var sel48DietRecallOrNot = "[role!='RecallDiet48Hour']";

            if ($("#chk48DietRecall").is(':checked')) {
                sel48DietRecallOrNot = "";
            }


            var $dataRows = $("table[id*='tblFoodListMeal']" + sel48DietRecallOrNot + " tr:not('.totalRow, .titleRow')");

            $dataRows.each(function () {
                $(this).find('.rowDataSd').each(function (i) {
                    totals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            });

            $("table[id='tblFoodListTotal'] td").each(function (i) {
                $(this).html(totals[i].toFixed(2));
            });
        }

        function saveMeal(MealId) {
            var weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
            var mealDays = "";
            var mealData = "";
            var mealTime = $("input[id$='txtTimePicker" + MealId + "']").val().trim();
            var notes = $("textarea[id$='txtRecallDietNotes']").val().trim();


            $("input[id*='chkDays" + MealId + "_']:checked").each(function () {
                mealDays = mealDays + weekDays.indexOf($(this).val()) + "-";
            });

            mealDays = mealDays.substr(0, mealDays.lastIndexOf("-"));

            //alert(mealDays);


            var $dataRows = $("table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");

            $dataRows.each(function () {
                $(this).find('.mealInput').each(function () {
                    mealData = mealData + $(this).html().trim() + "|";
                });
                mealData = mealData.substr(0, mealData.lastIndexOf("|"));
                mealData = mealData + "~";
            });

            mealData = mealData.substr(0, mealData.lastIndexOf("~"));

            //alert(mealData);

            $.ajax({
                type: "POST",
                url: "../Screens/RecommendedDiet.aspx/SaveRecommendedSingleMealDetails",
                data: '{MealID: "' + MealId + '", MealDays: "' + mealDays + '", MealData: "' + mealData + '", MealTime: "' + mealTime + '", Notes: "' + notes + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (response) {
                    //alert(response.d);
                    $("input[id='btnSave" + MealId + "']").notify(
                      "Saved",
                      { position: "right", className: 'success' }
                    );

                    //$.notify("Saved", "success");

                    foodNutrients = response.d;
                },
                failure: function (response) {
                    //alert(response.d);
                    $("input[id='btnSave" + MealId + "']").notify(
                      "Error",
                      { position: "right", className: 'error' }
                    );
                }
            });


        }

        function saveAllMeals() {
            var mealName = "Meal";
            var length = 6;

            if ($("#chk48DietRecall").is(':checked')) {
                length = 12;
            }
            for (var meal = 1; meal <= length; meal++) {
                saveMeal(mealName + meal);
            }

            $("input[id='btnSaveAllMeals']").notify(
              "Saved",
              { position: "right", className: 'success' }
            );

        }

        function setDietRecallType() {
            if ($("#chk48DietRecall").is(':checked')) {
                $("div[role='RecallDiet48Hour'").show();
            }
            else {
                $("div[role='RecallDiet48Hour'").hide();
            }
            calculateAllTotal();
        }



    </script>
    <script type="text/javascript">

        jQuery(function ($) {


            $("input[name*='form-field-checkbox'][title='Select All']").on('change', function () {
                //$("input[id^='chkMeal1']").prop('checked', $(this).is(':checked'));
                $(this).parents('div.widget-container-col').children("div").children("div:last").find("input.ace").prop('checked', $(this).is(':checked'));
            });

            if (!ace.vars['touch']) {
                $('.chosen-select').chosen({ allow_single_deselect: true });
                //resize the chosen on window resize

                $(window)
                .off('resize.chosen')
                .on('resize.chosen', function () {
                    $('.chosen-select').each(function () {
                        var $this = $(this);
                        $this.next().css({ 'width': $this.parent().width() });
                    })
                }).trigger('resize.chosen');
                //resize chosen on sidebar collapse/expand
                $(document).on('settings.ace.chosen', function (e, event_name, event_val) {
                    if (event_name != 'sidebar_collapsed') return;
                    $('.chosen-select').each(function () {
                        var $this = $(this);
                        $this.next().css({ 'width': $this.parent().width() });
                    })
                });


                $('#chosen-multiple-style .btn').on('click', function (e) {
                    var target = $(this).find('input[type=radio]');
                    var which = parseInt(target.val());
                    if (which == 2) $('#form-field-select-4').addClass('tag-input-style');
                    else $('#form-field-select-4').removeClass('tag-input-style');
                });
            }


            $('[data-rel=tooltip]').tooltip({ container: 'body' });
            $('[data-rel=popover]').popover({ container: 'body' });

            $('textarea[class*=autosize]').autosize({ append: "\n" });
            $('textarea.limited').inputlimiter({
                remText: '%n character%s remaining...',
                limitText: 'max allowed : %n.'
            });



            //datepicker plugin
            //link
            $('.date-picker').datepicker({
                autoclose: true,
                todayHighlight: true
            })
            //show datepicker when clicking on the icon
            .next().on(ace.click_event, function () {
                $(this).prev().focus();
            });



            //$("input[id='timepicker1']").timepicker({
            $("input[id*='txtTimePickerMeal']").timepicker({
                minuteStep: 1,
                showSeconds: false,
                showMeridian: false
            }).next().on(ace.click_event, function () {
                $(this).prev().focus();
            });

            $('#date-timepicker1').datetimepicker().next().on(ace.click_event, function () {
                $(this).prev().focus();
            });



            /////////

            //typeahead.js
            //example taken from plugin's page at: https://twitter.github.io/typeahead.js/examples/
            var substringMatcher = function (strs) {
                return function findMatches(q, cb) {
                    var matches, substringRegex;

                    // an array that will be populated with substring matches
                    matches = [];

                    // regex used to determine if a string contains the substring `q`
                    substrRegex = new RegExp(q, 'i');

                    // iterate through the pool of strings and for any string that
                    // contains the substring `q`, add it to the `matches` array
                    $.each(strs, function (i, str) {
                        if (substrRegex.test(str)) {
                            // the typeahead jQuery plugin expects suggestions to a
                            // JavaScript object, refer to typeahead docs for more info
                            matches.push({ value: str });
                        }
                    });

                    cb(matches);
                }
            }


            $('input.FoodItem').typeahead({
                hint: true,
                highlight: true,
                minLength: 1
            }, {
                name: 'foods',
                displayKey: 'value',
                source: substringMatcher(ace.vars['Foods'])
            });


            //$('input.FoodQuantity').typeahead({
            //    hint: true,
            //    highlight: true,
            //    minLength: 1
            //}, {
            //    name: 'quantity',
            //    displayKey: 'value',
            //    source: substringMatcher(ace.vars['Qty'])
            //});

            $('input.FoodMeasure').typeahead({
                hint: true,
                highlight: true,
                minLength: 1
            }, {
                name: 'units',
                displayKey: 'value',
                source: substringMatcher(ace.vars['Measures'])
            });

            //$('input.FoodRemark').typeahead({
            //    hint: true,
            //    highlight: true,
            //    minLength: 1
            //}, {
            //    name: 'states',
            //    displayKey: 'value',
            //    source: substringMatcher(ace.vars['Remark'])
            //});

            // scrollables
            $('.scrollable').each(function () {
                var $this = $(this);
                $(this).ace_scroll({
                    size: $this.attr('data-size') || 100,
                    //styleClass: 'scroll-left scroll-margin scroll-thin scroll-dark scroll-light no-track scroll-visible'
                });
            });
            $('.scrollable-horizontal').each(function () {
                var $this = $(this);
                $(this).ace_scroll(
                  {
                      horizontal: true,
                      styleClass: 'scroll-top',//show the scrollbars on top(default is bottom)
                      size: $this.attr('data-size') || 500,
                      mouseWheelLock: true
                  }
                ).css({ 'padding-top': 12 });
            });

            $(window).on('resize.scroll_reset', function () {
                $('.scrollable-horizontal').ace_scroll('reset');
            });

            $(document).one('ajaxloadstart.page', function (e) {
                $('textarea[class*=autosize]').trigger('autosize.destroy');
                $('.limiterBox,.autosizejs').remove();
                $('.daterangepicker.dropdown-menu,.colorpicker.dropdown-menu,.bootstrap-datetimepicker-widget.dropdown-menu').remove();
            });

        });

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
