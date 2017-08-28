var itemCount = 0;
var containerRecallDiet = "#RecallDietSection ";

var objs = [];
var temp_objs = [];

function addFoodRow(MealId) {
    //$("#add_button").click(function () {
    debugger;
    var html = "";
    //var foodName = $("#txtFoodItemMeal1").val();
    var foodName = $(containerRecallDiet + "#txtFoodItem" + MealId).val();
    var foodQuantity = $(containerRecallDiet + "#txtFoodQuantity" + MealId).val();
    var foodUnit = $(containerRecallDiet + "#txtFoodMeasure" + MealId).val();

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

    if (foodNutrients.foodID == "-1")
    {
        $(containerRecallDiet + "#txtFoodItem" + MealId).notify("Food does not exist", { position: "bottom", className: 'error' });
        return;
    }

    var obj = {
        "ROW_ID": itemCount,
        "FOOD_ID": foodNutrients.foodID,
        "FOOD_NAME": $(containerRecallDiet + "#txtFoodItem" + MealId).val(),
        "FOOD_QUANTITY": $(containerRecallDiet + "#txtFoodQuantity" + MealId).val(),
        "FOOD_UNIT": $(containerRecallDiet + "#txtFoodMeasure" + MealId).val(),
        "FOOD_REMARK": $(containerRecallDiet + "#txtFoodRemark" + MealId).val(),
        "FOOD_ENERGY": foodNutrients.energy,
        "FOOD_PROTEIN": foodNutrients.protein,
        "FOOD_FAT": foodNutrients.fat,
        "FOOD_FIBRE": foodNutrients.fibre,
        "FOOD_CARBS": foodNutrients.carbs,
        "FOOD_CONSUMPTION_DAYS": getFoodConsumptionDayBits(MealId),
    }

    //debugger;
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
    html += "   <td class='mealInput editable'>" + getFoodConsumptionDaysTemplate(obj['FOOD_CONSUMPTION_DAYS']) + " </td>";
    html += "   <td class='action'><div class='displayInlineFlex'><button type='button' id='btnEditFoodRow" + itemCount + "' onclick='editFoodRow(&quot;" + MealId + "&quot; , this)'> <i class='fa fa-pencil fa-fw'></i> </button><button type='button' id='btnRemoveFoodRow" + itemCount + "' onclick='removeFoodRow(&quot;" + MealId + "&quot; , this)'> <i class='fa fa-trash fa-fw'></i> </button></div></td>";
    html += "</tr>";



    //add to the table
    $(containerRecallDiet + "table[id$='tblFoodList" + MealId + "'] > tbody:last").append(html);

    saveMeal(MealId);
    calculateTotal(MealId);

    $(containerRecallDiet + "#txtFoodItem" + MealId).val("");
    $(containerRecallDiet + "#txtFoodQuantity" + MealId).val("");
    $(containerRecallDiet + "#txtFoodMeasure" + MealId).val("");
    $(containerRecallDiet + "#txtFoodRemark" + MealId).val("");

    clearFoodConsumptionDays(MealId);
}

function clearFoodConsumptionDays(MealId) {
    //clear all week days check boxex
    $(containerRecallDiet + "input[type='checkbox'][id*='" + MealId + "']").each(function () {
        $(this).prop("checked", false);
    });
}

function getFoodConsumptionDayBits(MealId) {
    debugger;
    var foodConsumptionBits = "";
    $(containerRecallDiet + "input[id*='chkDays" + MealId + "_']").each(function () {
        foodConsumptionBits = foodConsumptionBits + (($(this).is(':checked')) ? "1" : "0");
    });
    return foodConsumptionBits;
}

function getFoodConsumptionDaysTemplate(foodConsumptionDaysBits) {
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

function setFoodConsumtionDays(MealId, foodConsumtionDaysBits) {
    debugger;
    $(containerRecallDiet + "input[id*='chkDays" + MealId + "_']").each(function (i) {

        if (foodConsumtionDaysBits.substr(i, 1) == "1")
            $(this).prop('checked', true);
        else
            $(this).prop('checked', false);
    });

    if (foodConsumtionDaysBits == "1111111") {
        $(containerRecallDiet + "input[id$='chkAlldays" + MealId + "']").prop("checked", true);
        $(containerRecallDiet + "input[id$='chkWeekdays" + MealId + "']").prop("checked", true);
        $(containerRecallDiet + "input[id$='chkWeekend" + MealId + "']").prop("checked", true);
    }


    if (foodConsumtionDaysBits.substr(0, 5) == "11111") {
        $(containerRecallDiet + "input[id$='chkWeekdays" + MealId + "']").prop("checked", true);
    }


    if (foodConsumtionDaysBits.substr(5, 2) == "11") {
        $(containerRecallDiet + "input[id$='chkWeekend" + MealId + "']").prop("checked", true);
    }

}

function removeFoodRow(MealId, removeButton) {
    debugger;
    $(removeButton).parent().parent().parent().remove();
    saveMeal(MealId);
    calculateTotal(MealId);
}

function changeRecallMealTime(MealId) {
    debugger;
    saveMeal(MealId);
    //calculateTotal(MealId); //No need to calculate total since only mealtime is changed
}

function editFoodRow(MealId, editButton) {
    debugger;
    var editableFields = $(editButton).parent().parent().parent().find('td.editable');
    $(containerRecallDiet + "#txtFoodItem" + MealId).typeahead('val', editableFields[0].innerText).blur();
    //$('#typeahead_object').typeahead('val', 'some value').blur();
    $(containerRecallDiet + "#txtFoodQuantity" + MealId).val(editableFields[1].innerText);
    $(containerRecallDiet + "#txtFoodMeasure" + MealId).typeahead('val', editableFields[2].innerText).blur();
    $(containerRecallDiet + "#txtFoodRemark" + MealId).val(editableFields[3].innerText);
    var foodConsumtionDaysBits = editableFields[4].children[0].dataset.foodConsumptionDays;  //Retrive food consuption data
    clearFoodConsumptionDays(MealId);
    setFoodConsumtionDays(MealId, foodConsumtionDaysBits);
    $(editButton).parent().parent().parent().remove();

}

function calculateTotal(MealId) {
    var weeklyTotals = [0, 0, 0, 0, 0];
    var weekdayTotals = [0, 0, 0, 0, 0];
    var weekendTotals = [0, 0, 0, 0, 0];

    var $dataRows = $(containerRecallDiet + "table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");
    debugger;
    $dataRows.each(function () {

        var editableFields = $(this).find('td.editable');
        var foodConsumtionDaysBits = editableFields[4].children[0].dataset.foodConsumptionDays;  //Retrive food consuption data

        for (var i = 0; i <= 6; i++) {

            //week total
            if (foodConsumtionDaysBits[i] == "1") {
                $(this).find('.rowDataSd').each(function (i) {
                    weeklyTotals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

            //weekday total
            if (foodConsumtionDaysBits[i] == "1" && i <= 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekdayTotals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

            //weekend total
            if (foodConsumtionDaysBits[i] == "1" && i > 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekendTotals[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

        }


    });

    //weekly average
    $(containerRecallDiet + "table[id$='tblFoodList" + MealId + "'] td.totalCol.week").each(function (i) {
        $(this).html((weeklyTotals[i] / 7).toFixed(2));
    });

    //weekday average
    $(containerRecallDiet + "table[id$='tblFoodList" + MealId + "'] td.totalCol.weekday").each(function (i) {
        $(this).html((weekdayTotals[i] / 5).toFixed(2));
    });

    //weekend average
    $(containerRecallDiet + "table[id$='tblFoodList" + MealId + "'] td.totalCol.weekend").each(function (i) {
        $(this).html((weekendTotals[i] / 2).toFixed(2));
    });

    //Overall Total
    calculateAllTotal();
    //calculateWeekendWeekdayTotal();
}

function calculateAllTotal() {
    debugger;
    var weeklyTotal = [0, 0, 0, 0, 0];
    var weekdayTotal = [0, 0, 0, 0, 0];
    var weekendTotal = [0, 0, 0, 0, 0];
    var sel48DietRecallOrNot = "[role!='RecallDiet48Hour']";

    if ($(containerRecallDiet + "#chk48DietRecall").is(':checked')) {
        sel48DietRecallOrNot = "";
    }


    var $dataRows = $(containerRecallDiet + "table[id*='tblFoodListMeal']" + sel48DietRecallOrNot + " tr:not('.totalRow, .titleRow')");

    $dataRows.each(function () {

        var editableFields = $(this).find('td.editable');
        var foodConsumtionDaysBits = editableFields[4].children[0].dataset.foodConsumptionDays;  //Retrive food consuption data

        for (var i = 0; i <= 6; i++) {

            //Total Weekday
            if (foodConsumtionDaysBits[i] == "1" && i <= 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekdayTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

            //Total Weekend
            if (foodConsumtionDaysBits[i] == "1" && i > 4) {
                $(this).find('.rowDataSd').each(function (i) {
                    weekendTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

            //Total Weekly
            if (foodConsumtionDaysBits[i] == "1") {
                $(this).find('.rowDataSd').each(function (i) {
                    weeklyTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            }

        }
    });

    // set weekday and weekend total on table
    $(containerRecallDiet + "table[id='tblRecallFoodListTotal'] tr.weekday td").each(function (i) {
        $(this).html((weekdayTotal[i] / 5).toFixed(2));
    });

    $(containerRecallDiet + "table[id='tblRecallFoodListTotal'] tr.weekend td").each(function (i) {
        $(this).html((weekendTotal[i] / 2).toFixed(2));
    });

    $(containerRecallDiet + "table[id='tblRecallFoodListTotal'] tr.weekly td").each(function (i) {
        $(this).html((weeklyTotal[i] / 7).toFixed(2));
    });
}

function calculateWeekendWeekdayTotal() {
    var weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    var mealDays = "";
    var noOfMeals = 6;
    var weekendTotal = [0, 0, 0, 0, 0];
    var weekdayTotal = [0, 0, 0, 0, 0];

    //set no of meals to be include in calculation based on 24/48 diet Recall selection
    if ($(containerRecallDiet + "#chk48DietRecall").is(':checked')) {
        noOfMeals = 12;
    }

    //traverse each meal
    for (var MealId = 1; MealId <= noOfMeals; MealId++) {

        $(containerRecallDiet + "input[id*='chkDaysMeal" + MealId + "_']:checked").each(function () {
            mealDays = mealDays + weekDays.indexOf($(this).val()) + "-";
        });

        mealDays = mealDays.substr(0, mealDays.lastIndexOf("-"));

        //idenitfy weekday or weekend
        if (mealDays.indexOf("5") != -1 || mealDays.indexOf("6") != -1) {

            //calculate weekend total
            var $weekendDataRows = $(containerRecallDiet + "table[id*='tblFoodListMeal" + MealId + "'] tr:not('.totalRow, .titleRow')");

            $weekendDataRows.each(function () {
                $(this).find('.rowDataSd').each(function (i) {
                    weekendTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            });

        } else {

            //calculate weekday total
            var $weekdayDataRows = $(containerRecallDiet + "table[id*='tblFoodListMeal" + MealId + "'] tr:not('.totalRow, .titleRow')");

            $weekdayDataRows.each(function () {
                $(this).find('.rowDataSd').each(function (i) {
                    weekdayTotal[i] += parseFloat(parseFloat($(this).html()).toFixed(2));
                });
            });

        }

    }
    // set weekday and weekend total on table
    $(containerRecallDiet + "table[id='tblRecallFoodListTotal'] tr.weekday td").each(function (i) {
        $(this).html((weekdayTotal[i] / 5).toFixed(2));
    });

    $(containerRecallDiet + "table[id='tblRecallFoodListTotal'] tr.weekend td").each(function (i) {
        $(this).html((weekendTotal[i] / 2).toFixed(2));
    });
}

function saveMeal(MealId) {
    var weekDays = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
    var mealDays = "";
    var mealData = "";
    var mealTime = $(containerRecallDiet + "input[id$='txtTimePicker" + MealId + "']").val().trim();
    var notes = $(containerRecallDiet + "textarea[id$='txtRecallDietNotes']").val().trim();


    $(containerRecallDiet + "input[id*='chkDays" + MealId + "_']:checked").each(function () {
        mealDays = mealDays + weekDays.indexOf($(this).val()) + "-";
    });
    debugger;
    mealDays = mealDays.substr(0, mealDays.lastIndexOf("-"));

    //alert(mealDays);


    var $dataRows = $(containerRecallDiet + "table[id$='tblFoodList" + MealId + "'] tr:not('.totalRow, .titleRow')");

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
        url: "../Screens/DietHelper.aspx/SaveSingleMealDetails",
        data: '{MealID: "' + MealId + '", MealDays: "' + mealDays + '", MealData: "' + mealData + '", MealTime: "' + mealTime + '", Notes: "' + notes + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            //alert(response.d);
            $(containerRecallDiet + "input[id='txtTimePicker" + MealId + "']").notify(
                "Saved", { position: "bottom", className: 'success' }
            );

            //$.notify("Saved", "success");

            foodNutrients = response.d;
            //calculateWeekendWeekdayTotal();
        },
        failure: function (response) {
            //alert(response.d);
            $(containerRecallDiet + "input[id='txtTimePicker" + MealId + "']").notify(
                "Error", { position: "bottom", className: 'error' }
            );
        }
    });


}

function saveAllMeals() {
    var mealName = "Meal";
    var length = 6;

    if ($(containerRecallDiet + "#chk48DietRecall").is(':checked')) {
        length = 12;
    }
    for (var meal = 1; meal <= length; meal++) {
        saveMeal(mealName + meal);
    }

    $(containerRecallDiet + "input[id='btnSaveAllMeals']").notify(
        "Saved", { position: "right", className: 'success' }
    );

}

function setDietRecallType() {
    if ($(containerRecallDiet + "#chk48DietRecall").is(':checked')) {
        $(containerRecallDiet + "div[role='RecallDiet48Hour']").show();
    } else {
        $(containerRecallDiet + "div[role='RecallDiet48Hour']").hide();
    }
    calculateAllTotal();
    //calculateWeekendWeekdayTotal();
}

function selectRecallDays(ctrl, mealId) {
    var check = $(ctrl).is(':checked');
    var ctrlValue = $(ctrl).attr("value");
    var weekDay = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    var weekEnd = ["Saturday", "Sunday"];

    switch (ctrlValue) {
        case "Alldays":
            //alert('All' + mealId);
            $(containerRecallDiet + "input[id^='chkDays" + mealId + "_']").each(function () {
                $(this).prop("checked", check);
            });

            $(containerRecallDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", check);
            $(containerRecallDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", check);
            break;

        case "Weekdays":
            //alert('Weekday' + mealId);
            $(containerRecallDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

                if (weekDay.indexOf($(this).val()) > -1) {
                    $(this).prop("checked", check);
                }

            });

            if (check && $(containerRecallDiet + "input[id$='chkWeekend" + mealId + "']").is(':checked')) {
                $(containerRecallDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecallDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", false);
            }

            break;

        case "Weekend":
            //alert('Weekend' + mealId);
            $(containerRecallDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

                if (weekEnd.indexOf($(this).val()) > -1) {
                    $(this).prop("checked", check);
                }
            });

            if (check && $(containerRecallDiet + "input[id$='chkWeekdays" + mealId + "']").is(':checked')) {
                $(containerRecallDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecallDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", false);
            }


        default:
            debugger;
            var isAllWeekDay = true;
            var isAllWeekend = true;
            $(containerRecallDiet + "input[id^='chkDays" + mealId + "_']").each(function () {

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
                $(containerRecallDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", true);
                $(containerRecallDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", true);
                $(containerRecallDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecallDiet + "input[id$='chkAlldays" + mealId + "']").prop("checked", false);
                $(containerRecallDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", false);
                $(containerRecallDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", false);
            }

            if (isAllWeekDay) {
                $(containerRecallDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecallDiet + "input[id$='chkWeekdays" + mealId + "']").prop("checked", false);
            }

            if (isAllWeekend) {
                $(containerRecallDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", true);
            }
            else {
                $(containerRecallDiet + "input[id$='chkWeekend" + mealId + "']").prop("checked", false);
            }

            break;
    }

}