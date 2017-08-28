<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecommendedDiet.ascx.cs" Inherits="GNHClientUI.UserControls.RecommendedDiet" %>

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
                        <input type="checkbox" class="ace" id="chk48DietRecall" onchange="setDietRecallType()" checked />
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
                            <th></th>
                            <th>Energy (kcal)</th>
                            <th>Protein (g)</th>
                            <th>Fat (g)</th>
                            <th>Fibre (mcg)</th>
                            <th>Carbs (g)</th>
                            <th rowspan="4">
                                <input type="button" id="btnSaveAllMeals" onclick="saveAllRecommendedDietMeals()" value="Save All" class="btn btn-primary btn-xlg" />
                                <input type="button" id="btnChooseFromHistory" class="btn btn-primary btn-xlg hidden" value="Choose from History" data-toggle="modal" data-target="#myModal" />
                            </th>
                        </tr>

                        <tr class="weekly">
                            <th>Weekly Avg.</th>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                        </tr>
                        <tr class="weekday">
                            <th>WeekDay Avg.</th>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                        </tr>
                        <tr class="weekend">
                            <th>WeekEnd Avg.</th>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td>
                        </tr>
                        <tr class="total hidden">
                            <th>Total</th>
                            <td>0</td>
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
                                                            <input name="add_button" type="button" id="add_button" value="Add" onclick="addRecommendedFoodRow('Meal1')" class="btn btn-primary btn-sm" /></td>
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
                                            <input type="button" class="btn btn-primary btn-sm" value="Save" onclick="saveRecommendedDietMeal('Meal1')" />
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
                        <asp:TextBox ID="txtRecommendedDietNotes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
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
                                                                            <th>Carbs (g)</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <input name="form-field-checkbox" type="checkbox" />
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
                                                                                <input name="form-field-checkbox" type="checkbox" />
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
                                                                                <input name="form-field-checkbox" type="checkbox" />
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
<script src="../Scripts/phone-format.js?v=2017082601"></script>
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
<script src="../Scripts/RecommendedDiet.js?v=2017082703"></script>
<script>
    $(document).ready(function () {
        setDietRecommendedType();
    });
</script>
<script type="text/javascript">

    $(document).ready(function () {


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


        //$('[data-rel=tooltip]').tooltip({ container: 'body' });
        //$('[data-rel=popover]').popover({ container: 'body' });

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


        $('input.FoodMeasure').typeahead({
            hint: true,
            highlight: true,
            minLength: 1
        }, {
            name: 'units',
            displayKey: 'value',
            source: substringMatcher(ace.vars['Measures'])
        });


        // scrollables
        //$('.scrollable').each(function () {
        //    var $this = $(this);
        //    $(this).ace_scroll({
        //        size: $this.attr('data-size') || 100,
        //        //styleClass: 'scroll-left scroll-margin scroll-thin scroll-dark scroll-light no-track scroll-visible'
        //    });
        //});
        //$('.scrollable-horizontal').each(function () {
        //    var $this = $(this);
        //    $(this).ace_scroll(
        //      {
        //          horizontal: true,
        //          styleClass: 'scroll-top',//show the scrollbars on top(default is bottom)
        //          size: $this.attr('data-size') || 500,
        //          mouseWheelLock: true
        //      }
        //    ).css({ 'padding-top': 12 });
        //});

        //$(window).on('resize.scroll_reset', function () {
        //    $('.scrollable-horizontal').ace_scroll('reset');
        //});

        $(document).one('ajaxloadstart.page', function (e) {
            $('textarea[class*=autosize]').trigger('autosize.destroy');
            $('.limiterBox,.autosizejs').remove();
            $('.daterangepicker.dropdown-menu,.colorpicker.dropdown-menu,.bootstrap-datetimepicker-widget.dropdown-menu').remove();
        });

    });

</script>


