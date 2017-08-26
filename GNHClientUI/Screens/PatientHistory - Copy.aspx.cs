using Diet.Business.Core.ModDietMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI
{
    public partial class PatientHistory : System.Web.UI.Page
    {
        DataTable dtSearchMaster = new DataTable();
        DietMasterManager master = new DietMasterManager();
        int i = 0; 	// I will use this for creating unique accordion panes
        // in each iteration of the loop
        Label lblTitle; 	// This i will use as a child control to handle Header Text
        // in the accordion pane
        Label lblContent; 	// This i will use as a child control to handle Content Text
        // in the accordion pane
        AjaxControlToolkit.AccordionPane pn; // I have declared an accordion pane but
        // not yet initialized
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["PatientID"] == null || Session["PatientID"].ToString().Equals("0"))
                    Server.Transfer("~/Screens/PatientDetails.aspx");
                else
                    bind();
            }
        }
        protected void bind()
        {
            dtSearchMaster = master.GetDietMaster_History(Convert.ToInt32(Session["PatientID"].ToString()));
            if (dtSearchMaster.Rows.Count == 0)
                Nodatadiv.Style.Add("display", "block");
            else
                Nodatadiv.Style.Add("display", "none");

            foreach (DataRow dr in dtSearchMaster.Rows)
            {
                lblTitle = new Label();
                lblContent = new Label();
                lblTitle.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr["CDdtUpdated"]));
                //lblContent.Text = dr["PatientName"].TString();
                pn = new AjaxControlToolkit.AccordionPane();
                pn.ID = "Pane" + i;
                pn.HeaderContainer.Controls.Add(lblTitle);
                pn.ContentContainer.Controls.Add(new LiteralControl(bindhistory(i)));
                accClientHistory.Panes.Add(pn);
                ++i;
            }

        }
        protected string bindhistory(int i)
        {
            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
            strBody.Append("<table align='center' width='100%'><tr><td colspan='4' align='center'><b>" + dtSearchMaster.Rows[i]["CDsCustName"].ToString() + "</b></td></tr>");
            strBody.Append("<tr><td align='left'>Patient ID :" + dtSearchMaster.Rows[i]["CDnCustomerIDPK"].ToString() + "</td><td colspan='2'>DOB:" + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Rows[i]["CDdtDOB"])) + "</td><td align='right'>" + dtSearchMaster.Rows[i]["CDnCustAge"].ToString() + "Y/" + (dtSearchMaster.Rows[i]["CDnGender"].ToString() == "0" ? "M" : "F") + "</td></tr></table>");
            strBody.Append("<hr size='1' width='100%'>");
            //Anthropometics
            strBody.Append(" <table  align='center' width='100%'><tr><td colspan='3' align='center'><b>Anthropometics</b></td></tr><tr><td align='left'>Measured Wt. " + dtSearchMaster.Rows[i]["AMnMeasWt"].ToString() + " kg</td><td align='right'>BMI " + dtSearchMaster.Rows[i]["AMnCalculatedBMI"].ToString() + "</td><td colspan=2 align='right'>BMI Category " + dtSearchMaster.Rows[i]["AMnBMICat"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Measured Ht. " + dtSearchMaster.Rows[i]["AMnMeasHt"].ToString() + " m</td><td align='right'>MUAC " + dtSearchMaster.Rows[i]["AMnMUAC"].ToString() + "cm</td><td align='right'>Measured Waist " + dtSearchMaster.Rows[i]["AMnMeasWaist"].ToString() + "cm</td></tr>");
            strBody.Append("<tr><td align='left'>Ideal Body Wt. " + dtSearchMaster.Rows[i]["AMnIdealBodyWt"].ToString() + " kg</td><td align='right'>Neck Circumference " + dtSearchMaster.Rows[i]["AMnNeckCircum"].ToString() + "</td><td align='right'>Blood Pressure " + dtSearchMaster.Rows[i]["AMnBloodPressure"].ToString() + " mmHg</td></tr>");
            strBody.Append("</tr></table>");

            //Bio Chemical Labs
            strBody.Append("<hr size='1' width='100%'>");
            strBody.Append("<table align='center' width='100%'><tr><td colspan='9' align='center'><b>Bio Chemical Labs</b></td></tr>");
            strBody.Append("<tr><td align='left'>Fasting Glucose</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnFastingGluc"].ToString() + "</td><td align='left'>mg/dL</td>");
            strBody.Append("<td align='left'>Creatinine</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnCreatinine"].ToString() + "</td><td align='left'>g/dL</td>");
            strBody.Append("<td align='left'>Albumin</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnAlbumin"].ToString() + "</td><td align='left'>g/dL</td></tr>");
            strBody.Append("<tr><td align='left'>HbA1C</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnHbA1C"].ToString() + "</td><td align='left'>%</td>");
            strBody.Append("<td align='left'>ALT (SGPT)</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnAltSGPT"].ToString() + "</td><td align='left'>IU/L</td>");
            strBody.Append("<td align='left'>ALT (SGOT)</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnAltSGOT"].ToString() + "</td></td><td align='left'>IU/L</td></tr>");
            strBody.Append("<tr><td align='left'>Hematocrit</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnHematocrit"].ToString() + "</td><td align='left'>(%)</td>");
            strBody.Append("<td align='left'>Triglycerides</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnTriglycerides"].ToString() + "</td><td align='left'>mg/dL</td>");
            strBody.Append("<td align='left'>HDL</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnHDL"].ToString() + "</td><td align='left'>mg/dL</td></tr>");
            strBody.Append("<tr><td align='left'>Total Cholesterol</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnTotCholesterol"].ToString() + "</td><td align='left'>mg/dL</td>");
            strBody.Append("<td align='left'>Alkaline Phosphatase</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnAlkalinePhosphatase"].ToString() + "</td><td align='left'>IU/L</td>");
            strBody.Append("<td align='left'>Vitamin D3</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnVitaminD3"].ToString() + "</td><td align='left'></td></tr>");
            strBody.Append("<tr><td align='left'>Vitamin B12</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLnVitaminB12"].ToString() + "</td><td align='left'></td>");
            strBody.Append("<td align='left'>Others</td><td align='left'>" + dtSearchMaster.Rows[i]["BCLsOthers"].ToString() + "</td><td align='left'></td></tr></table>");

            //COMORBIDITY 

            strBody.Append("<hr size='1' width='100%'>");
            strBody.Append("<table align='center' width='100%'><tr><td colspan='3' align='center' ><b>Comorbidity</b></td></tr>");
            strBody.Append("<tr><td align='left'>CHF :" + dtSearchMaster.Rows[i]["CBsCHF"].ToString() + "</td><td align='center'>Hypertension :" + dtSearchMaster.Rows[i]["CBsHypertension"].ToString() + "</td><td align='right'>Asthma :" + dtSearchMaster.Rows[i]["CBsAsthma"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Sleep Apnea :" + dtSearchMaster.Rows[i]["CBsSleepApnea"].ToString() + "</td><td align='center'>Thyroid :" + dtSearchMaster.Rows[i]["CBsThyroid"].ToString() + "</td><td align='right'>Diabetes :" + dtSearchMaster.Rows[i]["CBsDiabetes"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>IHD :" + dtSearchMaster.Rows[i]["CBsIHD"].ToString() + "</td><td align='right' colspan='2'>Functional Status :" + dtSearchMaster.Rows[i]["CBsFunctionalStatus"].ToString() + "</td></tr></table>");

            //Diet And Lifestyle
            strBody.Append("<hr size='1' width='100%'>");
            strBody.Append("<table  align='center' width='100%'><tr><td colspan='4' align='center'><b>Diet And Lifestyle</b></td></tr>");
            strBody.Append("<tr><td align='left'>Regular Execise</td><td align='left'>" + dtSearchMaster.Rows[i]["DLsRegExersize"].ToString() + "</td><td align='right'>Alcohol</td><td align='right'>" + dtSearchMaster.Rows[i]["DLsAlcohol"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Smoking</td><td align='left'>" + dtSearchMaster.Rows[i]["DLsSmoking"].ToString() + "</td><td align='right'>Sleep Hours Per Day</td><td align='right'>" + dtSearchMaster.Rows[i]["DLnSleepPerDay"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Exercise Detail</td><td align='left'>" + dtSearchMaster.Rows[i]["DLsExcersizeDetail"].ToString() + "</td><td></td><td></td></tr>");
            strBody.Append("<tr><td colspan='4' align='left'><b>Diet History</b></td></tr>");
            strBody.Append("<tr><td align='left'>Diet Type</td><td align='left'>" + dtSearchMaster.Rows[i]["DHsDietType"].ToString() + "</td><td align='right'>Eat When Stress</td><td align='right'>" + dtSearchMaster.Rows[i]["DHsStressEat"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Frequency Of Outside Eat</td><td align='left'>" + dtSearchMaster.Rows[i]["DHsFreqOutEat"].ToString() + "</td><td align='right'>Eat When Bored</td><td align='right'>" + dtSearchMaster.Rows[i]["DHsBoredEat"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Typical Meal in Day</td><td align='left'>" + dtSearchMaster.Rows[i]["DHnTypicalMealDay"].ToString() + "</td><td align='right'>Do You Have Breakfast Everyday</td><td align='right'>" + dtSearchMaster.Rows[i]["DHsBreakfast"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Typical Snax in Day</td><td align='left'>" + dtSearchMaster.Rows[i]["DHnTypicalSnaxDay"].ToString() + "</td><td align='right'>Eat when watching TV	</td><td align='right'>" + dtSearchMaster.Rows[i]["DHsWatchTVEat"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Caloric Beverages</td><td align='left'>" + dtSearchMaster.Rows[i]["DHsCaloricbeverages"].ToString() + "</td><td align='right'>Tried Wt. Loss Diet Before</td><td align='right'>" + dtSearchMaster.Rows[i]["DHsWtLossDiet"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Wt. Loss/Gain in Sixth Month</td><td align='left'>" + dtSearchMaster.Rows[i]["DHsWtLossGainSixMon"].ToString() + "</td><td></td><td></td></tr>");
            strBody.Append("<tr><td colspan='6' align='left'><b>Fat and Oil</b></td></tr>");
            strBody.Append("<tr><td align='left'>Oil Detail</td><td align='left'>" + dtSearchMaster.Rows[i]["CCsOilUseDetail"].ToString() + "</td><td align='right'>Oil Quantity in Month</td><td align='right'>" + dtSearchMaster.Rows[i]["CCnOilQuantityMonth"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>No of Family Members</td><td align='left'>" + dtSearchMaster.Rows[i]["CCnMembersInFamily"].ToString() + "</td><td align='right'>Sugar Quantity in Month</td><td align='right'><td align='right'>" + dtSearchMaster.Rows[i]["CCnSugarQuantity"].ToString() + "</td></tr></table>");

            //Clinical Complaints
            strBody.Append("<hr size='1' width='100%'>");
            strBody.Append("<table align='center' width='100%'><tr><td colspan='6' align='center'><b>Clinical Complaints</b></td></tr>");
            strBody.Append("<tr><td colspan='6' align='left'><b>Gastrointestinal Problems</b></td></tr>");
            strBody.Append("<tr><td align='left'>Heartburn </td><td align='left'>" + dtSearchMaster.Rows[i]["GPsHeartburn"].ToString() + "</td><td align='right'>Vomiting</td><td align='right'>" + dtSearchMaster.Rows[i]["GPsVomiting"].ToString() + "</td>");
            strBody.Append("<td align='right'>Bloating</td><td align='right'>" + dtSearchMaster.Rows[i]["GPsBloating"].ToString() + "</td><tr><tr><td align='left'>Use Any Luxative/Antacid</td><td align='left'>" + dtSearchMaster.Rows[i]["GPsConstipation"].ToString() + "</td>");
            strBody.Append("<td align='right'>Gas</td><td align='right'>" + dtSearchMaster.Rows[i]["GPsGas"].ToString() + "</td><td align='right'>Constipation</td><td align='right'>" + dtSearchMaster.Rows[i]["GPsLaxaAnta"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Diarrhoea</td><td align='left'>" + dtSearchMaster.Rows[i]["GPsDiarrhoea"].ToString() + "</td><td align='right'>Follow Home Remedy</td><td align='right'>" + dtSearchMaster.Rows[i]["GPsHomeRem"].ToString() + "</td></tr>");
            strBody.Append("<tr><td colspan='4' align='left'><b>ChronicDiseases</b></td></tr>");
            strBody.Append("<tr><td align='left'>Diabetes</td><td align='left'>" + dtSearchMaster.Rows[i]["CDsDiabetes"].ToString() + "</td><td align='right'>Liver Disorders</td><td align='right'>" + dtSearchMaster.Rows[i]["CDsLeverDis"].ToString() + "</td>");
            strBody.Append("<td align='right'>Hypertension</td><td align='right'>" + dtSearchMaster.Rows[i]["CDsHypertension"].ToString() + "</td></tr>");
            strBody.Append("<td align='right'>Cardiac Disorders</td><td align='right'>" + dtSearchMaster.Rows[i]["CDsCardiacDis"].ToString() + "</td><td align='right'>Others</td><td align='right'>" + dtSearchMaster.Rows[i]["CDsOtherDet"].ToString() + "</td></tr>");
            strBody.Append("<tr><td align='left'>Kidney Disorders</td><td align='left'>" + dtSearchMaster.Rows[i]["CDsKidneyDis"].ToString() + "</td><td align='right'>Followed Perticular Diet Details </td><td align='right'>" + dtSearchMaster.Rows[i]["CDsParticularProbDet"].ToString() + "</td></tr>");
            strBody.Append("<td colspan='4' align='left'><b>Medication</b></td></tr>");
            strBody.Append("<tr><td align='left'>Vitamin Suplement </td><td align='left'>" + dtSearchMaster.Rows[i]["MCsVitaminSup"].ToString() + "</td><td align='right'>Vitamin Suplement Details</td> <td align='right'>" + dtSearchMaster.Rows[i]["MCsVitaminSupDet"].ToString() + "</td>");
            strBody.Append("<td align='right'>Mineral Suplement </td><td align='right'>" + dtSearchMaster.Rows[i]["MCsMineralSup"].ToString() + "</td></tr><tr><td align='left'>Mineral Suplement Details </td><td align='left'>" + dtSearchMaster.Rows[i]["MCsMineralSupDet"].ToString() + "</td>");
            strBody.Append("<td align='right'>Oral Drug Type </td><td align='right'>" + dtSearchMaster.Rows[i]["MCsOralDrugType"].ToString() + "</td><td align='right'>Oral Drug  Details </td><td align='right'>" + dtSearchMaster.Rows[i]["MCsOralDrugDet"].ToString() + "</td></tr></table>");


            strBody.Append("<hr size='1' width='100%'>");
            strBody.Append("<table align='center' width='100%'><tr><td colspan='6' align='center'><b>DietRecall</b></td></tr>");
            strBody.Append("<tr><td align='left'>Meal 1 </td><td align='left'>" + String.Format("{0:t}", Convert.ToDateTime(dtSearchMaster.Rows[i]["DRdtMeal1"])) + "</td><td align='center'>Meal 2</td><td align='center'>" + String.Format("{0:t}", Convert.ToDateTime(dtSearchMaster.Rows[i]["DRdtMeal2"])) + "</td>");
            strBody.Append("<td align='left'>Meal 3</td><td align='left'>" + String.Format("{0:t}", Convert.ToDateTime(dtSearchMaster.Rows[i]["DRdtMeal3"])) + "</td></tr><tr><td align='left'>Meal 4</td><td align='left'>" + String.Format("{0:t}", Convert.ToDateTime(dtSearchMaster.Rows[i]["DRdtMeal4"])) + "</td>");
            strBody.Append("<td align='center'>Meal 5</td><td align='center'>" + String.Format("{0:t}", Convert.ToDateTime(dtSearchMaster.Rows[i]["DRdtMeal5"])) + "</td><td align='left'>Meal 6</td><td align='left'>" + String.Format("{0:t}", Convert.ToDateTime(dtSearchMaster.Rows[i]["DRdtMeal6"])) + "</td></tr></table>");
            return strBody.ToString();
        }

    }
}