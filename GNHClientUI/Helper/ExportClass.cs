using Diet.Business.Core;
using Diet.Business.Model;
using Diet.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Linq;
using Diet.Business.Core.ModDietMaster;

namespace GNHClientUI.Helper
{
    public class ExportClass
    {
        string[] splitString = { "@|@" };
        public ExportClass()
        {

        }

        public string ClientReport(DietMaster objDietMaster, string PatientID)
        {
            double ProteinTotal = 0, CalorieTotal = 0;
            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
            System.Text.StringBuilder strBody1 = new System.Text.StringBuilder("");
            strBody.Append("<html<head><title></title>");
            // The setting specifies document's view after it is downloaded as Print
            // instead of the default Web Layout
            strBody.Append("<style>");
            strBody.Append("table{ margin-left:2%; width:88%; }");
            strBody.Append("td{padding:5px; font-family:verdana; font-size:10pt;}");
            strBody.Append(".first{width:250px;font-weight:700; }");
            strBody.Append(".second{}");
            strBody.Append(".mcomplaint{line-height:22px;}");
            strBody.Append(".thead{background-color:darkred;color:floralwhite;}");
            strBody.Append(".rowcontent{text-align: left;}");
            strBody.Append(".firstu{width:350px; text-align:start; font-weight:700; }");
            strBody.Append(".secondu{}");
            strBody.Append(".middleu{}");
            // strBody.Append("<link rel='stylesheet' type='text/css' href ='mystyle.css'>");
            strBody.Append("@media print {.page-break  { display: block; page-break-before: always; }} table {font-family: Calibri; font-size: 18px; font-size: x-medium } @media print {thead {display: table-header-group;}}</style>");

            strBody.Append("</head>");
            //strBody.Append("<h3 align='center' color='black'>PH_CLINIC</h3>");
            strBody.Append("<h4 align='center' color='black'><u>PH_REPORT</u></h4>");

            //Client Info
            strBody.Append("<table cellspacing='0px' border='1'><tr><td colspan='2' align='right'>Date : " + DateTime.UtcNow.AddHours(5.5).ToString("dd-MMM-yyyy") + "</td></tr>");
            strBody.Append("<tr><td class='first'  align='left'>Name  </td>");
            strBody.Append("<td class='second'>" + objDietMaster.CustomerName + " " + objDietMaster.MiddleName + " " + objDietMaster.LastName + "</td></tr>");
            strBody.Append("<tr><td class='first' align='left'>ID  </td>");
            strBody.Append("<td class='second'>" + objDietMaster.CustomerID + "</td></tr>");

            if (!string.IsNullOrEmpty(objDietMaster.CustomerAge.ToString()))
            {
                strBody.Append("<tr><td class='first' align='left'>Age  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.CustomerAge + "</td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.MeasuredWeight.ToString()) && !objDietMaster.MeasuredWeight.ToString().Equals("0"))
            {
                strBody.Append("<tr><td  class='first' align='left'>Wt.  </td>");
                strBody.Append("<td class='second' >" + objDietMaster.MeasuredWeight + " kg</td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.MeasuredHeight.ToString()) && !objDietMaster.MeasuredHeight.ToString().Equals("0"))
            {
                strBody.Append("<tr><td class='first' align='left'>Ht.  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.MeasuredHeight * 100 + " Cm</td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.CalculatedBMI.ToString()) && !objDietMaster.CalculatedBMI.ToString().Equals("0"))
            {
                strBody.Append("<tr><td class='first' align='left'>BMI  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.CalculatedBMI + " kg/m<sup>2</sup></td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.FatPer.ToString()) && !objDietMaster.FatPer.ToString().Equals("0"))
            {
                strBody.Append("<tr><td class='first' align='left'>Fat %  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.FatPer + " %</td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.MussleMass.ToString()) && !objDietMaster.MussleMass.ToString().Equals("0"))
            {
                strBody.Append("<tr><td class='first' align='left'>Mussle Mass  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.MussleMass + " Kg</td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.IdealBodyWeight.ToString()) && !objDietMaster.IdealBodyWeight.ToString().Equals("0"))
            {
                strBody.Append("<tr><td class='first' align='left'>Ideal Body Weight.  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.IdealBodyWeight + " kg</td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.MeasuredWaist.ToString()) && !objDietMaster.MeasuredWaist.ToString().Equals("0"))
            {
                strBody.Append("<tr><td class='first' align='left'>Waist Circumference  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.MeasuredWaist * 100 + " Cm (Normal Range:Male-94 Cm ,Female-80 Cm)</td></tr>");
            }

            if (!string.IsNullOrEmpty(objDietMaster.VisceralFat.ToString()) && !objDietMaster.VisceralFat.ToString().Equals("0"))
            {
                strBody.Append("<tr><td  class='first' align='left'>Visceral Fat </td>");
                strBody.Append("<td class='second'>" + objDietMaster.VisceralFat + " </td></tr>");
            }
            if (!string.IsNullOrEmpty(objDietMaster.AnthrpometricsNotes.ToString()))
            {
                strBody.Append("<tr><td class='first' align='left'>Remark  </td>");
                strBody.Append("<td class='second'>" + objDietMaster.AnthrpometricsNotes.Replace("\n", "<br/>") + " </td></tr>");
            }

            strBody.Append("</table><br/>");

            strBody.Append("<table id='mcomplaint' border='1' cellspacing='0px'><tr><td class='thead'><b>Medical complaints:</b></td></tr><tr><td class='rowcontent'><ol><li>BMI : " + objDietMaster.BMICategory + "</li>");
            string weighlossgain = objDietMaster.WeightGainLossMonth >= 0 ? (objDietMaster.WeightGainLossMonth == 0 ? "No weight gain and loss" : "Recent weight gain") : "Recent Weight loss";
            strBody.Append("<li>" + weighlossgain + "</li>");
            if (objDietMaster.Thyroid.ToString().ToUpper() == "YES")
                strBody.Append("<li>" + objDietMaster.ThyroidType.ToString() + "</li>");

            //BioChemical Complaints
            if (!objDietMaster.FastingGlucose.ToString().Equals("-1"))
                strBody1.Append("<li>Fasting Glucose :" + (objDietMaster.FastingGlucose.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.FastingGlucose)) + "mg/dL");
            if (!objDietMaster.PP.ToString().Equals("-1"))
                strBody1.Append("<li>PP :" + (objDietMaster.PP.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.PP)) + "mg/dL");
            if (!objDietMaster.HB.ToString().Equals("-1"))
                strBody1.Append("<li>HB :" + (objDietMaster.HB.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.HB)) + "g/dL");
            if (!objDietMaster.Creatinine.ToString().Equals("-1"))
                strBody1.Append("<li>Creatinine :" + (objDietMaster.Creatinine.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.Creatinine)) + " g/dL");
            if (!objDietMaster.Albumin.ToString().Equals("-1"))
                strBody1.Append("<li>Albumin :" + (objDietMaster.Albumin.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.Albumin)) + " g/dL");
            if (!objDietMaster.HbA1C.ToString().Equals("-1"))
                strBody1.Append("<li>HbA1C :" + (objDietMaster.HbA1C.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.HbA1C)) + " %");
            if (!objDietMaster.AltSGPT.ToString().Equals("-1"))
                strBody1.Append("<li>ALT (SGPT) :" + (objDietMaster.AltSGPT.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.AltSGPT)) + " IU/L");
            if (!objDietMaster.AltSGOT.ToString().Equals("-1"))
                strBody1.Append("<li>ALT (SGOT) :" + (objDietMaster.AltSGOT.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.AltSGOT)) + " IU/L");
            if (!objDietMaster.Hematocrit.ToString().Equals("-1"))
                strBody1.Append("<li>Hematocrit :" + (objDietMaster.Hematocrit.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.Hematocrit)) + " %");
            if (!objDietMaster.Triglycerides.ToString().Equals("-1"))
                strBody1.Append("<li>Triglycerides :" + (objDietMaster.Triglycerides.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.Triglycerides)) + " mg/dL");
            if (!objDietMaster.TSH.ToString().Equals("-1"))
                strBody1.Append("<li>TSH :" + (objDietMaster.TSH.ToString().ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.TSH)) + " U/ml");
            if (!objDietMaster.HDL.ToString().Equals("-1"))
                strBody1.Append("<li>HDL :" + (objDietMaster.HDL.ToString().ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.HDL)) + " mg/dL");
            if (!objDietMaster.LDL.ToString().Equals("-1"))
                strBody1.Append("<li>LDL :" + (objDietMaster.LDL.ToString().ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.LDL)) + " mg/dL");
            if (!objDietMaster.UricAcid.ToString().Equals("-1"))
                strBody1.Append("<li>Uric Acid :" + (objDietMaster.UricAcid.ToString().ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.UricAcid)) + " mg/dL");
            if (!objDietMaster.TotalCholesterol.ToString().Equals("-1"))
                strBody1.Append("<li>Total Cholesterol :" + (objDietMaster.TotalCholesterol.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.TotalCholesterol)) + " mg/dL");
            if (!objDietMaster.AlkalinePhosphatase.ToString().Equals("-1"))
                strBody1.Append("<li>Alkaline Phosphatase :" + (objDietMaster.AlkalinePhosphatase.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.AlkalinePhosphatase)) + " IU/L");
            if (!objDietMaster.VitaminD3.ToString().Equals("-1"))
                strBody1.Append("<li>Vitamin D3 :" + (objDietMaster.VitaminD3.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.VitaminD3)) + "ng/L");
            if (!objDietMaster.VitaminB12.ToString().Equals("-1"))
                strBody1.Append("<li>Vitamin B12 :" + (objDietMaster.VitaminB12.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.VitaminB12)) + "ng/L");
            if (!objDietMaster.BSL.ToString().Equals("-1"))
                strBody1.Append("<li>Random BSL :" + (objDietMaster.BSL.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.BSL)) + "mg/dl");
            if (!objDietMaster.Platelet.ToString().Equals("-1"))
                strBody1.Append("<li>Platelet :" + (objDietMaster.Platelet.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.Platelet)));
            if (!objDietMaster.RBC.ToString().Equals("-1"))
                strBody1.Append("<li>RBC :" + (objDietMaster.RBC.ToString().Equals("-1") ? "Normal" : Convert.ToString(objDietMaster.RBC)));
            if (!string.IsNullOrEmpty(objDietMaster.BioChemicalLabNotes.ToString()))
                strBody1.Append("<li>Remark :" + objDietMaster.BioChemicalLabNotes.Replace("\n", "<br/>"));
            if (!string.IsNullOrEmpty(objDietMaster.OthersBioChemicalLabs.ToString()))
                strBody1.Append("<li>Others :" + objDietMaster.OthersBioChemicalLabs.Replace("\n", "<br/>"));

            if (!string.IsNullOrEmpty(strBody1.ToString()))
            {
                strBody.Append("<li>BioChemical Findings");
                strBody.Append("<ul type='square'>" + strBody1 + "</ul>");
            }
            //Comorbidity
            strBody.Append("<li>Comorbidity");
            strBody.Append("<ul type='square'>");
            if (!string.IsNullOrEmpty(objDietMaster.CHF) && !objDietMaster.CHF.ToUpper().Equals("NO"))
                strBody.Append("<li>CHF :" + objDietMaster.CHF);
            if (!string.IsNullOrEmpty(objDietMaster.Asthma) && !objDietMaster.Asthma.ToUpper().Equals("NO"))
                strBody.Append("<li>Asthma :" + objDietMaster.Asthma);
            if (!string.IsNullOrEmpty(objDietMaster.SleepApnea) && !objDietMaster.SleepApnea.ToUpper().Equals("NO"))
                strBody.Append("<li>Sleep Apnea :" + objDietMaster.SleepApnea);
            if (!string.IsNullOrEmpty(objDietMaster.IHD) && !objDietMaster.IHD.ToUpper().Equals("NO"))
                strBody.Append("<li>IHD :" + objDietMaster.IHD);
            //if (!string.IsNullOrEmpty(objDietMaster.FunctionalStatus))
            //    strBody.Append("<li>Functional Status :" + objDietMaster.FunctionalStatus);
            if (!string.IsNullOrEmpty(objDietMaster.Diabetes) && !objDietMaster.Diabetes.ToUpper().Equals("NO"))
                strBody.Append("<li>Diabetes :" + objDietMaster.Diabetes);
            if (!string.IsNullOrEmpty(objDietMaster.LeverDisorders) && !objDietMaster.LeverDisorders.ToUpper().Equals("NO"))
                strBody.Append("<li>Liver Disorders :" + objDietMaster.LeverDisorders);
            if (!string.IsNullOrEmpty(objDietMaster.Hypertension) && !objDietMaster.Hypertension.ToUpper().Equals("NO"))
                strBody.Append("<li>Hypertension :" + objDietMaster.Hypertension);
            if (!string.IsNullOrEmpty(objDietMaster.CardiacDisorders) && !objDietMaster.Hypertension.ToUpper().Equals("NO"))
                strBody.Append("<li>Cardiac Disorders :" + objDietMaster.CardiacDisorders);
            if (!string.IsNullOrEmpty(objDietMaster.KidneyDisorders) && !objDietMaster.KidneyDisorders.ToUpper().Equals("NO"))
                strBody.Append("<li>Kidney Disorders :" + objDietMaster.KidneyDisorders);
            if (!string.IsNullOrEmpty(objDietMaster.ComorbidityNotes))
                strBody.Append("<li>Remark :" + objDietMaster.ComorbidityNotes);
            if (!string.IsNullOrEmpty(objDietMaster.ComorbidityOthers))
                strBody.Append("<li>Others :" + objDietMaster.ComorbidityOthers.Replace("\n", "<br/>"));
            strBody.Append("</ul></li>");


            //Clinical Complaints
            strBody.Append("<li>Clinical Complaints</li>");
            strBody.Append("<ul type='square'>");
            if (!string.IsNullOrEmpty(objDietMaster.Heartburn) && !objDietMaster.Heartburn.ToUpper().Equals("NO"))
                strBody.Append("<li>Heartburn :" + objDietMaster.Heartburn);
            if (!string.IsNullOrEmpty(objDietMaster.Vomiting) && !objDietMaster.Vomiting.ToUpper().Equals("NO"))
                strBody.Append("<li>Vomiting" + objDietMaster.Vomiting);
            if (!string.IsNullOrEmpty(objDietMaster.Bloating) && !objDietMaster.Bloating.ToUpper().Equals("NO"))
                strBody.Append("<li>Bloating :" + objDietMaster.Bloating);
            if (!string.IsNullOrEmpty(objDietMaster.LaxativeAntacide) && !objDietMaster.LaxativeAntacide.ToUpper().Equals("NO"))
                strBody.Append("<li>Use Any Luxative/Antacid :" + objDietMaster.LaxativeAntacide);
            if (!string.IsNullOrEmpty(objDietMaster.Gas) && !objDietMaster.Gas.ToUpper().Equals("NO"))
                strBody.Append("<li>Gas :" + objDietMaster.Gas);
            if (!string.IsNullOrEmpty(objDietMaster.Constipation) && !objDietMaster.Constipation.ToUpper().Equals("NO"))
                strBody.Append("<li>Constipation :" + objDietMaster.Constipation);
            if (!string.IsNullOrEmpty(objDietMaster.Diarrhoea) && !objDietMaster.Diarrhoea.ToUpper().Equals("NO"))
                strBody.Append("<li>Diarrhoea :" + objDietMaster.Diarrhoea);
            if (!string.IsNullOrEmpty(objDietMaster.HomeRemedy) && !objDietMaster.HomeRemedy.ToUpper().Equals("NO"))
                strBody.Append("<li>Follow Home Remedy :" + objDietMaster.HomeRemedy);
            if (!string.IsNullOrEmpty(objDietMaster.TakeVitaminSup) && !objDietMaster.TakeVitaminSup.ToUpper().Equals("NO"))
            {
                strBody.Append("<li>Vitamin Suplement :" + objDietMaster.TakeVitaminSup);
                if (!string.IsNullOrEmpty(objDietMaster.VitaminSupDet))
                    strBody.Append("<li>Vitamin Suplement Details :" + objDietMaster.VitaminSupDet);
            }
            if (!string.IsNullOrEmpty(objDietMaster.TakeMineralSup) && !objDietMaster.TakeMineralSup.ToUpper().Equals("NO"))
            {
                strBody.Append("<li>Mineral Suplement :" + objDietMaster.TakeMineralSup);
                if (!string.IsNullOrEmpty(objDietMaster.MineralSupDet))
                    strBody.Append("<li>Mineral Suplement Details :" + objDietMaster.MineralSupDet);
            }
            if (!string.IsNullOrEmpty(objDietMaster.OralDrugDType) && !objDietMaster.OralDrugDType.ToUpper().Equals("NO"))
            {
                strBody.Append("<li>Oral Drug Type :" + objDietMaster.OralDrugDType);
                if (!string.IsNullOrEmpty(objDietMaster.OralDrugDet))
                    strBody.Append("<li>Oral Drug  Details :" + objDietMaster.OralDrugDet);
            }
            if (!string.IsNullOrEmpty(objDietMaster.ClinicComplaintsNotes))
                strBody.Append("<li>Remark :" + objDietMaster.ClinicComplaintsNotes.Replace("\n", "<br/>"));
            strBody.Append("</ul>");
            strBody.Append("</ol></td></tr></table><br/>");

            strBody.Append("<table width=100% border='1' cellspacing='0px'><tr class='thead'><td>Diet Type:" + objDietMaster.DietType + "</td></tr>");
            if (!string.IsNullOrEmpty(objDietMaster.ExcersizeDetail))
                strBody.Append("<tr><td>Exercise Details:</td></tr><tr><td>" + objDietMaster.ExcersizeDetail + "</td></tr>");
            strBody.Append("<tr><td class='thead'><b>Medical Nutrition Therapy</b></td></tr><tr><td class='rowcontent'><ol contenteditable='true'><li>Calorie Management:&nbsp;CALORIE_TOTAL</li><li>Protein Management:&nbsp;PROTEIN_TOTAL</li>");
            if (objDietMaster.WeightGainLossMonth != 0)
            {
                strBody.Append("<li>Prevent further " + (objDietMaster.WeightGainLossMonth > 0 ? "weight gain" : "Weight loss") + "</li>");
            }
            if (objDietMaster.Thyroid.ToString().ToUpper() == "YES")
                strBody.Append("<li>control " + objDietMaster.ThyroidType.ToString() + " through Medical management and MNT</li>");
            strBody.Append("</td></tr></table>");
            strBody.Append("<table width=100%><tr><td class='thead'><b> &nbsp;Other Nutrients :</b></td></tr><tr><td class='rowcontent'>Balanced Nutrients as per Recommended Dietary Allowances </td></tr></table><br/><br/>");
            //strBody.Append("<table width=100%><tr><td><b>Diet Recall </b></td></tr></table>");

            DataTable dtFoodListWithID = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT  FMnFoodID FoodID,FMsFoodname FoodName,(select FGsGroupName from FoodGroupMaster where FGnGroupId=FMsFoodType) 'FoodType' FROM FoodMaster", con);
                da.Fill(dtFoodListWithID);
            }


            DataTable dtFoodGroupImages = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM FoodGroupMaster", con);
                da.Fill(dtFoodGroupImages);
            }
            ////Get Customer Recall Diet Details
            int custID = Convert.ToInt32(PatientID);
            int i = 0;

            //strBody.Append("<div style='page-break-before: always;'>");
            if (!string.IsNullOrEmpty(objDietMaster.GrainsServings) || !string.IsNullOrEmpty(objDietMaster.DalsServings) || !string.IsNullOrEmpty(objDietMaster.MilkServings) || !string.IsNullOrEmpty(objDietMaster.NonvegServings) || !string.IsNullOrEmpty(objDietMaster.VegetablesServings)
                || !string.IsNullOrEmpty(objDietMaster.FruitsServings) || !string.IsNullOrEmpty(objDietMaster.SugarServings) || !string.IsNullOrEmpty(objDietMaster.WaterServings) || !string.IsNullOrEmpty(objDietMaster.BiscuitServings))
            {
                strBody.Append("<p style='page-break-before: always;'>&nbsp;</p><table width='90%'><tbody><tr><td><b>Dietary allowance recommended / day:</b></td></tr></tbody></table>");
                strBody.Append("<table border='1' width='90%' style='border-collapse: collapse;margin-top: 20px;' bordercolor='black'><thead><tr><th style='text-align: center' width='30%'>Food Group</th><th style='text-align: center' width='70%'>Servings</th></tr></thead>");
                //<th style='text-align: center'>Images</th></tr>");
                strBody.Append("<tr><td class='firstu'>Grains and Cereals</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.GrainsServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("GRAINS AND CEREALS")).First().Field<string>("FGsDefaultText") : objDietMaster.GrainsServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("GRAINS AND CEREALS") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("GRAINS AND CEREALS")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Dals Pulses and Legumes</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.DalsServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("DALS PULSES AND LEGUMES")).First().Field<string>("FGsDefaultText") : objDietMaster.DalsServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("DALS PULSES AND LEGUMES") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("DALS PULSES AND LEGUMES")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Milk and Milk Products</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.MilkServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("MILK AND MILK PRODUCTS")).First().Field<string>("FGsDefaultText") : objDietMaster.MilkServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("MILK AND MILK PRODUCTS") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("MILK AND MILK PRODUCTS")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Non-vegetarian foods</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.NonvegServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("NON-VEGETARIAN FOODS")).First().Field<string>("FGsDefaultText") : objDietMaster.NonvegServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("NON-VEGETARIAN FOODS") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("NON-VEGETARIAN FOODS")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Vegetables</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.VegetablesServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("VEGETABLES")).First().Field<string>("FGsDefaultText") : objDietMaster.VegetablesServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("VEGETABLES") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("VEGETABLES")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Fruits</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.FruitsServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FRUITS")).First().Field<string>("FGsDefaultText") : objDietMaster.FruitsServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FRUITS") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FRUITS")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Sugar</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.SugarServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("SUGAR")).First().Field<string>("FGsDefaultText") : objDietMaster.SugarServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("SUGAR") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("SUGAR")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Fat</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.FatServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FAT")).First().Field<string>("FGsDefaultText") : objDietMaster.FatServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FAT") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("FAT")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Water</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + (string.IsNullOrEmpty(objDietMaster.WaterServings) ? dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("WATER")).First().Field<string>("FGsDefaultText") : objDietMaster.WaterServings).Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("WATER") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("WATER")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("<tr><td class='firstu'>Miscellaneous</td>");
                strBody.Append("<td class='secondu'><p contenteditable='true'>" + objDietMaster.BiscuitServings.Replace("\n", "<br/>") + "</p></td>");
                //if (dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("BISCUIT") && !string.IsNullOrEmpty(Convert.ToString(x["FGsImage"]))).Count() > 0)
                //    strBody.Append("<td><img src='../Upload/FoodGroup/" + dtFoodGroupImages.AsEnumerable().Where(x => Convert.ToString(x["FGsGroupName"]).ToUpper().Equals("BISCUIT")).First().Field<string>("FGsImage") + "' height=50px width=50px></td></tr>");
                //else
                //    strBody.Append("<td></td></tr>");
                strBody.Append("</tr>");
                strBody.Append("</table><br/>");
            }
            //strBody.Append("</div>");

            strBody.Append("<table width=90% border='1' cellspacing='0px'><tr><td class='thead'><b>Meal Plan</b></td></tr></table><br/>");
            //strBody.Append("<table width=90%><tr><td>You are recommended to follow a <b>CALORIE_TOTAL</b> Calorie diet plan to reach the desired weight.");
            //strBody.Append("Here is sample menu options to help you understand your diet.</td></tr></table><br/><br/><br/>");
            strBody.Append("<table border='1' width='90%' style='border-collapse: collapse;margin-top: 20px;' bordercolor='black'><thead><tr><th align=center width='10%' bgcolor='darksalmon' ><b>Time</b></th><th align=center width='30%' bgcolor='darksalmon'><b>Exchange</b></th><th align=center width='60%' bgcolor='darksalmon'><b>Diet Chart</b></th></tr></thead>");
            DataTable dtRecommendedDietDetail = new DataTable();

            dtRecommendedDietDetail = new RecommendedDietManager().GetRecommendedDietDetails(custID);

            List<RecommendedDietDetails> lstRecommendedDietDetails = new List<RecommendedDietDetails>();
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
                        //strBody.Append("<tr><td align=center><b><h4>" + "Meal " + mealID + " - " + Convert.ToDateTime(objMealDetails.Time).ToShortTimeString() + "</h4></b></td>");
                        strBody.Append("<tr><td align=center class='firstu' width='20%'><b><h4>" + Convert.ToDateTime(objMealDetails.Time).ToShortTimeString() + "</h4></b></td>");
                    else
                        continue;

                    i = 0;
                    string remark = string.Empty;
                    foreach (String strFoodItem in strMealFoodDetails)
                    {
                        MealFoodDetails objMealFoodDetails = new MealFoodDetails();
                        string[] strFoodItemDetail = strFoodItem.Split(mealFoodItemDetailSeperatingChars, StringSplitOptions.None);

                        var foodRows = dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                        string strFoodName = Convert.ToString(foodRows[0]["FoodName"]);


                        DataTable dtFoodNutrients = new DataTable();
                        dtFoodNutrients = new FoodMasterManager().GetFoodMajorNutrients(strFoodName, Convert.ToDouble(strFoodItemDetail[1]), Convert.ToString(strFoodItemDetail[2]));
                        CalorieTotal += Convert.ToDouble(dtFoodNutrients.Rows[0]["Energy"]);
                        ProteinTotal += Convert.ToDouble(dtFoodNutrients.Rows[0]["Protein"]);

                        if (i == 0)
                            strBody.Append("<td class='middleu' width='40%'>" + strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "<br/>");
                        else
                            strBody.Append(strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "<br/>");
                        i++;
                        remark = remark + (Convert.ToString(strFoodItemDetail[3]) + "<br/>");
                    }
                    strBody.Append("</td><td class='secondu' width='40%'>" + remark + "</td></tr>");
                }
            }
            strBody.Append("</table><br/><br/>");
            //}

            strBody.Append("<p style='page-break-before: always;'>&nbsp;</p><table><tbody><tr><td><b>Things to Remember :</b></td></tr></tbody></table>");
            strBody.Append("<div id='ThingsRemember'><table width=90% border='1' cellspacing='0px'><tr><td class='rowcontent'><ol contenteditable='true'><li>Suspected food allergens are dairy, soy, gluten.(you need to be cautious with these foods.) eat small meals if it doesn't  bother you can increase the intake</li>");
            strBody.Append("<li>Take adequate rest</li><li>Drink water</li><li>If you feel muscle spasms  include calcium supplement's/ and monitor vitamin D and B12</li><li>Exercise:  walk/swim 45 minutes /daily</li></td></tr></table></div>");
            strBody.Append("<table width=90% border='1' cellspacing='0px'><tr><td class='thead'><b>Supplements Advised:</b></td></tr><tr><td class='firstu'> <p id='pgSupplements' onblur='return ManageEditableContents();' contenteditable='true'>Nil{SUPPLEMENTS}</p><br/></td></tr></table>");
            strBody.Append("<table width=90% border='1' cellspacing='0px'><tr><td class='thead'><b>Investigation Advised:</b></td></tr></table><p id='pgInvestigations' onblur='return ManageEditableContents();' contenteditable='true'>{INVESTIGATION}</p><br/>");
            strBody.Append("<table width=90% border='1' cellspacing='0px'><tr><td class='thead'><b>Follow up date :</b></td></tr><tr><td class='firstu'><p contenteditable='true'>After 15 days with weight and improvement symptoms.</p></td></tr></table><br/><br/>");
            strBody.Append("<table width=90% border='1' cellspacing='0px'><tr><td>PH_USER</td></tr><tr><td>Consultant Nutritionist & Registered Dietician</td></tr><tr><td class='firstu'>PH_CLINIC</td></tr><tr><td class='firstu'><p contenteditable='true'>Mob No:&nbsp;PH_MOB</p><br/><br/></td></tr></table>");
            strBody.Append("</div>");
            strBody.Append("</div>");
            //</body></html>");
            //strBody.Replace("CALORIE_TOTAL", Convert.ToString(CalorieTotal) + " (g)");
            //strBody.Replace("PROTEIN_TOTAL", Convert.ToString(ProteinTotal) + " (kcal)");
            return strBody.ToString();
        }

    }
}