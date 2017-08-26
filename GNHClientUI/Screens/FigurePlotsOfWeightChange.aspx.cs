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

namespace GNHClientUI.Screens
{
    public partial class FigurePlotsOfWeightChange : System.Web.UI.Page
    {

        static SqlCommand cmd;
        static SqlDataAdapter da;
        static DataTable dt;
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["PatientID"] = "14";
            if (!IsPostBack)
            {
                if (Session["PatientID"] == null || Session["PatientID"].ToString().Equals("0"))
                    Server.Transfer("~/Screens/PatientDetails.aspx");
            }

        }
        
        [System.Web.Services.WebMethod]
        public static Object GetWeightChangeData(string ClientID)
        {
            //return "Hello " + ClientID + Environment.NewLine + "The Current Time is: "
            //    + DateTime.UtcNow.AddHours(5.5).ToString();

            //return "['1-Jan-2016', '8-Jan-2016', '15-Jan-2016', '22-Jan-2016', '29-Jan-2016', '4-Feb-2016', '11-Feb-2016'],[60,61,62,63,64,65,67]";

            //WeightChangeData esd=new WeightChangeData();
            //esd.labels="['1-Jan-2016', '8-Jan-2016', '15-Jan-2016', '22-Jan-2016', '29-Jan-2016', '4-Feb-2016', '11-Feb-2016']";
            //esd.data = "[60,61,62,63,64,65,67]";

            StringBuilder sbDataset = new StringBuilder();
            sbDataset.Append("{ ");
            sbDataset.Append(" labels : {{labels}},");
            sbDataset.Append(" datasets : [");
            sbDataset.Append("              {");
            sbDataset.Append("                  label : 'My First Dataset',");
            sbDataset.Append("                  fillColor : '#3c8dbc',");
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
            cmd.Parameters.AddWithValue("@ReportID", 8);
            cmd.Parameters.AddWithValue("@CustomerID", Convert.ToInt16(ClientID));
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            dt = new DataTable();
            da.Fill(dt);
            string st = "";
            string st1 = "";
            if (dt.Rows.Count > 0)
            {
                st = "[";
                st1 = "[";
            
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
                st = st + "]";
                st1 = st1 + "]";
            }
            else
            {
                st = "{}";
                st1 = "{}";
            }
         
            sbDataset = sbDataset.Replace("{{labels}}", st);
            sbDataset = sbDataset.Replace("{{data}}", st1);

        
            //JavaScriptSerializer json = new JavaScriptSerializer();
            //return json.Serialize(sbDataset);

            JavaScriptSerializer j = new JavaScriptSerializer();
            object a = j.Deserialize(sbDataset.ToString(), typeof(object));

            return a;
        }

        [System.Web.Services.WebMethod]
        public static Object GetFoodData(string ClientID)
        {
            return new Object();
        }

        public class WeightChangeData
        {
            public string labels;
            public string data;
        }
    }
}