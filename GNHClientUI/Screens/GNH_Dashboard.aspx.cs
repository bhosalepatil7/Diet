using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI
{
    public partial class GNH_Dashboard : System.Web.UI.Page
    {
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static DataTable dt;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserCode"] = "RDUSER";
        }
        [System.Web.Services.WebMethod]
        public static Object Get12MonthsData()
        {
            StringBuilder sbDataset = new StringBuilder();
            sbDataset.Append("{ ");
            sbDataset.Append(" labels : {{labels}},");
            sbDataset.Append(" datasets : [");
            sbDataset.Append("              {");
            sbDataset.Append("                  label : 'My First Dataset',");
            sbDataset.Append("                  fillColor : 'rgba(255, 86, 48, 0.99)',");
            sbDataset.Append("                  strokeColor : 'rgba(220,220,220,1)',");
            sbDataset.Append("                  pointColor : 'rgba(220,220,220,1)',");
            sbDataset.Append("                  pointStrokeColor : '#fff',");
            sbDataset.Append("                  pointHighlightFill : '#fff',");
            sbDataset.Append("                  pointHighlightStroke : 'rgba(220,220,220,1)',");
            sbDataset.Append("                  data : {{data}}");
            sbDataset.Append("              }");
            sbDataset.Append("            ]");
            sbDataset.Append("}");

            cmd = new SqlCommand("csp_GetDashboardData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReportID", 3);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            string st = "[";
            string st1 = "[";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    st += "\'" + dt.Rows[i][0].ToString() + "\'";
                    st1 += dt.Rows[i][1].ToString();
                    if (i != dt.Rows.Count - 1)
                    {
                        st += ",";
                        st1 += ",";
                    }
                }
            }
            //sbDataset = sbDataset.Replace("{{labels}}", "['1-Jan-2016', '8-Jan-2016', '15-Jan-2016', '22-Jan-2016', '29-Jan-2016', '4-Feb-2016', '11-Feb-2016']");
            //sbDataset = sbDataset.Replace("{{data}}", "[60,61,62,61.5,64,62,63]");
            st = st + "]";
            st1 = st1 + "]";
            sbDataset = sbDataset.Replace("{{labels}}", st);
            sbDataset = sbDataset.Replace("{{data}}", st1);


            JavaScriptSerializer j = new JavaScriptSerializer();
            object a = j.Deserialize(sbDataset.ToString(), typeof(object));

            return a;

            // DashboardService ds = new DashboardService();
            // return ds.Get12MonthsData();
        }

        [System.Web.Services.WebMethod]
        public static Object GetDailyData()
        {
            StringBuilder sbDataset = new StringBuilder();
            sbDataset.Append("{ ");
            sbDataset.Append(" labels : {{labels}},");
            sbDataset.Append(" datasets : [");
            sbDataset.Append("              {");
            sbDataset.Append("                  label : 'My First Dataset',");
            sbDataset.Append("                  fillColor : 'rgba(160, 85, 113, 0.9)',");
            sbDataset.Append("                  strokeColor : 'rgba(220,220,220,1)',");
            sbDataset.Append("                  pointColor : 'rgba(220,220,220,1)',");
            sbDataset.Append("                  pointStrokeColor : '#fff',");
            sbDataset.Append("                  pointHighlightFill : '#fff',");
            sbDataset.Append("                  pointHighlightStroke : 'rgba(220,220,220,1)',");
            sbDataset.Append("                  data : {{data}}");
            sbDataset.Append("              }");
            sbDataset.Append("            ]");
            sbDataset.Append("}");

            cmd = new SqlCommand("csp_GetDashboardData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReportID", 2);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            string st = "[";
            string st1 = "[";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    st += "\'" + dt.Rows[i][0].ToString() + "\'";
                    st1 += dt.Rows[i][1].ToString();
                    if (i != dt.Rows.Count - 1)
                    {
                        st += ",";
                        st1 += ",";
                    }
                }
               
            }
            //sbDataset = sbDataset.Replace("{{labels}}", "['1-Jan-2016', '8-Jan-2016', '15-Jan-2016', '22-Jan-2016', '29-Jan-2016', '4-Feb-2016', '11-Feb-2016']");
            //sbDataset = sbDataset.Replace("{{data}}", "[60,61,62,61.5,64,62,63]");
            st = st + "]";
            st1 = st1 + "]";
            sbDataset = sbDataset.Replace("{{labels}}", st);
            sbDataset = sbDataset.Replace("{{data}}", st1);


            JavaScriptSerializer j = new JavaScriptSerializer();
            object a = j.Deserialize(sbDataset.ToString(), typeof(object));

            return a;

            //DashboardService ds = new DashboardService();
            //return ds.GetDailyData();
        }

        [System.Web.Services.WebMethod]
        public static List<PatientDetails> GetPatientData()
        {
            //DashboardService ds = new DashboardService();
            //JavaScriptSerializer j = new JavaScriptSerializer();
            //object a = j.Deserialize(ds.GetPatientDetails(), typeof(object));
            //return a;
            //return ds.GetPatientDetails();

            List<PatientDetails> pd = new List<PatientDetails>();

            cmd = new SqlCommand("csp_GetDashboardData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ReportID", 1);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    pd.Add(new PatientDetails { Sr = dt.Rows[i][0].ToString(), Name = dt.Rows[i][1].ToString(), Time = dt.Rows[i][2].ToString() });
                }
            }

            return pd;
        }
    }

    public class PatientDetails
    {
        public string Sr { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }

    }
}