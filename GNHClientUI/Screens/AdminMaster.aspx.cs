using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI.Screens
{
    public partial class AdminMaster : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd;
        //SqlDataAdapter da;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserCode"] = "RDUSER";
            if (!IsPostBack)
            {
                ViewState["CurrentAlphabet"] = "A";
                this.GenerateAlphabets();
                gridBind();
                gridBind_Season();
                gridBind_Exercise();
                gridBind_DrugSupplement();
                gridBind_Food();
                gridBind_Disease();
                gridBind_Unit();
                gridBind_Category();
            }
        }
        protected void gridBind()
        {
            try
            {
                cmd = new SqlCommand("Select * from AllergyMaster where AMbIsDeleted=0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                GridEllergie.DataSource = dt;
                GridEllergie.DataBind();
                //}
                //    dt.Rows.Add(dt.NewRow());
                //    GridEllergie.DataSource = dt;
                //    GridEllergie.DataBind();
                //    //int columncount = GridEllergie.Rows[0].Cells.Count;
                //    //GridEllergie.Rows[0].Cells.Clear();
                //    //GridEllergie.Rows[0].Cells.Add(new TableCell());
                //    //GridEllergie.Rows[0].Cells[0].ColumnSpan = columncount;
                //    //GridEllergie.Rows[0].Cells[0].Text = "No Records Found";
                //}
                //else
                //{

            }
            catch (Exception ex) { }
            finally { }
        }
        protected void on_row(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Ellergie")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridEllergie.EditIndex = rowindex;
                gridBind();
            }
            else if (e.CommandName == "Update_Ellergie")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = GridEllergie.Rows[rowindex];
                    LinkButton lb = (LinkButton)grid.FindControl("btnedit");
                    string ellergy = ((TextBox)grid.FindControl("EditEllergie")).Text;
                    string name = ((TextBox)grid.FindControl("EditFoodName")).Text;

                    cmd = new SqlCommand("update AllergyMaster set AMsAllergyName=@ellergie, AMsFoodName=@name where AMnAllergyID=@id", con);
                    cmd.Parameters.Add("@ellergie", SqlDbType.NVarChar).Value = ellergy;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    GridEllergie.EditIndex = -1;
                    cmd.Parameters.Clear();
                    gridBind();
                    msgbox("Allergy Updated successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_Ellergie")
            {
                GridEllergie.EditIndex = -1;
                gridBind();
            }
            else if (e.CommandName == "Delete_Ellergie")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = GridEllergie.Rows[rowIndex];
                    int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);
                    cmd = new SqlCommand("update AllergyMaster set AMbIsDeleted=1 where AMnAllergyID=@id", con);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    cmd.Parameters.Clear();
                    gridBind();
                    msgbox("Alergy Deleted successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Insert_Ellergie")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                    GridViewRow grid = GridEllergie.FooterRow;
                    string ellergie = ((TextBox)grid.FindControl("txtEllergie")).Text;
                    string name = ((TextBox)grid.FindControl("txtFoodName")).Text;

                    cmd = new SqlCommand("insert into AllergyMaster values(@ellergie,@name,0,dateadd(minute,330,getutcdate()))", con);
                    cmd.Parameters.Add("@ellergie", SqlDbType.NVarChar).Value = ellergie;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from  AllergyMaster  where upper(AMsAllergyName)=upper('" + ellergie + "') and AMbIsDeleted=0") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Allergy Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        cmd.Parameters.Clear();
                        msgbox("Allergy Added Sucessfully!!!");
                    }
                    gridBind();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }

        }

        protected void GridEllergie_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridEllergie.PageIndex = e.NewPageIndex;
            gridBind();
        }
        protected void gridBind_Season()
        {
            try
            {
                cmd = new SqlCommand("Select * from SeasonMaster where SMbIsDeleted=0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    dt.Rows.Add(dt.NewRow());
                //    GridSeason.DataSource = dt;
                //    GridSeason.DataBind();
                //    int columncount = GridSeason.Rows[0].Cells.Count;
                //    GridSeason.Rows[0].Cells.Clear();
                //    GridSeason.Rows[0].Cells.Add(new TableCell());
                //    GridSeason.Rows[0].Cells[0].ColumnSpan = columncount;
                //    GridSeason.Rows[0].Cells[0].Text = "No Records Found";
                //}
                //else
                //{
                GridSeason.DataSource = dt;
                GridSeason.DataBind();
                //}
            }
            catch (Exception ex) { }
            finally { }
        }
        protected void on_row_Season(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Season")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridSeason.EditIndex = rowindex;
                gridBind_Season();
            }
            else if (e.CommandName == "Update_Season")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = GridSeason.Rows[rowindex];
                    LinkButton lb = (LinkButton)grid.FindControl("btnedit_Exercise");

                    string season = ((TextBox)grid.FindControl("EditSeason")).Text;

                    cmd = new SqlCommand("update SeasonMaster set SMsSeasonName=@Season where SMnSeasonID=@id", con);
                    cmd.Parameters.Add("@Season", SqlDbType.NVarChar).Value = season;
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    GridSeason.EditIndex = -1;
                    cmd.Parameters.Clear();
                    gridBind_Season();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_Season")
            {
                GridSeason.EditIndex = -1;
                gridBind_Season();
            }
            else if (e.CommandName == "Delete_Season")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = GridSeason.Rows[rowIndex];
                    int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                    cmd = new SqlCommand("update SeasonMaster set SMbIsDeleted=1 where SMnSeasonID=@id", con);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    cmd.Parameters.Clear();
                    gridBind_Season();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Insert_Season")
            {
                try
                {

                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = GridSeason.FooterRow;
                    string Season = ((TextBox)grid.FindControl("txtSeason")).Text;

                    cmd = new SqlCommand("insert into SeasonMaster values(@Season,0,dateadd(minute,330,getutcdate()))", con);
                    cmd.Parameters.Add("@Season", SqlDbType.NVarChar).Value = Season;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from SeasonMaster where upper(SMsSeasonName)=upper('" + Season + "') and SMbIsDeleted=0") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Season Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        cmd.Parameters.Clear();
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Season Added Sucessfully'});", true);
                    }
                    gridBind_Season();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }

        }

        protected void GridSeason_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridSeason.PageIndex = e.NewPageIndex;
            gridBind_Season();
        }

        protected void gridBind_Exercise()
        {
            try
            {
                cmd = new SqlCommand("Select * from ExerciseMaster where EMbIsDeleted=0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    dt.Rows.Add(dt.NewRow());
                //    GridExercise.DataSource = dt;
                //    GridExercise.DataBind();
                //    int columncount = GridExercise.Rows[0].Cells.Count;
                //    GridExercise.Rows[0].Cells.Clear();
                //    GridExercise.Rows[0].Cells.Add(new TableCell());
                //    GridExercise.Rows[0].Cells[0].ColumnSpan = columncount;
                //    GridExercise.Rows[0].Cells[0].Text = "No Records Found";
                //}
                //else
                //{
                GridExercise.DataSource = dt;
                GridExercise.DataBind();
                //}
            }
            catch (Exception ex) { }
            finally { }
        }
        protected void on_row_Exercise(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Exercise")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridExercise.EditIndex = rowindex;
                gridBind_Exercise();
            }
            else if (e.CommandName == "Update_Exercise")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = GridExercise.Rows[rowindex];
                    LinkButton lb = (LinkButton)grid.FindControl("btnedit_Exercise");
                    string Exercise = ((TextBox)grid.FindControl("EditExercise")).Text;
                    string type = ((TextBox)grid.FindControl("EditType")).Text;
                    cmd = new SqlCommand("update ExerciseMaster set EMsExerciseName=@Exercise,EMsExerciseType=@type where EMnExerciseID=@id", con);
                    cmd.Parameters.Add("@Exercise", SqlDbType.NVarChar).Value = Exercise;
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    GridExercise.EditIndex = -1;
                    cmd.Parameters.Clear();
                    gridBind_Exercise();
                    msgbox("Exercise Updated successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_Exercise")
            {
                GridExercise.EditIndex = -1;
                gridBind_Exercise();
            }
            else if (e.CommandName == "Delete_Exercise")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = GridExercise.Rows[rowIndex];
                    int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);
                    cmd = new SqlCommand("update ExerciseMaster set EMbIsDeleted=1 where EMnExerciseID=@id", con);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    cmd.Parameters.Clear();
                    gridBind_Exercise();
                    msgbox("Exercise Deleted successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Insert_Exercise")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = GridExercise.FooterRow;
                    string Exercise = ((TextBox)grid.FindControl("txtExercise")).Text;
                    string type = ((TextBox)grid.FindControl("txtType")).Text;
                    cmd = new SqlCommand("insert into ExerciseMaster values(@Exercise,@type,0,dateadd(minute,330,getutcdate()))", con);
                    cmd.Parameters.Add("@Exercise", SqlDbType.NVarChar).Value = Exercise;
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from ExerciseMaster where upper(EMsExerciseName)=upper('" + Exercise + "') and EMbIsDeleted=0") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Exercise Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open) con.Close();
                        cmd.Parameters.Clear();
                        msgbox("Exercise Added Sucessfully!!!");
                    }
                    gridBind_Exercise();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }

        }

        protected void GridExercise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridExercise.PageIndex = e.NewPageIndex;
            gridBind_Exercise();
        }
        protected void gridBind_DrugSupplement()
        {
            try
            {
                cmd = new SqlCommand("Select * from DrugSupplementMaster where DSMIsDeleted=0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    dt.Rows.Add(dt.NewRow());
                //    GridDrugSupplement.DataSource = dt;
                //    GridDrugSupplement.DataBind();
                //    int columncount = GridDrugSupplement.Rows[0].Cells.Count;
                //    GridDrugSupplement.Rows[0].Cells.Clear();
                //    GridDrugSupplement.Rows[0].Cells.Add(new TableCell());
                //    GridDrugSupplement.Rows[0].Cells[0].ColumnSpan = columncount;
                //    GridDrugSupplement.Rows[0].Cells[0].Text = "No Records Found";
                //}
                //else
                //{
                GridDrugSupplement.DataSource = dt;
                GridDrugSupplement.DataBind();
                // }
            }
            catch (Exception ex) { }
            finally { }
        }
        protected void on_row_DrugSupplement(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_DrugSupplement")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridDrugSupplement.EditIndex = rowindex;
                gridBind_DrugSupplement();
            }
            else if (e.CommandName == "Update_DrugSupplement")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = GridDrugSupplement.Rows[rowindex];
                    LinkButton lb = (LinkButton)grid.FindControl("btnedit_DrugSupplement");
                    string DrugSupplement = ((TextBox)grid.FindControl("EditDrugSupplement")).Text;
                    string type = ((TextBox)grid.FindControl("EditDrugSupplementType")).Text;

                    cmd = new SqlCommand("update DrugSupplementMaster set DSMsDrugName=@DrugSupplement,DSMsType=@type where DSMnDrugID=@id", con);
                    cmd.Parameters.Add("@DrugSupplement", SqlDbType.NVarChar).Value = DrugSupplement;
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    GridDrugSupplement.EditIndex = -1;
                    cmd.Parameters.Clear();
                    gridBind_DrugSupplement();
                    msgbox("Drug Supplement Updated successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_DrugSupplement")
            {
                GridDrugSupplement.EditIndex = -1;
                gridBind_DrugSupplement();
            }
            else if (e.CommandName == "Delete_DrugSupplement")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = GridDrugSupplement.Rows[rowIndex];
                    int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);

                    cmd = new SqlCommand("update DrugSupplementMaster set DSMIsDeleted=1 where DSMnDrugID=@id", con);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    cmd.Parameters.Clear();
                    gridBind_DrugSupplement();
                    msgbox("Drug Supplement Deleted successfully!!!");

                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Insert_DrugSupplement")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                    GridViewRow grid = GridDrugSupplement.FooterRow;
                    string DrugSupplement = ((TextBox)grid.FindControl("txtDrugSupplement")).Text;
                    string type = ((TextBox)grid.FindControl("txtDrugSupplementType")).Text;

                    cmd = new SqlCommand("insert into DrugSupplementMaster values(@DrugSupplement,@type,0,dateadd(minute,330,getutcdate()))", con);
                    cmd.Parameters.Add("@DrugSupplement", SqlDbType.NVarChar).Value = DrugSupplement;
                    cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = type;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from DrugSupplementMaster  where upper(DSMsDrugName)=upper('" + DrugSupplement + "') and DSMIsDeleted=0") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Drug Supplement Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        cmd.Parameters.Clear();
                        msgbox("Drug Supplement Added successfully!!!");
                    }
                    gridBind_DrugSupplement();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }

        }

        protected void GridDrugSupplement_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDrugSupplement.PageIndex = e.NewPageIndex;
            gridBind_DrugSupplement();
        }

        protected void gridBind_Disease()
        {
            try
            {
                cmd = new SqlCommand("Select * from DiseaseMaster where DMbIsDeleted=0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    dt.Rows.Add(dt.NewRow());
                //    GridDisease.DataSource = dt;
                //    GridDisease.DataBind();
                //    int columncount = GridDisease.Rows[0].Cells.Count;
                //    GridDisease.Rows[0].Cells.Clear();
                //    GridDisease.Rows[0].Cells.Add(new TableCell());
                //    GridDisease.Rows[0].Cells[0].ColumnSpan = columncount;
                //    GridDisease.Rows[0].Cells[0].Text = "No Records Found";
                //}
                //else
                //{
                GridDisease.DataSource = dt;
                GridDisease.DataBind();
                // }
            }
            catch (Exception ex) { }
            finally { }
        }
        protected void on_row_Disease(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Disease")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridDisease.EditIndex = rowindex;
                gridBind_Disease();
            }
            else if (e.CommandName == "Update_Disease")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = GridDisease.Rows[rowindex];
                    LinkButton lb = (LinkButton)grid.FindControl("btnedit_Disease");
                    string Disease = ((TextBox)grid.FindControl("EditDisease")).Text;
                    string FoodName = ((TextBox)grid.FindControl("EditFoodName")).Text;
                    string ExersiceName = ((TextBox)grid.FindControl("EditExersiceName")).Text;

                    cmd = new SqlCommand("update DiseaseMaster set DMsDiseaseName=@Disease,DMsFoodName=@FoodName,DMsExersiceName=@ExersiceName where DMnDiseaseID=@id", con);
                    cmd.Parameters.Add("@Disease", SqlDbType.NVarChar).Value = Disease;
                    cmd.Parameters.Add("@FoodName", SqlDbType.NVarChar).Value = FoodName;
                    cmd.Parameters.Add("@ExersiceName", SqlDbType.NVarChar).Value = ExersiceName;
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    GridDisease.EditIndex = -1;
                    cmd.Parameters.Clear();
                    gridBind_Disease();
                    msgbox("Disease Updated successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_Disease")
            {
                GridDisease.EditIndex = -1;
                gridBind_Disease();
            }
            else if (e.CommandName == "Delete_Disease")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = GridDisease.Rows[rowIndex];
                    int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);
                    cmd = new SqlCommand("update DiseaseMaster set DMbIsDeleted=1 where DMnDiseaseID=@id", con);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    cmd.Parameters.Clear();
                    gridBind_Disease();
                    msgbox("Disease Deleted successfully!!!");

                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Insert_Disease")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                    GridViewRow grid = GridDisease.FooterRow;
                    string Disease = ((TextBox)grid.FindControl("txtDisease")).Text;
                    string FoodName = ((TextBox)grid.FindControl("txtFoodName")).Text;
                    string ExersiceName = ((TextBox)grid.FindControl("txtExersiceName")).Text;

                    cmd = new SqlCommand("insert into DiseaseMaster values(@Disease,@FoodName,@ExersiceName,0,dateadd(minute,330,getutcdate()))", con);
                    cmd.Parameters.Add("@Disease", SqlDbType.NVarChar).Value = Disease;
                    cmd.Parameters.Add("@FoodName", SqlDbType.NVarChar).Value = FoodName;
                    cmd.Parameters.Add("@ExersiceName", SqlDbType.NVarChar).Value = ExersiceName;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from DiseaseMaster where upper(DMsDiseaseName)=upper('" + Disease + "') and upper(DMsFoodName)=upper('" + FoodName + "') and upper(DMsExersiceName)=upper('" + ExersiceName + "')  and DMbIsDeleted=0") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Disease Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        cmd.Parameters.Clear();
                        msgbox("Disease Added successfully!!!");
                    }
                    gridBind_Disease();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            TabName1.Value = "tabs-2";

        }

        protected void GridDisease_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridDisease.PageIndex = e.NewPageIndex;
            gridBind_Disease();
        }

        protected void gridBind_Food(string alphabet = "")
        {
            try
            {

                if (string.IsNullOrEmpty(alphabet))
                {
                    cmd = new SqlCommand("Select * from FoodMaster where FMIsDeleted=0 and FMsFoodname like @Alphabet OR @Alphabet = 'ALL%'", con);
                    cmd.Parameters.AddWithValue("@Alphabet", ViewState["CurrentAlphabet"] + "%");
                }
                else
                {
                    cmd = new SqlCommand("Select * from FoodMaster where FMIsDeleted=0 and FMsFoodname like @Alphabet", con);
                    cmd.Parameters.AddWithValue("@Alphabet", alphabet + "%");
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    dt.Rows.Add(dt.NewRow());
                //    GridFood.DataSource = dt;
                //    GridFood.DataBind();
                //    int columncount = GridFood.Rows[0].Cells.Count;
                //    GridFood.Rows[0].Cells.Clear();
                //    GridFood.Rows[0].Cells.Add(new TableCell());
                //    GridFood.Rows[0].Cells[0].ColumnSpan = columncount;
                //    GridFood.Rows[0].Cells[0].Text = "No Records Found";
                //}
                //else
                //{
                GridFood.DataSource = dt;
                GridFood.DataBind();

                //}
            }
            catch (Exception ex) { }
            finally { }
        }

        protected void on_row_Food(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Food")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                GridFood.EditIndex = rowindex;
                gridBind_Food();
            }
            else if (e.CommandName == "Update_Food")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = GridFood.Rows[rowindex];

                    LinkButton lb = (LinkButton)grid.FindControl("btnedit_Food");
                    string FoodName = ((TextBox)grid.FindControl("EditFoodName")).Text;
                    string Fiber = ((TextBox)grid.FindControl("EditFiber")).Text;
                    string Carbohydrates = ((TextBox)grid.FindControl("EditCarbohydrate")).Text;
                    string Energy = ((TextBox)grid.FindControl("EditEnergy")).Text;
                    string Protein = ((TextBox)grid.FindControl("EditProtien")).Text;
                    string Fat = ((TextBox)grid.FindControl("EditFat")).Text;
                    //string Quantity = ((TextBox)grid.FindControl("EditQuantity")).Text;
                    //string Unit = ((DropDownList)grid.FindControl("EditUnit")).SelectedValue;
                    string foodtype = ((DropDownList)grid.FindControl("EditFoodType")).SelectedValue;
                    string query = "update FoodMaster set FMsFoodName=@foodname,FMnEnergy=@energy,FMnProtein=@protein,FMnCarbohydrate=@carbohydrate,FMnFibre=@fiber,FMnFat=@fat,FMnQuantity=@quantity,FMsUnit=@unit,FMsFoodType=@foodtype  where FMnFoodID=@id";
                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@foodname", SqlDbType.NVarChar).Value = FoodName;
                    cmd.Parameters.Add("@fiber", SqlDbType.Float).Value = Fiber;
                    cmd.Parameters.Add("@carbohydrate", SqlDbType.Float).Value = Carbohydrates;
                    cmd.Parameters.Add("@energy", SqlDbType.Float).Value = Energy;
                    cmd.Parameters.Add("@protein", SqlDbType.Float).Value = Protein;
                    cmd.Parameters.Add("@fat", SqlDbType.Float).Value = Fat;
                    //cmd.Parameters.Add("@calories", SqlDbType.BigInt).Value = Calaries;
                    cmd.Parameters.Add("@quantity", SqlDbType.Float).Value = "100";
                    cmd.Parameters.Add("@unit", SqlDbType.NVarChar).Value = "Gram";
                    cmd.Parameters.AddWithValue("@foodtype", foodtype);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    GridFood.EditIndex = -1;
                    cmd.Parameters.Clear();
                    gridBind_Food();
                    msgbox("Food updated successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_Food")
            {
                GridFood.EditIndex = -1;
                gridBind_Food();
            }
            else if (e.CommandName == "Delete_Food")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = GridFood.Rows[rowindex];
                    cmd = new SqlCommand("update FoodMaster set FMIsDeleted=1 where FMnFoodID=@id", con);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    cmd.Parameters.Clear();
                    gridBind_Food();
                    msgbox("Food Deleted successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Insert_Food")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                    GridViewRow grid = GridFood.FooterRow;

                    string FoodName = ((TextBox)grid.FindControl("txtFoodName")).Text;
                    string Fiber = ((TextBox)grid.FindControl("txtFiber")).Text;
                    string Carbohydrates = ((TextBox)grid.FindControl("txtCarbohydrate")).Text;
                    string Energy = ((TextBox)grid.FindControl("txtEnergy")).Text;
                    string Protein = ((TextBox)grid.FindControl("txtProtien")).Text;
                    string Fat = ((TextBox)grid.FindControl("txtFat")).Text;
                    //string Calaries = ((TextBox)grid.FindControl("txtCalories")).Text;
                    //string Quantity = ((TextBox)grid.FindControl("txtQuantity")).Text;
                    //string Unit = ((DropDownList)grid.FindControl("ddlUnit")).SelectedValue;
                    string foodtype = ((DropDownList)grid.FindControl("ddlFoodType")).SelectedValue;
                    string query = "insert into FoodMaster(FMsFoodname,FMnEnergy,FMnProtein,FMnCarbohydrate,FMnFibre,FMnFat,FMnQuantity,FMsUnit,FMIsDeleted,FMdtCreated,FMsFoodType) values(@foodname,@energy,@protein,@carbohydrate,@fiber,@fat,@quantity,@unit,0,dateadd(minute,330,getutcdate()),@foodtype)";

                    cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@foodname", SqlDbType.NVarChar).Value = FoodName;
                    cmd.Parameters.Add("@fiber", SqlDbType.Float).Value = Fiber;
                    cmd.Parameters.Add("@carbohydrate", SqlDbType.Float).Value = Carbohydrates;
                    cmd.Parameters.Add("@energy", SqlDbType.Float).Value = Energy;
                    cmd.Parameters.Add("@protein", SqlDbType.Float).Value = Protein;
                    cmd.Parameters.Add("@fat", SqlDbType.Float).Value = Fat;
                    //cmd.Parameters.Add("@calories", SqlDbType.BigInt).Value = Calaries;
                    cmd.Parameters.Add("@quantity", SqlDbType.Float).Value = "100";
                    cmd.Parameters.Add("@unit", SqlDbType.NVarChar).Value = "Gram";
                    cmd.Parameters.Add("@foodtype", SqlDbType.NVarChar).Value = foodtype;

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from  FoodMaster  where upper(FMsFoodName)=upper('" + FoodName + "') and FMIsDeleted=0") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Food Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        cmd.Parameters.Clear();
                        msgbox("Food Added successfully!!!");
                    }
                    gridBind_Food();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }

        }

        protected void GridFood_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFood.PageIndex = e.NewPageIndex;
            gridBind_Food();
        }

        protected void GridFood_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand("Select * from FoodMaster where FMIsDeleted=0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            {
                string SortDir = string.Empty;
                if (dir == SortDirection.Ascending)
                {
                    dir = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt1);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                GridFood.DataSource = sortedView;
                GridFood.DataBind();
            }

        }


        protected void GridDisease_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand("Select * from DiseaseMaster where DMbIsDeleted=0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            {
                string SortDir = string.Empty;
                if (dir1 == SortDirection.Ascending)
                {
                    dir1 = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir1 = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt1);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                GridDisease.DataSource = sortedView;
                GridDisease.DataBind();
            }
        }

        protected void GridExercise_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand("Select * from ExerciseMaster where EMbIsDeleted=0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            {
                string SortDir = string.Empty;
                if (dir2 == SortDirection.Ascending)
                {
                    dir2 = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir2 = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt1);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                GridExercise.DataSource = sortedView;
                GridExercise.DataBind();
            }
        }

        protected void GridDrugSupplement_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand("Select * from DrugSupplementMaster where DSMIsDeleted=0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            {
                string SortDir = string.Empty;
                if (dir3 == SortDirection.Ascending)
                {
                    dir3 = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir3 = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt1);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                GridDrugSupplement.DataSource = sortedView;
                GridDrugSupplement.DataBind();
            }
        }

        protected void GridSeason_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand("Select * from SeasonMaster where SMbIsDeleted=0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            {
                string SortDir = string.Empty;
                if (dir4 == SortDirection.Ascending)
                {
                    dir4 = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir4 = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt1);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                GridSeason.DataSource = sortedView;
                GridSeason.DataBind();
            }
        }

        protected void GridEllergie_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand("Select * from AllergyMaster where AMbIsDeleted=0", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            {
                string SortDir = string.Empty;
                if (dir5 == SortDirection.Ascending)
                {
                    dir5 = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir5 = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt1);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                GridEllergie.DataSource = sortedView;
                GridEllergie.DataBind();
            }
        }

        public SortDirection dir
        {
            get
            {
                if (ViewState["dirFood"] == null)
                {
                    ViewState["dirFood"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirFood"];
            }
            set
            {
                ViewState["dirFood"] = value;
            }

        }
        public SortDirection dir1
        {
            get
            {
                if (ViewState["dirDisease"] == null)
                {
                    ViewState["dirDisease"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirDisease"];
            }
            set
            {
                ViewState["dirDisease"] = value;
            }

        }
        public SortDirection dir2
        {
            get
            {
                if (ViewState["dirExercise"] == null)
                {
                    ViewState["dirExercise"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirExercise"];
            }
            set
            {
                ViewState["dirExercise"] = value;
            }

        }
        public SortDirection dir3
        {
            get
            {
                if (ViewState["dirDrugSupplement"] == null)
                {
                    ViewState["dirDrugSupplement"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirDrugSupplement"];
            }
            set
            {
                ViewState["dirDrugSupplement"] = value;
            }

        }
        public SortDirection dir4
        {
            get
            {
                if (ViewState["dirSeason"] == null)
                {
                    ViewState["dirSeason"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirSeason"];
            }
            set
            {
                ViewState["dirSeason"] = value;
            }

        }
        public SortDirection dir5
        {
            get
            {
                if (ViewState["dirEllergie"] == null)
                {
                    ViewState["dirEllergie"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirEllergie"];
            }
            set
            {
                ViewState["dirEllergie"] = value;
            }

        }

        public SortDirection dir6
        {
            get
            {
                if (ViewState["dirUnit"] == null)
                {
                    ViewState["dirUnit"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirUnit"];
            }
            set
            {
                ViewState["dirUnit"] = value;
            }

        }

        protected void grdUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUnit.PageIndex = e.NewPageIndex;
            gridBind_Unit();
        }

        protected void grdUnit_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt1 = new DataTable();
            cmd = new SqlCommand("Select * from UnitMaster", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);

            {
                string SortDir = string.Empty;
                if (dir5 == SortDirection.Ascending)
                {
                    dir5 = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir5 = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt1);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                grdUnit.DataSource = sortedView;
                grdUnit.DataBind();
            }
        }

        protected void grdUnit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Unit")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                grdUnit.EditIndex = rowindex;
                gridBind_Unit();
            }
            else if (e.CommandName == "Update_Unit")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = grdUnit.Rows[rowindex];
                    LinkButton lb = (LinkButton)grid.FindControl("btnedit");

                    string Unit = ((TextBox)grid.FindControl("EditUnit")).Text;
                    string gramsperunit = ((TextBox)grid.FindControl("EditGramsPerUnit")).Text;

                    cmd = new SqlCommand("update UnitMaster set UMsUnitName=@name, UMnGramsPerUnit=@grams where UMnUnitID=@id", con);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = Unit;
                    cmd.Parameters.Add("@grams", SqlDbType.Float).Value = gramsperunit;
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    grdUnit.EditIndex = -1;
                    cmd.Parameters.Clear();
                    gridBind_Unit();
                    msgbox("Unit updated successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_Unit")
            {
                grdUnit.EditIndex = -1;
                gridBind_Unit();
            }
            else if (e.CommandName == "Delete_Unit")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = grdUnit.Rows[rowIndex];
                    int id = Convert.ToInt32(((Label)grid.FindControl("lblID")).Text);
                    cmd = new SqlCommand("delete from UnitMaster where UMnUnitID=@id", con);
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    cmd.Parameters.Clear();
                    gridBind_Unit();
                    msgbox("Unit Updated Successfully!!!");
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Insert_Unit")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;

                    GridViewRow grid = grdUnit.FooterRow;

                    string unit = ((TextBox)grid.FindControl("txtUnit")).Text;
                    string gramsperunit = ((TextBox)grid.FindControl("txtGramsPerUnit")).Text;

                    cmd = new SqlCommand("insert into UnitMaster(UMsUnitName,UMdtCreatedOn,UMsCreatedBy,UMnGramsPerUnit) values(@name,dateadd(minute,330,getutcdate()),@user,@grams)", con);
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = unit;
                    cmd.Parameters.Add("@grams", SqlDbType.Float).Value = gramsperunit;
                    cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = Convert.ToString(Session["UserCode"]);
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from  UnitMaster  where upper(UMsUnitName)=upper('" + unit + "')") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Unit Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        cmd.Parameters.Clear();
                        msgbox("Unit Added successfully!!!");
                    }
                    gridBind_Unit();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
        }

        protected void gridBind_Unit()
        {
            try
            {
                cmd = new SqlCommand("Select * from UnitMaster", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                grdUnit.DataSource = dt;
                grdUnit.DataBind();


            }
            catch (Exception ex) { }
            finally { }
        }

        private void GenerateAlphabets()
        {
            List<ListItem> alphabets = new List<ListItem>();
            ListItem alphabet = new ListItem();
            alphabet.Value = "ALL";
            alphabet.Selected = alphabet.Value.Equals(ViewState["CurrentAlphabet"]);
            alphabets.Add(alphabet);
            for (int i = 65; i <= 90; i++)
            {
                alphabet = new ListItem();
                alphabet.Value = Char.ConvertFromUtf32(i);
                alphabet.Selected = alphabet.Value.Equals(ViewState["CurrentAlphabet"]);
                alphabets.Add(alphabet);
            }
            rptAlphabets.DataSource = alphabets;
            rptAlphabets.DataBind();
        }

        protected void lnkAlphabet_Click(object sender, EventArgs e)
        {
            LinkButton lnkAlphabet = (LinkButton)sender;
            ViewState["CurrentAlphabet"] = lnkAlphabet.Text;
            this.GenerateAlphabets();
            GridFood.PageIndex = 0;
            this.gridBind_Food();
        }

        protected void rptAlphabets_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            LinkButton btn = e.Item.FindControl("lnkAlphabet") as LinkButton;
            if (btn != null)
            {
                btn.Click += lnkAlphabet_Click;
                Toolkit1.RegisterAsyncPostBackControl(btn);
            }
        }

        public DataTable load_category()
        {
            DataTable dt = new DataTable();
            string sql = "select * from FoodGroupMaster";
            SqlDataAdapter sd = new SqlDataAdapter(sql, con);
            sd.Fill(dt);
            return dt;
        }
        public DataTable load_unit()
        {
            DataTable dt = new DataTable();
            string sql = "select * from UnitMaster";
            SqlDataAdapter sd = new SqlDataAdapter(sql, con);
            sd.Fill(dt);
            return dt;
        }

        protected void GridFood_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // Find the product drop-down list, you can id (or cell number)
                var ddlProducts = e.Row.FindControl("ddlFoodType") as DropDownList;
                //var ddlUnits = e.Row.FindControl("ddlUnit") as DropDownList;
                // var ddlProducts = e.Row.Cells[0].Controls[0]; // Finding by cell number and index
                if (null != ddlProducts)
                {
                    ddlProducts.DataSource = load_category();
                    ddlProducts.DataTextField = "FGsGroupName";
                    ddlProducts.DataValueField = "FGnGroupId";
                    ddlProducts.DataBind();
                }
                //if (null != ddlUnits)
                //{
                //    ddlUnits.DataSource = load_unit();
                //    ddlUnits.DataTextField = "UMsUnitName";
                //    ddlUnits.DataValueField = "UMsUnitName";
                //    ddlUnits.DataBind();
                //}
            }
            if (e.Row.RowType == DataControlRowType.DataRow && GridFood.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlFoodType = (DropDownList)e.Row.FindControl("EditFoodType");
                ddlFoodType.DataSource = load_category();
                ddlFoodType.DataTextField = "FGsGroupName";
                ddlFoodType.DataValueField = "FGnGroupId";
                ddlFoodType.DataBind();
                ddlFoodType.Items.FindByValue((e.Row.FindControl("lblfoodtype") as Label).Text).Selected = true;

                //DropDownList ddlUnits = (DropDownList)e.Row.FindControl("EditUnit");
                //ddlUnits.DataSource = load_unit();
                //ddlUnits.DataTextField = "UMsUnitName";
                //ddlUnits.DataValueField = "UMsUnitName";
                //ddlUnits.DataBind();
                //ddlUnits.Items.FindByValue((e.Row.FindControl("lblunit") as Label).Text).Selected = true;
            }
        }

        protected void grdCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Category")
            {
                int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                grdCategory.EditIndex = rowindex;
                gridBind_Category();
            }
            else if (e.CommandName == "Update_Category")
            {
                try
                {
                    int rowindex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    int id = Convert.ToInt32(e.CommandArgument);
                    GridViewRow grid = grdCategory.Rows[rowindex];

                    string Image;
                    string Group = ((TextBox)grid.FindControl("EditGroup")).Text;
                    if (((FileUpload)grid.FindControl("imgUpload")).HasFile)
                    {
                        string filename = Path.GetFileNameWithoutExtension(((FileUpload)grid.FindControl("imgUpload")).PostedFile.FileName);
                        string extension = Path.GetExtension(((FileUpload)grid.FindControl("imgUpload")).PostedFile.FileName);
                        string filepath = Server.MapPath("~/Upload/FoodGroup") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                        if (File.Exists(filepath))
                            File.Delete(filepath);
                        else
                            ((FileUpload)grid.FindControl("imgUpload")).PostedFile.SaveAs(filepath);
                        Image = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    }
                    else
                        Image = ((Label)grid.FindControl("lblImage")).Text;

                    cmd = new SqlCommand("update FoodGroupMaster set FGsGroupName=@group,FGsImage=@Image where FGnGroupId=@id", con);
                    cmd.Parameters.Add("@group", SqlDbType.NVarChar).Value = Group;
                    cmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    grdCategory.EditIndex = -1;
                    msgbox("Category updated successfully!!!");
                    cmd.Parameters.Clear();
                    gridBind_Category();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
            else if (e.CommandName == "Cancel_Category")
            {
                grdCategory.EditIndex = -1;
                gridBind_Category();
            }
            else if (e.CommandName == "Insert_Category")
            {
                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                    GridViewRow grid = grdCategory.FooterRow;
                    string Group = ((TextBox)grid.FindControl("txtGroup")).Text;
                    string Image = string.Empty;
                    if (((FileUpload)grid.FindControl("imgUpload")).HasFile)
                    {
                        string filename = Path.GetFileNameWithoutExtension(((FileUpload)grid.FindControl("imgUpload")).PostedFile.FileName);
                        string extension = Path.GetExtension(((FileUpload)grid.FindControl("imgUpload")).PostedFile.FileName);
                        string filepath = Server.MapPath("~/Upload/FoodGroup") + "\\" + filename + DateTime.Now.ToString("_ddMMyyyyhhmmss") + extension;

                        if (File.Exists(filepath))
                            File.Delete(filepath);
                        else
                            ((FileUpload)grid.FindControl("imgUpload")).PostedFile.SaveAs(filepath);
                        Image = filepath.Substring(filepath.LastIndexOf("\\") + 1);
                    }


                    cmd = new SqlCommand("insert into FoodGroupMaster values(@Group,dateadd(minute,330,getutcdate()),@Image)", con);
                    cmd.Parameters.Add("@Group", SqlDbType.NVarChar).Value = Group;
                    cmd.Parameters.Add("@Image", SqlDbType.NVarChar).Value = Image;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    if (checkExist("select count(*) from  FoodGroupMaster  where upper(FGsGroupName)=upper('" + Group + "')") > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Category Already exist'});", true);
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        cmd.Parameters.Clear();
                        msgbox("Category Added successfully!!!");
                    }

                    gridBind_Category();
                }
                catch (Exception ex) { }
                finally { if (con.State == ConnectionState.Open) con.Close(); }
            }
        }

        protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCategory.PageIndex = e.NewPageIndex;
            gridBind_Category();
        }

        protected void gridBind_Category()
        {
            try
            {
                cmd = new SqlCommand("Select * from FoodGroupMaster", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                grdCategory.DataSource = dt;
                grdCategory.DataBind();
            }
            catch (Exception ex) { }
            finally { }
        }
        public void msgbox(string message)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'" + message + "'});", true);
        }

        private int checkExist(string query)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                dt = new DataTable();
                da.Fill(dt);
                return Convert.ToInt16(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally { }
        }

        protected void grdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    LinkButton lb = (LinkButton)e.Row.FindControl("btnUpdate");
                    if (lb != null)
                    {
                        Toolkit1.RegisterPostBackControl(lb);
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("linkAdd");
                if (lb != null)
                {
                    Toolkit1.RegisterPostBackControl(lb);
                }
            }
            //foreach (GridViewRow Row in grdCategory.Rows)
            //{
            //    LinkButton lb = (LinkButton)e.Row.FindControl("btnUpdate");
            //    if (lb != null)
            //    {
            //        Toolkit1.RegisterPostBackControl(lb);
            //    }
            //}

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                ViewState["CurrentAlphabet"] = txtSearch.Text.Substring(0, 1);
                this.GenerateAlphabets();
                GridFood.PageIndex = 0;
                this.gridBind_Food(txtSearch.Text);
            }
            else
            {

                ViewState["CurrentAlphabet"] = "A";
                this.GenerateAlphabets();
                GridFood.PageIndex = 0;
                this.gridBind_Food();
            }
        }

    }

}