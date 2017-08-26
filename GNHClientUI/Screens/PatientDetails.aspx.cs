using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diet.Business.Model;
using Diet.Business.Core;
using Diet.Business.Contract;
using Diet.DataAccess.DataManagers;
using Diet.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Diet.Business.Core.ModDietMaster;
public partial class Screens_PatientDetails : System.Web.UI.Page
{
    //String constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString();
    //SqlConnection conn = new SqlConnection(constr);
    DataTable dtSearchMaster = new DataTable();
    DietMasterManager master = new DietMasterManager();
    HelperClass acs = new HelperClass();
    protected void Page_Error(object sender, EventArgs e)
    {
        String PhyFilePath = System.AppDomain.CurrentDomain.BaseDirectory;
        String sUser = Convert.ToString(Session["UserCode"]);
        String sLastError = Server.GetLastError().Message.ToString();
        String sStackTrace = Server.GetLastError().StackTrace.ToString();
        acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "Patient Master");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserCode"] = "SUPERADMIN";
        Toolkit1.RegisterPostBackControl(btnNew);
        if (!IsPostBack)
        {
            //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //{
            //    dtSearchMaster = DietMasterManager.SearchPatients("", "ALL");
            //});
            ViewState["Alphabet"] = "A";
            this.GenerateAlphabets();
            dtSearchMaster = master.SearchPatients("A", "NAME", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
            Session["PatientID"] = 0;
            Session["Operation"] = "";
        }
    }
    protected void btnViewAll_Click(object sender, EventArgs e)
    {
        //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
        //{
        //    dtSearchMaster = DietMasterManager.SearchPatients(txtID.Text.Trim(), "ALL");
        //});

        txtSearch.Text = "";
        dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "ALL", Convert.ToString(Session["UserCode"]));
        grdPatients.DataSource = dtSearchMaster;
        grdPatients.DataBind();
    }
    //protected void txtName_TextChanged(object sender, EventArgs e)
    //{
    //    //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
    //    //{
    //    //    dtSearchMaster = DietMasterManager.SearchPatients(txtName.Text.Trim(), "NAME");
    //    //});
    //    txtID.Text = "";
    //    txtContact.Text = "";
    //    txtEmail.Text = "";
    //    dtSearchMaster = master.SearchPatients(txtName.Text.Trim(), "NAME");
    //    grdPatients.DataSource = dtSearchMaster;
    //    grdPatients.DataBind();
    //}
    //protected void txtID_TextChanged(object sender, EventArgs e)
    //{

    //    //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
    //    //{
    //    //    dtSearchMaster = DietMasterManager.SearchPatients(txtID.Text.Trim(), "ID");
    //    //});
    //    // DietMasterManager.SearchPatients(txtID.Text.Trim(), "ID");
    //    txtName.Text = "";
    //    txtEmail.Text = "";
    //    txtContact.Text = "";
    //    dtSearchMaster = master.SearchPatients(txtID.Text.Trim(), "ID");
    //    grdPatients.DataSource = dtSearchMaster;
    //    grdPatients.DataBind();

    //}
    protected void grdPatients_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grdPatients.PageIndex = e.NewPageIndex;
        //dtSearchMaster = master.SearchPatients("", "ALL");
        //grdPatients.DataSource = dtSearchMaster;
        //grdPatients.DataBind();
    }
    protected void on_row(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            LinkButton lbtn = (LinkButton)grdPatients.Rows[rowindex].FindControl("btnView");
            Toolkit1.RegisterPostBackControl(lbtn);
            string value = ((Label)grdPatients.Rows[rowindex].FindControl("lblID")).Text;
            Session["PatientID"] = value;
            Session["Operation"] = "Edit";
            Server.Transfer("~/Screens/PatientMaster.aspx");

        }
        if (e.CommandName == "Visit")
        {
            int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            LinkButton lbtn = (LinkButton)grdPatients.Rows[rowindex].FindControl("btnVisit");
            Toolkit1.RegisterPostBackControl(lbtn);
            string value = ((Label)grdPatients.Rows[rowindex].FindControl("lblID")).Text;
            Session["PatientID"] = value;
            master = new DietMasterManager();

            Int32 i = master.UpdateClientData(Convert.ToInt16(Session["PatientID"].ToString()));
            if (i == 1)
                Tell.text("Marked as visit successfully!!", this);
            else if (i == -1)
                Tell.text("Visit already marked today!!", this);
            else
                Tell.text("Visit not marked !!", this);

            dtSearchMaster = master.SearchPatients("", "ALL", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["PatientID"] = 0;
        Session["Operation"] = "New";
        Server.Transfer("~/Screens/PatientMaster.aspx");
    }

    //protected void txtEmail_TextChanged(object sender, EventArgs e)
    //{
    //    //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
    //    //{
    //    //    dtSearchMaster = DietMasterManager.SearchPatients(txtName.Text.Trim(), "NAME");
    //    //});
    //    txtID.Text = "";
    //    txtName.Text = "";
    //    txtContact.Text = "";
    //    dtSearchMaster = master.SearchPatients(txtEmail.Text.Trim(), "EMAIL");
    //    grdPatients.DataSource = dtSearchMaster;
    //    grdPatients.DataBind();
    //}
    //protected void txtContact_TextChanged(object sender, EventArgs e)
    //{

    //    //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
    //    //{
    //    //    dtSearchMaster = DietMasterManager.SearchPatients(txtID.Text.Trim(), "ID");
    //    //});
    //    // DietMasterManager.SearchPatients(txtID.Text.Trim(), "ID");
    //    txtName.Text = "";
    //    txtID.Text = "";
    //    txtEmail.Text = "";
    //    dtSearchMaster = master.SearchPatients(txtContact.Text.Trim(), "CONTACT");
    //    grdPatients.DataSource = dtSearchMaster;
    //    grdPatients.DataBind();

    //}

    protected void grdPatients_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton b = (LinkButton)e.Row.FindControl("btnView");
            //LinkButton b1 = (LinkButton)e.Row.FindControl("btnVisit");
            Toolkit1.RegisterPostBackControl(b);
            //Toolkit1.RegisterPostBackControl(b1);
        }
    }

    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSearch.SelectedIndex == 0)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "ALL", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 1)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "ID", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 2)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "FIRSTNAME", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 3)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "LASTNAME", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 4)
        {
            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "EMAIL", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 5)
        {
            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "CONTACT", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlSearch.SelectedIndex == 0)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "ALL", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 1)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "ID", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 2)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "FIRSTNAME", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 3)
        {

            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "LASTNAME", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 4)
        {
            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "EMAIL", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
        else if (ddlSearch.SelectedIndex == 5)
        {
            dtSearchMaster = master.SearchPatients(txtSearch.Text.Trim(), "CONTACT", Convert.ToString(Session["UserCode"]));
            grdPatients.DataSource = dtSearchMaster;
            grdPatients.DataBind();
        }
    }

    //protected void lnkAlphabet_Click(object sender, EventArgs e)
    //{

    //}

    private void GenerateAlphabets()
    {
        List<ListItem> alphabets = new List<ListItem>();
        ListItem alphabet = new ListItem();
        //alphabet.Value = "ALL";
        //alphabet.Selected = alphabet.Value.Equals(ViewState["Alphabet"]);
        //alphabets.Add(alphabet);
        for (int i = 65; i <= 90; i++)
        {
            alphabet = new ListItem();
            alphabet.Value = Char.ConvertFromUtf32(i);
            alphabet.Selected = alphabet.Value.Equals(ViewState["Alphabet"]);
            alphabets.Add(alphabet);
        }
        rptAlphabets.DataSource = alphabets;
        rptAlphabets.DataBind();
    }

    protected void lnkAlphabet_Click(object sender, EventArgs e)
    {
        LinkButton lnkAlphabet = (LinkButton)sender;
        ViewState["Alphabet"] = lnkAlphabet.Text;
        this.GenerateAlphabets();
        // grdPatients.PageIndex = 0;
        dtSearchMaster = master.SearchPatients(Convert.ToString(ViewState["Alphabet"]), "NAME", Convert.ToString(Session["UserCode"]));
        grdPatients.DataSource = dtSearchMaster;
        grdPatients.DataBind();

    }
    protected void rptAlphabets_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        LinkButton btn = e.Item.FindControl("lnkAlphabet") as LinkButton;
        if (btn != null)
        {
            Toolkit1.RegisterAsyncPostBackControl(btn);
        }
    }

}
