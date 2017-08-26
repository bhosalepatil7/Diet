using Diet.Business.Core.ModDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI
{
    public partial class Daily_Appointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserCode"] = "RDUSER";
            if (!IsPostBack)
                binddata();
        }
        protected void binddata()
        {
            DashboardManager obj = new DashboardManager();
            grdClient.DataSource = obj.GetClientDetails(7);
            grdClient.DataBind();
        }

        protected void grdClient_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label l = ((Label)e.Row.FindControl("lblId"));
                Label l1 = ((Label)e.Row.FindControl("lblStatus"));

                if (l1.Text.Equals("INOFFICE"))
                {
                    ((Button)e.Row.FindControl("btnMark")).Text = l1.Text;
                    ((Button)e.Row.FindControl("btnMark")).Enabled = false;
                    ((Button)e.Row.FindControl("btnMark")).CssClass = "btn btn-info";
                }
                else if (l1.Text.Equals("FINISHED"))
                {
                    ((Button)e.Row.FindControl("btnMark")).Text = l1.Text;
                    ((Button)e.Row.FindControl("btnMark")).Enabled = false;
                    ((Button)e.Row.FindControl("btnMark")).CssClass = "btn btn-danger";
                }
                else
                {
                    ((Button)e.Row.FindControl("btnMark")).CssClass = "btn btn-success";
                    ((Button)e.Row.FindControl("btnMark")).Enabled = true;
                }
            }
        }

        protected void grdClient_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Mark")
            {
                int rowindex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                Button lbtn = (Button)grdClient.Rows[rowindex].FindControl("btnMark");
                Int32 ID = Convert.ToInt32(((Label)grdClient.Rows[rowindex].FindControl("lblID")).Text);
                DashboardManager obj = new DashboardManager();
                Int32 j = obj.UpdateDashoard(ID, "INOFFICE","");
                binddata();
                Tell.text("Client marked as in office!!", this);
            }
        }

        protected void grdClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdClient.PageIndex = e.NewPageIndex;
            DashboardManager obj = new DashboardManager();
            grdClient.DataSource = obj.GetClientDetails(7);
            grdClient.DataBind();
        }

    }
}