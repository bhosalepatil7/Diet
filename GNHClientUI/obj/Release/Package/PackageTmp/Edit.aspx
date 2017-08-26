<%@ Page Language="C#" AutoEventWireup="true" Inherits="Edit" %>

<% if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "0")
   {
       evr = GetCalendarDetailsByEventId(Request.QueryString["id"].ToString());
   }
   else
   {

       evr = GetCalendarDetailsForNewEvent(Convert.ToString(Request.QueryString["start"] ?? DateTime.UtcNow.AddHours(5.5).ToString()), Convert.ToString(Request.QueryString["end"] ?? DateTime.UtcNow.AddHours(5.5).ToString()));
       //evr = GetCalendarDetailsForNewEvent(Request.QueryString["start"].ToString(), Request.QueryString["end"].ToString());
   }
%>

<%--<?php
include_once("php/dbconfig.php");
include_once("php/functions.php");
function getCalendarByRange($id){
  try{
    $db = new DBConnection();
    $db->getConnection();
    $sql = "select * from `jqcalendar` where `id` = " . $id;
    $handle = mysql_query($sql);
    //echo $sql;
    $row = mysql_fetch_object($handle);
	}catch(Exception $e){
  }
  return $row;
}
if($_GET["id"]){
  $event = getCalendarByRange($_GET["id"]);
}
?>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8">
    <title>Calendar Details</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/dp.css" rel="stylesheet" />
    <link href="css/dropdown.css" rel="stylesheet" />
    <link href="css/colorselect.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.4/jquery-ui.css"/>
    
    <%--<script src="src/jquery.js" type="text/javascript"><script>--%>
    <script src="Scripts/jquery-1.12.0.js" type="text/javascript"></script>
    <script src="https://code.jquery.com/jquery-migrate-1.3.0.min.js" type="text/javascript"></script>
    <%--<script src="http://code.jquery.com/ui/1.8.22/jquery-ui.js" type="text/javascript"></script>--%>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
     
    
    <link href="Scripts/jquery-ui.css" rel="stylesheet" />
    <script src="src/Plugins/Common.js" type="text/javascript"></script>
    <script src="src/Plugins/jquery.form.js" type="text/javascript"></script>
    <script src="src/Plugins/jquery.validate.js" type="text/javascript"></script>
    <script src="src/Plugins/datepicker_lang_US.js" type="text/javascript"></script>
    <script src="src/Plugins/jquery.datepicker.js" type="text/javascript"></script>
    <script src="src/Plugins/jquery.dropdown.js" type="text/javascript"></script>
    <script src="src/Plugins/jquery.colorselect.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        if (!DateAdd || typeof (DateDiff) != "function") {
            var DateAdd = function (interval, number, idate) {
                number = parseInt(number);
                var date;
                if (typeof (idate) == "string") {
                    date = idate.split(/\D/);
                    eval("var date = new Date(" + date.join(",") + ")");
                }
                if (typeof (idate) == "object") {
                    date = new Date(idate.toString());
                }
                switch (interval) {
                    case "y": date.setFullYear(date.getFullYear() + number); break;
                    case "m": date.setMonth(date.getMonth() + number); break;
                    case "d": date.setDate(date.getDate() + number); break;
                    case "w": date.setDate(date.getDate() + 7 * number); break;
                    case "h": date.setHours(date.getHours() + number); break;
                    case "n": date.setMinutes(date.getMinutes() + number); break;
                    case "s": date.setSeconds(date.getSeconds() + number); break;
                    case "l": date.setMilliseconds(date.getMilliseconds() + number); break;
                }
                return date;
            }
        }
        function getHM(date) {
            var hour = date.getHours();
            var minute = date.getMinutes();
            var ret = (hour > 9 ? hour : "0" + hour) + ":" + (minute > 9 ? minute : "0" + minute);
            return ret;
        }
        $(document).ready(function () {
            //debugger;
            var DATA_FEED_URL = "CalService.svc/DataFeed";
            var arrT = [];
            var tt = "{0}:{1}";
            for (var i = 0; i < 24; i++) {
                arrT.push({ text: StrFormat(tt, [i >= 10 ? i : "0" + i, "00"]) }, { text: StrFormat(tt, [i >= 10 ? i : "0" + i, "30"]) });
            }
            $("#timezone").val(new Date().getTimezoneOffset() / 60 * -1);
            $("#stparttime").dropdown({
                dropheight: 200,
                dropwidth: 60,
                selectedchange: function (item) {
                    // set end time to 30 minutes by default
                    debugger;
                    var stTime = item.text.split(':');
                    var etTime;
                    if (stTime[1] == "00") {
                        etTime = stTime[0] + ":30";
                    }
                    else {
                        var etHour = parseInt(stTime[0]) + 1;
                        if (etHour < 10)
                        {
                            etHour = "0" + etHour;
                        }
                        etTime = etHour + ":00";
                    }

                    if (item.text == "23:30")  // if last value in dropdown selected
                    {
                        etTime = "00:00";
                    }

                    $("#etparttime").val(etTime);
                },
                items: arrT
            });
            $("#etparttime").dropdown({
                dropheight: 200,
                dropwidth: 60,
                selectedchange: function () { },
                items: arrT
            });
            var check = $("#IsAllDayEvent").click(function (e) {
                if (this.checked) {
                    $("#stparttime").val("00:00").hide();
                    $("#etparttime").val("00:00").hide();
                }
                else {
                    var d = new Date();
                    var p = 60 - d.getMinutes();
                    if (p > 30) p = p - 30;
                    d = DateAdd("n", p, d);
                    $("#stparttime").val(getHM(d)).show();
                    $("#etparttime").val(getHM(DateAdd("h", 1, d))).show();
                }
            });
            if (check[0].checked) {
                $("#stparttime").val("00:00").hide();
                $("#etparttime").val("00:00").hide();
            }


            $("#Savebtn").click(function () {
                debugger;
                $("#etpartdate").val($("#stpartdate").val());   //since startdate and enddate going to remain same as per new requirement
                $("#fmEdit").submit();
            });
            $("#Closebtn").click(function () { CloseModelWindow(); });
            $("#Deletebtn").click(function () {
                if (confirm("Are you sure to remove this event")) {
                    var CalendarId = ($("#hdnCalendarID").val() != null)?($("#hdnCalendarID").val()):-1;
                    var param = [{ "name": "calendarId", value: CalendarId }];
                    $.post(DATA_FEED_URL + "?method=remove",
                        param,
                        function (data) {
                            debugger;
                            //alert(data.Msg);  //Add or edit success status
                            $("#loadingpannel").html(data.Msg).show();
                            if (data.IsSuccess) {
                                window.setTimeout(function () {
                                    $("#loadingpannel").hide();
                                    CloseModelWindow(null, true);
                                }, 2000);
                            }
                        }
                    , "json");
                }
            });

            //$("#stpartdate,#etpartdate").datepicker({ picker: "<button class='calpick'></button>" });  //commented since no more required
            $("#stpartdate").datepicker({ picker: "<button class='calpick'></button>" });
            var cv = $("#colorvalue").val();
            if (cv == "") {
                cv = "-1";
            }
            $("#calendarcolor").colorselect({ title: "Color", index: cv, hiddenid: "colorvalue" });
            //to define parameters of ajaxform
            var options = {
                beforeSubmit: function () {
                    return true;
                },
                dataType: "json",
                success: function (data) {
                    debugger;
                    //alert(data.Msg);  //Add or edit success status
                    $("#loadingpannel").html(data.Msg).show();
                    if (data.IsSuccess) {
                        window.setTimeout(function () {
                            $("#loadingpannel").hide();
                            CloseModelWindow(null, true);
                        }, 2000);
                    }
                }
            };
            $.validator.addMethod("date", function (value, element) {
                var arrs = value.split(i18n.datepicker.dateformat.separator);
                var year = arrs[i18n.datepicker.dateformat.year_index];
                var month = arrs[i18n.datepicker.dateformat.month_index];
                var day = arrs[i18n.datepicker.dateformat.day_index];
                var standvalue = [year, month, day].join("-");
                return this.optional(element) || /^(?:(?:1[6-9]|[2-9]\d)?\d{2}[\/\-\.](?:0?[1,3-9]|1[0-2])[\/\-\.](?:29|30))(?: (?:0?\d|1\d|2[0-3])\:(?:0?\d|[1-5]\d)\:(?:0?\d|[1-5]\d)(?: \d{1,3})?)?$|^(?:(?:1[6-9]|[2-9]\d)?\d{2}[\/\-\.](?:0?[1,3,5,7,8]|1[02])[\/\-\.]31)(?: (?:0?\d|1\d|2[0-3])\:(?:0?\d|[1-5]\d)\:(?:0?\d|[1-5]\d)(?: \d{1,3})?)?$|^(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])[\/\-\.]0?2[\/\-\.]29)(?: (?:0?\d|1\d|2[0-3])\:(?:0?\d|[1-5]\d)\:(?:0?\d|[1-5]\d)(?: \d{1,3})?)?$|^(?:(?:16|[2468][048]|[3579][26])00[\/\-\.]0?2[\/\-\.]29)(?: (?:0?\d|1\d|2[0-3])\:(?:0?\d|[1-5]\d)\:(?:0?\d|[1-5]\d)(?: \d{1,3})?)?$|^(?:(?:1[6-9]|[2-9]\d)?\d{2}[\/\-\.](?:0?[1-9]|1[0-2])[\/\-\.](?:0?[1-9]|1\d|2[0-8]))(?: (?:0?\d|1\d|2[0-3])\:(?:0?\d|[1-5]\d)\:(?:0?\d|[1-5]\d)(?:\d{1,3})?)?$/.test(standvalue);
            }, "Invalid date format");
            $.validator.addMethod("time", function (value, element) {
                return this.optional(element) || /^([0-1]?[0-9]|2[0-3]):([0-5][0-9])$/.test(value);
            }, "Invalid time format");
            $.validator.addMethod("safe", function (value, element) {
                return this.optional(element) || /^[^$\<\>]+$/.test(value);
            }, "$<> not allowed");
            $("#fmEdit").validate({
                submitHandler: function (form) { $("#fmEdit").ajaxSubmit(options); },
                errorElement: "div",
                errorClass: "cusErrorPanel",
                errorPlacement: function (error, element) {
                    showerror(error, element);
                }
            });
            function showerror(error, target) {
                var pos = target.position();
                var height = target.height();
                var newpos = { left: pos.left, top: pos.top + height + 2 }
                var form = $("#fmEdit");
                error.appendTo(form).css(newpos);
            }
        });
    </script>

    <style type="text/css">
        .calpick {
            width: 16px;
            height: 16px;
            border: none;
            cursor: pointer;
            background: url("css/images/calendar/cal.gif") no-repeat center 2px;
            margin-left: -22px;
        }
    </style>
</head>
<body>
    <div>
        <div class="toolBotton">
            <a id="Savebtn" class="imgbtn" href="javascript:void(0);">
                <span class="Save" title="Save the calendar">Save(<u>S</u>)
                </span>
            </a>
            <%--<?php if(isset($event)){ ?>--%>
            <% if (evr != null)
               {%>
            <a id="Deletebtn" class="imgbtn" href="javascript:void(0);">
                <span class="Delete" title="Cancel the calendar">Delete(<u>D</u>)
                </span>
            </a>
            <% } %>
            <%--<?php } ?>     --%>
            <a id="Closebtn" class="imgbtn" href="javascript:void(0);">
                <span class="Close" title="Close the window">Close
                </span></a>
            </a>
            <div id="loadingpannel" style="background:#c44;color:#fff;position: absolute;top: 3px;right: 15px;height: 18px;padding: 1px 2px 1px 2px;font-weight: normal;display: none;"></div>        
        </div>
        <div style="clear: both">
        </div>
        <div class="infocontainer">
            <form action="CalService.svc/DataFeed?method=adddetails<%= (evr != null)?"&id=" + evr.Id:"" %>" class="fform" id="fmEdit" method="post">
                <label>
                    <span>*Name:              
                    </span>
                    <div id="calendarcolor">
                    </div>
                    <input maxlength="200" class="required safe NameCon autosuggest" id="Subject"  name="Subject" style="width: 85%;" type="text" value="<%= (evr != null)?(evr.Subject != null)?evr.Subject:String.Empty:string.Empty %>" />
                    <input id="hdnUserID" name="hdnUserID" type="hidden" value="<%= (evr != null)?(evr.CustomerID != 0)?evr.CustomerID:0:0 %>" />
                    <input id="hdnCalendarID" name="hdnCalendarID" type="hidden" value="<%= (evr != null)?(evr.Id != 0)?evr.Id:0:0 %>" />
                    <input id="colorvalue" name="colorvalue" type="hidden" value="<%= (evr != null)?(evr.Color != -1)?evr.Color:-1:-1 %>" />
                </label>
                <label>
                    <span>*Time:
                    </span>
                    <div>
                        <%--<?php if(isset($event)){
                  $sarr = explode(" ", php2JsTime(mySql2PhpTime($event->StartTime)));
                  $earr = explode(" ", php2JsTime(mySql2PhpTime($event->EndTime)));
              }?>         --%>
                        <input maxlength="10" class="required date" id="stpartdate" name="stpartdate" style="padding-left: 2px; width: 90px;" type="text" value="<%= (evr != null)?(evr.StartDate.GetHashCode() != 0)?evr.StartDate.Substring(0,evr.StartDate.IndexOf("|")):String.Empty:string.Empty %>" />&nbsp;&nbsp;&nbsp;From
                        <input maxlength="5" class="required time" id="stparttime" name="stparttime" style="width: 40px;" type="text" value="<%= (evr != null)?(evr.StartDate.GetHashCode() != 0)?evr.StartDate.Substring(evr.StartDate.IndexOf("|")+1,5):String.Empty:string.Empty %>" /> To                       
                        <%--<input maxlength="10" class="required date" id="etpartdate" name="etpartdate" style="padding-left: 2px; width: 90px;" type="text" value="<%= (evr != null)?(evr.EndDate.GetHashCode()!=0)?evr.EndDate.Substring(0,evr.EndDate.IndexOf("|")):String.Empty:string.Empty %>" />--%>
                        <input maxlength="10" id="etpartdate" name="etpartdate" style="padding-left: 2px; width: 90px;display:none;" type="text" value="<%= (evr != null)?(evr.EndDate.GetHashCode()!=0)?evr.EndDate.Substring(0,evr.EndDate.IndexOf("|")):String.Empty:string.Empty %>" />
                        <input maxlength="50" class="required time" id="etparttime" name="etparttime" style="width: 40px;" type="text" value="<%= (evr != null)?(evr.EndDate.GetHashCode() != 0)?evr.EndDate.Substring(evr.EndDate.IndexOf("|")+1,5):String.Empty:string.Empty %>" />
                        <label class="checkp" style="display:none;">
                            <input id="IsAllDayEvent" name="IsAllDayEvent" type="checkbox"  value="1" <%= (evr != null)?(evr.IsAllDayEvent!=0)?"checked":string.Empty:string.Empty %> />
                            All Day Event                      
                        </label>
                    </div>
                </label>
                <label style="display:none;">
                    <span>Address:
                    </span>
                    <input maxlength="200" id="Location" name="Location" style="width: 95%;" type="text" value="<%= (evr != null)?(evr.Location != null)?evr.Location:String.Empty:string.Empty %>" />
                </label>
                <label>
                    <span>Notes:
                    </span>
                    <textarea cols="20" id="Description" name="Description" rows="2" style="width: 95%; height: 70px">
<%= (evr != null)?(evr.Description != null)?evr.Description:String.Empty:string.Empty %>
</textarea>
                </label>
                <input id="timezone" name="timezone" type="hidden" value="" />
            </form>
        </div>
    </div>

    <%--<script type="text/javascript" src="Scripts/jquery-ui.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            
            $("#Subject").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Edit.aspx/GetEmployeeName",
                        data: "{'empName':'" + $('#Subject').val() + "'}",
                        dataType: "json",
                        success: function (data)
                        {
                            //alert(data.d);
                            response((data.d).map(function (value)
                            {
                                return {
                                    label: value.split('/')[0],
                                    val: value.split('/')[1]
                                }
                            }))
                        },
                        error: function (result)
                        { alert(result); }
                    });
                },
                select:function(event,ui)
                {
                    debugger;
                    $('#hdnUserID').val(ui.item.val);
                    $("#Subject").val(ui.item.label.split('~')[0].trim());
                    return false;
                }
            });
           
        });
    </script>
</body>
</html>
