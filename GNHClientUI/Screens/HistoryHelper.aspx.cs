using Diet.Business.Core;
using Diet.Business.Core.ModDietMaster;
using Diet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GNHClientUI
{
    public partial class HistoryHelper : System.Web.UI.Page
    {
        public static DataSet dtSearchMaster = null;
        public static DietMasterManager master = new DietMasterManager();
        //static int i = 0; 	// I will use this for creating unique accordion panes
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string[] GetHistoryDetails()
        {

            return getHistoryDetails();
        }

        private static string[] getHistoryDetails()
        {
            string[] result = null;
            int i = 0;
            StringBuilder sb = new StringBuilder();
            dtSearchMaster = new DataSet();
            dtSearchMaster = master.GetDietMaster_History(Convert.ToInt32(HttpContext.Current.Session["PatientID"]));
            if (dtSearchMaster.Tables[0].Rows.Count == 0)
                result = new string[] { "<div class='page-header'><h3>Client Visits</h3></div><div id='Nodatadiv' style='display: block; color: rgb(128, 137, 160);' class='align-center'><h4>No visits found</h4></div>" };
            else
            {
                sb.Append(" <div class='panel-group' id='accordion'>");
                foreach (DataRow dr in dtSearchMaster.Tables[0].Rows)
                {
                    sb.Append("<div class='panel panel-info'>");
                    sb.Append("<div class='panel-heading'>");
                    sb.Append("<h4 class='panel-title'>");
                    sb.Append("<a data-toggle='collapse' data-parent='#accordion' href='#accordion_" + String.Format("{0:MMMddyyyyHHmm}", Convert.ToDateTime(dr["CDdtUpdated"])) + "'>" + String.Format("{0:dd-MMM-yyyy(HH:MM)}", Convert.ToDateTime(dr["CDdtUpdated"])) + "</a>");
                    sb.Append("</h4></div>");
                    sb.Append("<div id='accordion_" + String.Format("{0:MMMddyyyyHHmm}", Convert.ToDateTime(dr["CDdtUpdated"])) + "' class='panel-collapse collapse'>");
                    sb.Append("<div class='panel-body'>");
                    sb.Append(bindhistory(i, String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dr["CDdtUpdated"])), String.Format("{0:yyyy-MM-dd HH:mm:ss}", Convert.ToDateTime(dr["CDdtUpdated"]))));
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    ++i;
                }
                sb.Append("</div>");
                result = new string[] { sb.ToString().Replace("<p>", "").Replace("</p>", "") }; ;
            }
            return result;
        }

        protected static string bindhistory(int i, string date, string date2)
        {
            int j = 0;
            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
            if (dtSearchMaster.Tables[0].Rows.Count > i)
            {

                strBody.Append("<table align='center' width='100%'><tr><td colspan='4' align='center'><b>" + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDsCustName"]) + " " + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDsLastName"]) + "</b></td></tr>");
                strBody.Append("<tr><td align='left'>Patient ID :" + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDnCustomerIDPK"]) + "</td><td colspan='2'>DOB:" + String.Format("{0:dd-MMM-yyyy}", Convert.ToDateTime(dtSearchMaster.Tables[0].Rows[i]["CDdtDOB"])) + "</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDnCustAge"]) + "Y/" + (Convert.ToString(dtSearchMaster.Tables[0].Rows[i]["CDnGender"]) == "0" ? "M" : "F") + "</td></tr></table>");
                strBody.Append("<hr size='1' width='100%'>");

            }
            //Anthropometics
            for (j = 0; j < dtSearchMaster.Tables[1].Rows.Count; j++)
            {
                if (String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dtSearchMaster.Tables[1].Rows[j]["AMdtUpdated"])).Equals(date))
                {
                    strBody.Append(" <table  align='center' width='100%'><tr><td colspan='3' align='center'><b>Anthropometics</b></td></tr><tr><td align='left'>Measured Wt. " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnMeasWt"]) + " kg</td><td align='right'>BMI " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnCalculatedBMI"]) + "</td><td colspan=2 align='right'>BMI Category " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnBMICat"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Measured Ht. " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnMeasHt"]) + " m</td><td align='right'>MUAC " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnMUAC"]) + "cm</td><td align='right'>Measured Waist " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnMeasWaist"]) + "cm</td></tr>");
                    strBody.Append("<tr><td align='left'>Ideal Body Wt. " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnIdealBodyWt"]) + " kg</td><td align='right'>Neck Circumference " + Convert.ToString(dtSearchMaster.Tables[1].Rows[j]["AMnNeckCircum"]) + "</td><td align='right'></td></tr>");
                    strBody.Append("</table>");
                    break;
                }
            }
            for (j = 0; j < dtSearchMaster.Tables[2].Rows.Count; j++)
            {
                //Bio Chemical Labs
                if (String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dtSearchMaster.Tables[2].Rows[j]["BCLdtUpdated"])).Equals(date))
                {
                    strBody.Append("<hr size='1' width='100%'>");
                    strBody.Append("<table align='center' width='100%'><tr><td colspan='9' align='center'><b>Bio Chemical Labs</b></td></tr>");
                    strBody.Append("<tr><td align='left'>Fasting Glucose</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnFastingGluc"]) + "</td><td align='left'>mg/dL</td>");
                    strBody.Append("<td align='left'>Creatinine</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnCreatinine"]) + "</td><td align='left'>g/dL</td>");
                    strBody.Append("<td align='left'>Albumin</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnAlbumin"]) + "</td><td align='left'>g/dL</td></tr>");
                    strBody.Append("<tr><td align='left'>HbA1C</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnHbA1C"]) + "</td><td align='left'>%</td>");
                    strBody.Append("<td align='left'>ALT (SGPT)</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnAltSGPT"]) + "</td><td align='left'>IU/L</td>");
                    strBody.Append("<td align='left'>ALT (SGOT)</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnAltSGOT"]) + "</td></td><td align='left'>IU/L</td></tr>");
                    strBody.Append("<tr><td align='left'>Hematocrit</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnHematocrit"]) + "</td><td align='left'>(%)</td>");
                    strBody.Append("<td align='left'>Triglycerides</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnTriglycerides"]) + "</td><td align='left'>mg/dL</td>");
                    strBody.Append("<td align='left'>HDL</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnHDL"]) + "</td><td align='left'>mg/dL</td></tr>");
                    strBody.Append("<tr><td align='left'>Total Cholesterol</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnTotCholesterol"]) + "</td><td align='left'>mg/dL</td>");
                    strBody.Append("<td align='left'>Alkaline Phosphatase</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnAlkalinePhosphatase"]) + "</td><td align='left'>IU/L</td>");
                    strBody.Append("<td align='left'>Vitamin D3</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnVitaminD3"]) + "</td><td align='left'></td></tr>");
                    strBody.Append("<tr><td align='left'>Vitamin B12</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLnVitaminB12"]) + "</td><td align='left'></td>");
                    strBody.Append("<td align='left'>Others</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[2].Rows[j]["BCLsOthers"]) + "</td><td align='left'></td></tr></table>");
                    break;
                }
            }
            for (j = 0; j < dtSearchMaster.Tables[3].Rows.Count; j++)
            {

                //COMORBIDITY 
                if (String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dtSearchMaster.Tables[3].Rows[j]["CBdtUpdated"])).Equals(date))
                {
                    strBody.Append("<hr size='1' width='100%'>");
                    strBody.Append("<table align='center' width='100%'><tr><td colspan='4' align='center' ><b>Comorbidity</b></td></tr>");
                    strBody.Append("<tr><td align='left'>CHF :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsCHF"]) + "</td><td>Asthma :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsAsthma"]) + "</td>");
                    strBody.Append("<td>Thyroid :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsThyroid"]) + "</td><td align='right'>IHD :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsIHD"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left' colspan='4'>Functional Status :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsFunctionalStatus"]) + "</td></tr>");
                    strBody.Append("<tr><td colspan='4' align='center'><b>Chronic Diseases</b></td></tr>");
                    strBody.Append("<tr><td align='left'>Diabetes :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsDiabetes"]) + "</td><td>Liver Disorders :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsLeverDis"]) + "</td>");
                    strBody.Append("<td>Hypertension :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsHypertension"]) + "</td><td align='right'>Cardiac Disorders :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsCardiacDis"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Kidney Disorders :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsKidneyDis"]) + "</td><td>Followed Perticular Diet Details :" + Convert.ToString(dtSearchMaster.Tables[3].Rows[j]["CBsParticularProbDet"]) + "</td></tr></table>");
                    break;
                }
            }
            for (j = 0; j < dtSearchMaster.Tables[4].Rows.Count; j++)
            {
                if (String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dtSearchMaster.Tables[4].Rows[j]["DLdtUpdated"])).Equals(date))
                {
                    //Diet And Lifestyle
                    strBody.Append("<hr size='1' width='100%'>");
                    strBody.Append("<table  align='center' width='100%'><tr><td colspan='4' align='center'><b>Diet And Lifestyle</b></td></tr>");
                    strBody.Append("<tr><td align='left'>Regular Execise</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLsRegExersize"]) + "</td><td align='right'>Alcohol</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLsAlcohol"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Smoking</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLsSmoking"]) + "</td><td align='right'>Sleep Hours Per Day</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLnSleepPerDay"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Exercise Detail</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLsExcersizeDetail"]) + "</td><td></td><td></td></tr>");
                    strBody.Append("<tr><td colspan='4' align='left'><b>Diet History</b></td></tr>");
                    strBody.Append("<tr><td align='left'>Diet Type</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsDietType"]) + "</td><td align='right'>Eat When Stress</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsStressEat"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Frequency Of Outside Eat</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsFreqOutEat"]) + "</td><td align='right'>Eat When Bored</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsBoredEat"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Typical Meal in Day</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHnTypicalMealDay"]) + "</td><td align='right'>Do You Have Breakfast Everyday</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsBreakfast"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Typical Snax in Day</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHnTypicalSnaxDay"]) + "</td><td align='right'>Eat when watching TV	</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsWatchTVEat"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Caloric Beverages</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsCaloricbeverages"]) + "</td><td align='right'>Tried Wt. Loss Diet Before</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsWtLossDiet"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Wt. Loss/Gain in Sixth Month</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DHsWtLossGainSixMon"]) + "</td><td></td><td></td></tr>");
                    strBody.Append("<tr><td colspan='6' align='left'><b>Fat and Oil</b></td></tr>");
                    strBody.Append("<tr><td align='left'>Oil Detail</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLsOilUseDetail"]) + "</td><td align='right'>Oil Quantity in Month</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLnOilQuantityMonth"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>No of Family Members</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLnMembersInFamily"]) + "</td><td align='right'>Sugar Quantity in Month</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[4].Rows[j]["DLnSugarQuantity"]) + "</td></tr></table>");
                    break;
                }
            }
            for (j = 0; j < dtSearchMaster.Tables[5].Rows.Count; j++)
            {
                //Clinical Complaints
                if (String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dtSearchMaster.Tables[5].Rows[j]["CCdtUpdated"])).Equals(date))
                {
                    strBody.Append("<hr size='1' width='100%'>");
                    strBody.Append("<table align='center' width='100%'><tr><td colspan='6' align='center'><b>Clinical Complaints</b></td></tr>");
                    strBody.Append("<tr><td colspan='6' align='left'><b>Gastrointestinal Problems</b></td></tr>");
                    strBody.Append("<tr><td align='left'>Heartburn </td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsHeartburn"]) + "</td><td align='right'>Vomiting</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsVomiting"]) + "</td>");
                    strBody.Append("<td align='right'>Bloating</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsBloating"]) + "</td><tr><tr><td align='left'>Use Any Luxative/Antacid</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsConstipation"]) + "</td>");
                    strBody.Append("<td align='right'>Gas</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsGas"]) + "</td><td align='right'>Constipation</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsLaxaAnta"]) + "</td></tr>");
                    strBody.Append("<tr><td align='left'>Diarrhoea</td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsDiarrhoea"]) + "</td><td align='right'>Follow Home Remedy</td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["GPsHomeRem"]) + "</td></tr>");
                    strBody.Append("<td colspan='4' align='left'><b>Medication</b></td></tr>");
                    strBody.Append("<tr><td align='left'>Vitamin Suplement </td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["MCsVitaminSup"]) + "</td><td align='right'>Vitamin Suplement Details</td> <td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["MCsVitaminSupDet"]) + "</td>");
                    strBody.Append("<td align='right'>Mineral Suplement </td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["MCsMineralSup"]) + "</td></tr><tr><td align='left'>Mineral Suplement Details </td><td align='left'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["MCsMineralSupDet"]) + "</td>");
                    strBody.Append("<td align='right'>Oral Drug Type </td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["MCsOralDrugType"]) + "</td><td align='right'>Oral Drug  Details </td><td align='right'>" + Convert.ToString(dtSearchMaster.Tables[5].Rows[j]["MCsOralDrugDet"]) + "</td></tr></table>");
                    break;
                }
            }
            ///Recall diet Details
            DataTable dtFoodListWithID = new FoodMasterManager().GetFoodListWithID();
            //Get Customer Recall Diet Details
            int custID = Convert.ToInt32(HttpContext.Current.Session["PatientID"]);
            int k = 0;
            DataTable dtRecallDietDetail = new DataTable();
            dtRecallDietDetail = new RecallDietManager().GetRecallDietDetailsHistory(custID, date2);
            if (dtRecallDietDetail.Rows.Count > 0)
            {
                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table width=90%><tr><td><b>Recall Diet</b></td></tr></table><br/>");
                strBody.Append("<table border=1 width=90%  align=center cellpadding='2'><tr><td align=center><b>Meals</b></td><td align=center><b>Meal Details</b></td><td align=center><b>Diet Chart</b></td></tr>");

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
                        string remark = string.Empty;
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
                            remark = remark + ("&nbsp;&nbsp;"+Convert.ToString(strFoodItemDetail[3]) + "<br/>");
                        }
                        //strBody.Append("</td></tr></table>");
                        if (strMealFoodDetails.Count() > 0)
                            strBody.Append("</ul></td><td>" + remark + "</td></tr>");
                    }
                    strBody.Append("</table>");
                }
            }

            //Recommended Diet
            DataTable dtRecommendedDietDetail = new DataTable();
            dtRecommendedDietDetail = new RecommendedDietManager().GetRecommendedDietDetailsHistory(custID, date2);
            List<RecommendedDietDetails> lstRecommendedDietDetails = new List<RecommendedDietDetails>();
            if (dtRecommendedDietDetail.Rows.Count > 0)
            {
                strBody.Append("<hr size='1' width='100%'>");
                strBody.Append("<table width=90%><tr><td><b>Recommended Diet</b></td></tr></table><br/>");
                strBody.Append("<table border=1 width=90% align=center cellpadding='2'><tr><td align=center><b>Meals</b></td><td align=center><b>Meal Details</b></td><td align=center><b>Diet Chart</b></td></tr>");

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
                        string remark = string.Empty;
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
                            remark = remark + ("&nbsp;&nbsp;" + Convert.ToString(strFoodItemDetail[3]) + "<br/>");
                        }
                        if (strMealFoodDetails.Count() > 0)
                            strBody.Append("</ul></td><td>" + remark + "</td></tr>");
                    }
                    strBody.Append("</table>");
                }
            }

            return strBody.ToString();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string[] GetRecommendedDetails()
        {

            return getRecommendedDetails();
        }

        private static string[] getRecommendedDetails()
        {
            string[] result = null;
            int i = 0;
            StringBuilder sb = new StringBuilder();
            dtSearchMaster = new DataSet();
            dtSearchMaster = master.GetDietMaster_History(Convert.ToInt32(HttpContext.Current.Session["PatientID"]));
            if (dtSearchMaster.Tables[0].Rows.Count == 0)
                result = new string[] { "<div><h5><b>Recommended Diet History</b></h5></div><div id='Nodatadiv' style='display: block; color: rgb(128, 137, 160);' class='align-center'><h4>No history diet found</h4></div>" };
            else
            {
                sb.Append("<div><h5><b>Recommended Diet History</b></h5></div>");
                sb.Append("<div id='tabs2' class='patient-detailsl-tabs'>");
                sb.Append("<div class='patient-detailsl-tabs-block' style='overflow: auto;'>");
                sb.Append("<ul class='nav nav-tabs' style='width: 90%;'>");
                foreach (DataRow dr in dtSearchMaster.Tables[0].Rows)
                {
                    if (i == 0)
                        sb.Append("<li class='active'><a href='#tabs_" + String.Format("{0:MMMddyyyyHHmm}", Convert.ToDateTime(dr["CDdtUpdated"])) + "' data-toggle='tab'>" + String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dr["CDdtUpdated"])) + "</a></li>");
                    else
                        sb.Append("<li><a href='#tabs_" + String.Format("{0:MMMddyyyyHHmm}", Convert.ToDateTime(dr["CDdtUpdated"])) + "' data-toggle='tab'>" + String.Format("{0:dd-MMM-yyyy(HH:mm)}", Convert.ToDateTime(dr["CDdtUpdated"])) + "</a></li>");
                    ++i;
                }
                sb.Append("</ul></div>");
                sb.Append("<div class='tab-content'>");
                i = 0;
                foreach (DataRow dr in dtSearchMaster.Tables[0].Rows)
                {
                    if (i == 0)
                        sb.Append("<div id='tabs_" + String.Format("{0:MMMddyyyyHHmm}", Convert.ToDateTime(dr["CDdtUpdated"])) + "'class='tab-pane fade in active'>");
                    else
                        sb.Append("<div id='tabs_" + String.Format("{0:MMMddyyyyHH}", Convert.ToDateTime(dr["CDdtUpdated"])) + "'class='tab-pane fade'>");
                    sb.Append(bindRecommended(i, String.Format("{0:yyyy-MM-dd HH:mm:ss}", Convert.ToDateTime(dr["CDdtUpdated"]))));
                    sb.Append("</div>");
                    ++i;
                }
                sb.Append("</div>");
                sb.Append("</div>");
                result = new string[] { sb.ToString().Replace("<p>", "").Replace("</p>", "") }; ;
            }
            return result;
        }

        protected static string bindRecommended(int i, string date)
        {
            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");

            DataTable dtFoodListWithID = new FoodMasterManager().GetFoodListWithID();
            //Get Customer Recall Diet Details
            int custID = Convert.ToInt32(HttpContext.Current.Session["PatientID"]);
            int k = 0;

            //Recommended Diet
            DataTable dtRecommendedDietDetail = new DataTable();
            dtRecommendedDietDetail = new RecommendedDietManager().GetRecommendedDietDetailsHistory(custID, date);
            List<RecommendedDietDetails> lstRecommendedDietDetails = new List<RecommendedDietDetails>();
            if (dtRecommendedDietDetail.Rows.Count > 0)
            {
                //strBody.Append("<hr size='1' width='100%'>");
                //strBody.Append("<table width=90%><tr><td><b>Recommended Diet</b></td></tr></table><br/>");
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
                        if (strMealFoodDetails.Count() > 0)
                            strBody.Append("</ul></td></tr>");
                    }
                    strBody.Append("</table>");
                }
            }

            return strBody.ToString();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string[] GetPrintDetails(string FileName)
        {

            return getPrintDetails(FileName);
        }

        private static string[] getPrintDetails(string FileName)
        {
            return new string[] { System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory + "Download/" + FileName + ".htm") };
        }

    }
}