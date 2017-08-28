<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" Inherits="Screens_PatientMaster" CodeBehind="PatientMaster.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="UC" TagName="History" Src="~/UserControl/UserHistory.ascx" %>
<%@ Register TagPrefix="UC" TagName="Recall" Src="~/UserControl/RecallDiet.ascx" %>
<%@ Register TagPrefix="UC" TagName="Recommend" Src="~/UserControl/RecommendedDiet.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <link href="../css/intlTelInput.css" rel="stylesheet" />
    
    <script src="../assets/js/jquery.js"></script>
    <script src="../Scripts/phone-format.js?v=2017082606"></script>      
    <script src="../assets/js/jquery-ui.custom.js"></script>
    <script src="../assets/js/jquery.ui.touch-punch.js"></script>
    <script src="../assets/js/chosen.jquery.js"></script>
    <script src="../assets/js/date-time/bootstrap-datepicker.js"></script>
    <script src="../assets/js/date-time/bootstrap-timepicker.js"></script>
    <script src="../assets/js/date-time/daterangepicker.js"></script>
    <script src="../assets/js/date-time/bootstrap-datetimepicker.js"></script>
    <script src="../assets/js/jquery.maskedinput.js"></script>
    <script src="../assets/js/jquery.addnew.js"></script>
    <script src="../Scripts/gnh-converter.js"></script>
    <script src="../Scripts/RecallDiet.js?v=2017082705"></script>
    <script src="../Scripts/RecommendedDiet.js?v=2017082705"></script>
    <style type="text/css">
        .table {
            border-bottom: 0px !important;
        }

            .table th, .table td {
                border: 0px !important;
            }

        .fixed-table-container {
            border: 0px !important;
        }

        .nopadding {
            padding: 2px !important;
            margin: 2px !important;
        }

        .ModalPopupBG {
            background-color: #666699;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .HellowWorldPopup {
            min-width: 200px;
            min-height: 150px;
            background: white;
        }

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

        .width1 {
            width: 445px;
        }

        .profession {
            display: none;
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

        .padd {
            margin-bottom: 2px !important;
        }

            .padd .control-block {
                padding-bottom: 2px;
            }

        /*-----------------------*/
        @-webkit-keyframes uil-default-anim {
            0% {
                opacity: 1;
            }

            100% {
                opacity: 0;
            }
        }

        @keyframes uil-default-anim {
            0% {
                opacity: 1;
            }

            100% {
                opacity: 0;
            }
        }

        .uil-default-css > div:nth-of-type(1) {
            -webkit-animation: uil-default-anim 1s linear infinite;
            animation: uil-default-anim 1s linear infinite;
            -webkit-animation-delay: -0.5s;
            animation-delay: -0.5s;
        }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(2) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: -0.4166666666666667s;
                animation-delay: -0.4166666666666667s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(3) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: -0.33333333333333337s;
                animation-delay: -0.33333333333333337s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(4) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: -0.25s;
                animation-delay: -0.25s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(5) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: -0.16666666666666669s;
                animation-delay: -0.16666666666666669s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(6) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: -0.08333333333333331s;
                animation-delay: -0.08333333333333331s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(7) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: 0s;
                animation-delay: 0s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(8) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: 0.08333333333333337s;
                animation-delay: 0.08333333333333337s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(9) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: 0.16666666666666663s;
                animation-delay: 0.16666666666666663s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(10) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: 0.25s;
                animation-delay: 0.25s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(11) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: 0.33333333333333337s;
                animation-delay: 0.33333333333333337s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

            .uil-default-css > div:nth-of-type(12) {
                -webkit-animation: uil-default-anim 1s linear infinite;
                animation: uil-default-anim 1s linear infinite;
                -webkit-animation-delay: 0.41666666666666663s;
                animation-delay: 0.41666666666666663s;
            }

        .uil-default-css {
            position: relative;
            background: none;
            width: 200px;
            height: 200px;
        }

        #loading {
            width: 100%;
            height: 100%;
            top: 38%;
            left: 45%;
            position: fixed;
            display: block;
            z-index: 99;
        }
        /*-----------------------*/
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            //$("#tabs").tabs();

            /*$("a[href$='tabs-7']").parent().replaceWith("</ul><ul>"); //hide RecallDiet Tab

			//$("body").keydown(function (event) {
			//    switch (event.which) {
			//        case 37: //Arrow left
			//            $('.nav-tabs > .active').prev('li').find('a').trigger('click');
			//            break;
			//        case 39: //Arrow left
			//            $('.nav-tabs > .active').next('li').find('a').trigger('click');
			//            break;
			//    }
			//});
			*/
            $(document).keydown(function (e) {

                // Set self as the current item in focus
                var self = $(':focus'),
					// Set the form by the current item in focus
					form = self.parents('form:eq(0)'),
					focusable;

                // Array of Indexable/Tab-able items
                focusable = form.find('input,a,select,button,textarea').filter(':visible');

                function enterKey() {
                    if (e.which === 13) { // [Enter] key!self.is('textarea'

                        // If not a regular hyperlink/button/textarea
                        if ($.inArray(self, focusable) && (!self.is('a')) && (!self.is('button'))) {
                            // Then prevent the default [Enter] key behaviour from submitting the form
                            e.preventDefault();
                        } // Otherwise follow the link/button as by design, or put new line in textarea

                        // Focus on the next item (either previous or next depending on shift)
                        focusable.eq(focusable.index(self) + (e.shiftKey ? -1 : 1)).focus();

                        return false;
                    }
                }
                // We need to capture the [Shift] key and check the [Enter] key either way.
                if (e.shiftKey) { enterKey() } else { enterKey() }
            });

            //$('#ContentPlaceHolder1_ContentPlaceHolder3_txtDOB').click(function () {
            //    alert(2);
            //})
            SetTabs();
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            if (prm != null) {
                prm.add_endRequest(function (sender, e) {
                    if (sender._postBackSettings.panelsToUpdate != null) {
                        SetTabs();
                    }
                });
            };

            //$('#btnComorbidity').live('click', function (evt) { SetTabs(); });
        });


        function ValidateMobileOnSubmit(oSrc, args) {
            debugger;
            var selectedCountry = $("#ContentPlaceHolder1_ContentPlaceHolder3_ddlCountries option:selected");
            var aCountryCode = countryNameToCode("" + selectedCountry.text());
            var txtMobile = $("#ContentPlaceHolder1_ContentPlaceHolder3_txtMobile");
            args.IsValid = isValidNumberForRegion(txtMobile.val(), aCountryCode);
        }

        function ValidateLandlineOnSubmit(oSrc, args) {
            var selectedCountry = $("#ContentPlaceHolder1_ContentPlaceHolder3_ddlCountries option:selected");
            var aCountryCode = countryNameToCode("" + selectedCountry.text());
            var txtLandline = $("#ContentPlaceHolder1_ContentPlaceHolder3_txtLandline");
            args.IsValid = isValidNumberForRegion(txtLandline.val(), aCountryCode);
        }

        function SetExampleMobileLandlineNumber() {
            var selectedCountry = $("#ContentPlaceHolder1_ContentPlaceHolder3_ddlCountries option:selected");
            var aCountryCode = countryNameToCode("" + selectedCountry.text());
            var txtMobile = $("#ContentPlaceHolder1_ContentPlaceHolder3_txtMobile");
            var txtLandline = $("#ContentPlaceHolder1_ContentPlaceHolder3_txtLandline");

            txtMobile.attr('placeholder', exampleMobileNumber(aCountryCode));
            txtLandline.attr('placeholder', exampleLandlineNumber(aCountryCode));
        }

        function pageLoad(sender, args) {
            $(document).ready(function () {
                SetExampleMobileLandlineNumber();
            });
        }


        function SetTabs() {

            $("textarea").on("keydown", function (e) {
                var key = e.keyCode;
                debugger;
                // If the user has pressed enter
                if (key === 13) {
                    $(this)[0].value = '' + $(this)[0].value + '\n';
                    return false;
                }
                else {
                    return true;
                }
            });
            //Calling BMR Function first time
            BMR();
            if ($("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val() == "") {
                $("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val('tabs-1');
            }

            //Add Space between meal and number i.e Meal1 will be Meal 1
            $("label[for^='txtTimePickerMeal']").each(function (i) {
                $(this).text("Meal " + $(this).text().substring(4));
            });

            $("#tabs a").click(function () {
                $("[id*='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val($(this).attr("href").replace("#", ""));

                if ($(this).text() == "Recommended Diet") {

                    $.ajax({
                        type: "POST",
                        url: 'DietHelper.aspx/GetRecommendedDietDetails',
                        //data: JSON.stringify({ moduleOfferingId: id }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            $('[id$="divRecommendedDietMeals"]').html(data.d[0]);
                            $('[id$="txtRecommendedDietNotes"]').val(data.d[1]);
                        },
                        error: function (data) {
                        }
                    });

                    $.ajax({
                        type: "POST",
                        url: 'HistoryHelper.aspx/GetRecommendedDetails',
                        //data: JSON.stringify({ moduleOfferingId: id }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            $('div[id="RecommendedDietHistory"]').html(data.d[0]);
                        },
                        error: function (data) {
                        }
                    });

                    $("label[for^='txtTimePickerMeal']").each(function (i) {
                        $(this).text("Meal " + $(this).text().substring(4));
                        //alert($(this).text());
                    });
                    calculateRecommendedDietAllTotal();
                    ////////

                    var substringMatcherRecommended = function (strs) {
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

                    $('#RecommendedDietSection input.FoodItem').typeahead({
                        hint: true,
                        highlight: true,
                        minLength: 1
                    }, {
                        name: 'foods',
                        displayKey: 'value',
                        source: substringMatcherRecommended(ace.vars['Foods'])
                    });

                    $('#RecommendedDietSection input.FoodMeasure').typeahead({
                        hint: true,
                        highlight: true,
                        minLength: 1
                    }, {
                        name: 'units',
                        displayKey: 'value',
                        source: substringMatcherRecommended(ace.vars['Measures'])
                    });

                    $("#RecommendedDietSection input[id*='txtTimePickerMeal']").timepicker({
                        minuteStep: 1,
                        showSeconds: false,
                        showMeridian: false
                    }).on("changeTime.timepicker", function (e) {
                        debugger;
                        var MealId = $(this).data().mealName;
                        var prevMealTime = $(this).attr('data-meal-time');
                        var newMealTime = e.time.value;
                        //console.log('' + MealId + ' New Meal Time - ' + newMealTime + ' Old Meal Time - ' + prevMealTime);
                        if (prevMealTime != newMealTime) {
                            changeRecommendedMealTime(MealId);
                            $(this).attr('data-meal-time', newMealTime);
                            $(this).attr('value', newMealTime);
                        }
                    }).next().on(ace.click_event, function () {
                        $(this).prev().focus();
                    });

                    ////////
                }

                if ($(this).text() == "Recall Diet") {

                    $.ajax({
                        type: "POST",
                        url: 'DietHelper.aspx/GetRecallDietDetails',
                        //data: JSON.stringify({ moduleOfferingId: id }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            $('[id$="divRecallDietMeals"]').html(data.d[0]);
                            $('[id$="txtRecallDietNotes"]').val(data.d[1]);
                        },
                        error: function (data) {
                        }
                    });

                    $("label[for^='txtTimePickerMeal']").each(function (i) {
                        $(this).text("Meal " + $(this).text().substring(4));
                        //alert($(this).text());
                    });


                    //calculateAllTotal();
                    //calculateWeekendWeekdayTotal();
                    setDietRecallType();
                    ////////

                    var substringMatcherRecommended = function (strs) {
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


                    $('#RecallDietSection input.FoodItem').typeahead({
                        hint: true,
                        highlight: true,
                        minLength: 1
                    }, {
                        name: 'foods',
                        displayKey: 'value',
                        source: substringMatcherRecommended(ace.vars['Foods'])
                    });

                    $('#RecallDietSection input.FoodMeasure').typeahead({
                        hint: true,
                        highlight: true,
                        minLength: 1
                    }, {
                        name: 'units',
                        displayKey: 'value',
                        source: substringMatcherRecommended(ace.vars['Measures'])
                    });

                    $("#RecallDietSection input[id*='txtTimePickerMeal']").timepicker({
                        //onSelect: function (d,i) { console.log('Hi'+i.lastVal());},
                        minuteStep: 1,
                        showSeconds: false,
                        showMeridian: false
                    }).on("changeTime.timepicker", function (e) {
                        debugger;
                        var MealId = $(this).data().mealName;
                        var prevMealTime = $(this).attr('data-meal-time');
                        var newMealTime = e.time.value;
                        //console.log('' + MealId + ' New Meal Time - ' + newMealTime + ' Old Meal Time - ' + prevMealTime);
                        if (prevMealTime != newMealTime) {
                            changeRecallMealTime(MealId);
                            $(this).attr('data-meal-time', newMealTime);
                            $(this).attr('value', newMealTime);
                        }
                    }).next().on(ace.click_event, function () {
                        $(this).prev().focus();
                    });


                    ////////
                }

                if ($(this).text() == "Visits") {

                    $.ajax({
                        type: "POST",
                        url: 'HistoryHelper.aspx/GetHistoryDetails',
                        //data: JSON.stringify({ moduleOfferingId: id }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        success: function (data) {
                            $('div[id="History"]').html(data.d[0]);
                        },
                        error: function (data) {
                        }
                    });
                }

            });
            var tabName = $("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val();
            $('#tabs a[href="#' + tabName + '"]').trigger('click');


			<%--//Datepicker
			$('.btn-date').on('click', function (e) {
				e.preventDefault();
				$.dateSelect.show({
					element: $('#<%= txtDOB.ClientID %>')
				});
			});--%>

		    $('#<%= txtDOB.ClientID %>').datepicker({
		        autoclose: true,
		        format: 'dd/mm/yyyy'
		    }).mask('99/99/9999');


		    var age = document.getElementById('<%=txtAge.ClientID %>').value;
		    if (age < 18)
		        $('div .child').css('display', 'block');
		    else
		        $('div .child').css('display', 'none');


		    $('#<%= ddlGender.ClientID %>').change(function () {
			    if ($(this).val() == 'Male') {
			        $('div .gender').css('display', 'none');
			    }
			    else {
			        $('div .gender').css('display', 'block');
			    }
			});

			if ($('#<%= ddlLactatingMother.ClientID %>').val() == 'Yes') {
		        $('div .NoLactic').css('display', 'block');
		    }
		    else {
		        $('div .NoLactic').css('display', 'none');
		    }

		    if ($('#<%= ddlPregnant.ClientID %>').val() == 'Yes') {
		        $('div .NoPregnant').css('display', 'block');
		        $('div .NoLactic').css('display', 'block');
		    }
		    else {
		        $('div .NoPregnant').css('display', 'none');
		        $('div .NoLactic').css('display', 'none');
		    }

		    if ($('#<%= ddlGender.ClientID %>').val() == 'Male')
		        $('div .gender').css('display', 'none');
		    else
		        $('div .gender').css('display', 'block');

		    if ($('#<%= ddlProfession.ClientID %>').val() == 'Other,Specify')
		        $('#<%=txtProfessionOthers.ClientID %>').css('display', 'block');
			else
			    $('#<%=txtProfessionOthers.ClientID %>').css('display', 'none');


            $('#<%= ddlProfession.ClientID %>').change(function () {
		        if ($(this).val() == 'Other,Specify') {

		            $('#<%=txtProfessionOthers.ClientID %>').css('display', 'block');
				}
				else {
				    $('#<%=txtProfessionOthers.ClientID %>').css('display', 'none');
				}
			});

            $('#<%= txtBloodPressure.ClientID %>').mask('999/999');

		    //$('#<%= txtSleep.ClientID %>').mask('99/99')

		    $('#<%= ddlAlcohol.ClientID %>').change(function () {
		        if ($(this).val() == 'Yes') {
		            $('div .NoAlcohol').css('display', 'block');
		        }
		        else {
		            $('div .NoAlcohol').css('display', 'none');
		        }
		    });
		    if ($('#<%= ddlAlcohol.ClientID %>').val() == 'Yes')
		        $('div .NoAlcohol').css('display', 'block');
		    else
		        $('div .NoAlcohol').css('display', 'none');

		    $('#<%= ddlPregnant.ClientID %>').change(function () {
		        if ($(this).val() == 'Yes') {

		            $('div .NoPregnant').css('display', 'block');
		            $('div .NoLactic').css('display', 'block');
		        }
		        else {
		            $('div .NoPregnant').css('display', 'none');
		            $('div .NoLactic').css('display', 'none');
		        }
		    });

		    $('#<%= ddlLactatingMother.ClientID %>').change(function () {
		        if ($(this).val() == 'Yes') {
		            $('div .NoLactic').css('display', 'block');
		        }
		        else {
		            $('div .NoLactic').css('display', 'none');
		        }
		    });
		    if ($('#<%= ddlThyroid.ClientID %>').val() == 'No')
		        $('div .NoThyroid').css('display', 'none');
		    else
		        $('div .NoThyroid').css('display', 'block');

		    $('#<%= ddlThyroid.ClientID %>').change(function () {
		        if ($(this).val() == 'No') {
		            $('div .NoThyroid').css('display', 'none');
		        }
		        else {
		            $('div .NoThyroid').css('display', 'block');
		        }
		    });

		    if ($('#<%= ddlExercise.ClientID %>').val() == 'Yes') {
		        $('div .NoExercise').css('display', 'block');
		    }
		    else {
		        $('div .NoExercise').css('display', 'none');
		    }


		    $('#<%= ddlExercise.ClientID %>').change(function () {
		        if ($(this).val() == 'Yes') {
		            $('div .NoExercise').css('display', 'block');
		        }
		        else {
		            $('div .NoExercise').css('display', 'none');
		        }
		    });

		    $('#<%= ddlVitaminSuplement.ClientID %>').change(function () {
		        if ($(this).val() == 'Yes') {
		            $('div .vitamindiv').css('opacity', '1');
		        }
		        else {
		            $('div .vitamindiv').css('opacity', '0');
		        }
		    });

		    if ($('#<%= ddlVitaminSuplement.ClientID %>').val() == 'Yes') {
		        $('div .vitamindiv').css('opacity', '1');
		    }
		    else {
		        $('div .vitamindiv').css('opacity', '0');
		    }

		    $('#<%= ddlMineralSuppliment.ClientID %>').change(function () {
		        if ($(this).val() == 'Yes') {
		            $('div .mineraldiv').css('opacity', '1');
		        }
		        else {
		            $('div .mineraldiv').css('opacity', '0');
		        }
		    });

		    if ($('#<%= ddlMineralSuppliment.ClientID %>').val() == 'Yes') {
		        $('div .mineraldiv').css('opacity', '1');
		    }
		    else {
		        $('div .mineraldiv').css('opacity', '0');
		    }

		    $('#<%= ddlOralDetails.ClientID %>').change(function () {
		        if ($(this).val() == 'Yes') {
		            $('div .oraldiv').css('opacity', '1');
		        }
		        else {
		            $('div .oraldiv').css('opacity', '0');
		        }
		    });

		    if ($('#<%= ddlOralDetails.ClientID %>').val() == 'Yes') {
		        $('div .oraldiv').css('opacity', '1');
		    }
		    else {
		        $('div .oraldiv').css('opacity', '0');
		    }

		    $('#<%= ddlDietType.ClientID %>').change(function () {
		        if ($(this).val().toUpperCase() == 'NON-VEGETARIAN') {
		            $('div .nonveg').css('display', 'block');
		            $('div .chicken').css('display', 'none');
		            $('div .egg').css('display', 'none');
		            $('div .fish').css('display', 'none');
		            $('div .meat').css('display', 'none');
		            Nonveg();
		        }
		        else {
		            $('div .nonveg').css('display', 'none');
		            $('div .chicken').css('display', 'none');
		            $('div .egg').css('display', 'none');
		            $('div .fish').css('display', 'none');
		            $('div .meat').css('display', 'none');
		        }
		    });

		    $('#<%= chkNonvegType.ClientID %>').click(function (e) {
		        Nonveg();
		    });
		    if ($('#<%= ddlDietType.ClientID %>').val().toUpperCase() == 'NON-VEGETARIAN') {
		        $('div .nonveg').css('display', 'block');
		        $('div .chicken').css('display', 'none');
		        $('div .egg').css('display', 'none');
		        $('div .fish').css('display', 'none');
		        $('div .meat').css('display', 'none');
		        Nonveg();
		    }
		    else {
		        $('div .nonveg').css('display', 'none');
		        $('div .chicken').css('display', 'none');
		        $('div .egg').css('display', 'none');
		        $('div .fish').css('display', 'none');
		        $('div .meat').css('display', 'none');
		    }

		    $('#<%= txtTestDate.ClientID %>').datepicker({
		        autoclose: true,
		        format: 'dd/mm/yyyy'
		    }).mask('99/99/9999');

		    $("#<%=ddlActivity.ClientID%>").change(function () {
		        BMR();
		    });

		};
		function Nonveg() {

		    $("[id*='ContentPlaceHolder1_ContentPlaceHolder3_chkNonvegType']").each(function () {
		        if ($(this).val().toUpperCase() == 'CHICKEN') {
		            if ($(this).is(":checked") == true) {
		                $('div .chicken').css('display', 'block');
		            }
		            else {
		                $('div .chicken').css('display', 'none');
		            }
		        }
		        if ($(this).val().toUpperCase() == 'EGG') {
		            if ($(this).is(":checked") == true) {
		                $('div .egg').css('display', 'block');
		            }
		            else {
		                $('div .egg').css('display', 'none');
		            }
		        }
		        if ($(this).val().toUpperCase() == 'FISH') {
		            if ($(this).is(":checked") == true) {
		                $('div .fish').css('display', 'block');
		            }
		            else {
		                $('div .fish').css('display', 'none');
		            }
		        }
		        if ($(this).val().toUpperCase() == "RED MEAT") {
		            if ($(this).is(":checked") == true) {
		                $('div .meat').css('display', 'block');
		            }
		            else {
		                $('div .meat').css('display', 'none');
		            }
		        }
		        if ($(this).val().toUpperCase() == 'ALL') {
		            if ($(this).is(":checked") == true) {
		                $('div .meat').css('display', 'block');
		                $('div .fish').css('display', 'block');
		                $('div .egg').css('display', 'block');
		                $('div .chicken').css('display', 'block');
		            }
		        }
		    });
		}

		function BMI() {

		    // ****************      Calculated BMI             **************

		    var Height = document.getElementById('<%=txtHeight.ClientID %>').value;
		    var weight = document.getElementById('<%=txtWeight.ClientID %>').value;

		    var HeightBaseUnit = document.getElementById('<%=ddlHeightUnit.ClientID %>').value;
		    var WeightBaseUnit = document.getElementById('<%=ddlWeightUnit.ClientID %>').value;

		    var sex = document.getElementById('<%=ddlGender.ClientID %>').value;


		    if (weight == '') {
		        //  alert('Please enter weight for BMI calculations');

		    }
		    else if (Height == '') {
		        //  alert('Please enter Height for BMI calculations');
		    }

		    else {

		        Height = ConvertToMeters(Height, HeightBaseUnit); // Convert height from baseUnit to meter
		        weight = ConvertToKgs(weight, WeightBaseUnit);

		        var BMI = (weight / (Height * Height)).toFixed(2); //Roundoff to two decimals
			 <%--   document.getElementById('<%=txtBMI.ClientID %>').disabled = false;--%>
			    document.getElementById('<%=txtBMI.ClientID %>').value = BMI;
<%--                document.getElementById('<%=txtBMI.ClientID %>').disabled = true;--%>
			    if (BMI <= 15) {
			        document.getElementById('<%=txtBMICategory.ClientID %>').value = "Very severely underweight";
				}
				else if (BMI > 15 && BMI <= 16) {
				    document.getElementById('<%=txtBMICategory.ClientID %>').value = "Severely underweight";
				}
				else if (BMI > 16 && BMI <= 18.5) {
				    document.getElementById('<%=txtBMICategory.ClientID %>').value = "Underweight";
				}
				else if (BMI > 18.5 && BMI <= 25) {
				    document.getElementById('<%=txtBMICategory.ClientID %>').value = "Normal (Healthy weight)";
				}
				else if (BMI > 25 && BMI <= 30) {
				    document.getElementById('<%=txtBMICategory.ClientID %>').value = "Overweight";
				}
				else if (BMI > 30 && BMI <= 35) {
				    document.getElementById('<%=txtBMICategory.ClientID %>').value = "Obese Class I (Moderately obese)";
				}
				else if (BMI > 35 && BMI <= 40) {
				    document.getElementById('<%=txtBMICategory.ClientID %>').value = "Obese Class II (Severely obese)";
				}
				else if (BMI > 40) {
				    document.getElementById('<%=txtBMICategory.ClientID %>').value = "Obese Class III (Very severely obese)";
				}

			    //IBW();
}

}
/*
  HAMWI formula for IBW for individuals over 5 feet tall:

  Men: 106 + 6 lb for every inch over 60 in
  For height less than 5 feet we need to minus.
  Women: 100 + 5 lb for every inch over 60 in

  Add 10% if person has large frame, subtract 10% if person has small frame. If frame size is unavailable, assume medium.

  Example HAMWI calculation:
  Male: 
  Height=70", large frame 
  106 + (6 x 10) = 166 
  166 x 10% = 16.6 
  166 + 16.6 = 184

  Female: 
  Height=64", small frame
  100 + (5 x 4) = 120 
  120 x 10% = 12 
  120 - 12 = 108 lb
*/
function IBW() {

    //   alert('Called by gender');
    var gender;
    var wt;

    if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Select') {
	    // alert('Please select gender IBW.');
	}
	else if (document.getElementById('<%=txtHeight.ClientID %>').value == '') {
	    //  alert('Please enter Height IBW'); 
	}
	else {
	    if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Male') {

	        gender = 'Male';
	        // alert(gender);
	    }
	    else if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Female') {
		    gender = 'Female';
		    // alert(gender);
		}

        var mainhight = document.getElementById('<%=txtHeight.ClientID %>').value;
	    var HeightBaseUnit = document.getElementById('<%=ddlHeightUnit.ClientID %>').value;

	    mainhight = ConvertToInches(mainhight, HeightBaseUnit);

	    var Diff = mainhight - 60;
	    //  alert(Diff);
	    if (gender == "Male") {
	        wt = (106 + (6 * Diff));
	        //   alert(wt);
	    }
	    else if (gender == "Female") {
	        wt = (100 + (5 * Diff));
	        //  alert(wt);
	    }
	    //document.getElementById('<%=txtIdealWeight.ClientID %>').disabled = false;
	    if (document.getElementById('<%=txtBodyFrame.ClientID %>').value == "small") {
	        wt = wt - (wt / 10);
	        document.getElementById('<%=txtIdealWeight.ClientID %>').value = wt.toFixed(2);
        }
        else if (document.getElementById('<%=txtBodyFrame.ClientID %>').value == "medium" || document.getElementById('<%=txtBodyFrame.ClientID %>').value == "unavailable") {
		    wt = wt;
		    document.getElementById('<%=txtIdealWeight.ClientID %>').value = wt.toFixed(2);
        }
        else if (document.getElementById('<%=txtBodyFrame.ClientID %>').value == "large") {
		    wt = wt + (wt / 10);
		    document.getElementById('<%=txtIdealWeight.ClientID %>').value = wt.toFixed(2);
        }
	    //document.getElementById('<%=txtIdealWeight.ClientID %>').disabled = false;
	    var wt_Kg = ConvertToKgs(wt, 'LBS');

	    document.getElementById('<%=txtIdealWeight.ClientID %>').value = wt_Kg.toFixed(2);
	    //if IBW is less than zero
		if (wt_Kg < 0)
		    $("#lblIdlBdyWghtMsg").removeClass("hidden");
		else
		    $("#lblIdlBdyWghtMsg").addClass("hidden");
	    //document.getElementById('<%=txtIdealWeight.ClientID %>').disabled = true;
	}


}
        /*
		 Body Frame calculation
		
		 Women:
		
		 Height under 5'2"
		 Small = wrist size less than 5.5"
		 Medium = wrist size 5.5" to 5.75"
		 Large = wrist size over 5.75"
		
		 Height 5'2" to 5' 5"
		 Small = wrist size less than 6"
		 Medium = wrist size 6" to 6.25"
		 Large = wrist size over 6.25"
		
		 Height over 5' 5"
		 Small = wrist size less than 6.25"
		 Medium = wrist size 6.25" to 6.5"
		 Large = wrist size over 6.5"
		
		
		 Men:
		
		 Height over 5' 5"
		 Small = wrist size 5.5" to 6.5"
		 Medium = wrist size 6.5" to 7.5"
		 Large = wrist size over 7.5"
		
		*/
        function BodyFrame() {

            debugger;
            var bodyFrame = "unavailable";

            var Height = document.getElementById('<%=txtHeight.ClientID %>').value;
			var Wrist = document.getElementById('<%=txtwrist.ClientID %>').value;

		    var HeightBaseUnit = document.getElementById('<%=ddlHeightUnit.ClientID %>').value;
		    var WristBaseUnit = document.getElementById('<%=ddlWristUnit.ClientID %>').value;

		    Height = ConvertToFoots(Height, HeightBaseUnit);
		    Wrist = ConvertToInches(Wrist, WristBaseUnit);

		    if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Female') {

			    // Height under 5'2"
			    if (Height < 5.2 && Height > 0) {
			        // Small = wrist size less than 5.5"
			        if (Wrist < 5.5 && Wrist > 0) {
			            bodyFrame = "small";
			        }
			            // Medium = wrist size 5.5" to 5.75"
			        else if (Wrist >= 5.5 && Wrist <= 5.75) {
			            bodyFrame = "medium";
			        }
			            // Large = wrist size over 5.75"
			        else if (Wrist > 5.75) {
			            bodyFrame = "large";
			        }
			    }
			        // Height 5'2" to 5' 5"
			    else if (Height >= 5.2 && Height <= 5.5) {
			        // Small = wrist size less than 6"
			        if (Wrist < 6 && Wrist > 0) {
			            bodyFrame = "small";
			        }
			            // Medium = wrist size 6" to 6.25"
			        else if (Wrist >= 6 && Wrist <= 6.25) {
			            bodyFrame = "medium";
			        }
			            // Large = wrist size over 6.25"
			        else if (Wrist > 6.25) {
			            bodyFrame = "large";
			        }

			    }
			        // Height over 5' 5"
			    else if (Height > 5.5) {
			        // Small = wrist size less than 6.25"
			        if (Wrist < 6.25 && Wrist > 0) {
			            bodyFrame = "small";
			        }
			            // Medium = wrist size 6.25" to 6.5"
			        else if (Wrist >= 6.25 && Wrist <= 6.5) {
			            bodyFrame = "medium";
			        }
			            // Large = wrist size over 6.5"
			        else if (Wrist > 6.5) {
			            bodyFrame = "large";
			        }
			    }

			}
			else if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Male') {
			    // Height over 5' 5"
			    if (Height >= 5.5) {
			        // Small = wrist size 5.5" to 6.5"
			        if (Wrist >= 5.5 && Wrist < 6.5) {
			            bodyFrame = "small";
			        }
			            // Medium = wrist size 6.5" to 7.5"
			        else if (Wrist >= 6.5 && Wrist <= 7.5) {
			            bodyFrame = "medium";
			        }
			            // Large = wrist size over 7.5"
			        else if (Wrist > 7.5) {
			            bodyFrame = "large";
			        }

			    }
			}
		    //document.getElementById('<%=txtBodyFrame.ClientID %>').disabled = false;
		    document.getElementById('<%=txtBodyFrame.ClientID %>').value = bodyFrame;
		    //document.getElementById('<%=txtBodyFrame.ClientID %>').disabled = true;

		}
        function CalculateAge() {

            var birthDay = document.getElementById('<%=txtDOB.ClientID %>').value;

		    var dateParts = birthDay.split("/");

		    var DOB = new Date(dateParts[2], dateParts[1] - 1, dateParts[0]);

		    var today = new Date();
		    var age = today.getTime() - DOB.getTime();
		    age = Math.floor(age / (1000 * 60 * 60 * 24 * 365.25));
		    if (age != "NaN") {
		        document.getElementById('<%=txtAge.ClientID %>').value = age;
			    if (age < 18)
			        $('div .child').css('display', 'block');
			    else
			        $('div .child').css('display', 'none');
			    SetTabs();
			}
        }


        //        BMR CALCULATION
        //        Women: BMR = 655 + ( 9.6 x weight in kilos ) + ( 1.8 x height in cm ) - ( 4.7 x age in years )
        //        Men: BMR = 66 + ( 13.7 x weight in kilos ) + ( 5 x height in cm ) - ( 6.8 x age in years )

        /*
					1. If you are sedentary (little or no exercise) : Calorie-Calculation = BMR x 1.2
					2. If you are lightly active (light exercise/sports 1-3 days/week) : Calorie-Calculation = BMR x 1.375
					3. If you are moderatetely active (moderate exercise/sports 3-5 days/week) : Calorie-Calculation = BMR x 1.55
					4. If you are very active (hard exercise/sports 6-7 days a week) : Calorie-Calculation = BMR x 1.725
					5. If you are extra active (very hard exercise/sports & physical job or 2x training) : Calorie-Calculation = BMR x 1.9        
		
		*/

        function BMR() {
            debugger;
            var BMR = 0;
            var CALORIE = 0;
            var activity = 0;
            var gender = "unavailable";
            var Height = document.getElementById('<%=txtHeight.ClientID %>').value;
			var weight = document.getElementById('<%=txtWeight.ClientID %>').value;

		    var HeightBaseUnit = document.getElementById('<%=ddlHeightUnit.ClientID %>').value;
		    var WeightBaseUnit = document.getElementById('<%=ddlWeightUnit.ClientID %>').value;
		    var act = document.getElementById('<%=ddlActivity.ClientID %>').value.toUpperCase();

		    Height = ConvertToCms(Height, HeightBaseUnit); // Convert height from baseUnit to CM
		    weight = ConvertToKgs(weight, WeightBaseUnit);

		    if (act == 'SEDENTARY(LITTLE OR NO EXERCISE)')
		        activity = 1.2;
		    else if (act == 'LIGHTLY ACTIVE (LIGHT EXERCISE/ SPORTS 1-3 DAYS/WEEK)')
		        activity = 1.375;
		    else if (act == 'MODERATELY ACTIVE (MODERATE EXERCISE/SPORTS 3-5 DAYS A WEEK)')
		        activity = 1.55;
		    else if (act == 'VERY ACTIVE (HARD EXERCISE/SPORTS 3-5 DAYS/ WEEK)')
		        activity = 1.725;
		    else if (act == 'EXTRA ACTIVE (VERY HARD EXERCISE/SPORTS & PHYSICAL JOB OR 2X TRAINING)')
		        activity = 1.9;
		    else
		        activity = 0;

		    if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Select') {
			    // alert('Please select gender IBW.');
			}
			else if (document.getElementById('<%=txtHeight.ClientID %>').value == '') {
			    //  alert('Please enter Height IBW'); 
			}
			else {
			    if (weight == '' || Height == '' || document.getElementById('<%=txtAge.ClientID %>').value == '') {
			        //alert
			    }
			    else {
			        if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Male') {
				        BMR = (66 + (13.7 * weight) + (5 * Height) - (6.8 * document.getElementById('<%=txtAge.ClientID %>').value)).toFixed(2);
					    CALORIE = (BMR * activity).toFixed(2);
					    CalorieCal();
					    CalorieCal1();
					}
					else if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Female') {
					    BMR = (655 + (9.6 * weight) + (1.8 * Height) - (4.7 * document.getElementById('<%=txtAge.ClientID %>').value)).toFixed(2);
					    CALORIE = (BMR * activity).toFixed(2);
					    CalorieCal();
					    CalorieCal1();
					}
            }
        }
    document.getElementById('<%=txtBMR.ClientID %>').value = BMR;
		    <%--if (document.getElementById('<%=txtFatPer.ClientID %>').value == '' || document.getElementById('<%=txtFatPer.ClientID %>').value == '0.00')
		        document.getElementById('<%=txtFatPer.ClientID %>').value = BMR;--%>
            document.getElementById('<%=txtCalorie.ClientID %>').value = CALORIE;
		    document.getElementById('<%=txtCalorie1.ClientID %>').value = CALORIE;
		    if (document.getElementById('<%=txtCalorie2.ClientID %>').value == '')
		        document.getElementById('<%=txtCalorie2.ClientID %>').value = CALORIE;
        }

        //Calcualte calorie consumption
        /*
		
		Carbhohydrates	%  Of Calories	Kcal=	daily calories x percent protein / 4 calories per gram = grams protein
			
		Fat	%  Of Calories		=daily calories x percent fat / 9 calories per gram = grams fat
				
		Protein 	%  Of Calories	=	daily calories x percent carbs / 4 calories per gram = grams carbs

		*/
        function CalorieCal() {
            var CALORIE = document.getElementById('<%=txtCalorie.ClientID %>').value;
		    if (CALORIE != 0 && document.getElementById('<%=txtCarbhohydratesPercent.ClientID %>').value != "") {
		        $('#lblCarbo').text((CALORIE * (document.getElementById('<%=txtCarbhohydratesPercent.ClientID %>').value / 100) / 9).toFixed(2));
			}
			else {
			    $('#lblCarbo').text('0');
			}
            if (CALORIE != 0 && document.getElementById('<%=txtFatPercent.ClientID %>').value != "")
		        $('#lblFat').text((CALORIE * (document.getElementById('<%=txtFatPercent.ClientID %>').value / 100) / 9).toFixed(2));
			else
			    $('#lblFat').text('0');

            if (CALORIE != 0 && document.getElementById('<%=txtProteinPercent.ClientID %>').value != "") {
		        $('#lblProtein').text((CALORIE * (document.getElementById('<%=txtProteinPercent.ClientID %>').value / 100) / 4).toFixed(2));

			}
			else
			    $('#lblProtein').text('0');
        }

        function CalorieCal1() {
            var CALORIE = document.getElementById('<%=txtCalorie2.ClientID %>').value;
		    if (CALORIE != 0 && document.getElementById('<%=txtCarbhohydratesPercent1.ClientID %>').value != "") {
		        $('#lblCarbo1').text((CALORIE * (document.getElementById('<%=txtCarbhohydratesPercent1.ClientID %>').value / 100) / 9).toFixed(2));
			}
			else {
			    $('#lblCarbo1').text('0');
			}
            if (CALORIE != 0 && document.getElementById('<%=txtFatPercent1.ClientID %>').value != "")
		        $('#lblFat1').text((CALORIE * (document.getElementById('<%=txtFatPercent1.ClientID %>').value / 100) / 9).toFixed(2));
			else
			    $('#lblFat1').text('0');

            if (CALORIE != 0 && document.getElementById('<%=txtProteinPercent1.ClientID %>').value != "") {
		        $('#lblProtein1').text((CALORIE * (document.getElementById('<%=txtProteinPercent1.ClientID %>').value / 100) / 4).toFixed(2));
			    document.getElementById('<%=hdnProtein.ClientID %>').value = (CALORIE * (document.getElementById('<%=txtProteinPercent1.ClientID %>').value / 100) / 4).toFixed(2);
			}
			else
			    $('#lblProtein1').text('0');
        }


        function CalculatePercent() {
            var txtFirstNumberValue = document.getElementById('<%=txtProteinPercent1.ClientID %>').value;
		    var txtSecondNumberValue = document.getElementById('<%=txtFatPercent1.ClientID %>').value;
		    if (!isNaN(txtFirstNumberValue) && !isNaN(txtSecondNumberValue)) {
		        var result = parseInt(txtFirstNumberValue) + parseInt(txtSecondNumberValue);
		        if (result < 100) {
		            document.getElementById('<%=txtCarbhohydratesPercent1.ClientID %>').value = 100 - parseFloat(result);
				}
				else if (result = 100) {
				    document.getElementById('<%=txtCarbhohydratesPercent1.ClientID %>').value = 0;
				}
				else {
				    alert("Sum of the Protein and Carb % should be less than or equal to 100")
				}

        }
    }

    </script>
    <style>
        /*#tabs {
			font-size: 14px;
		}*/

        .ui-widget-header {
            bacKground: #b9cd6d;
            border: 1px solid #b9cd6d;
            color: #FFFFFF;
            font-weight: bold;
        }

        .control-block {
            padding-bottom: 20px;
        }

        .err-block {
            position: absolute;
            top: 0px;
            right: 0;
        }

        .err-bottom {
            top: auto;
            bottom: 0;
            left: 13px;
            white-space: nowrap;
        }

        .margin-left-1 {
            margin-left: -1px;
        }

        .patient-detailsl-tabs .input-group-addon {
            padding: 0;
            width: 60px;
        }

        .patient-detailsl-tabs .form-control-select {
            border: 0;
            background: #eee;
        }

        .patient-detailsl-tabs .input-group-addon span {
            padding: 0 5px;
        }

        .patient-detailsl-tabs .form-group {
            padding: 0;
        }

        #tabs-2 .form-group.col-md-4 {
            height: 45px;
        }

        #tabs-6 .form-group label {
            height: 40px;
        }

        .buttons-row .btn {
            margin: 5px;
        }

        .cur {
            cursor: pointer;
        }

        .clr {
            background-color: #4353b9 !important;
        }

        .display {
            display: none;
        }
    </style>
    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="TabName" runat="server" />

            <%-- <div class="page-header">--%>
            <div id="tabs" class="patient-detailsl-tabs">
                <div class="patient-detailsl-tabs-block" style="overflow: auto;">
                    <ul class="nav nav-tabs" style="width: 90%;">
                        <li class="active"><a href="#tabs-1" data-toggle="tab">Client Details</a></li>
                        <li><a href="#tabs-2" data-toggle="tab">Anthropometrics</a></li>
                        <li><a href="#tabs-3" data-toggle="tab">Biochemical Labs</a></li>
                        <li><a href="#tabs-4" data-toggle="tab">Comorbidity</a></li>
                        <li><a href="#tabs-6" data-toggle="tab">Clinical Complaints</a></li>
                        <li><a href="#tabs-5" data-toggle="tab">Diet And Lifestyle</a></li>
                        <li><a href="#tabs-7" data-toggle="tab">Recall Diet</a></li>
                        <li><a href="#tabs-8" data-toggle="tab">Recommended Diet</a></li>
                        <li><a href="#tabs-9" data-toggle="tab">Visits</a></li>
                    </ul>
                    <div class="tab-content">
                        <div id="tabs-1" class="tab-pane fade in active">
                            <div class="row">
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Client Name</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox ID="txtPatientID" CssClass="form-control" runat="server" TabIndex="1" Enabled="false" autocomplete="off" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtName" CssClass="form-control" runat="server" TabIndex="2" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Client Name Required" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Client Name" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z ]{1,40}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Middle Name</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtMiddleName" runat="server" TabIndex="3" autocomplete="off"></asp:TextBox>
                                        <%--                                    <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Client Middle Name Required" Display="Dynamic" ControlToValidate="txtMiddleName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Middle Name" Display="Dynamic" ControlToValidate="txtMiddleName" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z ]{1,40}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Last Name</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" TabIndex="4" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Client LastName  Required" Display="Dynamic" ControlToValidate="txtLastName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid txtLast Name" Display="Dynamic" ControlToValidate="txtLastName" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z ]{1,40}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Date Of Birth</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control cur" ID="txtDOB" runat="server" TabIndex="5" autocomplete="off" PlaceHolder="dd/MM/yyyy" Style="cursor: auto !important" onchange="CalculateAge();BMR();"></asp:TextBox>
                                        <%--<span style="position: absolute">
											<asp:ImageButton ID="lnkFromDate" runat="server" ImageUrl="~/Master/Images/calendar.gif" />
											<asp:CalendarExtender ID="FromDate_CalendarExtender" runat="server" Enabled="True"
												TargetControlID="txtDOB" PopupButtonID="lnkFromDate" Format="dd/MM/yyyy">
											</asp:CalendarExtender>
										</span>--%>
                                        <%--<span class="input-group-btn">
											<button class="btn btn-primary btn-date" type="button"><i class="fa fa-calendar"></i></button>
										</span>--%>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator4" runat="server" ErrorMessage="DOB Required" Display="Dynamic" ControlToValidate="txtDOB" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Client Age</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtAge" runat="server" autocomplete="off" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Age Required" Display="Dynamic" ControlToValidate="txtAge" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Gender</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:DropDownList CssClass="form-control" ID="ddlGender" runat="server" TabIndex="6" onchange="BMI();BodyFrame();IBW();BMR();">
                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                            <asp:ListItem Value="Male">Male</asp:ListItem>
                                            <asp:ListItem Value="Female">Female</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator runat="server" CssClass="err-block err-bottom" ID="ReqGender" ErrorMessage="Select Gender " Display="Dynamic" ControlToValidate="ddlGender" ValidationGroup="ValidationGroup" ForeColor="Red" InitialValue="Select"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Address Line1</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtAddress1" runat="server" TabIndex="7" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Address1 Required" Display="Dynamic" ControlToValidate="txtAddress1" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Address1 " Display="Dynamic" ControlToValidate="txtAddress1" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s\,]{1,200}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Locality</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtLocality" runat="server" TabIndex="8" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Address2 Required" Display="Dynamic" ControlToValidate="txtAddress2" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Locality " Display="Dynamic" ControlToValidate="txtLocality" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s\,]{1,200}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <%------------------                                -----------------------%>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Country</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <%-- <asp:TextBox CssClass="form-control" ID="txtCountry" runat="server" TabIndex="11" autocomplete="off"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Country_Changed" CssClass="form-control" TabIndex="9">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Select Country" Display="Dynamic" ControlToValidate="ddlCountries" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator60" runat="server" ErrorMessage="Invalid Country " Display="Dynamic" ControlToValidate="txtCountry" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s\,]{1,200}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">State</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <%-- <asp:TextBox CssClass="form-control" ID="txtState" runat="server" TabIndex="10" autocomplete="off"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlStates" runat="server" AutoPostBack="true" OnSelectedIndexChanged="State_Changed" CssClass="form-control" TabIndex="10">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator66" runat="server" ErrorMessage="Select States " Display="Dynamic" ControlToValidate="ddlStates" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator59" runat="server" ErrorMessage="Invalid State " Display="Dynamic" ControlToValidate="txtState" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s\,]{1,200}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">City</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block ">
                                        <%--<asp:TextBox CssClass="form-control" ID="txtCity" runat="server" TabIndex="9" autocomplete="off"></asp:TextBox> --%>
                                        <asp:DropDownList ID="ddlCities" runat="server" CssClass="form-control" TabIndex="11">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Select Cities " Display="Dynamic" ControlToValidate="ddlCities" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator58" runat="server" ErrorMessage="Invalid City " Display="Dynamic" ControlToValidate="txtCity" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s\,]{1,200}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Pin Code</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtPin" runat="server" TabIndex="12" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Address2 Required" Display="Dynamic" ControlToValidate="txtAddress2" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Pincode Reuored" Display="Dynamic" ControlToValidate="txtPin" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator61" runat="server" ErrorMessage="Invalid Pin " Display="Dynamic" ControlToValidate="txtPin" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[0-9]{6,6}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Email</label>
                                    <div class="col-sm-8 control-block ">
                                        <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" TabIndex="13" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Email Required" Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator6" runat="server" ErrorMessage="Invalid Email " Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Mobile</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8  control-block">
                                        <%--<div class="input-group">--%>
                                        <%--<div class="input-group-addon">
												<asp:Label runat="server" ID="lblMob1"></asp:Label>
											</div>--%>
                                        <%--<asp:TextBox CssClass="form-control" ID="txtMobile" runat="server" TabIndex="14" autocomplete="off"></asp:TextBox>
											<asp:RequiredFieldValidator runat="server" CssClass="err-block err-bottom" ID="RequiredFieldValidator6" ErrorMessage="Select Mobile " Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Mobile " Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                        <asp:TextBox ID="txtMobile" runat="server" TabIndex="14" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" CssClass="err-block err-bottom" ID="RequiredFieldValidator6" ErrorMessage="Select Mobile " Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="custMobileNumber" runat="server" CssClass="err-block err-bottom" ErrorMessage="Invalid Mobile" Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red" ClientValidationFunction="ValidateMobileOnSubmit" OnServerValidate="MobileNumberValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Landline</label>
                                    <div class="col-sm-8  control-block">
                                        <%--<asp:TextBox CssClass="form-control" ID="txtLandline" runat="server" TabIndex="15" autocomplete="off"></asp:TextBox>
											<%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Contact Required" Display="Dynamic" ControlToValidate="txtContact" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
											<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator62" runat="server" ErrorMessage="Invalid Landline " Display="Dynamic" ControlToValidate="txtLandline" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                        <asp:TextBox CssClass="form-control" ID="txtLandline" runat="server" TabIndex="15" autocomplete="off"></asp:TextBox>
                                        <asp:CustomValidator ID="custLandlineNumber" runat="server" CssClass="err-block err-bottom" ErrorMessage="Invalid Landline" Display="Dynamic" ControlToValidate="txtLandline" ValidationGroup="ValidationGroup" ForeColor="Red" ClientValidationFunction="ValidateLandlineOnSubmit" OnServerValidate="LandlineNumberValidate"></asp:CustomValidator>
                                        <%--</div>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Profession</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:DropDownList CssClass="form-control" ID="ddlProfession" runat="server" TabIndex="16">
                                            <asp:ListItem>Farming</asp:ListItem>
                                            <asp:ListItem>Petty Business</asp:ListItem>
                                            <asp:ListItem>Service Professional</asp:ListItem>
                                            <asp:ListItem>Service Non-Professional</asp:ListItem>
                                            <asp:ListItem>Skilled Professional</asp:ListItem>
                                            <asp:ListItem>Unskilled Professional</asp:ListItem>
                                            <asp:ListItem>Pensioner/Retired</asp:ListItem>
                                            <asp:ListItem>Unemployed</asp:ListItem>
                                            <asp:ListItem>Housewife</asp:ListItem>
                                            <asp:ListItem>Other,Specify</asp:ListItem>
                                        </asp:DropDownList>

                                        <asp:TextBox runat="server" ID="txtProfessionOthers" CssClass="form-control profession"></asp:TextBox>
                                    </div>
                                </div>
                                <%-- <div class="form-group col-sm-6 col-md-4">
									<label class="col-sm-4 control-label text-right">Present Exercise</label>
									<div class="col-sm-8 control-block">
										<asp:TextBox CssClass="form-control" ID="txtExercise1" runat="server" TabIndex="17" autocomplete="off"></asp:TextBox>
										<%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Present Exercise Required" Display="Dynamic" ControlToValidate="txtExercise1" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator8" runat="server" ErrorMessage="Invalid Present Exercise " Display="Dynamic" ControlToValidate="txtExercise1" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>
									</div>
								</div>--%>
                                <%--<div class="form-group col-sm-6 col-md-4">
									<label class="col-sm-4 control-label text-right">Execise Activity</label>
									<div class="col-sm-8 control-block">
										<asp:TextBox CssClass="form-control" ID="txtExercise2" runat="server" TabIndex="18" autocomplete="off"></asp:TextBox>
										<%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Exercise Activity Required" Display="Dynamic" ControlToValidate="txtExercise2" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator9" runat="server" ErrorMessage="Invalid Exercise Activity " Display="Dynamic" ControlToValidate="txtExercise2" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,100}$"></asp:RegularExpressionValidator>
									</div>
								</div>--%>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes" runat="server" TextMode="MultiLine" Width="100%" TabIndex="18" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Client Details Notes Required" Display="Dynamic" ControlToValidate="txtNotes" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator10" runat="server" ErrorMessage="Invalid Client Details Notes " Display="Dynamic" ControlToValidate="txtNotes" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnClientData" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup" OnClick="btnClientData_Click" />
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-12 control-block">
                                        <asp:ValidationSummary ID="ValClient"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true" ValidationGroup="ValidationGroup" runat="server" CssClass="alert alert-danger padd" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-2" class="tab-pane fade">
                            <div class="row">
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Measured Wt</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtWeight" runat="server" TabIndex="1" autocomplete="off" onkeyup="BMI();BMR();"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlWeightUnit" runat="server" TabIndex="2" onchange="BMI();BMR()">
                                                    <asp:ListItem Value="KG">Kg</asp:ListItem>
                                                    <asp:ListItem Value="LBS">Lbs</asp:ListItem>
                                                    <asp:ListItem Value="GRAM">Gram</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Measured Weight Required" Display="Dynamic" ControlToValidate="txtWeight" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator11" runat="server" ErrorMessage="Invalid Measured  Weight " Display="Dynamic" ControlToValidate="txtWeight" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

                                    </div>
                                </div>

                                <%--<div class="form-group col-sm-6 col-md-4">
									<label class="col-sm-4 control-label text-right">Wt. Loss Month</label>

									<div class="col-sm-8  control-block">
										<div class="input-group">
											<asp:TextBox CssClass="form-control" ID="txtWeightLossMonth" runat="server" TabIndex="22" autocomplete="off"></asp:TextBox>
											<div class="input-group-addon">
												<asp:DropDownList CssClass="form-control" ID="ddlWeightUnit1" runat="server" TabIndex="23">
													<asp:ListItem>Kg</asp:ListItem>
													<asp:ListItem>Gram</asp:ListItem>
													<asp:ListItem>Lbs</asp:ListItem>
												</asp:DropDownList>
											</div>
										</div>

										<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator14" runat="server" ErrorMessage="Weight Loss Month Required" Display="Dynamic" ControlToValidate="txtWeightLossMonth" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid Weight Loss Month" Display="Dynamic" ControlToValidate="txtWeightLossMonth" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
									</div>
								</div>--%>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Measured Ht</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtHeight" runat="server" TabIndex="3" onkeyup="BMI();BodyFrame();IBW();BMR();"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlHeightUnit" runat="server" TabIndex="4" onchange="BMI();BodyFrame();IBW();BMR();">
                                                    <asp:ListItem Value="CM">Cm</asp:ListItem>
                                                    <asp:ListItem Value="INCH">Inch</asp:ListItem>
                                                    <asp:ListItem Value="FOOT">Foot</asp:ListItem>
                                                    <asp:ListItem Value="METER">Meter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator15" runat="server" ErrorMessage="Measured Height Required" Display="Dynamic" ControlToValidate="txtHeight" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator13" runat="server" ErrorMessage="Invalid Height" Display="Dynamic" ControlToValidate="txtHeight" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <%--<div class="form-group col-sm-6 col-md-4">
									<label class="col-sm-4 control-label text-right">Wt Loss Six Month</label>
									<div class="col-sm-8  control-block">
										<div class="input-group">
											<asp:TextBox CssClass="form-control" ID="txtWeightLossSixMonths" runat="server" TabIndex="7" autocomplete="off"></asp:TextBox>
											<div class="input-group-addon">
												<asp:DropDownList CssClass="form-control" ID="ddlWeightUnit2" runat="server" TabIndex="8">
													<asp:ListItem>Kg</asp:ListItem>
													<asp:ListItem>Gram</asp:ListItem>
													<asp:ListItem>Lbs</asp:ListItem>
												</asp:DropDownList>
											</div>
										</div>
									   
										<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator14" runat="server" ErrorMessage="Invalid WeightLossSixMonths" Display="Dynamic" ControlToValidate="txtWeightLossSixMonths" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
									</div>
								</div>--%>

                                <%--<div class="form-group col-sm-6 col-md-4">
									<label class="col-sm-4 control-label text-right">Wt Loss Year</label>
									<div class="col-sm-8  control-block">
										<div class="input-group">
											<asp:TextBox CssClass="form-control" ID="txtWeightLossYear" runat="server" TabIndex="11" autocomplete="off"></asp:TextBox>
											<div class="input-group-addon">
												<asp:DropDownList CssClass="form-control" ID="ddlWeightUnit4" runat="server" TabIndex="12">
													<asp:ListItem>Kg</asp:ListItem>
													<asp:ListItem>Gram</asp:ListItem>
													<asp:ListItem>Lbs</asp:ListItem>
												</asp:DropDownList>
											</div>
										</div>
										
										<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator16" runat="server" ErrorMessage="Invalid WeightLossYear" Display="Dynamic" ControlToValidate="txtWeightLossYear" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

									</div>
								</div>--%>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Calculated BMI</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtBMI" runat="server" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator19" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator17" runat="server" ErrorMessage="Invalid BMI" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>



                                <div class="form-group col-sm-6 col-md-4 display">
                                    <label class="col-sm-4 control-label text-right">BMI Percentage</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtBMIPer" runat="server" TabIndex="5" autocomplete="off"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid BMI Percentage" Display="Dynamic" ControlToValidate="txtBMIPer" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">BMI Category</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtBMICategory"></asp:TextBox>
                                        <%-- <asp:DropDownList CssClass="form-control" ID="ddlBMI" runat="server" Enabled="false">
											<asp:ListItem>--Select BMI--</asp:ListItem>
											<asp:ListItem>Underweight BMI < 18.5</asp:ListItem>
											<asp:ListItem>Normal BMI 18.5 - 22.9</asp:ListItem>
											<asp:ListItem>Overweight 23 - 24.9 </asp:ListItem>
											<asp:ListItem>Obese Class I 25 - 32.9</asp:ListItem>
											<asp:ListItem>Obese Class II 33 - 39.9</asp:ListItem>
											<asp:ListItem>Obese Class III > 40</asp:ListItem>
										</asp:DropDownList>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Fat Percentage</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtFatPer" runat="server" TabIndex="6" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label15" Text="%" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator14" runat="server" ErrorMessage="Invalid fat Percentage" Display="Dynamic" ControlToValidate="txtFatPer" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 child">
                                    <label class="col-sm-4 control-label text-right">Neck Circumference</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtNeck" runat="server" TabIndex="7" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlNeck" runat="server" TabIndex="9">
                                                    <asp:ListItem Value="CM">Cm</asp:ListItem>
                                                    <asp:ListItem Value="INCH">Inch</asp:ListItem>
                                                    <asp:ListItem Value="FOOT">Foot</asp:ListItem>
                                                    <asp:ListItem Value="METER">Meter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator20" runat="server" ErrorMessage="Neck Circumference Required" Display="Dynamic" ControlToValidate="txtNeck" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator18" runat="server" ErrorMessage="Invalid Neck Circumference" Display="Dynamic" ControlToValidate="txtNeck" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Waist Circumference</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtWaist" runat="server" TabIndex="8" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlWaistUnit" runat="server" TabIndex="9">
                                                    <asp:ListItem Value="CM">Cm</asp:ListItem>
                                                    <asp:ListItem Value="INCH">Inch</asp:ListItem>
                                                    <asp:ListItem Value="FOOT">Foot</asp:ListItem>
                                                    <asp:ListItem Value="METER">Meter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator20" runat="server" ErrorMessage="Invalid Measured Waist" Display="Dynamic" ControlToValidate="txtWaist" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Measured wrist</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtwrist" runat="server" TabIndex="10" autocomplete="off" onkeyup="BodyFrame();"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlWristUnit" runat="server" TabIndex="11" onchange="BodyFrame();">
                                                    <asp:ListItem Value="CM">Cm</asp:ListItem>
                                                    <asp:ListItem Value="INCH">Inch</asp:ListItem>
                                                    <asp:ListItem Value="FOOT">Foot</asp:ListItem>
                                                    <asp:ListItem Value="METER">Meter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator78" runat="server" ErrorMessage="Invalid Measured wrist" Display="Dynamic" ControlToValidate="txtwrist" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">MUAC</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtMUAC" runat="server" TabIndex="12" autocomplete="off" ToolTip="Middle Upper Arm Circumference"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlMUAC" runat="server" TabIndex="13">
                                                    <asp:ListItem Value="CM">Cm</asp:ListItem>
                                                    <asp:ListItem Value="INCH">Inch</asp:ListItem>
                                                    <asp:ListItem Value="FOOT">Foot</asp:ListItem>
                                                    <asp:ListItem Value="METER">Meter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator21" runat="server" ErrorMessage="MUAC Required" Display="Dynamic" ControlToValidate="txtMUAC" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator19" runat="server" ErrorMessage="Invalid MUAC" Display="Dynamic" ControlToValidate="txtMUAC" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4 display">
                                    <label class="col-sm-4 control-label text-right">Blood Pressure </label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtBloodPressure" runat="server" TabIndex="14" autocomplete="off" PlaceHolder="NN/NN"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label14" Text="mmHg" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator23" runat="server" ErrorMessage="Blood Pressure Required" Display="Dynamic" ControlToValidate="txtBloodPressure" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator21" runat="server" ErrorMessage="Invalid BloodPressure" Display="Dynamic" ControlToValidate="txtBloodPressure" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d{1,3}\/\d{1,3}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Body Frame</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtBodyFrame" runat="server" autocomplete="off" onchange="IBW();"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="MUAC Required" Display="Dynamic" ControlToValidate="txtMUAC" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator16" runat="server" ErrorMessage="Invalid BodyFrame" Display="Dynamic" ControlToValidate="txtBodyFrame" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Ideal Body Wt</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtIdealWeight" runat="server" autocomplete="off"></asp:TextBox>
                                            <span class="hidden" style="color: red; display: inline; top: 35px; bottom: 0; left: 0; right: 0; position: absolute;" id="lblIdlBdyWghtMsg">Please check Height/Weight Values</span>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label8" Text="KG" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--    <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator17" runat="server" ErrorMessage="Ideal Body Weight Required" Display="Dynamic" ControlToValidate="txtIdealWeight" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator15" runat="server" ErrorMessage="Invalid Ideal Weight" Display="Dynamic" ControlToValidate="txtIdealWeight" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Muscle Mass</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtMuscleMass" runat="server" TabIndex="15" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label23" Text="KG" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator10" runat="server" ErrorMessage="Invalid Muscle Mass" Display="Dynamic" ControlToValidate="txtMuscleMass" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Bone Mass</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtBoneMass" runat="server" TabIndex="16" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label24" Text="KG" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator15" runat="server" ErrorMessage="Invalid Bone Mass" Display="Dynamic" ControlToValidate="txtBoneMass" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Body Water</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtBodyWater" runat="server" TabIndex="17" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label25" Text="%" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator16" runat="server" ErrorMessage="Invalid Body Water" Display="Dynamic" ControlToValidate="txtBodyWater" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Visceral Fat</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtVisceralFat" runat="server" TabIndex="18" autocomplete="off"></asp:TextBox>
                                        </div>
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator17" runat="server" ErrorMessage="Invalid Visceral Fat" Display="Dynamic" ControlToValidate="txtVisceralFat" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Wt. Gain/Loss Month</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtWeightGainLossMonth" runat="server" TabIndex="19" autocomplete="off" ToolTip="+ for Gain and - for Loss"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlWeightUnit5" runat="server" TabIndex="20">
                                                    <asp:ListItem Value="KG">Kg</asp:ListItem>
                                                    <asp:ListItem Value="LBS">Lbs</asp:ListItem>
                                                    <asp:ListItem Value="GRAM">Gram</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator24" runat="server" ErrorMessage="Weight Gain Month Required" Display="Dynamic" ControlToValidate="txtWeightGainMonth" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator22" runat="server" ErrorMessage="Invalid WeightGainMonth" Display="Dynamic" ControlToValidate="txtWeightGainLossMonth" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^([+-]{1,1})\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Wt Gain/Loss Six Month</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtWeightGainLossSixMonth" runat="server" TabIndex="21" autocomplete="off" ToolTip="+ for Gain and - for Loss"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlWeightUnit6" runat="server" TabIndex="22">
                                                    <asp:ListItem Value="KG">Kg</asp:ListItem>
                                                    <asp:ListItem Value="LBS">Lbs</asp:ListItem>
                                                    <asp:ListItem Value="GRAM">Gram</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator25" runat="server" ErrorMessage="Weight Gain Six Month Required" Display="Dynamic" ControlToValidate="txtWeightGainSixMonth" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator23" runat="server" ErrorMessage="Invalid WeightGainSixMonth" Display="Dynamic" ControlToValidate="txtWeightGainLossSixMonth" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^([+-]{1,1})\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Wt Gain/Loss Year</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtweightGainLossYear" runat="server" TabIndex="23" autocomplete="off" ToolTip="+ for Gain and - for Loss"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlWeightUnit7" runat="server" TabIndex="24">
                                                    <asp:ListItem Value="KG">Kg</asp:ListItem>
                                                    <asp:ListItem Value="LBS">Lbs</asp:ListItem>
                                                    <asp:ListItem Value="GRAM">Gram</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator26" runat="server" ErrorMessage="Weight Gain year Required" Display="Dynamic" ControlToValidate="txtweightGainYear" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator24" runat="server" ErrorMessage="Invalid weightGainYear" Display="Dynamic" ControlToValidate="txtweightGainLossYear" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^([+-]{1,1})\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-2 control-label text-right">Reason for WT gain / loss</label>
                                    <div class="col-sm-10  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtReason" runat="server" TextMode="MultiLine" Width="100%" TabIndex="25" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator27" runat="server" ErrorMessage="Antropometrics Notes Required" Display="Dynamic" ControlToValidate="txtNotes2" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%-- <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator63" runat="server" ErrorMessage="Invalid Reason" Display="Dynamic" ControlToValidate="txtReason" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes2" runat="server" TextMode="MultiLine" Width="100%" TabIndex="26" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator27" runat="server" ErrorMessage="Antropometrics Notes Required" Display="Dynamic" ControlToValidate="txtNotes2" ValidationGroup="validationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator25" runat="server" ErrorMessage="Invalid Antropometrics Notes" Display="Dynamic" ControlToValidate="txtNotes2" ValidationGroup="validationGroup1" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnAnthro" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="validationGroup1" OnClick="btnAnthro_Click" />
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-12 control-block">
                                        <asp:ValidationSummary ID="ValAntro"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true" ValidationGroup="validationGroup1" runat="server" CssClass="alert alert-danger padd" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-3" class="tab-pane fade">
                            <div class="row">

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Test Date</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control cur" ID="txtTestDate" runat="server" TabIndex="1" autocomplete="off" PlaceHolder="dd/MM/yyyy" Style="cursor: auto !important"></asp:TextBox>
                                        <%--<span style="position: absolute">
											<asp:ImageButton ID="lnkFromDate" runat="server" ImageUrl="~/Master/Images/calendar.gif" />
											<asp:CalendarExtender ID="FromDate_CalendarExtender" runat="server" Enabled="True"
												TargetControlID="txtDOB" PopupButtonID="lnkFromDate" Format="dd/MM/yyyy">
											</asp:CalendarExtender>
										</span>--%>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Test Date Required" Display="Dynamic" ControlToValidate="txtTestDate" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Fasting Glucose</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtGlucose" runat="server" TabIndex="2" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label1" Text="mg/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator28" runat="server" ErrorMessage="Fasting Glucose Required" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator26" runat="server" ErrorMessage="Invalid Fasting Glucose" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">PP</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtPP" runat="server" TabIndex="3" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label16" Text="mg/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator28" runat="server" ErrorMessage="Fasting Glucose Required" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator65" runat="server" ErrorMessage="Invalid PP" Display="Dynamic" ControlToValidate="txtPP" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">HB</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtHB" runat="server" TabIndex="4" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label17" Text="g/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator28" runat="server" ErrorMessage="Fasting Glucose Required" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator66" runat="server" ErrorMessage="Invalid HB" Display="Dynamic" ControlToValidate="txtHB" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Creatinine</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtCreatinine" runat="server" TabIndex="5" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label3" Text="g/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator30" runat="server" ErrorMessage="Creatinine  Required" Display="Dynamic" ControlToValidate="txtCreatinine" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator28" runat="server" ErrorMessage="Invalid Creatinine" Display="Dynamic" ControlToValidate="txtCreatinine" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Albumin</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtAlbumin" runat="server" TabIndex="6" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label5" Text="g/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator32" runat="server" ErrorMessage="Albumin  Required" Display="Dynamic" ControlToValidate="txtAlbumin" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator30" runat="server" ErrorMessage="Invalid Albumin" Display="Dynamic" ControlToValidate="txtAlbumin" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">HbA1C</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">

                                            <asp:TextBox CssClass="form-control" ID="txtHba1c" runat="server" TabIndex="7" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label7" Text="%" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator34" runat="server" ErrorMessage="Hba1c  Required" Display="Dynamic" ControlToValidate="txtHba1c" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator32" runat="server" ErrorMessage="Invalid Hba1c" Display="Dynamic" ControlToValidate="txtHba1c" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">AltSGPT</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtAltsgpt" runat="server" TabIndex="8" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label9" Text="IU/L" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator36" runat="server" ErrorMessage="Altsgpt  Required" Display="Dynamic" ControlToValidate="txtAltsgpt" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator34" runat="server" ErrorMessage="Invalid Altsgpt" Display="Dynamic" ControlToValidate="txtAltsgpt" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">AltSGOT</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtAltsgot" runat="server" TabIndex="9" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label10" Text="IU/L" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator38" runat="server" ErrorMessage="Altsgot  Required" Display="Dynamic" ControlToValidate="txtAltsgot" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator36" runat="server" ErrorMessage="Invalid Altsgot" Display="Dynamic" ControlToValidate="txtAltsgot" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Hematocrit</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtHematocrit" runat="server" TabIndex="10" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label11" Text="%" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator39" runat="server" ErrorMessage="Hematocrit  Required" Display="Dynamic" ControlToValidate="txtHematocrit" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator37" runat="server" ErrorMessage="Invalid Hematocrit" Display="Dynamic" ControlToValidate="txtHematocrit" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Triglycerides</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtTriglycerides" runat="server" TabIndex="11" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label12" Text="mg/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator40" runat="server" ErrorMessage="Triglycerides  Required" Display="Dynamic" ControlToValidate="txtTriglycerides" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator38" runat="server" ErrorMessage="Invalid Triglycerides" Display="Dynamic" ControlToValidate="txtTriglycerides" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">TSH</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtTsh" runat="server" TabIndex="12" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label18" Text="U/ml" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator67" runat="server" ErrorMessage="Invalid TSH" Display="Dynamic" ControlToValidate="txtTsh" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">HDL</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtHdl" runat="server" TabIndex="13" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label13" Text="mg/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator39" runat="server" ErrorMessage="Invalid Hdl" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">LDL</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtLDL" runat="server" TabIndex="14" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label19" Text="mg/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator68" runat="server" ErrorMessage="Invalid LDL" Display="Dynamic" ControlToValidate="txtLDL" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Uric Acid</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtUricAcid" runat="server" TabIndex="15" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label20" Text="mg/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator69" runat="server" ErrorMessage="Invalid UricAcid" Display="Dynamic" ControlToValidate="txtUricAcid" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Total Cholesterol</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtCholesterol" runat="server" TabIndex="16" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label2" Text="mg/dL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator29" runat="server" ErrorMessage="Cholesterol  Required" Display="Dynamic" ControlToValidate="txtCholesterol" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator27" runat="server" ErrorMessage="Invalid Cholesterol" Display="Dynamic" ControlToValidate="txtCholesterol" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Alkaline Phosphatase</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtAlkaline" runat="server" TabIndex="17" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">

                                                <asp:Label ID="Label4" Text="IU/L" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator31" runat="server" ErrorMessage="Alkaline  Required" Display="Dynamic" ControlToValidate="txtAlkaline" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator29" runat="server" ErrorMessage="Invalid Alkaline" Display="Dynamic" ControlToValidate="txtAlkaline" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">VitaminD3</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtVitamind3" runat="server" TabIndex="18" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label6" Text="ng/dl" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator33" runat="server" ErrorMessage="Vitamind3  Required" Display="Dynamic" ControlToValidate="txtVitamind3" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator31" runat="server" ErrorMessage="Invalid Vitamind3" Display="Dynamic" ControlToValidate="txtVitamind3" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">VitaminB12</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtVitaminb12" runat="server" TabIndex="19" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator33" runat="server" ErrorMessage="Invalid Vitaminb12" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label21" Text="ng/L" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Random BSL</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtRandomBsl" runat="server" TabIndex="20" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator70" runat="server" ErrorMessage="Invalid Random Bsl" Display="Dynamic" ControlToValidate="txtRandomBsl" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label22" Text="mg/dl" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">RBC</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtRbc" runat="server" TabIndex="21" autocomplete="off" placeholder="Normal"></asp:TextBox>

                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator71" runat="server" ErrorMessage="Invalid Rbc" Display="Dynamic" ControlToValidate="txtRbc" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Platelet Count</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtPlatelet" runat="server" TabIndex="22" autocomplete="off" placeholder="Normal"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator72" runat="server" ErrorMessage="Invalid Platelet Count" Display="Dynamic" ControlToValidate="txtPlatelet" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-8">
                                    <label class="col-sm-2 control-label text-right">Others</label>
                                    <div class="col-sm-10 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtOthers" runat="server" TabIndex="23" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator37" runat="server" ErrorMessage="Others  Required" Display="Dynamic" ControlToValidate="txtOthers" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator35" runat="server" ErrorMessage="Invalid Others" Display="Dynamic" ControlToValidate="txtOthers" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes3" runat="server" TextMode="MultiLine" Width="100%" TabIndex="24" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator42" runat="server" ErrorMessage="Biochemical Notes  Required" Display="Dynamic" ControlToValidate="txtNotes3" ValidationGroup="validationGroup2" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%-- <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator40" runat="server" ErrorMessage="Invalid Biochemical Notes" Display="Dynamic" ControlToValidate="txtNotes3" ValidationGroup="validationGroup2" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnBio" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="validationGroup2" OnClick="btnBio_Click" />
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-12 control-block">
                                        <asp:ValidationSummary ID="ValBio"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true" ValidationGroup="validationGroup2" runat="server" CssClass="alert alert-danger padd" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-4" class="tab-pane fade">
                            <div class="row">
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">CHF</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlChf" TabIndex="1">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Asthma</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlAsthma" TabIndex="2">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Sleep Apnea </label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlSleepApnea" TabIndex="3">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Thyroid</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlThyroid" TabIndex="4">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4 NoThyroid">
                                    <label class="col-sm-4 control-label text-right ">Thyroid Type</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlThyroidType" TabIndex="5">
                                            <asp:ListItem>Hypothyroid</asp:ListItem>
                                            <asp:ListItem>Hyperthyroid</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">IHD</label>
                                    <div class="col-sm-8  control-block">

                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlIhd" TabIndex="6">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Functional Status</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlFunctionslStatus" TabIndex="7">
                                            <asp:ListItem>Can walk 200ft unassisted</asp:ListItem>
                                            <asp:ListItem>Can walk 200ft with assist device</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <legend class="col-sm-12">Chronic Diseases</legend>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Diabetes</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlDiabetes" TabIndex="8">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Liver Disorders</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlLiver" TabIndex="9">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Hypertension</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlHypertension" TabIndex="10">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Cardiac Disorders</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlCardiacDisorders" TabIndex="11">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Kidney Disorders</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlKidney" TabIndex="12">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-2 control-label text-right">Followed particular Diet Details</label>
                                    <div class="col-sm-10  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtChronicDietDetails" runat="server" TabIndex="13" autocomplete="off" TextMode="MultiLine"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-2 control-label text-right">Others -Specify</label>
                                    <div class="col-sm-10  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtChronicOthers" runat="server" TabIndex="14" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes4" runat="server" TextMode="MultiLine" Width="100%" TabIndex="15" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator43" runat="server" ErrorMessage="Comorbidity Notes  Required" Display="Dynamic" ControlToValidate="txtNotes4" ValidationGroup="validationGroup3" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%-- <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator41" runat="server" ErrorMessage="Invalid Comorbidity Notes" Display="Dynamic" ControlToValidate="txtNotes4" ValidationGroup="validationGroup3" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnComorbidity" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnComorbidity_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-6" class="tab-pane fade">
                            <div class="row">
                                <legend class="col-sm-12">Gastrointestinal Problems</legend>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Heartburn</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:HiddenField ID="hdnGPID" runat="server" />
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlHeartburn" TabIndex="1">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Vomiting</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlVomiting" TabIndex="2">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Bloating</label>
                                    <div class="col-sm-8  control-block">

                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBloating" TabIndex="3">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Use Any Luxative/Antacid</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlLuxative" TabIndex="4">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Gas</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlGas" TabIndex="5">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Constipation</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlConstipation" TabIndex="6">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Diarrhoea</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlDiarrhoea" TabIndex="7">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Follow Home Remedy</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlRemedy" TabIndex="8">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Others</label>
                                    <div class="col-sm-11 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtGastroOthers" runat="server" TabIndex="9" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator37" runat="server" ErrorMessage="Others  Required" Display="Dynamic" ControlToValidate="txtOthers" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator74" runat="server" ErrorMessage="Invalid Gastro Others" Display="Dynamic" ControlToValidate="txtGastroOthers" ValidationGroup="validationGroup5" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>



                                <legend class="col-sm-12">Medication</legend>

                                <div class="form-group col-sm-6 col-md-5">
                                    <label class="col-sm-4 control-label text-right">Vitamin Suplement</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:HiddenField ID="hdnMCID" runat="server" />
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlVitaminSuplement" TabIndex="17">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-7 vitamindiv">
                                    <label class="col-sm-4 control-label text-right">Vitamin Suplement Details</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtVitaminSuplement" TabIndex="18" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator50" runat="server" ErrorMessage="VitaminSuplement  Required" Display="Dynamic" ControlToValidate="txtVitaminSuplement" ValidationGroup="validationGroup5" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator53" runat="server" ErrorMessage="Invalid VitaminSuplement" Display="Dynamic" ControlToValidate="txtVitaminSuplement" ValidationGroup="validationGroup5" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-5">
                                    <label class="col-sm-4 control-label text-right">Mineral Suplement</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlMineralSuppliment" TabIndex="19">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-7 mineraldiv">
                                    <label class="col-sm-4 control-label text-right">Mineral Suplement Details</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtMineralSuplement" TabIndex="20" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator51" runat="server" ErrorMessage="MineralSuplement  Required" Display="Dynamic" ControlToValidate="txtMineralSuplement" ValidationGroup="validationGroup5" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator54" runat="server" ErrorMessage="Invalid MineralSuplement" Display="Dynamic" ControlToValidate="txtMineralSuplement" ValidationGroup="validationGroup5" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-5">
                                    <label class="col-sm-4 control-label text-right">Oral Drug</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlOralDetails" TabIndex="21">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-7 oraldiv">
                                    <label class="col-sm-4 control-label text-right">Oral Drug Details </label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtOralDrugDetails" runat="server" TabIndex="22" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator53" runat="server" ErrorMessage="OralDrugHypertension  Required" Display="Dynamic" ControlToValidate="txtOralDrugHypertension" ValidationGroup="validationGroup5" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator56" runat="server" ErrorMessage="Invalid Oral Drug Details" Display="Dynamic" ControlToValidate="txtOralDrugDetails" ValidationGroup="validationGroup5" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Others</label>
                                    <div class="col-sm-11  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtMedicationOthers" runat="server" Width="100%" TabIndex="23" autocomplete="off"></asp:TextBox>
                                        <%--   <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator54" runat="server" ErrorMessage="Clinical Complaints Notes  Required" Display="Dynamic" ControlToValidate="txtNotes6" ValidationGroup="validationGroup5" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator75" runat="server" ErrorMessage="Invalid Medication Others" Display="Dynamic" ControlToValidate="txtMedicationOthers" ValidationGroup="validationGroup5" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes6" runat="server" TextMode="MultiLine" Width="100%" TabIndex="24" autocomplete="off"></asp:TextBox>
                                        <%--   <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator54" runat="server" ErrorMessage="Clinical Complaints Notes  Required" Display="Dynamic" ControlToValidate="txtNotes6" ValidationGroup="validationGroup5" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%-- <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator57" runat="server" ErrorMessage="Invalid Clinical Notes" Display="Dynamic" ControlToValidate="txtNotes6" ValidationGroup="validationGroup5" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnGastro" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="validationGroup5" OnClick="btnGastro_Click" />
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-12 control-block">
                                        <asp:ValidationSummary ID="ValGastro"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true" ValidationGroup="validationGroup5" runat="server" CssClass="alert alert-danger padd" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-5" class="tab-pane fade">
                            <div class="row">
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Smoking</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlSmoking" TabIndex="1">
                                            <asp:ListItem>Never smoked</asp:ListItem>
                                            <asp:ListItem>Current Smoker</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">No Meal in Day</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtMeal" TabIndex="2" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator63" runat="server" ErrorMessage="txtMeal  Required" Display="Dynamic" ControlToValidate="txtMeal" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator44" runat="server" ErrorMessage="Invalid Typical Meal" Display="Dynamic" ControlToValidate="txtMeal" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Alcohol</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlAlcohol" TabIndex="3">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 NoAlcohol" style="display: none">
                                    <label class="col-sm-4 control-label text-right">No of Drinks</label>
                                    <div class="col-sm-8  control-block">

                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtNoOfDrinks" TabIndex="4" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator44" runat="server" ErrorMessage="Sleep hours  Required" Display="Dynamic" ControlToValidate="txtSleep" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator55" runat="server" ErrorMessage="Invalid No Of Drinks" Display="Dynamic" ControlToValidate="txtNoOfDrinks" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 NoAlcohol" style="display: none">
                                    <label class="col-sm-4 control-label text-right">Frequency</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlDrinksFrequency" TabIndex="5">
                                            <asp:ListItem>Daily</asp:ListItem>
                                            <asp:ListItem>Weekly</asp:ListItem>
                                            <asp:ListItem>Monthly</asp:ListItem>
                                            <asp:ListItem>Rarely</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 NoAlcohol" style="display: none">
                                    <label class="col-sm-4 control-label text-right">type of Drinks</label>
                                    <div class="col-sm-8  control-block">

                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtTypeOfDrinks" TabIndex="6" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator44" runat="server" ErrorMessage="Sleep hours  Required" Display="Dynamic" ControlToValidate="txtSleep" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator76" runat="server" ErrorMessage="Invalid Type Of Drinks" Display="Dynamic" ControlToValidate="txtTypeOfDrinks" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">No of Snacks in Day </label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtSnax" TabIndex="7" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator46" runat="server" ErrorMessage="Snax  Required" Display="Dynamic" ControlToValidate="txtSnax" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator45" runat="server" ErrorMessage="Invalid Typical Snax" Display="Dynamic" ControlToValidate="txtSnax" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Regular Execise</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlExercise" TabIndex="8">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 NoExercise">
                                    <label class="col-sm-4 control-label text-right">Exercise Detail</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtExerciseDetail" TabIndex="9" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator45" runat="server" ErrorMessage="ExerciseDetail  Required" Display="Dynamic" ControlToValidate="txtExerciseDetail" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator43" runat="server" ErrorMessage="Invalid ExerciseDetail" Display="Dynamic" ControlToValidate="txtExerciseDetail" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Sleep Hours Per Day</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtSleep" TabIndex="10" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator45" runat="server" ErrorMessage="ExerciseDetail  Required" Display="Dynamic" ControlToValidate="txtExerciseDetail" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator42" runat="server" ErrorMessage="Invalid Sleep Details" Display="Dynamic" ControlToValidate="txtSleep" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d{1,2}\/\d{1,2}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Calculated BMR</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtBMR" autocomplete="off" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Activity Factor</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:DropDownList CssClass="form-control" ID="ddlActivity" runat="server" TabIndex="11" onchange="BMR();">
                                            <asp:ListItem Selected="True">Sedentary(little or no exercise)</asp:ListItem>
                                            <asp:ListItem>Lightly active (Light exercise/ Sports 1-3 days/week)</asp:ListItem>
                                            <asp:ListItem>Moderately active (Moderate exercise/sports 3-5 days a week)</asp:ListItem>
                                            <asp:ListItem>Very active (hard exercise/Sports 3-5 days/ week)</asp:ListItem>
                                            <asp:ListItem>extra active (very hard exercise/sports & physical job or 2x training)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Tea / Coffee-Number of Cups per Day</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" runat="server" ID="txtNOOFTea" TabIndex="12" autocomplete="off"></asp:TextBox>
                                            <div class="input-group-addon" style="width: 50%;">
                                                <asp:DropDownList CssClass="form-control" runat="server" ID="ddlFrequencyOfTea" TabIndex="13">
                                                    <asp:ListItem>Daily</asp:ListItem>
                                                    <asp:ListItem>Weekly</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 display">
                                    <div class="col-sm-12  control-block">
                                        <table class="table table-bordered table-striped dataTable">
                                            <tbody>
                                                <tr>
                                                    <th colspan="4" style="text-align: center">Designed /Recommended Diet</th>
                                                    <th colspan="3" style="text-align: center">Output</th>
                                                </tr>
                                                <tr>
                                                    <th>Required Calorie (kcal)</th>
                                                    <th>% Protein</th>
                                                    <th>% Carb</th>
                                                    <th>% Fat</th>
                                                    <th>Protein (gm)</th>
                                                    <th>Carb (gm)</th>
                                                    <th>Fat (gm)</th>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25%">
                                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtCalorie" TabIndex="14" autocomplete="off" Enabled="false" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtProteinPercent" TabIndex="15" autocomplete="off" onchange="CalorieCal();" Width="60px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator9" runat="server" ErrorMessage="Invalid Protein" Display="Dynamic" ControlToValidate="txtProteinPercent" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtCarbhohydratesPercent" TabIndex="16" autocomplete="off" onchange="CalorieCal();" Width="60px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Carbhohydrates" Display="Dynamic" ControlToValidate="txtCarbhohydratesPercent" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 15%">
                                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFatPercent" TabIndex="17" autocomplete="off" onchange="CalorieCal();" Width="60px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator8" runat="server" ErrorMessage="Invalid Fat" Display="Dynamic" ControlToValidate="txtFatPercent" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <span id="lblProtein" style="display: table-cell; vertical-align: middle; font-weight: bold;"></span>
                                                        <asp:HiddenField ID="hdnProtein" runat="server" />
                                                    </td>
                                                    <td style="width: 10%">
                                                        <span id="lblCarbo" style="display: table-cell; vertical-align: middle; font-weight: bold;"></span>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <span id="lblFat" style="display: table-cell; vertical-align: middle; font-weight: bold;"></span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <legend class="col-sm-12">Diet History</legend>

                                <div class="form-group col-sm-6 col-md-4">
                                    <asp:HiddenField ID="hdnDHID" runat="server" />
                                    <label class="col-sm-4 control-label text-right">Diet Type</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlDietType" TabIndex="18">
                                            <asp:ListItem>Vegetarian</asp:ListItem>
                                            <asp:ListItem>Ovo-Vegetarian</asp:ListItem>
                                            <asp:ListItem>Non-Vegetarian</asp:ListItem>
                                            <asp:ListItem>Lacto-Vegetarian</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4 display">
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <label class="col-sm-4 control-label text-right">Diet  Details</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtDietDetails" TabIndex="19" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-8 nonveg">
                                    <label class="col-sm-6 control-label text-right">Types Of Nonveg</label>
                                    <div class="col-sm-6  control-block">
                                        <asp:CheckBoxList runat="server" ID="chkNonvegType" TabIndex="20" RepeatDirection="Horizontal" RepeatColumns="5">
                                            <asp:ListItem>Chicken</asp:ListItem>
                                            <asp:ListItem>Egg</asp:ListItem>
                                            <asp:ListItem>Fish</asp:ListItem>
                                            <asp:ListItem>Red Meat</asp:ListItem>
                                            <asp:ListItem>All</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4 nonveg">
                                    <label class="col-sm-4 control-label text-right">No of Times in week</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtNonvegQuantity" TabIndex="21" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 chicken">
                                    <label class="col-sm-4 control-label text-right">Chicken Details</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtChicken" TabIndex="22" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4 egg">
                                    <label class="col-sm-4 control-label text-right">Egg details</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtEgg" TabIndex="23" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4 fish">
                                    <label class="col-sm-4 control-label text-right">Fish Details</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFish" TabIndex="24" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4 meat">
                                    <label class="col-sm-4 control-label text-right">Meat Details</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtMeat" TabIndex="25" autocomplete="off"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Eat When Stress</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEatStress" TabIndex="26">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Frequency  Of Outside Eat</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlOutsideEat" TabIndex="27">
                                            <asp:ListItem>Daily</asp:ListItem>
                                            <asp:ListItem>Weekly</asp:ListItem>
                                            <asp:ListItem>Fortnightly</asp:ListItem>
                                            <asp:ListItem>Monthly</asp:ListItem>
                                            <asp:ListItem>Rarely</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Eat When Bored</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEatBored" TabIndex="28">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Eat when watching TV</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlEatWatchingTV" TabIndex="29">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Caloric Beverages</label>
                                    <div class="col-sm-8  control-block">

                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtBeverages" TabIndex="30" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator47" runat="server" ErrorMessage="Beverages  Required" Display="Dynamic" ControlToValidate="txtBeverages" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator46" runat="server" ErrorMessage="Invalid Beverages" Display="Dynamic" ControlToValidate="txtBeverages" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 display">
                                    <label class="col-sm-4 control-label text-right">Tried Wt. Loss Diet Before</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlDietBefore" TabIndex="31">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4 display">
                                    <label class="col-sm-4 control-label text-right">Wt. Loss/Gain in Sixth Month</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlLossGainSixMonth" TabIndex="32">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Do You Have Breakfast Everyday</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBreakfast" TabIndex="33">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4 gender">
                                    <label class="col-sm-4 control-label text-right">Are you Pregnant?</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlPregnant" TabIndex="34">
                                            <asp:ListItem>No</asp:ListItem>
                                            <asp:ListItem>Yes</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4 NoPregnant gender">
                                    <label class="col-sm-4 control-label text-right">Are you Lactating Mother?</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlLactatingMother" TabIndex="35">
                                            <asp:ListItem>Yes</asp:ListItem>
                                            <asp:ListItem>No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-4 NoLactic gender">
                                    <label class="col-sm-4 control-label text-right">Baby's Age</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="ddlBabyAge" TabIndex="36">
                                            <asp:ListItem>Not available</asp:ListItem>
                                            <asp:ListItem>0 to 6 months</asp:ListItem>
                                            <asp:ListItem>7 to 12 months</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <legend class="col-sm-12">Fat and Oil</legend>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Oil Detail </label>
                                    <div class="col-sm-8  control-block">
                                        <%--<td align="left">--%>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtOilDetail" TabIndex="37" autocomplete="off">                              
                                        </asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator64" runat="server" ErrorMessage="OilDetail  Required" Display="Dynamic" ControlToValidate="txtOilDetail" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator47" runat="server" ErrorMessage="Invalid OilDetail" Display="Dynamic" ControlToValidate="txtOilDetail" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Oil Quantity in Month</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtOilQuantity" TabIndex="38" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator65" runat="server" ErrorMessage="OilQuantity  Required" Display="Dynamic" ControlToValidate="txtOilQuantity" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%-- <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator48" runat="server" ErrorMessage="Invalid OilQuantity" Display="Dynamic" ControlToValidate="txtOilQuantity" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">No of Family Members</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtFamilyMembers" TabIndex="39" autocomplete="off">                              
                                        </asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator66" runat="server" ErrorMessage="FamilyMembers  Required" Display="Dynamic" ControlToValidate="txtFamilyMembers" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator49" runat="server" ErrorMessage="Invalid FamilyMembers" Display="Dynamic" ControlToValidate="txtFamilyMembers" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Sugar Quantity In Month</label>
                                    <div class="col-sm-8  control-block">

                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtSugerQuantity" TabIndex="40" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator47" runat="server" ErrorMessage="Beverages  Required" Display="Dynamic" ControlToValidate="txtBeverages" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator77" runat="server" ErrorMessage="Invalid Suger Quantity" Display="Dynamic" ControlToValidate="txtSugerQuantity" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes5" runat="server" TextMode="MultiLine" Width="100%" TabIndex="35" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator55" runat="server" ErrorMessage="Diet & Lifestyle Notes Required" Display="Dynamic" ControlToValidate="txtNotes5" ValidationGroup="validationGroup4" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%-- <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator50" runat="server" ErrorMessage="Invalid Diet & Lifestyle Notes" Display="Dynamic" ControlToValidate="txtNotes5" ValidationGroup="validationGroup4" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnDietLifestyle" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="validationGroup4" OnClick="btnDietLifestyle_Click" />
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-12 control-block">
                                        <asp:ValidationSummary ID="ValDietLife"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true" ValidationGroup="validationGroup4" runat="server" CssClass="alert alert-danger padd" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-7" class="tab-pane fade">
                            <div class="row">
                                <div class="form-group col-sm-12">
                                    <div class="col-sm-12  control-block">
                                        <div id="RecallDietSection">
                                            <UC:Recall ID="RecallDiet1" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-8" class="tab-pane fade">
                            <div class="row">
                                <div class="form-group col-sm-12">
                                    <div class="col-sm-12  control-block">
                                        <div id="RecommendedDietHistory">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12">
                                    <div class="col-sm-12  control-block">
                                        <table class="table table-bordered table-striped dataTable">
                                            <tbody>
                                                <tr>
                                                    <th colspan="4" style="text-align: center">Designed /Recommended Diet</th>
                                                    <th colspan="4" style="text-align: center">Output</th>
                                                </tr>
                                                <tr>
                                                    <th>Required Calorie (kcal)</th>
                                                    <th>Recommended Calorie (kcal)</th>
                                                    <th>% Protein</th>
                                                    <th>% Fat</th>
                                                    <th>% Carb</th>
                                                    <th>Protein (gm)</th>
                                                    <th>Fat (gm)</th>
                                                    <th>Carb (gm)</th>

                                                </tr>
                                                <tr>
                                                    <td style="width: 15%">
                                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtCalorie1" TabIndex="14" autocomplete="off" Enabled="false" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 20%">
                                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtCalorie2" TabIndex="15" autocomplete="off" Width="100px" onchange="CalorieCal1();"></asp:TextBox>
                                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator10" runat="server" ErrorMessage="Calorie Required" Display="Dynamic" ControlToValidate="txtCalorie2" ValidationGroup="ValGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator35" runat="server" ErrorMessage="Invalid Calorie" Display="Dynamic" ControlToValidate="txtCalorie2" ValidationGroup="ValGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <asp:TextBox CssClass="form-control calorie" runat="server" ID="txtProteinPercent1" TabIndex="16" autocomplete="off" onchange="CalorieCal1();" Width="60px" onkeyup="CalculatePercent();"></asp:TextBox>
                                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Protein Percent Required" Display="Dynamic" ControlToValidate="txtProteinPercent1" ValidationGroup="ValGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator40" runat="server" ErrorMessage="Invalid Protein Percent" Display="Dynamic" ControlToValidate="txtProteinPercent1" ValidationGroup="ValGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <asp:TextBox CssClass="form-control calorie" runat="server" ID="txtFatPercent1" TabIndex="17" autocomplete="off" onchange="CalorieCal1();" Width="60px" onkeyup="CalculatePercent();"></asp:TextBox>
                                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator12" runat="server" ErrorMessage="Fat Percent Required" Display="Dynamic" ControlToValidate="txtFatPercent1" ValidationGroup="ValGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator41" runat="server" ErrorMessage="Invalid Fat Percent" Display="Dynamic" ControlToValidate="txtFatPercent1" ValidationGroup="ValGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <asp:TextBox CssClass="form-control calorie" runat="server" ID="txtCarbhohydratesPercent1" TabIndex="18" autocomplete="off" onchange="CalorieCal1();" Width="60px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Carbhohydrates Percent Required" Display="Dynamic" ControlToValidate="txtCarbhohydratesPercent1" ValidationGroup="ValGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator25" runat="server" ErrorMessage="Invalid Carbhohydrates Percent" Display="Dynamic" ControlToValidate="txtCarbhohydratesPercent1" ValidationGroup="ValGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <span id="lblProtein1" style="display: table-cell; vertical-align: middle; font-weight: bold;"></span>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <span id="lblFat1" style="display: table-cell; vertical-align: middle; font-weight: bold;"></span>
                                                    </td>
                                                    <td style="width: 10%">
                                                        <span id="lblCarbo1" style="display: table-cell; vertical-align: middle; font-weight: bold;"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnRecommendSave" Text="Save Diet Plan" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValGroup" OnClick="btnRecommendSave_Click" /></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12">
                                    <div class="col-sm-12  control-block">
                                        <table class="table table-bordered table-striped dataTable" style="width: 100%">
                                            <tbody>
                                                <tr>
                                                    <th style="text-align: left; width: 20%">Food Group</th>
                                                    <th style="width: 70%">Servings</th>
                                                    <%--<th style="width: 10%">Break-fast</th>
													<th style="width: 10%">Mid-Morning</th>
													<th style="width: 10%">Lunch</th>
													<th style="width: 10%">Tea</th>
													<th style="width: 10%">Snack</th>
													<th style="width: 10%">Dinner</th>
													<th style="width: 10%">Bed Time</th>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Grains and Cereals</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtGrainServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox>
                                                    </td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtGrain1" Width="82px"></asp:TextBox>
													</td>
													<td>
														<asp:TextBox runat="server" ID="txtGrain2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtGrain3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtGrain4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtGrain5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtGrain6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtGrain7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtGrain8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Dals, Pulses and Legumes</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtDalsServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtDal1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtDal2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtDal3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtDal4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtDal5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtDal6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtDal7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtDal8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Milk and Milk Products</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtMilkServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtMilk1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtMilk2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtMilk3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtMilk4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtMilk5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtMilk6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtMilk7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtMilk8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Non-vegetarian foods</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtNonvegServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtNonveg1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtNonveg2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtNonveg3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtNonveg4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtNonveg5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtNonveg6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtNonveg7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtNonveg8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Vegetables</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtVegetableServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtVegetable1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtVegetable2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtVegetable3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtVegetable4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtVegetable5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtVegetable6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtVegetable7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtVegetable8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Fruits</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtFruitsServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtFruits1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFruits2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFruits3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFruits4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFruits5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFruits6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFruits7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFruits8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Sugar</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtSugarServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtSugar1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtSugar2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtSugar3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtSugar4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtSugar5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtSugar6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtSugar7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtSugar8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Fat</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtFatServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtFat1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFat2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFat3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFat4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFat5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFat6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFat7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtFat8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Water</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtWaterServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                    <%--<td>
														<asp:TextBox runat="server" ID="txtWater1" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtWater2" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtWater3" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtWater4" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtWater5" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtWater6" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtWater7" Width="82px"></asp:TextBox></td>
													<td>
														<asp:TextBox runat="server" ID="txtWater8" Width="82px"></asp:TextBox></td>--%>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">Miscellaneous</td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtBiscuitServings" TextMode="MultiLine" Rows="2" CssClass="col-sm-10  control-block"></asp:TextBox></td>

                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>
                                                        <asp:Button runat="server" ID="btnServings" Text="Save Servings" CssClass="btn btn-primary btn-lg align-center" CausesValidation="true" ValidationGroup="ValGroup2" OnClick="btnServings_Click" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="form-group col-sm-12">
                                    <div class="col-sm-12  control-block">
                                        <div id="RecommendedDietSection">
                                            <UC:Recommend ID="RecommendedDiet" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-9" class="tab-pane fade">
                            <div class="row-fluid">
                                <div class="form-group col-sm-12" id="History">
                                </div>
                            </div>
                        </div>
                        <div class="row buttons-row">
                            <div class="col-sm-12 align-center">
                                <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-primary btn-sm" OnClick="btnBack_Click" PostBackUrl="~/Screens/PatientDetails.aspx" CausesValidation="false" />
                                <asp:Button runat="server" ID="btnSave" Text="Save All" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="ValidationGroup" />
                                <asp:Button runat="server" ID="btnUpdate" Text="Save And End Appoinment" CssClass="btn btn-primary btn-sm" OnClick="btnUpdate_Click" CausesValidation="true" ValidationGroup="ValidationGroup" />
                                <span onclick="return confirm('Are you sure you want to delete?')">
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-primary btn-sm" OnClick="btnDelete_Click" CausesValidation="false" /></span>
                                <%-- <input type="button" id="btnPrint" value="Print" class="btn btn-primary btn-sm" onclick="openPopup();"/>--%>
                                <%-- <span onclick="return confirm('Are you sure you want to print?')">--%>
                                <asp:Button runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClick="btnPrint_Click" />
                                <%--</span>--%>
                                <%--<asp:Button runat="server" ID="btnEnd" Text="End Appointment" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClick="btnEnd_Click" />--%>
                                <%-- <asp:Button runat="server" ID="btnUpload" Text="Upload Documents" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClick="btnUpload_Click" />
							<asp:Button runat="server" ID="btnHistory" Text="History" CssClass="btn btn-primary btn-sm" CausesValidation="false" OnClick="btnHistory_Click" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <%--<div class="PkModal">
				<div class="center">
					<img alt="" src="../Images/loader.gif" />
				</div>
			</div>--%>
            <div id="loading">
                <div class='uil-default-css' style='transform: scale(0.9); background-color: #ffffff; border-radius: 15px;'>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(0deg) translate(0,-60px); transform: rotate(0deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(30deg) translate(0,-60px); transform: rotate(30deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(60deg) translate(0,-60px); transform: rotate(60deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(90deg) translate(0,-60px); transform: rotate(90deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(120deg) translate(0,-60px); transform: rotate(120deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(150deg) translate(0,-60px); transform: rotate(150deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(180deg) translate(0,-60px); transform: rotate(180deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(210deg) translate(0,-60px); transform: rotate(210deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(240deg) translate(0,-60px); transform: rotate(240deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(270deg) translate(0,-60px); transform: rotate(270deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(300deg) translate(0,-60px); transform: rotate(300deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                    <div style='top: 80px; left: 93px; width: 14px; height: 40px; background: #00b2ff; -webkit-transform: rotate(330deg) translate(0,-60px); transform: rotate(330deg) translate(0,-60px); border-radius: 10px; position: absolute;'></div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="profilecontent" runat="server">
    <style>
        .sidebar.responsive.menu-min .cprofiles-block {
            display: none;
        }

        .cprofiles-block {
        }

            .cprofiles-block .cdp {
                text-align: center;
                font-size: 45px;
                color: #438EB9;
            }

            .cprofiles-block .usricon {
                border: 1px solid #438EB9;
                border-radius: 100%;
                padding: 10px;
            }
    </style>
    <div class="cprofiles-block" id="profilediv">
        <div class="cdp"><i class="glyphicon glyphicon-user usricon"></i></div>
        <div class="cdetails">
            <div class="align-center">
                <b>
                    <asp:Label ID="lblprofilename" runat="server"></asp:Label></b>&nbsp;<asp:Label ID="lblid" runat="server"></asp:Label>
            </div>
            <div class="align-center">
                <asp:Label ID="lbldob" runat="server"></asp:Label>
            </div>
            <br />
            <div class="align-center">
                <asp:Label ID="lbladdress" runat="server"></asp:Label>
            </div>
            <div class="align-center">
                <asp:Label ID="lbllandline" runat="server"></asp:Label>
            </div>
            <br />
            <div class="align-center">
                <label>Last visit</label>
                <asp:Label ID="lblVisit1" runat="server"></asp:Label>
            </div>
            <br />
            <div>
                <ul class="list-group">
                    <%-- <li><a href="../Screens/PatientHistory.aspx" class="list-group-item list-group-item-info" target="_blank">Visits</a></li>--%>
                    <%--<li><a href="../Screens/DietPlan.aspx" class="list-group-item list-group-item-info" target="_blank">Recall Diet</a></li>--%>
                    <li><a href="../Screens/PatientDocs.aspx" class="list-group-item list-group-item-info" target="_blank">Upload documents</a></li>
                    <li><a href="../Screens/FigurePlotsOfWeightChange.aspx" class="list-group-item list-group-item-info" target="_blank">Weight change graph</a></li>
                    <%-- <li><a href="../Screens/RecommendedDiet.aspx" class="list-group-item list-group-item-info" target="_blank">Recommended Diet</a></li>--%>
                    <li><a href="../Screens/FollowupQuestions.aspx" class="list-group-item list-group-item-info" target="_blank">Followup</a></li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
