using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Diet.Business.Core.ModDashboard;


public partial class Edit : System.Web.UI.Page
{
    string connDietDB = ConfigurationManager.ConnectionStrings["connDietDB"].ConnectionString.ToString();
    public Event evr;

    static SqlCommand cmd;
    static SqlDataAdapter da;
    static DataTable dt;
    static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connDietDB"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        string req = Request.QueryString[0].ToString();
    }

    public class Event
    {

        public int? Id { get; set; }

        public string Subject { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int IsAllDayEvent { get; set; }

        public int IsMoreThanOneDayEvent { get; set; }

        public int RecurringEvent { get; set; }

        public int Color { get; set; }

        public long CustomerID { get; set; }

        public int IsEditable { get; set; }

        public string Location { get; set; }

        public string Attendents { get; set; }

        public string Description { get; set; }
    }

    public Event GetCalendarDetailsByEventId(string id = "1")
    {
        Event _event = new Event();

        using (SqlConnection conn = new SqlConnection(connDietDB))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "select * from dbo.jqcalendar where id = " + id + "";

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
                            _event.Id = Convert.ToInt32(row["Id"].ToString());
                            _event.Subject = row["Subject"].ToString();
                            _event.Location = row["Location"].ToString();
                            _event.Description = row["Description"].ToString();
                            _event.StartDate = startDate.ToString(@"MM\/dd\/yyyy|HH:mm");
                            _event.EndDate = endDate.ToString(@"MM\/dd\/yyyy|HH:mm");
                            _event.IsAllDayEvent = Convert.ToInt16(row["IsAllDayEvent"].ToString());
                            _event.Color = Convert.ToInt16((!row.IsNull("Color")) ? row["Color"].ToString() : "-1");
                            _event.CustomerID = Convert.ToInt64((!row.IsNull("CustID")) ? row["CustID"].ToString() : "0");
                        }
                    }
                }

            }
        }

        return _event;

    }

    public Event GetCalendarDetailsForNewEvent(string start,string end)
    {
        Event _event = new Event();


        DateTime startDate = Convert.ToDateTime(start);
        //DateTime endDate = Convert.ToDateTime(end);
        DateTime endDate = startDate.AddHours(0.5);

        _event.Id = null;
        _event.Subject = "";
        _event.Location = "";
        _event.Description = "";
        _event.StartDate = startDate.ToString(@"MM\/dd\/yyyy|HH:mm");
        _event.EndDate = endDate.ToString(@"MM\/dd\/yyyy|HH:mm");
        _event.IsAllDayEvent = 0;
        _event.Color = -1;
        _event.CustomerID = 0;


        return _event;

    }

    // [System.Web.Services.WebMethod]
    //public static List<PatientDetails> GetEmployeeName(string empName)
    //{

    //    List<PatientDetails> pd = new List<PatientDetails>();

    //    DataSet ds = new DataSet();
    //    if (empName != "")
    //    {

    // DashboardManager obj = new DashboardManager();
    //  ds = obj.GetClientDetailswithId(empName);


    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //            {

    //                pd.Add(new PatientDetails { id = ds.Tables[0].Rows[i]["ID"].ToString(), Name = ds.Tables[0].Rows[i]["Name"].ToString() });
    //            }
    //        }

    //    }
    //    else
    //    {
    //        ds = null ;

    //    }
    //    return pd;   


    //}


    [System.Web.Services.WebMethod]
    public static List<string> GetEmployeeName(string empName)
    {

        List<string> result = new List<string>();


        cmd = new SqlCommand("csp_ClientDetailswithId", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@clientName", empName);
        cmd.Parameters.AddWithValue("@Session", Convert.ToString(HttpContext.Current.Session["UserCode"]));
        da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        dt = new DataTable();
        da.Fill(dt);


        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                result.Add(dt.Rows[i]["name"].ToString() + "/" + dt.Rows[i]["id"].ToString());
            }
        }



        return result;


    }
    public class PatientDetails
    {
        public string id { get; set; }

        public string Name { get; set; }


    }
}
