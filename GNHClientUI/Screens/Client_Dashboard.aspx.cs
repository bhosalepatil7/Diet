using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diet.Business.Core.ModDashboard;
using System.Globalization;
using System.Data;
using Diet.Business.Core.ModDietMaster;
using Diet.DataAccess.DataManagers.ModHelper;

namespace GNHClientUI
{
    public partial class Client_Dashboard : System.Web.UI.Page
    {
        DashboardManager obj;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Session["UserCode"] = "RDUSER";            
            if (!IsPostBack)
            {
                binddata();
            }
        }

        protected void grdScheduled_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn = ((Button)e.Row.FindControl("btnMark"));
                Toolkit1.RegisterAsyncPostBackControl(btn);
                btn = ((Button)e.Row.FindControl("btnView"));
                Toolkit1.RegisterAsyncPostBackControl(btn);


                DataRowView drview = e.Row.DataItem as DataRowView;
                //   dt = DateTime.ParseExact(drview[4].ToString(), "h:mmtt", CultureInfo.InvariantCulture);
                Label l = ((Label)e.Row.FindControl("lblDiff"));
                if (Convert.ToString(new HelperMasterDataManager().CheckAccess(Convert.ToString(Session["UserCode"])).Rows[0][0]).Equals("TRUE"))
                {
                    ((Button)e.Row.FindControl("btnMark")).Visible = true;
                    ((Button)e.Row.FindControl("btnMark")).CssClass = "btn btn-info";
                    ((Button)e.Row.FindControl("btnView")).Visible = true;
                    ((Button)e.Row.FindControl("btnView")).Enabled = true;
                    if (Convert.ToInt32(l.Text) < 0)
                    {
                        ((Button)e.Row.FindControl("btnView")).Text = Math.Abs(Convert.ToInt32(l.Text)).ToString() + " mins late";
                        ((Button)e.Row.FindControl("btnView")).CssClass = "btn btn-danger disabled cur";
                        ////((Button)e.Row.FindControl("btnView")).Enabled = false;
                        //((Button)e.Row.FindControl("btnView")).ForeColor = System.Drawing.Color.White ;
                    }
                    else
                    {


                        //TimeSpan span = DateTime.UtcNow.AddHours(5.5).Subtract(dt);
                        ((Button)e.Row.FindControl("btnView")).Text = "Appt in " + l.Text + " mins";
                        ((Button)e.Row.FindControl("btnView")).CssClass = "btn btn-info disabled cur";
                        ////((Button)e.Row.FindControl("btnView")).Enabled = false;
                        //((Button)e.Row.FindControl("btnView")).ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    ((Button)e.Row.FindControl("btnMark")).CssClass = "btn btn-info";
                    ((Button)e.Row.FindControl("btnMark")).Visible = true;
                    ((Button)e.Row.FindControl("btnView")).Visible = false;
                }

            }
        }

        protected void grdFinished_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DateTime dt;
            //DateTime dt1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label l = ((Label)e.Row.FindControl("lblDiff"));


                ((Button)e.Row.FindControl("btnView")).Text = "Appt ended in " + l.Text + " mins";
                ((Button)e.Row.FindControl("btnView")).CssClass = "btn btn-info disabled cur";

            }
        }

        protected void grdInoffice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DateTime dt;
            ////DateTime dt1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn = ((Button)e.Row.FindControl("btnVisit"));
                Toolkit1.RegisterPostBackControl(btn);
                btn = ((Button)e.Row.FindControl("btnEnd"));
                Toolkit1.RegisterAsyncPostBackControl(btn);


                Label l = ((Label)e.Row.FindControl("lblonoff"));
                if (Convert.ToString(new HelperMasterDataManager().CheckAccess(Convert.ToString(Session["UserCode"])).Rows[0][0]).Equals("TRUE"))
                {
                    ((Button)e.Row.FindControl("btnVisit")).Enabled = true;
                    ((Button)e.Row.FindControl("btnVisit")).CssClass = "btn btn-danger";
                    ((Button)e.Row.FindControl("btnEnd")).Enabled = true;
                    ((Button)e.Row.FindControl("btnEnd")).Attributes["Onclick"] = "return confirm('Are you sure you want to end appointment?')";
                    ((Button)e.Row.FindControl("btnEnd")).CssClass = "btn btn-success";

                }
                else
                {
                    ((Button)e.Row.FindControl("btnVisit")).Enabled = false;
                    ((Button)e.Row.FindControl("btnEnd")).Enabled = false;
                    ((Button)e.Row.FindControl("btnEnd")).CssClass = "btn btn-success disabled cur";
                    ((Button)e.Row.FindControl("btnVisit")).CssClass = "btn btn-danger disabled cur";
                }
                if (l.Text.Equals("ON"))
                {
                    ((Button)e.Row.FindControl("btnVisit")).Text = "Session in progress";
                }
                else
                {
                    ((Button)e.Row.FindControl("btnEnd")).Enabled = false;
                    ((Button)e.Row.FindControl("btnEnd")).CssClass = "btn btn-success disabled cur";
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            binddata();
        }
        protected void binddata()
        {
            obj = new DashboardManager();
            lblScheduled.Text = Convert.ToString(((DataTable)obj.GetClientDetails(4, Convert.ToString(Session["UserCode"]))).Rows.Count);
            lblInooffice.Text = Convert.ToString(((DataTable)obj.GetClientDetails(5, Convert.ToString(Session["UserCode"]))).Rows.Count);
            lblFinished.Text = Convert.ToString(((DataTable)obj.GetClientDetails(6, Convert.ToString(Session["UserCode"]))).Rows.Count);
            grdScheduled.DataSource = obj.GetClientDetails(4, Convert.ToString(Session["UserCode"]));
            grdScheduled.DataBind();
            grdInoffice.DataSource = obj.GetClientDetails(5, Convert.ToString(Session["UserCode"]));
            grdInoffice.DataBind();
            grdFinished.DataSource = obj.GetClientDetails(6, Convert.ToString(Session["UserCode"]));
            grdFinished.DataBind();
        }

        protected void grdInoffice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Visit")
            {
                int rowindex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                Button lbtn = (Button)grdInoffice.Rows[rowindex].FindControl("btnVisit");
                string value = ((Label)grdInoffice.Rows[rowindex].FindControl("lblCustID")).Text;
                string onoff = ((Label)grdInoffice.Rows[rowindex].FindControl("lblonoff")).Text;
                Int32 ID = Convert.ToInt32(((Label)grdInoffice.Rows[rowindex].FindControl("lblID")).Text);

                Session["PatientID"] = value;

                //Update Start Time if session noot opened already
                if (!onoff.Equals("ON"))
                {
                    obj = new DashboardManager();
                    Int32 j = obj.UpdateDashoard(ID, "STARTTIME", Convert.ToString(Session["UserCode"]));
                }
                if (value.Equals("0"))
                {
                    Session["PatientID"] = value;
                    Session["Operation"] = "New";
                }
                else
                {
                    //if (i == 1)
                    //    Tell.text("Marked as visit successfully!!", this);
                    //else if (i == -1)
                    //    Tell.text("Visit already marked today!!", this);
                    //else
                    //    Tell.text("Visit not marked !!", this);
                    Session["PatientID"] = value;
                    Session["Operation"] = "Edit";
                }
                Server.Transfer("~/Screens/PatientMaster.aspx");
            }
            else if (e.CommandName == "End")
            {
                int rowindex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                Button lbtn = (Button)grdInoffice.Rows[rowindex].FindControl("btnVisit");
                string value = ((Label)grdInoffice.Rows[rowindex].FindControl("lblCustID")).Text;
                string onoff = ((Label)grdInoffice.Rows[rowindex].FindControl("lblonoff")).Text;
                Int32 ID = Convert.ToInt32(((Label)grdInoffice.Rows[rowindex].FindControl("lblID")).Text);

                Session["PatientID"] = value;

                DashboardManager obj1 = new DashboardManager();
                Int32 j = obj1.UpdateDashoard(Convert.ToInt32(Session["PatientID"]), "ENDTIME", Convert.ToString(Session["UserCode"]));

                //Adding history for patient in History tables
                j = new DietMasterManager().UpdateClientData(Convert.ToInt16(Session["PatientID"].ToString()));
                binddata();
            }
            else
            { }
        }

        protected void grdScheduled_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdScheduled.PageIndex = e.NewPageIndex;
            obj = new DashboardManager();
            grdScheduled.DataSource = obj.GetClientDetails(4, Convert.ToString(Session["UserCode"]));
            grdScheduled.DataBind();

        }

        protected void grdInoffice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdInoffice.PageIndex = e.NewPageIndex;
            obj = new DashboardManager();
            grdInoffice.DataSource = obj.GetClientDetails(5, Convert.ToString(Session["UserCode"]));
            grdInoffice.DataBind();
        }

        protected void grdFinished_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFinished.PageIndex = e.NewPageIndex;
            obj = new DashboardManager();
            grdFinished.DataSource = obj.GetClientDetails(6, Convert.ToString(Session["UserCode"]));
            grdFinished.DataBind();
        }

        protected void grdScheduled_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Mark")
            {
                int rowindex = ((GridViewRow)((Button)e.CommandSource).NamingContainer).RowIndex;
                Button lbtn = (Button)grdScheduled.Rows[rowindex].FindControl("btnMark");
                Int32 ID = Convert.ToInt32(((Label)grdScheduled.Rows[rowindex].FindControl("lblID")).Text);
                DashboardManager obj = new DashboardManager();
                Int32 j = obj.UpdateDashoard(ID, "INOFFICE", "");
                binddata();
                Tell.text("Client marked as in office!!", this);
            }
        }

        protected void btnEnd_Click(object sender, EventArgs e)
        {
        }


    }
}