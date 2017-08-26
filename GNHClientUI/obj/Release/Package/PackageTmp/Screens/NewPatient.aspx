<%@ Page Title="" Language="C#" MasterPageFile="~/Master/MasterPage2.master" AutoEventWireup="true" CodeBehind="NewPatient.aspx.cs" Inherits="GNHClientUI.NewPatient" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link href="../css/intlTelInput.css" rel="stylesheet" />
    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="../assets/css/ace-ie.min.css" />
		<![endif]-->
    <script src="../assets/js/jquery.js"></script>
    <script src="../Scripts/intlTelInput.js?v=2017082401"></script>
    <script src="../Scripts/isValidNumber.js?v=2017082401"></script>
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

        .display {
            display: none;
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

            //$("a[href$='tabs-7']").parent().replaceWith("</ul><ul>"); //hide RecallDiet Tab

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
            //swal('Alert', 'Client details are not saved');
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
        });

        function ValidateMobileOnSubmit(oSrc, args) {
            var telInput = $("#ContentPlaceHolder1_ContentPlaceHolder3_txtMobile");
            args.IsValid = telInput.intlTelInput("isValidNumber");
        }

        function ValidateLandlineOnSubmit(oSrc, args) {
            var telInput = $("#ContentPlaceHolder1_ContentPlaceHolder3_txtLandline");
            args.IsValid = telInput.intlTelInput("isValidNumber");
        }

        function SetTabs() {
            if ($("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val() == "") {
                $("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val('tabs-1');
            }

            $("#tabs a").click(function () {
                $("[id*='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val($(this).attr("href").replace("#", ""));
            });
            var tabName = $("[id='ContentPlaceHolder1_ContentPlaceHolder3_TabName']").val();
            $('#tabs a[href="#' + tabName + '"]').trigger('click');

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


            $('#<%= txtTestDate.ClientID %>').datepicker({
                autoclose: true,
                format: 'dd/mm/yyyy'
            }).mask('99/99/9999');

        };
        //function Validate() {
        //    var isValid = false;
        //    isValid = Page_ClientValidate('ValidationGroup');

        //    if (isValid) {
        //        isValid = Page_ClientValidate('ValidationGroup1');
        //    }
        //    if (isValid) {
        //        isValid = Page_ClientValidate('ValidationGroup2');
        //    }
        //    return isValid;
        //}

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
            document.getElementById('<%=txtIdealWeight.ClientID %>').value =
                toFixed(2);
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
                if (Height > 5.5) {
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


        function BMR() {
            debugger;
            var BMR = "0";
            var gender = "0";
            var Height = document.getElementById('<%=txtHeight.ClientID %>').value;
            var weight = document.getElementById('<%=txtWeight.ClientID %>').value;

            var HeightBaseUnit = document.getElementById('<%=ddlHeightUnit.ClientID %>').value;
            var WeightBaseUnit = document.getElementById('<%=ddlWeightUnit.ClientID %>').value;

            Height = ConvertToCms(Height, HeightBaseUnit); // Convert height from baseUnit to CM
            weight = ConvertToKgs(weight, WeightBaseUnit);

            if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Select') {
                // alert('Please select gender IBW.');
            }
            else if (document.getElementById('<%=txtHeight.ClientID %>').value == '') {
                //  alert('Please enter Height IBW'); 
            }
            else {
                if (weight == '' || Height == '' || document.getElementById('<%=txtAge.ClientID %>').value == '') {

                }
                else {
                    if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Male') {
                        BMR = (66 + (13.7 * weight) + (5 * Height) - (6.8 * document.getElementById('<%=txtAge.ClientID %>').value)).toFixed(2);
                    }
                    else if (document.getElementById('<%=ddlGender.ClientID %>').value == 'Female') {
                        BMR = (655 + (9.6 * weight) + (1.8 * Height) - (4.7 * document.getElementById('<%=txtAge.ClientID %>').value)).toFixed(2);
                    }
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

        .modal1 {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .center1 {
            z-index: 1000;
            margin: 300px auto;
            padding: 10px;
            width: 130px;
            border-radius: 10px;
            filter: alpha(opacity=80);
            opacity: 0.6;
            -moz-opacity: 1;
        }

            .center1 img {
                height: 80px;
                width: 80px;
            }
    </style>
    <%--<div class="page-header">
        <h1>Screening
								<small>
                                    <i class="ace-icon fa fa-angle-double-right"></i>
                                    New Client
                                </small>
        </h1>
    </div>--%>

    <asp:ToolkitScriptManager runat="server" ID="Toolkit1"></asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="TabName" runat="server" />
            <%-- <div class="page-header">--%>
            <div id="tabs" class="patient-detailsl-tabs">
                <div class="patient-detailsl-tabs-block" style="overflow: auto;">
                    <ul class="nav nav-tabs" style="width: 800px;">
                        <li class="active"><a href="#tabs-1" data-toggle="tab">Client Details</a></li>
                        <li><a href="#tabs-2" data-toggle="tab">Anthropometrics</a></li>
                        <li><a href="#tabs-3" data-toggle="tab">Biochemical Labs</a></li>
                        <li><a href="#tabs-4" data-toggle="tab">Comorbidity</a></li>
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
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Client Name" Display="Dynamic" ControlToValidate="txtName" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Middle Name</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtMiddleName" runat="server" TabIndex="3" autocomplete="off"></asp:TextBox>
                                        <%--                                    <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Client Middle Name Required" Display="Dynamic" ControlToValidate="txtMiddleName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Middle Name" Display="Dynamic" ControlToValidate="txtMiddleName" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Last Name</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtLastName" runat="server" TabIndex="4" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Client LastName  Required" Display="Dynamic" ControlToValidate="txtLastName" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator3" runat="server" ErrorMessage="Invalid txtLast Name" Display="Dynamic" ControlToValidate="txtLastName" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Date Of Birth</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control cur" ID="txtDOB" runat="server" TabIndex="5" autocomplete="off" onchange="CalculateAge();" PlaceHolder="dd/MM/yyyy" Style="cursor: auto !important"></asp:TextBox>
                                        <%--<span style="position: absolute">
                                            <asp:ImageButton ID="lnkFromDate" runat="server" ImageUrl="~/Master/Images/calendar.gif" />
                                            <asp:CalendarExtender ID="FromDate_CalendarExtender" runat="server" Enabled="True"
                                                TargetControlID="txtDOB" PopupButtonID="lnkFromDate" Format="dd/MM/yyyy">
                                            </asp:CalendarExtender>
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
                                        <asp:DropDownList CssClass="form-control" ID="ddlGender" runat="server" TabIndex="6" onchange="BMI();BodyFrame();IBW();">
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
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Reuired Pin Code" Display="Dynamic" ControlToValidate="txtPin" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
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
                                        <%--                                            <asp:TextBox CssClass="form-control" ID="txtMobile" runat="server" TabIndex="14" autocomplete="off"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" CssClass="err-block err-bottom" ID="RequiredFieldValidator6" ErrorMessage="Select Mobile " Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator7" runat="server" ErrorMessage="Invalid Mobile " Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                        <asp:TextBox ID="txtMobile" runat="server" TabIndex="14" autocomplete="off"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" CssClass="err-block err-bottom" ID="RequiredFieldValidator6" ErrorMessage="Select Mobile " Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:CustomValidator ID="custMobileNumber" runat="server" CssClass="err-block err-bottom" ErrorMessage="Invalid Mobile" Display="Dynamic" ControlToValidate="txtMobile" ValidationGroup="ValidationGroup" ForeColor="Red" ClientValidationFunction="ValidateMobileOnSubmit"></asp:CustomValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Landline</label>
                                    <div class="col-sm-8  control-block">
                                        <%--<asp:TextBox CssClass="form-control" ID="txtLandline" runat="server" TabIndex="15" autocomplete="off"></asp:TextBox>
                                            <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Contact Required" Display="Dynamic" ControlToValidate="txtContact" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator62" runat="server" ErrorMessage="Invalid Landline " Display="Dynamic" ControlToValidate="txtLandline" ValidationGroup="ValidationGroup" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                                        <asp:TextBox CssClass="form-control" ID="txtLandline" runat="server" TabIndex="15" autocomplete="off"></asp:TextBox>
                                        <asp:CustomValidator ID="custLandlineNumber" runat="server" CssClass="err-block err-bottom" ErrorMessage="Invalid Landline" Display="Dynamic" ControlToValidate="txtLandline" ValidationGroup="ValidationGroup" ForeColor="Red" ClientValidationFunction="ValidateLandlineOnSubmit"></asp:CustomValidator>
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
                                            <asp:TextBox CssClass="form-control" ID="txtWeight" runat="server" TabIndex="1" autocomplete="off" onkeyup="BMI();"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlWeightUnit" runat="server" TabIndex="2" onchange="BMI();">
                                                    <asp:ListItem Value="KG">Kg</asp:ListItem>
                                                    <asp:ListItem Value="LBS">Lbs</asp:ListItem>
                                                    <asp:ListItem Value="GRAM">Gram</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator13" runat="server" ErrorMessage="Measured Weight Required" Display="Dynamic" ControlToValidate="txtWeight" ValidationGroup="ValidationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator11" runat="server" ErrorMessage="Invalid Measured  Weight " Display="Dynamic" ControlToValidate="txtWeight" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

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

                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator14" runat="server" ErrorMessage="Weight Loss Month Required" Display="Dynamic" ControlToValidate="txtWeightLossMonth" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid Weight Loss Month" Display="Dynamic" ControlToValidate="txtWeightLossMonth" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>--%>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-3 control-label text-right">Measured Ht</label><label class="col-sm-1 control-label text-right" style="color: red">*</label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtHeight" runat="server" TabIndex="3" onkeyup="BMI();BodyFrame();IBW();"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:DropDownList CssClass="form-control" ID="ddlHeightUnit" runat="server" TabIndex="4" onchange="BMI();BodyFrame();IBW();">
                                                    <asp:ListItem Value="CM">Cm</asp:ListItem>
                                                    <asp:ListItem Value="INCH">Inch</asp:ListItem>
                                                    <asp:ListItem Value="FOOT">Foot</asp:ListItem>
                                                    <asp:ListItem Value="METER">Meter</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator15" runat="server" ErrorMessage="Measured Height Required" Display="Dynamic" ControlToValidate="txtHeight" ValidationGroup="ValidationGroup1" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator13" runat="server" ErrorMessage="Invalid Height" Display="Dynamic" ControlToValidate="txtHeight" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                       
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator14" runat="server" ErrorMessage="Invalid WeightLossSixMonths" Display="Dynamic" ControlToValidate="txtWeightLossSixMonths" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator16" runat="server" ErrorMessage="Invalid WeightLossYear" Display="Dynamic" ControlToValidate="txtWeightLossYear" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

                                    </div>
                                </div>--%>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Calculated BMI</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtBMI" runat="server" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator19" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator17" runat="server" ErrorMessage="Invalid BMI" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>



                                <div class="form-group col-sm-6 col-md-4 display">
                                    <label class="col-sm-4 control-label text-right">BMI Percentage</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtBMIPer" runat="server" TabIndex="5" autocomplete="off"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator12" runat="server" ErrorMessage="Invalid BMI Percentage" Display="Dynamic" ControlToValidate="txtBMIPer" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%-- <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="BMI Required" Display="Dynamic" ControlToValidate="txtBMI" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator14" runat="server" ErrorMessage="Invalid fat Percentage" Display="Dynamic" ControlToValidate="txtFatPer" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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

                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator20" runat="server" ErrorMessage="Neck Circumference Required" Display="Dynamic" ControlToValidate="txtNeck" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator18" runat="server" ErrorMessage="Invalid Neck Circumference" Display="Dynamic" ControlToValidate="txtNeck" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator20" runat="server" ErrorMessage="Invalid Measured Waist" Display="Dynamic" ControlToValidate="txtWaist" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator78" runat="server" ErrorMessage="Invalid Measured wrist" Display="Dynamic" ControlToValidate="txtwrist" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator21" runat="server" ErrorMessage="MUAC Required" Display="Dynamic" ControlToValidate="txtMUAC" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator19" runat="server" ErrorMessage="Invalid MUAC" Display="Dynamic" ControlToValidate="txtMUAC" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Blood Pressure </label>
                                    <div class="col-sm-8  control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtBloodPressure" runat="server" TabIndex="14" autocomplete="off" PlaceHolder="NN/NN"></asp:TextBox>
                                            <div class="input-group-addon">
                                                <asp:Label ID="Label14" Text="mmHg" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator23" runat="server" ErrorMessage="Blood Pressure Required" Display="Dynamic" ControlToValidate="txtBloodPressure" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator21" runat="server" ErrorMessage="Invalid BloodPressure" Display="Dynamic" ControlToValidate="txtBloodPressure" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^\d{1,3}\/\d{1,3}$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Body Frame</label>
                                    <div class="col-sm-8  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtBodyFrame" runat="server" autocomplete="off" onchange="IBW();"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator2" runat="server" ErrorMessage="MUAC Required" Display="Dynamic" ControlToValidate="txtMUAC" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator16" runat="server" ErrorMessage="Invalid BodyFrame" Display="Dynamic" ControlToValidate="txtBodyFrame" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>--%>
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
                                        <%--    <asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator17" runat="server" ErrorMessage="Ideal Body Weight Required" Display="Dynamic" ControlToValidate="txtIdealWeight" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator15" runat="server" ErrorMessage="Invalid Ideal Weight" Display="Dynamic" ControlToValidate="txtIdealWeight" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>--%>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator24" runat="server" ErrorMessage="Weight Gain Month Required" Display="Dynamic" ControlToValidate="txtWeightGainMonth" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator22" runat="server" ErrorMessage="Invalid WeightGainMonth" Display="Dynamic" ControlToValidate="txtWeightGainLossMonth" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^([+-]{1,1})\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator25" runat="server" ErrorMessage="Weight Gain Six Month Required" Display="Dynamic" ControlToValidate="txtWeightGainSixMonth" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator23" runat="server" ErrorMessage="Invalid WeightGainSixMonth" Display="Dynamic" ControlToValidate="txtWeightGainLossSixMonth" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^([+-]{1,1})\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator26" runat="server" ErrorMessage="Weight Gain year Required" Display="Dynamic" ControlToValidate="txtweightGainYear" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator24" runat="server" ErrorMessage="Invalid weightGainYear" Display="Dynamic" ControlToValidate="txtweightGainLossYear" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^([+-]{1,1})\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>

                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-2 control-label text-right">Reason for WT gain / loss</label>
                                    <div class="col-sm-10  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtReason" runat="server" TextMode="MultiLine" Width="100%" TabIndex="25" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator27" runat="server" ErrorMessage="Antropometrics Notes Required" Display="Dynamic" ControlToValidate="txtNotes2" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator63" runat="server" ErrorMessage="Invalid Reason" Display="Dynamic" ControlToValidate="txtReason" ValidationGroup="ValidationGroup1" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11  control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes2" runat="server" TextMode="MultiLine" Width="100%" TabIndex="26" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator27" runat="server" ErrorMessage="Antropometrics Notes Required" Display="Dynamic" ControlToValidate="txtNotes2" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator25" runat="server" ErrorMessage="Invalid Antropometrics Notes" Display="Dynamic" ControlToValidate="txtNotes2" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnAnthro" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup1" OnClick="btnAnthro_Click" />
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-12 control-block">
                                        <asp:ValidationSummary ID="ValAntro"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true" ValidationGroup="ValidationGroup1" runat="server" CssClass="alert alert-danger padd" />
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator28" runat="server" ErrorMessage="Fasting Glucose Required" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator26" runat="server" ErrorMessage="Invalid Fasting Glucose" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator28" runat="server" ErrorMessage="Fasting Glucose Required" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator65" runat="server" ErrorMessage="Invalid PP" Display="Dynamic" ControlToValidate="txtPP" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator28" runat="server" ErrorMessage="Fasting Glucose Required" Display="Dynamic" ControlToValidate="txtGlucose" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator66" runat="server" ErrorMessage="Invalid HB" Display="Dynamic" ControlToValidate="txtHB" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator30" runat="server" ErrorMessage="Creatinine  Required" Display="Dynamic" ControlToValidate="txtCreatinine" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator28" runat="server" ErrorMessage="Invalid Creatinine" Display="Dynamic" ControlToValidate="txtCreatinine" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator32" runat="server" ErrorMessage="Albumin  Required" Display="Dynamic" ControlToValidate="txtAlbumin" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator30" runat="server" ErrorMessage="Invalid Albumin" Display="Dynamic" ControlToValidate="txtAlbumin" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                    <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator34" runat="server" ErrorMessage="Hba1c  Required" Display="Dynamic" ControlToValidate="txtHba1c" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator32" runat="server" ErrorMessage="Invalid Hba1c" Display="Dynamic" ControlToValidate="txtHba1c" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator36" runat="server" ErrorMessage="Altsgpt  Required" Display="Dynamic" ControlToValidate="txtAltsgpt" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator34" runat="server" ErrorMessage="Invalid Altsgpt" Display="Dynamic" ControlToValidate="txtAltsgpt" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator38" runat="server" ErrorMessage="Altsgot  Required" Display="Dynamic" ControlToValidate="txtAltsgot" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator36" runat="server" ErrorMessage="Invalid Altsgot" Display="Dynamic" ControlToValidate="txtAltsgot" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator39" runat="server" ErrorMessage="Hematocrit  Required" Display="Dynamic" ControlToValidate="txtHematocrit" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator37" runat="server" ErrorMessage="Invalid Hematocrit" Display="Dynamic" ControlToValidate="txtHematocrit" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator40" runat="server" ErrorMessage="Triglycerides  Required" Display="Dynamic" ControlToValidate="txtTriglycerides" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator38" runat="server" ErrorMessage="Invalid Triglycerides" Display="Dynamic" ControlToValidate="txtTriglycerides" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator67" runat="server" ErrorMessage="Invalid TSH" Display="Dynamic" ControlToValidate="txtTsh" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator39" runat="server" ErrorMessage="Invalid Hdl" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator68" runat="server" ErrorMessage="Invalid LDL" Display="Dynamic" ControlToValidate="txtLDL" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator41" runat="server" ErrorMessage="Hdl  Required" Display="Dynamic" ControlToValidate="txtHdl" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator69" runat="server" ErrorMessage="Invalid UricAcid" Display="Dynamic" ControlToValidate="txtUricAcid" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator29" runat="server" ErrorMessage="Cholesterol  Required" Display="Dynamic" ControlToValidate="txtCholesterol" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator27" runat="server" ErrorMessage="Invalid Cholesterol" Display="Dynamic" ControlToValidate="txtCholesterol" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator31" runat="server" ErrorMessage="Alkaline  Required" Display="Dynamic" ControlToValidate="txtAlkaline" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator29" runat="server" ErrorMessage="Invalid Alkaline" Display="Dynamic" ControlToValidate="txtAlkaline" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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
                                    <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator33" runat="server" ErrorMessage="Vitamind3  Required" Display="Dynamic" ControlToValidate="txtVitamind3" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator31" runat="server" ErrorMessage="Invalid Vitamind3" Display="Dynamic" ControlToValidate="txtVitamind3" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">VitaminB12</label>
                                    <div class="col-sm-8 control-block">
                                        <div class="input-group">
                                            <asp:TextBox CssClass="form-control" ID="txtVitaminb12" runat="server" TabIndex="19" autocomplete="off" placeholder="Normal"></asp:TextBox>

                                            <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator33" runat="server" ErrorMessage="Invalid Vitaminb12" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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

                                            <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                            <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator70" runat="server" ErrorMessage="Invalid Random Bsl" Display="Dynamic" ControlToValidate="txtRandomBsl" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
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

                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator71" runat="server" ErrorMessage="Invalid Rbc" Display="Dynamic" ControlToValidate="txtRbc" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-4">
                                    <label class="col-sm-4 control-label text-right">Platelet Count</label>
                                    <div class="col-sm-8 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtPlatelet" runat="server" TabIndex="22" autocomplete="off" placeholder="Normal"></asp:TextBox>

                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator35" runat="server" ErrorMessage="Vitaminb12  Required" Display="Dynamic" ControlToValidate="txtVitaminb12" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator72" runat="server" ErrorMessage="Invalid Platelet Count" Display="Dynamic" ControlToValidate="txtPlatelet" ValidationGroup="ValidationGroup2" ForeColor="Red" ValidationExpression="^\d+(\.\d{1,2})?$"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group col-sm-6 col-md-8">
                                    <label class="col-sm-2 control-label text-right">Others</label>
                                    <div class="col-sm-10 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtOthers" runat="server" TabIndex="23" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator37" runat="server" ErrorMessage="Others  Required" Display="Dynamic" ControlToValidate="txtOthers" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%--<asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator35" runat="server" ErrorMessage="Invalid Others" Display="Dynamic" ControlToValidate="txtOthers" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>


                                <div class="form-group col-sm-6 col-md-12">
                                    <label class="col-sm-1 control-label text-right">Notes</label>
                                    <div class="col-sm-11 control-block">
                                        <asp:TextBox CssClass="form-control" ID="txtNotes3" runat="server" TextMode="MultiLine" Width="100%" TabIndex="24" autocomplete="off"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator CssClass="err-block" ID="RequiredFieldValidator42" runat="server" ErrorMessage="Biochemical Notes  Required" Display="Dynamic" ControlToValidate="txtNotes3" ValidationGroup="ValidationGroup" ForeColor="Red" Text="*"></asp:RequiredFieldValidator>--%>
                                        <%-- <asp:RegularExpressionValidator CssClass="err-block err-bottom" ID="RegularExpressionValidator40" runat="server" ErrorMessage="Invalid Biochemical Notes" Display="Dynamic" ControlToValidate="txtNotes3" ValidationGroup="ValidationGroup" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9''-'\s]{1,100}$"></asp:RegularExpressionValidator>--%>
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center"></div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnBio" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="true" ValidationGroup="ValidationGroup2" OnClick="btnBio_Click" />
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-12 control-block">
                                        <asp:ValidationSummary ID="ValBio"
                                            DisplayMode="BulletList"
                                            EnableClientScript="true" ValidationGroup="ValidationGroup2" runat="server" CssClass="alert alert-danger padd" />
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
                                    <label class="col-sm-4 control-label text-right">Thyroid Type</label>
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
                                    </div>
                                </div>
                                <div class="form-group col-sm-6 col-md-12 padd">
                                    <div class="col-sm-5 control-block align-center">
                                        <asp:HiddenField ID="hdnDHID" runat="server" />
                                        <asp:HiddenField ID="hdnMCID" runat="server" />
                                        <asp:HiddenField ID="hdnGPID" runat="server" />
                                    </div>
                                    <div class="col-sm-2 control-block align-center">
                                        <asp:Button runat="server" ID="btnComorbidity" Text="Save" CssClass="btn btn-primary btn-lg btn-block" CausesValidation="false" OnClick="btnComorbidity_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="margin-top: 2px">
                        <div class="col-md-5 align-center"></div>
                        <div class="col-md-2 align-center">
                            <asp:Button runat="server" ID="btnSave" Text="Save All" CssClass="btn btn-primary btn-lg btn-block" OnClick="btnSave_Click" CausesValidation="true" ValidationGroup="ValidationGroup" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
