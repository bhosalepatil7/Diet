using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNHClientUI.Helper;
using Diet.Business.Model;
namespace GNHClientUI
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        ExportClass obj = new ExportClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserCode"] = "RDUSER";
            txtdate.Text = DateTime.UtcNow.AddHours(5.5).ToString();
            //Dictionary<string, bool> sections=new Dictionary<string, bool>();
            //sections.Add("ANTHROPOMETRICS", true);
            //sections.Add("BIOCHEMICALLABS", true);
            //sections.Add("COMORBIDITY",true);
            //sections.Add("DIETANDLIFESTYLE", true);
            // sections.Add("CLINICALCOMPLAINTS",true);
            // sections.Add("DietRecall", true);
            // Force this content to be downloaded 
            // as a Word document with the name of your choice
            //string body = obj.ClientReport(sections, "FileName");
            // Response.AppendHeader("Content-Type", "application/msword");
            // Response.AppendHeader("Content-disposition", "attachment; filename=1.doc");
            // Response.Write(body);
        }

    }
}