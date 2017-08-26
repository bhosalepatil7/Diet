using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace GNHClientUI
{

    public partial class PatientDocs : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd;
        //SqlDataAdapter da;
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PatientID"] == null || Session["PatientID"].ToString().Equals("0"))
                    Tell.error("Patient Id not found", this);
                else
                    gridBind();
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filepath = Server.MapPath("../UploadDocs") + "\\" + Session["PatientID"].ToString();
            if (!FileUpload1.HasFile)
            {
                Tell.error("Select the file", this);
                return;
            }
            if (File.Exists(filepath + "\\" + FileUpload1.PostedFile.FileName))
            {
                Tell.error("File already exist", this);
                return;
            }

            if (Session["PatientID"] == null || Session["PatientID"].ToString().Equals("0"))
                Tell.text("Patient Id not found", this);
            else
            {
                if (!Directory.Exists(filepath))
                    Directory.CreateDirectory(filepath);

                cmd = new SqlCommand("Insert into ClientDocument Values(@patientid,@clientname,@description,@filename,0,dateadd(minute,330,getutcdate()))", con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@patientid", Session["PatientID"].ToString());
                cmd.Parameters.AddWithValue("@clientname", txtName.Text);
                cmd.Parameters.AddWithValue("@description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@filename", FileUpload1.PostedFile.FileName);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open)
                    con.Close();
                FileUpload1.SaveAs(filepath + "\\" + FileUpload1.PostedFile.FileName);
                gridBind();
                Tell.Alert("Info", "Data Added succesfully", this);
            }
        }
        protected void gridBind()
        {
            try
            {
                cmd = new SqlCommand("Select * from ClientDocument where CDbIsDeleted=0 and CDnPatientID=@id", con);
                cmd.Parameters.AddWithValue("@id", Session["PatientID"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                dt = new DataTable();
                da.Fill(dt);
                grdClientDocs.DataSource = dt;
                grdClientDocs.DataBind();

            }
            catch (Exception ex) { }
            finally { }
        }
        protected void on_row(object sender, GridViewCommandEventArgs e)
        {
            string path = Server.MapPath("../UploadDocs") + "\\";
            if (e.CommandName == "View")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                LinkButton lbtn = (LinkButton)grdClientDocs.Rows[rowindex].FindControl("btnView");
                string docid = ((Label)grdClientDocs.Rows[rowindex].FindControl("lblID")).Text;
                string clientid = ((Label)grdClientDocs.Rows[rowindex].FindControl("lblClientID")).Text;
                string filename = ((Label)grdClientDocs.Rows[rowindex].FindControl("lblFileName")).Text;

                string filepath = path + clientid + "\\" + filename;
                if (!File.Exists(filepath))
                {
                    Tell.text("File Not Exist", this);
                    return;
                }
                else
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(filepath);

                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.WriteFile(file.FullName);
                    Response.End();
                }
            }
        }

        protected void grdClientDocs_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClientDocs.PageIndex = e.NewPageIndex;
            gridBind();
        }

        protected void grdClientDocs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton b = (LinkButton)e.Row.FindControl("btnView");
            //    Toolkit1.RegisterAsyncPostBackControl(b);

            //}
        }
    }
}