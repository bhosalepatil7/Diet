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
using Diet.Business.Core.ModDietMaster;
using System.Data;
using Diet.Common;
using System.Globalization;
using GNHClientUI.Helper;
using System.IO;
using GNHClientUI.Common;
using System.Data.SqlClient;
using System.Configuration;
using Diet.Business.Core.ModDashboard;
using Diet.Business.Core.ModComorbidity;
using Diet.Business.Model.ModClinicalComplaints;
using Diet.Business.Model.ModDietLifestyle;
using Diet.DataAccess.DataManagers.ModDietLifestyle;
using GNHClientUI;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace GNHClientUI
{
    public partial class PatientMaster2 : System.Web.UI.Page
    {
        HelperClass acs = new HelperClass();
        DietMasterManager obj;
        DataSet ds = new DataSet();
        ExportClass obj1 = new ExportClass();
        GNHUtility objUtility = new GNHUtility();
        int state = 0;
        int citycode = 0;
        CustomerDetailManager cobj;
        AnthropometricsManager aobj;
        BioChemicalManager bobj;
        ComorbidityManager crobj;
        string[] splitString = { "@|@" };
        DataTable dtFoodGroupImages = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            Toolkit1.RegisterPostBackControl(btnBack);
            //Toolkit1.RegisterPostBackControl(btnDelete);
            //Toolkit1.RegisterPostBackControl(btnSave);
            Toolkit1.RegisterPostBackControl(btnUpdate);
            //Toolkit1.RegisterAsyncPostBackControl(btnPrint);
            Toolkit1.RegisterAsyncPostBackControl(btnAnthro);
            Toolkit1.RegisterAsyncPostBackControl(btnBio);
            Toolkit1.RegisterAsyncPostBackControl(btnComorbidity);
            Toolkit1.RegisterAsyncPostBackControl(btnClientData);
            Toolkit1.RegisterAsyncPostBackControl(btnGastro);
            Toolkit1.RegisterAsyncPostBackControl(btnDietLifestyle);
            //Toolkit1.RegisterPostBackControl(btnUpload);

            txtBMI.Attributes.Add("readonly", "readonly");
            txtBMICategory.Attributes.Add("readonly", "readonly");
            txtBodyFrame.Attributes.Add("readonly", "readonly");
            txtIdealWeight.Attributes.Add("readonly", "readonly");

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM FoodGroupMaster", con);
                da.Fill(dtFoodGroupImages);
            }
            if (!IsPostBack)
            {
                txtName.Focus();
                TabName.Value = Request.Form[TabName.UniqueID];

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
                    bindprofile();
                }
                if (Session["Operation"].ToString() == "New")
                {
                    ddlCountries.Items.FindByText("India").Selected = true;
                    Country_Changed(sender, e);
                    State_Changed(sender, e);
                    //btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
                    //btnDelete.Enabled = false;
                    //btnEnd.Enabled = false;
                    //btnHistory.Enabled = false;

                }
                else
                {
                    //btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                    // btnDelete.Enabled = true;
                    //btnEnd.Enabled = true;
                    //btnHistory.Enabled = true;
                }
            }
        }

        protected void Page_Error(object sender, EventArgs e)
        {
            String PhyFilePath = System.AppDomain.CurrentDomain.BaseDirectory;
            String sUser = Convert.ToString(Session["UserCode"]);
            String sLastError = Server.GetLastError().Message.ToString();
            String sStackTrace = Server.GetLastError().StackTrace.ToString();
            acs.WriteError(sLastError, sStackTrace, sUser, PhyFilePath, "Patient Master");

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsGroupValid("ValidationGroup"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details validation fails'});", true);
                //Tell.text("Client details validation fails", this);
                Page.Validate("ValidationGroup");
                return;
            }
            if (!IsGroupValid("validationGroup1"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Antropometrics validation fails'});", true);
                //Tell.text("Antropometrics validation fails", this);
                Page.Validate("validationGroup1");
                return;
            }
            if (!IsGroupValid("validationGroup2"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Biochemical validation fails'});", true);
                //Tell.text("Biochemical validation fails", this);
                Page.Validate("validationGroup2");
                return;
            }
            if (!IsGroupValid("validationGroup4"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Diet and lifestyle validation fails'});", true);
                //Tell.text("Biochemical validation fails", this);
                Page.Validate("validationGroup4");
                return;
            }
            if (!IsGroupValid("validationGroup5"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Clinical Complaints validation fails'});", true);
                //Tell.text("Biochemical validation fails", this);
                Page.Validate("validationGroup5");
                return;
            }
            //System.Threading.Thread.Sleep(3000);
            if (Page.IsValid)
            {

                DietMaster objDietMaster = PrepareDietMaster();
                objDietMaster.Operation = 1;
                objDietMaster.CustomerID = 0;

                int i = 0;
                //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
                //{
                //    i = DietMasterManager.ModifyDietMaster(objDietMaster);
                //});
                obj = new DietMasterManager();
                i = obj.ModifyDietMaster(objDietMaster);

                if (i == 1)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details saved Succesfully!!!!'});", true);
                else if (i == -5)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Record already exists with same DOB and Mobile!!!!'});", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details saved Succesfully!!!!'});", true);
                setUnits();
                Server.Transfer("~/Screens/PatientDetails.aspx");
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
            ObjDietMaster.City = ddlCities.SelectedValue.ToString();
            ObjDietMaster.State = ddlStates.SelectedValue.ToString();
            ObjDietMaster.Country = ddlCountries.SelectedValue.ToString();
            ObjDietMaster.PinCode = txtPin.Text;
            ObjDietMaster.Email = txtEmail.Text;
            ObjDietMaster.Mobile = txtMobile.Text;
            ObjDietMaster.Landline = txtLandline.Text;
            ObjDietMaster.Profession = ddlProfession.SelectedItem.ToString();
            if (ddlProfession.SelectedItem.ToString() == "Other,Specify")
                ObjDietMaster.ProfessionOthers = txtProfessionOthers.Text;
            else
                ObjDietMaster.ProfessionOthers = "";
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
            ObjDietMaster.OthersBioChemicalLabs = txtOthers.Text;
            ObjDietMaster.BioChemicalLabNotes = txtNotes3.Text;

            //comorbidity
            ObjDietMaster.ComorbidityID = 0;
            ObjDietMaster.CHF = ddlChf.SelectedItem.ToString();
            ObjDietMaster.Hypertension = ddlHypertension.SelectedItem.ToString();
            ObjDietMaster.Asthma = ddlAsthma.SelectedItem.ToString();
            ObjDietMaster.SleepApnea = ddlSleepApnea.SelectedItem.ToString();
            ObjDietMaster.Thyroid = ddlThyroid.SelectedItem.ToString();

            if (ddlThyroid.SelectedItem.ToString().ToUpper() == "NO")
                ObjDietMaster.ThyroidType = "";
            else
                ObjDietMaster.ThyroidType = ddlThyroidType.SelectedItem.ToString();

            ObjDietMaster.Diabetes = ddlDiabetes.SelectedItem.ToString();
            ObjDietMaster.IHD = ddlIhd.SelectedItem.ToString();
            ObjDietMaster.FunctionalStatus = ddlFunctionslStatus.SelectedItem.ToString();
            ObjDietMaster.ComorbidityOthers = txtChronicOthers.Text;
            ObjDietMaster.ComorbidityNotes = txtNotes4.Text;
            ObjDietMaster.LeverDisorders = ddlLiver.SelectedItem.ToString();
            ObjDietMaster.CardiacDisorders = ddlCardiacDisorders.SelectedItem.ToString();
            ObjDietMaster.KidneyDisorders = ddlKidney.SelectedItem.ToString();
            ObjDietMaster.FollowedParticularDietForProb = txtChronicDietDetails.Text;


            //Diet and Lifestyle
            ObjDietMaster.DietAndLifeStyleID = 0;
            ObjDietMaster.Smoking = ddlSmoking.SelectedItem.ToString();
            ObjDietMaster.NoOfTypicalMealsInDay = Convert.ToInt16("0" + txtMeal.Text);
            ObjDietMaster.Alcohol = ddlAlcohol.SelectedItem.ToString();
            if (ddlAlcohol.SelectedItem.ToString().ToUpper() == "NO")
            {
                ObjDietMaster.NoOfDrinks = 0;
                ObjDietMaster.FrequencyOfDrinks = "";
                ObjDietMaster.TypeOfDrink = "";
            }
            else
            {
                ObjDietMaster.NoOfDrinks = Convert.ToInt16("0" + txtNoOfDrinks.Text);
                ObjDietMaster.FrequencyOfDrinks = ddlDrinksFrequency.SelectedItem.ToString();
                ObjDietMaster.TypeOfDrink = txtTypeOfDrinks.Text;
            }
            ObjDietMaster.NoOfTypicalSnaxsInDay = Convert.ToInt16("0" + txtSnax.Text);
            ObjDietMaster.RegularExcercise = ddlExercise.SelectedItem.ToString();
            ObjDietMaster.ExcersizeDetail = txtExerciseDetail.Text;
            ObjDietMaster.SleepHoursPerDay = txtSleep.Text;
            ObjDietMaster.NoOfTeaCoffeeInDay = txtNOOFTea.Text;
            ObjDietMaster.TeaCoffeeFrequency = ddlFrequencyOfTea.SelectedItem.ToString();
            ObjDietMaster.ActivityFactor = ddlActivity.SelectedItem.ToString();
            ObjDietMaster.BMR = Convert.ToDouble("0" + txtBMR.Text);
            ObjDietMaster.Calorie = Convert.ToDouble("0" + txtCalorie.Text);
            ObjDietMaster.CarbhohydratesPercent = Convert.ToDouble("0" + txtCarbhohydratesPercent.Text);
            ObjDietMaster.FatPercent = Convert.ToDouble("0" + txtFatPercent.Text);
            ObjDietMaster.ProteinPercent = Convert.ToDouble("0" + txtProteinPercent.Text);
            ObjDietMaster.Calorie1 = Convert.ToDouble("0" + txtCalorie2.Text);
            ObjDietMaster.CarbhohydratesPercent1 = Convert.ToDouble("0" + txtCarbhohydratesPercent1.Text);
            ObjDietMaster.FatPercent1 = Convert.ToDouble("0" + txtFatPercent1.Text);
            ObjDietMaster.ProteinPercent1 = Convert.ToDouble("0" + txtProteinPercent1.Text);
            ObjDietMaster.GrainsServings = txtGrainServings.Text;
            ObjDietMaster.DalsServings = txtDalsServings.Text;
            ObjDietMaster.MilkServings = txtMilkServings.Text;
            ObjDietMaster.NonvegServings = txtNonvegServings.Text;
            ObjDietMaster.VegetablesServings = txtVegetableServings.Text;
            ObjDietMaster.FruitsServings = txtFruitsServings.Text;
            ObjDietMaster.SugarServings = txtSugarServings.Text;
            ObjDietMaster.FatServings = txtFatServings.Text;
            ObjDietMaster.WaterServings = txtWaterServings.Text;
            ObjDietMaster.BiscuitServings = txtBiscuitServings.Text;
            ObjDietMaster.NonvegQuantity = txtNonvegQuantity.Text;

            string tmp = string.Empty;
            for (int i = 0; i < chkNonvegType.Items.Count; i++)
            {
                if (chkNonvegType.Items[i].Selected == true)
                    tmp += "TRUE";
                else
                    tmp += "FALSE";

                if (i != chkNonvegType.Items.Count - 1)
                    tmp += "@|@";

            }
            ObjDietMaster.NonvegTypes = tmp;
            ObjDietMaster.NonvegValues = txtChicken.Text + "@|@" + txtEgg.Text + "@|@" + txtFish.Text + "@|@" + txtMeat.Text;

            ObjDietMaster.DietLifeHistoryID = 0;
            ObjDietMaster.DietAndLifeStyleNotes = txtNotes5.Text;
            ObjDietMaster.DietHistoryID = 0;
            ObjDietMaster.DietType = ddlDietType.SelectedItem.ToString();
            ObjDietMaster.DietTypeDetails = txtDietDetails.Text;
            ObjDietMaster.EatWhenStressed = ddlEatStress.SelectedItem.ToString();
            ObjDietMaster.FreqOutFoodEat = ddlOutsideEat.SelectedItem.ToString();
            ObjDietMaster.EatWhenBored = ddlEatBored.SelectedItem.ToString();
            ObjDietMaster.BreakfastEveryDay = ddlBreakfast.SelectedItem.ToString();
            ObjDietMaster.EatWhenWatchTV = ddlEatWatchingTV.SelectedItem.ToString();
            ObjDietMaster.Caloricbeverages = txtBeverages.Text;
            ObjDietMaster.TriedWeightLossDiet = ddlDietBefore.SelectedItem.ToString();
            ObjDietMaster.WtLossGainSixMon = ddlLossGainSixMonth.SelectedItem.ToString();
            ObjDietMaster.Pregnant = ddlPregnant.SelectedItem.ToString();
            if (ddlPregnant.SelectedItem.ToString().ToUpper() == "No")
            {
                ObjDietMaster.LactatingMother = "";
                ObjDietMaster.BabyAge = "";
            }
            else
            {
                ObjDietMaster.LactatingMother = ddlLactatingMother.SelectedItem.ToString();
                if (ddlLactatingMother.SelectedItem.ToString().ToUpper() == "YES")
                    ObjDietMaster.BabyAge = ddlBabyAge.SelectedItem.ToString();
                else
                    ObjDietMaster.BabyAge = "";
            }
            ObjDietMaster.ClinicCompID = 0;
            ObjDietMaster.ClinicCompGastProbID = 0;
            ObjDietMaster.ClinicCompChronDisID = 0;
            ObjDietMaster.ClinicCompMedicationID = 0;
            ObjDietMaster.ClinicComplaintsNotes = txtNotes6.Text;

            //Gastrointenstinal Problems

            ObjDietMaster.GastProbID = 0;
            ObjDietMaster.Heartburn = ddlHeartburn.SelectedItem.ToString();
            ObjDietMaster.Vomiting = ddlVomiting.SelectedItem.ToString();
            ObjDietMaster.Bloating = ddlBloating.SelectedItem.ToString();
            ObjDietMaster.LaxativeAntacide = ddlLuxative.SelectedItem.ToString();
            ObjDietMaster.Gas = ddlGas.SelectedItem.ToString();
            ObjDietMaster.Constipation = ddlConstipation.SelectedItem.ToString();
            ObjDietMaster.Diarrhoea = ddlDiarrhoea.SelectedItem.ToString();
            ObjDietMaster.HomeRemedy = ddlRemedy.SelectedItem.ToString();
            ObjDietMaster.GastroOthers = txtGastroOthers.Text;


            ObjDietMaster.MedicationID = 0;
            ObjDietMaster.TakeVitaminSup = ddlVitaminSuplement.SelectedItem.ToString();
            ObjDietMaster.VitaminSupDet = txtVitaminSuplement.Text;
            ObjDietMaster.TakeMineralSup = ddlMineralSuppliment.SelectedItem.ToString();
            ObjDietMaster.MineralSupDet = txtMineralSuplement.Text;
            ObjDietMaster.OralDrugDType = ddlOralDetails.SelectedItem.ToString();
            ObjDietMaster.OralDrugDet = txtOralDrugDetails.Text;
            ObjDietMaster.MedicationOthers = txtMedicationOthers.Text;

            ObjDietMaster.OilUseDetail = txtOilDetail.Text;
            ObjDietMaster.OilQuantityForMonth = txtOilQuantity.Text;
            ObjDietMaster.SugarQuantityForMonth = txtSugerQuantity.Text;
            ObjDietMaster.NoOfMembersInFamily = Convert.ToInt16("0" + txtFamilyMembers.Text);

            ObjDietMaster.DietRecallID = 0;
            ObjDietMaster.Meal1 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal2 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal3 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal4 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal5 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal6 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.RecallDietNotes = "";

            return ObjDietMaster;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime d1;
            if (DateTime.TryParseExact(AppDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d1) == false)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Invalid appointment Date'});", true);
                return;
            }
            if (!IsGroupValid("ValidationGroup"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details validation fails'});", true);
                //Tell.text("Client details validation fails", this);
                Page.Validate("ValidationGroup");
                return;
            }
            if (!IsGroupValid("validationGroup1"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Antropometrics validation fails'});", true);
                //Tell.text("Antropometrics validation fails", this);
                Page.Validate("validationGroup1");
                return;
            }
            if (!IsGroupValid("validationGroup2"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Biochemical validation fails'});", true);
                //Tell.text("Biochemical validation fails", this);
                Page.Validate("validationGroup2");
                return;
            }
            if (!IsGroupValid("validationGroup4"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Diet and lifestyle validation fails'});", true);
                //Tell.text("Biochemical validation fails", this);
                Page.Validate("validationGroup4");
                return;
            }
            if (!IsGroupValid("validationGroup5"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Clinical Complaints validation fails'});", true);
                //Tell.text("Biochemical validation fails", this);
                Page.Validate("validationGroup5");
                return;
            }
            //System.Threading.Thread.Sleep(3000);
            if (Page.IsValid)
            {
                DietMaster objDietMaster = UpdateDietMaster();
                objDietMaster.Operation = 2;
                objDietMaster.CustomerID = PatientInfo.PatientID;


                int i = 0;
                //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
                //{
                //    i = DietMasterManager.ModifyDietMaster(objDietMaster);
                //});

                obj = new DietMasterManager();
                i = obj.ModifyDietMaster(objDietMaster);

                DietMasterDataManager obj111 = new DietMasterDataManager();
                i = obj111.AddHistory(objDietMaster.CustomerID, DateTime.ParseExact(AppDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                // DashboardManager obj1 = new DashboardManager();
                // Int32 j = obj1.UpdateDashoard(Convert.ToInt32(Session["PatientID"]), "ENDTIME", Convert.ToString(Session["UserCode"]));

                if (i == -1)
                    Tell.text("History already exists for the date", this);
                else
                    Tell.text("History Added Successfully", this);
                setUnits();
                //       Server.Transfer("~/Screens/Client_Dashboard.aspx");
                //Server.Transfer("~/Screens/PatientDetails.aspx");
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DietMaster objDietMaster = PrepareDietMaster();
            objDietMaster.Operation = 3;
            objDietMaster.CustomerID = PatientInfo.PatientID;


            int i = 0;
            //BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            //{
            //    i = DietMasterManager.ModifyDietMaster(objDietMaster);
            //});

            obj = new DietMasterManager();
            i = obj.ModifyDietMaster(objDietMaster);

            if (i == 1)
                Tell.text("Deleted Successfully", this);
            else
                Tell.text("Deleted Successfully", this);
            Server.Transfer("~/Screens/PatientDetails.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Releasing session value
            Session["PatientID"] = "0";
        }

        protected void bindData()
        {
            List<string> splitItems = new List<string>();
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
                state = Convert.ToInt16(ds.Tables[0].Rows[0]["CDsState"]);
                citycode = Convert.ToInt16(ds.Tables[0].Rows[0]["CDsCity"]);
                txtPin.Text = Convert.ToString(ds.Tables[0].Rows[0]["CDsPincode"]);
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
            //Convert.ToString(ds.Rows[0]["DLnDLIDPK"]);
            if (ds.Tables[4].Rows.Count > 0)
            {
                ddlSmoking.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DLsSmoking"]);
                txtMeal.Text = Convert.ToString(ds.Tables[4].Rows[0]["DHnTypicalMealDay"]);
                ddlAlcohol.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DLsAlcohol"]);
                if (ddlAlcohol.SelectedValue.ToString().ToUpper() == "YES")
                {
                    txtNoOfDrinks.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnNoOfDrinks"]);
                    ddlDrinksFrequency.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DLsFrequencyOfDrinks"]);
                    txtTypeOfDrinks.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLsTypeOfDrink"]);
                }

                txtSnax.Text = Convert.ToString(ds.Tables[4].Rows[0]["DHnTypicalSnaxDay"]);
                ddlExercise.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DLsRegExersize"]);
                txtExerciseDetail.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLsExcersizeDetail"]);
                txtSleep.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnSleepPerDay"]);
                txtNOOFTea.Text = Convert.ToString(ds.Tables[4].Rows[0]["DHsTeaCoffeeDay"]);
                ddlFrequencyOfTea.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsTeaCoffeeFrequency"]);
                ddlActivity.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DLsActivityFactor"]);
                txtBMR.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnBMR"]);
                txtCalorie.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnCalorie"]);
                txtCarbhohydratesPercent.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnCarbhohydratesPer"]);
                txtFatPercent.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnFatPer"]);
                txtProteinPercent.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnProteinPer"]);
                txtCalorie2.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnCalorie1"]);
                txtCarbhohydratesPercent1.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnCarbhohydratesPer1"]);
                txtFatPercent1.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnFatPer1"]);
                txtProteinPercent1.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnProteinPer1"]);

                //Binding grain fields            
                txtGrainServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsGrainsServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("GRAINS AND CEREALS")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsGrainsServings"]);

                //Binding dals fields            
                txtDalsServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsDalsServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("DALS PULSES AND LEGUMES")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsDalsServings"]);

                //Binding milk fields            
                txtMilkServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsMilkServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("MILK AND MILK PRODUCTS")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsMilkServings"]);


                //Binding nonveg fields            
                txtNonvegServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsNonvegServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("NON-VEGETARIAN FOODS")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsNonvegServings"]);

                //Binding vegetable fields            
                txtVegetableServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsVegetablesServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("VEGETABLES")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsVegetablesServings"]);


                //Binding fruit fields            
                txtFruitsServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsFruitsServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FRUITS")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsFruitsServings"]);

                //Binding sugar fields            
                txtSugarServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsSugarServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("SUGAR")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsSugarServings"]);

                //Binding fat fields            
                txtFatServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsFatServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FAT")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsFatServings"]);

                //Binding water fields            
                txtWaterServings.Text = string.IsNullOrEmpty(Convert.ToString(ds.Tables[4].Rows[0]["DLsWaterServings"])) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("WATER")).First().Field<string>("FGsDefaultText") : Convert.ToString(ds.Tables[4].Rows[0]["DLsWaterServings"]);
                txtBiscuitServings.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLsBiscuitServings"]);
                txtNonvegQuantity.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLsNonvegQuantity"]);
                splitItems = new List<string>();
                splitItems.AddRange(Convert.ToString(ds.Tables[4].Rows[0]["DLsNonvegTypes"]).Split(splitString, StringSplitOptions.None)); ;
                for (int i = 0; i < chkNonvegType.Items.Count; i++)
                {
                    if (splitItems[i].Equals("TRUE"))
                        chkNonvegType.Items[i].Selected = true;
                    else
                        chkNonvegType.Items[i].Selected = false;
                }

                splitItems = new List<string>();
                splitItems.AddRange(Convert.ToString(ds.Tables[4].Rows[0]["DLsNonvegValues"]).Split(splitString, StringSplitOptions.None)); ;
                txtChicken.Text = splitItems[0];
                txtEgg.Text = splitItems[1];
                txtFish.Text = splitItems[2];
                txtMeat.Text = splitItems[3];

                //Convert.ToString(ds.Rows[0]["DHnDHIDPK"]);
                ddlDietType.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsDietType"]);
                txtDietDetails.Text = Convert.ToString(ds.Tables[4].Rows[0]["DHsDietTypeDetails"]);
                ddlEatStress.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsStressEat"]);
                ddlOutsideEat.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsFreqOutEat"]);
                ddlEatBored.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsBoredEat"]);
                ddlBreakfast.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsBreakfast"]);
                ddlEatWatchingTV.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsWatchTVEat"]);
                txtBeverages.Text = Convert.ToString(ds.Tables[4].Rows[0]["DHsCaloricbeverages"]);
                ddlDietBefore.Text = Convert.ToString(ds.Tables[4].Rows[0]["DHsWtLossDiet"]);
                ddlLossGainSixMonth.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsWtLossGainSixMon"]);
                ddlPregnant.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsPregnant"]);

                if (Convert.ToString(ds.Tables[4].Rows[0]["DHsPregnant"]) == "NO")
                {
                    ddlLactatingMother.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsLactatingMother"]);
                    if (Convert.ToString(ds.Tables[4].Rows[0]["DHsLactatingMother"]).ToUpper() == "YES")
                        ddlBabyAge.SelectedValue = Convert.ToString(ds.Tables[4].Rows[0]["DHsBabyAge"]);
                }
                txtNotes5.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLsNotes"]);
                hdnDHID.Value = Convert.ToString(ds.Tables[4].Rows[0]["DLnDHIDFK"]);
                txtOilDetail.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLsOilUseDetail"]);
                txtOilQuantity.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnOilQuantityMonth"]);
                txtFamilyMembers.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnMembersInFamily"]);
                txtSugerQuantity.Text = Convert.ToString(ds.Tables[4].Rows[0]["DLnSugarQuantity"]);
            }
            else
            {
                //Binding grain fields            
                txtGrainServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("GRAINS AND CEREALS")).First().Field<string>("FGsDefaultText");

                //Binding dals fields            
                txtDalsServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("DALS PULSES AND LEGUMES")).First().Field<string>("FGsDefaultText");

                //Binding milk fields            
                txtMilkServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("MILK AND MILK PRODUCTS")).First().Field<string>("FGsDefaultText");


                //Binding nonveg fields            
                txtNonvegServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("NON-VEGETARIAN FOODS")).First().Field<string>("FGsDefaultText");

                //Binding vegetable fields            
                txtVegetableServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("VEGETABLES")).First().Field<string>("FGsDefaultText");


                //Binding fruit fields            
                txtFruitsServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FRUITS")).First().Field<string>("FGsDefaultText");

                //Binding sugar fields            
                txtSugarServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("SUGAR")).First().Field<string>("FGsDefaultText");

                //Binding fat fields            
                txtFatServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FAT")).First().Field<string>("FGsDefaultText");

                //Binding water fields            
                txtWaterServings.Text = dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("WATER")).First().Field<string>("FGsDefaultText");

            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                ddlHeartburn.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsHeartburn"]);
                ddlVomiting.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsVomiting"]);
                ddlBloating.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsBloating"]);
                ddlLuxative.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsLaxaAnta"]);
                ddlGas.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsGas"]);
                ddlConstipation.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsConstipation"]);
                ddlDiarrhoea.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsDiarrhoea"]);
                ddlRemedy.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["GPsHomeRem"]);
                txtGastroOthers.Text = Convert.ToString(ds.Tables[5].Rows[0]["GPsOthers"]);

                hdnGPID.Value = Convert.ToString(ds.Tables[5].Rows[0]["CCnGastProbIDFK"]);
                hdnMCID.Value = Convert.ToString(ds.Tables[5].Rows[0]["CCnMedicationIDFK"]);


                txtNotes6.Text = Convert.ToString(ds.Tables[5].Rows[0]["CCsNotes"]);

                ddlVitaminSuplement.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["MCsVitaminSup"]);
                txtVitaminSuplement.Text = Convert.ToString(ds.Tables[5].Rows[0]["MCsVitaminSupDet"]);
                ddlMineralSuppliment.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["MCsMineralSup"]);
                txtMineralSuplement.Text = Convert.ToString(ds.Tables[5].Rows[0]["MCsMineralSupDet"]);
                ddlOralDetails.SelectedValue = Convert.ToString(ds.Tables[5].Rows[0]["MCsOralDrugType"]);
                txtOralDrugDetails.Text = Convert.ToString(ds.Tables[5].Rows[0]["MCsOralDrugDet"]);
                txtMedicationOthers.Text = Convert.ToString(ds.Tables[5].Rows[0]["MCsOthers"]);
            }
            //txtMeal1.Text = Convert.ToDateTime(ds.Rows[0]["DRdsMeal1"].ToString()).ToShortTimeString();
            //txtMeal2.Text = Convert.ToDateTime(ds.Rows[0]["DRdsMeal2"].ToString()).ToShortTimeString();
            //txtMeal3.Text = Convert.ToDateTime(ds.Rows[0]["DRdsMeal3"].ToString()).ToShortTimeString();
            //txtMeal4.Text = Convert.ToDateTime(ds.Rows[0]["DRdsMeal4"].ToString()).ToShortTimeString();
            //txtMeal5.Text = Convert.ToDateTime(ds.Rows[0]["DRdsMeal5"].ToString()).ToShortTimeString();
            //txtMeal6.Text = Convert.ToDateTime(ds.Rows[0]["DRdsMeal6"].ToString()).ToShortTimeString();
            //txtNotes7.Text = Convert.ToString(ds.Rows[0]["DRsNotes"]);
        }

        private DietMaster UpdateDietMaster()
        {
            //Prepare 115 Parameters
            DietMaster ObjDietMaster = new DietMaster();

            ObjDietMaster.CustomerID = PatientInfo.PatientID;
            ObjDietMaster.CustomerName = txtName.Text.Trim();
            ObjDietMaster.MiddleName = txtMiddleName.Text.Trim();
            ObjDietMaster.LastName = txtLastName.Text.Trim();
            ObjDietMaster.CustomerAge = Convert.ToInt16("0" + txtAge.Text);
            ObjDietMaster.Gender = ddlGender.SelectedItem.Value.ToString().Equals("Male") ? 0 : 1;

            DateTime dtdob = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            ObjDietMaster.DOB = dtdob;
            ObjDietMaster.Address1 = txtAddress1.Text;
            ObjDietMaster.Locality = txtLocality.Text;
            ObjDietMaster.City = ddlCities.SelectedValue.ToString();
            ObjDietMaster.State = ddlStates.SelectedValue.ToString();
            ObjDietMaster.Country = ddlCountries.SelectedValue.ToString();
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

            //ObjDietMaster.WeightGainLossMonth = objUtility.GetWeight(Convert.ToDouble("0" + txtWeightGainLossMonth.Text.Replace("−", "-")), ddlWeightUnit5.SelectedValue.ToUpper());
            //ObjDietMaster.WeightGainLossSixMonth = objUtility.GetWeight(Convert.ToDouble("0" + txtWeightGainLossSixMonth.Text.Replace("−", "-")), ddlWeightUnit6.SelectedValue.ToUpper());
            //ObjDietMaster.WeightGainLossYear = objUtility.GetWeight(Convert.ToDouble("0" + txtweightGainLossYear.Text.Replace("−", "-")), ddlWeightUnit7.SelectedValue.ToUpper());
            ObjDietMaster.ReasonGainLoss = txtReason.Text;
            ObjDietMaster.AnthrpometricsNotes = txtNotes2.Text.Trim();
            ObjDietMaster.MussleMass = Convert.ToDouble('0' + txtMuscleMass.Text);
            ObjDietMaster.BoneMass = Convert.ToDouble('0' + txtBoneMass.Text);
            ObjDietMaster.BodyWater = Convert.ToDouble('0' + txtBodyWater.Text);
            ObjDietMaster.VisceralFat = Convert.ToDouble('0' + txtVisceralFat.Text);


            dtdob = DateTime.ParseExact(txtTestDate.Text.Equals("") ? DateTime.UtcNow.AddHours(5.5).ToString("dd/MM/yyyy") : txtTestDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
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
            ObjDietMaster.OthersBioChemicalLabs = txtOthers.Text;
            ObjDietMaster.BioChemicalLabNotes = txtNotes3.Text;

            ObjDietMaster.CHF = ddlChf.SelectedItem.ToString();
            ObjDietMaster.Hypertension = ddlHypertension.SelectedItem.ToString();
            ObjDietMaster.Asthma = ddlAsthma.SelectedItem.ToString();
            ObjDietMaster.SleepApnea = ddlSleepApnea.SelectedItem.ToString();
            ObjDietMaster.Thyroid = ddlThyroid.SelectedItem.ToString();

            if (ddlThyroid.SelectedItem.ToString().ToUpper() == "NO")
                ObjDietMaster.ThyroidType = "";
            else
                ObjDietMaster.ThyroidType = ddlThyroidType.SelectedItem.ToString();

            ObjDietMaster.Diabetes = ddlDiabetes.SelectedItem.ToString();
            ObjDietMaster.IHD = ddlIhd.SelectedItem.ToString();
            ObjDietMaster.FunctionalStatus = ddlFunctionslStatus.SelectedItem.ToString();
            ObjDietMaster.ComorbidityOthers = txtChronicOthers.Text;
            ObjDietMaster.ComorbidityNotes = txtNotes4.Text;
            ObjDietMaster.LeverDisorders = ddlLiver.SelectedItem.ToString();
            ObjDietMaster.CardiacDisorders = ddlCardiacDisorders.SelectedItem.ToString();
            ObjDietMaster.KidneyDisorders = ddlKidney.SelectedItem.ToString();
            ObjDietMaster.FollowedParticularDietForProb = txtChronicDietDetails.Text;

            ObjDietMaster.Smoking = ddlSmoking.SelectedItem.ToString();
            ObjDietMaster.NoOfTypicalMealsInDay = Convert.ToInt16("0" + txtMeal.Text);
            ObjDietMaster.Alcohol = ddlAlcohol.SelectedItem.ToString();
            if (ddlAlcohol.SelectedItem.ToString().ToUpper() == "NO")
            {
                ObjDietMaster.NoOfDrinks = 0;
                ObjDietMaster.FrequencyOfDrinks = "";
                ObjDietMaster.TypeOfDrink = "";
            }
            else
            {
                ObjDietMaster.NoOfDrinks = Convert.ToInt16("0" + txtNoOfDrinks.Text);
                ObjDietMaster.FrequencyOfDrinks = ddlDrinksFrequency.SelectedItem.ToString();
                ObjDietMaster.TypeOfDrink = txtTypeOfDrinks.Text;
            }
            ObjDietMaster.NoOfTypicalSnaxsInDay = Convert.ToInt16("0" + txtSnax.Text);

            ObjDietMaster.RegularExcercise = ddlExercise.SelectedItem.ToString();
            ObjDietMaster.ExcersizeDetail = txtExerciseDetail.Text;
            ObjDietMaster.SleepHoursPerDay = txtSleep.Text;
            ObjDietMaster.NoOfTeaCoffeeInDay = txtNOOFTea.Text;
            ObjDietMaster.TeaCoffeeFrequency = ddlFrequencyOfTea.SelectedItem.ToString();
            ObjDietMaster.ActivityFactor = ddlActivity.SelectedItem.ToString();
            ObjDietMaster.DietAndLifeStyleNotes = txtNotes5.Text;
            ObjDietMaster.BMR = Convert.ToDouble("0" + txtBMR.Text);
            ObjDietMaster.Calorie = Convert.ToDouble("0" + txtCalorie.Text);
            ObjDietMaster.CarbhohydratesPercent = Convert.ToDouble("0" + txtCarbhohydratesPercent.Text);
            ObjDietMaster.FatPercent = Convert.ToDouble("0" + txtFatPercent.Text);
            ObjDietMaster.ProteinPercent = Convert.ToDouble("0" + txtProteinPercent.Text);
            ObjDietMaster.Calorie1 = Convert.ToDouble("0" + txtCalorie2.Text);
            ObjDietMaster.CarbhohydratesPercent1 = Convert.ToDouble("0" + txtCarbhohydratesPercent1.Text);
            ObjDietMaster.FatPercent1 = Convert.ToDouble("0" + txtFatPercent1.Text);
            ObjDietMaster.ProteinPercent1 = Convert.ToDouble("0" + txtProteinPercent1.Text);
            ObjDietMaster.GrainsServings = txtGrainServings.Text;
            ObjDietMaster.DalsServings = txtDalsServings.Text;
            ObjDietMaster.MilkServings = txtMilkServings.Text;
            ObjDietMaster.NonvegServings = txtNonvegServings.Text;
            ObjDietMaster.VegetablesServings = txtVegetableServings.Text;
            ObjDietMaster.FruitsServings = txtFruitsServings.Text;
            ObjDietMaster.SugarServings = txtSugarServings.Text;
            ObjDietMaster.FatServings = txtFatServings.Text;
            ObjDietMaster.WaterServings = txtWaterServings.Text;
            ObjDietMaster.BiscuitServings = txtBiscuitServings.Text;
            ObjDietMaster.NonvegQuantity = txtNonvegQuantity.Text;
            string tmp = string.Empty;
            for (int i = 0; i < chkNonvegType.Items.Count; i++)
            {
                if (chkNonvegType.Items[i].Selected == true)
                    tmp += "TRUE";
                else
                    tmp += "FALSE";

                if (i != chkNonvegType.Items.Count - 1)
                    tmp += "@|@";

            }
            ObjDietMaster.NonvegTypes = tmp;
            ObjDietMaster.NonvegValues = txtChicken.Text + "@|@" + txtEgg.Text + "@|@" + txtFish.Text + "@|@" + txtMeat.Text;


            ObjDietMaster.DietType = ddlDietType.SelectedItem.ToString();
            ObjDietMaster.DietTypeDetails = txtDietDetails.Text;
            ObjDietMaster.EatWhenStressed = ddlEatStress.SelectedItem.ToString();
            ObjDietMaster.FreqOutFoodEat = ddlOutsideEat.SelectedItem.ToString();
            ObjDietMaster.EatWhenBored = ddlEatBored.SelectedItem.ToString();
            ObjDietMaster.BreakfastEveryDay = ddlBreakfast.SelectedItem.ToString();
            ObjDietMaster.EatWhenWatchTV = ddlEatWatchingTV.SelectedItem.ToString();
            ObjDietMaster.Caloricbeverages = txtBeverages.Text;
            ObjDietMaster.TriedWeightLossDiet = ddlDietBefore.SelectedItem.ToString();
            ObjDietMaster.WtLossGainSixMon = ddlLossGainSixMonth.SelectedItem.ToString();
            ObjDietMaster.Pregnant = ddlPregnant.SelectedItem.ToString();
            if (ddlPregnant.SelectedItem.ToString().ToUpper() == "No")
            {
                ObjDietMaster.LactatingMother = "";
                ObjDietMaster.BabyAge = "";
            }
            else
            {
                ObjDietMaster.LactatingMother = ddlLactatingMother.SelectedItem.ToString();
                if (ddlLactatingMother.SelectedItem.ToString().ToUpper() == "YES")
                    ObjDietMaster.BabyAge = ddlBabyAge.SelectedItem.ToString();
                else
                    ObjDietMaster.BabyAge = "";
            }

            //Retaining old values
            ObjDietMaster.GastProbID = Convert.ToInt16("0" + hdnGPID.Value);
            ObjDietMaster.MedicationID = Convert.ToInt16("0" + hdnMCID.Value);
            ObjDietMaster.DietLifeHistoryID = Convert.ToInt16("0" + hdnDHID.Value);
            ObjDietMaster.ClinicComplaintsNotes = txtNotes6.Text;

            ObjDietMaster.Heartburn = ddlHeartburn.SelectedItem.ToString();
            ObjDietMaster.Vomiting = ddlVomiting.SelectedItem.ToString();
            ObjDietMaster.Bloating = ddlBloating.SelectedItem.ToString();
            ObjDietMaster.LaxativeAntacide = ddlLuxative.SelectedItem.ToString();
            ObjDietMaster.Gas = ddlGas.SelectedItem.ToString();
            ObjDietMaster.Constipation = ddlConstipation.SelectedItem.ToString();
            ObjDietMaster.Diarrhoea = ddlDiarrhoea.SelectedItem.ToString();
            ObjDietMaster.HomeRemedy = ddlRemedy.SelectedItem.ToString();
            ObjDietMaster.GastroOthers = txtGastroOthers.Text;

            ObjDietMaster.TakeVitaminSup = ddlVitaminSuplement.SelectedItem.ToString();
            ObjDietMaster.VitaminSupDet = txtVitaminSuplement.Text;
            ObjDietMaster.TakeMineralSup = ddlMineralSuppliment.SelectedItem.ToString();
            ObjDietMaster.MineralSupDet = txtMineralSuplement.Text;
            ObjDietMaster.OralDrugDType = ddlOralDetails.SelectedItem.ToString();
            ObjDietMaster.OralDrugDet = txtOralDrugDetails.Text;
            ObjDietMaster.MedicationOthers = txtMedicationOthers.Text;

            ObjDietMaster.OilUseDetail = txtOilDetail.Text;
            ObjDietMaster.OilQuantityForMonth = txtOilQuantity.Text;
            ObjDietMaster.SugarQuantityForMonth = txtSugerQuantity.Text;
            ObjDietMaster.NoOfMembersInFamily = Convert.ToInt16("0" + txtFamilyMembers.Text);

            ObjDietMaster.Meal1 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal2 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal3 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal4 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal5 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.Meal6 = Convert.ToDateTime(DateTime.UtcNow.AddHours(5.5));
            ObjDietMaster.RecallDietNotes = "";

            return ObjDietMaster;
        }
        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            //if (txtDOB.Text != "")
            //{
            //    DateTime dt = DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    DateTime today = DateTime.Today;
            //    int age = today.Year - dt.Year;

            //    if (dt > today.AddYears(-age))
            //        age--;
            //    txtAge.Text = age.ToString();
            //}
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            ////Do selected stuff
            //DietMaster objDietMaster = Session["Operation"].ToString() == "New" ? PrepareDietMaster() : UpdateDietMaster();
            //string body = obj1.ClientReport(objDietMaster, Session["PatientID"].ToString());
            //string filename = System.AppDomain.CurrentDomain.BaseDirectory + objDietMaster.CustomerName + "_" + DateTime.UtcNow.AddHours(5.5).ToString("ddMMMyyyy") + ".doc";
            //if (File.Exists(filename))
            //    File.Delete(filename);

            //StreamWriter Sw = File.CreateText(filename);
            //Sw.WriteLine(body.Replace("PH_USER", GetName()));
            //Sw.Close();
            //Sw.Dispose();

            //string path = filename.Replace("\\", "]");
            //String sCode = "window.open('Download.ashx?FileName=" + path + "', '_blank');";
            //String sScript = "<script language='javascript' type='text/javascript'>" + sCode + "</script>";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertUser", sScript, false);
        }
        protected void btnNo_Click(object sender, EventArgs e)
        {
            //btnProcess_ModalPopupExtender.Hide();
            //pnlPopup.Visible = false;
            //pnlprocess.Visible = false;
        }

        public double BMR_HarrisBenedict(double Weight, double Height, int Age, String Gender, String WeightUnit, String HeightUnit, String AgeUnit)
        {
            double BMR = 0.00;
            double Weight1 = objUtility.GetWeight(Weight, WeightUnit);// WeightToKG function

            double Height1 = objUtility.GetHeight(Height, HeightUnit);//HeightToCM function


            if (Gender.ToLower() == "male" || Gender.ToLower() == "men")
            {

                BMR = 66 + (13.7 * Weight1 /*in kilos */) + (5 * Height1/* in cm*/ ) - (6.8 * Age/* in years*/ );//in Kcal

                //BMR = 66 + ( 13.7 * Weight) + ( 5 * Height) - ( 6.8 * Age );// # Kcal 

            }
            else if (Gender.ToLower() == "female" || Gender.ToLower() == "women")
            {

                //#Women: BMR = 655 + ( 9.6 x weight in kilos ) + ( 1.8 x height in cm ) - ( 4.7 x age in years ) in  Kcal 

                BMR = 655 + (9.6 * Weight1) + (1.8 * Height1) - (4.7 * Age);// # Kcal 

            }

            return (BMR);
        }

        /// <summary>
        /// http://www.bmi-calculator.net/bmi-formula.php
        /// </summary>
        /// <param name="Weight"></param>
        /// <param name="Height"></param>
        /// <returns></returns>

        protected void txtHeight_TextChanged(object sender, EventArgs e)
        {
            //if (txtWeight.Text != "" && txtHeight.Text != "")
            //{
            //    double weight = objUtility.GetWeight(Convert.ToDouble(txtWeight.Text.ToString()), ddlWeightUnit.SelectedValue.ToString().ToUpper());
            //    double height = objUtility.GetHeight(Convert.ToDouble(txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper());

            //    txtBMI.Text = Convert.ToString(objUtility.BMI_General(weight, height));
            //    GetBMI(objUtility.BMI_General(weight, height));
            //}
        }

        protected void txtWeight_TextChanged(object sender, EventArgs e)
        {
            //if (txtWeight.Text != "" && txtHeight.Text != "")
            //{
            //    double weight = objUtility.GetWeight(Convert.ToDouble(txtWeight.Text.ToString()), ddlWeightUnit.SelectedValue.ToString().ToUpper());
            //    double height = objUtility.GetHeight(Convert.ToDouble(txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper());

            //    txtBMI.Text = Convert.ToString(objUtility.BMI_General(weight, height));
            //    GetBMI(objUtility.BMI_General(weight, height));
            //}
        }
        private void GetBMI(double val)
        {
            //if (val < 18.5)
            //    ddlBMI.SelectedIndex = 1;
            //else if (val >= 18.5 && val < 23)
            //    ddlBMI.SelectedIndex = 2;
            //else if (val >= 23 && val < 25)
            //    ddlBMI.SelectedIndex = 3;
            //else if (val >= 25 && val < 33)
            //    ddlBMI.SelectedIndex = 4;
            //else if (val >= 33 && val < 40)
            //    ddlBMI.SelectedIndex = 5;
            //else if (val >= 40)
            //    ddlBMI.SelectedIndex = 6;
            //else
            //{
            //    ddlBMI.SelectedIndex = 0;
            //}
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Screens/PatientDocs.aspx");
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Screens/PatientHistory.aspx");
        }

        protected void ddlWeightUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtWeight.Text != "" && txtHeight.Text != "")
            {
                Double WT = objUtility.GetWeight(Convert.ToDouble("0" + txtWeight.Text.ToString()), ddlWeightUnit.SelectedValue.ToString().ToUpper());
                Double HT = objUtility.GetHeight(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper());


                txtBMI.Text = Convert.ToString(objUtility.BMI_General(WT, HT));
                GetBMI(objUtility.BMI_General(WT, HT));
                if (txtwrist.Text != "")
                {
                    double Wrist = objUtility.GetHeight(Convert.ToDouble(txtwrist.Text.ToString()), ddlWristUnit.SelectedValue.ToString().ToUpper());
                    txtBodyFrame.Text = Convert.ToString(objUtility.GetBodyFrame(ddlGender.SelectedValue.ToString().ToLower(), objUtility.GetHeightInCM(HT, "MTR"), objUtility.GetHeightInCM(Wrist, "MTR")));

                    txtIdealWeight.Text = Convert.ToString(objUtility.fnIdealBodyWt(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper(), ddlGender.SelectedValue.ToString().ToLower(), txtBodyFrame.Text.ToString()));

                }
            }
            UpdatePanel1.Update();
        }

        protected void ddlHeightUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtWeight.Text != "" && txtHeight.Text != "")
            {
                Double WT = objUtility.GetWeight(Convert.ToDouble("0" + txtWeight.Text.ToString()), ddlWeightUnit.SelectedValue.ToString().ToUpper());
                Double HT = objUtility.GetHeight(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper());

                txtBMI.Text = Convert.ToString(objUtility.BMI_General(WT, HT));
                GetBMI(objUtility.BMI_General(WT, HT));
                if (txtwrist.Text != "")
                {
                    double Wrist = objUtility.GetHeight(Convert.ToDouble(txtwrist.Text.ToString()), ddlWristUnit.SelectedValue.ToString().ToUpper());
                    txtBodyFrame.Text = Convert.ToString(objUtility.GetBodyFrame(ddlGender.SelectedValue.ToString().ToLower(), objUtility.GetHeightInCM(HT, "MTR"), objUtility.GetHeightInCM(Wrist, "MTR")));

                    txtIdealWeight.Text = Convert.ToString(objUtility.fnIdealBodyWt(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper(), ddlGender.SelectedValue.ToString().ToLower(), txtBodyFrame.Text.ToString()));

                }
            }
        }
        protected void ddlWristUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtWeight.Text != "" && txtHeight.Text != "")
            {
                Double WT = objUtility.GetWeight(Convert.ToDouble("0" + txtWeight.Text.ToString()), ddlWeightUnit.SelectedValue.ToString().ToUpper());
                Double HT = objUtility.GetHeight(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper());

                txtBMI.Text = Convert.ToString(objUtility.BMI_General(WT, HT));
                GetBMI(objUtility.BMI_General(WT, HT));
                if (txtwrist.Text != "")
                {
                    double Wrist = objUtility.GetHeight(Convert.ToDouble(txtwrist.Text.ToString()), ddlWristUnit.SelectedValue.ToString().ToUpper());
                    txtBodyFrame.Text = Convert.ToString(objUtility.GetBodyFrame(ddlGender.SelectedValue.ToString().ToLower(), objUtility.GetHeightInCM(HT, "MTR"), objUtility.GetHeightInCM(Wrist, "MTR")));

                    txtIdealWeight.Text = Convert.ToString(objUtility.fnIdealBodyWt(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper(), ddlGender.SelectedValue.ToString().ToLower(), txtBodyFrame.Text.ToString()));

                }
            }
        }

        protected void txtwrist_TextChanged(object sender, EventArgs e)
        {
            if (txtWeight.Text != "" && txtHeight.Text != "")
            {
                Double WT = objUtility.GetWeight(Convert.ToDouble("0" + txtWeight.Text.ToString()), ddlWeightUnit.SelectedValue.ToString().ToUpper());
                Double HT = objUtility.GetHeight(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper());

                txtBMI.Text = Convert.ToString(objUtility.BMI_General(WT, HT));
                GetBMI(objUtility.BMI_General(WT, HT));
                if (txtwrist.Text != "")
                {
                    double Wrist = objUtility.GetHeight(Convert.ToDouble(txtwrist.Text.ToString()), ddlWristUnit.SelectedValue.ToString().ToUpper());
                    txtBodyFrame.Text = Convert.ToString(objUtility.GetBodyFrame(ddlGender.SelectedValue.ToString().ToLower(), objUtility.GetHeightInCM(HT, "MTR"), objUtility.GetHeightInCM(Wrist, "MTR")));

                    txtIdealWeight.Text = Convert.ToString(objUtility.fnIdealBodyWt(Convert.ToDouble("0" + txtHeight.Text.ToString()), ddlHeightUnit.SelectedValue.ToString().ToUpper(), ddlGender.SelectedValue.ToString().ToLower(), txtBodyFrame.Text.ToString()));

                }
            }
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

        protected void bindprofile()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand("SELECT CDsCustName +' '+ CDsLastName as name,CDnCustAge,case when CDnGender=0 then 'M' else 'F' end as Gender,CONVERT(VARCHAR(12), CDdtDOB, 7) as DOB,CDsAddress1,CDsLocality,CDsLandline ,(select isnull(CONVERT(VARCHAR(12), max(CDdtUpdated), 7),'') from CustomerDetail_Trail t1 where t1.CDnCustomerIDPK=@id) as visit FROM CustomerDetail t where CDnCustomerIDPK=@id");
            cmd.Parameters.AddWithValue("@id", Session["PatientID"].ToString());
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    cmd.Connection = con;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);



                    lblprofilename.Text = Convert.ToString(dt.Rows[0]["name"]);
                    lblid.Text = "[" + Session["PatientID"].ToString() + "]";
                    lbldob.Text = Convert.ToString(dt.Rows[0]["DOB"]) + '(' + Convert.ToString(dt.Rows[0]["CDnCustAge"]) + " y) - " + Convert.ToString(dt.Rows[0]["Gender"]);
                    lbladdress.Text = Convert.ToString(dt.Rows[0]["CDsAddress1"]) + "," + Convert.ToString(dt.Rows[0]["CDsLocality"]);
                    lbllandline.Text = "[" + Convert.ToString(dt.Rows[0]["CDsLandline"]) + "]";
                    lblVisit1.Text = Convert.ToString(dt.Rows[0]["visit"]);
                }
            }

        }

        protected void btnEnd_Click(object sender, EventArgs e)
        {
            DietMaster objDietMaster = UpdateDietMaster();
            objDietMaster.Operation = 2;
            objDietMaster.CustomerID = PatientInfo.PatientID;

            int i = 0;
            obj = new DietMasterManager();
            i = obj.ModifyDietMaster(objDietMaster);

            DashboardManager obj1 = new DashboardManager();
            Int32 j = obj1.UpdateDashoard(Convert.ToInt32(Session["PatientID"]), "ENDTIME", Convert.ToString(Session["UserCode"]));

            if (i == 1)
                Tell.text("Updated Successfully", this);
            else
                Tell.text("Updated Successfully", this);
            Server.Transfer("~/Screens/Client_Dashboard.aspx");
        }

        protected void btnDietLifestyle_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(3000);
            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {
                DietLifestyle objLife = PrepareDietLifestyle();
                objLife.Operation = 2;
                objLife.CustomerID = PatientInfo.PatientID;

                DietLifestyleDataManager Lifeobj = new DietLifestyleDataManager();
                int i = Lifeobj.ModifyDietLifestyle(objLife);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Diet & lifestyle details saved!!!!'});", true);
                bindData();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Save Client details first!!!!'});", true);
            }
        }

        protected void btnGastro_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(3000);
            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {
                ClinicalComplaints objclinical = PrepareClinical();
                objclinical.Operation = 2;
                objclinical.CustomerID = PatientInfo.PatientID;

                ClinicalManager clinicobj = new ClinicalManager();
                int i = clinicobj.ModifyClinicalComplaints(objclinical);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Clinical details saved!!!!'});", true);
                bindData();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Save Client details first!!!!'});", true);
            }
        }
        protected void btnClientData_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(3000);
            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {

                CustomerDetail objcustMaster = PrepareClientmaster();
                objcustMaster.Operation = 2;
                objcustMaster.CustomerID = PatientInfo.PatientID;

                cobj = new CustomerDetailManager();
                PatientInfo.PatientID = cobj.ModifyCustomerDetail(objcustMaster);
                Session["PatientID"] = PatientInfo.PatientID;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details updated Succesfully!!!!'});", true);
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
                if (PatientInfo.PatientID == -5)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Record already exists with same DOB and Mobile!!!!'});", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Client details Saved Succesfully!!!!'});", true);
                bindData();
            }
        }
        protected void btnComorbidity_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(3000);
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
            //System.Threading.Thread.Sleep(3000);
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
        private ClinicalComplaints PrepareClinical()
        {
            ClinicalComplaints obj = new ClinicalComplaints();

            obj.ClinicCompID = 0;
            obj.ClinicCompGastProbID = 0;
            obj.ClinicCompChronDisID = 0;
            obj.ClinicCompMedicationID = 0;

            obj.ClinicComplaintsNotes = txtNotes6.Text;

            //Gastrointenstinal Problems
            obj.GastProbID = Convert.ToInt16("0" + hdnGPID.Value);
            obj.Heartburn = ddlHeartburn.SelectedItem.ToString();
            obj.Vomiting = ddlVomiting.SelectedItem.ToString();
            obj.Bloating = ddlBloating.SelectedItem.ToString();
            obj.LaxativeAntacide = ddlLuxative.SelectedItem.ToString();
            obj.Gas = ddlGas.SelectedItem.ToString();
            obj.Constipation = ddlConstipation.SelectedItem.ToString();
            obj.Diarrhoea = ddlDiarrhoea.SelectedItem.ToString();
            obj.HomeRemedy = ddlRemedy.SelectedItem.ToString();
            obj.GastroOthers = txtGastroOthers.Text;

            obj.MedicationID = Convert.ToInt16("0" + hdnMCID.Value);
            obj.TakeVitaminSup = ddlVitaminSuplement.SelectedItem.ToString();
            obj.VitaminSupDet = txtVitaminSuplement.Text;
            obj.TakeMineralSup = ddlMineralSuppliment.SelectedItem.ToString();
            obj.MineralSupDet = txtMineralSuplement.Text;
            obj.OralDrugDType = ddlOralDetails.SelectedItem.ToString();
            obj.OralDrugDet = txtOralDrugDetails.Text;
            obj.MedicationOthers = txtMedicationOthers.Text;

            return obj;
        }

        private DietLifestyle PrepareDietLifestyle()
        {
            DietLifestyle dobj = new DietLifestyle();

            dobj.DietLifeHistoryID = Convert.ToInt16("0" + hdnDHID.Value);
            dobj.Smoking = ddlSmoking.SelectedItem.ToString();
            dobj.NoOfTypicalMealsInDay = Convert.ToInt16("0" + txtMeal.Text);
            dobj.Alcohol = ddlAlcohol.SelectedItem.ToString();
            if (ddlAlcohol.SelectedItem.ToString().ToUpper() == "NO")
            {
                dobj.NoOfDrinks = 0;
                dobj.FrequencyOfDrinks = "";
                dobj.TypeOfDrink = "";
            }
            else
            {
                dobj.NoOfDrinks = Convert.ToInt16("0" + txtNoOfDrinks.Text);
                dobj.FrequencyOfDrinks = ddlDrinksFrequency.SelectedItem.ToString();
                dobj.TypeOfDrink = txtTypeOfDrinks.Text;
            }

            dobj.NoOfTypicalSnaxsInDay = Convert.ToInt16("0" + txtSnax.Text);
            dobj.RegularExcercise = ddlExercise.SelectedItem.ToString();
            dobj.ExcersizeDetail = txtExerciseDetail.Text;
            dobj.SleepHoursPerDay = txtSleep.Text;
            dobj.NoOfTeaCoffeeInDay = txtNOOFTea.Text;
            dobj.TeaCoffeeFrequency = ddlFrequencyOfTea.SelectedItem.ToString();
            dobj.ActivityFactor = ddlActivity.SelectedItem.ToString();
            dobj.DietAndLifeStyleNotes = txtNotes5.Text;
            dobj.OilUseDetail = txtOilDetail.Text;
            dobj.OilQuantityForMonth = txtOilQuantity.Text;
            dobj.SugarQuantityForMonth = txtSugerQuantity.Text;
            dobj.NoOfMembersInFamily = Convert.ToInt16("0" + txtFamilyMembers.Text);
            dobj.BMR = Convert.ToDouble("0" + txtBMR.Text);
            dobj.Calorie = Convert.ToDouble("0" + txtCalorie.Text);
            dobj.CarbhohydratesPercent = Convert.ToDouble("0" + txtCarbhohydratesPercent.Text);
            dobj.FatPercent = Convert.ToDouble("0" + txtFatPercent.Text);
            dobj.ProteinPercent = Convert.ToDouble("0" + txtProteinPercent.Text);

            dobj.Calorie1 = Convert.ToDouble("0" + txtCalorie2.Text);
            dobj.CarbhohydratesPercent1 = Convert.ToDouble("0" + txtCarbhohydratesPercent1.Text);
            dobj.FatPercent1 = Convert.ToDouble("0" + txtFatPercent1.Text);
            dobj.ProteinPercent1 = Convert.ToDouble("0" + txtProteinPercent1.Text);
            dobj.GrainsServings = txtGrainServings.Text;
            dobj.DalsServings = txtDalsServings.Text;
            dobj.MilkServings = txtMilkServings.Text;
            dobj.NonvegServings = txtNonvegServings.Text;
            dobj.VegetablesServings = txtVegetableServings.Text;
            dobj.FruitsServings = txtFruitsServings.Text;
            dobj.SugarServings = txtSugarServings.Text;
            dobj.FatServings = txtFatServings.Text;
            dobj.WaterServings = txtWaterServings.Text;
            dobj.BiscuitServings = txtBiscuitServings.Text;
            dobj.NonvegQuantity = txtNonvegQuantity.Text;

            string tmp = string.Empty;
            for (int i = 0; i < chkNonvegType.Items.Count; i++)
            {
                if (chkNonvegType.Items[i].Selected == true)
                    tmp += "TRUE";
                else
                    tmp += "FALSE";

                if (i != chkNonvegType.Items.Count - 1)
                    tmp += "@|@";

            }
            dobj.NonvegTypes = tmp;
            dobj.NonvegValues = txtChicken.Text + "@|@" + txtEgg.Text + "@|@" + txtFish.Text + "@|@" + txtMeat.Text;


            dobj.DietType = ddlDietType.SelectedItem.ToString();
            dobj.DietTypeDetails = txtDietDetails.Text;
            dobj.EatWhenStressed = ddlEatStress.SelectedItem.ToString();
            dobj.FreqOutFoodEat = ddlOutsideEat.SelectedItem.ToString();
            dobj.EatWhenBored = ddlEatBored.SelectedItem.ToString();
            dobj.BreakfastEveryDay = ddlBreakfast.SelectedItem.ToString();
            dobj.EatWhenWatchTV = ddlEatWatchingTV.SelectedItem.ToString();
            dobj.Caloricbeverages = txtBeverages.Text;
            dobj.TriedWeightLossDiet = ddlDietBefore.SelectedItem.ToString();
            dobj.WtLossGainSixMon = ddlLossGainSixMonth.SelectedItem.ToString();
            dobj.Pregnant = ddlPregnant.SelectedItem.ToString();
            if (ddlPregnant.SelectedItem.ToString().ToUpper() == "No")
            {
                dobj.LactatingMother = "";
                dobj.BabyAge = "";
            }
            else
            {
                dobj.LactatingMother = ddlLactatingMother.SelectedItem.ToString();
                if (ddlLactatingMother.SelectedItem.ToString().ToUpper() == "YES")
                    dobj.BabyAge = ddlBabyAge.SelectedItem.ToString();
                else
                    dobj.BabyAge = "";
            }

            return dobj;
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

        protected void btnAnthro_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(3000);
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

        protected void Print()
        {
            DietMaster objDietMaster = Session["Operation"].ToString() == "New" ? PrepareDietMaster() : UpdateDietMaster();
            string body = obj1.ClientReport(objDietMaster, Session["PatientID"].ToString());
            string filename = System.AppDomain.CurrentDomain.BaseDirectory + "Download/" + objDietMaster.CustomerName + "_" + DateTime.UtcNow.AddHours(5.5).ToString("ddMMMyyyy");
            if (File.Exists(filename))
                File.Delete(filename);

            StreamWriter Sw = File.CreateText(filename + ".htm");
            Sw.WriteLine(GetUseDetails(body).Replace("CALORIE_TOTAL", txtCalorie2.Text + " (kcal)").Replace("PROTEIN_TOTAL", hdnProtein.Value + " (gm)"));
            Sw.Close();
            Sw.Dispose();
            //AddHeader(filename);


            //Response.Redirect(@"..\Screens\PrintForm.aspx?FileName=" + filename.Substring(filename.LastIndexOf("/") + 1));
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "OpenWindow", "window.open('../Screens/PrintForm.aspx?FileName=" + filename.Substring(filename.LastIndexOf("/") + 1) + "','_newtab');", true);
            //Response.Write(String.Format("window.open('{0}','_blank')", ResolveUrl("../Screens/PrintForm.aspx?FileName=" + filename.Substring(filename.LastIndexOf("/") + 1))));
            // string path = filename.Replace("\\", "]");
            // String sCode = "window.open('Download.ashx?FileName=" + path + "', '_blank');";
            // String sScript = "<script language='javascript' type='text/javascript'>" + sCode + "</script>";
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertUser", sScript, false);
        }

        public string GetUseDetails(string response)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlDataAdapter _Cmd = new SqlDataAdapter("select  * from ADMIN_MAPS_user_master WHERE upper(USER_NAME)=upper('" + Session["UserCode"] + "')", con);
            if (con.State == ConnectionState.Closed) con.Open();

            DataTable dt = new DataTable();
            _Cmd.Fill(dt);
            response = response.Replace("PH_USER", Convert.ToString(dt.Rows[0]["USER_FULL_NAME"])).Replace("PH_CLINIC", Convert.ToString(dt.Rows[0]["clinic_name"]));
            response = response.Replace("PH_REPORT", Convert.ToString(dt.Rows[0]["report_heading"])).Replace("PH_MOB", Convert.ToString(dt.Rows[0]["contact1"]));
            return response;

        }

        protected void btnRecommendSave_Click(object sender, EventArgs e)
        {
            if (!IsGroupValid("validationGroup4"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Diet & lifestyle tab details validation fails'});", true);
                //Tell.text("Client details validation fails", this);
                Page.Validate("validationGroup4");
                return;
            }

            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {
                DietLifestyle objLife = PrepareDietLifestyle();
                objLife.Operation = 2;
                objLife.CustomerID = PatientInfo.PatientID;

                DietLifestyleDataManager Lifeobj = new DietLifestyleDataManager();
                int i = Lifeobj.ModifyDietLifestyle(objLife);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Recommendded Diet details saved!!!!'});", true);
                bindData();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Save Client details first!!!!'});", true);
            }
        }

        protected void btnServings_Click(object sender, EventArgs e)
        {
            if (!IsGroupValid("validationGroup4"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Diet & lifestyle tab details validation fails'});", true);
                //Tell.text("Client details validation fails", this);
                Page.Validate("validationGroup4");
                return;
            }
            if (!IsGroupValid("ValGroup2"))
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Recommended Servings tab details validation fails'});", true);
                //Tell.text("Client details validation fails", this);
                Page.Validate("ValGroup2");
                return;
            }

            if (!Convert.ToString(Session["PatientID"]).Equals("0"))
            {
                DietLifestyle objLife = PrepareDietLifestyle();
                objLife.Operation = 2;
                objLife.CustomerID = PatientInfo.PatientID;

                DietLifestyleDataManager Lifeobj = new DietLifestyleDataManager();
                int i = Lifeobj.ModifyDietLifestyle(objLife);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Recommendded Servings details saved!!!!'});", true);
                bindData();

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "swal({title:'',text:'Save Client details first!!!!'});", true);
            }
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