using Diet.Business.Core;
using Diet.Business.Core.ModComorbidity;
using Diet.Business.Core.ModDietMaster;
using Diet.Business.Model;
using Diet.Common;
using Diet.DataAccess.DataManagers.ModHelper;
using GNHClientUI.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI
{
    public partial class NewPatient : System.Web.UI.Page
    {
        DietMasterManager obj;
        CustomerDetailManager cobj;
        AnthropometricsManager aobj;
        BioChemicalManager bobj;
        ComorbidityManager crobj;


        DataTable dt = new DataTable();

        DataSet ds = new DataSet();
        GNHUtility objUtility = new GNHUtility();
        Int64 state = 0;
        Int64 citycode = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Toolkit1.RegisterPostBackControl(btnSave);
            //Toolkit1.RegisterPostBackControl(btnAnthro);
            //Toolkit1.RegisterPostBackControl(btnBio);
            //Toolkit1.RegisterPostBackControl(btnComorbidity);
            //Toolkit1.RegisterPostBackControl(btnClientData);
            txtBMI.Attributes.Add("readonly", "readonly");
            txtBMICategory.Attributes.Add("readonly", "readonly");
            txtBodyFrame.Attributes.Add("readonly", "readonly");
            txtIdealWeight.Attributes.Add("readonly", "readonly");

            if (!IsPostBack)
            {
                string query = "select CountryId, County from Country";
                BindDropDownList(ddlCountries, query, "County", "CountryId", "Select Country");
                ddlStates.Enabled = false;
                ddlCities.Enabled = false;
                ddlStates.Items.Insert(0, new ListItem("Select State", "0"));
                ddlCities.Items.Insert(0, new ListItem("Select City", "0"));
                //ModalPopupExtender1.Hide();
                //Panel1.Visible = false;
                PatientInfo.PatientID = Convert.ToInt32(Session["PatientID"].ToString());
                if (PatientInfo.PatientID != 0)
                {
                    bindData();
                    Country_Changed(sender, e);
                    ddlStates.Items.FindByValue(state.ToString()).Selected = true;
                    State_Changed(sender, e);
                    ddlCities.Items.FindByValue(citycode.ToString()).Selected = true;

                }
                if (Session["Operation"].ToString() == "New")
                {
                    ddlCountries.Items.FindByText("India").Selected = true;
                    Country_Changed(sender, e);
                    State_Changed(sender, e);
                    //btnSave.Enabled = true;

                }
                else
                {
                    //btnSave.Enabled = false;
                }
            }
        }
        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            if (txtDOB.Text != "")
            {
                DateTime dt = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime today = DateTime.Today;
                int age = today.Year - dt.Year;

                if (dt > today.AddYears(-age))
                    age--;
                txtAge.Text = age.ToString();
            }
        }
        private DietMaster PrepareDietMaster()
        {
            //Prepare Parameters
            DietMaster ObjDietMaster = new DietMaster();

            ObjDietMaster.CustomerName = txtName.Text.Trim();
            ObjDietMaster.MiddleName = txtMiddleName.Text.Trim();
            ObjDietMaster.LastName = txtLastName.Text.Trim();
            ObjDietMaster.CustomerAge = Convert.ToInt16("0" + txtAge.Text);
            ObjDietMaster.Gender = ddlGender.SelectedItem.Value.ToString().Equals("Male") ? 0 : 1; ;
            DateTime dtdob = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ObjDietMaster.DOB = dtdob;
            ObjDietMaster.Address1 = txtAddress1.Text;
            ObjDietMaster.Locality = txtLocality.Text;
            ObjDietMaster.City = ddlCountries.SelectedValue.ToString();
            ObjDietMaster.State = ddlStates.SelectedValue.ToString();
            ObjDietMaster.Country = ddlCities.SelectedValue.ToString();
            ObjDietMaster.PinCode = txtPin.Text;
            ObjDietMaster.Email = txtEmail.Text;
            ObjDietMaster.Mobile = txtMobile.Text;
            ObjDietMaster.Landline = txtLandline.Text;
            ObjDietMaster.Profession = ddlProfession.SelectedItem.ToString();
            if (ddlProfession.SelectedItem.ToString() == "Other,Specify")
                ObjDietMaster.ProfessionOthers = txtProfessionOthers.Text;
            else
                ObjDietMaster.ProfessionOthers = "";
            //ObjDietMaster.PresentExercise = txtExercise1.Text;
            ObjDietMaster.PresentExercise = "";
            //ObjDietMaster.ExersizeActivity = txtExercise2.Text;
            ObjDietMaster.ExersizeActivity = "";
            ObjDietMaster.CustomerDetailNotes = txtNotes.Text;
            ObjDietMaster.Session = Convert.ToString(Session["UserCode"]);

            ObjDietMaster.AnthropometricID = 0;
            ObjDietMaster.MeasuredWeight = objUtility.GetWeight(Convert.ToDouble("0" + txtWeight.Text), ddlWeightUnit.SelectedValue.ToUpper());
            ObjDietMaster.MeasuredHeight = objUtility.GetHeight(Convert.ToDouble("0" + txtHeight.Text), ddlHeightUnit.SelectedValue.ToUpper());
            //ObjDietMaster.IdealBodyWeight = GetWeight(Convert.ToDouble(txtIdealWeight.Text), ddlWeightUnit1.SelectedValue.ToUpper());
            ObjDietMaster.CalculatedBMI = Convert.ToDouble("0" + txtBMI.Text);
            ObjDietMaster.BMIPer = Convert.ToDouble("0" + txtBMIPer.Text);
            ObjDietMaster.BMICategory = txtBMICategory.Text;
            ObjDietMaster.FatPer = Convert.ToDouble("0" + txtFatPer.Text);
            ObjDietMaster.NeckCircumference = objUtility.GetHeight(Convert.ToDouble("0" + txtNeck.Text), ddlNeck.SelectedItem.ToString().ToUpper());
            ObjDietMaster.MeasuredWaist = objUtility.GetHeight(Convert.ToDouble("0" + txtWaist.Text), ddlWaistUnit.SelectedValue.ToString().ToUpper());
            ObjDietMaster.MeasuredWrist = objUtility.GetHeight(Convert.ToDouble("0" + txtwrist.Text), ddlWristUnit.SelectedValue.ToString().ToUpper());
            ObjDietMaster.MUAC = objUtility.GetHeight(Convert.ToDouble("0" + txtMUAC.Text.ToString()), ddlMUAC.SelectedValue.ToString().ToUpper()); ;
            ObjDietMaster.BloodPressure = txtBloodPressure.Text;
            ObjDietMaster.BodyFrame = txtBodyFrame.Text;
            ObjDietMaster.IdealBodyWeight = Convert.ToDouble("0" + txtIdealWeight.Text);
            if (txtWeightGainLossMonth.Text.Contains("-"))
                ObjDietMaster.WeightGainLossMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossMonth.Text.Replace("-", ""), CultureInfo.InvariantCulture), ddlWeightUnit5.SelectedValue.ToUpper()) * -1;
            else
                ObjDietMaster.WeightGainLossMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossMonth.Text.Replace("+", ""), CultureInfo.InvariantCulture), ddlWeightUnit5.SelectedValue.ToUpper());
            if (txtWeightGainLossSixMonth.Text.Contains("-"))
                ObjDietMaster.WeightGainLossSixMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossSixMonth.Text.Replace("-", ""), CultureInfo.InvariantCulture), ddlWeightUnit6.SelectedValue.ToUpper()) * -1;
            else
                ObjDietMaster.WeightGainLossSixMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossSixMonth.Text.Replace("+", ""), CultureInfo.InvariantCulture), ddlWeightUnit6.SelectedValue.ToUpper());
            if (txtweightGainLossYear.Text.Contains("-"))
                ObjDietMaster.WeightGainLossYear = objUtility.GetWeight(double.Parse("0" + txtweightGainLossYear.Text.Replace("-", ""), CultureInfo.InvariantCulture), ddlWeightUnit7.SelectedValue.ToUpper()) * -1;
            else
                ObjDietMaster.WeightGainLossYear = objUtility.GetWeight(double.Parse("0" + txtweightGainLossYear.Text.Replace("+", ""), CultureInfo.InvariantCulture), ddlWeightUnit7.SelectedValue.ToUpper());

            ObjDietMaster.ReasonGainLoss = txtReason.Text;
            ObjDietMaster.AnthrpometricsNotes = txtNotes2.Text.Trim();
            ObjDietMaster.MussleMass = Convert.ToDouble('0' + txtMuscleMass.Text);
            ObjDietMaster.BoneMass = Convert.ToDouble('0' + txtBoneMass.Text);
            ObjDietMaster.BodyWater = Convert.ToDouble('0' + txtBodyWater.Text);
            ObjDietMaster.VisceralFat = Convert.ToDouble('0' + txtVisceralFat.Text);

            //Biochemical Labs
            ObjDietMaster.BioChemicalLabID = 0;
            //dtdob = DateTime.ParseExact(DateTime.UtcNow.AddHours(5.5), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            dtdob = DateTime.ParseExact(txtTestDate.Text.Equals("") ? DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy") : txtTestDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ObjDietMaster.TestDate = dtdob;
            ObjDietMaster.FastingGlucose = Convert.ToDouble(txtGlucose.Text.Equals("") ? "-1" : txtGlucose.Text);
            ObjDietMaster.PP = Convert.ToDouble(txtPP.Text.Equals("") ? "-1" : txtPP.Text);
            ObjDietMaster.HB = Convert.ToDouble(txtHB.Text.Equals("") ? "-1" : txtHB.Text);
            ObjDietMaster.Creatinine = Convert.ToDouble(txtCreatinine.Text.Equals("") ? "-1" : txtCreatinine.Text);
            ObjDietMaster.Albumin = Convert.ToDouble(txtAlbumin.Text.Equals("") ? "-1" : txtAlbumin.Text);
            ObjDietMaster.HbA1C = Convert.ToDouble(txtHba1c.Text.Equals("") ? "-1" : txtHba1c.Text);
            ObjDietMaster.AltSGPT = Convert.ToDouble(txtAltsgpt.Text.Equals("") ? "-1" : txtAltsgpt.Text);
            ObjDietMaster.AltSGOT = Convert.ToDouble(txtAltsgot.Text.Equals("") ? "-1" : txtAltsgot.Text);
            ObjDietMaster.Hematocrit = Convert.ToDouble(txtHematocrit.Text.Equals("") ? "-1" : txtHematocrit.Text);
            ObjDietMaster.Triglycerides = Convert.ToDouble(txtTriglycerides.Text.Equals("") ? "-1" : txtTriglycerides.Text);
            ObjDietMaster.TSH = Convert.ToDouble(txtTsh.Text.Equals("") ? "-1" : txtTsh.Text);
            ObjDietMaster.HDL = Convert.ToDouble(txtHdl.Text.Equals("") ? "-1" : txtHdl.Text);
            ObjDietMaster.LDL = Convert.ToDouble(txtLDL.Text.Equals("") ? "-1" : txtLDL.Text);
            ObjDietMaster.UricAcid = Convert.ToDouble(txtUricAcid.Text.Equals("") ? "-1" : txtUricAcid.Text);
            ObjDietMaster.TotalCholesterol = Convert.ToDouble(txtCholesterol.Text.Equals("") ? "-1" : txtCholesterol.Text);
            ObjDietMaster.AlkalinePhosphatase = Convert.ToDouble(txtAlkaline.Text.Equals("") ? "-1" : txtAlkaline.Text);
            ObjDietMaster.VitaminD3 = Convert.ToDouble(txtVitamind3.Text.Equals("") ? "-1" : txtVitamind3.Text);
            ObjDietMaster.VitaminB12 = Convert.ToDouble(txtVitaminb12.Text.Equals("") ? "-1" : txtVitaminb12.Text);
            ObjDietMaster.BSL = Convert.ToDouble(txtRandomBsl.Text.Equals("") ? "-1" : txtRandomBsl.Text);
            ObjDietMaster.RBC = Convert.ToDouble(txtRbc.Text.Equals("") ? "-1" : txtRbc.Text);
            ObjDietMaster.Platelet = Convert.ToDouble(txtPlatelet.Text.Equals("") ? "-1" : txtPlatelet.Text);
            ObjDietMaster.OthersBioChemicalLabs = "";
            ObjDietMaster.BioChemicalLabNotes = "";

            //comorbidity
            ObjDietMaster.ComorbidityID = 0;
            ObjDietMaster.CHF = ddlChf.SelectedItem.ToString();
            ObjDietMaster.Hypertension = ddlHypertension.SelectedItem.ToString();
            ObjDietMaster.Asthma = ddlAsthma.SelectedItem.ToString();
            ObjDietMaster.SleepApnea = ddlSleepApnea.SelectedItem.ToString();
            ObjDietMaster.Thyroid = ddlThyroid.SelectedItem.ToString();
            if (ddlThyroid.SelectedItem.ToString().ToUpper() == "NO")
                ObjDietMaster.ThyroidType = ddlThyroidType.SelectedIndex.ToString();
            else
                ObjDietMaster.ThyroidType = ddlThyroidType.SelectedIndex.ToString();

            ObjDietMaster.Diabetes = ddlDiabetes.SelectedItem.ToString();
            ObjDietMaster.IHD = ddlIhd.SelectedItem.ToString();
            ObjDietMaster.FunctionalStatus = ddlFunctionslStatus.SelectedItem.ToString();
            ObjDietMaster.ComorbidityOthers = txtChronicOthers.Text;
            ObjDietMaster.ComorbidityNotes = txtNotes4.Text;
            ObjDietMaster.LeverDisorders = ddlLiver.SelectedItem.ToString();
            ObjDietMaster.CardiacDisorders = ddlCardiacDisorders.SelectedItem.ToString();
            ObjDietMaster.KidneyDisorders = ddlKidney.SelectedItem.ToString();
            ObjDietMaster.FollowedParticularDietForProb = txtChronicDietDetails.Text;

            ObjDietMaster.Smoking = "No";
            ObjDietMaster.NoOfTypicalMealsInDay = Convert.ToInt16("0");
            ObjDietMaster.Alcohol = "No";
            ObjDietMaster.NoOfDrinks = 0;
            ObjDietMaster.FrequencyOfDrinks = "Daily";
            ObjDietMaster.TypeOfDrink = "";

            ObjDietMaster.NoOfTypicalSnaxsInDay = Convert.ToInt16("0");
            ObjDietMaster.RegularExcercise = "";
            ObjDietMaster.ExcersizeDetail = "";
            ObjDietMaster.SleepHoursPerDay = "";
            ObjDietMaster.NoOfTeaCoffeeInDay = "";
            ObjDietMaster.TeaCoffeeFrequency = "Daily";
            ObjDietMaster.ActivityFactor = "Sedentary(little or no exercise)";
            ObjDietMaster.BMR = Convert.ToDouble("0");
            ObjDietMaster.Calorie = Convert.ToDouble("0");
            ObjDietMaster.CarbhohydratesPercent = Convert.ToDouble("0");
            ObjDietMaster.FatPercent = Convert.ToDouble("0");
            ObjDietMaster.ProteinPercent = Convert.ToDouble("0");
            ObjDietMaster.Calorie1 = Convert.ToDouble("0");
            ObjDietMaster.CarbhohydratesPercent1 = Convert.ToDouble("0");
            ObjDietMaster.FatPercent1 = Convert.ToDouble("0");
            ObjDietMaster.ProteinPercent1 = Convert.ToDouble("0");
            ObjDietMaster.GrainsServings = "";
            ObjDietMaster.DalsServings = "";
            ObjDietMaster.MilkServings = "";
            ObjDietMaster.NonvegServings = "";
            ObjDietMaster.VegetablesServings = "";
            ObjDietMaster.FruitsServings = "";
            ObjDietMaster.SugarServings = "";
            ObjDietMaster.FatServings = "";
            ObjDietMaster.WaterServings = "";
            ObjDietMaster.BiscuitServings = "";
            ObjDietMaster.NonvegTypes = "FALSE@|@FALSE@|@FALSE@|@FALSE@|@FALSE";
            ObjDietMaster.NonvegValues = "@|@@|@@|@";
            ObjDietMaster.NonvegQuantity = "";

            ObjDietMaster.DietLifeHistoryID = 0;
            ObjDietMaster.DietAndLifeStyleNotes = "";
            ObjDietMaster.DietHistoryID = 0;
            ObjDietMaster.DietType = "Vegetarian";
            ObjDietMaster.DietTypeDetails = "";
            ObjDietMaster.EatWhenStressed = "No";
            ObjDietMaster.FreqOutFoodEat = "Daily";
            ObjDietMaster.EatWhenBored = "No";
            ObjDietMaster.BreakfastEveryDay = "No";
            ObjDietMaster.EatWhenWatchTV = "No";
            ObjDietMaster.Caloricbeverages = "";
            ObjDietMaster.TriedWeightLossDiet = "No";
            ObjDietMaster.WtLossGainSixMon = "No";
            ObjDietMaster.Pregnant = "No";
            ObjDietMaster.LactatingMother = "No";
            ObjDietMaster.BabyAge = "Not available";
            ObjDietMaster.ClinicComplaintsNotes = "";

            //Gastrointenstinal Problems            
            ObjDietMaster.Heartburn = "No";
            ObjDietMaster.Vomiting = "No";
            ObjDietMaster.Bloating = "No";
            ObjDietMaster.LaxativeAntacide = "No";
            ObjDietMaster.Gas = "No";
            ObjDietMaster.Constipation = "No";
            ObjDietMaster.Diarrhoea = "No";
            ObjDietMaster.HomeRemedy = "No";
            ObjDietMaster.GastroOthers = "";

            ObjDietMaster.TakeVitaminSup = "";
            ObjDietMaster.VitaminSupDet = "";
            ObjDietMaster.TakeMineralSup = "No";
            ObjDietMaster.MineralSupDet = "";
            ObjDietMaster.OralDrugDType = "No";
            ObjDietMaster.OralDrugDet = "";
            ObjDietMaster.MedicationOthers = "";

            ObjDietMaster.OilUseDetail = "";
            ObjDietMaster.OilQuantityForMonth = "";
            ObjDietMaster.SugarQuantityForMonth = "";
            ObjDietMaster.NoOfMembersInFamily = Convert.ToInt16("0");


            ObjDietMaster.DietRecallID = 0;
            ObjDietMaster.Meal1 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal2 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal3 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal4 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal5 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal6 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.RecallDietNotes = "";

            //Retaining old values
            ObjDietMaster.GastProbID = Convert.ToInt16("0" + hdnGPID.Value);
            ObjDietMaster.MedicationID = Convert.ToInt16("0" + hdnMCID.Value);
            ObjDietMaster.DietLifeHistoryID = Convert.ToInt16("0" + hdnDHID.Value);

            return ObjDietMaster;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);            
            if (!IsGroupValid("ValidationGroup"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details validation fails'});", true);
                //Tell.text("Client details validation fails", this);
                Page.Validate("ValidationGroup");
                return;
            }
            if (!IsGroupValid("ValidationGroup1"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Antropometrics validation fails'});", true);
                //Tell.text("Antropometrics validation fails", this);
                Page.Validate("ValidationGroup1");
                return;
            }
            if (!IsGroupValid("ValidationGroup2"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Biochemical validation fails'});", true);
                //Tell.text("Biochemical validation fails", this);
                Page.Validate("ValidationGroup2");
                return;
            }

            if (Page.IsValid)
            {

                DietMaster objDietMaster = PrepareDietMaster();
                objDietMaster.Operation = Convert.ToString(Session["PatientID"]).Equals("0") ? 1 : 2;
                objDietMaster.CustomerID = Convert.ToString(Session["PatientID"]).Equals("0") ? 0 : PatientInfo.PatientID;

                int i = 0;
                //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
                //{
                //    i = DietMasterManager.ModifyDietMaster(objDietMaster);
                //});
                obj = new DietMasterManager();
                i = obj.ModifyDietMaster(objDietMaster);
                if (i == -5)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Record already exists with same DOB and Mobile!!!!'});", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details saved Succesfully!!!!'});", true);
                setUnits();
                Server.Transfer("~/Screens/Client_Details.aspx");

            }

            //clear();
        }
        protected void clear()
        {
            txtName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtDOB.Text = "";
            txtAge.Text = "";
            txtEmail.Text = "";
            txtAddress1.Text = "";
            txtLocality.Text = "";
            txtMobile.Text = "";
            txtLandline.Text = "";
            ddlGender.ClearSelection();
            txtPin.Text = "";
            txtProfessionOthers.Text = "";
            //txtExercise1.Text = "";
            txtNotes.Text = "";
            txtWeight.Text = "";
            txtHeight.Text = "";
            txtBMI.Text = "";
            txtBMIPer.Text = "";
            txtBMICategory.Text = "";
            txtFatPer.Text = "";
            txtNeck.Text = "";
            txtWaist.Text = "";
            txtwrist.Text = "";
            txtMUAC.Text = "";
            txtBloodPressure.Text = "";
            txtBodyFrame.Text = "";
            txtIdealWeight.Text = "";
            txtWeightGainLossMonth.Text = "";
            txtWeightGainLossSixMonth.Text = "";
            txtweightGainLossYear.Text = "";
            txtReason.Text = "";
            txtNotes2.Text = "";
        }
        private void BindDropDownList(DropDownList ddl, string query, string text, string value, string defaultText)
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    ddl.DataSource = cmd.ExecuteReader();
                    ddl.DataTextField = text;
                    ddl.DataValueField = value;
                    ddl.DataBind();
                    con.Close();
                }
            }
            ddl.Items.Insert(0, new ListItem(defaultText, "0"));
        }

        protected void Country_Changed(object sender, EventArgs e)
        {
            ddlStates.Enabled = false;
            ddlCities.Enabled = false;
            ddlStates.Items.Clear();
            ddlCities.Items.Clear();
            ddlStates.Items.Insert(0, new ListItem("Select State", "0"));
            ddlCities.Items.Insert(0, new ListItem("Select City", "0"));
            int countryId = int.Parse(ddlCountries.SelectedItem.Value);
            if (countryId > 0)
            {
                string query = string.Format("select StateId, State from countryState where CountryId = {0}", countryId);
                BindDropDownList(ddlStates, query, "State", "StateId", "Select State");
                ddlStates.Enabled = true;
            }

            //RegularExpressionValidator7.ValidationExpression = Convert.ToString(new HelperMasterDataManager().GetRegexForCountry(Convert.ToInt16(ddlCountries.SelectedValue)).Rows[0][0]);
            //RegularExpressionValidator62.ValidationExpression = Convert.ToString(new HelperMasterDataManager().GetRegexForCountry(Convert.ToInt16(ddlCountries.SelectedValue)).Rows[0][0]);
            //lblMob1.Text = Convert.ToString(new HelperMasterDataManager().GetCountryCode(Convert.ToInt16(ddlCountries.SelectedValue)).Rows[0][0]);
            //lblMob2.Text = Convert.ToString(new HelperMasterDataManager().GetCountryCode(Convert.ToInt16(ddlCountries.SelectedValue)).Rows[0][0]);
        }

        protected void State_Changed(object sender, EventArgs e)
        {
            ddlCities.Enabled = false;
            ddlCities.Items.Clear();
            ddlCities.Items.Insert(0, new ListItem("Select City", "0"));
            int stateId = int.Parse(ddlStates.SelectedItem.Value);
            if (stateId > 0)
            {
                string query = string.Format("select CityId, City from stateCity where StateId = {0}", stateId);
                BindDropDownList(ddlCities, query, "City", "CityId", "Select City");
                ddlCities.Enabled = true;
            }
        }

        protected void btnClientData_Click(object sender, EventArgs e)
        {
            if (!IsGroupValid("ValidationGroup")) return;

            System.Threading.Thread.Sleep(3000);           
            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {

                CustomerDetail objcustMaster = PrepareClientmaster();
                objcustMaster.Operation = 2;
                objcustMaster.CustomerID = PatientInfo.PatientID;

                cobj = new CustomerDetailManager();
                PatientInfo.PatientID = cobj.ModifyCustomerDetail(objcustMaster);
                Session["PatientID"] = PatientInfo.PatientID;
                if (PatientInfo.PatientID == 1)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details updated Succesfully!!!!'});", true);
                else if (PatientInfo.PatientID == -5)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Record already exists with same DOB and Mobile!!!!'});", true);
                bindData();
            }
            else
            {
                CustomerDetail objcustMaster = PrepareClientmaster();
                objcustMaster.Operation = 1;
                objcustMaster.CustomerID = PatientInfo.PatientID;

                cobj = new CustomerDetailManager();
                PatientInfo.PatientID = cobj.ModifyCustomerDetail(objcustMaster);
                Session["PatientID"] = PatientInfo.PatientID;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details Saved Succesfully!!!!'});", true);
                bindData();
            }
        }
        protected void btnAnthro_Click(object sender, EventArgs e)
        {
            if (!IsGroupValid("ValidationGroup1")) return;

            System.Threading.Thread.Sleep(3000);
            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {
                Anthropometrics objanthro = PrepareAnthro();
                objanthro.Operation = 2;
                objanthro.CustomerID = PatientInfo.PatientID;

                aobj = new AnthropometricsManager();
                int i = aobj.ModifyAnthropometrics(objanthro);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Antropometrics details saved!!!!'});", true);
                bindData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Save Client details first!!!!'});", true);
            }
            setUnits();
        }
        protected void btnComorbidity_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {
                Comorbidity obj = PrepareComorbidity();
                obj.Operation = 1;
                obj.CustomerID = PatientInfo.PatientID;

                crobj = new ComorbidityManager();
                int i = crobj.ModifyComorbidity(obj);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Comorbidity details saved!!!!'});", true);
                bindData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Save Client details first!!!!'});", true);
            }
        }
        protected void btnBio_Click(object sender, EventArgs e)
        {
            if (!IsGroupValid("ValidationGroup2")) return;

            System.Threading.Thread.Sleep(3000);
            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {
                BioChemicalLab objbio = PrepareBio();
                objbio.Operation = 2;
                objbio.CustomerID = PatientInfo.PatientID;

                bobj = new BioChemicalManager();
                int i = bobj.ModifyBiochemical(objbio);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'BiochemicalLabs details saved!!!!'});", true);
                bindData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Save Client details first!!!!'});", true);
            }

        }

        protected void bindData()
        {
            obj = new DietMasterManager();
            ds = obj.GetDietMaster(PatientInfo.PatientID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPatientID.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDnCustomerIDPK"]);
                txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsCustName"]);
                txtMiddleName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsMiddleName"]);
                txtLastName.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsLastName"]);
                txtAge.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDnCustAge"]);
                ddlGender.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CDnGender"]).Equals("0") ? "Male" : "Female";
                txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["CDdtDOB"].ToString()).ToString("dd/MM/yyyy");
                txtAddress1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsAddress1"]);
                txtLocality.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsLocality"]);
                ddlCountries.Items.FindByValue(ds.Tables[0].Rows[0]["CDsCountry"].ToString()).Selected = true;
                //txtCity.Text = Convert.ToString(ds.Rows[0]["CDsCity"]);
                state = Convert.ToInt64(ds.Tables[0].Rows[0]["CDsState"]);
                citycode = Convert.ToInt64(ds.Tables[0].Rows[0]["CDsCity"]);
                txtPin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsPincode"]).Equals("0") ? string.Empty : Convert.ToString(ds.Tables[0].Rows[0]["CDsPincode"]);
                txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsEmail"]);
                txtMobile.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsMobile"]);
                txtLandline.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsLandline"]);
                ddlProfession.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["CDsProfession"]);
                if (Convert.ToString(ds.Tables[0].Rows[0]["CDsProfession"]) == "Other,Specify")
                    txtProfessionOthers.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsProfessionOthers"]);
                else
                    txtProfessionOthers.Text = "";

                //txtExercise1.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsPresentExercise"]);
                //txtExercise2.Text = Convert.ToString(ds.Rows[0]["CDsExersizeActivity"]);
                txtNotes.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsNotes"]);
            }
            //ObjDietMaster.AnthropometricID = Convert.ToString(ds.Rows[0]["AMnAnthropometricIDPK"]);
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtWeight.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnMeasWt"]);
                txtHeight.Text = Convert.ToString(objUtility.GetHeightInCM(Convert.ToDouble(ds.Tables[1].Rows[0]["AMnMeasHt"]), "MTR"));
                txtBMI.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnCalculatedBMI"]);
                txtBMIPer.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnBMIPer"]);
                txtBMICategory.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnBMICat"]);
                txtFatPer.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnFatPer"]);
                txtNeck.Text = Convert.ToString(objUtility.GetHeightInCM(Convert.ToDouble(ds.Tables[1].Rows[0]["AMnNeckCircum"]), "MTR"));
                txtWaist.Text = Convert.ToString(objUtility.GetHeightInCM(Convert.ToDouble(ds.Tables[1].Rows[0]["AMnMeasWaist"]), "MTR"));
                txtwrist.Text = Convert.ToString(objUtility.GetHeightInCM(Convert.ToDouble(ds.Tables[1].Rows[0]["AMnMeasWrist"]), "MTR"));
                txtMUAC.Text = Convert.ToString(objUtility.GetHeightInCM(Convert.ToDouble(ds.Tables[1].Rows[0]["AMnMUAC"]), "MTR"));
                txtBloodPressure.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnBloodPressure"]);
                txtBodyFrame.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMsBodyFrame"]);
                txtIdealWeight.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnIdealBodyWt"]);

                txtWeightGainLossSixMonth.Text = Convert.ToDouble(ds.Tables[1].Rows[0]["AMnWtGainLossSixMon"]) >= 0 ? "+" + Convert.ToString(ds.Tables[1].Rows[0]["AMnWtGainLossSixMon"]) : Convert.ToString(ds.Tables[1].Rows[0]["AMnWtGainLossSixMon"]);
                txtweightGainLossYear.Text = Convert.ToDouble(ds.Tables[1].Rows[0]["AMnWtGainLossYear"]) >= 0 ? "+" + Convert.ToString(ds.Tables[1].Rows[0]["AMnWtGainLossYear"]) : Convert.ToString(ds.Tables[1].Rows[0]["AMnWtGainLossYear"]);
                txtWeightGainLossMonth.Text = Convert.ToDouble(ds.Tables[1].Rows[0]["AMnWtGainLossMon"]) >= 0 ? "+" + Convert.ToString(ds.Tables[1].Rows[0]["AMnWtGainLossMon"]) : Convert.ToString(ds.Tables[1].Rows[0]["AMnWtGainLossMon"]);
                txtReason.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMsReasonGainLoss"]);
                txtNotes2.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMsNotes"]);
                txtMuscleMass.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnMussleMass"]); ;
                txtBoneMass.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnBoneMass"]); ;
                txtBodyWater.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnBodyWater"]); ;
                txtVisceralFat.Text = Convert.ToString(ds.Tables[1].Rows[0]["AMnVisceralFat"]);

            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                txtTestDate.Text = Convert.ToDateTime(ds.Tables[2].Rows[0]["BCLdtTestDate"].ToString()).ToString("dd/MM/yyyy");
                txtGlucose.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnFastingGluc"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnFastingGluc"]);
                txtPP.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnPartPer"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnPartPer"]);
                txtHB.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnHB"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnHB"]);
                txtCreatinine.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnCreatinine"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnCreatinine"]);
                txtAlbumin.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnAlbumin"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnAlbumin"]);
                txtHba1c.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnHbA1C"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnHbA1C"]);
                txtAltsgpt.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnAltSGPT"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnAltSGPT"]);
                txtAltsgot.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnAltSGOT"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnAltSGOT"]);
                txtHematocrit.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnHematocrit"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnHematocrit"]);
                txtTriglycerides.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnTriglycerides"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnTriglycerides"]);
                txtTsh.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnTSH"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnTSH"]);
                txtHdl.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnHDL"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnHDL"]);
                txtLDL.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnLDL"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnLDL"]);
                txtUricAcid.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnUricAcid"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnUricAcid"]);
                txtCholesterol.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnTotCholesterol"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnTotCholesterol"]);
                txtAlkaline.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnAlkalinePhosphatase"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnAlkalinePhosphatase"]);
                txtVitamind3.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnVitaminD3"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnVitaminD3"]);
                txtVitaminb12.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnVitaminB12"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnVitaminB12"]);
                txtRandomBsl.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnBSL"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnBSL"]);
                txtRbc.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnRBC"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnRBC"]);
                txtPlatelet.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLnPlatelet"]).Equals("-1.00") ? "" : Convert.ToString(ds.Tables[2].Rows[0]["BCLnPlatelet"]);
                txtOthers.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLsOthers"]);
                txtNotes3.Text = Convert.ToString(ds.Tables[2].Rows[0]["BCLsNotes"]);
            }

            //Convert.ToString(ds.Rows[0]["CBnComorbidityIDPK"]);

            if (ds.Tables[3].Rows.Count > 0)
            {
                ddlChf.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsCHF"]);
                ddlHypertension.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsHypertension"]);
                ddlAsthma.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsAsthma"]);
                ddlSleepApnea.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsSleepApnea"]);

                ddlThyroid.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsThyroid"]);
                if (Convert.ToString(ds.Tables[3].Rows[0]["CBsThyroid"]).ToUpper() == "YES")
                    ddlThyroidType.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBSThyroidtype"]);

                ddlDiabetes.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsDiabetes"]);
                ddlIhd.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsIHD"]);
                ddlFunctionslStatus.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsFunctionalStatus"]);
                txtChronicOthers.Text = Convert.ToString(ds.Tables[3].Rows[0]["CBsOthers"]);
                txtNotes4.Text = Convert.ToString(ds.Tables[3].Rows[0]["CBsNotes"]);
                ddlLiver.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsLeverDis"]);
                ddlCardiacDisorders.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsCardiacDis"]);
                ddlKidney.SelectedValue = Convert.ToString(ds.Tables[3].Rows[0]["CBsKidneyDis"]);
                txtChronicDietDetails.Text = Convert.ToString(ds.Tables[3].Rows[0]["CBsParticularProbDet"]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                hdnDHID.Value = Convert.ToString(ds.Tables[4].Rows[0]["DLnDHIDFK"]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                hdnGPID.Value = Convert.ToString(ds.Tables[5].Rows[0]["CCnGastProbIDFK"]);
                hdnMCID.Value = Convert.ToString(ds.Tables[5].Rows[0]["CCnMedicationIDFK"]);
            }
        }

        private CustomerDetail PrepareClientmaster()
        {
            CustomerDetail obj = new CustomerDetail();
            obj.CustomerName = txtName.Text.Trim();
            obj.MiddleName = txtMiddleName.Text.Trim();
            obj.LastName = txtLastName.Text.Trim();
            obj.CustomerAge = Convert.ToInt16("0" + txtAge.Text);
            obj.Gender = ddlGender.SelectedItem.Value.ToString().Equals("Male") ? 0 : 1;

            DateTime dtdob = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj.DOB = dtdob;
            obj.Address1 = txtAddress1.Text;
            obj.Locality = txtLocality.Text;
            obj.City = ddlCities.SelectedValue.ToString();
            obj.State = ddlStates.SelectedValue.ToString();
            obj.Country = ddlCountries.SelectedValue.ToString();
            obj.Pincode = txtPin.Text;
            obj.Email = txtEmail.Text;
            obj.Mobile = txtMobile.Text;
            obj.Landline = txtLandline.Text;
            obj.Profession = ddlProfession.SelectedItem.ToString();
            if (ddlProfession.SelectedItem.ToString() == "Other,Specify")
                obj.ProfessionOthers = txtProfessionOthers.Text;
            else
                obj.ProfessionOthers = "";
            obj.PresentExercise = "";
            //ObjDietMaster.ExersizeActivity = txtExercise2.Text;
            obj.ExersizeActivity = "";
            obj.CustomerDetailNotes = txtNotes.Text;
            obj.Session = Convert.ToString(Session["UserCode"]);
            return obj;
        }

        private Anthropometrics PrepareAnthro()
        {
            Anthropometrics obj = new Anthropometrics();

            obj.MeasuredWeight = objUtility.GetWeight(Convert.ToDouble("0" + txtWeight.Text), ddlWeightUnit.SelectedValue.ToUpper());
            obj.MeasuredHeight = objUtility.GetHeight(Convert.ToDouble("0" + txtHeight.Text), ddlHeightUnit.SelectedValue.ToUpper());
            //ObjDietMaster.IdealBodyWeight = GetWeight(Convert.ToDouble(txtIdealWeight.Text), ddlWeightUnit1.SelectedValue.ToUpper());
            obj.CalculatedBMI = Convert.ToDouble("0" + txtBMI.Text);
            obj.BMIPer = Convert.ToDouble("0" + txtBMIPer.Text);
            obj.BMICategory = txtBMICategory.Text;
            obj.FatPer = Convert.ToDouble("0" + txtFatPer.Text);
            obj.NeckCircumference = objUtility.GetHeight(Convert.ToDouble("0" + txtNeck.Text), ddlNeck.SelectedItem.ToString().ToUpper());
            obj.MeasuredWaist = objUtility.GetHeight(Convert.ToDouble("0" + txtWaist.Text), ddlWaistUnit.SelectedValue.ToString().ToUpper());
            obj.MeasuredWrist = objUtility.GetHeight(Convert.ToDouble("0" + txtwrist.Text), ddlWristUnit.SelectedValue.ToString().ToUpper());
            obj.MUAC = objUtility.GetHeight(Convert.ToDouble("0" + txtMUAC.Text.ToString()), ddlMUAC.SelectedValue.ToString().ToUpper()); ;
            obj.BloodPressure = txtBloodPressure.Text;
            obj.BodyFrame = txtBodyFrame.Text;
            obj.IdealBodyWeight = Convert.ToDouble("0" + txtIdealWeight.Text);

            if (txtWeightGainLossMonth.Text.Contains("-"))
                obj.WeightGainLossMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossMonth.Text.Replace("-", ""), CultureInfo.InvariantCulture), ddlWeightUnit5.SelectedValue.ToUpper()) * -1;
            else
                obj.WeightGainLossMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossMonth.Text.Replace("+", ""), CultureInfo.InvariantCulture), ddlWeightUnit5.SelectedValue.ToUpper());
            if (txtWeightGainLossSixMonth.Text.Contains("-"))
                obj.WeightGainLossSixMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossSixMonth.Text.Replace("-", ""), CultureInfo.InvariantCulture), ddlWeightUnit6.SelectedValue.ToUpper()) * -1;
            else
                obj.WeightGainLossSixMonth = objUtility.GetWeight(double.Parse("0" + txtWeightGainLossSixMonth.Text.Replace("+", ""), CultureInfo.InvariantCulture), ddlWeightUnit6.SelectedValue.ToUpper());
            if (txtweightGainLossYear.Text.Contains("-"))
                obj.WeightGainLossYear = objUtility.GetWeight(double.Parse("0" + txtweightGainLossYear.Text.Replace("-", ""), CultureInfo.InvariantCulture), ddlWeightUnit7.SelectedValue.ToUpper()) * -1;
            else
                obj.WeightGainLossYear = objUtility.GetWeight(double.Parse("0" + txtweightGainLossYear.Text.Replace("+", ""), CultureInfo.InvariantCulture), ddlWeightUnit7.SelectedValue.ToUpper());


            obj.ReasonGainLoss = txtReason.Text;
            obj.AnthrpometricsNotes = txtNotes2.Text.Trim();
            obj.MussleMass = Convert.ToDouble('0' + txtMuscleMass.Text);
            obj.BoneMass = Convert.ToDouble('0' + txtBoneMass.Text);
            obj.BodyWater = Convert.ToDouble('0' + txtBodyWater.Text);
            obj.VisceralFat = Convert.ToDouble('0' + txtVisceralFat.Text);
            return obj;
        }

        private BioChemicalLab PrepareBio()
        {

            BioChemicalLab obj = new BioChemicalLab();
            DateTime dtdob = DateTime.ParseExact(txtTestDate.Text.Equals("") ? DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy") : txtTestDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            obj.TestDate = dtdob;
            obj.FastingGlucose = Convert.ToDouble(txtGlucose.Text.Equals("") ? "-1" : txtGlucose.Text);
            obj.PP = Convert.ToDouble(txtPP.Text.Equals("") ? "-1" : txtPP.Text);
            obj.HB = Convert.ToDouble(txtHB.Text.Equals("") ? "-1" : txtHB.Text);
            obj.Creatinine = Convert.ToDouble(txtCreatinine.Text.Equals("") ? "-1" : txtCreatinine.Text);
            obj.Albumin = Convert.ToDouble(txtAlbumin.Text.Equals("") ? "-1" : txtAlbumin.Text);
            obj.HbA1C = Convert.ToDouble(txtHba1c.Text.Equals("") ? "-1" : txtHba1c.Text);
            obj.AltSGPT = Convert.ToDouble(txtAltsgpt.Text.Equals("") ? "-1" : txtAltsgpt.Text);
            obj.AltSGOT = Convert.ToDouble(txtAltsgot.Text.Equals("") ? "-1" : txtAltsgot.Text);
            obj.Hematocrit = Convert.ToDouble(txtHematocrit.Text.Equals("") ? "-1" : txtHematocrit.Text);
            obj.Triglycerides = Convert.ToDouble(txtTriglycerides.Text.Equals("") ? "-1" : txtTriglycerides.Text);
            obj.TSH = Convert.ToDouble(txtTsh.Text.Equals("") ? "-1" : txtTsh.Text);
            obj.HDL = Convert.ToDouble(txtHdl.Text.Equals("") ? "-1" : txtHdl.Text);
            obj.LDL = Convert.ToDouble(txtLDL.Text.Equals("") ? "-1" : txtLDL.Text);
            obj.UricAcid = Convert.ToDouble(txtUricAcid.Text.Equals("") ? "-1" : txtUricAcid.Text);
            obj.TotalCholesterol = Convert.ToDouble(txtCholesterol.Text.Equals("") ? "-1" : txtCholesterol.Text);
            obj.AlkalinePhosphatase = Convert.ToDouble(txtAlkaline.Text.Equals("") ? "-1" : txtAlkaline.Text);
            obj.VitaminD3 = Convert.ToDouble(txtVitamind3.Text.Equals("") ? "-1" : txtVitamind3.Text);
            obj.VitaminB12 = Convert.ToDouble(txtVitaminb12.Text.Equals("") ? "-1" : txtVitaminb12.Text);
            obj.BSL = Convert.ToDouble(txtRandomBsl.Text.Equals("") ? "-1" : txtRandomBsl.Text);
            obj.RBC = Convert.ToDouble(txtRbc.Text.Equals("") ? "-1" : txtRbc.Text);
            obj.Platelet = Convert.ToDouble(txtPlatelet.Text.Equals("") ? "-1" : txtPlatelet.Text);
            obj.OthersBioChemicalLabs = txtOthers.Text;
            obj.BioChemicalLabNotes = txtNotes3.Text;

            return obj;
        }

        private Comorbidity PrepareComorbidity()
        {
            Comorbidity obj = new Comorbidity();

            obj.CHF = ddlChf.SelectedItem.ToString();
            obj.Hypertension = ddlHypertension.SelectedItem.ToString();
            obj.Asthma = ddlAsthma.SelectedItem.ToString();
            obj.SleepApnea = ddlSleepApnea.SelectedItem.ToString();
            obj.Thyroid = ddlThyroid.SelectedItem.ToString();

            if (ddlThyroid.SelectedItem.ToString().ToUpper() == "NO")
                obj.ThyroidType = "";
            else
                obj.ThyroidType = ddlThyroidType.SelectedIndex.ToString();

            obj.Diabetes = ddlDiabetes.SelectedItem.ToString();
            obj.IHD = ddlIhd.SelectedItem.ToString();
            obj.FunctionalStatus = ddlFunctionslStatus.SelectedItem.ToString();
            obj.ComorbidityOthers = txtChronicOthers.Text;
            obj.ComorbidityNotes = txtNotes4.Text;
            obj.LeverDisorders = ddlLiver.SelectedItem.ToString();
            obj.CardiacDisorders = ddlCardiacDisorders.SelectedItem.ToString();
            obj.KidneyDisorders = ddlKidney.SelectedItem.ToString();
            obj.FollowedParticularDietForProb = txtChronicDietDetails.Text;
            return obj;
        }

        protected bool IsGroupValid(string sValidationGroup)
        {
            foreach (BaseValidator validator in Page.Validators)
            {
                if (validator.ValidationGroup == sValidationGroup)
                {
                    bool fValid = validator.IsValid;
                    if (fValid)
                    {
                        validator.Validate();
                        fValid = validator.IsValid;
                        validator.IsValid = true;
                    }
                    if (!fValid)
                        return false;
                }

            }
            return true;
        }

        private void setUnits()
        {
            ddlWeightUnit.SelectedIndex = 0;
            ddlHeightUnit.SelectedIndex = 0;
            ddlNeck.SelectedIndex = 0;
            ddlWaistUnit.SelectedIndex = 0;
            ddlWristUnit.SelectedIndex = 0;
            ddlMUAC.SelectedIndex = 0;
            ddlWeightUnit5.SelectedIndex = 0;
            ddlWeightUnit6.SelectedIndex = 0;
            ddlWeightUnit7.SelectedIndex = 0;
        }
    }
}