using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Diet.Business.Model;
using Diet.Common;
using Diet.Business.Contract;
using EvoPdf;
using System.IO;
using System.Diagnostics;


namespace DietClientUI
{
    public partial class frmDiet : Form
    {
        Stopwatch watch = new Stopwatch();
        
            
        public frmDiet()
        {
            InitializeComponent();
            //ApplicationLookAndFeel.UseTheme(this);
            watch.Start();
            timerStopWatch.Start();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void frmDiet_Load(object sender, EventArgs e)
        {
            ///frmDiet
            //this.BackColor=System.Drawing.Color.

            
            

            ///Tab Control 1
            tabControl1.Height = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height*80)/100;
            tabControl1.Width = (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width*80)/100;


            //Customer Details Section
            cmbGender.SelectedIndex = 0;
            cmbProfession.SelectedIndex = 0;
            cmbNatureOfActivity.SelectedIndex = 0;

            //Anthropometrics Section
            cmbBMICategory.SelectedIndex = 0;

            //Comorbidity Section
            cmbCHF.SelectedIndex = 0;
            cmbComorbidityHypertension.SelectedIndex = 0;
            cmbAsthma.SelectedIndex = 0;
            cmbSleepApnea.SelectedIndex = 0;
            cmbThyroid.SelectedIndex = 0;
            cmbComorbidityDiaites.SelectedIndex = 0;
            cmbIHD.SelectedIndex = 0;
            cmbFunctionalStatus.SelectedIndex = 0;

            //Diet And Life Style Section
            cmbRegularExcercise.SelectedIndex = 0;
            cmbSmoking.SelectedIndex = 0;
            cmbAlcohol.SelectedIndex = 0;

            cmbDietType.SelectedIndex = 0;
            cmbFrequencyOfOutsideEat.SelectedIndex = 0;
            cmbEatWhenBored.SelectedIndex = 0;
            cmbEatWhenStressed.SelectedIndex = 0;
            cmbHaveBreakfastEveryday.SelectedIndex = 0;
            cmbEatWhenWatchingTV.SelectedIndex = 0;
            cmbTriedWtLossDiet.SelectedIndex = 0;
            cmbWtLossGainInSixMonth.SelectedIndex = 0;

            //Gastrointenstinal Problems
            cmbHeartburn.SelectedIndex = 0;
            cmbBloating.SelectedIndex = 0;
            cmbGas.SelectedIndex = 0;
            cmbDiarrhoea.SelectedIndex = 0;

            cmbVomiting.SelectedIndex = 0;
            cmbUseAntacid.SelectedIndex = 0;
            cmbConstipation.SelectedIndex = 0;
            cmbFollowHomeRemedy.SelectedIndex = 0;

            //Chronic Diseases
            cmbDiabetes.SelectedIndex = 0;
            cmbHypertension.SelectedIndex = 0;
            cmbCardiacDisorders.SelectedIndex = 0;
            cmbKidneyDisorders.SelectedIndex = 0;

            cmbLiverDisorders.SelectedIndex = 0;
            cmbPepticUlcer.SelectedIndex = 0;

            //Medications
            cmbVitaminSuppliment.SelectedIndex = 0;
            cmbMineralSuppliment.SelectedIndex = 0;

            //Dier-Recall Section
            dtAfterDinnerTime.ShowUpDown = true;
            dtAfterDinnerTime.CustomFormat = "hh:mm";
            dtAfterDinnerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtAfterDinnerTime.Text = "11:30";

            dtBreakfastTime.ShowUpDown = true;
            dtBreakfastTime.CustomFormat = "hh:mm";
            dtBreakfastTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtBreakfastTime.Text = "09:00";

            dtLunchTime.ShowUpDown = true;
            dtLunchTime.CustomFormat = "hh:mm";
            dtLunchTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtLunchTime.Text = "01:30";

            dtTeaTime.ShowUpDown = true;
            dtTeaTime.CustomFormat = "hh:mm";
            dtTeaTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtTeaTime.Text = "09:15";

            dtTeaTime2.ShowUpDown = true;
            dtTeaTime2.CustomFormat = "hh:mm";
            dtTeaTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtTeaTime2.Text = "04:30";

            dtDinnerTime.ShowUpDown = true;
            dtDinnerTime.CustomFormat = "hh:mm";
            dtDinnerTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtDinnerTime.Text="10:00";
                
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                //MessageBox.Show("You pressed Up arrow key");
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                //MessageBox.Show("You pressed Down arrow key");
                return true;
            }
            //capture left arrow key
            if (keyData == Keys.Left)
            {
                if (tabControl1.TabIndex != 0)
                    tabControl1.TabIndex = tabControl1.TabIndex - 1;
                //MessageBox.Show("You pressed Left arrow key");
                //return true;
            }
            //capture right arrow key
            if (keyData == Keys.Right)
            {
                tabControl1.TabIndex = tabControl1.TabIndex + 1;
                //MessageBox.Show("You pressed Right arrow key");
                //return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DietMaster objDietMaster = PrepareDietMaster();
            objDietMaster.Operation = 1;
            objDietMaster.CustomerID = 0;
            

            int i = 0;
            BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            {
                i = DietMasterManager.ModifyDietMaster(objDietMaster);
            });

            if (i == 1)
                MessageBox.Show("Added Successfully");
            else
                MessageBox.Show("Added Successfully");

            /*
            
            //Add Customer Details
            CustomerDetail objCustDetail = new CustomerDetail();
            //objCustDetail.CustomerID = Convert.ToInt32(txtPatientID.Text);
            //objCustDetail.CustomerName = txtPatientName.Text;
            //objCustDetail.CustomerAge = Convert.ToInt32(txtPatientAge.Text);
            //objCustDetail.Gender=cmbGender.SelectedIndex;
            //objCustDetail.DOB = Convert.ToDateTime(txtDOB.Text);
            //objCustDetail.Address = txtAddress.Text;
            //objCustDetail.Profession = cmbProfession.SelectedItem.ToString();
            //objCustDetail.Email = txtEmail.Text;
            //objCustDetail.Contact = txtContact.Text;
            //objCustDetail.PresentExercise = txtPresentExcercise.Text;
            //objCustDetail.ExersizeActivity = txtExcerciseActivity.Text;
            //objCustDetail.NatureOfActivity = cmbNatureOfActivity.SelectedItem.ToString();

            objCustDetail.CustomerID = 0;
            objCustDetail.CustomerName = "Prashant";
            objCustDetail.CustomerAge = 25;
            objCustDetail.Gender = 0;
            objCustDetail.DOB = Convert.ToDateTime("5/8/1989");
            objCustDetail.Address = "Wadala";
            objCustDetail.Profession = "Farming";
            objCustDetail.Email = "pk@gmail.com";
            objCustDetail.Contact = "9867815161";
            objCustDetail.PresentExercise = "Yoga";
            objCustDetail.ExersizeActivity = "Padmasan";
            objCustDetail.NatureOfActivity = "a. Sedentary( little or no exercise)";

            int i=0;
            BusinessHelper<ICustomerDetail>.Use(CustomerDetailManager =>
                {
                     i=CustomerDetailManager.ModifyCustomerDetail(objCustDetail);
                });
            int c = i; 

            //Add Anthropometrics details
            Anthropometrics objAnthropometrics = new Anthropometrics();
            objAnthropometrics.Operation = 1;

            //objAnthropometrics.CustomerID = 0;
            //objAnthropometrics.MeasuredWeight = Convert.ToInt32(txtMeasuredWeight.Text);
            //objAnthropometrics.MeasuredHeight = Convert.ToInt32(txtMeasuredHeight.Text);
            //objAnthropometrics.IdealBodyWeight = Convert.ToInt32(txtIdealBodyWeight.Text);
            //objAnthropometrics.CalculatedBMI = Convert.ToInt32(txtCalculatedBMI.Text);
            //objAnthropometrics.BMICategory = cmbBMICategory.SelectedItem.ToString();
            //objAnthropometrics.MeasuredWaist=Convert.ToInt32(txtMeasuredWaist.Text);
            //objAnthropometrics.WeightGainInMonth = Convert.ToInt32(txtWeightGainInLastOneMonth.Text);
            //objAnthropometrics.WeightGainInSixMonth=Convert.ToInt32(txtWeightGainInLastSixMonths.Text);
            //objAnthropometrics.WeightGainInYear = Convert.ToInt32(txtWeightGainInLastYear.Text);
            //objAnthropometrics.WeightLossInMonth = Convert.ToInt32(txtWeightGainInLastOneMonth.Text);
            //objAnthropometrics.WeightGainInSixMonth = Convert.ToInt32(txtWeighLossInLastSixMonths.Text);
            //objAnthropometrics.WeightLossInYear = Convert.ToInt32(txtWeighLossInLastYear.Text);
            //objAnthropometrics.NeckCircumference = Convert.ToInt32(txtNeckCircumference.Text);
            //objAnthropometrics.MUAC = Convert.ToInt32(txtMUAC.Text);
            //objAnthropometrics.BloodPressure = Convert.ToInt32(txtBloodPressure.Text);


            //dummy Data
            objAnthropometrics.AnthropometricID = 0;
            objAnthropometrics.CustomerID = 0;
            objAnthropometrics.MeasuredWeight = 0;
            objAnthropometrics.MeasuredHeight = 0;
            objAnthropometrics.IdealBodyWeight = 0;
            objAnthropometrics.CalculatedBMI = 0;
            objAnthropometrics.BMICategory = "Normal BMI";
            objAnthropometrics.MeasuredWaist = 0;
            objAnthropometrics.WeightGainInMonth = 0;
            objAnthropometrics.WeightGainInSixMonth = 0;
            objAnthropometrics.WeightGainInYear = 0;
            objAnthropometrics.WeightLossInMonth = 0;
            objAnthropometrics.WeightGainInSixMonth = 0;
            objAnthropometrics.WeightLossInYear = 0;
            objAnthropometrics.NeckCircumference = 0;
            objAnthropometrics.MUAC = 0;
            objAnthropometrics.BloodPressure = 0;

            i = 0;
            BusinessHelper<IAnthropometrics>.Use(AnthropometricsManager =>
            {
                i = AnthropometricsManager.ModifyAnthropometrics(objAnthropometrics);
            });

            //Add BioChemical Details
             * 
             * 
             * */

        }

        private DietMaster PrepareDietMaster()
        {
        //    //Prepare 112 Parameters
            DietMaster ObjDietMaster = new DietMaster();

        //    ObjDietMaster.CustomerName = txtPatientName.Text.Trim();
        //    ObjDietMaster.CustomerAge = Convert.ToInt16("0" + txtPatientAge.Text);
        //    ObjDietMaster.Gender = cmbGender.SelectedIndex;
        //    ObjDietMaster.DOB = Convert.ToDateTime(txtDOB.Text);
        //    ObjDietMaster.Address1 = txtAddress.Text;
        //    ObjDietMaster.Profession = cmbProfession.SelectedItem.ToString();
        //    ObjDietMaster.Email = txtEmail.Text;
        //    ObjDietMaster.Contact = txtContact.Text;
        //    ObjDietMaster.PresentExercise = txtPresentExcercise.Text;
        //    ObjDietMaster.ExersizeActivity = txtExcerciseActivity.Text;
        //    ObjDietMaster.NatureOfActivity = cmbNatureOfActivity.SelectedItem.ToString();
        //    ObjDietMaster.CustomerDetailNotes = txtPatientDetailsNotes.Text;

        //    ObjDietMaster.AnthropometricID = 0;
        //    ObjDietMaster.MeasuredWeight = Convert.ToInt16("0" + txtMeasuredWeight.Text);
        //    ObjDietMaster.MeasuredHeight = Convert.ToInt16("0" + txtMeasuredHeight.Text);
        //    ObjDietMaster.IdealBodyWeight = Convert.ToInt16("0" + txtIdealBodyWeight.Text);
        //    ObjDietMaster.CalculatedBMI = Convert.ToInt16("0" + txtCalculatedBMI.Text);
        //    ObjDietMaster.BMICategory = cmbBMICategory.SelectedItem.ToString();
        //    ObjDietMaster.MeasuredWaist = Convert.ToInt16("0" + txtMeasuredWaist.Text);
        //    ObjDietMaster.WeightGainInMonth = Convert.ToInt16("0" + txtWeightGainInLastOneMonth.Text);
        //    ObjDietMaster.WeightGainInSixMonth = Convert.ToInt16("0" + txtWeightGainInLastSixMonths.Text);
        //    ObjDietMaster.WeightGainInYear = Convert.ToInt16("0" + txtWeightGainInLastYear.Text);
        //    ObjDietMaster.WeightLossInMonth = Convert.ToInt16("0" + txtWeighLossInLastOneMonth.Text);
        //    ObjDietMaster.WeightLossInSixMonth = Convert.ToInt16("0" + txtWeighLossInLastSixMonths.Text);
        //    ObjDietMaster.WeightLossInYear = Convert.ToInt16("0" + txtWeighLossInLastYear.Text);
        //    ObjDietMaster.NeckCircumference = Convert.ToInt16("0" + txtNeckCircumference.Text);
        //    ObjDietMaster.MUAC = Convert.ToInt16("0" + txtMUAC.Text);
        //    ObjDietMaster.BloodPressure =  txtBloodPressure.Text;
        //    ObjDietMaster.AnthrpometricsNotes = txtAnthrpometricsNotes.Text.Trim();

        //    ObjDietMaster.BioChemicalLabID = 0;
        //    ObjDietMaster.FastingGlucose = Convert.ToInt16("0" + txtFastingGlucose.Text);
        //    ObjDietMaster.Creatinine = Convert.ToInt16("0" + txtCreatinine.Text);
        //    ObjDietMaster.Albumin = Convert.ToInt16("0" + txtAlbumin.Text);
        //    ObjDietMaster.HbA1C = Convert.ToInt16("0" + txtHbA1C.Text);
        //    ObjDietMaster.AltSGPT = Convert.ToInt16("0" + txtAltSGPT.Text);
        //    ObjDietMaster.AltSGOT = Convert.ToInt16("0" + txtAltSGOT.Text);
        //    ObjDietMaster.Hematocrit = Convert.ToInt16("0" + txtHematocrit.Text);
        //    ObjDietMaster.Triglycerides = Convert.ToInt16("0" + txtTriglycerides.Text);
        //    ObjDietMaster.HDL = Convert.ToInt16("0" + txtHDL.Text);
        //    ObjDietMaster.TotalCholesterol = Convert.ToInt16("0" + txtCholesterol.Text);
        //    ObjDietMaster.AlkalinePhosphatase = Convert.ToInt16("0" + txtAlkalinePhosphatase.Text);
        //    ObjDietMaster.VitaminD3 = Convert.ToInt16("0" + txtVitaminD3.Text);
        //    ObjDietMaster.OthersBioChemicalLabs = txtOtherBiochemicalDetails.Text;
        //    ObjDietMaster.BioChemicalLabNotes = txtBioChemicalLabsNotes.Text;

        //    ObjDietMaster.ComorbidityID = 0;
        //    ObjDietMaster.Hypertension = cmbComorbidityHypertension.SelectedItem.ToString();
        //    ObjDietMaster.Diabetes = cmbComorbidityDiaites.SelectedItem.ToString();
        //    ObjDietMaster.CHF = cmbCHF.SelectedItem.ToString();
        //    ObjDietMaster.Asthma = cmbAsthma.SelectedItem.ToString();
        //    ObjDietMaster.IHD = cmbIHD.SelectedItem.ToString();
        //    ObjDietMaster.Thyroid = cmbThyroid.SelectedItem.ToString();
        //    ObjDietMaster.SleepApnea = cmbSleepApnea.SelectedItem.ToString();
        //    ObjDietMaster.FunctionalStatus = cmbFunctionalStatus.SelectedItem.ToString();
        //    ObjDietMaster.ComorbidityNotes = txtComorbidityNotes.Text;

        //    ObjDietMaster.DietAndLifeStyleID = 0;
        //    ObjDietMaster.RegularExcercise = cmbRegularExcercise.SelectedItem.ToString();
        //    ObjDietMaster.Smoking = cmbSmoking.SelectedItem.ToString();
        //    ObjDietMaster.Alcohol = cmbAlcohol.SelectedItem.ToString();
        //    ObjDietMaster.ExcersizeDetail = txtExcerciseDetail.Text;
        //    ObjDietMaster.SleepHoursPerDay = Convert.ToInt16(txtSleepsPerDay.Text);
        //    ObjDietMaster.DietLifeHistoryID = 0;
        //    ObjDietMaster.DietAndLifeStyleNotes = txtDietAndLifeStyleNotes.Text;

        //    ObjDietMaster.DietHistoryID = 0;
        //    ObjDietMaster.DietType = cmbDietType.SelectedItem.ToString();
        //    ObjDietMaster.FreqOutFoodEat = cmbFrequencyOfOutsideEat.SelectedItem.ToString();
        //    ObjDietMaster.NoOfTypicalMealsInDay = Convert.ToInt16("0" + txtMealsInDay.Text);
        //    ObjDietMaster.NoOfTypicalSnaxsInDay = Convert.ToUInt16("0" + txtSnaxsInDay.Text);
        //    ObjDietMaster.Caloricbeverages = txtCaloricBevarges.Text;
        //    ObjDietMaster.BreakfastEveryDay = cmbHaveBreakfastEveryday.SelectedItem.ToString();
        //    ObjDietMaster.EatWhenBored = cmbEatWhenBored.SelectedItem.ToString();
        //    ObjDietMaster.EatWhenStressed = cmbEatWhenStressed.SelectedItem.ToString();
        //    ObjDietMaster.EatWhenWatchTV = cmbEatWhenWatchingTV.SelectedItem.ToString();
        //    ObjDietMaster.TriedWeightLossDiet = cmbTriedWtLossDiet.SelectedItem.ToString();
        //    ObjDietMaster.WtLossGainSixMon = cmbWtLossGainInSixMonth.SelectedItem.ToString();

        //    ObjDietMaster.ClinicCompID = 0;
        //    ObjDietMaster.ClinicCompGastProbID = 0;
        //    ObjDietMaster.ClinicCompChronDisID = 0;
        //    ObjDietMaster.ClinicCompMedicationID = 0;
        //    ObjDietMaster.ClinicCompFatOilID = 0;
        //    ObjDietMaster.ClinicComplaintsNotes = txtClinicComplaintsNotes.Text;

        //    ObjDietMaster.GastProbID = 0;
        //    ObjDietMaster.Heartburn = cmbHeartburn.SelectedItem.ToString();
        //    ObjDietMaster.Bloating = cmbBloating.SelectedItem.ToString();
        //    ObjDietMaster.Gas = cmbGas.SelectedItem.ToString();
        //    ObjDietMaster.Diarrhoea = cmbDiarrhoea.SelectedItem.ToString();
        //    ObjDietMaster.Vomiting = cmbVomiting.SelectedItem.ToString();
        //    ObjDietMaster.Constipation = cmbConstipation.SelectedItem.ToString();
        //    ObjDietMaster.LaxativeAntacide = cmbUseAntacid.SelectedItem.ToString();
        //    ObjDietMaster.HomeRemedy = cmbFollowHomeRemedy.SelectedItem.ToString();

        //    ObjDietMaster.ChronicDiseaseID = 0;
        //    ObjDietMaster.DiabetesChronDis = cmbDiabetes.SelectedItem.ToString();
        //    ObjDietMaster.HypertensionChronDis = cmbHypertension.SelectedItem.ToString();
        //    ObjDietMaster.CardiacDisorders = cmbCardiacDisorders.SelectedItem.ToString();
        //    ObjDietMaster.KidneyDisorders = cmbKidneyDisorders.SelectedItem.ToString();
        //    ObjDietMaster.LeverDisorders = cmbLiverDisorders.SelectedItem.ToString();
        //    ObjDietMaster.PepticUlser = cmbPepticUlcer.SelectedItem.ToString();
        //    ObjDietMaster.OtherChronicDiseases = txtOtherChroniDisease.Text;
        //    ObjDietMaster.FollowedParticularDietForProb = txtFollowedParticularDietDetails.Text;

        //    ObjDietMaster.MedicationID = 0;
        //    ObjDietMaster.TakeVitaminSup = cmbVitaminSuppliment.SelectedItem.ToString();
        //    ObjDietMaster.VitaminSupDet = txtVitaminSupplimentDetails.Text;
        //    ObjDietMaster.TakeMineralSup = cmbMineralSuppliment.SelectedItem.ToString();
        //    ObjDietMaster.MineralSupDet = txtMineralSupplimentDetails.Text;
        //    ObjDietMaster.OralDrugDiabeteseDet = txtOralDrugForDiabetes.Text;
        //    ObjDietMaster.OralDrugHypertensionDet = txtOralDrugForHypertension.Text;

        //    ObjDietMaster.FatOilID = 0;
        //    ObjDietMaster.OilUseDetail = "";
        //    ObjDietMaster.OilQuantityForMonth = 2;
        //    ObjDietMaster.NoOfMembersInFamily = 4;

        //    ObjDietMaster.DietRecallID = 0;
        //    ObjDietMaster.Meal1 = Convert.ToDateTime(dtTeaTime.Text);
        //    ObjDietMaster.Meal2 = Convert.ToDateTime(dtBreakfastTime.Text);
        //    ObjDietMaster.Meal3 = Convert.ToDateTime(dtLunchTime.Text);
        //    ObjDietMaster.Meal4 = Convert.ToDateTime(dtTeaTime2.Text);
        //    ObjDietMaster.Meal5 = Convert.ToDateTime(dtDinnerTime.Text);
        //    ObjDietMaster.Meal6 = Convert.ToDateTime(dtAfterDinnerTime.Text);
        //    ObjDietMaster.RecallDietNotes = txtDietRecallNotes.Text;

            return ObjDietMaster;
        }

        private void BindDietMaster(int CustomerID)
        {
            DietMasterPage objDietMaster = new DietMasterPage();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string htmlToConvert = string.Empty;
            DateTime dtNow = DateTime.Now;
            PdfConverter pdfConverter = new PdfConverter();
            
            pdfConverter.LicenseKey = "831ufGlsfGprfGlybHxvbXJtbnJlZWVl";
            pdfConverter.PdfDocumentOptions.PdfPageSize = PdfPageSize.A4;
            pdfConverter.PdfDocumentOptions.RightMargin = 30;
            pdfConverter.PdfDocumentOptions.LeftMargin = 30;
            pdfConverter.PdfDocumentOptions.PdfCompressionLevel = PdfCompressionLevel.NoCompression;
            pdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Portrait;
            //  pdfConverter.RenderedHtmlElementSelector = "#divcontener";
            
            pdfConverter.PdfFooterOptions.FooterHeight = 55;
            //pdfConverter.PdfFooterOptions.AddElement(footerHtml);
            pdfConverter.PdfDocumentOptions.ShowHeader = true;
            pdfConverter.PdfDocumentOptions.ShowFooter = true;
            pdfConverter.PdfDocumentOptions.FitWidth = true;
            pdfConverter.PdfDocumentOptions.EmbedFonts = true;
            pdfConverter.JavaScriptEnabled = true;
            pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = true;
            pdfConverter.PdfDocumentOptions.AvoidImageBreak = true;
            pdfConverter.ConversionDelay = 3;

            //string downLoadFileName = reportLabel.Replace(" ", "_") + "_" + Convert.ToString(dtReportInfo.Rows[0]["ProjectName"]).Replace(" ", "_") + "_" + month.Trim() + "_" + (DateTime.Now).ToString("dd_MM_yyyy_HH_mm").Trim() + ".pdf";
            
            //byte[] pdfBytes = pdfConverter.GetPdfBytesFromUrl(htmlToConvert);

            StringBuilder readText = new StringBuilder();
            //readText.Append(File.ReadAllText("Report-Test.htm"));
            readText.Append(File.ReadAllText("GeetaNeutriHeal _ Sample Report.html"));

            readText = readText.Replace("{CenterAddressLine1}", "Geeta Nutri Heal Center");
            readText = readText.Replace("{CenterAddressLine1}", "Pune");
            
            //Initiallize Dummy Data For Report
            readText = createReportWithDummyData(readText);

            //////////////////////////////////////////////

            ////Patient Details Section
            //readText = readText.Replace("{Date}", dtNow.ToString("dd/MM/yyy"));
            //readText = readText.Replace("{Time}", dtNow.ToString("HH:mm"));
            //readText = readText.Replace("{PatientName}", txtPatientName.Text);
            //readText = readText.Replace("{PatientID}", txtPatientID.Text);
            //readText = readText.Replace("{Age}", txtPatientAge.Text);
            //readText = readText.Replace("{Gender}", cmbGender.SelectedItem.ToString());
            //readText = readText.Replace("{DOB}", txtDOB.Text);

            ////Anthrpometrics Section
            //readText = readText.Replace("{MsrWt}", txtMeasuredWeight.Text);
            //readText = readText.Replace("{MsrHt}", txtMeasuredHeight.Text);
            //readText = readText.Replace("{IdealBodyWt}", txtIdealBodyWeight.Text);
            //readText = readText.Replace("{NeckCRCM}", txtNeckCircumference.Text);
            //readText = readText.Replace("{BMI}", txtCalculatedBMI.Text);
            //readText = readText.Replace("{MUAC}", txtMUAC.Text);
            //readText = readText.Replace("{BMICAT}", cmbBMICategory.SelectedItem.ToString());
            //readText = readText.Replace("{MsrWaist}", txtMeasuredWaist.Text);
            //readText = readText.Replace("{BP}", txtBloodPressure.Text);

            ////Bio Chemical Labs Section
            //readText = readText.Replace("{FastingGlucose}", txtFastingGlucose.Text);
            //readText = readText.Replace("{Creatinine}", txtCreatinine.Text);
            //readText = readText.Replace("{Albumin}", txtAlbumin.Text);
            //readText = readText.Replace("{HbA1C}", txtHbA1C.Text);
            //readText = readText.Replace("{SGPT}", txtAltSGPT.Text);
            //readText = readText.Replace("{SGOT}", txtAltSGOT.Text);
            //readText = readText.Replace("{Hematocrit}", txtHematocrit.Text);
            //readText = readText.Replace("{Triglycerides}", txtTriglycerides.Text);
            //readText = readText.Replace("{HDL}", txtHDL.Text);
            //readText = readText.Replace("{TotalChol}", txtCholesterol.Text);
            //readText = readText.Replace("{AlkPhosphate}", txtAlkalinePhosphatase.Text);
            //readText = readText.Replace("{VitD3}", txtVitaminD3.Text);
            //readText = readText.Replace("{VitB12}", txtVitaminB12.Text);
            //readText = readText.Replace("{OthersBIO}", txtOtherBiochemicalDetails.Text);

            //////////////////////////////////////////

            string temp = readText.ToString();

            string dir = Directory.GetCurrentDirectory();

            string file = txtPatientName.Text + "_" + dtNow.ToString("yyyyMMdd_HHmm");
            

            using (StreamWriter swReport = new StreamWriter(file + ".html"))
            {
                swReport.Write(temp);
            }


            //pdfConverter.SavePdfFromHtmlFileToFile(dir+"\\Report-Test.htm", file+".pdf");
            pdfConverter.SavePdfFromHtmlFileToFile(dir + "\\" + file + ".html", file + ".pdf");
            //pdfConverter.ConvertUrlToPdfDocumentObject("Report-Test.htm");
            //pdfConverter.ConvertHtmlFileToPdfDocumentObject("Report-Test.htm");
            //pdfConverter.SavePdfFromHtmlStringToFile(temp, "Test2.pdf");

            MessageBox.Show("Report Print Complete");
            
        }

        private StringBuilder createReportWithDummyData(StringBuilder sbReport)
        {
            ////Patient Details Section
            sbReport = sbReport.Replace("{Date}", DateTime.Now.ToString("dd/MM/yyy"));
            sbReport = sbReport.Replace("{Time}", DateTime.Now.ToString("HH:mm"));
            sbReport = sbReport.Replace("{PatientName}", "John SMith");
            sbReport = sbReport.Replace("{PatientID}", "1001");
            sbReport = sbReport.Replace("{Age}", "27");
            sbReport = sbReport.Replace("{Gender}", "M");
            sbReport = sbReport.Replace("{DOB}", "5/8/1989");

            //Anthrpometrics Section
            sbReport = sbReport.Replace("{MsrWt}", "54");
            sbReport = sbReport.Replace("{MsrHt}", "167");
            sbReport = sbReport.Replace("{IdealBodyWt}", "63");
            sbReport = sbReport.Replace("{NeckCRCM}","24");
            sbReport = sbReport.Replace("{BMI}", "20.5");
            sbReport = sbReport.Replace("{MUAC}", "16");
            sbReport = sbReport.Replace("{BMICAT}", "Normal");
            sbReport = sbReport.Replace("{MsrWaist}", "32");
            sbReport = sbReport.Replace("{BP}", "120");

            //Bio Chemical Labs Section
            sbReport = sbReport.Replace("{FastingGlucose}", "1");
            sbReport = sbReport.Replace("{Creatinine}", "0.8");
            sbReport = sbReport.Replace("{Albumin}", "1");
            sbReport = sbReport.Replace("{HbA1C}", "1");
            sbReport = sbReport.Replace("{SGPT}", "1");
            sbReport = sbReport.Replace("{SGOT}", "1");
            sbReport = sbReport.Replace("{Hematocrit}", "14");
            sbReport = sbReport.Replace("{Triglycerides}", "1");
            sbReport = sbReport.Replace("{HDL}", "1");
            sbReport = sbReport.Replace("{TotalChol}", "1");
            sbReport = sbReport.Replace("{AlkPhosphate}", "1");
            sbReport = sbReport.Replace("{VitD3}", "1");
            sbReport = sbReport.Replace("{VitB12}", "1");
            sbReport = sbReport.Replace("{OthersBIO}", "1");


            return sbReport;
        }

        private void timerStopWatch_Tick(object sender, EventArgs e)
        {
            int hour = watch.Elapsed.Hours;
            int min = watch.Elapsed.Minutes;
            int sec = watch.Elapsed.Seconds;
            lblStopWatchMin.Text = hour + " : " + min + " : "+ sec;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            DietMasterPage dm = new DietMasterPage();
            dm.Show();
        }

        private void frmDiet_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DietMaster objDietMaster = PrepareDietMaster();
            objDietMaster.Operation = 2;
            objDietMaster.CustomerID =  PatientInfo.PatientID;


            int i = 0;
            BusinessHelper<IDietMaster>.Use(DietMasterManager =>
            {
                i = DietMasterManager.ModifyDietMaster(objDietMaster);
            });

            if (i == 1)
                MessageBox.Show("Updated Successfully");
            else
                MessageBox.Show("Updated Successfully");
        }

        

        


       
        

    

        

        
        
    }
}
