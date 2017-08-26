using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

//namespace GNHClientUI
//{
[ServiceContract(Namespace = "")]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class CalService
{
    string connDietDB = ConfigurationManager.ConnectionStrings["connDietDB"].ConnectionString.ToString();

    [OperationContract]
    // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
    public CalendarData GetCalData()
    {
        WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

        List<Event> _events = new List<Event>()
            {
                new Event(){Id = 1,
                           Subject = "Test",
                           StartDate = JSDateTime.ToStr(DateTime.UtcNow.AddHours(5.5).Date),
                           EndDate =  JSDateTime.ToStr(DateTime.UtcNow.AddHours(5.5).Date.AddHours(11)),
                           IsAllDayEvent = 1,
                           IsEditable = 1,
                           IsMoreThanOneDayEvent =0,
                           Attendents ="",
                           Location="Noida",
                           RecurringEvent = 0,
                           Color = 2},

                  new Event(){Id = 2,
                           Subject = "More Test",
                           StartDate =  JSDateTime.ToStr( DateTime.UtcNow.AddHours(5.5).Date.AddDays(1)),
                           EndDate =  JSDateTime.ToStr(DateTime.UtcNow.AddHours(5.5).Date.AddHours(45)),
                           IsAllDayEvent = 1,
                           IsEditable = 1,
                           IsMoreThanOneDayEvent =0,
                           Attendents ="",
                           Location="Delhi",
                           RecurringEvent = 0,
                           Color = 4}
            
            };


        CalendarData objCalData = new CalendarData();
        objCalData.events = new List<ArrayList>();

        foreach (var item in _events)
        {
            objCalData.events.Add(ConvertToArrayList<Event>(item));
        }

        objCalData.issort = true;
        objCalData.start = JSDateTime.ToStr(new DateTime(2013, 7, 1));
        objCalData.end = JSDateTime.ToStr(new DateTime(2013, 7, 31));
        objCalData.error = null;
        return objCalData;

    }

    [OperationContract]
    // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
    public void AddCalData(Stream input)
    {
        string meth = HttpContext.Current.Request.QueryString["method"].ToString();
        string body = new StreamReader(input).ReadToEnd();
        NameValueCollection nvc = System.Web.HttpUtility.ParseQueryString(body);

        using (SqlConnection conn = new SqlConnection(connDietDB))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "insert into dbo.jqcalendar(Subject,StartTime,EndTime,IsAllDayEvent,CustID,SessionCode) values(@Subject,@StartTime,@EndTime,@IsAllDayEvent,@CustID,@SessionCode)";
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = nvc.Get("Subject").ToString();
                cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = (nvc.Get("stpartdate").ToString() != null) ? DateTime.UtcNow.AddHours(5.5) : DateTime.UtcNow.AddHours(5.5);
                cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = (nvc.Get("etpartdate").ToString() != null) ? DateTime.UtcNow.AddHours(5.5) : DateTime.UtcNow.AddHours(5.5);
                cmd.Parameters.Add("@IsAllDayEvent", SqlDbType.SmallInt).Value = Convert.ToInt16(nvc.Get("IsAllDayEvent").ToString());
                cmd.Parameters.Add("@SessionCode", SqlDbType.NVarChar).Value = Convert.ToString(HttpContext.Current.Session["UserCode"]);
                cmd.Parameters.Add("@CustID", SqlDbType.BigInt).Value = Convert.ToInt64(nvc.Get("hdnUserID").ToString());

                cmd.ExecuteNonQuery();

                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
    }

    [OperationContract]
    // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
    public void UpdateCalData(Stream input)
    {
        string body = new StreamReader(input).ReadToEnd();
        NameValueCollection nvc = System.Web.HttpUtility.ParseQueryString(body);
    }

    [OperationContract]
    // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
    public void RemoveCalData(Stream input)
    {
        string body = new StreamReader(input).ReadToEnd();
        NameValueCollection nvc = System.Web.HttpUtility.ParseQueryString(body);
    }


    [OperationContract]
    // [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
    public CalendarData DataFeed(Stream input)
    {
        WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");

        string body = new StreamReader(input).ReadToEnd();
        NameValueCollection nvc = System.Web.HttpUtility.ParseQueryString(body);



        string meth = (HttpContext.Current.Request.QueryString["method"] != null) ? HttpContext.Current.Request.QueryString["method"].ToString() : "";
        string id = (HttpContext.Current.Request.QueryString["id"] != null) ? HttpContext.Current.Request.QueryString["id"].ToString() : "";

        string calendarId, calendarStartTime, calendarEndTime, calendarTitle, isAllDayEvent, customerID;
        string showDate, viewType;
        string stpartdate, stparttime, etpartdate, etparttime, subject, description, location, colorValue, timeZone;

        CalendarData objCalData = new CalendarData();


        switch (meth)
        {
            case "add":
                calendarStartTime = HttpContext.Current.Server.UrlDecode(nvc.Get("CalendarStartTime").ToString());
                calendarEndTime = HttpContext.Current.Server.UrlDecode(nvc.Get("CalendarEndTime").ToString());
                calendarTitle = HttpContext.Current.Server.UrlDecode(nvc.Get("CalendarTitle").ToString());
                isAllDayEvent = HttpContext.Current.Server.UrlDecode(nvc.Get("IsAllDayEvent").ToString());

                objCalData = addCalendar(calendarStartTime, calendarEndTime, calendarTitle, isAllDayEvent);
                break;

            case "list":
                showDate = HttpContext.Current.Server.UrlDecode(nvc.Get("showdate").ToString());
                viewType = HttpContext.Current.Server.UrlDecode(nvc.Get("viewtype").ToString());
                objCalData = listCalendar(showDate, viewType);
                break;

            case "update":
                calendarId = HttpContext.Current.Server.UrlDecode(nvc.Get("calendarId").ToString());
                calendarStartTime = HttpContext.Current.Server.UrlDecode(nvc.Get("CalendarStartTime").ToString());
                calendarEndTime = HttpContext.Current.Server.UrlDecode(nvc.Get("CalendarEndTime").ToString());
                objCalData = updateCalendar(calendarId, calendarStartTime, calendarEndTime);
                break;

            case "remove":
                calendarId = HttpContext.Current.Server.UrlDecode(nvc.Get("calendarId").ToString());
                objCalData = removeCalendar(calendarId);
                break;

            case "adddetails":
                stpartdate = HttpContext.Current.Server.UrlDecode(nvc.Get("stpartdate").ToString());
                stparttime = HttpContext.Current.Server.UrlDecode(nvc.Get("stparttime").ToString());
                etpartdate = HttpContext.Current.Server.UrlDecode(nvc.Get("etpartdate").ToString());
                etparttime = HttpContext.Current.Server.UrlDecode(nvc.Get("etparttime").ToString());
                isAllDayEvent = HttpContext.Current.Server.UrlDecode((nvc.AllKeys.Contains("IsAllDayEvent")) ? "1" : "0");
                description = HttpContext.Current.Server.UrlDecode(nvc.Get("Description").ToString());
                location = HttpContext.Current.Server.UrlDecode(nvc.Get("Location").ToString());
                colorValue = HttpContext.Current.Server.UrlDecode(nvc.Get("colorvalue").ToString());
                timeZone = HttpContext.Current.Server.UrlDecode(nvc.Get("timezone").ToString());
                subject = HttpContext.Current.Server.UrlDecode(nvc.Get("Subject").ToString());
                customerID = HttpContext.Current.Server.UrlDecode(nvc.Get("hdnUserID").ToString());

                if (id != "")
                {
                    objCalData = updateDetailedCalendar(id, stpartdate + " " + stparttime, etpartdate + " " + etparttime, subject, isAllDayEvent, description, location, colorValue, timeZone, customerID);
                }
                else
                {
                    objCalData = addDetailedCalendar(id, stpartdate + " " + stparttime, etpartdate + " " + etparttime, subject, isAllDayEvent, description, location, colorValue, timeZone, customerID);
                }

                break;

            default:
                break;
        }

        return objCalData;



    }

    public CalendarData listCalendar(string day, string type)
    {
        DateTime showday = Convert.ToDateTime(day);
        DateTime startDate, endDate;
        startDate = new DateTime(2013, 7, 1);
        endDate = new DateTime(2013, 7, 31);
        switch (type)
        {
            case "month":
                startDate = new DateTime(showday.Year, showday.Month, 1);
                endDate = new DateTime(showday.Year, showday.Month, DateTime.DaysInMonth(showday.Year, showday.Month));
                break;
            case "week":
                int delta = DayOfWeek.Monday - showday.DayOfWeek;
                if (delta > 0)
                    delta -= 7;
                startDate = showday.AddDays(delta);     //startDate as monday
                endDate = startDate.AddDays(7);
                break;
            case "day":
                startDate = showday;
                endDate = showday.AddDays(1);
                break;
            default:
                break;
        }
        return listCalendarByRange(startDate, endDate);
    }

    public CalendarData listCalendarByRange(DateTime sd, DateTime ed)
    {
        CalendarData objCalData = new CalendarData();
        objCalData.events = new List<ArrayList>();

        try
        {

            List<Event> _events = new List<Event>();


            using (SqlConnection conn = new SqlConnection(connDietDB))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.jqcalendar where StartTime between @StartTime and @EndTime and SessionCode in " +
                                    "(select ISNULL(PARENT_ID,'') from admin_maps_user_master k where USER_NAME='" + Convert.ToString(HttpContext.Current.Session["UserCode"]) + "'  UNION 	select Isnull(USER_NAME,'') from admin_maps_user_master k where PARENT_ID='" + Convert.ToString(HttpContext.Current.Session["UserCode"]) + "' UNION SELECT '" + Convert.ToString(HttpContext.Current.Session["UserCode"]) + "')";

                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = sd;
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = ed;

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                DateTime startDate = Convert.ToDateTime(row["StartTime"].ToString());
                                DateTime endDate = Convert.ToDateTime(row["EndTime"].ToString());

                                Event _event = new Event();

                                _event.Id = Convert.ToInt32(row["Id"].ToString());
                                _event.Subject = row["Subject"].ToString();
                                _event.StartDate = JSDateTime.ToStr(startDate);
                                _event.EndDate = JSDateTime.ToStr(endDate);
                                _event.Location = row["Location"].ToString();
                                _event.Description = row["Description"].ToString();
                                _event.IsAllDayEvent = Convert.ToInt16(row["IsAllDayEvent"].ToString());
                                _event.IsEditable = 1;
                                _event.IsMoreThanOneDayEvent = 0;
                                _event.Attendents = "";
                                _event.RecurringEvent = 0;
                                _event.Color = Convert.ToInt16((row["Color"].ToString() != "") ? row["Color"].ToString() : "-1");
                                _event.CustomerID = Convert.ToInt64((row["CustID"].ToString() != "") ? row["CustID"].ToString() : "0");
                                _events.Add(_event);
                                _event = null;
                            }
                        }
                    }

                }
            }


            foreach (var item in _events)
            {
                objCalData.events.Add(ConvertToArrayList<Event>(item));
            }

            objCalData.issort = true;
            objCalData.start = JSDateTime.ToStr(sd);
            objCalData.end = JSDateTime.ToStr(ed);
            objCalData.error = null;
        }
        catch (Exception ex)
        {
            objCalData.error = ex.Message;
        }


        return objCalData;
    }

    public CalendarData addCalendar(string st, string et, string sub, string ade)
    {
        CalendarData objCalData = new CalendarData();
        objCalData.events = new List<ArrayList>();

        try
        {
            using (SqlConnection conn = new SqlConnection(connDietDB))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "insert into dbo.jqcalendar(Subject,StartTime,EndTime,IsAllDayEvent) output INSERTED.Id values(@Subject,@StartTime,@EndTime,@IsAllDayEvent)";
                    cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = sub;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = (st != null) ? Convert.ToDateTime(st) : DateTime.UtcNow.AddHours(5.5);
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = (et != null) ? Convert.ToDateTime(et) : DateTime.UtcNow.AddHours(5.5);
                    cmd.Parameters.Add("@IsAllDayEvent", SqlDbType.SmallInt).Value = Convert.ToInt16(ade);

                    objCalData.Data = cmd.ExecuteScalar().ToString();

                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            objCalData.IsSuccess = true;
            objCalData.Msg = "add success";
            objCalData.error = null;
        }
        catch (Exception ex)
        {
            objCalData.IsSuccess = false;
            objCalData.Msg = "add failed";
            objCalData.Data = "";
            objCalData.error = ex.Message;

        }



        return objCalData;
    }

    public CalendarData updateCalendar(string id, string st, string et)
    {
        CalendarData objCalData = new CalendarData();
        objCalData.events = new List<ArrayList>();

        try
        {
            using (SqlConnection conn = new SqlConnection(connDietDB))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "update  dbo.jqcalendar set StartTime=@StartTime,EndTime=@EndTime where Id=@Id";

                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = (st != null) ? Convert.ToDateTime(st) : DateTime.UtcNow.AddHours(5.5);
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = (et != null) ? Convert.ToDateTime(et) : DateTime.UtcNow.AddHours(5.5);


                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt16(id);

                    objCalData.Data = cmd.ExecuteNonQuery().ToString();

                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            objCalData.IsSuccess = true;
            objCalData.Msg = "update success";
            objCalData.error = null;
        }
        catch (Exception ex)
        {
            objCalData.IsSuccess = false;
            objCalData.Msg = "update failed";
            objCalData.Data = "";
            objCalData.error = ex.Message;
        }

        return objCalData;
    }

    public CalendarData updateDetailedCalendar(string id, string st, string et, string sub, string ade, string dscr, string loc, string color, string timezone, string customerID)
    {
        CalendarData objCalData = new CalendarData();
        objCalData.events = new List<ArrayList>();

        try
        {
            using (SqlConnection conn = new SqlConnection(connDietDB))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "update  dbo.jqcalendar set Subject=@Subject,StartTime=@StartTime,EndTime=@EndTime,IsAllDayEvent=@IsAllDayEvent,Location=@Location,Description=@Description,Color=@Color,CustID=@CustID,SessionCode=@SessionCode where Id=@Id";
                    cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = sub;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = (st != null) ? Convert.ToDateTime(st) : DateTime.UtcNow.AddHours(5.5);
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = (et != null) ? Convert.ToDateTime(et) : DateTime.UtcNow.AddHours(5.5);
                    cmd.Parameters.Add("@IsAllDayEvent", SqlDbType.SmallInt).Value = Convert.ToInt16(ade);

                    cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = loc;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dscr;
                    cmd.Parameters.Add("@Color", SqlDbType.SmallInt).Value = Convert.ToInt16(color);

                    cmd.Parameters.Add("@CustID", SqlDbType.BigInt).Value = Convert.ToInt64(customerID);
                    cmd.Parameters.Add("@SessionCode", SqlDbType.NVarChar).Value = Convert.ToString(HttpContext.Current.Session["UserCode"]);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt16(id);

                    objCalData.Data = cmd.ExecuteNonQuery().ToString();

                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            objCalData.IsSuccess = true;
            objCalData.Msg = "update success";
            objCalData.error = null;
        }
        catch (Exception ex)
        {
            objCalData.IsSuccess = false;
            objCalData.Msg = "update failed";
            objCalData.Data = "";
            objCalData.error = ex.Message;
        }

        return objCalData;
    }

    public CalendarData addDetailedCalendar(string id, string st, string et, string sub, string ade, string dscr, string loc, string color, string timezone, string customerID)
    {
        CalendarData objCalData = new CalendarData();
        objCalData.events = new List<ArrayList>();

        try
        {
            using (SqlConnection conn = new SqlConnection(connDietDB))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "insert into dbo.jqcalendar(Subject,StartTime,EndTime,IsAllDayEvent,Location,Description,Color,CustID,SessionCode) output INSERTED.Id values(@Subject,@StartTime,@EndTime,@IsAllDayEvent,@Location,@Description,@Color,@CustID,@SessionCode)";
                    cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = sub;
                    cmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = (st != null) ? Convert.ToDateTime(st) : DateTime.UtcNow.AddHours(5.5);
                    cmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = (et != null) ? Convert.ToDateTime(et) : DateTime.UtcNow.AddHours(5.5);
                    cmd.Parameters.Add("@IsAllDayEvent", SqlDbType.SmallInt).Value = Convert.ToInt16(ade);

                    cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = loc;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dscr;
                    cmd.Parameters.Add("@Color", SqlDbType.SmallInt).Value = Convert.ToInt16(color);
                    cmd.Parameters.Add("@SessionCode", SqlDbType.NVarChar).Value = Convert.ToString(HttpContext.Current.Session["UserCode"]);
                    cmd.Parameters.Add("@CustID", SqlDbType.BigInt).Value = Convert.ToInt64(customerID);


                    objCalData.Data = cmd.ExecuteScalar().ToString();

                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            objCalData.IsSuccess = true;
            objCalData.Msg = "add success";
            objCalData.error = null;
        }
        catch (Exception ex)
        {
            objCalData.IsSuccess = false;
            objCalData.Msg = "add failed";
            objCalData.Data = "";
            objCalData.error = ex.Message;
        }

        return objCalData;
    }


    public CalendarData removeCalendar(string id)
    {
        CalendarData objCalData = new CalendarData();
        objCalData.events = new List<ArrayList>();

        try
        {
            using (SqlConnection conn = new SqlConnection(connDietDB))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "delete from dbo.jqcalendar where Id=@Id";

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt16(id);

                    objCalData.Data = cmd.ExecuteNonQuery().ToString();

                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }

            objCalData.IsSuccess = true;
            objCalData.Msg = "delete success";
            objCalData.error = null;
        }
        catch (Exception ex)
        {
            objCalData.IsSuccess = false;
            objCalData.Msg = "delete failed";
            objCalData.Data = "";
            objCalData.error = ex.Message;
        }

        return objCalData;
    }
    [DataContract]
    public class CalendarData
    {
        [DataMember(Order = 1)]
        public List<ArrayList> events { get; set; }
        [DataMember(Order = 2)]
        public bool issort { get; set; }
        [DataMember(Order = 3)]
        public string start { get; set; }
        [DataMember(Order = 4)]
        public string end { get; set; }
        [DataMember(Order = 5)]
        public string error { get; set; }
        [DataMember(Order = 6)]
        public bool IsSuccess { get; set; }
        [DataMember(Order = 7)]
        public string Msg { get; set; }
        [DataMember(Order = 8)]
        public string Data { get; set; }
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.


    public static class JSDateTime
    {
        public static string ToStr(DateTime dateTime)
        {
            return dateTime.ToString(@"MM\/dd\/yyyy HH:mm");
        }
    }

    public class Event
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string StartDate { get; set; }
        [DataMember]
        public string EndDate { get; set; }
        [DataMember]
        public int IsAllDayEvent { get; set; }
        [DataMember]
        public int IsMoreThanOneDayEvent { get; set; }
        [DataMember]
        public int RecurringEvent { get; set; }
        [DataMember]
        public int Color { get; set; }
        [DataMember]
        public int IsEditable { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Attendents { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public long CustomerID { get; set; }
    }

    public ArrayList ConvertToArrayList<T>(T obj)
    {
        ArrayList ls = new ArrayList();
        PropertyInfo[] p = obj.GetType().GetProperties();
        foreach (var item in p)
        {
            ls.Add(item.GetValue(obj, null));
        }
        return ls;
    }
}
//}
