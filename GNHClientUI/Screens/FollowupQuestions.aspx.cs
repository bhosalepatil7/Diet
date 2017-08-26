using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI.Screens
{

    public partial class FollowupQuestions : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd;
        //SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Toolkit1.RegisterAsyncPostBackControl(btnFollowupQuestionsSave);
            if (!IsPostBack)
            {
                if (Session["PatientID"] == null || Convert.ToString(Session["PatientID"]).Equals("0"))
                    Tell.Alert("Info", "Patient Id not found!!", this);
                else
                    bind();
                gridBind();

            }
        }

        protected void btnFollowupQuestionsSave_Click(object sender, EventArgs e)
        {
            if (Session["PatientID"] == null || Convert.ToString(Session["PatientID"]).Equals("0"))
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Patient Id Not found'});", true);
            else
            {
                cmd = new SqlCommand("usp_ModifyFollowup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustId", Session["PatientID"]);
                cmd.Parameters.AddWithValue("@QueId", ddlQuestion.SelectedValue);
                cmd.Parameters.AddWithValue("@Ans", txtQuestion.Text);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Data Added Successfully!!'});", true);
                bind();
                gridBind();
            }
        }
        protected void bind()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select -1 'QMnQid','--select--' 'QMsQuestion' union Select * from QuestionMaster where QMnQid not in (select FMnQid from FollowupMaster where FMnCustID=3 and cast(FMdtCreated as date)=cast(dateadd(minute,330,getutcdate()) as date))", con);
            da.SelectCommand.Parameters.AddWithValue("@custid", Convert.ToInt32(Session["PatientID"]));
            dt = new DataTable();
            da.Fill(dt);
            ddlQuestion.DataSource = dt;
            ddlQuestion.DataValueField = "QMnQid";
            ddlQuestion.DataTextField = "QMsQuestion";
            ddlQuestion.DataBind();
        }

        protected void grdClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClient.PageIndex = e.NewPageIndex;
            bind();
            gridBind();
        }
        protected void gridBind()
        {
            try
            {
                cmd = new SqlCommand("Select * from FollowupMaster where FMnCustID=@custid and cast(FMdtCreated as date)=cast(dateadd(minute,330,getutcdate()) as date)", con);
                cmd.Parameters.AddWithValue("@custid", Convert.ToInt32(Session["PatientID"]));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                grdClient.DataSource = dt;
                grdClient.DataBind();

            }
            catch (Exception ex) { }
            finally { }
        }
    }
}