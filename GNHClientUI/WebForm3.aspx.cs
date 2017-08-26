using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace GNHClientUI
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserCode"] = "RDUSER";
            //if (!IsPostBack)
                //gridBind();
        }
        protected void gridBind()
        {
            try
            {
                cmd = new SqlCommand("Select * from EllergieMaster where EMbIsDeleted=0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                GridEllergie.DataSource = dt;
                GridEllergie.DataBind();
            }
            catch (Exception ex) { }
            finally { }
        }
    }
}