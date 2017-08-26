var itemCount = 0;
var containerRecommendedDiet = "#RecommendedDietSection ";

var objs = [];
var temp_objs = [];


//function addFoodRow(MealId) {
function addRecommendedFoodRow(MealId) {
    //$("#add_button").click(function () {
    debugger;
    var html = "";
    //var foodName = $("#txtFoodItemMeal1").val();
    var foodName = $(containerRecommendedDiet + "#txtFoodItem" + MealId).val();
    var foodQuantity = $(containerRecommendedDiet + "#txtFoodQuantity" + MealId).val();
    var foodUnit = $(containerRecommendedDiet + "#txtFoodMeasure" + MealId).val();

    if (foodName == '' || foodQuantity == '' || foodUnit == '')
        return;

    var foodNutrients;


    debugger;
    $.ajax({
        type: "POST",
        url: "../Screens/DietHelper.aspx/GetFoodNutrients",
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
        "FOOD_NAME": $(containerRecommendedDiet + "#txtFoodItem" + MealId).val(),
        "FOOD_QUANTITY": $(containerRecommendedDiet + "#txtFoodQuantity" + MealId).val(),
        "FOOD_UNIT": $(containerRecommendedDiet + "#txtFoodMeasure" + MealId).val(),
        "FOOD_REMARK": $(containerRecommendedDiet + "#txtFoodRemark" + MealId).val(),
        "FOOD_ENERGY": foodNutrients.energy,
        "FOOD_PROTEIN": foodNutrients.protein,
        "FOOD_FAT": foodNutrients.fat,
        "FOOD_FIBRE": foodNutrients.fibre,
        "FOOD_CARBS": foodNutrients.carbs,
        "FOOD_CONSUMPTION_DAYS": getRecommendedFoodConsumptionDayBits(MealId),
    }

    // add object
    objs.push(obj);

    itemCount++;
    // dynamically create rows in the table
    html += "<tr id='tr" + itemCount + "'>";
    html += "   <td class='mealInput hidden'>" + obj['FOOD_ID'] + "</td>";
    html += "   <td colspan='2' class='editable'>" + obj['FOOD_NAME'] + "</td>";
    html += "   <td class='mealInput editable'>" + obj['FOOD_QUANTITY'] + " </td>";
    html += "   <td class='mealInput editable'>" + obj['FOOD_UNIT'] + " </td>";
    html += "   <td class='mealInput editable'>" + obj['FOOD_REMARK'] + " </td>";
    html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_ENERGY'] + " </td>";
    html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_PROTEIN'] + " </td>";
    html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_FAT'] + " </td>";
    html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_FIBRE'] + " </td>";
    html += "   <td class='rowDataSd mealInput'>" + obj['FOOD_CARBS'] + " </td>";
    html += "   <td class='mealInput editable'>" + getRecommendedFoodConsumptionDaysTemplate(obj['FOOD_CONSUMPTION_DAYS']) + " </td>";
    html += "   <td class='action'><div class='displayInlineFlex'><button type='button' id='btnEditFoodRow" + itemCount + "' onclick='editRecommendedFoodRow(&quot;" + MealId + "&quot; , this)'> <i class='fa fa-pencil fa-fw'></i> </button><button type='button' id='btnRemoveFoodRow" + itemCount + "' onclick='removeRecommendedFoodRow(&quot;" + MealId + "&quot; , this)'> <i class='fa fa-trash fa-fw'></i> </button></div></td>";
    html += "</tr>";



    //add to the table
    $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] > tbody:last").append(html);

    saveRecommendedDietMeal(MealId);
    calculateRecommendedDietTotal(MealId);

    $(containerRecommendedDiet + "#txtFoodItem" + MealId).val("");
    $(containerRecommendedDiet + "#txtFoodQuantity" + MealId).val("");
    $(containerRecommendedDiet + "#txtFoodMeasure" + MealId).val("");
    $(containerRecommendedDiet + "#txtFoodRemark" + MealId).val("");

    clearRecommendedFoodConsumptionDays(MealId);
}

function clearRecommendedFoodConsumptionDays(MealId) {
    //clear all week days check boxex
    $(containerRecommendedDiet + "input[type='checkbox'][id*='" + MealId + "']").each(function () {
        $(this).prop("checked", false);
    });
}

function getRecommendedFoodConsumptionDayBits(MealId) {
    debugger;
    var foodConsumptionBits = "";
    $(containerRecommendedDiet + "input[id*='chkDays" + MealId + "_']").each(function () {
        foodConsumptionBits = foodConsumptionBits + (($(this).is(':checked')) ? "1" : "0");
    });
    return foodConsumptionBits;
}

function getRecommendedFoodConsumptionDaysTemplate(foodConsumptionDaysBits) {
    debugger;
    var foodConsumptionDaysTemplate = "";
    foodConsumptionDaysTemplate += " <div class='displayInlineFlex' data-food-consumption-days='" + foodConsumptionDaysBits + "' >";
    foodConsumptionDaysTemplate += "    <span class='" + ((foodConsumptionDaysBits.substr(0, 1) == "1") ? "activeDay" : "inactiveDay") + "'>M</span>";
    foodConsumptionDaysTemplate += "    <span class='" + ((foodConsumptionDaysBits.substr(1, 1) == "1") ? "activeDay" : "inactiveDay") + "'>T</span>";
    foodConsumptionDaysTemplate += "    <span class='" + ((foodConsumptionDaysBits.substr(2, 1) == "1") ? "activeDay" : "inactiveDay") + "'>W</span>";
    foodConsumptionDaysTemplate += "    <span class='" + ((foodConsumptionDaysBits.substr(3, 1) == "1") ? "activeDay" : "inactiveDay") + "'>T</span>";
    foodConsumptionDaysTemplate += "    <span class='" + ((foodConsumptionDaysBits.substr(4, 1) == "1") ? "activeDay" : "inactiveDay") + "'>F</span>";
    foodConsumptionDaysTemplate += "    <span class='" + ((foodConsumptionDaysBits.substr(5, 1) == "1") ? "activeDay" : "inactiveDay") + "'>S</span>";
    foodConsumptionDaysTemplate += "    <span class='" + ((foodConsumptionDaysBits.substr(6, 1) == "1") ? "activeDay" : "inactiveDay") + "'>S</span>";
    foodConsumptionDaysTemplate += " </div>";
    return foodConsumptionDaysTemplate;

}

function setRecommendedFoodConsumtionDays(MealId, foodConsumtionDaysBits) {
    debugger;
    $(containerRecommendedDiet + "input[id*='chkDays" + MealId + "_']").each(function (i) {

        if (foodConsumtionDaysBits.substr(i, 1) == "1")
            $(this).prop('checked', true);
        else
            $(this).prop('checked', false);
    });

    if (foodConsumtionDaysBits == "1111111") {
        $(containerRecommendedDiet + "input[id$='chkAlldays" + MealId + "']").prop("checked", true);
        $(containerRecommendedDiet + "input[id$='chkWeekdays" + MealId + "']").prop("checked", true);
        $(containerRecommendedDiet + "input[id$='chkWeekend" + MealId + "']").prop("checked", true);
    }


    if (foodConsumtionDaysBits.substr(0, 5) == "11111") {
        $(containerRecommendedDiet + "input[id$='chkWeekdays" + MealId + "']").prop("checked", true);
    }


    if (foodConsumtionDaysBits.substr(5, 2) == "11") {
        $(containerRecommendedDiet + "input[id$='chkWeekend" + MealId + "']").prop("checked", true);
    }

}

//function removeFoodRow(MealId, removeButton) {
function removeRecommendedFoodRow(MealId, removeButton) {
    $(removeButton).parent().parent().parent().remove();
    saveRecommendedDietMeal(MealId);
    calculateRecommendedDietTotal(MealId);
}

function editRecommendedFoodRow(MealId, editButton) {
    debugger;
    var editableFields = $(editButton).parent().parent().parent().find('td.editable');
    $(containerRecommendedDiet + "#txtFoodItem" + MealId).typeahead('val', editableFields[0].innerText).blur();
    //$('#typeahead_object').typeahead('val', 'some value').blur();
    $(containerRecommendedDiet + "#txtFoodQuantity" + MealId).val(editableFields[1].innerText);
    $(containerRecommendedDiet + "#txtFoodMeasure" + MealId).typeahead('val', editableFields[2].innerText).blur();
    $(containerRecommendedDiet + "#txtFoodRemark" + MealId).val(editableFields[3].innerText);
    var foodConsumtionDaysBits = editableFields[4].children[0].dataset.foodConsumptionDays;  //Retrive food consuption data
    clearRecommendedFoodConsumptionDays(MealId);
    setRecommendedFoodConsumtionDays(MealId, foodConsumtionDaysBits);
    $(editButton).parent().parent().parent().remove();

}
//function calculateTotal(MealId) {
function calculateRecommendedDietTotal(MealId) {
    var weekdayTotals = [0, 0, 0, 0, 0];
    var weekendTotals = [0, 0, 0, 0, 0];

    var $dataRows = $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");

    $dataRows.each(function () {
        var editableFields = $(this).find('td.editable');
        var foodConsumtionDaysBits = editableFields[4].children[0].dataset.foodConsumptionDays;  //Retrive food consuption data

        for (var i = 0; i <= 6; i++) {

            if (foodConsumtionDaysBits[i] == "1" && i <= 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekdayTotals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

            if (foodConsumtionDaysBits[i] == "1" && i > 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekendTotals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

        }


    });
    $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] td.totalCol.weekday").each(function (i) {
        $(this).html((weekdayTotals[i] / 5).toFixed(2));
    });

    $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] td.totalCol.weekend").each(function (i) {
        $(this).html((weekendTotals[i] / 2).toFixed(2));
    });
    //Overall Total
    calculateRecommendedDietAllTotal();
}

//function calculateAllTotal() {
function calculateRecommendedDietAllTotal() {
    var weeklyTotal = [0, 0, 0, 0, 0];
    var weekdayTotal = [0, 0, 0, 0, 0];
    var weekendTotal = [0, 0, 0, 0, 0];
    var sel48DietRecallOrNot = "[role!='RecallDiet48Hour']";

    if ($(containerRecommendedDiet + "#chk48DietRecall").is(':checked')) {
        sel48DietRecallOrNot = "";
    }


    var $dataRows = $(containerRecommendedDiet + "table[id*='tblFoodListMeal']" + sel48DietRecallOrNot + " tr:not('.totalRow, .titleRow')");

    $dataRows.each(function () {
        var editableFields = $(this).find('td.editable');
        var foodConsumtionDaysBits = editableFields[4].children[0].dataset.foodConsumptionDays;  //Retrive food consuption data

        for (var i = 0; i <= 6; i++) {

            //Weekday Total
            if (foodConsumtionDaysBits[i] == "1" && i <= 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekdayTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

            //Weekend Total
            if (foodConsumtionDaysBits[i] == "1" && i > 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekendTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

            //Weekly Total
            if (foodConsumtionDaysBits[i] == "1") {
                $(this).find('.rowDataSd').each(function (i) {
                    weeklyTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

        }
    });

    // set weekday and weekend total on table
    $(containerRecommendedDiet + "table[id='tblFoodListTotal'] tr.weekday td").each(function (i) {
        $(this).html((weekdayTotal[i] / 5).toFixed(2));
    });

    $(containerRecommendedDiet + "table[id='tblFoodListTotal'] tr.weekend td").each(function (i) {
        $(this).html((weekendTotal[i] / 2).toFixed(2));
    });

    $(containerRecommendedDiet + "table[id='tblFoodListTotal'] tr.weekly td").each(function (i) {
        $(this).html((weeklyTotal[i] / 7).toFixed(2));
    });
}

//function saveMeal(MealId) {
function saveRecommendedDietMeal(MealId) {
    var weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    var mealDays = "";
    var mealData = "";
    var mealTime = $(containerRecommendedDiet + "input[id$='txtTimePicker" + MealId + "']").val().trim();
    var notes = $(containerRecommendedDiet + "textarea[id$='txtRecommendedDietNotes']").val().trim();


    $(containerRecommendedDiet + "input[id*='chkDays" + MealId + "_']:checked").each(function () {
        mealDays = mealDays + weekDays.indexOf($(this).val()) + "-";
    });

    mealDays = mealDays.substr(0, mealDays.lastIndexOf("-"));

    //alert(mealDays);


    var $dataRows = $(containerRecommendedDiet + "table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");

    $dataRows.each(function () {
        $(this).find('.mealInput').each(function () {
            mealData = mealData + $(this).html().trim() + "|";
        });
        mealData = mealData.substr(0, mealData.lastIndexOf("|"));
        debugger;
        var consupDayHtml = mealData.substring(mealData.lastIndexOf("|") + 1, mealData.length);
        var wrapper = document.createElement('div');
        wrapper.innerHTML = '' + consupDayHtml;
        var divFoodConsumptionDiv = wrapper.firstChild;
        var foodConsumptionBits = divFoodConsumptionDiv.dataset.foodConsumptionDays;

        mealData = mealData.substr(0, mealData.lastIndexOf("|")) + "|" + foodConsumptionBits;
        mealData = mealData + "~";
    });

    mealData = mealData.substr(0, mealData.lastIndexOf("~"));

    //alert(mealData);

    $.ajax({
        type: "POST",
        url: "../Screens/DietHelper.aspx/SaveRecommendedSingleMealDetails",
        data: '{MealID: "' + MealId + '", MealDays: "' + mealDays + '", MealData: "' + mealData + '", MealTime: "' + mealTime + '", Notes: "' + notes + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            //alert(response.d);
            $(containerRecommendedDiet + "input[id='txtTimePicker" + MealId + "']").notify(
              "Saved",
              { position: "bottom", className: 'success' }
            );

            //$.notify("Saved", "success");

            foodNutrients = response.d;
        },
        failure: function (response) {
            //alert(response.d);
            $(containerRecommendedDiet + "input[id='txtTimePicker" + MealId + "']").notify(
              "Error",
              { position: "bottom", className: 'error' }
            );
        }
    });


}

//function saveAllMeals() {
function saveAllRecommendedDietMeals() {
    var mealName = "Meal";
    var length = 6;

    if ($(containerRecommendedDiet + "#chk48DietRecall").is(':checked')) {
        length = 12;
    }
    for (var meal = 1; meal <= length; meal++) {
        //saveRecommendedDietMeal(mealName + meal);
    }

    $(containerRecommendedDiet + "input[id='btnSaveAllMeals']").notify(
      "Saved",
      { position: "right", className: 'success' }
    );

}

function setDietRecommendedType() {
    if ($(containerRecommendedDiet + "#chk48DietRecall").is(':checked')) {
        $(containerRecommendedDiet + "div[role='RecallDiet48Hour'").show();
    }
    else {
        $(containerRecommendedDiet + "div[role='RecallDiet48Hour'").hide();
    }
    calculateRecommendedDietAllTotal();
}

function selectRecommendedDays(ctrl, mealId) {
    debugger;
    var check = $(ctrl).is(':checked');
    var ctrlValue = $(ctrl).attr("value");
    var weekDay = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    var weekEnd = ["Saturday", "Sunday"];

    switch (ctrlValue) {
        case "Alldays":
            //alert('All' + mealId);
            $(containerRecommendedDiet + "input[id^='chkDays" + mealId + "_']").each(function () {
                $(this).prop("checked", check);
            });
            $(containerRecommendedDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", check);
            $(containerRecommendedDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", check);
            break;

        case "Weekdays":
            //alert('Weekday' + mealId);
            $(containerRecommendedDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

                if (weekDay.indexOf($(this).val()) > -1) {
                    $(this).prop("checked", check);
                }

            });

            if (check && $(containerRecommendedDiet + "input[id$='chkWeekend" + mealId + "']").is(':checked')) {
                $(containerRecommendedDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecommendedDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", false);
            }

            break;

        case "Weekend":
            //alert('Weekend' + mealId);
            $(containerRecommendedDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

                if (weekEnd.indexOf($(this).val()) > -1) {
                    $(this).prop("checked", check);
                }
            });

            if (check && $(containerRecommendedDiet + "input[id$='chkWeekdays" + mealId + "']").is(':checked')) {
                $(containerRecommendedDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecommendedDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", false);
            }


        default:
            debugger;
            var isAllWeekDay = true;
            var isAllWeekend = true;
            $(containerRecommendedDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

                //check whether any week day is not selected
                if (weekDay.indexOf($(this).val()) > -1) {
                    if ($(this).is(':checked') == false) {
                        isAllWeekDay = false;
                    }
                }

                //check whether any weekend day is not selected
                if (weekEnd.indexOf($(this).val()) > -1) {
                    if ($(this).is(':checked') == false) {
                        isAllWeekend = false;
                    }
                }
            });

            if (isAllWeekDay && isAllWeekend) {
                $(containerRecommendedDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", true);
                $(containerRecommendedDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", true);
                $(containerRecommendedDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecommendedDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", false);
                $(containerRecommendedDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", false);
                $(containerRecommendedDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", false);
            }

            if (isAllWeekDay) {
                $(containerRecommendedDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecommendedDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", false);
            }

            if (isAllWeekend) {
                $(containerRecommendedDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecommendedDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", false);
            }

            break;

    }

}