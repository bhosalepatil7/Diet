using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI
{
    public partial class Drop_ans : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserCode"] = "RDUSER";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_getQuestion"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);

                        drop1.DataSource = ds;
                        drop1.DataTextField = "Question";
                        drop1.DataValueField = "QID";
                        drop1.DataBind();

                        drop2.DataSource = ds;
                        drop2.DataTextField = "Question";
                        drop2.DataValueField = "QID";
                        drop2.DataBind();

                        drop3.DataSource = ds;
                        drop3.DataTextField = "Question";
                        drop3.DataValueField = "QID";
                        drop3.DataBind();

                        drop4.DataSource = ds;
                        drop4.DataTextField = "Question";
                        drop4.DataValueField = "QID";
                        drop4.DataBind();

                        drop5.DataSource = ds;
                        drop5.DataTextField = "Question";
                        drop5.DataValueField = "QID";
                        drop5.DataBind();

                        drop6.DataSource = ds;
                        drop6.DataTextField = "Question";
                        drop6.DataValueField = "QID";
                        drop6.DataBind();

                        drop7.DataSource = ds;
                        drop7.DataTextField = "Question";
                        drop7.DataValueField = "QID";
                        drop7.DataBind();


                        drop8.DataSource = ds;
                        drop8.DataTextField = "Question";
                        drop8.DataValueField = "QID";
                        drop8.DataBind();

                        drop9.DataSource = ds;
                        drop9.DataTextField = "Question";
                        drop9.DataValueField = "QID";
                        drop9.DataBind();

                        drop10.DataSource = ds;
                        drop10.DataTextField = "Question";
                        drop10.DataValueField = "QID";
                        drop10.DataBind();


                        drop1.Items.Insert(0, new ListItem("", ""));
                        drop2.Items.Insert(0, new ListItem("", ""));
                        drop3.Items.Insert(0, new ListItem("", ""));
                        drop4.Items.Insert(0, new ListItem("", ""));
                        drop5.Items.Insert(0, new ListItem("", ""));
                        drop6.Items.Insert(0, new ListItem("", ""));
                        drop7.Items.Insert(0, new ListItem("", ""));
                        drop8.Items.Insert(0, new ListItem("", ""));
                        drop9.Items.Insert(0, new ListItem("", ""));
                        drop10.Items.Insert(0, new ListItem("", ""));


                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_InsertQueAns"))
                {
                    try
                    {
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dt = new DataTable();

                        dt.Columns.Add("CustomerID", typeof(string));
                        dt.Columns.Add("QuestionID", typeof(int));
                        dt.Columns.Add("QueAnwser", typeof(string));

                        DataRow dr1 = dt.NewRow();
                        dr1["CustomerID"] = 1;
                        dr1["QuestionID"] = Convert.ToInt32(Request.Form["drop1"].ToString());
                        dr1["QueAnwser"] = Text1.Value;
                        dt.Rows.Add(dr1);

                        DataRow dr2 = dt.NewRow();
                        dr2["CustomerID"] = 1;
                        dr2["QuestionID"] = Convert.ToInt32(Request.Form["drop2"].ToString());
                        dr2["QueAnwser"] = Text2.Value;
                        dt.Rows.Add(dr2);

                        DataRow dr3 = dt.NewRow();
                        dr3["CustomerID"] = 1;
                        dr3["QuestionID"] = Convert.ToInt32(Request.Form["drop3"].ToString());
                        dr3["QueAnwser"] = Text3.Value;
                        dt.Rows.Add(dr3);

                        DataRow dr4 = dt.NewRow();
                        dr4["CustomerID"] = 1;
                        dr4["QuestionID"] = Convert.ToInt32(Request.Form["drop4"].ToString());
                        dr4["QueAnwser"] = Text4.Value;
                        dt.Rows.Add(dr4);

                        DataRow dr5 = dt.NewRow();
                        dr5["CustomerID"] = 1;
                        dr5["QuestionID"] = Convert.ToInt32(Request.Form["drop5"].ToString());
                        dr5["QueAnwser"] = Text5.Value;
                        dt.Rows.Add(dr5);


                        DataRow dr6 = dt.NewRow();
                        dr6["CustomerID"] = 1;
                        dr6["QuestionID"] = Convert.ToInt32(Request.Form["drop6"].ToString());
                        dr6["QueAnwser"] = Text6.Value;
                        dt.Rows.Add(dr6);

                        DataRow dr7 = dt.NewRow();
                        dr7["CustomerID"] = 1;
                        dr7["QuestionID"] = Convert.ToInt32(Request.Form["drop7"].ToString());
                        dr7["QueAnwser"] = Text7.Value;
                        dt.Rows.Add(dr7);

                        DataRow dr8 = dt.NewRow();
                        dr8["CustomerID"] = 1;
                        dr8["QuestionID"] = Convert.ToInt32(Request.Form["drop8"].ToString());
                        dr8["QueAnwser"] = Text8.Value;
                        dt.Rows.Add(dr8);


                        DataRow dr9 = dt.NewRow();
                        dr9["CustomerID"] = 1;
                        dr9["QuestionID"] = Convert.ToInt32(Request.Form["drop9"].ToString());
                        dr9["QueAnwser"] = Text9.Value;
                        dt.Rows.Add(dr9);

                        DataRow dr10 = dt.NewRow();
                        dr10["CustomerID"] = 1;
                        dr10["QuestionID"] = Convert.ToInt32(Request.Form["drop10"].ToString());
                        dr10["QueAnwser"] = Text10.Value;
                        dt.Rows.Add(dr10);

                        SqlParameter[] objsqlparam = new SqlParameter[1];
                        SqlParameter param = new SqlParameter("@QueAnsPatient", SqlDbType.Structured);
                        param.Value = dt;
                        cmd.Parameters.Add(param);
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                }
            }
        }
    }
}