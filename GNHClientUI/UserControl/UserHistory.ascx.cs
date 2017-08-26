using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Diet.Business.Core.ModDietMaster;
using System.Data;
using Diet.Business.Core;
using Diet.Common;

namespace GNHClientUI
{
    public partial class UserHistory : System.Web.UI.UserControl
    {
        DataSet dtSearchMaster = new DataSet();
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
                {
                    Nodatadiv.Style.Add("display", "block");
                }
                else
                    bind();
            }
        }
        protected void bind()
        {
            dtSearchMaster = master.GetDietMaster_History(Convert.ToInt32(Session["PatientID"].ToString()));
            if (dtSearchMaster.Tables[0].Rows.Count == 0)
                Nodatadiv.Style.Add("display", "block");
            else
                Nodatadiv.Style.Add("display", "none");

            foreach (DataRow dr in dtSearchMaster.Tables[0].Rows)
            {
                lblTitle = new Label();
                lblContent = new Label();
                lblTitle.Text = String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr["CDdtUpdated"]));
                //lblContent.Text = dr["PatientName"].TString();
                pn = new AjaxControlToolkit.AccordionPane();
                pn.ID = "Pane" + i;
                pn.HeaderContainer.Controls.Add(lblTitle);
                pn.ContentContainer.Controls.Add(new LiteralControl(bindhistory(i, String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dr["CDdtUpdated"])))));
                pn.Attributes.Add("width", "100%");
                accClientHistory.Panes.Add(pn);
                ++i;
            }
        }
        protected string bindhistory(int i, string date)
        {
            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
            if (dtSearchMaster.Tables[0].Rows.Count > i)
            {

                strBody.Append("<table align='center' width='100%'><tr><td colspan='4' align='center'><b>" + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDsCustName"]) + " " + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDsLastName"]) + "</b></td></tr>");
                strBody.Append("<tr><td align='left'>Patient ID :" + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDnCustomerIDPK"]) + "</td><td colspan='2'>DOB:" + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Tables[0].Rows[i]["CDdtDOB"])) + "</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDnCustAge"]) + "Y/" + (Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDnGender"]) == "0" ? "M" : "F") + "</td></tr></table>");
                strBody.Append("<hr size='1' width='100%'>");

            }
            //Anthropometics
            if (dtSearchMaster.Tables[1].Rows.Count > i && String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Tables[1].Rows[i]["AMdtUpdated"])).Equals(date))
            {

                strBody.Append(" <table  align='center' width='100%'><tr><td colspan='3' align='center'><b>Anthropometics</b></td></tr><tr><td align='left'>Measured Wt. " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnMeasWt"]) + " kg</td><td align='right'>BMI " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnCalculatedBMI"]) + "</td><td colspan=2 align='right'>BMI Category " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnBMICat"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Measured Ht. " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnMeasHt"]) + " m</td><td align='right'>MUAC " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnMUAC"]) + "cm</td><td align='right'>Measured Waist " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnMeasWaist"]) + "cm</td></tr>");
                strBody.Append("<tr><td align='left'>Ideal Body Wt. " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnIdealBodyWt"]) + " kg</td><td align='right'>Neck Circumference " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnNeckCircum"]) + "</td><td align='right'>Blood Pressure " + Convert.ToString(dtSearchMaster.Tables[1].Rows[i]["AMnBloodPressure"]) + " mmHg</td></tr>");
                strBody.Append("</tr></table>");

            }
            //Bio Chemical Labs
            if (dtSearchMaster.Tables[2].Rows.Count > i && String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Tables[2].Rows[i]["BCLdtUpdated"])).Equals(date))
            {

                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table align='center' width='100%'><tr><td colspan='9' align='center'><b>Bio Chemical Labs</b></td></tr>");
                strBody.Append("<tr><td align='left'>Fasting Glucose</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnFastingGluc"]) + "</td><td align='left'>mg/dL</td>");
                strBody.Append("<td align='left'>Creatinine</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnCreatinine"]) + "</td><td align='left'>g/dL</td>");
                strBody.Append("<td align='left'>Albumin</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnAlbumin"]) + "</td><td align='left'>g/dL</td></tr>");
                strBody.Append("<tr><td align='left'>HbA1C</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnHbA1C"]) + "</td><td align='left'>%</td>");
                strBody.Append("<td align='left'>ALT (SGPT)</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnAltSGPT"]) + "</td><td align='left'>IU/L</td>");
                strBody.Append("<td align='left'>ALT (SGOT)</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnAltSGOT"]) + "</td></td><td align='left'>IU/L</td></tr>");
                strBody.Append("<tr><td align='left'>Hematocrit</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnHematocrit"]) + "</td><td align='left'>(%)</td>");
                strBody.Append("<td align='left'>Triglycerides</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnTriglycerides"]) + "</td><td align='left'>mg/dL</td>");
                strBody.Append("<td align='left'>HDL</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnHDL"]) + "</td><td align='left'>mg/dL</td></tr>");
                strBody.Append("<tr><td align='left'>Total Cholesterol</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnTotCholesterol"]) + "</td><td align='left'>mg/dL</td>");
                strBody.Append("<td align='left'>Alkaline Phosphatase</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnAlkalinePhosphatase"]) + "</td><td align='left'>IU/L</td>");
                strBody.Append("<td align='left'>Vitamin D3</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnVitaminD3"]) + "</td><td align='left'></td></tr>");
                strBody.Append("<tr><td align='left'>Vitamin B12</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLnVitaminB12"]) + "</td><td align='left'></td>");
                strBody.Append("<td align='left'>Others</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[i]["BCLsOthers"]) + "</td><td align='left'></td></tr></table>");
            }
            //COMORBIDITY 
            if (dtSearchMaster.Tables[3].Rows.Count > i && String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Tables[3].Rows[i]["CBdtUpdated"])).Equals(date))
            {
                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table align='center' width='100%'><tr><td colspan='3' align='center' ><b>Comorbidity</b></td></tr>");
                strBody.Append("<tr><td align='left'>CHF :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsCHF"]) + "</td><td align='center'>Hypertension :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsHypertension"]) + "</td><td align='right'>Asthma :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsAsthma"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Sleep Apnea :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsSleepApnea"]) + "</td><td align='center'>Thyroid :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsThyroid"]) + "</td><td align='right'>Diabetes :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsDiabetes"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>IHD :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsIHD"]) + "</td><td align='right' colspan='2'>Functional Status :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[i]["CBsFunctionalStatus"]) + "</td></tr></table>");
            }
            if (dtSearchMaster.Tables[4].Rows.Count > i && String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Tables[4].Rows[i]["DLdtUpdated"])).Equals(date))
            {
                //Diet And Lifestyle
                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table  align='center' width='100%'><tr><td colspan='4' align='center'><b>Diet And Lifestyle</b></td></tr>");
                strBody.Append("<tr><td align='left'>Regular Execise</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLsRegExersize"]) + "</td><td align='right'>Alcohol</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLsAlcohol"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Smoking</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLsSmoking"]) + "</td><td align='right'>Sleep Hours Per Day</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLnSleepPerDay"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Exercise Detail</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLsExcersizeDetail"]) + "</td><td></td><td></td></tr>");
                strBody.Append("<tr><td colspan='4' align='left'><b>Diet History</b></td></tr>");
                strBody.Append("<tr><td align='left'>Diet Type</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsDietType"]) + "</td><td align='right'>Eat When Stress</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsStressEat"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Frequency Of Outside Eat</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsFreqOutEat"]) + "</td><td align='right'>Eat When Bored</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsBoredEat"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Typical Meal in Day</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHnTypicalMealDay"]) + "</td><td align='right'>Do You Have Breakfast Everyday</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsBreakfast"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Typical Snax in Day</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHnTypicalSnaxDay"]) + "</td><td align='right'>Eat when watching TV	</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsWatchTVEat"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Caloric Beverages</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsCaloricbeverages"]) + "</td><td align='right'>Tried Wt. Loss Diet Before</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsWtLossDiet"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Wt. Loss/Gain in Sixth Month</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DHsWtLossGainSixMon"]) + "</td><td></td><td></td></tr>");
                strBody.Append("<tr><td colspan='6' align='left'><b>Fat and Oil</b></td></tr>");
                strBody.Append("<tr><td align='left'>Oil Detail</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLsOilUseDetail"]) + "</td><td align='right'>Oil Quantity in Month</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLnOilQuantityMonth"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>No of Family Members</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLnMembersInFamily"]) + "</td><td align='right'>Sugar Quantity in Month</td><td align='right'><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[i]["DLnSugarQuantity"]) + "</td></tr></table>");
            }
            //Clinical Complaints
            if (dtSearchMaster.Tables[5].Rows.Count > i && String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Tables[5].Rows[i]["CCdtUpdated"])).Equals(date))
            {
                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table align='center' width='100%'><tr><td colspan='6' align='center'><b>Clinical Complaints</b></td></tr>");
                strBody.Append("<tr><td colspan='6' align='left'><b>Gastrointestinal Problems</b></td></tr>");
                strBody.Append("<tr><td align='left'>Heartburn </td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsHeartburn"]) + "</td><td align='right'>Vomiting</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsVomiting"]) + "</td>");
                strBody.Append("<td align='right'>Bloating</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsBloating"]) + "</td><tr><tr><td align='left'>Use Any Luxative/Antacid</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsConstipation"]) + "</td>");
                strBody.Append("<td align='right'>Gas</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsGas"]) + "</td><td align='right'>Constipation</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsLaxaAnta"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Diarrhoea</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsDiarrhoea"]) + "</td><td align='right'>Follow Home Remedy</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["GPsHomeRem"]) + "</td></tr>");
                strBody.Append("<tr><td colspan='4' align='left'><b>ChronicDiseases</b></td></tr>");
                strBody.Append("<tr><td align='left'>Diabetes</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["CDsDiabetes"]) + "</td><td align='right'>Liver Disorders</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["CDsLeverDis"]) + "</td>");
                strBody.Append("<td align='right'>Hypertension</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["CDsHypertension"]) + "</td></tr>");
                strBody.Append("<td align='right'>Cardiac Disorders</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["CDsCardiacDis"]) + "</td><td align='right'>Others</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["CDsOtherDet"]) + "</td></tr>");
                strBody.Append("<tr><td align='left'>Kidney Disorders</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["CDsKidneyDis"]) + "</td><td align='right'>Followed Perticular Diet Details </td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["CDsParticularProbDet"]) + "</td></tr>");
                strBody.Append("<td colspan='4' align='left'><b>Medication</b></td></tr>");
                strBody.Append("<tr><td align='left'>Vitamin Suplement </td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["MCsVitaminSup"]) + "</td><td align='right'>Vitamin Suplement Details</td> <td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["MCsVitaminSupDet"]) + "</td>");
                strBody.Append("<td align='right'>Mineral Suplement </td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["MCsMineralSup"]) + "</td></tr><tr><td align='left'>Mineral Suplement Details </td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["MCsMineralSupDet"]) + "</td>");
                strBody.Append("<td align='right'>Oral Drug Type </td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["MCsOralDrugType"]) + "</td><td align='right'>Oral Drug  Details </td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[i]["MCsOralDrugDet"]) + "</td></tr></table>");

            }
            ///Recall diet Details
            DataTable dtFoodListWithID = new FoodMasterManager().GetFoodListWithID();
            //Get Customer Recall Diet Details
            int custID = Convert.ToInt32(Session["PatientID"]);
            int k = 0;
            DataTable dtRecallDietDetail = new DataTable();
            dtRecallDietDetail = new RecallDietManager().GetRecallDietDetailsHistory(custID, date);
            if (dtRecallDietDetail.Rows.Count > 0)
            {
                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table width=90%><tr><td><b>Recall Diet</b></td></tr></table><br/>");
                strBody.Append("<table border=1 width=90%  align=center><tr><td align=center><b>Meals</b></td><td align=center><b>Meal Details</b></td></tr>");

                List<RecallDietDetails> lstRecallDietDetails = new List<RecallDietDetails>();
                foreach (DataRow drRecallDiet in dtRecallDietDetail.Rows)
                {
                    RecallDietDetails objRecallDietDetails = new RecallDietDetails();
                    objRecallDietDetails.CustomerID = custID;
                    objRecallDietDetails.VisitDate = Convert.ToDateTime(drRecallDiet["VisitDate"]);
                    objRecallDietDetails.Notes = Convert.ToString(drRecallDiet["Notes"]);
                    List<MealDetails> lstMealDetails = new List<MealDetails>();

                    for (int mealID = 1; mealID <= 12; mealID++)
                    {
                        string mealName = "Meal" + mealID;
                        string[] mealDetailSeperatingChars = { "@@" };
                        char[] mealFoodItemSeperatingChars = { '~' };
                        char[] mealFoodItemDetailSeperatingChars = { '|' };

                        string[] strMealDetails = Convert.ToString(drRecallDiet[mealName]).Split(mealDetailSeperatingChars, StringSplitOptions.None);
                        MealDetails objMealDetails = new MealDetails();
                        objMealDetails.MealName = mealName;
                        objMealDetails.Time = Convert.ToDateTime(strMealDetails[0]);
                        objMealDetails.Days = Convert.ToString(strMealDetails[1]);

                        List<MealFoodDetails> lstMealFoodDetails = new List<MealFoodDetails>();
                        string[] strMealFoodDetails = Convert.ToString(strMealDetails[2]).Split(mealFoodItemSeperatingChars, StringSplitOptions.RemoveEmptyEntries);

                        if (strMealFoodDetails.Count() > 0)
                            strBody.Append("<tr><td align=center><b>" + "Meal " + mealID + " (" + Convert.ToDateTime(objMealDetails.Time).ToShortTimeString() + ")</b></td>");
                        k = 0;
                        foreach (String strFoodItem in strMealFoodDetails)
                        {

                            MealFoodDetails objMealFoodDetails = new MealFoodDetails();
                            string[] strFoodItemDetail = strFoodItem.Split(mealFoodItemDetailSeperatingChars, StringSplitOptions.None);

                            var foodRows = dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                            string strFoodName = Convert.ToString(foodRows[0]["FoodName"]);
                            if (k == 0)
                                strBody.Append("<td><ul><li>" + strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");
                            else
                                strBody.Append("<li>" + strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");
                            ++k;
                        }
                        //strBody.Append("</td></tr></table>");
                        strBody.Append("</td></tr>");
                    }
                    strBody.Append("</table>");
                }
            }

            //Recommended Diet
            DataTable dtRecommendedDietDetail = new DataTable();
            dtRecommendedDietDetail = new RecommendedDietManager().GetRecommendedDietDetailsHistory(custID, date);
            List<RecommendedDietDetails> lstRecommendedDietDetails = new List<RecommendedDietDetails>();
            if (dtRecommendedDietDetail.Rows.Count > 0)
            {
                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table width=90%><tr><td><b>Recommended Diet</b></td></tr></table><br/>");
                strBody.Append("<table border=1 width=90% align=center><tr><td align=center><b>Meals</b></td><td align=center><b>Meal Details</b></td></tr>");

                foreach (DataRow drRecommendedDiet in dtRecommendedDietDetail.Rows)
                {
                    RecommendedDietDetails objRecommendedDietDetails = new RecommendedDietDetails();
                    objRecommendedDietDetails.CustomerID = custID;
                    objRecommendedDietDetails.VisitDate = Convert.ToDateTime(drRecommendedDiet["VisitDate"]);
                    objRecommendedDietDetails.Notes = Convert.ToString(drRecommendedDiet["Notes"]);

                    List<MealDetails> lstMealDetails = new List<MealDetails>();
                    for (int mealID = 1; mealID <= 12; mealID++)
                    {
                        string mealName = "Meal" + mealID;
                        string[] mealDetailSeperatingChars = { "@@" };
                        char[] mealFoodItemSeperatingChars = { '~' };
                        char[] mealFoodItemDetailSeperatingChars = { '|' };

                        string[] strMealDetails = Convert.ToString(drRecommendedDiet[mealName]).Split(mealDetailSeperatingChars, StringSplitOptions.None);

                        MealDetails objMealDetails = new MealDetails();
                        objMealDetails.MealName = mealName;
                        objMealDetails.Time = Convert.ToDateTime(strMealDetails[0]);
                        objMealDetails.Days = Convert.ToString(strMealDetails[1]);

                        List<MealFoodDetails> lstMealFoodDetails = new List<MealFoodDetails>();
                        string[] strMealFoodDetails = Convert.ToString(strMealDetails[2]).Split(mealFoodItemSeperatingChars, StringSplitOptions.RemoveEmptyEntries);

                        if (strMealFoodDetails.Count() > 0)
                            strBody.Append("<tr><td align=center><b>" + "Meal " + mealID + " (" + Convert.ToDateTime(objMealDetails.Time).ToShortTimeString() + ")</b></td>");

                        k = 0;
                        foreach (String strFoodItem in strMealFoodDetails)
                        {
                            MealFoodDetails objMealFoodDetails = new MealFoodDetails();
                            string[] strFoodItemDetail = strFoodItem.Split(mealFoodItemDetailSeperatingChars, StringSplitOptions.None);

                            var foodRows = dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                            string strFoodName = Convert.ToString(foodRows[0]["FoodName"]);

                            if (k == 0)
                                strBody.Append("<td><ul><li>" + strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");
                            else
                                strBody.Append("<li>" + strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");

                            k++;
                        }
                        strBody.Append("</td></tr>");
                    }
                    strBody.Append("</table>");
                }
            }

            return strBody.ToString();
        }
    }
}